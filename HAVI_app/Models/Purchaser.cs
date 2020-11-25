using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
