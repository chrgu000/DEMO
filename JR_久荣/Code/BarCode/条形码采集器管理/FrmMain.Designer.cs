namespace BarCode
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btn出库 = new System.Windows.Forms.Button();
            this.btn现品票登记 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(2560, 1377);
            this.msgBox.Location = new System.Drawing.Point(-8, -8);
            // 
            // btn出库
            // 
            this.btn出库.Location = new System.Drawing.Point(73, 73);
            this.btn出库.Name = "btn出库";
            this.btn出库.Size = new System.Drawing.Size(97, 20);
            this.btn出库.TabIndex = 8;
            this.btn出库.Tag = "材料出库";
            this.btn出库.Text = "出库";
            this.btn出库.Visible = false;
            this.btn出库.Click += new System.EventHandler(this.btn出库_Click);
            // 
            // btn现品票登记
            // 
            this.btn现品票登记.Location = new System.Drawing.Point(73, 33);
            this.btn现品票登记.Name = "btn现品票登记";
            this.btn现品票登记.Size = new System.Drawing.Size(97, 20);
            this.btn现品票登记.TabIndex = 7;
            this.btn现品票登记.Tag = "采购入库";
            this.btn现品票登记.Text = "现品票登记";
            this.btn现品票登记.Click += new System.EventHandler(this.btn现品票登记_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(73, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 20);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Tag = "退出";
            this.btnCancel.Text = "退出";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btn出库);
            this.Controls.Add(this.btn现品票登记);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FrmMain";
            this.Text = "现品票管理";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn现品票登记;
        private System.Windows.Forms.Button btn出库;
        private System.Windows.Forms.Button btnCancel;

    }
}

