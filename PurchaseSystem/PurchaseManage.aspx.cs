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
        IEnumerable<OrderView> noworder = new List<OrderView>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuildDataTableCommit();
                BuildDDLCateCommit();
            }
        }
        public void BuildDataTableCommit()
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

            }
            else
            {
                TBpurid.Text = qid;

                PurchaseDBTool dBTool = new PurchaseDBTool();
                datepicker.Text = dBTool.GetPurchaseDate(qid);
                decimal fullprice;
                int page;
                var result = dBTool.GetOrder(qid, out fullprice, out page, pIndex);
                noworder = result;
                RepOrders.DataSource = noworder;
                RepOrders.DataBind();


                LblTotal.Text = $"總計 NT{fullprice}";
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

        protected void DDLCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string category = DDLCate.SelectedValue;

            //PurchaseDBTool dBTool = new PurchaseDBTool();
            //RepProd.DataSource = dBTool.GetProduct(Convert.ToInt32(category));
            //RepProd.DataBind();

            //ClientScript.RegisterStartupScript(this.GetType(), "dialog", "$('#dialog').dialog('open');", true);
        }

      
    }
}