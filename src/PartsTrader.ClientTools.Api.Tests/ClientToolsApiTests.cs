using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartsTrader.ClientTools.Api.ValueObjects;
using PartsTrader.ClientTools.Api.Exceptions;

namespace PartsTrader.ClientTools.Api.Tests
{
    [TestClass]
    public class PartCatalogueTests
    {
        [TestMethod]
        public void ShouldHaveCorrectPartIdAndPartCode()
        {
            string value = "1234-1234abcd";

            var partNumber = PartNumber.For(value);

            string result = partNumber;

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPartException),
        "123-abcd: This is not valid PartNumber!")]
        public void ShouldHaveWrongPartIdLessThan4()
        {
            var partNumber = PartNumber.For("123-abcd");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPartException),
        "1234-a23: This is not valid PartNumber!")]
        public void ShouldHaveWrongPartCodeLessThan4()
        {
            var partNumber = PartNumber.For("1234-a23");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPartException),
        "a234-abcd: This is not valid PartNumber!")]
        public void ShouldHaveWrongPartIdWithCharacters()
        {
            var partNumber = PartNumber.For("a234-abcd");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPartException),
        "a234abcd: This is not valid PartNumber!")]
        public void ShouldHaveWrongWithoutDash()
        {
            var partNumber = PartNumber.For("a234abcd");
        }

        [TestMethod]
        public void ToStringReturnsCorrectFormat()
        {
            const string value = "1234-1234abcd";

            var partNumber = PartNumber.For(value);

            Assert.AreEqual(value, partNumber.ToString());
        }

        [TestMethod]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const string value = "1234-1234abcd";

            var partNumber = PartNumber.For(value);

            string result = partNumber;

            Assert.AreEqual(value, result);
        }

        [TestMethod]
        public void ExplicitConversionFromStringSetsPartIdAndPartCode()
        {
            var partNumber = (PartNumber)"1234-1234abcd";

            Assert.AreEqual("1234", partNumber.PartId);
            Assert.AreEqual("1234abcd", partNumber.PartCode);
        }
    }
}
