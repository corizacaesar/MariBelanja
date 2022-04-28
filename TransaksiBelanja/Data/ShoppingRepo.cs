using TransaksiBelanja.Data;
using TransaksiBelanja.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransaksiBelanja.Data
{
    public class ShoppingRepo : IShopping
    {
        private readonly AppDbContext _context;

        public ShoppingRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteShopping = await GetById(id);
                _context.Shoppings.Remove(deleteShopping);
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

        public async Task<IEnumerable<Shopping>> GetAll()
        {
            var result = await _context.Shoppings.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Shopping> GetById(int id)
        {
            var result = await _context.Shoppings.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Shopping id: {id} tidak ditemukan");
            return result;
        }

        public async Task<Shopping> Insert(Shopping entity)
        {
            try
            {
                _context.Shoppings.Add(entity);
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

        public async Task<Shopping> Update(int id, Shopping entity)
        {
            try
            {
                var updateShopping = await GetById(id);                 
                updateShopping.ProductId = entity.ProductId;          
                await _context.SaveChangesAsync();                       
                return updateShopping;                                  
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
