using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Sapplant
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("InternalArticleInformation")]
        public int InternalArticleInformationId { get; set; }
        public string SapplantName { get; set; } = "";
        public int SapplantValue { get; set; } = 2;
        [JsonIgnore]
        public virtual InternalArticleInformation InternalArticleInformation { get; set; }
    }
}
