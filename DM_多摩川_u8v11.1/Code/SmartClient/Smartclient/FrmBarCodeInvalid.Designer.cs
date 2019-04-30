namespace Smartclient
{
    partial class FrmBarCodeInvalid
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
            this.btnInvalid = new System.Windows.Forms.Button();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.txtBarCodeInfo = new System.Windows.Forms.TextBox();
            this.btnExamine = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBarCodeCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInvalid
            // 
            this.btnInvalid.Location = new System.Drawing.Point(201, 9);
            this.btnInvalid.Name = "btnInvalid";
            this.btnInvalid.Size = new System.Drawing.Size(36, 20);
            this.btnInvalid.TabIndex = 1;
            this.btnInvalid.Text = "作废";
            this.btnInvalid.Click += new System.EventHandler(this.btnInvalid_Click);
            // 
            // txtBarCode
            // 
            this.txtBarCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarCode.Location = new System.Drawing.Point(61, 9);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(92, 19);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.Text = "140904000001";
            this.txtBarCode.GotFocus += new System.EventHandler(this.txtBarCode_GotFocus);
            this.txtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.Text = "条形码";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(157, 9);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(36, 20);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "扫描";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtBarCodeInfo
            // 
            this.txtBarCodeInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarCodeInfo.Location = new System.Drawing.Point(4, 59);
            this.txtBarCodeInfo.Multiline = true;
            this.txtBarCodeInfo.Name = "txtBarCodeInfo";
            this.txtBarCodeInfo.ReadOnly = true;
            this.txtBarCodeInfo.Size = new System.Drawing.Size(233, 206);
            this.txtBarCodeInfo.TabIndex = 7;
            // 
            // btnExamine
            // 
            this.btnExamine.Location = new System.Drawing.Point(157, 33);
            this.btnExamine.Name = "btnExamine";
            this.btnExamine.Size = new System.Drawing.Size(36, 20);
            this.btnExamine.TabIndex = 9;
            this.btnExamine.Text = "查看";
            this.btnExamine.Click += new System.EventHandler(this.btnExamine_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(201, 33);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 20);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.Text = "扫描条数";
            // 
            // labelBarCodeCount
            // 
            this.labelBarCodeCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelBarCodeCount.Location = new System.Drawing.Point(61, 31);
            this.labelBarCodeCount.Name = "labelBarCodeCount";
            this.labelBarCodeCount.Size = new System.Drawing.Size(67, 20);
            this.labelBarCodeCount.Text = "label3";
            // 
            // FrmBarCodeInvalid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.labelBarCodeCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExamine);
            this.Controls.Add(this.txtBarCodeInfo);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInvalid);
            this.Name = "FrmBarCodeInvalid";
            this.Text = "条形码作废";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInvalid;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtBarCodeInfo;
        private System.Windows.Forms.Button btnExamine;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBarCodeCount;
    }
}