using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Ilosorderpickgroup
    {
        public int Id { get; set; }
        public string Orderpickgroup { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
