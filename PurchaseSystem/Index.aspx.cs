﻿using PurchaseSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurchaseSystem
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PurchaseDBTool dBTool = new PurchaseDBTool();
            int page;
            var result = dBTool.GetPurchase(out page);
            RepPurchases.DataSource = result;
            RepPurchases.DataBind();
        }
    }
}