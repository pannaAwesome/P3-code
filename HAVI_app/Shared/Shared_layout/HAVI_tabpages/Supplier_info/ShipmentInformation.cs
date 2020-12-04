using HAVI_app.Models;
using HAVI_app.Services.Classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared.Shared_layout.HAVI_tabpages.Supplier_info
{
    public class ShipmentInformation : ComponentBase
    {
        [Parameter]
        public string CartonsPerPallet { get; set; }

        [Parameter]
        public string CartonsPerLayer { get; set; }

        [Parameter]
        public string CountryOfOrigin { get; set; }

        [Parameter]
        public string ImportedFrom { get; set; }

        [Parameter]
        public string TollTarif { get; set; }

        [Parameter]
        public string MinOrderQuantity { get; set; }

        [Parameter]
        public string TemperatureTransportation { get; set; }

        [Parameter]
        public string TemperatureStorage { get; set; }

        [Parameter]
        public string LeadTime { get; set; }
        [Inject]
        public ArticleInformationService ArticleInformationService { get; set; }

        [Parameter]
        public Article Article { get; set; }

        public bool EditingFields = false;
        public bool IsDisabled = true;

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
