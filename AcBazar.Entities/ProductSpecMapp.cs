using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Entities
{
    public class ProductSpecMapp
    {
        public Product Product { get; set; }
        public ProductSpecs ProductSpecs { get; set; }
        public int ProductID { get; set; }
        public int SpecKey { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class ProductSpecMapList
    {
        public string ProductID { get; set; }
        public string Name { get; set; }

    }
}
