using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class InformCostType
    {
        public int Id { get; set; }
        public string CostType { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
