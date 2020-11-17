﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class Purchaser
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public int CountryID { get; set; }

        public ICollection<Article> Articles { get; set; } 
        public Country Countries { get; set; }
        public Profile Profiles { get; set; }
    }
}
