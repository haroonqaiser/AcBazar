using AcBazar.Services;
using AcBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcBazar.Web.Controllers
{
    public class HomeController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();
        ProductsService productsService = new ProductsService();
        public ActionResult Index()
        {
            HomeViewModels model = new HomeViewModels
            {
                Categories = categoriesService.GetCategories(),
                Products = productsService.GetProducts()
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult Support()
        {
            return View();
        }

        public ActionResult Term()
        {
            return View();
        }
    }


}