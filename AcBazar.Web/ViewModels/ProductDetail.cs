using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcBazar.Web.ViewModels
{
    public class ProductDetail
    {
        public Product product { get; set; }
        public List<ProductSpecs> productSpecs { get; set; }
        public List<ProductSpecMapp> productSpecMapp { get; set; }
    }
}