using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HAVI_app.Models
{
    public partial class FreightResponsibility
    {

        [Key]
        public int Id { get; set; }
        public string Responsibility { get; set; }
    }
}
