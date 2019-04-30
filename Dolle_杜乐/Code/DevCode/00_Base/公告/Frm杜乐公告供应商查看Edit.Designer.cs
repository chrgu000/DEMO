namespace Base
{
    partial class Frm杜乐公告供应商查看Edit
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
            this.btn退出 = new System.Windows.Forms.Button();
            this.date阅读人 = new DevExpress.XtraEditors.DateEdit();
            this.date制单日期 = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt阅读人 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt制单人 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox内容 = new System.Windows.Forms.RichTextBox();
            this.txt主题 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.date阅读人.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date制单日期.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn退出
            // 
            this.btn退出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn退出.Location = new System.Drawing.Point(650, 340);
            this.btn退出.Name = "btn退出";
            this.btn退出.Size = new System.Drawing.Size(75, 23);
            this.btn退出.TabIndex = 107;
            this.btn退出.Text = "退出";
            this.btn退出.UseVisualStyleBackColor = true;
            this.btn退出.Click += new System.EventHandler(this.btn退出_Click);
            // 
            // date阅读人
            // 
            this.date阅读人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.date阅读人.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.date阅读人.Enabled = false;
            this.date阅读人.Location = new System.Drawing.Point(274, 346);
            this.date阅读人.Name = "date阅读人";
            this.date阅读人.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date阅读人.Size = new System.Drawing.Size(114, 21);
            this.date阅读人.TabIndex = 119;
            // 
            // date制单日期
            // 
            this.date制单日期.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.date制单日期.EditValue = new System.DateTime(2011, 10, 24, 0, 0, 0, 0);
            this.date制单日期.Enabled = false;
            this.date制单日期.Location = new System.Drawing.Point(274, 319);
            this.date制单日期.Name = "date制单日期";
            this.date制单日期.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date制单日期.Size = new System.Drawing.Size(114, 21);
            this.date制单日期.TabIndex = 118;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 117;
            this.label4.Text = "阅读日期";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 116;
            this.label6.Text = "制单日期";
            // 
            // txt阅读人
            // 
            this.txt阅读人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt阅读人.Enabled = false;
            this.txt阅读人.Location = new System.Drawing.Point(60, 349);
            this.txt阅读人.Name = "txt阅读人";
            this.txt阅读人.Size = new System.Drawing.Size(141, 21);
            this.txt阅读人.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 114;
            this.label3.Text = "阅读人";
            // 
            // txt制单人
            // 
            this.txt制单人.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt制单人.Enabled = false;
            this.txt制单人.Location = new System.Drawing.Point(60, 322);
            this.txt制单人.Name = "txt制单人";
            this.txt制单人.Size = new System.Drawing.Size(141, 21);
            this.txt制单人.TabIndex = 113;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 112;
            this.label2.Text = "制单人";
            // 
            // richTextBox内容
            // 
            this.richTextBox内容.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox内容.Enabled = false;
            this.richTextBox内容.Location = new System.Drawing.Point(61, 45);
            this.richTextBox内容.Name = "richTextBox内容";
            this.richTextBox内容.Size = new System.Drawing.Size(680, 265);
            this.richTextBox内容.TabIndex = 111;
            this.richTextBox内容.Text = "";
            // 
            // txt主题
            // 
            this.txt主题.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt主题.Enabled = false;
            this.txt主题.Location = new System.Drawing.Point(60, 14);
            this.txt主题.Name = "txt主题";
            this.txt主题.Size = new System.Drawing.Size(681, 21);
            this.txt主题.TabIndex = 110;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 108;
            this.label5.Text = "内容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 109;
            this.label1.Text = "主题";
            // 
            // Frm杜乐公告供应商查看Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 379);
            this.Controls.Add(this.date阅读人);
            this.Controls.Add(this.date制单日期);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt阅读人);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt制单人);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox内容);
            this.Controls.Add(this.txt主题);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn退出);
            this.Name = "Frm杜乐公告供应商查看Edit";
            this.Text = "杜乐公告";
            this.Load += new System.EventHandler(this.Frm杜乐公告供应商查看Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.date阅读人.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date制单日期.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn退出;
        private DevExpress.XtraEditors.DateEdit date阅读人;
        private DevExpress.XtraEditors.DateEdit date制单日期;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt阅读人;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt制单人;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox内容;
        private System.Windows.Forms.TextBox txt主题;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}