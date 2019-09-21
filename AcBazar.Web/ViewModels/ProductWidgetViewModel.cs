using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcBazar.Web.ViewModels
{
    public class ProductWidgetViewModel
    {
        public List<Product> Product { get; set; }
        public bool IsBest { get; set; }
        public string ProductTitle { get; set; }
    }
}