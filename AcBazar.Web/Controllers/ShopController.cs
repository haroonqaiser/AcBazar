using AcBazar.Services;
using AcBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcBazar.Web.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();
            ProductsService productsService = new ProductsService();
            var CartProductCookie = Request.Cookies["CartProducts"];
            if (CartProductCookie != null)
            {
                //var ProductIDs = Request.Cookies["CartProducts"].Value.Split('-').Select(x => int.Parse(x)).ToList();

                var ProductIDs = CartProductCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CardProducts = productsService.GetProducts(ProductIDs);

            }


            return View(model);
        }
    }
}