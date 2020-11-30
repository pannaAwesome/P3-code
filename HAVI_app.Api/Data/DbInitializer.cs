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
                new Profile{Username="DKAdmin", Password="1234", Usertype=0},
                new Profile{Username="Purchaser", Password="1234", Usertype=1},
                new Profile{Username="Supplier", Password="1234", Usertype=2}
            };

            context.Profiles.AddRange(profiles);
            context.SaveChanges();

            var countries = new Country[]
            {
                new Country{CountryName="Denmark",
                            CountryCode="DK",
                            ProfileId = profiles.Single(p => p.Username == "DKAdmin").Id,
                            Profile = profiles.Single(p => p.Username == "DKAdmin"),
                            PrimaryDciloscodes = new List<PrimaryDciloscode>(),
                            Purchasers = new List<Purchaser>(),
                            SupplierDeliveryUnits = new List<SupplierDeliveryUnit>(),
                            Articles = new List<Article>(),
                            VailedForCustomers = new List<VailedForCustomer>(),
                            VatTaxCodes = new List<VatTaxCode>(),
                            Iloscategories = new List<Iloscategory>(),
                            Ilosorderpickgroups = new List<Ilosorderpickgroup>(),
                            InformCostTypes = new List<InformCostType>()
                            }
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();

            var purchasers = new Purchaser[]
            {
                new Purchaser{CountryId = countries.Single(c => c.CountryCode == "DK").Id,
                              Country = countries.Single(c => c.CountryCode == "DK"),
                              ProfileId = profiles.Single(p => p.Username == "Purchaser").Id,
                              Profile = profiles.Single(p => p.Username == "Purchaser"),
                              Articles = new List<Article>()
                              }
            };

            context.Purchasers.AddRange(purchasers);
            context.SaveChanges();

            var suppliers = new Supplier[]
            {
                new Supplier{ProfileId = profiles.Single(p => p.Username == "Supplier").Id,
                             Profile = profiles.Single(p => p.Username == "Supplier"),
                             CompanyLocation="Denmark",
                             CompanyName="Hello and co.",
                             FreightResponsibility="EXP",
                             PalletExchange=1,
                             Articles = new List<Article>()
                            }
            };

            context.Suppliers.AddRange(suppliers);
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
                        customers.Add(new VailedForCustomer {Customer = field,
                                                             CountryId = countries.Single(c => c.CountryCode == "DK").Id,
                                                             Country = countries.Single(c => c.CountryCode == "DK")
                                                            });
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
                        orderpickgroup.Add(new Ilosorderpickgroup { Orderpickgroup = field,
                            CountryId = countries.Single(c => c.CountryCode == "DK").Id,
                            Country = countries.Single(c => c.CountryCode == "DK")
                        });
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
                        vatTaxCodes.Add(new VatTaxCode { Code = field,
                            CountryId = countries.Single(c => c.CountryCode == "DK").Id,
                            Country = countries.Single(c => c.CountryCode == "DK")
                        });
                    }
                }
            }

            context.VatTaxCodes.AddRange(vatTaxCodes);
            context.SaveChanges();


            List<IlossortGroup> sortGroup = new List<IlossortGroup>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/ILOSSortGroup.csv"))
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

            using (TextFieldParser parser = new TextFieldParser(@"./Data/ILOSCategory.csv"))
            {
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            categories.Add(new Iloscategory { Category = field,
                                CountryId = countries.Single(c => c.CountryCode == "DK").Id,
                                Country = countries.Single(c => c.CountryCode == "DK")
                            });
                        }
                    }
                }
            }
            context.Iloscategories.AddRange(categories);
            context.SaveChanges();

            List<SetCurrency> currencies = new List<SetCurrency>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/Currency.csv"))
            {
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            currencies.Add(new SetCurrency { CurrencyName = field });
                        }
                    }
                }
            }
            context.SetCurrencies.AddRange(currencies);
            context.SaveChanges();

            List<InformCostType> duties = new List<InformCostType>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/Duties.csv"))
            {
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            duties.Add(new InformCostType { CostType = field,
                                CountryId = countries.Single(c => c.CountryCode == "DK").Id,
                                Country = countries.Single(c => c.CountryCode == "DK")
                            });
                        }
                    }
                }
            }
            context.InformCostTypes.AddRange(duties);
            context.SaveChanges();

            List<FreightResponsibility> freights = new List<FreightResponsibility>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/Freight.csv"))
            {
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            freights.Add(new FreightResponsibility { Responsibility = field });
                        }
                    }
                }
            }
            context.FreightResponsibilities.AddRange(freights);
            context.SaveChanges();

            List<PackagingGroup> packagingGroups = new List<PackagingGroup>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/Packing.csv"))
            {
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {
                            packagingGroups.Add(new PackagingGroup { Group = field });
                        }
                    }
                }
            }
            context.PackagingGroups.AddRange(packagingGroups);
            context.SaveChanges();

            List<DepartmentId> departments = new List<DepartmentId>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/DepartmentID.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        departments.Add(new DepartmentId { Department = field });
                    }
                }
            }

            context.DeparmentIds.AddRange(departments);
            context.SaveChanges();


            List<PrimaryDciloscode> ilosCode = new List<PrimaryDciloscode>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/PrimaryDCILOScode.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    ilosCode.Add(new PrimaryDciloscode { PrimaryCode = fields[0], Sapplant = fields[1],
                        CountryId = countries.Single(c => c.CountryCode == "DK").Id,
                        Country = countries.Single(c => c.CountryCode == "DK")
                    });
                }
            }

            context.PrimaryDciloscodes.AddRange(ilosCode);
            context.SaveChanges();

            List<Qipnumber> qipnumbers = new List<Qipnumber>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/QIP.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    qipnumbers.Add(new Qipnumber { QipnumberName = fields[0], Qipdescription = fields[1], AnswerOptions=fields[2], SetAnswer=Int32.Parse(fields[3]), OKValue= Int32.Parse(fields[4]), LowBoundary= Int32.Parse(fields[5]), HighBoundary= Int32.Parse(fields[6]), FrequencyType= Int32.Parse(fields[7]), Frequency= Int32.Parse(fields[8])});
                }
            }

            context.Qipnumbers.AddRange(qipnumbers);
            context.SaveChanges();

            List<CompanyCode> codes = new List<CompanyCode>();

            using (TextFieldParser parser = new TextFieldParser(@"./Data/CompanyCode.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        codes.Add(new CompanyCode { Code = field, CountryId = 1 });
                    }
                }
            }

            context.CompanyCodes.AddRange(codes);
            context.SaveChanges();

            Console.WriteLine("Database created!");
        }
    }

}