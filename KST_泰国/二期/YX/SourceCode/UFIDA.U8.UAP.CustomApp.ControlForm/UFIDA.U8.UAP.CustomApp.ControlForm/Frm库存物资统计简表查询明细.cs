using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Frm库存物资统计简表查询明细 : Form
    {
        public string Conn { get; set; }
        public string cInvCode1 = "";
        public string cInvCode2 = "";
        public string sdate = "";
        public string edate = "";
        public string cFree1 = "";
        public string cFree3 = "";
        public string cFree4 = "";
        public string cposname = "";
        public string cWhCode = "";

        public Frm库存物资统计简表查询明细(string conn, string scInvCode1, string scInvCode2, string ssdate, string sedate, string scFree1, string scFree3, string scFree4, string scposname, string scWhCode)
        {
            InitializeComponent();
            Conn = conn;
            cInvCode1 = scInvCode1;
            cInvCode2 = scInvCode2;
            sdate = ssdate;
            edate = sedate;
            cFree1 = scFree1;
            cFree3 = scFree3;
            cFree4 = scFree4;
            cposname = scposname;
            cWhCode = scWhCode;
        }


        private void Frm库存物资统计简表查询明细_Load(object sender, EventArgs e)
        {
            try
            {
                系统服务.规格化.GetGridViewSet(gridView1);
                Cls时间锁 cls = new Cls时间锁();
                if (cls.bchk时间锁(Conn) == false)
                {
                    throw new Exception("加载数据失败");
                }
                btnRefresh_Click(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败");
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Cls时间锁 cls = new Cls时间锁();
                if (cls.bchk时间锁(Conn) == false)
                {
                    throw new Exception("加载数据失败");
                }
                for (int i = gridView1.Columns.Count - 1; i >= 6; i--)
                {
                    if (gridView1.Columns[i].FieldName.IndexOf("cWhCode_") > -1 || gridView1.Columns[i].FieldName.IndexOf("Project_") > -1 || gridView1.Columns[i].FieldName.IndexOf("QCResult_") > -1
                        || gridView1.Columns[i].FieldName.IndexOf("gridCol_待检") > -1 || gridView1.Columns[i].FieldName.IndexOf("gridCol_合格") > -1 || gridView1.Columns[i].FieldName.IndexOf("gridCol_不合格") > -1)
                    {
                        gridView1.Columns.Remove(gridView1.Columns[i]);
                    }
                }

                for (int i = gridBand期末质检状态.Children.Count - 1; i >= 0; i--)
                {
                    if (gridBand期末质检状态.Children[i].Name.IndexOf("gridCol待检") != -1 && gridBand期末质检状态.Children[i].Name.IndexOf("gridCol合格") != -1 && gridBand期末质检状态.Children[i].Name.IndexOf("gridCol不合格") != -1)
                    {
                        gridBand期末质检状态.Children[i].Visible = false;
                    }

                }
                数据源 f = new 数据源();
                DataTable dtck = f.Warehouse(Conn);
                for (int i = 0; i < dtck.Rows.Count; i++)
                {
                    GetCol(dtck.Rows[i]["cWhName"].ToString(), "cWhCode_" + dtck.Rows[i]["cWhCode"].ToString().Trim(), 1);
                }
                DataTable dtproj = f.Project(Conn);
                for (int i = 0; i < dtproj.Rows.Count; i++)
                {
                    GetCol(dtproj.Rows[i]["cValue"].ToString(), "Project_" + dtproj.Rows[i]["cValue"].ToString().Trim(), 2);
                }
                DataTable dtqc = f.QC(Conn, cInvCode1, cInvCode2);
                for (int s = 0; s < dtqc.Rows.Count; s++)
                {
                    GetCol(dtqc.Rows[s]["QCName"].ToString(), "QCResult_" + dtqc.Rows[s]["QCCode"].ToString().Trim());
                }
                DataTable dt = f.库存(Conn, cInvCode1, cInvCode2, sdate, edate, cFree1, cFree3, cFree4, cposname, cWhCode,true);
                gridControl1.DataSource = dt;
                gridView1.OptionsBehavior.Editable = false;
                
                gridView1.BestFitColumns();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetCol(string ColText, string FieldName,int flag)
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Col = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            Col.FieldName = FieldName;
            Col.Name = "gridBand_仓库" + FieldName;
            Col.Caption = ColText;
            Col.OptionsColumn.AllowEdit = false;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count - 1;
            Col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Col.SummaryItem.FieldName = FieldName;
            gridView1.Columns.Add(Col);
            if (flag == 1)
            {
                gridBand实体库.Columns.Add(Col);
            }
            else if (flag == 2)
            {
                gridBand虚拟库.Columns.Add(Col);
            }
            
            //gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, FieldName, Col);
        }

        private void GetCol(string ColText, string FieldName4)
        {
            //DevExpress.XtraGrid.Views.BandedGrid.GridBand Band1=new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            //bool b = false;
            //for (int i = gridBand期末质检状态.Children.Count - 1; i >= 0; i--)
            //{
            //    if (gridBand期末质检状态.Children[i].Name.IndexOf(ColText) > -1)
            //    {
            //        b = true;
            //        Band1 = gridBand期末质检状态.Children[i];
            //        Band1.Visible = true;
            //    }
            //}
            //if (b == false)
            //{
            //    Band1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            //    Band1.Caption = ColText;
            //    Band1.Name = "gridBand_检验" + ColText;
            //    gridBand期末质检状态.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { Band1 });
            //}

            //DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Col1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            //Col1.FieldName = FieldName1;
            //Col1.Name = "gridCol_待检" + FieldName1;
            //Col1.Caption = "待检";
            //Col1.OptionsColumn.AllowEdit = false;
            //Col1.Width = 70;
            //Col1.Visible = true;
            //Col1.VisibleIndex = gridView1.Columns.Count - 1;
            //Col1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //Col1.SummaryItem.FieldName = FieldName1;
            //gridView1.Columns.Add(Col1);
            //Band1.Columns.Add(Col1);


            //DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Col2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            //Col2.FieldName = FieldName2;
            //Col2.Name = "gridCol_合格" + FieldName2;
            //Col2.Caption = "合格";
            //Col2.OptionsColumn.AllowEdit = false;
            //Col2.Width = 70;
            //Col2.Visible = true;
            //Col2.VisibleIndex = gridView1.Columns.Count - 1;
            //Col2.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //Col2.SummaryItem.FieldName = FieldName2;
            //gridView1.Columns.Add(Col2);
            //Band1.Columns.Add(Col2);

            //DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Col3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            //Col3.FieldName = FieldName3;
            //Col3.Name = "gridCol_不合格" + FieldName3;
            //Col3.Caption = "不合格";
            //Col3.OptionsColumn.AllowEdit = false;
            //Col3.Width = 70;
            //Col3.Visible = true;
            //Col3.VisibleIndex = gridView1.Columns.Count - 1;
            //Col3.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //Col3.SummaryItem.FieldName = FieldName3;
            //gridView1.Columns.Add(Col3);
            //Band1.Columns.Add(Col3);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn Col4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            Col4.FieldName = FieldName4;
            Col4.Name = "gridCol_内容" + FieldName4;
            Col4.Caption = ColText;
            Col4.OptionsColumn.AllowEdit = false;
            Col4.Width = 70;
            Col4.Visible = true;
            Col4.VisibleIndex = gridView1.Columns.Count - 1;
            //Col4.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            //Col4.SummaryItem.FieldName = FieldName4;
            gridBand期末质检.Columns.Add(Col4);

            //gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, FieldName, Col);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                this.Validate();

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("导出列表失败：" + ee.Message);
            }
        }
    }
}