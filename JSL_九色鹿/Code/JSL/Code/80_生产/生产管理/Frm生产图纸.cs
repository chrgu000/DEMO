using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 生产
{
    public partial class Frm生产图纸 : 系统服务.FrmBaseInfo
    {

        public Frm生产图纸()
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
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
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
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("刷新窗体失败\n" + ee.Message);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
           


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
            throw new NotImplementedException();
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
                            string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                            int iRe = CheState(sID);
                            if (iRe == -1)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                                continue;
                            }
                            if (iRe == 0)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                                continue;
                            }
                            if (iRe == 2)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "单据已审核\n";
                                continue;
                            }
                            if (iRe == 3)
                            {
                                sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                                continue;
                            }

                            sSQL = "delete 生产图纸 where iID=" + sID + " ";
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
                gridView1.FocusedColumn = gridColS01;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            sSQL = "select * from 生产图纸 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";
            sSQL = "select isnull(max(iID)+1,1) as iID from 生产图纸";
            long iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            aList = new System.Collections.ArrayList();
            int scount = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                #region 判断
                if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "add" && gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "update")
                {
                    continue;
                }

                if (gridView1.GetRowCellDisplayText(i, gridColS01).Trim() == "")
                {
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, gridColS01).Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + gridColS02.Caption + "不能为空\n";
                    continue;
                }

                if (gridView1.GetRowCellValue(i, gridColS02).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + gridColS02.Caption + "不能为空\n";
                    continue;
                }

                #endregion

                #region 判断是否重复
                for (int j = 0; j < i; j++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColS01).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridColS01).ToString().Trim()
                        && gridView1.GetRowCellDisplayText(i, gridColS02).ToString().Trim() == gridView1.GetRowCellDisplayText(j, gridColS02).ToString().Trim())
                    {
                        sErr = sErr + "行" + (i + 1) + gridColS01.Caption + "：" + gridView1.GetRowCellDisplayText(i, gridColS01).ToString().Trim() + "，"
                            + gridColS01.Caption + "：" + gridView1.GetRowCellDisplayText(i, gridColS02).ToString().Trim() + "重复\n";
                        continue;
                    }
                }
                #endregion

                scount = scount + 1;
                #region 生成table
                DataRow dr = dt.NewRow();
                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() != "")
                {
                    dr["iID"] = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    dr["UpdateDate"] = DateTime.Now.ToString();
                    dr["UpdateUid"] = 系统服务.ClsBaseDataInfo.sUid;
                }
                else
                {
                    dr["iID"] = iID;
                    dr["CreateDate"] = DateTime.Now.ToString();
                    dr["CreateUid"] = 系统服务.ClsBaseDataInfo.sUid;
                    iID = iID + 1;
                }
                dr["S01"] = gridView1.GetRowCellValue(i, gridColS01).ToString().Trim();
                dr["S02"] = gridView1.GetRowCellValue(i, gridColS02).ToString().Trim();
                //dr["S03"] = gridView1.GetRowCellValue(i, gridColS03).ToString().Trim();
                //dr["S04"] = gridView1.GetRowCellValue(i, gridColS04).ToString().Trim();
                dr["S05"] = gridView1.GetRowCellValue(i, gridColS05).ToString().Trim();
                dr["S06"] = gridView1.GetRowCellValue(i, gridColS06).ToString().Trim();
                dr["S07"] = gridView1.GetRowCellValue(i, gridColS07).ToString().Trim();
                dr["S08"] = gridView1.GetRowCellValue(i, gridColS08).ToString().Trim();
                dr["S09"] = gridView1.GetRowCellValue(i, gridColS09).ToString().Trim();
                dr["S10"] = gridView1.GetRowCellValue(i, gridColS10).ToString().Trim();
                dr["S11"] = gridView1.GetRowCellValue(i, gridColS11).ToString().Trim();
                dr["S12"] = gridView1.GetRowCellValue(i, gridColS12).ToString().Trim();
                dr["S13"] = gridView1.GetRowCellValue(i, gridColS13).ToString().Trim();
                dr["S14"] = gridView1.GetRowCellValue(i, gridColS14).ToString().Trim();
                dr["S15"] = gridView1.GetRowCellValue(i, gridColS15).ToString().Trim();
                dr["S16"] = gridView1.GetRowCellValue(i, gridColS16).ToString().Trim();
                dr["S17"] = gridView1.GetRowCellValue(i, gridColS17).ToString().Trim();
                dr["S18"] = gridView1.GetRowCellValue(i, gridColS18).ToString().Trim();
                dr["S19"] = gridView1.GetRowCellValue(i, gridColS19).ToString().Trim();
                dr["S20"] = gridView1.GetRowCellValue(i, gridColS20).ToString().Trim();

                if (gridView1.GetRowCellDisplayText(i, gridColD01).Trim() != "")
                {
                    dr["D01"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD01).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD02).Trim() != "")
                {
                    dr["D02"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD02).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD03).Trim() != "")
                {
                    dr["D03"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD03).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD04).Trim() != "")
                {
                    dr["D04"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD04).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD05).Trim() != "")
                {
                    dr["D05"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD05).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD06).Trim() != "")
                {
                    dr["D06"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD06).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD07).Trim() != "")
                {
                    dr["D07"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD07).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD08).Trim() != "")
                {
                    dr["D08"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD08).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD09).Trim() != "")
                {
                    dr["D09"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD09).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD10).Trim() != "")
                {
                    dr["D10"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD10).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD11).Trim() != "")
                {
                    dr["D11"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD11).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD12).Trim() != "")
                {
                    dr["D12"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD12).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD13).Trim() != "")
                {
                    dr["D13"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD13).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD14).Trim() != "")
                {
                    dr["D14"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD14).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD15).Trim() != "")
                {
                    dr["D15"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD15).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD16).Trim() != "")
                {
                    dr["D16"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD16).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD17).Trim() != "")
                {
                    dr["D17"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD17).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD18).Trim() != "")
                {
                    dr["D18"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD18).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD19).Trim() != "")
                {
                    dr["D19"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD19).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColD20).Trim() != "")
                {
                    dr["D20"] = ReturnDecimal(gridView1.GetRowCellDisplayText(i, gridColD20).Trim());
                }


                if (gridView1.GetRowCellDisplayText(i, gridColDate01).Trim() != "")
                {
                    dr["Date01"] = ReturnDateTimeString(gridView1.GetRowCellDisplayText(i, gridColDate01).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColDate02).Trim() != "")
                {
                    dr["Date02"] = ReturnDateTimeString(gridView1.GetRowCellDisplayText(i, gridColDate02).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColDate03).Trim() != "")
                {
                    dr["Date03"] = ReturnDateTimeString(gridView1.GetRowCellDisplayText(i, gridColDate03).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColDate04).Trim() != "")
                {
                    dr["Date04"] = ReturnDateTimeString(gridView1.GetRowCellDisplayText(i, gridColDate04).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColDate05).Trim() != "")
                {
                    dr["Date05"] = ReturnDateTimeString(gridView1.GetRowCellDisplayText(i, gridColDate05).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColDate06).Trim() != "")
                {
                    dr["Date06"] = ReturnDateTimeString(gridView1.GetRowCellDisplayText(i, gridColDate06).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColDate07).Trim() != "")
                {
                    dr["Date07"] = ReturnDateTimeString(gridView1.GetRowCellDisplayText(i, gridColDate07).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColDate08).Trim() != "")
                {
                    dr["Date08"] = ReturnDateTimeString(gridView1.GetRowCellDisplayText(i, gridColDate08).Trim());
                }
                if (gridView1.GetRowCellDisplayText(i, gridColDate09).Trim() != "")
                {
                    dr["Date09"] = ReturnDateTimeString(gridView1.GetRowCellDisplayText(i, gridColDate09).Trim());
                }

                string S03_1 = gridView1.GetRowCellDisplayText(i, gridColS03_1).Trim();
                if (S03_1 != "")
                {
                    clsPublic.CreateFile(系统服务.ClsBaseDataInfo.sFiles + "1");
                    string filename = System.IO.Path.GetFileNameWithoutExtension(S03_1);
                    string fileext = System.IO.Path.GetExtension(S03_1);
                    string newfile = 系统服务.ClsBaseDataInfo.sFiles + "1/" + dr["S01"].ToString() + "_" + dr["S02"].ToString() + fileext;
                    File.Copy(S03_1, newfile);
                    dr["S03"] = filename + fileext;
                }

                string S04_1 = gridView1.GetRowCellDisplayText(i, gridColS04_1).Trim();
                if (S04_1 != "")
                {
                    clsPublic.CreateFile(系统服务.ClsBaseDataInfo.sFiles + "2");
                    string filename = System.IO.Path.GetFileNameWithoutExtension(S04_1);
                    string fileext = System.IO.Path.GetExtension(S04_1);
                    string newfile = 系统服务.ClsBaseDataInfo.sFiles + "2/" + dr["S01"].ToString() + "_" + dr["S02"].ToString() + fileext;
                    File.Copy(S04_1, newfile);
                    dr["S04"] = filename + fileext;
                }

                dt.Rows.Add(dr);
                #endregion

                if (gridView1.GetRowCellDisplayText(i, gridColiSave).Trim() == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "生产图纸", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).Trim() == "update")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "生产图纸", dt, dt.Rows.Count - 1);
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
                MessageBox.Show("保存成功！\n合计执行语句:" + scount + "条");
                GetGrid();
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new System.Collections.ArrayList();
            string slist = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                    int iRe = CheState(sID);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    if (iRe == 2)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已审核\n";
                        continue;
                    }
                    if (iRe == 3)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                        continue;
                    }

                    sSQL = "update 生产图纸 set AuditDate='" + GetSystemTime() + "',AuditUid='" + 系统服务.ClsBaseDataInfo.sUid + "' where iID=" + sID + " ";
                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                throw new Exception("请选择需审核的单据！" + sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                GetGrid();
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new System.Collections.ArrayList();
            string sList = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                    int iRe = CheState(sID);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    //if (iRe == 2)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "单据未关闭\n";
                    //    continue;
                    //}
                    if (iRe == 3)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                        continue;
                    }

                    sSQL = "update 生产图纸 set AuditDate=null,AuditUid=null where iID=" + sID + "";
                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                throw new Exception("请选择需弃审的单据！" + sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = iCou = clsSQLCommond.ExecSqlTran(aList);
                GetGrid();
                MessageBox.Show("弃审成功");
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new System.Collections.ArrayList();
            string sList = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                    int iRe = CheState(sID);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    if (iRe == 2)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据未关闭\n";
                        continue;
                    }
                    //if (iRe == 3)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                    //    continue;
                    //}

                    sSQL = "update 生产图纸 set CloseDate=null,CloseUid=null where iID=" + sID + "";
                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }
            int iCou = 0;
            if (aList.Count > 0)
            {
                iCou = clsSQLCommond.ExecSqlTran(aList);
                GetGrid();

                MessageBox.Show("打开成功！");
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
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new System.Collections.ArrayList();
            string slist = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();

                    int iRe = CheState(sID);
                    if (iRe == -1)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "检查单据状态出错\n";
                        continue;
                    }
                    if (iRe == 0)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据不存在\n";
                        continue;
                    }
                    //if (iRe == 2)
                    //{
                    //    sErr = sErr + "行" + (i + 1).ToString() + "单据未关闭\n";
                    //    continue;
                    //}
                    if (iRe == 3)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + "单据已关闭\n";
                        continue;
                    }

                    sSQL = "update 生产图纸 set CloseDate='" + GetSystemTime() + "',CloseUid='" + 系统服务.ClsBaseDataInfo.sUid + "' where iID=" + sID + " ";
                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                GetGrid();
                MessageBox.Show("关闭成功！");
            }
        }

        /// <summary>
        /// 判断单据状态
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState(string sID)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(CreateUid,'') as 制单人,isnull(AuditUid,'') as 审核人,isnull(CloseUid,'') as 关闭人 from 生产图纸 where iID = '" + sID + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dt.Rows[0]["制单人"] != "")
                    {
                        iReturn = 1;
                    }
                    if (dt.Rows[0]["审核人"] != "")
                    {
                        iReturn = 2;
                    }
                    if (dt.Rows[0]["关闭人"] != "")
                    {
                        iReturn = 3;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm采购入库单列表_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.Person(ItemLookUpEdit人员);

        }

        private void GetGrid()
        {
            string sSQL = "select 'edit' as iSave,*,convert(nvarchar(500),'') as S03_1,convert(nvarchar(500),'') as S04_1 from [dbo].[生产图纸] order by iID";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            gridView1.AddNewRow();
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
                if (e.Column == gridColS01 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColS01).ToString().Trim() != "")
                {
                    int iRow = gridView1.FocusedRowHandle;
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
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

        private void ItemButtonEditS03_1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog1.FileName;
                    gridView1.SetRowCellValue(iRow, gridColS03_1, filename);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEditS04_1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog1.FileName;
                    gridView1.SetRowCellValue(iRow, gridColS04_1, filename);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEditS03_2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string fileext = System.IO.Path.GetExtension(gridView1.GetRowCellValue(iRow, gridColS03).ToString());
                if (fileext != "")
                {
                    string oldfile = 系统服务.ClsBaseDataInfo.sFiles + "1/" + gridView1.GetRowCellValue(iRow, gridColS01).ToString() + "_" + gridView1.GetRowCellValue(iRow, gridColS02).ToString() + fileext;
                    if (!System.IO.File.Exists(oldfile))
                    {
                        MessageBox.Show("服务器上未找到已上传文件，不可下载");
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string filename = saveFileDialog1.FileName + fileext;
                            File.Copy(oldfile, filename);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("未上传文件，不可下载");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemButtonEditS04_2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.IsRowSelected(i))
                    {
                        iRow = i;
                    }
                }
                string fileext = System.IO.Path.GetExtension(gridView1.GetRowCellValue(iRow, gridColS04).ToString());
                if (fileext != "")
                {
                    string oldfile = 系统服务.ClsBaseDataInfo.sFiles + "2/" + gridView1.GetRowCellValue(iRow, gridColS01).ToString() + "_" + gridView1.GetRowCellValue(iRow, gridColS02).ToString() + fileext;
                    if (!System.IO.File.Exists(oldfile))
                    {
                        MessageBox.Show("服务器上未找到已上传文件，不可下载");
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string filename = saveFileDialog1.FileName + fileext;
                            File.Copy(oldfile, filename);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("未上传文件，不可下载");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}