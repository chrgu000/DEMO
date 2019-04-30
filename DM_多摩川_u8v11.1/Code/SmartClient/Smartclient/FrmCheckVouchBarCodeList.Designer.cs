namespace Smartclient
{
    partial class FrmCheckVouchBarCodeList
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBarCodeCount = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEnSure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(186, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(36, 20);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "返回";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.Text = "扫描条数";
            // 
            // labelBarCodeCount
            // 
            this.labelBarCodeCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelBarCodeCount.Location = new System.Drawing.Point(67, 9);
            this.labelBarCodeCount.Name = "labelBarCodeCount";
            this.labelBarCodeCount.Size = new System.Drawing.Size(113, 20);
            this.labelBarCodeCount.Text = "labelBarCodeCount";
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 58);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(234, 207);
            this.dataGrid1.TabIndex = 18;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(67, 32);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(36, 20);
            this.btnDel.TabIndex = 21;
            this.btnDel.Text = "删行";
            this.btnDel.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnEnSure
            // 
            this.btnEnSure.Location = new System.Drawing.Point(129, 32);
            this.btnEnSure.Name = "btnEnSure";
            this.btnEnSure.Size = new System.Drawing.Size(36, 20);
            this.btnEnSure.TabIndex = 22;
            this.btnEnSure.Text = "确定";
            this.btnEnSure.Click += new System.EventHandler(this.btnEnSure_Click);
            // 
            // FrmCheckVouchBarCodeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnEnSure);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.labelBarCodeCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmCheckVouchBarCodeList";
            this.Text = "盘点单条形码明细";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBarCodeCount;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEnSure;
    }
}