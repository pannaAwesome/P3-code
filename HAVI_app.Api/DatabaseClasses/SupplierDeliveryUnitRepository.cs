
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class SupplierDeliveryUnitRepository
    {
        private readonly HAVIdatabaseContext _context;
        public SupplierDeliveryUnitRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<SupplierDeliveryUnit> AddSupplierDeliveryUnit(SupplierDeliveryUnit deliveryUnit)
        {
            var result = await _context.SupplierDeliveryUnits.AddAsync(deliveryUnit);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<SupplierDeliveryUnit> GetSupplierDeliveryUnit(int DeliveryUnitId)
        {
            return await _context.SupplierDeliveryUnits.FirstOrDefaultAsync(s => s.Id == DeliveryUnitId);
        }

        public async Task<SupplierDeliveryUnit> DeleteSupplierDeliveryUnitAsync(int deliveryUnitId)
        {
            var result = await _context.SupplierDeliveryUnits.FirstOrDefaultAsync(s => s.Id == deliveryUnitId);
            if (result != null)
            {
                _context.SupplierDeliveryUnits.Remove(result);
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<IEnumerable<SupplierDeliveryUnit>> GetSupplierDeliveryUnits(int countryId)
        {
            return await _context.SupplierDeliveryUnits
                                 .Where(s => s.CountryId == countryId)
                                 .ToListAsync();
        }

        public async Task<SupplierDeliveryUnit> UpdateSupplierDeliveryUnit(SupplierDeliveryUnit deliveryUnit)
        {
            var result = await _context.SupplierDeliveryUnits.FirstOrDefaultAsync(s => s.Id == deliveryUnit.Id);
            if (result != null)
            {
                result.Unit = deliveryUnit.Unit;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
