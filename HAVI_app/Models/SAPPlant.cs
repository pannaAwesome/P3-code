using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Sapplant
    {
        public int Id { get; set; }
        public int? InternalArticleInformationId { get; set; }
        public string SapplantName { get; set; }
        public int? SapplantValue { get; set; }
    }
}
