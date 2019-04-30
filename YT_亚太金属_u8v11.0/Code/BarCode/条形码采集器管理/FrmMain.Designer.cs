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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn盘点 = new System.Windows.Forms.Button();
            this.btn销售出库 = new System.Windows.Forms.Button();
            this.btn产品入库 = new System.Windows.Forms.Button();
            this.btn材料出库 = new System.Windows.Forms.Button();
            this.btn采购入库 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1366, 719);
            this.msgBox.Location = new System.Drawing.Point(-8, -8);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(320, 320);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btn盘点);
            this.tabPage1.Controls.Add(this.btn销售出库);
            this.tabPage1.Controls.Add(this.btn产品入库);
            this.tabPage1.Controls.Add(this.btn材料出库);
            this.tabPage1.Controls.Add(this.btn采购入库);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(312, 291);
            this.tabPage1.Text = "条形码管理";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(133, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 20);
            this.button3.TabIndex = 14;
            this.button3.Tag = "货位调拨";
            this.button3.Text = "货位调拨";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(133, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 20);
            this.button2.TabIndex = 13;
            this.button2.Tag = "货位查询";
            this.button2.Text = "货位查询";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(133, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 20);
            this.button1.TabIndex = 12;
            this.button1.Tag = "物料查询";
            this.button1.Text = "物料查询";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn盘点
            // 
            this.btn盘点.Location = new System.Drawing.Point(133, 120);
            this.btn盘点.Name = "btn盘点";
            this.btn盘点.Size = new System.Drawing.Size(74, 20);
            this.btn盘点.TabIndex = 11;
            this.btn盘点.Tag = "盘点";
            this.btn盘点.Text = "盘点";
            this.btn盘点.Click += new System.EventHandler(this.btn盘点_Click);
            // 
            // btn销售出库
            // 
            this.btn销售出库.Location = new System.Drawing.Point(28, 120);
            this.btn销售出库.Name = "btn销售出库";
            this.btn销售出库.Size = new System.Drawing.Size(74, 20);
            this.btn销售出库.TabIndex = 10;
            this.btn销售出库.Tag = "销售出库";
            this.btn销售出库.Text = "销售出库";
            this.btn销售出库.Click += new System.EventHandler(this.btn销售出库_Click);
            // 
            // btn产品入库
            // 
            this.btn产品入库.Location = new System.Drawing.Point(28, 94);
            this.btn产品入库.Name = "btn产品入库";
            this.btn产品入库.Size = new System.Drawing.Size(74, 20);
            this.btn产品入库.TabIndex = 9;
            this.btn产品入库.Tag = "产品入库";
            this.btn产品入库.Text = "产品入库";
            this.btn产品入库.Click += new System.EventHandler(this.btn产品入库_Click);
            // 
            // btn材料出库
            // 
            this.btn材料出库.Location = new System.Drawing.Point(28, 68);
            this.btn材料出库.Name = "btn材料出库";
            this.btn材料出库.Size = new System.Drawing.Size(74, 20);
            this.btn材料出库.TabIndex = 8;
            this.btn材料出库.Tag = "材料出库";
            this.btn材料出库.Text = "材料出库";
            this.btn材料出库.Click += new System.EventHandler(this.btn材料出库_Click);
            // 
            // btn采购入库
            // 
            this.btn采购入库.Location = new System.Drawing.Point(28, 42);
            this.btn采购入库.Name = "btn采购入库";
            this.btn采购入库.Size = new System.Drawing.Size(74, 20);
            this.btn采购入库.TabIndex = 7;
            this.btn采购入库.Tag = "采购入库";
            this.btn采购入库.Text = "采购入库";
            this.btn采购入库.Click += new System.EventHandler(this.btn采购入库_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(320, 320);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.Text = "条形码管理工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn采购入库;
        private System.Windows.Forms.Button btn材料出库;
        private System.Windows.Forms.Button btn产品入库;
        private System.Windows.Forms.Button btn销售出库;
        private System.Windows.Forms.Button btn盘点;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;

    }
}

