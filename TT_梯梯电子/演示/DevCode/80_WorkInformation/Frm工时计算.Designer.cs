namespace WorkInformation
{
    partial class Frm工时计算
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridControl班组 = new DevExpress.XtraGrid.GridControl();
            this.gridView班组 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol人员数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol人员总工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol人员平均工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol人员状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridControl设备 = new DevExpress.XtraGrid.GridControl();
            this.gridView设备 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol设备 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol设备总工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol设备单台平均工时 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol设备状态 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn核查 = new System.Windows.Forms.Button();
            this.btn取消 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt正常 = new System.Windows.Forms.TextBox();
            this.txt加班 = new System.Windows.Forms.TextBox();
            this.txt两班 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl班组)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView班组)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl设备)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView设备)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerControl1.Location = new System.Drawing.Point(1, 71);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(950, 470);
            this.splitContainerControl1.SplitterPosition = 452;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gridControl班组);
            this.groupBox1.Location = new System.Drawing.Point(11, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 464);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "班组";
            // 
            // gridControl班组
            // 
            this.gridControl班组.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl班组.Location = new System.Drawing.Point(3, 17);
            this.gridControl班组.MainView = this.gridView班组;
            this.gridControl班组.Name = "gridControl班组";
            this.gridControl班组.Size = new System.Drawing.Size(429, 444);
            this.gridControl班组.TabIndex = 0;
            this.gridControl班组.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView班组});
            // 
            // gridView班组
            // 
            this.gridView班组.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol部门,
            this.gridCol人员数量,
            this.gridCol人员总工时,
            this.gridCol人员平均工时,
            this.gridCol人员状态});
            this.gridView班组.GridControl = this.gridControl班组;
            this.gridView班组.Name = "gridView班组";
            this.gridView班组.OptionsBehavior.Editable = false;
            this.gridView班组.OptionsView.ColumnAutoWidth = false;
            this.gridView班组.OptionsView.ShowGroupPanel = false;
            this.gridView班组.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView班组_CustomDrawRowIndicator);
            this.gridView班组.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView班组_RowCellStyle);
            // 
            // gridCol部门
            // 
            this.gridCol部门.Caption = "班组";
            this.gridCol部门.FieldName = "部门";
            this.gridCol部门.Name = "gridCol部门";
            this.gridCol部门.OptionsColumn.ReadOnly = true;
            this.gridCol部门.Visible = true;
            this.gridCol部门.VisibleIndex = 0;
            this.gridCol部门.Width = 93;
            // 
            // gridCol人员数量
            // 
            this.gridCol人员数量.Caption = "人员数量";
            this.gridCol人员数量.FieldName = "人员数量";
            this.gridCol人员数量.Name = "gridCol人员数量";
            this.gridCol人员数量.OptionsColumn.ReadOnly = true;
            this.gridCol人员数量.Visible = true;
            this.gridCol人员数量.VisibleIndex = 1;
            this.gridCol人员数量.Width = 71;
            // 
            // gridCol人员总工时
            // 
            this.gridCol人员总工时.Caption = "计划总工时";
            this.gridCol人员总工时.FieldName = "人员总工时";
            this.gridCol人员总工时.Name = "gridCol人员总工时";
            this.gridCol人员总工时.OptionsColumn.ReadOnly = true;
            this.gridCol人员总工时.Visible = true;
            this.gridCol人员总工时.VisibleIndex = 2;
            this.gridCol人员总工时.Width = 84;
            // 
            // gridCol人员平均工时
            // 
            this.gridCol人员平均工时.Caption = "计划平均工时";
            this.gridCol人员平均工时.FieldName = "人员平均工时";
            this.gridCol人员平均工时.Name = "gridCol人员平均工时";
            this.gridCol人员平均工时.OptionsColumn.ReadOnly = true;
            this.gridCol人员平均工时.Visible = true;
            this.gridCol人员平均工时.VisibleIndex = 3;
            this.gridCol人员平均工时.Width = 92;
            // 
            // gridCol人员状态
            // 
            this.gridCol人员状态.Caption = "人员状态";
            this.gridCol人员状态.FieldName = "人员状态";
            this.gridCol人员状态.Name = "gridCol人员状态";
            this.gridCol人员状态.OptionsColumn.ReadOnly = true;
            this.gridCol人员状态.Visible = true;
            this.gridCol人员状态.VisibleIndex = 4;
            this.gridCol人员状态.Width = 72;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.gridControl设备);
            this.groupBox2.Location = new System.Drawing.Point(5, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 464);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设备";
            // 
            // gridControl设备
            // 
            this.gridControl设备.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl设备.Location = new System.Drawing.Point(3, 17);
            this.gridControl设备.MainView = this.gridView设备;
            this.gridControl设备.Name = "gridControl设备";
            this.gridControl设备.Size = new System.Drawing.Size(479, 444);
            this.gridControl设备.TabIndex = 0;
            this.gridControl设备.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView设备});
            // 
            // gridView设备
            // 
            this.gridView设备.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol设备,
            this.gridCol数量,
            this.gridCol设备总工时,
            this.gridCol设备单台平均工时,
            this.gridCol设备状态});
            this.gridView设备.GridControl = this.gridControl设备;
            this.gridView设备.Name = "gridView设备";
            this.gridView设备.OptionsBehavior.Editable = false;
            this.gridView设备.OptionsView.ColumnAutoWidth = false;
            this.gridView设备.OptionsView.ShowGroupPanel = false;
            this.gridView设备.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView设备_CustomDrawRowIndicator);
            this.gridView设备.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView设备_RowCellStyle);
            // 
            // gridCol设备
            // 
            this.gridCol设备.Caption = "设备";
            this.gridCol设备.FieldName = "设备";
            this.gridCol设备.Name = "gridCol设备";
            this.gridCol设备.OptionsColumn.ReadOnly = true;
            this.gridCol设备.Visible = true;
            this.gridCol设备.VisibleIndex = 0;
            this.gridCol设备.Width = 110;
            // 
            // gridCol数量
            // 
            this.gridCol数量.Caption = "数量";
            this.gridCol数量.FieldName = "数量";
            this.gridCol数量.Name = "gridCol数量";
            this.gridCol数量.OptionsColumn.ReadOnly = true;
            this.gridCol数量.Visible = true;
            this.gridCol数量.VisibleIndex = 1;
            this.gridCol数量.Width = 56;
            // 
            // gridCol设备总工时
            // 
            this.gridCol设备总工时.Caption = "设备总工时";
            this.gridCol设备总工时.FieldName = "设备总工时";
            this.gridCol设备总工时.Name = "gridCol设备总工时";
            this.gridCol设备总工时.OptionsColumn.ReadOnly = true;
            this.gridCol设备总工时.Visible = true;
            this.gridCol设备总工时.VisibleIndex = 2;
            this.gridCol设备总工时.Width = 85;
            // 
            // gridCol设备单台平均工时
            // 
            this.gridCol设备单台平均工时.Caption = "设备单台平均工时";
            this.gridCol设备单台平均工时.FieldName = "设备单台平均工时";
            this.gridCol设备单台平均工时.Name = "gridCol设备单台平均工时";
            this.gridCol设备单台平均工时.OptionsColumn.ReadOnly = true;
            this.gridCol设备单台平均工时.Visible = true;
            this.gridCol设备单台平均工时.VisibleIndex = 3;
            this.gridCol设备单台平均工时.Width = 123;
            // 
            // gridCol设备状态
            // 
            this.gridCol设备状态.Caption = "设备状态";
            this.gridCol设备状态.FieldName = "设备状态";
            this.gridCol设备状态.Name = "gridCol设备状态";
            this.gridCol设备状态.OptionsColumn.ReadOnly = true;
            this.gridCol设备状态.Visible = true;
            this.gridCol设备状态.VisibleIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "日期";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(96, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(128, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // btn核查
            // 
            this.btn核查.Location = new System.Drawing.Point(240, 26);
            this.btn核查.Name = "btn核查";
            this.btn核查.Size = new System.Drawing.Size(75, 23);
            this.btn核查.TabIndex = 3;
            this.btn核查.Text = "核 查";
            this.btn核查.UseVisualStyleBackColor = true;
            this.btn核查.Click += new System.EventHandler(this.btn核查_Click);
            // 
            // btn取消
            // 
            this.btn取消.Location = new System.Drawing.Point(345, 25);
            this.btn取消.Name = "btn取消";
            this.btn取消.Size = new System.Drawing.Size(75, 23);
            this.btn取消.TabIndex = 4;
            this.btn取消.Text = "取 消";
            this.btn取消.UseVisualStyleBackColor = true;
            this.btn取消.Click += new System.EventHandler(this.btn取消_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "日生产工时";
            // 
            // txt正常
            // 
            this.txt正常.Location = new System.Drawing.Point(570, 28);
            this.txt正常.Name = "txt正常";
            this.txt正常.Size = new System.Drawing.Size(40, 21);
            this.txt正常.TabIndex = 6;
            this.txt正常.Text = "8";
            // 
            // txt加班
            // 
            this.txt加班.Location = new System.Drawing.Point(616, 28);
            this.txt加班.Name = "txt加班";
            this.txt加班.Size = new System.Drawing.Size(40, 21);
            this.txt加班.TabIndex = 7;
            this.txt加班.Text = "11.5";
            // 
            // txt两班
            // 
            this.txt两班.Location = new System.Drawing.Point(662, 28);
            this.txt两班.Name = "txt两班";
            this.txt两班.Size = new System.Drawing.Size(40, 21);
            this.txt两班.TabIndex = 8;
            this.txt两班.Text = "16";
            // 
            // Frm工时计算
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 553);
            this.Controls.Add(this.txt两班);
            this.Controls.Add(this.txt加班);
            this.Controls.Add(this.txt正常);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn取消);
            this.Controls.Add(this.btn核查);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "Frm工时计算";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工时计算";
            this.Load += new System.EventHandler(this.Frm工时计算_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl班组)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView班组)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl设备)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView设备)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraGrid.GridControl gridControl班组;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView班组;
        private DevExpress.XtraGrid.GridControl gridControl设备;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView设备;
        private System.Windows.Forms.Button btn核查;
        private System.Windows.Forms.Button btn取消;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt正常;
        private System.Windows.Forms.TextBox txt加班;
        private System.Windows.Forms.TextBox txt两班;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol部门;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol人员数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol人员总工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol人员平均工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol人员状态;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol设备;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol数量;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol设备总工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol设备单台平均工时;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol设备状态;
    }
}