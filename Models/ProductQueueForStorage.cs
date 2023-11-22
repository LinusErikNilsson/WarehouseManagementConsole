using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductQueueForStorage
    {
        public int id { get; set; }
        public int productid { get; set; }
        public int quantity { get; set; }

        public string? name { get; set; }
    }
}
