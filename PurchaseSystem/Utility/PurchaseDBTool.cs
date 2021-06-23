using PurchaseSystem.Models;
using PurchaseSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSystem.Utility
{
    public class PurchaseDBTool
    {

        public IEnumerable<PurchaseView> GetPurchase(out int TotalPage, int currentPage = 1, int pageSize = 10)
        {

            using (var context = new ContextModel())
            {
                var query =
                         from purchases in context.Purchases
                         join orders in context.orders on purchases.pur_id equals orders.order_purid
                         join prouducts in context.Prouducts on orders.order_prodid equals prouducts.prod_id
                         join categoryM in context.CategoryMasters on prouducts.prod_categoryid equals categoryM.category_id
                         where purchases.pur_deldate == null
                         select new
                         {
                             purchases.pur_id,
                             categoryM.category_name,
                             orders.order_num,
                             purchases.pur_purdate,
                             purchases.pur_total
                         };
                var result = query.ToList();

                List<PurchaseView> lastresult = new List<PurchaseView>();
                foreach (var item in result)
                {
                    if (lastresult.Count == 0)
                    {
                        PurchaseView Temp = new PurchaseView()
                        {
                            PurchaseID = item.pur_id,
                            PCategory = item.category_name,
                            TotalNum = item.order_num,
                            PurchaseDate = item.pur_purdate,
                            TotalMoney = item.pur_total
                        };
                        lastresult.Add(Temp);
                    }
                    else
                    {
                        bool isadd = false;
                        foreach (var itemcheck in lastresult)
                        {
                            if (item.pur_id == itemcheck.PurchaseID)
                            {
                                itemcheck.PCategory = "多項";
                                itemcheck.TotalNum += item.order_num;
                                isadd = true;
                            }
                        }
                        if (isadd == false)
                        {
                            PurchaseView Temp = new PurchaseView()
                            {
                                PurchaseID = item.pur_id,
                                PCategory = item.category_name,
                                TotalNum = item.order_num,
                                PurchaseDate = item.pur_purdate,
                                TotalMoney = item.pur_total
                            };
                            lastresult.Add(Temp);
                        }
                    }
                }
                TotalPage = (lastresult.Count / pageSize) + 1;
                return lastresult.Skip(pageSize * (currentPage - 1)).Take(10);
            }
        }
    }
}