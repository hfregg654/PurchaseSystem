using PurchaseSystem.Models;
using PurchaseSystem.Utility;
using PurchaseSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PurchaseSystem
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProdStatic.noworder = new List<OrderView>();
            ProdStatic.Subtotal = 0;
            ProdStatic.TempID = 0;
            if (!IsPostBack)
            {
                BuildDataTableCommit();
            }
        }
        public void BuildDataTableCommit()
        {
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

            PurchaseDBTool dBTool = new PurchaseDBTool();
            int page;
            var result = dBTool.GetPurchase(out page, pIndex);
            RepPurchases.DataSource = result.Skip(10 * (pIndex - 1)).Take(10);
            RepPurchases.DataBind();


            List<PageLink> pagingList = new List<PageLink>();
            HLFirst.NavigateUrl = $"Index.aspx?Page=1";
            int backpage = (pIndex - 1 <= 0) ? 1 : (pIndex - 1);
            HLBack.NavigateUrl = $"Index.aspx?Page={backpage}";
            int nextpage = (pIndex + 1 > page) ? page : (pIndex + 1);
            HLNext.NavigateUrl = $"Index.aspx?Page={nextpage}";
            HLLast.NavigateUrl = $"Index.aspx?Page={page}";

            for (var i = 1; i <= page; i++)
            {
                pagingList.Add(new PageLink()
                {
                    Link = $"Index.aspx?Page={i}",
                    Name = $"{i}",
                    Title = $"前往第 {i} 頁"
                });
            }

            this.RepPage.DataSource = pagingList;
            this.RepPage.DataBind();
        }

        protected void BtnDel_Click(object sender, EventArgs e)
        {
            //LogInfo info = Session["IsLogined"] as LogInfo;
            //if (info == null)
            //{
            //    LoginHelper loginHelper = new LoginHelper();
            //    loginHelper.Logout();
            //    Response.Redirect("../Login.aspx");
            //}
            List<string> delpur = new List<string>();
            foreach (RepeaterItem item in RepPurchases.Items)
            {
                CheckBox chk = item.FindControl("CBPurchase") as CheckBox;
                if (chk.Checked)
                {
                    delpur.Add(chk.ToolTip);
                }
            }
            PurchaseDBTool dBTool = new PurchaseDBTool();
            dBTool.DelPurchase(delpur);
            BuildDataTableCommit();
        }
    }
}