using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class ArticleBundleService
    {
        private readonly HttpClient httpClient;
        public ArticleBundleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<ArticleBundle>> GetSuppliers()
        {
            return await httpClient.GetFromJsonAsync<ArticleBundle[]>("/api/articleBundles");
        }
    }
}
