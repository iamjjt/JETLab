using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mall.Areas.SysManagement.Controllers
{
    public class BaseController:System.Web.Mvc.Controller
    {
        public ActionResult Success(string tbId, string cllType)
        {
            return Json(new
            {
                statusCode = "200",

                message = "操作成功",

                navTabId = tbId,

                callbackType = cllType,

                forwardUrl = ""
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Success(string msg,string tbId, string cllType)
        {
            return Json(new
            {
                statusCode = "200",

                message = msg,

                navTabId = tbId,

                callbackType = cllType,

                forwardUrl = ""
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SuccessTo(string tbId, string cllType,string forwardurl)
        {
            return Json(new
            {
                statusCode = "200",

                message = "操作成功",

                navTabId = tbId,

                callbackType = cllType,

                forwardUrl = forwardurl
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Failed(string msg,string tbId, string cllType)
        {
            return Json(new
            {
                statusCode = "300",

                message = "msg",

                navTabId = tbId,

                callbackType = cllType,

                forwardUrl = ""
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Failed(string tbId, string cllType)
        {
            return Json(new
            {
                statusCode = "300",

                message = "操作失败",

                navTabId = tbId,

                callbackType = cllType,

                forwardUrl = ""
            }, JsonRequestBehavior.AllowGet);
        }
    }
}