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
    public partial class Frm业务费申请 : 系统服务.FrmBaseInfo
    {
        string tablename = "OperationalCosts";
        string tableid = "iCode";
        string tablenames = "OperationalCostsDetails";
        long iID = -1;
        public string iCode1;
        public string iCode2;
        public string dDate1;
        public string dDate2;
        public string SS1;
        public string SS2;
        public string SS3;

        public Frm业务费申请(long siID)
        {
            iID = siID;
            InitializeComponent();
        }

        public Frm业务费申请()
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
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
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
            Frm业务费申请_Add frm = new Frm业务费申请_Add(iCode1, iCode2, dDate1, dDate2, SS1, SS2, SS3);
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
            if (dDate1 != null && dDate1 != "")
            {
                sSQL = sSQL + " and dDate >= '" + dDate1 + "'";
            }
            if (dDate2 != null && dDate2 != "")
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
            sSQL = sSQL + "  order by iCode";
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
                MessageBox.Show("加载数据失败：" + ee.Message );
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
            catch (Exception ee)
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
            throw new NotImplementedException();
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
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            GetNull();
            SetEnabled(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
            //dateEditTT1.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            sSQL = "select *,'edit' as iSave  from " + tablenames + " where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            try
            {
                gridView1.FocusedColumn = gridColD5;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;

            gridView1.OptionsBehavior.Editable = true;

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
                throw new Exception("没有单据号，不能删除");
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
                try
                {
                    if (iID != -1)
                    {
                        sSQL = "delete " + tablename + " where ID = '" + textEditiID.EditValue.ToString().Trim() + "' ";
                        aList.Add(sSQL);

                        sSQL = "delete " + tablenames + " where ID = '" + textEditiID.EditValue.ToString().Trim() + "' ";
                        aList.Add(sSQL);
                        if (sState != "add")
                        {
                            int iCou = clsSQLCommond.ExecSqlTran(aList);
                            MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                            btnPrev();
                        }
                        else
                        {
                            MessageBox.Show("新增状态下不可删除");
                        }
                    }
                    else
                    {
                        MessageBox.Show("未选中，下不可删除");
                    }
                }
                catch
                {
                    MessageBox.Show("删除失败！");
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

                if (dateEdit1.EditValue == null || dateEdit1.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("报销开始日期不可为空");
                }

                if (dateEdit2.EditValue == null || dateEdit2.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("报销结束日期不可为空");
                }

                dr["ID"] = textEditiID.Text;
                dr["iCode"] = textEdit单据号.EditValue.ToString().Trim();

                dr["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
                dr["dMemo"] = textEditdMemo.EditValue.ToString().Trim();

                dr["SS1"] = lookUpEditSS1.EditValue.ToString().Trim();
                dr["SS2"] = lookUpEditSS2.EditValue.ToString().Trim();

                dr["TT1"] = dateEdit1.EditValue.ToString().Trim();
                dr["TT2"] = dateEdit2.EditValue.ToString().Trim();


                dr["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
                dr["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();

                dt.Rows.Add(dr);
                if (sState == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                    aList.Add(sSQL);
                }
                if (sState == "edit")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                    aList.Add(sSQL);
                }

                sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
                long autoid = long.Parse(clsSQLCommond.ExecQuery(sSQL).Rows[0][0].ToString());

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColD5).ToString().Trim() == "" )
                    {
                        continue;
                    }
                    DataRow drDetail = dtDetail.NewRow();
                    if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() == "")
                    {
                        drDetail["AutoID"] = autoid;
                        autoid = autoid + 1;
                    }
                    else
                    {
                        drDetail["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                    }
                    drDetail["ID"] = textEditiID.Text.Trim();
                    drDetail["S1"] = gridView1.GetRowCellValue(i, gridColS1).ToString().Trim();
                    drDetail["S2"] = gridView1.GetRowCellValue(i, gridColS2).ToString().Trim();
                    drDetail["S3"] = gridView1.GetRowCellValue(i, gridColS3).ToString().Trim();
                    drDetail["S4"] = gridView1.GetRowCellValue(i, gridColS4).ToString().Trim();
                    drDetail["S5"] = gridView1.GetRowCellValue(i, gridColS5).ToString().Trim();
                    drDetail["S6"] = gridView1.GetRowCellValue(i, gridColS6).ToString().Trim();
                    drDetail["S7"] = gridView1.GetRowCellValue(i, gridColS2_1).ToString().Trim();
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
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD10)) != 0)
                    {
                        drDetail["D10"] = gridView1.GetRowCellValue(i, gridColD10).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD11)) != 0)
                    {
                        drDetail["D11"] = gridView1.GetRowCellValue(i, gridColD11).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD12)) != 0)
                    {
                        drDetail["D12"] = gridView1.GetRowCellValue(i, gridColD12).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD13)) != 0)
                    {
                        drDetail["D13"] = gridView1.GetRowCellValue(i, gridColD13).ToString().Trim();
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i, gridColD14)) != 0)
                    {
                        drDetail["D14"] = gridView1.GetRowCellValue(i, gridColD14).ToString().Trim();
                    }
                    //if ((gridView1.GetRowCellValue(i, gridColDate1)).ToString().Trim() != "")
                    //{
                    //    drDetail["Date1"] = gridView1.GetRowCellValue(i, gridColDate1).ToString().Trim();
                    //}
                    //if ((gridView1.GetRowCellValue(i, gridColDate2)).ToString().Trim() != "")
                    //{
                    //    drDetail["Date2"] = gridView1.GetRowCellValue(i, gridColDate2).ToString().Trim();
                    //}
                    //if ((gridView1.GetRowCellValue(i, gridColDate3)).ToString().Trim() != "")
                    //{
                    //    drDetail["Date3"] = gridView1.GetRowCellValue(i, gridColDate3).ToString().Trim();
                    //}
                    //if ((gridView1.GetRowCellValue(i, gridColDate4)).ToString().Trim() != "")
                    //{
                    //    drDetail["Date4"] = gridView1.GetRowCellValue(i, gridColDate4).ToString().Trim();
                    //}
                    //if ((gridView1.GetRowCellValue(i, gridColDate5)).ToString().Trim() != "")
                    //{
                    //    drDetail["Date5"] = gridView1.GetRowCellValue(i, gridColDate5).ToString().Trim();
                    //}
                    //if ((gridView1.GetRowCellValue(i, gridColDate6)).ToString().Trim() != "")
                    //{
                    //    drDetail["Date6"] = gridView1.GetRowCellValue(i, gridColDate6).ToString().Trim();
                    //}
                    dtDetail.Rows.Add(drDetail);
                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dtDetail, dtDetail.Rows.Count - 1);
                        aList.Add(sSQL);
                    }
                    else if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dtDetail, dtDetail.Rows.Count - 1);
                        aList.Add(sSQL);
                    }

                }
                
                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                #region 表体不能为空
                bool b列表 = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColD5).ToString().Trim() != "")
                        b列表 = true;
                }
                if (!b列表)
                {
                    sErr = sErr + "表体不能为空";
                }

                if (sErr.Length != 0)
                {
                    throw new Exception(sErr.ToString());
                }
                if (dt == null || dt.Rows.Count <= 0)
                {
                    throw new Exception("表头不能为空");
                }
                bool b = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColD5).ToString().Trim() != "")
                    {
                        b = true;
                        break;
                    }
                }
                if (!b)
                {
                    throw new Exception("表体不能为空");
                }
                #endregion

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

        private void Frm业务费申请_Load(object sender, EventArgs e)
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

                    dateEdit1.EditValue = dt.Rows[0]["TT1"].ToString();
                    dateEdit2.EditValue = dt.Rows[0]["TT2"].ToString();
                    
                    buttonEditSS1.EditValue = dt.Rows[0]["SS1"].ToString();
                    buttonEditSS2.EditValue = dt.Rows[0]["SS2"].ToString();

                    
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();

                    dateEdit制单日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dCreatesysTime"]);
                    dateEdit审核日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dVerifysysTime"]);

                    sSQL = "select *,'edit' as iSave from " + tablenames + " where ID='" + dt.Rows[0]["ID"].ToString().Trim() + "'";
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
            sState = "sel";
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
        }

        private void SetEnabled(bool b)
        {
            textEditiID.Enabled = false;
            textEdit单据号.Enabled = false;
            dateEdit单据日期.Enabled = b;

            buttonEditSS1.Enabled = b;
            buttonEditSS2.Enabled = b;
            
            lookUpEditSS1.Enabled = false;
            lookUpEditSS2.Enabled = false;

            textEditdMemo.Enabled = b;

            dateEdit1.Enabled = b;
            dateEdit2.Enabled = b;

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


            buttonEditSS1.EditValue = DBNull.Value;
            buttonEditSS2.EditValue = DBNull.Value;
            
            lookUpEditSS1.EditValue = DBNull.Value;
            lookUpEditSS2.EditValue = DBNull.Value;

            textEditdMemo.EditValue = DBNull.Value;

            dateEdit1.EditValue = DBNull.Value;
            dateEdit2.EditValue = DBNull.Value;

            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            textEdit制单人.EditValue = DBNull.Value;
            textEdit审核人.EditValue = DBNull.Value;

            gridControl1.DataSource = null;
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

        
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;
            if (e.Column == gridColD1 || e.Column == gridColD2 || e.Column == gridColD4 || e.Column == gridColD6||e.Column == gridColD7)
            {
                decimal sum = 0;
                if (gridView1.GetRowCellValue(iRow, gridColD1) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD1));
                }
                if (gridView1.GetRowCellValue(iRow, gridColD2) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD2));
                }
                if (gridView1.GetRowCellValue(iRow, gridColD4) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD4));
                }
                if (gridView1.GetRowCellValue(iRow, gridColD6) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD6));
                }
                if (gridView1.GetRowCellValue(iRow, gridColD7) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD7));
                }
                gridView1.SetRowCellValue(iRow, gridColD5, sum);
            }

            if (e.Column == gridColD10 || e.Column == gridColD11 || e.Column == gridColD12 || e.Column == gridColD13 || e.Column == gridColD14 || e.Column == gridColD3)
            {
                decimal sum = 0;
                if (gridView1.GetRowCellValue(iRow, gridColD10) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD10));
                }
                if (gridView1.GetRowCellValue(iRow, gridColD11) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD11));
                }
                if (gridView1.GetRowCellValue(iRow, gridColD12) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD12));
                }
                if (gridView1.GetRowCellValue(iRow, gridColD13) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD13));
                }
                if (gridView1.GetRowCellValue(iRow, gridColD14) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD14));
                }
                if (gridView1.GetRowCellValue(iRow, gridColD3) != null)
                {
                    sum = sum + ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColD3));
                }
                gridView1.SetRowCellValue(iRow, gridColD1, sum);
            }

            #region
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            }
            if (e.Column != gridColiSave && e.Column != gridColD5 && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
            if (e.Column == gridColD5 && iRow == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(iRow, gridColD5).ToString().Trim() != "")
            {
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = iRow;
            }
            #endregion
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

        private void ItemButtonEdit客户_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ItemButtonEdit客户_Leave(object sender, EventArgs e)
        {

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
    }
}
