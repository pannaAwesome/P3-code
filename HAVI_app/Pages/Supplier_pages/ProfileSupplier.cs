using HAVI_app.Models;
using HAVI_app.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;
using HAVI_app.Services.Classes;
using System;
using System.Collections.Generic;

namespace HAVI_app.Pages.Supplier_pages
{
    public class ProfileSupplier : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int SupplierId { get; set; }

        [Inject]
        public SupplierService SupplierService { get; set; }

        [Inject]
        public LocationService LocationService { get; set; }

        [Inject]
        public FreightResponsibilityService FreightResponsibilityService { get; set; }

        public Supplier Supplier { get; set; } = new Supplier();
        public string CurPassword { get; set; }
        public string NewPassword1 { get; set; }
        public string NewPassword2 { get; set; }
        public string PasswordError { get; set; }
        public string _saveMessage = "";
        public List<Location> Countries;
        public List<FreightResponsibility> Freights;

        protected async override Task OnInitializedAsync()
        {
            Supplier = await SupplierService.GetSupplier(SupplierId);
            Countries = await LocationService.GetLocations();
            Freights = await FreightResponsibilityService.GetFreightResponsibilities();
        }
        public void BackToSupplierOverview()
        {
            NavigationManager.NavigateTo($"/overview_supplier/{SupplierId}");
        }

        public async void SavePassword()
        {
            if(CurPassword == Supplier.Profile.Password && NewPassword1 == NewPassword2)
            {
                Supplier.Profile.Password = NewPassword1;
                await SupplierService.UpdateSupplier(Supplier.Id, Supplier);
            }else if(CurPassword != Supplier.Profile.Password)
            {
                PasswordError = "Incorrect password!";
            }else
            {
                PasswordError = "The new passwords do not match!";
            }
        }

        public async void SaveProfile()
        {
            await SupplierService.UpdateSupplier(Supplier.Id, Supplier);
            _saveMessage = "Changes saved!";
        }
    }
}
