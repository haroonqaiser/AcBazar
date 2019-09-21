using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ProductType ProductType { get; set; }
        public int? ProductTypeID { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool IsSale  { get; set; }
        public bool IsNew { get; set; }
        public bool IsBest { get; set; }
        public bool IsCancel { get; set; }
        public decimal AmountDis { get; set; }
        public int AmountDisPer { get; set; }

    }
}
