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
            this.btn同步刷卡数据 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn同步刷卡数据
            // 
            this.btn同步刷卡数据.Location = new System.Drawing.Point(12, 34);
            this.btn同步刷卡数据.Name = "btn同步刷卡数据";
            this.btn同步刷卡数据.Size = new System.Drawing.Size(100, 23);
            this.btn同步刷卡数据.TabIndex = 23;
            this.btn同步刷卡数据.Text = "同步刷卡数据";
            this.btn同步刷卡数据.UseVisualStyleBackColor = true;
            this.btn同步刷卡数据.Click += new System.EventHandler(this.btn同步刷卡数据_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "同步刷卡数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn同步刷卡数据);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn同步刷卡数据;
        private System.Windows.Forms.Button button1;

    }
}