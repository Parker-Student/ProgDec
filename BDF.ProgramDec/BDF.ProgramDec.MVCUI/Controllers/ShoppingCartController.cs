using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDF.ProgramDec.BL;
using BDF.ProgramDec.BL.Models;
namespace BDF.ProgramDec.MVCUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;

        // GET: ShoppingCart
        public ActionResult Index()
        {
            GetShoppingCart();
            return View();
        }

        //Show the cart in the sidebar
        [ChildActionOnly]
        public ActionResult CartDisplay()
        {
            GetShoppingCart();
            return PartialView(cart);
        }

        public ActionResult RemoveFromCart(int id)
        {
            GetShoppingCart();
            BL.Models.ProgDec progDec = cart.Items.FirstOrDefault(i => i.Id == id);
            ShoppingCartManager.Remove(cart, progDec);
            Session["cart"] = cart;
            return RedirectToAction("Index");

        }

        public ActionResult AddToCart(int id)
        {
            GetShoppingCart();
            BL.Models.ProgDec progDec = ProgDecManager.LoadById(id);
            ShoppingCartManager.Add(cart, progDec);
            Session["cart"] = cart;
            return RedirectToAction("Index", "ProgDec");
        }



        private void GetShoppingCart()
        {
            if (Session["cart"] == null)
                cart = new ShoppingCart();
            else
                cart = (ShoppingCart)Session["cart"];
        }

        public ActionResult Checkout()
        {
            GetShoppingCart();

            ShoppingCartManager.Checkout(cart);
            return View();
        }

    }
}