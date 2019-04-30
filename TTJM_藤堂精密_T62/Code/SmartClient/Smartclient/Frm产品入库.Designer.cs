namespace Smartclient
{
    partial class Frm产品入库
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm产品入库));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarCode2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt数量 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtWorkCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcInvCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcInvName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcInvStd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt订单数 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelUid = new System.Windows.Forms.Label();
            this.combo仓库 = new System.Windows.Forms.ComboBox();
            this.btnSEL = new System.Windows.Forms.Button();
            this.label生产订单IDs = new System.Windows.Forms.Label();
            this.label工序流转iID = new System.Windows.Forms.Label();
            this.chk入库 = new System.Windows.Forms.CheckBox();
            this.combo入库类别 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(4, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.Text = "条形码";
            // 
            // txtBarCode2
            // 
            this.txtBarCode2.Location = new System.Drawing.Point(77, 47);
            this.txtBarCode2.Name = "txtBarCode2";
            this.txtBarCode2.Size = new System.Drawing.Size(125, 21);
            this.txtBarCode2.TabIndex = 2;
            this.txtBarCode2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyUp);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.Text = "仓库";
            // 
            // txt数量
            // 
            this.txt数量.Location = new System.Drawing.Point(77, 179);
            this.txt数量.Name = "txt数量";
            this.txt数量.Size = new System.Drawing.Size(157, 21);
            this.txt数量.TabIndex = 3;
            this.txt数量.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt数量_KeyUp);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(4, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.Text = "扫描数量";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(141, 245);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(35, 20);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(195, 245);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 20);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtWorkCode
            // 
            this.txtWorkCode.Enabled = false;
            this.txtWorkCode.Location = new System.Drawing.Point(77, 69);
            this.txtWorkCode.Name = "txtWorkCode";
            this.txtWorkCode.Size = new System.Drawing.Size(157, 21);
            this.txtWorkCode.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.Text = "生产订单";
            // 
            // txtcInvCode
            // 
            this.txtcInvCode.Enabled = false;
            this.txtcInvCode.Location = new System.Drawing.Point(77, 91);
            this.txtcInvCode.Name = "txtcInvCode";
            this.txtcInvCode.Size = new System.Drawing.Size(157, 21);
            this.txtcInvCode.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.Text = "存货编码";
            // 
            // txtcInvName
            // 
            this.txtcInvName.Enabled = false;
            this.txtcInvName.Location = new System.Drawing.Point(77, 113);
            this.txtcInvName.Name = "txtcInvName";
            this.txtcInvName.Size = new System.Drawing.Size(157, 21);
            this.txtcInvName.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(4, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.Text = "存货名称";
            // 
            // txtcInvStd
            // 
            this.txtcInvStd.Enabled = false;
            this.txtcInvStd.Location = new System.Drawing.Point(77, 135);
            this.txtcInvStd.Name = "txtcInvStd";
            this.txtcInvStd.Size = new System.Drawing.Size(157, 21);
            this.txtcInvStd.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.Text = "规格型号";
            // 
            // txt订单数
            // 
            this.txt订单数.Enabled = false;
            this.txt订单数.Location = new System.Drawing.Point(77, 157);
            this.txt订单数.Name = "txt订单数";
            this.txt订单数.Size = new System.Drawing.Size(157, 21);
            this.txt订单数.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(4, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 20);
            this.label9.Text = "订单数";
            // 
            // labelUid
            // 
            this.labelUid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelUid.Location = new System.Drawing.Point(183, 224);
            this.labelUid.Name = "labelUid";
            this.labelUid.Size = new System.Drawing.Size(51, 18);
            this.labelUid.Text = "操作员：111111";
            this.labelUid.Visible = false;
            // 
            // combo仓库
            // 
            this.combo仓库.Location = new System.Drawing.Point(77, 1);
            this.combo仓库.Name = "combo仓库";
            this.combo仓库.Size = new System.Drawing.Size(157, 22);
            this.combo仓库.TabIndex = 1;
            // 
            // btnSEL
            // 
            this.btnSEL.Location = new System.Drawing.Point(208, 45);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(26, 21);
            this.btnSEL.TabIndex = 58;
            this.btnSEL.Text = "...";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // label生产订单IDs
            // 
            this.label生产订单IDs.Location = new System.Drawing.Point(15, 222);
            this.label生产订单IDs.Name = "label生产订单IDs";
            this.label生产订单IDs.Size = new System.Drawing.Size(78, 10);
            this.label生产订单IDs.Text = "生产订单IDs";
            this.label生产订单IDs.Visible = false;
            // 
            // label工序流转iID
            // 
            this.label工序流转iID.Location = new System.Drawing.Point(99, 224);
            this.label工序流转iID.Name = "label工序流转iID";
            this.label工序流转iID.Size = new System.Drawing.Size(78, 18);
            this.label工序流转iID.Text = "工序流转iID";
            this.label工序流转iID.Visible = false;
            // 
            // chk入库
            // 
            this.chk入库.Enabled = false;
            this.chk入库.Location = new System.Drawing.Point(115, 206);
            this.chk入库.Name = "chk入库";
            this.chk入库.Size = new System.Drawing.Size(62, 20);
            this.chk入库.TabIndex = 103;
            this.chk入库.Text = "入库";
            // 
            // combo入库类别
            // 
            this.combo入库类别.Location = new System.Drawing.Point(77, 24);
            this.combo入库类别.Name = "combo入库类别";
            this.combo入库类别.Size = new System.Drawing.Size(157, 22);
            this.combo入库类别.TabIndex = 119;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(4, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.Text = "入库类别";
            // 
            // Frm产品入库
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.combo入库类别);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chk入库);
            this.Controls.Add(this.label工序流转iID);
            this.Controls.Add(this.label生产订单IDs);
            this.Controls.Add(this.btnSEL);
            this.Controls.Add(this.combo仓库);
            this.Controls.Add(this.labelUid);
            this.Controls.Add(this.txt订单数);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtcInvStd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtcInvName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtcInvCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtWorkCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txt数量);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarCode2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm产品入库";
            this.Text = "产品入库";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarCode2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt数量;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtWorkCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcInvCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcInvName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcInvStd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt订单数;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelUid;
        private System.Windows.Forms.ComboBox combo仓库;
        private System.Windows.Forms.Button btnSEL;
        private System.Windows.Forms.Label label生产订单IDs;
        private System.Windows.Forms.Label label工序流转iID;
        private System.Windows.Forms.CheckBox chk入库;
        private System.Windows.Forms.ComboBox combo入库类别;
        private System.Windows.Forms.Label label11;


    }
}

