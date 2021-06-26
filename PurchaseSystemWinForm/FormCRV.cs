using PurchaseSystem;
using PurchaseSystem.Models;
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
    public partial class FormCRV : Form
    {
        public FormCRV()
        {
            InitializeComponent();
        }

        private void FormCRV_Load(object sender, EventArgs e)
        {
            using (var context = new ContextModel())
            {
                var rep =
                     (from obj in context.Purchases
                      where obj.pur_deldate == null
                      select new { obj.pur_id, obj.pur_total, obj.pur_purdate, obj.pur_credate }).ToList();

                PurchaseCrystalReport cr = new PurchaseCrystalReport();
                cr.SetDataSource(rep);

                crystalReportViewer1.ReportSource = cr;

            }
        }
    }
}
