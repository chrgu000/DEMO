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
    public partial class FrmOrderReview采购 : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmOrderReview采购()
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
            dtm计划开始日期.Enabled = false;
            dtm计划结束日期.Enabled = false;
            txt下单数量.Enabled = false;
            txt备注.Enabled = false;

            lookUpEdit批改.Enabled = b;
            txt批改.Enabled = b;
            btnChange.Enabled = b;

            gridView1.OptionsBehavior.Editable = false;

            gridView2.OptionsBehavior.Editable = b;
            gridCol2质检周期.OptionsColumn.AllowEdit = b;
            chkAll.Enabled = b;
        }

        DataTable dtBom = null;
        DataTable dt工时工序 = null;
        private void GetBOMPlan()
        {
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString2);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sInvCode = lookUpEdit产品编码.Text.Trim();
                DateTime dDate1 = dtm计划结束日期.DateTime;                     //预完工日期
                decimal dQty = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(txt下单数量.Text);             //下单数量

                ///一 展开BOM
                ///1. 获得BOM（单层），获得子件，使用数量，计算出毛需求量
                ///2. 获得工时工序表，当直接母件没有时搜寻其他母件下的工时工序表中有没有此物料，有则列表提醒人工选择（按照约定，相同物料应该拥有相同工时工序）
                ///3. 根据BOM子件，工时工序表获得采购、委外、生产周期
                ///4. 计算需求日期，根据库存、采购、委外、生产信息确定净需求（预留不参与计算的档案）
                ///5. 循环展开BOM直到最后一层结束
                ///备注：需要注意虚拟件、木制品；


                //获得BOM
                dtBom = GetBomSQL(tran, sInvCode);

                for (int i = 0; i < dtBom.Rows.Count; i++)
                {
                    dtBom.Rows[i]["级别"] = dtBom.Rows[i]["级别"].ToString().Trim().Length;

                    string sSQL = "select iInvAdvance as 提前期,cInvDefine3 as 最小批量 from Inventory where cInvCode = '" + dtBom.Rows[i]["子件编码"] + "'";
                    DataTable dt = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "采购")
                        {
                            dtBom.Rows[i]["采购周期"] = dt.Rows[0]["提前期"];
                        }
                        if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "委外")
                        {
                            dtBom.Rows[i]["委外周期"] = dt.Rows[0]["提前期"];
                        }

                        decimal d = 0;
                        try
                        {
                            d = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[0]["最小批量"]);
                        }
                        catch { }
                        dtBom.Rows[i]["最小批量"] = d;
                    }
                }

                for (int i = 0; i < dtBom.Rows.Count; i++)
                {
                    if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "采购")
                    {
                        dtBom.Rows[i]["质检周期"] = 3;
                    }
                    if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "委外")
                    {
                        dtBom.Rows[i]["质检周期"] = 2;
                    }
                    if (dtBom.Rows[i]["子件属性"].ToString().Trim() == "自制")
                    {
                        dtBom.Rows[i]["生产日工时"] = 8;
                    }
                }

                string sErrBOM = "";
                //判断BOM是否完整
                //最末级是否采购件
                for (int i = 0; i < dtBom.Rows.Count; i++)
                {
                    if (dtBom.Rows[i]["级别"].ToString().Trim() == "0")
                    {
                        continue;
                    }
                    string s子件属性 = dtBom.Rows[i]["子件属性"].ToString().Trim();
                    if (s子件属性 == "采购")
                        continue;

                    string s子件编码 = dtBom.Rows[i]["子件编码"].ToString().Trim();
                    DataRow[] dr = dtBom.Select(" 母件属性 = '" + s子件属性 + "' ");
                    if (dr.Length == 0)
                    {
                        sErrBOM = sErrBOM + s子件编码 + "\n";
                    }
                }
                if (sErrBOM.Trim() != "")
                {
                    throw new Exception("请完善BOM\n物料：\n" + sErrBOM);
                }


                //获得工时工序
                dt工时工序 = Get工时工序(tran, sInvCode);

                if (dtBom == null || dtBom.Rows.Count < 1)
                {
                    throw new Exception("物料" + sInvCode + " 未建立BOM");
                }

                InitBomN(tran, "--", decimal.Round(decimal.Parse(txt下单数量.Text), 6), dtm计划结束日期.DateTime);

                gridControl1.DataSource = dtBom;
                gridControl2.DataSource = dtBom;

                tran.Commit();
            }

            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }
        }

        /// <summary>
        /// 新增状态逆排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="dQty">母件下单数量</param>
        /// <param name="dDate1">计划结束日期</param>
        private void InitBomN(SqlTransaction tran,string sInvCode, decimal dQty, DateTime dDate1)
        {
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
                dr["置办周期"] = i置办周期;

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

                InitBomN(tran, dr["子件编码"].ToString().Trim(), decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["本次下单数量"]), 6), Convert.ToDateTime(Convert.ToDateTime(dr["开始日期"]).ToString("yyyy-MM-dd")));
            }
        }

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
        //            i置办周期 = Math.Ceiling(d工时 / Convert.ToDouble(dr["生产日工时"]));
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
            //for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        gridView1.DeleteRow(i);
            //    }
            //}
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (txt单据号.Text.Trim() == "")
            {
                throw new Exception("请选择需要评审的单据");
            }

            if (txt审核.Text.Trim() == "")
            {
                throw new Exception("尚未审核，不能评审");
            }

            if (txt关闭.Text.Trim() != "")
            {
                throw new Exception("已经关闭，不能评审");
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

            for (int i = 0; i < gridView2.RowCount; i++)
            {
                if (gridView2.GetRowCellValue(i, gridCol选择).ToString().Trim() == "√")
                {
                    sSQL = "update 订单评审表体 set 评审开始日期 = '" + gridView2.GetRowCellValue(i, gridCol2评审开始日期) + "',评审完成日期='" + gridView2.GetRowCellValue(i, gridCol2评审完成日期) + "',采购周期 = " + gridView2.GetRowCellValue(i, gridCol2采购周期) + ",质检周期 =" + gridView2.GetRowCellValue(i, gridCol2质检周期) + ", 评审人 = '" + gridView2.GetRowCellValue(i, gridCol2评审人) + "',评审日期 = '" + gridView2.GetRowCellValue(i, gridCol2评审日期) + "' where iID = " + gridView2.GetRowCellValue(i, gridCol2iID) + " ";
                    aList.Add(sSQL);
                }
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                SetEdit(false);

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
           
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            
        }

        /// <summary>
        /// 下达计划：生成采购请购单，委外计划，生产订单
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

        private void FrmOrderReview采购_Load(object sender, EventArgs e)
        {
            try
            {
                sState = "sel";

                SetEnable(false);

                GetLookUp();

                GetDTList();

                radio逆排.Visible = false;
                radio顺排.Checked = true;
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

            sSQL = "select '' as 选择,cast(null as decimal(16,0)) as 仓库现存量,* from 订单评审表体 where 表头单据号 = '" + sCode + "' and 帐套号 = '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "' order by iID";
            DataTable dtGrid = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dtGrid;
            gridControl2.DataSource = dtGrid;

            gridCol2子件属性.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("[子件属性] = '采购'");

            SetGrid();

            chkAll.Checked = false;
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
            #region 新增状态排程
            if (sState == "add")
            {
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString2);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if (radio逆排.Checked)
                    {
                        dtm计划开始日期.DateTime = dtm计划结束日期.DateTime;
                        gridView1.SetRowCellValue(0, gridCol完成日期, DateTime.Parse(dtm计划结束日期.DateTime.ToString("yyyy-MM-dd")));

                        InitBomN(tran, "--", decimal.Round(decimal.Parse(txt下单数量.Text), 6), Convert.ToDateTime(dtm计划结束日期.DateTime.ToString("yyyy-MM-dd")));
                    }
                    if (radio顺排.Checked)
                    {
                        dtm计划结束日期.DateTime = dtm计划开始日期.DateTime;

                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            gridView1.SetRowCellValue(i, gridCol完成日期, DBNull.Value);
                            gridView1.SetRowCellValue(i, gridCol建议完成日期, DBNull.Value);
                            gridView1.SetRowCellValue(i, gridCol建议开始日期, DBNull.Value);
                            gridView1.SetRowCellValue(i, gridCol开始日期, DBNull.Value);
                        }
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "采购")
                            {
                                string sInvCode = gridView1.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                                gridView1.SetRowCellValue(i, gridCol建议开始日期, dtm计划开始日期.DateTime.ToString("yyyy-MM-dd"));
                            }
                        }
                    }
                    gridControl1.DataSource = dtBom;
                    gridControl2.DataSource = dtBom;

                    try
                    {
                        gridView1.FocusedRowHandle -= 1;
                        gridView1.FocusedRowHandle += 1;
                    }
                    catch { }

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();

                    MessageBox.Show("排程失败" + error.Message);
                }
            }
            #endregion

            if (sState == "edit")
            {
                if (radio顺排.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridCol子件属性).ToString().Trim() == "采购")
                        {
                            gridView1.SetRowCellValue(i, gridCol建议开始日期, dtm计划开始日期.DateTime);
                        }
                    }
                }
                if (radio逆排.Checked)
                {
                    gridView1.SetRowCellValue(0, gridCol建议完成日期, dtm计划结束日期.DateTime);
                }
            }
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
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.OptionsBehavior.Editable)
            {
                if (gridView1.GetRowCellValue(e.FocusedRowHandle, gridCol子件属性).ToString().Trim() == "采购")
                {
                    gridCol采购周期.OptionsColumn.AllowEdit = true;
                    gridCol本次下单数量.OptionsColumn.AllowEdit = true;
                    gridCol评审开始日期.OptionsColumn.AllowEdit = true;
                    gridCol评审完成日期.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridCol采购周期.OptionsColumn.AllowEdit = false;
                    gridCol本次下单数量.OptionsColumn.AllowEdit = false;
                    gridCol评审开始日期.OptionsColumn.AllowEdit = false;
                    gridCol评审完成日期.OptionsColumn.AllowEdit = false;
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

        //private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        //{
        //    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        //    if (e.Info.IsRowIndicator)
        //    {
        //        if (e.RowHandle >= 0)
        //        {
        //            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        //        }
        //        else if (e.RowHandle < 0 && e.RowHandle > -1000)
        //        {
        //            e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
        //            e.Info.DisplayText = "G" + e.RowHandle.ToString();
        //        }
        //    }
        //}

        //private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        //{
        //    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        //    if (e.Info.IsRowIndicator)
        //    {
        //        if (e.RowHandle >= 0)
        //        {
        //            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        //        }
        //        else if (e.RowHandle < 0 && e.RowHandle > -1000)
        //        {
        //            e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
        //            e.Info.DisplayText = "G" + e.RowHandle.ToString();
        //        }
        //    }
        //}

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
                gridCol2评审开始日期 .OptionsColumn.AllowEdit = false;
                gridCol2评审完成日期.OptionsColumn.AllowEdit = true;
            }
            if (radio顺排.Checked)
            {
                gridCol2评审开始日期.OptionsColumn.AllowEdit = true;
                gridCol2评审完成日期.OptionsColumn.AllowEdit = false;
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

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (sState == "edit")
            {
                CheckLock();
                try
                {
                    if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol2锁定人).ToString().Trim() == "")
                    {
                        if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol选择).ToString().Trim() == "")
                        {
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol选择, "√");
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol评审开始日期, gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol2建议开始日期));
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol评审完成日期, gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol2建议完成日期));
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol2评审人, FrameBaseFunction.ClsBaseDataInfo.sUserName);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol2评审日期, FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                        }
                        else
                        {
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol选择, "");
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol评审开始日期, DBNull.Value);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol评审完成日期, DBNull.Value);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol2评审人, DBNull.Value);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol2评审日期, DBNull.Value);
                        }
                    }
                    else
                    {
                        MessageBox.Show("已经锁定，不能评审");
                    }
                }
                catch
                { }
            }
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (radio顺排.Checked)
            {
                if (e.Column == gridCol2评审开始日期)
                {
                    string iID2 = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol2iID).ToString().Trim();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string iID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                        if (iID == iID2)
                        {
                            gridView1.SetRowCellValue(i, gridCol建议开始日期, gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol评审开始日期));
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol2评审完成日期, gridView1.GetRowCellValue(i, gridCol建议完成日期));
                            break;
                        }
                    }
                }
                if (e.Column == gridCol2采购周期)
                {
                    string iID2 = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol2iID).ToString().Trim();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string iID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                        if (iID == iID2)
                        {
                            gridView1.SetRowCellValue(i, gridCol采购周期, gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol2采购周期));
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol2评审完成日期, gridView1.GetRowCellValue(i, gridCol建议完成日期));
                            break;
                        }
                    }
                }
                if (e.Column == gridCol2质检周期)
                {
                    string iID2 = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol2iID).ToString().Trim();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        string iID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                        if (iID == iID2)
                        {
                            gridView1.SetRowCellValue(i, gridCol质检周期, gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridCol2质检周期));
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridCol2评审完成日期, gridView1.GetRowCellValue(i, gridCol建议完成日期));
                            break;
                        }
                    }
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckLock();

            if (chkAll.Checked)
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, gridCol2锁定人).ToString().Trim() != "")
                        continue;

                    gridView2.SetRowCellValue(i, gridCol选择, "√");
                    gridView2.SetRowCellValue(i, gridCol2评审人, FrameBaseFunction.ClsBaseDataInfo.sUserName);
                    gridView2.SetRowCellValue(i, gridCol2评审日期, FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                    if (gridView2.GetRowCellValue(i, gridCol2评审开始日期).ToString().Trim() == "")
                    {
                        gridView2.SetRowCellValue(i, gridCol2评审开始日期, gridView2.GetRowCellValue(i, gridCol2建议开始日期));
                        gridView2.SetRowCellValue(i, gridCol2评审完成日期, gridView2.GetRowCellValue(i, gridCol2建议完成日期));
                    }
                }
            }
            else
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    gridView2.SetRowCellValue(i, gridCol选择, "");
                } 
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (sState == "edit")
                {
                    if (gridView2.GetRowCellValue(e.FocusedRowHandle, gridCol2锁定人).ToString().Trim() == "")
                    {
                        gridView2.OptionsBehavior.Editable = true;
                    }
                    else
                    {
                        gridView2.OptionsBehavior.Editable = false;
                    }
                }
                else
                {
                    gridView2.OptionsBehavior.Editable = false;
                }
            }
            catch { }
        }

        private void CheckLock()
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount;i++ )
                {
                    sSQL = "select * from 订单评审表体 where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(i, gridCol锁定人, dt.Rows[0]["锁定人"]);
                        gridView1.SetRowCellValue(i, gridCol锁定日期, dt.Rows[0]["锁定日期"]);
                    }
                }
            }
            catch { }
        }
    }
}
