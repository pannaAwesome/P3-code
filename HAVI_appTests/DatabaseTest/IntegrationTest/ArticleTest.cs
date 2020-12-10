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
    public class ArticleTest
    {
        private readonly HAVIdatabaseContext _context;
        private readonly HttpClient _client;

        public ArticleTest()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);
            _context = server.Host.Services.GetService(typeof(HAVIdatabaseContext)) as HAVIdatabaseContext;
            _client = server.CreateClient();
        }

        [TestMethod]
        public async Task GetArticlesWithCertainStateReturnArticlesWithState()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 0,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            Article expected = await articleService.CreateArticle(article);

            // act
            List<Article> actual = await articleService.GetArticleWithCertainState(article.CountryId, article.ArticleState);

            // assert
            Assert.IsTrue(expected.ArticleInformationCompleted == actual[0].ArticleInformationCompleted);
            Assert.IsTrue(expected.ArticleInformationId == actual[0].ArticleInformationId);
            Assert.IsTrue(expected.ArticleState == actual[0].ArticleState);
            Assert.IsTrue(expected.CountryId == actual[0].CountryId);
            Assert.IsTrue(expected.DateCreated == actual[0].DateCreated);
            Assert.IsTrue(expected.ErrorField == actual[0].ErrorField);
            Assert.IsTrue(expected.ErrorMessage == actual[0].ErrorMessage);
            Assert.IsTrue(expected.ErrorOwner == actual[0].ErrorOwner);
            Assert.IsTrue(expected.ErrorReported == actual[0].ErrorReported);
            Assert.IsTrue(expected.Id == actual[0].Id);
            Assert.IsTrue(expected.InternalArticalInformationCompleted == actual[0].InternalArticalInformationCompleted);
            Assert.IsTrue(expected.InternalArticleInformationId == actual[0].InternalArticleInformationId);
            Assert.IsTrue(expected.PurchaserId == actual[0].PurchaserId);
            Assert.IsTrue(expected.SupplierId == actual[0].SupplierId);
            Assert.IsTrue(expected.VailedForCustomer == actual[0].VailedForCustomer);
        }

        [TestMethod]
        public async Task GetArticlesWithCertainReturnEmptyArticleListIfNoneFound()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 0,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);

            List<Article> expected = new List<Article>();

            // act
            List<Article> actual = await articleService.GetArticleWithCertainState(article.CountryId, 1);

            // assert
            Assert.IsTrue(expected.Count == actual.Count);
        }


        [TestMethod]
        public async Task GetArticlesForCountryReturnArticlesForCountry()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 0,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);

            List<Article> expected = new List<Article>(); 
            expected.Add(await articleService.CreateArticle(article));

            // act
            List<Article> actual = await articleService.GetArticlesForCountry(article.CountryId);

            // assert
            Assert.IsTrue(expected[0].ArticleInformationCompleted == actual[0].ArticleInformationCompleted);
            Assert.IsTrue(expected[0].ArticleInformationId == actual[0].ArticleInformationId);
            Assert.IsTrue(expected[0].ArticleState == actual[0].ArticleState);
            Assert.IsTrue(expected[0].CountryId == actual[0].CountryId);
            Assert.IsTrue(expected[0].DateCreated == actual[0].DateCreated);
            Assert.IsTrue(expected[0].ErrorField == actual[0].ErrorField);
            Assert.IsTrue(expected[0].ErrorMessage == actual[0].ErrorMessage);
            Assert.IsTrue(expected[0].ErrorOwner == actual[0].ErrorOwner);
            Assert.IsTrue(expected[0].ErrorReported == actual[0].ErrorReported);
            Assert.IsTrue(expected[0].Id == actual[0].Id);
            Assert.IsTrue(expected[0].InternalArticalInformationCompleted == actual[0].InternalArticalInformationCompleted);
            Assert.IsTrue(expected[0].InternalArticleInformationId == actual[0].InternalArticleInformationId);
            Assert.IsTrue(expected[0].PurchaserId == actual[0].PurchaserId);
            Assert.IsTrue(expected[0].SupplierId == actual[0].SupplierId);
            Assert.IsTrue(expected[0].VailedForCustomer == actual[0].VailedForCustomer);
        }

        [TestMethod]
        public async Task GetArticlesForCountryReturnsEmptyListIfNoneFound()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 0,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);

            List<Article> expected = new List<Article>();

            // act
            List<Article> actual = await articleService.GetArticlesForCountry(article.CountryId);

            // assert
            Assert.IsTrue(expected.Count == actual.Count);
        }


        [TestMethod]
        public async Task GetArticlesForPurchaserReturnArticlesForPurchaser()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 0,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);

            List<Article> expected = new List<Article>();
            expected.Add(await articleService.CreateArticle(article));

            // act
            List<Article> actual = await articleService.GetArticlesForPurchaser(article.PurchaserId);

            // assert
            Assert.IsTrue(expected[0].ArticleInformationCompleted == actual[0].ArticleInformationCompleted);
            Assert.IsTrue(expected[0].ArticleInformationId == actual[0].ArticleInformationId);
            Assert.IsTrue(expected[0].ArticleState == actual[0].ArticleState);
            Assert.IsTrue(expected[0].CountryId == actual[0].CountryId);
            Assert.IsTrue(expected[0].DateCreated == actual[0].DateCreated);
            Assert.IsTrue(expected[0].ErrorField == actual[0].ErrorField);
            Assert.IsTrue(expected[0].ErrorMessage == actual[0].ErrorMessage);
            Assert.IsTrue(expected[0].ErrorOwner == actual[0].ErrorOwner);
            Assert.IsTrue(expected[0].ErrorReported == actual[0].ErrorReported);
            Assert.IsTrue(expected[0].Id == actual[0].Id);
            Assert.IsTrue(expected[0].InternalArticalInformationCompleted == actual[0].InternalArticalInformationCompleted);
            Assert.IsTrue(expected[0].InternalArticleInformationId == actual[0].InternalArticleInformationId);
            Assert.IsTrue(expected[0].PurchaserId == actual[0].PurchaserId);
            Assert.IsTrue(expected[0].SupplierId == actual[0].SupplierId);
            Assert.IsTrue(expected[0].VailedForCustomer == actual[0].VailedForCustomer);
        }

        [TestMethod]
        public async Task GetArticlesForPurchaserReturnsEmptyListIfNoneFound()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 0,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);

            List<Article> expected = new List<Article>();

            // act
            List<Article> actual = await articleService.GetArticlesForPurchaser(article.PurchaserId);

            // assert
            Assert.IsTrue(expected.Count == actual.Count);
        }

        [TestMethod]
        public async Task GetArticlesForSupplierReturnArticlesForSupplier()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);
            SupplierService supplierService = new SupplierService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            await supplierService.CreateSupplier(supplier);

            List<Article> expected = new List<Article>();
            expected.Add(await articleService.CreateArticle(article));

            // act
            List<Article> actual = await articleService.GetArticlesForSupplier(article.SupplierId);

            // assert
            Assert.IsTrue(expected[0].ArticleInformationCompleted == actual[0].ArticleInformationCompleted);
            Assert.IsTrue(expected[0].ArticleInformationId == actual[0].ArticleInformationId);
            Assert.IsTrue(expected[0].ArticleState == actual[0].ArticleState);
            Assert.IsTrue(expected[0].CountryId == actual[0].CountryId);
            Assert.IsTrue(expected[0].DateCreated == actual[0].DateCreated);
            Assert.IsTrue(expected[0].ErrorField == actual[0].ErrorField);
            Assert.IsTrue(expected[0].ErrorMessage == actual[0].ErrorMessage);
            Assert.IsTrue(expected[0].ErrorOwner == actual[0].ErrorOwner);
            Assert.IsTrue(expected[0].ErrorReported == actual[0].ErrorReported);
            Assert.IsTrue(expected[0].Id == actual[0].Id);
            Assert.IsTrue(expected[0].InternalArticalInformationCompleted == actual[0].InternalArticalInformationCompleted);
            Assert.IsTrue(expected[0].InternalArticleInformationId == actual[0].InternalArticleInformationId);
            Assert.IsTrue(expected[0].PurchaserId == actual[0].PurchaserId);
            Assert.IsTrue(expected[0].SupplierId == actual[0].SupplierId);
            Assert.IsTrue(expected[0].VailedForCustomer == actual[0].VailedForCustomer);
        }

        [TestMethod]
        public async Task GetArticlesForSupplierReturnsEmptyListIfNoneFound()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);
            SupplierService supplierService = new SupplierService(_client);


            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            await supplierService.CreateSupplier(supplier);


            List<Article> expected = new List<Article>();

            // act
            List<Article> actual = await articleService.GetArticlesForPurchaser(article.SupplierId);

            // assert
            Assert.IsTrue(expected.Count == actual.Count);
        }

        [TestMethod]
        public async Task GetArticleReturnsAllArticles()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);
            SupplierService supplierService = new SupplierService(_client);


            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            await supplierService.CreateSupplier(supplier);

            List<Article> expected = new List<Article>();
            expected.Add(await articleService.CreateArticle(article));

            // act
            List<Article> actual = await articleService.GetArticles();

            // assert
            Assert.IsTrue(expected[0].ArticleInformationCompleted == actual[0].ArticleInformationCompleted);
            Assert.IsTrue(expected[0].ArticleInformationId == actual[0].ArticleInformationId);
            Assert.IsTrue(expected[0].ArticleState == actual[0].ArticleState);
            Assert.IsTrue(expected[0].CountryId == actual[0].CountryId);
            Assert.IsTrue(expected[0].DateCreated == actual[0].DateCreated);
            Assert.IsTrue(expected[0].ErrorField == actual[0].ErrorField);
            Assert.IsTrue(expected[0].ErrorMessage == actual[0].ErrorMessage);
            Assert.IsTrue(expected[0].ErrorOwner == actual[0].ErrorOwner);
            Assert.IsTrue(expected[0].ErrorReported == actual[0].ErrorReported);
            Assert.IsTrue(expected[0].Id == actual[0].Id);
            Assert.IsTrue(expected[0].InternalArticalInformationCompleted == actual[0].InternalArticalInformationCompleted);
            Assert.IsTrue(expected[0].InternalArticleInformationId == actual[0].InternalArticleInformationId);
            Assert.IsTrue(expected[0].PurchaserId == actual[0].PurchaserId);
            Assert.IsTrue(expected[0].SupplierId == actual[0].SupplierId);
            Assert.IsTrue(expected[0].VailedForCustomer == actual[0].VailedForCustomer);
        }

        [TestMethod]
        public async Task GetArticlesReturnsEmptyListIfNoneExist()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);
            SupplierService supplierService = new SupplierService(_client);


            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            await supplierService.CreateSupplier(supplier);


            List<Article> expected = new List<Article>();

            // act
            List<Article> actual = await articleService.GetArticles();

            // assert
            Assert.IsTrue(expected.Count == actual.Count);
        }

        [TestMethod]
        public async Task GetArticleWithInformationReturnTheArticle()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);
            SupplierService supplierService = new SupplierService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            await supplierService.CreateSupplier(supplier);
            Article expected = await articleService.CreateArticle(article);

            // act
            Article actual = await articleService.GetArticleWithInformation(expected.ArticleInformationId);

            // assert
            Assert.IsTrue(expected.ArticleInformationCompleted == actual.ArticleInformationCompleted);
            Assert.IsTrue(expected.ArticleInformationId == actual.ArticleInformationId);
            Assert.IsTrue(expected.ArticleState == actual.ArticleState);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.DateCreated == actual.DateCreated);
            Assert.IsTrue(expected.ErrorField == actual.ErrorField);
            Assert.IsTrue(expected.ErrorMessage == actual.ErrorMessage);
            Assert.IsTrue(expected.ErrorOwner == actual.ErrorOwner);
            Assert.IsTrue(expected.ErrorReported == actual.ErrorReported);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.InternalArticalInformationCompleted == actual.InternalArticalInformationCompleted);
            Assert.IsTrue(expected.InternalArticleInformationId == actual.InternalArticleInformationId);
            Assert.IsTrue(expected.PurchaserId == actual.PurchaserId);
            Assert.IsTrue(expected.SupplierId == actual.SupplierId);
            Assert.IsTrue(expected.VailedForCustomer == actual.VailedForCustomer);
        }

        [TestMethod]
        public async Task GetArticleWithInformationReturnsNewArticleIfItDoesNotExist()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);

            Article expected = new Article();

            // act
            Article actual = await articleService.GetArticleWithInformation(1);

            // assert
            Assert.IsTrue(expected.ArticleInformationCompleted == actual.ArticleInformationCompleted);
            Assert.IsTrue(expected.ArticleInformationId == actual.ArticleInformationId);
            Assert.IsTrue(expected.ArticleState == actual.ArticleState);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.ErrorField == actual.ErrorField);
            Assert.IsTrue(expected.ErrorMessage == actual.ErrorMessage);
            Assert.IsTrue(expected.ErrorOwner == actual.ErrorOwner);
            Assert.IsTrue(expected.ErrorReported == actual.ErrorReported);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.InternalArticalInformationCompleted == actual.InternalArticalInformationCompleted);
            Assert.IsTrue(expected.InternalArticleInformationId == actual.InternalArticleInformationId);
            Assert.IsTrue(expected.PurchaserId == actual.PurchaserId);
            Assert.IsTrue(expected.SupplierId == actual.SupplierId);
            Assert.IsTrue(expected.VailedForCustomer == actual.VailedForCustomer);
        }

        [TestMethod]
        public async Task GetArticleReturnsArticle()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);
            SupplierService supplierService = new SupplierService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            await supplierService.CreateSupplier(supplier);
            Article expected = await articleService.CreateArticle(article);

            // act
            Article actual = await articleService.GetArticle(expected.Id);

            // assert
            Assert.IsTrue(expected.ArticleInformationCompleted == actual.ArticleInformationCompleted);
            Assert.IsTrue(expected.ArticleInformationId == actual.ArticleInformationId);
            Assert.IsTrue(expected.ArticleState == actual.ArticleState);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.DateCreated == actual.DateCreated);
            Assert.IsTrue(expected.ErrorField == actual.ErrorField);
            Assert.IsTrue(expected.ErrorMessage == actual.ErrorMessage);
            Assert.IsTrue(expected.ErrorOwner == actual.ErrorOwner);
            Assert.IsTrue(expected.ErrorReported == actual.ErrorReported);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.InternalArticalInformationCompleted == actual.InternalArticalInformationCompleted);
            Assert.IsTrue(expected.InternalArticleInformationId == actual.InternalArticleInformationId);
            Assert.IsTrue(expected.PurchaserId == actual.PurchaserId);
            Assert.IsTrue(expected.SupplierId == actual.SupplierId);
            Assert.IsTrue(expected.VailedForCustomer == actual.VailedForCustomer);
        }

        [TestMethod]
        public async Task GetArticleReturnsNewArticleIfItDoesNotExist()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);

            Article expected = new Article();

            // act
            Article actual = await articleService.GetArticle(1);

            // assert
            Assert.IsTrue(expected.ArticleInformationCompleted == actual.ArticleInformationCompleted);
            Assert.IsTrue(expected.ArticleInformationId == actual.ArticleInformationId);
            Assert.IsTrue(expected.ArticleState == actual.ArticleState);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.ErrorField == actual.ErrorField);
            Assert.IsTrue(expected.ErrorMessage == actual.ErrorMessage);
            Assert.IsTrue(expected.ErrorOwner == actual.ErrorOwner);
            Assert.IsTrue(expected.ErrorReported == actual.ErrorReported);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.InternalArticalInformationCompleted == actual.InternalArticalInformationCompleted);
            Assert.IsTrue(expected.InternalArticleInformationId == actual.InternalArticleInformationId);
            Assert.IsTrue(expected.PurchaserId == actual.PurchaserId);
            Assert.IsTrue(expected.SupplierId == actual.SupplierId);
            Assert.IsTrue(expected.VailedForCustomer == actual.VailedForCustomer);
        }

        [TestMethod]
        public async Task UpdateArticleUpdateTheGivenArticle()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);
            SupplierService supplierService = new SupplierService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            await supplierService.CreateSupplier(supplier);
            
            Article expected = await articleService.CreateArticle(article);
            expected.PurchaserId = 2;

            // act
            await articleService.UpdateArticle(expected.Id, expected);
            Article actual = await articleService.GetArticle(expected.Id);

            // assert
            Assert.IsTrue(expected.ArticleInformationCompleted == actual.ArticleInformationCompleted);
            Assert.IsTrue(expected.ArticleInformationId == actual.ArticleInformationId);
            Assert.IsTrue(expected.ArticleState == actual.ArticleState);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.DateCreated == actual.DateCreated);
            Assert.IsTrue(expected.ErrorField == actual.ErrorField);
            Assert.IsTrue(expected.ErrorMessage == actual.ErrorMessage);
            Assert.IsTrue(expected.ErrorOwner == actual.ErrorOwner);
            Assert.IsTrue(expected.ErrorReported == actual.ErrorReported);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.InternalArticalInformationCompleted == actual.InternalArticalInformationCompleted);
            Assert.IsTrue(expected.InternalArticleInformationId == actual.InternalArticleInformationId);
            Assert.IsTrue(expected.PurchaserId == actual.PurchaserId);
            Assert.IsTrue(expected.SupplierId == actual.SupplierId);
            Assert.IsTrue(expected.VailedForCustomer == actual.VailedForCustomer);
        }

        [TestMethod]
        public async Task UpdateArticleReturnsNotFoundIfItDoesNotExist()
        {
            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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
            var result = await _client.PutAsJsonAsync($"/api/purchasers/{article.Id}", article);


            // assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task UpdateArticleReturnsBadResultIfArticleAndIdDoNotMatch()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);
            SupplierService supplierService = new SupplierService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            await supplierService.CreateSupplier(supplier);

            Article createArticle = await articleService.CreateArticle(article);

            // act
            var result = await _client.PutAsJsonAsync($"/api/purchasers/{2}", createArticle);

            // assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task DeleteArticleDeletesTheArticleIfItExists()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            PurchaserService purchaserService = new PurchaserService(_client);
            CountryService countryService = new CountryService(_client);
            SupplierService supplierService = new SupplierService(_client);

            Article article = new Article()
            {
                Id = 0,
                PurchaserId = 1,
                CountryId = 1,
                SupplierId = 1,
                ArticleInformationId = 0,
                InternalArticleInformationId = 0,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
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

            await countryService.CreateCountry(country);
            await purchaserService.CreatePurchaser(purchaser);
            await supplierService.CreateSupplier(supplier);

            Article createdArticle = await articleService.CreateArticle(article);
            await articleService.DeleteArticle(createdArticle.Id);

            // act
            Article actual = await articleService.GetArticle(createdArticle.Id);
            Article expected = new Article();

            // assert
            Assert.IsNotNull(createdArticle);
            Assert.IsTrue(expected.ArticleInformationCompleted == actual.ArticleInformationCompleted);
            Assert.IsTrue(expected.ArticleInformationId == actual.ArticleInformationId);
            Assert.IsTrue(expected.ArticleState == actual.ArticleState);
            Assert.IsTrue(expected.CountryId == actual.CountryId);
            Assert.IsTrue(expected.ErrorField == actual.ErrorField);
            Assert.IsTrue(expected.ErrorMessage == actual.ErrorMessage);
            Assert.IsTrue(expected.ErrorOwner == actual.ErrorOwner);
            Assert.IsTrue(expected.ErrorReported == actual.ErrorReported);
            Assert.IsTrue(expected.Id == actual.Id);
            Assert.IsTrue(expected.InternalArticalInformationCompleted == actual.InternalArticalInformationCompleted);
            Assert.IsTrue(expected.InternalArticleInformationId == actual.InternalArticleInformationId);
            Assert.IsTrue(expected.PurchaserId == actual.PurchaserId);
            Assert.IsTrue(expected.SupplierId == actual.SupplierId);
            Assert.IsTrue(expected.VailedForCustomer == actual.VailedForCustomer);
        }

        [TestMethod]
        public async Task DeleteArticleReturnsNotFoundIfArticleDoesNotExists()
        {
            // act
            var result = await _client.DeleteAsync($"/api/articles/{1}");

            // assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
