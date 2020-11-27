using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Shared
{
    public class CurrentUser
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
