using HAVI_app.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Shared_layout.HAVI_tabpages
{
    public class ViewError : ComponentBase
    {
        [Parameter]
        public int ArticleId { get; set; }



        public Article Article { get; set; }

        protected override async Task OnInitializedAsync()
        {
           
        }

        public async void ErrorFixed()
        {

        }
    }
}
