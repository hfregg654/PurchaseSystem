using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.ViewModels
{
    public class ProductView
    {
        public string ProuductID { get; set; }
        public string ProductCategory { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}