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

        public async Task<Country> GetCountry(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
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
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryId);
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == country.Id);
            
            if (country != null && profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();

                return country;
            }

            return null;
        }

        public async Task<Country> GetCountryEverything(int countryId)
        {
            return await _context.Countries
                                 .Include(c => c.Profile)
                                 .Include(c => c.Articles)
                                 .FirstOrDefaultAsync(s => s.Id == countryId);
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Countries
                                 .Include(c => c.Profile)
                                 .ToListAsync();
        }

        public async Task<Country> UpdateCountry(Country country)
        {   
            var resultCountry = await _context.Countries.FirstOrDefaultAsync(c => c.Id == country.Id);
            var resultProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == resultCountry.ProfileId);

            if (resultCountry != null && resultProfile != null)
            {
                resultProfile.Password = country.Profile.Password;
                resultCountry.CountryCode = country.CountryCode;
                resultCountry.CountryName = country.CountryName;
                await _context.SaveChangesAsync();
                return resultCountry;
            }

            return null;
        }
    }
}
