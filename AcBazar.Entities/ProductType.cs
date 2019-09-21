using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Entities
{
    public class ProductType:BaseEntity
    {
        public string ImageURL { get; set; }
        public List<Product> Products { get; set; }
    }
}
