

using KatalogProduk.Models;
using Microsoft.EntityFrameworkCore;

namespace KatalogProduk.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Produk> Produks { get; set; }
    }
}
