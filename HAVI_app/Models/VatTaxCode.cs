﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class VatTaxCode
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null;
    }
}
