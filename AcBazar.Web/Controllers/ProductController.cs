using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcBazar.Services;
using AcBazar.Entities;
using AcBazar.Web.ViewModels;
using System.IO;
using System.ComponentModel;

namespace AcBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductInfo(string dataSearch, int? pageNo)
        {
            ProductSearchViewModel model = new ProductSearchViewModel();
            pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int pageSize = int.Parse(BasicConfigService.Instance.GetBasicConfiguration("ListingPageSize").ConfigDescription);
            int TotalRecords = 0;


            if (!String.IsNullOrEmpty(dataSearch))
            {
                model.SearchTerm = dataSearch;
            }

            TotalRecords = ProductsService.Instance.GetProductsCount(dataSearch);
            model.product = ProductsService.Instance.GetProducts(dataSearch, pageNo.Value);

            if (model.product != null)
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
            ViewBag.ProductTypeList = ProductTypeService.Instance.GetProductTypes();
            ViewBag.CategoryList = CategoriesService.Instance.GetCategories();
            ViewBag.BrandList = BrandsService.Instance.GetBrands();
            List<ProductSpecs> productSpecs = ProductSpecMappService.Instance.GetProductSpec();
            return PartialView(productSpecs);
        }
        [HttpPost]
        public JsonResult Create(Product product)
        {
            JsonResult result = new JsonResult();
            try
            {
                product.IsBest = string.IsNullOrEmpty(Request["IsBest"]) ? false : Request["IsBest"].Equals("on");
                product.IsNew = string.IsNullOrEmpty(Request["IsNew"]) ? false : Request["IsNew"].Equals("on");
                product.IsSale = string.IsNullOrEmpty(Request["IsSale"]) ? false : Request["IsSale"].Equals("on");
                product.IsCancel = string.IsNullOrEmpty(Request["IsCancel"]) ? false : Request["IsCancel"].Equals("on");
                //CategoriesService categoriesService = new CategoriesService();
                //Category category = new Category();
                //category = categoriesService.GetCategory(Convert.ToInt16(Request.Form["Category_ID"]));
                //product.Category = category;
                int pID = ProductsService.Instance.SaveProduct(product);
                result.Data = new { Sucess = true, PID = pID };
            }
            catch (Exception ex)
            {
                result.Data = new { Sucess = false, Message = ex.Message };
            }

            return result;
            //return RedirectToAction("ProductInfo");
        }

        public ActionResult CreateProductDetail(List<ProductSpecMapp> productSpecMapp)
        {
            JsonResult result = new JsonResult();
            try
            {
                var p = productSpecMapp.Where(x => x.Name != null).ToList();

                if (productSpecMapp != null && productSpecMapp.Select(x => x.Name != null).ToList().Contains(true))
                {

                    ProductSpecMappService.Instance.DeleteProductSpecMapp(p.Select(x => x.ProductID).FirstOrDefault());

                    foreach (var item in p)
                    {
                        //item.Product = ProductsService.Instance.GetProduct(item.ProductID);
                        //item.ProductSpecs = ProductSpecMappService.Instance.GetProductSpec(item.SpecKey);
                        ProductSpecMappService.Instance.SaveProductSpecMapp(item);
                    }
                    //return RedirectToAction("ProductInfo");
                    result.Data = new { Sucess = true, PID = p.Select(x => x.ProductID).FirstOrDefault() };
                }
                else
                {
                    result.Data = new { Sucess = false, Message = "Record not found" };
                }
            }
            catch (Exception ex)
            {
                result.Data = new { Sucess = false, Message = ex.Message };
            }

            return result;
        }


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            ProductDetail model = new ProductDetail();
            ViewBag.ProductTypeList = ProductTypeService.Instance.GetProductTypes();
            ViewBag.CategoryList = CategoriesService.Instance.GetCategories();
            ViewBag.BrandList = BrandsService.Instance.GetBrands();
            model.product = ProductsService.Instance.GetProduct(ID);
            model.productSpecs = ProductSpecMappService.Instance.GetProductSpec();
            model.productSpecMapp = ProductSpecMappService.Instance.GetProductSpecMapp(ID);
            return PartialView(model);

        }
        [HttpPost]
        public JsonResult Edit(Product product)
        {
            JsonResult result = new JsonResult();
            try
            {
                Category category = new Category();
                category = CategoriesService.Instance.GetCategory(Convert.ToInt16(Request.Form["Category_ID"]));
                product.Category = category;
                product.IsBest = string.IsNullOrEmpty(Request["IsBest"]) ? false : Request["IsBest"].Equals("on");
                product.IsNew = string.IsNullOrEmpty(Request["IsNew"]) ? false : Request["IsNew"].Equals("on");
                product.IsSale = string.IsNullOrEmpty(Request["IsSale"]) ? false : Request["IsSale"].Equals("on");
                product.IsCancel = string.IsNullOrEmpty(Request["IsCancel"]) ? false : Request["IsCancel"].Equals("on");
                ProductsService.Instance.UpdateProduct(product);
                //here we will get product id and save it with product specs
                result.Data = new { Sucess = true, PID = product.ID };
            }
            catch (Exception ex)
            {
                result.Data = new { Sucess = false, Message = ex.Message };
            }

            return result;

            //return RedirectToAction("ProductInfo");
        }

        public ActionResult Delete(int ID)
        {
            var product = ProductsService.Instance.GetProduct(ID);
            ProductsService.Instance.DeleteProduct(product);
            return RedirectToAction("ProductInfo");
        }

        public void WriteTsv<T>(IEnumerable<T> data, TextWriter output)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Write(prop.DisplayName); // header
                output.Write("\t");
            }
            output.WriteLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    output.Write(prop.Converter.ConvertToString(
                         prop.GetValue(item)));
                    output.Write("\t");
                }
                output.WriteLine();
            }


        }

        public ActionResult ExportListFromTsv()
        {
            List<ProductReport> data = new List<ProductReport>();

            //var data = new[]{
            //                   new{ Name="Ram", Email="ram@techbrij.com", Phone="111-222-3333" },
            //                   new{ Name="Shyam", Email="shyam@techbrij.com", Phone="159-222-1596" },
            //                   new{ Name="Mohan", Email="mohan@techbrij.com", Phone="456-222-4569" },
            //                   new{ Name="Sohan", Email="sohan@techbrij.com", Phone="789-456-3333" },
            //                   new{ Name="Karan", Email="karan@techbrij.com", Phone="111-222-1234" },
            //                   new{ Name="Brij", Email="brij@techbrij.com", Phone="111-222-3333" }
            //          };

            //List<Product> data = new List<Product>();
                var ps = ProductsService.Instance.GetProducts(0).Select(c => { c.Description = c.Description.Replace(System.Environment.NewLine, " # "); return c; }).ToList();
            //    var pl = ps.Select(c => {c.Description = c.Description.Replace(System.Environment.NewLine, " # "); return c; }).ToList();
            //foreach (var item in ps)
            //{
            //    data.Add(new ProductReport() {
            //        ID = item.ID,
            //        Name=item.Name,
            //        Description = item.Description.Replace(System.Environment.NewLine, " # "),
            //        Price=item.Price,
            //        AmountDis=item.AmountDis,
            //        CategoryName=item.Category.Name,
            //        BrandName=item.Brand.Name
            //    });
            //}
            Response.ClearContent();
            //Response.AddHeader("Content-Disposition", "attachment;filename=myfilename.csv");
            Response.AddHeader("content-disposition", "attachment;filename=Products.xls");
            Response.AddHeader("Content-Type", "application/vnd.ms-excel");

            WriteTsv(ps, Response.Output);
            Response.End();
            return View();
        }

       

    }
}