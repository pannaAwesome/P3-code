using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Qip
    {
        public int Id { get; set; }
        public int InternalArticleInformationId { get; set; }
        public string QipnameNumber { get; set; }
        public string Qipdescription { get; set; }
        public string QipanswerOptions { get; set; }
        public string QipsetAnswer { get; set; }
        public string Qipokvalue { get; set; }
        public string QiplowBoundary { get; set; }
        public string QiphighBoundary { get; set; }
        public string QipfrequencyType { get; set; }
        public string Qipfrequency { get; set; }

        public virtual InternalArticleInformation InternalArticleInformation { get; set; }
    }
}
