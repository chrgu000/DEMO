using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace WorkInformation
{
    public partial class FrmWorkPlanDay : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmWorkPlanDay()
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
                    case "audit":
                        btnAudit();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "print":
                        btnPrint();
                        break;
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
                    case "layout":
                        btnLayout(sBtnText);
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "edit":
                        btnEdit();
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

        private void btnEdit()
        {
            if (lAudit.Text.Trim() != "")
                throw new Exception("已经审核不能修改");

            sSQL = "select max(排产日期) from 生产日计划";
            DateTime dMax = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
            if (dMax > dtm.DateTime)
            {
                throw new Exception("不能修改历史计划");
            }

            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.ReadOnly = false;
        }

        private void btnAlter()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = "生产计划表";
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
                MessageBox.Show("导出生产计划失败:" + ee.Message);
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
            DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
            DataColumn dc = new DataColumn();
            dc.ColumnName = "StateText";
            dt.Columns.Add(dc);
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
                if (drState.Length > 0)
                {
                    dt.Rows[i]["StateText"] = drState[0]["State"];
                }

            }

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
                if (lAudit.Text.Trim() == "lAudit" || lAudit.Text.Trim() == "")
                {
                    throw new Exception("尚未审核，不能导出");
                }

                #region 导出生产计划（用于条码工具导入）

                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "选择";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "外销订单";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "产品编码";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "物料编码";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "半成品编码";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "制造令号码";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "产品名称";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "产品规格";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "班组";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "加工顺序";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "下一班组";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "工序";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "下道工序";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "计划数量";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "制造令数量";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "计划日期";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "人员";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "未完工数量";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "备注";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "理论工时";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "设备";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "是否入库";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "完工数量";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "不良品数量";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "不良类别";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "是否计算工时";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "问题数据";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "最早计划日期";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "托外结束时间";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "预计计划数量";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "预计理论工时";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "子件缺料数量";
                dt.Columns.Add(dc);

                int i导出天数 = ReturnObjectToInt(textEdit1.Text.Trim());
                if (i导出天数 <= 0)
                {
                    throw new Exception("导出天数必须是大于0的整数");
                }
                if (i导出天数 > 30)
                {
                    throw new Exception("导出天数不能超过一个月");
                }

                string s日期 = dtmPlan1.DateTime.ToString("MM月dd日");
                int iCol = -1;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    if (gridView1.Columns[i].Caption == s日期)
                    {
                        iCol = i;
                        break;
                    }
                }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    //按设定取计划数量
                    decimal d计划数量 = 0;
                    for (int j = 0; j < i导出天数; j++)
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns[iCol + j]).ToString().Trim() != "" && gridView1.GetRowCellValue(i, gridView1.Columns[iCol + j]).ToString().Trim() != "0")
                        {
                            decimal d1 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[iCol + j]));// +FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["日期2"]));
                            if (d1 <= 0)
                            {
                                continue;
                            }
                            else
                            {
                                d计划数量 = d计划数量 + d1;
                            }
                        }
                    }
                    if (d计划数量 <= 0)
                        continue;

                    int i是否双条码 = 1;

                    //if (gridView1.GetRowCellValue(i, gridCol物料编码).ToString().Trim() == "ZZ1011Garden40")
                    //{ 
                    
                    //}

                    //流转跟工序报表合并一个条码
                    //if (gridView1.GetRowCellValue(i, gridCol完工入库).ToString().Trim().ToLower() == "y" || gridView1.GetRowCellValue(i, gridCol完工入库).ToString().Trim().ToLower() == "l")
                    //    i是否双条码 = 2;

                    if (gridView1.GetRowCellValue(i, gridCol完工入库).ToString().Trim().ToLower() == "y")
                        i是否双条码 = 2;

                    for (int ii = 0; ii < i是否双条码; ii++)
                    {
                        DataRow dr = dt.NewRow();

                        if (ii == 0)
                        {
                            dr["是否入库"] = gridView1.GetRowCellValue(i, gridCol完工入库);
                        }
                        else
                        {
                            dr["是否入库"] = "N";
                        }


                        dr["计划数量"] = d计划数量;
                        dr["预计计划数量"] = d计划数量;
                        dr["外销订单"] = gridView1.GetRowCellValue(i, gridCol外销订单);
                        dr["产品编码"] = gridView1.GetRowCellValue(i, gridCol产品编码);
                        dr["物料编码"] = gridView1.GetRowCellValue(i, gridCol物料编码);
                        dr["半成品编码"] = gridView1.GetRowCellValue(i, gridCol半成品编码);
                        dr["制造令号码"] = gridView1.GetRowCellValue(i, gridCol制造令号码);
                        dr["产品名称"] = gridView1.GetRowCellDisplayText(i, gridCol产品名称);
                        dr["产品规格"] = gridView1.GetRowCellDisplayText(i, gridCol产品规格);
                        dr["班组"] = gridView1.GetRowCellValue(i, gridCol组别);
                        dr["加工顺序"] = gridView1.GetRowCellValue(i, gridCol加工顺序);
                        dr["下一班组"] = gridView1.GetRowCellValue(i, gridCol下一班组);
                        dr["工序"] = gridView1.GetRowCellValue(i, gridCol工序);
                        dr["下道工序"] = gridView1.GetRowCellValue(i, gridCol下道工序);

                        dr["制造令数量"] = gridView1.GetRowCellValue(i, gridCol制造令数量);
                        if (gridView1.GetRowCellValue(i, gridCol制造令数量).ToString().Trim() == "")
                        {
                            dr["制造令数量"] = gridView1.GetRowCellValue(i, gridCol订单需求量);
                        }

                        dr["计划日期"] = dtmPlan1.DateTime.ToString("yyyy-MM-dd");
                        dr["人员"] = gridView1.GetRowCellValue(i, gridCol人员);
                        dr["未完工数量"] = gridView1.GetRowCellValue(i, gridCol未完工数量);

                        int i出货周 = ReturnObjectToInt(gridView1.GetRowCellValue(i, gridCol出货周));
                        if (i出货周 < 10 && dtmPlan1.DateTime.Month > 10)
                        {
                            dr["备注"] = dtmPlan1.DateTime.AddYears(1).ToString("yy年") + i出货周.ToString() + "/" + gridView1.GetRowCellValue(i, gridCol未完工数量);
                        }
                        else
                        {
                            dr["备注"] = dtmPlan1.DateTime.ToString("yy年") + i出货周.ToString() + "/" + gridView1.GetRowCellValue(i, gridCol未完工数量);
                        }

                        dr["理论工时"] = ReturnObjectToDecimal(ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol单位工时), 10) * d计划数量, 2);
                        dr["设备"] = gridView1.GetRowCellValue(i, gridCol设备);

                        dr["完工数量"] = gridView1.GetRowCellValue(i, gridCol完工数量);
                        //dr["不良品数量"] =  gridView1.GetRowCellValue(i, );
                        //dr["不良类别"] =  gridView1.GetRowCellValue(i, );
                        //dr["是否计算工时"] =  gridView1.GetRowCellValue(i, );
                        //dr["问题数据"] =  gridView1.GetRowCellValue(i, );
                        //dr["最早计划日期"] =  gridView1.GetRowCellValue(i, );
                        //dr["托外结束时间"] =  gridView1.GetRowCellValue(i, );
                        dr["预计理论工时"] = gridView1.GetRowCellValue(i, gridCol单位工时);
                        //dr["子件缺料数量"] =  gridView1.GetRowCellValue(i, );
                        dt.Rows.Add(dr);
                    }
                }

                if (dt == null || dt.Rows.Count < 1)
                {
                    throw new Exception("没有可以导出的数据");
                }

                Frm生产计划导入 frm = new Frm生产计划导入(dt);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show("导入成功");
                }
                #endregion
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
            Frm工时计算 frm = new Frm工时计算(dtmPlan1.DateTime, (DataTable)gridControl1.DataSource);
            frm.ShowDialog();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
          
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            gridCol选择.OptionsColumn.AllowEdit = true;

            SetGridColTxt();

            sSQL = "select count(*) from 生产日计划 where 排产日期 = '" + dtm.DateTime.ToString("yyyy-MM-dd") + "'";
            int iCount = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
            if (iCount > 0)
            {
                lSave.Text = "已保存";
            }
            else
            {
                lSave.Text = "";
            }

            sSQL = "select count(*) from 生产日计划 where isnull(审核人,'') <> '' and 排产日期 = '" + dtm.DateTime.ToString("yyyy-MM-dd") + "'";
            iCount = Convert.ToInt32(clsSQLCommond.ExecGetScalar(sSQL));
            if (iCount > 0)
            {
                lAudit.Text = "已审核";
            }
            else
            {
                lAudit.Text = "";
            }


            #region 当天已经审核,调用已排产审核信息，仅允许查看

            if (lAudit.Text == "已审核")
            {
                //                //使用工序报工扣减完工量，存在历史数据工序报工不全的情况

                sSQL = "exec @u8._GetWorkPlanDay '111111','222222'";
                sSQL = sSQL.Replace("111111", dtm.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));


                dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dtBingGrid;

                if (dtm.DateTime == DateTime.Today && lAudit.Text.Trim() == "")
                {
                    gridView1.OptionsBehavior.Editable = true;
                }
                else
                {
                    gridView1.OptionsBehavior.Editable = false;
                }
            }

            #endregion
            else
            {
                //当天未审核，按照生产计划逐行调用最大日期排产信息，并将未完工数量累加至今天，超额数量扣去,同时加载未排产的新计划
                sSQL = "select max(排产日期) from 生产日计划";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                DateTime dMaxDate = Convert.ToDateTime("1900-1-1");
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().Trim() != "")
                {
                    dMaxDate = Convert.ToDateTime(dt.Rows[0][0]);
                    gridControl1.DataSource = null;
                }
                if (dMaxDate > dtm.DateTime)
                {
                    return;
                }
                sSQL = "select max(排产日期) from 生产日计划 where isnull(审核人,'') <> '' ";
                dt = clsSQLCommond.ExecQuery(sSQL);
                DateTime dMaxDateAudit = Convert.ToDateTime("1900-1-1");
                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString().Trim() != "")
                {
                    dMaxDateAudit = Convert.ToDateTime(dt.Rows[0][0]);
                }
                
                //使用工序报工扣减完工量，存在历史数据工序报工不全的情况
