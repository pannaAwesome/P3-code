using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Qipnumber
    {
        public int Id { get; set; }
        public string QipnumberName { get; set; }
        public string Qipdescription { get; set; }
        public string AnswerOptions { get; set; }
    }
}
