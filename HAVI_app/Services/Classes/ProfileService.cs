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

        public async Task<Profile> GetProfileForCountry(int id)
        {
            return await httpClient.GetFromJsonAsync<Profile>($"/api/profiles/country/{id}");
        }

        public async Task<Profile> GetProfile(int id)
        {
            return await httpClient.GetFromJsonAsync<Profile>($"/api/profiles/{id}");
        }

        public async Task<Profile> GetProfileByUsernameAndpassword(string username, string password)
        {
            return await httpClient.GetFromJsonAsync<Profile>($"/api/profiles/{username}/{password}");
        }

        public async Task<List<Profile>> GetProfiles()
        {
            return await httpClient.GetFromJsonAsync<List<Profile>>("/api/profiles");
        }

        public async Task DeleteProfile(int id)
        {
            await httpClient.DeleteAsync($"/api/profiles/{id}");
        }
    }
}
