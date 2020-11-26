using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class CountryRepository : ICountryRepository
    {
        private readonly HAVIdatabaseContext _context;
        public CountryRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Country> AddCountry(Country country)
        {
            var profile = await _context.Profiles.AddAsync(country.Profile);
            await _context.SaveChangesAsync();

            var result = await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Country> DeleteCountryAsync(int countryId)
        {
            var result = await _context.Countries.Include(s => s.Profile)
                                                 .FirstOrDefaultAsync(s => s.Id == countryId);
            if (result != null)
            {
                _context.Countries.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Supplier> DeleteSupplierAsync(int supplierId)
        {
            var result = await _context.Suppliers
                                       .Include(s => s.Profile)
                                       .FirstOrDefaultAsync(s => s.Id == supplierId);
            if (result != null)
            {
                _context.Suppliers.Remove(result);
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Country> GetCountry(int countryId)
        {
            return await _context.Countries.FirstOrDefaultAsync(s => s.Id == countryId);
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            var result = await _context.Countries.FirstOrDefaultAsync(s => s.Id == country.Id);
            if (result != null)
            {
                result.CountryCode = country.CountryCode;
                result.CountryName = country.CountryName;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
