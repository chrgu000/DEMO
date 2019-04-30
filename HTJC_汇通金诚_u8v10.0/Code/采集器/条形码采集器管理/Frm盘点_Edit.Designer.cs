namespace BarCode
{
    partial class Frm盘点_Edit
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
            this.txt条形码 = new System.Windows.Forms.TextBox();
            this.btn返回 = new System.Windows.Forms.Button();
            this.btn确定 = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(3840, 2085);
            this.msgBox.Location = new System.Drawing.Point(-8, -8);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.Text = "条形码";
            // 
            // txt条形码
            // 
            this.txt条形码.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt条形码.Location = new System.Drawing.Point(65, 13);
            this.txt条形码.Name = "txt条形码";
            this.txt条形码.Size = new System.Drawing.Size(83, 19);
            this.txt条形码.TabIndex = 1;
            this.txt条形码.Validated += new System.EventHandler(this.txt条形码_Validated);
            this.txt条形码.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt条形码_KeyUp);
            // 
            // btn返回
            // 
            this.btn返回.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn返回.Location = new System.Drawing.Point(165, 44);
            this.btn返回.Name = "btn返回";
            this.btn返回.Size = new System.Drawing.Size(52, 20);
            this.btn返回.TabIndex = 8;
            this.btn返回.Text = "返回";
            this.btn返回.Click += new System.EventHandler(this.btn返回_Click);
            // 
            // btn确定
            // 
            this.btn确定.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn确定.Location = new System.Drawing.Point(165, 12);
            this.btn确定.Name = "btn确定";
            this.btn确定.Size = new System.Drawing.Size(52, 20);
            this.btn确定.TabIndex = 7;
            this.btn确定.Text = "确定";
            this.btn确定.Click += new System.EventHandler(this.btn确定_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtInfo.Location = new System.Drawing.Point(3, 70);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(234, 224);
            this.txtInfo.TabIndex = 49;
            // 
            // Frm盘点_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.txt条形码);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn确定);
            this.Controls.Add(this.btn返回);
            this.Menu = null;
            this.Name = "Frm盘点_Edit";
            this.Text = "盘点单";
            this.Load += new System.EventHandler(this.Frm盘点_Edit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt条形码;
        private System.Windows.Forms.Button btn返回;
        private System.Windows.Forms.Button btn确定;
        private System.Windows.Forms.TextBox txtInfo;

    }
}