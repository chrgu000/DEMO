using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;

namespace 人事管理
{
    public partial class Frm出差登记 : 系统服务.FrmBaseInfo
    {
        string tablename = "Travel";
        string tableid = "iCode";
        string tablenames = "Travels";
        long iID = -1;
        public string iCode1;
        public string iCode2;
        public string dDate1;
        public string dDate2;
        public string SS1;
        public string SS2;
        public string SS3;
        public string SS4 = "";

        public Frm出差登记(long siID)
        {
            iID = siID;
            InitializeComponent();
        }

        public Frm出差登记()
        {
            InitializeComponent();

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                //gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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
                    case "add":
                        btnAdd();
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
            
            return null;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            throw new NotImplementedException();
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
            SetLookUpEdit();

            GetGrid();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm出差登记_Add frm = new Frm出差登记_Add(iCode1, iCode2, dDate1, dDate2, SS1, SS2, SS3,SS4);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                iCode1 = frm.iCode1;
                iCode2 = frm.iCode2;
                dDate1 = frm.dDate1;
                dDate2 = frm.dDate2;
                SS1 = frm.SS1;
                SS2 = frm.SS2;
                SS3 = frm.SS3;
                SS4 = frm.SS4;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " where 1=1";
            if (iCode1 != null && iCode1 != "")
            {
                sSQL = sSQL + " and iCode>='" + iCode1 + "'";
            }
            if (iCode2 != null && iCode2 != "")
            {
                sSQL = sSQL + " and iCode<='" + iCode2 + "'";
            }
            if (dDate1 != "")
            {
                sSQL = sSQL + " and dDate >= '" + dDate1 + "'";
            }
            if (dDate2 != "")
            {
                sSQL = sSQL + " and dDate <= '" + dDate2 + "'";
            }
            if (SS1 != null && SS1 != "")
            {
                sSQL = sSQL + " and SS1='" + SS1 + "'";
            }
            if (SS2 != null && SS2 != "")
            {
                sSQL = sSQL + " and SS2='" + SS2 + "'";
            }
            if (SS3 != null && SS3 != "")
            {
                sSQL = sSQL + " and SS3='" + SS3 + "'";
            }
            if (SS4 != "")
            {
                sSQL = sSQL + " and SS4='" + SS4 + "'";
            }
            sSQL = sSQL + "  order by ID";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            if (dtSel.Rows.Count > 0)
            {
                iID = Convert.ToInt64(dtSel.Rows[0]["ID"]);
                GetGrid();
            }
            else
            {
                btnLast();
            }

        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                sSQL = "select min(ID) as ID from " + tablename + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditiID.Text = dt.Rows[0]["ID"].ToString();
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                }
                GetSelBind();
            }
            catch(Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (iID != -1)
                {
                    sSQL = "select ID from " + tablename + " where ID<" + textEditiID.Text + " order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditiID.Text = dt.Rows[0]["ID"].ToString();
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                    GetSelBind();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (iID != -1)
                {
                    sSQL = "select ID from " + tablename + " where ID>" + textEditiID.Text + " order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditiID.Text = dt.Rows[0]["ID"].ToString();
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                    GetSelBind();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditiID.Text = dt.Rows[0]["ID"].ToString();
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                }
                GetSelBind();
            }
            catch(Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }

        private void GetSelBind()
        {
            GetGrid();
            SetEnabled(false);
            sState = "";
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
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            GetNull();
            SetEnabled(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
            //dateEditTT1.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
            sState = "add";
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能审核");
            }
            int iReturn = CheState(textEdit单据号.Text.Trim());
            if (iReturn == -1)
            {
                throw new Exception("检查单据状态失败");
            }
            if (iReturn == 0)
            {
                throw new Exception("该单据不存在");
            }
            if (iReturn == 2)
            {
                throw new Exception("该单据已审核");
            }
            if (iReturn == 3)
            {
                throw new Exception("该单据已关闭");
            }
            SetEnabled(true);
            textEdit单据号.Enabled = false;

            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能审核");
            }
            int iReturn = CheState(textEdit单据号.Text.Trim());
            if (iReturn == -1)
            {
                throw new Exception("检查单据状态失败");
            }
            if (iReturn == 0)
            {
                throw new Exception("该单据不存在");
            }
            if (iReturn == 2)
            {
                throw new Exception("该单据已审核");
            }
            if (iReturn == 3)
            {
                throw new Exception("该单据已关闭");
            }

            aList = new System.Collections.ArrayList();
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                sSQL = "delete " + tablename + " where " + tableid + " = '" + textEdit单据号.EditValue.ToString().Trim() + "' ";
                aList.Add(sSQL);

                sSQL = "delete " + tablenames + " where iCodeHead = '" + textEdit单据号.EditValue.ToString().Trim() + "' ";
                aList.Add(sSQL);

                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                btnPrev();
            }
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
                sSQL = "select * from " + tablename + " where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select * from " + tablenames + " where 1=-1";
                DataTable dtDetail = clsSQLCommond.ExecQuery(sSQL);

