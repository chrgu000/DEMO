namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    partial class PrintBarCode_Box
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintBarCode_Box));
            this.btnPrintSet = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.textEditBoxQTY = new DevExpress.XtraEditors.TextEdit();
            this.textEditMomCode = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.textEditQTY = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.textEditHW = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.textEditBatch = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.tsbClearCon = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBoxQTY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMomCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQTY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBatch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintSet
            // 
            this.btnPrintSet.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintSet.Image")));
            this.btnPrintSet.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrintSet.Location = new System.Drawing.Point(373, 76);
            this.btnPrintSet.Name = "btnPrintSet";
            this.btnPrintSet.Size = new System.Drawing.Size(61, 41);
            this.btnPrintSet.TabIndex = 8;
            this.btnPrintSet.Text = "打印设置";
            this.btnPrintSet.Click += new System.EventHandler(this.btnPrintSet_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(306, 76);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(46, 41);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(238, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 25);
            this.labelControl1.TabIndex = 139;
            this.labelControl1.Text = "箱码打印";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 155;
            this.label1.Text = "箱数";
            // 
            // textEditBoxQTY
            // 
            this.textEditBoxQTY.Location = new System.Drawing.Point(104, 74);
            this.textEditBoxQTY.Name = "textEditBoxQTY";
            this.textEditBoxQTY.Properties.Mask.EditMask = "n0";
            this.textEditBoxQTY.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditBoxQTY.Size = new System.Drawing.Size(100, 20);
            this.textEditBoxQTY.TabIndex = 1;
            // 
            // textEditMomCode
            // 
            this.textEditMomCode.Location = new System.Drawing.Point(104, 100);
            this.textEditMomCode.Name = "textEditMomCode";
            this.textEditMomCode.Properties.Mask.EditMask = "n0";
            this.textEditMomCode.Size = new System.Drawing.Size(100, 20);
            this.textEditMomCode.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 157;
            this.label2.Text = "生产订单号";
            // 
            // textEditQTY
            // 
            this.textEditQTY.Location = new System.Drawing.Point(104, 126);
            this.textEditQTY.Name = "textEditQTY";
            this.textEditQTY.Properties.Mask.EditMask = "n0";
            this.textEditQTY.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditQTY.Size = new System.Drawing.Size(100, 20);
            this.textEditQTY.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 159;
            this.label3.Text = "数量";
            // 
            // textEditHW
            // 
            this.textEditHW.Location = new System.Drawing.Point(104, 152);
            this.textEditHW.Name = "textEditHW";
            this.textEditHW.Properties.Mask.EditMask = "n0";
            this.textEditHW.Size = new System.Drawing.Size(100, 20);
            this.textEditHW.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 161;
            this.label4.Text = "货位";
            // 
            // textEditBatch
            // 
            this.textEditBatch.Location = new System.Drawing.Point(104, 178);
            this.textEditBatch.Name = "textEditBatch";
            this.textEditBatch.Properties.Mask.EditMask = "n0";
            this.textEditBatch.Size = new System.Drawing.Size(100, 20);
            this.textEditBatch.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 163;
            this.label5.Text = "批号";
            // 
            // tsbClearCon
            // 
            this.tsbClearCon.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearCon.Image")));
            this.tsbClearCon.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.tsbClearCon.Location = new System.Drawing.Point(238, 76);
            this.tsbClearCon.Name = "tsbClearCon";
            this.tsbClearCon.Size = new System.Drawing.Size(46, 41);
            this.tsbClearCon.TabIndex = 6;
            this.tsbClearCon.Text = "清空";
            this.tsbClearCon.Click += new System.EventHandler(this.tsbClearCon_Click);
            // 
            // PrintBarCode_Box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsbClearCon);
            this.Controls.Add(this.textEditBatch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textEditHW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textEditQTY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textEditMomCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textEditBoxQTY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrintSet);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.labelControl1);
            this.Name = "PrintBarCode_Box";
            this.Size = new System.Drawing.Size(559, 371);
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEditBoxQTY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMomCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQTY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBatch.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPrintSet;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textEditBoxQTY;
        private DevExpress.XtraEditors.TextEdit textEditMomCode;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit textEditQTY;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit textEditHW;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit textEditBatch;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SimpleButton tsbClearCon;
    }
}
