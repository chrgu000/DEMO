﻿namespace WindowsFormsApplication1
{
    partial class frm处理日数据
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
            this.处理日数据1 = new UFIDA.U8.UAP.CustomApp.ControlForm.处理日数据();
            this.SuspendLayout();
            // 
            // 处理日数据1
            // 
            this.处理日数据1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.处理日数据1.Conn = null;
            this.处理日数据1.dSerToday = new System.DateTime(((long)(0)));
            this.处理日数据1.Location = new System.Drawing.Point(0, 1);
            this.处理日数据1.Name = "处理日数据1";
            this.处理日数据1.sAccID = null;
            this.处理日数据1.Size = new System.Drawing.Size(736, 362);
            this.处理日数据1.sLogDate = null;
            this.处理日数据1.sUserID = null;
            this.处理日数据1.sUserName = null;
            this.处理日数据1.TabIndex = 0;
            // 
            // frm处理日数据
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 367);
            this.Controls.Add(this.处理日数据1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm处理日数据";
            this.Text = "处理日数据";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.处理日数据 处理日数据1;










    }
}