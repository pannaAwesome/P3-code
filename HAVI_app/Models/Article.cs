using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public enum ArticleStates { Created, Submitted, RobotReady, Error, Completed };
    public enum ErrorReported { None, Reported };
    public enum InformationCompleted { Unfinished, Finished };
    public enum RadioButton { No, Yes };
    public partial class Article
    {
        public int Id { get; set; }
        public int PurchaserId { get; set; }
        public int SupplierId { get; set; }
        public int CountryId { get; set; }
        public int ArticleInformationId { get; set; }
        public int InternalArticleInformationId { get; set; }
        public string VailedForCustomer { get; set; }
        public DateTime DateCreated { get; set; }
        public int ArticleInformationCompleted { get; set; }
        public int InternalArticalInformationCompleted { get; set; }
        public int ArticleState { get; set; }
        public int ErrorReported { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorOwner { get; set; }

        public virtual ArticleInformation ArticleInformation { get; set; }
        public virtual Country Country { get; set; }
        public virtual InternalArticleInformation InternalArticleInformation { get; set; }
        public virtual Purchaser Purchaser { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
