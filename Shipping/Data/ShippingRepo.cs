using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shipping.Models;
using TransaksiBelanja.Models;
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

        public async Task<IEnumerable<Ship>> GetAll()
        {
            var results = await _context.Shippings.OrderBy(s => s.Id).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Ship> GetById(int id)
        {
            var result = await _context.Shippings.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Shipping id : {id} tidak ditemukan");
            return result;
        }

        public async Task<Ship> Insert(Ship obj)
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

        public async Task<Ship> Update(int id, Ship obj)
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


        public bool ExternalShoppingExist(int externalShoppingId)
        {
            return _context.Shoppings.Any(p=>p.ExternalID == externalShoppingId);
        }

        public IEnumerable<Shopping> GetAllShopping()
        {
            return _context.Shoppings.ToList();
        }
        public bool ShoppingExist(int ShoppingId)
        {
            return _context.Shoppings.Any(p=>p.Id==ShoppingId);
        }
        public void CreateShopping(Shopping shopping)
        {
            if(shopping==null)
                throw new ArgumentNullException(nameof(shopping));
            _context.Shoppings.Add(shopping);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
        
    }
}