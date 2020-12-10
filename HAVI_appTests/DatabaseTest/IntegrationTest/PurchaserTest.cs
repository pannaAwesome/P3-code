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
        public async Task GetPurchaserGetsExistingPurchaser()
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
        }

        [TestMethod]
        public async Task GetPurchaserNonExistingReturnsNewPurchaser()
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
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
        }

        [TestMethod]
        public async Task GetPurchasersForCountryGetsPurchaserIfItExists()
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
            List<Purchaser> actual = await purchaserService.GetPurchasersForCountry(expected.CountryId);

            // assert
            Assert.IsTrue(expected.Country == actual[0].Country);
            Assert.IsTrue(expected.Id == actual[0].Id);
            CollectionAssert.AreEquivalent(expected.Articles, actual[0].Articles);
            Assert.IsTrue(expected.CountryId == actual[0].CountryId);
            Assert.IsTrue(expected.Id == actual[0].Id);
            Assert.IsTrue(expected.Profile.Id == actual[0].Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual[0].Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual[0].Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual[0].Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual[0].Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Usertype == actual[0].Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual[0].Profile.Countries);
            Assert.IsTrue(expected.ProfileId == actual[0].ProfileId);
        }

        [TestMethod]
        public async Task GetPurchaserForProfileGetExistingPurchaserWithExistingProfile()
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
        }

        [TestMethod]
        public async Task GetPurchaserForProfileNonExistingReturnsNewPurchaser()
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
        public async Task GetPurchasersGetExistingPurchasers()
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
            List<Purchaser> actual = await purchaserService.GetPurchasers();

            // assert
            Assert.IsTrue(expected.Country == actual[0].Country);
            Assert.IsTrue(expected.Id == actual[0].Id);
            CollectionAssert.AreEquivalent(expected.Articles, actual[0].Articles);
            Assert.IsTrue(expected.CountryId == actual[0].CountryId);
            Assert.IsTrue(expected.Id == actual[0].Id);
            Assert.IsTrue(expected.Profile.Id == actual[0].Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual[0].Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual[0].Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual[0].Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual[0].Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Usertype == actual[0].Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual[0].Profile.Countries);
            Assert.IsTrue(expected.ProfileId == actual[0].ProfileId);
        }

        [TestMethod]
        public async Task GetPurchasersNoExistingReturnsNewPurchaserList()
        {
            // arrange
            PurchaserService purchaserService = new PurchaserService(_client);
            List<Purchaser> expected = new List<Purchaser>();

            // act
            var actual = await purchaserService.GetPurchasers();

            // assert
            Assert.IsTrue((expected.Count == 0) && (actual.Count == 0));
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
        }

        [TestMethod]
        public async Task DeletePurchaserForProfileDeletesThePurchaserIfItExists()
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

            Purchaser createdSuppler = await purchaserService.CreatePurchaser(purchaser);
            await purchaserService.DeletePurchaserForProfile(createdSuppler.Id);

            // act
            Purchaser expected = new Purchaser();
            Purchaser actual = await purchaserService.GetPurchaser(createdSuppler.Id);

            // assert
            Assert.IsNotNull(createdSuppler);
            Assert.IsTrue(expected.Country == actual.Country);
            Assert.IsTrue(expected.Id == actual.Id);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
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
