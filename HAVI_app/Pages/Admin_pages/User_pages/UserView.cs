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
        public static int Id { get; set; }

        [Inject]
        public PurchaserService PurchaserService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string profile = $"/profile_admin/{Id}";
        public string country = $"/country_view/{Id}";
        public string user = $"/user_view/{Id}";
        public string article = $"/article_view/{Id}";
        public string overview = $"/overview_admin/{Id}";

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

            await PurchaserService.CreatePurchaser(purchaser);

            NavigationManager.NavigateTo($"/user_view/{Id}", true);
        }
    }
}
