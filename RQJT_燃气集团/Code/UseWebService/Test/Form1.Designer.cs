namespace Test
{
    partial class Form1
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
            this.btnPU_AppVouch = new System.Windows.Forms.Button();
            this.btnMaterialAppVouc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPU_AppVouch
            // 
            this.btnPU_AppVouch.Location = new System.Drawing.Point(77, 47);
            this.btnPU_AppVouch.Name = "btnPU_AppVouch";
            this.btnPU_AppVouch.Size = new System.Drawing.Size(114, 59);
            this.btnPU_AppVouch.TabIndex = 0;
            this.btnPU_AppVouch.Text = "请购单导入";
            this.btnPU_AppVouch.UseVisualStyleBackColor = true;
            this.btnPU_AppVouch.Click += new System.EventHandler(this.btnPU_AppVouch_Click);
            // 
            // btnMaterialAppVouc
            // 
            this.btnMaterialAppVouc.Location = new System.Drawing.Point(77, 171);
            this.btnMaterialAppVouc.Name = "btnMaterialAppVouc";
            this.btnMaterialAppVouc.Size = new System.Drawing.Size(114, 59);
            this.btnMaterialAppVouc.TabIndex = 1;
            this.btnMaterialAppVouc.Text = "领用申请单导入";
            this.btnMaterialAppVouc.UseVisualStyleBackColor = true;
            this.btnMaterialAppVouc.Click += new System.EventHandler(this.btnMaterialAppVouc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 441);
            this.Controls.Add(this.btnMaterialAppVouc);
            this.Controls.Add(this.btnPU_AppVouch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPU_AppVouch;
        private System.Windows.Forms.Button btnMaterialAppVouc;
    }
}