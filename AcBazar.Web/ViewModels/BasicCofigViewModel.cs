using AcBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcBazar.Web.ViewModels
{
    public class BasicCofigViewModel
    {
        public List<Brand> Brand { get; set; }
        public BasicConfiguration BasicConfiguration { get; set; }

    }
}