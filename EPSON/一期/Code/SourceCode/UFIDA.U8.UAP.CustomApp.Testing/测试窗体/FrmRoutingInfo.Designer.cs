namespace WindowsFormsApplication1
{
    partial class FrmRoutingInfo
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
            this.routingInfo1 = new UFIDA.U8.UAP.CustomApp.ControlForm.RoutingInfo();
            this.SuspendLayout();
            // 
            // routingInfo1
            // 
            this.routingInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.routingInfo1.Conn = null;
            this.routingInfo1.dSerToday = new System.DateTime(((long)(0)));
            this.routingInfo1.Location = new System.Drawing.Point(4, 2);
            this.routingInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.routingInfo1.Name = "routingInfo1";
            this.routingInfo1.sAccID = null;
            this.routingInfo1.Size = new System.Drawing.Size(957, 593);
            this.routingInfo1.sLogDate = null;
            this.routingInfo1.sUserID = null;
            this.routingInfo1.sUserName = null;
            this.routingInfo1.TabIndex = 0;
            // 
            // FrmRoutingInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 596);
            this.Controls.Add(this.routingInfo1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmRoutingInfo";
            this.Text = "routingInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.RoutingInfo routingInfo1;




    }
}