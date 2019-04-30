using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Base
{
    /// <summary>
    /// Summary description for Report.
    /// </summary>
    public class RepQMREJECT : DevExpress.XtraReports.UI.XtraReport
    {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        public System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private System.Data.DataTable dataTable2;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private System.Data.DataColumn dataColumn16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell27;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataColumn dataColumn23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public RepQMREJECT()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 64;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBorders = false;
            // 
            // xrTable1
            // 
            this.xrTable1.Dpi = 254F;
            this.xrTable1.Location = new System.Drawing.Point(21, 0);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(2138, 64);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell9,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell2,
            this.xrTableCell20,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell22,
            this.xrTableCell28});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(2138, 64);
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Angle = 1F;
            this.xrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column9", "")});
            this.xrTableCell1.Dpi = 254F;
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.ParentStyleUsing.UseFont = false;
            this.xrTableCell1.Size = new System.Drawing.Size(96, 64);
            this.xrTableCell1.Text = "xrTableCell1";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22,
            this.dataColumn23});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "序号";
            this.dataColumn1.ColumnName = "Column1";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "订单号";
            this.dataColumn2.ColumnName = "Column2";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "存货编码";
            this.dataColumn3.ColumnName = "Column3";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "存货名称";
            this.dataColumn4.ColumnName = "Column4";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "规格型号";
            this.dataColumn5.ColumnName = "Column5";
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "计量单位";
            this.dataColumn6.ColumnName = "Column6";
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "辅计量";
            this.dataColumn7.ColumnName = "Column7";
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "数量";
            this.dataColumn8.ColumnName = "Column8";
            // 
            // dataColumn9
            // 
            this.dataColumn9.Caption = "件数";
            this.dataColumn9.ColumnName = "Column9";
            // 
            // dataColumn10
            // 
            this.dataColumn10.Caption = "条码";
            this.dataColumn10.ColumnName = "Column10";
            // 
            // dataColumn16
            // 
            this.dataColumn16.Caption = "订单交期";
            this.dataColumn16.ColumnName = "Column11";
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "Column12";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "Column13";
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "Column14";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "Column15";
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "Column16";
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "Column17";
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "Column18";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15});
            this.dataTable2.TableName = "Table2";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "Column1";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "Column2";
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "Column3";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "Column4";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "Column5";
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Angle = 1F;
            this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataTable1, "Column1", "")});
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell9.Location = new System.Drawing.Point(96, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.ParentStyleUsing.UseFont = false;
            this.xrTableCell9.Size = new System.Drawing.Size(225, 64);
            this.xrTableCell9.Text = "xrTableCell9";
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Angle = 1F;
            this.xrTableCell7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column2", "")});
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell7.Location = new System.Drawing.Point(321, 0);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.ParentStyleUsing.UseFont = false;
            this.xrTableCell7.Size = new System.Drawing.Size(174, 64);
            this.xrTableCell7.Text = "xrTableCell7";
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Angle = 1F;
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column3", "")});
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell8.Location = new System.Drawing.Point(495, 0);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.ParentStyleUsing.UseFont = false;
            this.xrTableCell8.Size = new System.Drawing.Size(213, 64);
            this.xrTableCell8.Text = "xrTableCell8";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Angle = 1F;
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column4", "")});
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell2.Location = new System.Drawing.Point(708, 0);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.ParentStyleUsing.UseFont = false;
            this.xrTableCell2.Size = new System.Drawing.Size(220, 64);
            this.xrTableCell2.Text = "xrTableCell2";
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataTable1, "Column11", "")});
            this.xrTableCell20.Dpi = 254F;
            this.xrTableCell20.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell20.Location = new System.Drawing.Point(928, 0);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.ParentStyleUsing.UseFont = false;
            this.xrTableCell20.Size = new System.Drawing.Size(286, 64);
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Angle = 1F;
            this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column5", "")});
            this.xrTableCell3.Dpi = 254F;
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell3.Location = new System.Drawing.Point(1214, 0);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.ParentStyleUsing.UseFont = false;
            this.xrTableCell3.Size = new System.Drawing.Size(380, 64);
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Angle = 1F;
            this.xrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column6", "")});
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell4.Location = new System.Drawing.Point(1594, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.ParentStyleUsing.UseFont = false;
            this.xrTableCell4.Size = new System.Drawing.Size(174, 64);
            this.xrTableCell4.Text = "xrTableCell4";
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Angle = 1F;
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column12", "")});
            this.xrTableCell22.Dpi = 254F;
            this.xrTableCell22.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell22.Location = new System.Drawing.Point(1768, 0);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.ParentStyleUsing.UseFont = false;
            this.xrTableCell22.Size = new System.Drawing.Size(143, 64);
            this.xrTableCell22.Text = "xrTableCell22";
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Angle = 1F;
            this.xrTableCell28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column13", "")});
            this.xrTableCell28.Dpi = 254F;
            this.xrTableCell28.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell28.Location = new System.Drawing.Point(1911, 0);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.ParentStyleUsing.UseFont = false;
            this.xrTableCell28.Size = new System.Drawing.Size(227, 64);
            this.xrTableCell28.Text = "xrTableCell28";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel2,
            this.xrPageInfo1});
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 210;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.Location = new System.Drawing.Point(296, 85);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(1862, 63);
            this.xrLabel4.Text = "第一联：存根（白） / 第二联：财务（红） / 第三联：采购（绿） / 第四联：厂商（蓝） / 第五联：门卫（黄）";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataTable2, "Column2", "")});
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.Location = new System.Drawing.Point(296, 21);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(1862, 64);
            this.xrLabel2.Text = "制单人";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Location = new System.Drawing.Point(1968, 169);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Size = new System.Drawing.Size(127, 41);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(889, 148);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(655, 84);
            this.xrLabel1.Text = "拒 收 单 列 表";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.Height = 64;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 254F;
            this.xrTable2.Location = new System.Drawing.Point(21, 0);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.Size = new System.Drawing.Size(2138, 64);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell18,
            this.xrTableCell15,
            this.xrTableCell11,
            this.xrTableCell17,
            this.xrTableCell19,
            this.xrTableCell14,
            this.xrTableCell16,
            this.xrTableCell21,
            this.xrTableCell27});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(2138, 64);
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.Dpi = 254F;
            this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell10.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.ParentStyleUsing.UseBorders = false;
            this.xrTableCell10.ParentStyleUsing.UseFont = false;
            this.xrTableCell10.Size = new System.Drawing.Size(95, 64);
            this.xrTableCell10.Text = "行号";
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell18.Dpi = 254F;
            this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell18.Location = new System.Drawing.Point(95, 0);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.ParentStyleUsing.UseBorders = false;
            this.xrTableCell18.ParentStyleUsing.UseFont = false;
            this.xrTableCell18.Size = new System.Drawing.Size(225, 64);
            this.xrTableCell18.Text = "单据号";
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.Dpi = 254F;
            this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell15.Location = new System.Drawing.Point(320, 0);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.ParentStyleUsing.UseBorders = false;
            this.xrTableCell15.ParentStyleUsing.UseFont = false;
            this.xrTableCell15.Size = new System.Drawing.Size(173, 64);
            this.xrTableCell15.Text = "日期";
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.Dpi = 254F;
            this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell11.Location = new System.Drawing.Point(493, 0);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.ParentStyleUsing.UseBorders = false;
            this.xrTableCell11.ParentStyleUsing.UseFont = false;
            this.xrTableCell11.Size = new System.Drawing.Size(211, 64);
            this.xrTableCell11.Text = "到货单号";
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell17.Dpi = 254F;
            this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell17.Location = new System.Drawing.Point(704, 0);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.ParentStyleUsing.UseBorders = false;
            this.xrTableCell17.ParentStyleUsing.UseFont = false;
            this.xrTableCell17.Size = new System.Drawing.Size(220, 64);
            this.xrTableCell17.Text = "存货编码";
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell19.Dpi = 254F;
            this.xrTableCell19.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell19.Location = new System.Drawing.Point(924, 0);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.ParentStyleUsing.UseBorders = false;
            this.xrTableCell19.ParentStyleUsing.UseFont = false;
            this.xrTableCell19.Size = new System.Drawing.Size(284, 64);
            this.xrTableCell19.Text = "存货名称";
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.Dpi = 254F;
            this.xrTableCell14.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell14.Location = new System.Drawing.Point(1208, 0);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.ParentStyleUsing.UseBorders = false;
            this.xrTableCell14.ParentStyleUsing.UseFont = false;
            this.xrTableCell14.Size = new System.Drawing.Size(383, 64);
            this.xrTableCell14.Text = "规格型号";
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.Dpi = 254F;
            this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell16.Location = new System.Drawing.Point(1591, 0);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.ParentStyleUsing.UseBorders = false;
            this.xrTableCell16.ParentStyleUsing.UseFont = false;
            this.xrTableCell16.Size = new System.Drawing.Size(173, 64);
            this.xrTableCell16.Text = "不良品数量";
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell21.Dpi = 254F;
            this.xrTableCell21.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell21.Location = new System.Drawing.Point(1764, 0);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.ParentStyleUsing.UseBorders = false;
            this.xrTableCell21.ParentStyleUsing.UseFont = false;
            this.xrTableCell21.Size = new System.Drawing.Size(143, 64);
            this.xrTableCell21.Text = "处理方式";
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell27.Dpi = 254F;
            this.xrTableCell27.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell27.Location = new System.Drawing.Point(1907, 0);
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.ParentStyleUsing.UseBorders = false;
            this.xrTableCell27.ParentStyleUsing.UseFont = false;
            this.xrTableCell27.Size = new System.Drawing.Size(231, 64);
            this.xrTableCell27.Text = "检验员";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel3,
            this.xrLabel1});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.Height = 366;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.Location = new System.Drawing.Point(550, 21);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(1226, 127);
            this.xrLabel5.Text = "杜乐（苏州）金属制品有限公司";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataTable2, "Column1", "")});
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(43, 274);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(1377, 64);
            this.xrLabel3.Text = "供应商";
            // 
            // RepQMREJECT
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageFooter,
            this.GroupHeader1,
            this.PageHeader});
            this.DataSource = this.dataSet1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 51, 41);
            this.PageHeight = 1400;
            this.PageWidth = 2200;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PaperName = "QmPaper";
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            xrControlStyle1.BackColor = System.Drawing.Color.Transparent;
            this.StyleSheet.Add("Style1", xrControlStyle1);
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
    }
}

