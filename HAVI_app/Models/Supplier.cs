using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public int PalletExchange { get; set; }
        public string FreightResponsibility { get; set; }

        public virtual Profile Profile { get; set; }
        [JsonIgnore]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
