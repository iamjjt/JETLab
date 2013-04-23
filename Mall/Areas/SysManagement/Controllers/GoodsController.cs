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
    public class GoodsController : BaseController
    {
        private MallDB db = new MallDB();

        //
        // GET: /SysManagement/Goods/

        public ViewResult Index(int? pageNum, int? numPerPage)
        {
            if (pageNum == null)
                pageNum = 1;
            if (numPerPage == null)
                numPerPage = 20;
            //var allList = db.Brand;

            var allList = db.Goods.OrderByDescending(m => m.ID);
            var model = new PaginatedList<Goods>(allList, pageNum.Value, numPerPage.Value);

            return View(model);
        }

        //
        // GET: /SysManagement/Goods/Details/5

        public ViewResult Details(int id)
        {
            Goods goods = db.Goods.Find(id);
            return View(goods);
        }

        //
        // GET: /SysManagement/Goods/Create

        public ActionResult Create()
        {

            List<SelectListItem> alllist = new List<SelectListItem>();
            List<Category> calist = new CategoryController().GetAllList();
            foreach (var item in calist)
            {
                alllist.Add(new SelectListItem { Text = item.CaName, Value = item.ID.ToString() });
            }
            ViewBag.CategoryList = alllist;


            List<SelectListItem> brandList = new List<SelectListItem>();
            db.Brand.ToList().ForEach(m => {
                brandList.Add(new SelectListItem { Text=m.Name,Value=m.ID.ToString()});
            });
            ViewBag.BrandList = brandList;

            List<SelectListItem> suppliersList = new List<SelectListItem>();
            db.Suppliers.ToList().ForEach(m =>
            {
                suppliersList.Add(new SelectListItem { Text = m.Name, Value = m.ID.ToString() });
            });
            ViewBag.SuppliersList = suppliersList;
            return View();
        } 

        //
        // POST: /SysManagement/Goods/Create

        [HttpPost]
        public ActionResult Create(Goods goods)
        {
            goods.LastUpdate = DateTime.Now;
            goods.AddTime = DateTime.Now;
            goods.Details = Request.Form["Details"];
            goods.Keywords = Request.Form["Keywords"];
            goods.Remarks = Request.Form["Remarks"];
            goods.ExtensionCode = "";
            goods.NameStyle = Request.Form["NameStyle"];
            if (goods.NO == string.Empty || Request.Form["NO"].Trim()==string.Empty)
            {
                goods.NO = Mall.Business.SiteHelper.GetGoodsNO();
            }
            if (!goods.IsPromote)
            {
                goods.PromoteStartDate = DateTime.Now;
                goods.PromoteEndDate = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                db.Goods.Add(goods);
                db.SaveChanges();
                return base.Success("GoodsIndex", ""); 
            }

            return RedirectToAction("Create");
        }
        
        //
        // GET: /SysManagement/Goods/Edit/5
 
        public ActionResult Edit(int id)
        {
            Goods goods = db.Goods.Find(id);
            return View(goods);
        }

        //
        // POST: /SysManagement/Goods/Edit/5

        [HttpPost]
        public ActionResult Edit(Goods goods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goods);
        }

        //
        // GET: /SysManagement/Goods/Delete/5
 
        public ActionResult Delete(int id)
        {
            Goods goods = db.Goods.Find(id);
            return View(goods);
        }

        //
        // POST: /SysManagement/Goods/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Goods goods = db.Goods.Find(id);
            db.Goods.Remove(goods);
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