using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartsTrader.ClientTools.Api.Entities;
using PartsTrader.ClientTools.Integration;
using System.Collections.Generic;
using System.Linq;

namespace PartsTrader.ClientTools.Tests
{
    [TestClass]
    public class ClientToolsTests
    {
        private PartsTraderPartsService _service;

        public ClientToolsTests()
        {
            _service = new PartsTraderPartsService();
        }

        [TestMethod]
        public void ShouldHaveItemsExclusionList()
        {
            var value = 0;
            PartCatalogue catalogue = new PartCatalogue(_service);

            IEnumerable<PartSummary> result = catalogue.GetCompatibleParts("1111-Invoice");

            Assert.AreEqual(value, result.Count());
        }

        [TestMethod]
        public void ShouldNotHaveItemsExclusionList()
        {
            var value = 1;
            PartCatalogue catalogue = new PartCatalogue(_service);
            IEnumerable<PartSummary> result = catalogue.GetCompatibleParts("1234-1234abcd");

            Assert.AreEqual(value, result.Count());
        }
        [TestMethod]
        public void ShouldNotHaveItemsInDatabase()
        {
            var value = 0;
            PartCatalogue catalogue = new PartCatalogue(_service);
            IEnumerable<PartSummary> result = catalogue.GetCompatibleParts("1234-1234abc");

            Assert.AreEqual(value, result.Count());
        }

    }
}
