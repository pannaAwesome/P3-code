using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Country
    {
        public Country()
        {
            Articles = new HashSet<Article>();
            PrimaryDciloscodes = new HashSet<PrimaryDciloscode>();
            Purchasers = new HashSet<Purchaser>();
            VailedForCustomers = new HashSet<VailedForCustomer>();
        }

        public int Id { get; set; }
        public int? ProfileId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<PrimaryDciloscode> PrimaryDciloscodes { get; set; }
        public virtual ICollection<Purchaser> Purchasers { get; set; }
        public virtual ICollection<VailedForCustomer> VailedForCustomers { get; set; }
    }
}
