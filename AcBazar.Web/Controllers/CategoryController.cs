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
    public class CategoryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var categories = CategoriesService.Instance.GetCategories();
            return View(categories);
        }
        public ActionResult MainInfo(string dataSearch, int? pageNo)
        {
            //var a = Request["Search"];
            CategorySearchViewModel model = new CategorySearchViewModel();
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int pageSize = int.Parse(BasicConfigService.Instance.GetBasicConfiguration("ListingPageSize").ConfigDescription);
            int TotalRecords = 0;

            
            if (!String.IsNullOrEmpty(dataSearch))
            {
                model.SearchTerm = dataSearch;
            }

            TotalRecords = CategoriesService.Instance.GetCategoriesCount(dataSearch);
            model.Categories = CategoriesService.Instance.GetCategories(dataSearch, pageNo.Value);

            if (model.Categories != null) {
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
        public ActionResult Create(Category category)
        {
            
            var IsFeatured = Request["IsFeatured"];
            if (IsFeatured != null && IsFeatured.Equals("on"))
            {
                category.IsFeatured = true;
            }
            else
            {
                category.IsFeatured = false;
            }
            CategoriesService.Instance.SaveCategory(category);
            return RedirectToAction("MainInfo");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = CategoriesService.Instance.GetCategory(ID);
            return PartialView(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var IsFeatured = Request["IsFeatured"];
            if (IsFeatured !=null && IsFeatured.Equals("on"))
            {
                category.IsFeatured = true;
            }
            else
            {
                category.IsFeatured = false;
            }
            CategoriesService.Instance.UpdateCategory(category);
            return RedirectToAction("MainInfo");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category = CategoriesService.Instance.GetCategory(ID);
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            category = CategoriesService.Instance.GetCategory(category.ID);
            CategoriesService.Instance.DeleteCategory(category);
            return RedirectToAction("MainInfo");
        }
    }
}