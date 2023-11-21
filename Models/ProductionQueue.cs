using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductionQueue
    {
        public int id { get; set; }
        public int materialId { get; set; }
        public int quantity { get; set; }
        public int priority {  get; set; }
    }
}
