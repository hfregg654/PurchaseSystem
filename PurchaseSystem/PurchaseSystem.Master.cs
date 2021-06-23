using PurchaseSystem.Models;
using PurchaseSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurchaseSystem
{
    public partial class PurchaseSystem : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogInfo info = Session["IsLogined"] as LogInfo;
            if (info != null)
            {
                if (info.user_acc.Length>10)
                {
                    Label1.Text = $"歡迎！{info.user_acc.Substring(0,10)}...";
                }
                else
                {
                    Label1.Text = $"歡迎！{info.user_acc}";
                }
            }
            else
            {
                Label1.Text = "";
            }
        }

        protected void LBLogout_Click(object sender, EventArgs e)
        {
            LoginHelper helper = new LoginHelper();
            helper.Logout();
            Response.Redirect("~/Login.aspx");
        }
    }
}