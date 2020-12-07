using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace HAVI_app.Pages.Admin_pages.User_pages
{
    public class UserView : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public PurchaserService PurchaserService { get; set; }

        [Inject]
        public ProfileService ProfileService { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string profile;
        public string country;
        public string user;
        public string article;
        public string overview;
        public string _userAlreadyExists { get; set; }

        protected override void OnInitialized()
        {
            profile = $"/profile_admin/" + Id;
            country = $"/country_view/{Id}";
            user = $"/user_view/{Id}";
            article = $"/article_view/{Id}";
            overview = $"/overview_admin/{Id}";
        }

        public string Email { get; set; }


        public async Task CreatePurchaser()
        {
            Purchaser purchaser = new Purchaser()
            {
                CountryId = Id,
                Profile = new Profile()
            };

            purchaser.Profile.Username = Email;
            purchaser.Profile.Password = "1234";
            purchaser.Profile.Usertype = 1;

            Profile testProfile = await ProfileService.GetProfileByUsernameAndpassword(purchaser.Profile.Username, purchaser.Profile.Password);

            if(testProfile.Username == "")
            {
                await PurchaserService.CreatePurchaser(purchaser);
                NavigationManager.NavigateTo($"/user_view/{Id}", true);
            }
            else
            {
                _userAlreadyExists = $"A purchaser with the email '{Email}' already exists";
            }
        }
    }
}
