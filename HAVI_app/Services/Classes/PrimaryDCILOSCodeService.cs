using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class PrimaryDCILOSCodeService
    {
        private readonly HttpClient httpClient;
        public PrimaryDCILOSCodeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<PrimaryDciloscode>> GetPrimaryDCILOSCodes(int id)
        {
            return await httpClient.GetFromJsonAsync<List<PrimaryDciloscode>>($"/api/PrimaryDciloscodes/country/{id}");
        }

        public async Task<PrimaryDciloscode> CreatePrimaryDCILOSCode(PrimaryDciloscode code)
        {
            var result = await httpClient.PostAsJsonAsync("/api/PrimaryDciloscodes", code);
            return await result.Content.ReadAsAsync<PrimaryDciloscode>();
        }

        public async void DeletePrimaryDCILOSCode(int id)
        {
            await httpClient.DeleteAsync($"/api/PrimaryDciloscodes/{id}");
        }

        public async void UpdatePrimaryDCILOSCode(int id, PrimaryDciloscode code)
        {
            await httpClient.PutAsJsonAsync($"/api/PrimaryDciloscodes/{id}", code);
        }
    }
}
