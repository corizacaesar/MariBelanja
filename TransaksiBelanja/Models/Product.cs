using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransaksiBelanja.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public Shopping? Shopping { get; set; }
    }
}
