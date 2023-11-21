using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductToOrder_Product
    {
        public int productid { get; set; }
        public int orderid { get; set; }
        public int orderQuantity { get; set; }

        public string? Name { get; set; }
    }
}
