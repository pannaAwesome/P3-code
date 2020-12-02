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

        public async Task<Country> GetCountryWithProfile(int id)
        {
            return await httpClient.GetFromJsonAsync<Country>($"/api/countries/profile/{id}");
        }

        public async Task<Country> GetCountryWithName(string name)
        {
            return await httpClient.GetFromJsonAsync<Country>($"/api/countries/{name}");
        }

        public async Task<List<Country>> GetCountries()
        {
            return await httpClient.GetFromJsonAsync<List<Country>>("/api/countries");
        }

        public async Task<Country> CreateCountry(Country country)
        {
            var result = await httpClient.PostAsJsonAsync("/api/countries", country);
            return await result.Content.ReadAsAsync<Country>();
        }

        public async Task UpdateCountry(int id, Country country)
        {
            await httpClient.PutAsJsonAsync($"/api/countries/{id}", country);
        }

        public async Task DeleteCountry(int id)
        {
            await httpClient.DeleteAsync($"/api/countries/{id}");
        }
    }
}
