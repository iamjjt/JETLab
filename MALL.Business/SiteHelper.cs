using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using JETLib.Common;
namespace Mall.Business
{
    /// <summary>
    /// 网站帮助类
    /// </summary>
    public static class SiteHelper
    {
        private static Random rd = new Random(DateTime.Now.Millisecond);
        private static string _root = "Uploadfiles/";

        #region 取得随机文件名
        /// <summary>
        /// 取得随机文件名
        /// </summary>
        /// <returns>eg：201203070901121234</returns>
        public static string GetFileName()
        {
            DateTime Today = DateTime.Now;
            StringBuilder FileName = new StringBuilder();
            return FileName.Append(Today.Year).Append(Today.Month.ToString().PadLeft(2, '0')).Append(Today.Day.ToString().PadLeft(2, '0'))
                .Append(Today.Hour.ToString().PadLeft(2, '0')).Append(Today.Minute.ToString().PadLeft(2, '0'))
                .Append(Today.Second.ToString().PadLeft(2, '0')).Append(rd.Next(1000, 9999)).ToString();
        }
        #endregion

        #region 取得文件夹目录

        private static string GetChildDir()
        {
            return GetDirByMonth();
        }

        /// <summary>
        /// 取得根目录物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath()
        {
            return System.Web.HttpContext.Current.Server.MapPath("~/");
        }
        /// <summary>
        /// 取得新闻图片存放目录
        /// eg:uploadfiles/News/2012-03/09/
        /// </summary>
        /// <returns></returns>
        public static string GetNewsDir()
        {
            return _root + "News/" + GetChildDir();
        }
        /// <summary>
        /// 取得商机信息图片存放目录
        /// eg:uploadfiles/bussiness/2012-03/09/
        /// </summary>
        /// <returns></returns>
        public static string GetBussinessDir()
        {
            return _root + "Bussiness/" + GetChildDir();
        }
        /// <summary>
        /// 取得企业图片存放目录
        /// eg:uploadfiles/Company/
        /// </summary>
        /// <returns></returns>
        public static string GetCompanysDir()
        {
            return _root + "Company/";
        }
        /// <summary>
        /// 取得广告图片存放目录
        /// eg:uploadfiles/Ad/2012-03/09/
        /// </summary>
        /// <returns></returns>
        public static string GetAdDir()
        {
            return _root + "Ad/" + GetChildDir();
        }
        /// <summary>
        /// 取得友情链接图片存放目录
        /// eg:uploadfiles/Links/2012-03/09/
        /// </summary>
        /// <returns></returns>
        public static string GetLinkDir()
        {
            return _root + "Links/";
        }
        /// <summary>
        /// 根据日期取得图片存放目录
        /// </summary>
        /// <returns>eg：2012/03/07/</returns>
        public static string GetDirByDate()
        {
            DateTime Today = DateTime.Now;
            StringBuilder ReturnDir = new StringBuilder();
            return ReturnDir.Append(Today.Year).Append("/")
                .Append(Today.Month.ToString().PadLeft(2, '0')).Append("/")
                .Append(Today.Day.ToString().PadLeft(2, '0')).Append("/").ToString();
        }
        /// <summary>
        /// 取得2012-03/08/目录样式
        /// </summary>
        /// <returns>eg:2012-03/08/</returns>
        public static string GetDirByMonth()
        {
            DateTime Today = DateTime.Now;
            StringBuilder ReturnDir = new StringBuilder();
            return ReturnDir.Append(Today.Year).Append("-")
                .Append(Today.Month.ToString().PadLeft(2, '0')).Append("/").ToString();
        }
        /// <summary>
        /// 取得企业logo图片存放目录（不加日期）
        /// </summary>
        /// <returns></returns>
        public static string GetCompanyLogoDir()
        {
            return GetCompanysDir() + "Logo/";
        }
        /// <summary>
        /// 取得杂志封面存放目录
        /// </summary>
        /// <returns></returns>
        public static string GetMagazineCover()
        {
            return _root + "Magazine/";
        }
        /// <summary>
        /// 取得企业荣誉证书目录（不加日期）
        /// </summary>
        /// <returns></returns>
        public static string GetCompanyCreditDir()
        {
            return GetCompanysDir() + "Credit/";
        }

        public static string GetBrandDir()
        {
            return _root + "Brand/" + GetChildDir();
        }
        #endregion

        #region 取得水印文件
        public static string GetWaterMark()
        {
            return GetRootPath() + "Images\\WaterMark.png";
        }
        #endregion

        #region 分割关键词
        /// <summary>
        /// 按空格或者逗号分隔字符串
        /// </summary>
        /// <param name="keys">源字符串</param>
        /// <returns>分割后的字符串数组</returns>
        public static string[] GetKeyArr(string keys)
        {
            return Regex.Split(keys, "[\\s|,]+");
        }
        #endregion