                string sErr = "";

                aList = new System.Collections.ArrayList();
                DataRow dr = dt.NewRow();
                if (sState == "add")
                {
                    sSQL = "select isnull(max(ID)+1,1) as ID from " + tablename;
                    iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                    textEditiID.EditValue = iID;
                    textEdit单据号.EditValue = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
                    dateEdit制单日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
                    textEdit制单人.EditValue = 系统服务.ClsBaseDataInfo.sUid;
                }

                if (textEdit单据号.Text.Trim() == "")
                {
                    throw new Exception("没有单据号，不能保存");
                }
                int iReturn = CheState(textEdit单据号.Text.Trim());
                if (iReturn == -1)
                {
                    throw new Exception("检查单据状态失败");
                }
                if (iReturn == 2)
                {
                    throw new Exception("该单据已审核");
                }
                if (iReturn == 3)
                {
                    throw new Exception("该单据已关闭");
                }

                if (dateEditTT1.Text.Trim() == "")
                {
                    throw new Exception("出差日期必须填写");
                }

                sSQL = "select count(1) from " + tablename + " where SS1 = '" + lookUpEditSS1.EditValue + "' and TT1 = '" + dateEditTT1.DateTime.ToString("yyyy-MM-dd") + "'";
                int iDCou = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
                if (sState == "add" && iDCou > 0)
                {
                    throw new Exception("该日期该业务员已有出差登记");
                }

