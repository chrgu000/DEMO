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
            this.btnFrmFrockClamp = new System.Windows.Forms.Button();
            this.btnrequisition = new System.Windows.Forms.Button();
            this.btnUserRight = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFrmFrockClamp
            // 
            this.btnFrmFrockClamp.Location = new System.Drawing.Point(33, 82);
            this.btnFrmFrockClamp.Margin = new System.Windows.Forms.Padding(2);
            this.btnFrmFrockClamp.Name = "btnFrmFrockClamp";
            this.btnFrmFrockClamp.Size = new System.Drawing.Size(119, 36);
            this.btnFrmFrockClamp.TabIndex = 1;
            this.btnFrmFrockClamp.Text = "工装登记";
            this.btnFrmFrockClamp.UseVisualStyleBackColor = true;
            this.btnFrmFrockClamp.Click += new System.EventHandler(this.btnFrmPurchasePlan_Click);
            // 
            // btnrequisition
            // 
            this.btnrequisition.Location = new System.Drawing.Point(33, 134);
            this.btnrequisition.Margin = new System.Windows.Forms.Padding(2);
            this.btnrequisition.Name = "btnrequisition";
            this.btnrequisition.Size = new System.Drawing.Size(119, 36);
            this.btnrequisition.TabIndex = 2;
            this.btnrequisition.Text = "工装领用";
            this.btnrequisition.UseVisualStyleBackColor = true;
            this.btnrequisition.Click += new System.EventHandler(this.btnrequisition_Click);
            // 
            // btnUserRight
            // 
            this.btnUserRight.Location = new System.Drawing.Point(33, 33);
            this.btnUserRight.Margin = new System.Windows.Forms.Padding(2);
            this.btnUserRight.Name = "btnUserRight";
            this.btnUserRight.Size = new System.Drawing.Size(119, 36);
            this.btnUserRight.TabIndex = 3;
            this.btnUserRight.Text = "用户权限";
            this.btnUserRight.UseVisualStyleBackColor = true;
            this.btnUserRight.Click += new System.EventHandler(this.btnUserRight_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 186);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "工装归还";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(33, 236);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "工装报废";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(198, 33);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 36);
            this.button3.TabIndex = 6;
            this.button3.Text = "工装维修";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(198, 134);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 36);
            this.button4.TabIndex = 7;
            this.button4.Text = "报表";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(198, 82);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(119, 36);
            this.button5.TabIndex = 8;
            this.button5.Text = "维修归还";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 286);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUserRight);
            this.Controls.Add(this.btnrequisition);
            this.Controls.Add(this.btnFrmFrockClamp);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFrmFrockClamp;
        private System.Windows.Forms.Button btnrequisition;
        private System.Windows.Forms.Button btnUserRight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;


    }
}