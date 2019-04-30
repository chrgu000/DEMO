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
            this.btn高开返利单 = new System.Windows.Forms.Button();
            this.btn高开返利单列表 = new System.Windows.Forms.Button();
            this.btn高开返利核销单 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn高开返利单
            // 
            this.btn高开返利单.Location = new System.Drawing.Point(36, 22);
            this.btn高开返利单.Name = "btn高开返利单";
            this.btn高开返利单.Size = new System.Drawing.Size(144, 23);
            this.btn高开返利单.TabIndex = 25;
            this.btn高开返利单.Text = "高开返利单";
            this.btn高开返利单.UseVisualStyleBackColor = true;
            this.btn高开返利单.Click += new System.EventHandler(this.btn高开返利单_Click);
            // 
            // btn高开返利单列表
            // 
            this.btn高开返利单列表.Location = new System.Drawing.Point(36, 51);
            this.btn高开返利单列表.Name = "btn高开返利单列表";
            this.btn高开返利单列表.Size = new System.Drawing.Size(144, 23);
            this.btn高开返利单列表.TabIndex = 26;
            this.btn高开返利单列表.Text = "高开返利单列表";
            this.btn高开返利单列表.UseVisualStyleBackColor = true;
            this.btn高开返利单列表.Click += new System.EventHandler(this.btn高开返利单列表_Click);
            // 
            // btn高开返利核销单
            // 
            this.btn高开返利核销单.Location = new System.Drawing.Point(36, 151);
            this.btn高开返利核销单.Name = "btn高开返利核销单";
            this.btn高开返利核销单.Size = new System.Drawing.Size(144, 23);
            this.btn高开返利核销单.TabIndex = 27;
            this.btn高开返利核销单.Text = "高开返利核销单";
            this.btn高开返利核销单.UseVisualStyleBackColor = true;
            this.btn高开返利核销单.Click += new System.EventHandler(this.btn高开返利核销单_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "高开返利核销单列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(352, 22);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(144, 23);
            this.btnExcel.TabIndex = 29;
            this.btnExcel.Text = "导入Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 262);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn高开返利核销单);
            this.Controls.Add(this.btn高开返利单列表);
            this.Controls.Add(this.btn高开返利单);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn高开返利单;
        private System.Windows.Forms.Button btn高开返利单列表;
        private System.Windows.Forms.Button btn高开返利核销单;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExcel;

    }
}