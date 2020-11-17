using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Bundle
    {
        public int Id { get; set; }
        public int? InternalArticleInformation { get; set; }
        public string ArticleBundle { get; set; }
        public int? ArticleBundleQuantity { get; set; }
    }
}
