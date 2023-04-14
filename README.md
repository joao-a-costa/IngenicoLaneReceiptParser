# IngenicoLaneReceiptParser
HTML parser for Ingenico TPA receipts

This project provides an HTML parsing solution that caters to Ingenico TPA receipts, allowing you to effortlessly extract relevant information from an HTML document. When a receipt event is sent to print, the information is typically embedded in HTML format, making it difficult to access and process. The parser seamlessly converts the HTML into objects, making it easier to extract specific data and streamline your printing processes.

Sample:
````
IngenicoLaneReceipt ingenicoLaneReceipt = new(IngenicoLaneReceipt.IngenicoLaneModel.Lane3000);

new List<string>()
{
    $@"{ingenicoLaneReceipt.ReceiptHeader.Text1}",
    ingenicoLaneReceipt.ReceiptHeader.Text2,
    ingenicoLaneReceipt.ReceiptHeader.Text3,
    ingenicoLaneReceipt.ReceiptHeader.Text4,
    ingenicoLaneReceipt.ReceiptHeader.Text5,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptHeader.MID) ? $@"MID: {ingenicoLaneReceipt.ReceiptHeader.MID}" : string.Empty,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptHeader.TID) ? $@"TID: {ingenicoLaneReceipt.ReceiptHeader.TID}" : string.Empty,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.CardSchemeDetails.AID) ? $@"AID: {ingenicoLaneReceipt.CardSchemeDetails.AID}" : string.Empty,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.CardSchemeDetails.Text1) ? ingenicoLaneReceipt.CardSchemeDetails.Text1 : string.Empty,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.CardSchemeDetails.Text2) ? ingenicoLaneReceipt.CardSchemeDetails.Text2 : string.Empty,
    ingenicoLaneReceipt.CardDetails.Text1,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text2) ? ingenicoLaneReceipt.CardDetails.Text2 : string.Empty,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text3) ? ingenicoLaneReceipt.CardDetails.Text3 : string.Empty,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text4) ? ingenicoLaneReceipt.CardDetails.Text4 : string.Empty,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.CardDetails.Text5) ? ingenicoLaneReceipt.CardDetails.Text5 : string.Empty,
    ingenicoLaneReceipt.CardDetails.Text6,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.Text1) ? ingenicoLaneReceipt.Text1 : string.Empty,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.Text2) ? ingenicoLaneReceipt.Text2 : string.Empty,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.PaymentDetails.Amount) ? $@"AMOUNT: {ingenicoLaneReceipt.PaymentDetails.Amount.Replace("&#xa3;", "£")}" : string.Empty,
    ingenicoLaneReceipt.ReceiptFooter.Text1,
    ingenicoLaneReceipt.ReceiptFooter.Text2,
    ingenicoLaneReceipt.ReceiptFooter.Text3,
    ingenicoLaneReceipt.ReceiptFooter.Text4,
    ingenicoLaneReceipt.ReceiptFooter.Text5,
    ingenicoLaneReceipt.ReceiptFooter.Text6,
    !string.IsNullOrEmpty(ingenicoLaneReceipt.ReceiptFooter.Text7) ? ingenicoLaneReceipt.ReceiptFooter.Text7 : string.Empty,
    ingenicoLaneReceipt.ReceiptFooter.Text8,
    ingenicoLaneReceipt.ReceiptFooter.Text9,
    ingenicoLaneReceipt.ReceiptFooter.Text13,
    ingenicoLaneReceipt.ReceiptFooter.Text14,
    Environment.NewLine,
    Environment.NewLine,
    Environment.NewLine,
};
````
