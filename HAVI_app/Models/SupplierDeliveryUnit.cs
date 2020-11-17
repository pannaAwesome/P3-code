using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class SupplierDeliveryUnit
    {
        public int Id { get; set; }
        public string Unit { get; set; }
        public int? CountryId { get; set; }
    }
}
