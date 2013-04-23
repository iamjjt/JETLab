using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Models.ViewModels;
using Mall.Models;
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
            IList<Mall.Models.ViewModels.SalerRoomGoods> modelList = new List<Mall.Models.ViewModels.SalerRoomGoods>();
            db.Goods.OrderByDescending(m => m.ID).ToList().ForEach(g =>
            {
                modelList.Add(new Models.ViewModels.SalerRoomGoods(g, db.PaintSizes.Where(p => p.GoodsID == g.ID).ToList()));
            });
            return View(modelList);
        }

        public ActionResult Details(int id)
        {
            SalerRoomGoods model = new SalerRoomGoods();
            model.Paint = db.Goods.First(g => g.ID == id);
            model.PrintSize = db.PaintSizes.Where(p => p.GoodsID == id).ToList();
            return View(model);
        }

        public ActionResult GetPaintSize(int id)
        {
            PaintSizes model=db.PaintSizes.First(p=>p.PaintSizesID==id);
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
