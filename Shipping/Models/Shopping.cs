using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Models;

namespace TransaksiBelanja.Models
{
    public class Shopping
    {
        public int Id { get; set; }
        public int ExternalID { get; set; }
        public DateTime ShoppingTime { get; set; }
    }
}
