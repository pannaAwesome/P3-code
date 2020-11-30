using BlazorTable;
using HAVI_app.Classes;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Admin_layout
{
    
    public class OverviewTableAdmin : ComponentBase
    {
        [Inject]
        public ArticleService ArticleService { get; set; }

        public List<Article> Articles;

        protected async override Task OnInitializedAsync()
        {
            Articles = await ArticleService.GetArticleWithCertainState(1, (int)ArticleState.RobotReady);
        }
    }
}
