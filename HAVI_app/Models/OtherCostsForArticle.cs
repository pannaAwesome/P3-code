using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class OtherCostsForArticle
    {
        public int Id { get; set; }
        public int ArticleInformationId { get; set; }
        public string InformCostType { get; set; }
        public double? Amount { get; set; }

        public virtual ArticleInformation ArticleInformation { get; set; }
    }
}
