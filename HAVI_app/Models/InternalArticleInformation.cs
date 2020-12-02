using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class InternalArticleInformation
    {
        public InternalArticleInformation()
        {
            Bundles = new List<Bundle>();
            Qips = new List<Qip>();
            Sapplants = new List<Sapplant>();
        }

        [Key]
        public int Id { get; set; }
        public int SupplierIdIlos { get; set; }
        public int CompanyCode { get; set; }
        public string SupplierDeliveryUnit { get; set; } = "";
        public int RemainShelfStore { get; set; }
        public string IlosorderPickGroup { get; set; } = "";
        public string IlossortGroup { get; set; } = "";
        public string NewIlosarticleNumber { get; set; } = "";
        public string ReferenceIlosnumber { get; set; } = "";
        public int ReferenceSapmaterial { get; set; }
        public string Iloscategory { get; set; } = "";
        public string VatTaxcode { get; set; } = "";
        public string DepartmentId { get; set; } = "";
        public string InnerPackingIlos { get; set; } = "";
        public double CurrencyRate { get; set; }
        public double PriceInCountryCurrency { get; set; }
        public int TextPurchaseNumber { get; set; }
        public int RegisterShelfLife { get; set; }
        public string ClassificationCode { get; set; } = "";
        public string PackagingGroup { get; set; } = "";
        public int InsertEanSap { get; set; }
        public int InsertGrinSap { get; set; }
        public int InsertBosSap { get; set; }
        public string Eannumber { get; set; }
        public string Grinnumber { get; set; }
        public string Bosnumber { get; set; }
        public string Gtinnumber { get; set; }
        public string Lrinnumber { get; set; }
        public string Sprnnumber { get; set; }
        public string Carlanumber { get; set; }
        public int PrimaryDcIloscode { get; set; }
        public int TransitTimeForHavi { get; set; }
        public int AmountInCurrency { get; set; }

        [JsonIgnore]
        public virtual Article Article { get; set; } = null;
        public virtual List<Bundle> Bundles { get; set; } = null;
        public virtual List<Qip> Qips { get; set; } = null;
        public virtual List<Sapplant> Sapplants { get; set; } = null;
    }
}
