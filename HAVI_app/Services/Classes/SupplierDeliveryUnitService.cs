using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class SupplierDeliveryUnitService
    {
        private readonly HttpClient httpClient;
        public SupplierDeliveryUnitService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<SupplierDeliveryUnit>> GetSupplierDeliveryUnits()
        {
            return await httpClient.GetFromJsonAsync<SupplierDeliveryUnit[]>("/api/supplierDeliveryUnits");
        }

        public async Task<SupplierDeliveryUnit> CreateSupplierDeliveryUnit(SupplierDeliveryUnit unit)
        {
            var result = await httpClient.PostAsJsonAsync("/api/supplierDeliveryUnits", unit);
            return await result.Content.ReadAsAsync<SupplierDeliveryUnit>();
        }

        public async Task<SupplierDeliveryUnit> DeleteSupplierDeliveryUnit(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/supplierDeliveryUnits/{id}");
            return await result.Content.ReadAsAsync<SupplierDeliveryUnit>();
        }

        public async Task<SupplierDeliveryUnit> UpdateSupplierDeliveryUnit(int id, SupplierDeliveryUnit unit)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/supplierDeliveryUnits/{id}", unit);
            return await result.Content.ReadAsAsync<SupplierDeliveryUnit>();
        }
    }
}
