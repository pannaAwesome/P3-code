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
        public async Task<IEnumerable<Ilosorderpickgroup>> GetILOSCategories()
        {
            return await httpClient.GetFromJsonAsync<Ilosorderpickgroup[]>("/api/IlosOrderpickgroups");
        }

        public async Task<Ilosorderpickgroup> CreateILOSCategory(Ilosorderpickgroup IlosOrderpickgroup)
        {
            var result = await httpClient.PostAsJsonAsync("/api/IlosOrderpickgroups", IlosOrderpickgroup);
            return await result.Content.ReadAsAsync<Ilosorderpickgroup>();
        }

        public async Task<Ilosorderpickgroup> UpdateILOSCategory(int id, Ilosorderpickgroup ilosCategory)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/IlosOrderpickgroups/{id}", ilosCategory);
            return await result.Content.ReadAsAsync<Ilosorderpickgroup>();
        }

        public async Task<Ilosorderpickgroup> DeleteILOSCategory(int id)
        {
            var result = await httpClient.DeleteAsync($"/api/ilosCategoies/{id}");
            return await result.Content.ReadAsAsync<Ilosorderpickgroup>();
        }
    }
}
