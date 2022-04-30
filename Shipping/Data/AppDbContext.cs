using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.Models;
using TransaksiBelanja.Models;
using Microsoft.EntityFrameworkCore;

namespace Shipping.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Ship> Shippings { get; set; }
        public DbSet<Shopping> Shoppings { get; set; }
    }
}