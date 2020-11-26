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

        public async Task<IEnumerable<PrimaryDciloscode>> GetPrimaryDCILOSCodes()
        {
            return await httpClient.GetFromJsonAsync<PrimaryDciloscode[]>("/api/PrimaryDciloscodes");
        }

        public async Task<PrimaryDciloscode> CreatePrimaryDCILOSCode(PrimaryDciloscode code)
        {
            var result = await httpClient.PostAsJsonAsync("/api/PrimaryDciloscodes", code);
            return await result.Content.ReadAsAsync<PrimaryDciloscode>();
        }

        public async Task<PrimaryDciloscode> DeletePrimaryDCILOSCode(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/PrimaryDciloscodes/{id}");
            return await result.Content.ReadAsAsync<PrimaryDciloscode>();
        }

        public async Task<PrimaryDciloscode> UpdatePrimaryDCILOSCode(int id, PrimaryDciloscode code)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/PrimaryDciloscodes/{id}", code);
            return await result.Content.ReadAsAsync<PrimaryDciloscode>();
        }
    }
}
