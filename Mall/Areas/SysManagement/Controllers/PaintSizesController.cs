using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Models;
using Mall.Models.Common;

namespace Mall.Areas.SysManagement.Controllers
{ 
    public class PaintSizesController : Controller
    {
        private MallDB db = new MallDB();

        //
        // GET: /SysManagement/PaintSizes/

        public ViewResult Index(int? pageNum, int? numPerPage)
        {
            if (pageNum == null)
                pageNum = 1;
            if (numPerPage == null)
                numPerPage = 20;
            //var allList = db.Brand;

            var allList = db.PaintSizes.OrderByDescending(m => m.ID);
            var model = new PaginatedList<PaintSizes>(allList, pageNum.Value, numPerPage.Value);
            //model.TotalCount = db.Brand.Count();

            return View(model);
        }

        //
        // GET: /SysManagement/PaintSizes/Details/5

        public ViewResult Details(int id)
        {
            PaintSizes paintsizes = db.PaintSizes.Find(id);
            return View(paintsizes);
        }

        //
        // GET: /SysManagement/PaintSizes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SysManagement/PaintSizes/Create

        [HttpPost]
        public ActionResult Create(PaintSizes paintsizes)
        {
            if (ModelState.IsValid)
            {
                db.PaintSizes.Add(paintsizes);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(paintsizes);
        }
        
        //
        // GET: /SysManagement/PaintSizes/Edit/5
 
        public ActionResult Edit(int id)
        {
            PaintSizes paintsizes = db.PaintSizes.Find(id);
            return View(paintsizes);
        }

        //
        // POST: /SysManagement/PaintSizes/Edit/5

        [HttpPost]
        public ActionResult Edit(PaintSizes paintsizes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paintsizes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paintsizes);
        }

        //
        // GET: /SysManagement/PaintSizes/Delete/5
 
        public ActionResult Delete(int id)
        {
            PaintSizes paintsizes = db.PaintSizes.Find(id);
            return View(paintsizes);
        }

        //
        // POST: /SysManagement/PaintSizes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            PaintSizes paintsizes = db.PaintSizes.Find(id);
            db.PaintSizes.Remove(paintsizes);
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