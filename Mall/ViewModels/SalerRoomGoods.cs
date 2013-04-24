using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mall.Models;

namespace Mall.ViewModels
{
    public class SalerRoomGoods
    {
        public SalerRoomGoods() { }
        public SalerRoomGoods(Goods goods)
        {
            Paint = goods;
            PrintSize = new MallDB().PaintSizes.Where(p => p.GoodsID == Paint.ID).ToList();
            ChosenSize = PrintSize.First();
        }
        public SalerRoomGoods(int goodid)
        {
            MallDB db=new MallDB();
            Paint = db.Goods.Single(g=>g.ID==goodid);
            PrintSize =db.PaintSizes.Where(p => p.GoodsID == goodid && p.ID!=1).ToList();
            ChosenSize = PrintSize.First();
        }
        public Goods Paint { get; set; }
        public IList<PaintSizes> PrintSize
        {
            get;
            set;
        }
        public PaintSizes ChosenSize
        {
            get;
            set;
        }

    }
}