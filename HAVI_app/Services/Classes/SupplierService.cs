using HAVI_app.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HAVI_app.Services.Interfaces;

namespace HAVI_app.Services.Classes
{
    public class SupplierService : ComponentBase, ISupplierService
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

        public async  Task<IEnumerable<Supplier>> GetSuppliers()
        {
            throw new NotImplementedException();
        }
    }
}
