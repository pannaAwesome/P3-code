using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Bundle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("InternalArticleInformation")]
        public int InternalArticleInformationId { get; set; }
        public string ArticleBundle { get; set; } = "";
        public int ArticleBundleQuantity { get; set; }
        [JsonIgnore]
        public virtual InternalArticleInformation InternalArticleInformation { get; set; } = null;
    }
}
