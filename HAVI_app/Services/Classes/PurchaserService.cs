using HAVI_app.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class PurchaserService
    {
        private readonly HttpClient httpClient;
        public PurchaserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Purchaser>> GetPurchasersForCountry(int id)
        {
            return await httpClient.GetFromJsonAsync<Purchaser[]>($"/api/purchasers/country/{id}");
        }

        public async Task<Purchaser> GetPurchaser(int id)
        {
            return await httpClient.GetFromJsonAsync<Purchaser>($"/api/purchasers/{id}");
        }

        public async Task<IEnumerable<Purchaser>> GetPurchasers()
        {
            return await httpClient.GetFromJsonAsync<Purchaser[]>("/api/purchasers");
        }

        public async Task<Purchaser> CreatePurchaser(Purchaser purchaser)
        {
            var result = await httpClient.PostAsJsonAsync("/api/purchasers", purchaser);
            return await result.Content.ReadAsAsync<Purchaser>();
        }

        public async Task<Purchaser> DeletePurchaser(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/purchasers/{id}");
            return await result.Content.ReadAsAsync<Purchaser>();
        }

        public async Task<Purchaser> UpdatePurchaser(int id, Purchaser purchaser)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/purchasers/{id}", purchaser);
            return await result.Content.ReadAsAsync<Purchaser>();
        }
    }
}
