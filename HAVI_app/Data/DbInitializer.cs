using HAVI_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ArticleContext context)
        {
            context.Database.EnsureCreated();
            if (context.Countries.Any())
            {
                Console.WriteLine("Hello do not find me");
                return;
            }

            var profile = new Profile[]
            {
                new Profile{Username="DKAdmin", Password="1234", Usertype=UserType.Admin}
            };

            context.Profiles.AddRange(profile);
            context.SaveChanges();

            var country = new Country[]
            {
                new Country{CountryName="Denmark", CountryCode="DK"}
            };
            context.Countries.AddRange(country);
            context.SaveChanges();
            Console.WriteLine("Hello find me");
        }
    }
}
