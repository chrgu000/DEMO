﻿namespace WindowsFormsApplication1
{
    partial class Frm采购设置
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
            this.purchaseSet1 = new UFIDA.U8.UAP.CustomApp.ControlForm.PurchaseSet();
            this.SuspendLayout();
            // 
            // purchaseSet1
            // 
            this.purchaseSet1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseSet1.Conn = null;
            this.purchaseSet1.dSerToday = new System.DateTime(((long)(0)));
            this.purchaseSet1.Location = new System.Drawing.Point(1, 9);
            this.purchaseSet1.Name = "purchaseSet1";
            this.purchaseSet1.sAccID = null;
            this.purchaseSet1.Size = new System.Drawing.Size(719, 465);
            this.purchaseSet1.sLogDate = null;
            this.purchaseSet1.sUserID = null;
            this.purchaseSet1.sUserName = null;
            this.purchaseSet1.TabIndex = 0;
            // 
            // Frm采购设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 477);
            this.Controls.Add(this.purchaseSet1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm采购设置";
            this.Text = "采购设置";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.PurchaseSet purchaseSet1;








    }
}