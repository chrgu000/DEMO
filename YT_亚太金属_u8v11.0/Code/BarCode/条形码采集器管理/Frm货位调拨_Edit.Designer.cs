namespace BarCode
{
    partial class Frm货位调拨_Edit
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
            this.txt换算率 = new System.Windows.Forms.TextBox();
            this.txt件数 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt货位2 = new System.Windows.Forms.TextBox();
            this.txt渗层 = new System.Windows.Forms.TextBox();
            this.txt数量 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt工艺要求 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt货位1 = new System.Windows.Forms.TextBox();
            this.txt材质 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt统一号 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn返回 = new System.Windows.Forms.Button();
            this.btn确定 = new System.Windows.Forms.Button();
            this.txt批号 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt规格型号 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt存货名称 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt存货编码 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt仓库1 = new System.Windows.Forms.TextBox();
            this.txt仓库2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1920, 1018);
            this.msgBox.Location = new System.Drawing.Point(-4, -4);
            this.msgBox.Load += new System.EventHandler(this.msgBox_Load);
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
            this.panel1.Controls.Add(this.txt换算率);
            this.panel1.Controls.Add(this.txt件数);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txt货位2);
            this.panel1.Controls.Add(this.txt渗层);
            this.panel1.Controls.Add(this.txt数量);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt工艺要求);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txt货位1);
            this.panel1.Controls.Add(this.txt材质);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt统一号);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn返回);
            this.panel1.Controls.Add(this.btn确定);
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
            this.panel1.Size = new System.Drawing.Size(234, 194);
            // 
            // txt换算率
            // 
            this.txt换算率.Enabled = false;
            this.txt换算率.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt换算率.Location = new System.Drawing.Point(218, 32);
            this.txt换算率.Name = "txt换算率";
            this.txt换算率.Size = new System.Drawing.Size(13, 19);
            this.txt换算率.TabIndex = 115;
            this.txt换算率.Visible = false;
            // 
            // txt件数
            // 
            this.txt件数.Enabled = false;
            this.txt件数.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt件数.Location = new System.Drawing.Point(166, 32);
            this.txt件数.Name = "txt件数";
            this.txt件数.Size = new System.Drawing.Size(49, 19);
            this.txt件数.TabIndex = 113;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(130, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.Text = "件数";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(145, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 20);
            this.label9.Text = "后";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(14, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 20);
            this.label14.Text = "调整前货仓";
            // 
            // txt货位2
            // 
            this.txt货位2.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt货位2.Location = new System.Drawing.Point(173, 2);
            this.txt货位2.Name = "txt货位2";
            this.txt货位2.Size = new System.Drawing.Size(41, 19);
            this.txt货位2.TabIndex = 102;
            this.txt货位2.Validated += new System.EventHandler(this.txt货位2_Validated);
            // 
            // txt渗层
            // 
            this.txt渗层.Enabled = false;
            this.txt渗层.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt渗层.Location = new System.Drawing.Point(145, 126);
            this.txt渗层.Name = "txt渗层";
            this.txt渗层.Size = new System.Drawing.Size(69, 19);
            this.txt渗层.TabIndex = 86;
            // 
            // txt数量
            // 
            this.txt数量.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt数量.Location = new System.Drawing.Point(50, 32);
            this.txt数量.Name = "txt数量";
            this.txt数量.Size = new System.Drawing.Size(49, 19);
            this.txt数量.TabIndex = 6;
            this.txt数量.Validated += new System.EventHandler(this.txt数量_Validated);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label12.Location = new System.Drawing.Point(119, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.Text = "渗层";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(14, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.Text = "数量";
            // 
            // txt工艺要求
            // 
            this.txt工艺要求.Enabled = false;
            this.txt工艺要求.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt工艺要求.Location = new System.Drawing.Point(145, 146);
            this.txt工艺要求.Name = "txt工艺要求";
            this.txt工艺要求.Size = new System.Drawing.Size(69, 19);
            this.txt工艺要求.TabIndex = 85;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label13.Location = new System.Drawing.Point(119, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 20);
            this.label13.Text = "工艺要求";
            // 
            // txt货位1
            // 
            this.txt货位1.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt货位1.Location = new System.Drawing.Point(96, 2);
            this.txt货位1.Name = "txt货位1";
            this.txt货位1.Size = new System.Drawing.Size(43, 19);
            this.txt货位1.TabIndex = 46;
            this.txt货位1.Validated += new System.EventHandler(this.txt货位1_Validated);
            // 
            // txt材质
            // 
            this.txt材质.Enabled = false;
            this.txt材质.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt材质.Location = new System.Drawing.Point(40, 126);
            this.txt材质.Name = "txt材质";
            this.txt材质.Size = new System.Drawing.Size(69, 19);
            this.txt材质.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(14, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.Text = "材质";
            // 
            // txt统一号
            // 
            this.txt统一号.Enabled = false;
            this.txt统一号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt统一号.Location = new System.Drawing.Point(40, 146);
            this.txt统一号.Name = "txt统一号";
            this.txt统一号.Size = new System.Drawing.Size(69, 19);
            this.txt统一号.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(14, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.Text = "统一号";
            // 
            // btn返回
            // 
            this.btn返回.Location = new System.Drawing.Point(173, 171);
            this.btn返回.Name = "btn返回";
            this.btn返回.Size = new System.Drawing.Size(52, 20);
            this.btn返回.TabIndex = 8;
            this.btn返回.Text = "返回";
            this.btn返回.Click += new System.EventHandler(this.btn返回_Click);
            // 
            // btn确定
            // 
            this.btn确定.Location = new System.Drawing.Point(119, 171);
            this.btn确定.Name = "btn确定";
            this.btn确定.Size = new System.Drawing.Size(52, 20);
            this.btn确定.TabIndex = 7;
            this.btn确定.Text = "确定";
            this.btn确定.Click += new System.EventHandler(this.btn确定_Click);
            // 
            // txt批号
            // 
            this.txt批号.Enabled = false;
            this.txt批号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt批号.Location = new System.Drawing.Point(40, 171);
            this.txt批号.Name = "txt批号";
            this.txt批号.Size = new System.Drawing.Size(69, 19);
            this.txt批号.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(14, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.Text = "批号";
            // 
            // txt规格型号
            // 
            this.txt规格型号.Enabled = false;
            this.txt规格型号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt规格型号.Location = new System.Drawing.Point(101, 104);
            this.txt规格型号.Name = "txt规格型号";
            this.txt规格型号.Size = new System.Drawing.Size(113, 19);
            this.txt规格型号.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(14, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.Text = "规格型号";
            // 
            // txt存货名称
            // 
            this.txt存货名称.Enabled = false;
            this.txt存货名称.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt存货名称.Location = new System.Drawing.Point(101, 79);
            this.txt存货名称.Name = "txt存货名称";
            this.txt存货名称.Size = new System.Drawing.Size(113, 19);
            this.txt存货名称.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(14, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.Text = "存货名称";
            // 
            // txt存货编码
            // 
            this.txt存货编码.Enabled = false;
            this.txt存货编码.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt存货编码.Location = new System.Drawing.Point(101, 57);
            this.txt存货编码.Name = "txt存货编码";
            this.txt存货编码.Size = new System.Drawing.Size(113, 19);
            this.txt存货编码.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(14, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.Text = "存货编码";
            // 
            // txt仓库1
            // 
            this.txt仓库1.Enabled = false;
            this.txt仓库1.Location = new System.Drawing.Point(153, 48);
            this.txt仓库1.Name = "txt仓库1";
            this.txt仓库1.Size = new System.Drawing.Size(23, 21);
            this.txt仓库1.TabIndex = 47;
            this.txt仓库1.Validated += new System.EventHandler(this.txt仓库1_Validated);
            // 
            // txt仓库2
            // 
            this.txt仓库2.Enabled = false;
            this.txt仓库2.Location = new System.Drawing.Point(182, 48);
            this.txt仓库2.Name = "txt仓库2";
            this.txt仓库2.Size = new System.Drawing.Size(23, 21);
            this.txt仓库2.TabIndex = 48;
            this.txt仓库2.Validated += new System.EventHandler(this.txt仓库2_Validated);
            // 
            // Frm货位调整单_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.txt仓库2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt条形码);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt仓库1);
            this.Menu = this.mainMenu1;
            this.Name = "Frm货位调整单_Edit";
            this.Text = "货位调整单";
            this.Load += new System.EventHandler(this.Frm货位调整单_Edit_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt条形码;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt数量;
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
        private System.Windows.Forms.TextBox txt统一号;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt材质;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt货位1;
        private System.Windows.Forms.TextBox txt仓库1;
        private System.Windows.Forms.TextBox txt渗层;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt工艺要求;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt货位2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt件数;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt换算率;
        private System.Windows.Forms.TextBox txt仓库2;

    }
}