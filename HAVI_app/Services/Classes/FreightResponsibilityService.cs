using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class FreightResponsibilityService
    {
        private readonly HttpClient httpClient;
        public FreightResponsibilityService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<FreightResponsibility>> GetFreightResponsibilities()
        {
            return await httpClient.GetFromJsonAsync<FreightResponsibility[]>("/api/freightResponsibilities");
        }
    }
}
