using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace HAVI_app.Models
{
    public partial class DepartmentId
    {
        [Key]
        public int Id { get; set; }
        public string Department { get; set; }
    }
}
