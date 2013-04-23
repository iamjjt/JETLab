using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Models;
using JETLib.Common;
using Mall.Business;
using Mall.Models.Common;

namespace Mall.Areas.SysManagement.Controllers
{ 
    public class BrandController :BaseController
    {
        private MallDB db = new MallDB();

        //
        // GET: /SysManagement/Brand/

        public ViewResult Index(int? pageNum, int? numPerPage)
        {
            if (pageNum == null)
                pageNum = 1;
            if (numPerPage == null)
                numPerPage = 20;
            //var allList = db.Brand;

            var allList = db.Brand.OrderByDescending(m => m.ID);
            var model=new PaginatedList<Brand>(allList,pageNum.Value,numPerPage.Value);
            //model.TotalCount = db.Brand.Count();

            return View(model);
        }

        //
        // GET: /SysManagement/Brand/Details/5

        public ViewResult Details(int id)
        {
            Brand brand = db.Brand.Find(id);
            return View(brand);
        }

        //
        // GET: /SysManagement/Brand/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SysManagement/Brand/Create

        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            
            if (ModelState.IsValid)
            {
                db.Brand.Add(brand);
                db.SaveChanges();
                return base.Success("BrandIndex", "closeCurrent");  
            }

            return View(brand);
        }
        
        //
        // GET: /SysManagement/Brand/Edit/5
 
        public ActionResult Edit(int id)
        {
            Brand brand = db.Brand.Find(id);
            return View(brand);
        }

        //
        // POST: /SysManagement/Brand/Edit/5

        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        //
        // GET: /SysManagement/Brand/Delete/5
 
        public ActionResult Delete(int id)
        {
            Brand brand = db.Brand.Find(id);
            return View(brand);
        }

        //
        // POST: /SysManagement/Brand/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Brand brand = db.Brand.Find(id);
            db.Brand.Remove(brand);
            db.SaveChanges();
            return base.Success("BrandIndex", "");
        }

        public ActionResult DeleteList(string ids)
        {
            string[] idList = ids.Split(',');
            foreach (var item in idList)
            {
                Brand brand = db.Brand.Find(Convert.ToInt32(item));
                db.Brand.Remove(brand);
            }
            db.SaveChanges();
            return base.Success("BrandIndex", "");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}