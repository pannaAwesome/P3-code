using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class PackagingGroupService
    {
        private readonly HttpClient httpClient;
        public PackagingGroupService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<PackagingGroup>> GetPackagingGroups()
        {
            return await httpClient.GetFromJsonAsync<List<PackagingGroup>>("/api/packagingGroups");
        }
    }
}
