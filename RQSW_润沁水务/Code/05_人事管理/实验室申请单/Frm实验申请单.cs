using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 人事管理
{
    public partial class Frm实验申请单 : 系统服务.FrmBaseInfo
    {
        string tablename = "ExperimentApplications";
        string tableid = "申请单编号";
        long iID = -1;
        public string iCode1;
        public string iCode2;
        public string dDate1;
        public string dDate2;
        public string SS1;
        public string SS2;

        public Frm实验申请单(long siID)
        {
            iID = siID;
            InitializeComponent();
        }

        public Frm实验申请单()
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
            Frm实验申请单_Add frm = new Frm实验申请单_Add(iCode1, iCode2, dDate1, dDate2, SS1, SS2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                iCode1 = frm.iCode1;
                iCode2 = frm.iCode2;
                dDate1 = frm.dDate1;
                dDate2 = frm.dDate2;
                SS1 = frm.SS1;
                SS2 = frm.SS2;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " where 1=1";
            if (iCode1 != null && iCode1 != "")
            {
                sSQL = sSQL + " and " + tableid + ">='" + iCode1 + "'";
            }
            if (iCode2 != null && iCode2 != "")
            {
                sSQL = sSQL + " and " + tableid + "<='" + iCode2 + "'";
            }
            if (dDate1 != "")
            {
                sSQL = sSQL + " and 申请日期 >= '" + dDate1 + "'";
            }
            if (dDate2 != "")
            {
                sSQL = sSQL + " and 申请日期 <= '" + dDate2 + "'";
            }
            if (SS1 != null && SS1 != "")
            {
                sSQL = sSQL + " and 销售人员='" + SS1 + "'";
            }
            if (SS2 != null && SS2 != "")
            {
                sSQL = sSQL + " and 单位名称='" + SS2 + "'";
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
            dateEdit单据日期.EditValue = ReturnDateTimeString(系统服务.ClsBaseDataInfo.sLogDate);
            dateEdit实验日期.EditValue = ReturnDateTimeString(系统服务.ClsBaseDataInfo.sLogDate);

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
                    dateEdit制单日期.EditValue = ReturnDateTimeString(系统服务.ClsBaseDataInfo.sLogDate);
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

                if (dateEdit单据日期.EditValue == null || ReturnDateTimeString(dateEdit单据日期.EditValue) == "")
                {
                    throw new Exception("申请日期不可为空");
                }

                if (buttonEdit销售人员.EditValue == null || buttonEdit销售人员.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("销售人员不可为空");
                }

                if (textEdit单位名称.EditValue == null || textEdit单位名称.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("单位名称不可为空");
                }

                if (dateEdit实验日期.EditValue == null || ReturnDateTimeString(dateEdit实验日期.EditValue) == "")
                {
                    throw new Exception("实验日期不可为空");
                }

                dr["ID"] = textEditiID.EditValue.ToString().Trim();
                dr["申请日期"] = ReturnDateTimeString(dateEdit单据日期.EditValue);
                dr["申请单编号"] = textEdit单据号.EditValue.ToString().Trim();
                
                dr["销售人员"] = buttonEdit销售人员.EditValue.ToString().Trim();
                dr["紧急情况"] = radioGroup紧急情况.EditValue.ToString().Trim();
                dr["单位名称"] = textEdit单位名称.EditValue.ToString().Trim();
                dr["所属行业"] = lookUpEdit所属行业.EditValue.ToString().Trim();
                dr["月用量"] = textEdit月用量.EditValue.ToString().Trim();
                dr["有没有带回样品"] = radioGroup有没有带回样品.EditValue.ToString().Trim();
                dr["有没有带回污水污泥"] = radioGroup有没有带回污水污泥.EditValue.ToString().Trim();
                dr["竞争对手"] = textEdit竞争对手.EditValue.ToString().Trim();
                dr["型号"] = textEdit型号.EditValue.ToString().Trim();
                dr["价格"] = textEdit价格.EditValue.ToString().Trim();
                dr["阴离子"] = checkEdit阴离子.EditValue.ToString().Trim();
                dr["非离子"] = checkEdit非离子.EditValue.ToString().Trim();
                dr["阳离子"] = checkEdit阳离子.EditValue.ToString().Trim();
                dr["自然沉降"] = checkEdit自然沉降.EditValue.ToString().Trim();
                dr["汽浮"] = checkEdit汽浮.EditValue.ToString().Trim();
                dr["其它前段设备"] = textEdit其它前段设备.EditValue.ToString().Trim();
                dr["板框机"] = checkEdit板框机.EditValue.ToString().Trim();
                dr["离心机"] = checkEdit离心机.EditValue.ToString().Trim();
                dr["带机"] = checkEdit带机.EditValue.ToString().Trim();
                dr["其它后段压泥设备"] = textEdit其它后段压泥设备.EditValue.ToString().Trim();
                dr["台数"] = textEdit台数.EditValue.ToString().Trim();
                dr["带机是否有混凝缸"] = radioGroup带机是否有混凝缸.EditValue.ToString().Trim();
                dr["管道反应"] = textEdit管道反应.EditValue.ToString().Trim();
                dr["其它混凝缸"] = textEdit其它混凝缸.EditValue.ToString().Trim();
                dr["手动添加"] = checkEdit手动添加.EditValue.ToString().Trim();
                dr["自动添加"] = checkEdit自动添加.EditValue.ToString().Trim();
                dr["其它添加剂工艺"] = textEdit其它添加剂工艺.EditValue.ToString().Trim();
                dr["现场泡药时间"] = textEdit现场泡药时间.EditValue.ToString().Trim();
                dr["PAC"] = checkEditPAC.EditValue.ToString().Trim();
                dr["酸"] = checkEdit酸.EditValue.ToString().Trim();
                dr["碱"] = checkEdit碱.EditValue.ToString().Trim();
                dr["铝铁"] = checkEdit铝铁.EditValue.ToString().Trim();
                dr["碱铝"] = checkEdit碱铝.EditValue.ToString().Trim();
                dr["石灰"] = checkEdit石灰.EditValue.ToString().Trim();
                dr["其它药剂"] = textEdit其它药剂.EditValue.ToString().Trim();
                dr["销售人员对实验的要求"] = textEdit销售人员对实验的要求.EditValue.ToString().Trim();
                dr["实验详细过程"] = textEdit实验详细过程.EditValue.ToString().Trim();
                dr["实验结论"] = textEdit实验结论.EditValue.ToString().Trim();
                dr["实验人员"] = textEdit实验人员.EditValue.ToString().Trim();
                dr["实验日期"] = ReturnDateTimeString(dateEdit实验日期.EditValue);


                dr["dCreatesysTime"] = ReturnDateTimeString(dateEdit制单日期.EditValue);
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

            sSQL = "update " + tablename + " set dVerifysysPerson ='" + 系统服务.ClsBaseDataInfo.sUid + "',dVerifysysTime = '" + ReturnDateTimeString(系统服务.ClsBaseDataInfo.sLogDate) + "' where " + tableid + " = '" + textEdit单据号.Text.Trim() + "'";
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
            sSQL = "update " + tablename + " set dVerifysysPerson =null,dVerifysysTime =null where " + tableid + " = '" + textEdit单据号.Text.Trim() + "'";
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

        private void Frm实验申请单_Load(object sender, EventArgs e)
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
                    textEdit单据号.EditValue = dt.Rows[0]["申请单编号"].ToString();
                    dateEdit单据日期.EditValue = ReturnDateTimeString(dt.Rows[0]["申请日期"]);

                    buttonEdit销售人员.EditValue = dt.Rows[0]["销售人员"].ToString();
                    radioGroup紧急情况.EditValue = dt.Rows[0]["紧急情况"].ToString();
                    textEdit单位名称.EditValue = dt.Rows[0]["单位名称"].ToString();
                    lookUpEdit所属行业.EditValue = dt.Rows[0]["所属行业"].ToString();
                    textEdit月用量.EditValue = dt.Rows[0]["月用量"].ToString();
                    radioGroup有没有带回样品.EditValue = dt.Rows[0]["有没有带回样品"].ToString();
                    radioGroup有没有带回污水污泥.EditValue = dt.Rows[0]["有没有带回污水污泥"].ToString();
                    textEdit竞争对手.EditValue = dt.Rows[0]["竞争对手"].ToString();
                    textEdit型号.EditValue = dt.Rows[0]["型号"].ToString();
                    textEdit价格.EditValue = dt.Rows[0]["价格"].ToString();
                    if (dt.Rows[0]["阴离子"].ToString() == "True")
                    {
                        checkEdit阴离子.Checked = true;
                    }
                    if (dt.Rows[0]["非离子"].ToString() == "True")
                    {
                        checkEdit非离子.Checked = true;
                    }
                    if (dt.Rows[0]["阳离子"].ToString() == "True")
                    {
                        checkEdit阳离子.Checked = true;
                    }
                    if (dt.Rows[0]["自然沉降"].ToString() == "True")
                    {
                        checkEdit自然沉降.Checked = true;
                    }
                    if (dt.Rows[0]["汽浮"].ToString() == "True")
                    {
                        checkEdit汽浮.Checked = true;
                    }
                    textEdit其它前段设备.EditValue = dt.Rows[0]["其它前段设备"].ToString();
                    if (dt.Rows[0]["板框机"].ToString() == "True")
                    {
                        checkEdit板框机.Checked = true;
                    }
                    if (dt.Rows[0]["离心机"].ToString() == "True")
                    {
                        checkEdit离心机.Checked = true;
                    }
                    if (dt.Rows[0]["带机"].ToString() == "True")
                    {
                        checkEdit带机.Checked = true;
                    }
                    textEdit其它后段压泥设备.EditValue = dt.Rows[0]["其它后段压泥设备"].ToString();
                    textEdit台数.EditValue = dt.Rows[0]["台数"].ToString();
                    radioGroup带机是否有混凝缸.EditValue = dt.Rows[0]["带机是否有混凝缸"].ToString();
                    textEdit管道反应.EditValue = dt.Rows[0]["管道反应"].ToString();
                    textEdit其它混凝缸.EditValue = dt.Rows[0]["其它混凝缸"].ToString();
                    if (dt.Rows[0]["手动添加"].ToString() == "True")
                    {
                        checkEdit手动添加.Checked = true;
                    }
                    if (dt.Rows[0]["自动添加"].ToString() == "True")
                    {
                        checkEdit自动添加.Checked = true;
                    }
                    textEdit其它添加剂工艺.EditValue = dt.Rows[0]["其它添加剂工艺"].ToString();
                    textEdit现场泡药时间.EditValue = dt.Rows[0]["现场泡药时间"].ToString();
                    if (dt.Rows[0]["PAC"].ToString() == "True")
                    {
                        checkEditPAC.Checked = true;
                    }
                    if (dt.Rows[0]["酸"].ToString() == "True")
                    {
                        checkEdit酸.Checked = true;
                    }
                    if (dt.Rows[0]["碱"].ToString() == "True")
                    {
                        checkEdit碱.Checked = true;
                    }
                    if (dt.Rows[0]["铝铁"].ToString() == "True")
                    {
                        checkEdit铝铁.Checked = true;
                    }
                    if (dt.Rows[0]["碱铝"].ToString() == "True")
                    {
                        checkEdit碱铝.Checked = true;
                    }
                    if (dt.Rows[0]["石灰"].ToString() == "True")
                    {
                        checkEdit石灰.Checked = true;
                    }
                    textEdit其它药剂.EditValue = dt.Rows[0]["其它药剂"].ToString();
                    textEdit销售人员对实验的要求.EditValue = dt.Rows[0]["销售人员对实验的要求"].ToString();
                    textEdit实验详细过程.EditValue = dt.Rows[0]["实验详细过程"].ToString();
                    textEdit实验结论.EditValue = dt.Rows[0]["实验结论"].ToString();
                    textEdit实验人员.EditValue = dt.Rows[0]["实验人员"].ToString();
                    dateEdit实验日期.EditValue = ReturnDateTimeString(dt.Rows[0]["实验日期"]);


                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();

                    dateEdit制单日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dCreatesysTime"]);
                    dateEdit审核日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dVerifysysTime"]);

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
            系统服务.LookUp.Person(lookUpEdit销售人员);
            系统服务.LookUp.TradeClass(lookUpEdit所属行业);
        }

        private void SetEnabled(bool b)
        {
            textEditiID.Enabled = false;
            textEdit单据号.Enabled = false;
            dateEdit单据日期.Enabled = b;
            buttonEdit销售人员.Enabled = b;
            radioGroup紧急情况.Enabled = b;
            textEdit单位名称.Enabled = b;
            lookUpEdit所属行业.Enabled = b;
            textEdit月用量.Enabled = b;
            radioGroup有没有带回样品.Enabled = b;
            radioGroup有没有带回污水污泥.Enabled = b;
            textEdit竞争对手.Enabled = b;
            textEdit型号.Enabled = b;
            textEdit价格.Enabled = b;
            checkEdit阴离子.Enabled = b;
            checkEdit非离子.Enabled = b;
            checkEdit阳离子.Enabled = b;
            checkEdit自然沉降.Enabled = b;
            checkEdit汽浮.Enabled = b;
            textEdit其它前段设备.Enabled = b;
            checkEdit板框机.Enabled = b;
            checkEdit离心机.Enabled = b;
            checkEdit带机.Enabled = b;
            textEdit其它后段压泥设备.Enabled = b;
            textEdit台数.Enabled = b;
            radioGroup带机是否有混凝缸.Enabled = b;
            textEdit管道反应.Enabled = b;
            textEdit其它混凝缸.Enabled = b;
            checkEdit手动添加.Enabled = b;
            checkEdit自动添加.Enabled = b;
            textEdit其它添加剂工艺.Enabled = b;
            textEdit现场泡药时间.Enabled = b;
            checkEditPAC.Enabled = b;
            checkEdit酸.Enabled = b;
            checkEdit碱.Enabled = b;
            checkEdit铝铁.Enabled = b;
            checkEdit碱铝.Enabled = b;
            checkEdit石灰.Enabled = b;
            textEdit其它药剂.Enabled = b;
            textEdit销售人员对实验的要求.Enabled = b;
            textEdit实验详细过程.Enabled = b;
            textEdit实验结论.Enabled = b;
            textEdit实验人员.Enabled = b;
            dateEdit实验日期.Enabled = b;
            lookUpEdit销售人员.Enabled = false;

            labelControl1.Enabled = b;
            labelControl2.Enabled = b;
            labelControl3.Enabled = b;
            labelControl4.Enabled = b;
            labelControl5.Enabled = b;

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

            buttonEdit销售人员.EditValue = "";
            radioGroup紧急情况.EditValue = "";
            textEdit单位名称.EditValue = "";
            lookUpEdit所属行业.EditValue = "";
            textEdit月用量.EditValue = "";
            radioGroup有没有带回样品.EditValue = "1";
            radioGroup有没有带回污水污泥.EditValue = "1";
            textEdit竞争对手.EditValue = "";
            textEdit型号.EditValue = "";
            textEdit价格.EditValue = "";
            checkEdit阴离子.Checked = false;
            checkEdit非离子.Checked = false;
            checkEdit阳离子.Checked = false;
            checkEdit自然沉降.Checked = false;
            checkEdit汽浮.Checked = false;
            textEdit其它前段设备.EditValue = "";
            checkEdit板框机.Checked = false;
            checkEdit离心机.Checked = false;
            checkEdit带机.Checked = false;
            textEdit其它后段压泥设备.EditValue = "";
            textEdit台数.EditValue = "";
            radioGroup带机是否有混凝缸.EditValue = "1";
            textEdit管道反应.EditValue = "";
            textEdit其它混凝缸.EditValue = "";
            checkEdit手动添加.Checked = false;
            checkEdit自动添加.Checked = false;
            textEdit其它添加剂工艺.EditValue = "";
            textEdit现场泡药时间.EditValue = "";
            checkEditPAC.Checked = false;
            checkEdit酸.Checked = false;
            checkEdit碱.Checked = false;
            checkEdit铝铁.Checked = false;
            checkEdit碱铝.Checked = false;
            checkEdit石灰.Checked = false;
            textEdit其它药剂.EditValue = "";
            textEdit销售人员对实验的要求.EditValue = "";
            textEdit实验详细过程.EditValue = "";
            textEdit实验结论.EditValue = "";
            textEdit实验人员.EditValue = "";
            dateEdit实验日期.EditValue = DBNull.Value;
            lookUpEdit销售人员.EditValue = "";

            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            textEdit制单人.EditValue = DBNull.Value;
            textEdit审核人.EditValue = DBNull.Value;
        }

        private void buttonEdit销售人员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit销售人员.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEdit销售人员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit销售人员.Text.Trim() != "")
                lookUpEdit销售人员.EditValue = buttonEdit销售人员.Text.Trim();
            else
                lookUpEdit销售人员.EditValue = null;
        }

        private void buttonEdit销售人员_Leave(object sender, EventArgs e)
        {
            if (buttonEdit销售人员.Text.Trim() == "")
                return;
            if (lookUpEdit销售人员.Text.Trim() == "")
            {
                buttonEdit销售人员.Text = "";
                buttonEdit销售人员.Focus();
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
    }
}
