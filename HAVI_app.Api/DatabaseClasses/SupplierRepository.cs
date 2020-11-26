using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly HAVIdatabaseContext _context;
        public SupplierRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            var profile = await _context.Profiles.AddAsync(supplier.Profile);
            await _context.SaveChangesAsync();

            supplier.ProfileId = _context.Profiles.FirstOrDefault(p => p.Username == supplier.Profile.Username).Id;
            var result = await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Supplier> DeleteSupplierAsync(int supplierId)
        {
            var result = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);
            
            if (result != null)
            {
                _context.Suppliers.Remove(result);
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Supplier> GetSupplier(int supplierId)
        {
            return await _context.Suppliers
                                 .Include(s => s.Profile)
                                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _context.Suppliers
                                 .Include(s => s.Profile)
                                 .ToListAsync();
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            var result = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplier.Id);
            if (result != null)
            {
                result.CompanyName = supplier.CompanyName;
                result.CompanyLocation = supplier.CompanyLocation;
                result.PalletExchange = supplier.PalletExchange;
                result.FreightResponsibility = supplier.FreightResponsibility;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}

