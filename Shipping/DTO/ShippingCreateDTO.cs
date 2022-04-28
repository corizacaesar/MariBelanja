using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping.DTO
{
    public class ShippingCreateDTO
    {
        public int ShoppingId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int ShippingCost { get; set; }
    }
}