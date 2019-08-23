using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
    }
}
