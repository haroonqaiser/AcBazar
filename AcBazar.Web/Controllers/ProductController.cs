using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcBazar.Services;
using AcBazar.Entities;

namespace AcBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsService = new ProductsService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductInfo(string dataSearch)
        {
            //if (!string.IsNullOrEmpty(Search))
            //{
            //    var products = productsService.GetProducts(Search);
            //}
                var products = productsService.GetProducts();
            if (!string.IsNullOrEmpty(dataSearch))
            {
                products = products.Where(p => p.Name.ToLower().Contains(dataSearch.ToLower())).ToList();
            }
            return PartialView(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CategoriesService categoriesService = new CategoriesService();
            BrandsService brandsService = new BrandsService();

            ViewBag.CategoryList = categoriesService.GetCategories();
            ViewBag.BrandList = brandsService.GetBrands();
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            //CategoriesService categoriesService = new CategoriesService();
            //Category category = new Category();
            //category = categoriesService.GetCategory(Convert.ToInt16(Request.Form["Category_ID"]));
            //product.Category = category;
            productsService.SaveProduct(product);
            return RedirectToAction("ProductInfo");
            //return NULL
            //return PartialView("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            CategoriesService categoriesService = new CategoriesService();
            BrandsService brandsService = new BrandsService();
            ViewBag.CategoryList = categoriesService.GetCategories();
            ViewBag.BrandList = brandsService.GetBrands();
            var product = productsService.GetProduct(ID);
            return PartialView(product);

        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            CategoriesService categoriesService = new CategoriesService();
            Category category = new Category();
            category = categoriesService.GetCategory(Convert.ToInt16(Request.Form["Category_ID"]));
            product.Category = category;
            productsService.UpdateProduct(product);
            return RedirectToAction("ProductInfo");
        }

        public ActionResult Delete(int ID)
        {
            CategoriesService categoriesService = new CategoriesService();
            var product = productsService.GetProduct(ID);
            productsService.DeleteProduct(product);
            return RedirectToAction("ProductInfo");

        }
    }
}