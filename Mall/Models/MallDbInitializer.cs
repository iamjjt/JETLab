using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mall.Models
{
    public class MallDbInitializer:DropCreateDatabaseAlways<MallDB>
    {
        protected override void Seed(MallDB context)
        {
            //添加分类
            context.Category.Add(new Category { CaName = "国画", PID = 0, Level = 0, Sort = 0, Status = "1", Summary = "国画" });
            context.Category.Add(new Category { CaName = "油画", PID = 0, Level = 0, Sort = 0, Status = "1", Summary = "油画" });
            //添加商品
            context.Goods.Add(new Goods { NO = "1184574546A", BrandID = 1, AddTime = DateTime.Now, CAID = 1, Details = "北京故宫博物院馆藏 绢本/设色", ExtensionCode="", GiveIntegral=10, Hits=0, 
             Img="Uploadfiles/Goods/Samples/07_big.jpg", Thumb="Uploadfiles/Goods/Samples/07.jpg", Integral=50, IsAloneSale=1, IsBest=true, IsDelete=false, IsHot=true, IsNew=true, IsOnSale = true, IsPromote=false, IsReal=1,
             Keywords="国画", LastUpdate=DateTime.Now, MallPrice=3479.00m, MarketPrice=4000.00m, Name="《金藻图》明·缪辅", NameStyle="", Number=30, PromoteEndDate=DateTime.Now,
             PromotePrice=0, PromoteStartDate=DateTime.Now, ProviderName="1", Remarks="", SortOrder=100, Summary="北京故宫博物院馆藏 绢本/设色", Type=1, WarnNumber=0, Weight=0});
            //添加尺寸
            context.PaintSizes.Add(new PaintSizes { Cycle = "1天", GoodsID = 1, Width = 82.9m, Height = 92.6m, Price = 4130.00m });
            context.PaintSizes.Add(new PaintSizes { Cycle = "1天", GoodsID = 1, Width = 94.5m, Height = 123.8m, Price = 5330.00m });
            //添加品牌
            context.Brand.Add(new Brand { IsShow=true, logo="", Name="壁彩九天", SortOrder=1, Summary="壁彩九天" });

            context.Suppliers.Add(new Suppliers { IsCheck=true, Name="潘家园", Summary="潘家园" });
            context.Frames.Add(new Frames { FramesID=1, Enabled=false, Img="", Name="无边框", Price=decimal.Zero, Summary="没有装框"});
            base.Seed(context);
        }
    }
}