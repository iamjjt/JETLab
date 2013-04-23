using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mall.Models
{
    public class PaintSizes
    {
        [Display(Name = "尺寸编号")]
        public int PaintSizesID { get; set; }
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