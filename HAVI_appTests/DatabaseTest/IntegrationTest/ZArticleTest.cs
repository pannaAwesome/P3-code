﻿using HAVI_app.Models;
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
    public class ZArticleTest
    {
        private readonly HAVIdatabaseContext _context;
        private readonly HttpClient _client;

        public ZArticleTest()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            var server = new TestServer(webHostBuilder);
            _context = server.Host.Services.GetService(typeof(HAVIdatabaseContext)) as HAVIdatabaseContext;
            _client = server.CreateClient();
        }

        
        [TestMethod]
        public async Task GetArticlesWithCertainStateReturnArticles()
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

            Country countryToDelete = await countryService.CreateCountry(country);
            Purchaser purchaserToDelete = await purchaserService.CreatePurchaser(purchaser);
            Supplier supplierToDelete = await supplierService.CreateSupplier(supplier);

            article.CountryId = countryToDelete.Id;
            article.PurchaserId = purchaserToDelete.Id;
            article.SupplierId = supplierToDelete.Id;

            Article articleToDelete = await articleService.CreateArticle(article);

            int expected = 1;

            // act
            List<Article> actual = await articleService.GetArticleWithCertainState(article.CountryId, article.ArticleState);

            // assert
            Assert.IsTrue(actual.Count == expected);
            List<Country> now = await countryService.GetCountries();

            await articleService.DeleteArticle(articleToDelete.Id);
            await purchaserService.DeletePurchaserForProfile(purchaserToDelete.ProfileId);
            await supplierService.DeleteSupplier(supplierToDelete.Id);
            await countryService.DeleteCountry(countryToDelete.Id);

            await _context.DisposeAsync();
            List<Country> late = await countryService.GetCountries();

        }

        [TestMethod]
        public async Task GetArticlesWithCertainStatesReturnEmptyArticleListIfNoneFound()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);

            int expected = 0;

            // act
            List<Article> actual = await articleService.GetArticleWithCertainState(1, 0);

            // assert
            Assert.IsTrue(expected == actual.Count);
        }
        
        [TestMethod]
        public async Task GetArticlesForCountryReturnArticles()
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

            Country countryToDelete = await countryService.CreateCountry(country);
            purchaser.CountryId = countryToDelete.Id;
            Purchaser purchaserToDelete = await purchaserService.CreatePurchaser(purchaser);
            Supplier supplierToDelete = await supplierService.CreateSupplier(supplier);

            article.CountryId = countryToDelete.Id;
            article.PurchaserId = purchaserToDelete.Id;
            article.SupplierId = supplierToDelete.Id;

            int expected = 1;

            Article articleToDelete = await articleService.CreateArticle(article);
            
            // act
            List<Article> actual = await articleService.GetArticlesForCountry(article.CountryId);

            // assert
            Assert.IsTrue(expected == actual.Count);
                        List<Country> now = await countryService.GetCountries();

            await articleService.DeleteArticle(articleToDelete.Id);
            await purchaserService.DeletePurchaserForProfile(purchaserToDelete.ProfileId);
            await supplierService.DeleteSupplier(supplierToDelete.Id);
            await countryService.DeleteCountry(countryToDelete.Id);
            await _context.DisposeAsync();
            List<Country> late = await countryService.GetCountries();

        }

        [TestMethod]
        public async Task GetArticlesForCountryReturnsEmptyListIfNoneFound()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);

            int expected = 0;

            // act
            List<Article> actual = await articleService.GetArticlesForCountry(1);

            // assert
            Assert.IsTrue(expected == actual.Count);
        }
        
        [TestMethod]
        public async Task GetArticlesForPurchaserReturnArticles()
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

            Supplier supplierToDelete = await supplierService.CreateSupplier(supplier);
            Country countryToDelete = await countryService.CreateCountry(country);
            purchaser.CountryId = countryToDelete.Id;
            Purchaser purchaserToDelete = await purchaserService.CreatePurchaser(purchaser);

            article.CountryId = countryToDelete.Id;
            article.PurchaserId = purchaserToDelete.Id;
            article.SupplierId = supplierToDelete.Id;

            Article articleToDelete = await articleService.CreateArticle(article);

            int expected = 1;

            // act
            List<Article> actual = await articleService.GetArticlesForPurchaser(article.PurchaserId);

            // assert
            Assert.IsTrue(expected == actual.Count);
                        List<Country> now = await countryService.GetCountries();

            await articleService.DeleteArticle(articleToDelete.Id);
            await purchaserService.DeletePurchaserForProfile(purchaserToDelete.ProfileId);
            await supplierService.DeleteSupplier(supplierToDelete.Id);
            await countryService.DeleteCountry(countryToDelete.Id);
            await _context.DisposeAsync();
                        List<Country> late = await countryService.GetCountries();

        }

        [TestMethod]
        public async Task GetArticlesForPurchaserReturnsEmptyListIfNoneFound()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);

            int expected = 0;

            // act
            List<Article> actual = await articleService.GetArticlesForPurchaser(1);

            // assert
            Assert.IsTrue(expected == actual.Count);
        }

        [TestMethod]
        public async Task GetArticlesForSupplierReturnArticles()
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

            Country countryToDelete = await countryService.CreateCountry(country);
            purchaser.CountryId = countryToDelete.Id;
            Purchaser purchaserToDelete = await purchaserService.CreatePurchaser(purchaser);
            Supplier supplierToDelete = await supplierService.CreateSupplier(supplier);
            article.CountryId = countryToDelete.Id;
            article.PurchaserId = purchaserToDelete.Id;
            article.SupplierId = supplierToDelete.Id;
            Article articleToDelete = await articleService.CreateArticle(article);

            int expected = 1;

            // act
            List<Article> actual = await articleService.GetArticlesForSupplier(article.SupplierId);

            // assert
            Assert.IsTrue(expected == actual.Count);
                        List<Country> now = await countryService.GetCountries();

            await articleService.DeleteArticle(articleToDelete.Id);
            await purchaserService.DeletePurchaserForProfile(purchaserToDelete.ProfileId);
            await supplierService.DeleteSupplier(supplierToDelete.Id);
            await countryService.DeleteCountry(countryToDelete.Id);
            await _context.DisposeAsync();
                        List<Country> late = await countryService.GetCountries();

        }

        [TestMethod]
        public async Task GetArticlesForSupplierReturnsEmptyListIfNoneFound()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);
            int expected = 0;

            // act
            List<Article> actual = await articleService.GetArticlesForPurchaser(1);

            // assert
            Assert.IsTrue(expected == actual.Count);
        }
        
        [TestMethod]
        public async Task GetArticlesReturnsAllArticles()
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
                    Usertype = 1
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

            Country countryToDelete = await countryService.CreateCountry(country);
            purchaser.CountryId = countryToDelete.Id;
            Purchaser purchaserToDelete = await purchaserService.CreatePurchaser(purchaser);
            Supplier supplierToDelete = await supplierService.CreateSupplier(supplier);

            article.CountryId = countryToDelete.Id;
            article.PurchaserId = purchaserToDelete.Id;
            article.SupplierId = supplierToDelete.Id;

            Article articleToDelete = await articleService.CreateArticle(article);

            int expected = 1;

            // act
            List<Article> actual = await articleService.GetArticles();

            // assert
            Assert.IsTrue(expected == actual.Count);

            await articleService.DeleteArticle(articleToDelete.Id);
            await purchaserService.DeletePurchaserForProfile(purchaserToDelete.ProfileId);
            await supplierService.DeleteSupplier(supplierToDelete.Id);
            await countryService.DeleteCountry(countryToDelete.Id);
            await _context.DisposeAsync();
        }

        [TestMethod]
        public async Task GetArticlesReturnsEmptyListIfNoneExist()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);

            int expected = 0;

            // act
            List<Article> actual = await articleService.GetArticles();

            // assert
            Assert.IsTrue(expected == actual.Count);
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

            Country countryToDelete = await countryService.CreateCountry(country);
            purchaser.CountryId = countryToDelete.Id;
            Purchaser purchaserToDelete = await purchaserService.CreatePurchaser(purchaser);
            Supplier supplierToDelete = await supplierService.CreateSupplier(supplier);
            article.CountryId = countryToDelete.Id;
            article.PurchaserId = purchaserToDelete.Id;
            article.SupplierId = supplierToDelete.Id;
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
                        List<Country> now = await countryService.GetCountries();

            await articleService.DeleteArticle(expected.Id);
            await purchaserService.DeletePurchaserForProfile(purchaserToDelete.ProfileId);
            await supplierService.DeleteSupplier(supplierToDelete.Id);
            await countryService.DeleteCountry(countryToDelete.Id);

            await _context.DisposeAsync();
                        List<Country> late = await countryService.GetCountries();

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

            country = await countryService.CreateCountry(country);
            purchaser.CountryId = country.Id;
            purchaser = await purchaserService.CreatePurchaser(purchaser);
            supplier = await supplierService.CreateSupplier(supplier);

            article.CountryId = country.Id;
            article.PurchaserId = purchaser.Id;
            article.SupplierId = supplier.Id;
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
                        List<Country> now = await countryService.GetCountries();

            await articleService.DeleteArticle(actual.Id);
            await purchaserService.DeletePurchaserForProfile(purchaser.ProfileId);
            await supplierService.DeleteSupplier(supplier.Id);
            await countryService.DeleteCountry(country.Id);
            await _context.DisposeAsync();
                        List<Country> late = await countryService.GetCountries();

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

            Country countryToDelete = await countryService.CreateCountry(country);
            purchaser.CountryId = countryToDelete.Id;
            Purchaser purchaserToDelete = await purchaserService.CreatePurchaser(purchaser);
            Supplier supplierToDelete = await supplierService.CreateSupplier(supplier);

            article.CountryId = countryToDelete.Id;
            article.SupplierId = supplierToDelete.Id;
            article.PurchaserId = purchaserToDelete.Id;
            Article expected = await articleService.CreateArticle(article);
            expected.ArticleState = 3;

            // act
            await articleService.UpdateArticle(expected.Id, expected);
            Article actual = await articleService.GetArticle(expected.Id);            

            // assert
            Assert.IsTrue(expected.ArticleState == actual.ArticleState);
                        List<Country> now = await countryService.GetCountries();

            await articleService.DeleteArticle(expected.Id);
            await purchaserService.DeletePurchaserForProfile(purchaserToDelete.ProfileId);
            await supplierService.DeleteSupplier(supplierToDelete.Id);
            await countryService.DeleteCountry(countryToDelete.Id);
            await _context.DisposeAsync();
                        List<Country> late = await countryService.GetCountries();

        }

        [TestMethod]
        public async Task UpdateArticleReturnsNotFoundIfItDoesNotExist()
        {
            // act
            var result = await _client.DeleteAsync($"/api/articles/{1}");

            // assert
            Assert.IsTrue(result.StatusCode == HttpStatusCode.NotFound);
        }
        
        [TestMethod]
        public async Task UpdateArticleReturnsBadResultIfArticleAndIdDoNotMatch()
        {
            // arrange
            ArticleService articleService = new ArticleService(_client);

            Article createArticle = new Article();
            int id = createArticle.Id + 1;
            // act
            var result = await _client.PutAsJsonAsync($"/api/purchasers/{id}", createArticle);

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

            country = await countryService.CreateCountry(country);
            purchaser.CountryId = country.Id;
            purchaser = await purchaserService.CreatePurchaser(purchaser);
            supplier = await supplierService.CreateSupplier(supplier);

            article.CountryId = country.Id;
            article.PurchaserId = purchaser.Id;
            article.SupplierId = supplier.Id;
            Article createdArticle = await articleService.CreateArticle(article);
            Article expected = new Article();

            // act
            await articleService.DeleteArticle(createdArticle.Id);
            Article actual = await articleService.GetArticle(createdArticle.Id);

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
                        List<Country> now = await countryService.GetCountries();

            await purchaserService.DeletePurchaserForProfile(purchaser.ProfileId);
            await supplierService.DeleteSupplier(supplier.Id);
            await countryService.DeleteCountry(country.Id);
            await _context.DisposeAsync();
                        List<Country> late = await countryService.GetCountries();

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
