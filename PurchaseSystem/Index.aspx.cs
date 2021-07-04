using CrystalDecisions.Shared;
using PurchaseSystem.Models;
using PurchaseSystem.Utility;
using PurchaseSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace PurchaseSystem
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProdStatic.noworder = new List<OrderView>();    //重置暫存訂單資料
            ProdStatic.Subtotal = 0;                        //重置暫存小計
            ProdStatic.TempID = 0;                          //重置暫存編號
            //載入畫面時取得畫面資料
            if (!IsPostBack)
            {
                BuildDataTableCommit();                     
            }
        }
        //取得進貨單列表
        public void BuildDataTableCommit()
        {
            string qpage = Request.QueryString["Page"];     //取得Page的querystring
            int pIndex;                                     //定義儲存目前頁數的變數
            //若沒有querystring則將目前頁數設為1
            if (string.IsNullOrEmpty(qpage))
                pIndex = 1;
            //否則在確認querystring能夠轉型成數字後將目前頁數設為該數值
            else
            {
                int.TryParse(qpage, out pIndex);

                if (pIndex <= 0)
                    pIndex = 1;
            }

            PurchaseDBTool dBTool = new PurchaseDBTool();       //準備連接資料庫的工具
            int page;                                           //定義儲存總頁數的變數
            var result = dBTool.GetPurchase(out page, pIndex);  //呼叫查詢方法查回資料
            RepPurchases.DataSource = result.Skip(10 * (pIndex - 1)).Take(10); //取當前頁數的10筆資料輸出
            RepPurchases.DataBind();


            List<PageLink> pagingList = new List<PageLink>();           //定義儲存頁面連結字串的變數
            HLFirst.NavigateUrl = $"Index.aspx?Page=1";                 //設定第一頁連結
            int backpage = (pIndex - 1 <= 0) ? 1 : (pIndex - 1);        //設定上一頁頁數
            HLBack.NavigateUrl = $"Index.aspx?Page={backpage}";         //設定上一頁連結
            int nextpage = (pIndex + 1 > page) ? page : (pIndex + 1);   //設定下一頁頁數
            HLNext.NavigateUrl = $"Index.aspx?Page={nextpage}";         //設定下一頁連結
            HLLast.NavigateUrl = $"Index.aspx?Page={page}";             //設定最尾頁連結

            //產生頁數連結
            for (var i = 1; i <= page; i++)
            {
                pagingList.Add(new PageLink()
                {
                    Link = $"Index.aspx?Page={i}",
                    Name = $"{i}",
                    Title = $"前往第 {i} 頁"
                });
            }
            //將頁數連結顯示至畫面
            this.RepPage.DataSource = pagingList;
            this.RepPage.DataBind();
        }
        //刪除按鈕
        protected void BtnDel_Click(object sender, EventArgs e)
        {
            //檢查是否為登入狀態,非登入狀態踢回首頁
            LogInfo info = Session["IsLogined"] as LogInfo;
            if (info == null)
            {
                LoginHelper loginHelper = new LoginHelper();
                loginHelper.Logout();
                Response.Redirect("../Login.aspx");
            }
            List<string> delpur = new List<string>();//定義刪除清單
            //找出頁面中有被打勾的選框並加入清單
            foreach (RepeaterItem item in RepPurchases.Items)
            {
                CheckBox chk = item.FindControl("CBPurchase") as CheckBox;
                if (chk.Checked)
                {
                    delpur.Add(chk.ToolTip);
                }
            }
            //開啟工具並執行刪除
            PurchaseDBTool dBTool = new PurchaseDBTool();
            dBTool.DelPurchase(delpur);
            BuildDataTableCommit();
        }

        //輸出報表按鈕
        protected void BtnOutput_Click(object sender, EventArgs e)
        {
            //執行輸出報表
            OutputPurchase();
        }
        //輸出報表
        public void OutputPurchase()
        {
            //查詢需輸出的資料放入報表顯示並開啟畫面至報表頁
            using (var context = new ContextModel())
            {
                //查詢需輸出的資料
                var rep =
                     (from obj in context.Purchases
                      where obj.pur_deldate == null
                      select new { obj.pur_id, obj.pur_total, obj.pur_purdate, obj.pur_credate }).ToList();

                //將資料放入報表
                PurchaseCrystalReport cr = new PurchaseCrystalReport();
                cr.SetDataSource(rep);
                PurchaseCRV.ReportSource = cr;

                //開啟畫面至報表頁
                cr.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "発注書一覧表");
            }
        }
    }
}