//                sSQL = @"
//declare @dtmStartUse datetime
//set @dtmStartUse = '2016-11-01' 
//
//select sum(QualifiedInQty) as Qty,a.MoCode, b.InvCode,sum(b.Qty) as iQuantity 
//into #a
//from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid 
//group by a.MoCode, b.InvCode
//
//
//select sum(b.iQuantity) as Qty ,a.WorkOrderNO,a.cInvCode, a.workProcedure
//into #b1
//from UFDLImport.dbo.WorkPlan a inner join UFDLImport.dbo.WorkPlanDetail b on a.GUID = b.GUIDHead 
//where  isnull(b.ensureuid,'0') = '0' and a.bRDIn = 0 and a.accid = '222222' and a.accyear = '111111'
//    and a.dtmPlan <= @dtmStartUse
//group by a.WorkOrderNO,a.cInvCode, a.workProcedure
//
//insert into #b1
//select sum(b.iQuantity) as Qty ,a.WorkOrderNO,a.cInvCode, a.workProcedure
//from UFDLImport.dbo.WorkPlan a inner join UFDLImport.dbo.WorkPlanDetail b on a.GUID = b.GUIDHead 
//where  (isnull(b.ensureuid,'0') = '0' or isnull(b.ensureuid,'0') = 'l') and (a.bRDIn = 0 or a.bRDIn = 2) and a.accid = '222222' and a.accyear = '111111'
//    and a.dtmPlan > @dtmStartUse
//group by a.WorkOrderNO,a.cInvCode, a.workProcedure
//
//select SUM(qty) as Qty, a.WorkOrderNO,a.cInvCode, a.workProcedure
//into #b
//from #B1 a
//group by a.WorkOrderNO,a.cInvCode, a.workProcedure
//
//if exists ( select 0 where not object_id('tempdb..#B1') is null ) drop table #B1
//
//declare @b datetime
//select @b = max(dtmDay) from UFDLImport.dbo.WorkPlanDetail where dtmDay < '333333'
//
//select sum(b.iQuantity) as Qty ,a.WorkOrderNO,a.cInvCode, a.workProcedure
//into #d
//from UFDLImport.dbo.WorkPlan a inner join UFDLImport.dbo.WorkPlanDetail b on a.GUID = b.GUIDHead 
//where  (a.bRDIn = 0 or a.bRDIn = 2) and a.accid = '222222' and a.accyear = '111111'  and dtmDay = @b
//        and a.dtmPlan <= @dtmStartUse
//group by a.WorkOrderNO,a.cInvCode, a.workProcedure
//
//insert into #d
//select sum(b.iQuantity) as Qty ,a.WorkOrderNO,a.cInvCode, a.workProcedure
//from UFDLImport.dbo.WorkPlan a inner join UFDLImport.dbo.WorkPlanDetail b on a.GUID = b.GUIDHead 
//where  (a.bRDIn = 0 or a.bRDIn = 2) and a.accid = '222222' and a.accyear = '111111'  and dtmDay = @b
//        and a.dtmPlan > @dtmStartUse
//group by a.WorkOrderNO,a.cInvCode, a.workProcedure
//
//declare @a datetime
//select  @a = max(排产日期) from 生产日计划 where isnull(审核人,'') = ''
//having max(排产日期) > (select max(排产日期) from 生产日计划 where isnull(审核人,'') <> '')
//
//--将已排产未审核的数据先加载，这样每天都可随时排计划
//select 生产计划明细iID,sum(数量) as 数量 ,人员, 物料编码, 制造令, 制造令行号, 设备, 组别, 工序
//into #c
//from dbo.生产日计划 where 排产日期 = @a
//group by 生产计划明细iID ,人员, 物料编码, 制造令, 制造令行号, 设备, 组别, 工序
//
//
//
//declare @aa datetime
//select  @aa = max(排产日期) from 生产日计划 where isnull(审核人,'') <> ''
//
//--将其他之前拍过计划的数据加载
//insert into #c(生产计划明细iID,数量 ,人员, 物料编码, 制造令, 制造令行号, 设备, 组别, 工序)
//select 生产计划明细iID,sum(数量) as 数量 ,人员, 物料编码, 制造令, 制造令行号, 设备, 组别, 工序
//from dbo.生产日计划 
//where 排产日期 = @aa and 生产计划明细iID not in (select 生产计划明细iID from #c)
//group by 生产计划明细iID ,人员, 物料编码, 制造令, 制造令行号, 设备, 组别, 工序 
//
//select 
//     b.iID,f.iQuantity as U8生产订单数量
//	  ,cast(0 as bit) as 选择, a.单据号, a.单据日期, a.排产完工日期, a.产品编码, a.销售订单号, a.销售订单行号, a.帐套号, a.备注, a.创建人, a.创建日期, a.审核人, a.审核日期,a.出货周, 
//      a.时间戳, b.iID, b.表头单据号, b.母件顺序, b.物料编码, b.半成品编码, b.逻辑顺序, b.加工顺序, b.产品名称, b.产品规格, 
//      b.内部流转, b.数量, b.单位工时, b.开工时间, b.开工排序, b.结束时间, b.间隔时间, b.作业人员数量, b.订单数量, b.总工时, b.开工日期, b.结束日期,  
//      b.日计划起, b.下道工序, b.下一班组, b.完工入库, b.制造令数量, b.订单需求量,b.关闭人, b.关闭日期
//      ,b.iID as 生产计划明细iID ,d.dPreDate as 船期,d.dPreMoDate as 预完工日期,d.cDefine36 as 国外要求交期,d.cItemCode as 外销订单,c.cDefine2 as 客户订单 
//      ,cast(null as varchar(50)) as 零件包过滤 
//      ,case when isnull(b.单位工时,0) * isnull(b.作业人员数量,0) <> 0 then cast(10 / ( isnull(b.单位工时,0) * isnull(b.作业人员数量,0)) as decimal(16,0)) else cast(null as decimal(16,0)) end as 日计划量 
//      ,b.制造令数量 as 需求总量 
//      ,cast(null as varchar(50)) as 物料紧急 
//      ,cast(null as datetime) as 完工时间 
//      ,cast(null as datetime) as 委外结束时间 
//      ,cast(b.制造令数量 - case when isnull(a.单据类型,0) <> 0 then case when ISNULL(g.Qty,0) >  ISNULL(f.Qty,0) then  ISNULL(g.Qty,0) else  ISNULL(f.Qty,0) end else  ISNULL(g.Qty,0) end * b.单位工时 as decimal(16,10)) as 未完成工时 
//      ,cast(null as decimal(16,10)) as 预留日工时 
//      ,cast(null as decimal(16,10)) as 总工时 
//      ,cast(null as decimal(16,10)) as 总工时2 
//      ,cast(null as varchar(50)) as 木制品 
//      ,b.制造令数量 - case when isnull(a.单据类型,0) <> 0 then case when ISNULL(g.Qty,0) >  ISNULL(f.Qty,0) then  ISNULL(g.Qty,0) else  ISNULL(f.Qty,0) end else  ISNULL(g.Qty,0) end as 未完工数量 
//      ,case when isnull(a.单据类型,0) <> 0 then case when ISNULL(g.Qty,0) >  ISNULL(f.Qty,0) then  ISNULL(g.Qty,0) else  ISNULL(f.Qty,0) end else  ISNULL(g.Qty,0) end   as 完工数量 
//      ,cast(null as varchar(50)) as 出货周 
//      ,case when isnull(h.人员,'') <> '' then h.人员 else b.人员 end as 人员 
//
//,case when isnull(h.物料编码,'') <> '' then h.物料编码 else b.物料编码 end as 物料编码 
//,case when isnull(h.制造令,'') <> '' then h.制造令 else b.制造令号码 end as 制造令号码 
//,case when isnull(h.制造令行号,'') <> '' then h.制造令行号 else b.制造令行号 end as 制造令行号 
//,case when isnull(h.组别,'') <> '' then h.组别 else b.组别 end as 组别 
//,case when isnull(h.设备,'') <> '' then h.设备 else b.设备 end as 设备 
//,case when isnull(h.工序,'') <> '' then h.工序 else b.工序 end as 工序 
//
//      ,isnull(h.数量,0) as 日计划总量 
//      ,b.制造令数量 - case when isnull(a.单据类型,0) <> 0 then case when ISNULL(g.Qty,0) <  ISNULL(f.Qty,0) then  ISNULL(g.Qty,0) else  ISNULL(f.Qty,0) end else  ISNULL(g.Qty,0) end  as 计划余量 
//      ,cast(null as decimal(16,6)) as 完工总量 
//      ,cast(null as decimal(16,6)) as 调整量 
//      ,cast(null as decimal(16,6)) as 周汇总,1 as 是否新增数据 
//      ,cast(null as decimal(16,6)) as 日期1,cast(null as decimal(16,10)) as 日期工时1,cast(null as decimal(16,6)) as 日期2,cast(null as decimal(16,10)) as 日期工时2,cast(null as decimal(16,6)) as 日期3,cast(null as decimal(16,10)) as 日期工时3,cast(null as decimal(16,6)) as 日期4,cast(null as decimal(16,10)) as 日期工时4,cast(null as decimal(16,6)) as 日期5,cast(null as decimal(16,10)) as 日期工时5,cast(null as decimal(16,6)) as 日期6,cast(null as decimal(16,10)) as 日期工时6,cast(null as decimal(16,6)) as 日期7,cast(null as decimal(16,10)) as 日期工时7,cast(null as decimal(16,6)) as 日期8,cast(null as decimal(16,10)) as 日期工时8,cast(null as decimal(16,6)) as 日期9,cast(null as decimal(16,10)) as 日期工时9,cast(null as decimal(16,6)) as 日期10,cast(null as decimal(16,10)) as 日期工时10,cast(null as decimal(16,6)) as 日期11,cast(null as decimal(16,10)) as 日期工时11,cast(null as decimal(16,6)) as 日期12,cast(null as decimal(16,10)) as 日期工时12,cast(null as decimal(16,6)) as 日期13,cast(null as decimal(16,10)) as 日期工时13,cast(null as decimal(16,6)) as 日期14,cast(null as decimal(16,10)) as 日期工时14,cast(null as decimal(16,6)) as 日期15,cast(null as decimal(16,10)) as 日期工时15,cast(null as decimal(16,6)) as 日期16,cast(null as decimal(16,10)) as 日期工时16,cast(null as decimal(16,6)) as 日期17,cast(null as decimal(16,10)) as 日期工时17,cast(null as decimal(16,6)) as 日期18,cast(null as decimal(16,10)) as 日期工时18,cast(null as decimal(16,6)) as 日期19,cast(null as decimal(16,10)) as 日期工时19,cast(null as decimal(16,6)) as 日期20,cast(null as decimal(16,10)) as 日期工时20,cast(null as decimal(16,6)) as 日期21,cast(null as decimal(16,10)) as 日期工时21,cast(null as decimal(16,6)) as 日期22,cast(null as decimal(16,10)) as 日期工时22,cast(null as decimal(16,6)) as 日期23,cast(null as decimal(16,10)) as 日期工时23,cast(null as decimal(16,6)) as 日期24,cast(null as decimal(16,10)) as 日期工时24,cast(null as decimal(16,6)) as 日期25,cast(null as decimal(16,10)) as 日期工时25,cast(null as decimal(16,6)) as 日期26,cast(null as decimal(16,10)) as 日期工时26,cast(null as decimal(16,6)) as 日期27,cast(null as decimal(16,10)) as 日期工时27,cast(null as decimal(16,6)) as 日期28,cast(null as decimal(16,10)) as 日期工时28,cast(null as decimal(16,6)) as 日期29,cast(null as decimal(16,10)) as 日期工时29,cast(null as decimal(16,6)) as 日期30,cast(null as decimal(16,10)) as 日期工时30
//      ,cast(null as decimal(16,6)) as 日期31,cast(null as decimal(16,10)) as 日期工时31,cast(null as decimal(16,6)) as 日期32,cast(null as decimal(16,10)) as 日期工时32,cast(null as decimal(16,6)) as 日期33,cast(null as decimal(16,10)) as 日期工时33,cast(null as decimal(16,6)) as 日期34,cast(null as decimal(16,10)) as 日期工时34,cast(null as decimal(16,6)) as 日期35,cast(null as decimal(16,10)) as 日期工时35 ,cast(null as decimal(16,6)) as 日期36,cast(null as decimal(16,10)) as 日期工时36,cast(null as decimal(16,6)) as 日期37,cast(null as decimal(16,10)) as 日期工时37,cast(null as decimal(16,6)) as 日期38,cast(null as decimal(16,10)) as 日期工时38,cast(null as decimal(16,6)) as 日期39,cast(null as decimal(16,10)) as 日期工时39,cast(null as decimal(16,6)) as 日期40,cast(null as decimal(16,10)) as 日期工时40,cast(null as decimal(16,6)) as 日期41,cast(null as decimal(16,10)) as 日期工时41,cast(null as decimal(16,6)) as 日期42,cast(null as decimal(16,10)) as 日期工时42,cast(null as decimal(16,6)) as 日期43,cast(null as decimal(16,10)) as 日期工时43,cast(null as decimal(16,6)) as 日期44,cast(null as decimal(16,10)) as 日期工时44,cast(null as decimal(16,6)) as 日期45,cast(null as decimal(16,10)) as 日期工时45,cast(null as decimal(16,6)) as 日期46,cast(null as decimal(16,10)) as 日期工时46,cast(null as decimal(16,6)) as 日期47,cast(null as decimal(16,10)) as 日期工时47,cast(null as decimal(16,6)) as 日期48,cast(null as decimal(16,10)) as 日期工时48,cast(null as decimal(16,6)) as 日期49,cast(null as decimal(16,10)) as 日期工时49,cast(null as decimal(16,6)) as 日期50,cast(null as decimal(16,10)) as 日期工时50,cast(null as decimal(16,6)) as 日期51,cast(null as decimal(16,10)) as 日期工时51,cast(null as decimal(16,6)) as 日期52,cast(null as decimal(16,10)) as 日期工时52,cast(null as decimal(16,6)) as 日期53,cast(null as decimal(16,10)) as 日期工时53,cast(null as decimal(16,6)) as 日期54,cast(null as decimal(16,10)) as 日期工时54,cast(null as decimal(16,6)) as 日期55,cast(null as decimal(16,10)) as 日期工时55,cast(null as decimal(16,6)) as 日期56,cast(null as decimal(16,10)) as 日期工时56,cast(null as decimal(16,6)) as 日期57,cast(null as decimal(16,10)) as 日期工时57,cast(null as decimal(16,6)) as 日期58,cast(null as decimal(16,10)) as 日期工时58,cast(null as decimal(16,6)) as 日期59,cast(null as decimal(16,10)) as 日期工时59,cast(null as decimal(16,6)) as 日期60,cast(null as decimal(16,10)) as 日期工时60
//      ,cast(null as varchar(50)) as 问题说明
//      ,i.Qty as 最近完工,cast(null as varchar(50)) as 平移核查日期
//from 生产计划 a 
//      left join dbo.生产计划明细 b on a.单据号 = b.表头单据号 
//      left join #c h on h.生产计划明细iID = b.iID
//      left join @u8.SO_SOMain c on a.销售订单号 = c.cSOCode  
//      left join @u8.SO_SODetails d on d.ID = c.ID and a.销售订单行号 = d.iRowNo  
//      left join #a f on f.MoCode = b.制造令号码 and b.物料编码 = f.InvCode
//      left join #b g on g.WorkOrderNO = b.制造令号码 and g.cInvCode = b.物料编码 and (g.workProcedure = h.工序 or g.workProcedure = b.工序)
//      left join #d i on i.WorkOrderNO = b.制造令号码 and i.cInvCode = b.物料编码 and (i.workProcedure = h.工序 or i.workProcedure = b.工序 )
//
//where isnull(b.制造令数量,0) > 0 and isnull(a.审核人,'') <> '' and isnull(b.关闭人,'') = '' and b.日计划起 <= '444444'
//               and b.工序 <> '缴库' and b.组别 <> '委外部'
//               and (
//					b.制造令数量 > case when ISNULL(g.Qty,0) >  ISNULL(f.Qty,0) then  ISNULL(g.Qty,0) else  ISNULL(f.Qty,0) end
//				or
//					f.iquantity > case when ISNULL(g.Qty,0) >  ISNULL(f.Qty,0) then  ISNULL(g.Qty,0) else  ISNULL(f.Qty,0) end
//				)
//        and isnull(b.制造令数量,0) - isnull(case when isnull(a.单据类型,0) <> 0 then case when ISNULL(g.Qty,0) <  ISNULL(f.Qty,0) then  ISNULL(g.Qty,0) else  ISNULL(f.Qty,0) end else  ISNULL(g.Qty,0) end,0)  > 0
//
//order by b.iID       
//";

                sSQL = " exec @u8._GetWorkPlanDayNow '333333','444444','222222','111111'";
                sSQL = sSQL.Replace("333333", dtm.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                sSQL = sSQL.Replace("444444", dtmPlan2.DateTime.ToString("yyyy-MM-dd"));

                dtBingGrid = clsSQLCommond.ExecQuery(sSQL);


                for (int i = 1; i <= i排产日期跨度; i++)
                {
                    dtBingGrid.Columns["日期" + i.ToString()].Caption = dtm.DateTime.AddDays(i).ToString("MM月dd日");
                    dtBingGrid.Columns["日期工时" + i.ToString()].Caption = dtm.DateTime.AddDays(i).ToString("MM月dd日工时");
                }

                                    string sSQLOldPlan =@"
select c.* 
 from dbo.生产计划 a inner join dbo.生产计划明细 b on a.单据号 = b.表头单据号 inner join dbo.生产日计划 c on c.生产计划明细iID = b.iID 
 where a.帐套号 = '200' 
    and 排产日期 = '" +dMaxDate + "' " +
 "order by c.iID desc";
                    DataTable dtOldPlanSum1 = clsSQLCommond.ExecQuery(sSQLOldPlan);


                sSQLOldPlan = @"
select c.* 
from dbo.生产计划 a inner join dbo.生产计划明细 b on a.单据号 = b.表头单据号 inner join dbo.生产日计划 c on c.生产计划明细iID = b.iID 
where a.帐套号 = '200'  and 排产日期 = '" + dMaxDateAudit + "' " +
"order by c.iID desc";
DataTable dtOldPlanSum2 = clsSQLCommond.ExecQuery(sSQLOldPlan);

                for (int i = 0; i < dtBingGrid.Rows.Count; i++)
                {
                    //全部完工则不需要计算
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["未完工数量"]) <= 0)
                    {
                        decimal dU8生产订单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["U8生产订单数量"]);
                        decimal d完工数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["完工数量"]);

                        if (dU8生产订单数量 <= d完工数量)
                        {
                            continue;
                        }
                    }
                    decimal d日计划量 = ReturnObjectToDecimal(dtBingGrid.Rows[i]["日计划量"], 0);

                    DataRow[] drOldPlanSum = dtOldPlanSum1.Select("生产计划明细iID = " + dtBingGrid.Rows[i]["生产计划明细iID"]);
                    if (drOldPlanSum.Length == 0)
                    {
                        drOldPlanSum = dtOldPlanSum2.Select("生产计划明细iID = " + dtBingGrid.Rows[i]["生产计划明细iID"]);
                    }

                    decimal d未完工 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["未完工数量"]);
                    //新计划，以前没有排过，按照日计划量进行划分
                    if (drOldPlanSum == null || drOldPlanSum.Length < 1)
                    {
                        int k = 1;
                        if (d日计划量 != 0)
                        {
                            k = Convert.ToInt32(Math.Ceiling(d未完工 / d日计划量));
                        }
                        for (int j = 1; j <= k; j++)
                        {
                            DateTime d日计划起 = Convert.ToDateTime(dtBingGrid.Rows[i]["日计划起"]);
                            TimeSpan ts = d日计划起 - dtm.DateTime;
                            int iDate = ts.Days;
                            if (iDate < 1)
                                iDate = 1;
                            else
                                iDate = iDate + j - 1;
                            if (iDate > i排产日期跨度)
                                continue;

                            if (d日计划量 == 0)
                            {
                                dtBingGrid.Rows[i]["日期" + iDate.ToString()] = d未完工;
                                dtBingGrid.Rows[i]["日期工时" + iDate.ToString()] = d未完工 * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["单位工时"]);
                                d未完工 = 0;
                            }
                            else
                            {
                                if (d未完工 > d日计划量)
                                {
                                    dtBingGrid.Rows[i]["日期" + iDate.ToString()] = d日计划量;
                                    d未完工 = d未完工 - d日计划量;
                                    dtBingGrid.Rows[i]["日期工时" + iDate.ToString()] = d日计划量 * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["单位工时"]);
                                }
                                else
                                {
                                    dtBingGrid.Rows[i]["日期" + iDate.ToString()] = d未完工;
                                    dtBingGrid.Rows[i]["日期工时" + iDate.ToString()] = d未完工 * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["单位工时"]);
                                    d未完工 = 0;
                                }
                            }
                        }
                    }
                    //老计划，将未完工数量累加至第一天，其他日期沿用
                    else
                    {
                        decimal d安排第一天 = 0;

                        for (int j = 0; j < drOldPlanSum.Length; j++)
                        {
                            DateTime dTime = Convert.ToDateTime(drOldPlanSum[j]["计划生产日期"]);
                            if (dTime <= dtm.DateTime.AddDays(1))
                            {
                                if (Convert.ToDateTime(drOldPlanSum[j]["排产日期"]) == Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate))
                                {
                                    //当天已排产的计划直接调用当天数据
                                    d安排第一天 = ReturnObjectToDecimal(drOldPlanSum[j]["数量"], 6);
                                }
                                else
                                {
                                    //有历史排产计划的用未完工数量 - 之后日期的排产数量(存在生产跨度超出60天的数据会将60天后未排产的数据加到第一天的问题)
                                    decimal d其他日期排产 = 0;
                                    for (int k = 0; k < drOldPlanSum.Length; k++)
                                    {
                                        if (Convert.ToDateTime(drOldPlanSum[k]["计划生产日期"]) > dtmPlan1.DateTime)
                                        {
                                            d其他日期排产 = d其他日期排产 + ReturnObjectToDecimal(drOldPlanSum[k]["数量"], 6);
                                        }
                                    }

                                    d安排第一天 = d未完工 - d其他日期排产;
                                }
                            }

                            if (dTime > dtm.DateTime.AddDays(1) && dTime < dtm.DateTime.AddDays(i排产日期跨度))
                            {
                                int iCol = 0;
                                for (int k = 0; k < dtBingGrid.Columns.Count; k++)
                                {
                                    if (dtBingGrid.Columns[k].Caption == dTime.ToString("MM月dd日"))
                                    {
                                        iCol = k;
                                        break;
                                    }
                                }
                                dtBingGrid.Rows[i][iCol] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(drOldPlanSum[j]["数量"]);
                                for (int k = 0; k < dtBingGrid.Columns.Count; k++)
                                {
                                    if (dtBingGrid.Columns[k].Caption == dTime.ToString("MM月dd日工时"))
                                    {
                                        iCol = k;
                                        break;
                                    }
                                }
                                dtBingGrid.Rows[i][iCol] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(drOldPlanSum[j]["数量"]) * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["单位工时"]);

                                //if (d安排第一天 > 0)
                                //{
                                //    d安排第一天 = d安排第一天 - FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(drOldPlanSum[j]["数量"]);
                                //}
                            }
                        }

                        if (d安排第一天 > 0)
                        {
                            dtBingGrid.Rows[i]["日期1"] = d安排第一天;
                            dtBingGrid.Rows[i]["日期工时1"] = d安排第一天 * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["单位工时"]);
                        }
                    }

                    decimal d日计划总量 = 0;
                    decimal d总工时2 = 0;

                    for (int j = 1; j <= i排产日期跨度; j++)
                    {
                        d日计划总量 = d日计划总量 + FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["日期" + j.ToString()]);
                        d总工时2 = d总工时2 + FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["日期工时" + j.ToString()]);
                    }
                    dtBingGrid.Rows[i]["日计划总量"] = decimal.Round(d日计划总量, 0);
                    dtBingGrid.Rows[i]["总工时2"] = d总工时2;

                    if (dtBingGrid.Rows[i]["日计划起"].ToString().Trim() != "" && dtBingGrid.Rows[i]["结束日期"].ToString().Trim() != "" && dtBingGrid.Rows[i]["开工日期"].ToString().Trim() != "")
                    {
                        dtBingGrid.Rows[i]["完工时间"] = Convert.ToDateTime(dtBingGrid.Rows[i]["日计划起"]).AddDays(Convert.ToDouble(dtBingGrid.Rows[i]["结束日期"]) - Convert.ToDouble(dtBingGrid.Rows[i]["开工日期"]));
                    }
                    if (dtBingGrid.Rows[i]["单位工时"].ToString().Trim() != "" && dtBingGrid.Rows[i]["未完工数量"].ToString().Trim() != "")
                    {
                        dtBingGrid.Rows[i]["未完成工时"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["单位工时"]) * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["未完工数量"]);
                    }

                    DataRow[] dr木制品 = dt木制品.Select(" 物料编码 = '" + dtBingGrid.Rows[i]["产品编码"].ToString().Trim() + "' ");
                    if (dr木制品.Length > 0)
                    {
                        dtBingGrid.Rows[i]["木制品"] = "Y";
                    }

                    if (dtBingGrid.Rows[i]["产品编码"].ToString().Trim().ToLower().IndexOf("fsc") > 0)
                    {
                        dtBingGrid.Rows[i]["FSC"] = "Y";
                    }

                    //if (dtBingGrid.Rows[i]["日计划总量"].ToString().Trim() != "" && dtBingGrid.Rows[i]["订单需求量"].ToString().Trim() != "")
                    //{
                        dtBingGrid.Rows[i]["计划余量"] = decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["制造令数量"]) - FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["日计划总量"]) - FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["完工数量"]), 0);
                    //}
                }
                for (int i = 0; i < dtBingGrid.Rows.Count; i++)
                {
                    decimal d计划余量 = ReturnObjectToDecimal(dtBingGrid.Rows[i]["计划余量"], 6);
                    if (d计划余量 > 0)
                    {
                        decimal d日计划量 = ReturnObjectToDecimal(dtBingGrid.Rows[i]["日计划量"], 6);

                        DateTime d日计划起 = Convert.ToDateTime(dtBingGrid.Rows[i]["日计划起"]);

                        int i排产最后一天 = i排产日期跨度;
                        if (d日计划起 > dtmPlan1.DateTime.AddDays(10))
                        {
                            for (int j = i排产日期跨度; j > 0; j--)
                            {
                                decimal d = ReturnObjectToDecimal(dtBingGrid.Rows[i]["日期" + j.ToString()], 6);

                                decimal d2 = ReturnObjectToDecimal(dtBingGrid.Rows[i]["日期工时" + j.ToString()], 6);

                                if (d > 0 || d2 > 0)
                                {
                                    i排产最后一天 = j;
                                    break;
                                }
                            }
                        }

                        for (int j = i排产最后一天 + 1; j <= i排产日期跨度; j++)
                        {
                            if (d计划余量 > d日计划量)
                            {
                                d计划余量 = d计划余量 - d日计划量;
                                dtBingGrid.Rows[i]["日期" + j.ToString()] = d日计划量;
                                dtBingGrid.Rows[i]["日期工时" + j.ToString()] = ReturnObjectToDecimal(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["单位工时"], 10) * d日计划量, 10);
                                dtBingGrid.Rows[i]["计划余量"] = d计划余量;
                            }
                            else
                            {
                                dtBingGrid.Rows[i]["日期" + j.ToString()] = d计划余量;
                                dtBingGrid.Rows[i]["日期工时" + j.ToString()] = ReturnObjectToDecimal(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["单位工时"], 10) * d计划余量, 10);
                                dtBingGrid.Rows[i]["计划余量"] = 0;
                                break;
                            }
                        }
                    }
                }

                for (int i = dtBingGrid.Rows.Count - 1; i >= 0; i--)
                {
                    decimal d1 = ReturnObjectToDecimal(dtBingGrid.Rows[i]["制造令数量"], 6);
                    decimal d2 = ReturnObjectToDecimal(dtBingGrid.Rows[i]["完工数量"], 6);

                    decimal dU8生产订单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBingGrid.Rows[i]["U8生产订单数量"]);

                    if (d1 <= d2 && dU8生产订单数量 <= d2)
                    {
                        dtBingGrid.Rows.RemoveAt(i);
                    }
                }

                gridControl1.DataSource = dtBingGrid;
                gridView1.OptionsBehavior.Editable = true;
            }
         
            Chk半成品产品顺序();
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (!bNewCode())
            {
                MessageBox.Show("历史计划，不能删除");
                return;
            }

            if (dtm.DateTime < DateTime.Today)
            {
                MessageBox.Show("历史计划，不能删除");
                return;
            }

            if (lAudit.Text.Trim() == "已审核")
            {
                MessageBox.Show("已审核不能删除");
                return;
            }
            sSQL = "delete 生产日计划 where 排产日期 = '" + dtm.DateTime.ToString("yyyy-MM-dd") + "'";
            int iCou = clsSQLCommond.ExecSql(sSQL);
            MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");

            lAudit.Text = "";
            lSave.Text = "";
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
        }

       
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            if (!bNewCode())
            {
                MessageBox.Show("历史计划，不能修改");
                return;
            }

            if (dtm.DateTime < DateTime.Today)
            {
                MessageBox.Show("历史计划，不能修改");
                return;
            }

            if (lAudit.Text.Trim() == "已审核")
            {
                MessageBox.Show("已审核不能修改");
                return;
            }

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            sSQL = "select * from dbo.生产日计划 where 1 = -1";
            DataTable dtDetail = clsSQLCommond.ExecQuery(sSQL);

            aList = new System.Collections.ArrayList();

            bool b全选 = true;
            
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (!Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    b全选 = false;
                    continue;
                }
                for (int j = 0; j < gridView1.Columns.Count; j++)
                {
                    for (int k = 0; k < i排产日期跨度; k++)
                    {
                        if (gridView1.Columns[j].Caption.Trim() == dtmPlan1.DateTime.AddDays(k).ToString("MM月dd日"))
                        {
                            if (gridView1.GetRowCellValue(i, gridView1.Columns[j]).ToString() != "")
                            {
                                decimal d数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[j]), 6);
                                if (d数量 < 0)
                                    continue;

                                DataRow drDetail = dtDetail.NewRow();
                                drDetail["生产计划明细iID"] = gridView1.GetRowCellDisplayText(i, gridCol生产计划明细iID);
                                drDetail["排产日期"] = dtm.DateTime.ToString("yyyy-MM-dd");
                                drDetail["计划生产日期"] = dtmPlan1.DateTime.AddDays(k).ToString("yyyy-MM-dd");
                                drDetail["数量"] = d数量;
                                drDetail["人员"] = gridView1.GetRowCellValue(i, gridCol人员);

                                drDetail["物料编码"] = gridView1.GetRowCellValue(i, gridCol物料编码);
                                drDetail["制造令"] = gridView1.GetRowCellValue(i, gridCol制造令号码);
                                //drDetail["制造令行号"] = gridView1.GetRowCellValue(i, gridCol制造令 );
                                drDetail["设备"] = gridView1.GetRowCellValue(i, gridCol设备);
                                drDetail["组别"] = gridView1.GetRowCellValue(i, gridCol组别);
                                drDetail["工序"] = gridView1.GetRowCellValue(i, gridCol工序);

                                dtDetail.Rows.Add(drDetail);

                                aList.Add("delete 生产日计划 where 排产日期 = '" + dtm.DateTime.ToString("yyyy-MM-dd") + "' and 生产计划明细iID = '" + gridView1.GetRowCellDisplayText(i, gridCol生产计划明细iID).ToString().Trim() + "' ");
                            }
                        }
                    }
                }
            }

            if (!b全选)
            {
                if (DialogResult.Yes != MessageBox.Show("含未选中的行，是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
                    return;
            }

            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {
                sSQL = clsGetSQL.GetInsertSQL("生产日计划", dtDetail, i);
                aList.Add(sSQL);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                SetEdit(false);

                lSave.Text = "已保存";

                sState = "save";
            }
            else
            {
                MessageBox.Show("没有选择保存的数据");
            }
        }

        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            DialogResult d = MessageBox.Show("确定审核生产计划么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d == DialogResult.No)
            {
                return;
            }

            if (lSave.Text != "已保存")
            {
                MessageBox.Show("计划尚未保存，不能审核");
                return;
            }

            if (!bNewCode())
            {
                MessageBox.Show("历史计划，不能审核");
                return;
            }

            if (dtm.DateTime < DateTime.Today)
            {
                MessageBox.Show("历史计划，不能审核");
                return;
            }
            if (lAudit.Text.Trim() == "已审核")
            {
                return;
            }
            sSQL = "update 生产日计划 set 审核人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',审核日期 = getdate() where 排产日期 = '" + dtm.DateTime.ToString("yyyy-MM-dd") + "'";
            int iCou = clsSQLCommond.ExecSql(sSQL);
            MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");

            lAudit.Text = "已审核";
            gridView1.OptionsBehavior.Editable = false;
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            //判断是否已经导入日计划，导入的不能弃审
            sSQL = "select count(*) from UFDLImport.dbo.WorkPlan where dtmPlan = '" + dtm.DateTime.ToString("yyyy-MM-dd") + "' ";
            int iCount =Convert.ToInt32( clsSQLCommond.ExecGetScalar(sSQL));
            if (iCount > 0)
            {
                throw new Exception("已经导入生产计划，不能弃审");
            }

            if (!bNewCode())
            {
                MessageBox.Show("历史计划，不能弃审");
                return;
            }

            if (dtm.DateTime < DateTime.Today)
            {
                MessageBox.Show("历史计划，不能弃审");
                return;
            }
            if (lAudit.Text.Trim() == "")
            {
                return;
            }
            sSQL = "update 生产日计划 set 审核人 = null,审核日期 = null where 排产日期 = '" + dtm.DateTime.ToString("yyyy-MM-dd") + "'";
            int iCou = clsSQLCommond.ExecSql(sSQL);
            MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");

            lAudit.Text = "";

            if (dtm.DateTime == DateTime.Today && lAudit.Text.Trim() == "")
            {
                gridView1.OptionsBehavior.Editable = true;
            }
            else
            {
                gridView1.OptionsBehavior.Editable = false;
            }
        }
      

        #endregion

        int i排产日期跨度 = 60;
        private void FrmWorkPlanDay_Load(object sender, EventArgs e)
        {
            try
            {
                btn全消.Text = "全选";

                lAudit.Text = "";
                dtm.Enabled = true;
                dtmPlan1.Enabled = false;
                dtmPlan2.Enabled = false;

                GetLookUp();

                sSQL = "select max(a.排产日期) from dbo.生产日计划 a inner join  dbo.生产计划明细 b on a.生产计划明细iID = b.iID " +
                        "where b.帐套号 = '200' ";
                DateTime d = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
                if (d < Convert.ToDateTime("2013-1-1"))
                    return;
                else
                    dtm.DateTime = d;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetGridColTxt()
        {
            for (int i = 0; i < i排产日期跨度; i++)
            {
                for (int j = 0; j < gridView1.Columns.Count; j++)
                {
                    if (gridView1.Columns[j].FieldName == "日期" + (i + 1).ToString())
                    {
                        gridView1.Columns[j].Caption = dtmPlan1.DateTime.AddDays(i).ToString("MM月dd日");
                        continue;
                    }
                    if (gridView1.Columns[j].FieldName == "日期工时" + (i + 1).ToString())
                    {
                        gridView1.Columns[j].Caption = dtmPlan1.DateTime.AddDays(i).ToString("MM月dd日") + "工时";
                        continue;
                    }
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gridCol物料编码)
            {
                gridView1.SetRowCellValue(e.RowHandle, gridCol产品规格, gridView1.GetRowCellValue(e.RowHandle, gridCol物料编码));
                gridView1.SetRowCellValue(e.RowHandle, gridCol产品名称, gridView1.GetRowCellValue(e.RowHandle, gridCol物料编码));
            }
            if (e.Column.FieldName.Trim().Length > 2 && e.Column.FieldName.Trim().Length < 5 && e.Column.FieldName.Substring(0, 2) == "日期")
            {
                if(gridView1.GetRowCellValue(e.RowHandle, gridCol制造令数量).ToString().Trim() == "")
                {
                    return;
                }
                decimal dQty = 0;
                decimal dQty2 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol制造令数量),6);
                decimal dHours = 0;
                for (int i = gridView1.Columns.Count-1; i>=0; i--)
                {
                    if (gridView1.Columns[i].FieldName.Trim().Length > 2 && gridView1.Columns[i].FieldName.Trim().Length < 5 && gridView1.Columns[i].FieldName.Substring(0, 2) == "日期")
                    {
                        dQty = dQty + ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns[i]),6);
                        for (int j = 0; j < gridView1.Columns.Count; j++)
                        {
                            if (gridView1.Columns[j].FieldName.Trim().Length > 4 && gridView1.Columns[j].FieldName.Substring(0, 4) == "日期工时" && gridView1.Columns[j].FieldName.Substring(4) == gridView1.Columns[i].FieldName.Substring(2))
                            {
                                if (gridView1.GetRowCellValue(e.RowHandle, gridCol单位工时).ToString().Trim() == "")
                                {
                                    continue;
                                }
                                decimal d1 =ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns[i]),6);
                                decimal d2 = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(e.RowHandle, gridCol单位工时), 6);
                                if (d1 * d2 == 0)
                                {
                                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[j], DBNull.Value);
                                }
                                else
                                {
                                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[j], d1 * d2);
                                }
                                dHours = dHours + d1 * d2;
                                break;
                            }
                        }
                    }
                }

                if (dQty == 0)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol日计划总量, DBNull.Value);
                }
                else
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol日计划总量, dQty);
                }

                decimal d完工数量 = ReturnObjectToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol完工数量), 6);

                if (dQty2 - dQty - d完工数量 == 0)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol计划余量, DBNull.Value);

                    string s = gridView1.GetRowCellDisplayText(e.RowHandle,gridCol问题说明).ToString().Trim();
                    if(s == "计划未排完" || s == "超计划")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol问题说明, "");
                    }
                }
                else
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol计划余量, dQty2 - dQty);
                    if (dQty2 > dQty)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol问题说明, "计划未排完");
                    }
                    if (dQty2 < dQty)
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridCol问题说明, "超计划");
                    }

                }
                if (dHours == 0)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol总工时2, DBNull.Value);
                }
                else
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridCol总工时2, dHours);
                }
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


        DataTable dt木制品;
        /// <summary>
        /// 获得LookUp
        /// </summary>
        private void GetLookUp()
        {
            string sSQL = "select iID,iText as State from dbo._LookUpDate where iType = '3' and isnull(bClose,1)=1 order by iID";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditState.DataSource = dt;

            sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditInventory.DataSource = dt;
            ItemLookUpEdit产品名称.DataSource = dt;
            ItemLookUpEdit产品规格.DataSource = dt;

            sSQL = "select MachineNO,Machine,负责人 from dbo.Machine where State = 1 order by MachineNO";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit设备.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit班组.DataSource = dt;

            sSQL = "select WorkProcessNO,WorkProcess from dbo.WorkProcess where State = 1 order by WorkProcessNO";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit工序.DataSource = dt;

            sSQL = "select * from dbo.木制品档案 order by 物料编码";
            dt木制品 = clsSQLCommond.ExecQuery(sSQL);
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                int iRow = e.RowHandle;
                if (iRow < 0 || iRow >= gridView1.RowCount)
                    return;
                if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol问题说明).ToString().Trim() != "")
                    e.Appearance.BackColor = Color.Tomato;
            }
            catch { }
        }
        
        private void SetEdit(bool b)
        {
            dtmPlan2.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;
        }

        private void SetTxtGridNull()
        {
            dtBingGrid = null;
            gridControl1.DataSource = dtBingGrid;
        }

        private void dtmPlan1_EditValueChanged(object sender, EventArgs e)
        {
            dtmPlan2.DateTime = dtmPlan1.DateTime.AddDays(i排产日期跨度);
        }

        private void dtm_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtmPlan1.DateTime = dtm.DateTime.AddDays(1);
                dtmPlan2.DateTime = dtmPlan1.DateTime.AddDays(i排产日期跨度 - 1);

                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";

                if (txtDays.Text.Trim() == "")
                {
                    MessageBox.Show("请输入调整天数");
                    return;
                }
                int iDays = int.Parse(txtDays.Text.Trim());

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        int i出货周 = ReturnObjectToInt(gridView1.GetRowCellValue(i, gridCol出货周));
                        int i年 = (ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate)).Year;
                        if (i出货周 < 20 && i年 < DateTime.Now.Year)
                            i年 += 1;

                        sSQL = "select iText from _LookUpDate where iType = 16 and iID = '" + i年.ToString().Trim() + "' + '01'";
                        DateTime d日期 = ReturnObjectToDatetime(clsSQLCommond.ExecGetScalar(sSQL));

                        DateTime d平移核查日期 = d日期.AddDays(7 * (i出货周 - 2));
                        

                        if (iDays > 0)
                        {
                            for (int j = gridView1.Columns.Count - 1; j >= 0; j--)
                            {
                                if (gridView1.Columns[j].FieldName.Trim().Length > 2 && gridView1.Columns[j].FieldName.Trim().Substring(0, 2) == "日期" && (gridView1.Columns[j].FieldName.Trim().Length < 4 || gridView1.Columns[j].FieldName.Substring(0, 4) != "日期工时"))
                                {
                                    if (gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]).ToString().Trim() != "")
                                    {
                                        DateTime d = Convert.ToDateTime(gridView1.Columns[j].Caption);
                                        string s = d.AddDays(iDays).ToString("MM月dd日");
                                        decimal dQty = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[j]));

                                        if (d.AddDays(iDays) > dtm.DateTime.AddDays(i排产日期跨度))
                                        {
                                            //MessageBox.Show("行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期超出范围");
                                            sErr = sErr + "行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期超出范围\n";
                                        }
                                        if (d.AddDays(iDays) < dtm.DateTime)
                                        {
                                            //MessageBox.Show("行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期不能早于排产日期");
                                            sErr = sErr + "行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期不能早于排产日期\n";
                                        }
                                        if (d.AddDays(iDays) > d平移核查日期)
                                        {
                                            //MessageBox.Show("行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期超出出货周");
                                            sErr = sErr + "行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期超出出货周\n";
                                        }

                                        for (int k = gridView1.Columns.Count - 1; k >= 0; k--)
                                        {
                                            if (gridView1.Columns[k].FieldName.Trim().Length > 2 && gridView1.Columns[k].FieldName.Trim().Substring(0, 2) == "日期" && (gridView1.Columns[k].FieldName.Trim().Length < 4 || gridView1.Columns[k].FieldName.Substring(0, 4) != "日期工时"))
                                            {
                                                if (s == gridView1.Columns[k].Caption.Trim())
                                                {
                                                    if (dQty == 0)
                                                        gridView1.SetRowCellValue(i, gridView1.Columns[k], DBNull.Value);
                                                    else
                                                        gridView1.SetRowCellValue(i, gridView1.Columns[k], dQty);

                                                    gridView1.SetRowCellValue(i, gridView1.Columns[j], DBNull.Value);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j < gridView1.Columns.Count; j++)
                            {
                                if (gridView1.Columns[j].FieldName.Trim().Length > 2 && gridView1.Columns[j].FieldName.Trim().Substring(0, 2) == "日期" && (gridView1.Columns[j].FieldName.Trim().Length < 4 || gridView1.Columns[j].FieldName.Substring(0, 4) != "日期工时"))
                                {
                                    if (gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]).ToString().Trim() != "")
                                    {
                                        DateTime d = Convert.ToDateTime(gridView1.Columns[j].Caption);
                                        string s = d.AddDays(iDays).ToString("MM月dd日");
                                        decimal dQty = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns[j]));

                                        if (d.AddDays(iDays) > dtm.DateTime.AddDays(i排产日期跨度))
                                        {
                                            //MessageBox.Show("行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期超出范围");
                                            sErr = sErr + "行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期超出范围\n";
                                        }
                                        if (d.AddDays(iDays) < dtm.DateTime)
                                        {
                                            //MessageBox.Show("行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期不能早于排产日期");
                                            sErr = sErr + "行" + (i + 1).ToString() + " 列 " + d.ToString("MM月dd日") + "平移日期不能早于排产日期\n";
                                        }


                                        for (int k = 0; k < gridView1.Columns.Count; k++)
                                        {
                                            if (gridView1.Columns[k].FieldName.Trim().Length > 2 && gridView1.Columns[k].FieldName.Trim().Substring(0, 2) == "日期" && (gridView1.Columns[k].FieldName.Trim().Length < 4 || gridView1.Columns[k].FieldName.Substring(0, 4) != "日期工时"))
                                            {
                                                if (s == gridView1.Columns[k].Caption.Trim())
                                                {
                                                    if (dQty == 0)
                                                        gridView1.SetRowCellValue(i, gridView1.Columns[k], DBNull.Value);
                                                    else
                                                        gridView1.SetRowCellValue(i, gridView1.Columns[k], dQty);

                                                    gridView1.SetRowCellValue(i, gridView1.Columns[j], DBNull.Value);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (sErr.Trim().Length > 0)
                {
                    MsgBox("提示", sErr);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("平移失败:" + ee.Message);
            }
        }

        private bool bNewCode()
        {
            bool b = true;
            sSQL = "select max(排产日期) from 生产日计划";
            object o = clsSQLCommond.ExecGetScalar(sSQL);
            if (o == null ||o.ToString().Trim() == "")
            {
                b = true;
            }
            else
            {
                DateTime d = Convert.ToDateTime(o);
                if (d > dtm.DateTime)
                {
                    b = false;
                }
                else
                {
                    b = true;
                }
            }
            return b;
        }

        private void Chk半成品产品顺序()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string s物料编码 = gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim();
                string s产品编码 = gridView1.GetRowCellDisplayText(i, gridCol产品编码).ToString().Trim();
                string s外销订单 = gridView1.GetRowCellDisplayText(i, gridCol外销订单).ToString().Trim();

                if (s物料编码 == s产品编码)
                {
                    string s物料编码2 = gridView1.GetRowCellDisplayText(i - 1, gridCol物料编码).ToString().Trim();
                    string s产品编码2 = gridView1.GetRowCellDisplayText(i - 1, gridCol产品编码).ToString().Trim();
                    string s外销订单2 = gridView1.GetRowCellDisplayText(i - 1, gridCol外销订单).ToString().Trim();

                    if (s物料编码2 == s产品编码2)
                        continue;

                    if (s外销订单 != s外销订单2 || s产品编码2 != s产品编码)
                        continue;

                    int i产品最早开工 = 0;
                    for (int j = 1; j <= i排产日期跨度; j++)
                    {
                        decimal d = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridView1.Columns["日期" + j.ToString()]), 2);
                        if (d > 0)
                        {
                            i产品最早开工 = j;
                            break;
                        }
                    }

                    int i半成品最迟完工 = 0;
                    for (int j =i排产日期跨度; j >0; j--)
                    {
                        decimal d = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i-1, gridView1.Columns["日期" + j.ToString()]), 2);
                        if (d > 0)
                        {
                            i半成品最迟完工 = j;
                            break;
                        }
                    }
                    if (i产品最早开工 < i半成品最迟完工)
                    {
                        gridView1.SetRowCellValue(i, gridCol问题说明, "半成品晚于成品");
                    }
                }



                if (gridView1.GetRowCellDisplayText(i, gridCol计划余量).ToString().Trim() == "")
                {
                    gridView1.SetRowCellValue(i, gridCol计划余量, 0);
                }
                if (gridView1.GetRowCellDisplayText(i, gridCol计划余量).ToString().Trim() != string.Empty && Convert.ToDecimal(gridView1.GetRowCellDisplayText(i, gridCol计划余量)) > 0)
                {
                    gridView1.SetRowCellValue(i, gridCol问题说明, "计划未排完");
                }
                if (gridView1.GetRowCellDisplayText(i, gridCol计划余量).ToString().Trim() != string.Empty && Convert.ToDecimal(gridView1.GetRowCellDisplayText(i, gridCol计划余量)) < 0)
                {
                    gridView1.SetRowCellValue(i, gridCol问题说明, "超计划未排产");
                }

                decimal d总工时 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol单位工时), 10) * ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol订单数量), 6);
                gridView1.SetRowCellValue(i, gridCol总工时, d总工时);
            }
        }

        private void btn全消_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn全消.Text.Trim() == "全消")
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, false);
                    }
                    btn全消.Text = "全选";
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, true);
                    }
                    btn全消.Text = "全消";
                }
            }
            catch { }
        }

        private void btn物料核查_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gridControl1.DataSource;

            Frm物料计算 f = new Frm物料计算(dt);
            f.ShowDialog();
        }
    }
}
