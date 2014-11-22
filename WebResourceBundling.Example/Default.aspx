<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebResourceBundling.Example.WebForm1" %>
<%@ Import Namespace="System.Web.Optimization" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Bunling with embedded scripts</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <a runat="server" ID="s1" href="#">script 1</a><br/>
            <a runat="server" ID="s2" href="#">script 2</a><br/>
            <a runat="server" ID="s3" href="#">bundle</a><br/>
            <%: Scripts.Render("~/bundle") %>
        </form>
    </body>
</html>
