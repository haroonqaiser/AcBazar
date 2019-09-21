using AcBazar.Entities;
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
        public void PassThings(List<Thing> things)
        {
            var t = things;
        }
        public ActionResult Index()
        {
            HomeViewModels model = new HomeViewModels
            {
                ProductType = ProductTypeService.Instance.GetProductTypes(),
                Categories = CategoriesService.Instance.GetCategories(),
                Products = ProductsService.Instance.GetProducts(0),
                Brand = BrandsService.Instance.GetBrands(),
                BasicConfiguration = BasicConfigService.Instance.GetBasicConfigurations().FirstOrDefault(),
                BasicConfigurations = BasicConfigService.Instance.GetBasicConfigurations()
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

        public ActionResult FAQs()
        {
            return View();
        }
    }


}