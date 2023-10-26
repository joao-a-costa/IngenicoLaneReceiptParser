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

            Assert.AreEqual(true, testLane3000 && testLane3000V2);
        }


        [TestMethod]
        public void TestParseLane3000V3()
        {
            IngenicoLaneReceipt ingenicoLaneReceipt = new(IngenicoLaneReceipt.IngenicoLaneModel.Lane3000);

            var testLane3000 = ingenicoLaneReceipt.ParseV2(File.ReadAllText(@"Files\lane3000.html"));
            var testLane3000V2 = ingenicoLaneReceipt.ParseV2(File.ReadAllText(@"Files\lane3000V2.html"));
            var testLane3000V3 = ingenicoLaneReceipt.Parse(File.ReadAllText(@"Files\lane3000V3.html"));

            Assert.AreEqual(true, testLane3000 && testLane3000V2 & testLane3000V3);
        }

        [TestMethod]
        public void TestParseLane3000V4()
        {
            IngenicoLaneReceipt ingenicoLaneReceipt = new(IngenicoLaneReceipt.IngenicoLaneModel.Lane3000);

            var testLane3000V3 = ingenicoLaneReceipt.Parse(File.ReadAllText(@"Files\lane3000V3.html"));
            var ticketLineList = new List<string>();
            //ticketLineList.Add($@"{rawPrinterESCPOS.eInit + rawPrinterESCPOS.eCentre}{ingenicoLaneReceipt.ReceiptHeader.Text1}");
            //ticketLineList.Add(rawPrinterESCPOS.eCentre + ingenicoLaneReceipt.ReceiptHeader.Text2);
            //ticketLineList.Add(rawPrinterESCPOS.eCentre + ingenicoLaneReceipt.ReceiptHeader.Text3);
            //if (!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text4))
            //    ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptHeader.Text4) ? ingenicoLaneReceipt.ReceiptHeader.Text4 : string.Empty);
            //if (!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text5))
            //    ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptHeader.Text5) ? ingenicoLaneReceipt.ReceiptHeader.Text5 : string.Empty);

            var amount = ingenicoLaneReceipt.PaymentDetails?.Amount?.Replace("&#xa3;", "GBP");

            //ticketLineList.Add($@"{rawPrinterESCPOS.eInit}");
            ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptHeader.MID) ? $@"MID: {ingenicoLaneReceipt.ReceiptHeader.MID}" : string.Empty);
            ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptHeader.TID) ? $@"TID: {ingenicoLaneReceipt.ReceiptHeader.TID}" : string.Empty);
            ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.CardSchemeDetails.AID) ? $@"AID: {ingenicoLaneReceipt.CardSchemeDetails.AID}" : string.Empty);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.CardSchemeDetails.Text1))
                ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.CardSchemeDetails.Text1) ? ingenicoLaneReceipt.CardSchemeDetails.Text1 : string.Empty);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.CardSchemeDetails.Text2))
                ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.CardSchemeDetails.Text2) ? ingenicoLaneReceipt.CardSchemeDetails.Text2 : string.Empty);


            ticketLineList.Add(ingenicoLaneReceipt.CardDetails.ExpiryDateDisplay_Title);
            ticketLineList.Add(ingenicoLaneReceipt.CardDetails.ICC);
            ticketLineList.Add(ingenicoLaneReceipt.CardDetails.PANSEQ);

            ticketLineList.Add(ingenicoLaneReceipt.CardDetails.Text1);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text2))
                ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text2) ? ingenicoLaneReceipt.CardDetails.Text2 : string.Empty);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text3))
                ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text3) ? ingenicoLaneReceipt.CardDetails.Text3 : string.Empty);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text4))
                ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text4) ? ingenicoLaneReceipt.CardDetails.Text4 : string.Empty);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text5))
                ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text5) ? ingenicoLaneReceipt.CardDetails.Text5 : string.Empty);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text6))
                ticketLineList.Add(ingenicoLaneReceipt.CardDetails.Text6);

            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.Text1))
                ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.Text1) ? ingenicoLaneReceipt.Text1 : string.Empty);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.Text2))
                ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.Text2) ? ingenicoLaneReceipt.Text2 : string.Empty);
            ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.PaymentDetails.Amount) ? $@"AMOUNT: {amount}" : string.Empty);
            ticketLineList.Add(!string.IsNullOrEmpty(ingenicoLaneReceipt.PaymentDetails.VerifiedByPIN) ? ingenicoLaneReceipt.PaymentDetails.VerifiedByPIN.Replace("\\n", string.Empty) : string.Empty);

            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text1))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text1);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text2))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text2);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text3))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text3);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text4))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text4);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text5))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text5);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text6))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text6);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text8))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text8);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text9))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text9);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text13))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text13);
            if (!string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text14))
                ticketLineList.Add(ingenicoLaneReceipt.ReceiptFooter.Text14);
            ticketLineList.Add(Environment.NewLine);

            Assert.AreEqual(true, testLane3000V3);
        }

        [TestMethod]
        public void TestParseLane3000V5()
        {
            IngenicoLaneReceipt ingenicoLaneReceipt = new(IngenicoLaneReceipt.IngenicoLaneModel.Lane3000);

            var testLane3000V3 = ingenicoLaneReceipt.ParseV3(File.ReadAllText(@"Files\lane3000V3.html"));

            Assert.AreEqual(true, testLane3000V3);
        }

        [TestMethod]
        public void TestParseLane3000V6()
        {
            IngenicoLaneReceipt ingenicoLaneReceipt = new(IngenicoLaneReceipt.IngenicoLaneModel.Lane3000);

            var testLane3000V3 = ingenicoLaneReceipt.ParseV3(File.ReadAllText(@"Files\lane3000V4.html"));

            Assert.AreEqual(true, testLane3000V3);
        }
    }
}