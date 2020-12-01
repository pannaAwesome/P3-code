using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class CreationCodeService
    {
        private readonly HttpClient httpClient;
        public CreationCodeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<CreationCode> GetCreationCode(int id)
        {
            return await httpClient.GetFromJsonAsync<CreationCode>($"/api/creationCodes/{id}");
        }

        public async Task<CreationCode> CreateCreationCode(CreationCode creationCode)
        {
            var result = await httpClient.PostAsJsonAsync("/api/creationCodes", creationCode);
            return await result.Content.ReadAsAsync<CreationCode>();
        }

        public async Task<CreationCode> UpdateCreationCode(int id, CreationCode creationCode)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/creationCodes/{id}", creationCode);
            return await result.Content.ReadAsAsync<CreationCode>();
        }
    }
}
