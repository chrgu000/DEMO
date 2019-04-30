using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 报表
{
    public partial class Frm订单部季报 : 系统服务.FrmBaseInfo
    {
        DateTime Date1;
        DateTime Date2;
        string tablename = "StatByQuarter";

        int i保底量;
        int i保底家数;
        int i保底收款;
        int i出货量;
        int i本期变更出货量;
        int i调整出货量;
        int i出货家数;
        int i收款;
        int i是否达成;
        int i调整规定出差费用;
        int i规定出差费用;
        int i业务招待费;
        int i本期变更业务招待费;
        int i调整业务招待费;
        int i规定业务招待费;
        int i业务招待费差额;
        int i规定出差费用扣款额;
        
        public Frm订单部季报()
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
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (radioGroup1.EditValue.ToString().Trim() == "1")
            {
                throw new Exception("按部门统计数据不可修改，请选择按人员");
            }
            sState = "edit";
            gridView1.OptionsBehavior.Editable = true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            sSQL = "select * from " + tablename + " where Quarter='" + lookUpEdit季度.EditValue.ToString().Trim() + "' and iYear = " + lookUpEdit年.EditValue + " ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            aList = new System.Collections.ArrayList();

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["dVerifysysPerson"].ToString() != "")
                {
                    throw new Exception("已有后续月份数据，请删除后再进行计算");
                }
                else
                {
                    sSQL = "delete  " + tablename + " where Quarter='" + lookUpEdit季度.EditValue.ToString().Trim() + "' and iYear = " + lookUpEdit年.EditValue + " ";
                    aList.Add(sSQL);

                    if (aList.Count > 0)
                    {
                        int iCou = clsSQLCommond.ExecSqlTran(aList);
                        MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");
                        GetGrid();

                    }
                }
            }
            else
            {
                throw new Exception("无本月数据");
            }
        }

        /// <summary>
        /// 新增 重新计算
        /// </summary>
        private void btnAdd()
        {
            DialogResult result = MessageBox.Show("是否计算当月考核数据，如果已有历史数据，会自动删除当月所有人员的考核数据?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                string sErr = "";
                if (lookUpEdit季度.Enabled && lookUpEdit季度.Text.Trim() == "")
                {
                    sErr = sErr + "计划类型月份不能为空\n";
                }

                if (sErr == "")
                {
                    string 部门 = "";
                    string 业务员 = "";
                    string s季度 = "";
                    string s年 = "";
                    if (lookUpEdit部门.EditValue != null)
                    {
                        部门 = lookUpEdit部门.EditValue.ToString().Trim();
                    }
                    if (lookUpEdit业务员.EditValue != null)
                    {
                        业务员 = lookUpEdit业务员.EditValue.ToString().Trim();
                    }
                    if (lookUpEdit季度.EditValue != null)
                    {
                        s季度 = lookUpEdit季度.EditValue.ToString().Trim();
                    }
                    if (lookUpEdit年.EditValue != null)
                    {
                        s年 = lookUpEdit年.EditValue.ToString().Trim();
                    }
                    string 统计方式 = "";
                    if (radioGroup1.EditValue != null)
                    {
                        统计方式 = radioGroup1.EditValue.ToString().Trim();
                    }
                    季报.Get(部门, 业务员, s年, s季度, 统计方式, true);
                }
                GetGrid();
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
            }
            catch { }

            int iRe = CheState();
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            //if (iRe == 0 && (sState == "edit" || sState == "alter"))
            //{
            //    throw new Exception("单据不存在");
            //}
            if (iRe == 1 && sState == "alter")
            {
                throw new Exception("单据未审核");
            }
            if (iRe == 2 && sState == "edit")
            {
                throw new Exception("单据已审核");
            }
            //if (iRe == 3)
            //{
            //    throw new Exception("单据已关闭");
            //}

            string sErr = "";

            try
            {
                GetSave();
            }
            catch
            {
                throw new Exception("保存失败");
            }

            if (sErr.Length != 0)
            {
                throw new Exception(sErr.ToString());
            }

        }

        private void GetSave()
        {

            string sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select S1 as cDepCode,S3 as PersonCode from SAPlan where 1=1 and I1=2 and I2='" + lookUpEdit季度.EditValue.ToString().Trim() + "' and s5 = '" + lookUpEdit年.EditValue.ToString().Trim() + "' ";
            DataTable dtsaplan = clsSQLCommond.ExecQuery(sSQL);


            System.Collections.ArrayList aList = new System.Collections.ArrayList();

            #region 子表
            string sErr="";
            dt = (DataTable)gridControl1.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].ColumnName != "统计项" && dt.Columns[j].ColumnName != "合计" && dt.Columns[j].ColumnName != "是否可修改")
                    {
                        sSQL = "select * from " + tablename + " where Quarter='" + lookUpEdit季度.EditValue.ToString().Trim() + "'  and iYear = " + lookUpEdit年.EditValue + " and PersonCode='" + dt.Columns[j].ColumnName + "' and iType='" + dt.Rows[i]["统计项"].ToString().Trim() + "'";
                        DataTable dtl = clsSQLCommond.ExecQuery(sSQL);
                        if (dtl.Rows.Count > 0)
                        {
                            sSQL = "update " + tablename + " set iValue2='" + dt.Rows[i][j].ToString() + "' where Quarter='" + lookUpEdit季度.EditValue.ToString().Trim() + "'  and iYear = " + lookUpEdit年.EditValue + "  and PersonCode='" + dt.Columns[j].ColumnName + "' and iType='" + dt.Rows[i]["统计项"].ToString().Trim() + "'";
                            aList.Add(sSQL);
                        }
                        else
                        {
                            sSQL = "insert into " + tablename + "(iYear, Quarter, PersonCode, iType, iValue2, dCreatesysTime) " +
                                "values(" + lookUpEdit年.EditValue + ",'" + lookUpEdit季度.EditValue.ToString().Trim() + "','" + dt.Columns[j].ColumnName + "','" + dt.Rows[i][j].ToString() + "','" + dt.Rows[i]["统计项"].ToString().Trim() + "','" + dateEdit制单日期.EditValue.ToString() + "')";
                            aList.Add(sSQL);
                        }


                    }
                }
            }
            #endregion

            if (sErr != "")
            {
                throw new Exception(sErr.ToString());
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
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
            
            int iRe = CheState();
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            //if (iRe == 1)
            //{
            //    throw new Exception("单据已保存");
            //} 
            if (iRe == 2)
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' " +
                    "where Quarter=" + lookUpEdit季度.EditValue.ToString().Trim() + " and iYear = " + lookUpEdit年.EditValue + " ";
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
            int iRe = CheState();
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            if (iRe == 1)
            {
                throw new Exception("单据未审核");
            }
            //if (iRe == 2)
            //{
            //    throw new Exception("单据已审核");
            //}
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            aList = new System.Collections.ArrayList();

            sSQL = "update " + tablename + " set dVerifysysTime=null,dVerifysysPerson=null " +
                    "where Quarter=" + lookUpEdit季度.EditValue.ToString().Trim() + " and iYear = " + lookUpEdit年.EditValue + " ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");
                textEdit审核人.Text = "";
                dateEdit审核日期.Text = "";
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

        private void Frm订单部季报_Load(object sender, EventArgs e)
        {
            try
            {
                
                SetLookUpEdit();
                lookUpEdit年.EditValue = DateTime.Now.Year.ToString();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp._LoopUpData(lookUpEdit季度, "34");
            系统服务.LookUp._LoopUpData(ItemLookUpEdit统计项, "33");
            系统服务.LookUp.Year(lookUpEdit年);

            radioGroup1.EditValue = "2";
            lookUpEdit部门.EditValue = "";
            lookUpEdit业务员.EditValue = "";
            lookUpEdit季度.EditValue = "";
        }

        private void GetGrid()
        {
            gridControl1.DataSource = null;
            DataTable dtnew = new DataTable();
            for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
            {
                gridView1.Columns.Remove(gridView1.Columns[i]);
            }

            if (lookUpEdit季度.EditValue!=null && lookUpEdit季度.EditValue.ToString().Trim() != "")
            {
                sSQL = "select * from " + tablename + " where Quarter='" + lookUpEdit季度.EditValue.ToString().Trim() + "' and iYear = " + lookUpEdit年.EditValue + "  ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count == 0)
                {
                    //throw new Exception("无当月数据,请点击计算得到当月数据");
                }
                else
                {
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    sSQL = "select * from " + tablename + " where Quarter='" + lookUpEdit季度.EditValue.ToString().Trim() + "' and iYear = " + lookUpEdit年.EditValue + "  ";
                    if (lookUpEdit部门.EditValue!=null && lookUpEdit部门.EditValue.ToString().Trim() != "")
                    {
                        sSQL = sSQL + " and cDepCode='" + lookUpEdit部门.EditValue.ToString().Trim() + "'";
                    }
                    if (lookUpEdit业务员.EditValue!=null && lookUpEdit业务员.EditValue.ToString().Trim() != "")
                    {
                        sSQL = sSQL + " and PersonCode='" + lookUpEdit业务员.EditValue.ToString().Trim() + "'";
                    }
                    DataTable dtstat = clsSQLCommond.ExecQuery(sSQL);


                    sSQL = "select S1 as cDepCode,S3 as PersonCode from SAPlan where 1=1 and I1=2 and I2='" + lookUpEdit季度.EditValue.ToString().Trim() + "' and s5 = '" + lookUpEdit年.EditValue.ToString().Trim() + "' ";
                    if (lookUpEdit部门.EditValue!=null && lookUpEdit部门.EditValue.ToString().Trim() != "")
                    {
                        sSQL = sSQL + " and S1='" + lookUpEdit部门.EditValue.ToString().Trim() + "'";
                    }
                    if (lookUpEdit业务员.EditValue!=null && lookUpEdit业务员.EditValue.ToString().Trim() != "")
                    {
                        sSQL = sSQL + " and S3='" + lookUpEdit业务员.EditValue.ToString().Trim() + "'";
                    }
                    DataTable dtsaplan = clsSQLCommond.ExecQuery(sSQL);

                    sSQL = "select S1 as cDepCode from SAPlan where 1=1 and I1=2 and I2='" + lookUpEdit季度.EditValue.ToString().Trim() + "' and s5 = '" + lookUpEdit年.EditValue.ToString().Trim() + "' ";
                    if (lookUpEdit部门.EditValue!=null && lookUpEdit部门.EditValue.ToString().Trim() != "")
                    {
                        sSQL = sSQL + " and S1='" + lookUpEdit部门.EditValue.ToString().Trim() + "'";
                    }
                    if (lookUpEdit业务员.EditValue!=null && lookUpEdit业务员.EditValue.ToString().Trim() != "")
                    {
                        sSQL = sSQL + " and S3='" + lookUpEdit业务员.EditValue.ToString().Trim() + "'";
                    }
                    sSQL = sSQL + " group by S1";
                    DataTable dtsaplandept = clsSQLCommond.ExecQuery(sSQL);

                    sSQL = "select iID, iText,bSystem as 是否可修改 from  _LookUpDate where iType=33 order by  Remark";
                    DataTable dtlook = clsSQLCommond.ExecQuery(sSQL);

                    dtnew.Columns.Add("统计项");
                    dtnew.Columns.Add("是否可修改");
                    if (radioGroup1.EditValue.ToString().Trim() == "1")
                    {
                        for (int j = 0; j < dtsaplandept.Rows.Count; j++)
                        {
                            dtnew.Columns.Add(dtsaplandept.Rows[j]["cDepCode"].ToString());
                        } 
                    }
                    else
                    {
                        for (int j = 0; j < dtsaplan.Rows.Count; j++)
                        {
                            dtnew.Columns.Add(dtsaplan.Rows[j]["PersonCode"].ToString());
                        }
                    }
                    dtnew.Columns.Add("合计");
                    for (int i = 0; i < dtlook.Rows.Count; i++)
                    {
                        DataRow dw = dtnew.NewRow();
                        dw["统计项"] = dtlook.Rows[i]["iID"].ToString();
                        dw["是否可修改"] = dtlook.Rows[i]["是否可修改"].ToString();
                        decimal sum = 0;
                        for (int j = 0; j < dtnew.Columns.Count; j++)
                        {
                            if (dtnew.Columns[j].ColumnName != "统计项" && dtnew.Columns[j].ColumnName != "合计" && dtnew.Columns[j].ColumnName != "是否可修改")
                            {
                                if (radioGroup1.EditValue.ToString().Trim() == "1")
                                {
                                    DataRow[] dw1 = dtstat.Select("cDepCode='" + dtnew.Columns[j].ColumnName + "' and iType='" + dtlook.Rows[i]["iID"].ToString() + "'");
                                    if (dw1.Length > 0)
                                    {
                                        decimal sum1 = 0;
                                        for (int s = 0; s < dw1.Length; s++)
                                        {
                                            sum1 = sum1 + ReturnDecimal(dw1[s]["iValue2"].ToString());
                                        }
                                        dw[j] = sum1;
                                        sum = sum + sum1;
                                    }
                                }
                                else
                                {
                                    DataRow[] dw1 = dtstat.Select("PersonCode='" + dtnew.Columns[j].ColumnName + "' and iType='" + dtlook.Rows[i]["iID"].ToString() + "'");
                                    if (dw1.Length > 0)
                                    {
                                        dw[j] = dw1[0]["iValue2"].ToString();
                                        sum = sum + ReturnDecimal(dw1[0]["iValue2"].ToString());
                                    }
                                }
                            }
                        }
                        if (sum != 0M)
                        {
                            dw["合计"] = sum;
                        }
                        dtnew.Rows.Add(dw);
                    }

                    sSQL = "select PersonCode,PersonName as Name from Person ";
                    DataTable dtper = clsSQLCommond.ExecQuery(sSQL);

                    sSQL = "select cDepCode, cDepName as Name from Department ";
                    DataTable dtdept = clsSQLCommond.ExecQuery(sSQL);

                    GetCol统计项();
                    GetCol是否可修改();
                    for (int i = 1; i < dtnew.Columns.Count; i++)
                    {
                        if (dtnew.Columns[i].ColumnName != "统计项" && dtnew.Columns[i].ColumnName != "合计" && dtnew.Columns[i].ColumnName != "是否可修改")
                        {
                            DataRow[] dw;
                            if (radioGroup1.EditValue.ToString().Trim() == "1")
                            {
                                dw = dtdept.Select("cDepCode='" + dtnew.Columns[i].ColumnName + "'");
                            }
                            else
                            {
                                dw = dtper.Select("PersonCode='" + dtnew.Columns[i].ColumnName + "'");
                            }

                            if (dw.Length > 0)
                            {
                                GetCol(dtnew.Columns[i].ColumnName, dw[0]["Name"].ToString().Trim(), dtnew.Columns[i].ColumnName);
                            }
                            else
                            {
                                GetCol(dtnew.Columns[i].ColumnName, dtnew.Columns[i].ColumnName, dtnew.Columns[i].ColumnName);
                            }
                        }
                    }
                    GetCol合计();
                    gridControl1.DataSource = dtnew;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        switch (gridView1.GetRowCellValue(i, "统计项").ToString().Trim())
                        {
                            case "11":
                                i保底量 = i;
                                break;
                            case "14":
                                i保底家数 = i;
                                break;
                            case "17":
                                i保底收款 = i;
                                break;
                            case "21":
                                i出货量 = i;
                                break;
                            case "22":
                                i本期变更出货量 = i;
                                break;
                            case "23":
                                i调整出货量 = i;
                                break;
                            case "24":
                                i出货家数 = i;
                                break;
                            case "27":
                                i收款 = i;
                                break;
                            case "31":
                                i是否达成 = i;
                                break;
                            case "101":
                                i规定出差费用 = i;
                                break;
                            case "100":
                                i调整规定出差费用 = i;
                                break;
                            case "102":
                                i规定出差费用扣款额 = i;
                                break;
                            case "111":
                                i业务招待费 = i;
                                break;
                            case "112":
                                i规定业务招待费 = i;
                                break;
                            case "113":
                                i业务招待费差额 = i;
                                break;
                            case "114":
                                i本期变更业务招待费 = i;
                                break;
                            case "115":
                                i调整业务招待费 = i;
                                break;
                        }
                    }
                    sState = "sel";
                }
            }
            gridView1.OptionsBehavior.Editable = false;
        }

        private void GetCol统计项()
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = "统计项";
            Col.Caption = "统计项";
            Col.Name = "gridCol统计项";
            Col.Width = 108;
            Col.Visible = true;
            Col.ColumnEdit = ItemLookUpEdit统计项;
            Col.OptionsColumn.AllowEdit = true;
            Col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            Col.OptionsColumn.ReadOnly = true;
            Col.VisibleIndex = 0;
            Col.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns.Add(Col);
        }

        private void GetCol是否可修改()
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = "是否可修改";
            Col.Caption = "是否可修改";
            Col.Name = "gridCol是否可修改";
            Col.Width = 108;
            Col.Visible = false;
            Col.OptionsColumn.AllowEdit = true;
            Col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            Col.OptionsColumn.ReadOnly = true;
            Col.VisibleIndex = 1;
            Col.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns.Add(Col);
        }

        private void GetCol合计()
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = "合计";
            Col.Caption = "合计";
            Col.Name = "gridCol合计";
            Col.Width = 108;
            Col.Visible = true;
            Col.OptionsColumn.AllowEdit = true;
            Col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            Col.OptionsColumn.ReadOnly = true;
            Col.VisibleIndex = gridView1.Columns.Count - 1;
            gridView1.Columns.Add(Col);
        }


        private void GetCol(string filename,string caption,string name)
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = filename;
            Col.Caption = caption;
            Col.Name = "gridCol" + name;
            Col.Width = 108;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count - 1;
            gridView1.Columns.Add(Col);
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                string s = gridView1.GetRowCellValue(iRow, "统计项").ToString().Trim();
                string col = gridView1.FocusedColumn.FieldName;
                if (s == "11" || s == "14" || s == "17" || s == "21" || s == "22" || s == "23" || s == "24" || s == "27" || s == "28")
                {
                    
                    string str = "达成";
                    decimal 保底量 = ReturnDecimal(gridView1.GetRowCellValue(i保底量, col));
                    decimal 保底家数 = ReturnDecimal(gridView1.GetRowCellValue(i保底家数, col));
                    decimal 保底收款 = ReturnDecimal(gridView1.GetRowCellValue(i保底收款, col));
                    decimal 出货量 = ReturnDecimal(gridView1.GetRowCellValue(i出货量, col));
                    decimal 本期变更出货量 = ReturnDecimal(gridView1.GetRowCellValue(i本期变更出货量, col));
                    decimal 调整出货量 = ReturnDecimal(gridView1.GetRowCellValue(i调整出货量, col));
                    decimal 出货家数 = ReturnDecimal(gridView1.GetRowCellValue(i出货家数, col));
                    decimal 收款 = ReturnDecimal(gridView1.GetRowCellValue(i收款, col));

                    if (保底量 > 出货量 + 本期变更出货量)
                    {
                        str = "未达成";
                    }
                    if (保底家数 > 出货家数)
                    {
                        str = "未达成";
                    }
                    if (保底收款 > 收款 + 调整出货量)
                    {
                        str = "未达成";
                    }
                    if (gridView1.GetRowCellValue(i是否达成, col).ToString().Trim() != str)
                    {
                        gridView1.SetRowCellValue(i是否达成, col, str);
                    }
                }
                #region 出差费用
                DataTable dt = (DataTable)gridControl1.DataSource;
                if (s == "21" || s == "22")
                {

                    decimal 出货 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='21'")[0][col]) + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='22'")[0][col]) + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='23'")[0][col]);
                    decimal 计划 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='1'")[0][col]);
                    decimal 费用 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='92'")[0][col]) + 系统服务.规格化.ReturnDecimal(dt.Select("统计项='93'")[0][col]);
                    decimal 原规定出差费用 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='101'")[0][col]);

                    if (计划 != 0)
                    {
                        decimal imoney = (出货 / 计划) * 费用;
                        if (ReturnDecimal(gridView1.GetRowCellValue(i调整规定出差费用, col)) != imoney)
                        {
                            gridView1.SetRowCellValue(i调整规定出差费用, col, imoney);
                        }
                    }
                    decimal sum调整规定出差费用 = 0;
                    for (int i = 1; i < gridView1.Columns.Count; i++)
                    {
                        if (gridView1.Columns[i].Caption != "统计项" && gridView1.Columns[i].Caption != "合计" && gridView1.Columns[i].Caption != "是否可修改")
                        {
                            sum调整规定出差费用 = sum调整规定出差费用 + ReturnDecimal(gridView1.GetRowCellValue(i调整规定出差费用, gridView1.Columns[i]));
                        }
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i规定出差费用扣款额, gridView1.Columns["合计"])) != sum调整规定出差费用)
                    {
                        gridView1.SetRowCellValue(i规定出差费用扣款额, gridView1.Columns["合计"], sum调整规定出差费用);
                    }
                }
                #endregion
                #region 业务招待费
                if (s == "111" || s == "112" || s == "114" || s == "115")
                {
                    decimal 业务招待费 = 0;
                    decimal 规定业务招待费 = 0;
                    decimal 本期变更业务招待费 = 0;
                    decimal 调整业务招待费 = 0;

                    if (dt.Select("统计项='111'")[0][col].ToString() != "")
                    {
                        业务招待费 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='111'")[0][col]);
                    }
                    if (dt.Select("统计项='112'")[0][col].ToString() != "")
                    {
                        规定业务招待费 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='112'")[0][col]);
                    }
                    if (dt.Select("统计项='114'")[0][col].ToString() != "")
                    {
                        本期变更业务招待费 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='114'")[0][col]);
                    }
                    if (dt.Select("统计项='115'")[0][col].ToString() != "")
                    {
                        调整业务招待费 = 系统服务.规格化.ReturnDecimal(dt.Select("统计项='115'")[0][col]);
                    }
                    decimal imoney = 规定业务招待费 - 业务招待费 - 本期变更业务招待费 - 调整业务招待费;
                    if (ReturnDecimal(gridView1.GetRowCellValue(i业务招待费差额, col)) != imoney)
                    {
                        gridView1.SetRowCellValue(i业务招待费差额, col, imoney);
                    }
                    decimal sum调整业务招待费 = 0;
                    decimal sum业务招待费差额 = 0;
                    for (int i = 1; i < gridView1.Columns.Count; i++)
                    {
                        if (gridView1.Columns[i].Caption != "统计项" && gridView1.Columns[i].Caption != "合计" && gridView1.Columns[i].Caption != "是否可修改")
                        {
                            sum调整业务招待费 = sum调整业务招待费 + ReturnDecimal(gridView1.GetRowCellValue(i调整业务招待费, gridView1.Columns[i]));
                            sum业务招待费差额 = sum业务招待费差额 + ReturnDecimal(gridView1.GetRowCellValue(i业务招待费差额, gridView1.Columns[i]));
                        }
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i调整业务招待费, gridView1.Columns["合计"])) != sum调整业务招待费)
                    {
                        gridView1.SetRowCellValue(i调整业务招待费, gridView1.Columns["合计"], sum调整业务招待费);
                    }
                    if (ReturnDecimal(gridView1.GetRowCellValue(i业务招待费差额, gridView1.Columns["合计"])) != sum业务招待费差额)
                    {
                        gridView1.SetRowCellValue(i业务招待费差额, gridView1.Columns["合计"], sum业务招待费差额);
                    }
                }
                #endregion
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


        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit部门.EditValue = frm.sID;
                frm.Enabled = true;
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

        private void buttonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit业务员.EditValue = frm.sID;

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

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroup1.EditValue.ToString().Trim() == "1")
            {
                buttonEdit业务员.EditValue = "";
                buttonEdit业务员.Enabled = false;
            }
            else
            {
                buttonEdit业务员.Enabled = true;
            }
            GetGrid();
        }

        /// 判断单据状态
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState()
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(dVerifysysPerson,'') as 审核人 from " + tablename + " where Quarter=" + lookUpEdit季度.EditValue.ToString().Trim() + " and iYear = " + lookUpEdit年.EditValue + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    iReturn = 1;
                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        iReturn = 2;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        private void lookUpEdit月_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                try
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                catch
                {
                }
                if (sState == "edit" && gridView1.GetRowCellValue(iRow, "是否可修改").ToString().Trim() == "0")
                {
                    gridView1.OptionsBehavior.Editable = true;
                }
                else
                {
                    gridView1.OptionsBehavior.Editable = false;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEdit年_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
