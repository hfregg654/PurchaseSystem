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
                         orderby purchases.pur_credate descending
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
                return lastresult.Skip(pageSize * (currentPage - 1)).Take(pageSize);
            }
        }

        public void DelPurchase(List<string> delpur)
        {
            LogInfo info = HttpContext.Current.Session["IsLogined"] as LogInfo;
            if (info == null)
            {
                return;
            }
            using (var context = new ContextModel())
            {
                foreach (var item in delpur)
                {
                    var delpurchase =
                         context.Purchases.Where(obj => obj.pur_id == item && obj.pur_deldate == null).FirstOrDefault();
                    var delorder =
                        context.orders.Where(obj => obj.order_purid == item && obj.order_delflag == false).ToArray();
                    if (delorder.Length > 0 && delpurchase != null)
                    {
                        foreach (var delod in delorder)
                        {
                            delod.order_delflag = true;
                        }
                        delpurchase.pur_delid = info.user_id;
                        delpurchase.pur_deldate = DateTime.Now;
                    }
                }
                context.SaveChanges();
            }
        }

        public List<ProductView> GetProduct()
        {
            using (var context = new ContextModel())
            {
                var prouductslist =
                     from prouducts in context.Prouducts
                     join categoryM in context.CategoryMasters on prouducts.prod_categoryid equals categoryM.category_id
                     select new ProductView
                     {
                         ProuductID = prouducts.prod_id,
                         ProductCategory = categoryM.category_name,
                         ProductName = prouducts.prod_name,
                         ProductPrice = prouducts.prod_price
                     };
                return prouductslist.ToList();
            }
        }
        public List<ProductView> GetProduct(int category)
        {
            using (var context = new ContextModel())
            {
                var prouductslist =
                     from prouducts in context.Prouducts
                     where prouducts.prod_categoryid == category
                     select new ProductView
                     {
                         ProuductID = prouducts.prod_id,
                         ProductName = prouducts.prod_name,
                         ProductPrice = prouducts.prod_price,
                         ProductCategory = ""
                     };
                if (prouductslist.ToList().Count > 0)
                {
                    return prouductslist.ToList();
                }
                else
                {
                    return null;
                }

            }
        }
        public List<CategoryMaster> GetCategory()
        {
            using (var context = new ContextModel())
            {
                return context.CategoryMasters.ToList();
            }
        }

        public string GetPurchaseDate(string purid)
        {
            using (var context = new ContextModel())
            {
                var date =
                     from purchases in context.Purchases
                     where purchases.pur_id == purid
                     select purchases.pur_purdate;

                return date.FirstOrDefault().ToString("yyyy-MM-dd HH:mm");
            }
        }

        public IEnumerable<OrderView> GetOrder(string purid, out decimal FullPrice, out int TotalPage, int currentPage = 1, int pageSize = 10)
        {
            using (var context = new ContextModel())
            {
                var orderslist =
                     from orders in context.orders
                     join prouducts in context.Prouducts on orders.order_prodid equals prouducts.prod_id
                     where orders.order_purid == purid
                     select new OrderView
                     {
                         OrderID = orders.order_id,
                         ProuductID = orders.order_prodid,
                         ProductName = prouducts.prod_name,
                         OrderNum = orders.order_num,
                         ProductPrice = prouducts.prod_price
                     };
                List<OrderView> result = orderslist.ToList();

                FullPrice = 0;
                foreach (var item in result)
                {
                    FullPrice += item.TotalPrice;
                }
                TotalPage = (result.Count / pageSize) + 1;
                return result.Skip(pageSize * (currentPage - 1)).Take(pageSize); ;
            }
        }
    }
}