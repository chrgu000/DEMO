namespace BarCode
{
    partial class Frm现品票登记_Edit
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
            this.txt条形码扫描 = new System.Windows.Forms.TextBox();
            this.btn返回 = new System.Windows.Forms.Button();
            this.btn确定 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt收容数 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt条形码 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt箱数 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt订单编号 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt纳入指示日期 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt送货数量 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt箱种 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt品番 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt产品名称 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt门号 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt供应商 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(2560, 1377);
            this.msgBox.Location = new System.Drawing.Point(-8, -8);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.Text = "条形码";
            // 
            // txt条形码扫描
            // 
            this.txt条形码扫描.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt条形码扫描.Location = new System.Drawing.Point(70, 19);
            this.txt条形码扫描.Multiline = true;
            this.txt条形码扫描.Name = "txt条形码扫描";
            this.txt条形码扫描.Size = new System.Drawing.Size(562, 23);
            this.txt条形码扫描.TabIndex = 1;
            this.txt条形码扫描.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt单据号扫描_KeyUp);
            // 
            // btn返回
            // 
            this.btn返回.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn返回.Location = new System.Drawing.Point(551, 419);
            this.btn返回.Name = "btn返回";
            this.btn返回.Size = new System.Drawing.Size(52, 20);
            this.btn返回.TabIndex = 8;
            this.btn返回.Text = "返回";
            this.btn返回.Click += new System.EventHandler(this.btn返回_Click);
            // 
            // btn确定
            // 
            this.btn确定.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn确定.Location = new System.Drawing.Point(476, 419);
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
            this.panel1.Controls.Add(this.txt收容数);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt条形码);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txt箱数);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txt订单编号);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txt纳入指示日期);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt送货数量);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt箱种);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt品番);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt产品名称);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt门号);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt供应商);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(4, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 364);
            // 
            // txt收容数
            // 
            this.txt收容数.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt收容数.Enabled = false;
            this.txt收容数.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt收容数.Location = new System.Drawing.Point(102, 125);
            this.txt收容数.Name = "txt收容数";
            this.txt收容数.Size = new System.Drawing.Size(526, 19);
            this.txt收容数.TabIndex = 42;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label11.Location = new System.Drawing.Point(6, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 20);
            this.label11.Text = "收容数";
            // 
            // txt条形码
            // 
            this.txt条形码.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt条形码.Enabled = false;
            this.txt条形码.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt条形码.Location = new System.Drawing.Point(102, 240);
            this.txt条形码.Multiline = true;
            this.txt条形码.Name = "txt条形码";
            this.txt条形码.Size = new System.Drawing.Size(526, 109);
            this.txt条形码.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(6, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.Text = "条形码";
            // 
            // txt箱数
            // 
            this.txt箱数.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt箱数.Enabled = false;
            this.txt箱数.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt箱数.Location = new System.Drawing.Point(102, 194);
            this.txt箱数.Name = "txt箱数";
            this.txt箱数.Size = new System.Drawing.Size(526, 19);
            this.txt箱数.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label12.Location = new System.Drawing.Point(6, 198);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 20);
            this.label12.Text = "箱数";
            // 
            // txt订单编号
            // 
            this.txt订单编号.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt订单编号.Enabled = false;
            this.txt订单编号.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt订单编号.Location = new System.Drawing.Point(102, 217);
            this.txt订单编号.Name = "txt订单编号";
            this.txt订单编号.Size = new System.Drawing.Size(526, 19);
            this.txt订单编号.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(6, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.Text = "订单编号";
            // 
            // txt纳入指示日期
            // 
            this.txt纳入指示日期.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt纳入指示日期.Enabled = false;
            this.txt纳入指示日期.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt纳入指示日期.Location = new System.Drawing.Point(102, 171);
            this.txt纳入指示日期.Name = "txt纳入指示日期";
            this.txt纳入指示日期.Size = new System.Drawing.Size(526, 19);
            this.txt纳入指示日期.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(6, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.Text = "纳入指示日期";
            // 
            // txt送货数量
            // 
            this.txt送货数量.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt送货数量.Enabled = false;
            this.txt送货数量.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt送货数量.Location = new System.Drawing.Point(102, 148);
            this.txt送货数量.Name = "txt送货数量";
            this.txt送货数量.Size = new System.Drawing.Size(526, 19);
            this.txt送货数量.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(6, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.Text = "送货数量";
            // 
            // txt箱种
            // 
            this.txt箱种.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt箱种.Enabled = false;
            this.txt箱种.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt箱种.Location = new System.Drawing.Point(102, 102);
            this.txt箱种.Name = "txt箱种";
            this.txt箱种.Size = new System.Drawing.Size(526, 19);
            this.txt箱种.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(6, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.Text = "箱种";
            // 
            // txt品番
            // 
            this.txt品番.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt品番.Enabled = false;
            this.txt品番.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt品番.Location = new System.Drawing.Point(102, 79);
            this.txt品番.Name = "txt品番";
            this.txt品番.Size = new System.Drawing.Size(526, 19);
            this.txt品番.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(6, 78);
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
            this.txt产品名称.Location = new System.Drawing.Point(102, 56);
            this.txt产品名称.Name = "txt产品名称";
            this.txt产品名称.Size = new System.Drawing.Size(526, 19);
            this.txt产品名称.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.Text = "产品名称";
            // 
            // txt门号
            // 
            this.txt门号.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt门号.Enabled = false;
            this.txt门号.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt门号.Location = new System.Drawing.Point(102, 33);
            this.txt门号.Name = "txt门号";
            this.txt门号.Size = new System.Drawing.Size(526, 19);
            this.txt门号.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.Text = "门号";
            // 
            // txt供应商
            // 
            this.txt供应商.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt供应商.Enabled = false;
            this.txt供应商.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt供应商.Location = new System.Drawing.Point(102, 10);
            this.txt供应商.Name = "txt供应商";
            this.txt供应商.Size = new System.Drawing.Size(526, 19);
            this.txt供应商.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.Text = "供应商";
            // 
            // Frm现品票登记_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt条形码扫描);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn返回);
            this.Controls.Add(this.btn确定);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Frm现品票登记_Edit";
            this.Text = "现品票登记单";
            this.Load += new System.EventHandler(this.Frm现品票登记_Edit_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt条形码扫描;
        private System.Windows.Forms.Button btn返回;
        private System.Windows.Forms.Button btn确定;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt供应商;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt品番;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt产品名称;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt门号;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt订单编号;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt纳入指示日期;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt送货数量;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt箱种;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt箱数;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt条形码;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt收容数;
        private System.Windows.Forms.Label label11;

    }
}