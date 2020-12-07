using HAVI_app.Classes;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
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

        [Inject]
        public ArticleService ArticleService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Article Article { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Article = await ArticleService.GetArticle(ArticleId);
        }

        public async void ErrorFixed()
        {
            Article.ErrorReported = 0;
            Article.ErrorOwner = "";
            Article.ErrorMessage = "";
            Article.ErrorField = "";
            Article.ArticleState = (int)ArticleState.RobotReady;

            await ArticleService.UpdateArticle(ArticleId, Article);
            NavigationManager.NavigateTo($"/overview_purchaser/{Article.PurchaserId}", true);
        }
    }
}
