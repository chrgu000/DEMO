using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Data.SqlClient;
using FrameBaseFunction;


namespace ImportDLL
{
    public partial class Frm销售发票导入 : FrameBaseFunction.FrmFromModel
    {
        ClsExcel clsexcel = FrameBaseFunction.ClsExcel.Instance();
        

        DataTable dtGridInfo;

        string sTable = "";

        public Frm销售发票导入()
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
            gridView1.OptionsCustomization.AllowColumnMoving = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            //sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            //sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            //if (File.Exists(sLayoutHeadPath))
            //    layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            //if (File.Exists(sLayoutGridPath))
            //{
            //    gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            //}

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
            //DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
           
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //}

            //return dt;
            return null;
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
                MessageBox.Show(ee.Message);
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


                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：取消保存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    int iCou = 0;
                    SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        sSQL = @"update [dbo].[列表设置] set [可见] = 0 where 库名 = '.' and [表名] = '111111'";
                        sSQL = sSQL.Replace("111111", sTable);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        for (int i = 0; i < gridView1.Columns.Count; i++)
                        {
                            int iW = gridView1.Columns[i].Width;
                            string sColName = gridView1.Columns[i].FieldName.Trim();
                            string sColText = gridView1.Columns[i].Caption.Trim();
                            int iIndex = gridView1.Columns[i].VisibleIndex;
                            bool bVis = gridView1.Columns[i].Visible;

                            sSQL = @"update [dbo].[列表设置] set [排序] = 444444,[可见] = 555555, [宽度] = " + iW + " where 库名 = '.' and [表名] = '111111' and [列名] = '222222' and [列标题] = '333333'";
                            sSQL = sSQL.Replace("111111", sTable);
                            sSQL = sSQL.Replace("222222", sColName);
                            sSQL = sSQL.Replace("333333", sColText);
                            sSQL = sSQL.Replace("444444", iIndex.ToString().Trim());
                            if (bVis)
                            {
                                sSQL = sSQL.Replace("555555", "1");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("555555", "0");
                            }
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        }
                        if (iCou > 0)
                        {
                            tran.Commit();
                        }
                        else
                        {
                            tran.Rollback();
                        }
                    }
                    catch (Exception error)
                    {
                        tran.Rollback();

                        throw new Exception(error.Message);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {
            string sErr = "";
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel文件(*.xlsx)|*.xlsx|Excel文件(*.xls)|*.xls";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select 序号,地区,名称,组别,数量,单价,作番号,完纳单号,完纳日期";

                    if (radio含税.Checked == true)
                    {
                        sSQL = sSQL + ",[总价(含税)],null as [总价(不含税)]";
                        gridCol总价含税.OptionsColumn.AllowEdit = true;
                        gridCol总价不含税.OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        sSQL = sSQL + ",null as [总价(含税)],[总价(不含税)]";
                        gridCol总价含税.OptionsColumn.AllowEdit = false;
                        gridCol总价不含税.OptionsColumn.AllowEdit = true;
                    }
                    if (radio客户单号.Checked == true)
                    {
                        sSQL = sSQL + ",订单号 as 客户订单号,'' as T6单号";
                        gridCol客户订单号.OptionsColumn.AllowEdit = true;
                        gridCol订单号.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        sSQL = sSQL + ",'' as 客户订单号,订单号 as T6单号";
                        gridCol客户订单号.OptionsColumn.AllowEdit = true;
                        gridCol订单号.OptionsColumn.AllowEdit = true;
                    }
                    if (radioT6存货编码.Checked == true)
                    {
                        sSQL = sSQL + ",零件号码 as 产品编码,'' as 零件号码";
                        gridColT6存货编码.OptionsColumn.AllowEdit = true;
                        gridCol零件号码.OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        sSQL = sSQL + ",'' as 产品编码,零件号码";
                        gridColT6存货编码.OptionsColumn.AllowEdit = true;
                        gridCol零件号码.OptionsColumn.AllowEdit = true;
                    }
                    sSQL = sSQL + " from [发票$]";
                    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    for (int i = dtExcel.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dtExcel.Rows[i][0].ToString().Trim() == "" && dtExcel.Rows[i][1].ToString().Trim() == "" && dtExcel.Rows[i][2].ToString().Trim() == "" && dtExcel.Rows[i][3].ToString().Trim() == "" && dtExcel.Rows[i][4].ToString().Trim() == "")
                        {
                            dtExcel.Rows.RemoveAt(i);
                        }
                        else
                        {
                            string 零件号码 = dtExcel.Rows[i]["零件号码"].ToString();
                            if (radioT6存货编码.Checked == true)
                            {
                                零件号码 = dtExcel.Rows[i]["产品编码"].ToString();
                            }
                            string 订单号 = dtExcel.Rows[i]["客户订单号"].ToString();
                            if (radioT6单号.Checked == true)
                            {
                                订单号 = dtExcel.Rows[i]["T6单号"].ToString();
                            }
                            sSQL = "select * from @u8.SO_SOMain a left join  @u8.SO_SODetails b on a.ID=b.ID where (cInvCode= '" + 零件号码 + "' or cDefine30= '" + 零件号码 + "') and (cDefine22= '" + 订单号 + "'or a.cSOCode='" + 订单号 + "')";
                            DataTable dtso = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtso.Rows.Count > 0)
                            {
                                if (radio客户编码.Checked == true)
                                {
                                    dtExcel.Rows[i]["产品编码"] = dtso.Rows[0]["cInvCode"];
                                }
                                if (radio客户单号.Checked == true)
                                {
                                    dtExcel.Rows[i]["T6单号"] = dtso.Rows[0]["cSOCode"];
                                }
                            }
                        }
                    }
                    SetLookup();
                    gridControl1.DataSource = dtExcel;
                }
                else
                {
                    throw new Exception("取消导入");
                }
            }
            catch (Exception error)
            {
                tran.Rollback();

                throw new Exception(error.Message);
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            SetLookup();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
        }

        private void GetGrid()
        {
            throw new NotImplementedException();
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
            gridView1.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(i,gridView1.Columns["bChoose"])))
                {
                    gridView1.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
           
        }

      
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            int iErr = 0;
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {

                TH.DAL.SaleBillVouch DAL = new TH.DAL.SaleBillVouch();
                TH.DAL.SaleBillVouchs Dals = new TH.DAL.SaleBillVouchs();

                string sErr = "";
                long lCode = 0;
                long lID = 0;
                long lIDDetail = 0;

                int iCou = 0;

                sSQL = "SELECT * FROM UFSystem..UA_Identity WHERE cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' AND cVouchType = 'BILLVOUCH'";
                DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                {
                    sSQL = "INSERT INTO UFSystem..UA_Identity(cAcc_Id,cVouchType,iFatherId,iChildId)VALUES('111111','BILLVOUCH',0,0)";
                    sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                }
                else
                {
                    lID = ReturnObjectToLong(dt.Rows[0]["iFatherId"]);
                    lIDDetail = ReturnObjectToLong(dt.Rows[0]["iChildId"]);
                }

                DataTable dtGrid = (DataTable)gridControl1.DataSource;
                DataTable dts = dtGrid.Copy();
                dts.Columns.Add("cCusCode");
                dts.Columns.Add("cSTCode");
                dts.Columns.Add("iTaxRate");
                dts.Columns.Add("cPersonCode");
                dts.Columns.Add("cDepCode");
                dts.Columns.Add("cexch_name");
                dts.Columns.Add("iExchRate");
                dts.Columns.Add("cBusType");
                dts.Columns.Add("cCusName");
                dts.Columns.Add("cSOCode");
                dts.Columns.Add("cGroupCode");
                dts.Columns.Add("iSOsID");
                //dts.Columns.Add("iDLsID");
                dts.Columns.Add("cWhCode");
                dts.Columns.Add("cInvCode");
                dts.Columns.Add("cInvName");
                dts.Columns.Add("iQuantity");
                dts.Columns.Add("iNum");
                dts.Columns.Add("iInvExchRate");
                dts.Columns.Add("cUnitID");
                dts.Columns.Add("AutoID");
                dts.Columns.Add("cDefine22");
                dts.Columns.Add("cDefine23");
                dts.Columns.Add("cDefine24");
                dts.Columns.Add("cDefine25");
                dts.Columns.Add("cDefine26");
                dts.Columns.Add("cDefine27");
                dts.Columns.Add("cDefine28");
                dts.Columns.Add("cDefine29");
                dts.Columns.Add("cDefine30");
                dts.Columns.Add("cDefine31");
                dts.Columns.Add("cDefine32");
                dts.Columns.Add("cDefine33");
                dts.Columns.Add("cDefine34");
                dts.Columns.Add("cDefine35");
                dts.Columns.Add("cDefine36");
                dts.Columns.Add("cDefine37");
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    string 零件号码 = dts.Rows[i]["零件号码"].ToString();
                    if (radioT6存货编码.Checked == true)
                    {
                        零件号码 = dts.Rows[i]["产品编码"].ToString();
                    }
                    string 订单号 = dts.Rows[i]["客户订单号"].ToString();
                    if (radioT6单号.Checked == true)
                    {
                        订单号 = dts.Rows[i]["T6单号"].ToString();
                    }
                    string 完纳单号 = dts.Rows[i]["完纳单号"].ToString();
                    string 完纳日期 = dts.Rows[i]["完纳日期"].ToString();
                    string iSOsID = "";
                    string cSOCode = "";
                    string cInvCode = "";
                    string cGroupCode = "";
                    if (完纳单号 != "")
                    {
                        sSQL = "select * from @u8.SaleBillVouch where isnull(cVerifier,'')!='' and cSBVCode= '" + 完纳单号 + "'";
                        DataTable dtsv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtsv.Rows.Count > 0)
                        {
                            sErr = sErr + "行：" + (i + 1) + ",T6单号或客户订单号：" + 订单号 + ",T6存货编码或零件号码：" + 零件号码 + ",完纳单号：" + 完纳单号 + ",完纳单号已导入\n";
                        }
                    }
                    if (订单号 == "")
                    {
                        sErr = sErr + "行：" + (i + 1) + ",T6存货编码或零件号码：" + 零件号码 + ",完纳单号：" + 完纳单号 + ",订单号不可为空,请输入销售订单号或客户订单号\n";
                    }
                    if (完纳日期 == "")
                    {
                        sErr = sErr + "行：" + (i + 1) + ",T6单号或客户订单号：" + 订单号 + ",T6存货编码或零件号码：" + 零件号码 + ",完纳单号：" + 完纳单号 + ",完纳日期不可为空\n";
                    }
                    #region 判断以哪种方式输入
                    decimal d原币含税金额 = ReturnObjectToDecimal(dts.Rows[i]["总价(含税)"], 4);
                    decimal d原币无税金额 = ReturnObjectToDecimal(dts.Rows[i]["总价(不含税)"], 4);
                    if (radio含税.Checked == true && d原币含税金额 == 0)
                    {
                        sErr = sErr + "行：" + (i + 1) + ",T6单号或客户订单号：" + 订单号 + ",T6存货编码或零件号码：" + 零件号码 + ",完纳单号：" + 完纳单号 + ",含税金额不可为0或空\n";
                    }
                    if (radio不含税.Checked == true && d原币无税金额 == 0)
                    {
                        sErr = sErr + "行：" + (i + 1) + ",T6单号或客户订单号：" + 订单号 + ",T6存货编码或零件号码：" + 零件号码 + ",完纳单号：" + 完纳单号 + ",不含税金额不可为0或空\n";
                    }
                    #endregion
                    decimal 发票数量 = ReturnObjectToDecimal(dts.Rows[i]["数量"].ToString(), 6);
                    #region 是否有订单
                    sSQL = "select * from @u8.SO_SOMain a left join  @u8.SO_SODetails b on a.ID=b.ID where isnull(cVerifier,'')!='' and  (cInvCode= '" + 零件号码 + "' or cDefine30= '" + 零件号码 + "') and (cDefine22= '" + 订单号 + "'or a.cSOCode='" + 订单号 + "')";
                    DataTable dtso = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtso.Rows.Count > 0)
                    {
                        dts.Rows[i]["cCusCode"] = dtso.Rows[0]["cCusCode"];
                        dts.Rows[i]["cSTCode"] = dtso.Rows[0]["cSTCode"];
                        dts.Rows[i]["iTaxRate"] = dtso.Rows[0]["iTaxRate"];
                        dts.Rows[i]["cPersonCode"] = dtso.Rows[0]["cPersonCode"];
                        dts.Rows[i]["cDepCode"] = dtso.Rows[0]["cDepCode"];
                        dts.Rows[i]["cexch_name"] = dtso.Rows[0]["cexch_name"];
                        dts.Rows[i]["iExchRate"] = dtso.Rows[0]["iExchRate"];
                        dts.Rows[i]["cBusType"] = dtso.Rows[0]["cBusType"];
                        dts.Rows[i]["cCusName"] = dtso.Rows[0]["cCusName"];
                        dts.Rows[i]["cSOCode"] = dtso.Rows[0]["cSOCode"];
                        dts.Rows[i]["iSOsID"] = dtso.Rows[0]["iSOsID"];
                        dts.Rows[i]["iQuantity"] = dtso.Rows[0]["iQuantity"];
                        dts.Rows[i]["iNum"] = dtso.Rows[0]["iNum"];
                        dts.Rows[i]["iInvExchRate"] = dtso.Rows[0]["iInvExchRate"];
                        dts.Rows[i]["cUnitID"] = dtso.Rows[0]["cUnitID"];
                        dts.Rows[i]["cInvCode"] = dtso.Rows[0]["cInvCode"];
                        dts.Rows[i]["cInvName"] = dtso.Rows[0]["cInvName"];
                        dts.Rows[i]["AutoID"] = dtso.Rows[0]["AutoID"];
                        dts.Rows[i]["cDefine22"] = dtso.Rows[0]["cDefine22"];
                        dts.Rows[i]["cDefine23"] = dtso.Rows[0]["cDefine23"];
                        dts.Rows[i]["cDefine24"] = dtso.Rows[0]["cDefine24"];
                        dts.Rows[i]["cDefine25"] = dtso.Rows[0]["cDefine25"];
                        dts.Rows[i]["cDefine26"] = dtso.Rows[0]["cDefine26"];
                        dts.Rows[i]["cDefine27"] = dtso.Rows[0]["cDefine27"];
                        dts.Rows[i]["cDefine28"] = dtso.Rows[0]["cDefine28"];
                        dts.Rows[i]["cDefine29"] = dtso.Rows[0]["cDefine29"];
                        dts.Rows[i]["cDefine30"] = dtso.Rows[0]["cDefine30"];
                        dts.Rows[i]["cDefine31"] = dtso.Rows[0]["cDefine31"];
                        dts.Rows[i]["cDefine32"] = dtso.Rows[0]["cDefine32"];
                        dts.Rows[i]["cDefine33"] = dtso.Rows[0]["cDefine33"];
                        dts.Rows[i]["cDefine34"] = dtso.Rows[0]["cDefine34"];
                        dts.Rows[i]["cDefine35"] = dtso.Rows[0]["cDefine35"];
                        dts.Rows[i]["cDefine36"] = dtso.Rows[0]["cDefine36"];
                        dts.Rows[i]["cDefine37"] = dtso.Rows[0]["cDefine37"];

                        cSOCode = dtso.Rows[0]["cSOCode"].ToString();
                        iSOsID = dtso.Rows[0]["iSOsID"].ToString();
                        cInvCode = dtso.Rows[0]["cInvCode"].ToString();
                        sSQL = "select * from @u8.Inventory where cInvCode='" + cInvCode + "'";
                        DataTable dtinv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtinv.Rows.Count > 0)
                        {
                            dts.Rows[i]["cGroupCode"] = dtinv.Rows[0]["cGroupCode"];
                            cGroupCode = dtinv.Rows[0]["cGroupCode"].ToString();
                        }

                        //判断数量件数
                        sErr = sErr + IsQty(i, cSOCode, 完纳单号, cInvCode, 发票数量, iSOsID, cGroupCode, tran);
                    }
                    else
                    {
                        sErr = sErr + "行：" + (i + 1) + ",T6单号或客户订单号：" + 订单号 + ",T6存货编码或零件号码：" + 零件号码 + ",完纳单号：" + 完纳单号 + ",未找到相关销售订单\n";
                    }
                    #endregion
                    //#region 是否有发货单
                    //if (iSOsID != "")
                    //{
                    //    sSQL = "select * from @u8.DispatchLists a left join @u8.DispatchList b on a.DLID=b.DLID where isnull(cVerifier,'')!='' and iSOsID= '" + iSOsID + "'";
                    //    DataTable dtdl = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    //    if (dtdl.Rows.Count > 0)
                    //    {
                    //        dts.Rows[i]["iDLsID"] = dtdl.Rows[0]["iDLsID"].ToString();
                    //        dts.Rows[i]["cWhCode"] = dtdl.Rows[0]["cWhCode"].ToString();
                    //    }
                    //    else
                    //    {
                    //        sErr = sErr + "行：" + (i + 1) + ",T6单号或客户订单号：" + 订单号 + ",T6存货编码或零件号码：" + 零件号码 + ",完纳单号：" + 完纳单号 + ",未找到相关发货单\n";
                    //    }
                    //}
                    //#endregion

                }

                if (sErr.Trim() != "")
                    throw new Exception(sErr);

                DataTable dtgroup = Group(dts, new string[] { "cCusCode", "cSTCode", "iTaxRate", "cPersonCode", "cDepCode", "cexch_name", "iExchRate", "完纳日期", "完纳单号" }, "");
                for (int s = 0; s < dtgroup.Rows.Count; s++)
                {
                    #region 表头
                    string cDepCode = dtgroup.Rows[s]["cDepCode"].ToString().Trim();
                    string cPersonCode = dtgroup.Rows[s]["cPersonCode"].ToString().Trim();
                    decimal d税率 = ReturnObjectToDecimal(dtgroup.Rows[s]["iTaxRate"], 2);
                    decimal d汇率 = ReturnObjectToDecimal(dtgroup.Rows[s]["iExchRate"], 2);
                    string cCusCode = dtgroup.Rows[s]["cCusCode"].ToString().Trim();
                    string cexch_name = dtgroup.Rows[s]["cexch_name"].ToString().Trim();
                    string 完纳单号 = dtgroup.Rows[s]["完纳单号"].ToString().Trim();
                    string cSTCode = dtgroup.Rows[s]["cSTCode"].ToString().Trim();
                    DateTime d单据日期 = ReturnObjectToDatetime(dtgroup.Rows[s]["完纳日期"]);

                    #region 发票号
                    string cSBVCode = "";
                    if (完纳单号 != "")
                    {
                        cSBVCode = 完纳单号;
                    }
                    else
                    {
                        sSQL = "SELECT * FROM @u8.VoucherHistory WHERE CardNumber = '13' and cSeed = '" + d单据日期.ToString("yyyyMM") + "'";
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            lCode = ReturnObjectToLong(dt.Rows[0]["cNumber"]);
                        }
                        else
                        {
                            sSQL = "INSERT INTO @u8.VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)values('13','单据日期','月','" + d单据日期.ToString("yyyyMM") + "',1,0)";
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        lCode += 1;
                        cSBVCode = sCode(lCode, d单据日期);
                    }
                    #endregion

                    string isel = "cCusCode='" + cCusCode + "' and cSTCode='" + cSTCode + "' and iTaxRate='" + d税率 + "' and iExchRate='" + d汇率 + "' and cPersonCode='" + cPersonCode + "' and cDepCode='" + cDepCode + "' and cexch_name='" + cexch_name + "'  and 完纳日期='" + d单据日期 + "' ";
                    if (完纳单号 == "")
                    {
                        isel = isel + " and 完纳单号 is null";
                    }
                    else
                    {
                        isel = isel + " and 完纳单号='" + 完纳单号 + "'";
                    }
                    DataTable dtsel = Select(dts, isel, "序号");
                    string cSOCode = dtsel.Rows[0]["cSOCode"].ToString().Trim();
                    string cBusType = dtsel.Rows[0]["cBusType"].ToString().Trim();
                    string cCusName = dtsel.Rows[0]["cCusName"].ToString().Trim();
                    lID = lID + 1;
                    long lIDMain = lID;

                    TH.Model.SaleBillVouch model = new TH.Model.SaleBillVouch();
                    model.SBVID = lIDMain;
                    model.cSBVCode = cSBVCode;
                    model.cVouchType = "26";
                    model.cSTCode = cSTCode;
                    model.iVTid = 53;
                    model.dDate = d单据日期;
                    model.cDepCode = cDepCode;
                    model.cPersonCode = cPersonCode;
                    model.cSOCode = cSOCode;
                    model.cCusCode = cCusCode;
                    model.cexch_name = cexch_name;
                    model.iTaxRate = d税率;
                    model.iExchRate = d汇率;
                    model.cexch_name = cexch_name;
                    model.bReturnFlag = false;
                    model.cMaker = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    model.cBusType = cBusType;
                    model.bFirst = false;
                    model.iDisp = 1;
                    model.cCusName = cCusName;
                    model.cSource = "销售";
                    model.cAccountPDate = d单据日期;
                    model.cDefine10 = "Y";

                    sSQL = DAL.Add(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    #endregion

                    string 表头发货单号 = "";
                    #region 表体
                    for (int j = 0; j < dtsel.Rows.Count; j++)
                    {
                        long iSOsID = ReturnObjectToLong(dtsel.Rows[j]["iSOsID"].ToString());
                        decimal iQuantity = ReturnObjectToDecimal(dtsel.Rows[j]["iQuantity"], 6);
                        decimal iNum = ReturnObjectToDecimal(dtsel.Rows[j]["iNum"], 6);
                        decimal i原币含税金额 = ReturnObjectToDecimal(dtsel.Rows[j]["总价(含税)"], 4);
                        decimal i原币无税金额 = ReturnObjectToDecimal(dtsel.Rows[j]["总价(不含税)"], 4);
                        string cInvCode = dtsel.Rows[j]["cInvCode"].ToString();
                        string cInvName = dtsel.Rows[j]["cInvName"].ToString();
                        decimal soAutoID = ReturnObjectToDecimal(dtsel.Rows[j]["AutoID"], 2);
                        string cSoCode = dtsel.Rows[j]["cSoCode"].ToString();
                        decimal iInvExchRate = ReturnObjectToDecimal(dtsel.Rows[j]["iInvExchRate"].ToString(), 6);
                        string cUnitID = dtsel.Rows[j]["cUnitID"].ToString();

                        string cDefine22 = dtsel.Rows[j]["cDefine22"].ToString();
                        string cDefine23 = dtsel.Rows[j]["cDefine23"].ToString();
                        string cDefine24 = dtsel.Rows[j]["cDefine24"].ToString();
                        string cDefine25 = dtsel.Rows[j]["cDefine25"].ToString();
                        decimal cDefine26 = ReturnObjectToDecimal(dtsel.Rows[j]["cDefine26"].ToString(), 4);
                        decimal cDefine27 = ReturnObjectToDecimal(dtsel.Rows[j]["cDefine27"].ToString(), 4);
                        string cDefine28 = dtsel.Rows[j]["cDefine28"].ToString();
                        string cDefine29 = dtsel.Rows[j]["cDefine29"].ToString();
                        string cDefine30 = dtsel.Rows[j]["cDefine30"].ToString();
                        string cDefine31 = dtsel.Rows[j]["cDefine31"].ToString();
                        string cDefine32 = dtsel.Rows[j]["cDefine32"].ToString();
                        string cDefine33 = dtsel.Rows[j]["cDefine33"].ToString();
                        int cDefine34 = ReturnObjectToInt(dtsel.Rows[j]["cDefine34"].ToString());
                        int cDefine35 = ReturnObjectToInt(dtsel.Rows[j]["cDefine35"].ToString());
                        DateTime cDefine36 = ReturnObjectToDatetime(dtsel.Rows[j]["cDefine36"].ToString());
                        DateTime cDefine37 = ReturnObjectToDatetime(dtsel.Rows[j]["cDefine37"].ToString());

                        sSQL = "select a.*,b.cDLCode from @u8.DispatchLists a left join @u8.DispatchList b on a.DLID=b.DLID where a.iSOsID= '" + iSOsID + "'";
                        DataTable dtdl = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        for (int i = 0; i < dtdl.Rows.Count; i++)
                        {
                            if (表头发货单号 != "")
                            {
                                表头发货单号 = 表头发货单号 + ",";
                            }
                            表头发货单号 = dtdl.Rows[i]["cDLCode"].ToString();
                            long iDLsID = ReturnObjectToLong(dtdl.Rows[i]["iDLsID"].ToString());

                            string cWhCode = dtdl.Rows[i]["cWhCode"].ToString();

                            decimal d数量 = ReturnObjectToDecimal(dtdl.Rows[i]["iQuantity"], 6);
                            decimal d件数 = ReturnObjectToDecimal(dtdl.Rows[i]["iNum"], 2);

                            decimal d原币含税单价 = 0;
                            decimal d原币无税单价 = 0;
                            decimal d原币含税金额 = ReturnObjectToDecimal(i原币含税金额 * d数量 / iQuantity, 4);
                            decimal d原币无税金额 = ReturnObjectToDecimal(i原币无税金额 * d数量 / iQuantity, 4);
                            decimal d原币税额 = 0;

                            decimal d本币含税单价 = 0;
                            decimal d本币无税单价 = 0;
                            decimal d本币含税金额 = 0;
                            decimal d本币无税金额 = 0;
                            decimal d本币税额 = 0;

                            GetMoney(d税率, d汇率, d数量, d原币含税金额, d原币无税金额,
                                out d原币含税单价, out d原币无税单价, out d原币含税金额, out d原币无税金额, out d原币税额,
                                out d本币含税单价, out d本币无税单价, out d本币含税金额, out d本币无税金额, out d本币税额);

                            lIDDetail += 1;
                            TH.Model.SaleBillVouchs models = new TH.Model.SaleBillVouchs();
                            models.SBVID = lIDMain;
                            models.AutoID = lIDDetail;
                            models.cWhCode = cWhCode;
                            models.cInvCode = cInvCode;
                            models.iQuantity = d数量;
                            models.iNum = d件数;
                            models.iQuotedPrice = 0;
                            models.iSOsID = iSOsID;
                            models.iDLsID = iDLsID;
                            models.KL = 100;
                            models.KL2 = 100;
                            models.cInvName = cInvName;
                            models.cSoCode = cSoCode;
                            models.iInvExchRate = iInvExchRate;
                            models.cUnitID = cUnitID;

                            models.iTaxRate = d税率;

                            models.iTaxUnitPrice = d原币含税单价;
                            models.iUnitPrice = d原币无税单价;
                            models.iSum = d原币含税金额;
                            models.iMoney = d原币无税金额;
                            models.iTax = d原币税额;
                            models.iDisCount = 0;

                            models.iNatUnitPrice = d本币无税单价;
                            models.iNatSum = d本币含税金额;
                            models.iNatMoney = d本币无税金额;
                            models.iNatTax = d本币税额;
                            models.iNatDisCount = 0;

                            models.cDefine22 = cDefine22;
                            models.cDefine23 = cDefine23;
                            models.cDefine24 = cDefine24;
                            models.cDefine25 = cDefine25;
                            models.cDefine26 = cDefine26;
                            models.cDefine27 = cDefine27;
                            models.cDefine28 = cDefine28;
                            models.cDefine29 = cDefine29;
                            models.cDefine30 = cDefine30;
                            models.cDefine31 = cDefine31;
                            models.cDefine32 = cDefine32;
                            models.cDefine33 = cDefine33;
                            models.cDefine34 = cDefine34;
                            models.cDefine35 = cDefine35;
                            if (cDefine36.ToString() != "1900/1/1 0:00:00")
                            {
                                models.cDefine36 = cDefine36;
                            }
                            if (cDefine37.ToString() != "1900/1/1 0:00:00")
                            {
                                models.cDefine37 = cDefine37;
                            }
                            sSQL = Dals.Add(models);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        #region 反写
                        sSQL = "update  @u8.SO_SODetails set iKPQuantity=iKPQuantity+" + iQuantity + ",iKPNum=iKPNum+" + iNum + ",iKPMoney=iKPMoney+" + i原币含税金额 + " where AutoID='" + soAutoID + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        sSQL = "update @u8.DispatchLists set iSettleQuantity=iSettleQuantity+" + iQuantity + ",iSettleNum=iSettleNum+" + iNum + "  where AutoID='" + soAutoID + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        #endregion
                        sSQL = "update @u8.SaleBillVouch set cDLCode='" + 表头发货单号 + "' where SBVID='" + lIDMain + "'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    #endregion

                    #region 更新发票号记录档案
                    if (完纳单号 == "")
                    {
                        sSQL = "UPDATE @u8.VoucherHistory SET cNumber = 111111 WHERE CardNumber = '13' and cSeed = '" + d单据日期.ToString("yyyyMM") + "'";
                        sSQL = sSQL.Replace("111111", lCode.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    #endregion
                    iCou = iCou + 1;
                }

                sSQL = "UPDATE UFSystem..UA_Identity SET iFatherId = 111111,iChildId = 222222 WHERE cAcc_Id = '333333' AND cVouchType = 'BILLVOUCH'";
                sSQL = sSQL.Replace("111111", lID.ToString());
                sSQL = sSQL.Replace("222222", lIDDetail.ToString());
                sSQL = sSQL.Replace("333333", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);



                tran.Commit();

                if (iCou > 0)
                {
                    MessageBox.Show("保存成功");

                }
            }
            catch (Exception ee)
            {
                tran.Rollback();
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
 
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            
        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                btnRefresh();
           
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
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

        private void SetLookup()
        {
            sSQL = "SELECT cInvCode,cInvName,cInvStd FROM @u8.Inventory ORDER BY cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit物料.DataSource = dt;

            sSQL = "SELECT cWhCode,cWhName FROM @u8.Warehouse ORDER BY cWhCode";
            DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit仓库.DataSource = dt;

            sSQL = "SELECT cSOCode FROM @u8.SO_SOMain where isnull(cVerifier,'')!='' ORDER BY cSOCode";
            DataTable dt3 = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit订单号.DataSource = dt3;
        }

        private string sCode(long lCode, DateTime d单据日期)
        {
            string sCode = lCode.ToString().Trim();
            while (sCode.Length < 5)
            {
                sCode = "0" + sCode;
            }
            sCode = "SV" + d单据日期.ToString("yyyyMM") + sCode;

            return sCode;
        }

        public static DataTable Group(DataTable dt, string[] ColumnName, string Sel)
        {
            DataRow[] dw = dt.Select(Sel);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            DataView dv = new DataView(dts);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            return dtgroup;
        }

        public static DataTable Select(DataTable dt, string Sel, string Order)
        {
            DataRow[] dw = dt.Select(Sel, Order);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            return dts;
        }

        public decimal GetNowQty(string cInvCode, string cWhCode,SqlTransaction tran)
        {
            string sSQL = "select *,iQuantity-isnull(fOutQuantity,0)-isnull(fTransOutQuantity,0) as 现存量 from @u8.CurrentStock where cInvCode='" + cInvCode + "' and cWhCode='" + cWhCode + "'";
            DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return ReturnObjectToDecimal(dt.Rows[0]["现存量"], 2);
            }
            return 0;
        }

        private string IsQty(int i, string sCode, string 完纳单号, string cInvCode, decimal d数量, string iSOsID, string cGroupCode, SqlTransaction tran)
        {
            string sErr = "";
            decimal 订单数量 = 0;
            decimal 出库单数量 = 0;
            decimal 发票数量 = 0;
            string type = "";
            string type2 = "";
            if (cGroupCode == "W000")
            {
                type = "iQuantity";
                type2 = "数量";
            }
            else
            {
                type = "iNum";
                type2 = "件数";
            }
            sSQL = "select sum(" + type + ") as iQuantity from @u8.SO_SODetails a left join @u8.SO_SOMain b on a.ID=b.ID where isnull(cVerifier,'')!='' and a.iSOsID= '" + iSOsID + "'";
            DataTable dt1 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                订单数量 = ReturnObjectToDecimal(dt1.Rows[0]["iQuantity"].ToString(), 6);
            }
            sSQL = "select sum(" + type + ") as iQuantity from @u8.DispatchLists a left join @u8.DispatchList b on a.DLID=b.DLID where isnull(cVerifier,'')!='' and  iSOsID= '" + iSOsID + "'";
            DataTable dt2 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            if (dt2.Rows.Count > 0)
            {
                出库单数量 = ReturnObjectToDecimal(dt2.Rows[0]["iQuantity"].ToString(), 6);
            }
            sSQL = "select sum(" + type + ") as iQuantity from @u8.SaleBillVouchs where iSOsID= '" + iSOsID + "'";
            DataTable dt3 = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            if (dt3.Rows.Count > 0)
            {
                发票数量 = ReturnObjectToDecimal(dt3.Rows[0]["iQuantity"].ToString(), 6);
            }
            if (订单数量 != d数量)//订单数量需等于开票数量
            {
                sErr = sErr + "行：" + (i + 1) + ",T6单号或客户订单号：" + sCode + ",T6存货编码或零件号码：" + cInvCode + ",完纳单号：" + 完纳单号 + ",订单" + type2 + "需等于开票" + type2 + "\n";
            }
            if (订单数量 != 出库单数量)//订单数量需等于出库单数量
            {
                sErr = sErr + "行：" + (i + 1) + ",T6单号或客户订单号：" + sCode + ",T6存货编码或零件号码：" + cInvCode + ",完纳单号：" + 完纳单号 + ",订单" + type2 + "需等于出库单" + type2 + "\n";
            }
            if (发票数量 > 0)
            {
                sErr = sErr + "行：" + (i + 1) + ",T6单号或客户订单号：" + sCode + ",T6存货编码或零件号码：" + cInvCode + ",完纳单号：" + 完纳单号 + ",已生成发票\n";
            }
            return sErr;
        }

        private void GetMoney(decimal d税率, decimal d汇率,decimal d数量,decimal 原币含税金额,decimal 原币无税金额,
            out decimal d原币含税单价, out decimal d原币无税单价, out decimal d原币含税金额, out decimal d原币无税金额, out decimal d原币税额,
            out decimal d本币含税单价, out decimal d本币无税单价, out decimal d本币含税金额, out decimal d本币无税金额, out decimal d本币税额)
        {
            if (原币含税金额 != 0)
            {
                d原币含税金额 = ReturnObjectToDecimal(原币含税金额,2);
                d原币无税金额 = ReturnObjectToDecimal(d原币含税金额 / (1 + d税率 / 100),2);
                d原币含税单价 = ReturnObjectToDecimal(d原币含税金额 / d数量,4);
                d原币无税单价 = ReturnObjectToDecimal(d原币含税金额 / (1 + d税率 / 100) / d数量, 4);
                d原币税额 = d原币含税金额 - d原币无税金额;

                d本币含税金额 = ReturnObjectToDecimal(d原币含税金额 * d汇率,2);
                d本币无税金额 = ReturnObjectToDecimal(d原币无税金额 * d汇率,2);
                d本币含税单价 = ReturnObjectToDecimal(d原币含税单价 / d汇率, 4);
                d本币无税单价 = ReturnObjectToDecimal(d原币无税单价 * d汇率, 4);
                d本币税额 = d本币含税金额 - d本币无税金额;
            }
            else if (原币无税金额 != 0)
            {
                d原币无税金额 = ReturnObjectToDecimal(原币无税金额,2);
                d原币含税金额 = ReturnObjectToDecimal(d原币无税金额 * (1 + d税率 / 100),2);
                d原币含税单价 = ReturnObjectToDecimal(d原币无税金额 * (1 + d税率 / 100) / d数量, 4);
                d原币无税单价 = ReturnObjectToDecimal(d原币无税金额 / d数量,4);
                d原币税额 = d原币含税金额 - d原币无税金额;

                d本币含税金额 = ReturnObjectToDecimal(d原币含税金额 * d汇率, 2);
                d本币无税金额 = ReturnObjectToDecimal(d原币无税金额 * d汇率, 2);
                d本币含税单价 = ReturnObjectToDecimal(d原币含税单价 / d汇率, 4);
                d本币无税单价 = ReturnObjectToDecimal(d原币无税单价 * d汇率, 4);
                d本币税额 = d本币含税金额 - d本币无税金额;
            }
            else
            {
                d原币无税金额 = 0;
                d原币含税金额 = 0;
                d原币含税单价 = 0;
                d原币无税单价 = 0;
                d原币税额 = 0;

                d本币含税金额 = 0;
                d本币无税金额 = 0;
                d本币含税单价 = 0;
                d本币无税单价 = 0;
                d本币税额 = 0;
            }
            d原币含税金额 = ReturnObjectToDecimal(d原币含税金额, 2);
            d原币无税金额 = ReturnObjectToDecimal(d原币无税金额, 2);
            d原币含税单价 = ReturnObjectToDecimal(d原币含税单价, 4);
            d原币无税单价 = ReturnObjectToDecimal(d原币无税单价, 4);
            d原币税额 = ReturnObjectToDecimal(d原币税额, 2);

            d本币含税金额 = ReturnObjectToDecimal(d本币含税金额, 2);
            d本币无税金额 = ReturnObjectToDecimal(d本币无税金额, 2);
            d本币含税单价 = ReturnObjectToDecimal(d本币含税单价, 4);
            d本币无税单价 = ReturnObjectToDecimal(d本币无税单价, 4);
            d本币税额 = ReturnObjectToDecimal(d本币税额, 2);
        }

    }
}
