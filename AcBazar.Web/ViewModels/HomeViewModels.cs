using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcBazar.Web.ViewModels
{
    public class HomeViewModels
    {
        public List<ProductType> ProductType { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Brand> Brand { get; set; }
        public List<BasicConfiguration> BasicConfigurations { get; set; }
        public BasicConfiguration BasicConfiguration { get; set; }
    }
}