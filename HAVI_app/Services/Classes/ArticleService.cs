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

        public async Task<List<Article>> GetArticleWithCertainState(int countryid, int state)
        {
            return await httpClient.GetFromJsonAsync<List<Article>>($"/api/articles/country/{state}/{countryid}");
        }

        public async Task<List<Article>> GetArticlesForCountry(int countryid)
        {
            return await httpClient.GetFromJsonAsync<List<Article>>($"/api/articles/country/{countryid}");
        }

        public async Task<Article> GetArticle(int id)
        {
            return await httpClient.GetFromJsonAsync<Article>($"/api/articles/{id}");
        }

        public async Task<List<Article>> GetArticles()
        {
            return await httpClient.GetFromJsonAsync<List<Article>>("/api/articles");
        }

        public async void CreateArticle(Article article)
        {
            await httpClient.PostAsJsonAsync("/api/articles", article);
        }

        public async void UpdateArticle(int id, Article article)
        {
            await httpClient.PutAsJsonAsync($"/api/articles/{id}", article);
        }

        public async void DeleteArticle(int id)
        {
            await httpClient.DeleteAsync($"/api/articles/{id}");
        }
    }
}
