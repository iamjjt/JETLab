using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mall.Models.ViewModels;
namespace Mall.Models
{
    public class ShoppingCart
    {
        MallDB db = new MallDB();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        /// <summary>
        /// 取得购物车
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(ShoppingCartPaintItem paint)
        {
            //取得购物项
            var cartItem = db.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId && c.GoodsId == paint.GoodsID
             );

            if (cartItem == null)
            {
                if (paint.IsFrame)
                {
                    cartItem = new Cart
                    {
                        GoodsId = paint.GoodsID,
                        CartId = ShoppingCartId,
                        Count = 1,
                        Pubdate = DateTime.Now,
                       // FramesId = paint.FrameId,
                       Frame=new Frames{ FramesID=paint.FrameId},
                        IsFrame = paint.IsFrame,
                        //PaintSizesId = paint.PaintSizeId,
                        PaintSize=new PaintSizes{ PaintSizesID=paint.PaintSizeId},
                        Others = ""
                    };
                }
                else
                {
                    cartItem = new Cart
                    {
                        GoodsId = paint.GoodsID,
                        CartId = ShoppingCartId,
                        Count = 1,
                        Pubdate = DateTime.Now,
                        IsFrame = paint.IsFrame,
                        // PaintSizesId = paint.PaintSizeId
                        PaintSize = new PaintSizes { PaintSizesID = paint.PaintSizeId },
                    };
                }
                db.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            db.SaveChanges();
        }


        public int RemoveFromCart(int id)
        {
            var cartItem = db.Carts.Single(
                cart=>cart.CartId==ShoppingCartId && cart.RecordId==id
            );
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Carts.Remove(cartItem);
                }
                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.Carts.Where(cart=>cart.CartId==ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.Carts.Remove(cartItem);
            }
            db.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(cart=>cart.CartId==ShoppingCartId).ToList();
        }

        /// <summary>
        /// 取得购物车中商品总量
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int? count = (from cartItems in db.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        /// <summary>
        /// 取得购物车中商品的总价
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {


            //TODO:计算商品总价
            decimal? total = (from cartItems in db.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count * cartItems.Good.MallPrice).Sum();
            //计算框的价格，要先判断是否装框，如果装框，再计算装框价格
            decimal? totalFramePrice = (from cartItems in db.Carts
                              where cartItems.CartId == ShoppingCartId && cartItems.IsFrame
                              select (int?)cartItems.Frame.Price * (cartItems.PaintSize.Width+cartItems.PaintSize.Height)*2
                            ).Sum();
            return total ?? decimal.Zero + totalFramePrice??decimal.Zero;
        }



        /// <summary>
        /// 取得购物车编号，如果已经登录，则使用用户名作为购物车编号
        /// 如果没有登录，则是哟个guid作为购物车编号
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();

                }

            }
            return context.Session[CartSessionKey].ToString();
        }
    }
}