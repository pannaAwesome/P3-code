using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Purchaser
    {
        public Purchaser()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [JsonIgnore]
        public virtual Country Country { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
