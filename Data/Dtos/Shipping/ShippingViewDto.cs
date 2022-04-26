using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Shipping
{
    public class ShippingViewDto
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public int TotalOrder { get; set; }
        public int ShippingCost { get; set; }
        public int TotalPayment { get; set; }
    }
}
