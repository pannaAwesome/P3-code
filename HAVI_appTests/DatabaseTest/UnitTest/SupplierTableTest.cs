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
        public void AddSupplierToDatabaseTest()
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
            var result = repository.AddSupplier(supplier);

            // assert
            Assert.IsTrue(result.Id > 0);

            dbContext.Dispose();
        }

        [TestMethod]
        public void DeleteSupplierFromDatabaseTest()
        {

        }

        [TestMethod]
        public void UpdateSupplierInDatabaseTest()
        {

        }

        [TestMethod]
        public void GetSupplierFromDatabaseTest()
        {

        }

        [TestMethod]
        public void GetSupplierWithProfileFromDatabaseTest()
        {

        }

        [TestMethod]
        public void GetSuppliersFromDatabaseTest()
        {

        }
    }
}
