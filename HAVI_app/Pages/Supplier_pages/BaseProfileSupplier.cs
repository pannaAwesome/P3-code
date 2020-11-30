using HAVI_app.Models;
using HAVI_app.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;
using HAVI_app.Services.Classes;
using System;

namespace HAVI_app.Pages.Supplier_pages
{
    public class BaseProfileSupplier : ComponentBase
    {
        [Parameter]
        public int supplierId { get; set; }

        [Inject]
        public SupplierService SupplierService { get; set; }

        public Supplier Supplier { get; set; } = new Supplier();

        protected async override Task OnInitializedAsync()
        {
            Supplier = await SupplierService.GetSupplier(supplierId);
        }

    }
}
