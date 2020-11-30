using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class CompanyCodeService
    {
        private readonly HttpClient httpClient;
        public CompanyCodeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<CompanyCode>> GetCompanyCodes(int id)
        {
            return await httpClient.GetFromJsonAsync<List<CompanyCode>>($"/api/companycodes/country/{id}");
        }

        public async Task<CompanyCode> CreateCompanyCode(CompanyCode code)
        {
            var result = await httpClient.PostAsJsonAsync("/api/companycodes", code);
            return await result.Content.ReadAsAsync<CompanyCode>();
        }

        public async Task<CompanyCode> UpdateCompanyCode(int id, CompanyCode code)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/companycodes/{id}", code);
            return await result.Content.ReadAsAsync<CompanyCode>();
        }

        public async void DeleteCompanyCode(int id)
        {
            await httpClient.DeleteAsync($"/api/companycodes/{id}");
        }
    }
}
