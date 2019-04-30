namespace BarCode
{
    partial class Frm材料出库单核查
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
            this.btnClose = new System.Windows.Forms.Button();
            this.txt单据号 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1366, 719);
            this.msgBox.Location = new System.Drawing.Point(-4, -4);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(268, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 20);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "返回";
            this.btnClose.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txt单据号
            // 
            this.txt单据号.Enabled = false;
            this.txt单据号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt单据号.Location = new System.Drawing.Point(70, 19);
            this.txt单据号.Name = "txt单据号";
            this.txt单据号.Size = new System.Drawing.Size(181, 19);
            this.txt单据号.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(14, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.Text = "生产订单";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(0, 53);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(320, 214);
            this.dataGrid1.TabIndex = 45;
            // 
            // Frm材料出库单核查
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(320, 270);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.txt单据号);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnClose);
            this.KeyPreview = true;
            this.Menu = null;
            this.Name = "Frm材料出库单核查";
            this.Text = "未出库材料";
            this.Load += new System.EventHandler(this.Frm材料出库单核查_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm材料出库单核查_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txt单据号;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGrid dataGrid1;
    }
}