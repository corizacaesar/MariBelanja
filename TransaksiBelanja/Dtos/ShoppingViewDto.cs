using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class ShoppingViewDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime ShoppingTime { get; set; }
    }
}
