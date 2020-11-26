using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class InformCostTypeService
    {
        private readonly HttpClient httpClient;
        public InformCostTypeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<InformCostType>> GetInformCostTypes()
        {
            return await httpClient.GetFromJsonAsync<InformCostType[]>("/api/informCostTypes");
        }

        public async Task<InformCostType> CreateInformCostType(InformCostType type)
        {
            var result = await httpClient.PostAsJsonAsync("/api/informCostTypes", type);
            return await result.Content.ReadAsAsync<InformCostType>();
        }

        public async Task<InformCostType> DeleteInformCostType(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/informCostTypes/{id}");
            return await result.Content.ReadAsAsync<InformCostType>();
        }

        public async Task<InformCostType> UpdateInformCostType(int id, InformCostType type)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/informCostType/{id}", type);
            return await result.Content.ReadAsAsync<InformCostType>();
        }
    }
}
