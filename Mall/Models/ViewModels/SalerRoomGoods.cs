﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mall.Models.ViewModels
{
    public class SalerRoomGoods
    {
        public SalerRoomGoods() { }
        public SalerRoomGoods(Goods goods, IList<PaintSizes> paintsize)
        {
            Paint = goods;
            PrintSize = paintsize;
        }

        public Goods Paint { get; set; }
        public IList<PaintSizes> PrintSize { get; set; }
    }
}