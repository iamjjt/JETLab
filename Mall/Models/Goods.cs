using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Mall.Models
{
    /// <summary>
    /// 商品实体类
    /// </summary>
    public class Goods
    {
        public int ID { get; set; }
        [Display(Name = "分类编号")]
        public int CAID { get; set; }
        [Display(Name = "商品编号")]
        public string NO { get; set; }
        [Display(Name = "商品名")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "标题样式")]
        public string NameStyle { get; set; }
        [Display(Name = "点击量")]
        public int Hits { get; set; }
        [Display(Name = "品牌编号")]
        public int BrandID { get; set; }
        [Display(Name = "供货人")]
        [Required]
        public string ProviderName { get; set; }
        [Display(Name = "商品数量")]
        [Required]
        public int Number { get; set; }
        [Display(Name = "商品重量")]
        public int Weight { get; set; }
        [Display(Name = "市场价")]
        [Required]
        public decimal MarketPrice { get; set; }
        [Display(Name = "商城价格")]
        [Required]
        public decimal MallPrice { get; set; }
        [Display(Name = "促销价格")]
        public decimal PromotePrice { get; set; }
        [Display(Name = "促销开始日期")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime PromoteStartDate { get; set; }
        [Display(Name = "促销结束日期")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime PromoteEndDate { get; set; }
        [Display(Name = "报警数量")]
        public int WarnNumber { get; set; }
        [Display(Name = "关键字")]
        public string Keywords { get; set; }
        [Display(Name = "商品简介")]
        public string Summary { get; set; }
        [Display(Name = "商品描述")]
        public string Details { get; set; }
        [Display(Name = "缩略图")]
        [Required]
        public string Thumb { get; set; }
        [Display(Name = "商品图片")]
        [Required]
        public string Img { get; set; }
        [Display(Name = "是否实体商品")]
        public int IsReal { get; set; }
        [Display(Name = "扩展代码")]
        public string ExtensionCode { get; set; }
        [Display(Name = "是否开放销售")]
        public bool IsOnSale { get; set; }
        [Display(Name = "是否单独出售")]
        public int IsAloneSale { get; set; }
        [Display(Name = "可使用积分")]
        public int Integral { get; set; }
        [Display(Name = "添加时间")]
        public DateTime AddTime { get; set; }
        [Display(Name = "排序")]
        public int SortOrder { get; set; }
        [Display(Name = "是否删除")]
        public bool IsDelete { get; set; }
        [Display(Name = "是否精品")]
        public bool IsBest { get; set; }
        [Display(Name = "是否新品")]
        public bool IsNew { get; set; }
        [Display(Name = "是否热销")]
        public bool IsHot { get; set; }
        [Display(Name = "是否促销")]
        public bool IsPromote { get; set; }
        [Display(Name = "最后更新")]
        public DateTime LastUpdate { get; set; }
        [Display(Name = "类型编号")]
        public int Type { get; set; }
        [Display(Name = "商品备注")]
        public string Remarks { get; set; }
        [Display(Name = "购买赠送积分")]
        [Required]
        public int GiveIntegral { get; set; }

    }

    /// <summary>
    /// 商品类型，用于关联商品自定义属性
    /// </summary>
    public class GoodsType
    {
        [Display(Name="编号")]
        public int ID { get; set; }
        [Display(Name = "类型名称")]
        public string Name { get; set; }
        [Display(Name = "类型状态")]
        public bool Enabled { get; set; }
        [Display(Name = "类型分组")]
        public string Group { get; set; }

    }
    /// <summary>
    /// 商品自定义属性，不同类型的商品显示不同类型的属性
    /// 比如：书包含的属性有：作者，出版社，出版日期
    /// 油画包含的属性有：
    /// </summary>
    public class CustomAttrbute
    {
        public int ID { get; set; }
        [Display(Name = "商品类型")]
        public int CAID { get; set; }
        [Display(Name = "属性名")]
        public string Name { get; set; }
        [Display(Name = "添加类别")]//属性类别：0手动，1选择输入，2多行文本
        public int InputType { get; set; }
        [Display(Name = "是否多选")]//0唯一，1单选，2复选属性
        public int Type { get; set; }
        [Display(Name = "编号")]//如果inputtype选择1，则对应的值为该字段的值
        public string Values { get; set; }
        [Display(Name = "是否可以检索")]
        public bool IsSearch { get; set; }
        [Display(Name = "是否关联")]
        public string Linked { get; set; }
        [Display(Name = "显示顺序")]
        public string Order { get; set; }
        [Display(Name = "属性分组")]
        public string Group { get; set; }
    }

    public class GoodsAttr
    {
        [Display(Name = "自增编号")]
        public int ID { get; set; }
        [Display(Name = "商品编号")]
        public int GoodsID { get; set; }
        [Display(Name = "属性编号")]
        public int AttrID { get; set; }
        [Display(Name = "属性具体值")]
        public string Value { get; set; }
        [Display(Name = "属性价格")]
        public decimal Price { get; set; }
    }
}

//捋一捋各种关系
//商品分类关联商品自定义属性，
//每一个商品分类都对应一系列的商品属性，即：category 1-* CustomAttrbute
//选择商品时，根据所选商品分类来确定加载的商品类型，这可以通过partialview来做，动态加载过来就行
//那么goodType和分类有什么区别呢？为什么goodType也要和CustomAttrbute关联呢？搞不明白
//goodType和商品分类基本一样，所不同的是，类型更宽泛一些，好像手机可以有很多种分类，但是统称手机


//有一个问题需要讨论下：就是画框是否要算钱，这样：同样的一副画，如果有不同尺寸，需要用不同尺寸的画框
//这时画框是否也是同时需要按照不同尺寸计费，如果需要按照不同尺寸画框计费的话，则在选框的
//同时，则需要选择画框尺寸，则在添加画框的时候即需要同时添加不同的尺寸范围所需费用，例如：
//1m内：500,2m内：800，单选，这个价格最终会加在所购商品的价格中。

//还有就是不同颜色的商品是当作两个商品来卖，还是当作一个商品来卖