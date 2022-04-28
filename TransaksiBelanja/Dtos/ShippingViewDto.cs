﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class ShippingViewDto
    {
        public int Id { get; set; }
        public int ShoppingId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int ShippingCost { get; set; }
    }
}
