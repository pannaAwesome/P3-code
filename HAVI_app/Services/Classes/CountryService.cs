using HAVI_app.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class CountryService
    {
        private readonly HttpClient httpClient;
        public CountryService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Country> GetCountry(int id)
        {
            return await httpClient.GetFromJsonAsync<Country>($"/api/countries/{id}");
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await httpClient.GetFromJsonAsync<Country[]>("/api/countries");
        }

        public async Task<Country> CreateSupplier(Country country)
        {
            var result = await httpClient.PostAsJsonAsync("/api/countries", country);
            return await result.Content.ReadAsAsync<Country>();
        }

        public async Task<Country> UpdateSupplier(int id, Country country)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/countries/{id}", country);
            return await result.Content.ReadAsAsync<Country>();
        }

        public async Task<Country> DeleteSupplier(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/countries/{id}");
            return await result.Content.ReadAsAsync<Country>();
        }
    }
}
