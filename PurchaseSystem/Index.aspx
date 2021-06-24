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
                    <div class="col-2 tableBorder">
                        <a href='PurchaseManage.aspx?ID=<%#Eval("PurchaseID") %>'><%#Eval("PurchaseID") %></a>
                    </div>
                    <div class="col-2 tableBorder"><%#Eval("PCategory") %></div>
                    <div class="col-2 tableBorder"><%#Eval("TotalNum") %></div>
                    <div class="col-3 tableBorder"><%#Eval("PurchaseDate","{0:yyyy-MM-dd HH:mm}") %></div>
                    <div class="col-2 tableBorder">NT<%#Eval("TotalMoney") %></div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="row justify-content-between">
            <div class="col">
                <asp:Button ID="BtnDel" runat="server" Text="刪除" CssClass="btn btn-danger"
                    OnClientClick="return confirm('確定刪除勾選的進貨單？');" OnClick="BtnDel_Click" />
                <asp:HyperLink ID="HLNew" runat="server" CssClass="btn btn-success text-white"
                    NavigateUrl="~/PurchaseManage.aspx">新增</asp:HyperLink>
                <asp:HyperLink ID="HLFirst" runat="server">第一頁</asp:HyperLink>｜
                <asp:HyperLink ID="HLBack" runat="server">上一頁</asp:HyperLink>｜
                <asp:Repeater ID="RepPage" runat="server">
                    <ItemTemplate>
                        <a href="<%# Eval("Link") %>" title="<%# Eval("Title") %>"><%# Eval("Name") %></a>｜
                    </ItemTemplate>
                </asp:Repeater>
                <asp:HyperLink ID="HLNext" runat="server">下一頁</asp:HyperLink>｜
                <asp:HyperLink ID="HLLast" runat="server">最末頁</asp:HyperLink>
            </div>
            <div class="col">
                <asp:Button ID="BtnOutput" runat="server" Text="輸出報表" CssClass="btn btn-info Buttonright" />
            </div>
        </div>
    </div>
</asp:Content>
