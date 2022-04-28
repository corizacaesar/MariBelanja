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
            var result = await _context.Shippings.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Shipping> GetById(int id)
        {
            var result = await _context.Shippings.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Shipping id: {id} tidak ditemukan");
            return result;
        }

        public async Task<Shipping> Insert(Shipping entity)
        {
            try
            {
                _context.Shippings.Add(entity);
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

        public async Task<Shipping> Update(int id, Shipping entity)
        {
            try
            {
                var updateShipping = await GetById(id);
                updateShipping.ShoppingId = entity.ShoppingId;
                updateShipping.ShippingCost = entity.ShippingCost;
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
