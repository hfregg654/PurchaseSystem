
namespace PurchaseSystemWinForm
{
    partial class AddProuduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblcate = new System.Windows.Forms.Label();
            this.purchaseSystemDataSet = new PurchaseSystemWinForm.PurchaseSystemDataSet();
            this.categoryMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryMasterTableAdapter = new PurchaseSystemWinForm.PurchaseSystemDataSetTableAdapters.CategoryMasterTableAdapter();
            this.btnaddp = new System.Windows.Forms.Button();
            this.btncancelp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBpnum = new System.Windows.Forms.TextBox();
            this.lblProd = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryMasterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.categoryMasterBindingSource, "category_id", true));
            this.comboBox1.DataSource = this.categoryMasterBindingSource;
            this.comboBox1.DisplayMember = "category_name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(194, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(161, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "category_id";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(462, 235);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // lblcate
            // 
            this.lblcate.AutoSize = true;
            this.lblcate.Location = new System.Drawing.Point(121, 30);
            this.lblcate.Name = "lblcate";
            this.lblcate.Size = new System.Drawing.Size(67, 15);
            this.lblcate.TabIndex = 2;
            this.lblcate.Text = "貨物種類";
            // 
            // purchaseSystemDataSet
            // 
            this.purchaseSystemDataSet.DataSetName = "PurchaseSystemDataSet";
            this.purchaseSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryMasterBindingSource
            // 
            this.categoryMasterBindingSource.DataMember = "CategoryMaster";
            this.categoryMasterBindingSource.DataSource = this.purchaseSystemDataSet;
            // 
            // categoryMasterTableAdapter
            // 
            this.categoryMasterTableAdapter.ClearBeforeFill = true;
            // 
            // btnaddp
            // 
            this.btnaddp.BackColor = System.Drawing.Color.GreenYellow;
            this.btnaddp.Location = new System.Drawing.Point(83, 467);
            this.btnaddp.Margin = new System.Windows.Forms.Padding(1);
            this.btnaddp.Name = "btnaddp";
            this.btnaddp.Size = new System.Drawing.Size(83, 30);
            this.btnaddp.TabIndex = 18;
            this.btnaddp.Text = "加入";
            this.btnaddp.UseVisualStyleBackColor = false;
            this.btnaddp.Click += new System.EventHandler(this.btnaddp_Click);
            // 
            // btncancelp
            // 
            this.btncancelp.BackColor = System.Drawing.Color.LightPink;
            this.btncancelp.Location = new System.Drawing.Point(317, 467);
            this.btncancelp.Margin = new System.Windows.Forms.Padding(1);
            this.btncancelp.Name = "btncancelp";
            this.btncancelp.Size = new System.Drawing.Size(83, 30);
            this.btncancelp.TabIndex = 17;
            this.btncancelp.Text = "取消";
            this.btncancelp.UseVisualStyleBackColor = false;
            this.btncancelp.Click += new System.EventHandler(this.btncancelp_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(54, 322);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 27);
            this.label3.TabIndex = 19;
            this.label3.Text = "已挑選商品：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(135, 369);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 20;
            this.label1.Text = "數量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(135, 415);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 27);
            this.label2.TabIndex = 21;
            this.label2.Text = "小計：";
            // 
            // TBpnum
            // 
            this.TBpnum.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TBpnum.Location = new System.Drawing.Point(234, 357);
            this.TBpnum.Margin = new System.Windows.Forms.Padding(1);
            this.TBpnum.Name = "TBpnum";
            this.TBpnum.Size = new System.Drawing.Size(166, 39);
            this.TBpnum.TabIndex = 22;
            this.TBpnum.TextChanged += new System.EventHandler(this.TBpnum_TextChanged);
            this.TBpnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBpurid_KeyPress);
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblProd.Location = new System.Drawing.Point(230, 322);
            this.lblProd.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(0, 27);
            this.lblProd.TabIndex = 23;
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbltotal.Location = new System.Drawing.Point(230, 415);
            this.lbltotal.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(59, 27);
            this.lbltotal.TabIndex = 24;
            this.lbltotal.Text = "NT0";
            // 
            // AddProuduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 526);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.TBpnum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnaddp);
            this.Controls.Add(this.btncancelp);
            this.Controls.Add(this.lblcate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Name = "AddProuduct";
            this.Text = "AddProuduct";
            this.Load += new System.EventHandler(this.AddProuduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryMasterBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblcate;
        private PurchaseSystemDataSet purchaseSystemDataSet;
        private System.Windows.Forms.BindingSource categoryMasterBindingSource;
        private PurchaseSystemDataSetTableAdapters.CategoryMasterTableAdapter categoryMasterTableAdapter;
        private System.Windows.Forms.Button btnaddp;
        private System.Windows.Forms.Button btncancelp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBpnum;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label lbltotal;
    }
}