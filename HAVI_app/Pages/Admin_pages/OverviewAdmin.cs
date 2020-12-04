using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Pages.Admin_pages
{
    public class OverviewAdmin : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        public string profile;
        public string country;
        public string user;
        public string article;
        public string overview;

        protected override void OnInitialized()
        {
            profile = $"/profile_admin/" + Id;
            country = $"/country_view/{Id}";
            user = $"/user_view/{Id}";
            article = $"/article_view/{Id}";
            overview = $"/overview_admin/{Id}";
        }
    }
}
