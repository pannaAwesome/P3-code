using System;
using HAVI_app.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Data
{
    public class DbInitializer
    {
        public static void Initialize(masterContext context)
        {
            if (context.Profiles.Any())
            {
                return;
            }
            
            var profiles = new Profile[]
            {

            }
        }
    }
}