        #region 取得加密key
        //public static string GetEncryptKey()
        //{
        //    //return Jet.StringHelper.MD5EncryptOne(SiteConfigs.ENCRYPT_KEY);
        //}
        #endregion

        #region 取得允许上传文件类型集合
        public static ICollection<string> GetAllowFileTypes()
        {
            //todo:这里留待一个方法：从配置中取出真正的附件类型
            ICollection<string> contentTypes = new string[] { "image/jpg", "image/pjpg", "image/jpeg", "image/png", "image/x-png", "image/gif", "image/pjpeg" };
            return contentTypes;
        }
        #endregion

        #region 获取订单号，货号
        public static string GetGoodsNO()
        {
            return GetFileName();
        }
        #endregion

        #region 检测上传文件合法性
        public static string CheckUpload(System.Web.HttpPostedFileBase postFile)
        {
            return CheckUpload(postFile, GetAllowFileTypes(), SiteConfigs.SITE_FILE_MAXSIZE);
        }

        /// <summary>
        /// 检测上传文件合法性
        /// </summary>
        /// <param name="postFile">上传文件</param>
        /// <param name="contentTypes">允许的类型集合</param>
        /// <param name="maxSize">最大尺寸</param>
        /// <returns>空则为允许上传</returns>
        public static string CheckUpload(System.Web.HttpPostedFileBase postFile, ICollection<string> contentTypes, int maxSize)
        {
            string msg = string.Empty;
            if (!ImgHelper.CheckContentType(postFile, contentTypes)) msg = "仅允许上传类型为（"+SiteConfigs.SITE_ATTACHMENT_TYPE+"）的附件！";
            if (!ImgHelper.CheckMaxSize(postFile, 204800)) msg += "允许上传最大附件大小为"+maxSize+"KB！";
            return msg.Trim();
        }
        #endregion

        //        #region 取得网站头部信息
//        public static string GetPageHeader(SiteConfigs.Columns c)
//        {
//            Model.Columns model = new ColumnsDAL().GetModel((int)c);
//            StringBuilder header = new StringBuilder();
//            header.Append(String.Format(@"<title>{2}-{3}-</title>
//    <meta name=""keywords"" content=""农资招商,{0}"" />
//    <meta name=""description"" content=""{1}"" />",
//                                          model.Keywords, model.Summary, model.Name, SiteConfigs.SITE_NAME));

//            return header.ToString();
//        }
//        #endregion
    }
    /// <summary>
    /// 网站参数配置类
    /// </summary>
    public static class SiteConfigs
    {
        #region 用户类型
        public enum UserType
        {
            /// <summary>
            /// 普通会员
            /// </summary>
            Common = 0,
            /// <summary>
            /// 经销商
            /// </summary>
            Dealer = 1,
            /// <summary>
            /// 企业会员
            /// </summary>
            Company = 2
        }
        #endregion

        #region 删除状态
        /// <summary>
        /// 记录删除状态
        /// </summary>
        public enum Deleted
        {
            /// <summary>
            /// 未删除
            /// </summary>
            No = 0,
            /// <summary>
            /// 删除
            /// </summary>
            Yes = 1
        }
        #endregion

        #region 推荐级别
        /// <summary>
        /// 推荐级别
        /// </summary>
        public enum RecomLevl
        {
            /// <summary>
            /// 取得所有
            /// </summary>
            All = -1,
            /// <summary>
            /// 首页推荐
            /// </summary>
            Index = 0,
            /// <summary>
            /// 二级推荐
            /// </summary>
            Second = 1,
            /// <summary>
            /// 热点推荐
            /// </summary>
            Hot = 2,
            /// <summary>
            /// 最新推荐
            /// </summary>
            New = 3
        }
        #endregion

        #region 普通记录状态
        /// <summary>
        /// 记录状态
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// 未通过
            /// </summary>
            NoPass = 0,
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 1,
            /// <summary>
            /// 冻结
            /// </summary>
            Frozen = 2,
            /// <summary>
            /// 删除
            /// </summary>
            Deleted = 3
        }
        #endregion

