﻿using HAVI_app.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        public async Task<Supplier> GetSupplierWithProfile(int id)
        {
            return await httpClient.GetFromJsonAsync<Supplier>($"/api/suppliers/profile/{id}");
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            return await httpClient.GetFromJsonAsync<List<Supplier>>("/api/suppliers");
        }
        
        public async Task<Supplier> CreateSupplier(Supplier supplier)
        {
            var result = await httpClient.PostAsJsonAsync("/api/suppliers", supplier);
            return await result.Content.ReadAsAsync<Supplier>();
        }

        public async Task UpdateSupplier(int id, Supplier supplier)
        {
            await httpClient.PutAsJsonAsync($"/api/suppliers/{id}", supplier);
        }

        public async Task DeleteSupplier(int id)
        {
            await httpClient.DeleteAsync($"/api/suppliers/{id}");
        }
    }
}
