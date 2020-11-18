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
                new Country{ProfileId=1, CountryName="Denmark", CountryCode="DK"}
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();

            List<VailedForCustomer> customers = new List<VailedForCustomer>();

            using(TextFieldParser parser = new TextFieldParser(@"./Data/Customer.csv"))
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

            List<Location> locations = new List<Location>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/Countries.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        locations.Add(new Location { Country = field });
                    }
                }
            }

            context.Locations.AddRange(locations);
            context.SaveChanges();

            List<SalesUnit> salesunits = new List<SalesUnit>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/Salesunits.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        salesunits.Add(new SalesUnit { Unit = field });
                    }
                }
            }

            context.SalesUnits.AddRange(salesunits);
            context.SaveChanges();

            List<Ilosorderpickgroup> orderpickgroup = new List<Ilosorderpickgroup>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/ILOSOrderpickgroup.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        orderpickgroup.Add(new Ilosorderpickgroup { Orderpickgroup = field, CountryId = 1 });
                    }
                }
            }

            context.Ilosorderpickgroups.AddRange(orderpickgroup);
            context.SaveChanges();

            List<VatTaxCode> vatTaxCodes = new List<VatTaxCode>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/TAXCode.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        vatTaxCodes.Add(new VatTaxCode { Code = field, CountryId = 1 });
                    }
                }
            }

            context.VatTaxCodes.AddRange(vatTaxCodes);
            context.SaveChanges();


            List<IlossortGroup> sortGroup = new List<IlossortGroup>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/ILOSTemp.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        sortGroup.Add(new IlossortGroup { SortGroup = field });
                    }
                }
            }

            context.IlossortGroups.AddRange(sortGroup);
            context.SaveChanges();

            List<Iloscategory> categories = new List<Iloscategory>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/ILOSAcc.csv"))
            { 
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            categories.Add(new Iloscategory { Category = field, CountryId = 1 });
                        }
                    }
                }

                context.Iloscategories.AddRange(categories);
                context.SaveChanges();
            }
            Console.WriteLine("Database created!");
        }
    }
}