using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.Shopping
{
    public class ShoppingCreateDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TotalOrder { get; set; }
        public DateTime ShoppingTime { get; set; }
    }
}
