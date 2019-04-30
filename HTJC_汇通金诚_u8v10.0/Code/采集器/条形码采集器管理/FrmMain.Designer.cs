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
            this.btn盘点 = new System.Windows.Forms.Button();
            this.btn销售出库 = new System.Windows.Forms.Button();
            this.btn产品入库 = new System.Windows.Forms.Button();
            this.btn材料出库 = new System.Windows.Forms.Button();
            this.btn采购入库 = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(3840, 2085);
            this.msgBox.Location = new System.Drawing.Point(-9, -9);
            // 
            // btn盘点
            // 
            this.btn盘点.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn盘点.Location = new System.Drawing.Point(139, 135);
            this.btn盘点.Name = "btn盘点";
            this.btn盘点.Size = new System.Drawing.Size(74, 20);
            this.btn盘点.TabIndex = 11;
            this.btn盘点.Tag = "盘点";
            this.btn盘点.Text = "盘点";
            this.btn盘点.Click += new System.EventHandler(this.btn盘点_Click);
            // 
            // btn销售出库
            // 
            this.btn销售出库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn销售出库.Location = new System.Drawing.Point(139, 87);
            this.btn销售出库.Name = "btn销售出库";
            this.btn销售出库.Size = new System.Drawing.Size(74, 20);
            this.btn销售出库.TabIndex = 10;
            this.btn销售出库.Tag = "销售出库";
            this.btn销售出库.Text = "销售出库";
            this.btn销售出库.Click += new System.EventHandler(this.btn销售出库_Click);
            // 
            // btn产品入库
            // 
            this.btn产品入库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn产品入库.Location = new System.Drawing.Point(21, 87);
            this.btn产品入库.Name = "btn产品入库";
            this.btn产品入库.Size = new System.Drawing.Size(74, 20);
            this.btn产品入库.TabIndex = 9;
            this.btn产品入库.Tag = "产品入库";
            this.btn产品入库.Text = "产品入库";
            this.btn产品入库.Click += new System.EventHandler(this.btn产品入库_Click);
            // 
            // btn材料出库
            // 
            this.btn材料出库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn材料出库.Location = new System.Drawing.Point(139, 41);
            this.btn材料出库.Name = "btn材料出库";
            this.btn材料出库.Size = new System.Drawing.Size(74, 20);
            this.btn材料出库.TabIndex = 8;
            this.btn材料出库.Tag = "材料出库";
            this.btn材料出库.Text = "材料出库";
            this.btn材料出库.Click += new System.EventHandler(this.btn材料出库_Click);
            // 
            // btn采购入库
            // 
            this.btn采购入库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn采购入库.Location = new System.Drawing.Point(21, 41);
            this.btn采购入库.Name = "btn采购入库";
            this.btn采购入库.Size = new System.Drawing.Size(74, 20);
            this.btn采购入库.TabIndex = 7;
            this.btn采购入库.Tag = "采购入库";
            this.btn采购入库.Text = "采购入库";
            this.btn采购入库.Click += new System.EventHandler(this.btn采购入库_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btnExit.Location = new System.Drawing.Point(139, 219);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 20);
            this.btnExit.TabIndex = 12;
            this.btnExit.Tag = "退出";
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btn盘点);
            this.Controls.Add(this.btn销售出库);
            this.Controls.Add(this.btn材料出库);
            this.Controls.Add(this.btn产品入库);
            this.Controls.Add(this.btn采购入库);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "FrmMain";
            this.Text = "条形码管理工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn采购入库;
        private System.Windows.Forms.Button btn材料出库;
        private System.Windows.Forms.Button btn产品入库;
        private System.Windows.Forms.Button btn销售出库;
        private System.Windows.Forms.Button btn盘点;
        private System.Windows.Forms.Button btnExit;

    }
}

