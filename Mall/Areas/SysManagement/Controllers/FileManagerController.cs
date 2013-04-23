using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Business;
using JETLib.Common;

namespace Mall.Areas.SysManagement.Controllers
{
    public class FileManagerController : BaseController
    {
        //
        // GET: /SysManagement/FileManager/

        public ActionResult FileUpload()
        {
            if (Request.Files["brandLogo"] != null)
            {
                HttpPostedFileBase postFile = Request.Files["BrandLogo"];
                if (postFile != null)
                {
                    string msg = SiteHelper.CheckUpload(postFile);
                    if (msg != string.Empty)
                    {
                        return Content("<script>parent.uploadCallback('','"+msg+"')</script>");
                    }
                    else
                    {
                        string fileName = postFile.FileName;
                        string fileExt = FileHelper.GetPostfixStr(fileName).ToLower();
                        string savePath = SiteHelper.GetBrandDir() + SiteHelper.GetFileName() + fileExt;
                        ImgHelper.UploadOPic(postFile, Server.MapPath("~") + savePath);
                        //brand.logo = savePath;
                        return Content("<script>parent.uploadCallback(true,'" + savePath + "')</script>");
                    }
                }
            }

            return Content("<script>parent.uploadCallback('','上传失败')</script>"); ;
        }

    }
}
