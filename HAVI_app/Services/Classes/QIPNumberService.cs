using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class QIPNumberService
    {
        private readonly HttpClient httpClient;
        public QIPNumberService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<QIPNumberService>> GetQIPNumbers()
        {
            return await httpClient.GetFromJsonAsync<QIPNumberService[]>("/api/qipNumbers");
        }
    }
}
