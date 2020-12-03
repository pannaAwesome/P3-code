using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Qip
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("InternalArticleInformation")]
        public int InternalArticleInformationId { get; set; }
        public string QipnameNumber { get; set; } = "";
        public string Qipdescription { get; set; } = "";
        public string QipanswerOptions { get; set; } = "";
        public string QipsetAnswer { get; set; } = "";
        public double Qipokvalue { get; set; }
        public double QiplowBoundary { get; set; }
        public double QiphighBoundary { get; set; }
        public double QipfrequencyType { get; set; }
        public double Qipfrequency { get; set; }
        [JsonIgnore]
        public virtual InternalArticleInformation InternalArticleInformation { get; set; }
    }
}
