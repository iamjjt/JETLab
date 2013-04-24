using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Models;
using Mall.ViewModels;
namespace Mall.Controllers
{
    public class HomeController : Controller
    {
        Mall.Models.MallDB db = new Models.MallDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SalerRoom()
        {
            IList<SalerRoomGoods> modelList = new List<SalerRoomGoods>();
            db.Goods.OrderByDescending(m => m.ID).ToList().ForEach(g =>
            {
                modelList.Add(new SalerRoomGoods(g));
            });
            return View(modelList);
        }

        public ActionResult Details(int id)
        {
            SalerRoomGoods model = new SalerRoomGoods(id);
            //model.Paint = db.Goods.First(g => g.ID == id);
            //model.PrintSize = db.PaintSizes.Where(p => p.GoodsID == id).ToList();
            return View(model);
        }

        public ActionResult GetPaintSize(int id)
        {
            PaintSizes model=db.PaintSizes.First(p=>p.ID==id);
            return Json(new
            {
                Width=model.Width,
                Height=model.Height,
                Price=model.Price

            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShoppingCart()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
