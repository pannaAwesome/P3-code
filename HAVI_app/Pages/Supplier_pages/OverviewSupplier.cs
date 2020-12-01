using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Pages.Supplier_pages
{
    public class OverviewSupplier : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public CountryService CountryService { get; set; }

        [Inject]
        public ArticleService ArticleService { get; set; }

        [Inject]
        public PurchaserService PurchaserService { get; set; }

        [Parameter]
        public int Id { get; set; }

        public string CountryName { get; set; }
        public string ValidForCustomer { get; set; }
        public string PurchaserUsername { get; set; }


        public async void NewArticleAdded()
        {
            Country Country = await CountryService.GetCountryWithName(CountryName);


            Article Article = new Article()
            {
                SupplierId = Id,
                CountryId = Country.Id,
                VailedForCustomer = ValidForCustomer
            };

            ArticleService.CreateArticle(Article);



            NavigationManager.NavigateTo($"/supplier_info_form/{Id}", true);
        }
    }
}
