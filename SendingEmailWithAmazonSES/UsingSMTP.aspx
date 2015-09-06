<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsingSMTP.aspx.cs" Inherits="SendingEmailWithAmazonSES.UsingSMTP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span style="color: rgb(51, 51, 51); font-family: 'Open Sans', 'Lucida Grande', 'Helvetica Neue', Arial; font-size: 18px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">Amazon Simple Email Service - Sending an Email Using SMTP with C#
        <br />
            </span>
            <br />
            <asp:Button ID="btnSend" runat="server" Text="Send Email" OnClick="btnSend_Click" />
        </div>
    </form>
</body>
</html>
