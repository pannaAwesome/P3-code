using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class BundleService
    {
        private readonly HttpClient httpClient;
        public BundleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Bundle> GetBundle(int id)
        {
            return await httpClient.GetFromJsonAsync<Bundle>($"/api/bundles/{id}");
        }

        public async Task<List<Bundle>> GetBundles()
        {
            return await httpClient.GetFromJsonAsync<List<Bundle>>("/api/bundles");
        }

        public async Task<Bundle> UpdateBundle(int id, Bundle bundle)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/bundles/{id}", bundle);
            return await result.Content.ReadAsAsync<Bundle>();
        }
    }
}
