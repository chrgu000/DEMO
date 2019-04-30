namespace WindowsFormsApplication1
{
    partial class FormTest
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
            this.btn材料退回单 = new System.Windows.Forms.Button();
            this.btnXML = new System.Windows.Forms.Button();
            this.btn采购入库单 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn材料退回单
            // 
            this.btn材料退回单.Location = new System.Drawing.Point(29, 139);
            this.btn材料退回单.Margin = new System.Windows.Forms.Padding(4);
            this.btn材料退回单.Name = "btn材料退回单";
            this.btn材料退回单.Size = new System.Drawing.Size(133, 29);
            this.btn材料退回单.TabIndex = 23;
            this.btn材料退回单.Text = "材料退回单";
            this.btn材料退回单.UseVisualStyleBackColor = true;
            this.btn材料退回单.Click += new System.EventHandler(this.btn材料退回单_Click);
            // 
            // btnXML
            // 
            this.btnXML.Location = new System.Drawing.Point(29, 91);
            this.btnXML.Margin = new System.Windows.Forms.Padding(4);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(133, 29);
            this.btnXML.TabIndex = 24;
            this.btnXML.Text = "文件转换";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // btn采购入库单
            // 
            this.btn采购入库单.Location = new System.Drawing.Point(29, 191);
            this.btn采购入库单.Margin = new System.Windows.Forms.Padding(4);
            this.btn采购入库单.Name = "btn采购入库单";
            this.btn采购入库单.Size = new System.Drawing.Size(133, 29);
            this.btn采购入库单.TabIndex = 25;
            this.btn采购入库单.Text = "采购入库单";
            this.btn采购入库单.UseVisualStyleBackColor = true;
            this.btn采购入库单.Click += new System.EventHandler(this.btn采购入库单_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 328);
            this.Controls.Add(this.btn采购入库单);
            this.Controls.Add(this.btnXML);
            this.Controls.Add(this.btn材料退回单);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn材料退回单;
        private System.Windows.Forms.Button btnXML;
        private System.Windows.Forms.Button btn采购入库单;

    }
}