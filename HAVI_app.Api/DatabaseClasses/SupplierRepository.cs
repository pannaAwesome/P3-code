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
            await _context.Profiles.AddAsync(supplier.Profile);
            await _context.SaveChangesAsync();

            var result = await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Supplier> DeleteSupplierAsync(int supplierId)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == supplier.ProfileId);

            if (supplier != null && profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
                return supplier;
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
            var resultSupplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplier.Id);
            var resultProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == resultSupplier.ProfileId);
            if (resultSupplier != null && resultProfile != null)
            {
                resultProfile.Username = supplier.Profile.Username;
                resultProfile.Password = supplier.Profile.Password;
                resultSupplier.CompanyName = supplier.CompanyName;
                resultSupplier.CompanyLocation = supplier.CompanyLocation;
                resultSupplier.PalletExchange = supplier.PalletExchange;
                resultSupplier.FreightResponsibility = supplier.FreightResponsibility;
                await _context.SaveChangesAsync();
                return resultSupplier;
            }

            return null;
        }
    }
}

