using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class ILOSCategory
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }
    }
}
