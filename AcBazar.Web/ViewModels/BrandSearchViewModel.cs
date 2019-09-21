using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcBazar.Web.ViewModels
{
    public class BrandSearchViewModel
    {
        public List<Brand> brand { get; set; }
        public string SearchTerm { get; set; }
        public Pager pager { get; set; }
    }
}