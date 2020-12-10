using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HAVI_app.Models;
using HAVI_app.Api.DatabaseClasses;

namespace HAVI_appTests.DatabaseTest.UnitTest
{
    [TestClass]
    public class ArticleTableTest
    {
        private HAVIdatabaseContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<HAVIdatabaseContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;

            var dbContext = new HAVIdatabaseContext(options);

            return dbContext;
        }

        [TestMethod]
        public async Task AddArticleToDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);
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

            // act
            Article result = await repository.AddArticle(article);

            // assert
            Assert.IsTrue(result.Id > 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task DeleteExistingArticleTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);
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
            Article addedArticle = await repository.AddArticle(article);

            // act
            Article result = await repository.DeleteArticleAsync(addedArticle.Id);

            // assert
            Assert.IsTrue(result == addedArticle);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task DeleteNonExistingArticle()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);
            Article article = new Article()
            {
                Id = 1,
                PurchaserId = 0,
                CountryId = 0,
                SupplierId = 0,
                ArticleInformationId = 1,
                InternalArticleInformationId = 1,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner"
            };
            // act
            Article result = await repository.DeleteArticleAsync(article.Id);

            // assert
            Assert.IsTrue(result == null);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task UpdateExistingArticleInDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);
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
                ErrorReported = 1,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner",
                ArticleInformation = new ArticleInformation(),
                InternalArticleInformation = new InternalArticleInformation()
            };
            Article addedArticle = await repository.AddArticle(article);
            addedArticle.VailedForCustomer = "Sticks and sushi";
            addedArticle.ArticleInformationCompleted = 1;
            addedArticle.InternalArticalInformationCompleted = 1;
            addedArticle.ArticleState = 1;
            addedArticle.ErrorReported = 0;
            addedArticle.ErrorField = "";
            addedArticle.ErrorMessage = "";
            addedArticle.ErrorOwner = "";

            // act
            Article result = await repository.UpdateArticle(addedArticle);

            // assert
            Assert.IsTrue(result == addedArticle);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task UpdateNonExistingArticleInDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);
            Article article = new Article()
            {
                Id = 1,
                PurchaserId = 0,
                CountryId = 0,
                SupplierId = 0,
                ArticleInformationId = 1,
                InternalArticleInformationId = 1,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner"
            };
            // act
            Article result = await repository.UpdateArticle(article);

            // assert
            Assert.IsTrue(result == null);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingArticleFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);
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
            Article addedArticle = await repository.AddArticle(article);

            // act
            Article result = await repository.GetArticle(addedArticle.Id);

            // assert
            Assert.IsTrue(result == addedArticle);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingArticleFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);
            Article article = new Article()
            {
                Id = 1,
                PurchaserId = 0,
                CountryId = 0,
                SupplierId = 0,
                ArticleInformationId = 1,
                InternalArticleInformationId = 1,
                VailedForCustomer = "Customer",
                DateCreated = DateTime.Now,
                ArticleInformationCompleted = 0,
                InternalArticalInformationCompleted = 0,
                ArticleState = 0,
                ErrorReported = 0,
                ErrorField = "Field",
                ErrorMessage = "Message",
                ErrorOwner = "Owner"
            };

            // act
            Article result = await repository.GetArticle(article.Id);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingArticlesFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository countryRepository = new CountryRepository(dbContext);
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
            PurchaserRepository purchaserRepository = new PurchaserRepository(dbContext);
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
            await countryRepository.AddCountry(country);
            await purchaserRepository.AddPurchaser(purchaser);
            ArticleRepository repository = new ArticleRepository(dbContext);
            Article article1 = new Article()
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
            Article article2 = new Article()
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
            Article addedArticle1 = await repository.AddArticle(article1);
            Article addedArticle2 = await repository.AddArticle(article2);

            // act
            List<Article> result = (List<Article>)await repository.GetArticles();

            // assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(addedArticle1));
            Assert.IsTrue(result.Contains(addedArticle2));

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingArticlesFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);

            // act
            List<Article> result = (List<Article>)await repository.GetArticles();

            // assert
            Assert.IsTrue(result.Count == 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingArticlesWithCertainStateFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository countryRepository = new CountryRepository(dbContext);
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
            PurchaserRepository purchaserRepository = new PurchaserRepository(dbContext);
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
            await countryRepository.AddCountry(country);
            await purchaserRepository.AddPurchaser(purchaser);
            ArticleRepository repository = new ArticleRepository(dbContext);
            Article article1 = new Article()
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
            Article article2 = new Article()
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
            Article addedArticle1 = await repository.AddArticle(article1);
            Article addedArticle2 = await repository.AddArticle(article2);

            // act
            List<Article> result = (List<Article>)await repository.GetArticlesWithCertainState(0, 1);

            // assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(addedArticle1));
            Assert.IsTrue(result.Contains(addedArticle2));

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingArticlesWithCertainStateFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);

            // act
            List<Article> result = (List<Article>)await repository.GetArticlesWithCertainState(0, 1);

            // assert
            Assert.IsTrue(result.Count == 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingArticlesForCountryFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository countryRepository = new CountryRepository(dbContext);
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
            PurchaserRepository purchaserRepository = new PurchaserRepository(dbContext);
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

            await countryRepository.AddCountry(country);
            await purchaserRepository.AddPurchaser(purchaser);
            ArticleRepository repository = new ArticleRepository(dbContext);
            Article article1 = new Article()
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
            Article article2 = new Article()
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
            Article addedArticle1 = await repository.AddArticle(article1);
            Article addedArticle2 = await repository.AddArticle(article2);

            // act
            List<Article> result = (List<Article>)await repository.GetArticlesForCountry(addedArticle1.CountryId);

            // assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(addedArticle1));
            Assert.IsTrue(result.Contains(addedArticle2));

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingArticlesForCountryFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);

            // act
            List<Article> result = (List<Article>)await repository.GetArticlesForCountry(1);

            // assert
            Assert.IsTrue(result.Count == 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingArticlesForSupplierFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository countryRepository = new CountryRepository(dbContext);
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
            PurchaserRepository purchaserRepository = new PurchaserRepository(dbContext);
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
            await countryRepository.AddCountry(country);
            await purchaserRepository.AddPurchaser(purchaser);
            SupplierRepository supplierRepository = new SupplierRepository(dbContext);
            Supplier supplier = new Supplier()
            {
                Id = 1,
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
            ArticleRepository repository = new ArticleRepository(dbContext);
            Article article1 = new Article()
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
            Article article2 = new Article()
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
            await supplierRepository.AddSupplier(supplier);
            Article addedArticle1 = await repository.AddArticle(article1);
            Article addedArticle2 = await repository.AddArticle(article2);

            // act
            List<Article> result = (List<Article>)await repository.GetArticlesForSupplier(1);

            // assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(addedArticle1));
            Assert.IsTrue(result.Contains(addedArticle2));

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingArticlesForSupplierFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);

            // act
            List<Article> result = (List<Article>)await repository.GetArticlesForSupplier(1);

            // assert
            Assert.IsTrue(result.Count == 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingArticlesForPurchaserFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository purchaserRepository = new PurchaserRepository(dbContext);
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
            ArticleRepository repository = new ArticleRepository(dbContext);
            Article article1 = new Article()
            {
                Id = 0,
                PurchaserId = 1,
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
            Article article2 = new Article()
            {
                Id = 0,
                PurchaserId = 1,
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
            await purchaserRepository.AddPurchaser(purchaser);
            Article addedArticle1 = await repository.AddArticle(article1);
            Article addedArticle2 = await repository.AddArticle(article2);

            // act
            List<Article> result = (List<Article>)await repository.GetArticlesForPurchaser(1);

            // assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(addedArticle1));
            Assert.IsTrue(result.Contains(addedArticle2));

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingArticlesForPurchaserFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);

            // act
            List<Article> result = (List<Article>)await repository.GetArticlesForPurchaser(1);

            // assert
            Assert.IsTrue(result.Count == 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingArticleWithInformationFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);
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
            Article addedArticle = await repository.AddArticle(article);

            // act
            Article result = await repository.GetArticleWithInformation(addedArticle.ArticleInformationId);

            // assert
            Assert.IsTrue(result == addedArticle);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingArticleWithArticleInformationFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            ArticleRepository repository = new ArticleRepository(dbContext);

            // act
            Article result = await repository.GetArticleWithInformation(1);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }
    }
}
