using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class ILOSCategoriesService
    {
        private readonly HttpClient httpClient;
        public ILOSCategoriesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Iloscategory>> GetILOSCategories(int id)
        {
            return await httpClient.GetFromJsonAsync<List<Iloscategory>>($"/api/ilosCategories/country/{id}");
        }

        public async Task<Iloscategory> CreateILOSCategory(Iloscategory ilosCategory)
        {
            var result = await httpClient.PostAsJsonAsync("/api/ilosCategories", ilosCategory);
            return await result.Content.ReadAsAsync<Iloscategory>();
        }

        public async Task<Iloscategory> UpdateILOSCategory(int id, Iloscategory ilosCategory)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/ilosCategories/{id}", ilosCategory);
            return await result.Content.ReadAsAsync<Iloscategory>();
        }

        public async void DeleteILOSCategory(int id)
        {
            await httpClient.DeleteAsync($"/api/ilosCategoies/{id}");
        }
    }
}
