using PurchaseSystem.Models;
using PurchaseSystem.Utility;
using PurchaseSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurchaseSystem
{
    public partial class PurchaseManage : System.Web.UI.Page
    {
        static string pid;
        static string pdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ProdStatic.TempID == 0)
                {
                    BuildDataTableCommit();
                }
                else
                {
                    BuildDataTableCommitTemp();
                }

                BuildDDLCateCommit();
            }
        }
        public void BuildDataTableCommit()
        {
            LogInfo info = Session["IsLogined"] as LogInfo;
            //if (info == null)
            //{
            //    LoginHelper loginHelper = new LoginHelper();
            //    loginHelper.Logout();
            //    Response.Redirect("../Login.aspx");
            //}
            string qid = Request.QueryString["ID"];
            string qpage = Request.QueryString["Page"];

            int pIndex;
            if (string.IsNullOrEmpty(qpage))
                pIndex = 1;
            else
            {
                int.TryParse(qpage, out pIndex);

                if (pIndex <= 0)
                    pIndex = 1;
            }

            if (string.IsNullOrEmpty(qid))
            {
                DateTime nowtime = DateTime.Now;
                pid = $"ASN-{nowtime.ToString("yyyyMMddHHmm")}-{info.user_id}";
                TBpurid.Text = pid;
                pdate = nowtime.ToString("yyyy-MM-dd HH:mm");
                datepicker.Text = pdate;

                ProdStatic.Subtotal = 0;
                ProdStatic.noworder = new List<OrderView>();

                LblTotal.Text = $"總計 NT{ProdStatic.Subtotal}";
                List<PageLink> pagingList = new List<PageLink>();
                HLFirst.NavigateUrl = $"PurchaseManage.aspx?Page=1";
                HLBack.NavigateUrl = $"PurchaseManage.aspx?Page=1";
                HLNext.NavigateUrl = $"PurchaseManage.aspx?Page=1";
                HLLast.NavigateUrl = $"PurchaseManage.aspx?Page=1";

                for (var i = 1; i <= 1; i++)
                {
                    pagingList.Add(new PageLink()
                    {
                        Link = $"PurchaseManage.aspx?ID={qid}&Page={i}",
                        Name = $"{i}",
                        Title = $"前往第 {i} 頁"
                    });
                }

                this.RepPage.DataSource = pagingList;
                this.RepPage.DataBind();
            }
            else
            {
                TBpurid.Text = qid;

                PurchaseDBTool dBTool = new PurchaseDBTool();
                datepicker.Text = dBTool.GetPurchaseDate(qid);
                decimal fullprice;
                int page;
                var result = dBTool.GetOrder(qid, out fullprice, out page, pIndex);
                ProdStatic.Subtotal = fullprice;
                ProdStatic.noworder = result;
                RepOrders.DataSource = ProdStatic.noworder.Skip(10 * (pIndex - 1)).Take(10);
                RepOrders.DataBind();


                LblTotal.Text = $"總計 NT{ProdStatic.Subtotal}";
                List<PageLink> pagingList = new List<PageLink>();
                HLFirst.NavigateUrl = $"PurchaseManage.aspx?ID={qid}&Page=1";
                int backpage = (pIndex - 1 <= 0) ? 1 : (pIndex - 1);
                HLBack.NavigateUrl = $"PurchaseManage.aspx?ID={qid}&Page={backpage}";
                int nextpage = (pIndex + 1 > page) ? page : (pIndex + 1);
                HLNext.NavigateUrl = $"PurchaseManage.aspx?ID={qid}&Page={nextpage}";
                HLLast.NavigateUrl = $"PurchaseManage.aspx?ID={qid}&Page={page}";

                for (var i = 1; i <= page; i++)
                {
                    pagingList.Add(new PageLink()
                    {
                        Link = $"PurchaseManage.aspx?ID={qid}&Page={i}",
                        Name = $"{i}",
                        Title = $"前往第 {i} 頁"
                    });
                }

                this.RepPage.DataSource = pagingList;
                this.RepPage.DataBind();
            }


        }

        public void BuildDataTableCommitTemp()
        {
            string qid = Request.QueryString["ID"];
            string qpage = Request.QueryString["Page"];

            int pIndex;
            if (string.IsNullOrEmpty(qpage))
                pIndex = 1;
            else
            {
                int.TryParse(qpage, out pIndex);

                if (pIndex <= 0)
                    pIndex = 1;
            }

            if (string.IsNullOrEmpty(qid))
            {
                TBpurid.Text = pid;
                datepicker.Text = pdate;

                int page = (ProdStatic.noworder.Count / 10) + 1;
                var resultDB =
                    from orders in ProdStatic.noworder
                    where orders.OrderID > 0
                    orderby orders.OrderID descending
                    select orders;
                var resultTemp =
                    from orders in ProdStatic.noworder
                    where orders.OrderID < 0
                    orderby orders.OrderID
                    select orders;
                var result = resultTemp.ToList();
                foreach (var item in resultDB.ToList())
                {
                    result.Add(item);
                }
                RepOrders.DataSource = result.Skip(10 * (pIndex - 1)).Take(10);
                RepOrders.DataBind();


                LblTotal.Text = $"總計 NT{ProdStatic.Subtotal}";
                List<PageLink> pagingList = new List<PageLink>();
                HLFirst.NavigateUrl = $"PurchaseManage.aspx?Page=1";
                int backpage = (pIndex - 1 <= 0) ? 1 : (pIndex - 1);
                HLBack.NavigateUrl = $"PurchaseManage.aspx?Page={backpage}";
                int nextpage = (pIndex + 1 > page) ? page : (pIndex + 1);
                HLNext.NavigateUrl = $"PurchaseManage.aspx?Page={nextpage}";
                HLLast.NavigateUrl = $"PurchaseManage.aspx?Page={page}";

                for (var i = 1; i <= page; i++)
                {
                    pagingList.Add(new PageLink()
                    {
                        Link = $"PurchaseManage.aspx?Page={i}",
                        Name = $"{i}",
                        Title = $"前往第 {i} 頁"
                    });
                }

                this.RepPage.DataSource = pagingList;
                this.RepPage.DataBind();
            }
            else
            {
                TBpurid.Text = qid;

                PurchaseDBTool dBTool = new PurchaseDBTool();
                datepicker.Text = dBTool.GetPurchaseDate(qid);
                int page = (ProdStatic.noworder.Count / 10) + 1;
                var resultDB =
                    from orders in ProdStatic.noworder
                    where orders.OrderID > 0
                    orderby orders.OrderID descending
                    select orders;
                var resultTemp =
                    from orders in ProdStatic.noworder
                    where orders.OrderID < 0
                    orderby orders.OrderID
                    select orders;
                var result = resultTemp.ToList();
                foreach (var item in resultDB.ToList())
                {
                    result.Add(item);
                }
                RepOrders.DataSource = result.Skip(10 * (pIndex - 1)).Take(10);
                RepOrders.DataBind();


                LblTotal.Text = $"總計 NT{ProdStatic.Subtotal}";
                List<PageLink> pagingList = new List<PageLink>();
                HLFirst.NavigateUrl = $"PurchaseManage.aspx?ID={qid}&Page=1";
                int backpage = (pIndex - 1 <= 0) ? 1 : (pIndex - 1);
                HLBack.NavigateUrl = $"PurchaseManage.aspx?ID={qid}&Page={backpage}";
                int nextpage = (pIndex + 1 > page) ? page : (pIndex + 1);
                HLNext.NavigateUrl = $"PurchaseManage.aspx?ID={qid}&Page={nextpage}";
                HLLast.NavigateUrl = $"PurchaseManage.aspx?ID={qid}&Page={page}";

                for (var i = 1; i <= page; i++)
                {
                    pagingList.Add(new PageLink()
                    {
                        Link = $"PurchaseManage.aspx?ID={qid}&Page={i}",
                        Name = $"{i}",
                        Title = $"前往第 {i} 頁"
                    });
                }

                this.RepPage.DataSource = pagingList;
                this.RepPage.DataBind();
            }
        }

        public void BuildDDLCateCommit()
        {
            DDLCate.Items.Add(new ListItem() { Text = "請選擇", Value = "0" });
            PurchaseDBTool dBTool = new PurchaseDBTool();
            List<CategoryMaster> categories = dBTool.GetCategory();
            for (int i = 0; i < categories.Count; i++)
            {
                DDLCate.Items.Add
                    (new ListItem() { Text = $"{categories[i].category_name}", Value = $"{categories[i].category_id}" });
            }

        }

        protected void Btndel_Click(object sender, EventArgs e)
        {
            List<string> delorder = new List<string>();
            foreach (RepeaterItem item in RepOrders.Items)
            {
                CheckBox chk = item.FindControl("CBOrder") as CheckBox;
                if (chk.Checked)
                {
                    delorder.Add(chk.ToolTip);
                }
            }
            PurchaseDBTool dBTool = new PurchaseDBTool();
            dBTool.DelOrder(delorder);
            BuildDataTableCommitTemp();
        }

        protected void BtnDone_Click(object sender, EventArgs e)
        {
            string qid = Request.QueryString["ID"];
            PurchaseDBTool dBTool = new PurchaseDBTool();
            ContextModel context = new ContextModel();
            DateTime purdate = Convert.ToDateTime(datepicker.Text);
            var nowassests = context.Assets.Where(obj => obj.assets_id == 1).FirstOrDefault();
            decimal assests = nowassests.assets_total;
            if (string.IsNullOrEmpty(qid))
            {
                dBTool.InsertPurchase(TBpurid.Text, purdate, assests, ProdStatic.noworder);
                nowassests.assets_total = assests - ProdStatic.Subtotal;
                context.SaveChanges();
                ProdStatic.noworder.Clear();
                ProdStatic.Subtotal = 0;
                ProdStatic.TempID = 0;
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                dBTool.UpdatePurchase(qid, purdate, assests, ProdStatic.noworder);
                nowassests.assets_total = assests - ProdStatic.Subtotal;
                context.SaveChanges();
                ProdStatic.noworder.Clear();
                ProdStatic.Subtotal = 0;
                ProdStatic.TempID = 0;
                Response.Redirect("~/Index.aspx");
            }
        }

        protected void Btncancel_Click(object sender, EventArgs e)
        {
            ProdStatic.noworder.Clear();
            ProdStatic.Subtotal = 0;
            ProdStatic.TempID = 0;
            Response.Redirect("~/Index.aspx");
        }
    }
}