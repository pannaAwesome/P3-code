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

        [Inject]
        public InformCostTypeService InformCostTypeService { get; set; }

        [Parameter]
        public Article Article { get; set; }

        public bool EditingFields = false;
        public int NumberOfOtherCosts = 0;
        public bool IsDisabled = true;

        public string Amount = "";
        public string LastAmount = "";
        public List<InformCostType> costType = new List<InformCostType>();

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

        protected override async Task OnInitializedAsync()
        {
            costType = await InformCostTypeService.GetInformCostTypes();

            ArticleInformation article = await ArticleInformationService.GetArticleInformation(Article.ArticleInformationId);
            Article.ArticleInformation.OtherCostsForArticles = article.OtherCostsForArticles;

            NumberOfOtherCosts = 0;

            foreach(OtherCostsForArticle cost in Article.ArticleInformation.OtherCostsForArticles)
            {
                NumberOfOtherCosts += cost.InformCostType != "" && cost.Amount != 0 ? 1 : 0;
            }
        }

        public void AddExtraCosts()
        {
            NumberOfOtherCosts++;
        }

        public void RemoveExtraCosts()
        {
            Article.ArticleInformation.OtherCostsForArticles[NumberOfOtherCosts - 1].InformCostType = "";
            Article.ArticleInformation.OtherCostsForArticles[NumberOfOtherCosts - 1].Amount = 0;
            NumberOfOtherCosts--;
        }
    }
}