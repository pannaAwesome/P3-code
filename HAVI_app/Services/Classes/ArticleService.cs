using HAVI_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
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

        public async Task<List<Article>> GetArticlesForSupplier(int supplierId)
        {
            return await httpClient.GetFromJsonAsync<List<Article>>($"/api/articles/supplier/{supplierId}");
        }

        public async Task<List<Article>> GetArticlesForPurchaser(int purchaserId)
        {
            return await httpClient.GetFromJsonAsync<List<Article>>($"/api/articles/purchaser/{purchaserId}");
        }

        public async Task<Article> GetArticle(int id)
        {
            return await httpClient.GetFromJsonAsync<Article>($"/api/articles/{id}");
        }

        public async Task<Article> GetArticleWithInformation(int id)
        {
            return await httpClient.GetFromJsonAsync<Article>($"/api/articles/information/{id}");
        }

        public async Task<Article> GetArticleWithInternal(int id)
        {
            return await httpClient.GetFromJsonAsync<Article>($"/api/articles/internal/{id}");
        }

        public async Task<List<Article>> GetArticles()
        {
            return await httpClient.GetFromJsonAsync<List<Article>>("/api/articles");
        }

        public async Task<Article> CreateArticle(Article article)
        {
            var result = await httpClient.PostAsJsonAsync("/api/articles", article);
            return await result.Content.ReadAsAsync<Article>();
        }

        public async Task UpdateArticle(int id, Article article)
        {
            await httpClient.PutAsJsonAsync($"/api/articles/{id}", article);
        }

        public async Task DeleteArticle(int id)
        {
            await httpClient.DeleteAsync($"/api/articles/{id}");
        }
    }
}
