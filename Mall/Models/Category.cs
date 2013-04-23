using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Mall.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display( Name="分类名称")]
        public string CaName { get; set; }
        [Display(Name = "父类")]
        public int PID { get; set; }
        [Display(Name = "分类简介")]
        public string Summary { get; set; }
        [Display(Name = "级别")]
        public int Level { get; set; }
        [Display(Name = "状态")]
        public string Status { get; set; }
        [Display(Name = "排序字段")]
        public int Sort { get; set; }
    }
}