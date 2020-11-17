using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class Bundles
    {
        public int ID { get; set; }
        public int InternalArticleInformationID { get; set; }
        public string ArticleBundle { get; set; }
        public int ArticleBundleQuantity { get; set; }

        public virtual InternalArticleInformation InternalArticleInformations { get; set; }
    }
}
