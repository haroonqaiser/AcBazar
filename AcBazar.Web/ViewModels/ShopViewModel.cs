using AcBazar.Entities;
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
}