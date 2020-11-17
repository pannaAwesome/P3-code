using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class ArticleInformation
    {
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public string Email { get; set; }
        public bool PalletExchange { get; set; }
        public string FreightResponsibility { get; set; }
        public string SpecialInformation { get; set; }
        public bool TransportBooking { get; set; }
        public int TransitTime { get; set; }
        public bool DangerousGoods { get; set; }
        public string Class { get; set; }
        public string ClassificationCode { get; set; }
        public string ArticleName { get; set; }
        public string Salesunit { get; set; }
        public int ArticlesPerSalesunit { get; set; }
        public string SupplierArticleName { get; set; }
        public int GTINNumber { get; set; }
        public int Shelflife { get; set; }
        public int MinimumShelflife { get; set; }
        public bool OrganicArticle { get; set; }
        public float LengthPerSalesunit { get; set; }
        public float WidthPerSalesunit { get; set; }
        public float HeightPerSalesunit { get; set; }
        public float NetWeightPerSalesunit { get; set; }
        public float GrossWeightPerSalesunit { get; set; }
        public int CartonsPerPallet { get; set; }
        public int CartonsPerLayer { get; set; }
        public string CountryOfOrigin { get; set; }
        public string ImportedFrom { get; set; }
        public string TollTarifNumber { get; set; }
        public int MinimumOrderCountry { get; set; }
        public float TemperatureTransportationMin { get; set; }
        public float TemperatureTransportationMax { get; set; }
        public float TemperatureStorageMin { get; set; }
        public float TemperatureStorageMax { get; set; }
        public int LeadTime { get; set; }
        public string SetCurrency { get; set; }
        public float PurchasePrice { get; set; }
        public bool OtherCosts { get; set; }

        public Article Articles { get; set; }
        public ICollection<OtherCostsForArticles> OtherCostForArticle { get; set; }
    }
}
