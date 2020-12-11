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
using Microsoft.AspNetCore.Http;

namespace HAVI_appTests.DatabaseTest.IntegrationTest
{
    [TestClass]
    public class SupplierTest
    {
        private readonly HAVIdatabaseContext _context;
        private readonly HttpClient _client;

        public SupplierTest()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);
            _context = server.Host.Services.GetService(typeof(HAVIdatabaseContext)) as HAVIdatabaseContext;
            _client = server.CreateClient();
        }

        [TestMethod]
        public async Task GetSupplierGetsExistingSupplier()
        {
            // arrange
            SupplierService supplierService = new SupplierService(_client);
            Supplier supplier = new Supplier()
            {
                Id = 0,
                ProfileId = 0,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Supplier expected = await supplierService.CreateSupplier(supplier);

            // act
            Supplier actual =  await supplierService.GetSupplier(expected.Id);

            // assert
            Assert.IsTrue(expected.CompanyLocation == actual.CompanyLocation);
            Assert.IsTrue(expected.CompanyName == actual.CompanyName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.FreightResponsibility == actual.FreightResponsibility);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.PalletExchange == actual.PalletExchange);
            Assert.IsTrue(expected.Profile.Id == actual.Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual.Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual.Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Suppliers, actual.Profile.Suppliers);
            Assert.IsTrue(expected.Profile.Usertype == actual.Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual.Profile.Countries);

            await supplierService.DeleteSupplier(actual.Id);
        }

        [TestMethod]
        public async Task GetSupplierNonExistingReturnsNewSupplier()
        {
            // arrange
            SupplierService supplierService = new SupplierService(_client);
            Supplier expected = new Supplier();

            // act
            Supplier actual = await supplierService.GetSupplier(1);

            // assert
            Assert.IsTrue(expected.CompanyLocation == actual.CompanyLocation);
            Assert.IsTrue(expected.CompanyName == actual.CompanyName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.FreightResponsibility == actual.FreightResponsibility);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.PalletExchange == actual.PalletExchange);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
        }
        
        [TestMethod]
        public async Task GetSupplierWithProfileGetExistingSupplierWithExistingProfile()
        {
            // arrange
            SupplierService supplierService = new SupplierService(_client);
            Supplier supplier = new Supplier()
            {
                Id = 0,
                ProfileId = 0,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Supplier expected = await supplierService.CreateSupplier(supplier);

            // act
            Supplier actual = await supplierService.GetSupplierWithProfile(expected.ProfileId);

            // assert
            Assert.IsTrue(expected.CompanyLocation == actual.CompanyLocation);
            Assert.IsTrue(expected.CompanyName == actual.CompanyName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.FreightResponsibility == actual.FreightResponsibility);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.PalletExchange == actual.PalletExchange);
            Assert.IsTrue(expected.Profile.Id == actual.Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual.Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual.Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Suppliers, actual.Profile.Suppliers);
            Assert.IsTrue(expected.Profile.Usertype == actual.Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual.Profile.Countries);

            await supplierService.DeleteSupplier(actual.Id);
        }

        [TestMethod]
        public async Task GetSupplierWithProfileNonExistingReturnsNewSupplier()
        {
            // arrange
            SupplierService supplierService = new SupplierService(_client);
            Supplier expected = new Supplier();

            // act
            Supplier actual = await supplierService.GetSupplierWithProfile(0);

            // assert
            Assert.IsTrue(expected.CompanyLocation == actual.CompanyLocation);
            Assert.IsTrue(expected.CompanyName == actual.CompanyName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.FreightResponsibility == actual.FreightResponsibility);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.PalletExchange == actual.PalletExchange);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
        }

        [TestMethod]
        public async Task GetSuppliersGetExistingSuppliers()
        {
            // arrange
            SupplierService supplierService = new SupplierService(_client);
            Supplier supplier1 = new Supplier()
            {
                Id = 0,
                ProfileId = 0,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Supplier supplier2 = new Supplier()
            {
                Id = 0,
                ProfileId = 0,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };
            supplier1 = await supplierService.CreateSupplier(supplier1);
            supplier2 = await supplierService.CreateSupplier(supplier2);
            int expected = 2;

            // act
            List<Supplier> actual = await supplierService.GetSuppliers();

            // assert
            Assert.IsTrue(expected == actual.Count);

            await supplierService.DeleteSupplier(supplier1.Id);
            await supplierService.DeleteSupplier(supplier2.Id);
        }

        [TestMethod]
        public async Task GetSuppliersNoExistingReturnsNewSupplierList()
        {
            // arrange
            SupplierService supplierService = new SupplierService(_client);
            int expected = 0;

            // act
            var actual = await supplierService.GetSuppliers();

            // assert
            Assert.IsTrue(expected == actual.Count);
        }

        [TestMethod]
        public async Task UpdateSupplierUpdatesExistingSupplier()
        {
            // arrange
            SupplierService supplierService = new SupplierService(_client);
            Supplier supplier = new Supplier()
            {
                Id = 0,
                ProfileId = 0,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Supplier expected = await supplierService.CreateSupplier(supplier);

            expected.CompanyName = "TestName";

            await supplierService.UpdateSupplier(expected.Id, expected);

            // act
            Supplier actual = await supplierService.GetSupplier(expected.Id);

            // assert
            Assert.IsTrue(expected.CompanyLocation == actual.CompanyLocation);
            Assert.IsTrue(expected.CompanyName == actual.CompanyName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.FreightResponsibility == actual.FreightResponsibility);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.PalletExchange == actual.PalletExchange);
            Assert.IsTrue(expected.Profile.Id == actual.Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual.Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual.Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual.Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Suppliers, actual.Profile.Suppliers);
            Assert.IsTrue(expected.Profile.Usertype == actual.Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual.Profile.Countries);

            await supplierService.DeleteSupplier(expected.Id);
        }

        [TestMethod]
        public async Task UpdateSupplierReturnsNotFoundIfItDoesNotExist()
        {
            //arrange
            SupplierService supplierService = new SupplierService(_client);
            Supplier supplier = new Supplier()
            {
                Id = 0,
                ProfileId = 0,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            // act
            var result = await _client.PutAsJsonAsync($"/api/suppliers/{supplier.Id}", supplier);


            // assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task UpdateSupplierReturnsBadResultIfSupplierAndIdDoNotMatch()
        {
            //arrange
            SupplierService supplierService = new SupplierService(_client);
            Supplier supplier = new Supplier()
            {
                Id = 0,
                ProfileId = 0,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Supplier createSupplier = await supplierService.CreateSupplier(supplier);

            // act
            var result = await _client.PutAsJsonAsync($"/api/suppliers/{2}", createSupplier);

            // assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.BadRequest);

            await supplierService.DeleteSupplier(createSupplier.Id);
        }


        [TestMethod]
        public async Task DeleteSupplierDeletesTheSupplierIfItExists()
        {
            // arrange
            SupplierService supplierService = new SupplierService(_client);
            Supplier supplier = new Supplier()
            {
                Id = 0,
                ProfileId = 0,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            Supplier createdSuppler = await supplierService.CreateSupplier(supplier);
            await supplierService.DeleteSupplier(createdSuppler.Id);
            
            // act
            Supplier expected = new Supplier();
            Supplier actual = await supplierService.GetSupplier(createdSuppler.Id);

            // assert
            Assert.IsNotNull(createdSuppler);
            Assert.IsTrue(expected.CompanyLocation == actual.CompanyLocation);
            Assert.IsTrue(expected.CompanyName == actual.CompanyName);
            CollectionAssert.AreEquivalent(expected.Articles, actual.Articles);
            Assert.IsTrue(expected.FreightResponsibility == actual.FreightResponsibility);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.PalletExchange == actual.PalletExchange);
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
        }

        [TestMethod]
        public async Task DeleteSupplierReturnsErrorIfSupplierDoesNotExists()
        {
            // act
            var result = await _client.DeleteAsync($"/api/suppliers/{1}");

            //assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
