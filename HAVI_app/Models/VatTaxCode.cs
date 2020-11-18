using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class VatTaxCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
