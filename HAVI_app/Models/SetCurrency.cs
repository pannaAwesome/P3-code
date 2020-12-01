using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HAVI_app.Models
{
    public partial class SetCurrency
    {
        [Key]
        public int Id { get; set; }
        public string CurrencyName { get; set; }
    }
}
