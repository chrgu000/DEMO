namespace BarCode
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btn缴库产品入库 = new System.Windows.Forms.Button();
            this.btn委外毛坯退回 = new System.Windows.Forms.Button();
            this.btn委外生单发料 = new System.Windows.Forms.Button();
            this.btn其他出库 = new System.Windows.Forms.Button();
            this.btn其他入库 = new System.Windows.Forms.Button();
            this.btn到货 = new System.Windows.Forms.Button();
            this.btn产品入库货位 = new System.Windows.Forms.Button();
            this.btn材料出库 = new System.Windows.Forms.Button();
            this.btn调拨出库 = new System.Windows.Forms.Button();
            this.btn材料入库 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgBox
            // 
            this.msgBox.ClientSize = new System.Drawing.Size(1920, 1031);
            this.msgBox.Location = new System.Drawing.Point(-9, -9);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn缴库产品入库);
            this.tabPage1.Controls.Add(this.btn委外毛坯退回);
            this.tabPage1.Controls.Add(this.btn委外生单发料);
            this.tabPage1.Controls.Add(this.btn其他出库);
            this.tabPage1.Controls.Add(this.btn其他入库);
            this.tabPage1.Controls.Add(this.btn到货);
            this.tabPage1.Controls.Add(this.btn产品入库货位);
            this.tabPage1.Controls.Add(this.btn材料出库);
            this.tabPage1.Controls.Add(this.btn调拨出库);
            this.tabPage1.Controls.Add(this.btn材料入库);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(232, 231);
            this.tabPage1.Text = "货位管理";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 21);
            this.label1.Text = "仓库条形码管理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn缴库产品入库
            // 
            this.btn缴库产品入库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn缴库产品入库.Location = new System.Drawing.Point(7, 125);
            this.btn缴库产品入库.Name = "btn缴库产品入库";
            this.btn缴库产品入库.Size = new System.Drawing.Size(105, 31);
            this.btn缴库产品入库.TabIndex = 10;
            this.btn缴库产品入库.Text = "缴库产品入库";
            this.btn缴库产品入库.Click += new System.EventHandler(this.btn缴库产品入库_Click);
            // 
            // btn委外毛坯退回
            // 
            this.btn委外毛坯退回.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn委外毛坯退回.Location = new System.Drawing.Point(128, 41);
            this.btn委外毛坯退回.Name = "btn委外毛坯退回";
            this.btn委外毛坯退回.Size = new System.Drawing.Size(105, 28);
            this.btn委外毛坯退回.TabIndex = 9;
            this.btn委外毛坯退回.Text = "委外毛坯退回";
            this.btn委外毛坯退回.Click += new System.EventHandler(this.btn委外毛坯退回_Click);
            // 
            // btn委外生单发料
            // 
            this.btn委外生单发料.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn委外生单发料.Location = new System.Drawing.Point(128, 84);
            this.btn委外生单发料.Name = "btn委外生单发料";
            this.btn委外生单发料.Size = new System.Drawing.Size(105, 28);
            this.btn委外生单发料.TabIndex = 8;
            this.btn委外生单发料.Text = "委外生单发料";
            this.btn委外生单发料.Click += new System.EventHandler(this.btn委外生单发料_Click);
            // 
            // btn其他出库
            // 
            this.btn其他出库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn其他出库.Location = new System.Drawing.Point(128, 202);
            this.btn其他出库.Name = "btn其他出库";
            this.btn其他出库.Size = new System.Drawing.Size(105, 28);
            this.btn其他出库.TabIndex = 7;
            this.btn其他出库.Tag = "68852235";
            this.btn其他出库.Text = "其他出库货位";
            this.btn其他出库.Click += new System.EventHandler(this.btn其他出库_Click);
            // 
            // btn其他入库
            // 
            this.btn其他入库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn其他入库.Location = new System.Drawing.Point(7, 202);
            this.btn其他入库.Name = "btn其他入库";
            this.btn其他入库.Size = new System.Drawing.Size(105, 28);
            this.btn其他入库.TabIndex = 6;
            this.btn其他入库.Text = "其他入库货位";
            this.btn其他入库.Click += new System.EventHandler(this.btn其他入库_Click);
            // 
            // btn到货
            // 
            this.btn到货.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn到货.Location = new System.Drawing.Point(7, 41);
            this.btn到货.Name = "btn到货";
            this.btn到货.Size = new System.Drawing.Size(105, 28);
            this.btn到货.TabIndex = 0;
            this.btn到货.Text = "到  货";
            this.btn到货.Click += new System.EventHandler(this.btn到货_Click);
            // 
            // btn产品入库货位
            // 
            this.btn产品入库货位.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn产品入库货位.Location = new System.Drawing.Point(7, 164);
            this.btn产品入库货位.Name = "btn产品入库货位";
            this.btn产品入库货位.Size = new System.Drawing.Size(105, 28);
            this.btn产品入库货位.TabIndex = 4;
            this.btn产品入库货位.Text = "产品入库货位";
            this.btn产品入库货位.Click += new System.EventHandler(this.btn产品入库货位_Click);
            // 
            // btn材料出库
            // 
            this.btn材料出库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn材料出库.Location = new System.Drawing.Point(128, 125);
            this.btn材料出库.Name = "btn材料出库";
            this.btn材料出库.Size = new System.Drawing.Size(105, 28);
            this.btn材料出库.TabIndex = 5;
            this.btn材料出库.Text = "委外材料出库";
            this.btn材料出库.Click += new System.EventHandler(this.btn委外材料出库_Click);
            // 
            // btn调拨出库
            // 
            this.btn调拨出库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn调拨出库.Location = new System.Drawing.Point(128, 164);
            this.btn调拨出库.Name = "btn调拨出库";
            this.btn调拨出库.Size = new System.Drawing.Size(105, 28);
            this.btn调拨出库.TabIndex = 2;
            this.btn调拨出库.Text = "调拨出库";
            this.btn调拨出库.Click += new System.EventHandler(this.btn调拨出库_Click);
            // 
            // btn材料入库
            // 
            this.btn材料入库.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.btn材料入库.Location = new System.Drawing.Point(7, 84);
            this.btn材料入库.Name = "btn材料入库";
            this.btn材料入库.Size = new System.Drawing.Size(105, 28);
            this.btn材料入库.TabIndex = 1;
            this.btn材料入库.Text = "材料入库";
            this.btn材料入库.Click += new System.EventHandler(this.btn采购入库_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 265);
            this.tabControl1.TabIndex = 6;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn缴库产品入库;
        private System.Windows.Forms.Button btn委外毛坯退回;
        private System.Windows.Forms.Button btn委外生单发料;
        private System.Windows.Forms.Button btn其他出库;
        private System.Windows.Forms.Button btn其他入库;
        private System.Windows.Forms.Button btn到货;
        private System.Windows.Forms.Button btn产品入库货位;
        private System.Windows.Forms.Button btn材料出库;
        private System.Windows.Forms.Button btn调拨出库;
        private System.Windows.Forms.Button btn材料入库;
        private System.Windows.Forms.TabControl tabControl1;


    }
}

