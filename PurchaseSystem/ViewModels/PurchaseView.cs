using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.ViewModels
{
    public class PurchaseView
    {
        public string PurchaseID { get; set; }
        public string PCategory { get; set; }
        public int TotalNum { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalMoney { get; set; }
    }
}