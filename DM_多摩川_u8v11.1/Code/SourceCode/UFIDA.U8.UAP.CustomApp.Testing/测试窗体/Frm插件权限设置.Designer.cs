﻿namespace WindowsFormsApplication1
{
    partial class Frm插件权限设置
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userRight1 = new UFIDA.U8.UAP.CustomApp.ControlForm.UserRight();
            this.SuspendLayout();
            // 
            // userRight1
            // 
            this.userRight1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userRight1.Conn = null;
            this.userRight1.dSerToday = new System.DateTime(((long)(0)));
            this.userRight1.Location = new System.Drawing.Point(12, 12);
            this.userRight1.Name = "userRight1";
            this.userRight1.sAccID = null;
            this.userRight1.Size = new System.Drawing.Size(924, 518);
            this.userRight1.sLogDate = null;
            this.userRight1.sUserID = null;
            this.userRight1.sUserName = null;
            this.userRight1.TabIndex = 0;
            // 
            // Frm插件权限设置
            // 
            this.ClientSize = new System.Drawing.Size(938, 542);
            this.Controls.Add(this.userRight1);
            this.Name = "Frm插件权限设置";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.UserRight userRight1;




    }
}