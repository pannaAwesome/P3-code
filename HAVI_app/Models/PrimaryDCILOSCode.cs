using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class PrimaryDCILOSCode
    {
        public int ID { get; set; }
        public string PrimaryCode { get; set; }
        public string SAPPlant { get; set; }
        public int CountryID { get; set; }
        public Country Countries { get; set; }

    }
}
