﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public enum ArticleStates { Created, Submitted, RobotReady, Completed, Error};
    public class Article
    {
        public int ID { get; set; }
        public int PurchaserID { get; set; }
        public int AdminID { get; set; }
        public int SupplierID { get; set; }
        public int ArticleInformationID { get; set; }
        public int InternalArticleInformationID { get; set; }   
        public DateTime DateCreated { get; set; }
        public bool ArticleInformationCompleted { get; set; }
        public bool InternalArticleInformationCompleted { get; set; }
        public ArticleStates ArticleState { get; set; }
        public bool ErrorReported { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorOwner { get; set; }
    }
}