using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class InternalArticleInformation
    {
        public InternalArticleInformation()
        {
            Articles = new HashSet<Article>();
            Bundles = new HashSet<Bundle>();
            Qips = new HashSet<Qip>();
            Sapplants = new HashSet<Sapplant>();
        }

        public int Id { get; set; }
        public int? SupplierIdIlos { get; set; }
        public int? CompanyCode { get; set; }
        public string SupplierDeliveryUnit { get; set; }
        public int? RemainShelfStore { get; set; }
        public string IlosorderPickGroup { get; set; }
        public string IlossortGroup { get; set; }
        public string NewIlosarticleNumber { get; set; }
        public string ReferenceIlosnumber { get; set; }
        public int? ReferenceSapmaterial { get; set; }
        public string Iloscategory { get; set; }
        public string VatTaxcode { get; set; }
        public string DepartmentId { get; set; }
        public string InnerPackingIlos { get; set; }
        public double? CurrencyRate { get; set; }
        public double? PriceInCountryCurrency { get; set; }
        public int? TextPurchaseNumber { get; set; }
        public int? RegisterShelfLife { get; set; }
        public string ClassificationCode { get; set; }
        public string PackagingGroup { get; set; }
        public int? InsertEanSap { get; set; }
        public int? InsertGrinSap { get; set; }
        public int? InsertBosSap { get; set; }
        public int? Eannumber { get; set; }
        public int? Grinnumber { get; set; }
        public int? Bosnumber { get; set; }
        public int? Gtinnumber { get; set; }
        public int? Lrinnumber { get; set; }
        public int? Sprnnumber { get; set; }
        public int? Carlanumber { get; set; }
        public int? PrimaryDcIloscode { get; set; }
        public int? TransitTimeForHavi { get; set; }

        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }
        [JsonIgnore]
        public virtual ICollection<Bundle> Bundles { get; set; }
        [JsonIgnore]
        public virtual ICollection<Qip> Qips { get; set; }
        [JsonIgnore]
        public virtual ICollection<Sapplant> Sapplants { get; set; }
    }
}
