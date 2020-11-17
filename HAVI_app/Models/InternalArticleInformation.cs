using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class InternalArticleInformation
    {
        //HAVI Internal Information
        public int CompanyCode { get; set; }
        public int SupplierID_ILOS { get; set; }
        public bool SupplierDeliveryUnit { get; set; }
        public int RemainSelfStoreValue { get; set; }
        public string ILOSOrderPickGroup { get; set; }
        public string ILOSTempGroups { get; set; }
        public int NewILOSArticleNumber { get; set; }
        public int ReferenceILOSNumber { get; set; }
        public int ReferenceSAPMaterialNumber { get; set; }
        public string ILOSCategory { get; set; }
        public string VAT_TAXCode { get; set; }
        public string DeparmentID { get; set; }
        public string InnerpackingILOS { get; set; }
        public string TextPurchaseNumber { get; set; }
        public bool RegisterSelfLife { get; set; }
        public string ClassificationCode { get; set; }
        public string PackagingGroup { get; set; }

        //Alias
        public bool EAN_SAP { get; set; }
        public bool GRIN_SAP { get; set; }
        public bool BOS_SAP { get; set; }
        public int EAN_Number { get; set; }
        public int GRIN_Number { get; set; }
        public int BOS_Number { get; set; }
        public int GTIN_Number { get; set; }
        public int LRIN_Number { get; set; }
        public int SPRN_Number { get; set; }
        public int CARLA_Number { get; set; }

        //Pick Storage
        public string PrimaryDC_ILOSCode { get; set; }
        public bool SAPPlant_0640 { get; set; }
        public bool SAPPlant_0650 { get; set; }
        public bool SAPPlant_0660 { get; set; }

        //Bundles
        public string ArticleBundle { get; set; }
        public int ArticleBundleQuantity { get; set; }

        //QIP
        public string QIPNumberAndName { get; set; }
        public string QIPDescription { get; set; }
        public string QIPAnswerOption { get; set; }
        public string QIPSetAnswer { get; set; }
        public string QIPOKValue { get; set; }
        public string QIPLowBoundary { get; set; }
        public string QIPHighBoundary { get; set; }
        public string QIPFrequencyType { get; set; }
        public string QIPFrequency { get; set; }

    }
}
