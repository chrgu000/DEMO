using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using FrameBaseFunction;
using System.Data.SqlClient;

namespace SaleOrder
{
    public partial class FrmOrderReview下达计划 : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmOrderReview下达计划()
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

                SetEnable(false);

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
                    case "add":
                        btnAdd();
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

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnAdd()
        {
            //try
            //{
            //    SetTxtGridNull();

            //    FrmSaleList frmSaleList = new FrmSaleList();
            //    frmSaleList.ShowDialog();
            //    if (frmSaleList.DialogResult == DialogResult.OK)
            //    {
            //        string sOrderID = frmSaleList.sOrderID;

            //        SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString2);
            //        sSQL = "select a.ID as 销售订单ID,a.*,b.*,c.cInvName,c.cInvStd,d.cCusAbbName from so_somain a inner join so_sodetails b on a.ID = B.ID left join Inventory c on b.cInvCode = c.cInvCode left join Customer d on d.cCusCode = a.cCusCode where b.AutoID = '" + sOrderID + "'";
            //        DataTable dt = ClsSqlHelper.ExecuteDataset(conn, CommandType.Text, sSQL).Tables[0];

            //        string s行号 = dt.Rows[0]["iRowNo"].ToString().Trim();
            //        if (s行号.Length < 2)
            //        { 
            //            s行号 = "0" + s行号;
            //        }
            //        txt单据号.Text = dt.Rows[0]["cSOCode"].ToString().Trim() + s行号;
            //        dtm单据日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            //        txt销售订单号.Text = dt.Rows[0]["cSOCode"].ToString().Trim();
            //        txt行号.Text = dt.Rows[0]["iRowNo"].ToString().Trim();
            //        txt外销订单号.Text = dt.Rows[0]["cItemCode"].ToString().Trim();
            //        txt客户订单号.Text = dt.Rows[0]["cDefine2"].ToString().Trim();
            //        txt客户简称.Text = dt.Rows[0]["cCusAbbName"].ToString().Trim();
            //        dtm船期.Text = dt.Rows[0]["dPreDate"].ToString().Trim();
            //        dtm预完工日期.Text =  dt.Rows[0]["dPreMoDate"].ToString().Trim();          //预完工日期
            //        dtm国外要求交期.Text = dt.Rows[0]["cDefine36"].ToString().Trim();

            //        lookUpEdit产品名称.EditValue = dt.Rows[0]["cInvCode"];
            //        lookUpEdit规格型号.EditValue = dt.Rows[0]["cInvCode"];
            //        txt订单数量.Text = dt.Rows[0]["iQuantity"].ToString().Trim();               //销售数量

            //        dtm计划结束日期.DateTime = dtm预完工日期.DateTime;                          //结束日期
            //        dtm计划开始日期.DateTime = dtm预完工日期.DateTime;                          //默认结束日期，按照逆排取最小日期
            //        txt下单数量.Text = txt订单数量.Text;                                        //下单数量
            //        lookUpEdit产品编码.EditValue = dt.Rows[0]["cInvCode"];
            //        txt销售订单子表ID.Text = dt.Rows[0]["AutoID"].ToString().Trim();
            //        txt销售订单ID.Text = dt.Rows[0]["销售订单ID"].ToString().Trim();

            //        SetEnable(true);

            //        GetBOMPlan();

            //        sState = "add";

            //        SetGrid();
            //    }
            //}
            //catch (Exception ee)
            //{
            //    throw new Exception(ee.Message);
            //}
        }

        private void SetEnable(bool b)
        {
            btnSchedule.Enabled = b;
            radio顺排.Enabled = b;
            radio逆排.Enabled = b;
            dtm计划开始日期.Enabled = b;
            dtm计划结束日期.Enabled = b;
            txt下单数量.Enabled = b;
            txt备注.Enabled = b;

            lookUpEdit批改.Enabled = b;
            txt批改.Enabled = b;
            btnChange.Enabled = b;

            gridView1.OptionsBehavior.Editable = b;
            gridView2.OptionsBehavior.Editable = b;
            gridView3.OptionsBehavior.Editable = b;
            gridView4.OptionsBehavior.Editable = b;
        }

        DataTable dtBom = null;
        DataTable dt工时工序 = null;
        //private void GetBOMPlan()
        //{
        //    SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString2);
        //    conn.Open();
        //    //启用事务
        //    SqlTransaction tran = conn.BeginTransaction();
        //    try
        //    {
        //        string sInvCode = lookUpEdit产品编码.Text.Trim();
        //        DateTime dDate1 = dtm计划结束日期.DateTime;                     //预完工日期
        //        decimal dQty = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(txt下单数量.Text);             //下单数量

        //        ///一 展开BOM
        //        ///1. 获得BOM（单层），获得子件，使用数量，计算出毛需求量
        //        ///2. 获得工时工序表，当直接母件没有时搜寻其他母件下的工时工序表中有没有此物料，有则列表提醒人工选择（按照约定，相同物料应该拥有相同工时工序）
        //        ///3. 根据BOM子件，工时工序表获得采购、委外、生产周期
        //        ///4. 计算需求日期，根据库存、采购、委外、生产信息确定净需求（预留不参与计算的档案）
        //        ///5. 循环展开BOM直到最后一层结束
        //        ///备注：需要注意虚拟件、木制品；


        //        //获得BOM
        //        dtBom = GetBomSQL(tran, sInvCode);

        //        for (int i = 0; i < dtBom.Rows.Count; i++)
        //        {
        //            dtBom.Rows[i]["级别"] = dtBom.Rows[i]["级别"].ToString().Trim().Length;

        //            string sSQL = "select iInvAdvance as 提前期,cInvDefine3 as 最小批量 from Inventory where cInvCode = '" + dtBom.Rows[i]["子件编码"] + "'";
        //            DataTable dt = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "采购")
        //                {
        //                    dtBom.Rows[i]["采购周期"] = dt.Rows[0]["提前期"];
        //                }
        //                if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "委外")
        //                {
        //                    dtBom.Rows[i]["委外周期"] = dt.Rows[0]["提前期"];
        //                }

        //                decimal d = 0;
        //                try
        //                {
        //                    d = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["最小批量"]);
        //                }
        //                catch { }
        //                dtBom.Rows[i]["最小批量"] = d;
        //            }
        //        }

        //        for (int i = 0; i < dtBom.Rows.Count; i++)
        //        {
        //            if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "采购")
        //            {
        //                dtBom.Rows[i]["质检周期"] = 3;
        //            }
        //            if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "委外")
        //            {
        //                dtBom.Rows[i]["质检周期"] = 2;
        //            }
        //            if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "自制")
        //            {
        //                dtBom.Rows[i]["生产日工时"] = 8;
        //            }
        //        }

        //        string sErrBOM = "";
        //        //判断BOM是否完整
        //        //最末级是否采购件
        //        for (int i = 0; i < dtBom.Rows.Count; i++)
        //        {
        //            if (dtBom.Rows[i]["级别"].ToString().Trim() == "0")
        //            {
        //                continue;
        //            }
        //            string s子件属性 = dtBom.Rows[i]["子件属性"].ToString().Trim();
        //            if (s子件属性 == "采购")
        //                continue;

        //            string s子件编码 = dtBom.Rows[i]["子件编码"].ToString().Trim();
        //            DataRow[] dr = dtBom.Select(" 母件属性 = '" + s子件属性 + "' ");
        //            if (dr.Length == 0)
        //            {
        //                sErrBOM = sErrBOM + s子件编码 + "\n";
        //            }
        //        }
        //        if (sErrBOM.Trim() != "")
        //        {
        //            throw new Exception("请完善BOM\n物料：\n" + sErrBOM);
        //        }


        //        //获得工时工序
        //        dt工时工序 = Get工时工序(tran, sInvCode);

        //        if (dtBom == null || dtBom.Rows.Count < 1)
        //        {
        //            throw new Exception("物料" + sInvCode + " 未建立BOM");
        //        }

        //        InitBomN(tran, "--", decimal.Round(decimal.Parse(txt下单数量.Text), 6), dtm计划结束日期.DateTime);

        //        gridControl1.DataSource = dtBom;
        //        gridControl2.DataSource = dtBom;
        //        gridControl3.DataSource = dtBom;
        //        gridControl4.DataSource = dtBom; 

        //        tran.Commit();
        //    }

        //    catch (Exception error)
        //    {
        //        tran.Rollback();
        //        throw new Exception(error.Message);
        //    }
        //}

        ///// <summary>
        ///// 新增状态逆排计划
        ///// </summary>
        ///// <param name="tran"></param>
        ///// <param name="sInvCode">母件编码</param>
        ///// <param name="dQty">母件下单数量</param>
        ///// <param name="dDate1">计划结束日期</param>
        //private void InitBomN(SqlTransaction tran,string sInvCode, decimal dQty, DateTime dDate1)
        //{
        //    DataRow[] drList = dtBom.Select(" 母件编码 = '" + sInvCode + "' ");

        //    foreach (DataRow dr in drList)
        //    {
        //        dr["需求数量"] = decimal.Round(dQty * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["使用数量"]), 6);
        //        dr["本次下单数量"] = dr["需求数量"];

        //        double i置办周期 = 1;
        //        if (dr["子件属性"].ToString().Trim() == "采购" && dr["采购周期"].ToString().Trim() != "")
        //        {
        //            i置办周期 = ReturnObjectToInt(dr["采购周期"]) + ReturnObjectToInt(dr["质检周期"]);
        //        }
        //        if (dr["子件属性"].ToString().Trim() == "委外" && dr["委外周期"].ToString().Trim() != "")
        //        {
        //            i置办周期 = ReturnObjectToInt(dr["委外周期"]) + ReturnObjectToInt(dr["质检周期"]);
        //        }
        //        if (dr["子件属性"].ToString().Trim() == "自制")
        //        {
        //            DataRow[] dr工时List = dt工时工序.Select(" 物料编码 = '" + dr["子件编码"].ToString().Trim() + "' ");
        //            if (dr工时List.Length < 1)
        //            {
        //                //未设置母件工时工序，需要中其他母件工时工序表获得资料
        //            }

        //            double d工时 = 0;
        //            for (int i = 0; i < dr工时List.Length; i++)
        //            {
        //                if (dr工时List[i]["单位工时"].ToString().Trim() != "")
        //                {
        //                    d工时 = d工时 + Convert.ToDouble(dr工时List[i]["单位工时"]) * Convert.ToDouble(dr["本次下单数量"]) / Convert.ToDouble(dr工时List[i]["作业人员数量"]);
        //                }
        //            }
        //            i置办周期 = Math.Ceiling(d工时 / Convert.ToDouble(dr["生产日工时"]), 0);
        //            dr["生产周期"] = i置办周期;
        //        }
        //        dr["置办周期"] = i置办周期;

        //        if (sInvCode == "--")
        //        {
        //            dr["完成日期"] = dDate1;
        //            dr["建议完成日期"] = dDate1;
        //        }
        //        else
        //        {
        //            dr["完成日期"] = dDate1.AddDays(-1);
        //            dr["建议完成日期"] = dDate1.AddDays(-1);
        //        }
        //        dr["开始日期"] = Convert.ToDateTime(dr["完成日期"]).AddDays(-1 * i置办周期);
        //        dr["建议开始日期"] = Convert.ToDateTime(dr["完成日期"]).AddDays(-1 * i置办周期);
        //        if (dtm计划开始日期.DateTime > Convert.ToDateTime(dr["开始日期"]))
        //        {
        //            dtm计划开始日期.DateTime = Convert.ToDateTime(dr["开始日期"]);
        //        }

