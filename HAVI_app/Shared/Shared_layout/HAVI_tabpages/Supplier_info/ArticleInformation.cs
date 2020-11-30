using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Shared_layout.HAVI_tabpages.Supplier_info
{
    public class ArticleInformation : ComponentBase
    {
        [Parameter]
        public string ArticleName { get; set; }

        [Parameter]
        public string Salesunit { get; set; }

        [Parameter]
        public string ArticlePerSalesunit { get; set; }

        [Parameter]
        public string SupplierNameNumber { get; set; }

        [Parameter]
        public string GTINNumber { get; set; }

        [Parameter]
        public string Shelflife { get; set; }

        [Parameter]
        public string MinShelflife { get; set; }

        [Parameter]
        public string OrganicArticles { get; set; }

        [Inject]
        public ArticleService ArticleService { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Article Article { get; set; }

        public bool EditingFields = false;

        public void OrganicArticle(int value)
        {
            Article.ArticleInformation.OrganicArticle = value;
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

        protected override async Task OnInitializedAsync()
        {
            Article = await ArticleService.GetArticle(Id);
        }
    }
}
