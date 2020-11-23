using HAVI_app.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HAVI_appTests
{
    [TestClass]
    public class ValidationsTests
    {
        [TestMethod]
        public void LettersOnlyTest()
        {
            var letters = new Validation();
            Assert.IsTrue(letters.LettersOnly("Hej"));
        }

        [TestMethod]
        public void NumbersOnlyTest()
        {
            var numbers = new Validation();
            Assert.IsTrue(numbers.NumbersOnly("123"));
        }

        [TestMethod]
        public void IsEmailValidTest()
        {
            var email = new Validation();
            Assert.IsTrue(email.IsEmailValid("employee@havi.com"));
        }
        [TestMethod]
        public void IsEmailValidTestFail()
        {
            var email = new Validation();
            Assert.IsFalse(email.IsEmailValid("employee*@havi. com"));
        }

        [TestMethod]
        public void GTINValidationTest()
        {
            var gtin = new Validation();
            var test = gtin.GTINValidation("12345");
            Assert.AreEqual("00000000012345", test);
        }
    }
}
