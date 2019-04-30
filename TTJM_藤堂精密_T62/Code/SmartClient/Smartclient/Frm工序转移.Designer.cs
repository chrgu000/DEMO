namespace Smartclient
{
    partial class Frm工序转移
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm工序转移));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarCode2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt装箱数 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt数量 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chk分包 = new System.Windows.Forms.CheckBox();
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
            this.txt分包数 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelUid = new System.Windows.Forms.Label();
            this.txt工序 = new System.Windows.Forms.TextBox();
            this.combo工序 = new System.Windows.Forms.ComboBox();
            this.btnSEL = new System.Windows.Forms.Button();
            this.label生产订单IDs = new System.Windows.Forms.Label();
            this.label工序流转iID = new System.Windows.Forms.Label();
            this.btnSEL2 = new System.Windows.Forms.Button();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chk入库 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.Text = "条形码";
            // 
            // txtBarCode2
            // 
            this.txtBarCode2.Location = new System.Drawing.Point(77, 24);
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
            this.label2.Text = "工序";
            // 
            // txt装箱数
            // 
            this.txt装箱数.Enabled = false;
            this.txt装箱数.Location = new System.Drawing.Point(189, 157);
            this.txt装箱数.Name = "txt装箱数";
            this.txt装箱数.Size = new System.Drawing.Size(45, 21);
            this.txt装箱数.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(145, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.Text = "装箱数";
            // 
            // txt数量
            // 
            this.txt数量.Location = new System.Drawing.Point(77, 200);
            this.txt数量.Name = "txt数量";
            this.txt数量.Size = new System.Drawing.Size(69, 21);
            this.txt数量.TabIndex = 3;
            this.txt数量.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt数量_KeyUp);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(4, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.Text = "扫描数量";
            // 
            // chk分包
            // 
            this.chk分包.Enabled = false;
            this.chk分包.Location = new System.Drawing.Point(146, 178);
            this.chk分包.Name = "chk分包";
            this.chk分包.Size = new System.Drawing.Size(62, 20);
            this.chk分包.TabIndex = 11;
            this.chk分包.Text = "分包";
            this.chk分包.CheckStateChanged += new System.EventHandler(this.chk分包_CheckStateChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 20);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(195, 228);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 20);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtWorkCode
            // 
            this.txtWorkCode.Enabled = false;
            this.txtWorkCode.Location = new System.Drawing.Point(77, 68);
            this.txtWorkCode.Name = "txtWorkCode";
            this.txtWorkCode.Size = new System.Drawing.Size(164, 21);
            this.txtWorkCode.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(4, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.Text = "生产订单";
            // 
            // txtcInvCode
            // 
            this.txtcInvCode.Enabled = false;
            this.txtcInvCode.Location = new System.Drawing.Point(77, 90);
            this.txtcInvCode.Name = "txtcInvCode";
            this.txtcInvCode.Size = new System.Drawing.Size(164, 21);
            this.txtcInvCode.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.Text = "存货编码";
            // 
            // txtcInvName
            // 
            this.txtcInvName.Enabled = false;
            this.txtcInvName.Location = new System.Drawing.Point(77, 112);
            this.txtcInvName.Name = "txtcInvName";
            this.txtcInvName.Size = new System.Drawing.Size(164, 21);
            this.txtcInvName.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(4, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.Text = "存货名称";
            // 
            // txtcInvStd
            // 
            this.txtcInvStd.Enabled = false;
            this.txtcInvStd.Location = new System.Drawing.Point(77, 134);
            this.txtcInvStd.Name = "txtcInvStd";
            this.txtcInvStd.Size = new System.Drawing.Size(164, 21);
            this.txtcInvStd.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.Text = "规格型号";
            // 
            // txt订单数
            // 
            this.txt订单数.Enabled = false;
            this.txt订单数.Location = new System.Drawing.Point(77, 156);
            this.txt订单数.Name = "txt订单数";
            this.txt订单数.Size = new System.Drawing.Size(69, 21);
            this.txt订单数.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(4, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 20);
            this.label9.Text = "订单数";
            // 
            // txt分包数
            // 
            this.txt分包数.Enabled = false;
            this.txt分包数.Location = new System.Drawing.Point(77, 178);
            this.txt分包数.Name = "txt分包数";
            this.txt分包数.Size = new System.Drawing.Size(69, 21);
            this.txt分包数.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(4, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.Text = "分包数";
            // 
            // labelUid
            // 
            this.labelUid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelUid.Location = new System.Drawing.Point(208, 205);
            this.labelUid.Name = "labelUid";
            this.labelUid.Size = new System.Drawing.Size(26, 18);
            this.labelUid.Text = "操作员：111111";
            this.labelUid.Visible = false;
            // 
            // txt工序
            // 
            this.txt工序.Enabled = false;
            this.txt工序.Location = new System.Drawing.Point(135, 2);
            this.txt工序.Name = "txt工序";
            this.txt工序.Size = new System.Drawing.Size(99, 21);
            this.txt工序.TabIndex = 3;
            // 
            // combo工序
            // 
            this.combo工序.Location = new System.Drawing.Point(77, 1);
            this.combo工序.Name = "combo工序";
            this.combo工序.Size = new System.Drawing.Size(53, 22);
            this.combo工序.TabIndex = 1;
            this.combo工序.TextChanged += new System.EventHandler(this.combo工序_TextChanged);
            // 
            // btnSEL
            // 
            this.btnSEL.Location = new System.Drawing.Point(208, 24);
            this.btnSEL.Name = "btnSEL";
            this.btnSEL.Size = new System.Drawing.Size(26, 21);
            this.btnSEL.TabIndex = 58;
            this.btnSEL.Text = "...";
            this.btnSEL.Click += new System.EventHandler(this.btnSEL_Click);
            // 
            // label生产订单IDs
            // 
            this.label生产订单IDs.Location = new System.Drawing.Point(208, 205);
            this.label生产订单IDs.Name = "label生产订单IDs";
            this.label生产订单IDs.Size = new System.Drawing.Size(26, 15);
            this.label生产订单IDs.Text = "生产订单IDs";
            this.label生产订单IDs.Visible = false;
            // 
            // label工序流转iID
            // 
            this.label工序流转iID.Location = new System.Drawing.Point(208, 187);
            this.label工序流转iID.Name = "label工序流转iID";
            this.label工序流转iID.Size = new System.Drawing.Size(29, 18);
            this.label工序流转iID.Text = "工序流转iID";
            this.label工序流转iID.Visible = false;
            // 
            // btnSEL2
            // 
            this.btnSEL2.Location = new System.Drawing.Point(21, 228);
            this.btnSEL2.Name = "btnSEL2";
            this.btnSEL2.Size = new System.Drawing.Size(35, 20);
            this.btnSEL2.TabIndex = 72;
            this.btnSEL2.Text = "查看";
            this.btnSEL2.Click += new System.EventHandler(this.btnSEL2_Click);
            // 
            // txtBarCode
            // 
            this.txtBarCode.Enabled = false;
            this.txtBarCode.Location = new System.Drawing.Point(77, 46);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(125, 21);
            this.txtBarCode.TabIndex = 88;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(4, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 20);
            this.label12.Text = "原始条码";
            // 
            // chk入库
            // 
            this.chk入库.Enabled = false;
            this.chk入库.Location = new System.Drawing.Point(146, 200);
            this.chk入库.Name = "chk入库";
            this.chk入库.Size = new System.Drawing.Size(62, 20);
            this.chk入库.TabIndex = 103;
            this.chk入库.Text = "入库";
            // 
            // Frm工序转移
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.chk入库);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnSEL2);
            this.Controls.Add(this.label工序流转iID);
            this.Controls.Add(this.label生产订单IDs);
            this.Controls.Add(this.btnSEL);
            this.Controls.Add(this.combo工序);
            this.Controls.Add(this.labelUid);
            this.Controls.Add(this.txt分包数);
            this.Controls.Add(this.label10);
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
            this.Controls.Add(this.chk分包);
            this.Controls.Add(this.txt数量);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt装箱数);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt工序);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBarCode2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Frm工序转移";
            this.Text = "工序转移";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarCode2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt装箱数;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt数量;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk分包;
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
        private System.Windows.Forms.TextBox txt分包数;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelUid;
        private System.Windows.Forms.TextBox txt工序;
        private System.Windows.Forms.ComboBox combo工序;
        private System.Windows.Forms.Button btnSEL;
        private System.Windows.Forms.Label label生产订单IDs;
        private System.Windows.Forms.Label label工序流转iID;
        private System.Windows.Forms.Button btnSEL2;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chk入库;


    }
}

