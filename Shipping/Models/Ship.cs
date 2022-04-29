using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shipping.Models
{
    public class Ship
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ShoppingId { get; set; }
        //[Required]
        //public Shopping Shopping { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public int ShippingCost { get; set; }

    }
}