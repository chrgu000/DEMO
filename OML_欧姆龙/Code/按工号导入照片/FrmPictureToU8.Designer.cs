namespace TH.Tooles.U8
{
    partial class FrmPictureToU8
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSQLConn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label成功 = new System.Windows.Forms.Label();
            this.label失败 = new System.Windows.Forms.Label();
            this.listBox成功 = new System.Windows.Forms.ListBox();
            this.listBox失败 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(11, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "加载并保存";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(105, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSQLConn
            // 
            this.txtSQLConn.Location = new System.Drawing.Point(83, 48);
            this.txtSQLConn.Name = "txtSQLConn";
            this.txtSQLConn.Size = new System.Drawing.Size(543, 21);
            this.txtSQLConn.TabIndex = 4;
            this.txtSQLConn.Text = "server=WIN2008u8v12;uid=sa;pwd=189.cn;database=UFDATA_001_2015";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "数据库连接";
            // 
            // label成功
            // 
            this.label成功.AutoSize = true;
            this.label成功.Location = new System.Drawing.Point(12, 76);
            this.label成功.Name = "label成功";
            this.label成功.Size = new System.Drawing.Size(53, 12);
            this.label成功.TabIndex = 2;
            this.label成功.Text = "成功列表";
            // 
            // label失败
            // 
            this.label失败.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label失败.AutoSize = true;
            this.label失败.Location = new System.Drawing.Point(314, 76);
            this.label失败.Name = "label失败";
            this.label失败.Size = new System.Drawing.Size(53, 12);
            this.label失败.TabIndex = 3;
            this.label失败.Text = "失败列表";
            // 
            // listBox成功
            // 
            this.listBox成功.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox成功.FormattingEnabled = true;
            this.listBox成功.ItemHeight = 12;
            this.listBox成功.Location = new System.Drawing.Point(7, 102);
            this.listBox成功.Name = "listBox成功";
            this.listBox成功.Size = new System.Drawing.Size(293, 388);
            this.listBox成功.TabIndex = 3;
            // 
            // listBox失败
            // 
            this.listBox失败.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox失败.FormattingEnabled = true;
            this.listBox失败.ItemHeight = 12;
            this.listBox失败.Location = new System.Drawing.Point(310, 102);
            this.listBox失败.Name = "listBox失败";
            this.listBox失败.Size = new System.Drawing.Size(293, 388);
            this.listBox失败.TabIndex = 8;
            // 
            // FrmPictureToU8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 488);
            this.Controls.Add(this.label失败);
            this.Controls.Add(this.label成功);
            this.Controls.Add(this.listBox失败);
            this.Controls.Add(this.listBox成功);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSQLConn);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPictureToU8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "根据工号导入照片";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSQLConn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label成功;
        private System.Windows.Forms.Label label失败;
        private System.Windows.Forms.ListBox listBox成功;
        private System.Windows.Forms.ListBox listBox失败;
    }
}

