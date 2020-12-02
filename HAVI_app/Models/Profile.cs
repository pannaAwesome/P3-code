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
            Purchasers = new List<Purchaser>();
            Suppliers = new List<Supplier>();
            Countries = new List<Country>();
        }

        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public int Usertype { get; set; }

        [JsonIgnore]
        public virtual List<Country> Countries { get; set; }
        [JsonIgnore]
        public virtual List<Purchaser> Purchasers { get; set; }
        [JsonIgnore]
        public virtual List<Supplier> Suppliers { get; set; }
    }
}
