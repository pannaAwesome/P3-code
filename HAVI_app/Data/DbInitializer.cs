using System;
using HAVI_app.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace HAVI_app.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HAVIdatabaseContext context)
        {
            if (context.Countries.Any())
            {
                return;
            }

            var profiles = new Profile[]
            {
                new Profile{Username="DKAdmin", Password="1234", Usertype=0}
            };

            context.Profiles.AddRange(profiles);
            context.SaveChanges();

            var countries = new Country[]
            {
                new Country{ProfileId=1, CountryName="Denmark", CountryCode="DK", CreationCode="12345"}
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();

            List<VailedForCustomer> customers = new List<VailedForCustomer>();

            using(TextFieldParser parser = new TextFieldParser(@"./Data/Kunder.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach(string field in fields)
                    {
                        customers.Add(new VailedForCustomer {Customer = field, CountryId = 1});
                    }
                }
            }

            context.VailedForCustomers.AddRange(customers);
            context.SaveChanges();
            Console.WriteLine("Database created!");
        }
    }
}