using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string AdminName { get; set; }
        public string AdminPasword { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<Purchaser> Purchaser { get; set; }
        public virtual ICollection<Article> Article { get; set; }
        public virtual ICollection<ILOSCategory> ILOSCategory { get; set; }
        public virtual ICollection<ILOSOrderpickgroup> ILOSOrderpickgroup { get; set; }
        public virtual ICollection<InformCostType> InformCostType { get; set; }
        public virtual ICollection<PrimaryDCILOSCode> PrimaryDCILOSCode { get; set; }
        public virtual ICollection<SupplierDeliveryUnit> SupplierDeliveryUnit { get; set; }
        public virtual ICollection<VailedForCustomer> VailedForCustomer { get; set; }
        public virtual ICollection<VatTaxCode> VatTaxCode { get; set; }
    }
}
