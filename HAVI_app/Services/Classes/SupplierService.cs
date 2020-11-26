using HAVI_app.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class SupplierService 
    {
        private readonly HttpClient httpClient;
        public SupplierService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Supplier> GetSupplier(int id)
        {
            return await httpClient.GetFromJsonAsync<Supplier>($"/api/suppliers/{id}"); 
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await httpClient.GetFromJsonAsync<Supplier[]>("/api/suppliers");
        }
        /*
        public async Task<ActionResult> CreateSupplier(Supplier supplier)
        {
            var result = await httpClient.PostAsJsonAsync("/api/suppliers", supplier);
            var addedSupplier = result.Content.ReadAsAsync<Supplier>();
            if (result.IsSuccessStatusCode)
            {

            }
        }

        public async Task<Supplier> UpdateSupplier(int id, Supplier supplier)
        {
            return await httpClient.PutAsJsonAsync($"/api/suppliers/{id}", supplier);
        }

        public async Task<Supplier> DeleteSupplier(int id)
        {
            return await httpClient.DeleteAsync($"/api/suppliers/{id}");
        }*/
    }
}
