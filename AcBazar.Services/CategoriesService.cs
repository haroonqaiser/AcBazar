using AcBazar.Database;
using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Services
{
    public class CategoriesService
    {
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
