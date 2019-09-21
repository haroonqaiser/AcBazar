using AcBazar.Database;
using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Services
{
    public class ProductTypeService
    {
        #region Singleton
        private static ProductTypeService instance { get; set; }
        public static ProductTypeService Instance
        {
            get
            {
                if (instance == null) instance = new ProductTypeService();
                return instance;
            }
        }
        ProductTypeService()
        {
        }

        #endregion
        public ProductType GetProductType(int ID)
        {
            using (var context = new ACContext())
            {
                return context.ProductType.Find(ID);
            }

        }
        public List<ProductType> GetProductTypes()
        {
            using (var context = new ACContext())
            {
                return context.ProductType.ToList();
            }

        }


        public int GetProductTypesCount(string search)
        {
            using (var context = new ACContext())
            {
                if (!String.IsNullOrEmpty(search))
                    return context.ProductType.Where(x => x.Name.ToLower().Contains(search.ToLower())).Count();
                else
                    return context.ProductType.Count();
            }

        }

        public List<ProductType> GetProductTypes(string search, int pageNo)
        {
            int pageSize = int.Parse(BasicConfigService.Instance.GetBasicConfiguration("ListingPageSize").ConfigDescription);
            using (var context = new ACContext())
            {
                if (!String.IsNullOrEmpty(search))
                    return context.ProductType.Where(x => x.Name != null && x.Name.ToLower()
                        .Contains(search.ToLower()))
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                else
                    return context.ProductType
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
            }
        }


        public void SaveProductType(ProductType ProductType)
        {
            using (var context = new ACContext())
            {
                ProductType.RowAddDate = System.DateTime.Now;
                context.ProductType.Add(ProductType);
                context.SaveChanges();
            }
        }

        public void UpdateProductType(ProductType ProductType)
        {
            using (var context = new ACContext())
            {
                context.Entry(ProductType).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void DeleteProductType(ProductType ProductType)
        {
            using (var context = new ACContext())
            {
                context.Entry(ProductType).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

        }
    }
}
