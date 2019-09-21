using AcBazar.Services;
using AcBazar.Web.Code;
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
        public ActionResult Index(string SearchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            ShopViewModel model = new ShopViewModel();
            model.FeaturedCategories = CategoriesService.Instance.GetFeaturedCategories();
            model.MaximumPrice = (int)(ProductsService.Instance.GetMaximumPrice());

            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;

            model.Products = ProductsService.Instance.SearchProducts(SearchTerm, minimumPrice, maximumPrice, categoryID, sortBy, pageNo.Value, 10);
            model.CategoryID = categoryID;
            //model.SearchTerm = SearchTerm;
            model.sortBy = sortBy;
            ////var sort = (SortByEnum)sortyBy.Value;
            int totalCount = ProductsService.Instance.SearchProductsCount(SearchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            model.Pager = new Pager(totalCount, pageNo);

            return View(model);

        }
        //FilterProductsViewModel

        public ActionResult FilterProducts(string SearchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int? pageNo)
        {
            FilterProductsViewModel model = new FilterProductsViewModel();
            model.Products = ProductsService.Instance.SearchProducts(SearchTerm, minimumPrice, maximumPrice, categoryID, sortBy, (pageNo.HasValue? pageNo.Value:0) , 10);
            int totalCount = ProductsService.Instance.SearchProductsCount(SearchTerm, minimumPrice, maximumPrice, categoryID, sortBy);
            model.Pager = new Pager(totalCount, pageNo);
            return PartialView(model);
        }

        public ActionResult ShoptDetail(int ProductID)
        {
            ProductDetail model = new ProductDetail();
            model.product = ProductsService.Instance.GetProduct(ProductID);
            model.productSpecs = ProductSpecMappService.Instance.GetProductSpec();
            model.productSpecMapp = ProductSpecMappService.Instance.GetProductSpecMapp(ProductID);
            return View(model);
        }

        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();
            var CartProductCookie = Request.Cookies["CartProducts"];
            if (CartProductCookie != null)
            {
                //var ProductIDs = Request.Cookies["CartProducts"].Value.Split('-').Select(x => int.Parse(x)).ToList();

                model.ProductIDs = CartProductCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.CardProducts = ProductsService.Instance.GetProducts(model.ProductIDs);

            }


            return View(model);
        }
    }
}