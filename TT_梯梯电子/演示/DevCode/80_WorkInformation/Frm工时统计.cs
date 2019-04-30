using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace WorkInformation
{
    public partial class Frm工时统计 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm工时统计()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            }

            dtBingGrid = new DataTable();
            dtBingHead = new DataTable();
        }

       

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "audit":
                        btnAudit();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "print":
                        btnPrint();
                        break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "layout":
                        btnLayout(sBtnText);
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnEdit()
        {
         
        }

        private void btnAlter()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = "班组工时";
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


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            //DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
           
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //}

            //return dt;
            return null;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = "班组工时";
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
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = "设备工时";
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView2.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLayout(string sText)
        {
            if (layoutControl1 == null) return;
            if (sText == "布局")
            {
                //layoutControl1.ShowCustomizationForm();
                layoutControl1.AllowCustomizationMenu = true;
                base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

                gridView1.OptionsMenu.EnableColumnMenu = true;
                gridView1.OptionsMenu.EnableFooterMenu = true;
                gridView1.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView1.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView1.OptionsMenu.EnableColumnMenu = false;
                gridView1.OptionsMenu.EnableFooterMenu = false;
                gridView1.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView1.OptionsCustomization.AllowColumnMoving = false;


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                    gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
                }
                else if (d == DialogResult.No)
                {
                    if (File.Exists(sLayoutHeadPath))
                        File.Delete(sLayoutHeadPath);

                    if (File.Exists(sLayoutGridPath))
                        File.Delete(sLayoutGridPath);
                }
            }
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
          
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {

            if (dtm.DateTime < Convert.ToDateTime("2013-1-1"))
                throw new Exception("排产日期错误");

            AddGridCol();

            string sSQL = @"
select d.iText as 组别,c.计划生产日期,CAST( sum(ISNULL(cast( b.单位工时 as decimal(16,10)),0) * ISNULL(cast(c.数量 as decimal(16,2)),0)) as decimal(16,2)) as 工时
from dbo.生产计划 a inner join dbo.生产计划明细 b on a.单据号 = b.表头单据号
	inner join dbo.生产日计划 c on b.iID = c.生产计划明细iID
	left join dbo._LookUpDate d on d.iID = b.组别 and d.iType = 15
where a.帐套号 = '200' and c.排产日期 = '2013-10-14'
group by d.iText,c.计划生产日期
order by c.计划生产日期,d.iText
";

            sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
            sSQL = sSQL.Replace("2013-10-14", dtm.DateTime.ToString("yyyy-MM-dd"));
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select distinct iText from dbo._LookUpDate where iType = 15 order by iText";
            DataTable dt组别 = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dt组别.Rows.Count; i++)
            {
                DataRow dr = dtGrid.NewRow();
                dr["班组"] = dt组别.Rows[i]["iText"].ToString().Trim();
                dtGrid.Rows.Add(dr);
            }

            for (int i = 0; i < dtGrid.Rows.Count; i++)
            {
                string s组别 = dtGrid.Rows[i]["班组"].ToString().Trim();

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s组别2 = dt.Rows[j]["组别"].ToString();
                    string s列 = Convert.ToDateTime( dt.Rows[j]["计划生产日期"]).ToString("MM月dd日");

                    if (s组别 == s组别2)
                    {
                        dtGrid.Rows[i]["[" + s列 + "]"] = dt.Rows[j]["工时"];
                    }
                }
            }

            gridControl1.DataSource = dtGrid;


            //---------

            sSQL = @"
select b.设备,c.计划生产日期,CAST( sum(ISNULL(cast( b.单位工时 as decimal(16,10)),0) * ISNULL(cast( c.数量 as decimal(16,2)),0)) as decimal(16,2)) as 工时
from dbo.生产计划 a inner join dbo.生产计划明细 b on a.单据号 = b.表头单据号
	inner join dbo.生产日计划 c on b.iID = c.生产计划明细iID
where a.帐套号 = '200' and c.排产日期 = '2013-10-14'
group by b.设备,c.计划生产日期
order by c.计划生产日期,设备
";

            sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
            sSQL = sSQL.Replace("2013-10-14", dtm.DateTime.ToString("yyyy-MM-dd"));
            dt = clsSQLCommond.ExecQuery(sSQL);


            sSQL = @"
