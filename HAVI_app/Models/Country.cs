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

        public virtual ICollection<Purchaser> Purchasers { get; set; }
        public virtual ICollection<Article> Articles { get; set; }

        public virtual Profile Profiles { get; set; }
    }
}
