using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public Shopping Shopping { get; set; }
        public int OrderTotal { get; set; }
        public int ShippingCost { get; set; }
        public int TotalPayment { get; set; }
    }
}
