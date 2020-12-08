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
    public class SupplierTableTest
    {
        private HAVIdatabaseContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<HAVIdatabaseContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString("N")).Options;

            var dbContext = new HAVIdatabaseContext(options);

            return dbContext;
        }

        [TestMethod]
        public async Task AddSupplierToDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
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
            Supplier result = await repository.AddSupplier(supplier);

            // assert
            Assert.IsTrue(result.Id > 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task DeleteExistingSupplierTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
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
            Supplier addedSupplier = await repository.AddSupplier(supplier);

            // act
            Supplier result = await repository.DeleteSupplierAsync(addedSupplier.Id);

            // assert
            Assert.IsTrue(result == addedSupplier);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task DeleteNonExistingSupplier()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
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

            // act
            Supplier result = await repository.DeleteSupplierAsync(supplier.Id);

            // assert
            Assert.IsTrue(result == null);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task UpdateExistingSupplierInDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
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
            Supplier addedSupplier = await repository.AddSupplier(supplier);
            addedSupplier.CompanyLocation = "Denmark";
            addedSupplier.CompanyName = "Monsters Inc.";
            addedSupplier.FreightResponsibility = "CIP";
            addedSupplier.PalletExchange = 0;

            // act
            Supplier result = await repository.UpdateSupplier(addedSupplier);

            // assert
            Assert.IsTrue(result == addedSupplier);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task UpdateNonExistingSupplierInDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
            Supplier supplier = new Supplier()
            {
                Id = 1,
                ProfileId = 1,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            // act
            Supplier result = await repository.UpdateSupplier(supplier);

            // assert
            Assert.IsTrue(result == null);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingSupplierFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
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
            Supplier addedSupplier = await repository.AddSupplier(supplier);

            // act
            Supplier result = await repository.GetSupplier(addedSupplier.Id);

            // assert
            Assert.IsTrue(result == addedSupplier);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingSupplierFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
            Supplier supplier = new Supplier()
            {
                Id = 1,
                ProfileId = 1,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };

            // act
            Supplier result = await repository.GetSupplier(supplier.Id);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingSupplierWithProfileFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
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
            Supplier addedSupplier = await repository.AddSupplier(supplier);

            // act
            Supplier result = await repository.GetSupplierWithProfile(addedSupplier.ProfileId);

            // assert
            Assert.IsTrue(result == addedSupplier);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingSupplierWithProfileFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
            Supplier supplier = new Supplier()
            {
                Id = 1,
                ProfileId = 1,
                CompanyName = "Name",
                CompanyLocation = "Location",
                FreightResponsibility = "EXW",
                PalletExchange = 1,
                Profile = new Profile()
                {
                    Id = 1,
                    Username = "Email",
                    Password = "1234",
                    Usertype = 2
                }
            };
            // act
            Supplier result = await repository.GetSupplierWithProfile(supplier.ProfileId);

            // assert
            Assert.IsTrue(result == default);

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetExistingSuppliersFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);
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
            Supplier addedSupplier1 = await repository.AddSupplier(supplier1);
            Supplier addedSupplier2 = await repository.AddSupplier(supplier2);

            // act
            List<Supplier> result = await repository.GetSuppliers();

            // assert
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(addedSupplier1));
            Assert.IsTrue(result.Contains(addedSupplier2));

            dbContext.Dispose();
        }

        [TestMethod]
        public async Task GetNonExistingSuppliersFromDatabaseTest()
        {
            // arrange
            HAVIdatabaseContext dbContext = CreateDbContext();
            SupplierRepository repository = new SupplierRepository(dbContext);

            // act
            List<Supplier> result = await repository.GetSuppliers();

            // assert
            Assert.IsTrue(result.Count == 0);

            dbContext.Dispose();
        }
    }
}
