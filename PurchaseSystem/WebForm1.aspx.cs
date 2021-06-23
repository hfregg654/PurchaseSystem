using PurchaseSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurchaseSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PurchaseDBTool dBTool = new PurchaseDBTool();
            int page;
            var a= dBTool.GetPurchase(out page);
            Repeater1.DataSource = a;
            Repeater1.DataBind();
        }
    }
}