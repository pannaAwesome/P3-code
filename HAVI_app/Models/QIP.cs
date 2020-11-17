using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class QIP
    {
        public int ID { get; set; }
        public int InternalArticleInformationID { get; set; }
        public string QIPNumberAndName { get; set; }
        public string QIPDescription { get; set; }
        public string QIPAnswerOption { get; set; }
        public string QIPSetAnswer { get; set; }
        public string QIPOKValue { get; set; }
        public string QIPLowBoundary { get; set; }
        public string QIPHighBoundary { get; set; }
        public string QIPFrequencyType { get; set; }
        public string QIPFrequency { get; set; }

        public virtual InternalArticleInformation InternalArticleInformation { get; set; }
    }
}
