using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class ArticleService
    {
        private readonly HttpClient httpClient;
        public ArticleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Article> GetArticle(int id)
        {
            return await httpClient.GetFromJsonAsync<Article>($"/api/articles/{id}");
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await httpClient.GetFromJsonAsync<Article[]>("/api/articles");
        }

        public async Task<Article> CreateArticle(Article article)
        {
            var result = await httpClient.PostAsJsonAsync("/api/articles", article);
            return await result.Content.ReadAsAsync<Article>();
        }

        public async Task<Article> UpdateArticle(int id, Article article)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/articles/{id}", article);
            return await result.Content.ReadAsAsync<Article>();
        }

        public async Task<Article> DeleteArticle(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/articles/{id}");
            return await result.Content.ReadAsAsync<Article>();
        }
    }
}
