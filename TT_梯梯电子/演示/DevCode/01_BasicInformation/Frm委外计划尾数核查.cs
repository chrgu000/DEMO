using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace BasicInformation
{
    public partial class Frm委外计划尾数核查 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm委外计划尾数核查()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            //gridView1.OptionsMenu.EnableColumnMenu = false;
            //gridView1.OptionsMenu.EnableFooterMenu = false;
            //gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //gridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            //gridView1.OptionsCustomization.AllowColumnMoving = false;
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


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
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
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
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
                    gridView1.ExportToXls(sF.FileName);
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
            string sErr = "";
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = oFile.FileName;
                string sSQL = "select distinct 设备编号 as MachineNO,设备 as Machine,负责人,状态 as State,备注 as Remark,null as tstamp,null as iSave from [设备档案$]";

                DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    string sMachineNO = dtExcel.Rows[i]["MachineNO"].ToString().Trim();
                    DataRow[] dr = dtBingGrid.Select("MachineNO = '" + sMachineNO + "'");
                    if (dr.Length > 0)
                    {
                        dtExcel.Rows[i]["tstamp"] = dr[0]["tstamp"];
                        sErr = sErr + sMachineNO + "\n";
                    }
                }
                gridControl1.DataSource = dtExcel;

                if (sErr.Length > 0)
                {
                    sErr = "以下设备编号已经存在，不能重复导入：\n" + sErr;
                    MsgBox("提示", sErr);
                }
            }
            else
            {
                throw new Exception("取消导入");
            }
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
            GetGrid();
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
            gridView1.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
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
        /// 判断生产设备是否已经使用
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private bool CheckCanDel(string p,out string sErr)
        {
            bool b = true;
            sErr = "";

            return b;
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {

        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            GetGrid();
            gridView1.FocusedRowHandle = iFocRow;
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

        private void Frm委外计划尾数核查_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit导入日期1.DateTime = DateTime.Today.AddMonths(-1);
                dateEdit导入日期2.DateTime = DateTime.Today;

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = @"

select distinct a.iID,a.InvCode as 物料编码,i.cInvName as 物料名称,i.cInvStd as 物料规格,a.ImportDate as 导入日期,a.SoCode as 外销单号,a.PlanQty as 计划数量
	,null as 订单数量
	,e.iQuantity as 到货数量
	,null as 入库数量
into #a
from  UFDLImport.dbo.OMPlan a left join UFDLImport.dbo.OMPlanDay_Import b on a.iID = b.OMPlanID
	inner join @u8.inventory i on a.InvCode = i.cInvCode
	left join @u8.OM_MODetails c on c.MODetailsID = b.OM_MODetailsID
	left join( 
				select a.cCode,b.cInvCode,b.iQuantity,b.SoDId,b.iPOsID,b.Autoid
				from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.ID
				where a.cPTCode = '02'
			 ) e on e.iPOsID = c.MODetailsID and e.cInvCode = a.InvCode
where 1=1 and a.AccID = '200'

select distinct a.iID,a.InvCode as 物料编码,i.cInvName as 物料名称,i.cInvStd as 物料规格,a.ImportDate as 导入日期,a.SoCode as 外销单号,a.PlanQty as 计划数量
	,null as 订单数量
	,null as 到货数量
	,sum(f.iQuantity) as 入库数量
into #b
from  UFDLImport.dbo.OMPlan a left join UFDLImport.dbo.OMPlanDay_Import b on a.iID = b.OMPlanID
	inner join @u8.inventory i on a.InvCode = i.cInvCode
	left join @u8.OM_MODetails c on c.MODetailsID = b.OM_MODetailsID
	left join @u8.OM_MOMain d on d.MOID = c.MOID 
	left join( 
				select a.cCode,b.cInvCode,b.iQuantity,b.SoDId,b.iPOsID,b.Autoid
				from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.ID
				where a.cPTCode = '02'
			 ) e on e.iPOsID = c.MODetailsID and e.cInvCode = a.InvCode
	left join (
			    select a.cCode ,b.cInvCode,b.iQuantity,b.iArrsId
			    from @u8.rdrecord01 a inner join @u8.rdrecords01 b on a.id = b.ID
			 ) f on e.Autoid = f.iArrsId
where 1=1 and a.AccID = '200' 
group by a.iID,a.InvCode,i.cInvName,i.cInvStd,a.ImportDate,a.SoCode,a.PlanQty


select 

	iID, 物料编码,物料名称,物料规格,导入日期,外销单号, 外销单号,计划数量,SUM(订单数量) as 订单数量,SUM(到货数量) as 到货数量,SUM(入库数量) as 入库数量,cast (null as varchar(1000)) as 供应商
from
(
select distinct a.iID,a.InvCode as 物料编码,i.cInvName as 物料名称,i.cInvStd as 物料规格,a.ImportDate as 导入日期,a.SoCode as 外销单号,a.PlanQty as 计划数量
	,sum(c.iQuantity) as 订单数量
	,null as 到货数量
	,null as 入库数量
from  UFDLImport.dbo.OMPlan a left join UFDLImport.dbo.OMPlanDay_Import b on a.iID = b.OMPlanID
	inner join @u8.inventory i on a.InvCode = i.cInvCode
	left join @u8.OM_MODetails c on c.MODetailsID = b.OM_MODetailsID
	left join @u8.OM_MOMain d on d.MOID = c.MOID 
where 1=1 and a.AccID = '200'
group by a.iID,a.InvCode,i.cInvName,i.cInvStd,a.ImportDate,a.SoCode,a.PlanQty
union 

select iID,物料编码, 物料名称,物料规格,导入日期,外销单号,计划数量,订单数量,SUM(到货数量) as 到货数量,入库数量
from #a
group by  iID,物料编码, 物料名称,物料规格,导入日期,外销单号,计划数量,订单数量,入库数量

union 

select iID,物料编码, 物料名称,物料规格,导入日期,外销单号,计划数量,订单数量, 到货数量,SUM(入库数量) as 入库数量
from #b
group by  iID,物料编码, 物料名称,物料规格,导入日期,外销单号,计划数量,订单数量,到货数量

) a
group by iID, 物料编码,物料名称,物料规格,导入日期,外销单号, 外销单号,计划数量
having 2=2
order by a.iID


";

            sSQL = sSQL.Replace("1=1", " 1=1 and a.ImportDate >= '" + dateEdit导入日期1.DateTime.ToString("yyyy-MM-dd") + "' and a.ImportDate <= '" + dateEdit导入日期2.DateTime.ToString("yyyy-MM-dd") + "'");

            if(!chk包含已关闭.Checked)
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and isnull(a.ClosedUID,'') = '' ");
            }

            if (radio数量.Checked)
            {
                sSQL = sSQL.Replace("2=2", " 2=2 and isnull(计划数量,0) -  isnull(SUM(入库数量),0) <= " + ReturnObjectToDecimal(txt范围.Text.Trim(), 6) + " and isnull(计划数量,0) > isnull(SUM(入库数量),0) and isnull(SUM(入库数量),0) > 0 ");
            }

            if (radio百分比.Checked)
            {
                sSQL = sSQL.Replace("2=2", " 2=2 and isnull(计划数量,0) > 0 and (isnull(计划数量,0) -  isnull(SUM(入库数量),0)) / isnull(计划数量,0) <= " + ReturnObjectToDecimal(txt范围.Text.Trim(), 6) + "/100 and isnull(计划数量,0) > isnull(SUM(入库数量),0) and isnull(SUM(入库数量),0) > 0 ");
            }

            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dtBingGrid.Rows.Count; i++)
            {
                sSQL = @"
select distinct a.iID,e.cVenCode,e.cVenName,e.cVenAbbName
from  UFDLImport.dbo.OMPlan a left join UFDLImport.dbo.OMPlanDay_Import b on a.iID = b.OMPlanID
	inner join @u8.inventory i on a.InvCode = i.cInvCode
	left join @u8.OM_MODetails c on c.MODetailsID = b.OM_MODetailsID
	left join @u8.OM_MOMain d on d.MOID = c.MOID 
    left join @u8.Vendor e on d.cVenCode = e.cVenCode
where 1=1 and a.iID = 111111
";
                sSQL = sSQL.Replace("111111", dtBingGrid.Rows[i]["iID"].ToString().Trim());

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                string sVendor = "";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["cVenCode"].ToString().Trim() == "")
                        continue;

                    if (sVendor == "")
                    {
                        sVendor = "【" + dt.Rows[j]["cVenCode"].ToString().Trim() + "】" + dt.Rows[j]["cVenAbbName"].ToString().Trim();
                    }
                    else
                    {
                        sVendor = sVendor + "；【" + dt.Rows[j]["cVenCode"].ToString().Trim() + "】" + dt.Rows[j]["cVenAbbName"].ToString().Trim();
                    }
                }

                dtBingGrid.Rows[i]["供应商"] = sVendor;
            }
                
            gridControl1.DataSource = dtBingGrid;
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow >= 0 && iRow < gridView1.RowCount)
                {
                    int iID = ReturnObjectToInt(gridView1.GetRowCellDisplayText(iRow, gridColiID));

                    Frm委外计划执行核查明细 f = new Frm委外计划执行核查明细(iID);
                    f.ShowDialog();
                }
            }
            catch { }
        }

        private void radio百分比_CheckedChanged(object sender, EventArgs e)
        {
            if (radio百分比.Checked)
                label1.Text = "%";
            else
                label1.Text = "";
        }
    }
}
