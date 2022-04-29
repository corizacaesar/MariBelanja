using Microsoft.EntityFrameworkCore;
using TransaksiBelanja.Models;

namespace TransaksiBelanja.Data
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await _context.Products.AsNoTracking().ToListAsync();
            return result;
        }

        public Task<IEnumerable<Product>> GetByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Insert(Product entity)
        {
            try
            {
                _context.Products.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
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

        public Task<Product> Update(int id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
