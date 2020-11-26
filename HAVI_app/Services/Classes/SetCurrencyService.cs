using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class SetCurrencyService
    {
        private readonly HttpClient httpClient;
        public SetCurrencyService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<SetCurrency>> GetSetCurrencies()
        {
            return await httpClient.GetFromJsonAsync<SetCurrency[]>("/api/setCurrencies");
        }
    }
}
