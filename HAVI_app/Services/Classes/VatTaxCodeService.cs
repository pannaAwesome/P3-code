using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class VatTaxCodeService
    {
        private readonly HttpClient httpClient;
        public VatTaxCodeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<VatTaxCode>> GetVatTaxCodes()
        {
            return await httpClient.GetFromJsonAsync<VatTaxCode[]>("/api/vatTaxCodes");
        }

        public async Task<VatTaxCode> CreateVatTaxCode(VatTaxCode code)
        {
            var result = await httpClient.PostAsJsonAsync("/api/vatTaxCodes", code);
            return await result.Content.ReadAsAsync<VatTaxCode>();
        }

        public async Task<VatTaxCode> DeleteVatTaxCode(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/vatTaxCodes/{id}");
            return await result.Content.ReadAsAsync<VatTaxCode>();
        }

        public async Task<VatTaxCode> UpdateVatTaxCode(int id, VatTaxCode code)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/vatTaxCodes/{id}", code);
            return await result.Content.ReadAsAsync<VatTaxCode>();
        }
    }
}