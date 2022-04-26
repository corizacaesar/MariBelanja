using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Shopping
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
