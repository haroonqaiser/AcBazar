using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Entities
{
    public class Brand : BaseEntity
    {
        public string ImageURL { get; set; }
        public List<Product> Products { get; set; }
    }
}
