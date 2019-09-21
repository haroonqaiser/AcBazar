using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Database
{
    public class ACContext : DbContext
    {
        public ACContext() : base("ACBazarConnection")
        {

        }

        public DbSet<BasicConfiguration> BasicConfiguration { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSpecs> ProductSpecs { get; set; }
        public DbSet<ProductSpecMapp> ProductSpecMapps { get; set; }
    }
}
