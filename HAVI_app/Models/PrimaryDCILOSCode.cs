﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HAVI_app.Models
{
    public partial class PrimaryDciloscode
    {
        public int Id { get; set; }
        public string PrimaryCode { get; set; }
        public string Sapplant { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
