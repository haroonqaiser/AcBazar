using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Entities
{
    public class ProductSpecs
    {
        [Key]
        public int SpecKey { get; set; }
        [StringLength(75)]
        public string SpecValue { get; set; }
        [DefaultValue("string")]
        [StringLength(15)]
        //LongString for html tab textarea
        //string for general html inputbox  
        public string SpecInputValueType { get; set; }
        public int OrderSeq { get; set; }
    }

    
}
