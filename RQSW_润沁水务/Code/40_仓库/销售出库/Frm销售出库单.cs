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
using System.Text.RegularExpressions;

namespace 仓库
{
    public partial class Frm销售出库单 : 系统服务.FrmBaseInfo
    {
        decimal 乘数 = 0.1M;
        string tablename = "SO_SOOutMain";
        string tableid = "cSOOutCode";
        string tablenames = "SO_SOOutDetails";
        string tablenamel = "SO_SOOutSublist";

        long iID = -1;
        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 单据日期1 = "";
        public string 单据日期2 = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 业务员 = "";
        public string 部门 = "";
        public string 客户1 = "";
        public string 客户2 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 制单人1 = "";
        public string 制单人2 = "";
        public string 审核人1 = "";
        public string 审核人2 = "";
        public string 物料1 = "";
        public string 物料2 = "";

        public string s销售订单号 = "";

        string isChange = "";

        public DataSet ds;

        DataTable dt出库子件;


        public Frm销售出库单(long siID)
        {
            iID = siID;
            InitializeComponent();

        }

        public Frm销售出库单()
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
        /// 导入 打印
        /// </summary>
        private void btnImport()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            if (ds.Tables["dtGrid"].Rows.Count > 0)
            {
                Replist rep = new Replist();


                DataRow dw = rep.dsPrint.Tables["dtHead"].NewRow();
                
                dw["Column2"] = ds.Tables["dtHead"].Rows[0]["dDate"].ToString();
                dw["Column3"] = ds.Tables["dtHead"].Rows[0]["cSOOutCode"].ToString();
                //dw["Column4"] = 系统服务.ClsBaseDataInfo.sUserName;
                dw["Column5"] = DateTime.Now.ToString("yyyy-MM-dd");
                sSQL = "select * from Customer where cCusCode='" + ds.Tables["dtHead"].Rows[0]["cCusCode"].ToString().Trim() + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                dw["Column6"] = dt.Rows[0]["cCusName"].ToString();
                dw["Column7"] = dt.Rows[0]["cCusAddress"].ToString();
                dw["Column8"] = dt.Rows[0]["cCusPerson"].ToString();
                dw["Column9"] = dt.Rows[0]["cCusPhone"].ToString();
                dw["Column16"] = "[" + textEdit备注.EditValue.ToString().Trim() + "]";
               
                sSQL = "select * from SO_SOMain a left join SO_SODetails b on a.ID=b.ID left join Person c on a.cPersonCode=c.PersonCode where AutoID='" + ds.Tables["dtGrid"].Rows[0]["SoAutoID"].ToString() + "'";
                DataTable dtso = clsSQLCommond.ExecQuery(sSQL);
                dw["Column1"] = dtso.Rows[0]["ECode"].ToString().Trim();
                dw["Column12"] = "联系人：" + dtso.Rows[0]["PersonName"].ToString();
                if (dtso.Rows[0]["S1"].ToString() == "01" || dtso.Rows[0]["S1"].ToString() == "03" || dtso.Rows[0]["S1"].ToString() == "06")
                {
                    dw["Column10"] = "送货回单";
                }
                else
                {
                    dw["Column10"] = "发货回单";
                }
                
                if (dtso.Rows[0]["cSTCode"].ToString() == "01")//RQ
                {
                    dw["Column11"] = "苏州润沁水务技术有限公司";
                    dw["Column4"] = "侯钦";
                }
                else
                {
                    dw["Column11"] = "苏州市平江区益森商贸行";
                    dw["Column4"] = "费春兰";
                }
                rep.dsPrint.Tables["dtHead"].Rows.Add(dw);
                for (int i = 0; i < ds.Tables["dtGrid"].Rows.Count; i++)
                {
                    DataRow dwr = rep.dsPrint.Tables["dtGrid"].NewRow();
                    string sInvCode = ds.Tables["dtGrid"].Rows[i]["cInvCode"].ToString().Trim();

                    sSQL = "select * from inventory where cInvCode = '" + sInvCode + "'";
                    DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        string s存货分类 = dtTemp.Rows[0]["cInvClassCode"].ToString().Trim();
                        if (s存货分类 == "0101")
                        {
                            dwr["Column2"] = sInvCode;
                            sInvCode = "聚丙烯酰胺";
                        }
                        if (s存货分类 == "0102")
                        {
                            dwr["Column2"] = sInvCode;
                            sInvCode = "聚合氯化铝";
                        }
                        if (s存货分类 == "0103")
                        {
                            string sInvCode2 = "";
                            for (int ii = 0; ii < sInvCode.Length; ii++)
                            {
                                string s = sInvCode.Substring(ii, 1);
                                if (Check数字字母(s))
                                    break;
                                else
                                    sInvCode2 = sInvCode2 + s;
                            }
                            sInvCode = sInvCode2;
                        }
                        if (sInvCode == "LSL00")
                        {
                            dwr["Column2"] = sInvCode;
                            sInvCode = "硫酸铝";
                        }
                        //if (s存货分类 == "0104")
                        //    sInvCode = "PAM";
                    }
                    if (sInvCode == "聚合氯化铝" || sInvCode == "硫酸铝")
                    {
                        dwr["Column2"] = "";
                    }
                    if(dwr["Column2"].ToString().Trim()=="Null" || dwr["Column2"].ToString().Trim()=="NULL非" || dwr["Column2"].ToString().Trim()=="NULL阳")
                    {
                        dwr["Column2"] = "";
                    }

                    dwr["Column1"] = sInvCode;
                    //dwr["Column2"] = ds.Tables["dtGrid"].Rows[i]["cInvCode"].ToString();
                    if (ReturnDecimal(ds.Tables["dtGrid"].Rows[i]["D1"].ToString()) != 0)
                    {
                        if (dtTemp.Rows[0]["cInvClassCode"].ToString().Trim() == "0103" || dtTemp.Rows[0]["cInvClassCode"].ToString().Trim() == "0203")
                        {
                            dwr["Column3"] = double.Parse(ds.Tables["dtGrid"].Rows[i]["D1"].ToString()).ToString() + "桶";
                        }
                        else
                        {
                            dwr["Column3"] = double.Parse(ds.Tables["dtGrid"].Rows[i]["D1"].ToString()).ToString() + "袋";
                        }
                    }
                    if (ds.Tables["dtGrid"].Rows[i]["cInvStd"].ToString().Trim() != "")
                    {
                        string s规格 = ds.Tables["dtGrid"].Rows[i]["cInvStd"].ToString();
                        string[] s = s规格.Split('/');
                        if (dtTemp.Rows[0]["cInvClassCode"].ToString().Trim() == "0103" || dtTemp.Rows[0]["cInvClassCode"].ToString().Trim() == "0203")
                        {
                            dwr["Column4"] = s[0] + "kg/桶";
                        }
                        else
                        {
                            dwr["Column4"] = s[0] + "kg/袋";
                        }
                    }
                    dwr["Column5"] = ds.Tables["dtGrid"].Rows[i]["iQuantity"].ToString()+dtTemp.Rows[0]["cComUnitCode"].ToString().Trim();
                    dwr["Column6"] = dwr["Column5"];
                    rep.dsPrint.Tables["dtGrid"].Rows.Add(dwr);
                }

