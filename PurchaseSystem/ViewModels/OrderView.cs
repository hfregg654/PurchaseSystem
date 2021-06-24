using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.ViewModels
{
    public class OrderView
    {
        public int OrderID { get; set; }
        public string ProuductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int OrderNum { get; set; }
        public decimal TotalPrice { get { return ProductPrice * OrderNum; } }

    }
}