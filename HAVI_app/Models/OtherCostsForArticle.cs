using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class OtherCostsForArticle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ArticleInformation")]
        public int ArticleInformationId { get; set; }
        public string InformCostType { get; set; }
        public double? Amount { get; set; }
        [JsonIgnore]
        public virtual ArticleInformation ArticleInformation { get; set; }
    }
}
