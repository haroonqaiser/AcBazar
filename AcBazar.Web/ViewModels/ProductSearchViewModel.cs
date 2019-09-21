using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcBazar.Web.ViewModels
{
    public class ProductSearchViewModel
    {
        public List<Product> product { get; set; }
        public string SearchTerm { get; set; }
        public Pager pager { get; set; }
    }
}