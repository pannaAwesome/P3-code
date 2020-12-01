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

        public async void CreateCompanyCode(CompanyCode code)
        {
            var result = await httpClient.PostAsJsonAsync("/api/companycodes", code);
        }

        public async void UpdateCompanyCode(int id, CompanyCode code)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/companycodes/{id}", code);
        }

        public async void DeleteCompanyCode(int id)
        {
            await httpClient.DeleteAsync($"/api/companycodes/{id}");
        }
    }
}
