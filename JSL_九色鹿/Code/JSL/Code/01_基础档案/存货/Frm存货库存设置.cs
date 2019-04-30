﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 基础设置
{
    public partial class Frm存货库存设置 : 系统服务.FrmBaseInfo
    {
        string tablename = "Inventory";
        string tableid = "cInvCode";
        public Frm存货库存设置()
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
                throw new Exception(sBtnText + " 失败! \n\n原因:\n" + ee.Message);
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
            //DataTable dtState = (DataTable)ItemLookUpEditDept.DataSource;
            //DataTable dtType = (DataTable)ItemLookUpEditSexID.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
            //dc = new DataColumn();
            //dc.ColumnName = "TypeText";
            //dt.Columns.Add(dc);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //    DataRow[] drType = dtType.Select("iID = '" + dt.Rows[i]["Type"].ToString().Trim() + "'");
            //    if (drType.Length > 0)
            //    {
            //        dt.Rows[i]["TypeText"] = drType[0]["Type"];
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
                throw new Exception(ee.Message);
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
            //string sErr = "";
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            //if (oFile.ShowDialog() == DialogResult.OK)
            //{
            //    string sFilePath = oFile.FileName;
            //    string sSQL = "select 员工工号 as PerNO,姓名拼音 as NamePY,姓名 as Name,状态 as State,岗位 as Post,级别 as Levels,类型 as PerType,备注 as Remark,null as tstamp,null as iSave from [生产员工$]";
            //    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //    for (int i = 0; i < dtExcel.Rows.Count; i++)
            //    {
            //        string sPerNO = dtExcel.Rows[i]["PerNO"].ToString().Trim();
            //        DataRow[] dr = dtBingGrid.Select("PerNO = '" + sPerNO + "'");
            //        if (dr.Length > 0)
            //        {
            //            dtExcel.Rows[i]["tstamp"] = dr[0]["tstamp"];
            //            sErr = sErr + sPerNO + "\n";
            //        }
            //        string sName = dtExcel.Rows[i]["Name"].ToString().Trim();
            //        DataRow[] dr2 = dtBingGrid.Select("Name = '" + sName + "'");
            //        if (dr2.Length > 0)
            //        {
            //            dtExcel.Rows[i]["tstamp"] = dr2[0]["tstamp"];
            //            sErr = sErr + sName + "\n";
            //        }
            //    }

            //    gridControl1.DataSource = dtExcel;
                
            //    if (sErr.Length > 0)
            //    {
            //        sErr = "以下工号已经存在，不能重复导入：\n" + sErr;
            //        throw new Exception(sErr);
            //    }
            //}
            //else
            //{
            //    throw new Exception("取消导入");
            //}
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            try
            {

                DevExpress.XtraTreeList.Nodes.TreeListNode tr = treeList1.FocusedNode;
                SetLookUpEdit();
                GetTree();
                treeList1.FocusedNode = tr;
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("刷新窗体失败\n" + ee.Message);
            }
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
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
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
            gridView1.OptionsBehavior.Editable = true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                try
                {
                    string sErr = "";

                    aList = new System.Collections.ArrayList();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.IsRowSelected(i))
                        {
                            string sID = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
                            sSQL = "select count(1) from dbo.SO_SODetails where cInvcode = '" + sID + "' ";
                            long iCou1 = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                            if (iCou1 > 0)
                            {
                                sErr = "行" + (i + 1).ToString() + " 物料 " + sID + " 已经在销售模块使用不能删除\n";
                                continue;
                            }
                            sSQL = "select count(1) from dbo.RdRecords where cInvcode = '" + sID + "' ";
                            long iCou2 = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                            if (iCou2 > 0)
                            {
                                sErr = "行" + (i + 1).ToString() + " 物料 " + sID + " 已经在仓库模块使用不能删除\n";
                                continue;
                            }
                            sSQL = "select count(1) from dbo.PO_Podetails where cInvcode = '" + sID + "' ";
                            long iCou3 = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                            if (iCou3 > 0)
                            {
                                sErr = "行" + (i + 1).ToString() + " 物料 " + sID + " 已经在采购模块使用不能删除\n";
                                continue;
                            }

                            sSQL = "delete " + tablename + " where " + tableid + " = '" + sID + "' ";
                            aList.Add(sSQL);
                        }
                    }
                    if (sErr.Trim().Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    if (aList.Count > 0)
                    {
                        int iCou = clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("删除成功！\n合计执行语句:" + iCou.ToString() + "条");
                   
                        GetGrid();
                     
                        sState = "del";
                    }
                }
                catch (Exception ee)
                {
                    throw new Exception("删除失败！" + ee.Message);
                }
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
                gridView1.FocusedColumn = gridCol存货编码;
            }
            catch { }
            sSQL = "select * from Inventory where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";
            sSQL = "select isnull(max(iID)+1,1) as iID from " + tablename;
            long iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            aList = new System.Collections.ArrayList();

            sSQL = "select * from InventoryM1";
            DataTable dtM1 = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "add" && gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "update")
                {
                    continue;
                }
                string cinv = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
                string m1 = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                string num1 = gridView1.GetRowCellDisplayText(i, gridColiSafeNum1).ToString().Trim();
                string num2 = gridView1.GetRowCellDisplayText(i, gridColiSafeNum2).ToString().Trim();

                if (num1 == "0")
                {
                    num1 = "";
                }
                if (num2 == "0")
                {
                    num2 = "";
                }

                if(gridColiSafeNum1.Visible)
                {
                    if (num1 != "" && num2 == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "最低库存盒数和最高库存盒数必须同时输入\n";
                        continue;
                    }
                    if (num1 == "" && num2 != "")
                    {
                        sErr = sErr + "行" + (i + 1) + "最低库存盒数和最高库存盒数必须同时输入\n";
                        continue;
                    }
                    if (num1 != "")
                    {
                        if (ReturnDecimal(num1) >= ReturnDecimal(num2))
                        {
                            sErr = sErr + "行" + (i + 1) + "最低库存盒数必须小于最高库存盒数\n";
                            continue;
                        }
                    }
                }

                string numQty1 = gridView1.GetRowCellValue(i, gridColiSafeNumQty1).ToString().Trim();
                string numQty2 = gridView1.GetRowCellValue(i, gridColiSafeNumQty2).ToString().Trim();
                if (numQty1 == "0")
                {
                    numQty1 = "";
                }
                if (numQty2 == "0")
                {
                    numQty2 = "";
                }
                if (gridColiSafeNumQty1.Visible)
                {
                    if (numQty1 != "" && numQty2 == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "最低库存数量和最高库存数量必须同时输入\n";
                        continue;
                    }
                    if (numQty1 == "" && numQty2 != "")
                    {
                        sErr = sErr + "行" + (i + 1) + "最低库存数量和最高库存数量必须同时输入\n";
                        continue;
                    }
                    if (numQty1 != "")
                    {
                        if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColiSafeNumQty1).ToString().Trim()) >= ReturnDecimal(gridView1.GetRowCellValue(i, gridColiSafeNumQty2).ToString().Trim()))
                        {
                            sErr = sErr + "行" + (i + 1) + "最低库存数量必须小于最高库存数量\n";
                            continue;
                        }
                    }
                }

                if (num1 == "")
                {
                    num1 = "null";
                }
                if (num2 == "")
                {
                    num2 = "null";
                }
                if (numQty1 == "")
                {
                    numQty1 = "null";
                }
                if (numQty2 == "")
                {
                    numQty2 = "null";
                }
                DataRow[] dw = dtM1.Select("cInvCode='" + cinv + "' and M1='" + m1 + "'");
                if (dw.Length > 0)
                {
                    sSQL = "update InventoryM1 set iSafeNum1=" + num1 + ",iSafeNum2=" + num2 + ",iSafeNumQty1=" + numQty1 + ",iSafeNumQty2=" + numQty2 + " where cInvCode='" + cinv + "' and M1='" + m1 + "'";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "insert into InventoryM1(cInvCode,M1,iSafeNum1,iSafeNum2,iSafeNumQty1,iSafeNumQty2) values('" + cinv + "','" + m1 + "'," + num2 + "," + numQty2 + "," + numQty1 + "," + numQty2 + ")";
                    aList.Add(sSQL);
                }
            }

            if (sErr.Trim().Length > 0)
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            GetGrid();
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

        private void Frm存货库存设置_Load(object sender, EventArgs e)
        {
            try
            {
                //GetInsert();
                SetLookUpEdit();
                GetTree();
                GetGrid();
                
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        //private void GetInsert()
        //{
            
        //    sSQL = "select * from 颜色尺码 ";
        //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //    sSQL = "select * from Inventory";
        //    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
        //    for ( int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        string[] str = dt.Rows[i]["颜色明细"].ToString().Split(',');
        //        string s = "";
        //        for (int j = 0; j < str.Length; j++)
        //        {
        //            if (s != "")
        //            {
        //                s = s + ",";
        //            }
        //            s = s + str[j].Substring(0, 4);
        //        }
        //        DataRow[] dw = dts.Select("cInvCode='" + dt.Rows[i]["商品代码"].ToString() + "'");
        //        if (dw.Length == 0)
        //        {

        //            sSQL = "insert into Inventory(cInvCode,cInvName,cInvClassCode,cGroupCode,M1) values('" + dt.Rows[i]["商品代码"].ToString() + "','" + dt.Rows[i]["商品代码"].ToString() + "','01','01','" + s + "')";
        //        }
        //        else
        //        {
        //            sSQL = "update Inventory set M1='" + s + "' where cInvCode='" + dt.Rows[i]["商品代码"].ToString() + "'";
        //        }
        //        clsSQLCommond.ExecSql(sSQL);
        //    }
           
        //}

        private void GetGrid()
        {
            string sRole = ReturnRoleCode(sUid);
            string sDep = ReturnDepCode(sUid);

            int iFocRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iFocRow = gridView1.FocusedRowHandle;

            string sSQL = @"select cInvCode,cInvName,cInvStd,cGroupCode,cInvClassCode,convert(nvarchar(4000),M1) as M1 into #a from Inventory where 1=1

SELECT distinct a.cInvCode,a.cInvName,a.cInvStd,a.cGroupCode,a.cInvClassCode,b.M1 into #b
FROM (SELECT cInvCode,cInvName,cInvStd,cGroupCode,cInvClassCode,M1=CAST('<v>'+REPLACE(M1,',','</v><v>')+'</v>' AS xml) FROM #a) a
OUTER APPLY (SELECT M1=T.C.value('.','varchar(50)') FROM a.M1.nodes('/v') AS T(C)) b where (ISNULL(b.M1, '') <> '') 

select 'edit' as iSave,a.cInvCode,a.cInvName,a.cInvStd,a.cGroupCode,a.cInvClassCode,a.M1,iSafeNum1, iSafeNum2, iSafeNumQty1, iSafeNumQty2
 from #b a left join InventoryM1 b on a.cInvCode=b.cInvCode and a.M1=b.M1 
";


            if (treeList1.FocusedNode != null && treeList1.FocusedNode.Tag.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", " 1=1 and cInvClassCode = '" + treeList1.FocusedNode.Tag.ToString().Trim() + "' ");
            }
            else
            {
                sSQL = sSQL.Replace("1=1", " 1=-1 ");
            }
            DataTable dtgrid = clsSQLCommond.ExecQuery(sSQL);


            gridControl1.DataSource = dtgrid;
            gridView1.BestFitColumns();

            //gridView1.AddNewRow();

            gridView1.FocusedRowHandle = iFocRow;
            gridView1.OptionsBehavior.Editable = false;

            //SetBtnEnable(true);
            gridView1.BestFitColumns();
            sState = "sel";
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.InventoryClass(ItemLookUpEdit存货分类);
            系统服务.LookUp.ComputationUnitGroup(ItemLookUpEdit计量单位组);
            系统服务.LookUp.ComputationUnitGroupcComunitCode(ItemLookUpEdit主计量); 
            系统服务.LookUp.ComputationUnitGroupcAuxComunitCode(ItemLookUpEdit辅计量);
            系统服务.LookUp.ColorNo(ItemCheckedComboBoxEditM1);
        }

        private void GetTree()
        {
            try
            {
                clsPublic.GetTree(treeList1, "InventoryClass", "cInvClassCode", "存货分类");
                treeList1.ExpandAll();
                treeList1.BestFitColumns();
            }
            catch (Exception ee)
            {
                throw new Exception("获得分类档案失败！  " + ee.Message);
            }
        }
        
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).Trim() == "")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).Trim() == "edit")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "update");
                }
                if (e.Column == gridCol存货编码)
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol存货分类, treeList1.FocusedNode.Tag.ToString().Trim());
                }
                if (e.Column == gridCol存货名称 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol存货编码).ToString().Trim() != "")
                {
                    int iRow = gridView1.FocusedRowHandle;
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                }
                //if (e.Column == gridCol计量单位组 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol计量单位组).Trim() != "")
                //{
                //    DataTable dt = 系统服务.LookUp.ComputationUnitGroup(gridView1.GetRowCellDisplayText(e.RowHandle, gridCol计量单位组).Trim());
                //    if (dt.Rows.Count > 0)
                //    {
                //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol主计量, dt.Rows[0]["cComunitName"].ToString());
                //        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol辅计量, dt.Rows[0]["cAuxComunitName"].ToString());
                //    }
                //}
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            try
            {
                BtnClick("refresh", "提示");

                toolStripMenuBtn.Items["edit"].Enabled = true;
                toolStripMenuBtn.Items["save"].Enabled = false;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                string sUpdate = gridView1.GetRowCellValue(iRow, gridColiSave).ToString().Trim();
                if (sUpdate == "" || sUpdate == "add")
                {
                    gridCol存货编码.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridCol存货编码.OptionsColumn.AllowEdit = false;
                }
            }
            catch { }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void ItemButtonEdit存货分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                系统服务.Frm参照 frm = new 系统服务.Frm参照(7);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    gridView1.SetRowCellValue(iRow, gridCol存货分类, frm.sID);
                    frm.Enabled = true;
                }
            }
            catch { }
        }
    }
}
