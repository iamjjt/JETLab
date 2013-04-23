using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mall.Models
{
    [Bind(Exclude = "ID")]
    public class PaintSizes
    {
        [Key]
        [Display(Name = "尺寸编号")]
        public int ID { get; set; }
        [Display(Name="商品编号")]
        public int GoodsID { get; set; }
        [Display(Name = "作品宽度")]
        [Required]
        public decimal Width { get; set; }
        [Display(Name = "作品高度")]
        public decimal Height { get; set; }
        [Display(Name = "制作周期")]
        public string Cycle { get; set; }
        [Display(Name = "价格")]
        public decimal Price { get; set; }
    }
}