using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class Purchaser
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public int CountryID { get; set; }

        public virtual ICollection<Article> Articles { get; set; } 
        public virtual Country Countries { get; set; }
        public virtual Profile Profiles { get; set; }
    }
}
