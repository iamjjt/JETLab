﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mall.Models
{
    public class Cart
    {
        public Cart() { }
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int Count { get; set; }
        public int GoodsId { get; set; }
        public System.DateTime Pubdate { get; set; }
        public virtual Goods Good { get; set; }
        public int PaintSizeId { get; set; }
        [ForeignKey("PaintSizeId")]
        public virtual PaintSizes PaintSize { get; set; }
        public string Others { get; set; }
        public bool IsFrame { get; set; }
        public int FrameId { get; set; }
        [ForeignKey("FrameId")]
        public virtual Frames Frame { get; set; }
    }
}