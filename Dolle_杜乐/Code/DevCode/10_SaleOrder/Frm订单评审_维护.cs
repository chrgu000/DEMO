using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using FrameBaseFunction;
using System.Data.SqlClient;
using System.Collections;

namespace SaleOrder
{
    public partial class Frm订单评审_维护 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm订单评审_维护()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView评审维护.OptionsMenu.EnableColumnMenu = false;
            gridView评审维护.OptionsMenu.EnableFooterMenu = false;
            gridView评审维护.OptionsMenu.EnableGroupPanelMenu = false;
            gridView评审维护.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView评审维护.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView评审维护.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView评审维护.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView评审维护.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView评审维护.OptionsBehavior.FocusLeaveOnTab = true;
            gridView评审维护.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl评审维护.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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
                    case "add":
                        btnAdd();
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
                        btnLock(false);
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

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        DataTable dt评审 = new DataTable();

        private void btnAdd()
        {
           
        }

        #region 按钮模板

        ///// <summary>
        ///// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
        //    DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "StateText";
        //    dt.Columns.Add(dc);
           
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
        //        if (drState.Length > 0)
        //        {
        //            dt.Rows[i]["StateText"] = drState[0]["State"];
        //        }

        //    }

            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
                gridView评审维护.FocusedRowHandle -= 1;
                gridView评审维护.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl评审维护.DataSource).Copy());
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
                    gridView评审维护.ExportToXls(sF.FileName);
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

                gridView评审维护.OptionsMenu.EnableColumnMenu = true;
                gridView评审维护.OptionsMenu.EnableFooterMenu = true;
                gridView评审维护.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView评审维护.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView评审维护.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView评审维护.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView评审维护.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView评审维护.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView评审维护.OptionsMenu.EnableColumnMenu = false;
                gridView评审维护.OptionsMenu.EnableFooterMenu = false;
                gridView评审维护.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView评审维护.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView评审维护.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView评审维护.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView评审维护.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView评审维护.OptionsCustomization.AllowColumnMoving = false;


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                    gridControl评审维护.MainView.SaveLayoutToXml(sLayoutGridPath);
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

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm订单评审_维护SEL fSel = new Frm订单评审_维护SEL();
            fSel.ShowDialog();
            if (fSel.DialogResult != DialogResult.OK)
            {
                throw new Exception("取消查询");
            }
            GetGrid(fSel.i销售订单ID);
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = 0;
                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage > 0)
                {
                    iPage -= 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage < dtSel.Rows.Count - 1)
                {
                    iPage += 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);

                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch { }
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = dtSel.Rows.Count - 1;

                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch { }
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock(bool bChooseAll)
        {
            try
            {
                try
                {
                    gridView评审维护.FocusedRowHandle -= 1;
                    gridView评审维护.FocusedRowHandle += 1;
                }
                catch { }

                //FrameBaseFunction.ClsSqlHelper DBSQL = new ClsSqlHelper();

                string sErr = "";
                int iCount = 0;

                DateTime dLogDate = BaseFunction.ReturnDate(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                    DataTable dt订单评审运算1 = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    if (dt订单评审运算1 == null || dt订单评审运算1.Rows.Count < 1)
                    {
                        throw new Exception("请选择需要保存的单据");
                    }
                    if (dt订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "")
                    {
                        throw new Exception("已经审核，不能维护");
                    }
                    if (dt订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
                    {
                        throw new Exception("已经关闭，不能维护");
                    }

                    for (int i = 0; i < gridView评审维护.RowCount; i++)
                    {
                        if (!bChooseAll)
                        {
                            if (gridView评审维护.GetRowCellValue(i, gridCol选择).ToString().Trim() == "√")
                            {

                                sSQL = "update 订单评审运算3 set 锁定人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',锁定日期 = getdate() where iID = " + gridView评审维护.GetRowCellValue(i, gridColiID) + " ";
                                iCount += ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }
                        else
                        {
                            sSQL = "update 订单评审运算3 set 锁定人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',锁定日期 = getdate() where iID = " + gridView评审维护.GetRowCellValue(i, gridColiID) + " ";
                            iCount += ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("锁定成功！\n合计执行语句:" + iCount + "条");
                        SetColEdit(false);

                        GetGrid(Convert.ToInt64(txt销售订单ID.Text));

                        sState = "lock";
                    }
                    else
                    {
                        throw new Exception("请选择需要锁定的数据");
                    }

                }
                catch (Exception ee)
                {
                    tran.Rollback();

                    throw new Exception(ee.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    tran = null;
                }

                #region del

                /*
                sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
                if (dt订单评审运算1 == null || dt订单评审运算1.Rows.Count < 1)
                {
                    throw new Exception("请选择需要保存的单据");
                }
                if (dt订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "")
                {
                    throw new Exception("已经审核，不能维护");
                }
                if (dt订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
                {
                    throw new Exception("已经关闭，不能维护");
                }

                aList = new System.Collections.ArrayList();
                for (int i = 0; i < gridView评审维护.RowCount; i++)
                {
                    if (gridView评审维护.GetRowCellValue(i, gridCol选择).ToString().Trim() == "√")
                    {

                        sSQL = "update 订单评审运算3 set 锁定人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',锁定日期 = getdate() where iID = " + gridView评审维护.GetRowCellValue(i, gridColiID) + " ";
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("锁定成功！\n合计执行语句:" + iCou + "条");
                    SetColEdit(false);

                    GetGrid(Convert.ToInt64(txt销售订单ID.Text));

                    sState = "lock";
                }
                else
                {
                    throw new Exception("请选择需要锁定的数据");
                }
                 * */
                #endregion
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {
            try
            {
                try
                {
                    gridView评审维护.FocusedRowHandle -= 1;
                    gridView评审维护.FocusedRowHandle += 1;
                }
                catch { }

                sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
                if (dt订单评审运算1 == null || dt订单评审运算1.Rows.Count < 1)
                {
                    throw new Exception("请选择需要保存的单据");
                }
                if (dt订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "")
                {
                    throw new Exception("已经审核，不能维护");
                }
                if (dt订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
                {
                    throw new Exception("已经关闭，不能维护");
                }


                aList = new System.Collections.ArrayList();
                for (int i = 0; i < gridView评审维护.RowCount; i++)
                {
                    if (gridView评审维护.GetRowCellValue(i, gridCol选择).ToString().Trim() == "√")
                    {

                        sSQL = "update 订单评审运算3 set 锁定人 = null,锁定日期 = null where iID = " + gridView评审维护.GetRowCellValue(i, gridColiID) + " ";
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("解锁成功！\n合计执行语句:" + iCou + "条");
                    SetColEdit(false);

                    GetGrid(Convert.ToInt64(txt销售订单ID.Text));

                    sState = "unlock";
                }
                else
                {
                    throw new Exception("请选择需要解锁的数据");
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {
            gridView评审维护.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView评审维护.RowCount - 1; i >= 0 ; i--)
            {
                if (gridView评审维护.IsRowSelected(i))
                {
                    gridView评审维护.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            try
            {
                btnLock(true);

                sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
                if (dt订单评审运算1 == null || dt订单评审运算1.Rows.Count < 1)
                {
                    throw new Exception("请选择需要保存的单据");
                }
                if (dt订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "")
                {
                    throw new Exception("已经审核，不能维护");
                }
                if (dt订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
                {
                    throw new Exception("已经关闭，不能维护");
                }
                if (dt订单评审运算1.Rows[0]["下达生产人"].ToString().Trim() != "")
                {
                    throw new Exception("已经下达生产，不能维护");
                }
                if (dt订单评审运算1.Rows[0]["下达委外人"].ToString().Trim() != "")
                {
                    throw new Exception("已经下达委外，不能维护");
                }

                dt评审 = (DataTable)gridControl评审维护.DataSource;

                Get实时数据();

                sState = "edit";

                for (int i = 0; i < gridView评审维护.RowCount; i++)
                {
                    gridView评审维护.SetRowCellValue(i, gridCol选择, "√");
                }


                SetColEdit(true);
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
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
            try
            {
                try
                {
                    gridView评审维护.FocusedRowHandle -= 1;
                    gridView评审维护.FocusedRowHandle += 1;
                }
                catch { }

                if (!radio手工.Checked)
                {
                    throw new Exception("为防止数量重新计算，请在手工状态保存数据");
                }

                string sErr = "";
                sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
                if (dt订单评审运算1 == null || dt订单评审运算1.Rows.Count < 1)
                {
                    throw new Exception("请选择需要保存的单据");
                }
                if (dt订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "")
                {
                    throw new Exception("已经审核");
                }
                if (dt订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
                {
                    throw new Exception("已经关闭，不能保存");
                }
                //for (int i = 0; i < gridView评审维护.RowCount; i++)
                //{
                //    sSQL = "select isnull(锁定人,'') as 锁定人 from 订单评审运算3 where iID = " + gridView评审维护.GetRowCellValue(i, gridColiID).ToString();
                //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                //    if (dt == null || dt.Rows.Count < 1 || dt.Rows[0]["锁定人"].ToString().Trim() == "")
                //    {
                //        sErr = sErr + "行 " + (i + 1) + "没有锁定\n";
                //    }
                //}
                

                aList = new System.Collections.ArrayList();

                for (int i = 0; i < gridView评审维护.RowCount; i++)
                {
                    if (gridView评审维护.GetRowCellValue(i, gridCol选择).ToString().Trim() == "√")
                    {
                        if (gridView评审维护.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "采购")
                        {
                            sSQL = "update 订单评审运算3 set 本次下单数量 = " + gridView评审维护.GetRowCellValue(i, gridCol本次下单数量) + ",置办周期 = " + gridView评审维护.GetRowCellValue(i, gridCol置办周期) + ",开始日期  = '" + gridView评审维护.GetRowCellValue(i, gridCol开始日期) + "',完成日期 = '" + gridView评审维护.GetRowCellValue(i, gridCol完成日期) + "',质检周期 =" + FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(i, gridCol质检周期)) + " where iID = " + gridView评审维护.GetRowCellValue(i, gridColiID) + " ";
                            aList.Add(sSQL);
                        }
                        if (gridView评审维护.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "委外")
                        {
                            sSQL = "update 订单评审运算3 set 本次下单数量 = " + gridView评审维护.GetRowCellValue(i, gridCol本次下单数量) + ",置办周期 = " + gridView评审维护.GetRowCellValue(i, gridCol置办周期) + ",开始日期  = '" + gridView评审维护.GetRowCellValue(i, gridCol开始日期) + "',完成日期 = '" + gridView评审维护.GetRowCellValue(i, gridCol完成日期) + "',质检周期 =" + FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(i, gridCol质检周期)) + " where iID = " + gridView评审维护.GetRowCellValue(i, gridColiID) + " ";
                            aList.Add(sSQL);
                        }
                        if (gridView评审维护.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "自制")
                        {
                            sSQL = "update 订单评审运算3 set 本次下单数量 = " + gridView评审维护.GetRowCellValue(i, gridCol本次下单数量) + ",置办周期 = " + gridView评审维护.GetRowCellValue(i, gridCol置办周期) + ",生产日工时 = " + gridView评审维护.GetRowCellValue(i, gridCol生产日工时) + ",开始日期 = '" + gridView评审维护.GetRowCellValue(i, gridCol开始日期) + "',完成日期='" + gridView评审维护.GetRowCellValue(i, gridCol完成日期) + "' where iID = " + gridView评审维护.GetRowCellValue(i, gridColiID) + " ";
                            aList.Add(sSQL);
                        }
                    }
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                    SetColEdit(false);

                    sState = "save";
                }
                else
                {
                    throw new Exception("请选择需要保存的数据");
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            SetColEdit(false);

            if (txt销售订单ID.Text.Trim() != "")
            {
                GetGrid(Convert.ToInt64(txt销售订单ID.Text));
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            try
            {
                try
                {
                    gridView评审维护.FocusedRowHandle -= 1;
                    gridView评审维护.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";

                aList = new System.Collections.ArrayList();


                sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
                if (dt订单评审运算1 == null || dt订单评审运算1.Rows.Count < 1)
                {
                    throw new Exception("请选择需要审核的单据");
                }
                if (dt订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "")
                {
                    throw new Exception("已经审核");
                }
                if (dt订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
                {
                    throw new Exception("已经关闭，不能审核");
                }

                sSQL = " select count(1) from 订单评审运算3 where  isnull(锁定人,'') = '' and isnull(本次下单数量,0) <> 0 and 销售订单ID = " + txt销售订单ID.Text.Trim() + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                int iCou = ReturnObjectToInt(clsSQLCommond.ExecGetScalar(sSQL));


                //for (int i = 0; i < gridView评审维护.RowCount; i++)
                //{
                //    sSQL = "select isnull(锁定人,'') as 锁定人 from 订单评审运算3 where iID = " + gridView评审维护.GetRowCellValue(i, gridColiID).ToString() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                //    if (dt == null || dt.Rows.Count < 1 || dt.Rows[0]["锁定人"].ToString().Trim() == "")
                //    {
                //        sErr = sErr + "行 " + (i + 1) + "没有锁定\n";
                //    }
                //}

                if (iCou > 0)
                {
                    MsgBox("提示", "存在未锁定单据，请核查");
                }
                else
                {
                    sSQL = "update 订单评审运算1 set 维护审核人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,维护审核日期 = getdate() where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                    clsSQLCommond.ExecSql(sSQL);

                    GetGrid(Convert.ToInt64(txt销售订单ID.Text));
                    MessageBox.Show("审核成功");
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            try
            {
                try
                {
                    gridView评审维护.FocusedRowHandle -= 1;
                    gridView评审维护.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";

                aList = new System.Collections.ArrayList();

                sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
                if (dt订单评审运算1 == null || dt订单评审运算1.Rows.Count < 1)
                {
                    throw new Exception("请选择需要弃审的单据");
                }
                if(dt订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() == "")
                {
                    throw new Exception("尚未审核，不能弃审");
                }
                if(dt订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
                {
                    throw new Exception("已经关闭，不能弃审");
                }
                if (dt订单评审运算1.Rows[0]["下达生产人"].ToString().Trim() != "")
                {
                    throw new Exception("已经下达生产，不能弃审");
                }
                if (dt订单评审运算1.Rows[0]["下达委外人"].ToString().Trim() != "")
                {
                    throw new Exception("已经下达委外，不能弃审");
                }

                if (sErr.Trim() != "")
                {
                    throw new Exception(sErr);
                }
                else
                {
                    sSQL = "update 订单评审运算1 set 维护审核人 = null,维护审核日期 = null where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                    clsSQLCommond.ExecSql(sSQL);

                    GetGrid(Convert.ToInt64(txt销售订单ID.Text));
                    MessageBox.Show("弃审成功");
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
          
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
          
        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm订单评审_维护_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                GetSelList();

                btn回签日期核查.Enabled = true;
                btn15天核查.Enabled = true;
                //btnLast();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView销售订单列表_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView评审计算_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
            string sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow drInv = dt.NewRow();
            drInv["cInvCode"] = "--";
            dt.Rows.Add(drInv);
            ItemLookUpEdit1存货编码.DataSource = dt;
            ItemLookUpEdit1存货名称.DataSource = dt;
            ItemLookUpEdit1规格型号.DataSource = dt;

            ItemLookUpEdit物料编码.DataSource = dt;
            ItemLookUpEdit物料名称.DataSource = dt;
            ItemLookUpEdit规格型号.DataSource = dt;

            sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit客户.Properties.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["iID"] = "采购";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "委外";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "自制";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "全部";
            dt.Rows.Add(dr);
            ItemLookUpEdit子件属性.DataSource = dt;
            lookUpEdit属性.Properties.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit部门编码.DataSource = dt;
            ItemLookUpEdit部门名称.DataSource = dt;

            sSQL = "select cWhCode,cWhName from @u8.Warehouse  order by cWhCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit仓库编号.DataSource = dt;
            ItemLookUpEdit仓库名称.DataSource = dt;
        }

        private void gridView评审维护_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                int i1 = ReturnObjectToInt(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol销售订单行号));
                int i2 = i1%2;

                if (i2 == 0)
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.AntiqueWhite;
                }
            }
            catch
            { }
            try
            {
                DateTime d1 = Convert.ToDateTime(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol回签日期2));
                DateTime d2 = Convert.ToDateTime(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol完成日期));
                if (d1 != d2)
                    e.Appearance.BackColor = Color.Tomato;
            }
            catch { }
            try
            {
                if (gridView评审维护.GetRowCellValue(e.RowHandle, gridCol回签日期2).ToString().Trim() == "" )
                    e.Appearance.BackColor = Color.Yellow;
            }
            catch { }

        }

        private void Get实时数据()
        {
            for (int i = 0; i < gridView评审维护.RowCount; i++)
            {
                string sInvCode = gridView评审维护.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                string sSoCode = txt销售订单号.Text.Trim();
                string sSoID = txt销售订单ID.Text.Trim();
                string sWhCode = gridView评审维护.GetRowCellValue(i, gridCol仓库代号).ToString().Trim();
                string s子件属性 = gridView评审维护.GetRowCellValue(i, gridCol子件属性).ToString().Trim();

                DataTable dt = new DataTable();
                try
                {
                    sSQL = "select isnull(cInvDefine3,0.00) as 最小批量,isnull(cInvDefine13,0.00) as 调整数量 from @u8.Inventory where cInvCode = '" + sInvCode + "'";
                    dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().Trim() != "")
                    {
                        decimal d1 = GetQTY(dt.Rows[0][0]);
                        if (d1 < 0)
                            d1 = 0;
                        gridView评审维护.SetRowCellValue(i, gridCol最小批量, d1);
                        gridView评审维护.SetRowCellValue(i, gridCol调整数量, GetQTY(dt.Rows[0]["调整数量"]));
                    }
                }
                catch 
                {
                
                }

                decimal d最小批量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(i, gridCol最小批量));

                try
                {
                    Frm物料供需分析 fSEL = new Frm物料供需分析();
                    int iType = 1;

                    dt = fSEL.Get物料供需分析汇总表(sInvCode, sSoCode, iType);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        gridView评审维护.SetRowCellValue(i, gridCol仓库现存量, dt.Rows[0]["现存量"]);
                        gridView评审维护.SetRowCellValue(i, gridCol待入库量, dt.Rows[0]["待入库"]);
                        gridView评审维护.SetRowCellValue(i, gridCol待出库量, dt.Rows[0]["待出库"]);
                    }
                }
                catch
                { 
                
                }
            }
        }
        private decimal GetQTY(object d)
        {
            try
            {
                return FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(d);
            }
            catch
            {
                return 0;
            }
        }

        private decimal GetQTYRet0(object d)
        {
            try
            {
                return FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(d);
            }
            catch
            {
                return 0;
            }
        }

        private void SetColEdit(bool b)
        {
            gridCol本次下单数量.OptionsColumn.AllowEdit = b;
            gridCol开始日期.OptionsColumn.AllowEdit = b;
            gridCol完成日期.OptionsColumn.AllowEdit = b;
            gridCol置办周期.OptionsColumn.AllowEdit = b;
            gridCol质检周期.OptionsColumn.AllowEdit = b;
            gridCol生产日工时.OptionsColumn.AllowEdit = b;
            gridCol生产工时.OptionsColumn.AllowEdit = b;

            radio逆排.Enabled = b;
            radio顺排.Enabled = b;
            radio手工.Enabled = b;

            txt存货编码.Enabled = b;
            btnChange.Enabled = b;

            chk全选.Enabled = true;

            txt存货编码.Enabled = b;
            chk开始日期.Enabled = b;
            chk完成日期.Enabled = b;
            dtm开始日期.Enabled = false;
            dtm完成日期.Enabled = false;
            btn选择.Enabled = b;
        }

        private void gridView评审计算_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (radio手工.Checked && sState == "edit")
            {
                string s子件编码 = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol子件编码).ToString().Trim();
                string s母子 = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol母子对应).ToString().Trim();
                decimal d本次下单 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol本次下单数量));
                int i行号 = ReturnObjectToInt(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol销售订单行号));
                InitEditSG(s子件编码, s母子, d本次下单, i行号);

                if (s子件编码.Substring(0, 2).ToLower() == "yz" && e.Column == gridCol本次下单数量)
                {
                    string s母件编码 = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol母件编码).ToString().Trim();

                    string sSQL = "select count(1) as iCou from dbo._LookUpDate where iType = 19 and isnull(bClose,0) = 1 and iID = '" + s子件编码 + "' and iText = '" + s母件编码 + "'";
                    int iCou = ReturnObjectToInt(clsSQLCommond.ExecGetScalar(sSQL));
                    if (iCou == 0)
                    {
                        string s销售订单子表ID = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol销售订单行号).ToString().Trim();
                        decimal d使用数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol使用数量));

                        for (int i = 0; i < gridView评审维护.RowCount; i++)
                        {
                            string s子件编码2 = gridView评审维护.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                            string s销售订单子表ID2 = gridView评审维护.GetRowCellValue(i, gridCol销售订单行号).ToString().Trim();
                            decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol本次下单数量));

                            #region 对比母子对应关系一致的才属于同一BOM分支，由于虚拟件的关系，假设有三层虚拟件需要去除

                            string s母子2 = gridView评审维护.GetRowCellValue(i, gridCol母子对应).ToString().Trim();

                            if (s销售订单子表ID2 == s销售订单子表ID && s母件编码 == s子件编码2)
                            {
                                int iLast = s母子.LastIndexOf("→");
                                if (iLast > 0)
                                {
                                    s母子 = s母子.Substring(0, iLast);
                                }
                                while (s母子 != s母子2 && iLast > 0)
                                {
                                    iLast = s母子.LastIndexOf("→");
                                    if (iLast > 0)
                                    {
                                        s母子 = s母子.Substring(0, iLast);
                                    }
                                }
                                if (s母子 == s母子2)
                                {
                                    gridView评审维护.SetRowCellValue(i, gridCol本次下单数量, decimal.Round(d本次下单数量 / d使用数量, 6));

                                }
                                s母子 = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol母子对应).ToString().Trim();
                            }
                            #endregion
                        }
                    }
                }
            }

            if (radio逆排.Checked && sState == "edit")
            {
                gridControl评审维护.Refresh();
                if (e.Column == gridCol完成日期 || e.Column == gridCol本次下单数量 || e.Column == gridCol置办周期 || e.Column == gridCol生产日工时 || e.Column == gridCol质检周期)
                {
                    string s子件编码 = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol子件编码).ToString().Trim();
                    string s母子 = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol母子对应).ToString().Trim();
                    decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol本次下单数量));
                    DateTime d完成日期 = Convert.ToDateTime(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol完成日期));
                    int i置办周期 = 0;
                    int i周期 = 0;
                    if (gridView评审维护.GetRowCellValue(e.RowHandle, gridCol子件属性).ToString().Trim() == "自制" && e.Column != gridCol置办周期)
                    {
                        i置办周期 = ReturnObjectToInt(Math.Ceiling(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol单件生产工时), 10) * d本次下单数量 / FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol生产日工时))));
                    }
                    else
                    {
                        i置办周期 = ReturnObjectToInt(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol置办周期));
                    }
                    if (gridView评审维护.GetRowCellValue(e.RowHandle, gridCol质检周期).ToString().Trim() != "")
                    {
                        i周期 = i置办周期 + ReturnObjectToInt(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol质检周期));
                    }
                    else
                    {
                        i周期 = i置办周期;
                    }
                    DateTime d开始日期 = d完成日期.AddDays(-1 * i周期);
                    gridView评审维护.SetRowCellValue(e.RowHandle, gridCol开始日期, d开始日期);

                    int i行号 = ReturnObjectToInt(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol销售订单行号));

                    InitEditN(s子件编码, s母子,d本次下单数量, d开始日期, i行号);

                    gridControl评审维护.DataSource = dt评审;
                }
            }
            if (radio顺排.Checked && sState == "edit")
            {
                if (e.Column == gridCol开始日期 || e.Column == gridCol置办周期 || e.Column == gridCol生产日工时 ||e.Column == gridCol质检周期)
                {
                    string s母件编码 = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol母件编码).ToString().Trim();
                    decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol本次下单数量));
                    DateTime d开始日期 = Convert.ToDateTime(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol开始日期));
                    int i行号 = ReturnObjectToInt(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol销售订单行号));
                    int i置办周期 = 0;
                    int i周期 = 0;
                    if (gridView评审维护.GetRowCellValue(e.RowHandle, gridCol子件属性).ToString().Trim() == "自制" && e.Column != gridCol置办周期)
                    {
                        decimal dTemp = ReturnObjectToDecimal(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol单件生产工时), 10);
                        dTemp = dTemp * d本次下单数量 / ReturnObjectToDecimal(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol生产日工时), 10);
                        i置办周期 = ReturnObjectToInt(Math.Ceiling(dTemp));
                    }
                    else
                    {
                        i置办周期 =ReturnObjectToInt(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol置办周期));
                    }
                    if (gridView评审维护.GetRowCellValue(e.RowHandle, gridCol质检周期).ToString().Trim() != "")
                    {
                        i周期 = i置办周期 + ReturnObjectToInt(gridView评审维护.GetRowCellValue(e.RowHandle, gridCol质检周期));
                    }
                    else
                    {
                        i周期 = i置办周期;
                    }
                    DateTime d完成日期 = d开始日期.AddDays(i置办周期);
                    gridView评审维护.SetRowCellValue(e.RowHandle, gridCol完成日期, d完成日期);
                    string s母子 = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol母子对应).ToString().Trim();


                    string s销售订单子表ID = gridView评审维护.GetRowCellValue(e.RowHandle, gridCol销售订单行号).ToString().Trim();

                    for (int i = 0; i < gridView评审维护.RowCount; i++)
                    {
                        string s子件编码2 = gridView评审维护.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                        string s销售订单子表ID2 = gridView评审维护.GetRowCellValue(i, gridCol销售订单行号).ToString().Trim();
                        string s母子2 = gridView评审维护.GetRowCellValue(i, gridCol母子对应).ToString().Trim();

                        if (s销售订单子表ID2 == s销售订单子表ID && s母件编码 == s子件编码2)
                        {
                            int iLast = s母子.LastIndexOf("→");
                            if (iLast > 0)
                            {
                                s母子 = s母子.Substring(0, iLast);
                            }
                            while (s母子 != s母子2 && iLast > 0 )
                            {
                                iLast = s母子.LastIndexOf("→");
                                if (iLast > 0)
                                {
                                    s母子 = s母子.Substring(0, iLast);
                                }
                            }
                            if (s母子 == s母子2)
                            {
                                InitEditS(s母件编码, s母子, d开始日期.AddDays(i周期).AddDays(1), i行号);
                                break;
                            }
                        }

                    }
                    if (s母子 == "--")
                        InitEditS(s母件编码, s母子, d开始日期.AddDays(i周期).AddDays(1), i行号);

                    gridControl评审维护.DataSource = dt评审;
                }
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (radio顺排.Checked)
            {
                gridCol开始日期.OptionsColumn.AllowEdit = true;
                gridCol完成日期.OptionsColumn.AllowEdit = false;
                gridCol本次下单数量.OptionsColumn.AllowEdit = true;
            }
            if (radio逆排.Checked)
            {
                gridCol开始日期.OptionsColumn.AllowEdit = false;
                gridCol完成日期.OptionsColumn.AllowEdit = true;
                gridCol本次下单数量.OptionsColumn.AllowEdit = true;
            }
            if(radio手工.Checked)
            {
                gridCol开始日期.OptionsColumn.AllowEdit = true;
                gridCol完成日期.OptionsColumn.AllowEdit = true;
                gridCol本次下单数量.OptionsColumn.AllowEdit = true;
            }
        }

        /// <summary>
        /// 编辑状态逆排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="dQty">母件下单数量</param>
        /// <param name="dDate1">计划结束日期</param>
        /// <param name="i行号">销售订单行号</param>
        private void InitEditN(string sInvCode, string sInvCode2, decimal dQty, DateTime dDate1, int i行号)
        {
            DataRow[] drList = dt评审.Select(" 母件编码 = '" + sInvCode + "' and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");

            foreach (DataRow dr in drList)
            {
                decimal d当前物料累计下单 = 0;
                decimal d当前物料累计需求 = 0;

                for (int i = 0; i < dt评审.Rows.Count; i++)
                {
                    string s本次下单 = dt评审.Rows[i]["本次下单数量"].ToString().Trim();
                    if (s本次下单.Length == 0)
                        continue;
                    string s子件编码 = dt评审.Rows[i]["子件编码"].ToString().Trim();
                    if (s子件编码 == dr["子件编码"].ToString().Trim())
                    {
                        decimal d1 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt评审.Rows[i]["本次下单数量"]);
                        d当前物料累计下单 = d当前物料累计下单 + d1;
                        decimal d2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt评审.Rows[i]["需求数量"]);
                        d当前物料累计需求 = d当前物料累计需求 + d2;
                    }
                }

                decimal d当前需求 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["需求数量"]);
                decimal d当前下单 = GetQTYRet0(dr["本次下单数量"]);
                d当前物料累计需求 = d当前物料累计需求 - d当前需求;
                d当前物料累计下单 = d当前物料累计下单 - d当前下单;

                decimal d现存量 = GetQTYRet0(dr["仓库现存量"]);
                if (d现存量 <= FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(0.000001))
                    d现存量 = 0;

                decimal d调整数量 = GetQTYRet0(dr["调整数量"]);
                decimal d待入库 = GetQTYRet0(dr["待入库量"]);
                decimal d待出库 = GetQTYRet0(dr["待出库量"]);
                decimal d最小批量 = GetQTYRet0(dr["最小批量"]);
                decimal d当前行可用量 = d现存量 - d调整数量 + d待入库 - d待出库 - (d当前物料累计需求 - d当前物料累计下单);
                decimal d本次下单数量 = 0;

                decimal d需求数量 = decimal.Round(dQty * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["使用数量"]), 6);
                dr["需求数量"] = d需求数量;
                if (d需求数量 == 0)
                {
                    d本次下单数量 = 0;
                }
                else
                {
                    if (d需求数量 > d当前行可用量)
                    {
                        d本次下单数量 = d需求数量 - d当前行可用量;
                        if (d当前物料累计下单 < d最小批量)
                        {
                            d本次下单数量 = d最小批量;
                        }
                    }
                    else
                        d本次下单数量 = 0;
                }
                dr["本次下单数量"] = d本次下单数量;

                int i置办周期 = 0;
                if (dr["子件属性"].ToString().Trim() == "自制")
                {
                    i置办周期 = ReturnObjectToInt(Math.Ceiling(Convert.ToDouble(dr["单件生产工时"]) * (Convert.ToDouble(dr["本次下单数量"])) / Convert.ToDouble(dr["生产日工时"])));
                }
                else
                {
                    i置办周期 = ReturnObjectToInt(dr["置办周期"]);
                }
                int i周期 = 0;
                int i质检周期 = 0;
                if (dr["质检周期"].ToString().Trim() != "")
                {
                    i质检周期 = ReturnObjectToInt(dr["质检周期"]);
                    i周期 = i置办周期 + i质检周期;
                }
                else
                {
                    i周期 = i置办周期;
                }
                dr["完成日期"] = dDate1.AddDays(-1 * i质检周期).AddDays(-1);
                dr["开始日期"] = dDate1.AddDays(-1 * i周期).AddDays(-1);

                InitEditN(dr["子件编码"].ToString().Trim(), dr["母子对应"].ToString().Trim(), decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["本次下单数量"]), 6), Convert.ToDateTime(dr["开始日期"]), i行号);
            }
        }

        /// <summary>
        /// 编辑状态顺排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">子件编码</param>
        /// <param name="dQty">本次下单数量</param>
        /// <param name="dDate1">计划开始日期</param>
        private void InitEditS(string sInvCode, string sInvCode2, DateTime dDate1, int i行号)
        {
            DataRow[] drList = dt评审.Select(" 子件编码 = '" + sInvCode + "'  and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");
            while (drList.Length == 0)
            {
                int iLast = sInvCode2.LastIndexOf("→");
                if (iLast > 0)
                {
                    sInvCode2 = sInvCode2.Substring(0, iLast);
                    drList = dt评审.Select(" 子件编码 = '" + sInvCode + "'  and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");
                }
                else
                {
                    break;
                }
               
            }

            //日期减少时，确保使用同阶最大日期来推算，避免产品提前至其子件之前
            DataRow[] drList2 = dt评审.Select(" 母件编码 = '" + sInvCode + "'  and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");
            foreach (DataRow dr in drList2)
            {
                DateTime d1 = FrameBaseFunction.ClsBaseDataInfo.ReturnDate(dr["完成日期"]).AddDays(1);
                int i质检周期 = FrameBaseFunction.ClsBaseDataInfo.ReturnInt(dr["质检周期"]);      //作为母件的开工时间，必须考虑子件的质检周期
                d1 = d1.AddDays(i质检周期);

                if (dDate1 < d1)
                    dDate1 = d1;
            }

            foreach (DataRow dr in drList)
            {
                int i置办周期 = 0;
                if (dr["子件属性"].ToString().Trim() == "自制")
                {
                    i置办周期 = ReturnObjectToInt(Math.Ceiling(ReturnObjectToDecimal(dr["单件生产工时"], 10) * ReturnObjectToDecimal(dr["本次下单数量"], 10) / ReturnObjectToDecimal(dr["生产日工时"], 10)));
                }
                else
                {
                    i置办周期 = ReturnObjectToInt(dr["置办周期"]);
                }
                int i周期 = 0;
                int i质检周期 = 0;
                if (dr["质检周期"].ToString().Trim() != "")
                {
                    i质检周期 = ReturnObjectToInt(dr["质检周期"]);
                    i周期 = i置办周期 + i质检周期;
                }
                else
                {
                    i周期 = i置办周期;
                }

                dr["开始日期"] = dDate1;
                dr["完成日期"] = dDate1.AddDays(i置办周期);

                string s母子 = dr["母子对应"].ToString().Trim();
                int iLast = s母子.LastIndexOf("→");
                if (iLast > 0)
                {
                    s母子 = s母子.Substring(0, iLast);
                    InitEditS(dr["母件编码"].ToString().Trim(), s母子, Convert.ToDateTime(Convert.ToDateTime(dr["完成日期"]).ToString("yyyy-MM-dd")).AddDays(1).AddDays(i质检周期), i行号);
                }
            }
        }

        private void GetGrid(long i销售订单ID)
        {
            string sSQL = "select * from dbo.订单评审运算1 where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from dbo.订单评审运算2 where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " order by iID";
            DataTable dt订单评审运算2 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select *,'' as 选择,cast(null as decimal(18,6)) as 最小批量,cast(null as decimal(18,6)) as 调整数量,cast(null as decimal(18,6)) as 仓库现存量,cast(null as decimal(18,6)) as 待入库量,cast(null as decimal(18,6)) as 待出库量 " +
                    "from dbo.订单评审运算3 where 销售订单ID = " + i销售订单ID + " and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " ";
            if (!chk0.Checked)
            {
                sSQL = sSQL + " and isnull(本次下单数量,0) <> 0 ";
            }
            if (lookUpEdit属性.Text.Trim() != "" && lookUpEdit属性.Text.Trim() != "全部")
            {
                sSQL = sSQL + " and 子件属性 = '" + lookUpEdit属性.Text.Trim() + "' ";
            }

            sSQL = sSQL + " order by 子件编码";
            DataTable dt订单评审运算3 = clsSQLCommond.ExecQuery(sSQL);

            if (dt订单评审运算1 != null && dt订单评审运算1.Rows.Count > 0 && dt订单评审运算2 != null && dt订单评审运算2.Rows.Count > 0 && dt订单评审运算3 != null && dt订单评审运算3.Rows.Count > 0)
            {
                txt销售订单号.Text = dt订单评审运算1.Rows[0]["销售订单号"].ToString().Trim();
                txt外销订单号.Text = dt订单评审运算1.Rows[0]["外销订单号"].ToString().Trim();
                txt客户订单号.Text = dt订单评审运算1.Rows[0]["客户订单号"].ToString().Trim();
                lookUpEdit客户.EditValue = dt订单评审运算1.Rows[0]["客户编号"];
                txt备注.Text = dt订单评审运算1.Rows[0]["备注"].ToString().Trim();
                txt销售订单ID.Text = dt订单评审运算1.Rows[0]["销售订单ID"].ToString().Trim();
                txt评审备注.Text = dt订单评审运算1.Rows[0]["评审备注"].ToString().Trim();
                txt审核人.Text = dt订单评审运算1.Rows[0]["维护审核人"].ToString().Trim();
                dtm审核.Text = dt订单评审运算1.Rows[0]["维护审核日期"].ToString().Trim();
              
                gridControl销售订单列表.DataSource = dt订单评审运算2;
                gridControl评审维护.DataSource = dt订单评审运算3;

                SetColEdit(false);

                chk全选.Checked = false;

                lookUpEdit属性.EditValue = "全部";
                txt存货编码.Text = "";
                chk开始日期.Checked = false;
                chk完成日期.Checked = false;
            }
            else
            {
                throw new Exception("没有符合条件的数据");
            }
        }

        private void GetSelList()
        {
            string sSQL = "select 销售订单ID from 订单评审运算1 where 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " order by 销售订单号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
            }
        }

        private void chk全选_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chk全选.Checked)
                {
                    for (int i = 0; i < gridView评审维护.RowCount; i++)
                    {
                        gridView评审维护.SetRowCellValue(i, gridCol选择, "√");
                    }
                }
                else
                {
                    for (int i = 0; i < gridView评审维护.RowCount; i++)
                    {
                        gridView评审维护.SetRowCellValue(i, gridCol选择, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView评审维护_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (sState != "edit")
                    return;

                int i = gridView评审维护.FocusedRowHandle;
                if (gridView评审维护.GetRowCellValue(i, gridCol选择).ToString().Trim() == "")
                {
                        gridView评审维护.SetRowCellValue(i, gridCol选择, "√");
                }
                else
                {
                    gridView评审维护.SetRowCellValue(i, gridCol选择, "");
                }
            }
            catch { }
        }

        private void chk0_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt销售订单ID.Text.Trim() != "")
                {
                    GetGrid(Convert.ToInt64(txt销售订单ID.Text.Trim()));
                    SetColEdit(true);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (!radio手工.Checked)
                {
                    DialogResult d = MessageBox.Show("批改在分手工情况可能引起逻辑错误，请注意", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d != DialogResult.Yes)
                    {
                        throw new Exception("取消批改");
                    }
                }

                bool b = false;
                if (chk开始日期.Checked && dtm开始日期.Text.Trim() != "")
                {
                    b = true;
                }
                if (chk完成日期.Checked && dtm完成日期.Text.Trim() != "")
                {
                    b = true;
                }
                if (!b)
                {
                    MessageBox.Show("请选择要批改的内容");
                    return;
                }
                for (int i = 0; i < gridView评审维护.RowCount; i++)
                {
                    if (gridView评审维护.GetRowCellValue(i, gridCol选择).ToString().Trim() == "√")
                    {
                        if (chk开始日期.Checked)
                        {
                            gridView评审维护.SetRowCellValue(i, gridCol开始日期, dtm开始日期.DateTime);
                        }
                        if (chk完成日期.Checked)
                        {
                            gridView评审维护.SetRowCellValue(i, gridCol完成日期, dtm完成日期.DateTime);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void btn选择_Click(object sender, EventArgs e)
        {
            if (txt存货编码.Text.Trim() != "")
            {
                string s = txt存货编码.Text.ToLower().Trim();
                int iLength = s.Length;
                for (int i = 0; i < gridView评审维护.RowCount; i++)
                {
                    string s物料 = gridView评审维护.GetRowCellValue(i, gridCol子件编码).ToString().Trim().ToLower();
                    if (s物料.Substring(0, iLength) == s)
                    {
                        gridView评审维护.SetRowCellValue(i, gridCol选择, "√");
                    }
                }
            }
        }

        private void chk开始日期_CheckedChanged(object sender, EventArgs e)
        {
            if (chk开始日期.Checked)
                dtm开始日期.Enabled = true;
            else
            {
                dtm开始日期.Enabled = false;
                dtm开始日期.Text = "";
            }
        }

        private void chk完成日期_CheckedChanged(object sender, EventArgs e)
        {
            if (chk完成日期.Checked)
                dtm完成日期.Enabled = true;
            else
            {
                dtm完成日期.Enabled = false;
                dtm完成日期.Text = "";
            }
        }

        private void lookUpEdit属性_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit属性.Text.Trim() == "全部")
            {
                gridCol子件属性.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo();
            }
            else
            {
                gridCol子件属性.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(" 子件属性 = '" + lookUpEdit属性.Text.Trim() + "' ");
            }
        }


        /// <summary>
        /// 手工计划需要逆排下一层的需求数量
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="sInvCode2">母子对应</param>
        /// <param name="dQty">母件下单数量</param>
        /// <param name="dDate1">计划结束日期</param>
        /// <param name="i行号">销售订单行号</param>
        private void InitEditSG(string sInvCode, string sInvCode2, decimal dQty, int i行号)
        {
            DataRow[] drList = dt评审.Select(" 母件编码 = '" + sInvCode + "' and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");

            foreach (DataRow dr in drList)
            {
                decimal d需求数量 = decimal.Round(dQty * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["使用数量"]), 6);
                dr["需求数量"] = d需求数量;
            }
        }

        private void btn回签日期核查_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "行号";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "子件编码";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "子件名称";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "子件规格";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "评审完成日期";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "回签完成日期";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "母件编码";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "母件名称";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "母件规格";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "子件为共用件";
            dt.Columns.Add(dc);


            for (int i = 0; i < gridView评审维护.RowCount; i++)
            {
                string s属性 = gridView评审维护.GetRowCellDisplayText(i, gridCol子件属性).ToString().Trim();
                if (s属性 != "采购")
                    continue;


                DateTime d1 = ReturnObjectToDatetime(gridView评审维护.GetRowCellDisplayText(i, gridCol完成日期));
                DateTime d2 = ReturnObjectToDatetime(gridView评审维护.GetRowCellDisplayText(i, gridCol回签日期2));
                if (d1 != d2)
                {
                    sSQL = @"
select distinct c.子件编码,c.母件编码,d.cInvName,d.cInvStd
from dbo.订单评审运算1 a inner join 订单评审运算3 c on a.销售订单ID = c.销售订单ID and a.帐套号 = c.帐套号
    inner join @u8.Inventory d on c.母件编码 = d.cInvCode
where a.帐套号 = 200 and c.子件编码 = 'YLGC060006Z00' and a.销售订单号 = '1310711'
";
                    sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                    sSQL = sSQL.Replace("1310711", txt销售订单号.Text.Trim());
                    sSQL = sSQL.Replace("YLGC060006Z00", gridView评审维护.GetRowCellDisplayText(i, gridCol子件编码).ToString().Trim());

                    DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

                    for (int ii = 0; ii < dtTemp.Rows.Count; ii++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["行号"] = i + 1;
                        dr["子件编码"] = gridView评审维护.GetRowCellDisplayText(i, gridCol子件编码).ToString().Trim();
                        dr["子件名称"] = gridView评审维护.GetRowCellDisplayText(i, gridCol子件名称).ToString().Trim();
                        dr["子件规格"] = gridView评审维护.GetRowCellDisplayText(i, gridCol子件规格).ToString().Trim();
                        if (d1 != Convert.ToDateTime("1900-01-01"))
                            dr["评审完成日期"] = d1;
                        if (d2 != Convert.ToDateTime("1900-01-01"))
                            dr["回签完成日期"] = d2;
                        dr["母件编码"] = dtTemp.Rows[ii]["母件编码"].ToString().Trim();
                        dr["母件名称"] = dtTemp.Rows[ii]["cInvName"].ToString().Trim();
                        dr["母件规格"] = dtTemp.Rows[ii]["cInvStd"].ToString().Trim();
                        dr["子件为共用件"] = dtTemp.Rows.Count;
                        dt.Rows.Add(dr);
                    }
                }
            }

            DataView dv = dt.DefaultView;
            dv.Sort = " 子件编码 asc ";
            dv.RowFilter = " isnull(子件为共用件,0) > 1 ";

            if (dv.Count > 0)
            {
                Frm物料时间检查 f = new Frm物料时间检查();

                f.dtSEL = dv.ToTable();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有相关数据");
            }
        }

        private void btn15天核查_Click(object sender, EventArgs e)
        {
             try
            {
                try
                {
                    gridView评审维护.FocusedRowHandle -= 1;
                    gridView评审维护.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[table15Days]') AND type in (N'U'))
	delete table15Days
else
	create table table15Days(
		存货编码 varchar(100),
		需求日期 datetime,
		数量 decimal(18,6),
		外销单号 varchar(100),
		单据号 varchar(100),
        行号 int,
        类型 varchar(10)
	)";
                aList.Add(sSQL);

                for (int i = 0; i < gridView评审维护.RowCount; i++)
                {
                    //string s子件属性 = gridView评审维护.GetRowCellValue(i, gridCol子件属性).ToString().Trim();

                    //if (s子件属性 != "采购")
                    //    continue;

                    string s存货编码 = gridView评审维护.GetRowCellValue(i, gridCol子件编码).ToString().Trim();

                    if(gridView评审维护.GetRowCellValue(i,gridCol完成日期).ToString().Trim() == "")
                        continue;

                    DateTime d完成日期 = Convert.ToDateTime(gridView评审维护.GetRowCellValue(i,gridCol完成日期));
                    sSQL = @"
insert into table15Days
select b.cInvCode as 存货编码,b.dRequirDate as 需求日期,b.fQuantity as 数量,b.cItemCode as 外销单号,a.cCode as 请购单号,222222,'采购'
from @u8.PU_AppVouch a inner join @u8.PU_AppVouchs b on a.id = b.id
where ISNULL(cCloser,'') = '' and  b.cInvCode = '111111'  and '333333' <= b.dRequirDate and '444444' >=  b.dRequirDate
     and b.cItemCode <> '555555'

insert into table15Days
select b.InvCode,c.StartDate,b.Qty,b.SoCode,a.MoCode,222222,'自制'
from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId
	inner join @u8.mom_morder c on b.MoDId =  c.MoDId
where b.Status = '3' and b.InvCode = '111111'  and '333333' <= c.StartDate and '444444' >=  c.StartDate
    and b.SoCode <>  '555555'

insert into table15Days
select InvCode,DueDate,PlanQty,SoCode,iID,222222,'委外'
from UFDLImport..omplan
where ISNULL(ClosedUID,'') = '' and InvCode = '111111'  and '333333' <= DueDate and '444444' >=  DueDate
    and SoCode <>  '555555'
";
                    sSQL = sSQL.Replace("222222", (i + 1).ToString());
                    sSQL = sSQL.Replace("111111", s存货编码);
                    sSQL = sSQL.Replace("333333", d完成日期.AddDays(-15).ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("444444", d完成日期.AddDays(15).ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("555555", txt外销订单号.Text.Trim());
                    aList.Add(sSQL);
                }

                clsSQLCommond.ExecSqlTran(aList);
                sSQL = "select * from table15Days";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                Frm15天分析 f = new Frm15天分析();
                f.dtSEL = dt.Copy();
                f.ShowDialog();

            }
            catch (Exception ee)
            {
                MessageBox.Show("核查失败:" + ee.Message);
            }
        }
    }
}
