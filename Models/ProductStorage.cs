using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductStorage
    {
        public int Id { get; set; }
        public int Aisle { get; set; }
        public int Shelf { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
    }
}
