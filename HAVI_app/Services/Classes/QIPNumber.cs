using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class QIPNumber
    {
        private readonly HttpClient httpClient;
        public QIPNumber(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<QIPNumber>> GetQIPNumbers()
        {
            return await httpClient.GetFromJsonAsync<QIPNumber[]>("/api/qipNumbers");
        }
    }
}
