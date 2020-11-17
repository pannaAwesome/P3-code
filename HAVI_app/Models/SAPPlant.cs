using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class SAPPlant
    {
        public int ID { get; set; }
        public int InternalArticleInformationID { get; set; }
        public string SAPPlantName { get; set; }
        public bool SAPPlantValue { get; set; }

        public virtual InternalArticleInformation InternalArticleInformations { get; set; }
    }
}
