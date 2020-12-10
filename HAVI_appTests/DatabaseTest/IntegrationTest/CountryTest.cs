using HAVI_app.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HAVI_app.Api;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HAVI_app.Services.Classes;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace HAVI_appTests.DatabaseTest.IntegrationTest
{
    [TestClass]
    public class CountryTest
    {
        private readonly HAVIdatabaseContext _context;
        private readonly HttpClient _client;

        public CountryTest()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);
            _context = server.Host.Services.GetService(typeof(HAVIdatabaseContext)) as HAVIdatabaseContext;
            _client = server.CreateClient();
        }

        [TestMethod]
        public async Task GetCountryGetsExistingCountry()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            Country expected = await CountryService.CreateCountry(country);

            // act
            Country actual = await CountryService.GetCountry(expected.Id);

            // assert
            Assert.IsTrue(expected.CountryCode == actual.CountryCode);
            Assert.IsTrue(expected.CountryName == actual.CountryName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.Profile.Id == actual.Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual.Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual.Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Suppliers, actual.Profile.Suppliers);
            Assert.IsTrue(expected.Profile.Usertype == actual.Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual.Profile.Countries);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
            CollectionAssert.AreEquivalent(expected.CompanyCodes, actual.CompanyCodes);
            CollectionAssert.AreEquivalent(expected.Iloscategories, actual.Iloscategories);
            CollectionAssert.AreEquivalent(expected.Ilosorderpickgroups, actual.Ilosorderpickgroups);
            CollectionAssert.AreEquivalent(expected.InformCostTypes, actual.InformCostTypes);
            CollectionAssert.AreEquivalent(expected.PrimaryDciloscodes, actual.PrimaryDciloscodes);
            CollectionAssert.AreEquivalent(expected.Purchasers, actual.Purchasers);
            CollectionAssert.AreEquivalent(expected.SupplierDeliveryUnits, actual.SupplierDeliveryUnits);
            CollectionAssert.AreEquivalent(expected.VailedForCustomers, actual.VailedForCustomers);
            CollectionAssert.AreEquivalent(expected.VatTaxCodes, actual.VatTaxCodes);
        }

        [TestMethod]
        public async Task GetCountryReturnNewCountryIfItDoesNotExist()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country expected = new Country();
            // act
            Country actual = await CountryService.GetCountry(country.Id);

            // assert
            Assert.IsTrue(expected.CountryCode == actual.CountryCode);
            Assert.IsTrue(expected.CountryName == actual.CountryName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
            CollectionAssert.AreEquivalent(expected.CompanyCodes, actual.CompanyCodes);
            CollectionAssert.AreEquivalent(expected.Iloscategories, actual.Iloscategories);
            CollectionAssert.AreEquivalent(expected.Ilosorderpickgroups, actual.Ilosorderpickgroups);
            CollectionAssert.AreEquivalent(expected.InformCostTypes, actual.InformCostTypes);
            CollectionAssert.AreEquivalent(expected.PrimaryDciloscodes, actual.PrimaryDciloscodes);
            CollectionAssert.AreEquivalent(expected.Purchasers, actual.Purchasers);
            CollectionAssert.AreEquivalent(expected.SupplierDeliveryUnits, actual.SupplierDeliveryUnits);
            CollectionAssert.AreEquivalent(expected.VailedForCustomers, actual.VailedForCustomers);
            CollectionAssert.AreEquivalent(expected.VatTaxCodes, actual.VatTaxCodes);
        }

        [TestMethod]
        public async Task GetCountryIdWithProfileReturnsExistingCountryWithProfile()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country expected = await CountryService.CreateCountry(country);
            // act
            Country actual = await CountryService.GetCountryWithProfile(expected.ProfileId);

            // assert
            Assert.IsTrue(expected.CountryCode == actual.CountryCode);
            Assert.IsTrue(expected.CountryName == actual.CountryName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
            CollectionAssert.AreEquivalent(expected.CompanyCodes, actual.CompanyCodes);
            CollectionAssert.AreEquivalent(expected.Iloscategories, actual.Iloscategories);
            CollectionAssert.AreEquivalent(expected.Ilosorderpickgroups, actual.Ilosorderpickgroups);
            CollectionAssert.AreEquivalent(expected.InformCostTypes, actual.InformCostTypes);
            CollectionAssert.AreEquivalent(expected.PrimaryDciloscodes, actual.PrimaryDciloscodes);
            CollectionAssert.AreEquivalent(expected.Purchasers, actual.Purchasers);
            CollectionAssert.AreEquivalent(expected.SupplierDeliveryUnits, actual.SupplierDeliveryUnits);
            CollectionAssert.AreEquivalent(expected.VailedForCustomers, actual.VailedForCustomers);
            CollectionAssert.AreEquivalent(expected.VatTaxCodes, actual.VatTaxCodes);
        }

        [TestMethod]
        public async Task GetCountryIdWithProfileReturnsNewCountryIfNotExist()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country expected = new Country();
            // act
            Country actual = await CountryService.GetCountryWithProfile(expected.ProfileId);

            // assert
            Assert.IsTrue(expected.CountryCode == actual.CountryCode);
            Assert.IsTrue(expected.CountryName == actual.CountryName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
            CollectionAssert.AreEquivalent(expected.CompanyCodes, actual.CompanyCodes);
            CollectionAssert.AreEquivalent(expected.Iloscategories, actual.Iloscategories);
            CollectionAssert.AreEquivalent(expected.Ilosorderpickgroups, actual.Ilosorderpickgroups);
            CollectionAssert.AreEquivalent(expected.InformCostTypes, actual.InformCostTypes);
            CollectionAssert.AreEquivalent(expected.PrimaryDciloscodes, actual.PrimaryDciloscodes);
            CollectionAssert.AreEquivalent(expected.Purchasers, actual.Purchasers);
            CollectionAssert.AreEquivalent(expected.SupplierDeliveryUnits, actual.SupplierDeliveryUnits);
            CollectionAssert.AreEquivalent(expected.VailedForCustomers, actual.VailedForCustomers);
            CollectionAssert.AreEquivalent(expected.VatTaxCodes, actual.VatTaxCodes);
        }

        [TestMethod]
        public async Task GetCountryWithNameGetsExistingCountry()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            Country expected = await CountryService.CreateCountry(country);

            // act
            Country actual = await CountryService.GetCountryWithName(expected.CountryName);

            // assert
            Assert.IsTrue(expected.CountryCode == actual.CountryCode);
            Assert.IsTrue(expected.CountryName == actual.CountryName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
            CollectionAssert.AreEquivalent(expected.CompanyCodes, actual.CompanyCodes);
            CollectionAssert.AreEquivalent(expected.Iloscategories, actual.Iloscategories);
            CollectionAssert.AreEquivalent(expected.Ilosorderpickgroups, actual.Ilosorderpickgroups);
            CollectionAssert.AreEquivalent(expected.InformCostTypes, actual.InformCostTypes);
            CollectionAssert.AreEquivalent(expected.PrimaryDciloscodes, actual.PrimaryDciloscodes);
            CollectionAssert.AreEquivalent(expected.Purchasers, actual.Purchasers);
            CollectionAssert.AreEquivalent(expected.SupplierDeliveryUnits, actual.SupplierDeliveryUnits);
            CollectionAssert.AreEquivalent(expected.VailedForCustomers, actual.VailedForCustomers);
            CollectionAssert.AreEquivalent(expected.VatTaxCodes, actual.VatTaxCodes);
        }

        [TestMethod]
        public async Task GetCountryWithNameGetsNewCountryIfCountryDoesNotExist()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            Country expected = new Country();
            // act
            Country actual = await CountryService.GetCountryWithName(country.CountryName);

            // assert
            Assert.IsTrue(expected.CountryCode == actual.CountryCode);
            Assert.IsTrue(expected.CountryName == actual.CountryName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
            CollectionAssert.AreEquivalent(expected.CompanyCodes, actual.CompanyCodes);
            CollectionAssert.AreEquivalent(expected.Iloscategories, actual.Iloscategories);
            CollectionAssert.AreEquivalent(expected.Ilosorderpickgroups, actual.Ilosorderpickgroups);
            CollectionAssert.AreEquivalent(expected.InformCostTypes, actual.InformCostTypes);
            CollectionAssert.AreEquivalent(expected.PrimaryDciloscodes, actual.PrimaryDciloscodes);
            CollectionAssert.AreEquivalent(expected.Purchasers, actual.Purchasers);
            CollectionAssert.AreEquivalent(expected.SupplierDeliveryUnits, actual.SupplierDeliveryUnits);
            CollectionAssert.AreEquivalent(expected.VailedForCustomers, actual.VailedForCustomers);
            CollectionAssert.AreEquivalent(expected.VatTaxCodes, actual.VatTaxCodes);
        }

        [TestMethod]
        public async Task GetCountriesGetCountriesIfCountryExists()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            List<Country> expected = new List<Country>();
            expected.Add(await CountryService.CreateCountry(country));

            List<Country> actual = await CountryService.GetCountries();

            // assert
            Assert.IsTrue(expected[0].CountryCode == actual[0].CountryCode);
            Assert.IsTrue(expected[0].CountryName == actual[0].CountryName);
            CollectionAssert.AreEquivalent(expected[0].Articles, actual[0].Articles);
            Assert.IsTrue(expected[0].Id == actual[0].Id);
            Assert.IsTrue(expected[0].Profile.Id == actual[0].Profile.Id);
            Assert.IsTrue(expected[0].Profile.Password == actual[0].Profile.Password);
            CollectionAssert.AreEquivalent(expected[0].Profile.Purchasers, actual[0].Profile.Purchasers);
            Assert.IsTrue(expected[0].Profile.Username == actual[0].Profile.Username);
            CollectionAssert.AreEquivalent(expected[0].Profile.Suppliers, actual[0].Profile.Suppliers);
            Assert.IsTrue(expected[0].Profile.Usertype == actual[0].Profile.Usertype);
            CollectionAssert.AreEquivalent(expected[0].Profile.Countries, actual[0].Profile.Countries);
            Assert.IsTrue(expected[0].ProfileId == actual[0].ProfileId);
            CollectionAssert.AreEquivalent(expected[0].CompanyCodes, actual[0].CompanyCodes);
            CollectionAssert.AreEquivalent(expected[0].Iloscategories, actual[0].Iloscategories);
            CollectionAssert.AreEquivalent(expected[0].Ilosorderpickgroups, actual[0].Ilosorderpickgroups);
            CollectionAssert.AreEquivalent(expected[0].InformCostTypes, actual[0].InformCostTypes);
            CollectionAssert.AreEquivalent(expected[0].PrimaryDciloscodes, actual[0].PrimaryDciloscodes);
            CollectionAssert.AreEquivalent(expected[0].Purchasers, actual[0].Purchasers);
            CollectionAssert.AreEquivalent(expected[0].SupplierDeliveryUnits, actual[0].SupplierDeliveryUnits);
            CollectionAssert.AreEquivalent(expected[0].VailedForCustomers, actual[0].VailedForCustomers);
            CollectionAssert.AreEquivalent(expected[0].VatTaxCodes, actual[0].VatTaxCodes);
        }

        [TestMethod]
        public async Task GetCountriesGetNewCountryIfNoneExist()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            List<Country> expected = new List<Country>();
            List<Country> actual = await CountryService.GetCountries();

            // assert
            Assert.IsTrue(expected.Count == 0 && actual.Count == 0);
        }

        [TestMethod]
        public async Task UpdateCountryUpdatesExistingCountry()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            Country expected = await CountryService.CreateCountry(country);
            expected.CountryName = "TestName";

            await CountryService.UpdateCountry(expected.Id, expected);

            // act
            Country actual = await CountryService.GetCountry(expected.Id);

            // assert
            Assert.IsTrue(expected.CountryCode == actual.CountryCode);
            Assert.IsTrue(expected.CountryName == actual.CountryName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.Profile.Id == actual.Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual.Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual.Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Suppliers, actual.Profile.Suppliers);
            Assert.IsTrue(expected.Profile.Usertype == actual.Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual.Profile.Countries);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
            CollectionAssert.AreEquivalent(expected.CompanyCodes, actual.CompanyCodes);
            CollectionAssert.AreEquivalent(expected.Iloscategories, actual.Iloscategories);
            CollectionAssert.AreEquivalent(expected.Ilosorderpickgroups, actual.Ilosorderpickgroups);
            CollectionAssert.AreEquivalent(expected.InformCostTypes, actual.InformCostTypes);
            CollectionAssert.AreEquivalent(expected.PrimaryDciloscodes, actual.PrimaryDciloscodes);
            CollectionAssert.AreEquivalent(expected.Purchasers, actual.Purchasers);
            CollectionAssert.AreEquivalent(expected.SupplierDeliveryUnits, actual.SupplierDeliveryUnits);
            CollectionAssert.AreEquivalent(expected.VailedForCustomers, actual.VailedForCustomers);
            CollectionAssert.AreEquivalent(expected.VatTaxCodes, actual.VatTaxCodes);
        }

        /*[TestMethod]
        public async Task UpdateCountryReturnsEmptyCountryIfItDoesNotExist()
        {
            //arrange
           CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            var result = await CountryService.UpdateCountry(1, country);
            BadRequestObjectResult badRequestResult = await CountryService.UpdateCountry(1, country);
        }*/

        /*[TestMethod]
        public async Task UpdateCountryReturnsBadResutIfCountryAndIdDoNotMatch()
        {
            //arrange
           CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            var result = await countryService.UpdateCountry(1, country);
            BadRequestObjectResult badRequestResult = await countryService.UpdateCountry(1, country);
        }
        */

        [TestMethod]
        public async Task DeleteCountryDeletesTheCountryIfItExists()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            Country createdSuppler = await CountryService.CreateCountry(country);
            await CountryService.DeleteCountry(createdSuppler.Id);

            // act
            Country expected = new Country();
            Country actual = await CountryService.GetCountry(createdSuppler.Id);

            // assert
            Assert.IsNotNull(expected);
            Assert.IsTrue(expected.CountryCode == actual.CountryCode);
            Assert.IsTrue(expected.CountryName == actual.CountryName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
            CollectionAssert.AreEquivalent(expected.CompanyCodes, actual.CompanyCodes);
            CollectionAssert.AreEquivalent(expected.Iloscategories, actual.Iloscategories);
            CollectionAssert.AreEquivalent(expected.Ilosorderpickgroups, actual.Ilosorderpickgroups);
            CollectionAssert.AreEquivalent(expected.InformCostTypes, actual.InformCostTypes);
            CollectionAssert.AreEquivalent(expected.PrimaryDciloscodes, actual.PrimaryDciloscodes);
            CollectionAssert.AreEquivalent(expected.Purchasers, actual.Purchasers);
            CollectionAssert.AreEquivalent(expected.SupplierDeliveryUnits, actual.SupplierDeliveryUnits);
            CollectionAssert.AreEquivalent(expected.VailedForCustomers, actual.VailedForCustomers);
            CollectionAssert.AreEquivalent(expected.VatTaxCodes, actual.VatTaxCodes);

        }

        [TestMethod]
        public async Task DeleteCountryReturnsErrorIfCountryDoesNotExists()
        {
            // arrange
            CountryService CountryService = new CountryService(_client);

            // act and assert
            try
            {
                await CountryService.DeleteCountry(1);
                Assert.Fail("An exception Should have been thrown");
            }
            catch (InvalidOperationException ioe)
            {
                Assert.AreEqual($"Country with id = {1} not found", ioe.Message);
            }
            catch (Exception e)
            {
                Assert.Fail(
                    string.Format($"Unexpected exception of type {e.GetType()} caught: {e.Message} ")
                    );
            }
        }
    }
}
