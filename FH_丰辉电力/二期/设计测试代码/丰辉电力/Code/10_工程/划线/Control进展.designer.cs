namespace 工程
{
    partial class Control进展
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chkCheck = new DevExpress.XtraEditors.CheckEdit();
            this.memoEditTitle = new DevExpress.XtraEditors.MemoEdit();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.lblPer = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditTitle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkCheck
            // 
            this.chkCheck.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.False;
            this.chkCheck.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.chkCheck.Location = new System.Drawing.Point(129, 3);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Properties.Caption = "";
            this.chkCheck.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.chkCheck.Size = new System.Drawing.Size(20, 19);
            this.chkCheck.TabIndex = 0;
            this.chkCheck.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chkCheck_MouseClick);
            // 
            // memoEditTitle
            // 
            this.memoEditTitle.EditValue = "";
            this.memoEditTitle.Enabled = false;
            this.memoEditTitle.Location = new System.Drawing.Point(0, 0);
            this.memoEditTitle.Name = "memoEditTitle";
            this.memoEditTitle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.memoEditTitle.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEditTitle.Size = new System.Drawing.Size(127, 27);
            this.memoEditTitle.TabIndex = 7;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(6, 27);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 14);
            this.lblTime.TabIndex = 9;
            // 
            // lblPer
            // 
            this.lblPer.Location = new System.Drawing.Point(96, 27);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(0, 14);
            this.lblPer.TabIndex = 8;
            // 
            // Control进展
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblPer);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.memoEditTitle);
            this.Controls.Add(this.chkCheck);
            this.Name = "Control进展";
            this.Size = new System.Drawing.Size(150, 50);
            ((System.ComponentModel.ISupportInitialize)(this.chkCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditTitle.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkCheck;
        private DevExpress.XtraEditors.MemoEdit memoEditTitle;
        private DevExpress.XtraEditors.LabelControl lblPer;
        private DevExpress.XtraEditors.LabelControl lblTime;

    }
}
