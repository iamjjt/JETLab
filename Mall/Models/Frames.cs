using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mall.Models
{
    [Bind(Exclude = "ID")]
    public class Frames
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string EnName { get; set; }
        public string Summary { get; set; }
        public decimal Price { get; set; }
        public bool Enabled { get; set; }
        public string Img { get; set; }
        public string Thumb { get; set; }
    }
}