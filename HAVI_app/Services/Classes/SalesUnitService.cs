﻿using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class SalesUnitService
    {
        private readonly HttpClient httpClient;
        public SalesUnitService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<SalesUnit>> GetSalesUnits()
        {
            return await httpClient.GetFromJsonAsync<List<SalesUnit>>("/api/salesUnits");
        }
    }
}
