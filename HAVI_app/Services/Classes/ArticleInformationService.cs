using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class ArticleInformationService
    {
        private readonly HttpClient httpClient;
        public ArticleInformationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<ArticleInformation> GetArticleInformation(int id)
        {
            return await httpClient.GetFromJsonAsync<ArticleInformation>($"/api/articleInformations/{id}");
        }

        public async Task UpdateArticleInformation(int id, ArticleInformation articleInformation)
        {
            await httpClient.PutAsJsonAsync($"/api/articleInformations/{id}", articleInformation);
        }
    }
}
