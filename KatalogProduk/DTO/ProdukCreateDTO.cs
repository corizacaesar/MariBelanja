using System.ComponentModel.DataAnnotations;

namespace KatalogProduk.DTO
{
    public class ProdukCreateDTO
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductCategory { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int ProductPrice { get; set; }
    }
}
