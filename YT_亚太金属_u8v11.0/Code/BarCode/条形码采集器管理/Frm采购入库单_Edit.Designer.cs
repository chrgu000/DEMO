namespace BarCode
{
    partial class Frm采购入库单_Edit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.txt条形码 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txt提示货位 = new System.Windows.Forms.TextBox();
            this.txt入库件数 = new System.Windows.Forms.TextBox();
            this.txtAutoID = new System.Windows.Forms.TextBox();
            this.txt拒收件数 = new System.Windows.Forms.TextBox();
            this.txt拒收数量 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn返回 = new System.Windows.Forms.Button();
            this.btn确定 = new System.Windows.Forms.Button();
            this.txt入库数量 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt批号 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt规格型号 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt存货名称 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt存货编码 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt货仓 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1366, 719);
            this.msgBox.Location = new System.Drawing.Point(-4, -4);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.Text = "条形码";
            // 
            // txt条形码
            // 
            this.txt条形码.Location = new System.Drawing.Point(61, 44);
            this.txt条形码.Name = "txt条形码";
            this.txt条形码.Size = new System.Drawing.Size(136, 21);
            this.txt条形码.TabIndex = 1;
            this.txt条形码.Validated += new System.EventHandler(this.txt条形码_Validated);
            this.txt条形码.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt条形码_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt提示货位);
            this.panel1.Controls.Add(this.txt入库件数);
            this.panel1.Controls.Add(this.txtAutoID);
            this.panel1.Controls.Add(this.txt拒收件数);
            this.panel1.Controls.Add(this.txt拒收数量);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn返回);
            this.panel1.Controls.Add(this.btn确定);
            this.panel1.Controls.Add(this.txt入库数量);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt批号);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt规格型号);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt存货名称);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt存货编码);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 194);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(16, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.Text = "最多料货位";
            // 
            // txt提示货位
            // 
            this.txt提示货位.Enabled = false;
            this.txt提示货位.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt提示货位.Location = new System.Drawing.Point(101, 137);
            this.txt提示货位.Name = "txt提示货位";
            this.txt提示货位.Size = new System.Drawing.Size(196, 19);
            this.txt提示货位.TabIndex = 32;
            // 
            // txt入库件数
            // 
            this.txt入库件数.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt入库件数.Location = new System.Drawing.Point(200, 92);
            this.txt入库件数.Name = "txt入库件数";
            this.txt入库件数.Size = new System.Drawing.Size(97, 19);
            this.txt入库件数.TabIndex = 25;
            // 
            // txtAutoID
            // 
            this.txtAutoID.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txtAutoID.Location = new System.Drawing.Point(298, 114);
            this.txtAutoID.Name = "txtAutoID";
            this.txtAutoID.Size = new System.Drawing.Size(13, 19);
            this.txtAutoID.TabIndex = 18;
            this.txtAutoID.Visible = false;
            // 
            // txt拒收件数
            // 
            this.txt拒收件数.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt拒收件数.Location = new System.Drawing.Point(200, 115);
            this.txt拒收件数.Name = "txt拒收件数";
            this.txt拒收件数.Size = new System.Drawing.Size(97, 19);
            this.txt拒收件数.TabIndex = 10;
            // 
            // txt拒收数量
            // 
            this.txt拒收数量.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt拒收数量.Location = new System.Drawing.Point(101, 115);
            this.txt拒收数量.Name = "txt拒收数量";
            this.txt拒收数量.Size = new System.Drawing.Size(93, 19);
            this.txt拒收数量.TabIndex = 9;
            this.txt拒收数量.Validated += new System.EventHandler(this.txt拒收数量_Validated);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(16, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.Text = "拒收件数/数量";
            // 
            // btn返回
            // 
            this.btn返回.Location = new System.Drawing.Point(159, 158);
            this.btn返回.Name = "btn返回";
            this.btn返回.Size = new System.Drawing.Size(52, 20);
            this.btn返回.TabIndex = 12;
            this.btn返回.Text = "返回";
            this.btn返回.Click += new System.EventHandler(this.btn返回_Click);
            // 
            // btn确定
            // 
            this.btn确定.Location = new System.Drawing.Point(101, 158);
            this.btn确定.Name = "btn确定";
            this.btn确定.Size = new System.Drawing.Size(52, 20);
            this.btn确定.TabIndex = 11;
            this.btn确定.Text = "确定";
            this.btn确定.Click += new System.EventHandler(this.btn确定_Click);
            // 
            // txt入库数量
            // 
            this.txt入库数量.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt入库数量.Location = new System.Drawing.Point(101, 91);
            this.txt入库数量.Name = "txt入库数量";
            this.txt入库数量.Size = new System.Drawing.Size(93, 19);
            this.txt入库数量.TabIndex = 7;
            this.txt入库数量.Validated += new System.EventHandler(this.txt入库数量_Validated);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(14, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.Text = "合格件数/数量";
            // 
            // txt批号
            // 
            this.txt批号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt批号.Location = new System.Drawing.Point(101, 71);
            this.txt批号.Name = "txt批号";
            this.txt批号.Size = new System.Drawing.Size(196, 19);
            this.txt批号.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(16, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.Text = "批号";
            // 
            // txt规格型号
            // 
            this.txt规格型号.Enabled = false;
            this.txt规格型号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt规格型号.Location = new System.Drawing.Point(101, 50);
            this.txt规格型号.Name = "txt规格型号";
            this.txt规格型号.Size = new System.Drawing.Size(196, 19);
            this.txt规格型号.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(14, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.Text = "规格型号";
            // 
            // txt存货名称
            // 
            this.txt存货名称.Enabled = false;
            this.txt存货名称.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt存货名称.Location = new System.Drawing.Point(101, 29);
            this.txt存货名称.Name = "txt存货名称";
            this.txt存货名称.Size = new System.Drawing.Size(196, 19);
            this.txt存货名称.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(14, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.Text = "存货名称";
            // 
            // txt存货编码
            // 
            this.txt存货编码.Enabled = false;
            this.txt存货编码.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt存货编码.Location = new System.Drawing.Point(101, 8);
            this.txt存货编码.Name = "txt存货编码";
            this.txt存货编码.Size = new System.Drawing.Size(196, 19);
            this.txt存货编码.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(14, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.Text = "存货编码";
            // 
            // txt货仓
            // 
            this.txt货仓.Location = new System.Drawing.Point(235, 44);
            this.txt货仓.Name = "txt货仓";
            this.txt货仓.Size = new System.Drawing.Size(65, 21);
            this.txt货仓.TabIndex = 2;
            this.txt货仓.Validated += new System.EventHandler(this.txt货仓_Validated);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(203, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.Text = "货仓";
            // 
            // Frm采购入库单_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(320, 270);
            this.Controls.Add(this.txt货仓);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt条形码);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "Frm采购入库单_Edit";
            this.Text = "采购入库单";
            this.Load += new System.EventHandler(this.Frm采购入库单_Edit_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt条形码;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt入库数量;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt批号;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt规格型号;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt存货名称;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt存货编码;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn返回;
        private System.Windows.Forms.Button btn确定;
        private System.Windows.Forms.TextBox txt货仓;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt拒收件数;
        private System.Windows.Forms.TextBox txt拒收数量;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAutoID;
        private System.Windows.Forms.TextBox txt入库件数;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt提示货位;

    }
}