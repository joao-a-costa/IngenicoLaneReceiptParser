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

            string? baseNode = "/html[1]/body[1]/div";

            ReceiptHeader = new ReceiptHeader
            {
                Text1 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[1]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[2]"),
                Text3 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[3]"),
                Text4 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[4]"),
                Text5 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[5]"),

                VATNumberTitle = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[7]/div[2]"),

                MID = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[8]/div[2]"),

                TID = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[9]/div[2]"),

                AcquirerID_Title = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[10]/div[2]"),

                IssuerID_Title = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[11]/div[2]")
            };
            CardSchemeDetails = new CardSchemeDetails
            {
                Waiter_Title = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[15]/div[2]"),
                AID = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[16]/div[2]"),
                Text1 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[17]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[18]"),
            };
            CardDetails = new CardDetails
            {
                Text1 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[19]"),
                StartDateDisplay_Title = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[20]/div[1]"),
                ExpiryDateDisplay_Title = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[20]/div[2]"),
                ICC = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[21]/div[1]"),
                IssueNumber_Title = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[21]/div[2]"),
                PANSEQ = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[21]/div[1]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[22]"),
                Text3 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[23]"),
                Text4 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[24]"),
                Text5 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[25]"),
                Text6 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[26]"),
            };
            Text1 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[28]");
            Text2 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[29]");
            PaymentDetails = new PaymentDetails
            {
                Amount = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[31]/div[2]"),
                VerifiedByPIN = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[37]/div[1]")
            };
            ReceiptFooter = new ReceiptFooter
            {
                Text1 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[41]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[42]"),
                Text3 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[43]"),
                Text4 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[44]"),
                Text5 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[45]"),
                Text6 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[46]/div[1]"),
                Text7 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[47]"),
                Text8 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[48]"),
                Text9 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[49]/div[1]"),
                Text10 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[50]/div[1]"),
                Text11 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[51]/div[1]"),
                Text12 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[52]/div[1]"),
                Text13 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[53]/div[1]"),
                Text14 = Utility.GetHTMLInnerText(helpDocument, $"{baseNode}[54]/div[1]"),
            };

            return res;
        }

        #endregion
    }
}
