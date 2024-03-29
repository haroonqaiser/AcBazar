﻿using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcBazar.Web.ViewModels
{
    public class CheckoutViewModel
    {
        public List<Product> CardProducts { get; set; }
        public List<int> ProductIDs { get; set; }

    }

    public class ShopViewModel
    {
        public int MaximumPrice { get; set; }
        public List<Category> FeaturedCategories { get; set; }
        public List<Product> Products { get; set; }
        public int? sortBy { get; set; }
        public int? CategoryID { get; set; }
        public Pager Pager { get; set; }
    }

    public class FilterProductsViewModel
    {
        public  List<Product> Products { get; set; }
        public Pager Pager { get; set; }
    }
}