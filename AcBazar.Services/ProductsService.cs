using AcBazar.Database;
using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AcBazar.Services
{
    public class ProductsService
    {
        #region Singleton
        private static ProductsService instance { get; set; }
        public static ProductsService Instance
        {
            get
            {
                if (instance == null) instance = new ProductsService();
                return instance;
            }
        }
        ProductsService()
        {
        }

        #endregion
        public Product GetProduct(int ID)
        {
            using (var context = new ACContext())
            {
                return context.Products.Include(x => x.Category).Include(x=>x.Brand).Where(x => x.ID == ID).FirstOrDefault();
                //return context.Products.Find(ID);
            }
        }

        public List<Product> GetProducts(bool IsBest, int totalProducts, int? categoryID, int? ProductID)
        {
            var products = new List<Product>();
            using (var context = new ACContext())
            {
                if (IsBest) {
                    if (categoryID.HasValue)
                    {
                        if (ProductID.HasValue)
                        {
                            products = context.Products.OrderByDescending(x => x.RowAddDate).Where(x => x.IsBest == true && x.ID != ProductID.Value && x.CategoryId == categoryID.Value).Include(x => x.Category).Take(totalProducts).ToList();
                        }
                        else
                        { 
                            products = context.Products.OrderByDescending(x => x.RowAddDate).Where(x => x.IsBest == true && x.CategoryId == categoryID.Value).Include(x => x.Category).Take(totalProducts).ToList();
                        }
                    }
                    else
                    {
                        products = context.Products.OrderByDescending(x => x.RowAddDate).Where(x => x.IsBest == true).Include(x => x.Category).Take(totalProducts).ToList();
                    }
                }
                else 
                {
                    if (categoryID.HasValue)
                    {
                        if (ProductID.HasValue)
                        {
                            products = context.Products.OrderByDescending(x => x.RowAddDate).Include(x => x.Category).Where(x => x.CategoryId == categoryID.Value && x.ID != ProductID.Value).Take(totalProducts).ToList();
                        }
                        else
                        {
                            products = context.Products.OrderByDescending(x => x.RowAddDate).Include(x => x.Category).Where(x => x.CategoryId == categoryID.Value).Take(totalProducts).ToList();
                        }
                    }
                    else
                    {
                        products = context.Products.OrderByDescending(x => x.RowAddDate).Include(x => x.Category).Take(totalProducts).ToList();
                    }
                }

              
            return products;
            }
        }


        public int SearchProductsCount(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy)
        {
            using (var context = new ACContext())
            {
                var products = context.Products.ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.CategoryId == categoryID.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }
                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }

                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderByDescending(x => x.ID).Where(x => x.IsBest == true).ToList();
                            break;
                        case 3:
                            products = products.OrderBy(x => x.Price - x.AmountDis).ToList();
                            break;
                        case 4:
                            products = products.OrderByDescending(x => x.Price - x.AmountDis).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                    }
                }
                return products.Count;
            }
        }


        public List<Product> SearchProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID, int? sortBy, int pageNo, int pageSize)
        {
            using (var context = new ACContext())
            {
                var products = context.Products.ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.CategoryId == categoryID.Value).ToList();
                }

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }

                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price >= minimumPrice.Value).ToList();
                }
                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }

                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            products = products.OrderByDescending(x => x.ID).Where(x => x.IsBest == true).ToList();
                            break;
                        case 3:
                            products = products.OrderBy(x => x.Price - x.AmountDis).ToList();
                            break;
                        case 4:
                            products = products.OrderByDescending(x => x.Price-x.AmountDis).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                    }
                }
                return products.Skip((pageNo-1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Product> GetProducts(int recordnumbers)
        {
            using (var context = new ACContext())
            {
                if (recordnumbers != 0)
                {
                    return context.Products.Include(x => x.Category).Include(x => x.Brand).OrderByDescending(x => x.ID).Take(recordnumbers).ToList();
                }
                else
                {
                    return context.Products.Include(x => x.Category).Include(x => x.Brand).ToList();
                }
                //return context.Products.ToList();
            }
        }

        public decimal GetMaximumPrice()
        {
            using (var context = new ACContext())
            {
                    return context.Products.Max(x=>x.Price);
            }

        }
        public int GetProductsCount(string search)
        {
            using (var context = new ACContext())
            {
                if (!String.IsNullOrEmpty(search))
                    return context.Products.Where(x => x.Name.ToLower().Contains(search.ToLower())).Count();
                else
                    return context.Products.Count();
            }

        }

        public List<Product> GetProducts(string search, int pageNo)
        {
            int pageSize = int.Parse(BasicConfigService.Instance.GetBasicConfiguration("ListingPageSize").ConfigDescription);
            using (var context = new ACContext())
            {
                if (!String.IsNullOrEmpty(search))
                    return context.Products.Where(x => x.Name != null && x.Name.ToLower()
                        .Contains(search.ToLower()))
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Category)
                        .Include(x => x.Brand)
                        .ToList();
                else
                    return context.Products
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .Include(x => x.Category)
                        .Include(x => x.Brand)
                        .ToList();
            }
        }


        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new ACContext())
            {
                //return context.Products.Where(x=> IDs.Contains(x.ID)).Include(x => x.Category).Include(x => x.Brand).ToList();
                List<Product> pl = new List<Product>();
                pl = context.Products.Where(product => IDs.Contains(product.ID)).Include(x => x.Category).Include(x => x.Brand).ToList();
                return pl;
            } 
        }
        //public List<Product> GetProducts(string ProductSearch)
        //{
        //    using (var context = new ACContext())
        //    {
        //        return context.Products.ToList().FindAll(ProductSearch);
        //    }
        //}
        public int SaveProduct(Product product)
        {
            int id = 0;
            using (var context = new ACContext())
            {
                product.RowAddDate = System.DateTime.Now;
                //context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
                id = product.ID;
            }
            return id;
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new ACContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var context = new ACContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
