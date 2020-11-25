using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Country
    {
        public Country()
        {
            Articles = new HashSet<Article>();
            Iloscategories = new HashSet<Iloscategory>();
            Ilosorderpickgroups = new HashSet<Ilosorderpickgroup>();
            InformCostTypes = new HashSet<InformCostType>();
            PrimaryDciloscodes = new HashSet<PrimaryDciloscode>();
            Purchasers = new HashSet<Purchaser>();
            SupplierDeliveryUnits = new HashSet<SupplierDeliveryUnit>();
            VailedForCustomers = new HashSet<VailedForCustomer>();
            VatTaxCodes = new HashSet<VatTaxCode>();
        }

        public int Id { get; set; }
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual Profile Profile { get; set; }
        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }
        [JsonIgnore]
        public virtual ICollection<Iloscategory> Iloscategories { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ilosorderpickgroup> Ilosorderpickgroups { get; set; }
        [JsonIgnore]
        public virtual ICollection<InformCostType> InformCostTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<PrimaryDciloscode> PrimaryDciloscodes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Purchaser> Purchasers { get; set; }
        [JsonIgnore]
        public virtual ICollection<SupplierDeliveryUnit> SupplierDeliveryUnits { get; set; }
        [JsonIgnore]
        public virtual ICollection<VailedForCustomer> VailedForCustomers { get; set; }
        [JsonIgnore]
        public virtual ICollection<VatTaxCode> VatTaxCodes { get; set; }
    }
}
