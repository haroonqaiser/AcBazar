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
    public class ProductSpecMappService
    {
        #region Singleton
        private static ProductSpecMappService instance { get; set; }
        public static ProductSpecMappService Instance
        {
            get
            {
                if (instance == null) instance = new ProductSpecMappService();
                return instance;
            }
        }
        ProductSpecMappService()
        {
        }

        #endregion


       
        public List<ProductSpecs> GetProductSpec()
        {
            using (var context = new ACContext())
            {
                return context.ProductSpecs.OrderBy(x=>x.OrderSeq).ToList();
            }
        }

        public ProductSpecs GetProductSpec(int ID)
        {
            using (var context = new ACContext())
            {
                return context.ProductSpecs.Find(ID);
            }
        }
        public List<ProductSpecMapp> GetProductSpecMapp()
        {
            using (var context = new ACContext())
            {
                return context.ProductSpecMapps.Include(p => p.Product).Include(p => p.ProductSpecs).ToList();
            }
        }
        public List<ProductSpecMapp> GetProductSpecMapp(int ProductId)
        {
            using (var context = new ACContext())
            {
                return context.ProductSpecMapps.Where(x => x.ProductID == ProductId).Include(p => p.Product).Include(p => p.ProductSpecs).ToList();
            }
        }


        public void SaveProductSpecMapp(ProductSpecMapp productSpecMapp)
        {
            using (var context = new ACContext())
            {
                //productSpecMapp.RowAddDate = System.DateTime.Now;
                //context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.ProductSpecMapps.Add(productSpecMapp);
                context.SaveChanges();
            }
        }

        //public void UpdateProduct(Product product)
        //{
        //    using (var context = new ACContext())
        //    {
        //        context.Entry(product).State = System.Data.Entity.EntityState.Modified;
        //        context.SaveChanges();
        //    }
        //}
        public void DeleteProductSpecMapp(int ProductID)
        {
            using (var context = new ACContext())
            {
                string error;
                try
                {
                    //var productSpecMapp = instance.GetProductSpecMapp(ProductID);
                    //context.ProductSpecMapps.RemoveRange(productSpecMapp);
                    context.ProductSpecMapps.RemoveRange(context.ProductSpecMapps.Where(x => x.ProductID == ProductID));
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }
        }

        public void DeleteProductSpecMapp(ProductSpecMapp productSpecMapp)
        {
            using (var context = new ACContext())
            {
                context.Entry(productSpecMapp).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }


    }
}
