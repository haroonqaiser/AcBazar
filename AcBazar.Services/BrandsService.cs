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
        #region Singleton
        private static BrandsService instance { get; set; }
        public static BrandsService Instance    
        {
            get {
                if (instance == null) instance = new BrandsService();
                return instance;
            }
        }
        BrandsService()
        {
        }

        #endregion
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


        public int GetBrandsCount(string search)
        {
            using (var context = new ACContext())
            {
                if (!String.IsNullOrEmpty(search))
                    return context.Brands.Where(x => x.Name.ToLower().Contains(search.ToLower())).Count();
                else
                    return context.Brands.Count();
            }

        }

        public List<Brand> GetBrands(string search, int pageNo)
        {
            int pageSize = int.Parse(BasicConfigService.Instance.GetBasicConfiguration("ListingPageSize").ConfigDescription);
            using (var context = new ACContext())
            {
                if (!String.IsNullOrEmpty(search))
                    return context.Brands.Where(x => x.Name != null && x.Name.ToLower()
                        .Contains(search.ToLower()))
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                else
                    return context.Brands
                        .OrderBy(x => x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
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
