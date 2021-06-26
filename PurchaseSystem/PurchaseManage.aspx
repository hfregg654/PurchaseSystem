<%@ Page Title="" Language="C#" MasterPageFile="~/PurchaseSystem.Master" AutoEventWireup="true" CodeBehind="PurchaseManage.aspx.cs" Inherits="PurchaseSystem.PurchaseManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Script/jquery-ui-1.12.1/jquery-ui.min.css" rel="stylesheet" />
    <script src="Script/jquery-ui-1.12.1/jquery-ui.min.js"></script>
    <link href="Script/jquery-ui-timepicker-addon.css" rel="stylesheet" />
    <script src="Script/jquery-ui-timepicker-addon.js"></script>
    <script>
        function handleChange1(product) {
            var prod = product.split(',');
            $("#ContentPlaceHolder1_LblProd").html(prod[0]);
            $("#selectprodprice").val(prod[1]);
            $("#selectprodid").val(prod[2]);
            var num = $("#ContentPlaceHolder1_TBProdnum").val();
            gettotal(num);
        }
        function gettotal(num) {
            $.ajax({
                url: "API/POPGetProuductHandler.ashx",
                data: {
                    "Num": num,
                    "Price": $("#selectprodprice").val()
                },
                type: "POST",
                dataType: "json",
            })
                .done(function (responsedata) {
                    $("#ContentPlaceHolder1_LblTprice").html(responsedata)
                })
                .fail(function (xhr, status, errThrown) {
                    alert("傳送失敗");
                })
        }
        function getproducts(category) {
            $.ajax({
                url: "API/POPGetProuductHandler.ashx",
                data: {
                    "Category": category
                },
                type: "POST",
                dataType: "json",
            })
                .done(function (responsedata) {
                    $("#ContentPlaceHolder1_LblProd").html("");
                    $("#ContentPlaceHolder1_LblTprice").html("");
                    $("#ContentPlaceHolder1_TBProdnum").val(0);
                    $("#prodtable").html("");
                    var htmltext = "";
                    htmltext += "<div class='col-1 tableBorder'></div>";
                    htmltext += "<div class='col-4 tableBorder'>商品編號</div>";
                    htmltext += "<div class='col-4 tableBorder'>商品名稱</div>";
                    htmltext += "<div class='col-3 tableBorder'>單價</div>";

                    for (var i = 0; i < responsedata.length; i++) {
                        htmltext += "<div class='col-1 tableBorder'>";
                        htmltext += "<input type='radio' id='html";
                        htmltext += i;
                        htmltext += "' name='chooseprod' onchange='handleChange1(this.value);' value='";
                        htmltext += responsedata[i].ProductName + "," + responsedata[i].ProductPrice + "," + responsedata[i].ProuductID;
                        htmltext += "'></div>";
                        htmltext += "<div class='col-4 tableBorder'>";
                        htmltext += responsedata[i].ProuductID;
                        htmltext += "</div>";
                        htmltext += "<div class='col-4 tableBorder'>";
                        htmltext += responsedata[i].ProductName;
                        htmltext += "</div>";
                        htmltext += "<div class='col-3 tableBorder'>";
                        htmltext += responsedata[i].ProductPrice;
                        htmltext += "</div>";
                    }
                    $("#prodtable").append(htmltext);
                })
                .fail(function (xhr, status, errThrown) {
                    alert("傳送失敗");
                })
        }
        $(document).ready(function () {

            $('#ContentPlaceHolder1_datepicker').datetimepicker({
                "dateFormat": "yy-mm-dd",
                "timeFormat": "HH:mm"
            });

            $("#dialog").dialog({
                autoOpen: false,
                width: 800,
                show: {},
                hide: {}
            });
            $("#Btnadd").click(function () {
                $("#dialog").dialog("open");
            });

            $("#Btnprodcancel").click(function () {
                $("#dialog").dialog("close");
                $("#prodtable").html("");
                $("#ContentPlaceHolder1_LblProd").html("");
                $("#ContentPlaceHolder1_LblTprice").html("");
                $("#ContentPlaceHolder1_TBProdnum").val(0);
                $("#ContentPlaceHolder1_DDLCate").val(0);
            });

            $("#Btnprodadd").click(function () {
                $.ajax({
                    url: "API/POPAddProdHandler.ashx",
                    data: {
                        "ProuductID": $("#selectprodid").val(),
                        "ProductName": $("#ContentPlaceHolder1_LblProd").html(),
                        "OrderNum": $("#ContentPlaceHolder1_TBProdnum").val(),
                        "ProductPrice": $("#selectprodprice").val()
                    },
                    type: "POST",
                    dataType: "json",
                })
                    .done(function (responsedata) {
                        location.reload(true);
                    })
                    .fail(function (xhr, status, errThrown) {
                        alert("傳送失敗");
                    })
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center">進貨單管理</h1>
    <div class="container">
        <br />
        <div class="row">
            <div class="col-4">
                單據編號：<asp:TextBox ID="TBpurid" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="col-4">
                進貨時間：<asp:TextBox ID="datepicker" runat="server" CssClass="form-control" TextMode="DateTime"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <button id="Btnadd" type="button" class="btn btn-success">＋</button>
            <asp:Button ID="Btndel" runat="server" Text="－" CssClass="btn btn-danger" OnClick="Btndel_Click"
                OnClientClick="return confirm('確定刪除勾選的訂單？');" />
        </div>
        <div class="row">
            <asp:Repeater ID="RepOrders" runat="server">
                <HeaderTemplate>
                    <div class="col-1 tableBorder"></div>
                    <div class="col-2 tableBorder">商品編號</div>
                    <div class="col-3 tableBorder">商品名稱</div>
                    <div class="col-2 tableBorder">單價</div>
                    <div class="col-2 tableBorder">數量</div>
                    <div class="col-2 tableBorder">小計</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-1 tableBorder">
                        <asp:CheckBox ID="CBOrder" runat="server" ToolTip='<%#Eval("OrderID") %>' />
                    </div>
                    <div class="col-2 tableBorder"><%#Eval("ProuductID") %></div>
                    <div class="col-3 tableBorder"><%#Eval("ProductName") %></div>
                    <div class="col-2 tableBorder"><%#Eval("ProductPrice") %></div>
                    <div class="col-2 tableBorder"><%#Eval("OrderNum") %></div>
                    <div class="col-2 tableBorder">NT<%#Eval("TotalPrice") %></div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />
        <div class="Buttonright">
            <asp:Label ID="LblTotal" runat="server" Text="總計 NT0"></asp:Label>
        </div>
        <br />
        <br />
        <br />
        <br />
        <div class="row justify-content-between">
            <div class="col">
                <asp:Button ID="Btncancel" runat="server" Text="取消" CssClass="btn btn-danger" OnClick="Btncancel_Click" />
                <asp:Button ID="BtnDone" runat="server" Text="完成" CssClass="btn btn-success"
                    OnClientClick="return confirm('確定完成進貨單？');" OnClick="BtnDone_Click" />
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
        </div>
    </div>

    <div id="dialog" title="選擇商品" class="container" style="text-align: center">
        <div class="row">
            <div class="col-12">
                貨物種類：
                <asp:DropDownList ID="DDLCate" runat="server" onchange="getproducts(this.value);" />
            </div>
        </div>
        <div class="row" id="prodtable">
        </div>
        <div class="row">
            <div class="col-6">已挑選商品：</div>
            <div class="col-6">
                <asp:Label ID="LblProd" runat="server" Text=""></asp:Label>
                <input id="selectprodprice" type="hidden" value="" />
                <input id="selectprodid" type="hidden" value="" />
            </div>
            <div class="col-6">數量：</div>
            <div class="col-6">
                <asp:TextBox ID="TBProdnum" runat="server" TextMode="Number" min="1" max="10000" Text="0"
                    onKeyDown="if(this.value.length==5 && event.keyCode!=8) return false;" onchange="gettotal(this.value);"></asp:TextBox>
            </div>
            <div class="col-6">小計：</div>
            <div class="col-6">
                <asp:Label ID="LblTprice" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row align-items-center">
            <div class="col">
                <button id="Btnprodadd" type="submit" class="btn btn-success">加入</button>
            </div>
            <div class="col">
                <button id="Btnprodcancel" type="button" class="btn btn-danger">取消</button>
            </div>
        </div>
    </div>




</asp:Content>
