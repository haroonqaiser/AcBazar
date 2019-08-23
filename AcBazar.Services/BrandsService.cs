using System;
using AcBazar.Database;
using AcBazar.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Services
{
    public class BrandsService
    {
        public Brand GetBrand(int ID)
        {
            using (var context = new ACContext())
            {
                return context.Brands.Find(ID);
            }

        }
        public List<Brand> GetBrands()
        {
            using (var context = new ACContext())
            {
                return context.Brands.ToList();
            }

        }
        public void SaveBrand(Brand brand)
        {
            using (var context = new ACContext())
            {
                brand.RowAddDate = System.DateTime.Now;
                context.Brands.Add(brand);
                context.SaveChanges();
            }
        }

        public void UpdateBrand(Brand brand)
        {
            using (var context = new ACContext())
            {
                context.Entry(brand).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void DeleteBrand(Brand brand)
        {
            using (var context = new ACContext())
            {
                context.Entry(brand).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

        }
    }
}
