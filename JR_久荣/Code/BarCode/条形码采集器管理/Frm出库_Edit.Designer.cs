namespace BarCode
{
    partial class Frm出库_Edit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt二维码 = new System.Windows.Forms.TextBox();
            this.btn返回 = new System.Windows.Forms.Button();
            this.btn确定 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txt条形码 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt箱数 = new System.Windows.Forms.TextBox();
            this.txt仓库 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt单据序号 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt单据号 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt单据子表序号 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt数量 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt品番 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt产品名称 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt供应商 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.Text = "二维码";
            // 
            // txt二维码
            // 
            this.txt二维码.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt二维码.Location = new System.Drawing.Point(96, 19);
            this.txt二维码.Multiline = true;
            this.txt二维码.Name = "txt二维码";
            this.txt二维码.Size = new System.Drawing.Size(526, 23);
            this.txt二维码.TabIndex = 1;
            this.txt二维码.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt二维码_KeyUp);
            // 
            // btn返回
            // 
            this.btn返回.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn返回.Location = new System.Drawing.Point(556, 432);
            this.btn返回.Name = "btn返回";
            this.btn返回.Size = new System.Drawing.Size(52, 20);
            this.btn返回.TabIndex = 8;
            this.btn返回.Text = "返回";
            this.btn返回.Click += new System.EventHandler(this.btn返回_Click);
            // 
            // btn确定
            // 
            this.btn确定.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn确定.Location = new System.Drawing.Point(488, 432);
            this.btn确定.Name = "btn确定";
            this.btn确定.Size = new System.Drawing.Size(52, 20);
            this.btn确定.TabIndex = 7;
            this.btn确定.Text = "确定";
            this.btn确定.Click += new System.EventHandler(this.btn确定_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt条形码);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt箱数);
            this.panel1.Controls.Add(this.txt仓库);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt单据序号);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txt单据号);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txt单据子表序号);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt数量);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt品番);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt产品名称);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt供应商);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(5, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 378);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(36, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.Text = "箱数";
            // 
            // txt条形码
            // 
            this.txt条形码.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt条形码.Location = new System.Drawing.Point(91, 217);
            this.txt条形码.Multiline = true;
            this.txt条形码.Name = "txt条形码";
            this.txt条形码.Size = new System.Drawing.Size(526, 158);
            this.txt条形码.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(36, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.Text = "二维码";
            // 
            // txt箱数
            // 
            this.txt箱数.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt箱数.Enabled = false;
            this.txt箱数.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt箱数.Location = new System.Drawing.Point(91, 104);
            this.txt箱数.Name = "txt箱数";
            this.txt箱数.Size = new System.Drawing.Size(526, 19);
            this.txt箱数.TabIndex = 47;
            // 
            // txt仓库
            // 
            this.txt仓库.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt仓库.Enabled = false;
            this.txt仓库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt仓库.Location = new System.Drawing.Point(91, 192);
            this.txt仓库.Name = "txt仓库";
            this.txt仓库.Size = new System.Drawing.Size(526, 19);
            this.txt仓库.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(36, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.Text = "仓库";
            // 
            // txt单据序号
            // 
            this.txt单据序号.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt单据序号.Enabled = false;
            this.txt单据序号.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt单据序号.Location = new System.Drawing.Point(91, 172);
            this.txt单据序号.Multiline = true;
            this.txt单据序号.Name = "txt单据序号";
            this.txt单据序号.Size = new System.Drawing.Size(526, 20);
            this.txt单据序号.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(36, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.Text = "单据序号";
            // 
            // txt单据号
            // 
            this.txt单据号.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt单据号.Enabled = false;
            this.txt单据号.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt单据号.Location = new System.Drawing.Point(91, 129);
            this.txt单据号.Name = "txt单据号";
            this.txt单据号.Size = new System.Drawing.Size(526, 19);
            this.txt单据号.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label12.Location = new System.Drawing.Point(25, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.Text = "单据号";
            // 
            // txt单据子表序号
            // 
            this.txt单据子表序号.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt单据子表序号.Enabled = false;
            this.txt单据子表序号.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt单据子表序号.Location = new System.Drawing.Point(91, 150);
            this.txt单据子表序号.Name = "txt单据子表序号";
            this.txt单据子表序号.Size = new System.Drawing.Size(526, 19);
            this.txt单据子表序号.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(8, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.Text = "单据子表序号";
            // 
            // txt数量
            // 
            this.txt数量.Enabled = false;
            this.txt数量.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt数量.Location = new System.Drawing.Point(91, 79);
            this.txt数量.Name = "txt数量";
            this.txt数量.Size = new System.Drawing.Size(526, 19);
            this.txt数量.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(36, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.Text = "数量";
            // 
            // txt品番
            // 
            this.txt品番.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt品番.Enabled = false;
            this.txt品番.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt品番.Location = new System.Drawing.Point(91, 56);
            this.txt品番.Name = "txt品番";
            this.txt品番.Size = new System.Drawing.Size(526, 19);
            this.txt品番.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(36, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.Text = "品番";
            // 
            // txt产品名称
            // 
            this.txt产品名称.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt产品名称.Enabled = false;
            this.txt产品名称.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt产品名称.Location = new System.Drawing.Point(91, 33);
            this.txt产品名称.Name = "txt产品名称";
            this.txt产品名称.Size = new System.Drawing.Size(526, 19);
            this.txt产品名称.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(25, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.Text = "产品名称";
            // 
            // txt供应商
            // 
            this.txt供应商.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt供应商.Enabled = false;
            this.txt供应商.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt供应商.Location = new System.Drawing.Point(91, 10);
            this.txt供应商.Name = "txt供应商";
            this.txt供应商.Size = new System.Drawing.Size(526, 19);
            this.txt供应商.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(36, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.Text = "供应商";
            // 
            // Frm出库_Edit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt二维码);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn返回);
            this.Controls.Add(this.btn确定);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Frm出库_Edit";
            this.Text = "出库";
            this.Load += new System.EventHandler(this.Frm出库_Edit_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt二维码;
        private System.Windows.Forms.Button btn返回;
        private System.Windows.Forms.Button btn确定;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt单据序号;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt单据号;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt单据子表序号;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt数量;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt品番;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt产品名称;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt供应商;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt仓库;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt箱数;
        private System.Windows.Forms.TextBox txt条形码;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;

    }
}