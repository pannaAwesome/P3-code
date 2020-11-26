using HAVI_app.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HAVI_app.Services.Classes
{
    public class ProfileService
    {
        private readonly HttpClient httpClient;
        public ProfileService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Profile> GetProfile(int id)
        {
            return await httpClient.GetFromJsonAsync<Profile>($"/api/profiles/{id}");
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            return await httpClient.GetFromJsonAsync<Profile[]>("/api/profiles");
        }

        public async Task<Profile> UpdateProfile(int id, Profile profile)
        {
            var result = await httpClient.PutAsJsonAsync($"/api/profiles/{id}", profile);
            return await result.Content.ReadAsAsync<Profile>();
        }
    }
}
