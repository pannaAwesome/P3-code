using HAVI_app.Classes;
using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
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
        public ProfileService ProfileService { get; set; }

        [Inject]
        public PurchaserService PurchaserService { get; set; }

        [Inject]
        public VailedForCustomerService VailedForCustomerService { get; set; }

        [Inject]
        public SupplierService SupplierService { get; set; }

        [Parameter]
        public int Id { get; set; }

        public string CountryName { get; set; }
        public string ValidForCustomer { get; set; }
        public string PurchaserUsername { get; set; }
        public List<Purchaser> Purchasers { get; set; } = new List<Purchaser>();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<VailedForCustomer> Customers { get; set; } = new List<VailedForCustomer>();
        public Profile Profile { get; set; } = new Profile();
        public Supplier Supplier { get; set; } = new Supplier();

        protected async override Task OnInitializedAsync()
        {
            Countries = await CountryService.GetCountries();
            CountryName = Countries[0].CountryName;
            Supplier = await SupplierService.GetSupplier(Id);
            Profile = await ProfileService.GetProfileByUsernameAndpassword(Supplier.Profile.Username, "1234");
        }

        public async Task UpdateFields()
        {
            Country country = await CountryService.GetCountryWithName(CountryName);
            Purchasers = await PurchaserService.GetPurchasersForCountry(country.Id);
            Customers = await VailedForCustomerService.GetVailedCustomers(country.Id);
        }

        public async void NewArticleAdded()
        {
            Country country = await CountryService.GetCountryWithName(CountryName);
            Profile profile = await ProfileService.GetProfileByUsernameAndpassword(PurchaserUsername, "1234");
            Purchaser purchaser = await PurchaserService.GetPurchaserForProfile(profile.Id);

            Article Article = new Article()
            {
                PurchaserId = purchaser.Id,
                SupplierId = Id,
                CountryId = country.Id,
                VailedForCustomer = ValidForCustomer,
                DateCreated = DateTime.Now,
                ArticleState = (int)ArticleState.Created,
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
            };

            Article.ArticleInformation.CompanyName = Supplier.CompanyName;
            Article.ArticleInformation.CompanyLocation = Supplier.CompanyLocation;
            Article.ArticleInformation.FreightResponsibility = Supplier.FreightResponsibility;
            Article.ArticleInformation.PalletExchange = Supplier.PalletExchange;

            Article newArticle = await ArticleService.CreateArticle(Article);

            NavigationManager.NavigateTo($"/supplier_info_form/{newArticle.ArticleInformation.Id}", true);
        }

        public void NavigateToProfilePage()
        {
            NavigationManager.NavigateTo($"/profile_supplier/{Id}");
        }
    }
}
