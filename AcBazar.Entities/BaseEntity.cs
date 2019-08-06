using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcBazar.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RowAddUser { get; set; }
        public DateTime RowAddDate { get; set; }
    }
}
