using System.ComponentModel.DataAnnotations;

namespace KatalogProduk.Models
{
    public class Produk
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductCategory { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        //public int ProductStock { get; set; }
        //public List<Shopping> Shopping { get; set; }
    }
}
