namespace BarCode
{
    partial class Frm其他出库
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
            this.txt条形码 = new System.Windows.Forms.TextBox();
            this.btn删行 = new System.Windows.Forms.Button();
            this.btn保存 = new System.Windows.Forms.Button();
            this.date单据日期 = new System.Windows.Forms.DateTimePicker();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(3840, 2083);
            this.msgBox.Location = new System.Drawing.Point(-9, -9);
            // 
            // txt条形码
            // 
            this.txt条形码.Location = new System.Drawing.Point(5, 72);
            this.txt条形码.Name = "txt条形码";
            this.txt条形码.Size = new System.Drawing.Size(192, 25);
            this.txt条形码.TabIndex = 2;
            this.txt条形码.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt条形码_KeyUp);
            // 
            // btn删行
            // 
            this.btn删行.Location = new System.Drawing.Point(5, 42);
            this.btn删行.Name = "btn删行";
            this.btn删行.Size = new System.Drawing.Size(47, 20);
            this.btn删行.TabIndex = 4;
            this.btn删行.Text = "删行";
            this.btn删行.Click += new System.EventHandler(this.btn删行_Click);
            // 
            // btn保存
            // 
            this.btn保存.Location = new System.Drawing.Point(69, 42);
            this.btn保存.Name = "btn保存";
            this.btn保存.Size = new System.Drawing.Size(47, 20);
            this.btn保存.TabIndex = 3;
            this.btn保存.Text = "保存";
            this.btn保存.Click += new System.EventHandler(this.btn保存_Click);
            // 
            // date单据日期
            // 
            this.date单据日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date单据日期.Location = new System.Drawing.Point(133, 40);
            this.date单据日期.Name = "date单据日期";
            this.date单据日期.Size = new System.Drawing.Size(103, 26);
            this.date单据日期.TabIndex = 5;
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 106);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(231, 185);
            this.dataGrid1.TabIndex = 6;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(201, 72);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(33, 20);
            this.btnScan.TabIndex = 7;
            this.btnScan.Text = "...";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(182, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(52, 20);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "返回";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Frm其他出库
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.date单据日期);
            this.Controls.Add(this.btn保存);
            this.Controls.Add(this.btn删行);
            this.Controls.Add(this.txt条形码);
            this.Name = "Frm其他出库";
            this.Text = "出库";
            this.Load += new System.EventHandler(this.Frm其他出库货位_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt条形码;
        private System.Windows.Forms.Button btn删行;
        private System.Windows.Forms.Button btn保存;
        private System.Windows.Forms.DateTimePicker date单据日期;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnExit;
    }
}