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
    public partial class Frm用人申请 : 系统服务.FrmBaseInfo
    {
        string tablename = "Employer";
        string tableid = "iCode";
        long iID = -1;
        public string iCode1;
        public string iCode2;
        public string dDate1;
        public string dDate2;
        public string SS1;
        public string SS2;
        public string SS3;

        public Frm用人申请(long siID)
        {
            iID = siID;
            InitializeComponent();
        }

        public Frm用人申请()
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
            Frm用人申请_Add frm = new Frm用人申请_Add(iCode1, iCode2, dDate1, dDate2, SS1, SS2, SS3);
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
            catch (Exception ee)
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
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
        }

        private void GetSelBind()
        {
            GetGrid();
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            GetNull();
            SetEnabled(true);
            dateEdit单据日期.EditValue = ReturnDateTimeString(系统服务.ClsBaseDataInfo.sLogDate);
            dateEditTT1.EditValue = ReturnDateTimeString(系统服务.ClsBaseDataInfo.sLogDate);
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

            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (iID != -1)
                    {
                        sSQL = "delete " + tablename + " where " + tableid + " = '" + textEditiID.EditValue.ToString().Trim() + "' ";
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

                if (dateEditTT1.EditValue == null || dateEditTT1.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("开始时间不可为空");
                }

                if (dateEditTT2.EditValue == null || dateEditTT2.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("结束时间不可为空");
                }

                if (dateEditTT2.DateTime < dateEditTT1.DateTime)
                {
                    throw new Exception("结束时间不能早于开始时间");
                }

                if (lookUpEditSS1.EditValue == null || lookUpEditSS1.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("申请人不可为空");
                }

                if (lookUpEditSS2.EditValue == null || lookUpEditSS2.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("申请人不可为空");
                }

                if (lookUpEditSS3.EditValue == null || lookUpEditSS3.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("技术员不可为空");
                }


                dr["ID"] = textEditiID.Text;
                dr["iCode"] = textEdit单据号.EditValue.ToString().Trim();

                dr["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

                dr["SS1"] = lookUpEditSS1.EditValue.ToString().Trim();
                dr["SS2"] = lookUpEditSS2.EditValue.ToString().Trim();
                dr["SS3"] = lookUpEditSS3.EditValue.ToString().Trim();
                dr["SS4"] = textEdit用人理由.EditValue.ToString().Trim();
                dr["SS5"] = textEdit备注.EditValue.ToString().Trim();

                dr["TT1"] = ReturnDateTimeString(dateEditTT1.EditValue);
                dr["TT2"] = ReturnDateTimeString(dateEditTT2.EditValue);

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
                dateEdit审核日期.Text = ReturnDateTimeString(系统服务.ClsBaseDataInfo.sLogDate);
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

        private void Frm用人申请_Load(object sender, EventArgs e)
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
            sSQL = "select * from " + tablename + " where ID=" + iID;
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                textEditiID.Text = dt.Rows[0]["ID"].ToString();
                textEdit单据号.EditValue = dt.Rows[0]["iCode"].ToString();
                dateEdit单据日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dDate"]);

                dateEditTT1.EditValue = ReturnDateTimeString(dt.Rows[0]["TT1"]);
                dateEditTT2.EditValue = ReturnDateTimeString(dt.Rows[0]["TT2"]);

                buttonEditSS1.EditValue = dt.Rows[0]["SS1"].ToString();
                buttonEditSS2.EditValue = dt.Rows[0]["SS2"].ToString();
                buttonEditSS3.EditValue = dt.Rows[0]["SS3"].ToString();

                textEdit用人理由.EditValue = dt.Rows[0]["SS4"].ToString();
                textEdit备注.EditValue = dt.Rows[0]["SS5"].ToString();

                textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();

                dateEdit制单日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dCreatesysTime"]);
                dateEdit审核日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dVerifysysTime"]);
            }
            else
            {
                GetNull();
            }
            SetEnabled(false);
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.Person(lookUpEditSS1);
            系统服务.LookUp.Department(lookUpEditSS2);
            系统服务.LookUp.Person(lookUpEditSS3);
        }

        private void SetEnabled(bool b)
        {
            textEditiID.Enabled = false;
            textEdit单据号.Enabled = false;
            dateEdit单据日期.Enabled = b;
            textEdit用人理由.Enabled = b;
            textEdit备注.Enabled = b;

            dateEditTT1.Enabled = b;
            dateEditTT2.Enabled = b;

            buttonEditSS1.Enabled = b;
            buttonEditSS2.Enabled = b;
            buttonEditSS3.Enabled = b;

            lookUpEditSS1.Enabled = false;
            lookUpEditSS2.Enabled = false;
            lookUpEditSS3.Enabled = false;

            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;
            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;
        }

        private void GetNull()
        {
            textEditiID.EditValue = DBNull.Value;
            textEdit单据号.EditValue = DBNull.Value; 
            dateEdit单据日期.EditValue = DBNull.Value;
            textEdit制单人.EditValue = DBNull.Value;
            textEdit备注.EditValue = DBNull.Value;
            textEdit用人理由.EditValue = DBNull.Value;
            textEdit备注.EditValue = DBNull.Value;

            dateEditTT1.EditValue = DBNull.Value;
            dateEditTT2.EditValue = DBNull.Value;

            buttonEditSS1.EditValue = DBNull.Value;
            buttonEditSS2.EditValue = DBNull.Value;
            buttonEditSS3.EditValue = DBNull.Value;
            
            lookUpEditSS1.EditValue = DBNull.Value;
            lookUpEditSS2.EditValue = DBNull.Value;
            lookUpEditSS3.EditValue = DBNull.Value;

            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            textEdit制单人.EditValue = DBNull.Value;
            textEdit审核人.EditValue = DBNull.Value;
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

        private void buttonEditSS3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEditSS3.EditValue = frm.sID;
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


        private void buttonEditSS3_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditSS3.Text.Trim() != "")
                lookUpEditSS3.EditValue = buttonEditSS3.Text.Trim();
            else
                lookUpEditSS3.EditValue = null;
        }

        private void buttonEditSS3_Leave(object sender, EventArgs e)
        {
            if (buttonEditSS3.Text.Trim() == "")
                return;
            if (lookUpEditSS3.Text.Trim() == "")
            {
                buttonEditSS3.Text = "";
                buttonEditSS3.Focus();
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
    }
}
