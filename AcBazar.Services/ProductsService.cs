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
        public Product GetProduct(int ID)
        {
            using (var context = new ACContext())
            {
                return context.Products.Find(ID);
            }
        }

        public List<Product> GetProducts()
        {
            using (var context = new ACContext())
            {
                return context.Products.Include(x => x.Category).Include(x => x.Brand).ToList();
                //return context.Products.ToList();
            }
        }

        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new ACContext())
            {
                return context.Products.Where(x=> IDs.Contains(x.ID)).Include(x => x.Category).Include(x => x.Brand).ToList();
                //return context.Products.ToList();
            }
        }
        //public List<Product> GetProducts(string ProductSearch)
        //{
        //    using (var context = new ACContext())
        //    {
        //        return context.Products.ToList().FindAll(ProductSearch);
        //    }
        //}
        public void SaveProduct(Product product)
        {
            using (var context = new ACContext())
            {
                product.RowAddDate = System.DateTime.Now;
                //context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
            }
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
