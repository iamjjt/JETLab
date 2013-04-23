using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Mall.Models;
using Mall.ViewModels;
namespace Mall.Controllers
{
    public class ShoppingCartController : Controller
    {
        Mall.Models.MallDB db = new Models.MallDB();

        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }

        public ActionResult AddToCart(FormCollection fc)
        {
            //这里，需要赋的值有，商品编号，是否装框，框id，尺寸id
            var cart = ShoppingCart.GetCart(this.HttpContext);
            Mall.Models.ViewModels.ShoppingCartPaintItem paintItem = new Mall.Models.ViewModels.ShoppingCartPaintItem(Convert.ToInt32(fc["GoodsId"]),
                Convert.ToInt32(fc["PaintSizeId"]),Convert.ToBoolean(fc["IsFrame"]),Convert.ToInt32(fc["FrameId"]));

            cart.AddToCart(paintItem);
            return RedirectToAction("Index");
        }

    }
}
