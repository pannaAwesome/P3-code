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

        public async Task<IEnumerable<ArticleInformation>> GetArticleInformations()
        {
            return await httpClient.GetFromJsonAsync<ArticleInformation[]>("/api/articleInformations");
        }

        public async Task<ArticleInformation> CreateArticleInformation(ArticleInformation articleInformation)
        {
            var result = await httpClient.PostAsJsonAsync("/api/articleInformations", articleInformation);
            return await result.Content.ReadAsAsync<ArticleInformation>();
        }

        public async Task<ArticleInformation> UpdateArticleInformation(int id, ArticleInformation articleInformation)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/articleInformations/{id}", articleInformation);
            return await result.Content.ReadAsAsync<ArticleInformation>();
        }
    }
}
