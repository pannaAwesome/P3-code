using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Shared_layout.HAVI_tabpages.Supplier_info
{
    public class SupplierInformation : ComponentBase
    {
        [Inject]
        public ArticleService ArticleService { get; set; }

        [Parameter]
        public int Id { get; set; }
        public Article Article { get; set; }

        public bool EditingFields = false;

        public void PalletExchange(int value)
        {
            Article.ArticleInformation.PalletExchange = value;
        }

        public void BookingTransport(int value)
        {
            Article.ArticleInformation.TransportBooking = value;
        }

        public void Dangerous(int value)
        {
            Article.ArticleInformation.DangerousGoods = value;
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
