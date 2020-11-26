using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class ILOSSortGroupService
    {
        private readonly HttpClient httpClient;
        public ILOSSortGroupService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<IlossortGroup>> GetILOSSortgroups()
        {
            return await httpClient.GetFromJsonAsync<IlossortGroup[]>("/api/ilossortGroups");
        }
    }
}