                if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("单据日期不可为空");
                }

                if (lookUpEditSS1.EditValue == null || lookUpEditSS1.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("业务员不可为空");
                }

                if (lookUpEditSS2.EditValue == null || lookUpEditSS2.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("部门不可为空");
                }

                if (dateEditTT1.EditValue == null || dateEditTT1.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("出差日期不可为空");
                }

                dr["ID"] = textEditiID.Text;
                dr["iCode"] = textEdit单据号.EditValue.ToString().Trim();

                dr["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
                dr["dMemo"] = textEditdMemo.EditValue.ToString().Trim();

                dr["SS1"] = lookUpEditSS1.EditValue.ToString().Trim();
                dr["SS2"] = lookUpEditSS2.EditValue.ToString().Trim();

                dr["TT1"] = dateEditTT1.EditValue.ToString().Trim();

                dr["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
                dr["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();

                dt.Rows.Add(dr);

                decimal d出差金额 = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColS1).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridColS3).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridColS4).ToString().Trim() == "")
                    {
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridColS1).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridColS3).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridColS4).ToString().Trim() != "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColS4.Caption + "客户或者意向性客户不能同时为空\n";
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridColS4).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColS4.Caption + " 不能为空\n";
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridColS5).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridColS5.Caption + " 不能为空\n";
                        continue;
                    }

                    d出差金额 = d出差金额 + ReturnDecimal(gridView1.GetRowCellValue(i, gridColD1));

                    DataRow drDetail = dtDetail.NewRow();
                    drDetail["iCodeHead"] = textEdit单据号.Text.Trim();
                    drDetail["S1"] = gridView1.GetRowCellValue(i, gridColS1).ToString().Trim();
                    drDetail["S2"] = gridView1.GetRowCellValue(i, gridColS2).ToString().Trim();
                    drDetail["S3"] = gridView1.GetRowCellValue(i, gridColS3).ToString().Trim();
                    drDetail["S4"] = gridView1.GetRowCellValue(i, gridColS4).ToString().Trim();
                    drDetail["S5"] = gridView1.GetRowCellValue(i, gridColS5).ToString().Trim();
                    drDetail["S6"] = gridView1.GetRowCellValue(i, gridColS6).ToString().Trim();
                    drDetail["S7"] = gridView1.GetRowCellValue(i, gridColS7).ToString().Trim();
                    drDetail["S8"] = gridView1.GetRowCellValue(i, gridColS8).ToString().Trim();
                    drDetail["S9"] = gridView1.GetRowCellValue(i, gridColS9).ToString().Trim();
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD1)) != 0)
                    {
                        drDetail["D1"] = gridView1.GetRowCellValue(i, gridColD1).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD2)) != 0)
                    {
                        drDetail["D2"] = gridView1.GetRowCellValue(i, gridColD2).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD3)) != 0)
                    {
                        drDetail["D3"] = gridView1.GetRowCellValue(i, gridColD3).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD4)) != 0)
                    {
                        drDetail["D4"] = gridView1.GetRowCellValue(i, gridColD4).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD5)) != 0)
                    {
                        drDetail["D5"] = gridView1.GetRowCellValue(i, gridColD5).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD6)) != 0)
                    {
                        drDetail["D6"] = gridView1.GetRowCellValue(i, gridColD6).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD7)) != 0)
                    {
                        drDetail["D7"] = gridView1.GetRowCellValue(i, gridColD7).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD8)) != 0)
                    {
                        drDetail["D8"] = gridView1.GetRowCellValue(i, gridColD8).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD9)) != 0)
                    {
                        drDetail["D9"] = gridView1.GetRowCellValue(i, gridColD9).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate1)).ToString().Trim() != "")
                    {
                        drDetail["Date1"] = gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate2)).ToString().Trim() != "")
                    {
                        drDetail["Date2"] = gridView1.GetRowCellValue(i, gridColDate2).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate3)).ToString().Trim() != "")
                    {
                        drDetail["Date3"] = gridView1.GetRowCellValue(i, gridColDate3).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate4)).ToString().Trim() != "")
                    {
                        drDetail["Date4"] = gridView1.GetRowCellValue(i, gridColDate4).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate5)).ToString().Trim() != "")
                    {
                        drDetail["Date5"] = gridView1.GetRowCellValue(i, gridColDate5).ToString().Trim();
                    }
                    if ((gridView1.GetRowCellValue(i, gridColDate6)).ToString().Trim() != "")
                    {
                        drDetail["Date6"] = gridView1.GetRowCellValue(i, gridColDate6).ToString().Trim();
                    }
                    dtDetail.Rows.Add(drDetail);
                }
                //if (d出差金额 <= 0)
                //{
                //    sErr = sErr + "至少有一项出差金额";
                //}

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (sState == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                    aList.Add(sSQL);

                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dtDetail, i);
                        aList.Add(sSQL);
                    }
                }
                if (sState == "edit")
                {
                    sSQL = "delete " + tablenames + " where iCodeHead = '" + textEdit单据号.Text.Trim() +"'";
                    aList.Add(sSQL);

                    sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                    aList.Add(sSQL);

                    for (int i = 0; i < dtDetail.Rows.Count; i++)
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dtDetail, i);
                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                    textEditiID.EditValue = iID;
                    GetSelBind();
                    sState = "save";
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能审核");
            }
            int iReturn = CheState(textEdit单据号.Text.Trim());
            if (iReturn == -1)
            {
                throw new Exception("检查单据状态失败");
            }
            if (iReturn == 0)
            {
                throw new Exception("该单据不存在");
            }
            //if (iReturn == 1)
            //{
            //    throw new Exception("该单据已保存");
            //}
            if (iReturn == 2)
            {
                throw new Exception("该单据已审核");
            }
            if (iReturn == 3)
            {
                throw new Exception("该单据已关闭");
            }
            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysPerson ='" + 系统服务.ClsBaseDataInfo.sUid + "',dVerifysysTime = '" + 系统服务.ClsBaseDataInfo.sLogDate + "' where iCode = '" + textEdit单据号.Text.Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
                textEdit审核人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit审核日期.Text = 系统服务.ClsBaseDataInfo.sLogDate;

                sState = "audit";
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能弃审");
            }
            int iReturn = CheState(textEdit单据号.Text.Trim());
            if (iReturn == -1)
            {
                throw new Exception("检查单据状态失败");
            }
            if (iReturn == 0)
            {
                throw new Exception("该单据不存在");
            }
            if (iReturn == 1)
            {
                throw new Exception("该单据未审核");
            }
            //if (iReturn == 2)
            //{
            //    throw new Exception("该单据已审核");
            //}
            if (iReturn == 3)
            {
                throw new Exception("该单据已关闭");
            }
            aList = new System.Collections.ArrayList();
            sSQL = "update " + tablename + " set dVerifysysPerson =null,dVerifysysTime =null where iCode = '" + textEdit单据号.Text.Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");
                textEdit审核人.EditValue = DBNull.Value;
                dateEdit审核日期.EditValue = DBNull.Value;
                sState = "unaudit";
            }
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

        private void Frm出差登记_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                if (iID != -1)
                {
                    GetGrid();
                }
                else
                {
                    btnLast();
                }
                SetEnabled(false);
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            if (iID != -1)
            {
                sSQL = "select * from " + tablename + " where ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditiID.Text = dt.Rows[0]["ID"].ToString();
                    textEdit单据号.EditValue = dt.Rows[0]["iCode"].ToString();
                    dateEdit单据日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dDate"]);
                    textEditdMemo.EditValue = dt.Rows[0]["dMemo"].ToString();


                    dateEditTT1.EditValue = ReturnDateTimeString(dt.Rows[0]["TT1"]);

                    buttonEditSS1.EditValue = dt.Rows[0]["SS1"].ToString();
                    buttonEditSS2.EditValue = dt.Rows[0]["SS2"].ToString();
                    
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();

                    dateEdit制单日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dCreatesysTime"]);
                    dateEdit审核日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dVerifysysTime"]);

                    sSQL = "select * from " + tablenames + " where iCodeHead='" + dt.Rows[0]["iCode"].ToString().Trim() + "'";
                    DataTable dtGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtGrid;
                    gridView1.AddNewRow();

                    SetEnabled(false);
                }
                else
                {
                    GetNull();
                    SetEnabled(false);
                }

            }
            else
            {
                GetNull();
                SetEnabled(false);
            }
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.Person(lookUpEditSS1);
            系统服务.LookUp.Department(lookUpEditSS2);

            系统服务.LookUp.Customer(ItemLookUpEdit客户);
            系统服务.LookUp.CustomersIntentionality(ItemLookUpEdit意向性客户);
            系统服务.LookUp.DistrictClass(ItemLookUpEdit区域);
            系统服务.LookUp._LoopUpData(ItemLookUpEdit跟踪情况, "17");
            系统服务.LookUp.Competitors(ItemLookUpEdit竞争对手);
        }

        private void SetEnabled(bool b)
        {
            textEditiID.Enabled = false;
            textEdit单据号.Enabled = false;
            dateEdit单据日期.Enabled = b;
            textEditdMemo.Enabled = b;

            dateEditTT1.Enabled = b;

            buttonEditSS1.Enabled = b;
            buttonEditSS2.Enabled = b;
        
            lookUpEditSS1.Enabled = false;
            lookUpEditSS2.Enabled = false;

            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;
            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;

            gridView1.OptionsBehavior.Editable = b;
        }

        private void GetNull()
        {
            textEditiID.EditValue = DBNull.Value;
            textEdit单据号.EditValue = DBNull.Value; 
            dateEdit单据日期.EditValue = DBNull.Value;
            textEditdMemo.EditValue = DBNull.Value;

            dateEditTT1.EditValue = DBNull.Value;

            buttonEditSS1.EditValue = DBNull.Value;
            buttonEditSS2.EditValue = DBNull.Value;
          
            lookUpEditSS1.EditValue = DBNull.Value;
            lookUpEditSS2.EditValue = DBNull.Value;

            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            textEdit制单人.EditValue = DBNull.Value;
            textEdit审核人.EditValue = DBNull.Value;

            sSQL = "select * from " + tablenames + " where 1=-1";
            DataTable dtGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtGrid;
            gridView1.AddNewRow();
        }

        private void buttonEditSS1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEditSS1.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEditSS2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEditSS2.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEditSS1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditSS1.Text.Trim() != "")
            {
                lookUpEditSS1.EditValue = buttonEditSS1.Text.Trim();
                if (lookUpEditSS1.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.PersonDepartment(buttonEditSS1.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEditSS2.EditValue = dt.Rows[0]["cDepCode"];
                    }
                }
            }
            else
                lookUpEditSS1.EditValue = null;
        }

        private void buttonEditSS1_Leave(object sender, EventArgs e)
        {
            if (buttonEditSS1.Text.Trim() == "")
                return;
            if (lookUpEditSS1.Text.Trim() == "")
            {
                buttonEditSS1.Text = "";
                buttonEditSS1.Focus();
            }
        }

        private void buttonEditSS2_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditSS2.Text.Trim() != "")
                lookUpEditSS2.EditValue = buttonEditSS2.Text.Trim();
            else
                lookUpEditSS2.EditValue = null;
        }

        private void buttonEditSS2_Leave(object sender, EventArgs e)
        {
            if (buttonEditSS2.Text.Trim() == "")
                return;
            if (lookUpEditSS2.Text.Trim() == "")
            {
                buttonEditSS2.Text = "";
                buttonEditSS2.Focus();
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
        private int CheState(string sCode)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,'' as 关闭人 from " + tablename + " where " + tableid + " = '" + sCode + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dt.Rows[0]["制单人"].ToString().Trim() != "")
                    {
                        iReturn = 1;
                    }
                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        iReturn = 2;
                    }
                    if (dt.Rows[0]["关闭人"].ToString().Trim() != "")
                    {
                        iReturn = 3;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        private void ItemButtonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColS1, frm.sID);
                frm.Enabled = true;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColS1 && gridView1.GetRowCellValue(e.RowHandle, gridColS2).ToString().Trim() != "")
                {

                    string s1 = gridView1.GetRowCellValue(e.RowHandle, gridColS1).ToString().Trim();
                    gridView1.SetRowCellValue(e.RowHandle, gridColS2, s1);
                    if (gridView1.GetRowCellDisplayText(e.RowHandle, gridColS2).ToString().Trim() == "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColS1, "");
                    }

                    if (s1 != "")
                    {
                        sSQL = "select isnull(a.cDCCode,'') as 区域,isnull(b.PersonName,'') as 业务员 from dbo.Customer a left join person b on a.cCusPPerson = b.PersonCode where a.cCusCode = '" + gridView1.GetRowCellValue(e.RowHandle, gridColS2).ToString().Trim() + "' ";
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridColS4, dt.Rows[0]["区域"].ToString().Trim());
                            gridView1.SetRowCellValue(e.RowHandle, gridColS8, dt.Rows[0]["业务员"].ToString().Trim());
                        }
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColS4, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColS8, "");
                    }
                }

                if (e.Column == gridColS3)
                {
                    string s3 = gridView1.GetRowCellValue(e.RowHandle, gridColS3).ToString().Trim();
                    if (s3 != "")
                    {
                        sSQL = "select isnull(a.s6,'')  as 区域,isnull(b.PersonName,'') as 业务员 from dbo.CustomersIntentionality a left join person b on a.cintPerson = b.PersonCode where iCode = '" + s3 + "' ";
                        //string s = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();
                        //if (s != "")
                        //{
                        //    gridView1.SetRowCellValue(e.RowHandle, gridColS4, s);
                        //}
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridColS4, dt.Rows[0]["区域"].ToString().Trim());
                            gridView1.SetRowCellValue(e.RowHandle, gridColS8, dt.Rows[0]["业务员"].ToString().Trim());
                        }
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColS4, "");
                        gridView1.SetRowCellValue(e.RowHandle, gridColS8, "");
                    }
                }

                if (e.Column == gridColS4)
                {
                    string s = gridView1.GetRowCellValue(e.RowHandle, gridColS4).ToString().Trim();
                    sSQL = "select D1 from DistrictClass where cDCCode = '" + s + "' ";
                    decimal d = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                    gridView1.SetRowCellValue(e.RowHandle, gridColD1, d);
                }

                if (e.Column == gridColS5 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColS5).ToString().Trim() != "")
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

        private void ItemButtonEdit意向性客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(14);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColS3, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEdit意向性客户_Leave(object sender, EventArgs e)
        {
            if (gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridColS3).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol意向性客户, "");
            }
        }

        private void ItemButtonEdit区域_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(4);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColS4, frm.sID);
                frm.Enabled = true;
            }
        }

        private void ItemButtonEdit区域_Leave(object sender, EventArgs e)
        {
            if (gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridColS4).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol区域编码, "");
            }
        }
    }
}
