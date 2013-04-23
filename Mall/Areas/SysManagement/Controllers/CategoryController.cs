using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Models;
using Mall.Models.ViewModels;

namespace Mall.Areas.SysManagement.Controllers
{ 
    public class CategoryController : Controller
    {
        private MallDB db = new MallDB();

        //
        // GET: /SysManagement/Category/

        public ViewResult Index()
        {
            IList<Category> calist = GetCategorysByPID(0);
            Dictionary<Category, int> dictCategorys = new Dictionary<Category, int>();
            foreach (var item in calist)
            {
                dictCategorys.Add(item,GetChildCount(item.ID) );
            }
            return View(dictCategorys);
        }

        //
        // GET: /SysManagement/Category/Details/5

        public ViewResult Details(int id)
        {
            Category category = db.Category.Find(id);
            return View(category);
        }

        //
        // GET: /SysManagement/Category/Create

        public ActionResult Create()
        {
            List<SelectListItem> alllist = new List<SelectListItem>();
            List<Category> calist = GetAllList();
            alllist.Add(new SelectListItem { Text="顶级分类",Value="0", Selected=true });
            foreach (var item in calist)
            {
                alllist.Add(new SelectListItem { Text=item.CaName, Value=item.ID.ToString() });
            }
            
            ViewBag.AllList = alllist;
            return View();
        } 

        //
        // POST: /SysManagement/Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {

                category.Level = 0;
                if (category.PID != 0)
                {
                    category.Level = db.Category.First(c => c.ID == category.PID).Level + 1;
                }
                db.Category.Add(category);
                db.SaveChanges();
                //return RedirectToAction("Index"); 
                return Success( "CategorysList", "closeCurrent");
            }

            return View(category);
        }


        public ActionResult Success( string tbId, string cllType)
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

        //
        // GET: /SysManagement/Category/Edit/5
 
        public ActionResult Edit(int id)
        {
            Category category = db.Category.Find(id);
            return View(category);
        }

        //
        // POST: /SysManagement/Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //
        // GET: /SysManagement/Category/Delete/5
 
        public ActionResult Delete(int id)
        {
            Category category = db.Category.Find(id);
            return View(category);
        }

        //
        // POST: /SysManagement/Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Category category = db.Category.Find(id);
            db.Category.Remove(category);
            db.SaveChanges();
            return Success("CategorysList", "");
            //return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public List<Category> GetCategorysByPID(int pid)
        {
            return db.Category.Where(c=>c.PID==pid).ToList();
        }

        public int GetChildCount(int id)
        {
            return GetCategorysByPID(id).Count;
        }

        public ActionResult GetChildrens(int id)
        {
            if (Request.IsAjaxRequest())
            {
                IList<Category> calist = GetCategorysByPID(id);
                if (calist != null)
                {
                    Dictionary<Category, int> dictCategorys = new Dictionary<Category, int>();
                    foreach (var item in calist)
                    {
                        dictCategorys.Add(item, GetChildCount(item.ID));
                    }
                    return PartialView(dictCategorys);
                }
                else
                {
                    return Content("-1");
                }
            }
            else
            {
                return Content("-1");
            }
        }

        #region linq分类
        public List<Category> GetAllList()
        {
            List<Category> retList = new List<Category>();
            List<Category> alllist = db.Category.ToList();
            if (alllist != null)
            {
                alllist.Where(c => c.PID == 0).ToList().ForEach(c =>
                {

                    retList.Add(AddFix(c));
                    retList.Concat(GetSonCategory(alllist, retList, c.ID));
                });
                return retList;
            }
            return null;
        }

        public List<Category> GetSonCategory(List<Category> allList, List<Category> retlist, int pid)
        {
            //List<Category> retlist = new List<Category>();
            List<Category> clist = allList.Where(c => c.PID == pid).ToList();
            clist.ForEach(c =>
            {
                retlist.Add(AddFix(c));
                retlist.Concat(GetSonCategory(allList, retlist, c.ID));
            });
            return retlist;
        }
        #endregion

        protected Category AddFix(Category c)
        {
            for (int i = 0; i < c.Level; i++)
            {
                c.CaName = "━" + c.CaName;
            }
            c.CaName = "┗" + c.CaName;
            return c;
        }
    }
}