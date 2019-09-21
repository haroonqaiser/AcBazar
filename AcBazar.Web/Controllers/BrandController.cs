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
    public class BrandController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MainInfo(string dataSearch, int? pageNo)
        { 
            BrandSearchViewModel model = new BrandSearchViewModel();
            pageNo = pageNo.HasValue? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int pageSize = int.Parse(BasicConfigService.Instance.GetBasicConfiguration("ListingPageSize").ConfigDescription);
            int TotalRecords = 0;


            if (!String.IsNullOrEmpty(dataSearch))
            {
                model.SearchTerm = dataSearch;
            }

            TotalRecords = BrandsService.Instance.GetBrandsCount(dataSearch);
            model.brand = BrandsService.Instance.GetBrands(dataSearch, pageNo.Value);

            if (model.brand != null)
            {
                model.pager = new Pager(TotalRecords, pageNo, pageSize);
                return PartialView(model);
}
            else
            {
                return HttpNotFound();
            }

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            BrandsService.Instance.SaveBrand(brand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var brand = BrandsService.Instance.GetBrand(ID);
            return View(brand);
        }
        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            BrandsService.Instance.UpdateBrand(brand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var brand = BrandsService.Instance.GetBrand(ID);
            return View(brand);
        }
        [HttpPost]
        public ActionResult Delete(Brand brand)
        {
            BrandsService.Instance.DeleteBrand(brand);
            return RedirectToAction("Index");
        }
    }
}