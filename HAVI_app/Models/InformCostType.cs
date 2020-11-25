﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace HAVI_app.Models
{
    public partial class InformCostType
    {
        public int Id { get; set; }
        public string CostType { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
