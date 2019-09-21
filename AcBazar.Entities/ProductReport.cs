using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Entities
{
    public class ProductReport
    {
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal AmountDis { get; set; }

    }
}
