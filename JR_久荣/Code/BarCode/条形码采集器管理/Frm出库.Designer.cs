namespace BarCode
{
    partial class Frm出库
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txt单据号 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn返回 = new System.Windows.Forms.Button();
            this.lSum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(2560, 1377);
            this.msgBox.Location = new System.Drawing.Point(-9, -9);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 74);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(632, 378);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Click += new System.EventHandler(this.dataGrid1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(4, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 20);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(61, 28);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(42, 20);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "删行";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(121, 28);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(42, 20);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txt单据号
            // 
            this.txt单据号.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt单据号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt单据号.Location = new System.Drawing.Point(73, 3);
            this.txt单据号.Name = "txt单据号";
            this.txt单据号.Size = new System.Drawing.Size(554, 19);
            this.txt单据号.TabIndex = 34;
            this.txt单据号.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt单据号_KeyUp);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(4, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.Text = "发货单号";
            // 
            // btn返回
            // 
            this.btn返回.Location = new System.Drawing.Point(182, 28);
            this.btn返回.Name = "btn返回";
            this.btn返回.Size = new System.Drawing.Size(42, 20);
            this.btn返回.TabIndex = 40;
            this.btn返回.Text = "返回";
            this.btn返回.Click += new System.EventHandler(this.btn返回_Click);
            // 
            // lSum
            // 
            this.lSum.Location = new System.Drawing.Point(3, 51);
            this.lSum.Name = "lSum";
            this.lSum.Size = new System.Drawing.Size(177, 20);
            this.lSum.Text = "label1";
            // 
            // Frm出库
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.lSum);
            this.Controls.Add(this.btn返回);
            this.Controls.Add(this.txt单据号);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGrid1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Frm出库";
            this.Text = "出库";
            this.Load += new System.EventHandler(this.Frm出库_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txt单据号;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn返回;
        private System.Windows.Forms.Label lSum;
    }
}