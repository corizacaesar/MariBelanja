using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos
{
    public class ShoppingPublishDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Event { get; set; }

    }
}