using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class LocationService
    {
        private readonly HttpClient httpClient;
        public LocationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Location>> GetLocations()
        {
            return await httpClient.GetFromJsonAsync<List<Location>>("/api/locations");
        }
    }
}
