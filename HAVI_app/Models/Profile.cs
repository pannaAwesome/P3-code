using System;
using System.Collections.Generic;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Purchasers = new HashSet<Purchaser>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Usertype { get; set; }

        public virtual ICollection<Purchaser> Purchasers { get; set; }
    }
}
