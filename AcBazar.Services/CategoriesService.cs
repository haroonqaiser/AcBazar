using AcBazar.Database;
using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Services
{
    public class CategoriesService
    {
        #region Singleton
        private static CategoriesService instance { get; set; }
        public static CategoriesService Instance
        {
            get
            {
                if (instance == null) instance = new CategoriesService();
                return instance;
            }
        }
        CategoriesService()
        {
        }

        #endregion
      
        public Category GetCategory(int ID)
        {
            using (var context = new ACContext())
            {
                return context.Categories.Find(ID);
            }

        }
        public List<Category> GetCategories()
        {
            using (var context = new ACContext())
            {
                return context.Categories.ToList();
            }

        }

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new ACContext())
            {
                return context.Categories.Where(x=>x.IsFeatured).ToList();
            }

        }

        public int GetCategoriesCount(string search)
        {
            using (var context = new ACContext())
            {
                if (!String.IsNullOrEmpty(search))
                    return context.Categories.Where(x => x.Name.ToLower().Contains(search.ToLower())).Count();
                else
                    return context.Categories.Count();
            }

        }

        public List<Category> GetCategories(string search, int pageNo)
        {
            int pageSize = int.Parse(BasicConfigService.Instance.GetBasicConfiguration("ListingPageSize").ConfigDescription);
            using (var context = new ACContext())
            {
                if (!String.IsNullOrEmpty(search))
                    return context.Categories.Where(x => x.Name !=null && x.Name.ToLower()
                        .Contains(search.ToLower()))
                        .OrderBy(x=>x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                else
                return context.Categories
                        .OrderBy(x=>x.ID)
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

    //            return context.Categories.Where(x => x.Name != null && x.Name.ToLower()
    //.Contains(search.ToLower()))
    //.OrderBy(x => x.ID)
    //.Skip((pageNo - 1) * pageSize)
    //.Take(pageSize)
    //.Include(x => x.Products)
    //.ToList();

            }
        }


        public void SaveCategory(Category category)
        {
            using (var context = new ACContext())
            {
                category.RowAddDate = System.DateTime.Now;
                context.Categories.Add(category);
                context.SaveChanges();
            }   
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new ACContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void DeleteCategory(Category category)
        {
            using (var context = new ACContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

        }
    }
}
