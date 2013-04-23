using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Models;

namespace Mall.Areas.SysManagement.Controllers
{ 
    public class GoodsTypeController : BaseController
    {
        private MallDB db = new MallDB();

        //
        // GET: /SysManagement/GoodsType/

        public ViewResult Index()
        {
            return View(db.GoodsType.ToList());
        }

        //
        // GET: /SysManagement/GoodsType/Details/5

        public ViewResult Details(int id)
        {
            GoodsType goodstype = db.GoodsType.Find(id);
            return View(goodstype);
        }

        //
        // GET: /SysManagement/GoodsType/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SysManagement/GoodsType/Create

        [HttpPost]
        public ActionResult Create(GoodsType goodstype)
        {
            if (ModelState.IsValid)
            {
                db.GoodsType.Add(goodstype);
                db.SaveChanges();
               // return RedirectToAction("Index");  
                return base.Success("GoodsTypeIndex", "closeCurrent");
            }

            return View(goodstype);
        }
        
        //
        // GET: /SysManagement/GoodsType/Edit/5
 
        public ActionResult Edit(int id)
        {
            GoodsType goodstype = db.GoodsType.Find(id);
            return View(goodstype);
        }

        //
        // POST: /SysManagement/GoodsType/Edit/5

        [HttpPost]
        public ActionResult Edit(GoodsType goodstype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goodstype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goodstype);
        }

        //
        // GET: /SysManagement/GoodsType/Delete/5
 
        public ActionResult Delete(int id)
        {
            GoodsType goodstype = db.GoodsType.Find(id);
            return View(goodstype);
        }

        //
        // POST: /SysManagement/GoodsType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            GoodsType goodstype = db.GoodsType.Find(id);
            db.GoodsType.Remove(goodstype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}