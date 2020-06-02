using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTPractice.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public Decimal UnitPrice { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
