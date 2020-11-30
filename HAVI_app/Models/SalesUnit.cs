using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HAVI_app.Models
{
    public partial class SalesUnit
    {
        [Key]
        public int Id { get; set; }
        public string Unit { get; set; }
    }
}
