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
    public class ProductTypeController : Controller
    {
        // GET: ProductType
        [HttpGet]
        public ActionResult Index()
        {
            var productTypes = ProductTypeService.Instance.GetProductTypes();
            return View(productTypes);
        }
        public ActionResult MainInfo(string dataSearch, int? pageNo)
        {
            //var a = Request["Search"];
            ProductTypeSearchViewModel model = new ProductTypeSearchViewModel();
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int pageSize = int.Parse(BasicConfigService.Instance.GetBasicConfiguration("ListingPageSize").ConfigDescription);
            int TotalRecords = 0;


            if (!String.IsNullOrEmpty(dataSearch))
            {
                model.SearchTerm = dataSearch;
            }

            TotalRecords = ProductTypeService.Instance.GetProductTypesCount(dataSearch);
            model.productTypes = ProductTypeService.Instance.GetProductTypes(dataSearch, pageNo.Value);

            if (model.productTypes != null)
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
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(ProductType productType)
        {
            ProductTypeService.Instance.SaveProductType(productType);
            return RedirectToAction("MainInfo");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var productType = ProductTypeService.Instance.GetProductType(ID);
            return PartialView(productType);
        }
        [HttpPost]
        public ActionResult Edit(ProductType productType)
        {
            ProductTypeService.Instance.UpdateProductType(productType);
            return RedirectToAction("MainInfo");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var productType = ProductTypeService.Instance.GetProductType(ID);
            return View(productType);
        }
        [HttpPost]
        public ActionResult Delete(ProductType productType)
        {
            productType = ProductTypeService.Instance.GetProductType(productType.ID);
            ProductTypeService.Instance.DeleteProductType(productType);
            return RedirectToAction("MainInfo");
        }
    }
}
