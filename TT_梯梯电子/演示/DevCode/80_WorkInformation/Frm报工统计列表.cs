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
    public partial class Frm生产报工统计列表 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm生产报工统计列表()
        {
            InitializeComponent();

            #region 禁止用户调整表格

            GridView1.OptionsMenu.EnableColumnMenu = false;
            GridView1.OptionsMenu.EnableFooterMenu = false;
            GridView1.OptionsMenu.EnableGroupPanelMenu = false;
            GridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            GridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            GridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            GridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            GridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            GridView1.OptionsBehavior.FocusLeaveOnTab = true;
            GridView1.OptionsCustomization.AllowColumnMoving = false;
            //GridView1.OptionsCustomization.

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
                    case "addrow":
                        btnAddRow();
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "first":
                        btnFirst();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    case "print":
                        btnPrint();
                        break;
                    //case "printset":
                    //    btnPrintSet();
                    //    break;
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
                    case "undo":
                        btnUnDo();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClose();
                        break;
                    case "layout":
                        btnLayout(sBtnText);
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

        private void btnSave()
        {
           
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            DataTable dtState = (DataTable)ItemLookUpEdit设备.DataSource;
            DataColumn dc = new DataColumn();
            dc.ColumnName = "StateText";
            dt.Columns.Add(dc);
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
                if (drState.Length > 0)
                {
                    dt.Rows[i]["StateText"] = drState[0]["State"];
                }

            }

            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
                GridView1.FocusedRowHandle -= 1;
                GridView1.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
            dtGrid.TableName = "dtGrid";

            base.dsPrint.Tables.Add(dtGrid);
            DataTable dtHead = dtBingHead.Copy();
            dtHead.TableName = "dtHead";
            base.dsPrint.Tables.Add(dtHead);
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
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    GridView1.ExportToXls(sF.FileName);
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

                GridView1.OptionsMenu.EnableColumnMenu = true;
                GridView1.OptionsMenu.EnableFooterMenu = true;
                GridView1.OptionsMenu.EnableGroupPanelMenu = true;
                //GridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                GridView1.OptionsMenu.ShowAutoFilterRowItem = true;
                GridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                GridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
                GridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
                GridView1.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                GridView1.OptionsMenu.EnableColumnMenu = false;
                GridView1.OptionsMenu.EnableFooterMenu = false;
                GridView1.OptionsMenu.EnableGroupPanelMenu = false;
                //GridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                GridView1.OptionsMenu.ShowAutoFilterRowItem = false;
                GridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                GridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
                GridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
                GridView1.OptionsCustomization.AllowColumnMoving = false;


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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            aList = new System.Collections.ArrayList();

            for(int i= GridView1.Columns.Count - 1;i>=0; i--)
            {
                string sName = GridView1.Columns[i].FieldName.Trim();
                if (sName.Length > 2 && (sName.Substring(0, 2) == "数量" || sName.Substring(0, 2) == "工时"))
                {
                    GridView1.Columns.RemoveAt(i);
                }
            }

            for (int i = GridView1.Bands.Count - 1; i >= 0; i--)
            {
                string sBand = GridView1.Bands[i].Caption.Trim();
                if (sBand != "")
                    GridView1.Bands.RemoveAt(i);
            }

            TimeSpan ts = dtm生产日期2.DateTime - dtm生产日期1.DateTime;
            int iCol = ts.Days;

            string sC = "";
            for (int i = 0; i <= iCol; i++)
            {
                string sName = dtm生产日期1.DateTime.AddDays(i).ToString("yyyy年MM月dd日");
                AddCol(sName);

                sC = sC + ",数量111111 decimal(16,2),工时111111 decimal(16,2)";
                sC = sC.Replace("111111",sName);
            }

            sSQL = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[报工统计列表]') AND type in (N'U'))
    DROP TABLE [dbo].[报工统计列表]

create table 报工统计列表(
        制造令号码 varchar(100)
        ,物料编码 varchar(100)
        ,物料名称 varchar(100)
        ,规格型号 varchar(100)
        ,工序 varchar(100)
        ,部门 varchar(100)
        ,人员 varchar(100)
        ,设备 varchar(100)
        ,外销单号 varchar(100)
        111111
    )
";
            sSQL = sSQL.Replace("111111", sC);
            aList.Add(sSQL);
            //,case when ISNULL(a.bRDIn,0) = 0 then workProcedure else '缴库' end
            for (int i = 0; i <= iCol; i++)
            {
                //日期中含有具体时间，所以where条件修正为 >= 日期1 and < 日期1 + 1，以便获得 日期1的数据
                string sName = dtm生产日期1.DateTime.AddDays(i).ToString("yyyy-MM-dd");
                string sName2 = dtm生产日期1.DateTime.AddDays(i + 1).ToString("yyyy-MM-dd");
                sSQL = @"

declare @dtmStartUse datetime
set @dtmStartUse = '2016-11-01' 

insert into 报工统计列表(制造令号码,物料编码,物料名称,规格型号,工序,部门,人员,设备,外销单号,数量111111,工时111111)
select a.WorkOrderNO as 制造令号码,a.cInvCode as 物料编码,c.cInvName,c.cInvStd,workProcedure  as 工序
	,WorkDepment as 部门,b.vchrPer as 人员,b.vchrFacility as 设备,a.sOrder,b.iQuantity as 报工数量, cast(isnull(a.dtmtime,0) / a.iQuantity  * b.iQuantity as decimal(16,2)) as 报工工时
from UFDLImport..workplan a
	inner join UFDLImport.dbo.WorkPlanDetail b on a.GUID = b.GUIDHead 
    left join @u8.Inventory c on a.cInvCode = c.cInvCode
where a.AccID = '200' and a.AccYear = 'aaaaaa' and b.dtmDay >= '222222' and b.dtmDay < '333333'
    and (isnull(a.bRDIn,0) = 0 or isnull(a.bRDIn,0) = 2)
    and a.dtmPlan > @dtmStartUse

insert into 报工统计列表(制造令号码,物料编码,物料名称,规格型号,工序,部门,人员,设备,外销单号,数量111111,工时111111)
select a.WorkOrderNO as 制造令号码,a.cInvCode as 物料编码,c.cInvName,c.cInvStd,workProcedure  as 工序
	,WorkDepment as 部门,b.vchrPer as 人员,b.vchrFacility as 设备,a.sOrder,b.iQuantity as 报工数量, cast(isnull(a.dtmtime,0) / a.iQuantity  * b.iQuantity as decimal(16,2)) as 报工工时
from UFDLImport..workplan a
	inner join UFDLImport.dbo.WorkPlanDetail b on a.GUID = b.GUIDHead 
    left join @u8.Inventory c on a.cInvCode = c.cInvCode
where a.AccID = '200' and a.AccYear = 'aaaaaa' and b.dtmDay >= '222222' and b.dtmDay < '333333'
    and isnull(a.bRDIn,0) = 0 
    and a.dtmPlan <= @dtmStartUse
";
                sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                sSQL = sSQL.Replace("aaaaaa", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));

                sSQL = sSQL.Replace("111111", Convert.ToDateTime(sName).ToString("yyyy年MM月dd日"));
                sSQL = sSQL.Replace("222222", sName);
                sSQL = sSQL.Replace("333333", sName2);
                aList.Add(sSQL);
            }

            clsSQLCommond.ExecSqlTran(aList);

            string s = "";
            for (int i = 0; i < GridView1.Columns.Count; i++)
            {
                string sName = GridView1.Columns[i].FieldName.Trim();
                if (sName.Length > 2 && (sName.Substring(0, 2) == "数量" || sName.Substring(0, 2) == "工时"))
                {
                    s = s + ",sum(111111) as 111111";
                    s = s.Replace("111111", sName);
                }

            }

            string sCol = "物料编码,物料名称,规格型号,工序,部门,人员,设备,外销单号,制造令号码";

            sSQL = "select 111111 222222 from 报工统计列表 group by 111111 order by 111111";
            sSQL = sSQL.Replace("111111", sCol);
            sSQL = sSQL.Replace("222222", s);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {
            GridView1.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = GridView1.RowCount - 1; i >= 0 ; i--)
            {
                if (GridView1.IsRowSelected(i))
                {
                    GridView1.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            
        }

      
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {

        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm报工统计列表_Load(object sender, EventArgs e)
        {
            try
            {
                dtm生产日期1.DateTime = DateTime.Today.AddDays(-8);
                dtm生产日期2.DateTime = DateTime.Today.AddDays(-1);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    decimal d = ReturnObjectToDecimal(GridView1.GetRowCellDisplayText(e.RowHandle, GridView1.Columns["缺料数量"]), 6);
                    if (d > 0)
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            { }
        }

        private void AddCol(string sName)
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol数量 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            GridCol数量.AppearanceHeader.Options.UseTextOptions = true;
            GridCol数量.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            GridCol数量.Caption = "数量";
            GridCol数量.FieldName = "数量" + sName;
            GridCol数量.Name = "GridCol数量" + sName;
            GridCol数量.Visible = true;
            GridCol数量.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;


            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn GridCol工时 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            GridCol工时.AppearanceHeader.Options.UseTextOptions = true;
            GridCol工时.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            GridCol工时.Caption = "工时";
            GridCol工时.FieldName = "工时" + sName;
            GridCol工时.Name = "GridCol工时" + sName;
            GridCol工时.Visible = true;
            GridCol工时.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
              
         DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
                GridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gridBand});
               gridBand.AppearanceHeader.Options.UseTextOptions = true;
            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand.Caption = sName;
            gridBand.Columns.Add(GridCol数量);
            gridBand.Columns.Add(GridCol工时);
            gridBand.Name = "gridBand" + sName;
            gridBand.Width = 150;
        }
    }
}
