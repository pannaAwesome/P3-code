using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Models
{
    public enum UserType { Admin, Purchaser, Supplier };
    public class Profile
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType Usertype { get; set; }
    }
}
