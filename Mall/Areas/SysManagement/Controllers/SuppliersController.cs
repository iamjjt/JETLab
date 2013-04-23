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
    public class SuppliersController : Controller
    {
        private MallDB db = new MallDB();

        //
        // GET: /SysManagement/Suppliers/

        public ViewResult Index(int? pageNum, int? numPerPage)
        {
            if (pageNum == null)
                pageNum = 1;
            if (numPerPage == null)
                numPerPage = 20;

            var allList = db.Suppliers.OrderByDescending(m => m.ID);
            var model = new PaginatedList<Suppliers>(allList, pageNum.Value, numPerPage.Value);
            //model.TotalCount = db.Brand.Count();

            return View(model);
            //return View(db.Suppliers.ToList());
        }

        //
        // GET: /SysManagement/Suppliers/Details/5

        public ViewResult Details(int id)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            return View(suppliers);
        }

        //
        // GET: /SysManagement/Suppliers/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SysManagement/Suppliers/Create

        [HttpPost]
        public ActionResult Create(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(suppliers);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(suppliers);
        }
        
        //
        // GET: /SysManagement/Suppliers/Edit/5
 
        public ActionResult Edit(int id)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            return View(suppliers);
        }

        //
        // POST: /SysManagement/Suppliers/Edit/5

        [HttpPost]
        public ActionResult Edit(Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suppliers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suppliers);
        }

        //
        // GET: /SysManagement/Suppliers/Delete/5
 
        public ActionResult Delete(int id)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            return View(suppliers);
        }

        //
        // POST: /SysManagement/Suppliers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Suppliers suppliers = db.Suppliers.Find(id);
            db.Suppliers.Remove(suppliers);
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