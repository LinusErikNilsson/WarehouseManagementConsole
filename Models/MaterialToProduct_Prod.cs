using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MaterialToProduct_Prod
    {
        public int materialId { get; set; }
        public int productId { get; set; }
        public string? name { get; set; }
    }
}
