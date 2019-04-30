namespace WindowsFormsApplication1
{
    partial class FrmActionFCost
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
            this.actionFCost1 = new UFIDA.U8.UAP.CustomApp.ControlForm.ActionFCost();
            this.SuspendLayout();
            // 
            // actionFCost1
            // 
            this.actionFCost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.actionFCost1.Conn = null;
            this.actionFCost1.dSerToday = new System.DateTime(((long)(0)));
            this.actionFCost1.Location = new System.Drawing.Point(0, 2);
            this.actionFCost1.Margin = new System.Windows.Forms.Padding(4);
            this.actionFCost1.Name = "actionFCost1";
            this.actionFCost1.sAccID = null;
            this.actionFCost1.Size = new System.Drawing.Size(960, 596);
            this.actionFCost1.sLogDate = null;
            this.actionFCost1.sUserID = null;
            this.actionFCost1.sUserName = null;
            this.actionFCost1.TabIndex = 0;
            // 
            // FrmActionFCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.actionFCost1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmActionFCost";
            this.Text = "ActionFCost";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.ActionFCost actionFCost1;






    }
}