        //        InitBomN(tran, dr["子件编码"].ToString().Trim(), decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["本次下单数量"]), 6), Convert.ToDateTime(Convert.ToDateTime(dr["开始日期"]).ToString("yyyy-MM-dd")));
        //    }
        //}

        ///// <summary>
        ///// 顺排计划
        ///// </summary>
        ///// <param name="tran"></param>
        ///// <param name="sInvCode">子件编码</param>
        ///// <param name="dQty">本次下单数量</param>
        ///// <param name="dDate1">计划开始日期</param>
        //private void InitBomS(SqlTransaction tran, string sInvCode, decimal dQty, DateTime dDate1)
        //{
        //    DataRow[] drList = dtBom.Select(" 子件编码 = '" + sInvCode + "' ");

        //    foreach (DataRow dr in drList)
        //    {
        //        double i置办周期 = 1;
        //        if (dr["子件属性"].ToString().Trim() == "采购" && dr["采购周期"].ToString().Trim() != "")
        //        {
        //            i置办周期 = ReturnObjectToInt(dr["采购周期"]) + ReturnObjectToInt(dr["质检周期"]);
        //        }
        //        if (dr["子件属性"].ToString().Trim() == "委外" && dr["委外周期"].ToString().Trim() != "")
        //        {
        //            i置办周期 = ReturnObjectToInt(dr["委外周期"]) + ReturnObjectToInt(dr["质检周期"]);
        //        }
        //        if (dr["子件属性"].ToString().Trim() == "自制")
        //        {
        //            DataRow[] dr工时List = dt工时工序.Select(" 物料编码 = '" + sInvCode + "' ");
        //            if (dr工时List.Length < 1)
        //            {
        //                //未设置母件工时工序，需要中其他母件工时工序表获得资料
        //            }

        //            double d工时 = 0;
        //            for (int i = 0; i < dr工时List.Length; i++)
        //            {
        //                if (dr工时List[i]["单位工时"].ToString().Trim() != "")
        //                {
        //                    d工时 = d工时 + Convert.ToDouble(dr工时List[i]["单位工时"]) * Convert.ToDouble(dr["本次下单数量"]) / Convert.ToDouble(dr工时List[i]["作业人员数量"]);
        //                }
        //            }
        //            i置办周期 = Math.Ceiling(d工时 / Convert.ToDouble(dr["生产日工时"]), 0);
        //            dr["生产周期"] = i置办周期;
        //        }
        //        dr["置办周期"] = i置办周期;
        //        if (dr["开始日期"].ToString().Trim() != "")
        //        {
        //            if (Convert.ToDateTime(dr["开始日期"]) < dDate1)
        //            {
        //                dr["开始日期"] = dDate1;
        //            }
        //        }
        //        else
        //        {
        //            dr["开始日期"] = dDate1;
        //        }

        //        dr["完成日期"] = Convert.ToDateTime(dr["开始日期"]).AddDays(i置办周期);

        //        if (dtm计划结束日期.DateTime < Convert.ToDateTime(dr["完成日期"]))
        //        {
        //            dtm计划结束日期.DateTime = Convert.ToDateTime(dr["完成日期"]);
        //        }

        //        InitBomS(tran, dr["母件编码"].ToString().Trim(), decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["需求数量"]), 6), Convert.ToDateTime(Convert.ToDateTime(dr["完成日期"]).ToString("yyyy-MM-dd")).AddDays(1));
        //    }
        //}

       

        private DataTable Get工时工序(SqlTransaction tran, string sInvCode)
        { 
             sSQL = "select cast(null as varchar(50)) as BOM中物料作为子件时供应类型, cast('0' as varchar(50)) as 手工计划,a.*,b.cInvName,cast(null as decimal(16,1)) as 结束时间,cast(null as varchar(50)) as 制造令号码,cast(null as decimal(16,6)) as 制造令数量,cast(null as decimal(16,10)) as 总工时,cast(null as decimal(16,0)) as 开工日期,cast(null as decimal(16,0)) as 结束日期,cast(null as datetime) as 日计划起,cast(null as decimal(16,3)) as 订单数量,null as 订单需求量 " +
                        "from XWSystemDB_DL..ProProcess a left join Inventory b on a.产品编码 = b.cInvName " +
                        "where a.产品编码 = 'aaabbbccc' order by a.母件顺序,a.加工顺序";

             sSQL = sSQL.Replace("aaabbbccc", sInvCode);

             return ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
        }

        private DataTable GetBomSQL(SqlTransaction tran, string sInvCode)
        {
            string sSQL = @"
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[TH_TMPUF_BOM_ERP]') AND type in (N'U'))
	drop table TH_TMPUF_BOM_ERP

exec  Usp_BO_ExpandByParent ' and  1=1   And ((c.InvCode >= N''aaabbbccc'') And (c.InvCode <= N''aaabbbccc''))', '2012-08-30',1, 0,  0, 3, 0, 0, 0,1, ''   ,'TH_TMPUF_BOM_ERP'

select * 
    ,cast(null as decimal(16,2)) as 需求数量
    ,cast(null as decimal(16,2)) as 本次下单数量
    ,cast(null as decimal(16,2)) as 历史超单数量
    ,cast(null as decimal(16,2)) as 仓库现存量
    ,cast(null as decimal(16,2)) as 待入库量
    ,cast(null as decimal(16,2)) as 最小批量
    ,cast(null as decimal(16,0)) as 置办周期
    ,cast(null as decimal(16,0)) as 采购周期
    ,cast(null as decimal(16,0)) as 委外周期
    ,cast(null as decimal(16,0)) as 生产周期
    ,cast(null as decimal(16,0)) as 生产日工时
    ,cast(null as decimal(16,0)) as 质检周期
    ,cast(null as datetime) as 开始日期
    ,cast(null as datetime) as 完成日期
    ,cast(null as datetime) as 建议开始日期
    ,cast(null as datetime) as 建议完成日期
from TH_TMPUF_BOM_ERP
";

            sSQL = sSQL.Replace("aaabbbccc", sInvCode);

            DataTable dt =  ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

            DataRow dr = dt.NewRow();
            dr["母件编码"] = "--";
            dr["使用数量"] = 1;
            dr["子件编码"] = sInvCode;
            dr["子件属性"] = "自制";
            dt.Rows.InsertAt(dr, 0);

            return dt;
        }

        #region 按钮模板

        ///// <summary>
        ///// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
        //    DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "StateText";
        //    dt.Columns.Add(dc);
           
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
        //        if (drState.Length > 0)
        //        {
        //            dt.Rows[i]["StateText"] = drState[0]["State"];
        //        }

        //    }

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

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {

        }

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            FrmOrderReview_SEL fSel = new FrmOrderReview_SEL();
            fSel.ShowDialog();
            if (fSel.DialogResult != DialogResult.OK)
            {
                throw new Exception("取消查询");
            }

