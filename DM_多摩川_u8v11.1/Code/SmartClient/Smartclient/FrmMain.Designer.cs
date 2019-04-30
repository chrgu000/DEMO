namespace Smartclient
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBarCodeInvalid = new System.Windows.Forms.Button();
            this.btnUnBox = new System.Windows.Forms.Button();
            this.btnBox = new System.Windows.Forms.Button();
            this.btnTransVouch = new System.Windows.Forms.Button();
            this.btnCheckVouch = new System.Windows.Forms.Button();
            this.btnDispatchList = new System.Windows.Forms.Button();
            this.btnRdrecord10 = new System.Windows.Forms.Button();
            this.btnrdRecord11 = new System.Windows.Forms.Button();
            this.btnRdRecord01 = new System.Windows.Forms.Button();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.btnBarCodeAdjust = new System.Windows.Forms.Button();
            this.btnrdRecord09 = new System.Windows.Forms.Button();
            this.btnrdRecord08 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(142, 229);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 20);
            this.btnExit.TabIndex = 18;
            this.btnExit.Tag = "退出系统";
            this.btnExit.Text = "退出系统";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 33);
            this.label1.Text = "条形码智能终端";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBarCodeInvalid
            // 
            this.btnBarCodeInvalid.Location = new System.Drawing.Point(34, 173);
            this.btnBarCodeInvalid.Name = "btnBarCodeInvalid";
            this.btnBarCodeInvalid.Size = new System.Drawing.Size(74, 20);
            this.btnBarCodeInvalid.TabIndex = 15;
            this.btnBarCodeInvalid.Tag = "条形码作废";
            this.btnBarCodeInvalid.Text = "条形码作废";
            this.btnBarCodeInvalid.Click += new System.EventHandler(this.btnBarCodeInvalid_Click);
            // 
            // btnUnBox
            // 
            this.btnUnBox.Location = new System.Drawing.Point(142, 147);
            this.btnUnBox.Name = "btnUnBox";
            this.btnUnBox.Size = new System.Drawing.Size(74, 20);
            this.btnUnBox.TabIndex = 14;
            this.btnUnBox.Tag = "拆箱";
            this.btnUnBox.Text = "拆箱";
            this.btnUnBox.Click += new System.EventHandler(this.btnUnBox_Click);
            // 
            // btnBox
            // 
            this.btnBox.Location = new System.Drawing.Point(34, 147);
            this.btnBox.Name = "btnBox";
            this.btnBox.Size = new System.Drawing.Size(74, 20);
            this.btnBox.TabIndex = 13;
            this.btnBox.Tag = "装箱";
            this.btnBox.Text = "装箱";
            this.btnBox.Click += new System.EventHandler(this.btnBox_Click);
            // 
            // btnTransVouch
            // 
            this.btnTransVouch.Location = new System.Drawing.Point(34, 121);
            this.btnTransVouch.Name = "btnTransVouch";
            this.btnTransVouch.Size = new System.Drawing.Size(74, 20);
            this.btnTransVouch.TabIndex = 12;
            this.btnTransVouch.Tag = "调拨";
            this.btnTransVouch.Text = "调拨";
            this.btnTransVouch.Click += new System.EventHandler(this.btnTransVouch_Click);
            // 
            // btnCheckVouch
            // 
            this.btnCheckVouch.Location = new System.Drawing.Point(142, 121);
            this.btnCheckVouch.Name = "btnCheckVouch";
            this.btnCheckVouch.Size = new System.Drawing.Size(74, 20);
            this.btnCheckVouch.TabIndex = 11;
            this.btnCheckVouch.Tag = "盘点";
            this.btnCheckVouch.Text = "盘点";
            this.btnCheckVouch.Click += new System.EventHandler(this.btnCheckVouch_Click);
            // 
            // btnDispatchList
            // 
            this.btnDispatchList.Location = new System.Drawing.Point(142, 69);
            this.btnDispatchList.Name = "btnDispatchList";
            this.btnDispatchList.Size = new System.Drawing.Size(74, 20);
            this.btnDispatchList.TabIndex = 10;
            this.btnDispatchList.Tag = "销售发货";
            this.btnDispatchList.Text = "销售发货";
            this.btnDispatchList.Click += new System.EventHandler(this.btnDispatchList_Click);
            // 
            // btnRdrecord10
            // 
            this.btnRdrecord10.Location = new System.Drawing.Point(34, 69);
            this.btnRdrecord10.Name = "btnRdrecord10";
            this.btnRdrecord10.Size = new System.Drawing.Size(74, 20);
            this.btnRdrecord10.TabIndex = 9;
            this.btnRdrecord10.Tag = "产品入库";
            this.btnRdrecord10.Text = "产品入库";
            this.btnRdrecord10.Click += new System.EventHandler(this.btnRdrecord10_Click);
            // 
            // btnrdRecord11
            // 
            this.btnrdRecord11.Location = new System.Drawing.Point(142, 43);
            this.btnrdRecord11.Name = "btnrdRecord11";
            this.btnrdRecord11.Size = new System.Drawing.Size(74, 20);
            this.btnrdRecord11.TabIndex = 8;
            this.btnrdRecord11.Tag = "材料出库";
            this.btnrdRecord11.Text = "材料出库";
            this.btnrdRecord11.Click += new System.EventHandler(this.btnrdRecord11_Click);
            // 
            // btnRdRecord01
            // 
            this.btnRdRecord01.Location = new System.Drawing.Point(34, 43);
            this.btnRdRecord01.Name = "btnRdRecord01";
            this.btnRdRecord01.Size = new System.Drawing.Size(74, 20);
            this.btnRdRecord01.TabIndex = 7;
            this.btnRdRecord01.Tag = "采购入库";
            this.btnRdRecord01.Text = "采购入库";
            this.btnRdRecord01.Click += new System.EventHandler(this.btnRdRecord01_Click);
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(34, 229);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(74, 20);
            this.btnChangePwd.TabIndex = 22;
            this.btnChangePwd.Tag = "修改密码";
            this.btnChangePwd.Text = "修改密码";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // btnBarCodeAdjust
            // 
            this.btnBarCodeAdjust.Location = new System.Drawing.Point(142, 173);
            this.btnBarCodeAdjust.Name = "btnBarCodeAdjust";
            this.btnBarCodeAdjust.Size = new System.Drawing.Size(74, 20);
            this.btnBarCodeAdjust.TabIndex = 24;
            this.btnBarCodeAdjust.Tag = "标签数量调整";
            this.btnBarCodeAdjust.Text = "标签数量调整";
            this.btnBarCodeAdjust.Click += new System.EventHandler(this.btnBarCodeAdjust_Click);
            // 
            // btnrdRecord09
            // 
            this.btnrdRecord09.Location = new System.Drawing.Point(142, 95);
            this.btnrdRecord09.Name = "btnrdRecord09";
            this.btnrdRecord09.Size = new System.Drawing.Size(74, 20);
            this.btnrdRecord09.TabIndex = 26;
            this.btnrdRecord09.Tag = "其他出库单";
            this.btnrdRecord09.Text = "其他出库单";
            this.btnrdRecord09.Click += new System.EventHandler(this.btnrdRecord09_Click);
            // 
            // btnrdRecord08
            // 
            this.btnrdRecord08.Location = new System.Drawing.Point(34, 95);
            this.btnrdRecord08.Name = "btnrdRecord08";
            this.btnrdRecord08.Size = new System.Drawing.Size(74, 20);
            this.btnrdRecord08.TabIndex = 27;
            this.btnrdRecord08.Tag = "其他入库单";
            this.btnrdRecord08.Text = "其他入库单";
            this.btnrdRecord08.Click += new System.EventHandler(this.btnrdRecord08_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnrdRecord08);
            this.Controls.Add(this.btnrdRecord09);
            this.Controls.Add(this.btnBarCodeAdjust);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBarCodeInvalid);
            this.Controls.Add(this.btnRdRecord01);
            this.Controls.Add(this.btnBox);
            this.Controls.Add(this.btnUnBox);
            this.Controls.Add(this.btnTransVouch);
            this.Controls.Add(this.btnrdRecord11);
            this.Controls.Add(this.btnRdrecord10);
            this.Controls.Add(this.btnDispatchList);
            this.Controls.Add(this.btnCheckVouch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.Text = "条形码智能终端";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRdRecord01;
        private System.Windows.Forms.Button btnrdRecord11;
        private System.Windows.Forms.Button btnRdrecord10;
        private System.Windows.Forms.Button btnDispatchList;
        private System.Windows.Forms.Button btnCheckVouch;
        private System.Windows.Forms.Button btnBarCodeInvalid;
        private System.Windows.Forms.Button btnUnBox;
        private System.Windows.Forms.Button btnBox;
        private System.Windows.Forms.Button btnTransVouch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.Button btnBarCodeAdjust;
        private System.Windows.Forms.Button btnrdRecord09;
        private System.Windows.Forms.Button btnrdRecord08;

    }
}

