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


namespace HAVI_appTests.DatabaseTest
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
        public async Task GetSupplierGetExistingSupplier()
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
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
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
            Assert.IsTrue(expected.ProfileId == actual.ProfileId);
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
            List<Supplier> actual = await supplierService.GetSuppliers();

            // assert
            Assert.IsTrue(expected.CompanyLocation == actual[0].CompanyLocation);
            Assert.IsTrue(expected.CompanyName == actual[0].CompanyName);
            CollectionAssert.AreEquivalent(expected.Articles, actual[0].Articles);
            Assert.IsTrue(expected.FreightResponsibility == actual[0].FreightResponsibility);
            Assert.IsTrue(expected.Id == actual[0].Id);
            Assert.IsTrue(expected.PalletExchange == actual[0].PalletExchange);
            Assert.IsTrue(expected.Profile.Id == actual[0].Profile.Id);
            Assert.IsTrue(expected.Profile.Password == actual[0].Profile.Password);
            CollectionAssert.AreEquivalent(expected.Profile.Purchasers, actual[0].Profile.Purchasers);
            Assert.IsTrue(expected.Profile.Username == actual[0].Profile.Username);
            CollectionAssert.AreEquivalent(expected.Profile.Suppliers, actual[0].Profile.Suppliers);
            Assert.IsTrue(expected.Profile.Usertype == actual[0].Profile.Usertype);
            CollectionAssert.AreEquivalent(expected.Profile.Countries, actual[0].Profile.Countries);
            Assert.IsTrue(expected.ProfileId == actual[0].ProfileId);
        }

        [TestMethod]
        public async Task GetSuppliersNonExistingReturnsNewSupplier()
        {
            // arrange
            SupplierService supplierService = new SupplierService(_client);
            List<Supplier> expected = new List<Supplier>();

            // act
            var actual = await supplierService.GetSuppliers();

            // assert
            Assert.IsTrue((expected.Count == 0) && (actual.Count == 0));
        }
    }
}
