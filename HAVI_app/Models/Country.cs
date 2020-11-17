using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class Country
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public ICollection<Purchaser> Purchasers { get; set; }
        public ICollection<Article> Articles { get; set; }

        public Profile Profiles { get; set; }
    }
}
