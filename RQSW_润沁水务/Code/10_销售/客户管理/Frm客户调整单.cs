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

namespace 销售
{
    public partial class Frm客户调整单 : 系统服务.FrmBaseInfo
    {
        string tablename = "CustomersAdjust";
        string checktalbename = "Customer";
        string checktalbeID = "cCusCode";
        string tableid = "iCode";
         long iID = -1;
        public string 单据号1;
        public string 单据号2;
        public string 单据日期1;
        public string 单据日期2;
        public string 调整日期1;
        public string 调整日期2;
        public string 业务员;
        public string 部门;
        public string 客户;



        public Frm客户调整单(long siID)
        {
            iID = siID;
            InitializeComponent();
        }

        public Frm客户调整单()
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
            Frm客户调整单_Add frm = new Frm客户调整单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 调整日期1, 调整日期2, 业务员, 部门, 客户);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                单据号1 = frm.单据号1;
                单据号2 = frm.单据号2;
                单据日期1 = frm.单据日期1;
                单据日期2 = frm.单据日期2;
                调整日期1 = frm.调整日期1;
                调整日期2 = frm.调整日期2;
                业务员 = frm.业务员;
                部门 = frm.部门;
                客户 = frm.客户;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " where 1=1";
            if (单据号1 != null && 单据号1 != "")
            {
                sSQL = sSQL + " and iCode>='" + 单据号1 + "'";
            }
            if (单据号2 != null && 单据号2 != "")
            {
                sSQL = sSQL + " and iCode<='" + 单据号2 + "'";
            }
            if (单据日期1 != "")
            {
                sSQL = sSQL + " and dDate >= '" + 单据日期1 + "'";
            }
            if (单据日期2 != "")
            {
                sSQL = sSQL + " and dDate <= '" + 单据日期2 + "'";
            }
            if (调整日期2 != "")
            {
                sSQL = sSQL + " and aAdjAdjustTime>='" + 调整日期2 + "'";
            }
            if (调整日期2 != "")
            {
                sSQL = sSQL + " and aAdjAdjustTime<='" + 调整日期2 + "'";
            }
            if (业务员 != null && 业务员 != "")
            {
                sSQL = sSQL + " and aIntPerson='" + 业务员 + "'";
            }
            if (部门 != null && 部门 != "")
            {
                sSQL = sSQL + " and aIntDepCode='" + 部门 + "'";
            }
            if (客户 != null && 客户 != "")
            {
                sSQL = sSQL + " and aIntName='" + 客户 + "'";
            }
            sSQL = sSQL + "  order by iID";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            if (dtSel.Rows.Count > 0)
            {
                iID = Convert.ToInt64(dtSel.Rows[0]["iID"]);   
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
                sSQL = "select min(iID) as iID from " + tablename + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditiID.Text = dt.Rows[0]["iID"].ToString();
                    iID = Convert.ToInt64(dt.Rows[0]["iID"]);
                }
                GetSelBind();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (textEditiID.Text.Trim() == "")
                    return;

                if (iID != -1)
                {
                    sSQL = "select iID from " + tablename + " where iID<" + textEditiID.Text + " order by iID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditiID.Text = dt.Rows[0]["iID"].ToString();
                        iID = Convert.ToInt64(dt.Rows[0]["iID"]);
                    }
                    GetSelBind();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (textEditiID.Text.Trim() == "")
                    return;

