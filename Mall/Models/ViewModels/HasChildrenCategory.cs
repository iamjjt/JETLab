using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mall.Models.ViewModels
{
    public class HasChildrenCategory
    {
        public int ID { get; set; }
        public string CaName { get; set; }
        public int PID { get; set; }
        public string Summary { get; set; }
        public int Level { get; set; }
        public string Status { get; set; }
        public int Sort { get; set; }
        public  Category ParentCategory { get; set; }
        public IList<Category> ChildrenCategorys { get; set; } 
    }
}