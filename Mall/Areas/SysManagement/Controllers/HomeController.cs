using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mall.Areas.SysManagement.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /SysManagement/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
