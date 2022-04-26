using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Shipping
{
    public class ShippingCreateDto
    {
        public string BuyerName { get; set; }
        public int ShippingCost { get; set; }
    }
}
