namespace KatalogProduk.Models
{
    public class Produk
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        //public int ProductStock { get; set; }
        //public List<Shopping> Shopping { get; set; }
    }
}
