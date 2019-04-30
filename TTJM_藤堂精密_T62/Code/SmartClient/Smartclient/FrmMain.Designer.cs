namespace Smartclient
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label11 = new System.Windows.Forms.Label();
            this.btn工序转移 = new System.Windows.Forms.Button();
            this.btn退出 = new System.Windows.Forms.Button();
            this.btn条形码查看 = new System.Windows.Forms.Button();
            this.btn工单查看 = new System.Windows.Forms.Button();
            this.labelUid = new System.Windows.Forms.Label();
            this.btn产品入库 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(240, 23);
            this.label11.Text = "条形码管理工具";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn工序转移
            // 
            this.btn工序转移.Location = new System.Drawing.Point(73, 32);
            this.btn工序转移.Name = "btn工序转移";
            this.btn工序转移.Size = new System.Drawing.Size(93, 20);
            this.btn工序转移.TabIndex = 2;
            this.btn工序转移.Text = "工序转移";
            this.btn工序转移.Click += new System.EventHandler(this.btn工序转移_Click);
            // 
            // btn退出
            // 
            this.btn退出.Location = new System.Drawing.Point(73, 207);
            this.btn退出.Name = "btn退出";
            this.btn退出.Size = new System.Drawing.Size(72, 20);
            this.btn退出.TabIndex = 4;
            this.btn退出.Text = "退出";
            this.btn退出.Click += new System.EventHandler(this.btn退出_Click);
            // 
            // btn条形码查看
            // 
            this.btn条形码查看.Location = new System.Drawing.Point(73, 96);
            this.btn条形码查看.Name = "btn条形码查看";
            this.btn条形码查看.Size = new System.Drawing.Size(93, 20);
            this.btn条形码查看.TabIndex = 5;
            this.btn条形码查看.Text = "条形码查看";
            this.btn条形码查看.Click += new System.EventHandler(this.btn条形码查看_Click);
            // 
            // btn工单查看
            // 
            this.btn工单查看.Location = new System.Drawing.Point(73, 128);
            this.btn工单查看.Name = "btn工单查看";
            this.btn工单查看.Size = new System.Drawing.Size(93, 20);
            this.btn工单查看.TabIndex = 6;
            this.btn工单查看.Text = "工单查看";
            this.btn工单查看.Click += new System.EventHandler(this.btn工单查看_Click);
            // 
            // labelUid
            // 
            this.labelUid.Location = new System.Drawing.Point(3, 248);
            this.labelUid.Name = "labelUid";
            this.labelUid.Size = new System.Drawing.Size(100, 20);
            this.labelUid.Text = "label1";
            // 
            // btn产品入库
            // 
            this.btn产品入库.Location = new System.Drawing.Point(73, 64);
            this.btn产品入库.Name = "btn产品入库";
            this.btn产品入库.Size = new System.Drawing.Size(93, 20);
            this.btn产品入库.TabIndex = 8;
            this.btn产品入库.Text = "产品入库";
            this.btn产品入库.Click += new System.EventHandler(this.btn产品入库_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btn产品入库);
            this.Controls.Add(this.labelUid);
            this.Controls.Add(this.btn工单查看);
            this.Controls.Add(this.btn条形码查看);
            this.Controls.Add(this.btn退出);
            this.Controls.Add(this.btn工序转移);
            this.Controls.Add(this.label11);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.Text = "条形码管理工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn工序转移;
        private System.Windows.Forms.Button btn退出;
        private System.Windows.Forms.Button btn条形码查看;
        private System.Windows.Forms.Button btn工单查看;
        private System.Windows.Forms.Label labelUid;
        private System.Windows.Forms.Button btn产品入库;



    }
}

