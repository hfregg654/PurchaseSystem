using Newtonsoft.Json;
using PurchaseSystem.Utility;
using PurchaseSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.API
{
    /// <summary>
    /// POPGetProuductHandler 的摘要描述
    /// </summary>
    public class POPGetProuductHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string Category = context.Request.Form["Category"];
            string Num = context.Request.Form["Num"];
            string Price = context.Request.Form["Price"];
            if (!string.IsNullOrWhiteSpace(Category))
            {
                PurchaseDBTool dBTool = new PurchaseDBTool();
                List<ProductView> prouducts = dBTool.GetProduct(Convert.ToInt32(Category));

                string result = JsonConvert.SerializeObject(prouducts);
                context.Response.ContentType = "text/json";
                context.Response.Write(result);
            }
            else if (!string.IsNullOrWhiteSpace(Num))
            {
                context.Response.Write(Convert.ToDecimal(Price)*Convert.ToInt32(Num));
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}