
namespace PurchaseSystemWinForm
{
    partial class PurchaseManage
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
            this.btnaddp = new System.Windows.Forms.Button();
            this.btndelp = new System.Windows.Forms.Button();
            this.btncomplete = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBpurid = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.LblSubTotal = new System.Windows.Forms.Label();
            this.LblpID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnaddp
            // 
            this.btnaddp.BackColor = System.Drawing.Color.GreenYellow;
            this.btnaddp.Location = new System.Drawing.Point(30, 70);
            this.btnaddp.Margin = new System.Windows.Forms.Padding(1);
            this.btnaddp.Name = "btnaddp";
            this.btnaddp.Size = new System.Drawing.Size(83, 30);
            this.btnaddp.TabIndex = 16;
            this.btnaddp.Text = "＋";
            this.btnaddp.UseVisualStyleBackColor = false;
            this.btnaddp.Click += new System.EventHandler(this.btnaddp_Click);
            // 
            // btndelp
            // 
            this.btndelp.BackColor = System.Drawing.Color.LightPink;
            this.btndelp.Location = new System.Drawing.Point(115, 70);
            this.btndelp.Margin = new System.Windows.Forms.Padding(1);
            this.btndelp.Name = "btndelp";
            this.btndelp.Size = new System.Drawing.Size(83, 30);
            this.btndelp.TabIndex = 15;
            this.btndelp.Text = "－";
            this.btndelp.UseVisualStyleBackColor = false;
            this.btndelp.Click += new System.EventHandler(this.btndelp_Click);
            // 
            // btncomplete
            // 
            this.btncomplete.BackColor = System.Drawing.Color.GreenYellow;
            this.btncomplete.Location = new System.Drawing.Point(186, 570);
            this.btncomplete.Margin = new System.Windows.Forms.Padding(1);
            this.btncomplete.Name = "btncomplete";
            this.btncomplete.Size = new System.Drawing.Size(83, 30);
            this.btncomplete.TabIndex = 14;
            this.btncomplete.Text = "完成";
            this.btncomplete.UseVisualStyleBackColor = false;
            this.btncomplete.Click += new System.EventHandler(this.btncomplete_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.LightPink;
            this.btncancel.Location = new System.Drawing.Point(30, 570);
            this.btncancel.Margin = new System.Windows.Forms.Padding(1);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(83, 30);
            this.btncancel.TabIndex = 13;
            this.btncancel.Text = "取消";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(399, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 60);
            this.label1.TabIndex = 12;
            this.label1.Text = "進貨單管理";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1078, 366);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(577, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 27);
            this.label2.TabIndex = 19;
            this.label2.Text = "進貨時間：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(35, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 27);
            this.label3.TabIndex = 18;
            this.label3.Text = "單據編號：";
            // 
            // TBpurid
            // 
            this.TBpurid.Enabled = false;
            this.TBpurid.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TBpurid.Location = new System.Drawing.Point(197, 119);
            this.TBpurid.Margin = new System.Windows.Forms.Padding(1);
            this.TBpurid.Name = "TBpurid";
            this.TBpurid.Size = new System.Drawing.Size(265, 39);
            this.TBpurid.TabIndex = 17;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker1.Location = new System.Drawing.Point(746, 119);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(271, 39);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // LblSubTotal
            // 
            this.LblSubTotal.AutoSize = true;
            this.LblSubTotal.Font = new System.Drawing.Font("新細明體", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LblSubTotal.Location = new System.Drawing.Point(719, 546);
            this.LblSubTotal.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.LblSubTotal.Name = "LblSubTotal";
            this.LblSubTotal.Size = new System.Drawing.Size(100, 27);
            this.LblSubTotal.TabIndex = 21;
            this.LblSubTotal.Text = "總計NT";
            // 
            // LblpID
            // 
            this.LblpID.AutoSize = true;
            this.LblpID.Location = new System.Drawing.Point(143, 45);
            this.LblpID.Name = "LblpID";
            this.LblpID.Size = new System.Drawing.Size(30, 15);
            this.LblpID.TabIndex = 22;
            this.LblpID.Text = "PID";
            this.LblpID.Visible = false;
            // 
            // PurchaseManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 652);
            this.Controls.Add(this.LblpID);
            this.Controls.Add(this.LblSubTotal);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBpurid);
            this.Controls.Add(this.btnaddp);
            this.Controls.Add(this.btndelp);
            this.Controls.Add(this.btncomplete);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PurchaseManage";
            this.Text = "PurchaseManage";
            this.Load += new System.EventHandler(this.PurchaseManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnaddp;
        private System.Windows.Forms.Button btndelp;
        private System.Windows.Forms.Button btncomplete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBpurid;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label LblSubTotal;
        private System.Windows.Forms.Label LblpID;
    }
}