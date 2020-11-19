using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Bundle
    {
        public int Id { get; set; }
        public int InternalArticleInformationId { get; set; }
        public string ArticleBundle { get; set; }
        public int? ArticleBundleQuantity { get; set; }

        public virtual InternalArticleInformation InternalArticleInformation { get; set; }
    }
}
