using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace HAVI_app.Models
{
    public partial class Profile
    {
        public Profile()
        {
            Purchasers = new HashSet<Purchaser>();
            Suppliers = new HashSet<Supplier>();
            Countries = new HashSet<Country>();
        }

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Usertype { get; set; }

        [JsonIgnore]
        public virtual ICollection<Country> Countries { get; set; }
        [JsonIgnore]
        public virtual ICollection<Purchaser> Purchasers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
