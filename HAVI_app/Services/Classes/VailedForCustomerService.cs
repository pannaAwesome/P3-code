using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class VailedForCustomerService
    {
        private readonly HttpClient httpClient;
        public VailedForCustomerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<VailedForCustomer>> GetVailedCustomers(int id)
        {
            return await httpClient.GetFromJsonAsync<List<VailedForCustomer>>($"/api/vailedForCustomers/country/{id}");
        }

        public async void CreateVailedForCustomer(VailedForCustomer customer)
        {
            await httpClient.PostAsJsonAsync("/api/vailedForCustomers", customer);
        }

        public async void DeleteVailedForCustomer(int id)
        {
            await httpClient.DeleteAsync($"/api/vailedForCustomers/{id}");
        }

        public async void UpdateVailedForCustomer(int id, VailedForCustomer customer)
        {
            await httpClient.PutAsJsonAsync($"/api/vailedForCustomers/{id}", customer);
        }
    }
}
