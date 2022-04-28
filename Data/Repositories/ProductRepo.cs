using Data.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepo : IProduct
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteProduct = await GetById(id);
                _context.Products.Remove(deleteProduct);
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

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await _context.Products.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Product>> GetByCategory(string name)
        {
            var result = await _context.Products.Where(s => s.ProductCategory.Contains(name)).ToListAsync();
            if (result == null) throw new Exception($"Data Product dengan nama: {name} tidak ditemukan");
            return result;
        }

        public async Task<Product> GetById(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Product id: {id} tidak ditemukan");
            return result;
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            var result = await _context.Products.Where(s => s.ProductName.Contains(name)).ToListAsync();
            if (result == null) throw new Exception($"Data Element dengan nama: {name} tidak ditemukan");
            return result;
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

        public async Task<Product> Update(int id, Product entity)
        {
            try
            {
                var updateProduct = await GetById(id);
                updateProduct.ProductName = entity.ProductName;
                await _context.SaveChangesAsync();
                return updateProduct;
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
