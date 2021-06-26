using PurchaseSystem.Models;
using PurchaseSystem.Utility;
using PurchaseSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PurchaseSystemWinForm
{
    public partial class PurchaseManage : Form
    {
        public PurchaseManage()
        {
            InitializeComponent();
        }
        public Index mainform = null;
        public string ID = null;
        private void PurchaseManage_Load(object sender, EventArgs e)
        {
            if (ProdStatic.TempID == 0)
            {
                BuildDataTableCommit();
            }
            else
            {
                BuildDataTableCommitTemp();
            }
        }

        public void BuildDataTableCommitTemp()
        {
            var resultDB =
                from orders in ProdStatic.noworder
                where orders.OrderID > 0
                orderby orders.OrderID descending
                select orders;
            var resultTemp =
                from orders in ProdStatic.noworder
                where orders.OrderID < 0
                orderby orders.OrderID
                select orders;
            var result = resultTemp.ToList();
            foreach (var item in resultDB.ToList())
            {
                result.Add(item);
            }
            dataGridView1.DataSource = result.ToList();
            LblSubTotal.Text = "總計NT" + ProdStatic.Subtotal.ToString();
        }

        private void BuildDataTableCommit()
        {
            if (string.IsNullOrWhiteSpace(ID))
            {
                DateTime nowtime = DateTime.Now;
                TBpurid.Text = $"ASN-{nowtime.ToString("yyyyMMddHHmm")}-{Program.wLogInfo.user_id}";
                dateTimePicker1.Text = nowtime.ToString("yyyy-MM-dd HH:mm");

                ProdStatic.Subtotal = 0;
                ProdStatic.noworder = new List<OrderView>();

                LblSubTotal.Text = "總計NT0";
            }
            else
            {
                TBpurid.Text = ID;

                PurchaseDBTool dBTool = new PurchaseDBTool();
                dateTimePicker1.Text = dBTool.GetPurchaseDate(ID);
                decimal fullprice;

                using (var context = new ContextModel())
                {
                    var orderslist =
                         from orders in context.orders
                         join prouducts in context.Prouducts on orders.order_prodid equals prouducts.prod_id
                         where orders.order_purid == ID && orders.order_delflag == false
                         orderby orders.order_id descending
                         select new OrderView
                         {
                             OrderID = orders.order_id,
                             ProuductID = orders.order_prodid,
                             ProductName = prouducts.prod_name,
                             OrderNum = orders.order_num,
                             ProductPrice = prouducts.prod_price
                         };
                    List<OrderView> result = orderslist.ToList();

                    fullprice = 0;
                    foreach (var item in result)
                    {
                        fullprice += item.TotalPrice;
                    }
                    ProdStatic.Subtotal = fullprice;
                    ProdStatic.noworder = result;
                    dataGridView1.DataSource = ProdStatic.noworder.ToList();
                }

                LblSubTotal.Text = "總計NT" + ProdStatic.Subtotal.ToString();
                LblpID.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
        }

        public static bool DelCancel()
        {
            const string message = "確定刪除選擇的訂單?";
            const string caption = "Cancel Installer";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
        public static bool Completecheck()
        {
            const string message = "確定完成進貨單?";
            const string caption = "Cancel Installer";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void btnaddp_Click(object sender, EventArgs e)
        {
            AddProuduct selectform = new AddProuduct();
            selectform.mainform = this;
            selectform.Show();
        }

        private void btndelp_Click(object sender, EventArgs e)
        {
            if (DelCancel() == true)
            {
                using (var context = new ContextModel())
                {
                    int idtemp = Convert.ToInt32(LblpID.Text);
                    if (idtemp > 0)
                    {
                        var delorder =
                            context.orders.Where(obj => obj.order_id == idtemp && obj.order_delflag == false).FirstOrDefault();
                        if (delorder != null)
                        {
                            delorder.order_delflag = true;
                            var prodprice =
                                context.Prouducts.Where(obj => obj.prod_id == delorder.order_prodid).FirstOrDefault();

                            ProdStatic.Subtotal -= prodprice.prod_price * delorder.order_num;
                            ProdStatic.noworder.Remove(ProdStatic.noworder.Where(obj => obj.OrderID == idtemp).FirstOrDefault());
                        }

                    }
                    else
                    {
                        var selectorder = ProdStatic.noworder.Where(obj => obj.OrderID == idtemp).FirstOrDefault();
                        ProdStatic.Subtotal -= selectorder.ProductPrice * selectorder.OrderNum;
                        ProdStatic.noworder.Remove(selectorder);
                    }

                    context.SaveChanges();
                }
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            mainform.Show();
            mainform.BuildDataTableCommit();
            this.Close();
        }

        private void btncomplete_Click(object sender, EventArgs e)
        {
            if (Completecheck() == true)
            {
                using (var context = new ContextModel())
                {
                    DateTime purdate = Convert.ToDateTime(dateTimePicker1.Text);
                    var nowassests = context.Assets.Where(obj => obj.assets_id == 1).FirstOrDefault();
                    decimal assests = nowassests.assets_total;
                    if (string.IsNullOrEmpty(ID))
                    {

                        var updpurchase =
                                 context.Purchases.Where(obj => obj.pur_id == TBpurid.Text && obj.pur_deldate == null).FirstOrDefault();
                        if (updpurchase == null)
                        {
                            Purchase addpur = new Purchase()
                            {
                                pur_id = TBpurid.Text,
                                pur_purdate = purdate,
                                pur_total = ProdStatic.Subtotal,
                                pur_assets = assests - ProdStatic.Subtotal,
                                pur_credate = DateTime.Now,
                                pur_creid = Program.wLogInfo.user_id,

                            };
                            context.Purchases.Add(addpur);
                        }
                        else
                        {
                            return;
                        }
                        foreach (var item in ProdStatic.noworder)
                        {
                            var updorder =
                                context.orders.Where(obj => obj.order_id == item.OrderID && obj.order_delflag == false).FirstOrDefault();
                            if (updorder == null)
                            {
                                context.orders.Add(new order
                                {
                                    order_purid = TBpurid.Text,
                                    order_prodid = item.ProuductID,
                                    order_num = item.OrderNum,
                                    order_delflag = false
                                });
                            }
                        }
                        nowassests.assets_total = assests - ProdStatic.Subtotal;
                    }
                    else
                    {
                        var updpurchase =
                        context.Purchases.Where(obj => obj.pur_id == ID && obj.pur_deldate == null).FirstOrDefault();
                        decimal lastassets = assests + updpurchase.pur_total;
                        if (updpurchase != null)
                        {
                            updpurchase.pur_purdate = purdate;
                            updpurchase.pur_total = ProdStatic.Subtotal;
                            updpurchase.pur_assets = lastassets - ProdStatic.Subtotal;
                            updpurchase.pur_update = DateTime.Now;
                            updpurchase.pur_upid = Program.wLogInfo.user_id;
                        }
                        else
                        {
                            return;
                        }
                        foreach (var item in ProdStatic.noworder)
                        {
                            var updorder =
                                context.orders.Where(obj => obj.order_id == item.OrderID && obj.order_delflag == false).FirstOrDefault();
                            if (updorder == null)
                            {
                                context.orders.Add(new order
                                {
                                    order_purid = ID,
                                    order_prodid = item.ProuductID,
                                    order_num = item.OrderNum,
                                    order_delflag = false
                                });
                            }
                        }
                        nowassests.assets_total = assests - ProdStatic.Subtotal;
                    }
                    context.SaveChanges();
                    ProdStatic.noworder.Clear();
                    ProdStatic.Subtotal = 0;
                    ProdStatic.TempID = 0;
                    mainform.Show();
                    mainform.BuildDataTableCommit();
                    this.Close();
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                LblpID.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
