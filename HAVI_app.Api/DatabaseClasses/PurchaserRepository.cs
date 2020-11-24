using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class PurchaserRepository : IPurchaserRepository
    {
        private readonly HAVIdatabaseContext _context;
        public PurchaserRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Purchaser> AddPuchaser(Purchaser purchaser)
        {
            var result = await _context.Purchasers.AddAsync(purchaser);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async void DeletePurchaserAsync(int purchaserId)
        {
            var result = await _context.Purchasers.FirstOrDefaultAsync(s => s.Id == purchaserId);
            if (result != null)
            {
                _context.Purchasers.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Purchaser> GetPurchaser(int purchaserId)
        {
            return await _context.Purchasers.FirstOrDefaultAsync(s => s.Id == purchaserId);
        }

        public async Task<IEnumerable<Purchaser>> GetPurchasers()
        {
            return await _context.Purchasers.ToListAsync();
        }
    }
}
