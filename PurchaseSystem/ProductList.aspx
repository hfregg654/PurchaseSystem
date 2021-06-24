<%@ Page Title="" Language="C#" MasterPageFile="~/PurchaseSystem.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="PurchaseSystem.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">商品清單</h1>
    <div class="container">
        <br />
        <div class="row">
            <asp:Repeater ID="RepProuduct" runat="server">
                <HeaderTemplate>
                    <div class="col-3 tableBorder">商品編號</div>
                    <div class="col-3 tableBorder">分類</div>
                    <div class="col-3 tableBorder">商品名稱</div>
                    <div class="col-3 tableBorder">單價</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-3 tableBorder"><%#Eval("ProuductID") %></div>
                    <div class="col-3 tableBorder"><%#Eval("ProductCategory") %></div>
                    <div class="col-3 tableBorder"><%#Eval("ProductName") %></div>
                    <div class="col-3 tableBorder">NT<%#Eval("ProductPrice") %></div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
