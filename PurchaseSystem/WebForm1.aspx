<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PurchaseSystem.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <%#Eval("PurchaseID") %>
                    <br />
                     <%#Eval("PCategory") %>
                    <br />
                     <%#Eval("TotalNum") %>
                    <br />
                     <%#Eval("PurchaseDate","{0:yyyy-MM-dd HH:mm}") %>
                    <br />
                     <%#Eval("TotalMoney") %>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
