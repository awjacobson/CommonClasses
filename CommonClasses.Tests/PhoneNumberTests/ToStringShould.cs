using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonClasses.Tests.PhoneNumberTests
{
    [TestClass]
    public class ToStringShould
    {
        [DataTestMethod]
        [DataRow(new[] { 1, 777, 888, 9999 }, "(777) 888-9999")]
        [DataRow(new[] { 777, 888, 9999 }, "(777) 888-9999")]
        public void ReturnFormattedPhoneNumber(int[] input, string expected)
        {
            // Arrange
            PhoneNumber phoneNumber = null;
            if (input.Length == 4)
            {
                phoneNumber = new PhoneNumber
                {
                    CountryCode = input[0],
                    AreaCode = input[1],
                    Prefix = input[2],
                    LineNumber = input[3]
                };
            }
            else
            {
                phoneNumber = new PhoneNumber
                {
                    AreaCode = input[0],
                    Prefix = input[1],
                    LineNumber = input[2]
                };
            }

            // Act
            var actual = phoneNumber.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
