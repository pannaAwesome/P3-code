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
    public class PurchaserTest
    {
        private readonly HAVIdatabaseContext _context;
        private readonly HttpClient _client;

        public PurchaserTest()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);
            _context = server.Host.Services.GetService(typeof(HAVIdatabaseContext)) as HAVIdatabaseContext;
            _client = server.CreateClient();
        }

        [TestMethod]
        public async Task GetPurchaserReturnsExistingPurchaser()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            Purchaser purchaser = new Purchaser()
            {
                Id = 0,
                ProfileId = 0,
                CountryId = 0,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Purchaser expected = await purchaserService.CreatePurchaser(purchaser);

            // act
            Purchaser actual = await purchaserService.GetPurchaser(expected.Id);
            
            // assert
            Assert.IsTrue(expected.Country == actual.Country);
            Assert.IsTrue(expected.Id == actual.Id);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.Profile.Id == actual.Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual.Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual.Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Usertype == actual.Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual.Profile.Countries);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);

            await purchaserService.DeletePurchaserForProfile(expected.ProfileId);
        }

        [TestMethod]
        public async Task GetPurchaserReturnsNewPurchaserIfItDoesNotExist()
        {

            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            Purchaser expected = new Purchaser();

            // act
            Purchaser actual = await purchaserService.GetPurchaser(1);

            // assert
            Assert.IsTrue(expected.Country == actual.Country);
            Assert.IsTrue(expected.Id == actual.Id);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
        }

        [TestMethod]
        public async Task GetPurchasersForCountryReturnsPurchaserIfItExists()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);

            Purchaser purchaser = new Purchaser()
            {
                Id = 0,
                ProfileId = 0,
                CountryId = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryName = "Name",
                CountryCode = "Code",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            Country toDeleteCountry = await countryService.CreateCountry(country);
            Purchaser toDeletePurchaser = await purchaserService.CreatePurchaser(purchaser);
            int expected = 1;

            // act
            List<Purchaser> actual = await purchaserService.GetPurchasersForCountry(1);

            // assert
            Assert.IsTrue(actual.Count == expected);

            await purchaserService.DeletePurchaserForProfile(toDeletePurchaser.ProfileId);
            await countryService.DeleteCountry(toDeleteCountry.Id);
        }

        [TestMethod]
        public async Task GetPurchaserForProfileReturnsExistingPurchaser()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            Purchaser purchaser = new Purchaser()
            {
                Id = 0,
                ProfileId = 0,
                CountryId = 0,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Purchaser expected = await purchaserService.CreatePurchaser(purchaser);

            // act
            Purchaser actual = await purchaserService.GetPurchaserForProfile(expected.ProfileId);

            // assert
            Assert.IsTrue(expected.Country == actual.Country);
            Assert.IsTrue(expected.Id == actual.Id);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.Profile.Id == actual.Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual.Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual.Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Usertype == actual.Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual.Profile.Countries);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);

            await purchaserService.DeletePurchaserForProfile(expected.ProfileId);
        }

        [TestMethod]
        public async Task GetPurchaserForProfileReturnsNewPurchaserIfNotExist()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            Purchaser expected = new Purchaser();

            // act
            Purchaser actual = await purchaserService.GetPurchaserForProfile(0);

            // assert
            Assert.IsTrue(expected.Country == actual.Country);
            Assert.IsTrue(expected.Id == actual.Id);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
        }

        [TestMethod]
        public async Task GetPurchasersReturnsExistingPurchasers()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            Purchaser purchaser = new Purchaser()
            {
                Id = 0,
                ProfileId = 0,
                CountryId = 0,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            int expected = 1;
            Purchaser toDelete = await purchaserService.CreatePurchaser(purchaser);

            // act
            List<Purchaser> actual = await purchaserService.GetPurchasers();

            // assert
            Assert.IsTrue(expected == actual.Count);

            await purchaserService.DeletePurchaserForProfile(toDelete.ProfileId);
        }

        [TestMethod]
        public async Task GetPurchasersReturnsNewPurchaserListIfNoneExist()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            List<Purchaser> expected = new List<Purchaser>();

            // act
            var actual = await purchaserService.GetPurchasers();

            // assert
            Assert.IsTrue(actual.Count == 0);
        }

        [TestMethod]
        public async Task UpdatePurchaserUpdatesExistingPurchaser()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            Purchaser purchaser = new Purchaser()
            {
                Id = 0,
                ProfileId = 0,
                CountryId = 0,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Purchaser expected = await purchaserService.CreatePurchaser(purchaser);

            expected.Profile.Password = "12345";

            await purchaserService.UpdatePurchaser(expected.Id, expected);

            // act
            Purchaser actual = await purchaserService.GetPurchaser(expected.Id);

            // assert
            Assert.IsTrue(expected.Country == actual.Country);
            Assert.IsTrue(expected.Id == actual.Id);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.Profile.Id == actual.Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual.Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual.Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Usertype == actual.Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual.Profile.Countries);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);

            await purchaserService.DeletePurchaserForProfile(expected.ProfileId);
        }

        [TestMethod]
        public async Task UpdatePurchaserReturnsNotFoundIfItDoesNotExist()
        {
            // arrange
            Purchaser purchaser = new Purchaser()
            {
                Id = 0,
                ProfileId = 0,
                CountryId = 0,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            // act
            var result = await _client.PutAsJsonAsync($"/api/purchasers/{purchaser.Id}", purchaser);


            // assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task UpdatePurchaserReturnsBadResultIfSPurchaserAndIdDoNotMatch()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            Purchaser purchaser = new Purchaser()
            {
                Id = 0,
                ProfileId = 0,
                CountryId = 0,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Purchaser createPurchaser = await purchaserService.CreatePurchaser(purchaser);

            // act
            var result = await _client.PutAsJsonAsync($"/api/purchasers/{2}", createPurchaser);

            // assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.BadRequest);
            await purchaserService.DeletePurchaserForProfile(createPurchaser.ProfileId);
        }

        [TestMethod]
        public async Task DeletePurchaserForProfileDeletesThePurchaserIfItExists()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);

            Purchaser purchaser = new Purchaser()
            {
                Id = 0,
                ProfileId = 0,
                CountryId = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryName = "Name",
                CountryCode = "Code",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            Country createdCountry = await countryService.CreateCountry(country);
            Purchaser createdPurchaser = await purchaserService.CreatePurchaser(purchaser);
            await purchaserService.DeletePurchaserForProfile(createdPurchaser.ProfileId);

            // act
            Purchaser expected = new Purchaser();
            Purchaser actual = await purchaserService.GetPurchaser(createdPurchaser.ProfileId);

            // assert
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);

            await countryService.DeleteCountry(createdCountry.Id);
        }

        [TestMethod]
        public async Task DeletePurchaserForProfileReturnsNotFoundIfPurchaserDoesNotExists()
        {
            // act
            var result = await _client.DeleteAsync($"/api/purchasers/profile/{1}");

            // assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
