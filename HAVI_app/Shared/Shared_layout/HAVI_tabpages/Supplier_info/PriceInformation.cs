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
        [Inject]
        public ArticleService ArticleService { get; set; }

        [Parameter]
        public int Id { get; set; }
        public Article Article { get; set; }

        public bool EditingFields = false;
        public string OtherCost = "yes";
        public string Currency = "DKK";
        public int NumberOfOtherCosts = 1;
        public List<OtherCostsForArticle> OtherCostsForArticle;
        public double TotalAmount = 0.0;

        public void OtherCosts(int value)
        {
            Article.ArticleInformation.OtherCosts = value;
        }

        public void Editing()
        {
            EditingFields = true;
        }

        public void Saving()
        {
            ArticleService.UpdateArticle(Article.Id, Article);
            EditingFields = false;
        }

        protected async override Task OnInitializedAsync()
        {
            Article = await ArticleService.GetArticle(Id);

            foreach (OtherCostsForArticle item in Article.ArticleInformation.OtherCostsForArticles)
            {
                TotalAmount += item.Amount;
            }

            OtherCostsForArticle = (List<OtherCostsForArticle>)Article.ArticleInformation.OtherCostsForArticles;

            if (Article.ArticleInformation.OtherCostsForArticles == null)
            {
                NumberOfOtherCosts = 0;
            }else
            {
                NumberOfOtherCosts = OtherCostsForArticle.Count;
            }
        }
    }
}
