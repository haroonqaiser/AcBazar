using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Entities
{
    public class BasicConfiguration
    {
        [Key]
        public string ConfigKey { get; set; }
        public string ConfigDescription { get; set; }
    }
}
