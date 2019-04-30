using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImportDLL
{
    public partial class Frm工时计算 : Form
    {
        TH.DAL.生产排产 DAL = new TH.DAL.生产排产();

        DateTime dTime1;
        DateTime dTime2;
        string sLineNo;
        DataTable dt生产计划;
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        public Frm工时计算(DateTime dDate1,DateTime dDate2,string sLineNO,DataTable dt)
        {
            InitializeComponent();

            dTime1 = dDate1;
            dTime2 = dDate2;
            sLineNo = sLineNO;
            dt生产计划 = dt;
        }

        public Frm工时计算(DateTime dDate1, DateTime dDate2,DataTable dt)
        {
            InitializeComponent();

            dTime1 = dDate1;
            dTime2 = dDate2;
            dt生产计划 = dt;
        }


        private void Frm工时计算_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void AddCol(DateTime dDay)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.Caption = dDay.ToString("MM月dd日");
            gridBand.MinWidth = 80;
            gridBand.Name = "gridBandtemp日期" + dDay.ToString("yyMMdd");
            gridBand.AppearanceHeader.Options.UseTextOptions = true;
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.Bands.Add(gridBand);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "工时";
            gridColumn1.Name = "gridColtemp工时" + dDay.ToString("yyMMdd");
            gridColumn1.FieldName = "工时" + dDay.ToString("yyMMdd");
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.Width = 40;
            gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
            gridBand.Columns.Add(gridColumn1);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn2.Caption = "人均工时";
            gridColumn2.Name = "gridColtemp人均工时" + dDay.ToString("yyMMdd");
            gridColumn2.FieldName = "人均工时" + dDay.ToString("yyMMdd");
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = gridView1.Columns.Count;
            gridColumn2.Width = 40;
            gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand.Columns.Add(gridColumn2);
        }

        private void GetGrid()
        {
            try
            {
                if (dTime2 < dTime1)
                {
                    throw new Exception("生产日期需要从小到大");
                }

                for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Columns[i].Name.Length > 11 && gridView1.Columns[i].Name.Substring(0, 11) == "gridColtemp")
                        gridView1.Columns.RemoveAt(i);
                }

                for (int i = gridView1.Bands.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Bands[i].Name.Length > 12 && gridView1.Bands[i].Name.Substring(0, 12) == "gridBandtemp")
                    {
                        gridView1.Bands.RemoveAt(i);
                    }
                }
                DateTime dTime = dTime1;
                while (dTime <= dTime2)
                {
                    AddCol(dTime);
                    dTime = dTime.AddDays(1);
                }

                label2.Visible = false;
                txt加班.Visible = false;
                txt两班.Visible = false;
                txt三班.Visible = false;
                txt正常.Visible = false;

                DataTable dt = DAL.GetWorkTime();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows.Count >= 1)
                    {
                        label2.Visible = true;
                        txt正常.Visible = true;
                        txt正常.Text = dt.Rows[0]["iText"].ToString().Trim();
                    }
                    if (dt.Rows.Count >= 2)
                    {
                        txt加班.Visible = true;
                        txt加班.Text = dt.Rows[1]["iText"].ToString().Trim();
                    }
                    if (dt.Rows.Count >= 3)
                    {
                        txt两班.Visible = true;
                        txt两班.Text = dt.Rows[2]["iText"].ToString().Trim();
                    }

                    if (dt.Rows.Count >= 4)
                    {
                        txt三班.Visible = true;
                        txt三班.Text = dt.Rows[3]["iText"].ToString().Trim();
                    }
                }

                gridControl1.DataSource = DAL.GetLineWorkTime(dTime1, dTime2, sLineNo, dt生产计划);
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得产线工时失败:" + ee.Message);
            }
        }

        private void btn核查_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                DevExpress.Utils.AppearanceDefault appLawnGreen = new DevExpress.Utils.AppearanceDefault(Color.LawnGreen);
                DevExpress.Utils.AppearanceDefault appLawnLightBlue = new DevExpress.Utils.AppearanceDefault(Color.LightBlue);
                DevExpress.Utils.AppearanceDefault appLawnLightYellow = new DevExpress.Utils.AppearanceDefault(Color.LightYellow);
                DevExpress.Utils.AppearanceDefault appTomato = new DevExpress.Utils.AppearanceDefault(Color.Tomato);

                string sName = e.Column.Name.ToString().Trim();
                if (sName.Length > 11 && sName.Substring(0, 15) == "gridColtemp人均工时" && BaseFunction.BaseFunction.ReturnDecimal(sName.Substring(15)) > 0)
                {

                    decimal d = BaseFunction.BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, e.Column), 1);
                    if (d == 0)
                    {

                    }
                    else if (d > 0 && d <= 8)
                    {
                        //DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appLawnGreen);
                    }
                    else if (d > 8 && d <= 16)
                    {
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appLawnLightBlue);
                    }
                    else if (d > 16 && d <= 24)
                    {
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appLawnLightYellow);
                    }
                    else
                    {
                        DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appTomato);
                    }
                }
            }
            catch { }
        }

        private void btn导出_Click(object sender, EventArgs e)
        {
            try
            {
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
                MessageBox.Show(ee.Message);
            }
        }



        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

    }
}
