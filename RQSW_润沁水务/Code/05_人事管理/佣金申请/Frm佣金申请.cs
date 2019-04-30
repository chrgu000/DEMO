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
    public partial class Frm佣金申请 : 系统服务.FrmBaseInfo
    {
        string tablename = "Commission";
        string tableid = "iCode";
        string tablenames = "Commissions";

        long iID = -1;
        public string iCode1;
        public string iCode2;
        public string dDate1;
        public string dDate2;
        public string SS1;
        public string SS2;
        public string SS3;

        public string s销售订单号 = "";

        string isChange = "";

        public Frm佣金申请(long siID)
        {
            iID = siID;
            InitializeComponent();
        }

        public Frm佣金申请()
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
            Frm佣金申请_Add frm = new Frm佣金申请_Add(iCode1, iCode2, dDate1, dDate2, SS1, SS2, SS3);
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
            string sSQL = "select * from " + tablename + "  a left join " + tablenames + "  b on a.ID=b.ID where 1=1";
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
            DataTable dtt = (DataTable)gridControl1.DataSource;
            if (dtt.Rows.Count > 0)
            {
                s销售订单号 = dtt.Rows[0]["AutoID"].ToString();
            }
            else
            {
                s销售订单号 = "";
            }
            Frm销售订单_New frm = new Frm销售订单_New(buttonEditSS3.EditValue.ToString().Trim(), (DataTable)gridControl1.DataSource, s销售订单号);
            if (buttonEditSS3.EditValue == null)
                frm.客户 = "";
            else
                frm.客户 = buttonEditSS3.EditValue.ToString().Trim();

            if (DialogResult.OK == frm.ShowDialog())
            {
                if (frm.客户 != "")
                {
                    buttonEditSS3.Enabled = false;
                }
                //if (buttonEditSS3.EditValue != null && buttonEditSS3.EditValue != "" && frm.客户.Trim() != buttonEditSS3.EditValue.ToString().Trim() && frm.客户.Trim() != "")
                //{
                //    throw new Exception("一张单据只能有一个客户");
                //}

                if (s销售订单号 != "" && frm.销售订单号.Trim() != s销售订单号 && frm.销售订单号.Trim() != "")
                {
                    throw new Exception("一张单据只能有一张销售订单");
                }

                buttonEditSS3.EditValue = frm.客户;
                buttonEditSS1.EditValue = frm.业务员;
                buttonEditSS2.EditValue = frm.部门;
                s销售订单号 = frm.销售订单号;
                lookUpEditSS4.EditValue = frm.销售订单号;

                //sSQL = "select a.iMoney-b.iMoney as iMoney from (select cSOCode,sum(iMoney) as iMoney from SO_SODetails where cSOCode='" + s销售订单号 + "' group by cSOCode)"
                //+ "a left join (select cSOCode,isnull(sum(SO_SOOutDetails.iMoney),0) as iMoney  from SO_SOOutDetails left join SO_SODetails on SO_SOOutDetails.SoAutoID=SO_SODetails.AutoID where cSOCode='" + s销售订单号 + "' group by cSOCode) b on a.cSOCode=b.cSOCode";
                sSQL = @" select Date1 from SO_SOMain where cSOCode='" + s销售订单号 + "' ";

                DataTable dtm = clsSQLCommond.ExecQuery(sSQL);
                radioGroupSS5.EditValue = "0";
                if (dtm.Rows.Count > 0)
                {
                    if (dtm.Rows[0]["Date1"].ToString() != "")
                    {
                        radioGroupSS5.EditValue = "1";
                    }
                    else
                    {

                    }
                }

                frm.Enabled = true;
                DataTable dtnew = frm.dt;
                int i = gridView1.RowCount - 1;
                gridView1.FocusedRowHandle = i;
                for (int s = 0; s < dtnew.Rows.Count; s++)
                {
                    if (s != 0)
                    {
                        gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                        i = gridView1.RowCount - 1;
                    }
                    gridView1.SetRowCellValue(i, gridCol已申请金额, dtnew.Rows[s]["usedMoney"].ToString());

                    gridView1.SetRowCellValue(i, gridColSS1, dtnew.Rows[s]["SS1"].ToString());
                    gridView1.SetRowCellValue(i, gridColSS2, dtnew.Rows[s]["SS2"].ToString());
                    gridView1.SetRowCellValue(i, gridColSS3, dtnew.Rows[s]["SS3"].ToString());
                    gridView1.SetRowCellValue(i, gridColSS4, dtnew.Rows[s]["SS4"].ToString());
                    gridView1.SetRowCellValue(i, gridColSS5, dtnew.Rows[s]["SS5"].ToString());
                    

                    gridView1.SetRowCellValue(i, gridColCID, dtnew.Rows[s]["CID"].ToString());

                    gridView1.SetRowCellValue(i, gridColDD1, dtnew.Rows[s]["DD1"]);
                    gridView1.SetRowCellValue(i, gridColDD2, dtnew.Rows[s]["usedQty"]);

                    sSQL = "select * from Customer where cCusCode='" + buttonEditSS3.EditValue.ToString().Trim() + "' and cCusPerson='" + dtnew.Rows[s]["SS1"].ToString() + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(i, gridColSS6, dt.Rows[0]["cCusAccount"].ToString());
                        gridView1.SetRowCellValue(i, gridColSS7, dt.Rows[0]["cCusBank"].ToString());
                    }
                }

                
            }
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
                    if (gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim() != "")
                    {
                        if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
                        {
                            textEditDel.EditValue = textEditDel.EditValue.ToString().Trim() + "," + gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim();
                        }
                        else
                        {
                            textEditDel.EditValue = gridView1.GetRowCellDisplayText(i, gridColAutoID).ToString().Trim();
                        }
                    }
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

            sSQL = "select *,cast(0 as decimal(16,6)) as sCount, 'edit' as iSave  from " + tablenames + " where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            try
            {
                gridView1.FocusedColumn = gridColID;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;

            gridView1.OptionsBehavior.Editable = true;

            btnAddRow();

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
            //sSQL = "select isnull(sum(DD1),0) DD1 from " + tablename + " where SS4='" + lookUpEditSS4.EditValue.ToString().Trim() + "' ";
            //DataTable dtsss = clsSQLCommond.ExecQuery(sSQL);
            //if (dtsss.Rows.Count > 0)
            //{
            //    textEditDD2.EditValue = dtsss.Rows[0]["DD1"].ToString();
            //}
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

            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                try
                {
                    if (iID != -1)
                    {
                        sSQL = "delete from " + tablename + " where ID = '" + textEditiID.EditValue.ToString().Trim() + "' ";
                        aList.Add(sSQL);

                        sSQL = "delete from " + tablenames + " where ID = '" + textEditiID.EditValue.ToString().Trim() + "' ";
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
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                string sErr = "";

                sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
                long sID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));

                aList = new System.Collections.ArrayList();
                DataRow drh = dt.NewRow();
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
                if (lookUpEditSS4.EditValue == null || lookUpEditSS4.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("销售订单号不可为空");
                }

                if (lookUpEditSS1.EditValue == null || lookUpEditSS1.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("业务员不可为空");
                }

                if (lookUpEditSS2.EditValue == null || lookUpEditSS2.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("部门不可为空");
                }

                if (lookUpEditSS3.EditValue == null || lookUpEditSS3.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("客户不可为空");
                }

                if (radioGroupSS5.EditValue.ToString().Trim() == "0")
                {
                    if (dateEditTT1.EditValue == null || dateEditTT1.EditValue.ToString().Trim() == "")
                    {
                        throw new Exception("未回款申请必须填写预计回款日期");
                    }
                }


                //if (textEditDD1.EditValue == null || ReturnDecimal( textEditDD1.EditValue)<=0)
                //{
                //    throw new Exception("佣金金额不小于等于0");
                //}

                //sSQL = "select a.Commission * sum(iQuantity) as Commission from SO_SOMain a inner join dbo.SO_SODetails b on a.ID = b.ID where a.cSOCode='" + lookUpEditSS4.EditValue.ToString().Trim() + "' group by a.cCusCode,a.Commission,a.cDepCode,a.cPersonCode";
                //textEdit订单佣金金额.Text =  ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL)).ToString();

                //sSQL = "select isnull(sum(DD1),0) as DD1 from " + tablename + " where SS4='" + lookUpEditSS4.EditValue.ToString().Trim() + "' and ID<>'" + textEditiID.EditValue.ToString().Trim() + "'";
                //decimal d累计申请金额 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                //textEditDD2.EditValue = d累计申请金额;

                //if (ReturnDecimal(textEdit订单佣金金额.EditValue) < d累计申请金额 + ReturnDecimal(textEditDD1.EditValue))
                //{
                //    throw new Exception("佣金金额不可大于订单业务金额");
                //}

                //if (radioGroupSS5.EditValue.ToString().Trim() == "1")
                //{
                //    if (dateEditTT1.EditValue == null || dateEditTT1.EditValue == "")
                //    {
                //        throw new Exception("已回款必须填写回款日期");
                //    }
                //}

                //if (ReturnDecimal(textEditDD1.EditValue.ToString().Trim()) > ReturnDecimal(textEdit订单佣金金额.EditValue.ToString().Trim()))
                //{
                //    throw new Exception("佣金金额必须小于等于订单业务费用");
                //}


                drh["ID"] = textEditiID.Text;
                drh["iCode"] = textEdit单据号.EditValue.ToString().Trim();

                drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();
                drh["dMemo"] = textEditdMemo.EditValue.ToString().Trim();

                drh["S1"] = lookUpEditSS1.EditValue.ToString().Trim();
                drh["S2"] = lookUpEditSS2.EditValue.ToString().Trim();
                drh["S3"] = lookUpEditSS3.EditValue.ToString().Trim();
                drh["S4"] = lookUpEditSS4.EditValue.ToString().Trim();
                drh["S5"] = radioGroupSS5.EditValue.ToString().Trim();
                //dr["SS6"] = textEditSS6.EditValue.ToString().Trim();
                //dr["SS7"] = textEditSS7.EditValue.ToString().Trim();
                //dr["SS8"] = textEditSS8.EditValue.ToString().Trim();
                //dr["SS9"] = lookUpEdit付款方式.EditValue.ToString();
                //dr["SS10"] = textEdit开户行.Text.Trim();
                //dr["SS11"] = textEdit开户行账户.Text.Trim();

                //dr["DD1"] = textEditDD1.EditValue.ToString().Trim();
                //dr["DD2"] = textEditDD2.EditValue.ToString().Trim();

                if (dateEditTT1.EditValue != null && dateEditTT1.EditValue.ToString().Trim() != "")
                {
                    drh["T1"] = dateEditTT1.EditValue.ToString().Trim();
                }
                //dr["TT2"] = dateEditTT2.EditValue.ToString().Trim();



                drh["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
                drh["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();

                dt.Rows.Add(drh);
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

                #region 删行
                if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
                {
                    系统服务.变更表.GetDelRow(tablenames, textEditDel.EditValue.ToString().Trim(), aList);
                }
                #endregion

                #region 子表
                
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                    {
                        #region 判断
                        if (gridView1.GetRowCellDisplayText(i, gridColCID).ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridColDD1).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridColDD1.Caption + "不能为空\n";
                            continue;
                        }

                        if (gridView1.GetRowCellValue(i, gridColDD2).ToString().Trim() == "")
                        {
                            sErr = sErr + "行" + (i + 1) + gridColDD2.Caption + "不能为空\n";
                            continue;
                        }

                        sSQL = "select a.cSOCode,a.dDate,a.cPersonCode,a.cDepCode,a.cCusCode,a.cSTCode,"
                        + "b.DD1,b.DD2,isnull(b.DD1*b.DD2,0)-isnull(f.usedMoney,0) as usedMoney "
                        + "from SO_SOMain a left join SO_SOMainCommissiion b on a.ID=b.ID "
                        + "left join (select CID,sum(isnull(DD1*DD2,0)) as usedMoney,sum(isnull(DD2,0)) as DD2 from Commissions where 1=1  group by CID) f on b.CID=f.CID "
                        + "where isnull(b.DD1*b.DD2,0)-isnull(f.usedMoney,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null  and b.CID='" + gridView1.GetRowCellDisplayText(i, gridColCID).ToString().Trim() + "'";
                        if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "AutoID<>'" + gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() + "'");
                        }
                        DataTable dtso = clsSQLCommond.ExecQuery(sSQL);
                        if (dtso.Rows.Count > 0)
                        {
                            if (double.Parse(dtso.Rows[0]["usedMoney"].ToString().Trim()) < double.Parse(gridView1.GetRowCellValue(i, gridCol业务费用).ToString().Trim()))
                            {
                                sErr = sErr + "行" + (i + 1) + "业务费用超出销售订单未申请业务费用,销售订单未申请业务费用为" + dtso.Rows[0]["usedMoney"].ToString().Trim() + "\n";
                                continue;
                            }
                        }
                        else
                        {
                            sErr = sErr + "行" + (i + 1) + "业务费用超出销售订单未申请业务费用,销售订单未申请业务费用为0\n";
                            continue;
                        }
                    
                        #endregion

                        #region 生成table
                        DataRow dr = dts.NewRow();
                        if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() == "")
                        {
                            dr["AutoID"] = sID;
                        }
                        else
                        {
                            dr["AutoID"] = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                        }
                        dr["ID"] = iID;
                        dr["CID"] = gridView1.GetRowCellValue(i, gridColCID).ToString().Trim();
                        dr["SS1"] = gridView1.GetRowCellValue(i, gridColSS1).ToString().Trim();
                        dr["SS2"] = gridView1.GetRowCellValue(i, gridColSS2).ToString().Trim();
                        dr["SS3"] = gridView1.GetRowCellValue(i, gridColSS3).ToString().Trim();
                        dr["SS4"] = gridView1.GetRowCellValue(i, gridColSS4).ToString().Trim();
                        dr["SS5"] = gridView1.GetRowCellValue(i, gridColSS5).ToString().Trim();
                        dr["SS6"] = gridView1.GetRowCellValue(i, gridColSS6).ToString().Trim();
                        dr["SS7"] = gridView1.GetRowCellValue(i, gridColSS7).ToString().Trim();
                        dr["SS8"] = gridView1.GetRowCellValue(i, gridColSS8).ToString().Trim();

                        dr["DD1"] = gridView1.GetRowCellValue(i, gridColDD1).ToString().Trim();
                        dr["DD2"] = gridView1.GetRowCellValue(i, gridColDD2).ToString().Trim();

                        //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                        //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();

                        dts.Rows.Add(dr);
                        sID = sID + 1;
                        #endregion

                        if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                        {
                            sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                        }
                        else if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                        {
                            sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                        }

                        aList.Add(sSQL);

                    }
                }
                #endregion
                if (sErr != "")
                {
                    throw new Exception(sErr);
                }

                if (dt == null || dt.Rows.Count <= 0)
                {
                    throw new Exception("表头不能为空");
                }
                #region 表体不能为空
                bool b列表 = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColCID).ToString().Trim() != "")
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
                    if (gridView1.GetRowCellValue(i, gridColCID).ToString().Trim() != "")
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

        private void Frm佣金申请_Load(object sender, EventArgs e)
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

                    if (dt.Rows[0]["T1"].ToString() != "")
                    {
                        dateEditTT1.EditValue = dt.Rows[0]["T1"].ToString();
                    }
                    lookUpEditSS4.EditValue = dt.Rows[0]["S4"].ToString();
                    buttonEditSS1.EditValue = dt.Rows[0]["S1"].ToString();
                    buttonEditSS2.EditValue = dt.Rows[0]["S2"].ToString();
                    buttonEditSS3.EditValue = dt.Rows[0]["S3"].ToString();

                    radioGroupSS5.EditValue = dt.Rows[0]["S5"].ToString();

                    //textEditSS6.EditValue = dt.Rows[0]["SS6"].ToString();
                    //textEditSS7.EditValue = dt.Rows[0]["SS7"].ToString();
                    //textEditSS8.EditValue = dt.Rows[0]["SS8"].ToString();
                    //textEditDD1.EditValue = dt.Rows[0]["DD1"].ToString();
                    ////textEditDD2.EditValue = dt.Rows[0]["DD2"].ToString();
                    //lookUpEdit付款方式.EditValue = dt.Rows[0]["SS9"];
                    //textEdit开户行.Text = dt.Rows[0]["SS10"].ToString();
                    //textEdit开户行账户.Text = dt.Rows[0]["SS11"].ToString();

                    
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();

                    dateEdit制单日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dCreatesysTime"]);
                    dateEdit审核日期.EditValue = ReturnDateTimeString(dt.Rows[0]["dVerifysysTime"]);

                    sSQL = "select *, 'edit' as iSave,cast(DD1*DD2 as decimal(16,6)) as  sCount  from " + tablenames + "  where ID=" + iID;


                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;


                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iFocRow;

                    //sSQL = "select a.Commission * sum(iQuantity) from SO_SOMain a inner join dbo.SO_SODetails b on a.ID = b.ID where a.cSOCode='" + lookUpEditSS4.EditValue.ToString().Trim() + "' group by a.Commission ";
                    //textEdit订单佣金金额.EditValue = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));

                    //sSQL = "select isnull(sum(DD1),0) DD1 from " + tablename + " where SS4='" + lookUpEditSS4.EditValue.ToString().Trim() + "' ";
                    //textEditDD2.EditValue = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                 
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
            系统服务.LookUp.Customer(lookUpEditSS3);
            系统服务.LookUp.SO_SOMainCommission(lookUpEditSS4);
            系统服务.LookUp.SettleStyle(ItemLookUpEdit付款方式);
            系统服务.LookUp.Inventory(ItemLookUpEdit物料名称);
        }

        private void SetEnabled(bool b)
        {
            textEditiID.Enabled = false;
            textEdit单据号.Enabled = false;
            dateEdit单据日期.Enabled = b;

            dateEditTT1.Enabled = b;

            buttonEditSS1.Enabled = b;
            buttonEditSS2.Enabled = b;
            buttonEditSS3.Enabled = false;
            
            lookUpEditSS1.Enabled = false;
            lookUpEditSS2.Enabled = false;
            lookUpEditSS3.Enabled = false;
            lookUpEditSS4.Enabled = false;

            //textEditDD1.Enabled = b;
            //textEditDD2.Enabled = false;
            //textEditSS6.Enabled = b;
            //textEditSS7.Enabled = b;
            //textEditSS8.Enabled = b;
            textEditdMemo.Enabled = b;

            //radioGroupSS5.Enabled = false;

            //lookUpEdit付款方式.Enabled = b;
            //textEdit开户行.Enabled = b;
            //textEdit开户行账户.Enabled = b;

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

            dateEditTT1.EditValue = DBNull.Value;

            buttonEditSS1.EditValue = DBNull.Value;
            buttonEditSS2.EditValue = DBNull.Value;
            buttonEditSS3.EditValue = DBNull.Value;
            
            lookUpEditSS1.EditValue = DBNull.Value;
            lookUpEditSS2.EditValue = DBNull.Value;
            lookUpEditSS3.EditValue = DBNull.Value;
            lookUpEditSS4.EditValue = "";

            //textEditDD1.EditValue = DBNull.Value;
            //textEditDD2.EditValue = DBNull.Value;
            //textEditSS6.EditValue = DBNull.Value;
            //textEditSS7.EditValue = DBNull.Value;
            //textEditSS8.EditValue = DBNull.Value;
            //lookUpEdit付款方式.EditValue = DBNull.Value;
            //textEdit开户行.EditValue = DBNull.Value;
            //textEdit开户行账户.EditValue = DBNull.Value;

            textEditdMemo.EditValue = DBNull.Value;

            //radioGroupSS5.EditValue = "0";

            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            textEdit制单人.EditValue = DBNull.Value;
            textEdit审核人.EditValue = DBNull.Value;
            textEditDel.EditValue = "";
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

        private void buttonEditSS3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
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
            {
                lookUpEditSS3.EditValue = buttonEditSS3.Text.Trim();
                //DataTable dt = 系统服务.LookUp.CustomercCusPPerson(buttonEditSS3.Text.Trim());
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    buttonEditSS1.EditValue = dt.Rows[0]["cCusPPerson"];
                //}
            }
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
            try
            {
                int iRow = 0;
                if (gridView1.FocusedRowHandle >= 0)
                    iRow = gridView1.FocusedRowHandle;

                if (e.Column == gridColDD1 || e.Column == gridColDD2)
                {
                    decimal DD1 = 0;
                    decimal DD2 = 0;
                    decimal iSum = 0;
                    if (gridView1.GetRowCellValue(iRow, gridColDD1) != null && gridView1.GetRowCellValue(iRow, gridColDD1).ToString().Trim() != "")
                    {
                        DD1 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColDD1).ToString().Trim(),6);
                    }
                    if (gridView1.GetRowCellValue(iRow, gridColDD2) != null && gridView1.GetRowCellValue(iRow, gridColDD2).ToString().Trim() != "")
                    {
                        DD2 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridColDD2).ToString().Trim(),6);
                    }
                    iSum = DD1 * DD2;
                    if (iSum != 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol业务费用, ReturnDecimal(iSum,2));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol业务费用, null);
                    }
                }


                #region
                if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "add");
                }
                if (e.Column != gridColiSave && e.Column != gridColSS5 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
                {
                    gridView1.SetRowCellValue(iRow, gridColiSave, "update");
                }
                if (e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridColSS5).ToString().Trim() != "")
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = iRow;
                }
                #endregion
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
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

        //private void lookUpEditSS4_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (sState == "add" || sState == "edit")
        //        {
        //            if (lookUpEditSS4.EditValue.ToString().Trim() == "")
        //                return;

        //            sSQL = "select sum(DD1) as Commission from Commission where SS4='" + lookUpEditSS4.EditValue.ToString().Trim() + "'";
        //            //decimal d已申请 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
        //            //textEditDD2.Text = d已申请.ToString();

        //            sSQL = "select cCusCode,a.Commission * sum(iQuantity) as Commission,cDepCode,cPersonCode from SO_SOMain a inner join dbo.SO_SODetails b on a.ID = b.ID where a.cSOCode='" + lookUpEditSS4.EditValue.ToString().Trim() + "' group by a.cCusCode,a.Commission,a.cDepCode,a.cPersonCode";
        //            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //            if (dt.Rows.Count > 0)
        //            {
        //                buttonEditSS3.EditValue = dt.Rows[0]["cCusCode"].ToString();
        //                buttonEditSS1.EditValue = dt.Rows[0]["cPersonCode"].ToString();
        //                buttonEditSS2.EditValue = dt.Rows[0]["cDepCode"].ToString();

        //                decimal d订单佣金 = ReturnDecimal(dt.Rows[0]["Commission"].ToString());
        //                //textEditDD1.EditValue = d订单佣金 - d已申请;
        //                //textEdit订单佣金金额.EditValue = d订单佣金;
        //                //sSQL = "select * from Customer where cCusCode='" + buttonEditSS3.EditValue.ToString().Trim() + "'";
        //                //DataTable dts = clsSQLCommond.ExecQuery(sSQL);
        //                //if (dts.Rows.Count > 0)
        //                //{
        //                //    textEditSS6.EditValue = dts.Rows[0]["cCusPerson"].ToString();
        //                //    textEditSS7.EditValue = dts.Rows[0]["cCusPhone"].ToString();
        //                //    textEditSS8.EditValue = dts.Rows[0]["cCusAddress"].ToString();
        //                //}
        //            }
        //        }
        //    }
        //    catch(Exception ee)
        //    {
        //        MessageBox.Show(ee.Message);
        //    }
        //}

        //private void radioGroupSS5_EditValueChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (radioGroupSS5.EditValue.ToString().Trim() == "0")
        //        {
        //            this.layoutControlItem11.AppearanceItemCaption.ForeColor = System.Drawing.Color.Blue;
        //        }
        //        else
        //        {
        //            this.layoutControlItem11.AppearanceItemCaption.ForeColor = System.Drawing.Color.AntiqueWhite;
        //        }
        //    }
        //    catch { }
        //}

    }
}
