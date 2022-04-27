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
        public int ProductId { get; set; }
        public List<Product> Product { get; set; }
        public int TotalOrder { get; set; }
        public DateTime ShoppingTime { get; set; }
    }
}
