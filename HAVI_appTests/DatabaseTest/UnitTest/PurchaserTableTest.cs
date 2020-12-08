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
    public class PurchaserTableTest
    {
        private HAVIdatabaseContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<HAVIdatabaseContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;

            var dbContext = new HAVIdatabaseContext(options);

            return dbContext;
        }

        [TestMethod]
        public async Task AddPurchaserToDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
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
            Purchaser result = await repository.AddPurchaser(purchaser);

            // assert
            Assert.IsTrue(result.Id > 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task DeleteExistingPurchaserTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
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
            Purchaser addedPurchaser = await repository.AddPurchaser(purchaser);

            // act
            Purchaser result = await repository.DeletePurchaserForProfile(addedPurchaser.ProfileId);

            // assert
            Assert.IsTrue(result == addedPurchaser);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task DeleteNonExistingPurchaser()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
            Purchaser purchaser = new Purchaser()
            {
                Id = 1,
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
            Purchaser result = await repository.DeletePurchaserForProfile(purchaser.ProfileId);

            // assert
            Assert.IsTrue(result == null);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task UpdateExistingPurchaserInDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
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
            Purchaser addedPurchaser = await repository.AddPurchaser(purchaser);
            addedPurchaser.Profile.Username = "hello@havi.dk";
            addedPurchaser.Profile.Password = "1234";

            // act
            Purchaser result = await repository.UpdatePurchaser(addedPurchaser);

            // assert
            Assert.IsTrue(result == addedPurchaser);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task UpdateNonExistingPurchaserInDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
            Purchaser purchaser = new Purchaser()
            {
                Id = 1,
                ProfileId = 1,
                CountryId = 0,
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            // act
            Purchaser result = await repository.UpdatePurchaser(purchaser);

            // assert
            Assert.IsTrue(result == null);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingPurchaserFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
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
            Purchaser addedPurchaser = await repository.AddPurchaser(purchaser);

            // act
            Purchaser result = await repository.GetPurchaser(addedPurchaser.Id);

            // assert
            Assert.IsTrue(result == addedPurchaser);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingPurchaserFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
            Purchaser purchaser = new Purchaser()
            {
                Id = 1,
                ProfileId = 1,
                CountryId = 0,
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            // act
            Purchaser result = await repository.GetPurchaser(purchaser.Id);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingPurchaserWithProfileFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
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
            Purchaser addedPurchaser = await repository.AddPurchaser(purchaser);

            // act
            Purchaser result = await repository.GetPurchaserForProfile(addedPurchaser.ProfileId);

            // assert
            Assert.IsTrue(result == addedPurchaser);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingPurchaserWithProfileFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
            Purchaser purchaser = new Purchaser()
            {
                Id = 1,
                ProfileId = 1,
                CountryId = 1,
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };
            // act
            Purchaser result = await repository.GetPurchaserForProfile(purchaser.ProfileId);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingPurchasersFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);
            Purchaser purchaser1 = new Purchaser()
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
            Purchaser purchaser2 = new Purchaser()
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
            Purchaser addedPurchaser1 = await repository.AddPurchaser(purchaser1);
            Purchaser addedPurchaser2 = await repository.AddPurchaser(purchaser2);

            // act
            List<Purchaser> result = (List<Purchaser>)await repository.GetPurchasers();

            // assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(addedPurchaser1));
            Assert.IsTrue(result.Contains(addedPurchaser2));

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingPurchasersFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            PurchaserRepository repository = new PurchaserRepository(dbContext);

            // act
            List<Purchaser> result = (List<Purchaser>)await repository.GetPurchasers();

            // assert
            Assert.IsTrue(result.Count == 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingPurchasersForCountryFromDatabaseTest()
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
            PurchaserRepository repository = new PurchaserRepository(dbContext);
            Purchaser purchaser1 = new Purchaser()
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
            Purchaser purchaser2 = new Purchaser()
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
            Purchaser addedPurchaser1 = await repository.AddPurchaser(purchaser1);
            Purchaser addedPurchaser2 = await repository.AddPurchaser(purchaser2);

            // act
            List<Purchaser> result = await repository.GetPurchasersForCountry(1);

            // assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(addedPurchaser1));
            Assert.IsTrue(result.Contains(addedPurchaser2));

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingPurchasersForCountryFromDatabaseTest()
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
            PurchaserRepository repository = new PurchaserRepository(dbContext);
            await countryRepository.AddCountry(country);

            // act
            List<Purchaser> result = await repository.GetPurchasersForCountry(1);

            // assert
            Assert.IsTrue(result.Count == 0);

            dbContext.Dispose();
        }
    }
}
