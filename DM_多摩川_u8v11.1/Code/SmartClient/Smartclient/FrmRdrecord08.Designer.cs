namespace Smartclient
{
    partial class FrmRdrecord08
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnScanCode = new System.Windows.Forms.Button();
            this.btnExamine = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBarCodeCount = new System.Windows.Forms.Label();
            this.txtcCode = new System.Windows.Forms.TextBox();
            this.btnRdrecord08 = new System.Windows.Forms.Button();
            this.btnScanBarCode = new System.Windows.Forms.Button();
            this.txtBarCodeInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lQty = new System.Windows.Forms.Label();
            this.lScanQty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInvalid
            // 
            this.btnInvalid.Location = new System.Drawing.Point(193, 3);
            this.btnInvalid.Name = "btnInvalid";
            this.btnInvalid.Size = new System.Drawing.Size(36, 20);
            this.btnInvalid.TabIndex = 1;
            this.btnInvalid.Text = "保存";
            this.btnInvalid.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.Text = "单据号";
            // 
            // btnScanCode
            // 
            this.btnScanCode.Location = new System.Drawing.Point(151, 3);
            this.btnScanCode.Name = "btnScanCode";
            this.btnScanCode.Size = new System.Drawing.Size(36, 20);
            this.btnScanCode.TabIndex = 5;
            this.btnScanCode.Text = "扫描";
            this.btnScanCode.Click += new System.EventHandler(this.btnScanCode_Click);
            // 
            // btnExamine
            // 
            this.btnExamine.Location = new System.Drawing.Point(148, 74);
            this.btnExamine.Name = "btnExamine";
            this.btnExamine.Size = new System.Drawing.Size(81, 20);
            this.btnExamine.TabIndex = 9;
            this.btnExamine.Text = "查看条码";
            this.btnExamine.Click += new System.EventHandler(this.btnExamine_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(193, 25);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 20);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.Text = "扫描条数";
            // 
            // labelBarCodeCount
            // 
            this.labelBarCodeCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelBarCodeCount.Location = new System.Drawing.Point(73, 75);
            this.labelBarCodeCount.Name = "labelBarCodeCount";
            this.labelBarCodeCount.Size = new System.Drawing.Size(34, 20);
            this.labelBarCodeCount.Text = "lCou";
            // 
            // txtcCode
            // 
            this.txtcCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtcCode.Location = new System.Drawing.Point(53, 4);
            this.txtcCode.Name = "txtcCode";
            this.txtcCode.Size = new System.Drawing.Size(92, 19);
            this.txtcCode.TabIndex = 1;
            this.txtcCode.Text = "140904000001";
            this.txtcCode.GotFocus += new System.EventHandler(this.txtcCode_GotFocus);
            this.txtcCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcCode_KeyUp);
            // 
            // btnRdrecord08
            // 
            this.btnRdrecord08.Location = new System.Drawing.Point(148, 50);
            this.btnRdrecord08.Name = "btnRdrecord08";
            this.btnRdrecord08.Size = new System.Drawing.Size(81, 20);
            this.btnRdrecord08.TabIndex = 23;
            this.btnRdrecord08.Text = "单据明细";
            this.btnRdrecord08.Click += new System.EventHandler(this.btnRdrecord08_Click);
            // 
            // btnScanBarCode
            // 
            this.btnScanBarCode.Location = new System.Drawing.Point(151, 26);
            this.btnScanBarCode.Name = "btnScanBarCode";
            this.btnScanBarCode.Size = new System.Drawing.Size(36, 20);
            this.btnScanBarCode.TabIndex = 24;
            this.btnScanBarCode.Text = "扫描";
            this.btnScanBarCode.Click += new System.EventHandler(this.btnScanBarCode_Click);
            // 
            // txtBarCodeInfo
            // 
            this.txtBarCodeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarCodeInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarCodeInfo.Location = new System.Drawing.Point(3, 116);
            this.txtBarCodeInfo.Multiline = true;
            this.txtBarCodeInfo.Name = "txtBarCodeInfo";
            this.txtBarCodeInfo.ReadOnly = true;
            this.txtBarCodeInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBarCodeInfo.Size = new System.Drawing.Size(233, 149);
            this.txtBarCodeInfo.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(0, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.Text = "条形码";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarCode.Location = new System.Drawing.Point(53, 27);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(92, 19);
            this.txtBarCode.TabIndex = 2;
            this.txtBarCode.Text = "140904000001";
            this.txtBarCode.GotFocus += new System.EventHandler(this.txtBarCode_GotFocus);
            this.txtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyUp);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtQty.Location = new System.Drawing.Point(53, 51);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(92, 19);
            this.txtQty.TabIndex = 3;
            this.txtQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyUp);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(4, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.Text = "数量";
            // 
            // lQty
            // 
            this.lQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lQty.Location = new System.Drawing.Point(4, 94);
            this.lQty.Name = "lQty";
            this.lQty.Size = new System.Drawing.Size(113, 20);
            this.lQty.Text = "待出库";
            // 
            // lScanQty
            // 
            this.lScanQty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lScanQty.Location = new System.Drawing.Point(116, 95);
            this.lScanQty.Name = "lScanQty";
            this.lScanQty.Size = new System.Drawing.Size(113, 20);
            this.lScanQty.Text = "累计扫描";
            // 
            // FrmRdrecord08
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.lScanQty);
            this.Controls.Add(this.lQty);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBarCodeInfo);
            this.Controls.Add(this.btnScanBarCode);
            this.Controls.Add(this.btnRdrecord08);
            this.Controls.Add(this.txtcCode);
            this.Controls.Add(this.labelBarCodeCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExamine);
            this.Controls.Add(this.btnScanCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInvalid);
            this.Name = "FrmRdrecord08";
            this.Text = "其他入库单";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInvalid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScanCode;
        private System.Windows.Forms.Button btnExamine;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBarCodeCount;
        private System.Windows.Forms.TextBox txtcCode;
        private System.Windows.Forms.Button btnRdrecord08;
        private System.Windows.Forms.Button btnScanBarCode;
        private System.Windows.Forms.TextBox txtBarCodeInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lQty;
        private System.Windows.Forms.Label lScanQty;
    }
}