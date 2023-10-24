using HtmlAgilityPack;

namespace IngenicoLaneReceiptParser.Utilities
{
    public class Utility
    {
        public static string GetHTMLInnerText(HtmlDocument htmlDocument, string xpath)
        {
            return htmlDocument.DocumentNode.SelectSingleNode(xpath)?.InnerText;
        }
    }
}
