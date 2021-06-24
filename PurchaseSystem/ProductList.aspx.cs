using PurchaseSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurchaseSystem
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PurchaseDBTool dBTool = new PurchaseDBTool();
                RepProuduct.DataSource = dBTool.GetProduct();
                RepProuduct.DataBind();
            }
        }
    }
}