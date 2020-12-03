using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class ILOSOrderpickgroupService
    {
        private readonly HttpClient httpClient;
        public ILOSOrderpickgroupService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Ilosorderpickgroup>> GetILOSOrderpickgroup(int id)
        {
            return await httpClient.GetFromJsonAsync<List<Ilosorderpickgroup>>($"/api/IlosOrderpickgroups/country/{id}");
        }

        public async Task<Ilosorderpickgroup> CreateILOSOrderpickgroup(Ilosorderpickgroup IlosOrderpickgroup)
        {
            var result = await httpClient.PostAsJsonAsync("/api/IlosOrderpickgroups", IlosOrderpickgroup);
            return await result.Content.ReadAsAsync<Ilosorderpickgroup>();
        }

        public async void UpdateILOSOrderpickgroup(int id, Ilosorderpickgroup ilosCategory)
        {
            await httpClient.PutAsJsonAsync($"/api/IlosOrderpickgroups/{id}", ilosCategory);
        }

        public async void DeleteILOSOrderpickgroup(int id)
        {
            await httpClient.DeleteAsync($"/api/ilosCategoies/{id}");
        }
    }
}
