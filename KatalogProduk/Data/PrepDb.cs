using KatalogProduk.Models;

namespace KatalogProduk.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateAsyncScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());

            }
        }

        private static void SeedData(AppDbContext context)
        {
            /* if (isProd)
             {
                 Console.WriteLine("--> Jalankan Perintah Migrasi");
                 try
                 {
                     context.Database.Migrate();
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine($"--> Perintah Migrasi gagal {ex.Message}");
                 }
             }*/
            if (!context.Produks.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                context.Produks.AddRange(
                    new Produk { ProductName = "Sanco", ProductCategory = "Minyak", ProductDescription = "Minyak Pouch Isi 2 liter", ProductPrice = 50000 },
                    new Produk { ProductName = "Lifebuoy", ProductCategory = "Sabun", ProductDescription = "dapat membersihkan tubuh terbebas dari kuman dan bakteri ", ProductPrice = 25000 },
                    new Produk { ProductName = "Panten", ProductCategory = "Shampo", ProductDescription = "Anti hair fall", ProductPrice = 30000}
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Data Platforms sudah ada..");

            }
        }
    }
}
