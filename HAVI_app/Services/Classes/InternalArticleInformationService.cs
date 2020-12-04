using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class InternalArticleInformationService
    {
        private readonly HttpClient httpClient;
        public InternalArticleInformationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<InternalArticleInformation> GetInternalArticleInformation(int id)
        {
            return await httpClient.GetFromJsonAsync<InternalArticleInformation>($"/api/internalArticleInformations/{id}");
        }

        public async Task UpdateInternalArticleInformation(int id, InternalArticleInformation internalArticleInformation)
        {
            await httpClient.PutAsJsonAsync($"/api/internalArticleInformations/{id}", internalArticleInformation);
        }
    }
}
