namespace WindowsFormsApplication1
{
    partial class Frm发货编辑
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
            this.barSalesShipmentEdit1 = new UFIDA.U8.UAP.CustomApp.ControlForm.BarSalesShipmentEdit();
            this.SuspendLayout();
            // 
            // barSalesShipmentEdit1
            // 
            this.barSalesShipmentEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.barSalesShipmentEdit1.Conn = null;
            this.barSalesShipmentEdit1.dSerToday = new System.DateTime(((long)(0)));
            this.barSalesShipmentEdit1.Location = new System.Drawing.Point(-1, 3);
            this.barSalesShipmentEdit1.Name = "barSalesShipmentEdit1";
            this.barSalesShipmentEdit1.sAccID = null;
            this.barSalesShipmentEdit1.Size = new System.Drawing.Size(1033, 432);
            this.barSalesShipmentEdit1.sLogDate = null;
            this.barSalesShipmentEdit1.sUserID = null;
            this.barSalesShipmentEdit1.sUserName = null;
            this.barSalesShipmentEdit1.TabIndex = 0;
            // 
            // Frm发货编辑
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 434);
            this.Controls.Add(this.barSalesShipmentEdit1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm发货编辑";
            this.Text = "发货编辑";
            this.ResumeLayout(false);

        }

        #endregion

        private UFIDA.U8.UAP.CustomApp.ControlForm.BarSalesShipmentEdit barSalesShipmentEdit1;








    }
}