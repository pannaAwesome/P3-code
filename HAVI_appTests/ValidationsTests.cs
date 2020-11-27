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
            Assert.IsTrue(letters.LettersOnly("McDonalds"));
        }

        [TestMethod]
        public void NumbersLettersDashOnlyTest()
        {
            var numbers = new Validation();
            Assert.IsTrue(numbers.NumbersLettersDashOnly("123-12s"));
        }

        [TestMethod]
        public void OnlyDoubleTest()
        {
            var numbers = new Validation();
            Assert.IsTrue(numbers.DoubleOnly("11.323"));
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
            var test = gtin.GTINValidation(1234);
            Assert.AreEqual(00000000001234, test);
        }
    }
}
