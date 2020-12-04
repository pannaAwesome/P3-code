using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Shared_layout.HAVI_tabpages.Supplier_info
{
    public class PriceInformation : ComponentBase
    {
        [Parameter]
        public string EditFields { get; set; }

        [Inject]
        public ArticleInformationService ArticleInformationService { get; set; }

        [Parameter]
        public Article Article { get; set; }

        public bool EditingFields = false;
        public int NumberOfOtherCosts = 0;
        public bool IsDisabled = true;

        public void OtherCosts(int value)
        {
            Article.ArticleInformation.OtherCosts = value;
        }

        public void Editing()
        {
            EditingFields = true;
            IsDisabled = false;
        }

        public async void Saving()
        {
            await ArticleInformationService.UpdateArticleInformation(Article.ArticleInformationId, Article.ArticleInformation);
            EditingFields = false;
            IsDisabled = true;
        }

        protected override void OnInitialized()
        {
            if (Article.ArticleInformation.OtherCostsForArticles == null)
            {
                NumberOfOtherCosts = 0;
            }else
            {
                NumberOfOtherCosts = Article.ArticleInformation.OtherCostsForArticles.Count;
            }
        }
    }
}
