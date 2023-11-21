using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomerOrder
    {
        public int id { get; set;}
        public int customerid { get; set;}
        public bool isPacked { get; set;}
        public bool isSent { get; set;}
        public bool isDelivered { get; set;}
    }
}
