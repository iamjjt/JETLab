using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Mall.Models.ViewModels
{
    /// <summary>
    /// 购物车画单项
    /// </summary>
    //public class ShoppingCartPaintItem
    //{
    //    public ShoppingCartPaintItem() { }
    //    public ShoppingCartPaintItem(int goodsid,int paintsizeid, bool isframe,int frameid)
    //    {
    //        this.GoodsID = goodsid;
    //        this.PaintSizeId = paintsizeid;
    //        this.IsFrame = isframe;
    //        this.FrameId = 1;
    //        if (isframe)
    //        {
    //            this.FrameId = frameid;
    //        }
    //    }

    //    public int GoodsID { get; private set; }
    //    public string GoodsName { get; private set; }
    //    public string GoodsSummary { get; private set; }
    //    public string GoodsNO { get; private set; }
    //    public string Cycle { get; private set; }
    //    public int GoodsNumber { get; set; }
    //    public decimal Price { get; private set; }
    //    public PaintSizes PaintSize { get; private set; }
    //    public int PaintSizeId { get; set; }
    //    //是否装框
    //    public bool IsFrame { get; set; }
    //    public Frames Frame { get; set; }
    //    public int FrameId { get; set; }
    //    public decimal FramePrice { get; set; }
    //    //其他配饰，以字符串表现，费用包含在框中了
    //    public string Others { get; set; }
    //}

    //public class ShoppingCart
    //{
    //    Hashtable Items = new Hashtable();
    //    /// <summary>
    //    /// 购物车中的项
    //    /// </summary>
    //    public ICollection<ShoppingCartPaintItem> CartItems
    //    {
    //        get
    //        {
    //            return (ICollection<ShoppingCartPaintItem>)Items.Values;
    //        }
    //    }

    //    public decimal TotalPrice
    //    {
    //        get
    //        {
    //            decimal sum = 0;
    //            foreach (ShoppingCartPaintItem item in Items.Values)
    //            {
    //                sum += item.Price * item.GoodsNumber;
    //            }
    //            return sum;
    //        }
    //    }

    //    public void AddItem(ShoppingCartPaintItem paintItem)
    //    {
    //        ShoppingCartPaintItem item = (ShoppingCartPaintItem)Items[paintItem.GoodsID];
    //        if (item != null)
    //        {
    //            item.GoodsNumber++;
    //            Items[paintItem.GoodsID] = item;
    //        }
    //        else
    //        {
    //            Items.Add(paintItem.GoodsID, paintItem);
    //        }
    //    }
    //    public void AddItem(ShoppingCartPaintItem paintItem, int num)
    //    {
    //        ShoppingCartPaintItem item = (ShoppingCartPaintItem)Items[paintItem.GoodsID];
    //        if (item != null)
    //        {
    //            item.GoodsNumber+=num;
    //            Items[paintItem.GoodsID] = item;
    //        }
    //        else
    //        {
    //            Items.Add(paintItem.GoodsID, paintItem);
    //        }
    //    }
    //    public void RemoveItem(int id)
    //    {
    //        ShoppingCartPaintItem item = (ShoppingCartPaintItem)Items[id];
    //        if (item != null)
    //        {
    //            item.GoodsNumber--;
    //            if (item.GoodsNumber == 0)
    //            {
    //                Items.Remove(id);
    //            }
    //            else
    //            {
    //                Items[id] = item;
    //            }
    //        }
    //        else
    //        {
    //            return;
    //        }
    //    }
    //    public void Clear()
    //    {
    //        Items.Clear();
    //    }
    //}
}