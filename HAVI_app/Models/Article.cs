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
        public int Id { get; set; } = 0;
        [ForeignKey("Purchaser")]
        public int PurchaserId { get; set; } = 0;
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; } = 0;
        [ForeignKey("Country")]
        public int CountryId { get; set; } = 0;
        [ForeignKey("ArticleInformation")]
        public int ArticleInformationId { get; set; } = 0;
        [ForeignKey("InternalArticleInformation")]
        public int InternalArticleInformationId { get; set; } = 0;
        public string VailedForCustomer { get; set; } = "";
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int ArticleInformationCompleted { get; set; } = 0;
        public int InternalArticalInformationCompleted { get; set; } = 0;
        public int ArticleState { get; set; } = 0;
        public int ErrorReported { get; set; } = 0;
        public string ErrorField { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
        public string ErrorOwner { get; set; } = "";

        public virtual ArticleInformation ArticleInformation { get; set; } = new ArticleInformation();
        [JsonIgnore]
        public virtual Country Country { get; set; } = null;
        public virtual InternalArticleInformation InternalArticleInformation { get; set; } = new InternalArticleInformation();
        public virtual Purchaser Purchaser { get; set; } = null;
        [JsonIgnore]
        public virtual Supplier Supplier { get; set; } = null;
    }
}
