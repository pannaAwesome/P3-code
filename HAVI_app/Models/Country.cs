using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Country
    {
        public Country()
        {
            Articles = new List<Article>();
            CompanyCodes = new List<CompanyCode>();
            Iloscategories = new List<Iloscategory>();
            Ilosorderpickgroups = new List<Ilosorderpickgroup>();
            InformCostTypes = new List<InformCostType>();
            PrimaryDciloscodes = new List<PrimaryDciloscode>();
            Purchasers = new List<Purchaser>();
            SupplierDeliveryUnits = new List<SupplierDeliveryUnit>();
            VailedForCustomers = new List<VailedForCustomer>();
            VatTaxCodes = new List<VatTaxCode>();
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public string CountryName { get; set; } = "";
        public string CountryCode { get; set; } = "";

        public virtual Profile Profile { get; set; } = null;
        public virtual List<Article> Articles { get; set; } = null;
        [JsonIgnore]
        public virtual List<CompanyCode> CompanyCodes { get; set; }
        [JsonIgnore]
        public virtual List<Iloscategory> Iloscategories { get; set; }
        [JsonIgnore]
        public virtual List<Ilosorderpickgroup> Ilosorderpickgroups { get; set; }
        [JsonIgnore]
        public virtual List<InformCostType> InformCostTypes { get; set; }
        [JsonIgnore]
        public virtual List<PrimaryDciloscode> PrimaryDciloscodes { get; set; }
        [JsonIgnore]
        public virtual List<Purchaser> Purchasers { get; set; }
        [JsonIgnore]
        public virtual List<SupplierDeliveryUnit> SupplierDeliveryUnits { get; set; }
        [JsonIgnore]
        public virtual List<VailedForCustomer> VailedForCustomers { get; set; }
        [JsonIgnore]
        public virtual List<VatTaxCode> VatTaxCodes { get; set; }
    }
}