select distinct b.设备 
from dbo.生产计划 a inner join dbo.生产计划明细 b on a.单据号 = b.表头单据号
	inner join dbo.生产日计划 c on b.iID = c.生产计划明细iID
where a.帐套号 = '200' and c.排产日期 = '2013-10-14' 
order by b.设备
";
            sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
            sSQL = sSQL.Replace("2013-10-14", dtm.DateTime.ToString("yyyy-MM-dd"));

            DataTable dt设备 = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt设备.Rows.Count; i++)
            {
                DataRow dr = dtGrid2.NewRow();
                dr["设备"] = dt设备.Rows[i]["设备"].ToString().Trim();
                dtGrid2.Rows.Add(dr);
            }

            for (int i = 0; i < dtGrid2.Rows.Count; i++)
            {
                string s设备 = dtGrid2.Rows[i]["设备"].ToString().Trim();

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s设备2 = dt.Rows[j]["设备"].ToString();
                    string s列 = Convert.ToDateTime(dt.Rows[j]["计划生产日期"]).ToString("MM月dd日");

                    if (s设备 == s设备2)
                    {
                        dtGrid2.Rows[i]["[" + s列 + "]"] = dt.Rows[j]["工时"];
                    }
                }
            }

            gridControl2.DataSource = dtGrid2;
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
           
        }

       
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
          
        }

        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
           
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
          
        }
      

        #endregion

        private void Frm工时统计_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select max(排产日期) from 生产日计划";
                DateTime d = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
                dtm.DateTime = d;
            }
            catch (Exception ee) 
            {
                MessageBox.Show("加载数据失败");
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

        DataTable dtGrid;
        DataTable dtGrid2;
        private void AddGridCol()
        {
            for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
            {
                gridView1.Columns.RemoveAt(i);
            }

            dtGrid = new DataTable();
            DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();

            gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1 });
            gridColumn1.Caption = "班组";
            gridColumn1.Name = "gridCol班组";
            gridColumn1.FieldName = "班组";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = 0;
            gridColumn1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            DataColumn dc = new DataColumn();
            dc.ColumnName = "班组";
            dtGrid.Columns.Add(dc);

            string sSQL = "select distinct 计划生产日期 from 生产日计划 where 排产日期 = '" + dtm.DateTime.ToString("yyyy-MM-dd") + "' order by 计划生产日期";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();

                gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1 });

                string sCol = Convert.ToDateTime(dt.Rows[i]["计划生产日期"]).ToString("MM月dd日");
                gridColumn1.Caption = sCol;
                gridColumn1.Name = "gridCol" + sCol;
                gridColumn1.FieldName = "[" + sCol + "]";
                gridColumn1.Visible = true;
                gridColumn1.VisibleIndex = 0;
                gridColumn1.VisibleIndex = i + 2;
                gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});

                dc = new DataColumn();
                dc.ColumnName = "[" + sCol + "]";
                dtGrid.Columns.Add(dc);
            }

            //-----------------------

            for (int i = gridView2.Columns.Count - 1; i >= 0; i--)
            {
                gridView2.Columns.RemoveAt(i);
            }

            dtGrid2 = new DataTable();
            DevExpress.XtraGrid.Columns.GridColumn gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();

            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn2 });
            gridColumn2.Caption = "设备";
            gridColumn2.Name = "gridCol_设备";
            gridColumn2.FieldName = "设备";
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = 0;
            gridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "设备";
            dtGrid2.Columns.Add(dc2);

            string sSQL2 = "select distinct 计划生产日期 from 生产日计划 where 排产日期 = '" + dtm.DateTime.ToString("yyyy-MM-dd") + "' order by 计划生产日期";
            DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();

                gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn2 });

                string sCol = Convert.ToDateTime(dt2.Rows[i]["计划生产日期"]).ToString("MM月dd日");
                gridColumn2.Caption = sCol;
                gridColumn2.Name = "gridCol_" + sCol;
                gridColumn2.FieldName = "[" + sCol + "]";
                gridColumn2.Visible = true;
                gridColumn2.VisibleIndex = 0;
                gridColumn2.VisibleIndex = i + 2;
                gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

                dc = new DataColumn();
                dc.ColumnName = "[" + sCol + "]";
                dtGrid2.Columns.Add(dc);
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
