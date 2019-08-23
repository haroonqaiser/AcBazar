using AcBazar.Entities;
using AcBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcBazar.Web.Controllers
{
    public class BrandController : Controller
    {
        BrandsService brandService = new BrandsService();
        [HttpGet]
        public ActionResult Index()
        {
            var Brands = brandService.GetBrands();
            return View(Brands);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            brandService.SaveBrand(brand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var brand = brandService.GetBrand(ID);
            return View(brand);
        }
        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            brandService.UpdateBrand(brand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var brand = brandService.GetBrand(ID);
            return View(brand);
        }
        [HttpPost]
        public ActionResult Delete(Brand brand)
        {
            brandService.DeleteBrand(brand);
            return RedirectToAction("Index");
        }
    }
}