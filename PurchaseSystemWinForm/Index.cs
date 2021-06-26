using PurchaseSystem;
using PurchaseSystem.Models;
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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }
        public Login main = null;
        private void Index_Load(object sender, EventArgs e)
        {
            ProdStatic.noworder = new List<OrderView>();
            ProdStatic.Subtotal = 0;
            ProdStatic.TempID = 0;

            BuildDataTableCommit();
            label2.Text = "歡迎" + Program.wLogInfo.user_acc;
            LblPID.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();

        }

        public void BuildDataTableCommit()
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
                Dictionary<string, string> catenum = new Dictionary<string, string>();
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
                        catenum.Add(item.pur_id, item.category_name);
                    }
                    else
                    {
                        bool isadd = false;
                        foreach (var itemcheck in lastresult)
                        {
                            if (item.pur_id == itemcheck.PurchaseID)
                            {
                                if (catenum.ContainsKey(item.pur_id))
                                {
                                    if (catenum[item.pur_id].Contains(item.category_name))
                                    {
                                        itemcheck.TotalNum += item.order_num;
                                        isadd = true;
                                    }
                                    else
                                    {
                                        catenum[item.pur_id] += $",{item.category_name}";
                                        itemcheck.PCategory = $"多項({catenum[item.pur_id].Split(',').Length})";
                                        itemcheck.TotalNum += item.order_num;
                                        isadd = true;
                                    }
                                }
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
                            catenum.Add(item.pur_id, item.category_name);
                        }
                    }

                    dataGridView1.DataSource = lastresult.ToList();

                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.wLogInfo.user_id = 0;
            Program.wLogInfo.user_pri = null;
            Program.wLogInfo.user_acc = null;

            main.Show();
            this.Close();
        }

        private void btnoutput_Click(object sender, EventArgs e)
        {
            FormCRV formCRV = new FormCRV();
            formCRV.Show();
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            PurchaseManage purchaseManage = new PurchaseManage();
            purchaseManage.mainform = this;
            purchaseManage.Show();
            this.Hide();
        }

        private void buttondel_Click(object sender, EventArgs e)
        {
            if (DelCancel() == true)
            {
                using (var context = new ContextModel())
                {

                    var delpurchase =
                         context.Purchases.Where(obj => obj.pur_id == LblPID.Text && obj.pur_deldate == null).FirstOrDefault();
                    var delorder =
                        context.orders.Where(obj => obj.order_purid == LblPID.Text && obj.order_delflag == false).ToArray();
                    if (delorder.Length > 0 && delpurchase != null)
                    {
                        foreach (var delod in delorder)
                        {
                            delod.order_delflag = true;
                        }
                        delpurchase.pur_delid = Program.wLogInfo.user_id;
                        delpurchase.pur_deldate = DateTime.Now;
                    }
                    context.SaveChanges();
                }
                BuildDataTableCommit();
                LblPID.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
        }



        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                LblPID.Text = row.Cells[0].Value.ToString();
            }
        }

        public static bool DelCancel()
        {
            const string message = "確定刪除選擇的進貨單?";
            const string caption = "Cancel Installer";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PurchaseManage purchaseManage = new PurchaseManage();
            purchaseManage.mainform = this;
            purchaseManage.ID = LblPID.Text;
            purchaseManage.Show();
            this.Hide();
        }
    }
}
