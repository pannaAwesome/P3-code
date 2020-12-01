using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Qipnumber
    {
        [Key]
        public int Id { get; set; }
        public string QipnumberName { get; set; } = "";
        public string Qipdescription { get; set; } = "";
        public string AnswerOptions { get; set; } = "";
        public int SetAnswer { get; set; }
        public int OKValue { get; set; }
        public int LowBoundary { get; set; }
        public int HighBoundary { get; set; }
        public int FrequencyType { get; set; }
        public int Frequency { get; set; }

    }
}
