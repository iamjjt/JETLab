using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mall.Models
{
    public class Suppliers
    {
        [Display(Name = "供货商编号")]
        public int ID { get; set; }
        [Display(Name = "供货商名称")]
        public string Name { get; set; }
        [Display(Name = "描述")]
        public string Summary { get; set; }
        [Display(Name = "负责人")]
        public bool IsCheck { get; set; }
    }
}