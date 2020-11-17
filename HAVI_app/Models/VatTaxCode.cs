using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class VatTaxCode
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

    }
}
