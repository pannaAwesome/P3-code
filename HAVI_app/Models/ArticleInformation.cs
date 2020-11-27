using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class ArticleInformation
    {
        public ArticleInformation()
        {
            OtherCostsForArticles = new HashSet<OtherCostsForArticle>();
        }

        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public string Email { get; set; }
        public int PalletExchange { get; set; }
        public string FreightResponsibility { get; set; }
        public string SpecialInformation { get; set; }
        public int? TransportBooking { get; set; }
        public int? TransitTime { get; set; }
        public int? DangerousGoods { get; set; }
        public string Class { get; set; }
        public string ClassificationCode { get; set; }
        public string ArticleName { get; set; }
        public string Salesunit { get; set; }
        public int? ArticlesPerSalesunit { get; set; }
        public string SupplierArticleName { get; set; }
        public int? Gtinnumber { get; set; }
        public int? Shelflife { get; set; }
        public int? MinimumShelflife { get; set; }
        public int? OrganicArticle { get; set; }
        public double? LengthPerSalesunit { get; set; }
        public double? WidthPerSalesunit { get; set; }
        public double? HeightPerSalesunit { get; set; }
        public double? NetWeightPerSalesunit { get; set; }
        public double? GrossWeightPerSalesunit { get; set; }
        public int? CartonsPerPallet { get; set; }
        public int? CartonsPerLayer { get; set; }
        public string CountryOfOrigin { get; set; }
        public string ImportedFrom { get; set; }
        public string TollTarifNumber { get; set; }
        public int? MinimumOrderQuantity { get; set; }
        public double? TemperatureTransportationMin { get; set; }
        public double? TemperatureTransportationMax { get; set; }
        public double? TemperatureStorageMin { get; set; }
        public double? TemperatureStorageMax { get; set; }
        public int? LeadTime { get; set; }
        public string SetCurrency { get; set; }
        public double? PurchasePrice { get; set; }
        public int? OtherCosts { get; set; }

        [JsonIgnore]
        public virtual Article Article { get; set; }
        public virtual ICollection<OtherCostsForArticle> OtherCostsForArticles { get; set; }
    }
}
