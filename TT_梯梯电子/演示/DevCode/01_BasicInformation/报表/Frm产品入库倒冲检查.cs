using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Collections;


namespace BasicInformation
{
    public partial class Frm产品入库倒冲检查 : FrameBaseFunction.Frm列表窗体模板
    {

        public Frm产品入库倒冲检查()
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

            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败:" + ee.Message);
            }
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }
            ArrayList aList = new ArrayList();
            string sSQL = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (FrameBaseFunction.ClsBaseDataInfo.ReturnInt(gridView1.GetRowCellValue(i, "选择")) == 1)
                {
                    sSQL = "update @u8.mom_orderdetail set Define34 = null where modid = " + gridView1.GetRowCellValue(i, "生成订单明细ID").ToString().Trim();
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("打开成功");
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }

            ArrayList aList = new ArrayList();
            string sSQL = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (FrameBaseFunction.ClsBaseDataInfo.ReturnInt(gridView1.GetRowCellValue(i, "选择")) == 1)
                {
                    sSQL = "update @u8.mom_orderdetail set Define34 = 1 where modid = " + gridView1.GetRowCellValue(i, "生成订单明细ID").ToString().Trim();
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭成功");
            }
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm产品入库倒冲检查_Load(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        //DataTable dtBom子件 = new DataTable();
        private void GetGrid()
        {
            try
            {
                string sSQL = @"
select cast(0 as bit) as 选择,a.mocode as 生产订单号,b.SortSeq 行号,b.InvCode as 母件编码,e.cInvName as 母件名称,b.Qty 订单数量,b.QualifiedInQty 入库数量,c.invcode as 子件编码,d.cInvName as 子件名称,c.Qty 应领材料数量,c.IssQty 已领材料数量,b.MoDId as 生成订单明细ID,isnull(b.Define34,0) as 关闭 
from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid inner join @u8.mom_moallocate c on c.modid = b.modid 
	inner join @u8.Inventory d on d.cInvCode = c.InvCode inner join @u8.Inventory e on e.cInvCode = c.InvCode 
where a.moid >=23833 and (b.Status = 3 or b.Status = 4) 
	and cast(isnull(b.QualifiedInQty,0) / b.Qty as decimal(16,2)) > cast(isnull(c.IssQty,0) / c.Qty as decimal(16,2))
    and isnull(b.Qty,0) <> 0 and isnull(c.Qty,0) <> 0
";
                if (radio未处理.Checked)
                {
                    sSQL = sSQL + " and isnull(b.Define34,0) = 0 ";
                }
                sSQL = sSQL + " order by c.AllocateId";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                gridControl1.DataSource = dt;
                gridView1.OptionsBehavior.Editable = true;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].ToString().Trim() == "选择")
                    {
                        gridView1.Columns[i].OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得数据失败\n" + ee.Message);
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


        //private DataTable RetuntBOMDetail(string sInvCode, decimal d使用倍数)
        //{
        //    sSQL = "select BaseQtyN/BaseQtyD/(1-isnull(ParentScrap,0))*(1+isnull(CompScrap,0))*" + d使用倍数 + " as 使用数量,a.bomid,b.ComponentId,b.BaseQtyN,b.BaseQtyD," +
        //             " c.ParentScrap,b.CompScrap,d.InvCode,e.cDefWareHouse,f.Whcode,e.cInvCode,b.OpComponentId,e.cAssComUnitCode,b.ChangeRate,b.AuxBaseQtyN,f.WIPType " +
        //         "from @u8.bom_bom a inner join @u8.bom_opcomponent b on a.bomID = b.bomid inner join @u8.bom_parent c on c.bomid = a.bomid  " +
        //             " inner join @u8.bom_opcomponentopt f on f.OptionsId = b.OptionsId " +
        //             " inner join @u8.bas_part d on d.PartId = b.ComponentId " +
        //             " inner join @u8.Inventory e on e.cInvCode = d.InvCode " +
        //             " inner join @u8.bas_part g on g.PartId = c.ParentId " +
        //         "where g.InvCode = '" + sInvCode + "' and a.[Status] = 3 and b.EffBegDate < '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' and b.EffEndDate > '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "'";
        //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        if (dt.Rows[i]["WIPType"].ToString().Trim() == "4")
        //        {
        //            decimal d使用数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[i]["使用数量"]);
        //            DataTable dtTemp = RetuntBOMDetail(dt.Rows[i]["InvCode"].ToString().Trim(), d使用数量);
        //        }
        //        else
        //        {
        //            DataRow dr = dtBom子件.NewRow();
        //            for (int j = 0; j < dt.Columns.Count; j++)
        //            {
        //                dr[j] = dt.Rows[i][j];
        //            }
        //            dtBom子件.Rows.Add(dr);
        //        }
        //    }

        //    return dt;
        //}
    }
}
