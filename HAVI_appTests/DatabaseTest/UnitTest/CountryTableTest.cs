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
    public class CountryTableTest
    {
        private HAVIdatabaseContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<HAVIdatabaseContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;

            var dbContext = new HAVIdatabaseContext(options);

            return dbContext;
        }

        [TestMethod]
        public async Task AddCountryToDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            // act
            Country result = await repository.AddCountry(country);

            // assert
            Assert.IsTrue(result.Id > 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task DeleteExistingCountryTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country addedCountry = await repository.AddCountry(country);

            // act
            Country result = await repository.DeleteCountryAsync(addedCountry.Id);

            // assert
            Assert.IsTrue(result == addedCountry);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task DeleteNonExistingCountry()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            // act
            Country result = await repository.DeleteCountryAsync(country.Id);

            // assert
            Assert.IsTrue(result == null);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task UpdateExistingCountryInDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country addedCountry = await repository.AddCountry(country);
            addedCountry.CountryName = "Denmark";
            addedCountry.CountryCode = "DK";
            addedCountry.Profile.Username = "DKAdmin";
            addedCountry.Profile.Password = "4321";

            // act
            Country result = await repository.UpdateCountry(addedCountry);

            // assert
            Assert.IsTrue(result == addedCountry);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task UpdateNonExistingCountryInDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 1,
                ProfileId = 1,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            // act
            Country result = await repository.UpdateCountry(country);

            // assert
            Assert.IsTrue(result == null);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingCountryFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 1,
                ProfileId = 1,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country addedCountry = await repository.AddCountry(country);

            // act
            Country result = await repository.GetCountry(addedCountry.Id);

            // assert
            Assert.IsTrue(result == addedCountry);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingCountryFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 1,
                ProfileId = 1,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            // act
            Country result = await repository.GetCountry(country.Id);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingCountryWithProfileFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country addedCountry = await repository.AddCountry(country);

            // act
            Country result = await repository.GetCountryWithProfile(addedCountry.ProfileId);

            // assert
            Assert.IsTrue(result == addedCountry);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingCountryWithProfileFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 1,
                ProfileId = 1,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            // act
            Country result = await repository.GetCountryWithProfile(country.ProfileId);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingCountriesFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country1 = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country country2 = new Country()
            {
                Id = 0,
                ProfileId = 0,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 0,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country addedCountry1 = await repository.AddCountry(country1);
            Country addedCountry2 = await repository.AddCountry(country2);

            // act
            List<Country> result = (List<Country>)await repository.GetCountries();

            // assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(addedCountry1));
            Assert.IsTrue(result.Contains(addedCountry2));

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingCountriesFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);

            // act
            List<Country> result = (List<Country>)await repository.GetCountries();

            // assert
            Assert.IsTrue(result.Count == 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingCountryWithNameFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 1,
                ProfileId = 1,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country addedCountry = await repository.AddCountry(country);

            // act
            Country result = await repository.GetCountryWithName(addedCountry.CountryName);

            // assert
            Assert.IsTrue(result == addedCountry);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingCountryWithNameFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 1,
                ProfileId = 1,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            // act
            Country result = await repository.GetCountryWithName(country.CountryName);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingCountryWithEverythingFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 1,
                ProfileId = 1,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };
            Country addedCountry = await repository.AddCountry(country);

            // act
            Country result = await repository.GetCountryEverything(addedCountry.Id);

            // assert
            Assert.IsTrue(result == addedCountry);
            Assert.IsTrue(result.Profile != null);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingCountryWithEverythingFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            CountryRepository repository = new CountryRepository(dbContext);
            Country country = new Country()
            {
                Id = 1,
                ProfileId = 1,
                CountryCode = "Code",
                CountryName = "Name",
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Username",
                    Password = "1234",
                    Usertype = 0
                }
            };

            // act
            Country result = await repository.GetCountryEverything(country.Id);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }
    }
}
