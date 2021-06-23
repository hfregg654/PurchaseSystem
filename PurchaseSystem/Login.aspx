<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PurchaseSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Script/jquery-3.6.0.min.js"></script>
    <link href="Script/bootstrap.min.css" rel="stylesheet" />
    <script src="Script/bootstrap.min.js"></script>
    <link href="Script/mystyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 250px"></div>
    <div class="container" style="border: solid blue 2px;"> 
        <h1>登入</h1>
        <div class="row">
            <div class="col-12">
                帳號：
                <asp:TextBox ID="TextBoxacc" runat="server" ToolTip="帳號"  CssClass="form-control" MaxLength="50" ></asp:TextBox>
                <span class="errorMessage">
                    <asp:Literal ID="ltlacc" runat="server"></asp:Literal>
                </span>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                密碼：
                <asp:TextBox ID="TextBoxpwd" runat="server" ToolTip="密碼" CssClass="form-control" TextMode="Password" MaxLength="50"></asp:TextBox>
                <span class="errorMessage">
                    <asp:Literal ID="ltlpwd" runat="server"></asp:Literal>
                </span>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:Button ID="btnlogin" runat="server" Text="登入" OnClick="Button1_Click" CssClass="btn btn-primary" />
                <span class="errorMessage">
                    <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
                </span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
