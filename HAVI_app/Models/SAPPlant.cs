using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Sapplant
    {
        public int Id { get; set; }
        [ForeignKey("InternalArticleInformation")]
        public int InternalArticleInformationId { get; set; }
        public string SapplantName { get; set; }
        public int? SapplantValue { get; set; }

        public virtual InternalArticleInformation InternalArticleInformation { get; set; }
    }
}
