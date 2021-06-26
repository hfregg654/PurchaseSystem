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
    public partial class AddProuduct : Form
    {
        public AddProuduct()
        {
            InitializeComponent();
        }
        public PurchaseManage mainform = null;
        decimal price;
        string pid;
        private void AddProuduct_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'purchaseSystemDataSet.CategoryMaster' 資料表。您可以視需要進行移動或移除。
            this.categoryMasterTableAdapter.Fill(this.purchaseSystemDataSet.CategoryMaster);
            comboBox1.SelectedIndex = 0;
            BuildDataTableCommit();

        }

        private void BuildDataTableCommit()
        {
            using (var context = new ContextModel())
            {
                int CateID;
                if (comboBox1.SelectedValue != null)
                {
                    CateID = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                    var prouductlist =
                     from prods in context.Prouducts
                     where prods.prod_categoryid == CateID
                     select prods;

                    dataGridView1.DataSource = prouductlist.ToList();
                    lblProd.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    pid = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    price = Convert.ToDecimal(dataGridView1.Rows[0].Cells[2].Value);
                    int num;
                    if (int.TryParse(TBpnum.Text, out num))
                    {
                        lbltotal.Text = (price * num).ToString();
                    }
                    else
                    {
                        lbltotal.Text = (price * 0).ToString();
                    }
                }
                else
                {
                    return;
                }
            }

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                lblProd.Text = row.Cells[1].Value.ToString();
                pid = row.Cells[0].Value.ToString();
                price = Convert.ToDecimal(row.Cells[2].Value);
                int num;
                if (int.TryParse(TBpnum.Text, out num))
                {
                    lbltotal.Text = (price * num).ToString();
                }
                else
                {
                    lbltotal.Text = (price * 0).ToString();
                }
            }
        }

        private void TBpurid_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildDataTableCommit();
        }

        private void TBpnum_TextChanged(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(TBpnum.Text, out num))
            {
                lbltotal.Text = "NT" + (price * num).ToString();
            }
            else
            {
                lbltotal.Text = "NT" + (price * 0).ToString();
            }
        }

        private void btncancelp_Click(object sender, EventArgs e)
        {
            mainform.Show();
            this.Close();
        }

        private void btnaddp_Click(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(TBpnum.Text, out num))
            {
            }
            ProdStatic.TempID--;
            OrderView order = new OrderView()
            {
                OrderID = ProdStatic.TempID,
                ProductName = lblProd.Text,
                ProuductID = pid,
                OrderNum = Convert.ToInt32(TBpnum.Text),
                ProductPrice = price
            };
            ProdStatic.Subtotal += order.TotalPrice;
            ProdStatic.noworder.Add(order);
            mainform.Show();
            mainform.BuildDataTableCommitTemp();
            this.Close();
        }
    }
}
