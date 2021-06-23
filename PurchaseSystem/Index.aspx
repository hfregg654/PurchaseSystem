<%@ Page Title="" Language="C#" MasterPageFile="~/PurchaseSystem.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PurchaseSystem.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">進貨單管理</h1>
    <div class="container">
        <br />
        <div class="row">
            <asp:Repeater ID="RepPurchases" runat="server">
                <HeaderTemplate>
                    <div class="col-1 tableBorder"></div>
                    <div class="col-2 tableBorder">單據編號</div>
                    <div class="col-2 tableBorder">貨物種類</div>
                    <div class="col-2 tableBorder">總進貨數量</div>
                    <div class="col-3 tableBorder">預計進貨時間</div>
                    <div class="col-2 tableBorder">進貨金額</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-1 tableBorder">
                        <asp:CheckBox ID="CBPurchase" runat="server" ToolTip='<%#Eval("PurchaseID") %>' />
                    </div>
                    <div class="col-2 tableBorder"><a href="#"><%#Eval("PurchaseID") %></a></div>
                    <div class="col-2 tableBorder"><%#Eval("PCategory") %></div>
                    <div class="col-2 tableBorder"><%#Eval("TotalNum") %></div>
                    <div class="col-3 tableBorder"><%#Eval("PurchaseDate","{0:yyyy-MM-dd HH:mm}") %></div>
                    <div class="col-2 tableBorder">NT<%#Eval("TotalMoney") %></div>
                </ItemTemplate>
            </asp:Repeater>
        </div> 
        <div class="row">

        </div>
    </div>
</asp:Content>
