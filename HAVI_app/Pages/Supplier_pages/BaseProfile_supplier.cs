﻿using HAVI_app.Models;
using HAVI_app.Services.Classes;
using HAVI_app.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Pages.Supplier_pages
{
    public class BaseProfile_supplier : ComponentBase
    {
        [Parameter]
        public int supplierId { get; set; }
        [Inject]
        public ISupplierService SupplierService { get; set; }
        public Supplier Supplier { get; set; } = new Supplier();
        public string PalletExchangeYes { get; set; }
        public string PalletExchangeNo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Supplier = await SupplierService.GetSupplier(supplierId);
            PalletExchangeYes = Supplier.PalletExchange == 1 ? "checked" : "";
            PalletExchangeNo = Supplier.PalletExchange == 1 ? "" : "checked";
        }

    }
}
