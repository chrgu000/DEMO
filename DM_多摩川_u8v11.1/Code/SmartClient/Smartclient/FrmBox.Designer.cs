namespace Smartclient
{
    partial class FrmBox
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
            this.btnBox = new System.Windows.Forms.Button();
            this.txtBoxCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnScanBoxCode = new System.Windows.Forms.Button();
            this.txtBarCodeInfo = new System.Windows.Forms.TextBox();
            this.btnScanBarCode = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBarCodeCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.btnExamine = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBox
            // 
            this.btnBox.Location = new System.Drawing.Point(201, 10);
            this.btnBox.Name = "btnBox";
            this.btnBox.Size = new System.Drawing.Size(36, 20);
            this.btnBox.TabIndex = 1;
            this.btnBox.Text = "装箱";
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
            // 
            // txtBoxCode
            // 
            this.txtBoxCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBoxCode.Location = new System.Drawing.Point(61, 10);
            this.txtBoxCode.Name = "txtBoxCode";
            this.txtBoxCode.Size = new System.Drawing.Size(92, 19);
            this.txtBoxCode.TabIndex = 1;
            this.txtBoxCode.Text = "140904000001";
            this.txtBoxCode.GotFocus += new System.EventHandler(this.txtBoxCode_GotFocus);
            this.txtBoxCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBoxCode_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.Text = "箱码";
            // 
            // btnScanBoxCode
            // 
            this.btnScanBoxCode.Location = new System.Drawing.Point(157, 10);
            this.btnScanBoxCode.Name = "btnScanBoxCode";
            this.btnScanBoxCode.Size = new System.Drawing.Size(36, 20);
            this.btnScanBoxCode.TabIndex = 5;
            this.btnScanBoxCode.Text = "扫描";
            this.btnScanBoxCode.Click += new System.EventHandler(this.btnScanBoxCode_Click);
            // 
            // txtBarCodeInfo
            // 
            this.txtBarCodeInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarCodeInfo.Location = new System.Drawing.Point(4, 92);
            this.txtBarCodeInfo.Multiline = true;
            this.txtBarCodeInfo.Name = "txtBarCodeInfo";
            this.txtBarCodeInfo.ReadOnly = true;
            this.txtBarCodeInfo.Size = new System.Drawing.Size(233, 173);
            this.txtBarCodeInfo.TabIndex = 7;
            // 
            // btnScanBarCode
            // 
            this.btnScanBarCode.Location = new System.Drawing.Point(159, 36);
            this.btnScanBarCode.Name = "btnScanBarCode";
            this.btnScanBarCode.Size = new System.Drawing.Size(36, 20);
            this.btnScanBarCode.TabIndex = 9;
            this.btnScanBarCode.Text = "扫描";
            this.btnScanBarCode.Click += new System.EventHandler(this.btnScanBarCode_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(201, 34);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 20);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(9, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.Text = "扫描条数";
            // 
            // labelBarCodeCount
            // 
            this.labelBarCodeCount.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.labelBarCodeCount.Location = new System.Drawing.Point(61, 69);
            this.labelBarCodeCount.Name = "labelBarCodeCount";
            this.labelBarCodeCount.Size = new System.Drawing.Size(67, 20);
            this.labelBarCodeCount.Text = "label3";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(6, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.Text = "条形码";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBarCode.Location = new System.Drawing.Point(61, 34);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(92, 19);
            this.txtBarCode.TabIndex = 14;
            this.txtBarCode.Text = "140904000001";
            this.txtBarCode.GotFocus += new System.EventHandler(this.txtBarCode_GotFocus);
            this.txtBarCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyUp);
            // 
            // btnExamine
            // 
            this.btnExamine.Location = new System.Drawing.Point(157, 59);
            this.btnExamine.Name = "btnExamine";
            this.btnExamine.Size = new System.Drawing.Size(80, 20);
            this.btnExamine.TabIndex = 15;
            this.btnExamine.Text = "查看条码";
            this.btnExamine.Click += new System.EventHandler(this.btnExamine_Click);
            // 
            // FrmBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnExamine);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelBarCodeCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnScanBarCode);
            this.Controls.Add(this.txtBarCodeInfo);
            this.Controls.Add(this.btnScanBoxCode);
            this.Controls.Add(this.txtBoxCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBox);
            this.Name = "FrmBox";
            this.Text = "装箱";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBox;
        private System.Windows.Forms.TextBox txtBoxCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnScanBoxCode;
        private System.Windows.Forms.TextBox txtBarCodeInfo;
        private System.Windows.Forms.Button btnScanBarCode;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBarCodeCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Button btnExamine;
    }
}