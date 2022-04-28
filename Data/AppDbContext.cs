using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shopping> Shoppings { get; set; }
        public DbSet<Shipping> Shippings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shopping>().Property(so => so.ShoppingTime).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Shipping>().Property(si => si.DateStart).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Shipping>().Property(si => si.DateEnd).HasDefaultValueSql("getdate().AddDays(5)");
        }

    }
}
