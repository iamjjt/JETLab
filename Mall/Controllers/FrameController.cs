using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Models;
using Mall.ViewModels;
namespace Mall.Controllers
{
    public class FrameController : Controller
    {

        MallDB db = new MallDB();
        //
        // GET: /Frame/

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult FrameIt(int goodId,int paintsizeId)
        {
            PaintFrameViewModel Model = new PaintFrameViewModel { 
                 FrameList=db.Frames.ToList(),
                  ChosenSize=db.PaintSizes.Single(p=>p.ID==paintsizeId),
                 Paint=db.Goods.Single(g=>g.ID==goodId),
                  PaintFramePrice=0
            };
            return View(Model);
        }

        
    }
}
