using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public class CreationCode
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public int Active { get; set; }
    }
}
