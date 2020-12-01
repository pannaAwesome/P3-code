using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Article
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Purchaser")]
        public int PurchaserId { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        [ForeignKey("ArticleInformation")]
        public int ArticleInformationId { get; set; }
        [ForeignKey("InternalArticleInformation")]
        public int InternalArticleInformationId { get; set; }
        public string VailedForCustomer { get; set; }
        public DateTime DateCreated { get; set; }
        public int ArticleInformationCompleted { get; set; }
        public int InternalArticalInformationCompleted { get; set; }
        public int ArticleState { get; set; }
        public int ErrorReported { get; set; }
        public string ErrorField { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorOwner { get; set; }

        public virtual ArticleInformation ArticleInformation { get; set; }
        [JsonIgnore]
        public virtual Country Country { get; set; }
        public virtual InternalArticleInformation InternalArticleInformation { get; set; }
        public virtual Purchaser Purchaser { get; set; }
        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }
    }
}