            iPage = fSel.iPageSEL + 1;
            sFrmSEL = fSel.sSEL;
            GetFrmSEL();
        }

        private void GetFrmSEL()
        {
            dtSel = clsSQLCommond.ExecQuery(sFrmSEL);
            //iPage = dtSel.Rows.Count;
            if (dtSel == null || dtSel.Rows.Count < 1)
            {
                SetTxtGridNull();
                return;
            }

            string sCode = dtSel.Rows[iPage - 1]["单据号"].ToString().Trim();
            GetGrid(sCode);
            base.lPageInfo.Text = iPage.ToString() + "/" + dtSel.Rows.Count.ToString();
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            iPage = 1;
            string sCode = dtSel.Rows[iPage-1]["单据号"].ToString().Trim();
            GetGrid(sCode);

            base.lPageInfo.Text = iPage.ToString() + "/" + dtSel.Rows.Count.ToString();

        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            if (iPage > 1)
            {
                iPage = iPage - 1;
            }
            string sCode = dtSel.Rows[iPage-1]["单据号"].ToString().Trim();
            GetGrid(sCode);

            base.lPageInfo.Text = iPage.ToString() + "/" + dtSel.Rows.Count.ToString();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            if (iPage < dtSel.Rows.Count)
            {
                iPage = iPage + 1;
            }
            string sCode = dtSel.Rows[iPage-1]["单据号"].ToString().Trim();
            GetGrid(sCode);

            base.lPageInfo.Text = iPage.ToString() + "/" + dtSel.Rows.Count.ToString();
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            iPage = dtSel.Rows.Count;
            string sCode = dtSel.Rows[iPage-1]["单据号"].ToString().Trim();
            GetGrid(sCode);

            base.lPageInfo.Text = iPage.ToString() + "/" + dtSel.Rows.Count.ToString();
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
            for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
            {
                if (gridView1.IsRowSelected(i))
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
            if (txt单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            if (txt审核.Text.Trim() != "")
            {
                throw new Exception("已经审核，不能修改");
            }

            if (txt关闭.Text.Trim() != "")
            {
                throw new Exception("已经关闭，不能修改");
            }

               SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString2);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                //获得工时工序
                dt工时工序 = Get工时工序(tran, lookUpEdit产品编码.Text.Trim());

                tran.Commit();
            }
            catch (Exception error)
            {
                tran.Rollback();
            }

            dtBom = (DataTable)gridControl1.DataSource;

            SetEnable(true);

            radio_CheckedChanged(null, null);

            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
           // if (txt单据号.Text.Trim() == "")
           // {
           //     throw new Exception("请选择需要删除的单据");
           // }

           // if (txt审核.Text.Trim() != "")
           // {
           //     throw new Exception("已经审核，不能删除");
           // }

           // if (MessageBox.Show("确定删除单据：" + txt单据号.Text.Trim() + "?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
           // {
           //     throw new Exception("取消删除");
           // }

           // aList = new System.Collections.ArrayList();
           //sSQL = "delete dbo.订单评审表体 where 表头单据号 = '" + txt单据号.Text.Trim() + "' " ;
           // aList.Add(sSQL);

           // sSQL = "delete dbo.订单评审表头 where 单据号 = '" + txt单据号.Text.Trim() + "'";
           // aList.Add(sSQL);
            
           // if (aList.Count > 0)
           // {
           //     int iCou = clsSQLCommond.ExecSqlTran(aList);
           //     MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
           //     SetEdit(false);

           //     GetFrmSEL();

           //     sState = "del";
           // }
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
            }
            catch { }

            aList = new System.Collections.ArrayList();

            if (sState == "add")
            {
                txt制单.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dtm制单.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                //sSQL = "select case when isnull(max(单据号)+1,1) = 1 then '" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMMdd") + "01' else  isnull(max(单据号)+1,1) end as 单据号 from 生产计划 where 单据号 like '" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMMdd") + "%'";
                //DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                //txt单据号.Text = dt.Rows[0]["单据号"].ToString().Trim();
                //dtm单据日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            }
            sSQL = "select * from dbo.订单评审表头 where 1 = -1";
            DataTable dtHead = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from dbo.订单评审表体 where 1 = -1";
            DataTable dtDetail = clsSQLCommond.ExecQuery(sSQL);

            aList = new System.Collections.ArrayList();

            DataRow drHead = dtHead.NewRow();
            drHead["单据号"] = txt单据号.Text.Trim();
            drHead["单据日期"] = dtm单据日期.DateTime.ToString("yyyy-MM-dd");
            drHead["销售订单号"] = txt销售订单号.Text.Trim();
            drHead["行号"] = txt行号.Text.Trim();
            drHead["外销订单号"] = txt外销订单号.Text.Trim();
            drHead["客户订单号"] = txt客户订单号.Text.Trim();
            drHead["客户简称"] = txt客户简称.Text.Trim();
            drHead["船期"] = dtm船期.DateTime.ToString("yyyy-MM-dd");
            drHead["预完工日期"] = dtm预完工日期.DateTime.ToString("yyyy-MM-dd");


            drHead["国外要求交期"] =ReturnDate( dtm国外要求交期.DateTime);
            drHead["产品编码"] = lookUpEdit产品编码.Text.Trim();
            drHead["订单数量"] = txt订单数量.Text.Trim();
            drHead["计划开始日期"] = dtm计划开始日期.DateTime.ToString("yyyy-MM-dd");
            drHead["计划结束日期"] = dtm计划结束日期.DateTime.ToString("yyyy-MM-dd");
            drHead["下单数量"] = txt下单数量.Text.Trim();
            drHead["备注"] = txt备注.Text.Trim();
            drHead["帐套号"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            drHead["年度"] = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4).Trim();
            drHead["制单"] = txt制单.Text.Trim();
            drHead["制单日期"] = dtm制单.DateTime.ToString("yyyy-MM-dd");
            drHead["销售订单子表ID"] = txt销售订单子表ID.Text.Trim();
            drHead["销售订单ID"] = txt销售订单ID.Text.Trim();
            drHead["已下单"] = 0;
            dtHead.Rows.Add(drHead);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow drDetail = dtDetail.NewRow();
                drDetail["表头单据号"] = txt单据号.Text.Trim();
                drDetail["排序"] = i + 1;
                drDetail["根母件"] =ReturnValue( gridView1.GetRowCellDisplayText(i, gridCol根母件));
                drDetail["级别"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol级别));
                drDetail["母件编码"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol母件编码));
                drDetail["子件行号"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol子件行号));
                drDetail["工序行号"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol工序行号));
                drDetail["子件编码"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol子件编码));

                drDetail["换算率"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol换算率));
                drDetail["供应类型"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol供应类型));
                drDetail["使用数量"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol使用数量));
                drDetail["子件属性"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol子件属性));
                drDetail["仓库代号"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol仓库代号));
                drDetail["领料部门代号"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol领料部门代号));
                drDetail["备注"] = ReturnValue(gridView1.GetRowCellValue(i, gridCol备注));

                drDetail["需求数量"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol需求数量));
                drDetail["本次下单数量"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol本次下单数量));
                drDetail["待入库量"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol待入库量));
                drDetail["最小批量"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol最小批量));
                drDetail["开始日期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol开始日期));
                drDetail["完成日期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol完成日期));

                if (sState == "add")
                {
                    //保存第一次日期为初始日期
                    drDetail["初始开始日期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol开始日期));
                    drDetail["初始完成日期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol完成日期));
                    drDetail["建议开始日期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol建议开始日期));
                    drDetail["建议完成日期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol建议完成日期));
                }

                drDetail["采购周期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol采购周期));
                drDetail["委外周期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol委外周期));
                drDetail["生产周期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol生产周期));
                drDetail["质检周期"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol质检周期));
                drDetail["生产日工时"] = ReturnValue(gridView1.GetRowCellDisplayText(i, gridCol生产日工时));
                drDetail["帐套号"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                drDetail["年度"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)).Trim();

                dtDetail.Rows.Add(drDetail);
            }


            for (int i = 0; i < dtHead.Rows.Count; i++)
            {
                if (sState == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL("订单评审表头", dtHead, i);
                    aList.Add(sSQL);
                }
                if (sState == "edit")
                {
                    sSQL = clsGetSQL.GetUpdateSQL("订单评审表头", dtHead, i);
                    aList.Add(sSQL);
                }
            }

            if (sState == "edit")
            {
                sSQL = "delete 订单评审表体 where 表头单据号 = '" + txt单据号.Text.Trim() + "'";
                aList.Add(sSQL);
            }
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                sSQL = clsGetSQL.GetInsertSQL("订单评审表体", dtDetail, i);
                aList.Add(sSQL);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                SetEdit(false);

                if(sState == "add")
                {
                    string sCode = txt单据号.Text.Trim();
                    GetFrmSEL();
                    GetGrid(sCode);
                }

                sState = "save";
            }
        }

        private void SetEdit(bool p)
        {
            txt单据号.Enabled = false;
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
            if (txt单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要审核的单据");
            }

            if (txt审核.Text.Trim() != "")
            {
                throw new Exception("该单据已审核");
            }

            if (txt关闭.Text.Trim() != "")
            {
                throw new Exception("该单据已关闭，不能审核");
            }

            if (sState == "add" || sState == "edit")
            {
                throw new Exception("该单据尚未保存，不能审核");
            }

            aList = new System.Collections.ArrayList();
            sSQL = "update dbo.订单评审表头 set 审核 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',审核日期 = getdate()  where 单据号 = '" + txt单据号.Text.Trim() + "' ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);

                if (iCou > 0)
                {
                    txt审核.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    dtm审核.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;

                    MessageBox.Show("审核成功");

                    sState = "audit";
                }
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            if (txt单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要弃审的单据");
            }

            if (txt审核.Text.Trim() == "")
            {
                throw new Exception("该单据尚未审核");
            }

            if (txt关闭.Text.Trim() != "")
            {
                throw new Exception("该单据已关闭，不能弃审");
            }

            if (sState == "add" || sState == "edit")
            {
                throw new Exception("该单据尚未保存，不能弃审");
            }

            aList = new System.Collections.ArrayList();
            sSQL = "update dbo.订单评审表头 set 审核 = null,审核日期 = null where 单据号 = '" + txt单据号.Text.Trim() + "' ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);

                if (iCou > 0)
                {
                    txt审核.Text = "";
                    dtm审核.Text = "";

                    MessageBox.Show("弃审成功");

                    sState = "unaudit";
                }
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            if (toolStripMenuBtn.Items["open"].Text.Trim() == "打开")
            {
                if (txt单据号.Text.Trim() == "")
                {
                    throw new Exception("请选择需要打开的单据");
                }

                if (txt关闭.Text.Trim() == "")
                {
                    throw new Exception("该单据未关闭");
                }

                if (sState == "add" || sState == "edit")
                {
                    throw new Exception("该单据尚未保存");
                }

                aList = new System.Collections.ArrayList();
                sSQL = "update dbo.订单评审表头 set 关闭 = null,关闭日期 = null where 单据号 = '" + txt单据号.Text.Trim() + "' ";
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);

                    if (iCou > 0)
                    {
                        txt关闭.Text = "";
                        dtm关闭.Text = "";

                        MessageBox.Show("打开成功");

                        sState = "open";

                        toolStripMenuBtn.Items["open"].Text = "关闭";
                    }
                }
            }
            else
            {
                if (txt单据号.Text.Trim() == "")
                {
                    throw new Exception("请选择需要关闭的单据");
                }

                if (txt关闭.Text.Trim() != "")
                {
                    throw new Exception("该单据已关闭");
                }

                if (sState == "add" || sState == "edit")
                {
                    throw new Exception("该单据尚未保存，不能关闭");
                }

                aList = new System.Collections.ArrayList();
                sSQL = "update dbo.订单评审表头 set 关闭 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',关闭日期 = getdate()  where 单据号 = '" + txt单据号.Text.Trim() + "' ";
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);

                    if (iCou > 0)
                    {
                        txt关闭.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        dtm关闭.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;

                        MessageBox.Show("关闭成功");

                        sState = "close";

                        toolStripMenuBtn.Items["open"].Text = "打开";
                    }
                } 
            }
        }

        /// <summary>
        /// 下达计划：生成采购请购单，委外计划，生产订单
        /// </summary>
        private void btnClose()
        {
            if (txt单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要下达计划的单据");
            }

            if (txt关闭.Text.Trim() != "")
            {
                throw new Exception("该单据已关闭");
            }

            if (txt审核.Text.Trim() == "")
            {
                throw new Exception("该单据未审核");
            }

            if (chk已下达计划.Checked)
            {
                throw new Exception("不能重复下达计划");
            }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol评审人).ToString().Trim() == "")
                {
                    throw new Exception("请评审结束再下单");
                }
            }

            bool b采购 = false;
            bool b委外 = false;
            bool b生产 = false;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "采购")
                    b采购 = true;
                if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "委外")
                    b委外 = true;
                if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "自制")
                    b生产 = true;
            }

            aList = new System.Collections.ArrayList();
            string s生成提示 = "";

            #region 下达采购计划（采购请购单）
            if (b采购)
            {
                //获得请购单主表框架
                sSQL = "select * from @u8.PU_AppVouch where 1=-1";
                DataTable dtPU_AppVouch = clsSQLCommond.ExecQuery(sSQL);
                //获得请购单子表框架
                sSQL = "select * from @u8.PU_AppVouchs  where 1=-1";
                DataTable dtPU_AppVouchs = clsSQLCommond.ExecQuery(sSQL);

                //获得最大单据号
                long iVouNumber;
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='27' and cSeed = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                iVouNumber = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);

                bool bVouNumber = false;            //当月第一张单据
                if (iVouNumber == 0)
                {
                    bVouNumber = true;
                }

                //获得单据ID号
                long iID;
                long iIDDetail;
                sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'PuApp'";
                dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt == null || dt.Rows.Count < 1)
                {
                    iID = 0;
                    iIDDetail = 0;
                }
                else
                {
                    iID = Convert.ToInt64(dt.Rows[0]["iFatherID"]);
                    iIDDetail = Convert.ToInt64(dt.Rows[0]["iChildID"]);
                }

                DataRow drPU_AppVouch = dtPU_AppVouch.NewRow();
                drPU_AppVouch["iVTid"] = "8171";
                iID += 1;
                drPU_AppVouch["ID"] = iID;
                iVouNumber += 1;
                drPU_AppVouch["cCode"] = GetPU_AppVouchCode(iVouNumber.ToString());
                drPU_AppVouch["dDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                drPU_AppVouch["cDepCode"] = "802";
                //drPU_AppVouch["cPersonCode"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
                drPU_AppVouch["cPTCode"] = "01";
                drPU_AppVouch["cBusType"] = "普通采购";
                drPU_AppVouch["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                drPU_AppVouch["cVerifier"] = DBNull.Value;
                drPU_AppVouch["cCloser"] = DBNull.Value;
                drPU_AppVouch["cDefine1"] = DBNull.Value;
                drPU_AppVouch["cDefine2"] = txt客户订单号.Text.Trim();
                drPU_AppVouch["cDefine11"] = txt外销订单号.Text.Trim();
                drPU_AppVouch["cMemo"] = "";
                drPU_AppVouch["cLocker"] = "";
                drPU_AppVouch["iverifystateex"] = 0;
                drPU_AppVouch["ireturncount"] = DBNull.Value;
                drPU_AppVouch["IsWfControlled"] = 0;
                drPU_AppVouch["cMakeTime"] = Get当前服务器时间();
                drPU_AppVouch["cModifyTime"] = DBNull.Value;
                drPU_AppVouch["cAuditTime"] = DBNull.Value;
                drPU_AppVouch["cAuditDate"] = DBNull.Value;
                drPU_AppVouch["cModifyDate"] = DBNull.Value;
                drPU_AppVouch["cReviser"] = DBNull.Value;
                dtPU_AppVouch.Rows.Add(drPU_AppVouch);

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() != "采购")
                        continue;

                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次下单数量)) == 0)
                        continue;

                    DataRow drPU_AppVouchs = dtPU_AppVouchs.NewRow();
                    drPU_AppVouchs["ID"] = iID;

                    iIDDetail += 1;
                    drPU_AppVouchs["AutoID"] = iIDDetail;
                    drPU_AppVouchs["cVenCode"] = DBNull.Value;
                    drPU_AppVouchs["cInvCode"] = gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                    drPU_AppVouchs["fQuantity"] = gridView1.GetRowCellValue(i, gridCol本次下单数量).ToString().Trim();
                    drPU_AppVouchs["fUnitPrice"] = DBNull.Value;
                    drPU_AppVouchs["iPerTaxRate"] = 17;
                    drPU_AppVouchs["fTaxPrice"] = DBNull.Value;
                    drPU_AppVouchs["fMoney"] = DBNull.Value;
                    drPU_AppVouchs["dRequirDate"] = gridView1.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    drPU_AppVouchs["dArriveDate"] = gridView1.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    drPU_AppVouchs["iReceivedQTY"] = 0;
                    drPU_AppVouchs["cItem_class"] = "00";
                    drPU_AppVouchs["cItemCode"] = txt外销订单号.Text.Trim();
                    drPU_AppVouchs["CItemName"] = txt外销订单号.Text.Trim();
                    drPU_AppVouchs["bTaxCost"] = true;
                    drPU_AppVouchs["iPPartId"] = DBNull.Value;
                    drPU_AppVouchs["iPQuantity"] = DBNull.Value;
                    drPU_AppVouchs["iPTOSeq"] = DBNull.Value;
                    drPU_AppVouchs["cSource"] = DBNull.Value;
                    drPU_AppVouchs["SoDId"] = txt销售订单子表ID.Text.Trim();
                    drPU_AppVouchs["SoType"] = "1";
                    drPU_AppVouchs["iMrpsid"] = DBNull.Value;
                    drPU_AppVouchs["iRopsid"] = DBNull.Value;
                    drPU_AppVouchs["cbcloser"] = DBNull.Value;
                    //if (gridView1.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    //{
                    //    decimal d1 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol换算率));
                    //    decimal d2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次下单数量));
                    //    d1 = decimal.Round(d1, 6);
                    //    d2 = decimal.Round(d2, 6);
                    //    drPU_AppVouchs["fNum"] = decimal.Round(d2 / d1);
                    //    drPU_AppVouchs["cUnitID"] = gridView1.GetRowCellValue(i, gridCol辅助单位).ToString().Trim();
                    //}
                    drPU_AppVouchs["iReceivedNum"] = DBNull.Value;
                    drPU_AppVouchs["cPersonCodeExec"] = DBNull.Value;
                    drPU_AppVouchs["cDepCodeExec"] = DBNull.Value;
                    drPU_AppVouchs["iInvMPCost"] = DBNull.Value;
                    drPU_AppVouchs["cexch_name"] = "人民币";
                    drPU_AppVouchs["iExchRate"] = 1;
                    drPU_AppVouchs["iOriCost"] = DBNull.Value;
                    drPU_AppVouchs["iOriTaxCost"] = DBNull.Value;
                    drPU_AppVouchs["iOriMoney"] = DBNull.Value;
                    drPU_AppVouchs["iOriTaxPrice"] = DBNull.Value;
                    drPU_AppVouchs["iOriSum"] = DBNull.Value;
                    drPU_AppVouchs["iMoney"] = DBNull.Value;
                    drPU_AppVouchs["iTaxPrice"] = DBNull.Value;
                    drPU_AppVouchs["cdemandcode"] = DBNull.Value;
                    drPU_AppVouchs["cdetailsdemandmemo"] = DBNull.Value;

                    dtPU_AppVouchs.Rows.Add(drPU_AppVouchs);
                }

                if (dtPU_AppVouchs.Rows.Count > 0)
                {
                    //更新最大单据号
                    if (bVouNumber)
                    {
                        sSQL = "insert into @u8.VoucherHistory(cardnumber,cContent,cContentRule,cSeed,cNumber,bEmpty) " +
                                "values('27','单据日期','年','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "','1',0)";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouNumber + "' Where  CardNumber='27' and cSeed = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";
                        aList.Add(sSQL);
                    }

                    //更新最大ID
                    sSQL = "update UFSystem..UA_Identity set iFatherID=" + iID + ",iChildID=" + iIDDetail + " where  cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'PuApp'";
                    aList.Add(sSQL);

                    for (int i = 0; i < dtPU_AppVouch.Rows.Count; i++)
                    {
                        //生成委外订单表体
                        aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "PU_AppVouch", dtPU_AppVouch, i));
                    }
                    for (int i = 0; i < dtPU_AppVouchs.Rows.Count; i++)
                    {
                        //生成委外订单表体
                        aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "PU_AppVouchs", dtPU_AppVouchs, i));
                    }

                    s生成提示 = s生成提示 + "采购请购单：" + GetPU_AppVouchCode(iVouNumber.ToString()) + "\n";
                }
            }
            #endregion

            #region 下达委外计划

            if (b委外)
            {
                //获得请购单主表框架
                sSQL = "select * from UFDLImport.dbo.OMPlan where 1=-1";
                DataTable dtOMPlan = clsSQLCommond.ExecQuery(sSQL);

                long iVouOMNumber;
                sSQL = "select max(iID) as Maxnumber from UFDLImport.dbo.OMPlan";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                iVouOMNumber = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() != "委外")
                        continue;

                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次下单数量)) == 0)
                        continue;

                    DataRow drOMPlan = dtOMPlan.NewRow();
                    iVouOMNumber += 1;
                    drOMPlan["iID"] = iVouOMNumber;
                    drOMPlan["DemandId"] = DBNull.Value;

                    sSQL = "select * from @u8.bas_part where InvCode = '" + gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() + "'";
                    DataTable dtBas_part = clsSQLCommond.ExecQuery(sSQL);
                    if (dtBas_part != null && dtBas_part.Rows.Count > 0)
                    {
                        drOMPlan["PartId"] = dtBas_part.Rows[0]["PartId"];
                    }
                    drOMPlan["SoType"] = 1;
                    drOMPlan["SoDId"] = txt销售订单子表ID.Text.Trim();
                    drOMPlan["SoId"] = txt销售订单ID.Text.Trim();
                    drOMPlan["SoCode"] = txt销售订单号.Text.Trim();
                    drOMPlan["SoSeq"] = txt行号.Text.Trim();
                    //drOMPlan["PlanCode"] = "";
                    drOMPlan["DueDate"] = gridView1.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    drOMPlan["StartDate"] = gridView1.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    drOMPlan["DueDate2"] = gridView1.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    drOMPlan["StartDate2"] = gridView1.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    drOMPlan["LUSD"] = gridView1.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    drOMPlan["LUCD"] = gridView1.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    drOMPlan["PlanQty"] = gridView1.GetRowCellValue(i, gridCol本次下单数量).ToString().Trim();
                    drOMPlan["CrdQty"] = 0;
                    drOMPlan["SupplyType"] = 2;
                    drOMPlan["SchId"] = DBNull.Value;
                    drOMPlan["ManualFlag"] = false;
                    drOMPlan["DelFlag"] = false;
                    drOMPlan["ModifyFlag"] = false;
                    drOMPlan["ProjectId"] = DBNull.Value;
                    drOMPlan["FirmDate"] = DBNull.Value;
                    drOMPlan["FirmUser"] = DBNull.Value;
                    drOMPlan["Status"] = 1;
                    drOMPlan["SrpSoDId"] = 0;
                    drOMPlan["SrpSoType"] = 0;

                    sSQL = "select a.cInvAddCode,a.cComUnitCode,b.cComUnitName from @u8.Inventory a left join @u8.ComputationUnit b on a.cComunitCode = b.cComunitCode  where a.cInvCode = '" + gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() + "'";
                    DataTable dtInvCode = clsSQLCommond.ExecQuery(sSQL);
                    drOMPlan["InvCode"] = gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                    drOMPlan["InvName"] = gridView1.GetRowCellValue(i, gridCol子件名称).ToString().Trim();
                    drOMPlan["InvStd"] = gridView1.GetRowCellValue(i, gridCol子件规格).ToString().Trim();
                  
                    if (dtInvCode != null && dtInvCode.Rows.Count > 0)
                    {
                        drOMPlan["InvAddCode"] = dtInvCode.Rows[0]["cInvAddCode"];
                        drOMPlan["ComUnitCode"] = dtInvCode.Rows[0]["cComUnitCode"];
                        drOMPlan["ComUnitName"] = dtInvCode.Rows[0]["cComUnitName"];
                    }
                    drOMPlan["IsRem"] = false;
                    drOMPlan["Police"] = "PE";
                    //drOMPlan["MinQty"] = "";
                    //drOMPlan["MulQty"] = "";
                    //drOMPlan["FixQty"] = "";
                    //drOMPlan["SafeQty"] = "";
                    //drOMPlan["PlannerName"] = "";
                    //drOMPlan["Planner"] = "";
                    //drOMPlan["InvDefine1"] = "";
                    //drOMPlan["InvDefine2"] = "";
                    //drOMPlan["InvDefine3"] = "";
                    //drOMPlan["InvDefine4"] = "";
                    //drOMPlan["InvDefine5"] = "";
                    //drOMPlan["InvDefine6"] = "";
                    //drOMPlan["InvDefine7"] = "";
                    //drOMPlan["InvDefine8"] = "";
                    //drOMPlan["InvDefine9"] = "";
                    //drOMPlan["InvDefine10"] = "";
                    //drOMPlan["InvDefine11"] = "";
                    //drOMPlan["InvDefine12"] = "";
                    //drOMPlan["InvDefine13"] = "";
                    //drOMPlan["InvDefine14"] = "";
                    //drOMPlan["InvDefine15"] = "";
                    //drOMPlan["InvDefine16"] = "";
                    //drOMPlan["BasEngineerFigNo"] = "";
                    //drOMPlan["OrderQty"] = "";
                    drOMPlan["AccID"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                    drOMPlan["AccYear"] =  (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)).Trim();
                    drOMPlan["bClosed"] = false;
                    drOMPlan["bUsed"] = false;
                    drOMPlan["bAllBatchCreate"] = false;
                    //drOMPlan["cVenCode"] = "";
                    //drOMPlan["iTaxPrice"] = "";
                    //drOMPlan["iTaxRate"] = "";
                    //drOMPlan["iUnitPrice"] = "";
                    drOMPlan["bSave"] = false;
                    //drOMPlan["SvaeUID"] = "";
                    //drOMPlan["SaveDate"] = "";
                    drOMPlan["bAudit"] = false;
                    //drOMPlan["AuditUID"] = "";
                    //drOMPlan["AuditDate"] = "";
                    drOMPlan["bBeSure"] = false;
                    //drOMPlan["BeSureUID"] = "";
                    //drOMPlan["BeSureDate"] = "";
                    //drOMPlan["dVenPlanDate"] = "";
                    //drOMPlan["dVenCloseDate"] = "";
                    //drOMPlan["ClosedUID"] = "";
                    //drOMPlan["ClosedDate"] = "";
                    drOMPlan["bImport"] = false;
                    drOMPlan["ImportUID"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    drOMPlan["ImportDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                    //drOMPlan["StartFlag"] = "";
                    //drOMPlan["Remark"] = "";

                    dtOMPlan.Rows.Add(drOMPlan);
                }

                for (int i = 0; i < dtOMPlan.Rows.Count; i++)
                {
                    //生成委外订单表体
                    aList.Add(clsGetSQL.GetInsertSQL("UFDLImport", "OMPlan", dtOMPlan, i));
                }


                s生成提示 = s生成提示 + "委外计划：" +  dtOMPlan.Rows.Count  + "行\n";
            }


            #endregion

            #region 下达生产计划（生产订单）
            //获得生产订单主表框架
            sSQL = "select * from @u8.mom_order where 1=-1";
            DataTable dtmom_order = clsSQLCommond.ExecQuery(sSQL);
            //获得生产订单子表框架
            sSQL = "select * from @u8.mom_orderdetail where 1=-1";
            DataTable dtmom_orderdetail= clsSQLCommond.ExecQuery(sSQL);
            //获得生产订单子件用料表框架
            sSQL = "select * from @u8.mom_moallocate where 1=-1";
            DataTable dtmom_moallocate = clsSQLCommond.ExecQuery(sSQL);
            //获得生产订单资料框架
            sSQL = "select * from @u8.mom_morder  where 1=-1";
            DataTable dtmom_morder = clsSQLCommond.ExecQuery(sSQL);

            //获得最大单据号
            long iVouMOM;
            sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where CardNumber='MO21' and (cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtMOM = clsSQLCommond.ExecQuery(sSQL);
            iVouMOM = Convert.ToInt64(dtMOM.Rows[0]["Maxnumber"]);

            bool bVouMOM = false;            //当月第一张单据
            if (iVouMOM == 0)
            {
                bVouMOM = true;
            }

            ////获得单据ID号
            long iIDmom_order;
            long iIDmom_orderdetail;
            long iIDmom_moallocate;
            sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'mom_order'";
            DataTable dtID = clsSQLCommond.ExecQuery(sSQL);
            if (dtID == null || dtID.Rows.Count < 1)
            {
                iIDmom_order = 0;
            }
            else
            {
                iIDmom_order = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
            }
            sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'mom_orderdetail'";
            dtID = clsSQLCommond.ExecQuery(sSQL);
            if (dtID == null || dtID.Rows.Count < 1)
            {
                iIDmom_orderdetail = 0;
            }
            else
            {
                iIDmom_orderdetail = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
            }
            sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'mom_moallocate'";
            dtID = clsSQLCommond.ExecQuery(sSQL);
            if (dtID == null || dtID.Rows.Count < 1)
            {
                iIDmom_moallocate = 0;
            }
            else
            {
                iIDmom_moallocate = Convert.ToInt64(dtID.Rows[0]["iChildID"]);
            }

            DataRow drmom_order = dtmom_order.NewRow();
            iIDmom_order += 1;
            drmom_order["MoId"] = iIDmom_order;
            iVouMOM += 1;
            drmom_order["MoCode"] = GetMOMCode(iVouMOM.ToString());

            drmom_order["CreateDate"] =FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            drmom_order["CreateUser"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
            drmom_order["ModifyDate"] = DBNull.Value;
            drmom_order["ModifyUser"] = DBNull.Value;
            drmom_order["UpdCount"] = 1;
            //drmom_order["Define1"] = "";
            //drmom_order["Define2"] = "";
            //drmom_order["Define3"] = "";
            //drmom_order["Define4"] = "";
            //drmom_order["Define5"] = "";
            //drmom_order["Define6"] = "";
            //drmom_order["Define7"] = "";
            //drmom_order["Define8"] = "";
            //drmom_order["Define9"] = "";
            //drmom_order["Define10"] = "";
            drmom_order["Define11"] = "";
            //drmom_order["Define12"] = "";
            //drmom_order["Define13"] = "";
            //drmom_order["Define14"] = "";
            //drmom_order["Define15"] = "";
            //drmom_order["Define16"] = "";
            drmom_order["VTid"] = 30422;
            drmom_order["CreateTime"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            drmom_order["ModifyTime"] = DBNull.Value;
            dtmom_order.Rows.Add(drmom_order);
            int iSortSeq = 0;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() != "自制")
                    continue;

                if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次下单数量)) == 0)
                    continue;

                sSQL = "select a.cInvCode,a.iInvAdvance,a.cDefWareHouse,b.PartID,a.cInvDepCode from @u8.Inventory a inner join @u8.bas_Part b on a.cInvCode = b.InvCode where a.cInvCode = '" + gridView1.GetRowCellValue(i, gridCol子件编码) + "'";
                DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);

                //生产子件
                sSQL = "select a.bomid,b.ComponentId,b.BaseQtyN,b.BaseQtyD,c.ParentScrap,b.CompScrap,d.InvCode,e.cDefWareHouse,e.cInvCode,b.OpComponentId,e.cAssComUnitCode,b.ChangeRate,b.AuxBaseQtyN " +
                        "from @u8.bom_bom a inner join @u8.bom_opcomponent b on a.bomID = b.bomid inner join @u8.bom_parent c on c.bomid = a.bomid inner join @u8.bas_part d on d.PartId = b.ComponentId " +
                            " inner join @u8.Inventory e on e.cInvCode = d.InvCode " +
                        "where ParentId = '" + dtInv.Rows[0]["PartID"] + "' and a.[Status] = 3 and b.EffBegDate < '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' and b.EffEndDate > '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "'";
                DataTable dtBomInfo = clsSQLCommond.ExecQuery(sSQL);

                DataRow drmom_orderdetail = dtmom_orderdetail.NewRow();

                iIDmom_orderdetail += 1;
                drmom_orderdetail["MoDId"] = iIDmom_orderdetail;
                drmom_orderdetail["MoId"] = iIDmom_order;
                iSortSeq += 1;
                drmom_orderdetail["SortSeq"] = iSortSeq;
                drmom_orderdetail["MoClass"] = 1;
                drmom_orderdetail["MoTypeId"] = DBNull.Value;
                drmom_orderdetail["Qty"] = gridView1.GetRowCellValue(i, gridCol本次下单数量);
                drmom_orderdetail["MrpQty"] = gridView1.GetRowCellValue(i, gridCol需求数量);
                drmom_orderdetail["AuxUnitCode"] = DBNull.Value;
                drmom_orderdetail["AuxQty"] = DBNull.Value;
                drmom_orderdetail["ChangeRate"] = DBNull.Value;
                drmom_orderdetail["MoLotCode"] = DBNull.Value;
                drmom_orderdetail["WhCode"] = gridView1.GetRowCellValue(i, gridCol仓库代号);
                drmom_orderdetail["MDeptCode"] = dtInv.Rows[0]["cInvDepCode"];
                drmom_orderdetail["SoType"] = 1;
                drmom_orderdetail["SoDId"] = txt销售订单子表ID.Text.Trim();
                drmom_orderdetail["SoCode"] = txt销售订单号.Text.Trim();
                drmom_orderdetail["SoSeq"] = txt行号.Text.Trim();
                drmom_orderdetail["DeclaredQty"] = 0;
                drmom_orderdetail["QualifiedInQty"] = 0;
                drmom_orderdetail["Status"] = 2;
                drmom_orderdetail["OrgStatus"] = 2;
                drmom_orderdetail["BomId"] = dtBomInfo.Rows[0]["bomid"];
                drmom_orderdetail["RoutingId"] = 0;
                drmom_orderdetail["CustBomId"] = 0;
                drmom_orderdetail["DemandId"] = 0;
                drmom_orderdetail["PlanCode"] = DBNull.Value;

                if (dtInv != null && dtInv.Rows.Count > 0)
                {
                    drmom_orderdetail["PartId"] = dtInv.Rows[0]["PartID"];
                    drmom_orderdetail["LeadTime"] = dtInv.Rows[0]["iInvAdvance"];
                }
                drmom_orderdetail["InvCode"] = gridView1.GetRowCellValue(i, gridCol子件编码);
                drmom_orderdetail["SfcFlag"] = 0;
                drmom_orderdetail["CrpFlag"] = 0;
                drmom_orderdetail["QcFlag"] = 0;
                drmom_orderdetail["RelsDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                drmom_orderdetail["RelsUser"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
                drmom_orderdetail["CloseDate"] = DBNull.Value;
                drmom_orderdetail["OrgClsDate"] = DBNull.Value;
                //drmom_orderdetail["Define22"] = "";
                //drmom_orderdetail["Define28"] = "";
                //drmom_orderdetail["Define36"] = "";
                drmom_orderdetail["OpScheduleType"] = 1;
                drmom_orderdetail["OrdFlag"] = 0;
                drmom_orderdetail["WIPType"] = 5;
                drmom_orderdetail["SupplyWhCode"] = DBNull.Value;
                drmom_orderdetail["ReasonCode"] = DBNull.Value;
                drmom_orderdetail["IsWFControlled"] = 0;
                drmom_orderdetail["iVerifyState"] = 0;
                drmom_orderdetail["iReturnCount"] = 0;
                drmom_orderdetail["Remark"] = DBNull.Value;
                drmom_orderdetail["SourceMoCode"] = DBNull.Value;
                drmom_orderdetail["SourceMoSeq"] = DBNull.Value;
                drmom_orderdetail["SourceMoId"] = 0;
                drmom_orderdetail["SourceMoDId"] = 0;
                drmom_orderdetail["SourceQCCode"] = DBNull.Value;
                drmom_orderdetail["SourceQCId"] = 0;
                drmom_orderdetail["SourceQCDId"] = 0;
                drmom_orderdetail["CostItemCode"] = DBNull.Value;
                drmom_orderdetail["CostItemName"] = DBNull.Value;
                drmom_orderdetail["RelsTime"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                drmom_orderdetail["CloseUser"] = DBNull.Value;
                drmom_orderdetail["CloseTime"] = DBNull.Value;
                drmom_orderdetail["OrgClsTime"] = DBNull.Value;
                drmom_orderdetail["AuditStatus"] = 1;
                drmom_orderdetail["PAllocateId"] = 0;
                drmom_orderdetail["DemandCode"] = DBNull.Value;
                drmom_orderdetail["CollectiveFlag"] = 0;
                drmom_orderdetail["OrderType"] = 1;
                drmom_orderdetail["OrderDId"] = txt销售订单子表ID.Text.Trim();
                drmom_orderdetail["OrderCode"] = txt销售订单号.Text.Trim();
                drmom_orderdetail["OrderSeq"] = txt行号.Text.Trim();
                drmom_orderdetail["ManualCode"] = DBNull.Value;
                drmom_orderdetail["ReformFlag"] = 0;
                drmom_orderdetail["SourceQCVouchType"] = 0;
                drmom_orderdetail["OrgQty"] = 0;
                drmom_orderdetail["FmFlag"] = 0;
                dtmom_orderdetail.Rows.Add(drmom_orderdetail);

                //生产订单资料
                DataRow drmom_morder = dtmom_morder.NewRow();
                drmom_morder["MoDId"] = iIDmom_orderdetail;
                drmom_morder["StartDate"] = gridView1.GetRowCellValue(i, gridCol开始日期);
                drmom_morder["DueDate"] = gridView1.GetRowCellValue(i, gridCol完成日期);
                drmom_morder["MoId"] = iIDmom_order;
                dtmom_morder.Rows.Add(drmom_morder);

                //生产订单子件用料表
                for (int j = 0; j < dtBomInfo.Rows.Count; j++)
                {
                    DataRow drmom_moallocate = dtmom_moallocate.NewRow();
                    iIDmom_moallocate += 1;
                    drmom_moallocate["AllocateId"] = iIDmom_moallocate;
                    drmom_moallocate["MoDId"] = iIDmom_orderdetail;
                    drmom_moallocate["SortSeq"] = (j + 1) * 10;
                    drmom_moallocate["OpSeq"] = "0000";
                    drmom_moallocate["ComponentId"] = dtBomInfo.Rows[j]["ComponentId"];
                    drmom_moallocate["FVFlag"] = 1;
                    drmom_moallocate["BaseQtyN"] = dtBomInfo.Rows[j]["BaseQtyN"];
                    drmom_moallocate["BaseQtyD"] = dtBomInfo.Rows[j]["BaseQtyD"];
                    drmom_moallocate["ParentScrap"] = dtBomInfo.Rows[j]["ParentScrap"];
                    drmom_moallocate["CompScrap"] = dtBomInfo.Rows[j]["CompScrap"];

                    decimal d使用数量 = 0;
                    for (int k = 0; k < gridView1.RowCount; k++)
                    {
                        if (gridView1.GetRowCellValue(k, gridCol母件编码).ToString().Trim() == gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim() && gridView1.GetRowCellValue(k, gridCol子件编码).ToString().Trim() == dtBomInfo.Rows[j]["InvCode"].ToString().Trim())
                        {
                            if (gridView1.GetRowCellValue(k, gridCol使用数量).ToString().Trim() != "")
                            {
                                d使用数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(k, gridCol使用数量));
                                break;
                            }
                        }
                    }
                    drmom_moallocate["Qty"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次下单数量)) * d使用数量;
                    drmom_moallocate["IssQty"] = 0;
                    drmom_moallocate["DeclaredQty"] = 0;
                    drmom_moallocate["StartDemDate"] = gridView1.GetRowCellValue(i, gridCol开始日期);
                    drmom_moallocate["EndDemDate"] = gridView1.GetRowCellValue(i, gridCol完成日期);
                    drmom_moallocate["WhCode"] = dtBomInfo.Rows[j]["cDefWareHouse"];
                    drmom_moallocate["LotNo"] = DBNull.Value;
                    drmom_moallocate["WIPType"] = 1;
                    drmom_moallocate["ByproductFlag"] = 0;
                    drmom_moallocate["QcFlag"] = 0;
                    drmom_moallocate["Offset"] = 0;
                    drmom_moallocate["InvCode"] = dtBomInfo.Rows[j]["cDefWareHouse"];
                    drmom_moallocate["OpComponentId"] = dtBomInfo.Rows[j]["OpComponentId"];

                    if (dtBomInfo.Rows[j]["cAssComUnitCode"].ToString().Trim() != "")
                    {
                        drmom_moallocate["AuxUnitCode"] = dtBomInfo.Rows[j]["cAssComUnitCode"];
                        drmom_moallocate["ChangeRate"] = dtBomInfo.Rows[j]["ChangeRate"];
                        drmom_moallocate["AuxBaseQtyN"] = dtBomInfo.Rows[j]["AuxBaseQtyN"];
                        drmom_moallocate["AuxQty"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol本次下单数量)) * d使用数量 * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBomInfo.Rows[j]["ChangeRate"]);
                    }
                    drmom_moallocate["ReplenishQty"] = 0;
                    drmom_moallocate["Remark"] = DBNull.Value;
                    drmom_moallocate["TransQty"] = 0;
                    drmom_moallocate["ProductType"] = 1;
                    drmom_moallocate["SoType"] = DBNull.Value;
                    drmom_moallocate["SoDId"] = DBNull.Value;
                    drmom_moallocate["SoCode"] = DBNull.Value;
                    drmom_moallocate["SoSeq"] = DBNull.Value;
                    drmom_moallocate["DemandCode"] = DBNull.Value;
                    drmom_moallocate["QmFlag"] = 0;
                    drmom_moallocate["OrgQty"] = 0;
                    drmom_moallocate["OrgAuxQty"] = 0;
                    dtmom_moallocate.Rows.Add(drmom_moallocate);
                }
            }
            if (dtmom_orderdetail.Rows.Count > 0)
            {
                for (int i = 0; i < dtmom_order.Rows.Count; i++)
                {
                    //生成生产订单表头
                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "mom_order", dtmom_order, i));
                }

                for (int i = 0; i < dtmom_orderdetail.Rows.Count; i++)
                {
                    //生成生产订单表体
                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "mom_orderdetail", dtmom_orderdetail, i));
                }

                for (int i = 0; i < dtmom_morder.Rows.Count; i++)
                {
                    //生成生产订单资料表
                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "mom_morder", dtmom_morder, i));
                }

                for (int i = 0; i < dtmom_moallocate.Rows.Count; i++)
                {
                    //生成生产订单用料表
                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "mom_moallocate", dtmom_moallocate, i));
                }

                //更新最大单据号
                if (bVouMOM)
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,cContent,cContentRule,cSeed,cNumber,bEmpty) " +
                            "values('MO21','单据日期','月','" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouMOM + "' Where CardNumber='MO21' and (cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                    aList.Add(sSQL);
                }

                //更新最大ID
                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_order + ",iChildID=" + iIDmom_order + " where  cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'mom_order'";
                aList.Add(sSQL);
                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_orderdetail + ",iChildID=" + iIDmom_orderdetail + " where  cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'mom_orderdetail'";
                aList.Add(sSQL);
                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDmom_moallocate + ",iChildID=" + iIDmom_moallocate + " where  cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'mom_moallocate'";
                aList.Add(sSQL);

                s生成提示 = s生成提示 + "生产订单：" + GetMOMCode(iVouMOM.ToString()) + "\n";
            }
            #endregion

            sSQL = "update dbo.订单评审表头 set 已下单 = 1 where 单据号 = '" + txt单据号.Text.Trim() + "' and 帐套号 = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MsgBox("提示", s生成提示);

                chk已下达计划.Checked = true;
            }
        }

        /// <summary>
        /// 获得请购单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetPU_AppVouchCode(string s)
        {
            for (int i = 0; i < 5; i++)
            {
                if (s.Length < 3)
                {
                    s = "0" + s;
                }
                else
                {
                    break;
                }
            }
            return "PRPM" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + s;
        }
        /// <summary>
        /// 获得生产订单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string GetMOMCode(string s)
        {
            for (int i = 0; i < 5; i++)
            {
                if (s.Length < 4)
                {
                    s = "0" + s;
                }
                else
                {
                    break;
                }
            }
            return "SD" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + s;
        }



        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void FrmOrderReview下达计划_Load(object sender, EventArgs e)
        {
            try
            {
                sState = "sel";

                SetEnable(false);

                GetLookUp();

                GetDTList();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid(string sCode)
        {
            string sSQL = "select * from 订单评审表头 where 单据号 = '" + sCode + "' and 帐套号 = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "' order by iID";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
            {
                return;
            }

            txt单据号.Text = dt.Rows[0]["单据号"].ToString().Trim();
            dtm单据日期.DateTime = Convert.ToDateTime(dt.Rows[0]["单据日期"]);
            txt销售订单号.Text = dt.Rows[0]["销售订单号"].ToString().Trim();
            txt行号.Text = dt.Rows[0]["行号"].ToString().Trim();
            txt外销订单号.Text = dt.Rows[0]["外销订单号"].ToString().Trim();
            txt客户订单号.Text = dt.Rows[0]["客户订单号"].ToString().Trim();
            txt客户简称.Text = dt.Rows[0]["客户简称"].ToString().Trim();
            dtm船期.Text = dt.Rows[0]["船期"].ToString().Trim();
            dtm预完工日期.Text = dt.Rows[0]["预完工日期"].ToString().Trim();
            dtm国外要求交期.Text = dt.Rows[0]["国外要求交期"].ToString().Trim();
            lookUpEdit产品编码.EditValue = dt.Rows[0]["产品编码"];
            lookUpEdit产品名称.EditValue = dt.Rows[0]["产品编码"];
            lookUpEdit规格型号.EditValue = dt.Rows[0]["产品编码"];
            txt订单数量.Text = dt.Rows[0]["订单数量"].ToString().Trim();
            dtm计划开始日期.Text = dt.Rows[0]["计划开始日期"].ToString().Trim();
            dtm计划结束日期.Text = dt.Rows[0]["计划结束日期"].ToString().Trim();
            txt下单数量.Text = dt.Rows[0]["下单数量"].ToString().Trim();
            txt备注.Text = dt.Rows[0]["备注"].ToString().Trim();
            txt制单.Text = dt.Rows[0]["制单"].ToString().Trim();
            dtm制单.Text = dt.Rows[0]["制单日期"].ToString().Trim();
            txt审核.Text = dt.Rows[0]["审核"].ToString().Trim();
            dtm审核.Text = dt.Rows[0]["审核日期"].ToString().Trim();
            txt关闭.Text = dt.Rows[0]["关闭"].ToString().Trim();
            dtm关闭.Text = dt.Rows[0]["关闭日期"].ToString().Trim();
            txt销售订单子表ID.Text = dt.Rows[0]["销售订单子表ID"].ToString().Trim();
            txt销售订单ID.Text = dt.Rows[0]["销售订单ID"].ToString().Trim();
            chk已下达计划.Checked = Convert.ToBoolean(dt.Rows[0]["已下单"]);

            if (txt关闭.Text == "")
                toolStripMenuBtn.Items["open"].Text = "关闭";
            else  
                toolStripMenuBtn.Items["open"].Text = "打开";

            sSQL = "select cast(null as decimal(16,0)) as 仓库现存量,* from 订单评审表体 where 表头单据号 = '" + sCode + "' and 帐套号 = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "' order by iID";
            DataTable dtGrid = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dtGrid;
            gridControl2.DataSource = dtGrid;
            gridControl3.DataSource = dtGrid;
            gridControl4.DataSource = dtGrid;

            gridCol2子件属性.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[子件属性] = '采购'");
            gridCol3子件属性.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[子件属性] = '委外'");
            gridCol4子件属性.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[子件属性] = '自制'");

            SetGrid();
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
        
        /// <summary>
        /// 建立U8与吕云系统的部门对应信息
        /// </summary>
        /// <param name="sDep"></param>
        /// <returns></returns>
        private string sDepInfo(string sDep)
        {
            string sDepU8Name = "";
            switch (sDep)
            {
                case "冲压组": sDepU8Name = "冲压"; break;
                case "焊接组": sDepU8Name = "电焊"; break;
                case "冲压": sDepU8Name = "冲压"; break;
                case "出冲压": sDepU8Name = "冲压"; break;
                case "电焊组": sDepU8Name = "电焊"; break;
                case "拉伸": sDepU8Name = ""; break;
                case "拉伸孔": sDepU8Name = ""; break;
                case "铝件组": sDepU8Name = "铝件"; break;
                case "品管部": sDepU8Name = "品检"; break;
                case "铁件组": sDepU8Name = "铁件组"; break;
                case "维护组": sDepU8Name = "维护组"; break;
                case "委外部": sDepU8Name = "委外部"; break;
                case "物控部": sDepU8Name = "委外部"; break;
                case "研发部": sDepU8Name = "研发"; break;
                case "组装": sDepU8Name = "组装"; break;
                case "组装组": sDepU8Name = "组装"; break;
                case "采购部": sDepU8Name = "采购"; break;
                case "生管部": sDepU8Name = "生管部"; break;
                case "销售/人事部": sDepU8Name = "人事"; break;
                case "财务部": sDepU8Name = "财务"; break;
                case "生产部": sDepU8Name = "生产"; break;
                case "裁切组": sDepU8Name = "裁切--停用"; break;
                case "办公室": sDepU8Name = "人事"; break;

                default: sDepU8Name = sDep; break;
            }
            return sDepU8Name;
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
        //    #region 新增状态排程
        //    if (sState == "add")
        //    {
        //        SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString2);
        //        conn.Open();
        //        //启用事务
        //        SqlTransaction tran = conn.BeginTransaction();
        //        try
        //        {
        //            if (radio逆排.Checked)
        //            {
        //                dtm计划开始日期.DateTime = dtm计划结束日期.DateTime;
        //                gridView1.SetRowCellValue(0, gridCol完成日期, DateTime.Parse(dtm计划结束日期.DateTime.ToString("yyyy-MM-dd")));

        //                InitBomN(tran, "--", decimal.Round(decimal.Parse(txt下单数量.Text), 6), Convert.ToDateTime(dtm计划结束日期.DateTime.ToString("yyyy-MM-dd")));
        //            }
        //            if (radio顺排.Checked)
        //            {
        //                dtm计划结束日期.DateTime = dtm计划开始日期.DateTime;

        //                for (int i = 0; i < gridView1.RowCount; i++)
        //                {
        //                    gridView1.SetRowCellValue(i, gridCol完成日期, DBNull.Value);
        //                    gridView1.SetRowCellValue(i, gridCol建议完成日期, DBNull.Value);
        //                    gridView1.SetRowCellValue(i, gridCol建议开始日期, DBNull.Value);
        //                    gridView1.SetRowCellValue(i, gridCol开始日期, DBNull.Value);
        //                }
        //                for (int i = 0; i < gridView1.RowCount; i++)
        //                {
        //                    if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "采购")
        //                    {
        //                        string sInvCode = gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
        //                        gridView1.SetRowCellValue(i, gridCol建议开始日期, dtm计划开始日期.DateTime.ToString("yyyy-MM-dd"));
        //                    }
        //                }
        //            }
        //            gridControl1.DataSource = dtBom;
        //            gridControl2.DataSource = dtBom;
        //            gridControl3.DataSource = dtBom;
        //            gridControl4.DataSource = dtBom;

        //            try
        //            {
        //                gridView1.FocusedRowHandle -= 1;
        //                gridView1.FocusedRowHandle += 1;
        //            }
        //            catch { }

        //            tran.Commit();
        //        }
        //        catch (Exception error)
        //        {
        //            tran.Rollback();

        //            MessageBox.Show("排程失败" + error.Message);
        //        }
        //    }
        //    #endregion

        //    if (sState == "edit")
        //    {
        //        if (radio顺排.Checked)
        //        {
        //            for (int i = 0; i < gridView1.RowCount; i++)
        //            {
        //                if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "采购")
        //                {
        //                    gridView1.SetRowCellValue(i, gridCol建议开始日期, dtm计划开始日期.DateTime);
        //                }
        //            }
        //        }
        //        if (radio逆排.Checked)
        //        {
        //            gridView1.SetRowCellValue(0, gridCol建议完成日期, dtm计划结束日期.DateTime);
        //        }
        //    }
        }

        private void GetLookUp()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["iID"] = "采购";
            dt.Rows.Add(dr); 
            dr = dt.NewRow();
            dr["iID"] = "委外";
            dt.Rows.Add(dr); 
            dr = dt.NewRow();
            dr["iID"] = "自制";
            dt.Rows.Add(dr);
            ItemLookUpEdit子件属性.DataSource = dt;
            ItemLookUpEdit_子件属性.DataSource = dt;
            ItemLookUpEdit3子件属性.DataSource = dt;
            ItemLookUpEdit4子件属性.DataSource = dt;

            dt = new DataTable();
            dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            dr = dt.NewRow();
            dr["iID"] = "采购周期";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "委外周期";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "质检周期";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "生产日工时";
            dt.Rows.Add(dr);
            lookUpEdit批改.Properties.DataSource = dt;

            sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow drInv = dt.NewRow();
            drInv["cInvCode"] = "--";
            drInv["cInvName"] = "--";
            drInv["cInvStd"] = "--";
            dt.Rows.Add(drInv);

            lookUpEdit产品编码.Properties.DataSource = dt;
            lookUpEdit产品名称.Properties.DataSource = dt;
            lookUpEdit规格型号.Properties.DataSource = dt;
            ItemLookUpEdit规格型号.DataSource = dt;
            ItemLookUpEdit物料编码.DataSource = dt;
            ItemLookUpEdit物料名称.DataSource = dt;
            ItemLookUpEdit_物料编码.DataSource = dt;
            ItemLookUpEdit_物料名称.DataSource = dt;
            ItemLookUpEdit_物料规格.DataSource = dt;
            ItemLookUpEdit3物料编码.DataSource = dt;
            ItemLookUpEdit3物料名称.DataSource = dt;
            ItemLookUpEdit3物料规格.DataSource = dt;
            ItemLookUpEdit4物料编码.DataSource = dt;
            ItemLookUpEdit4物料名称.DataSource = dt;
            ItemLookUpEdit4物料规格.DataSource = dt;
        }

        private void dtm计划开始日期_EditValueChanged(object sender, EventArgs e)
        {
            if (dtm计划开始日期.DateTime < Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
            {
                dtm计划开始日期.BackColor = Color.Tomato;
            }
            else
            {
                dtm计划开始日期.BackColor = Color.White;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (lookUpEdit批改.Text.Trim() == "")
            {
                MessageBox.Show("请选择需要批改的内容");
                return;
            }
            if (txt批改.Text.Trim() == "")
            {
                MessageBox.Show("请输入需要批改的内容");
                return;
            }

            string s = lookUpEdit批改.Text.Trim();

            for (int j = 0; j < gridView1.RowCount; j++)
            {
                string s1 = gridView1.GetRowCellValue(j, gridCol子件属性).ToString().Trim();

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].Caption == s && gridView1.GetRowCellValue(j,gridView1.Columns[i]).ToString().Trim() != "")
                    {
                        gridView1.SetRowCellValue(j, gridView1.Columns[i], txt批改.Text.Trim());
                        continue;
                    }
                }
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //DateTime dTime1 = Convert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, gridCol开始日期));
            //if (dTime1 < DateTime.Today)
            //    e.Appearance.BackColor = Color.Tomato;
            //DateTime dTime2 = Convert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, gridCol完成日期));
            //if (dTime2 < DateTime.Today)
            //    e.Appearance.BackColor = Color.Tomato;
            //if (dTime1 > dTime2)
            //    e.Appearance.BackColor = Color.Tomato;
        }

        private object ReturnValue(object a)
        {
            if (a.ToString().Trim() == "")
                return DBNull.Value;
            else
                return a;
        }

        private object ReturnDate(DateTime a)
        {
            if (a < Convert.ToDateTime("1900-1-1"))
                return DBNull.Value;
            else
                return a.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 获得单据列表
        /// </summary>
        private void GetDTList()
        { 
            sSQL = "select 单据号 from dbo.订单评审表头 order by iID";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count;
                string sCode = dtSel.Rows[iPage-1]["单据号"].ToString().Trim();
                GetGrid(sCode);

                base.lPageInfo.Text = iPage.ToString() + "/" + iPage.ToString();
            }
            else
            {
                SetTxtGridNull();
            }
        }

        private void SetTxtGridNull()
        {
            txt单据号.Text = "";
            dtm单据日期.Text = "";
            txt销售订单号.Text = "";
            txt行号.Text = "";
            txt外销订单号.Text = "";
            txt客户订单号.Text = "";
            txt客户简称.Text = "";
            dtm船期.Text = "";
            dtm预完工日期.Text = "";
            dtm国外要求交期.Text = "";
            lookUpEdit产品编码.EditValue = DBNull.Value;
            lookUpEdit产品名称.EditValue = DBNull.Value;
            lookUpEdit规格型号.EditValue = DBNull.Value;
            txt订单数量.Text = "";
            dtm计划开始日期.Text = "";
            dtm计划结束日期.Text = "";
            txt下单数量.Text = "";
            txt备注.Text = "";
            txt制单.Text = "";
            dtm制单.Text = "";
            txt审核.Text = "";
            dtm审核.Text = "";
            txt关闭.Text = "";
            dtm关闭.Text = "";
            txt销售订单子表ID.Text = "";
            txt销售订单ID.Text = "";
            chk已下达计划.Checked = false;

            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            gridControl3.DataSource = null;
            gridControl4.DataSource = null;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.OptionsBehavior.Editable)
            {
                switch (gridView1.GetRowCellValue(e.FocusedRowHandle, gridCol子件属性).ToString().Trim())
                {
                    case "委外":
                        gridCol采购周期.OptionsColumn.AllowEdit = false;
                        gridCol委外周期.OptionsColumn.AllowEdit = true;
                        gridCol生产周期.OptionsColumn.AllowEdit = false;
                        gridCol生产日工时.OptionsColumn.AllowEdit = false;
                        break;
                    case "采购":
                        gridCol采购周期.OptionsColumn.AllowEdit = true;
                        gridCol委外周期.OptionsColumn.AllowEdit = false;
                        gridCol生产周期.OptionsColumn.AllowEdit = false;
                        gridCol生产日工时.OptionsColumn.AllowEdit = false;
                        break;
                    case "自制":
                        gridCol采购周期.OptionsColumn.AllowEdit = false;
                        gridCol委外周期.OptionsColumn.AllowEdit = false;
                        gridCol生产周期.OptionsColumn.AllowEdit = true;
                        gridCol生产日工时.OptionsColumn.AllowEdit = true;
                        break;
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

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (radio逆排.Checked)
            {
                if (e.Column == gridCol建议完成日期 || e.Column == gridCol本次下单数量 || e.Column == gridCol采购周期 || e.Column == gridCol委外周期 || e.Column == gridCol生产日工时 || e.Column == gridCol生产周期 || e.Column == gridCol质检周期)
                {
                    string s子件编码 = gridView1.GetRowCellValue(e.RowHandle, gridCol子件编码).ToString().Trim();
                    decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol本次下单数量));
                    DateTime d建议完成日期 = Convert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, gridCol建议完成日期));
                    gridView1.SetRowCellValue(e.RowHandle, gridCol完成日期, d建议完成日期);

                    InitEditN(s子件编码, d本次下单数量, d建议完成日期);

                    dtm计划结束日期.DateTime = Convert.ToDateTime(gridView1.GetRowCellValue(0, gridCol建议完成日期));
                    dtm计划开始日期.DateTime = Convert.ToDateTime(gridView1.GetRowCellValue(0, gridCol建议完成日期));
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        DateTime d = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridCol建议开始日期));
                        if (d < dtm计划开始日期.DateTime)
                            dtm计划开始日期.DateTime = d;
                    }
                }
            }
            if (radio顺排.Checked)
            {
                if (gridView1.GetRowCellValue(e.RowHandle, gridCol建议开始日期).ToString() == "")
                    return;

                if (e.Column == gridCol建议开始日期 || e.Column == gridCol本次下单数量 || e.Column == gridCol采购周期 || e.Column == gridCol委外周期 || e.Column == gridCol生产日工时 || e.Column == gridCol生产周期 || e.Column == gridCol质检周期)
                {
                    string s子件编码 = gridView1.GetRowCellValue(e.RowHandle, gridCol子件编码).ToString().Trim();
                    decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol本次下单数量));
                    DateTime d建议开始日期 = Convert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, gridCol建议开始日期));
                    //gridView1.SetRowCellValue(e.RowHandle, gridCol开始日期, d建议开始日期);
                    InitEditS(s子件编码, d本次下单数量, d建议开始日期);

                    DateTime d1 = Convert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, gridCol建议开始日期));
                    DateTime d11 = Convert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, gridCol建议完成日期 ));
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridCol建议开始日期).ToString().Trim() == "")
                            continue;
                        DateTime d2 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridCol建议开始日期));
                        if (d1 > d2)
                        {
                            d1 = d2;
                        }
                        if (gridView1.GetRowCellValue(i, gridCol建议完成日期).ToString().Trim() == "")
                            continue;
                        DateTime d22 = Convert.ToDateTime(gridView1.GetRowCellValue(i, gridCol建议完成日期));
                        if (d11 < d22)
                        {
                            d11 = d22;
                        }
                    }
                    dtm计划开始日期.DateTime = d1;
                    dtm计划结束日期.DateTime = d11;
                }
            }
        }

        /// <summary>
        /// 编辑状态逆排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="dQty">母件下单数量</param>
        /// <param name="dDate1">计划结束日期</param>
        private void InitEditN(string sInvCode, decimal dQty, DateTime dDate1)
        {
            DataRow[] drMList = dtBom.Select(" 子件编码 = '" + sInvCode + "' ");
            foreach (DataRow dr in drMList)
            {
                   double i置办周期 = 1;
                if (dr["子件属性"].ToString().Trim() == "采购" && dr["采购周期"].ToString().Trim() != "")
                {
                    i置办周期 = ReturnObjectToInt(dr["采购周期"]) + ReturnObjectToInt(dr["质检周期"]);
                }
                if (dr["子件属性"].ToString().Trim() == "委外" && dr["委外周期"].ToString().Trim() != "")
                {
                    i置办周期 = ReturnObjectToInt(dr["委外周期"]) + ReturnObjectToInt(dr["质检周期"]);
                }
                if (dr["子件属性"].ToString().Trim() == "自制")
                {
                    DataRow[] dr工时List = dt工时工序.Select(" 物料编码 = '" + dr["子件编码"].ToString().Trim() + "' ");
                    if (dr工时List.Length < 1)
                    {
                        //未设置母件工时工序，需要中其他母件工时工序表获得资料
                    }

                    double d工时 = 0;
                    for (int i = 0; i < dr工时List.Length; i++)
                    {
                        if (dr工时List[i]["单位工时"].ToString().Trim() != "")
                        {
                            d工时 = d工时 + Convert.ToDouble(dr工时List[i]["单位工时"]) * Convert.ToDouble(dr["本次下单数量"]) / Convert.ToDouble(dr工时List[i]["作业人员数量"]);
                        }
                    }
                    i置办周期 = Math.Ceiling(d工时 / Convert.ToDouble(dr["生产日工时"]));
                }
                dr["开始日期"] = Convert.ToDateTime(dr["完成日期"]).AddDays(-1 * i置办周期);
                dr["建议开始日期"] = Convert.ToDateTime(dr["完成日期"]).AddDays(-1 * i置办周期);
                dDate1 = Convert.ToDateTime(dr["完成日期"]).AddDays(-1 * i置办周期);
            }


            DataRow[] drList = dtBom.Select(" 母件编码 = '" + sInvCode + "' ");

            foreach (DataRow dr in drList)
            {
                dr["需求数量"] = decimal.Round(dQty * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["使用数量"]), 6);
                dr["本次下单数量"] = dr["需求数量"];

                double i置办周期 = 1;
                if (dr["子件属性"].ToString().Trim() == "采购" && dr["采购周期"].ToString().Trim() != "")
                {
                    i置办周期 = ReturnObjectToInt(dr["采购周期"]) + ReturnObjectToInt(dr["质检周期"]);
                }
                if (dr["子件属性"].ToString().Trim() == "委外" && dr["委外周期"].ToString().Trim() != "")
                {
                    i置办周期 = ReturnObjectToInt(dr["委外周期"]) + ReturnObjectToInt(dr["质检周期"]);
                }
                if (dr["子件属性"].ToString().Trim() == "自制")
                {
                    DataRow[] dr工时List = dt工时工序.Select(" 物料编码 = '" + dr["子件编码"].ToString().Trim() + "' ");
                    if (dr工时List.Length < 1)
                    {
                        //未设置母件工时工序，需要中其他母件工时工序表获得资料
                    }

                    double d工时 = 0;
                    for (int i = 0; i < dr工时List.Length; i++)
                    {
                        if (dr工时List[i]["单位工时"].ToString().Trim() != "")
                        {
                            d工时 = d工时 + Convert.ToDouble(dr工时List[i]["单位工时"]) * Convert.ToDouble(dr["本次下单数量"]) / Convert.ToDouble(dr工时List[i]["作业人员数量"]);
                        }
                    }
                    i置办周期 = Math.Ceiling(d工时 / Convert.ToDouble(dr["生产日工时"]));
                    dr["生产周期"] = i置办周期;
                }
                //dr["置办周期"] = i置办周期;

                if (sInvCode == "--")
                {
                    dr["完成日期"] = dDate1;
                    dr["建议完成日期"] = dDate1;
                }
                else
                {
                    dr["完成日期"] = dDate1.AddDays(-1);
                    dr["建议完成日期"] = dDate1.AddDays(-1);
                }
                dr["开始日期"] = Convert.ToDateTime(dr["完成日期"]).AddDays(-1 * i置办周期);
                dr["建议开始日期"] = Convert.ToDateTime(dr["完成日期"]).AddDays(-1 * i置办周期);
                if (dtm计划开始日期.DateTime > Convert.ToDateTime(dr["开始日期"]))
                {
                    dtm计划开始日期.DateTime = Convert.ToDateTime(dr["开始日期"]);
                }

                InitEditN(dr["子件编码"].ToString().Trim(), decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["本次下单数量"]), 6), Convert.ToDateTime(Convert.ToDateTime(dr["开始日期"]).ToString("yyyy-MM-dd")));
            }
        }

        /// <summary>
        /// 编辑状态顺排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">子件编码</param>
        /// <param name="dQty">本次下单数量</param>
        /// <param name="dDate1">计划开始日期</param>
        private void InitEditS(string sInvCode, decimal dQty, DateTime dDate1)
        {
            DataRow[] drList = dtBom.Select(" 子件编码 = '" + sInvCode + "' ");

            foreach (DataRow dr in drList)
            {
                double i置办周期 = 1;
                if (dr["子件属性"].ToString().Trim() == "采购" && dr["采购周期"].ToString().Trim() != "")
                {
                    i置办周期 = ReturnObjectToInt(dr["采购周期"]) + ReturnObjectToInt(dr["质检周期"]);
                }
                if (dr["子件属性"].ToString().Trim() == "委外" && dr["委外周期"].ToString().Trim() != "")
                {
                    i置办周期 = ReturnObjectToInt(dr["委外周期"]) + ReturnObjectToInt(dr["质检周期"]);
                }
                if (dr["子件属性"].ToString().Trim() == "自制")
                {
                    DataRow[] dr工时List = dt工时工序.Select(" 物料编码 = '" + sInvCode + "' ");
                    if (dr工时List.Length < 1)
                    {
                        //未设置母件工时工序，需要中其他母件工时工序表获得资料
                    }

                    double d工时 = 0;
                    for (int i = 0; i < dr工时List.Length; i++)
                    {
                        if (dr工时List[i]["单位工时"].ToString().Trim() != "")
                        {
                            d工时 = d工时 + Convert.ToDouble(dr工时List[i]["单位工时"]) * Convert.ToDouble(dr["本次下单数量"]) / Convert.ToDouble(dr工时List[i]["作业人员数量"]);
                        }
                    }
                    i置办周期 = Math.Ceiling(d工时 / Convert.ToDouble(dr["生产日工时"]));
                    dr["生产周期"] = i置办周期;
                }
                if (dr["建议开始日期"].ToString().Trim() != "")
                {
                    if (Convert.ToDateTime(dr["建议开始日期"]) < dDate1)
                    {
                        dr["建议开始日期"] = dDate1;
                    }
                }
                else
                {
                    dr["建议开始日期"] = dDate1;
                }

                dr["建议完成日期"] = Convert.ToDateTime(dr["建议开始日期"]).AddDays(i置办周期);
                dr["开始日期"] = dr["建议开始日期"];
                dr["完成日期"] = dr["建议完成日期"];

                if (dtm计划结束日期.DateTime < Convert.ToDateTime(dr["建议完成日期"]))
                {
                    dtm计划结束日期.DateTime = Convert.ToDateTime(dr["建议完成日期"]);
                }

                InitEditS(dr["母件编码"].ToString().Trim(), decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["需求数量"]), 6), Convert.ToDateTime(Convert.ToDateTime(dr["建议完成日期"]).ToString("yyyy-MM-dd")).AddDays(1));
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (radio逆排.Checked)
            {
                gridCol建议开始日期.OptionsColumn.AllowEdit = false;
                gridCol建议完成日期.OptionsColumn.AllowEdit = true;
            }
            if (radio顺排.Checked)
            {
                gridCol建议开始日期.OptionsColumn.AllowEdit = true;
                gridCol建议完成日期.OptionsColumn.AllowEdit = false;
            }
        }

        /// <summary>
        /// 获得Grid动态数据
        /// </summary>
        private void SetGrid()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string s子件编码 = gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                string s仓库编码= gridView1.GetRowCellValue(i, gridCol仓库代号).ToString().Trim();
                sSQL = "select sum(iQuantity) as iQty from @u8.CurrentStock where cInvCode = '" + s子件编码 + "' and cWhCode = '" + s仓库编码 + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(i, gridCol仓库现存量, dt.Rows[0][0]);

                    if (sState == "add")
                    {
                        if (gridView1.GetRowCellValue(i, gridCol最小批量).ToString().Trim() != "" && FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridCol最小批量)) > 0)
                        {
                            sSQL = "select sum(isnull(a.需求数量,0)) - sum(isnull(a.本次下单数量,0)) from dbo.订单评审表体 a inner join dbo.订单评审表头 b on a.表头单据号 = b.单据号 " +
                                    "where isnull(b.已下单,0) = 1 and b.帐套号 =  " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " and 子件编码 = '" + s子件编码 + "'";
                            dt = clsSQLCommond.ExecQuery(sSQL);

                            decimal d超单数量 = 0;
                            decimal d需求数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i,gridCol需求数量));
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                d超单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0][0]);
                                if (d超单数量 >= d需求数量)
                                {
                                    gridView1.SetRowCellValue(i, gridCol本次下单数量, 0);
                                }
                                else
                                {
                                    gridView1.SetRowCellValue(i, gridCol本次下单数量, gridView1.GetRowCellValue(i, gridCol最小批量));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
