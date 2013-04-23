using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mall.Models
{
    public class Frames
    {
        public int FramesID { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public decimal Price { get; set; }
        public bool Enabled { get; set; }
        public string Img { get; set; }
    }
}