using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class InternalArticleInformation
    {
        public InternalArticleInformation()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        public int? SupplierIdIlos { get; set; }
        public int? CompanyCode { get; set; }
        public int? SupplierDeliveryUnit { get; set; }
        public int? RemainShelfStore { get; set; }
        public string IlosorderPickGroup { get; set; }
        public string IlossortGroup { get; set; }
        public int? NewIlosarticleNumber { get; set; }
        public int? ReferenceIlosnumber { get; set; }
        public int? ReferenceSapmaterial { get; set; }
        public string Iloscategory { get; set; }
        public string VatTaxcode { get; set; }
        public string DepartmentId { get; set; }
        public string InnerPackingIlos { get; set; }
        public string TextPurchaseNumber { get; set; }
        public int? RegisterShelfLife { get; set; }
        public string ClassificationCode { get; set; }
        public string PackagingGroup { get; set; }
        public int? EanSap { get; set; }
        public int? GrinSap { get; set; }
        public int? BosSap { get; set; }
        public int? Eannumber { get; set; }
        public int? Grinnumber { get; set; }
        public int? Bosnumber { get; set; }
        public int? Gtinnumber { get; set; }
        public int? Lrinnumber { get; set; }
        public int? Sprnnumber { get; set; }
        public int? Carlanumber { get; set; }
        public int? PrimaryDcIloscode { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
