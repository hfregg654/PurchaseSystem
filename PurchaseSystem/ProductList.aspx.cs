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
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProdStatic.noworder = new List<OrderView>();
            ProdStatic.Subtotal = 0;
            ProdStatic.TempID = 0;
            if (!IsPostBack)
            {
                PurchaseDBTool dBTool = new PurchaseDBTool();
                RepProuduct.DataSource = dBTool.GetProduct();
                RepProuduct.DataBind();
            }
        }
    }
}