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

namespace 基础设置
{
    public partial class Frm贵金属每月单价 : 系统服务.FrmBaseInfo
    {
        string tablename = "PreciousMetals";
        string tableid = "iCode";
        long iID = -1;
        public string 单据号1;
        public string 单据号2;
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 年;



        public Frm贵金属每月单价(long siID)
        {
            iID = siID;
            InitializeComponent();
            
        }

        public Frm贵金属每月单价()
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
            Frm贵金属每月单价_Add frm = new Frm贵金属每月单价_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 年);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                单据号1 = frm.单据号1;
                单据号2 = frm.单据号2;
                单据日期1 = frm.单据日期1;
                单据日期2 = frm.单据日期2;
                年 = frm.年;
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
                sSQL = sSQL + " and convert(varchar(10),dDate,120)>=convert(varchar(10),'" + 单据日期1 + "',120)";
            }
            if (单据日期2 != "")
            {
                sSQL = sSQL + " and convert(varchar(10),dDate,120)<=convert(varchar(10),'" + 单据日期2 + "',120)";
            }
            if (年 != "")
            {
                sSQL = sSQL + " and S1 = '" + 年 + "'";
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
                GetGrid();
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
                    GetGrid();
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
                    GetGrid();
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
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditiID.Text = dt.Rows[0]["iID"].ToString();
                    iID = Convert.ToInt64(dt.Rows[0]["iID"]);
                }
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败：" + ee.Message);
            }
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
            GetShow(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;
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
            GetShow(true);
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
                if (lookUpEdit月.Text.Trim() == "")
                {
                    throw new Exception("月份不可为空");
                }
                int S1 = int.Parse(textEdit年.Text.Trim());
                if (S1 <= 2000 || S1 >= 2050)
                {
                    throw new Exception("年份不正确");
                }
                if (textEdit年.Text.Trim() == "")
                {
                    throw new Exception("年份不可为空");
                }
                if (textEdit贵金属单价.Text == "")
                {
                    throw new Exception("贵金属单价不可为空");
                }
                dr["iID"] = textEditiID.Text;
                dr["iCode"] = textEdit单据号.EditValue.ToString().Trim();

                dr["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

                dr["S1"] = textEdit年.EditValue.ToString().Trim();
                dr["S2"] = lookUpEdit月.EditValue.ToString().Trim();

                dr["D1"] = textEdit贵金属单价.Text.Trim();

                dr["Remark"] = textEdit备注.Text.Trim();
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
                    GetGrid();

                }

            }
            catch
            {
                throw new Exception("保存失败！");
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
            sSQL = "update "+tablename+" set dVerifysysPerson ='" + 系统服务.ClsBaseDataInfo.sUid + "',dVerifysysTime = '" + 系统服务.ClsBaseDataInfo.sLogDate + "' where iCode = '" + textEdit单据号.Text.Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
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
            sSQL = "update "+tablename+" set dVerifysysPerson =null,dVerifysysTime =null where iCode = '" + textEdit单据号.Text.Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
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

        private void Frm贵金属每月单价_Load(object sender, EventArgs e)
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
                GetShow(false);
                
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
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();

                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["Remark"].ToString();

                    lookUpEdit月.EditValue = dt.Rows[0]["S2"].ToString();
                    textEdit年.EditValue = dt.Rows[0]["S1"].ToString();
                    textEdit贵金属单价.EditValue = dt.Rows[0]["D1"].ToString();
                }
                else
                {
                    GetNull();
                }
            }
            else
            {
                GetNull();
            }
            GetShow(false);
            sState = "sel";
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp._LoopUpData(lookUpEdit月,"19");
        }

        private void GetShow(bool b)
        {
            dateEdit单据日期.Enabled = b;
            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;

            textEdit单据号.Enabled = false;
            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;
            textEdit备注.Enabled = b;

            textEdit贵金属单价.Enabled = b;
            lookUpEdit月.Enabled = b;
            textEdit年.Enabled = b;

        }

        private void GetNull()
        {
            dateEdit单据日期.EditValue = DBNull.Value;
            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;

            textEditiID.EditValue = "";
            textEdit单据号.EditValue = "";
            textEdit制单人.EditValue = "";
            textEdit审核人.EditValue = "";
            textEdit备注.EditValue = "";

            textEdit贵金属单价.EditValue = "";
            lookUpEdit月.EditValue = "";
            textEdit年.EditValue = "";
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

    }
}
