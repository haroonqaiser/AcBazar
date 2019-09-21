using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcBazar.Web.ViewModels
{
    public class ProductTypeSearchViewModel
    {
        public List<ProductType> productTypes { get; set; }
        public string SearchTerm { get; set; }
        public Pager pager { get; set; }
    }
}