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
    public class ReportNewError : ComponentBase
    {
        [Parameter]
        public int ArticleId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ArticleService ArticleService { get; set; }

        public string ErrorField { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
        public string ErrorSender { get; set; } = "";

        public async void SaveError()
        {
            Article article = await ArticleService.GetArticle(ArticleId);

            article.ErrorReported = 1;
            article.ErrorField = ErrorField;
            article.ErrorMessage = ErrorMessage;
            article.ErrorOwner = ErrorSender;
            article.ArticleState = (int)ArticleState.Error;

            await ArticleService.UpdateArticle(ArticleId, article);

            NavigationManager.NavigateTo($"/article_view/{article.CountryId}", true);
        }
    }
}
