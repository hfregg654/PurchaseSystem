using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.ViewModels
{
    public static class ProdStatic
    {
        public static List<OrderView> noworder { get; set; }
        public static decimal Subtotal { get; set; }
        public static int TempID { get; set; }
    }
}