namespace 系统服务
{
    partial class FrmBaseSEL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaseSEL));
            this.childLF = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.toolStripMenuBtn = new System.Windows.Forms.ToolStrip();
            this.Exit = new System.Windows.Forms.ToolStripButton();
            this.Ensure = new System.Windows.Forms.ToolStripButton();
            this.Sel = new System.Windows.Forms.ToolStripButton();
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.toolStripMenuBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenuBtn
            // 
            this.toolStripMenuBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit,
            this.Ensure,
            this.Sel});
            this.toolStripMenuBtn.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenuBtn.Name = "toolStripMenuBtn";
            this.toolStripMenuBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripMenuBtn.Size = new System.Drawing.Size(861, 25);
            this.toolStripMenuBtn.TabIndex = 4;
            this.toolStripMenuBtn.Text = "toolStrip1";
            this.toolStripMenuBtn.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // Exit
            // 
            this.Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Exit.ImageTransparentColor = System.Drawing.Color.MediumPurple;
            this.Exit.Name = "Exit";
            this.Exit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Exit.Size = new System.Drawing.Size(36, 22);
            this.Exit.Text = "退出";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Ensure
            // 
            this.Ensure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Ensure.Image = ((System.Drawing.Image)(resources.GetObject("Ensure.Image")));
            this.Ensure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Ensure.Name = "Ensure";
            this.Ensure.Size = new System.Drawing.Size(36, 22);
            this.Ensure.Text = "确定";
            // 
            // Sel
            // 
            this.Sel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Sel.Image = ((System.Drawing.Image)(resources.GetObject("Sel.Image")));
            this.Sel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sel.Name = "Sel";
            this.Sel.Size = new System.Drawing.Size(36, 22);
            this.Sel.Text = "查询";
            // 
            // layoutControl
            // 
            this.layoutControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl.Location = new System.Drawing.Point(4, 28);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(221, 143, 250, 350);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(851, 372);
            this.layoutControl.TabIndex = 5;
            this.layoutControl.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(851, 372);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // FrmBaseSEL
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 403);
            this.Controls.Add(this.layoutControl);
            this.Controls.Add(this.toolStripMenuBtn);
            this.Name = "FrmBaseSEL";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "FrmBaseInfo";
            this.Load += new System.EventHandler(this.FrmBaseSEL_Load);
            this.toolStripMenuBtn.ResumeLayout(false);
            this.toolStripMenuBtn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.LookAndFeel.DefaultLookAndFeel childLF;
        protected System.Windows.Forms.ToolStrip toolStripMenuBtn;
        private System.Windows.Forms.ToolStripButton Exit;
        private System.Windows.Forms.ToolStripButton Sel;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.ToolStripButton Ensure;
    }
}