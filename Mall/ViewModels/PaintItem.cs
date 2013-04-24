using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mall.Models;
using Mall.ViewModels;
namespace Mall.ViewModels
{
    public class PaintFrameViewModel
    {
        public Goods Paint { get; set; }
        public PaintSizes ChosenSize { get; set; }
        public decimal PaintFramePrice { get; set; }
        public List<Frames> FrameList { get; set; }
    }
}