using KatalogProduk.Models;
using Microsoft.EntityFrameworkCore;

namespace KatalogProduk.Data
{
    public class ProdukRepo : IProduk
    {
        private AppDbContext _context;

        public ProdukRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteProduk = await GetById(id);
                _context.Produks.Remove(deleteProduk);
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Produk>> GetAll()
        {
            var results = await _context.Produks.OrderBy(s => s.Id).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Produk> GetById(int id)
        {
            var result = await _context.Produks.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Produk id : {id} tidak ditemukan");
            return result;
        }

        public async Task<Produk> Insert(Produk obj)
        {
            try
            {
                _context.Produks.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produk> Update(int id, Produk obj)
        {
            try
            {
                var updateProduk = await GetById(id);

                updateProduk.ProductName = obj.ProductName;
                updateProduk.ProductPrice = obj.ProductPrice;
                updateProduk.ProductDescription = obj.ProductDescription;
                updateProduk.ProductCategory = obj.ProductCategory;
                await _context.SaveChangesAsync();
                return updateProduk;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
