using System;
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
    public partial class Frm客户档案 : 系统服务.FrmBaseInfo
    {
        string tablename = "Customer";
        string tableid = "cCusCode";
        public Frm客户档案()
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
            //DataTable dtState = (DataTable)ItemLookUpEditcTrade.DataSource;
            //DataTable dtType = (DataTable)ItemLookUpEditcCCCode.DataSource;
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
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            try
            {
                SetLookUpEdit();
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
            sState = "edit";
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
                            string sID = gridView1.GetRowCellValue(i, gridCol客户编码).ToString().Trim();
                            sSQL = "select count(1) from dbo.SO_SOMain where cCusCode = '" + sID + "' ";
                            long iCou = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                            if (iCou > 0)
                            {
                                sErr = "行" + (i + 1).ToString() + " " + sID + " 已经在销售档案中使用不能删除\n";
                                continue;
                            }

                            sSQL = "select count(1) from dbo.AR_First where S1 = '" + sID + "' ";
                            long iCou1 = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                            if (iCou > 0)
                            {
                                sErr = "行" + (i + 1).ToString() + " " + sID + " 已经使在应收期初用不能删除\n";
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
                gridView1.FocusedColumn = gridCol客户编码;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            sSQL = "select * from Customer where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";
            sSQL = "";
            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                #region 判断
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                {
                    if (gridView1.GetRowCellDisplayText(i, gridCol客户编码).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridCol客户名称).ToString().Trim() == "")
                    {
                        continue;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol客户编码).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol客户编码.Caption + "不能为空\n";
                        continue;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol客户名称).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol客户名称.Caption + "不能为空\n";
                        continue;
                    }
                    //if (gridView1.GetRowCellDisplayText(i, gridCol客户分类编码).ToString().Trim() == "")
                    //{
                    //    sErr = sErr + "行" + (i + 1) + gridCol客户分类编码.Caption + "不能为空\n";
                    //    continue;
                    //}
                    //if (gridView1.GetRowCellDisplayText(i, gridCol分管业务员).ToString().Trim() == "")
                    //{
                    //    sErr = sErr + "行" + (i + 1) + gridCol分管业务员.Caption + "不能为空\n";
                    //    continue;
                    //}

                    //if (gridView1.GetRowCellValue(i, gridColD1).ToString().Trim() == "")
                    //{
                    //    sErr = sErr + "行" + (i + 1) + gridColD1.Caption + "不可为空\n";
                    //    continue;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim() == "")
                    //{
                    //    sErr = sErr + "行" + (i + 1) + gridColDate1.Caption + "不可为空\n";
                    //    continue;
                    //}
                    //if (gridView1.GetRowCellValue(i, gridColDate2).ToString().Trim() == "")
                    //{
                    //    sErr = sErr + "行" + (i + 1) + gridColDate2.Caption + "不可为空\n";
                    //    continue;
                    //}
                #endregion

                    #region 判断是否重复
                    for (int j = 0; j < i; j++)
                    {
                        if (gridView1.GetRowCellDisplayText(i, gridCol客户编码).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridCol客户编码).ToString().Trim())
                        {
                            sErr = sErr + "行" + (i + 1) + gridCol客户编码.Caption + "重复\n";
                            continue;
                        }
                    }
                    #endregion

                    #region 生成table
                    DataRow dr = dt.NewRow();
                    dr["cCusCode"] = gridView1.GetRowCellValue(i, gridCol客户编码).ToString().Trim();
                    dr["cCusName"] = gridView1.GetRowCellValue(i, gridCol客户名称).ToString().Trim();
                    dr["cCusAbbName"] = gridView1.GetRowCellValue(i, gridCol客户简称).ToString().Trim();
                    dr["cCCCode"] = gridView1.GetRowCellValue(i, gridCol客户分类编码).ToString().Trim();
                    dr["cDCCode"] = gridView1.GetRowCellValue(i, gridCol地区).ToString().Trim();
                    dr["cCusPerson"] = gridView1.GetRowCellValue(i, gridCol联系人).ToString().Trim();
                    dr["cCusPhone"] = gridView1.GetRowCellValue(i, gridCol联系电话).ToString().Trim();
                    dr["cCusPhone2"] = gridView1.GetRowCellValue(i, gridColcCusPhone2).ToString().Trim();
                    dr["cCusAddress"] = gridView1.GetRowCellValue(i, gridCol地址1).ToString().Trim();
                    dr["cCusEmail"] = gridView1.GetRowCellValue(i, gridCol邮件).ToString().Trim();

                    if (gridView1.GetRowCellValue(i, gridCol发展日期) != null && gridView1.GetRowCellValue(i, gridCol发展日期).ToString() != "")
                    {
                        dr["cCusDevDate"] = gridView1.GetRowCellValue(i, gridCol发展日期).ToString().Trim();
                    }
                    else
                    {
                        dr["cCusDevDate"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellValue(i, gridColdcEndDate) != null && gridView1.GetRowCellValue(i, gridColdcEndDate).ToString() != "")
                    {
                        dr["cEndDate"] = gridView1.GetRowCellValue(i, gridColdcEndDate).ToString().Trim();
                    }
                    else
                    {
                        dr["cEndDate"] = DBNull.Value;
                    }
                    dr["cCusRegCode"] = gridView1.GetRowCellValue(i, gridColcCusRegCode).ToString().Trim();
                    dr["cCusAccount"] = gridView1.GetRowCellValue(i, gridColcCusAccount).ToString().Trim();
                    dr["cCusBank"] = gridView1.GetRowCellValue(i, gridColcCusBank).ToString().Trim();
                    dr["cCusLPerson"] = gridView1.GetRowCellValue(i, gridColcCusLPerson).ToString().Trim();
                    dr["cCusDepart"] = gridView1.GetRowCellValue(i, gridCol分管部门).ToString().Trim();
                    dr["cCusPPerson"] = gridView1.GetRowCellValue(i, gridCol分管业务员).ToString().Trim();
                    dr["NotDelivery"] = gridView1.GetRowCellValue(i, gridColNotDelivery).ToString().Trim();

                    #region
                    dr["S1"] = gridView1.GetRowCellValue(i, gridColS1).ToString().Trim();
                    dr["S2"] = gridView1.GetRowCellValue(i, gridColS2).ToString().Trim();
                    dr["S3"] = gridView1.GetRowCellValue(i, gridColS3).ToString().Trim();
                    dr["S4"] = gridView1.GetRowCellValue(i, gridColS4).ToString().Trim();
                    dr["S5"] = gridView1.GetRowCellValue(i, gridColS5).ToString().Trim();
                    dr["S6"] = gridView1.GetRowCellValue(i, gridColS6).ToString().Trim();
                    dr["S7"] = gridView1.GetRowCellValue(i, gridColS7).ToString().Trim();
                    dr["S8"] = gridView1.GetRowCellValue(i, gridColS8).ToString().Trim();
                    dr["S9"] = gridView1.GetRowCellValue(i, gridColS9).ToString().Trim();
                    dr["S10"] = gridView1.GetRowCellValue(i, gridColS10).ToString().Trim();
                    #endregion

                    #region
                    if (gridView1.GetRowCellDisplayText(i, gridColD1).ToString() != "")
                    {
                        decimal d1=ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD1).ToString());
                        if (d1<=100 && d1>=0)
                        {
                            dr["D1"] = gridView1.GetRowCellValue(i, gridColD1).ToString().Trim();
                        }
                        else
                        {
                            sErr = sErr + "行" + (i + 1) + gridColD1.Caption + "在0-100之间\n";
                        }
                    }
                    else
                    {
                        dr["D1"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColD2).ToString() != "")
                    {
                        dr["D2"] = gridView1.GetRowCellValue(i, gridColD2).ToString().Trim();
                    }
                    else
                    {
                        dr["D2"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColD3).ToString() != "")
                    {
                        dr["D3"] = gridView1.GetRowCellValue(i, gridColD3).ToString().Trim();
                    }
                    else
                    {
                        dr["D3"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColD4).ToString() != "")
                    {
                        dr["D4"] = gridView1.GetRowCellValue(i, gridColD4).ToString().Trim();
                    }
                    else
                    {
                        dr["D4"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColD5).ToString() != "")
                    {
                        dr["D5"] = gridView1.GetRowCellValue(i, gridColD5).ToString().Trim();
                    }
                    else
                    {
                        dr["D5"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColD6).ToString() != "")
                    {
                        dr["D6"] = gridView1.GetRowCellValue(i, gridColD6).ToString().Trim();
                    }
                    else
                    {
                        dr["D6"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColD7).ToString() != "")
                    {
                        dr["D7"] = gridView1.GetRowCellValue(i, gridColD7).ToString().Trim();
                    }
                    else
                    {
                        dr["D7"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColD8).ToString() != "")
                    {
                        dr["D8"] = gridView1.GetRowCellValue(i, gridColD8).ToString().Trim();
                    }
                    else
                    {
                        dr["D8"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColD9).ToString() != "")
                    {
                        dr["D9"] = gridView1.GetRowCellValue(i, gridColD9).ToString().Trim();
                    }
                    else
                    {
                        dr["D9"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColD10).ToString() != "")
                    {
                        dr["D10"] = gridView1.GetRowCellValue(i, gridColD10).ToString().Trim();
                    }
                    else
                    {
                        dr["D10"] = DBNull.Value;
                    }
                    #endregion

                    #region
                    if (gridView1.GetRowCellDisplayText(i, gridColDate1).ToString() != "")
                    {
                        dr["Date1"] = gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim();
                    }
                    else
                    {
                        dr["Date1"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColDate2).ToString() != "")
                    {
                        dr["Date2"] = gridView1.GetRowCellValue(i, gridColDate2).ToString().Trim();
                    }
                    else
                    {
                        dr["Date2"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColDate3).ToString() != "")
                    {
                        dr["Date3"] = gridView1.GetRowCellValue(i, gridColDate3).ToString().Trim();
                    }
                    else
                    {
                        dr["Date3"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColDate4).ToString() != "")
                    {
                        dr["Date4"] = gridView1.GetRowCellValue(i, gridColDate4).ToString().Trim();
                    }
                    else
                    {
                        dr["Date4"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColDate5).ToString() != "")
                    {
                        dr["Date5"] = gridView1.GetRowCellValue(i, gridColDate5).ToString().Trim();
                    }
                    else
                    {
                        dr["Date5"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColDate6).ToString() != "")
                    {
                        dr["Date6"] = gridView1.GetRowCellValue(i, gridColDate6).ToString().Trim();
                    }
                    else
                    {
                        dr["Date6"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColDate7).ToString() != "")
                    {
                        dr["Date7"] = gridView1.GetRowCellValue(i, gridColDate7).ToString().Trim();
                    }
                    else
                    {
                        dr["Date7"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColDate8).ToString() != "")
                    {
                        dr["Date8"] = gridView1.GetRowCellValue(i, gridColDate8).ToString().Trim();
                    }
                    else
                    {
                        dr["Date8"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColDate9).ToString() != "")
                    {
                        dr["Date9"] = gridView1.GetRowCellValue(i, gridColDate9).ToString().Trim();
                    }
                    else
                    {
                        dr["Date9"] = DBNull.Value;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColDate10).ToString() != "")
                    {
                        dr["Date10"] = gridView1.GetRowCellValue(i, gridColDate10).ToString().Trim();
                    }
                    else
                    {
                        dr["Date10"] = DBNull.Value;
                    }
                    #endregion
                    dt.Rows.Add(dr);
                    #endregion

                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "Customer", dt, dt.Rows.Count - 1);
                        aList.Add(sSQL);
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "Customer", dt, dt.Rows.Count - 1);
                        aList.Add(sSQL);
                    }
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

        private void Frm客户档案_Load(object sender, EventArgs e)
        {
            try
            {
                GetLayOut(layoutControl1, gridControl1);
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            int iFocRow = 0;
            if(gridView1.FocusedRowHandle>0)
                iFocRow = gridView1.FocusedRowHandle;

            string sSQL = "select *, 'edit' as iSave from dbo.Customer order by cCusCode";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            gridView1.AddNewRow();
            
            gridView1.FocusedRowHandle = iFocRow;
            gridView1.SetRowCellValue(gridView1.RowCount, gridColNotDelivery, false);
            
            gridView1.OptionsBehavior.Editable = false;

            sState = "sel";
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            //客户分类
            string sSQL = "select cCCode as iID,cCName as iText from CustomerClass order by cCCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit客户分类.DataSource = dt;


            //地区
            sSQL = "select cDCCode as iID,cDCName as iText from dbo.DistrictClass order by cDCCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit地区分类.DataSource = dt;

            //分管部门
            sSQL = "select cDepCode,cDepName from dbo.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit分管部门.DataSource = dt;

            //专管业务员
            sSQL = "select PersonCode,PersonName from dbo.Person order by PersonCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit分管业务员.DataSource = dt;


            系统服务.LookUp.CustomerLevel(ItemLookUpEdit客户等级);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {

                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColiSave, "update");
                }
                if (e.Column == gridCol客户名称 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol客户编码).ToString().Trim() != "")
                {
                    int iRow = gridView1.FocusedRowHandle;
                    gridView1.AddNewRow();
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColNotDelivery, false);
                    gridView1.FocusedRowHandle = iRow;
                    
                }
                if (e.Column == gridCol客户编码)
                {
                    if (gridView1.GetRowCellDisplayText(e.RowHandle, gridColNotDelivery) == "不确定")
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColNotDelivery, false);
                    }
                }

                if (e.Column == gridCol分管业务员)
                {
                    if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol分管业务员).ToString().Trim() != "" && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol分管业务员名称).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol分管业务员, "");
                    }
                    sSQL = "select DeptID from dbo.Person where PersonCode='" + gridView1.GetRowCellDisplayText(e.RowHandle, gridCol分管业务员).ToString().Trim() + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol分管部门, dt.Rows[0]["DeptID"]);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol分管部门, "");
                    }
                }
                if (e.Column == gridCol分管部门)
                {
                    if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol分管部门).ToString().Trim() != "" && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol分管部门名称).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol分管部门, "");
                    }
                }
                if (e.Column == gridCol地区)
                {
                    if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol地区).ToString().Trim() != "" && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol地区名称).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol地区, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEditcCusPPerson_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol分管业务员, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEditcCusDepart_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol分管部门, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEdit地区_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            系统服务.Frm参照 frm = new 系统服务.Frm参照(4);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol地区, frm.sID);
            }
        }

        private void ItemButtonEdit客户分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = gridView1.FocusedRowHandle;
            系统服务.Frm参照 frm = new 系统服务.Frm参照(5);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol客户分类编码, frm.sID);
            }
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
    }
}
