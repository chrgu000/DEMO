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
    public partial class Frm意向性客户登记单 : 系统服务.FrmBaseInfo
    {
        string tablename = "CustomersIntentionality";
        string tableid = "iCode";
        long iID = -1;
        public string 单据号1;
        public string 单据号2;
        public string 单据日期1;
        public string 单据日期2;
        public string 部门;
        public string 客户全称;
        public string 人员编码;



        public Frm意向性客户登记单(long siID)
        {
            iID = siID;
            InitializeComponent();

        }

        public Frm意向性客户登记单()
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
            Frm意向性客户登记单_Add frm = new Frm意向性客户登记单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 部门, 客户全称, 人员编码);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                单据号1 = frm.单据号1;
                单据号2 = frm.单据号2;
                单据日期1 = frm.单据日期1;
                单据日期2 = frm.单据日期2;
                部门 = frm.部门;
                客户全称 = frm.客户全称;
                人员编码 = frm.业务员;
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
            if (单据日期1 != null && 单据日期1 != "")
            {
                sSQL = sSQL + " and convert(varchar(10),dDate,120)>=convert(varchar(10),'" + 单据日期1 + "',120)";
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                sSQL = sSQL + " and convert(varchar(10),dDate,120)<=convert(varchar(10),'" + 单据日期2 + "',120)";
            }
            if (部门 != null && 部门 != "")
            {
                sSQL = sSQL + " and cIntDept='" + 部门 + "'";
            }
            if (客户全称 != null && 客户全称 != "")
            {
                sSQL = sSQL + " and cIntName like '%" + 客户全称 + "%'";
            }
            if (人员编码 != null && 人员编码 != "")
            {
                sSQL = sSQL + " and cIntPerson='" + 人员编码 + "'";
            }
            sSQL = sSQL + "  order by iID";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            if (dtSel.Rows.Count > 0)
            {
                iID = Convert.ToInt64(dtSel.Rows[0]["iID"]);;
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
                sSQL = "select isnull(min(iID),-1) as iID from " + tablename + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                textEditiID.Text = iID.ToString();
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
                sSQL = "select isnull(max(iID),-1) as iID from " + tablename + " ";
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                textEditiID.Text = iID.ToString();
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
            dateEdit登记日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
            sState = "add";
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            int iReturn = CheState(textEdit单据号.Text.Trim());
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
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            int iReturn = CheState(textEdit单据号.Text.Trim());
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

            DialogResult result = MessageBox.Show("是否删除单据" + textEdit单据号.Text.Trim(), "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (iID != -1)
                    {
                        sSQL = "select * from " + tablename + " where 1=-1";
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        string sErr = "";

                        aList = new System.Collections.ArrayList();
                        DataRow dr = dt.NewRow();
                        dr["iID"] = textEditiID.Text.ToString().Trim();
                        dr["iCode"] = textEdit单据号.EditValue.ToString().Trim();

                        dt.Rows.Add(dr);

                        if (sState != "add")
                        {
                            sSQL = clsGetSQL.GetDeleteSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, dt.Rows.Count - 1);
                            aList.Add(sSQL);
                            int iCou = clsSQLCommond.ExecSqlTran(aList);
                            MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");

                            sState = "del";
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
            string sErr = "";

            sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            //if (lookUpEdit业务员.Text.Trim() == "")
            //    throw new Exception("业务员不能为空");
            //if (lookUpEdit部门.Text.Trim() == "")
            //    throw new Exception("部门不能为空");
            if (textEdit客户全称.Text.Trim() == "")
                throw new Exception("客户全称不能为空");

            aList = new System.Collections.ArrayList();
            DataRow dr = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select * from " + tablename + " where cIntName='" + textEdit客户全称.EditValue.ToString().Trim() + "' and convert(varchar(10),dCreatesysTime,120)>convert(varchar(10),'" + DateTime.Now.AddMonths(-3) + "',120)";
                DataTable dtchk = clsSQLCommond.ExecQuery(sSQL);
                if (dtchk.Rows.Count > 0)
                {
                    throw new Exception("三月内已有此客户登记");
                }
                

                sSQL = "select isnull(max(iID)+1,1) as iID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                dr["iID"] = iID;
                textEdit单据号.Text = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
                dr["iCode"] = textEdit单据号.Text.Trim();
            }
            else
            {
                int iReturn = CheState(textEdit单据号.Text.Trim());
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

                dr["iID"] = textEditiID.Text;
                dr["iCode"] = textEdit单据号.EditValue.ToString().Trim();
            }
            dr["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            if (lookUpEdit业务员.EditValue != null)
            {
                dr["cIntPerson"] = lookUpEdit业务员.EditValue.ToString().Trim();
            }
            if (lookUpEdit部门.EditValue != null)
            {
                dr["cIntDept"] = lookUpEdit部门.EditValue.ToString().Trim();
            }
            if (textEdit客户编码.EditValue != null && textEdit客户编码.Text.Trim() != "")
            {
                sSQL = "select * from Customer where cCusCode='" + textEdit客户编码.EditValue.ToString().Trim() + "'";
                DataTable dtcus = clsSQLCommond.ExecQuery(sSQL);
                if (dtcus.Rows.Count == 0)
                {
                    throw new Exception("客户档案中无此客户编码");
                }
                dr["cIntCode"] = textEdit客户编码.EditValue.ToString().Trim();
            }
            dr["cIntName"] = textEdit客户全称.EditValue.ToString().Trim();

            dr["cIntRegDate"] = dateEdit登记日期.EditValue.ToString().Trim();
            dr["Remark"] = textEdit备注.EditValue.ToString().Trim();
            dr["S1"] = textEdit联系人.EditValue.ToString().Trim();
            dr["S2"] = textEdit联系电话.EditValue.ToString().Trim();
            dr["S3"] = textEdit联系地址.EditValue.ToString().Trim();
            dr["S4"] = textEdit客户部门.EditValue.ToString().Trim();
            if (lookUpEdit客户状态.EditValue != null)
            {
                dr["S5"] = lookUpEdit客户状态.EditValue.ToString().Trim();
            }
            if (lookUpEdit区域.EditValue != null)
            {
                dr["S6"] = lookUpEdit区域.EditValue.ToString().Trim();
            }
            dr["S7"] = textEdit竞争对手.EditValue.ToString().Trim();

            if (textEdit月用量.EditValue != null)
            {
                try
                {
                    decimal d = decimal.Parse(textEdit月用量.EditValue.ToString().Trim());
                }
                catch
                {
                    throw new Exception("月用量必须为数字");
                }
                if (textEdit月用量.EditValue.ToString().Trim() != "" && ReturnDecimal(textEdit月用量.EditValue.ToString().Trim()) != 0)
                {
                    dr["D1"] = textEdit月用量.EditValue.ToString().Trim();
                }
            }
            if (textEdit竞争对手价格.EditValue != null)
            {
                try
                {
                    decimal d = decimal.Parse(textEdit竞争对手价格.EditValue.ToString().Trim());
                }
                catch
                {
                    throw new Exception("竞争对手价格必须为数字");
                }
                if (textEdit竞争对手价格.EditValue.ToString().Trim() != "" && ReturnDecimal(textEdit竞争对手价格.EditValue.ToString().Trim()) != 0)
                {
                    dr["D2"] = textEdit竞争对手价格.EditValue.ToString().Trim();
                }
            }
            if (sState == "add")
            {
                dr["dCreatesysTime"] = 系统服务.ClsBaseDataInfo.sLogDate;
                dr["dCreatesysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            }
            else
            {
                dr["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
                dr["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();
            }
            dt.Rows.Add(dr);
            if (sState == "add")
            {
                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                aList.Add(sSQL);
            }
            else
            {
                sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablename, dt, 0);
                aList.Add(sSQL);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");

                textEditiID.EditValue = iID;

                if (sState == "add")
                {
                    textEdit制单人.Text = 系统服务.ClsBaseDataInfo.sUid;
                    dateEdit制单日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
                }
                SetEnabled(false);
                sState = "save";
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
            int iReturn = CheState(textEdit单据号.Text.Trim());
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

            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能审核");
            }
            if (textEdit审核人.Text.Trim() != "")
            {
                throw new Exception("已经审核，不能审核");
            }
            sSQL = "update " + tablename + " set dVerifysysPerson ='" + 系统服务.ClsBaseDataInfo.sUid + "',dVerifysysTime = '" + 系统服务.ClsBaseDataInfo.sLogDate + "' where iCode = '" + textEdit单据号.Text.Trim() + "'";
            aList.Add(sSQL);


            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
                sState = "audit";

                textEdit审核人.Text = 系统服务.ClsBaseDataInfo.sUid;
                dateEdit审核日期.Text = 系统服务.ClsBaseDataInfo.sLogDate;
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            int iReturn = CheState(textEdit单据号.Text.Trim());
            if (iReturn == 0)
            {
                throw new Exception("该单据不存在");
            }
            if (iReturn == 1)
            {
                throw new Exception("该单据未审核");
            }
            if (iReturn == 3)
            {
                throw new Exception("该单据已关闭");
            }

            if (iID == -1)
            {
                throw new Exception("不可弃审");
            }

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + "  set dVerifysysPerson =null,dVerifysysTime =null where iCode = '" + textEdit单据号.Text.Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");

                sState = "unaudit";
                textEdit审核人.EditValue = null;
                dateEdit审核日期.EditValue = null;
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

        private void Frm意向性客户登记单_Load(object sender, EventArgs e)
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

                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit登记日期.EditValue = dt.Rows[0]["cIntRegDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    textEdit客户编码.EditValue = dt.Rows[0]["cIntCode"].ToString();
                    textEdit客户全称.EditValue = dt.Rows[0]["cIntName"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit备注.EditValue = dt.Rows[0]["Remark"].ToString();

                    lookUpEdit业务员.EditValue = dt.Rows[0]["cIntPerson"].ToString();
                    lookUpEdit部门.EditValue = dt.Rows[0]["cIntDept"].ToString();

                    buttonEdit部门.EditValue = dt.Rows[0]["cIntDept"].ToString();
                    buttonEdit业务员.EditValue = dt.Rows[0]["cIntPerson"].ToString();

                    textEdit联系人.EditValue = dt.Rows[0]["S1"].ToString();
                    textEdit联系电话.EditValue = dt.Rows[0]["S2"].ToString();
                    textEdit联系地址.EditValue = dt.Rows[0]["S3"].ToString();
                    textEdit客户部门.EditValue = dt.Rows[0]["S4"].ToString();
                    lookUpEdit客户状态.EditValue = ReturnInt(dt.Rows[0]["S5"].ToString());
                    buttonEdit区域.EditValue = dt.Rows[0]["S6"].ToString();

                    textEdit月用量.EditValue = ReturnDecimal(dt.Rows[0]["D1"].ToString());
                    textEdit竞争对手.EditValue = dt.Rows[0]["S7"].ToString();
                    textEdit竞争对手价格.EditValue = ReturnDecimal(dt.Rows[0]["D2"].ToString());
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
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);

            系统服务.LookUp.DistrictClass(lookUpEdit区域);


            //系统服务.LookUp._LoopUpData(lookUpEdit客户状态, "27");
            string sSQL = "select iID,iText,remark from dbo._LookUpDate where iType = '27' and isnull(bClose,1) = 1 order by iID";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit客户状态.Properties.DataSource = dt;
        }

        private void SetEnabled(bool b)
        {
            dateEdit单据日期.Enabled = b;
            dateEdit登记日期.Enabled = b;
            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;

            textEdit单据号.Enabled = false;

            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;
            textEdit备注.Enabled = b;
            textEdit客户全称.Enabled = b;

            lookUpEdit业务员.Enabled = false;
            lookUpEdit部门.Enabled = false;

            textEdit联系人.Enabled = b;
            textEdit联系电话.Enabled = b;
            textEdit客户编码.Enabled = b;
            textEdit联系地址.Enabled = b;

            buttonEdit部门.Enabled = b;
            buttonEdit业务员.Enabled = b;
            textEdit客户编码.Enabled = b;

            textEdit客户部门.Enabled = b;
            lookUpEdit客户状态.Enabled = b;
            buttonEdit区域.Enabled = b;
            lookUpEdit区域.Enabled = false;

            textEdit月用量.Enabled = b;
            textEdit竞争对手.Enabled = b;
            textEdit竞争对手价格.Enabled = b;
        }

        private void GetNull()
        {
            dateEdit单据日期.EditValue = DBNull.Value;
            dateEdit登记日期.EditValue = DBNull.Value;
            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;

            textEditiID.EditValue = "";
            textEdit单据号.EditValue = "";
            textEdit制单人.EditValue = "";
            textEdit审核人.EditValue = "";
            textEdit备注.EditValue = "";
            textEdit客户全称.EditValue = "";

            lookUpEdit业务员.EditValue = "";
            lookUpEdit部门.EditValue = "";

            buttonEdit部门.EditValue = null;
            buttonEdit业务员.EditValue = null;

            textEdit客户编码.EditValue = null;
            textEdit联系人.EditValue = "";
            textEdit联系电话.EditValue = "";
            textEdit联系地址.EditValue = "";
            textEdit客户部门.EditValue = "";
            lookUpEdit客户状态.EditValue = null;

            buttonEdit区域.EditValue = "";
            lookUpEdit区域.EditValue = "";

            textEdit月用量.EditValue = "";
            textEdit竞争对手.EditValue = "";
            textEdit竞争对手价格.EditValue = "";
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
            {
                lookUpEdit业务员.EditValue = null;
                buttonEdit部门.EditValue = null;
            }
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

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
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

        private void buttonEdit区域_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(4);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit区域.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit区域_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit区域.Text.Trim() != "")
                lookUpEdit区域.EditValue = buttonEdit区域.Text.Trim();
            else
                lookUpEdit区域.EditValue = "";
        }

        private void buttonEdit区域_Leave(object sender, EventArgs e)
        {
            if (buttonEdit区域.Text.Trim() == "")
                return;
            if (lookUpEdit区域.Text.Trim() == "")
            {
                buttonEdit区域.Text = "";
                buttonEdit区域.Focus();
            }
        }

        private void textEdit客户全称_EditValueChanged(object sender, EventArgs e)
        {
            sSQL = "select cCusCode from dbo.Customer where cCusName = '" + textEdit客户全称.EditValue.ToString().Trim() + "'";
            DataTable dtcus = clsSQLCommond.ExecQuery(sSQL);
            if (dtcus.Rows.Count > 0)
            {
                textEdit客户编码.EditValue = dtcus.Rows[0]["cCusCode"].ToString();
            }
        }

    }
}
