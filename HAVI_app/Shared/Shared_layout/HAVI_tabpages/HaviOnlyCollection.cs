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
    public class HaviOnlyCollection : ComponentBase
    {
        [Parameter]
        public int ArticleId { get; set; }

        [Parameter]
        public string User { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        [Parameter]
        public string EditPossible { get; set; }

        [Inject]
        public ArticleService ArticleService { get; set; }

        [Inject]
        public InternalArticleInformationService InternalArticleInformationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Article Article;

        public string SaveOrNot = "";

        public int PageIndex = 0;

        public string MissedFields = "";

        protected override async Task OnInitializedAsync()
        {
            Article = await ArticleService.GetArticle(ArticleId);
            SaveOrNot = Article.ArticleState == (int)ArticleState.Completed || Article.ArticleState == (int)ArticleState.Error ? "Return to overview" : "Save";
        }

        public void PageUp()
        {
            PageIndex++;
            if (PageIndex > 4)
            {
                PageIndex = 4;
            }
        }

        public void PageDown()
        {
            PageIndex--;
            if (PageIndex < 0)
            {
                PageIndex = 0;
            }
        }

        public async void ReturnToOverview()
        {
            ValidateInformation();

            if(MissedFields == "")
            {
                if (Article.ArticleState == (int)ArticleState.Submitted)
                {
                    Article.ArticleState = (int)ArticleState.RobotReady;
                    await ArticleService.UpdateArticle(Article.Id, Article);
                }

                Article.InternalArticleInformation.InnerPackingIlos = "1/10";
                

                await InternalArticleInformationService.UpdateInternalArticleInformation(Article.InternalArticleInformationId, Article.InternalArticleInformation);

                if (User == "Purchaser")
                {
                    NavigationManager.NavigateTo($"/overview_purchaser/{Article.PurchaserId}", true);
                }
                else
                {
                    NavigationManager.NavigateTo($"/article_view/{Article.CountryId}", true);
                }
            }
            
        }

        private void ValidateInformation()
        {
            int correctNumber = 23;
            int validated = 0;

            validated += Article.InternalArticleInformation.SupplierIdIlos != 0 ? 1 : 0;
            validated += Article.InternalArticleInformation.CompanyCode != 0 ? 1 : 0;
            validated += Article.InternalArticleInformation.SupplierDeliveryUnit != "" ? 1 : 0;
            validated += Article.InternalArticleInformation.RemainShelfStore != 0 ? 1 : 0;
            validated += Article.InternalArticleInformation.IlosorderPickGroup != "" ? 1 : 0;
            validated += Article.InternalArticleInformation.IlossortGroup != "" ? 1 : 0;
            validated += Article.InternalArticleInformation.NewIlosarticleNumber != "" ? 1 : 0;
            validated += Article.InternalArticleInformation.ReferenceIlosnumber != "" ? 1 : 0;
            validated += Article.InternalArticleInformation.ReferenceSapmaterial != 0 ? 1 : 0;
            validated += Article.InternalArticleInformation.Iloscategory != "" ? 1 : 0;
            validated += Article.InternalArticleInformation.VatTaxcode != "" ? 1 : 0;
            validated += Article.InternalArticleInformation.DepartmentId != "" ? 1 : 0;
            validated += Article.InternalArticleInformation.TextPurchaseNumber != 0 ? 1 : 0;
            validated += Article.InternalArticleInformation.RegisterShelfLife != 2 ? 1 : 0;
            validated += Article.InternalArticleInformation.InsertEanSap != 2 ? 1 : 0;
            validated += Article.InternalArticleInformation.InsertGrinSap != 2 ? 1 : 0;
            validated += Article.InternalArticleInformation.InsertBosSap != 2 ? 1 : 0;
            validated += Article.InternalArticleInformation.PrimaryDcIloscode != 0 ? 1 : 0;
            validated += Article.InternalArticleInformation.Gtinnumber != "" ? 1 : 0;

            validated += Article.InternalArticleInformation.CurrencyRate != 0 ? 1 : 0;
            validated += Article.InternalArticleInformation.PriceInCountryCurrency != 0 ? 1 : 0;
            validated += Article.InternalArticleInformation.Bundles[0].ArticleBundle != "" ? 1 : 0;
            validated += Article.InternalArticleInformation.Bundles[0].ArticleBundleQuantity != 0 ? 1 : 0;

            foreach(Sapplant item in Article.InternalArticleInformation.Sapplants)
            {
                validated += item.SapplantValue != 2 ? 1 : 0;
                correctNumber += 1;
            }

            if(validated != correctNumber)
            {
                MissedFields = "Sorry, you did not fill out all the required fields.";
            }else
            {
                MissedFields = "";
            }
        }
    }
}