        #region 网站分类
        /// <summary>
        /// 分类
        /// </summary>
        public enum Category
        {
            /// <summary>
            /// 农药资讯
            /// </summary>
            NongyaoZX = 1,
            /// <summary>
            /// 肥料资讯
            /// </summary>
            FeiliaoZX = 2,
            /// <summary>
            /// 农药百科
            /// </summary>
            NongyaoBK = 4,
            /// <summary>
            /// 肥料百科
            /// </summary>
            FeiliaoBK = 31,
            /// <summary>
            /// 价格行情
            /// </summary>
            JiaGeHQ = 39,
            /// <summary>
            /// 杀虫杀螨剂
            /// </summary>
            ShaChongMan = 11,
            /// <summary>
            /// 除草剂
            /// </summary>
            Chucaoji = 12,
            /// <summary>
            /// 杀菌剂
            /// </summary>
            Shajunji = 13,
            /// <summary>
            /// 调节剂
            /// </summary>
            Tiaojieji = 14,
            /// <summary>
            /// 土壤处理剂
            /// </summary>
            Turang = 15,
            /// <summary>
            /// 种子处理剂
            /// </summary>
            Zhongzi = 34,
            /// <summary>
            /// 叶面肥
            /// </summary>
            Yemian = 35,
            /// <summary>
            /// 其他农药 
            /// </summary>
            NongyaoOther = 36,
            Danfei = 16,
            /// <summary>
            /// 磷肥
            /// </summary>
            LinFei = 17,
            /// <summary>
            /// 钾肥
            /// </summary>
            JiaFei = 18,
            /// <summary>
            /// 复合复混肥
            /// </summary>
            Fuhefei = 19,
            /// <summary>
            /// 生物肥
            /// </summary>
            Shengwufei = 37,
            /// <summary>
            /// 其他肥料 
            /// </summary>
            FeiliaoOther = 38,
            /// <summary>
            /// 植保技术
            /// </summary>
            Zhibaojishu = 41,
            /// <summary>
            /// 农资展会
            /// </summary>
            Nongzizhanhui = 26,
            /// <summary>
            /// 展会报道
            /// </summary>
            Zhanhuibaodao = 27,
            /// <summary>
            /// 峰会
            /// </summary>
            Fenghui = 28,
            /// <summary>
            /// 首脑会
            /// </summary>
            Shownaohui = 29,
            /// <summary>
            /// 营销节
            /// </summary>
            Yingxiaojie = 30

        }
        #endregion

        #region 网站栏目
        public enum Columns
        {
            /// <summary>
            /// 农药招商
            /// </summary>
            NongyaoZS = 1,
            /// <summary>
            /// 肥料招商
            /// </summary>
            FeiliaoZX = 2,
            /// <summary>
            /// 资讯中心
            /// </summary>
            News = 3,
            /// <summary>
            /// 农化企业
            /// </summary>
            Company = 4,
            /// <summary>
            /// 产品库
            /// </summary>
            Product = 5,
            /// <summary>
            /// 供求信息
            /// </summary>
            TradeInfo = 6,
            /// <summary>
            /// 代理信息
            /// </summary>
            AgentInfo = 7,
            /// <summary>
            /// 排行榜
            /// </summary>
            Top = 8,
            /// <summary>
            /// 会议中心
            /// </summary>
            Meeting = 9,
            /// <summary>
            /// 网站广告 
            /// </summary>
            Ad = 13,
            /// <summary>
            /// 农资经销商
            /// </summary>
            Dealer = 16,
            /// <summary>
            /// 首页
            /// </summary>
            Index = 17

        }
        #endregion

        #region 会员审核状态
        /// <summary>
        /// 会员审核状态（关联status字段）
        /// </summary>
        public enum PassStatus
        {
            /// <summary>
            /// 申请审核
            /// </summary>
            Passing = 0,
            /// <summary>
            /// 二审通过
            /// </summary>
            Passed = 1,
            /// <summary>
            /// 一审 
            /// </summary>
            FirstPass = 2,
            /// <summary>
            /// 审核未通过 
            /// </summary>
            NoPassed = 3
        }

        #endregion

        #region 91基本配置
        /// <summary>
        /// 网站名称
        /// </summary>
        public const string SITE_NAME = "91农资网【农资招商|农药招商|肥料招商】";
        /// <summary>
        /// 网站地址
        /// </summary>
        public const string SITE_URL = "http://www.91nongzi.com/nongzi/";
        /// <summary>
        /// 上传文件最大尺寸
        /// </summary>
        public const int SITE_FILE_MAXSIZE = 204800;
        /// <summary>
        /// 默认的推荐级别
        /// 0000：按顺序依次为-首页，二级，热点，最新
        /// </summary>
        public const string DEFAULT_RECOMLEVEL = "0000";

        #region 图片长宽定义
        public const double AD_SOUPRO_WIDTH = 130;
        public const double AD_SOUPRO_HEIGHT = 130;

        public const double LINKS_WIDTH = 90;
        public const double LINKS_HEIGHT = 35;

        public const double PRO_MAX_WIDTH = 350;
        public const double PRO_MAX_HEIGHT = 350;

        public const double COMPANY_LOGO_WIDTH = 285;
        public const double COMPANY_LOGO_HEIGHT = 230;

        public const double COMPANY_CREDIT_WIDTH = 650;
        public const double COMPANY_CREDIT_HEIGHT = 650;
        #endregion

        public const string ENCRYPT_KEY = "qweriupouwe";

        public static string GetManageDir()
        {
            return SITE_URL + "nongzi_sys_gl/";
        }

        public const int MAX_AGENT_COUNT = 20;

        #endregion

        #region 允许上传附件类型
        public const string SITE_ATTACHMENT_TYPE = "jpg,gif,png";
        #endregion
    }
}
