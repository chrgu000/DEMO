namespace BarCode
{
    partial class Frm盘点_Edit
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
            this.txt盘点单子表ID = new System.Windows.Forms.TextBox();
            this.txt炉号 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt长度 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn返回 = new System.Windows.Forms.Button();
            this.btn确定 = new System.Windows.Forms.Button();
            this.txt数量 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt批号 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt规格型号 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt存货名称 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt存货编码 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1366, 706);
            this.msgBox.Location = new System.Drawing.Point(-8, -8);
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
            this.txt条形码.Size = new System.Drawing.Size(63, 21);
            this.txt条形码.TabIndex = 1;
            this.txt条形码.Validated += new System.EventHandler(this.txt条形码_Validated);
            this.txt条形码.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt条形码_KeyUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt盘点单子表ID);
            this.panel1.Controls.Add(this.txt炉号);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt长度);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn返回);
            this.panel1.Controls.Add(this.btn确定);
            this.panel1.Controls.Add(this.txt数量);
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
            this.panel1.Size = new System.Drawing.Size(234, 194);
            // 
            // txt盘点单子表ID
            // 
            this.txt盘点单子表ID.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt盘点单子表ID.Location = new System.Drawing.Point(16, 138);
            this.txt盘点单子表ID.Name = "txt盘点单子表ID";
            this.txt盘点单子表ID.Size = new System.Drawing.Size(40, 19);
            this.txt盘点单子表ID.TabIndex = 45;
            this.txt盘点单子表ID.Visible = false;
            // 
            // txt炉号
            // 
            this.txt炉号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt炉号.Location = new System.Drawing.Point(150, 67);
            this.txt炉号.Name = "txt炉号";
            this.txt炉号.Size = new System.Drawing.Size(64, 19);
            this.txt炉号.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(115, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.Text = "炉号";
            // 
            // txt长度
            // 
            this.txt长度.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt长度.Location = new System.Drawing.Point(150, 90);
            this.txt长度.Name = "txt长度";
            this.txt长度.Size = new System.Drawing.Size(64, 19);
            this.txt长度.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(115, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.Text = "长度";
            // 
            // btn返回
            // 
            this.btn返回.Location = new System.Drawing.Point(162, 140);
            this.btn返回.Name = "btn返回";
            this.btn返回.Size = new System.Drawing.Size(52, 20);
            this.btn返回.TabIndex = 8;
            this.btn返回.Text = "返回";
            this.btn返回.Click += new System.EventHandler(this.btn返回_Click);
            // 
            // btn确定
            // 
            this.btn确定.Location = new System.Drawing.Point(101, 140);
            this.btn确定.Name = "btn确定";
            this.btn确定.Size = new System.Drawing.Size(52, 20);
            this.btn确定.TabIndex = 7;
            this.btn确定.Text = "确定";
            this.btn确定.Click += new System.EventHandler(this.btn确定_Click);
            // 
            // txt数量
            // 
            this.txt数量.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt数量.Location = new System.Drawing.Point(40, 90);
            this.txt数量.Name = "txt数量";
            this.txt数量.Size = new System.Drawing.Size(69, 19);
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
            // txt批号
            // 
            this.txt批号.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.txt批号.Location = new System.Drawing.Point(40, 67);
            this.txt批号.Name = "txt批号";
            this.txt批号.Size = new System.Drawing.Size(69, 19);
            this.txt批号.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(14, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.Text = "批号";
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
            // Frm盘点_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt条形码);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "Frm盘点_Edit";
            this.Text = "盘点单";
            this.Load += new System.EventHandler(this.Frm盘点_Edit_Load);
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
        private System.Windows.Forms.TextBox txt长度;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt炉号;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt盘点单子表ID;

    }
}