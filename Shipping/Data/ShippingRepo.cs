using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.Model;
using Microsoft.EntityFrameworkCore;

namespace Shipping.Data
{
    public class ShippingRepo : IShipping
    {
        private readonly AppDbContext _context;

        public ShippingRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteShipping = await GetById(id);
                _context.Shippings.Remove(deleteShipping);
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

        public async Task<IEnumerable<Shipping>> GetAll()
        {
            var results = await _context.Shippings.OrderBy(s => s.Id).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Shipping> GetById(int id)
        {
            var result = await _context.Shippings.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Shipping id : {id} tidak ditemukan");
            return result;
        }

        public async Task<Shipping> Insert(Shipping obj)
        {
            try
            {
                _context.Shippings.Add(obj);
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

        public async Task<Shipping> Update(int id, Shipping obj)
        {
            try
            {
                var updateShipping = await GetById(id);

                updateShipping.ShoppingId = obj.ShoppingId;
                updateShipping.ShippingCost = obj.ShippingCost;
                updateShipping.DateStart = obj.DateStart;
                updateShipping.DateEnd = obj.DateEnd;
                await _context.SaveChangesAsync();
                return updateShipping;
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