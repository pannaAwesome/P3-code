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
        public string EditFields { get; set; }

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
        public string OrganicArticle { get; set; }

        [Inject]
        public ArticleInformationService ArticleInformationService { get; set; }

        [Parameter]
        public Article Article { get; set; }

        public bool IsDisabled = true;

        public bool EditingFields = false;

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
    }
}