                rep.ShowPreview();
            }
        }

        private bool Check数字字母(string s)
        {
            string s正则表达式 = @"^[A-Za-z0-9]+$";

            return Regex.IsMatch(s, s正则表达式);
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
            Frm销售出库单_Add frm = new Frm销售出库单_Add(单据号1, 单据号2, 单据日期1, 单据日期2, 制单日期1, 制单日期2, 业务员,
               部门, 客户1, 客户2, 审核日期1, 审核日期2, 制单人1, 制单人2, 审核人1, 审核人2, 物料1, 物料2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                单据号1 = frm.单据号1;
                单据号2 = frm.单据号2;
                单据日期1 = frm.单据日期1;
                单据日期2 = frm.单据日期2;
                制单日期1 = frm.制单日期1;
                制单日期2 = frm.制单日期2;
                业务员 = frm.业务员;
                部门 = frm.部门;
                客户1 = frm.客户1;
                客户2 = frm.客户2;
                审核日期1 = frm.审核日期1;
                审核日期2 = frm.审核日期2;
                制单人1 = frm.制单人1;
                制单人2 = frm.制单人2;
                审核人1 = frm.审核人1;
                审核人2 = frm.审核人2;
                物料1 = frm.物料1;
                物料2 = frm.物料2;
                GetSel();
            }

        }

        private void GetSel()
        {
            string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1";
            if (单据号1 != null && 单据号1 != "")
            {
                sSQL = sSQL + " and a." + tableid + ">='" + 单据号1 + "'";
            }
            if (单据号2 != null && 单据号2 != "")
            {
                sSQL = sSQL + " and a." + tableid + "<='" + 单据号2 + "'";
            }
            if (单据日期1 != null && 单据日期1 != "")
            {
                sSQL = sSQL + " and dDate>='" + 单据日期1 + "'";
            }
            if (单据日期2 != null && 单据日期2 != "")
            {
                sSQL = sSQL + " and dDate<='" + 单据日期2 + "'";
            }
            if (制单日期1 != null && 制单日期1 != "")
            {
                sSQL = sSQL + " and dCreatesysTime>='" + 制单日期1 + "'";
            }
            if (制单日期2 != null && 制单日期2 != "")
            {
                sSQL = sSQL + " and dCreatesysTime<='" + 制单日期2 + "'";
            }
            if (业务员 != null && 业务员 != "")
            {
                sSQL = sSQL + " and cPersonCode='" + 业务员 + "'";
            }
            if (部门 != "")
            {
                sSQL = sSQL + " and cDepCode='" + 部门 + "'";
            }
            if (客户1 != "")
            {
                sSQL = sSQL + " and cCusCode>='" + 客户1 + "'";
            }
            if (客户2 != "")
            {
                sSQL = sSQL + " and cCusCode<='" + 客户2 + "'";
            }
            if (审核日期1 != "")
            {
                sSQL = sSQL + " and dVerifysysTime>='" + 审核日期1 + "'";
            }
            if (审核日期2 != "")
            {
                sSQL = sSQL + " and dVerifysysTime<='" + 审核日期2 + "'";
            }
            if (制单人1 != "")
            {
                sSQL = sSQL + " and dCreatesysPerson>='" + 制单人1 + "'";
            }
            if (制单人2 != "")
            {
                sSQL = sSQL + " and dCreatesysPerson<='" + 制单人2 + "'";
            }
            if (审核人1 != "")
            {
                sSQL = sSQL + " and dVerifysysPerson>='" + 审核人1 + "'";
            }
            if (审核人2 != "")
            {
                sSQL = sSQL + " and dVerifysysPerson<='" + 审核人2 + "'";
            }
            if (物料1 != "")
            {
                sSQL = sSQL + " and cInvCode>='" + 物料1 + "'";
            }
            if (物料2 != "")
            {
                sSQL = sSQL + " and cInvCode<='" + 物料2 + "'";
            }
            sSQL = sSQL + "  order by a.ID";
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
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
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
                    sSQL = "select ID from " + tablename + " where ID<" + textEditID.Text + " order by ID desc";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
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
                    sSQL = "select ID from " + tablename + " where ID>" + textEditID.Text + " order by ID ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
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
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);;
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
            GetShow(false);
            sState = "";
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            string sErr = "";
            for (int i = gridView2.RowCount - 1; i >= 0; i--)
            {
                if (gridView2.IsRowSelected(i))
                {
                    if (gridView2.GetRowCellValue(i, gridColumn2)==null || gridView2.GetRowCellValue(i, gridColumn2).ToString().Trim() == "")
                    {
                        gridView2.DeleteRow(i);
                        
                    }
                    else
                    {
                        sErr = sErr + "行" + (i + 1) + "不可删除\n";
                    }
                   
                }
            }
            if (sErr != "")
            {
                MsgBox("提示", sErr);
            }
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
            if (radioGroup蓝红标识.EditValue == null)
            {
                radioGroup蓝红标识.EditValue = "";
            }
            DataTable dtt=(DataTable)gridControl1.DataSource;
            if (dtt.Rows.Count > 0)
            {
                s销售订单号 = dtt.Rows[0]["AutoID"].ToString();
            }
            else
            {
                s销售订单号 = "";
            }
            Frm销售订单_New frm = new Frm销售订单_New(buttonEdit客户.Text.ToString().Trim(), dtt, s销售订单号, radioGroup蓝红标识.EditValue.ToString().Trim());
            if (lookUpEdit客户.EditValue == null)
                frm.客户 = "";
            else
                frm.客户 = lookUpEdit客户.EditValue.ToString().Trim();

            frm.红蓝标志 = radioGroup蓝红标识.EditValue.ToString().Trim();
            
            if (DialogResult.OK == frm.ShowDialog())
            {
                if (frm.客户 != "")
                {
                    buttonEdit客户.Enabled = false;
                }
                if (radioGroup蓝红标识.EditValue != "")
                {
                    radioGroup蓝红标识.Enabled = false;
                }
                if (lookUpEdit客户.EditValue!=null && lookUpEdit客户.EditValue != "" && frm.客户.Trim() != lookUpEdit客户.EditValue.ToString().Trim() && frm.客户.Trim() != "")
                {
                    throw new Exception("一张单据只能有一个客户");
                }
                if (radioGroup蓝红标识.EditValue != "" && frm.红蓝标志.Trim() != radioGroup蓝红标识.EditValue.ToString().Trim())
                {
                    throw new Exception("红蓝标志不能修改");
                }

                if (s销售订单号 != null && frm.销售订单号.Trim() != s销售订单号 && frm.销售订单号.Trim() != "")
                {
                    throw new Exception("一张单据只能有一张销售订单");
                }

                radioGroup蓝红标识.EditValue = frm.红蓝标志;
                buttonEdit客户.EditValue = frm.客户;
                s销售订单号 = frm.销售订单号;
                frm.Enabled = true;
                DataTable dtnew = frm.dt;
                int i = gridView1.RowCount - 1;
                gridView1.FocusedRowHandle = i;

                if (dtnew.Rows.Count > 0)
                {
                    buttonEdit业务员.EditValue = dtnew.Rows[0]["cPersonCode"].ToString();
                    dateEdit单据日期.EditValue = dtnew.Rows[0]["dDate"].ToString();
                }

                if (dtnew.Rows.Count > 0 && dateEdit单据日期.EditValue!="")
                {
                    dateEdit单据日期.EditValue = dtnew.Rows[0]["dDate"].ToString();
                }
                for (int s = 0; s < dtnew.Rows.Count; s++)
                {
                    if (s != 0)
                    {
                        gridView1.FocusedRowHandle = gridView1.RowCount - 1;
                        i = gridView1.RowCount - 1;
                    }
                    gridView1.SetRowCellValue(i, gridCol物料编码, dtnew.Rows[s]["cInvCode"].ToString());
                    gridView1.SetRowCellValue(i, gridCol规格型号, dtnew.Rows[s]["cInvStd"].ToString());
                    gridView1.SetRowCellValue(i, gridCol销售订单子表ID, dtnew.Rows[s]["AutoID"].ToString());
                    gridView1.SetRowCellValue(i, gridCol数量, dtnew.Rows[s]["iQuantity"].ToString());
                    if (dtnew.Rows[s]["iNum"].ToString() != "" && dtnew.Rows[s]["iNum"].ToString() != "0")
                    {
                        gridView1.SetRowCellValue(i, gridCol件数, dtnew.Rows[s]["iNum"].ToString());
                    }
                    if (dtnew.Rows[s]["iUnitPrice"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol含税单价, dtnew.Rows[s]["iUnitPrice"].ToString());
                    }
                    if (dtnew.Rows[s]["iMoney"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol含税金额, dtnew.Rows[s]["iMoney"].ToString());
                    }
                    if (dtnew.Rows[s]["iNatUnitPrice"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol无税单价, dtnew.Rows[s]["iNatUnitPrice"].ToString());
                    }
                    if (dtnew.Rows[s]["iNatMoney"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol无税金额, dtnew.Rows[s]["iNatMoney"].ToString());
                    }
                    if (dtnew.Rows[s]["iTaxRate"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol税率, dtnew.Rows[s]["iTaxRate"].ToString());
                    }
                    if (dtnew.Rows[s]["iChangRate"].ToString() != "")
                    {
                        gridView1.SetRowCellValue(i, gridCol换算率, dtnew.Rows[s]["iChangRate"].ToString());
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
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellDisplayText(i, gridCol序号).ToString().Trim() != "")
                {
                    gridView1.SetRowCellValue(i, gridCol序号, i + 1);
                }
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            
            GetNull();
            GetShow(true);
            dateEdit单据日期.EditValue = 系统服务.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            sSQL = "select a.*,i.cInvName,i.cInvStd, 'edit' as iSave  from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
                    + " left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;

            sSQL = "select a.*,b.cInvCode as scInvCode,b.iQuantity as siQuantity,b.iNum as siNum,b.iChangRate as siChangRate,b.D1 as 子件单价 from  " + tablenames + " a left join " + tablenamel + " b on a.AutoID=b.AutoID where 1=-1";
            DataTable dtBingGrid2 = clsSQLCommond.ExecQuery(sSQL);
            gridControl2.DataSource = dtBingGrid2;

            try
            {
                gridView1.FocusedColumn = gridCol序号;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;

            gridView1.OptionsBehavior.Editable = true;
            gridView2.OptionsBehavior.Editable = true;

            btnAddRow();

            sState = "add";
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (textEdit关闭人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已关闭，不能修改");
            }
            else if (textEdit审核人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已审核，不能修改");
            }
            sState = "edit";
            GetShow(true);

            radioGroup蓝红标识.Enabled = false;
            buttonEdit客户.Enabled = false;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (textEditID.Text.Trim() == "")
                throw new Exception("请选择需要删除的单据");

            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            int iRe = CheState(textEdit单据号.Text.Trim());
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
            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                string sErr = "";

                aList = new System.Collections.ArrayList();
                sSQL = "select * from " + tablename + " where 1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select * from " + tablenames + " where 1=-1";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);


                sSQL = "delete from " + tablename + " where ID=" + textEditID.EditValue.ToString().Trim();
                aList.Add(sSQL);
                sSQL = "delete from " + tablenames + " where ID=" + textEditID.EditValue.ToString().Trim();
                aList.Add(sSQL);
                sSQL = "delete from " + tablenamel + " where ID=" + textEditID.EditValue.ToString().Trim();
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                    btnLast();
                    sState = "del";
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
                gridView1.FocusedColumn = gridCol序号;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            sSQL = "select * from " + tablename + " where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from " + tablenames + " where 1=-1";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            
            string sErr = "";

            if (radioGroup蓝红标识.EditValue == null || radioGroup蓝红标识.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "蓝红标识不能为空\n";
            }
            if (buttonEdit客户.EditValue == null || buttonEdit客户.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "客户不能为空\n";
            }
            if (dateEdit单据日期.EditValue == null || dateEdit单据日期.EditValue.ToString().Trim() == "")
            {
                sErr = sErr + "单据日期不能为空\n";
            }
            if (lookUpEdit仓库.EditValue == null || lookUpEdit仓库.Text.Trim() == "")
            {
                throw new Exception("仓库不能为空");
            }
            if (buttonEdit业务员.EditValue == null || buttonEdit业务员.Text.Trim() == "")
            {
                throw new Exception("业务员不能为空");
            }
            if (lookUpEdit出入库类别.EditValue == null || lookUpEdit出入库类别.Text.Trim() == "")
            {
                throw new Exception("出库类别不能为空");
            }

            sSQL = "select isnull(max(AutoID)+1,1) as AutoID from " + tablenames;
            long sID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            sSQL = "select isnull(max(sID)+1,1) as AutoID from " + tablenamel;
            long oID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));

            aList = new System.Collections.ArrayList();
            DataRow drh = dt.NewRow();
            if (sState == "add")
            {
                sSQL = "select isnull(isnull(max(ID),-1)+1,1) as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
                drh["ID"] = iID;
                drh["cSOOutCode"] = 系统服务.序号.GetNewSerialNumberContinuous(tablename, tableid);
                textEdit单据号.EditValue = drh["cSOOutCode"].ToString();
            }
            else
            {
                drh["ID"] = textEditID.Text;
                iID = Convert.ToInt64(textEditID.Text);
                drh["cSOOutCode"] = textEdit单据号.EditValue.ToString().Trim();
            }
            drh["dDate"] = dateEdit单据日期.EditValue.ToString().Trim();

            drh["cPersonCode"] = buttonEdit业务员.EditValue.ToString().Trim();
            drh["cWhCode"] = lookUpEdit仓库.EditValue.ToString().Trim();
            drh["cCusCode"] = buttonEdit客户.EditValue.ToString().Trim();
            drh["cSendPersonCode"] = buttonEdit发货人.EditValue.ToString().Trim();
            drh["cOutCode"] = lookUpEdit出入库类别.EditValue.ToString().Trim();

            drh["Flag"] = radioGroup蓝红标识.EditValue.ToString().Trim();

            drh["cMemo"] = textEdit备注.EditValue.ToString().Trim();

            if (sState == "add")
            {
                drh["dCreatesysTime"] = 系统服务.ClsBaseDataInfo.sLogDate;
                drh["dCreatesysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            }
            else
            {
                drh["dCreatesysTime"] = dateEdit制单日期.EditValue.ToString().Trim();
                drh["dCreatesysPerson"] = textEdit制单人.EditValue.ToString().Trim();
            }
            if (sState == "alter")
            {
                drh["dVerifysysPerson"] = textEdit审核人.Text.Trim();
                drh["dVerifysysTime"] = dateEdit审核日期.Text.Trim();
                drh["dChangeVerifyTime"] = 系统服务.ClsBaseDataInfo.sLogDate;
                drh["dChangeVerifyPerson"] = 系统服务.ClsBaseDataInfo.sUid;
            }
            dt.Rows.Add(drh);
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

            #region 更新变更表
            if (sState == "alter")
            {
                系统服务.变更表.GetChange(tablename, tablenames, tablenamel, textEditID.EditValue.ToString().Trim(), clsGetSQL, aList);
            }
            #endregion

            #region 删行
            if (textEditDel.EditValue != null && textEditDel.EditValue.ToString().Trim() != "")
            {
                系统服务.变更表.GetDelRow(tablenames, tablenamel, textEditDel.EditValue.ToString().Trim(), aList);
            }
            #endregion

            sSQL = "delete from " + tablenamel + " where ID='" + iID + "'";
            aList.Add(sSQL);
            sSQL = "select * from " + tablenamel + " where 1=-1";
            DataTable dtl = clsSQLCommond.ExecQuery(sSQL);
            DataTable dtout = (DataTable)gridControl2.DataSource;

            #region 子表
            

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string aid = "";
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update" || gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                {
                    #region 判断
                    if (gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() == "")
                    {
                        continue;
                    }

                    if (gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "不能为空\n";
                        continue;
                    }
                    else
                    {
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()) < 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为正\n";
                                continue;
                            }
                        }
                        else if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()) >= 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为负\n";
                                continue;
                            }
                        }
                    }

                    if (gridView1.GetRowCellValue(i, gridCol包).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + gridCol包.Caption + "不能为空\n";
                        continue;
                    }

                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                    {
                        sSQL = "select isnull(b.iQuantity,0)-isnull(f.iQuantity,0)-isnull(r.iQuantity,0) as iQuantity,isnull(b.iMoney,0)-isnull(f.iMoney,0)-isnull(r.iMoney,0) as iMoney from SO_SOMain a left join SO_SODetails b on a.ID=b.ID "
                        + " left join (select SoAutoID,sum(iQuantity) as iQuantity,sum(isnull(iMoney,0)) as iMoney from SO_SOReturns group by SoAutoID) r on b.AutoID=r.SoAutoID "
                        + " left join (select SoAutoID,sum(iQuantity) as iQuantity,sum(isnull(iMoney,0)) as iMoney from " + tablenames + " where 1=1 group by SoAutoID) f on b.AutoID=f.SoAutoID "
                        + "where isnull(b.iQuantity,0)-isnull(f.iQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null and  AutoID='" + gridView1.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim() + "' ";
                        if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "AutoID<>'" + gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() + "'");
                        }
                        DataTable dtso = clsSQLCommond.ExecQuery(sSQL);
                        if (dtso.Rows.Count > 0)
                        {
                            if (double.Parse(dtso.Rows[0]["iQuantity"].ToString().Trim()) < double.Parse(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()))
                            {
                                sErr = sErr + "行" + (i + 1) + "数量超出销售订单剩余数量,销售订单剩余数量" + dtso.Rows[0]["iQuantity"].ToString().Trim() + "\n";
                                continue;
                            }
                        }
                        else
                        {
                            sErr = sErr + "行" + (i + 1) + "数量超出销售订单剩余数量,销售订单剩余数量为0\n";
                            continue;
                        }
                    }
                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                    {
                        sSQL = "select isnull(-f.iQuantity,0) as iQuantity,isnull(-f.iMoney,0) as iMoney,isnull(f.iQuantity,0) as outQuantity from SO_SOMain a left join SO_SODetails b on a.ID=b.ID "
                            + "left join (select SoAutoID,sum(iQuantity) as iQuantity,sum(isnull(iMoney,0)) as iMoney from " + tablenames + " where 1=1 group by SoAutoID) f on b.AutoID=f.SoAutoID "
                        + "where isnull(f.iQuantity,0)>0 and a.dVerifysysPerson is not null and a.dClosesysPerson is null and b.cClosesysPerson is null and  AutoID='" + gridView1.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim() + "' ";
                        if (gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() != "")
                        {
                            sSQL = sSQL.Replace("1=1", "AutoID<>'" + gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim() + "'");
                        }
                        DataTable dtso = clsSQLCommond.ExecQuery(sSQL);
                        if (dtso.Rows.Count > 0)
                        {
                            if (double.Parse(dtso.Rows[0]["iQuantity"].ToString().Trim()) > double.Parse(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()))
                            {
                                sErr = sErr + "行" + (i + 1) + "红字数量超出销售订单已出库数量,销售订单已出库数量" + dtso.Rows[0]["outQuantity"].ToString().Trim() + "\n";
                                continue;
                            }
                        }
                        else
                        {
                            sErr = sErr + "行" + (i + 1) + "红字数量超出销售订单已出库数量,销售订单已出库数量为0\n";
                            continue;
                        }
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
                        sID = long.Parse(dr["AutoID"].ToString());
                    }
                    dr["ID"] = iID;
                    aid = dr["AutoID"].ToString();
                    dr["cSOOutCode"] = textEdit单据号.EditValue.ToString().Trim();
                    dr["iRowNo"] = gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim();
                    dr["SoAutoID"] = gridView1.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim();
                    dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim();
                    dr["cInvStd"] = gridView1.GetRowCellValue(i, gridCol规格型号).ToString().Trim();
                    dr["iQuantity"] = gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim();
                    if (gridView1.GetRowCellValue(i, gridCol件数) != null && gridView1.GetRowCellValue(i, gridCol件数).ToString().Trim() != "")
                    {
                        dr["iNum"] = gridView1.GetRowCellValue(i, gridCol件数).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol含税单价) != null && gridView1.GetRowCellValue(i, gridCol含税单价).ToString().Trim() != "")
                    {
                        dr["iUnitPrice"] = gridView1.GetRowCellValue(i, gridCol含税单价).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol含税金额) != null && gridView1.GetRowCellValue(i, gridCol含税金额).ToString().Trim() != "")
                    {
                        dr["iMoney"] = gridView1.GetRowCellValue(i, gridCol含税金额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol无税单价) != null && gridView1.GetRowCellValue(i, gridCol无税单价).ToString().Trim() != "")
                    {
                        dr["iNatUnitPrice"] = gridView1.GetRowCellValue(i, gridCol无税单价).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol无税金额) != null && gridView1.GetRowCellValue(i, gridCol无税金额).ToString().Trim() != "")
                    {
                        dr["iNatMoney"] = gridView1.GetRowCellValue(i, gridCol无税金额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol税率) != null && gridView1.GetRowCellValue(i, gridCol税率).ToString().Trim() != "")
                    {
                        dr["iTaxRate"] = gridView1.GetRowCellValue(i, gridCol税率).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol税额) != null && gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim() != "")
                    {
                        dr["iNatTax"] = gridView1.GetRowCellValue(i, gridCol税额).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol换算率) != null && gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr["iChangRate"] = gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim();
                    }
                    if (gridView1.GetRowCellValue(i, gridCol包) != null && gridView1.GetRowCellValue(i, gridCol包).ToString().Trim() != "")
                    {
                        dr["D1"] = gridView1.GetRowCellValue(i, gridCol包).ToString().Trim();
                    }
                    dr["cMemo"] = gridView1.GetRowCellValue(i, gridCol备注).ToString().Trim();

                    //dr["cClosesysPerson"] = gridView1.GetRowCellValue(i, gridCol行关闭人).ToString().Trim();
                    //dr["cClosesysTime"] = gridView1.GetRowCellValue(i, gridCol行关闭日期).ToString().Trim();

                    dts.Rows.Add(dr);
                    if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "update")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }
                    else if (gridView1.GetRowCellDisplayText(i, gridColiSave).ToString().Trim() == "add")
                    {
                        sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenames, dts, dts.Rows.Count - 1);
                    }

                    aList.Add(sSQL);
                    #endregion

                    #region 出库子件
                    if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                    {
                        if (gridView1.GetRowCellValue(i, gridCol序号) != null && gridView1.GetRowCellValue(i, gridCol序号) != "")
                        {
                            DataRow[] dwo = dtout.Select("iRowNo='" + gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim() + "'");
                            for (int s = 0; s < dwo.Length; s++)
                            {
                                DataRow drl = dtl.NewRow();
                                drl["sID"] = oID;
                                drl["ID"] = iID;
                                drl["AutoID"] = dr["AutoID"].ToString();
                                drl["iRowNo"] = dwo[s]["iRowNo"].ToString();
                                drl["cSOOutCode"] = textEdit单据号.EditValue.ToString().Trim();
                                drl["cInvCode"] = dwo[s]["scInvCode"].ToString();
                                drl["iQuantity"] = dwo[s]["siQuantity"].ToString();
                                drl["iUsedQty"] = dwo[s]["iUsedQty"].ToString();
                                if (dwo[s]["siNum"].ToString() != "")
                                {
                                    drl["iNum"] = dwo[s]["siNum"].ToString();
                                }
                                if (dwo[s]["siChangRate"].ToString() != "")
                                {
                                    drl["iChangRate"] = dwo[s]["siChangRate"].ToString();
                                }

                                drl["aInvCode"] = dwo[s]["aInvCode"].ToString();
                                if (dwo[s]["aiQuantity"].ToString() != "")
                                {
                                    drl["aiQuantity"] = dwo[s]["aiQuantity"].ToString();
                                }
                                if (dwo[s]["aiNum"].ToString() != "")
                                {
                                    drl["aiNum"] = dwo[s]["aiNum"].ToString();
                                }
                                if (dwo[s]["aiChangRate"].ToString() != "")
                                {
                                    drl["aiChangRate"] = dwo[s]["aiChangRate"].ToString();
                                }
                                drl["ECode"] = dwo[s]["ECode"].ToString();
                                drl["D1"] = dwo[s]["子件单价"].ToString();
                                dtl.Rows.Add(drl);
                                sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamel, dtl, dtl.Rows.Count - 1);
                                aList.Add(sSQL);
                                oID = oID + 1;

                            }
                        }
                    }
                    #endregion

                    sID = sID + 1;
                }
                else
                {
                    if (gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim() != "")
                    {
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()) < 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为正\n";
                                continue;
                            }
                        }
                        else if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
                        {
                            if (ReturnDecimal(gridView1.GetRowCellValue(i, gridCol数量).ToString().Trim()) >= 0)
                            {
                                sErr = sErr + "行" + (i + 1) + gridCol数量.Caption + "需为负\n";
                                continue;
                            }
                        }

                        #region 出库子件
                        aid=gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                        if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
                        {
                            if (gridView1.GetRowCellValue(i, gridCol序号) != null && gridView1.GetRowCellValue(i, gridCol序号) != "")
                            {
                                DataRow[] dwo = dtout.Select("iRowNo='" + gridView1.GetRowCellValue(i, gridCol序号).ToString().Trim() + "'");
                                for (int s = 0; s < dwo.Length; s++)
                                {
                                    DataRow drl = dtl.NewRow();
                                    drl["sID"] = oID;
                                    drl["ID"] = iID;
                                    drl["AutoID"] = aid;
                                    drl["iRowNo"] = dwo[s]["iRowNo"].ToString();
                                    drl["cSOOutCode"] = textEdit单据号.EditValue.ToString().Trim();
                                    drl["cInvCode"] = dwo[s]["scInvCode"].ToString();
                                    drl["iQuantity"] = dwo[s]["siQuantity"].ToString();
                                    drl["iUsedQty"] = dwo[s]["iUsedQty"].ToString();
                                    if (dwo[s]["siNum"].ToString() != "")
                                    {
                                        drl["iNum"] = dwo[s]["siNum"].ToString();
                                    }
                                    if (dwo[s]["siChangRate"].ToString() != "")
                                    {
                                        drl["iChangRate"] = dwo[s]["siChangRate"].ToString();
                                    }

                                    drl["aInvCode"] = dwo[s]["aInvCode"].ToString();
                                    if (dwo[s]["aiQuantity"].ToString() != "")
                                    {
                                        drl["aiQuantity"] = dwo[s]["aiQuantity"].ToString();
                                    }
                                    if (dwo[s]["aiNum"].ToString() != "")
                                    {
                                        drl["aiNum"] = dwo[s]["aiNum"].ToString();
                                    }
                                    if (dwo[s]["aiChangRate"].ToString() != "")
                                    {
                                        drl["aiChangRate"] = dwo[s]["aiChangRate"].ToString();
                                    }
                                    drl["ECode"] = dwo[s]["ECode"].ToString();
                                    dtl.Rows.Add(drl);
                                    
                                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, tablenamel, dtl, dtl.Rows.Count - 1);
                                    aList.Add(sSQL);
                                    oID = oID + 1;

                                }
                            }
                        }
                    }
                    #endregion
                }
            }
            #endregion

            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "1")
            {
                #region 判断材料出库单是否正确
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridColumn序号) != null && gridView2.GetRowCellValue(i, gridColumn序号).ToString().Trim() != "")
                    {
                        if (gridView2.GetRowCellValue(i, gridColumn子件数量) == null || gridView2.GetRowCellValue(i, gridColumn子件数量).ToString().Trim() == "")
                        {
                            sErr = sErr + "出库单材料表行" + (i + 1) + gridColumn子件数量.Caption + "不可为空\n";
                        }
                        if (ReturnDecimal(gridView2.GetRowCellValue(i, gridColumn子件数量)) == 0)
                        {
                            sErr = sErr + "出库单材料表行" + (i + 1) + gridColumn子件数量.Caption + "不可为0\n";
                        }
                        if ((gridView2.GetRowCellValue(i, gridColumn代替料) != null && gridView2.GetRowCellValue(i, gridColumn代替料).ToString().Trim() != "") || (gridView2.GetRowCellValue(i, gridColumn代替料数量) != null && gridView2.GetRowCellValue(i, gridColumn代替料数量).ToString().Trim() != ""))
                        {
                            if (gridView2.GetRowCellValue(i, gridColumn代替料) == null || gridView2.GetRowCellValue(i, gridColumn代替料).ToString().Trim() == "")
                            {
                                sErr = sErr + "出库单材料表行" + (i + 1) + gridColumn代替料.Caption + "不可为空\n";
                            }
                            if (gridView2.GetRowCellValue(i, gridColumn代替料数量) == null || gridView2.GetRowCellValue(i, gridColumn代替料数量).ToString().Trim() == "")
                            {
                                sErr = sErr + "出库单材料表行" + (i + 1) + gridColumn代替料数量.Caption + "不可为空\n";
                            }
                            if (gridView2.GetRowCellValue(i, gridColumn8位数编码) == null || gridView2.GetRowCellValue(i, gridColumn8位数编码).ToString().Trim() == "")
                            {
                                sErr = sErr + "出库单材料表行" + (i + 1) + " " + gridColumn8位数编码.Caption + "不可为空\n";
                            }
                            else
                            {
                                sSQL = "select ECode from SO_SOMain a left join SO_SODetails b on a.ID=b.ID where isnull(dVerifysysTime,'')<>'' and ECode='" + gridView2.GetRowCellValue(i, gridColumn8位数编码).ToString().Trim() + "'";
                                if (clsSQLCommond.ExecQuery(sSQL).Rows.Count == 0)
                                {
                                    sErr = sErr + "出库单材料表行" + (i + 1) + " " + gridColumn8位数编码.Caption + "在已审核的销售订单中不存在\n";
                                }
                            }
                        }
                    }
                }

                DataTable dto = (DataTable)gridControl2.DataSource;

                DataView dv = new DataView(dt出库子件);
                DataTable dtgroup = dv.ToTable(true, new string[] { "scInvCode" });
                dtgroup.Columns.Add("siQuantity", typeof(decimal));
                for (int i = 0; i < dtgroup.Rows.Count; i++)
                {
                    dtgroup.Rows[i]["siQuantity"] = dt出库子件.Compute("sum(siQuantity)", "scInvCode='" + dtgroup.Rows[i]["scInvCode"].ToString() + "'");
                    if (ReturnDecimal(dtgroup.Rows[i]["siQuantity"]) != ReturnDecimal(dto.Compute("sum(siQuantity)", "scInvCode='" + dtgroup.Rows[i]["scInvCode"].ToString() + "'")))
                    {
                        sErr = sErr + "出库单材料" + dtgroup.Rows[i]["scInvCode"].ToString() + "子件数量与实际出库子件数量不符合，实际总共出" + ReturnDecimal(dtgroup.Rows[i]["siQuantity"]) + "\n";
                    }
                }

                #endregion


            }

            
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
                if (gridView1.GetRowCellValue(i, gridColumn物料编码).ToString().Trim() != "")
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
                if (gridView1.GetRowCellValue(i, gridColumn物料编码).ToString().Trim() != "")
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
                textEditID.EditValue = iID;
                GetSelBind();
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
            aList = new System.Collections.ArrayList();

            if (textEdit单据号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能审核");
            }
            if (textEdit审核人.Text.Trim() != "")
            {
                throw new Exception("已经审核，不能审核");
            }
            if (textEdit关闭人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已关闭，不能审核");
            }

            sSQL = "update " + tablename + " set dVerifysysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dVerifysysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
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
            aList = new System.Collections.ArrayList();

            if (textEdit单据号.EditValue.ToString().Trim() == "")
            {
                throw new Exception("没有单据号，不能弃审");
            }
            if (textEdit审核人.EditValue.ToString().Trim() == "")
            {
                throw new Exception("未审核，不能弃审");
            }
            if (textEdit关闭人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已关闭，不能弃审");
            }

            sSQL = "update " + tablename + " set dVerifysysTime=null,dVerifysysPerson=null where ID=" + textEditID.Text + "";
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
            aList = new System.Collections.ArrayList();

            if (textEdit单据号.EditValue.ToString().Trim() == "")
            {
                throw new Exception("没有单据号，不能打开");
            }
            if (textEdit关闭人.EditValue.ToString().Trim() == "")
            {
                throw new Exception("未关闭，不能打开");
            }

            sSQL = "update " + tablename + " set dClosesysTime=null,dClosesysPerson=null where ID=" + textEditID.Text + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime=null,cClosesysPerson=null where ID=" + textEditID.Text + " ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("打开成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            aList = new System.Collections.ArrayList();

            if (textEdit单据号.EditValue.ToString().Trim() == "")
            {
                throw new Exception("没有单据号，不能弃审");
            }
            if (textEdit关闭人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已关闭，不能再次关闭");
            }

            sSQL = "update " + tablename + " set dClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',dClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + "";
            aList.Add(sSQL);
            sSQL = "update " + tablenames + " set cClosesysTime='" + 系统服务.ClsBaseDataInfo.sLogDate + "',cClosesysPerson='" + 系统服务.ClsBaseDataInfo.sUid + "' where ID=" + textEditID.Text + " and  (cClosesysPerson='' or cClosesysPerson is null)";
            aList.Add(sSQL);
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");
                GetGrid();
            }
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            int iRe = CheState(textEdit单据号.Text.Trim());
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
            sState = "alter";
            GetShow(true);
        }

        #endregion

        private void Frm销售出库单_Load(object sender, EventArgs e)
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
                ds = new DataSet();

                sSQL = "select * from " + tablename + " where ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt.Rows.Count > 0)
                {
                    dt.TableName = "dtHead";
                    ds.Tables.Add(dt.Copy());

                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);;
                    textEdit单据号.EditValue = dt.Rows[0]["cSOOutCode"].ToString();

                    dateEdit单据日期.EditValue = dt.Rows[0]["dDate"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["dCreatesysTime"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["dVerifysysTime"].ToString();
                    dateEdit关闭日期.EditValue = dt.Rows[0]["dClosesysTime"].ToString();

                    textEdit备注.EditValue = dt.Rows[0]["cMemo"].ToString();
                    textEdit制单人.EditValue = dt.Rows[0]["dCreatesysPerson"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["dVerifysysPerson"].ToString();
                    textEdit关闭人.EditValue = dt.Rows[0]["dClosesysPerson"].ToString();

                    buttonEdit客户.EditValue = dt.Rows[0]["cCusCode"].ToString();
                    buttonEdit业务员.EditValue = dt.Rows[0]["cPersonCode"].ToString();
                    lookUpEdit仓库.EditValue = dt.Rows[0]["cWhCode"].ToString();
                    
                    buttonEdit发货人.EditValue = dt.Rows[0]["cSendPersonCode"].ToString();
                    lookUpEdit出入库类别.EditValue = dt.Rows[0]["cOutCode"].ToString();

                    radioGroup蓝红标识.EditValue = dt.Rows[0]["Flag"].ToString();
                    buttonEdit客户.Enabled = false;
                    sSQL = "select a.*,i.cInvName, 'edit' as iSave  from " + tablenames + " a left join  Inventory i on a.cInvCode=i.cInvCode "
                    + " left join ComputationUnitGroup g on i.cGroupCode=g.cGroupCode where ID=" + iID;


                    dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dtBingGrid;

                    dtBingGrid.TableName = "dtGrid";
                    ds.Tables.Add(dtBingGrid.Copy());

                    gridView1.AddNewRow();

                    gridView1.FocusedRowHandle = iFocRow;

                    sSQL = "select a.*,b.cInvCode as scInvCode,b.iQuantity as siQuantity,b.iNum as siNum,b.iChangRate as siChangRate,b.iUsedQty,b.aInvCode,b.aiChangRate,b.aiNum,b.aiQuantity,b.ECode,b.D1 as 子件单价 from  " + tablenames + " a left join " + tablenamel + " b on a.AutoID=b.AutoID where a.ID=" + iID;
                    DataTable dtBingGrid2 = clsSQLCommond.ExecQuery(sSQL);
                    gridControl2.DataSource = dtBingGrid2;

                    dt出库子件 = dtBingGrid2.Copy();

                    

                    if (dtBingGrid2.Rows.Count > 0)
                    {
                        DataTable dtm = 系统服务.Table.DataRowToDataTable(dtBingGrid2.Select("1=1"));
                        repositoryItemLookUpEdit销售订单ID.DataSource = dtm;

                        gridView2.AddNewRow();

                        gridView2.FocusedRowHandle = iFocRow;
                    }

                    GetShow(false);
                }
                else
                {
                    GetNull();
                    GetShow(false);
                }
            }
            else
            {
                GetNull();
                GetShow(false);
            }
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            lookUpEdit仓库.Properties.DataSource = 系统服务.LookUp.Warehouse();
            ItemLookUpEditcInvCode.Properties.DataSource = 系统服务.LookUp.Inventory();
            ItemLookUpEditcInvName.Properties.DataSource = 系统服务.LookUp.Inventory();
            ItemLookUpEditcInvStd.Properties.DataSource = 系统服务.LookUp.Inventory();
            系统服务.LookUp.RdStyle(lookUpEdit出入库类别);
            系统服务.LookUp.Customer(lookUpEdit客户);
            系统服务.LookUp.Person(lookUpEdit发货人);
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Inventory(repositoryItemLookUpEdit2);
            repositoryItemLookUpEdit2.Properties.DisplayMember = "cInvName";
            系统服务.LookUp.Inventory(repositoryItemLookUpEdit3);
            repositoryItemLookUpEdit3.Properties.DisplayMember = "cInvStd";

            系统服务.LookUp.Inventory3(ItemLookUpEdit物料代码);
            系统服务.LookUp.Inventory3(ItemLookUpEdit子件代码);

            repositoryItemLookUpEdit销售订单ID.Properties.ValueMember = "SoAutoID";
            repositoryItemLookUpEdit销售订单ID.Properties.DisplayMember = "SoAutoID";
            repositoryItemLookUpEdit销售订单ID.Properties.NullText = "";
            repositoryItemLookUpEdit销售订单ID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoAutoID","销售订单号"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cInvCode","物料编码"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iQuantity","数量"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("scInvCode","子件编码"),
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("siQuantity","子件数量")});

        }

        private void GetShow(bool b)
        {
            dateEdit单据日期.Enabled = b;
            dateEdit制单日期.Enabled = false;
            dateEdit审核日期.Enabled = false;
            dateEdit关闭日期.Enabled = false;

            textEdit单据号.Enabled = false;
            textEdit备注.Enabled = b;
            textEdit制单人.Enabled = false;
            textEdit审核人.Enabled = false;
            textEdit关闭人.Enabled = false;

            buttonEdit业务员.Enabled = b;
            lookUpEdit仓库.Enabled = b;
            buttonEdit客户.Enabled = b;
            buttonEdit发货人.Enabled = b;
            lookUpEdit出入库类别.Enabled = false;

            lookUpEdit发货人.Enabled = false;
            lookUpEdit客户.Enabled = false;
            lookUpEdit业务员.Enabled = false;

            radioGroup蓝红标识.Enabled = b;

            gridView1.OptionsBehavior.Editable = b;
            gridView2.OptionsBehavior.Editable = b;
            if (b == false)
            {
                isChange = "N";
            }
            else
            {
                isChange = "";
            }
        }

        private void GetNull()
        {
            dateEdit单据日期.EditValue = DBNull.Value;
            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            dateEdit关闭日期.EditValue = DBNull.Value;

            textEditID.EditValue = "";
            textEdit单据号.EditValue = "";
            textEdit备注.EditValue = "";
            textEdit制单人.EditValue = "";
            textEdit审核人.EditValue = "";
            textEdit关闭人.EditValue = "";

            buttonEdit业务员.EditValue = "";
            lookUpEdit仓库.EditValue = "01";
            buttonEdit客户.EditValue = "";
            buttonEdit发货人.EditValue = "";
            lookUpEdit出入库类别.EditValue = "11";
            radioGroup蓝红标识.EditValue = "";

            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;

            if (gridView1.GetRowCellValue(iRow, gridCol序号)==null || gridView1.GetRowCellValue(iRow, gridCol序号).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridCol序号, iRow + 1);
            }

            #region 换算率
            if (e.Column == gridCol物料编码 || e.Column == gridCol物料名称 || e.Column == gridCol规格型号)
            {
                if (e.Column == gridCol物料编码)
                {
                    gridView1.SetRowCellValue(iRow, gridCol物料名称, gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim());
                    gridView1.SetRowCellValue(iRow, gridCol规格型号, gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim());
                    gridView1.SetRowCellValue(iRow, gridCol税率, 17);
                }
                string invocde = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
                sSQL = "select 换算率 from Inventory where cInvCode='" + invocde + "'";
                decimal d换算率 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (d换算率 > 0)
                {
                    gridView1.SetRowCellValue(iRow, gridCol换算率, d换算率);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol换算率, null);
                }
            }
            if (e.Column == gridCol数量 || e.Column == gridCol换算率)
            {
                if (gridView1.GetRowCellValue(iRow, gridCol换算率).ToString().Trim() != "")
                {
                    decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
                    decimal 数量 = 0;
                    if (gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "")
                    {
                        数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                    }
                    if (数量 == 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, null);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, ReturnDecimal(数量 * 换算率));
                    }

                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol件数, null);
                }
            }
            #endregion

            if (e.Column == gridCol数量 || e.Column == gridCol件数 || e.Column == gridCol税率 || e.Column == gridCol税额 || e.Column == gridCol含税单价 || e.Column == gridCol含税金额
                || e.Column == gridCol无税单价 || e.Column == gridCol无税金额)
            {
                decimal 数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                decimal 件数 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol件数));
                decimal 税率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税率)) / 100;
                decimal 税额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol税额));
                decimal 换算率 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol换算率));
                decimal 含税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税单价));
                decimal 含税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol含税金额));
                decimal 无税单价 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税单价));
                decimal 无税金额 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol无税金额));

                #region 计算
                if (e.Column == gridCol数量)
                {
                    if (换算率 != 0)
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, ReturnDecimal(数量 * 换算率));
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol件数, null);
                    }
                }
                if (e.Column == gridCol含税单价 || e.Column == gridCol数量 || e.Column == gridCol税率)
                {
                    无税单价 = ReturnDecimal(含税单价 / (1 + 税率));
                    含税金额 = ReturnDecimal(含税单价 * 数量);
                    无税金额 = ReturnDecimal(无税单价 * 数量);
                    税额 = 含税金额 - 无税金额;

                    gridView1.SetRowCellValue(iRow, gridCol无税单价, 无税单价);
                    gridView1.SetRowCellValue(iRow, gridCol无税金额, 无税金额);
                    gridView1.SetRowCellValue(iRow, gridCol含税金额, 含税金额);
                    gridView1.SetRowCellValue(iRow, gridCol税额, 税额);
                }
                if (e.Column == gridCol含税金额 && 数量 != 0)
                {
                    含税单价 = ReturnDecimal(含税金额 / 数量);
                }


                #endregion

            }
            if (e.Column == gridCol数量 || e.Column == gridCol规格型号)
            {
                decimal 数量 = 0;
                decimal 规格型号 = 0;
                if (gridView1.GetRowCellValue(iRow, gridCol数量) != null && gridView1.GetRowCellValue(iRow, gridCol数量).ToString().Trim() != "")
                {
                    数量 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol数量));
                }
                if (gridView1.GetRowCellValue(iRow, gridCol规格型号) != null && gridView1.GetRowCellValue(iRow, gridCol规格型号).ToString().Trim() != "")
                {
                    if (gridView1.GetRowCellValue(iRow, gridCol规格型号).ToString().Trim().IndexOf('/') >= 0)
                    {
                        规格型号 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol规格型号).ToString().Split('/')[0]);
                    }
                    else
                    {
                        规格型号 = ReturnDecimal(gridView1.GetRowCellValue(iRow, gridCol规格型号));
                    }
                }
                if (规格型号 != 0)
                {
                    gridView1.SetRowCellValue(iRow, gridCol包, 数量 / 规格型号);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridCol包, null);
                }
            }

            if (e.Column == gridCol物料编码 || e.Column == gridCol数量)
            {
                DataTable dt=(DataTable)gridControl1.DataSource;
                

                sSQL = "select a.*,'save' as iSave,b.cInvCode as scInvCode,b.iQuantity as siQuantity,b.iNum as siNum,b.iChangRate as siChangRate,b.iUsedQty,b.aInvCode,b.aiQuantity,b.aiNum,aiChangRate,b.ECode,b.D1 as 子件单价 from  " + tablenames + " a left join " + tablenamel + " b on a.AutoID=b.AutoID where 1=-1";
                DataTable dtBingGrid2 = clsSQLCommond.ExecQuery(sSQL);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SoAutoID"].ToString() != "")
                    {
                        sSQL = "select * from SO_SODetails where AutoID='" + dt.Rows[i]["SoAutoID"].ToString() + "'";
                        DataTable dtso = clsSQLCommond.ExecQuery(sSQL);
                        decimal qty = ReturnDecimal(dt.Rows[i]["iQuantity"].ToString());
                        DataTable dts = clsSQLCommond.ExecQuery("select * from SO_SOSublist where AutoID='" + dt.Rows[i]["SoAutoID"].ToString() + "'");
                        for (int j = 0; j < dts.Rows.Count; j++)
                        {
                            if (dt.Rows[i]["iQuantity"].ToString() != "")
                            {
                                DataRow dw = dtBingGrid2.NewRow();
                                if (dt.Rows[i]["AutoID"].ToString() != "")
                                {
                                    dw["AutoID"] = dt.Rows[i]["AutoID"].ToString();
                                }

                                dw["SoAutoID"] = dt.Rows[i]["SoAutoID"].ToString();
                                dw["iSave"] = "edit";
                                dw["iRowNo"] = dt.Rows[i]["iRowNo"].ToString();
                                dw["cInvCode"] = dt.Rows[i]["cInvCode"].ToString();
                                dw["iQuantity"] = dt.Rows[i]["iQuantity"].ToString();
                                if (dt.Rows[i]["iNum"].ToString() != "")
                                {
                                    dw["iNum"] = dt.Rows[i]["iNum"].ToString();
                                }
                                if (dt.Rows[i]["iChangRate"].ToString() != "")
                                {
                                    dw["iChangRate"] = dt.Rows[i]["iChangRate"].ToString();
                                }
                                dw["scInvCode"] = dts.Rows[j]["cInvCode"].ToString();
                                dw["siQuantity"] = ReturnDecimal(dts.Rows[j]["iUsedQty"].ToString()) * qty * 乘数;
                                dw["iUsedQty"] = ReturnDecimal(dts.Rows[j]["iUsedQty"].ToString());
                                if (dts.Rows[j]["iChangRate"].ToString() != "")
                                {
                                    dw["siNum"] = ReturnDecimal(dw["siQuantity"].ToString()) * ReturnDecimal(dts.Rows[j]["iChangRate"].ToString()) * 乘数;
                                    dw["siChangRate"] = dts.Rows[j]["iChangRate"].ToString();
                                }
                                if (dts.Rows[j]["D1"].ToString() != "")
                                {
                                    dw["子件单价"] = dts.Rows[j]["D1"].ToString();
                                }
                                dtBingGrid2.Rows.Add(dw);
                                
                            }
                        }
                    }
                }
                if (dtBingGrid2.Rows.Count > 0)
                {
                    DataTable dtm = 系统服务.Table.DataRowToDataTable(dtBingGrid2.Select("1=1"));
                    repositoryItemLookUpEdit销售订单ID.DataSource = dtm;
                }

                gridControl2.DataSource = dtBingGrid2;
                gridView2.AddNewRow();

                gridView2.FocusedRowHandle = iFocRow;

                dt出库子件 = dtBingGrid2.Copy();

            }

            #region
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            }
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
            if (e.Column == gridCol物料编码 && e.RowHandle == gridView1.RowCount - 1 && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol物料编码).ToString().Trim() != "")
            {
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = iRow;
            }
            #endregion
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView2.FocusedRowHandle >= 0)
                iRow = gridView2.FocusedRowHandle;

            #region 换算率
            if (e.Column == gridColumn物料编码 || e.Column == gridColumn物料名称 || e.Column == gridColumn规格型号)
            {
                if (e.Column == gridColumn物料编码)
                {
                    gridView2.SetRowCellValue(iRow, gridColumn物料名称, gridView2.GetRowCellValue(iRow, gridColumn物料编码).ToString().Trim());
                    gridView2.SetRowCellValue(iRow, gridColumn规格型号, gridView2.GetRowCellValue(iRow, gridColumn物料编码).ToString().Trim());
                }
                string invocde = gridView2.GetRowCellValue(iRow, gridColumn物料编码).ToString().Trim();
                sSQL = "select 换算率 from Inventory where cInvCode='" + invocde + "'";
                decimal d换算率 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (d换算率 > 0)
                {
                    gridView2.SetRowCellValue(iRow, gridColumn换算率, d换算率);
                }
                else
                {
                    gridView2.SetRowCellValue(iRow, gridColumn换算率, null);
                }
            }
            if (e.Column == gridColumn数量 || e.Column == gridColumn换算率)
            {
                if (gridView2.GetRowCellValue(iRow, gridColumn换算率).ToString().Trim() != "")
                {
                    decimal 换算率 = ReturnDecimal(gridView2.GetRowCellValue(iRow, gridColumn换算率));
                    decimal 数量 = 0;
                    if (gridView2.GetRowCellValue(iRow, gridColumn数量).ToString().Trim() != "")
                    {
                        数量 = ReturnDecimal(gridView2.GetRowCellValue(iRow, gridColumn数量));
                    }
                    if (数量 == 0)
                    {
                        gridView2.SetRowCellValue(iRow, gridColumn件数, null);
                    }
                    else
                    {
                        gridView2.SetRowCellValue(iRow, gridColumn件数, ReturnDecimal(数量 * 换算率));
                    }

                }
                else
                {
                    gridView2.SetRowCellValue(iRow, gridColumn件数, null);
                }
            }
            #endregion

            #region 换算率
            if (e.Column == gridColumn子件编码 || e.Column == gridColumn子件名称 || e.Column == gridColumn子件规格)
            {
                if (e.Column == gridColumn子件编码)
                {
                    gridView2.SetRowCellValue(iRow, gridColumn子件名称, gridView2.GetRowCellValue(iRow, gridColumn子件编码).ToString().Trim());
                    gridView2.SetRowCellValue(iRow, gridColumn子件规格, gridView2.GetRowCellValue(iRow, gridColumn子件编码).ToString().Trim());
                }
                string invocde = gridView2.GetRowCellValue(iRow, gridColumn子件编码).ToString().Trim();
                sSQL = "select 换算率 from Inventory where cInvCode='" + invocde + "'";
                decimal d换算率 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                if (d换算率 > 0)
                {
                    gridView2.SetRowCellValue(iRow, gridColumn子件换算率, d换算率);
                }
                else
                {
                    gridView2.SetRowCellValue(iRow, gridColumn子件换算率, null);
                }
            }
            if (e.Column == gridColumn子件数量 || e.Column == gridColumn子件换算率)
            {
                if (gridView2.GetRowCellValue(iRow, gridColumn子件换算率).ToString().Trim() != "")
                {
                    decimal 换算率 = ReturnDecimal(gridView2.GetRowCellValue(iRow, gridColumn子件换算率));
                    decimal 数量 = 0;
                    if (gridView2.GetRowCellValue(iRow, gridColumn子件数量).ToString().Trim() != "")
                    {
                        数量 = ReturnDecimal(gridView2.GetRowCellValue(iRow, gridColumn子件数量));
                    }
                    if (数量 == 0)
                    {
                        gridView2.SetRowCellValue(iRow, gridColumn子件件数, null);
                    }
                    else
                    {
                        gridView2.SetRowCellValue(iRow, gridColumn子件件数, ReturnDecimal(数量 * 换算率));
                    }
                }
                else
                {
                    gridView2.SetRowCellValue(iRow, gridColumn子件件数, null);
                }
            }
            #endregion

            #region 换算率
            if (e.Column == gridColumn代替料 || e.Column == gridColumn代替料名称 || e.Column == gridColumn代替料规格型号)
            {
                if (gridView2.GetRowCellValue(iRow, gridColumn代替料) != null)
                {
                    if (e.Column == gridColumn代替料)
                    {
                        gridView2.SetRowCellValue(iRow, gridColumn代替料名称, gridView2.GetRowCellValue(iRow, gridColumn代替料).ToString().Trim());
                        gridView2.SetRowCellValue(iRow, gridColumn代替料规格型号, gridView2.GetRowCellValue(iRow, gridColumn代替料).ToString().Trim());
                    }
                    if (gridView2.GetRowCellValue(iRow, gridColumn代替料) != null)
                    {
                        string invocde = gridView2.GetRowCellValue(iRow, gridColumn代替料).ToString().Trim();
                        sSQL = "select 换算率 from Inventory where cInvCode='" + invocde + "'";
                        decimal d换算率 = ReturnDecimal(clsSQLCommond.ExecGetScalar(sSQL));
                        if (d换算率 > 0)
                        {
                            gridView2.SetRowCellValue(iRow, gridColumn代替料换算率, d换算率);
                        }
                        else
                        {
                            gridView2.SetRowCellValue(iRow, gridColumn代替料换算率, null);
                        }
                    }
                    else
                    {
                        gridView2.SetRowCellValue(iRow, gridColumn代替料换算率, null);
                    }
                }
            }
            if (e.Column == gridColumn代替料数量 || e.Column == gridColumn代替料换算率)
            {
                if (gridView2.GetRowCellValue(iRow, gridColumn代替料换算率) != null)
                {
                    decimal 换算率 = ReturnDecimal(gridView2.GetRowCellValue(iRow, gridColumn代替料换算率));
                    decimal 数量 = 0;
                    if (gridView2.GetRowCellValue(iRow, gridColumn代替料数量).ToString().Trim() != "")
                    {
                        数量 = ReturnDecimal(gridView2.GetRowCellValue(iRow, gridColumn代替料数量));
                    }
                    if (数量 == 0)
                    {
                        gridView2.SetRowCellValue(iRow, gridColumn代替料件数, null);
                    }
                    else
                    {
                        gridView2.SetRowCellValue(iRow, gridColumn代替料件数, ReturnDecimal(数量 * 换算率));
                    }

                }
                else
                {
                    gridView2.SetRowCellValue(iRow, gridColumn代替料件数, null);
                }
            }
            #endregion

            #region 选择销售订单
            if (e.Column == gridColumn销售订单子表ID)
            {
                DataTable dt = (DataTable)gridControl2.DataSource;
                if (gridView2.GetRowCellValue(iRow, gridColumn销售订单子表ID) != null)
                {
                    DataRow[] dw = dt.Select("SoAutoID='" + gridView2.GetRowCellValue(iRow, gridColumn销售订单子表ID).ToString().Trim() + "'");
                    if (dw.Length > 0)
                    {
                        if (dw[0]["AutoID"].ToString() != "")
                        {
                            gridView2.SetRowCellValue(iRow, gridColumn1, dw[0]["AutoID"].ToString());
                        }
                        gridView2.SetRowCellValue(iRow, gridColumn序号, dw[0]["iRowNo"].ToString());
                        gridView2.SetRowCellValue(iRow, gridColumn物料编码, dw[0]["cInvCode"].ToString());
                        gridView2.SetRowCellValue(iRow, gridColumn数量, dw[0]["iQuantity"].ToString());
                        gridView2.SetRowCellValue(iRow, gridColumn子件编码, dw[0]["scInvCode"].ToString());
                        gridView2.SetRowCellValue(iRow, gridColumn子件数量, 0);
                        gridView2.SetRowCellValue(iRow, gridColColumn使用数量, dw[0]["iUsedQty"].ToString());
                    }
                }
            }
            #endregion

            if (e.Column == gridCol销售订单子表ID && e.RowHandle == gridView2.RowCount - 1 && gridView2.GetRowCellDisplayText(e.RowHandle, gridCol销售订单子表ID).ToString().Trim() != "")
            {
                gridView2.AddNewRow();
                gridView2.FocusedRowHandle = iRow;
            }


        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (isChange != "N")
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol行关闭人) != null)
                {
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol行关闭人).ToString().Trim() != "")
                    {
                        gridView1.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        gridView1.OptionsBehavior.Editable = true;
                    }
                }
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2) != null)
            {
                if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridColumn2).ToString().Trim() == "")
                {
                    gridColumn销售订单子表ID.OptionsColumn.ReadOnly = false;
                }
                else
                {
                    gridColumn销售订单子表ID.OptionsColumn.ReadOnly = true;
                }
            }
            else
            {
                gridColumn销售订单子表ID.OptionsColumn.ReadOnly = false;
            }
        }

        private void gridView2_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            
        }



        private void lookUpEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
            {
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
                if (lookUpEdit客户.Text.Trim() != "")
                {
                    DataTable dt = 系统服务.LookUp.CustomercCusPPerson(buttonEdit客户.Text.Trim());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        buttonEdit业务员.EditValue = dt.Rows[0]["cCusPPerson"];
                    }
                }
            }
            else
            {
                buttonEdit客户.EditValue = null;
                lookUpEdit业务员.EditValue = null;
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

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit发货人_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit发货人.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit发货人_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit发货人.Text.Trim() != "")
                lookUpEdit发货人.EditValue = buttonEdit发货人.Text.Trim();
            else
                lookUpEdit发货人.EditValue = null;
        }

        private void buttonEdit发货人_Leave(object sender, EventArgs e)
        {
            if (buttonEdit发货人.Text.Trim() == "")
                return;
            if (lookUpEdit发货人.Text.Trim() == "")
            {
                buttonEdit发货人.Text = "";
                buttonEdit发货人.Focus();
            }
        }

        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
            else
                lookUpEdit客户.EditValue = null;
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() == "")
                return;
            if (lookUpEdit客户.Text.Trim() == "")
            {
                buttonEdit客户.Text = "";
                buttonEdit客户.Focus();
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
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
                sSQL = "select  isnull(dCreatesysPerson,'') as 制单人,isnull(dVerifysysPerson,'') as 审核人,isnull(dClosesysPerson,'') as 关闭人 from " + tablename + " where " + tableid + " = '" + sCode + "'";
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

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void radioGroup蓝红标识_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroup蓝红标识.EditValue.ToString().Trim() == "2")
            {
                layoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                layoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView2.FocusedRowHandle > 0)
                iRow = gridView2.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView2.SetRowCellValue(iRow, gridColumn物料编码, frm.sID);


                frm.Enabled = true;
            }
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView2.FocusedRowHandle > 0)
                iRow = gridView2.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView2.SetRowCellValue(iRow, gridColumn子件编码, frm.sID);

                frm.Enabled = true;
            }
        }

        private void repositoryItemButtonEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView2.FocusedRowHandle > 0)
                iRow = gridView2.FocusedRowHandle;

            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView2.SetRowCellValue(iRow, gridColumn代替料, frm.sID);


                frm.Enabled = true;
            }
        }

    }
}
