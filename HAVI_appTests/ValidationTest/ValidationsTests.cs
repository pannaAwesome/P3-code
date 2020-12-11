using HAVI_app.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HAVI_appTests.ValidationsTest
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
            Assert.IsTrue(numbers.DoubleOnly(11.323));
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
            var test = gtin.GTINValidation("11111111111111");
            Assert.AreEqual(true, test);
        }

        [TestMethod]
        public void GTINValidationTestFail()
        {
            var gtin = new Validation();
            var test = gtin.GTINValidation("1234");
            Assert.AreEqual(false, test);
        }

        [TestMethod]
        public void MustNotBeZeroOrNegativeNumberTestSucces()
        {
            // arrange
            int greatherThanZero = 1;
            Validation validate = new Validation();

            // act
            bool test = validate.MustNotBeZeroOrNegativeNumbere(greatherThanZero);

            // assert
            Assert.IsTrue(test);
        }

        [TestMethod]
        public void MustNotBeZeroOrNegativeNumberTestFail()
        {
            // arrange
            int isNegative = -1;
            int isZero = 0;
            Validation validate = new Validation();

            // act
            bool test1 = validate.MustNotBeZeroOrNegativeNumbere(isZero);
            bool test2 = validate.MustNotBeZeroOrNegativeNumbere(isNegative);

            // assert
            Assert.IsFalse(test1);
            Assert.IsFalse(test2);
        }
    }
}
