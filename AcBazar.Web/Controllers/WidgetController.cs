using AcBazar.Services;
using AcBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcBazar.Web.Controllers
{
    public class WidgetController : Controller
    {
        // GET: Widget
        public ActionResult Products(bool IsBest, int totalProducts, string ProductTitle, int? categoryID, int? ProductID)
        {
            ProductWidgetViewModel model = new ProductWidgetViewModel();
            model.Product = ProductsService.Instance.GetProducts(IsBest, totalProducts, categoryID, ProductID);
            model.IsBest = IsBest;
            model.ProductTitle = ProductTitle;
            return PartialView(model);
        }
    }
}