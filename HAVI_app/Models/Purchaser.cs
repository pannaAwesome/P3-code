using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Purchaser
    {
        public Purchaser()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        public int? ProfileId { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
