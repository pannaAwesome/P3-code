using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class OtherCostsForArticle
    {
        public int ID { get; set; }
        public int ArticleInformationID { get; set; }
        public string InformCostType { get; set; }
        public float Amount { get; set; }

        public virtual ArticleInformation ArticleInformation { get; set; }
    }
}
