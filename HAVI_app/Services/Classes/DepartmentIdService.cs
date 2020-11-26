﻿using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class DepartmentIdService
    {
        private readonly HttpClient httpClient;
        public DepartmentIdService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<DepartmentId>> GetDepartmentIds()
        {
            return await httpClient.GetFromJsonAsync<DepartmentId[]>("/api/departmentIds");
        }
    }
}