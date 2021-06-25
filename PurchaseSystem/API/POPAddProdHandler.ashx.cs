using PurchaseSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.API
{
    /// <summary>
    /// POPAddProdHandler 的摘要描述
    /// </summary>
    public class POPAddProdHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ProductName = context.Request.Form["ProductName"];
            string OrderNum = context.Request.Form["OrderNum"];
            string ProductPrice = context.Request.Form["ProductPrice"];
            string ProuductID = context.Request.Form["ProuductID"];
            
            ProdStatic.TempID--;
            OrderView order = new OrderView()
            {
                OrderID = ProdStatic.TempID,
                ProductName = ProductName,
                ProuductID = ProuductID,
                OrderNum = Convert.ToInt32(OrderNum),
                ProductPrice = Convert.ToDecimal(ProductPrice)
            };
            ProdStatic.Subtotal += order.TotalPrice;
            ProdStatic.noworder.Add(order);

            context.Response.Write(0);
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