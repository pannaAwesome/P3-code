using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseInterfaces
{
    pubic interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(int countryId);
        Task<Country> AddCountry(Country country);
        Task<Country> UpdateCountry(Country country);
        void DeleteCountryAsync(int countryId);
    }
}
