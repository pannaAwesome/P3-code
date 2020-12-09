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

namespace HAVI_appTests.DatabaseTest
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
            PurchaserService PurchaserService = new PurchaserService(_client);
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

            Purchaser expected = await PurchaserService.CreatePurchaser(purchaser);

            // act
            Purchaser actual = await PurchaserService.GetPurchaser(expected.Id);
            
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
            PurchaserService PurchaserService = new PurchaserService(_client);
            Purchaser expected = new Purchaser();

            // act
            Purchaser actual = await PurchaserService.GetPurchaser(1);

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
            PurchaserService PurchaserService = new PurchaserService(_client);
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

            Purchaser expected = await PurchaserService.CreatePurchaser(purchaser);

            // act
            List<Purchaser> actual = await PurchaserService.GetPurchasersForCountry(expected.CountryId);

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
            PurchaserService PurchaserService = new PurchaserService(_client);
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

            Purchaser expected = await PurchaserService.CreatePurchaser(purchaser);

            // act
            Purchaser actual = await PurchaserService.GetPurchaserForProfile(expected.ProfileId);

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
            PurchaserService PurchaserService = new PurchaserService(_client);
            Purchaser expected = new Purchaser();

            // act
            Purchaser actual = await PurchaserService.GetPurchaserForProfile(0);

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
            PurchaserService PurchaserService = new PurchaserService(_client);
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

            Purchaser expected = await PurchaserService.CreatePurchaser(purchaser);

            // act
            List<Purchaser> actual = await PurchaserService.GetPurchasers();

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
            PurchaserService PurchaserService = new PurchaserService(_client);
            List<Purchaser> expected = new List<Purchaser>();

            // act
            var actual = await PurchaserService.GetPurchasers();

            // assert
            Assert.IsTrue((expected.Count == 0) && (actual.Count == 0));
        }

        [TestMethod]
        public async Task UpdatePurchaserUpdatesExistingPurchaser()
        {
            // arrange
            PurchaserService PurchaserService = new PurchaserService(_client);
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

            Purchaser expected = await PurchaserService.CreatePurchaser(purchaser);

            expected.Profile.Password = "12345";

            await PurchaserService.UpdatePurchaser(expected.Id, expected);

            // act
            Purchaser actual = await PurchaserService.GetPurchaser(expected.Id);

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

        /*[TestMethod]
        public async Task UpdatePurchaserReturnsEmptyPurchaserIfItDoesNotExist()
        {
            //arrange
            PurchaserService PurchaserService = new PurchaserService(_client);
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

            var result = await PurchaserService.UpdatePurchaser(1, purchaser);
            BadRequestObjectResult badRequestResult = await PurchaserService.UpdatePurchaser(1, Purchaser);
        }*/

        /*[TestMethod]
        public async Task UpdatePurchaserReturnsBadResutIfPurchaserAndIdDoNotMatch()
        {
            //arrange
            PurchaserService PurchaserService = new PurchaserService(_client);
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

            var result = await PurchaserService.UpdatePurchaser(1, purchaser);
            BadRequestObjectResult badRequestResult = await PurchaserService.UpdatePurchaser(1, Purchaser);
        }
        */

        [TestMethod]
        public async Task DeletePurchaserForProfileDeletesThePurchaserIfItExists()
        {
            // arrange
            PurchaserService PurchaserService = new PurchaserService(_client);
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

            Purchaser createdSuppler = await PurchaserService.CreatePurchaser(purchaser);
            await PurchaserService.DeletePurchaserForProfile(createdSuppler.Id);

            // act
            Purchaser expected = new Purchaser();
            Purchaser actual = await PurchaserService.GetPurchaser(createdSuppler.Id);

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
        public async Task DeletePurchaserForProfileReturnsErrorIfPurchaserDoesNotExists()
        {
            // arrange
            PurchaserService PurchaserService = new PurchaserService(_client);

            // act and assert
            try
            {
                await PurchaserService.DeletePurchaserForProfile(1);
                Assert.Fail("An exception Should have been thrown");
            }
            catch (InvalidOperationException ioe)
            {
                Assert.AreEqual($"Purchaser with id = {1} not found", ioe.Message);
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
