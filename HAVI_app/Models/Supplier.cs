using System;
using System.Collections.Generic;

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
        public int ProfileId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }
        public int PalletExchange { get; set; }
        public string FreightResponsibility { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
