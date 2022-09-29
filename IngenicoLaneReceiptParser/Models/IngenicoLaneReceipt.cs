using HtmlAgilityPack;
using IngenicoLaneReceiptParser.Utilities;

namespace IngenicoLaneReceiptParser.Models
{
    public class IngenicoLaneReceipt
    {
        public enum IngenicoLaneModel
        {
            Lane3000
        }

        #region "Constructor

        public IngenicoLaneReceipt(IngenicoLaneModel laneModel)
        {
            LaneModel = laneModel;
        }

        #endregion

        #region "Properties"

        public IngenicoLaneModel LaneModel { get; set; }
        public ReceiptHeader ReceiptHeader { get; set; } = new ReceiptHeader();
        public CardSchemeDetails CardSchemeDetails { get; set; } = new CardSchemeDetails();
        public CardDetails CardDetails { get; set; } = new CardDetails();
        public string Text1 { get; set; } = string.Empty;
        public string Text2 { get; set; } = string.Empty;
        public PaymentDetails PaymentDetails { get; set; } = new PaymentDetails();
        public ReceiptFooter ReceiptFooter { get; set; } = new ReceiptFooter();

        #endregion

        #region "Methods"

        public bool Parse(string htmlToParse)
        {
            bool res = true;
            HtmlDocument? helpDocument = new();
            helpDocument.LoadHtml(htmlToParse);

            ReceiptHeader = new ReceiptHeader
            {
                Text1 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[1]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[2]"),
                Text3 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[3]"),
                Text4 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[4]"),
                Text5 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[5]"),

                VATNumberTitle = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[7]/div[2]"),

                MID = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[8]/div[2]"),

                TID = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[9]/div[2]"),

                AcquirerID_Title = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[10]/div[2]"),

                IssuerID_Title = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[11]/div[2]")
            };
            CardSchemeDetails = new CardSchemeDetails
            {
                Waiter_Title = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[15]/div[2]"),
                AID = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[16]/div[2]"),
                Text1 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[17]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[18]"),
            };
            CardDetails = new CardDetails
            {
                Text1 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[19]"),
                StartDateDisplay_Title = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[20]/div[1]"),
                ExpiryDateDisplay_Title = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[20]/div[2]"),
                ICC = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[21]/div[1]"),
                IssueNumber_Title = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[21]/div[2]"),
                PANSEQ = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[21]/div[1]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[22]"),
                Text3 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[23]"),
                Text4 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[24]"),
                Text5 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[25]"),
                Text6 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[26]"),
            };
            Text1 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[28]");
            Text2 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[29]");
            PaymentDetails = new PaymentDetails
            {
                Amount = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[31]/div[2]"),
                VerifiedByPIN = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[37]/div[1]")
            };
            ReceiptFooter = new ReceiptFooter
            {
                Text1 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[41]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[42]"),
                Text3 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[43]"),
                Text4 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[44]"),
                Text5 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[45]"),
                Text6 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[46]/div[1]"),
                Text7 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[47]"),
                Text8 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[48]"),
                Text9 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[49]/div[1]"),
                Text10 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[50]/div[1]"),
                Text11 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[51]/div[1]"),
                Text12 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[52]/div[1]"),
                Text13 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[53]/div[1]"),
                Text14 = Utility.GetHTMLInnerText(helpDocument, "/html[1]/body[1]/div[54]/div[1]"),
            };

            return res;
        }

        #endregion
    }
}
