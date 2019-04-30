namespace BarCode
{
    partial class Frm销售出库单_Edit
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
            this.txtAutoID = new System.Windows.Forms.TextBox();
            this.txt统一号 = new System.Windows.Forms.TextBox();
            this.txt渗层 = new System.Windows.Forms.TextBox();
            this.txt货位 = new System.Windows.Forms.TextBox();
            this.txt仓库 = new System.Windows.Forms.TextBox();
            this.txt材质 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt工艺要求 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn返回 = new System.Windows.Forms.Button();
            this.btn确定 = new System.Windows.Forms.Button();
            this.txt数量 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt亚太零件号 = new System.Windows.Forms.TextBox();
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.Text = "条形码";
            // 
            // txt条形码
            // 
            this.txt条形码.Location = new System.Drawing.Point(61, 48);
            this.txt条形码.Name = "txt条形码";
            this.txt条形码.Size = new System.Drawing.Size(86, 21);
            this.txt条形码.TabIndex = 1;
            this.txt条形码.Validated += new System.EventHandler(this.txt条形码_Validated);
            this.txt条形码.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt条形码_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAutoID);
            this.panel1.Controls.Add(this.txt统一号);
            this.panel1.Controls.Add(this.txt渗层);
            this.panel1.Controls.Add(this.txt货位);
            this.panel1.Controls.Add(this.txt仓库);
            this.panel1.Controls.Add(this.txt材质);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt工艺要求);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn返回);
            this.panel1.Controls.Add(this.btn确定);
            this.panel1.Controls.Add(this.txt数量);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt亚太零件号);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt规格型号);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt存货名称);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt存货编码);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 194);
            // 
            // txtAutoID
            // 
            this.txtAutoID.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txtAutoID.Location = new System.Drawing.Point(69, 172);
            this.txtAutoID.Name = "txtAutoID";
            this.txtAutoID.Size = new System.Drawing.Size(17, 19);
            this.txtAutoID.TabIndex = 56;
            this.txtAutoID.Visible = false;
            // 
            // txt统一号
            // 
            this.txt统一号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt统一号.Location = new System.Drawing.Point(46, 172);
            this.txt统一号.Name = "txt统一号";
            this.txt统一号.Size = new System.Drawing.Size(17, 19);
            this.txt统一号.TabIndex = 55;
            this.txt统一号.Visible = false;
            // 
            // txt渗层
            // 
            this.txt渗层.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt渗层.Location = new System.Drawing.Point(23, 172);
            this.txt渗层.Name = "txt渗层";
            this.txt渗层.Size = new System.Drawing.Size(17, 19);
            this.txt渗层.TabIndex = 54;
            this.txt渗层.Visible = false;
            // 
            // txt货位
            // 
            this.txt货位.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt货位.Location = new System.Drawing.Point(23, 153);
            this.txt货位.Name = "txt货位";
            this.txt货位.Size = new System.Drawing.Size(17, 19);
            this.txt货位.TabIndex = 46;
            this.txt货位.Visible = false;
            // 
            // txt仓库
            // 
            this.txt仓库.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt仓库.Location = new System.Drawing.Point(3, 153);
            this.txt仓库.Name = "txt仓库";
            this.txt仓库.Size = new System.Drawing.Size(14, 19);
            this.txt仓库.TabIndex = 45;
            this.txt仓库.Visible = false;
            // 
            // txt材质
            // 
            this.txt材质.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt材质.Location = new System.Drawing.Point(101, 111);
            this.txt材质.Name = "txt材质";
            this.txt材质.Size = new System.Drawing.Size(113, 19);
            this.txt材质.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(16, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.Text = "材质";
            // 
            // txt工艺要求
            // 
            this.txt工艺要求.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt工艺要求.Location = new System.Drawing.Point(101, 132);
            this.txt工艺要求.Name = "txt工艺要求";
            this.txt工艺要求.Size = new System.Drawing.Size(113, 19);
            this.txt工艺要求.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(14, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.Text = "工艺要求";
            // 
            // btn返回
            // 
            this.btn返回.Location = new System.Drawing.Point(164, 152);
            this.btn返回.Name = "btn返回";
            this.btn返回.Size = new System.Drawing.Size(52, 20);
            this.btn返回.TabIndex = 8;
            this.btn返回.Text = "返回";
            this.btn返回.Click += new System.EventHandler(this.btn返回_Click);
            // 
            // btn确定
            // 
            this.btn确定.Location = new System.Drawing.Point(101, 152);
            this.btn确定.Name = "btn确定";
            this.btn确定.Size = new System.Drawing.Size(52, 20);
            this.btn确定.TabIndex = 7;
            this.btn确定.Text = "确定";
            this.btn确定.Click += new System.EventHandler(this.btn确定_Click);
            // 
            // txt数量
            // 
            this.txt数量.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt数量.Location = new System.Drawing.Point(101, 90);
            this.txt数量.Name = "txt数量";
            this.txt数量.Size = new System.Drawing.Size(113, 19);
            this.txt数量.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(14, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.Text = "数量";
            // 
            // txt亚太零件号
            // 
            this.txt亚太零件号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt亚太零件号.Location = new System.Drawing.Point(101, 68);
            this.txt亚太零件号.Name = "txt亚太零件号";
            this.txt亚太零件号.Size = new System.Drawing.Size(113, 19);
            this.txt亚太零件号.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(14, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.Text = "亚太零件号";
            // 
            // txt规格型号
            // 
            this.txt规格型号.Enabled = false;
            this.txt规格型号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt规格型号.Location = new System.Drawing.Point(101, 47);
            this.txt规格型号.Name = "txt规格型号";
            this.txt规格型号.Size = new System.Drawing.Size(113, 19);
            this.txt规格型号.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(14, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.Text = "规格型号";
            // 
            // txt存货名称
            // 
            this.txt存货名称.Enabled = false;
            this.txt存货名称.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt存货名称.Location = new System.Drawing.Point(101, 26);
            this.txt存货名称.Name = "txt存货名称";
            this.txt存货名称.Size = new System.Drawing.Size(113, 19);
            this.txt存货名称.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(14, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.Text = "存货名称";
            // 
            // txt存货编码
            // 
            this.txt存货编码.Enabled = false;
            this.txt存货编码.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt存货编码.Location = new System.Drawing.Point(101, 5);
            this.txt存货编码.Name = "txt存货编码";
            this.txt存货编码.Size = new System.Drawing.Size(113, 19);
            this.txt存货编码.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(14, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.Text = "存货编码";
            // 
            // txt货仓
            // 
            this.txt货仓.Location = new System.Drawing.Point(182, 48);
            this.txt货仓.Name = "txt货仓";
            this.txt货仓.Size = new System.Drawing.Size(37, 21);
            this.txt货仓.TabIndex = 4;
            this.txt货仓.Validated += new System.EventHandler(this.txt货仓_Validated);
            this.txt货仓.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt货仓_KeyUp);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(153, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.Text = "货仓";
            // 
            // Frm销售出库单_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.txt货仓);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt条形码);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "Frm销售出库单_Edit";
            this.Text = "销售出库单";
            this.Load += new System.EventHandler(this.Frm销售出库单_Edit_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt条形码;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt数量;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt亚太零件号;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt规格型号;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt存货名称;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt存货编码;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn返回;
        private System.Windows.Forms.Button btn确定;
        private System.Windows.Forms.TextBox txt工艺要求;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt材质;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt货仓;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt货位;
        private System.Windows.Forms.TextBox txt仓库;
        private System.Windows.Forms.TextBox txtAutoID;
        private System.Windows.Forms.TextBox txt统一号;
        private System.Windows.Forms.TextBox txt渗层;

    }
}