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

        public virtual ICollection<Article> Article { get; set; } 
        public virtual Country Country { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