                if (iID != -1)
                {
                    sSQL = "select iID from " + tablename + " where iID>" + textEditiID.Text + " order by iID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditiID.Text = dt.Rows[0]["iID"].ToString();
                        iID = Convert.ToInt64(dt.Rows[0]["iID"]);
                    }
                    GetSelBind();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                sSQL = "select max(iID) as iID from " + tablename + " ";
                iID = ReturnInt(clsSQLCommond.ExecGetScalar(sSQL));
                textEditiID.Text = iID.ToString();
                GetSelBind();
            }
            catch(Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            GetNull();
            SetEnabled(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
            dateEdit调整日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
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
            aList = new System.Collections.ArrayList();
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
                        sSQL = "delete " + tablename + " where iID = '" + textEditiID.EditValue.ToString().Trim() + "' ";
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

                sSQL = "select * from " + checktalbename + " where " + checktalbeID + "='" + buttonEdit客户编码.EditValue.ToString().Trim() + "'";
                DataTable dtcheck = clsSQLCommond.ExecQuery(sSQL);
                string sErr = "";

                if (dtcheck.Rows.Count > 0)
                {
                    aList = new System.Collections.ArrayList();
                    DataRow dr = dt.NewRow();
                    if (sState == "add")
                    {
                        sSQL = "select isnull(max(iID)+1,1) as iID from " + tablename;
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

                    if (textEdit联系人.EditValue.ToString().Trim() == "")
                    {
                        throw new Exception("联系人不可为空");
                    }

                    if (textEdit电话.EditValue.ToString().Trim() == "")
                    {
                        throw new Exception("联系电话不可为空");
                    }

                    if (lookUpEdit业务员.EditValue.ToString().Trim() != "")
                    {
                        decimal d1 = ReturnDecimal(textEditD1.EditValue.ToString().Trim());
                        if (d1 > 100 && d1 < 0)
                        {
                            throw new Exception("利润分成在0-100之间");
                        }
                        if (dateEditDate1.EditValue == null || dateEditDate1.EditValue.ToString().Trim() == "")
                        {
                            throw new Exception("开始时间不可为空");
                        }
                        if (dateEditDate2.EditValue == null || dateEditDate2.EditValue.ToString().Trim() == "")
                        {
                            throw new Exception("结束时间不可为空");
                        }
                    }

                    dr["iID"] = textEditiID.Text;
                    dr["iCode"] = textEdit单据号.EditValue.ToString().Trim();
                    
                    dr["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

                    dr["aIntCode"] = buttonEdit客户编码.EditValue.ToString().Trim();
                    dr["aIntName"] = textEdit客户名称.Text.Trim();

                    dr["aIntAbbName"] = textEdit简称.EditValue.ToString().Trim();
                    dr["aIntPerson"] = textEdit联系人.EditValue.ToString().Trim();
                    dr["aIntPhone"] = textEdit电话.EditValue.ToString().Trim();
                    dr["aIntPerson2"] = textEdit联系人2.EditValue.ToString().Trim();
                    dr["aIntPhone2"] = textEdit联系电话2.EditValue.ToString().Trim();

                    dr["aIntAddress"] = textEdit地址.EditValue.ToString().Trim();
                    dr["aIntEmail"] = textEdit邮件.EditValue.ToString().Trim();
                    dr["aIntRegCode"] = textEdit税号.EditValue.ToString().Trim();
                    dr["aIntAccount"] = textEdit银行账户.EditValue.ToString().Trim();
                    dr["aIntBank"] = textEdit开户行.EditValue.ToString().Trim();
                    dr["aIntLPerson"] = textEdit法人.EditValue.ToString().Trim();

                    dr["aIntCCode"] = lookUpEdit客户分类.EditValue.ToString().Trim();
                    dr["aIntTCode"] = lookUpEdit行业.EditValue.ToString().Trim();
                    dr["aIntDCCode"] = lookUpEdit地区.EditValue.ToString().Trim();
                    dr["aIntDepCode"] = lookUpEdit部门.EditValue.ToString().Trim();
                    dr["aIntPPerson"] = lookUpEdit业务员.EditValue.ToString().Trim();

                    dr["aIntAdjustTime"] = dateEdit调整日期.EditValue.ToString().Trim();
                    dr["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
                    dr["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();


                    dr["aIntPerson"] = textEdit联系人.Text.Trim();
                    dr["aIntPhone"] = textEdit电话.Text.Trim();
                    dr["aIntAddress"] = textEdit地址.Text.Trim();
                    dr["aIntEmail"] = textEdit邮件.Text.Trim();
                    dr["aIntBank"] = textEdit开户行.Text.Trim();
                    dr["aIntAccount"] = textEdit银行账户.Text.Trim();
                    dr["aIntRegCode"] = textEdit税号.Text.Trim();
                    dr["aIntLPerson"] = textEdit法人.Text.Trim();

                    dr["D1"] = textEditD1.EditValue;
                    dr["Date1"] = dateEditDate1.EditValue;
                    dr["Date2"] = dateEditDate2.EditValue;

                    dr["S1"] = lookUpEdit原业务员.EditValue.ToString().Trim();
                    dr["S2"] = lookUpEdit原部门.EditValue.ToString().Trim();
                    
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
                else
                {
                    throw new Exception("需变更的单据不存在");
                }

            }
            catch(Exception ee)
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

            sSQL = "update " + tablename + "  set dVerifysysPerson ='" + 系统服务.ClsBaseDataInfo.sUid + "',dVerifysysTime = '" + 系统服务.ClsBaseDataInfo.sLogDate + "' where iCode = '" + textEdit单据号.Text.Trim() + "'";
            aList.Add(sSQL);

            #region 调整SQL

            sSQL = "select * from Customer where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr = dt.NewRow();
            dr["cCusCode"] = buttonEdit客户编码.EditValue;
            dr["cCusName"] = textEdit客户名称.EditValue;
            dr["cCusAbbName"] = textEdit简称.EditValue;
            dr["cCCCode"] = lookUpEdit客户分类.EditValue;
            dr["cDCCode"] = lookUpEdit地区.EditValue;
            dr["cTrade"] = lookUpEdit行业.EditValue;
            dr["cCusPerson"] = textEdit联系人.EditValue;
            dr["cCusPhone"] = textEdit电话.EditValue;
            dr["cCusPerson2"] = textEdit联系人2.EditValue;
            dr["cCusPhone2"] = textEdit联系电话2.EditValue;
            dr["cCusAddress"] = textEdit地址.EditValue;
            dr["cCusEmail"] = textEdit邮件.EditValue;
            dr["cCusRegCode"] = textEdit税号.EditValue;
            dr["cCusAccount"] = textEdit银行账户.EditValue;
            dr["cCusBank"] = textEdit开户行.EditValue;
            dr["cCusLPerson"] = textEdit法人.EditValue;
            dr["cCusDepart"] = lookUpEdit部门.EditValue;
            dr["cCusPPerson"] = lookUpEdit业务员.EditValue;

            dr["D1"] = textEditD1.EditValue;
            dr["Date1"] = dateEditDate1.EditValue;
            dr["Date2"] = dateEditDate2.EditValue;

            dt.Rows.Add(dr);

            sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "Customer", dt, dt.Rows.Count - 1);
            aList.Add(sSQL);
            #endregion

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
                textEdit审核人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit审核日期.Text = 系统服务.ClsBaseDataInfo.sLogDate;
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
            sSQL = "update " + tablename + "  set dVerifysysPerson =null,dVerifysysTime =null where iCode = '" + textEdit单据号.Text.Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n注意：弃审单据不能刷新客户档案\n合计执行语句:" + iCou + "条");
                textEdit审核人.EditValue = DBNull.Value;
                dateEdit审核日期.EditValue = DBNull.Value;
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

        private void Frm客户调整单_Load(object sender, EventArgs e)
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
                sSQL = "select * from " + tablename + " where iID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditiID.Text = dt.Rows[0]["iID"].ToString();
                    textEdit单据号.EditValue = dt.Rows[0]["iCode"].ToString();

                    buttonEdit客户编码.EditValue = dt.Rows[0]["aIntCode"].ToString();
                    textEdit客户名称.EditValue = dt.Rows[0]["aIntName"].ToString();

                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit调整日期.EditValue = dt.Rows[0]["aIntAdjustTime"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();

                    textEdit简称.EditValue = dt.Rows[0]["aIntAbbName"].ToString();
                    textEdit联系人.EditValue = dt.Rows[0]["aIntPerson"].ToString();
                    textEdit电话.EditValue = dt.Rows[0]["aIntPhone"].ToString();

                    textEdit联系人2.EditValue = dt.Rows[0]["aIntPerson2"].ToString();
                    textEdit联系电话2.EditValue = dt.Rows[0]["aIntPhone2"].ToString();
                    textEdit地址.EditValue = dt.Rows[0]["aIntAddress"].ToString();
                    textEdit邮件.EditValue = dt.Rows[0]["aIntEmail"].ToString();
                    textEdit税号.EditValue = dt.Rows[0]["aIntRegCode"].ToString();
                    textEdit银行账户.EditValue = dt.Rows[0]["aIntAccount"].ToString();
                    textEdit开户行.EditValue = dt.Rows[0]["aIntBank"].ToString();
                    textEdit法人.EditValue = dt.Rows[0]["aIntLPerson"].ToString();
                    buttonEdit业务员.EditValue = dt.Rows[0]["aIntPPerson"].ToString();
                    buttonEdit部门.EditValue = dt.Rows[0]["aIntDepCode"].ToString();
                    buttonEdit地区.EditValue = dt.Rows[0]["aIntDCCode"].ToString();

                    buttonEdit客户分类.EditValue = dt.Rows[0]["aIntCCode"].ToString();
                    lookUpEdit客户分类.EditValue = dt.Rows[0]["aIntCCode"].ToString();
                    lookUpEdit行业.EditValue = dt.Rows[0]["aIntTCode"].ToString();
                    lookUpEdit地区.EditValue = dt.Rows[0]["aIntDCCode"].ToString();
                    lookUpEdit部门.EditValue = dt.Rows[0]["aIntDepCode"].ToString();
                    lookUpEdit业务员.EditValue = dt.Rows[0]["aIntPPerson"].ToString();

                    buttonEdit原业务员.EditValue = dt.Rows[0]["S1"];
                    lookUpEdit原业务员.EditValue = dt.Rows[0]["S1"];

                    buttonEdit原部门.EditValue = dt.Rows[0]["S2"];
                    lookUpEdit原部门.EditValue = dt.Rows[0]["S2"];

                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();

                    textEditD1.EditValue = dt.Rows[0]["D1"].ToString();
                    dateEditDate1.EditValue = dt.Rows[0]["Date1"].ToString();
                    dateEditDate2.EditValue = dt.Rows[0]["Date2"].ToString();
                

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
            系统服务.LookUp.DistrictClass(lookUpEdit地区);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.CustomerClass(lookUpEdit客户分类);
            系统服务.LookUp.TradeClass(lookUpEdit行业);

            系统服务.LookUp.Person(lookUpEdit原业务员);

            系统服务.LookUp.Department(lookUpEdit原部门);
        }

        private void SetEnabled(bool b)
        {
            textEditiID.Enabled = false;
            textEdit单据号.Enabled = false;
            dateEdit单据日期.Enabled = b;
            buttonEdit客户编码.Enabled = b;
            textEdit客户名称.Enabled = b;
            textEdit简称.Enabled = b;
            buttonEdit客户分类.Enabled = b;
            lookUpEdit客户分类.Enabled = false;
            lookUpEdit行业.Enabled = b;
            buttonEdit地区.Enabled = b;
            lookUpEdit地区.Enabled = false;
            textEdit联系人.Enabled = b;
            textEdit电话.Enabled = b;
            textEdit联系人2.Enabled = b;
            textEdit联系电话2.Enabled = b;
            textEdit地址.Enabled = b;
            textEdit邮件.Enabled = b;
            textEdit开户行.Enabled = b;
            textEdit银行账户.Enabled = b;
            textEdit税号.Enabled = b;
            textEdit法人.Enabled = b;
            buttonEdit业务员.Enabled = b;
            lookUpEdit业务员.Enabled = false;
            buttonEdit部门.Enabled = b;
            lookUpEdit部门.Enabled = false;
            dateEdit调整日期.Enabled = b;
            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;
            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;

            buttonEdit原业务员.Enabled = b;
            lookUpEdit原业务员.Enabled = false;
            buttonEdit原部门.Enabled = b;
            lookUpEdit原部门.Enabled = false;

            textEditD1.Enabled = b;
            dateEditDate1.Enabled = b;
            dateEditDate2.Enabled = b;
        }

        private void GetNull()
        {
            textEditiID.EditValue = DBNull.Value;
            textEdit单据号.EditValue = DBNull.Value; 
            dateEdit单据日期.EditValue = DBNull.Value;
            buttonEdit客户编码.EditValue = DBNull.Value;
            textEdit客户名称.EditValue = DBNull.Value;
            textEdit简称.EditValue = DBNull.Value;
            buttonEdit客户分类.EditValue = DBNull.Value;
            lookUpEdit客户分类.EditValue = DBNull.Value;
            lookUpEdit行业.EditValue = DBNull.Value;
            buttonEdit地区.EditValue = DBNull.Value;
            lookUpEdit地区.EditValue = DBNull.Value;
            textEdit联系人.EditValue = DBNull.Value;
            textEdit电话.EditValue = DBNull.Value;
            textEdit联系人2.EditValue = DBNull.Value;
            textEdit联系电话2.EditValue = DBNull.Value;
            textEdit地址.EditValue = DBNull.Value;
            textEdit邮件.EditValue = DBNull.Value;
            textEdit开户行.EditValue = DBNull.Value;
            textEdit银行账户.EditValue = DBNull.Value;
            textEdit税号.EditValue = DBNull.Value;
            textEdit法人.EditValue = DBNull.Value;
            buttonEdit业务员.EditValue = DBNull.Value;
            lookUpEdit业务员.EditValue = DBNull.Value;
            buttonEdit部门.EditValue = DBNull.Value;
            lookUpEdit部门.EditValue = DBNull.Value;
            dateEdit调整日期.EditValue = DBNull.Value;
            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            textEdit制单人.EditValue = DBNull.Value;
            textEdit审核人.EditValue = DBNull.Value;

            buttonEdit原业务员.EditValue = DBNull.Value;
            lookUpEdit原业务员.EditValue = DBNull.Value;
            buttonEdit原部门.EditValue = DBNull.Value;
            lookUpEdit原部门.EditValue = DBNull.Value;
            

            textEditD1.EditValue = DBNull.Value;
            dateEditDate1.EditValue = DBNull.Value;
            dateEditDate2.EditValue = DBNull.Value;
        }

        private void buttonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit业务员.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEdit客户分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(5);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户分类.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit地区_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(4);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit地区.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit部门.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
            {
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
                if (lookUpEdit业务员.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.PersonDepartment(buttonEdit业务员.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"];
                    }
                }
            }
            else
                lookUpEdit业务员.EditValue = null;
        }

        private void buttonEdit业务员_Leave(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() == "")
                return;
            if (lookUpEdit业务员.Text.Trim() == "")
            {
                buttonEdit业务员.Text = "";
                buttonEdit业务员.Focus();
            }
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
        }

        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() == "")
                return;
            if (lookUpEdit部门.Text.Trim() == "")
            {
                buttonEdit部门.Text = "";
                buttonEdit部门.Focus();
            }
        }

        private void buttonEdit地区_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit地区.Text.Trim() != "")
                lookUpEdit地区.EditValue = buttonEdit地区.Text.Trim();
            else
                lookUpEdit地区.EditValue = null;
        }

        private void buttonEdit地区_Leave(object sender, EventArgs e)
        {
            if (buttonEdit地区.Text.Trim() == "")
                return;
            if (lookUpEdit地区.Text.Trim() == "")
            {
                buttonEdit地区.Text = "";
                buttonEdit地区.Focus();
            }
        }

        private void buttonEdit客户分类_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户分类.Text.Trim() != "")
                lookUpEdit客户分类.EditValue = buttonEdit客户分类.Text.Trim();
            else
                lookUpEdit客户分类.EditValue = null;
        }

        private void buttonEdit客户分类_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户分类.Text.Trim() == "")
                return;
            if (lookUpEdit客户分类.Text.Trim() == "")
            {
                buttonEdit客户分类.Text = "";
                buttonEdit客户分类.Focus();
            }
        }

        private void buttonEdit客户编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户编码.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit客户编码_EditValueChanged(object sender, EventArgs e)
        {

            if (buttonEdit客户编码.Text.Trim() != "")
            {
                if (sState == "add" || sState == "edit")
                {
                    sSQL = "select * from Customer where cCusCode = '" + buttonEdit客户编码.Text.Trim() + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt == null || dt.Rows.Count < 1)
                        return;

                    textEdit客户名称.EditValue = dt.Rows[0]["cCusName"];
                    textEdit简称.EditValue = dt.Rows[0]["cCusAbbName"];

                    buttonEdit客户分类.EditValue = dt.Rows[0]["cCCCode"];
                    lookUpEdit客户分类.EditValue = dt.Rows[0]["cCCCode"];
                    lookUpEdit行业.EditValue = dt.Rows[0]["cTrade"];
                    buttonEdit地区.EditValue = dt.Rows[0]["cCCCode"];
                    lookUpEdit地区.EditValue = dt.Rows[0]["cCCCode"];
                    textEdit联系人.EditValue = dt.Rows[0]["cCusPerson"];
                    textEdit电话.EditValue = dt.Rows[0]["cCusPhone"];
                    textEdit地址.EditValue = dt.Rows[0]["cCusAddress"];
                    textEdit邮件.EditValue = dt.Rows[0]["cCusEmail"];
                    textEdit开户行.EditValue = dt.Rows[0]["cCusBank"];
                    textEdit银行账户.EditValue = dt.Rows[0]["cCusAccount"];
                    textEdit税号.EditValue = dt.Rows[0]["cCusRegCode"];
                    textEdit法人.EditValue = dt.Rows[0]["cCusLPerson"];
                    buttonEdit业务员.EditValue = dt.Rows[0]["cCusPPerson"];
                    lookUpEdit业务员.EditValue = dt.Rows[0]["cCusPPerson"];
                    buttonEdit部门.EditValue = dt.Rows[0]["cCusDepart"];
                    lookUpEdit部门.EditValue = dt.Rows[0]["cCusDepart"];

                    buttonEdit原业务员.EditValue = dt.Rows[0]["cCusPPerson"];
                    lookUpEdit原业务员.EditValue = dt.Rows[0]["cCusPPerson"];

                    buttonEdit原部门.EditValue = dt.Rows[0]["cCusDepart"];
                    lookUpEdit原部门.EditValue = dt.Rows[0]["cCusDepart"];

                    textEditD1.EditValue = dt.Rows[0]["D1"];
                    dateEditDate1.EditValue = dt.Rows[0]["Date1"];
                    dateEditDate2.EditValue = dt.Rows[0]["Date2"];
                }
            }
            else
            {
                textEdit客户名称.EditValue = null;
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

        private void buttonEdit原业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit原业务员.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEdit原业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit原业务员.Text.Trim() != "")
            {
                lookUpEdit原业务员.EditValue = buttonEdit原业务员.Text.Trim();
                if (lookUpEdit原业务员.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.PersonDepartment(buttonEdit原业务员.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEdit原部门.EditValue = dt.Rows[0]["cDepCode"];
                    }
                }
            }
            else
                lookUpEdit原业务员.EditValue = null;
        }

        private void buttonEdit原业务员_Leave(object sender, EventArgs e)
        {
            if (buttonEdit原业务员.Text.Trim() == "")
                return;
            if (lookUpEdit原业务员.Text.Trim() == "")
            {
                buttonEdit原业务员.Text = "";
                buttonEdit原业务员.Focus();
            }
        }

        private void buttonEdit原部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit原部门.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit原部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit原部门.Text.Trim() != "")
                lookUpEdit原部门.EditValue = buttonEdit原部门.Text.Trim();
            else
                lookUpEdit原部门.EditValue = null;
        }

        private void buttonEdit原部门_Leave(object sender, EventArgs e)
        {
            if (buttonEdit原部门.Text.Trim() == "")
                return;
            if (lookUpEdit原部门.Text.Trim() == "")
            {
                buttonEdit原部门.Text = "";
                buttonEdit原部门.Focus();
            }
        }

    }
}
