using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public bool PalletExchange { get; set; }
        public string FreightResponsibility { get; set; }

        public ICollection<Article> Articles { get; set; }
        public Profile Profiles { get; set; }
    }
}
