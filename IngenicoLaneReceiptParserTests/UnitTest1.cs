using IngenicoLaneReceiptParser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IngenicoLaneReceiptParserTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParseLane3000()
        {
            IngenicoLaneReceipt? ingenicoLaneReceipt = new(IngenicoLaneReceipt.IngenicoLaneModel.Lane3000);

            Assert.AreEqual(true, ingenicoLaneReceipt.Parse(Properties.Resources.lane3000));
        }
    }
}