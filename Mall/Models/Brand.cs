using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mall.Models
{
    public class Brand
    {
        [Display(Name = "品牌编号")]
        public int ID { get; set; }
        [Display(Name = "品牌名称")]
        public string Name { get; set; }
        [Display(Name = "品牌标志")]
        public string logo { get; set; }
        [Display(Name = "品牌描述")]
        public string Summary { get; set; }
        [Display(Name = "排序")]
        public int SortOrder { get; set; }
        [Display(Name = "是否显示")]
        public bool IsShow { get; set; }
    }
}