using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {

        }

    }
}
