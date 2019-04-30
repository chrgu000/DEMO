using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace Warehouse
{
    public partial class Frm检验合格单列表 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm检验合格单列表()
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
                    case "addrow":
                        btnAddRow();
                        break;
                    case "add":
                        btnAdd();
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

        private void btnAdd()
        {
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (gridView1.GetRowCellValue(i, gridCol本次调拨) != null && gridView1.GetRowCellValue(i, gridCol本次调拨).ToString().Trim() != "")
            //        continue;

            //    string sInvCode = gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
            //    if ("WW0013Barcel01" == sInvCode)
            //    { 
                
            //    }
            //    decimal d累计下单 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol累计下单));
            //    decimal d现存量 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol仓库可用量));
            //    decimal d待调拨 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol子件待调拨数量));
            //    decimal d本次调拨 = ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次调拨));

            //    if (d待调拨 + d累计下单 < d现存量)
            //    {
            //        d本次调拨 = d待调拨;
            //        d累计下单 = d累计下单 + d本次调拨;
            //    }
            //    else
            //    {
            //        if (d现存量 > d累计下单)
            //        {
            //            d本次调拨 = d现存量 - d累计下单;
            //            d累计下单 = d累计下单 + d本次调拨;
            //        }
            //    }
            //    gridView1.SetRowCellValue(i, gridCol累计下单, d累计下单);
            //    gridView1.SetRowCellValue(i, gridCol本次调拨, d本次调拨);

            //    for (int j = i+1; j < gridView1.RowCount; j++)
            //    {
            //        string sInvCode2 = gridView1.GetRowCellValue(j, gridCol子件编码).ToString().Trim();
            //        if (sInvCode == sInvCode2)
            //        {
            //            decimal d待调拨2 = ReturnDecimal(gridView1.GetRowCellValue(j, gridCol子件待调拨数量));
            //            decimal d本次调拨2 = ReturnDecimal(gridView1.GetRowCellValue(j, gridCol本次调拨));
            //            if (d累计下单 < d现存量)
            //            {
            //                if (d待调拨2 > d现存量 - d累计下单)
            //                {
            //                    d本次调拨2 = d现存量 - d累计下单;
            //                    d累计下单 = d现存量;
            //                }
            //                else
            //                {
            //                    d本次调拨2 = d待调拨2;
            //                    d累计下单 = d累计下单 + d本次调拨2;
            //                }
            //            }
            //            gridView1.SetRowCellValue(j, gridCol累计下单, d累计下单);
            //            gridView1.SetRowCellValue(j, gridCol本次调拨, d本次调拨2);
            //        }
            //    }
            //}
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

            for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
            {
                if (!Convert.ToBoolean(dtGrid.Rows[i]["选择"]))
                {
                    dtGrid.Rows.RemoveAt(i);
                }
                else
                {
                    double d本次入库数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDouble(dtGrid.Rows[i]["本次入库数量"]);
                    dtGrid.Rows[i]["可入库数量"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDouble(dtGrid.Rows[i]["可入库数量"]);
                    dtGrid.Rows[i]["可入库件数"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDouble(dtGrid.Rows[i]["可入库件数"]);
                    dtGrid.Rows[i]["本次入库数量"] = d本次入库数量;
                    dtGrid.Rows[i]["本次入库件数"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDouble(dtGrid.Rows[i]["本次入库件数"]);
                    dtGrid.Rows[i]["检验日期"] = Convert.ToDateTime(dtGrid.Rows[i]["检验日期"]).ToString("yyyy-MM-dd ") + dtGrid.Rows[i]["检验时间"];
                }
            
            }
            base.dsPrint.Tables.Add(dtGrid);
            DataTable dtHead = dtBingHead.Copy();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "条数";
            dtHead.Columns.Add(dc);

            DataRow dr = dtHead.NewRow();
            dr["条数"] = dtGrid.Rows.Count;
            dtHead.Rows.Add(dr);

            dtHead.TableName = "dtHead";
            base.dsPrint.Tables.Add(dtHead);

            if (dtGrid.Rows.Count < 1)
            {
                throw new Exception("没有要打印的单据");
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
            //string sErr = "";
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            //if (oFile.ShowDialog() == DialogResult.OK)
            //{
            //    string sFilePath = oFile.FileName;
            //    string sSQL = "select distinct 设备编号 as MachineNO,设备 as Machine,负责人,状态 as State,备注 as Remark,null as tstamp,null as iSave from [设备档案$]";

            //    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //    for (int i = 0; i < dtExcel.Rows.Count; i++)
            //    {
            //        string sMachineNO = dtExcel.Rows[i]["MachineNO"].ToString().Trim();
            //        DataRow[] dr = dtBingGrid.Select("MachineNO = '" + sMachineNO + "'");
            //        if (dr.Length > 0)
            //        {
            //            dtExcel.Rows[i]["tstamp"] = dr[0]["tstamp"];
            //            sErr = sErr + sMachineNO + "\n";
            //        }
            //    }
            //    gridControl1.DataSource = dtExcel;

            //    if (sErr.Length > 0)
            //    {
            //        sErr = "以下设备编号已经存在，不能重复导入：\n" + sErr;
            //        MsgBox("提示", sErr);
            //    }
            //}
            //else
            //{
            //    throw new Exception("取消导入");
            //}
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
            throw new NotImplementedException();
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

        private void Frm检验合格单列表_Load(object sender, EventArgs e)
        {
            try
            {
                dtm单据日期1.DateTime = DateTime.Today;
                GetLookUp();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sSQL = @" 
select cast(0 as bit) as 选择 
	,a.ID as 检验单ID,a.CCHECKCODE as 检验单号,a.CINSPECTCODE 报检单号,a.CINVCODE as 物料编码,c.cInvName as 物料名称,c.cInvDepCode as 生产部门编码,d.cDepName as 生产部门,a.FQUANTITY as 检验数量,a.FNUM as 检验件数,a.FsumQuantity as 累计入库数量,a.FsumNum as 累计入库件数 
	,isnull(a.FREGQUANTITY,0) + isnull(a.FCONQUANTIY,0) -isnull(a.FsumQuantity,0) as 可入库数量 
   ,case when c.cAssComUnitCode is null then null else isnull(a.FREGNUM,0) + isnull(a.FCONNUM,0) -isnull(a.FsumNum,0) end as 可入库件数 
	,isnull(a.FREGQUANTITY,0) + isnull(a.FCONQUANTIY,0) -isnull(a.FsumQuantity,0) as 本次入库数量
   ,case when c.cAssComUnitCode is null then null else isnull(a.FREGNUM,0) + isnull(a.FCONNUM,0) -isnull(a.FsumNum,0) end as 本次入库件数 
	,a.CPOCODE as 订单号,a.CINSPECTDEPCODE as 部门编号,a.INSPECTID as 报检单主表ID,a.INSPECTAUTOID as 报检单子表ID 
	,a.SOURCEAUTOID as 来源单据子表ID,a.SOURCEID as 来源单据ID,a.SOURCECODE as 到货单号,a.CSOURCE as 来源类型 
	,a.CINSPECTDEPCODE as 业务部门编码,a.DARRIVALDATE as 到货日期 
	,a.CITEMCLASS as 项目大类编码 ,a.CITEMCNAME as 项目大类名称,a.CITEMCODE as 项目编码 ,a.CITEMNAME as 项目名称  
	,a.DDATE as 检验日期,a.CTIME as 检验时间,a.CDEPCODE as 检验部门编码,a.CVENCODE as 供应商编码,a.CWHCODE as 仓库编码,c.CPOSITION as 货位编码,e.cPosName as 货位
   ,cast(null as varchar(50)) as 条形码,c.cAssComUnitCode as 辅助计量编码 
from @u8.QMCHECKVOUCHER a inner join @u8.QMCHECKVOUCHERs b on a.id = b.id inner join @u8.Inventory c on a.cInvCode = c.cInvCode 
    inner join @u8.Department d on d.cDepCode = c.cInvDepCode 
    left join @u8.Position e on e.cPosCode = c.CPOSITION
where  isnull(a.FREGQUANTITY,0) + isnull(a.FCONQUANTIY,0) > isnull(a.FsumQuantity,0) and a.IVERIFYSTATE = 1
order by a.CWHCODE,a.CPOSITION,a.CINVCODE,a.CCHECKCODE 
";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            gridView1.FocusedRowHandle = iFocRow;

            chk全选.Checked = false;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = e.RowHandle;
            if (e.Column == gridCol选择)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridCol选择)))
                {
                    string sBarCode = "5$200$" + gridView1.GetRowCellValue(iRow, gridCol检验单ID).ToString().Trim() + "$" + (FrameBaseFunction.ClsBaseDataInfo.ReturnDouble(gridView1.GetRowCellValue(iRow, gridCol本次入库数量))).ToString().Trim() + "$" + (FrameBaseFunction.ClsBaseDataInfo.ReturnDouble(gridView1.GetRowCellValue(iRow, gridCol本次入库件数))).ToString().Trim();
                    gridView1.SetRowCellValue(iRow, gridCol条形码, sBarCode);
                }
            }

            if (e.Column == gridCol本次入库数量 || e.Column == gridCol本次入库件数)
            {
                gridView1.SetRowCellValue(iRow, gridCol选择, true);
            }

            if (e.Column == gridCol本次入库数量)
            {
                decimal d可入库数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol可入库数量));
                decimal d数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol本次入库数量));

                if (d数量 > d可入库数量)
                {
                    MessageBox.Show("本次入库数量不能超过可入库数量");
                    gridView1.SetRowCellValue(iRow, gridCol本次入库数量, d可入库数量);
                    d数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol本次入库数量));
                }

                if (gridView1.GetRowCellValue(iRow, gridCol辅助计量编码).ToString().Trim() != "" && radio数量.Checked)
                {
                    decimal d可入库件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol可入库件数));
                  
                    decimal d件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(d数量 * d可入库件数 / d可入库数量);
                    gridView1.SetRowCellValue(iRow, gridCol本次入库件数, d件数);
                }
            }
            if (e.Column == gridCol本次入库件数)
            {
                decimal d可入库件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol可入库件数));
                decimal d件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol本次入库件数));

                if (d件数 > d可入库件数)
                {
                    MessageBox.Show("本次入库件数不能超过可入库件数");
                    gridView1.SetRowCellValue(iRow, gridCol本次入库件数, d可入库件数);
                    d件数 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol本次入库件数));
                }

                if ( radio件数.Checked)
                {
                    decimal d可入库数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol可入库数量));

                    decimal d数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(d件数 * d可入库数量 / d可入库件数);
                    gridView1.SetRowCellValue(iRow, gridCol本次入库数量, d数量);
                }
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

        private void GetLookUp()
        {
            sSQL = "select * from @u8.Inventory";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit物料名称.DataSource = dt;

            sSQL = "select UPPER(cWhCode) as cWhCode,UPPER(cWhName) as cWhName from @u8.Warehouse ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit仓库.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit部门.DataSource = dt;

            sSQL = "select cVenCode,cVenName from @u8.Vendor where 1 = 1 order by cVenCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit供应商.DataSource = dt;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    int iRow = 0;
            //    if (gridView1.RowCount < 1)
            //        iRow = 0;
            //    else
            //        iRow = gridView1.FocusedRowHandle;

            //    if (gridView1.GetRowCellValue(iRow, gridColiChk).ToString().Trim() == "")
            //        gridView1.SetRowCellValue(iRow, gridColiChk, "√");
            //    else
            //        gridView1.SetRowCellValue(iRow, gridColiChk, "");
            //}

            //catch { }
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk全选.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, true);
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, false);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型</param>
        private void GetID(string sType, out long iID, out long iIDDetail)
        {
            string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = '" + sType + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0]["iFatherID"]);
                iIDDetail = Convert.ToInt64(dt.Rows[0]["iChildID"]);
            }
        }

        /// <summary>
        /// 返回调拨单号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string sSetTransVouchCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 6; i++)
            {
                if (sCode.Length < 6)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return "TR" + dtm单据日期1.DateTime.ToString("yyMM") + sCode;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            if(iRow <0) 
                return;

            if (gridView1.GetRowCellValue(iRow, gridCol辅助计量编码).ToString().Trim() == "")
                gridCol本次入库件数.OptionsColumn.AllowEdit = false;
            else
                gridCol本次入库件数.OptionsColumn.AllowEdit = true;
        }
    }
}
