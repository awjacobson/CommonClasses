using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonClasses.Tests.PhoneNumberTests
{
    [TestClass]
    public class ParseShould
    {
        [DataTestMethod]
        [DataRow("1(777)888-9999", new[] { 1, 777, 888, 9999 })]
        [DataRow("1(777) 888-9999", new[] { 1, 777, 888, 9999 })]
        [DataRow("1(777)888 9999", new[] { 1, 777, 888, 9999 })]
        [DataRow("1(777) 888 9999", new[] { 1, 777, 888, 9999 })]
        [DataRow("1 777 888 9999", new [] { 1, 777, 888, 9999 })]
        public void HandleCountryCodes(string input, int[] expected)
        {
            // Act
            var phoneNumber = PhoneNumber.Parse(input);

            // Assert
            Assert.AreEqual(expected[0], phoneNumber.CountryCode.Value);
            Assert.AreEqual(expected[1], phoneNumber.AreaCode.Value);
            Assert.AreEqual(expected[2], phoneNumber.Prefix.Value);
            Assert.AreEqual(expected[3], phoneNumber.LineNumber.Value);
        }

        [DataTestMethod]
        [DataRow("(777)888-9999", new[] { 777, 888, 9999 })]
        [DataRow("(777) 888-9999", new[] { 777, 888, 9999 })]
        [DataRow("(777)888 9999", new[] { 777, 888, 9999 })]
        [DataRow("(777) 888 9999", new[] { 777, 888, 9999 })]
        [DataRow("777-888-9999", new[] { 777, 888, 9999 })]
        [DataRow("777 888 9999", new[] { 777, 888, 9999 })]
        [DataRow("7778889999", new[] { 777, 888, 9999 })]
        public void HandleNoCountryCodes(string input, int[] expected)
        {
            // Act
            var phoneNumber = PhoneNumber.Parse(input);

            // Assert
            Assert.IsNull(phoneNumber.CountryCode);
            Assert.AreEqual(expected[0], phoneNumber.AreaCode.Value);
            Assert.AreEqual(expected[1], phoneNumber.Prefix.Value);
            Assert.AreEqual(expected[2], phoneNumber.LineNumber.Value);
        }

        [DataTestMethod]
        [DataRow("1")]
        [DataRow("12")]
        [DataRow("123 1234")]
        public void ReturnNull(string input)
        {
            // Act
            var phoneNumber = PhoneNumber.Parse(input);

            // Assert
            Assert.IsNull(phoneNumber);
        }
    }
}
