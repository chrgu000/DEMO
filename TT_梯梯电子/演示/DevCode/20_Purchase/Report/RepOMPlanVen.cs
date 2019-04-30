using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Purchase
{
    /// <summary>
    /// Summary description for Report.
    /// </summary>
    public class RepOMPlanVen : DevExpress.XtraReports.UI.XtraReport
    {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        public System.Data.DataSet dataSet1;
        private System.Data.DataTable dtDetail;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
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
        private System.Data.DataTable dtHead;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Data.DataColumn dataColumn18;
        private System.Data.DataColumn dataColumn19;
        private System.Data.DataColumn dataColumn20;
        private System.Data.DataColumn dataColumn21;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public RepOMPlanVen()
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
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.dtDetail = new System.Data.DataTable();
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
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.dataSet1 = new System.Data.DataSet();
            this.dtHead = new System.Data.DataTable();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHead)).BeginInit();
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
            this.Detail.Height = 25;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBorders = false;
            // 
            // xrTable1
            // 
            this.xrTable1.Location = new System.Drawing.Point(8, 0);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(1109, 25);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19,
            this.xrTableCell16,
            this.xrTableCell1,
            this.xrTableCell9,
            this.xrTableCell7,
            this.xrTableCell8,
            this.xrTableCell2,
            this.xrTableCell22,
            this.xrTableCell20,
            this.xrTableCell3,
            this.xrTableCell4});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(1109, 25);
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtDetail, "Column9", "")});
            this.xrTableCell19.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Size = new System.Drawing.Size(75, 25);
            this.xrTableCell19.Text = "xrTableCell19";
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtDetail, "Column10", "")});
            this.xrTableCell16.Location = new System.Drawing.Point(75, 0);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Size = new System.Drawing.Size(100, 25);
            this.xrTableCell16.Text = "xrTableCell16";
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Angle = 1F;
            this.xrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtDetail, "Column1", "")});
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell1.Location = new System.Drawing.Point(175, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.ParentStyleUsing.UseFont = false;
            this.xrTableCell1.Size = new System.Drawing.Size(92, 25);
            this.xrTableCell1.Text = "xrTableCell1";
            // 
            // dtDetail
            // 
            this.dtDetail.Columns.AddRange(new System.Data.DataColumn[] {
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
            this.dataColumn21});
            this.dtDetail.TableName = "dtDetail";
            // 
            // dataColumn1
            // 
            this.dataColumn1.Caption = "订单号";
            this.dataColumn1.ColumnName = "Column1";
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "入库单号";
            this.dataColumn2.ColumnName = "Column2";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "入库日期";
            this.dataColumn3.ColumnName = "Column3";
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "存货编码";
            this.dataColumn4.ColumnName = "Column4";
            // 
            // dataColumn5
            // 
            this.dataColumn5.Caption = "存货名称";
            this.dataColumn5.ColumnName = "Column5";
            // 
            // dataColumn6
            // 
            this.dataColumn6.Caption = "规格型号";
            this.dataColumn6.ColumnName = "Column6";
            // 
            // dataColumn7
            // 
            this.dataColumn7.Caption = "数量";
            this.dataColumn7.ColumnName = "Column7";
            // 
            // dataColumn8
            // 
            this.dataColumn8.Caption = "含税单价";
            this.dataColumn8.ColumnName = "Column8";
            // 
            // dataColumn9
            // 
            this.dataColumn9.Caption = "价税合计";
            this.dataColumn9.ColumnName = "Column9";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "Column10";
            // 
            // dataColumn16
            // 
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
            // xrTableCell9
            // 
            this.xrTableCell9.Angle = 1F;
            this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtDetail, "Column2", "")});
            this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell9.Location = new System.Drawing.Point(267, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.ParentStyleUsing.UseFont = false;
            this.xrTableCell9.Size = new System.Drawing.Size(200, 25);
            this.xrTableCell9.Text = "xrTableCell9";
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Angle = 1F;
            this.xrTableCell7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtDetail, "Column3", "")});
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell7.Location = new System.Drawing.Point(467, 0);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.ParentStyleUsing.UseFont = false;
            this.xrTableCell7.Size = new System.Drawing.Size(140, 25);
            this.xrTableCell7.Text = "xrTableCell7";
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Angle = 1F;
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtDetail, "Column4", "")});
            this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell8.Location = new System.Drawing.Point(607, 0);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.ParentStyleUsing.UseFont = false;
            this.xrTableCell8.Size = new System.Drawing.Size(75, 25);
            this.xrTableCell8.Text = "xrTableCell8";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Angle = 1F;
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtDetail, "Column5", "")});
            this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell2.Location = new System.Drawing.Point(682, 0);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.ParentStyleUsing.UseFont = false;
            this.xrTableCell2.Size = new System.Drawing.Size(60, 25);
            this.xrTableCell2.Text = "xrTableCell2";
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtDetail, "Column11", "")});
            this.xrTableCell22.Location = new System.Drawing.Point(742, 0);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Size = new System.Drawing.Size(58, 25);
            this.xrTableCell22.Text = "xrTableCell22";
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtDetail, "Column6", "")});
            this.xrTableCell20.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell20.Location = new System.Drawing.Point(800, 0);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.ParentStyleUsing.UseFont = false;
            this.xrTableCell20.Size = new System.Drawing.Size(100, 25);
            this.xrTableCell20.Text = "xrTableCell20";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Angle = 1F;
            this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column7", "")});
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell3.Location = new System.Drawing.Point(900, 0);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.ParentStyleUsing.UseFont = false;
            this.xrTableCell3.Size = new System.Drawing.Size(101, 25);
            this.xrTableCell3.Text = "xrTableCell3";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dtDetail,
            this.dtHead});
            // 
            // dtHead
            // 
            this.dtHead.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn14,
            this.dataColumn15});
            this.dtHead.TableName = "dtHead";
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
            // xrTableCell4
            // 
            this.xrTableCell4.Angle = 1F;
            this.xrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dataSet1, "Column8", "")});
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell4.Location = new System.Drawing.Point(1001, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.ParentStyleUsing.UseFont = false;
            this.xrTableCell4.Size = new System.Drawing.Size(108, 25);
            this.xrTableCell4.Text = "xrTableCell4";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.GroupHeader1.Height = 25;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable2
            // 
            this.xrTable2.Location = new System.Drawing.Point(8, 0);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.Size = new System.Drawing.Size(1109, 25);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell14,
            this.xrTableCell10,
            this.xrTableCell18,
            this.xrTableCell15,
            this.xrTableCell11,
            this.xrTableCell17,
            this.xrTableCell21,
            this.xrTableCell5,
            this.xrTableCell12,
            this.xrTableCell13});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(1109, 25);
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.ParentStyleUsing.UseBorders = false;
            this.xrTableCell6.Size = new System.Drawing.Size(75, 25);
            this.xrTableCell6.Text = "单据ID";
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.Location = new System.Drawing.Point(75, 0);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.ParentStyleUsing.UseBorders = false;
            this.xrTableCell14.Size = new System.Drawing.Size(100, 25);
            this.xrTableCell14.Text = "销售单号";
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell10.Location = new System.Drawing.Point(175, 0);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.ParentStyleUsing.UseBorders = false;
            this.xrTableCell10.ParentStyleUsing.UseFont = false;
            this.xrTableCell10.Size = new System.Drawing.Size(92, 25);
            this.xrTableCell10.Text = "存货编码";
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell18.Location = new System.Drawing.Point(267, 0);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.ParentStyleUsing.UseBorders = false;
            this.xrTableCell18.ParentStyleUsing.UseFont = false;
            this.xrTableCell18.Size = new System.Drawing.Size(200, 25);
            this.xrTableCell18.Text = "存货名称";
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell15.Location = new System.Drawing.Point(467, 0);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.ParentStyleUsing.UseBorders = false;
            this.xrTableCell15.ParentStyleUsing.UseFont = false;
            this.xrTableCell15.Size = new System.Drawing.Size(140, 25);
            this.xrTableCell15.Text = "规格型号";
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell11.Location = new System.Drawing.Point(607, 0);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.ParentStyleUsing.UseBorders = false;
            this.xrTableCell11.ParentStyleUsing.UseFont = false;
            this.xrTableCell11.Size = new System.Drawing.Size(74, 25);
            this.xrTableCell11.Text = "主计量单位";
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell17.Location = new System.Drawing.Point(681, 0);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.ParentStyleUsing.UseBorders = false;
            this.xrTableCell17.ParentStyleUsing.UseFont = false;
            this.xrTableCell17.Size = new System.Drawing.Size(61, 25);
            this.xrTableCell17.Text = "计划数量";
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell21.Location = new System.Drawing.Point(742, 0);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.ParentStyleUsing.UseBorders = false;
            this.xrTableCell21.Size = new System.Drawing.Size(58, 25);
            this.xrTableCell21.Text = "已下单";
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell5.Location = new System.Drawing.Point(800, 0);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.ParentStyleUsing.UseBorders = false;
            this.xrTableCell5.ParentStyleUsing.UseFont = false;
            this.xrTableCell5.Size = new System.Drawing.Size(100, 25);
            this.xrTableCell5.Text = "托外结束日期";
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell12.Location = new System.Drawing.Point(900, 0);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.ParentStyleUsing.UseBorders = false;
            this.xrTableCell12.ParentStyleUsing.UseFont = false;
            this.xrTableCell12.Size = new System.Drawing.Size(101, 25);
            this.xrTableCell12.Text = "需求日期";
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell13.Location = new System.Drawing.Point(1001, 0);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.ParentStyleUsing.UseBorders = false;
            this.xrTableCell13.ParentStyleUsing.UseFont = false;
            this.xrTableCell13.Size = new System.Drawing.Size(108, 25);
            this.xrTableCell13.Text = "供应商交货日期";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel2});
            this.ReportHeader.Height = 106;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(408, 17);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(350, 42);
            this.xrLabel1.Text = "委外计划供应商确认";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dtHead, "Column1", "")});
            this.xrLabel2.Location = new System.Drawing.Point(8, 75);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Size = new System.Drawing.Size(283, 25);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Location = new System.Drawing.Point(1050, 8);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Size = new System.Drawing.Size(50, 25);
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
            this.PageFooter.Height = 39;
            this.PageFooter.Name = "PageFooter";
            // 
            // RepOMPlanVen
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.GroupHeader1,
            this.ReportHeader,
            this.PageFooter});
            this.DataSource = this.dataSet1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 100);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            xrControlStyle1.BackColor = System.Drawing.Color.Transparent;
            this.StyleSheet.Add("Style1", xrControlStyle1);
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
    }
}

