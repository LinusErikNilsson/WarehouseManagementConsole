using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductOrder_Customer
    {
        public int id { get; set; }
        public string? Surname { get; set; }
        public string? Lastname { get; set; }

        public string? Phonenumber { get; set; }
        public bool isPacked { get; set; }
        public bool isSent { get; set; }
        public bool isDelivered { get; set; }
    }
}
