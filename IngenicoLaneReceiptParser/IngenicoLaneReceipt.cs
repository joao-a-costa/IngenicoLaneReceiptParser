﻿using HtmlAgilityPack;
using IngenicoLaneReceiptParser.Models;
using IngenicoLaneReceiptParser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace IngenicoLaneReceiptParser
{
    public class IngenicoLaneReceipt
    {
        private const string Xpath = "//div";
        private List<string> ListStylesToIgnore = new List<string>() { "\"display:table-cell;", "\"display:block" };

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
        public string BaseXPath { get; set; } = "/html[1]/body[1]/div";
        public List<string> Result { get; set; } = new List<string>();

        #endregion

        #region "Methods"

        [Obsolete("Parse is deprecated, please use ParseV3 instead.")]
        public bool Parse(string htmlToParse)
        {
            bool res = true;
            HtmlDocument helpDocument = new HtmlDocument();
            helpDocument.LoadHtml(htmlToParse);


            switch (LaneModel)
            {
                case IngenicoLaneModel.Lane3000:
                    break;
                default:
                    break;
            }

            ReceiptHeader = new ReceiptHeader
            {
                Text1 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[1]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[2]"),
                Text3 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[3]"),
                Text4 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[4]"),
                Text5 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[5]"),

                VATNumberTitle = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[7]/div[2]"),

                MID = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[8]/div[2]"),

                TID = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[9]/div[2]"),

                AcquirerID_Title = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[10]/div[2]"),

                IssuerID_Title = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[11]/div[2]")
            };
            CardSchemeDetails = new CardSchemeDetails
            {
                Waiter_Title = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[15]/div[2]"),
                AID = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[16]/div[2]"),
                Text1 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[17]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[18]"),
            };
            CardDetails = new CardDetails
            {
                Text1 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[19]"),
                StartDateDisplay_Title = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[20]/div[1]"),
                ExpiryDateDisplay_Title = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[20]/div[2]"),
                ICC = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[21]/div[1]"),
                IssueNumber_Title = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[21]/div[2]"),
                PANSEQ = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[21]/div[3]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[22]"),
                Text3 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[23]"),
                Text4 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[24]"),
                Text5 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[25]"),
                Text6 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[26]"),
            };
            Text1 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[28]");
            Text2 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[29]");
            PaymentDetails = new PaymentDetails
            {
                Amount = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[31]/div[2]"),
                VerifiedByPIN = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[37]/div[1]")
            };
            if (string.IsNullOrEmpty(PaymentDetails.Amount))
                PaymentDetails.Amount = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[32]/div[2]");
            ReceiptFooter = new ReceiptFooter
            {
                Text1 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[41]"),
                Text2 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[42]"),
                Text3 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[43]"),
                Text4 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[44]"),
                Text5 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[45]"),
                Text6 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[46]/div[1]"),
                Text7 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[47]"),
                Text8 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[48]"),
                Text9 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[49]/div[1]"),
                Text10 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[50]/div[1]"),
                Text11 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[51]/div[1]"),
                Text12 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[52]/div[1]"),
                Text13 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[53]/div[1]"),
                Text14 = Utility.GetHTMLInnerText(helpDocument, $"{BaseXPath}[54]/div[1]"),
            };

            return res;
        }

        [Obsolete("Parse is deprecated, please use ParseV3 instead.")]
        public bool ParseV2(string htmlToParse)
        {
            bool res = true;
            HtmlDocument helpDocument = new HtmlDocument();
            helpDocument.LoadHtml(htmlToParse);

            helpDocument.DocumentNode.SelectNodes(BaseXPath).ToList().ForEach(fe =>
            {
                var innerText = fe.InnerText;

                if (!string.IsNullOrEmpty(innerText))
                    Result.Add(innerText);
            });

            return res;
        }

        public bool ParseV3(string htmlToParse)
        {
            bool res = true;

            Result.Clear();

            var document = new HtmlDocument();
            document.LoadHtml(htmlToParse);

            foreach (HtmlNode div in document.DocumentNode.SelectNodes(Xpath).Where(
                w =>
                    !string.IsNullOrEmpty(w.InnerText.Trim()) &&
                    !w.InnerText.Trim().StartsWith("{") &&
                    !w.InnerText.Trim().StartsWith("}") &&
                    !Regex.IsMatch(w.InnerText.Trim(), @"\{.*?\}") &&
                    !w.GetAttributeValue("style", "").Contains("display:table-cell") &&
                    !w.GetAttributeValue("style", "").Contains("display:block")
                )
            )
            {
                if(div.ChildNodes.Count > 1)
                    Result.Add(string.Join(" ", div.ChildNodes.Where(w => !string.IsNullOrEmpty(w.InnerText.Trim())).Select(s => s.InnerText)));
                else
                    Result.Add(div.InnerText);
            }

            return res;
        }

        #endregion
    }
}
