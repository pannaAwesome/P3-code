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
                PurchaserId = 0,
                CountryId = 0,
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
        public async Task GetArticlesForCountry()
        {
        }

        [TestMethod]
        public async Task GetArticlesForPurchaser()
        {
        }

        [TestMethod]
        public async Task GetArticlesForSupplier()
        {
        }

        [TestMethod]
        public async Task GetArticle()
        {
        }

        [TestMethod]
        public async Task GetArticleWithInformation()
        {
        }

        [TestMethod]
        public async Task GetArticleWithInternal()
        {
        }

        [TestMethod]
        public async Task GetArticles()
        {
        }

        [TestMethod]
        public async Task UpdateArticle()
        {
        }

        [TestMethod]
        public async Task DeleteArticle()
        {
        }
    }
}
