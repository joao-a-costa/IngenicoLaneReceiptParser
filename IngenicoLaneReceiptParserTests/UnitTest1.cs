using IngenicoLaneReceiptParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace IngenicoLaneReceiptParserTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestParseLane3000()
        {
            IngenicoLaneReceipt ingenicoLaneReceipt = new(IngenicoLaneReceipt.IngenicoLaneModel.Lane3000);

            Assert.AreEqual(true, ingenicoLaneReceipt.Parse(File.ReadAllText(@"Files\lane3000.html")));
        }

        [TestMethod]
        public void TestParseLane3000V2()
        {
            IngenicoLaneReceipt ingenicoLaneReceipt = new(IngenicoLaneReceipt.IngenicoLaneModel.Lane3000);

            var testLane3000 = ingenicoLaneReceipt.ParseV2(File.ReadAllText(@"Files\lane3000.html"));
            var testLane3000V2 = ingenicoLaneReceipt.ParseV2(File.ReadAllText(@"Files\lane3000V2.html"));

            Assert.AreEqual(true, testLane3000 && testLane3000);
        }
    }
}