using BlazorTable;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Admin_layout
{
    public class UserTableAdmin : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public PurchaserService PurchaserService { get; set; }

        [Inject]
        public ProfileService ProfileService { get; set; }

        public List<Profile> Profiles { get; set; }

        private int ProfileClicked { get; set; }

        public async void DeleteProfile()
        {
            int profileId = Profiles[0].Id;
            Purchaser purchaser = await PurchaserService.GetPurchaserForProfile(profileId);

            await PurchaserService.DeletePurchaserForProfile(ProfileClicked);
            NavigationManager.NavigateTo($"/user_view/{purchaser.CountryId}", true);
        }

        public void DeleteButtonClicked(int id)
        {
            ProfileClicked = id;
        }

        protected async override Task OnInitializedAsync()
        {
            List<Purchaser> purchasers = await PurchaserService.GetPurchasersForCountry(1);
            Profiles = new List<Profile>();

            foreach(Purchaser purchaser in purchasers)
            {
                Profiles.Add(purchaser.Profile);
            }
        }
    }
}
