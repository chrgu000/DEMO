namespace Base
{
    partial class Frm杜乐耗材分类
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
            this.treView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt分类编码 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt分类名称 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // childLF
            // 
            this.childLF.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.childLF.LookAndFeel.UseWindowsXPTheme = false;
            // 
            // treView
            // 
            this.treView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treView.Location = new System.Drawing.Point(8, 8);
            this.treView.Name = "treView";
            this.treView.Size = new System.Drawing.Size(235, 387);
            this.treView.TabIndex = 5;
            this.treView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treView_NodeMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "分类编码";
            // 
            // txt分类编码
            // 
            this.txt分类编码.Location = new System.Drawing.Point(350, 41);
            this.txt分类编码.Name = "txt分类编码";
            this.txt分类编码.Size = new System.Drawing.Size(268, 21);
            this.txt分类编码.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(624, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 14);
            this.label5.TabIndex = 101;
            this.label5.Text = "** ** ** **";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 95;
            this.label2.Text = "分类名称";
            // 
            // txt分类名称
            // 
            this.txt分类名称.Location = new System.Drawing.Point(350, 68);
            this.txt分类名称.Name = "txt分类名称";
            this.txt分类名称.Size = new System.Drawing.Size(349, 21);
            this.txt分类名称.TabIndex = 96;
            // 
            // Frm杜乐耗材分类
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 399);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt分类名称);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt分类编码);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treView);
            this.Name = "Frm杜乐耗材分类";
            this.Text = "杜乐耗材分类";
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.SetChildIndex(this.treView, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txt分类编码, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txt分类名称, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt分类编码;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt分类名称;

    }
}