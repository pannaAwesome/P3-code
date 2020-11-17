﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class SupplierDeliveryUnit
    {
        public int ID { get; set; }
        public string Unit { get; set; }
        public int CountryID { get; set; }

        public virtual Country Countries { get; set; }
    }
}