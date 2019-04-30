using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;
using FrameBaseFunction;


namespace OM
{
    public partial class Frm委外日计划 : FrameBaseFunction.Frm列表窗体模板
    {
        //TH.BaseClsInfo.ClsDataBase clsSQLCommond = TH.BaseClsInfo.ClsDataBaseFactory.Instance();

        //TH.BaseForm.ClsGetSQL clsGetSQL = new TH.BaseForm.ClsGetSQL();
        bool bGetOrLoad = false;    //点击获得 true，点击 日计划查询 false
        bool bBtnType = false;      //点击获得 false；点击加载 True
        DataTable dtOMPlanDay;
        
 
        //ClsVenInvPrice clsPrice = new ClsVenInvPrice();
        private DataTable dt供应商存货价格 = null;

        //string sFocusCol = "";
        public DataTable dtOM;

        public Frm委外日计划()
        {
            InitializeComponent();

            //layoutControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            //base.layoutControlGroup1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            CreateMergetEditControl();
            CreateMergebEditControl();
            CreateMergedEditControl();
            CreateMerged2EditControl();
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
                        btnClosed();
                        break;
                    case "layout":
                        btnLayout(sBtnText);
                        break;
                    default:
                        break;
                }

                //sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        DataTable dt评审 = new DataTable();

        private void btnAdd()
        {

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
            //if (layoutControl1 == null) return;
            //if (sText == "布局")
            //{
            //    //layoutControl1.ShowCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = true;
            //    base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

            //    gridView1.OptionsMenu.EnableColumnMenu = true;
            //    gridView1.OptionsMenu.EnableFooterMenu = true;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = true;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            //    gridView1.OptionsCustomization.AllowColumnMoving = true;
            //}
            //else
            //{
            //    //layoutControl1.HideCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = false;
            //    gridView1.OptionsMenu.EnableColumnMenu = false;
            //    gridView1.OptionsMenu.EnableFooterMenu = false;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //    gridView1.OptionsCustomization.AllowColumnMoving = false;


            //    if (!Directory.Exists(base.sProPath + "\\layout"))
            //        Directory.CreateDirectory(base.sProPath + "\\layout");

            //    base.toolStripMenuBtn.Items["Layout"].Text = "布局";

            //    DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            //    if (d == DialogResult.Yes)
            //    {
            //        layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
            //        gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
            //    }
            //    else if (d == DialogResult.No)
            //    {
            //        if (File.Exists(sLayoutHeadPath))
            //            File.Delete(sLayoutHeadPath);

            //        if (File.Exists(sLayoutGridPath))
            //            File.Delete(sLayoutGridPath);
            //    }
            //}
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
        /// 获得委外计划
        /// </summary>
        private void btnSel()
        {
            try
            {
                //   获得计划不区分一对一，一对多
                dtOMPlanDay = new DataTable();
                chkAll.Checked = false;

                string sSQL = @"

execute 111111.dbo._GetOMPlanDay '222222','333333','444444','555555' ;

select distinct cast(0 as bit) as 选择, oII.cCode,cast (null as decimal(16,2)) as iSumOutQty,cast (null as decimal(16,2)) as iYuQty,0 as bEdit
    ,case when isnull(o.iID,0)=0 then 0 else 1 end as bCreateDayPlan,d.cDepName,T.*,DateDiff(day,isnull(WorkDate,'2099-12-31'),T.date2) as WorkDateDel
    ,DateDiff(day,isnull(PODate,'2099-12-31'),T.date2)  as PODateDel,DateDiff(day,isnull(OMDate,'2099-12-31'),T.date2)  as OMDateDel,oII.EnSureUser
    ,oII.EnSureDate,oII.EnSureDepment,d.cDepCode,T.ImportDate,isnull(T.RemarkXB,'9999-99') as RemarkXB ,i.iInvAdvance as 托外周期,cast(null as int) as 计划周期 ,cast(null as int) as 托外周期压缩
from @u8.TempOMPlanDay T left join @u8.vendor v on T.cVenCode = v.cVenCode left join @u8.Department d on v.cVenDepart = d.cDepCode 
   left join UFDLImport..OMPlanDay o on T.iID = o.iID and o.cCode like '666666%' 
   left join UFDLImport..OMPlanDay_Info oII on oII.iID = T.iID and oII.cCode = '666666' 
   inner join @u8.Inventory i on i.cInvCode = t.invcode
where 1=1 
order by isnull(T.RemarkXB,'9999-99') , T.iID,T.socode,T.soseq,T.invcode
";

                sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName);
                sSQL = sSQL.Replace("222222", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("333333", dateEdit2.DateTime.ToString("yyyy-MM-dd"));
                sSQL = sSQL.Replace("444444", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                sSQL = sSQL.Replace("555555", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                sSQL = sSQL.Replace("666666", DateTime.Parse(datePlan.Text).ToString("yyMMdd"));

                if (lookUpEditSOCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and T.SoCode = '" + lookUpEditSOCode.Text.Trim() + "'");
                }
                if (lookUpEditiRow1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and T.SoSeq >= '" + lookUpEditiRow1.Text.Trim() + "'");
                }
                if (lookUpEditiRow2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and T.SoSeq <= '" + lookUpEditiRow2.Text.Trim() + "'");
                }
                if (!chkVen.Checked && txtVenCode.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and T.cVenCode = '" + txtVenCode.Text.Trim() + "'");
                }
                if (radioQtyCurr.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(T.CurrQtyI,0) > 0");
                }
                if (radioQtyCanUse.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(T.CanUseQty,0) > 0");
                }

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "invSM";        //母件属性
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "invSZ";        //子件属性
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "QtyInYuI";     //入库余量
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "iType";        //委外计划日期来源标识，1 生成订单；2 委外计划来源委外计划，3 来源导入计划
                dt.Columns.Add(dc);

                //sSQL = "select o.*,i.iInvAdvance from DolleDatabase.dbo.OmPlanProduction o left join @u8.inventory i on i.cInvCode = o.物料编码 where 是否开启 = 'Y' order by 开工日期 desc ";

                sSQL = @"
select b.制造令号码 as 订单号,b.物料编码
	,a.销售订单号,a.销售订单行号,e.子件编码
	,min(c.计划生产日期) as 开工日期,max(c.计划生产日期) as 最晚开工日期
from XWSystemDB_DL.dbo.生产计划 a inner join XWSystemDB_DL.dbo.生产计划明细 b on a.单据号 = b.表头单据号 and a.帐套号 = b.帐套号 and a.帐套号 = '200'
	inner join XWSystemDB_DL.dbo.生产日计划 c on b.iID = c.生产计划明细iID
	inner join @u8.inventory d on d.cInvCode = b.物料编码
	left join (
					select a.MoCode,b.InvCode as 物料编码,c.InvCode as 子件编码
					from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid
						inner join @u8.mom_moallocate c on b.MoDId = c.MoDId
			   )e on e.MoCode = b.制造令号码 and b.物料编码 = e.物料编码
where 排产日期 = (select MAX(排产日期) from XWSystemDB_DL.dbo.生产日计划)
group by b.制造令号码,b.物料编码,a.销售订单号,a.销售订单行号,e.子件编码
";
                sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));

                DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);
                if (dt2.Rows.Count < 1)
                {
                    MessageBox.Show("无有效生产计划数据源，请导入生产计划后再试");
                    return;
                }

                sSQL = "select * from UFDLImport..OMPlan where accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and isnull(bClosed,0) <> 1 ";
                DataTable dt3 = clsSQLCommond.ExecQuery(sSQL);

                DataTable dtVen = null;

                //供应商分管部门
                sSQL = "select distinct v.cVenDepart as cDepCode,d.cDepName,v.cVenCode from @u8.vendor v left join @u8.Department d on v.cVenDepart = d.cDepCode where v.cVenDepart is not null order by v.cVenDepart,d.cDepName ";
                DataTable dtVenDep = clsSQLCommond.ExecQuery(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["QtyInYuI"] = Convert.ToDouble(dt.Rows[i]["QtyInI"]) - Convert.ToDouble(dt.Rows[i]["iSendQTYZ"]);
                    if (dt.Rows[i]["iSupplyType"].ToString().Trim() == "3") //领用
                    {
                        if (dt != null && dt.Rows.Count != 0 && dt.Rows[i]["iSendT"].ToString().Trim() != "")
                        {
                            //本次下单
                            double iSendT = 0;
                            if (dt.Rows[i]["iSendT"].ToString().Trim() != "")
                            {
                                iSendT = Math.Floor(Convert.ToDouble(dt.Rows[i]["iSendT"]));
                            }
                            dt.Rows[i]["QtyNow"] = Convert.ToDouble(dt.Rows[i]["PlanQty"]) - iSendT;
                        }
                        else
                        {
                            //本次下单
                            dt.Rows[i]["QtyNow"] = Convert.ToDouble(dt.Rows[i]["PlanQty"]);
                        }
                    }
                    if (dt.Rows[i]["使用数量"] == null || dt.Rows[i]["使用数量"].ToString().Trim() == "")
                    {
                        continue;
                    }
                    decimal dec1 = decimal.Round(Convert.ToDecimal(dt.Rows[i]["使用数量"]), 6);
                    decimal dec4 = decimal.Round(Convert.ToDecimal(dt.Rows[i]["QtyNow"]), 6);
                    if (dt.Rows[i]["ChangeRate"] != null && dt.Rows[i]["ChangeRate"].ToString().Trim() != "")
                    {
                        decimal d = decimal.Round(Convert.ToDecimal(dt.Rows[i]["ChangeRate"]), 6);
                        dt.Rows[i]["iNumI"] = decimal.Round(dec4 * dec1 / d, 6);
                    }
                    dt.Rows[i]["iQuantityI"] = dec4 * dec1;

                    string sInvSM = "";
                    if (Convert.ToBoolean(dt.Rows[i]["bPurchaseM"]))
                    {
                        sInvSM = sInvSM + "外购 ";
                    }
                    if (Convert.ToBoolean(dt.Rows[i]["bSelfM"]))
                    {
                        sInvSM = sInvSM + "自制 ";
                    }
                    if (Convert.ToBoolean(dt.Rows[i]["bProxyForeignM"]))
                    {
                        sInvSM = sInvSM + "委外 ";
                    }
                    dt.Rows[i]["invSM"] = sInvSM;
                    string sInvSZ = "";
                    if (Convert.ToBoolean(dt.Rows[i]["bPurchase"]))
                    {
                        sInvSZ = sInvSZ + "外购 ";
                    }
                    if (Convert.ToBoolean(dt.Rows[i]["bSelf"]))
                    {
                        sInvSZ = sInvSZ + "自制 ";
                    }
                    if (Convert.ToBoolean(dt.Rows[i]["bProxyForeign"]))
                    {
                        sInvSZ = sInvSZ + "委外 ";
                    }
                    dt.Rows[i]["invSZ"] = sInvSZ;

                    dt.Rows[i]["StartDate2"] = Convert.ToDateTime(datePlan.Text);
                    string sInvCode1 = dt.Rows[i]["InvCode"].ToString().Trim();                     //委外母件
                    string sSoCode = "";                                                            //销售订单号
                    if (dt.Rows[i]["SoCode"] != null && dt.Rows[i]["SoCode"].ToString().Trim() != "")
                    {
                        sSoCode = dt.Rows[i]["SoCode"].ToString().Trim(); ;
                    }
                    string sSoSeq = "";                                                             //销售订单号
                    if (dt.Rows[i]["SoSeq"] != null && dt.Rows[i]["SoSeq"].ToString().Trim() != "")
                    {
                        sSoSeq = dt.Rows[i]["SoSeq"].ToString().Trim(); ;
                    }

                    //供应商及价格
                    if (dt.Rows[i]["cVenCode"] == null || dt.Rows[i]["cVenCode"].ToString().Trim() == "")
                    {
                        dtVen = GetVendPriceInfo(sInvCode1);
                        if (dtVen != null && dtVen.Rows.Count > 0)
                        {
                            dt.Rows[i]["cVenCode"] = dtVen.Rows[0]["cVenCode"].ToString().Trim();
                            dt.Rows[i]["cVenName"] = dtVen.Rows[0]["cVenName"];
                            dt.Rows[i]["iTaxPrice"] = dtVen.Rows[0]["iTaxPrice"];
                            dt.Rows[i]["iTaxRate"] = dtVen.Rows[0]["iTaxRate"];
                        }
                    }

                    if (dt.Rows[i]["iTaxPrice"] == null || dt.Rows[i]["iTaxPrice"].ToString().Trim() == "" || BaseFunction.ReturnDecimal(dt.Rows[i]["iTaxPrice"]) <= 0)
                    {
                        DataTable dtVenPrice = GetVendPriceInfo(sInvCode1, dt.Rows[i]["cVenCode"].ToString().Trim());
                        if (dtVenPrice != null && dtVenPrice.Rows.Count > 0)
                        {
                            dt.Rows[i]["iTaxPrice"] = dtVenPrice.Rows[0]["iTaxPrice"];
                            dt.Rows[i]["iTaxRate"] = dtVenPrice.Rows[0]["iTaxRate"];
                        }
                    }

                    if (dt.Rows[i]["cVenCode"] != null && dt.Rows[i]["cVenCode"].ToString().Trim() != "")
                    {
                        DataRow[] dr = dtVenDep.Select(" cVenCode = '" + dt.Rows[i]["cVenCode"].ToString().Trim() + "'");
                        if (dr.Length > 0)
                        {
                            dt.Rows[i]["cDepCode"] = dr[0]["cDepCode"].ToString().Trim();
                        }
                    }

                    double d1 = Convert.ToDouble(dt.Rows[i]["iInvAdvance"]);                        //委外母件加工周期

                    string sInvCode2 = dt.Rows[i]["cInvCode"].ToString().Trim();                    //委外子件
                    double d2 = Convert.ToDouble(dt.Rows[i]["iInvAdvance2"]);                       //委外子件加工周期

                    #region 待入库日期 = Min(生产待入库日期，委外待入库日期，采购待入库日期，datePlan)
                    DateTime dDayIn = datePlan.DateTime;
                    if (dt.Rows[i]["PODate"] != null && dt.Rows[i]["PODate"].ToString().Trim() != "")   //采购待入库
                    {
                        DateTime dTimeTemp = Convert.ToDateTime(dt.Rows[i]["PODate"]);
                        if (dTimeTemp < dDayIn)
                        {
                            dDayIn = dTimeTemp;
                        }
                    }
                    if (dt.Rows[i]["OMDate"] != null && dt.Rows[i]["OMDate"].ToString().Trim() != "")   //委外待入库
                    {
                        DateTime dTimeTemp = Convert.ToDateTime(dt.Rows[i]["OMDate"]);
                        if (dTimeTemp < dDayIn)
                        {
                            dDayIn = dTimeTemp;
                        }
                    }
                    if (dt.Rows[i]["WorkDate"] != null && dt.Rows[i]["WorkDate"].ToString().Trim() != "")   //委外待入库
                    {
                        DateTime dTimeTemp = Convert.ToDateTime(dt.Rows[i]["WorkDate"]);
                        if (dTimeTemp < dDayIn)
                        {
                            dDayIn = dTimeTemp;
                        }
                    }
                    #endregion

                    #region 1. 生产订单所用子件来源委外订单
                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        string swInvCode1 = dt2.Rows[j]["子件编码"].ToString().Trim();              //生产订单子件
                        string swInvCode2 = dt2.Rows[j]["物料编码"].ToString().Trim();              //生产订单母件
                        string sSoCodeW = dt2.Rows[j]["销售订单号"].ToString().Trim();              //销售订单号
                        string sSoSeqW = dt2.Rows[j]["销售订单行号"].ToString().Trim();             //销售订单行号

                        if (swInvCode1 == sInvCode1 && sSoCodeW == sSoCode && sSoSeq == sSoSeqW)     //生产订单需要委外件作为子件
                        {
                            if (dt2.Rows[j]["开工日期"] != null && dt2.Rows[j]["开工日期"].ToString().Trim() != "")
                            {
                                DateTime dDate1 = Convert.ToDateTime(dt2.Rows[j]["开工日期"]);
                                //double d11 = Convert.ToDouble(dt2.Rows[j]["iInvAdvance"]);                  //生产订单物料加工周期
                                double d11 = 2;

                                DateTime dNeed = dDate1;       //需求日期
                                if (dNeed.AddDays(0 - 3) <= dDayIn)
                                {
                                    dNeed = dDayIn;
                                }
                                else
                                {
                                    dNeed = dNeed.AddDays(0 - 3);
                                }

                                dt.Rows[i]["date2"] = dNeed.ToString("yyyy-MM-dd");                         //需求日期 = 生产订单子件需求日期 = 生产订单开工日期 - 加工周期   

                                DateTime dNOut = dNeed;                                                     //托外结束日期
                                if (dNOut.AddDays(0 - d1) < DateTime.Parse(datePlan.DateTime.ToString("yyyy-MM-dd")))
                                {
                                    dt.Rows[i]["date1"] = DateTime.Parse(datePlan.DateTime.ToString("yyyy-MM-dd"));
                                }
                                else
                                {
                                    dt.Rows[i]["date1"] = dNOut.AddDays(0 - d1).ToString("yyyy-MM-dd");    //托外结束日期 = 需求日期 - 委外加工周期 
                                }
                                if (dt.Rows[i]["iType"].ToString().Trim() == "")
                                {
                                    dt.Rows[i]["iType"] = "生产";
                                }
                            }
                        }
                    }
                    #endregion
                }

                #region  3. 将最终没有日期的数据按照委外大计划日期填写
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dt.Rows[i]["date2"]) == DateTime.Parse("1900-01-01"))
                    {
                        for (int j = 0; j < dt3.Rows.Count; j++)
                        {
                            if (dt3.Rows[j]["iID"].ToString().Trim() == dt.Rows[i]["iID"].ToString().Trim())
                            {
                                dt.Rows[i]["date1"] = dt3.Rows[j]["StartDate"].ToString().Trim();
                                dt.Rows[i]["date2"] = dt3.Rows[j]["DueDate"].ToString().Trim();
                                if (dt.Rows[i]["iType"].ToString().Trim() == "")
                                {
                                    dt.Rows[i]["iType"] = "无";
                                }
                            }
                        }
                    }
                }
                #endregion

                #region 2. 委外所用母件来源委外计划子件 执行两遍避免遗漏
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //2. 委外所用母件来源委外计划子件
                    string sInvCode2 = dt.Rows[i]["cInvCode"].ToString().Trim();                    //委外子件
                    string sSoCode = "";                                                            //销售订单号
                    if (dt.Rows[i]["SoCode"] != null && dt.Rows[i]["SoCode"].ToString().Trim() != "")
                    {
                        sSoCode = dt.Rows[i]["SoCode"].ToString().Trim(); ;
                    }
                    string sSoSeq = "";                                                             //销售订单号
                    if (dt.Rows[i]["SoSeq"] != null && dt.Rows[i]["SoSeq"].ToString().Trim() != "")
                    {
                        sSoSeq = dt.Rows[i]["SoSeq"].ToString().Trim(); ;
                    }
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["date2"].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dt.Rows[j]["date2"] != null && dt.Rows[j]["date2"].ToString().Trim() != "" && Convert.ToDateTime(dt.Rows[j]["date2"]) > DateTime.Parse("2000-01-01") && dt.Rows[j]["iType"].ToString().Trim() != "无")
                        {
                            continue;
                        }
                        string sSoCodeOM = "";                                                   //销售订单号
                        if (dt.Rows[j]["SoCode"] != null && dt.Rows[j]["SoCode"].ToString().Trim() != "")
                        {
                            sSoCodeOM = dt.Rows[j]["SoCode"].ToString().Trim();
                        }
                        string sSoSeqOM = "";                                                   //销售订单行号
                        if (dt.Rows[j]["SoSeq"] != null && dt.Rows[j]["SoSeq"].ToString().Trim() != "")
                        {
                            sSoSeqOM = dt.Rows[j]["SoSeq"].ToString().Trim();
                        }
                        string sInvCodeOM = dt.Rows[j]["InvCode"].ToString().Trim();           //委外计划母件
                        if (sInvCode2 == sInvCodeOM && sSoCodeOM == sSoCode && sSoSeq == sSoSeqOM)
                        {
                            dt.Rows[j]["date2"] = Convert.ToDateTime(dt.Rows[i]["date1"]).AddDays(-1);        //需求日期 = 上一层子件需求日期 = 上一层BOM委外母件托外结束日期
                            double dInvAdvance = 0;
                            if (dt.Rows[j]["iInvAdvance"].ToString().Trim() != "")
                            {
                                dInvAdvance = Convert.ToDouble(dt.Rows[j]["iInvAdvance"]);
                            }
                            dt.Rows[j]["date1"] = Convert.ToDateTime(dt.Rows[j]["date2"]).AddDays(0 - dInvAdvance);        //托外结束日期 = 需求日期 - 加工周期
                            if (dt.Rows[j]["iType"].ToString().Trim() == "" || dt.Rows[j]["iType"].ToString().Trim() == "无")
                            {
                                dt.Rows[j]["iType"] = "委外";
                            }
                        }
                    }
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //2. 委外所用母件来源委外计划子件(再一次，预防因BOM层级展开顺序与dt顺序不一致造成的遗漏)
                    string sInvCode2 = dt.Rows[i]["cInvCode"].ToString().Trim();                    //委外子件
                    string sSoCode = "";                                                            //销售订单号
                    if (dt.Rows[i]["SoCode"] != null && dt.Rows[i]["SoCode"].ToString().Trim() != "")
                    {
                        sSoCode = dt.Rows[i]["SoCode"].ToString().Trim(); ;
                    }
                    string sSoSeq = "";                                                             //销售订单号
                    if (dt.Rows[i]["SoSeq"] != null && dt.Rows[i]["SoSeq"].ToString().Trim() != "")
                    {
                        sSoSeq = dt.Rows[i]["SoSeq"].ToString().Trim(); ;
                    }
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[i]["date2"].ToString().Trim() == "")
                        {
                            continue;
                        }
                        if (dt.Rows[j]["date2"] != null && dt.Rows[j]["date2"].ToString().Trim() != "" && Convert.ToDateTime(dt.Rows[j]["date2"]) >= DateTime.Parse("2000-01-01") && dt.Rows[j]["iType"].ToString().Trim() != "无")
                        {
                            continue;
                        }
                        string sSoCodeOM = "";                                                   //销售订单号
                        if (dt.Rows[j]["SoCode"] != null && dt.Rows[j]["SoCode"].ToString().Trim() != "")
                        {
                            sSoCodeOM = dt.Rows[j]["SoCode"].ToString().Trim();
                        }
                        string sSoSeqOM = "";                                                   //销售订单行号
                        if (dt.Rows[j]["SoSeq"] != null && dt.Rows[j]["SoSeq"].ToString().Trim() != "")
                        {
                            sSoSeqOM = dt.Rows[j]["SoSeq"].ToString().Trim();
                        }
                        string sInvCodeOM = dt.Rows[j]["InvCode"].ToString().Trim();           //委外计划母件
                        if (sInvCode2 == sInvCodeOM && sSoCodeOM == sSoCode && sSoSeq == sSoSeqOM)
                        {
                            dt.Rows[j]["date2"] = Convert.ToDateTime(dt.Rows[i]["date1"]).AddDays(-1);                        //需求日期 = 上一层子件需求日期 = 上一层BOM委外母件托外结束日期
                            double dInvAdvance = 0;
                            if (dt.Rows[j]["iInvAdvance"].ToString().Trim() != "")
                            {
                                dInvAdvance = Convert.ToDouble(dt.Rows[j]["iInvAdvance"]);
                            }
                            dt.Rows[j]["date1"] = Convert.ToDateTime(dt.Rows[j]["date2"]).AddDays(0 - dInvAdvance);        //托外结束日期 = 需求日期 - 加工周期
                            if (dt.Rows[j]["iType"].ToString().Trim() == "" || dt.Rows[j]["iType"].ToString().Trim() == "无")
                            {
                                dt.Rows[j]["iType"] = "委外";
                            }
                        }
                    }

                }
                #endregion
                #region  3. 将最终没有日期的数据按照委外大计划日期填写
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dt.Rows[i]["date2"]) == DateTime.Parse("1900-01-01"))
                    {
                        for (int j = 0; j < dt3.Rows.Count; j++)
                        {
                            if (dt3.Rows[j]["iID"].ToString().Trim() == dt.Rows[i]["iID"].ToString().Trim())
                            {
                                dt.Rows[i]["date1"] = dt3.Rows[j]["StartDate"].ToString().Trim();
                                dt.Rows[i]["date2"] = dt3.Rows[j]["DueDate"].ToString().Trim();
                                if (dt.Rows[i]["iType"].ToString().Trim() == "")
                                {
                                    dt.Rows[i]["iType"] = "无";
                                }
                            }
                        }
                    }
                }
                #endregion
                #region  4 托外结束日期早于计划日期的采用计划日期
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dt.Rows[i]["date1"]) < DateTime.Parse(datePlan.DateTime.ToString("yyyy-MM-dd")))
                    {
                        dt.Rows[i]["date1"] = datePlan.DateTime.ToString("yyyy-MM-dd");
                        dt.Rows[i]["bEdit"] = 1;
                        if (dt.Rows[i]["iType"].ToString().Trim() == "")
                        {
                            dt.Rows[i]["iType"] = "无";
                        }
                    }
                    if (Convert.ToDateTime(dt.Rows[i]["date2"]) < DateTime.Parse(datePlan.DateTime.ToString("yyyy-MM-dd")))
                    {
                        dt.Rows[i]["date2"] = datePlan.DateTime.ToString("yyyy-MM-dd");
                        dt.Rows[i]["bEdit"] = 1;
                        if (dt.Rows[i]["iType"].ToString().Trim() == "")
                        {
                            dt.Rows[i]["iType"] = "无";
                        }
                    }
                }
                #endregion

                #region 已完工订单

                sSQL = "select distinct a.sid as 销售订单号,a.cInvCode as 物料编码,a.PID as 制造令号码,d.InvCode as 子件编码 " +
                        "from DolleDatabase..ShortMaterielPlanFinish a inner join @u8.mom_order b on a.PID = b.MoCode " +
                            "inner join @u8.mom_orderdetail c on a.cInvCode = c.InvCode and b.MOID = c.moid " +
                            "inner join @u8.mom_moallocate d on d.MoDId = c.Modid";
                DataTable dtPClose = clsSQLCommond.ExecQuery(sSQL);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sSoCode = dt.Rows[i]["SoCode"].ToString().Trim().ToLower();
                    string sInvCode = dt.Rows[i]["InvCode"].ToString().Trim().ToLower();

                    for (int j = 0; j < dtPClose.Rows.Count; j++)
                    {
                        string sSoCode2 = dtPClose.Rows[j]["销售订单号"].ToString().Trim().ToLower();
                        string sInvCode2 = dtPClose.Rows[j]["子件编码"].ToString().Trim().ToLower();

                        if (sSoCode == sSoCode2 && sInvCode == sInvCode2)
                        {
                            dt.Rows[i]["iType"] = "已完工";
                            break;
                        }
                    }
                }


                #endregion

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["cVenCode"] = dt.Rows[i]["cVenCode"].ToString().Trim();

                    DateTime D1 = DateTime.Parse("1900-01-01");
                    if (dt.Rows[i]["date1"] != null && dt.Rows[i]["date1"].ToString().Trim() != "")
                    {
                        D1 = Convert.ToDateTime(dt.Rows[i]["date1"]);
                    }
                    DateTime D2 = DateTime.Parse("1900-01-01");
                    if (dt.Rows[i]["date2"] != null && dt.Rows[i]["date2"].ToString().Trim() != "")
                    {
                        D2 = Convert.ToDateTime(dt.Rows[i]["date2"]);
                    }


                    //if (dt.Rows[i]["invcode"].ToString().Trim() == "WW030222020004")
                    //{

                    //}
                    double d1 = 0;
                    if (dt.Rows[i]["iSendT"] != null && dt.Rows[i]["iSendT"].ToString().Trim() != "")
                    {
                        d1 = Convert.ToDouble(dt.Rows[i]["iSendT"]);
                    }
                    for (int j = i + 1; j < dt.Rows.Count; j++)
                    {
                        if (Convert.ToDouble(dt.Rows[i]["iID"]) == Convert.ToDouble(dt.Rows[j]["iID"]))
                        {
                            DateTime D3 = DateTime.Parse("1900-01-01");
                            if (dt.Rows[j]["date1"] != null && dt.Rows[j]["date1"].ToString().Trim() != "")
                            {
                                D3 = Convert.ToDateTime(dt.Rows[j]["date1"]);
                            }
                            DateTime D4 = DateTime.Parse("1900-01-01");
                            if (dt.Rows[j]["date2"] != null && dt.Rows[j]["date2"].ToString().Trim() != "")
                            {
                                D4 = Convert.ToDateTime(dt.Rows[j]["date2"]);
                            }

                            double d11 = 0;
                            if (dt.Rows[j]["iSendT"] != null && dt.Rows[j]["iSendT"].ToString().Trim() != "")
                            {
                                d11 = Convert.ToDouble(dt.Rows[j]["iSendT"]);
                            }
                            if (d1 > d11)
                            {
                                d1 = d11;
                                dt.Rows[i]["iSendT"] = d1;
                            }

                            if (D1 < D3)
                            {
                                D1 = D3;
                                dt.Rows[i]["date1"] = D3;
                            }
                            if (D2 < D4)
                            {
                                D2 = D4;
                                dt.Rows[i]["date2"] = D4;
                            }
                        }
                    }
                    for (int j = i + 1; j < dt.Rows.Count; j++)
                    {
                        if (Convert.ToDouble(dt.Rows[i]["iID"]) == Convert.ToDouble(dt.Rows[j]["iID"]))
                        {
                            dt.Rows[j]["date2"] = D2;
                            dt.Rows[j]["date1"] = D1;
                        }
                    }
                    if (D2 > DateTime.Parse("1901-01-01"))
                    {
                        dt.Rows[i]["date2"] = D2.ToString("yyyy-MM-dd");
                        dt.Rows[i]["date1"] = D1.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        dt.Rows[i]["date2"] = DBNull.Value;
                        dt.Rows[i]["date1"] = DBNull.Value;
                    }

                    if (dt.Rows[i]["date2"] != null && dt.Rows[i]["date2"].ToString().Trim() != "")
                    {
                        if (dt.Rows[i]["WorkDate"] != null && dt.Rows[i]["WorkDate"].ToString().Trim() != "")
                        {
                            System.TimeSpan ts = Convert.ToDateTime(dt.Rows[i]["date2"]) - Convert.ToDateTime(dt.Rows[i]["WorkDate"]);
                            dt.Rows[i]["WorkDateDel"] = ts.Days;
                        }
                        if (dt.Rows[i]["OMDate"] != null && dt.Rows[i]["OMDate"].ToString().Trim() != "")
                        {
                            System.TimeSpan ts = Convert.ToDateTime(dt.Rows[i]["date2"]) - Convert.ToDateTime(dt.Rows[i]["OMDate"]);
                            dt.Rows[i]["OMDateDel"] = ts.Days;
                        }
                        if (dt.Rows[i]["PODate"] != null && dt.Rows[i]["PODate"].ToString().Trim() != "")
                        {
                            System.TimeSpan ts = Convert.ToDateTime(dt.Rows[i]["date2"]) - Convert.ToDateTime(dt.Rows[i]["PODate"]);
                            dt.Rows[i]["PODateDel"] = ts.Days;
                        }
                    }
                    #region 可用数量 = 现存量 + 待入库（日期在托外结束日期之前）

                    double da1 = 0;              //现存量数量
                    double da2 = 0;              //采购待入库数量
                    double da3 = 0;              //委外待入库数量
                    double da4 = 0;              //生产待入库数量
                    double da5 = 0;              //累计可用数量
                    double dd1 = 0;              //现存件数
                    double dd2 = 0;              //采购待入库件数
                    double dd3 = 0;              //委外待入库件数
                    double dd4 = 0;              //生产待入库件数
                    double dd5 = 0;              //累计可用件数
                    DateTime dTime1 = DateTime.Parse("2099-12-31");            //托外结束日期
                    DateTime dTime2 = DateTime.Parse("2099-12-31");            //采购待入库日期
                    DateTime dTime3 = DateTime.Parse("2099-12-31");            //委外待入库日期
                    DateTime dTime4 = DateTime.Parse("2099-12-31");            //生产待入库日期

                    if (dt.Rows[i]["CurrQtyI"] != null && dt.Rows[i]["CurrQtyI"].ToString().Trim() != "")
                    {
                        da1 = Convert.ToDouble(dt.Rows[i]["CurrQtyI"]);
                    }
                    if (dt.Rows[i]["POQtyI"] != null && dt.Rows[i]["POQtyI"].ToString().Trim() != "")
                    {
                        da2 = Convert.ToDouble(dt.Rows[i]["POQtyI"]);
                    }
                    if (dt.Rows[i]["OMQtyI"] != null && dt.Rows[i]["OMQtyI"].ToString().Trim() != "")
                    {
                        da3 = Convert.ToDouble(dt.Rows[i]["OMQtyI"]);
                    }
                    if (dt.Rows[i]["WorkQtyI"] != null && dt.Rows[i]["WorkQtyI"].ToString().Trim() != "")
                    {
                        da4 = Convert.ToDouble(dt.Rows[i]["WorkQtyI"]);
                    }
                    if (dt.Rows[i]["CurrNumI"] != null && dt.Rows[i]["CurrNumI"].ToString().Trim() != "")
                    {
                        dd1 = Convert.ToDouble(dt.Rows[i]["CurrNumI"]);
                    }
                    if (dt.Rows[i]["PONumI"] != null && dt.Rows[i]["PONumI"].ToString().Trim() != "")
                    {
                        dd2 = Convert.ToDouble(dt.Rows[i]["PONumI"]);
                    }
                    if (dt.Rows[i]["OMNumI"] != null && dt.Rows[i]["OMNumI"].ToString().Trim() != "")
                    {
                        dd3 = Convert.ToDouble(dt.Rows[i]["OMNumI"]);
                    }
                    if (dt.Rows[i]["WorkNumI"] != null && dt.Rows[i]["WorkNumI"].ToString().Trim() != "")
                    {
                        dd4 = Convert.ToDouble(dt.Rows[i]["WorkNumI"]);
                    }
                    if (dt.Rows[i]["date1"] != null && dt.Rows[i]["date1"].ToString().Trim() != "")
                    {
                        dTime1 = Convert.ToDateTime(dt.Rows[i]["date1"]);
                    }
                    if (dt.Rows[i]["PODate"] != null && dt.Rows[i]["PODate"].ToString().Trim() != "")
                    {
                        dTime2 = Convert.ToDateTime(dt.Rows[i]["PODate"]);
                    }
                    if (dt.Rows[i]["OMDate"] != null && dt.Rows[i]["OMDate"].ToString().Trim() != "")
                    {
                        dTime3 = Convert.ToDateTime(dt.Rows[i]["OMDate"]);
                    }
                    if (dt.Rows[i]["WorkDate"] != null && dt.Rows[i]["WorkDate"].ToString().Trim() != "")
                    {
                        dTime4 = Convert.ToDateTime(dt.Rows[i]["WorkDate"]);
                    }
                    da5 = da1;
                    dd5 = dd1;
                    if (dTime1 > dTime2)
                    {
                        da5 = da5 + da2;
                        dd5 = dd5 + dd2;
                    }
                    if (dTime1 > dTime3)
                    {
                        da5 = da5 + da3;
                        dd5 = dd5 + dd3;
                    }
                    if (dTime1 > dTime4)
                    {
                        da5 = da5 + da4;
                        dd5 = dd5 + dd4;
                    }
                    dt.Rows[i]["CanUseQty"] = da5;
                    dt.Rows[i]["CanUseNum"] = dd5;
                    #endregion

                    #region 调整显示格式  0不显示
                    if (dt.Rows[i]["PlanQty"] != null && dt.Rows[i]["PlanQty"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["PlanQty"]) != 0) //子件累计发料数量
                    {
                        dt.Rows[i]["PlanQty"] = Convert.ToDouble(dt.Rows[i]["PlanQty"]);
                    }
                    else
                    {
                        dt.Rows[i]["PlanQty"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iSendQTYZ"] != null && dt.Rows[i]["iSendQTYZ"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iSendQTYZ"]) != 0) //子件累计发料数量
                    {
                        dt.Rows[i]["iSendQTYZ"] = Convert.ToDouble(dt.Rows[i]["iSendQTYZ"]);
                    }
                    else
                    {
                        dt.Rows[i]["iSendQTYZ"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iSendNumZ"] != null && dt.Rows[i]["iSendNumZ"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iSendNumZ"]) != 0) //子件累计发料件数
                    {
                        dt.Rows[i]["iSendNumZ"] = Convert.ToDouble(dt.Rows[i]["iSendNumZ"]);
                    }
                    else
                    {
                        dt.Rows[i]["iSendNumZ"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iSendT"] != null && dt.Rows[i]["iSendT"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iSendT"]) != 0)   //母件累计发料套数
                    {
                        dt.Rows[i]["iSendT"] = Math.Floor(Convert.ToDouble(dt.Rows[i]["iSendT"]));
                    }
                    else
                    {
                        dt.Rows[i]["iSendT"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["DidQty"] != null && dt.Rows[i]["DidQty"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["DidQty"]) != 0)   //已生单数量
                    {
                        dt.Rows[i]["DidQty"] = Math.Floor(Convert.ToDouble(dt.Rows[i]["DidQty"]));
                    }
                    else
                    {
                        dt.Rows[i]["DidQty"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iNumI"] != null && dt.Rows[i]["iNumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iNumI"]) != 0)   //子件件数
                    {
                        dt.Rows[i]["iNumI"] = Convert.ToDouble(dt.Rows[i]["iNumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["iNumI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["QtyInYuI"] != null && dt.Rows[i]["QtyInYuI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["QtyInYuI"]) != 0)   //入库余量
                    {
                        dt.Rows[i]["QtyInYuI"] = Convert.ToDouble(dt.Rows[i]["QtyInYuI"]);
                    }
                    else
                    {
                        dt.Rows[i]["QtyInYuI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["QtyInI"] != null && dt.Rows[i]["QtyInI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["QtyInI"]) != 0)   //
                    {
                        dt.Rows[i]["QtyInI"] = Convert.ToDouble(dt.Rows[i]["QtyInI"]);
                    }
                    else
                    {
                        dt.Rows[i]["QtyInI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["QtyNow"] != null && dt.Rows[i]["QtyNow"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["QtyNow"]) != 0)   //
                    {
                        dt.Rows[i]["QtyNow"] = Convert.ToDouble(dt.Rows[i]["QtyNow"]);
                    }
                    else
                    {
                        dt.Rows[i]["QtyNow"] = DBNull.Value;
                    }

                    if (dt.Rows[i]["iTaxPrice"] != null && dt.Rows[i]["iTaxPrice"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iTaxPrice"]) != 0)   //
                    {
                        dt.Rows[i]["iTaxPrice"] = Convert.ToDouble(dt.Rows[i]["iTaxPrice"]);
                    }
                    else
                    {
                        dt.Rows[i]["iTaxPrice"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iTaxRate"] != null && dt.Rows[i]["iTaxRate"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iTaxRate"]) != 0)   //
                    {
                        dt.Rows[i]["iTaxRate"] = Convert.ToDouble(dt.Rows[i]["iTaxRate"]);
                    }
                    else
                    {
                        dt.Rows[i]["iTaxRate"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["使用数量"] != null && dt.Rows[i]["使用数量"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["使用数量"]) != 0)   //
                    {
                        dt.Rows[i]["使用数量"] = Convert.ToDouble(dt.Rows[i]["使用数量"]);
                    }
                    else
                    {
                        dt.Rows[i]["使用数量"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["辅助使用数量"] != null && dt.Rows[i]["辅助使用数量"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["辅助使用数量"]) != 0)   //
                    {
                        dt.Rows[i]["辅助使用数量"] = Convert.ToDouble(dt.Rows[i]["辅助使用数量"]);
                    }
                    else
                    {
                        dt.Rows[i]["辅助使用数量"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["iQuantityI"] != null && dt.Rows[i]["iQuantityI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["iQuantityI"]) != 0)   //
                    {
                        dt.Rows[i]["iQuantityI"] = Convert.ToDouble(dt.Rows[i]["iQuantityI"]);
                    }
                    else
                    {
                        dt.Rows[i]["iQuantityI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["CurrQtyI"] != null && dt.Rows[i]["CurrQtyI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["CurrQtyI"]) != 0)   //
                    {
                        dt.Rows[i]["CurrQtyI"] = Convert.ToDouble(dt.Rows[i]["CurrQtyI"]);
                    }
                    else
                    {
                        dt.Rows[i]["CurrQtyI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["CurrNumI"] != null && dt.Rows[i]["CurrNumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["CurrNumI"]) != 0)   //
                    {
                        dt.Rows[i]["CurrNumI"] = Convert.ToDouble(dt.Rows[i]["CurrNumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["CurrNumI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["POQtyI"] != null && dt.Rows[i]["POQtyI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["POQtyI"]) != 0)   //
                    {
                        dt.Rows[i]["POQtyI"] = Convert.ToDouble(dt.Rows[i]["POQtyI"]);
                    }
                    else
                    {
                        dt.Rows[i]["POQtyI"] = DBNull.Value;
                        dt.Rows[i]["PODate"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["PONumI"] != null && dt.Rows[i]["PONumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["PONumI"]) != 0)   //
                    {
                        dt.Rows[i]["PONumI"] = Convert.ToDouble(dt.Rows[i]["PONumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["PONumI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["OMQtyI"] != null && dt.Rows[i]["OMQtyI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["OMQtyI"]) != 0)   //
                    {
                        dt.Rows[i]["OMQtyI"] = Convert.ToDouble(dt.Rows[i]["OMQtyI"]);
                    }
                    else
                    {
                        dt.Rows[i]["OMQtyI"] = DBNull.Value;
                        dt.Rows[i]["OMDate"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["OMNumI"] != null && dt.Rows[i]["OMNumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["OMNumI"]) != 0)   //
                    {
                        dt.Rows[i]["OMNumI"] = Convert.ToDouble(dt.Rows[i]["OMNumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["OMNumI"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["WorkQtyI"] != null && dt.Rows[i]["WorkQtyI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["WorkQtyI"]) != 0)   //
                    {
                        dt.Rows[i]["WorkQtyI"] = Convert.ToDouble(dt.Rows[i]["WorkQtyI"]);
                    }
                    else
                    {
                        dt.Rows[i]["WorkQtyI"] = DBNull.Value;
                        dt.Rows[i]["WorkDate"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["WorkNumI"] != null && dt.Rows[i]["WorkNumI"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["WorkNumI"]) != 0)   //
                    {
                        dt.Rows[i]["WorkNumI"] = Convert.ToDouble(dt.Rows[i]["WorkNumI"]);
                    }
                    else
                    {
                        dt.Rows[i]["WorkNumI"] = DBNull.Value;
                    }

                    if (dt.Rows[i]["CanUseQty"] != null && dt.Rows[i]["CanUseQty"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["CanUseQty"]) != 0)   //
                    {
                        dt.Rows[i]["CanUseQty"] = Convert.ToDouble(dt.Rows[i]["CanUseQty"]);
                    }
                    else
                    {
                        dt.Rows[i]["CanUseQty"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["CanUseNum"] != null && dt.Rows[i]["CanUseNum"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[i]["CanUseNum"]) != 0)   //
                    {
                        dt.Rows[i]["CanUseNum"] = Convert.ToDouble(dt.Rows[i]["CanUseNum"]);
                    }
                    else
                    {
                        dt.Rows[i]["CanUseNum"] = DBNull.Value;
                    }
                    if (dt.Rows[i]["WorkDate2"] != null && dt.Rows[i]["WorkDate2"].ToString().Trim() != "" && Convert.ToDateTime(dt.Rows[i]["WorkDate2"]) != DateTime.Parse("1900-01-01"))   //
                    {
                        dt.Rows[i]["WorkDate2"] = Convert.ToDateTime(dt.Rows[i]["WorkDate2"]);
                    }
                    else
                    {
                        dt.Rows[i]["WorkDate2"] = DBNull.Value;
                    }
                    #endregion

                    DateTime daa1 = Convert.ToDateTime(dt.Rows[i]["Date1"]);
                    DateTime daa2 = Convert.ToDateTime(dt.Rows[i]["Date2"]);

                    TimeSpan tss = daa2 - daa1;
                    int iDay = tss.Days + 1;

                    int i托外周期 = ReturnObjectToInt(dt.Rows[i]["托外周期"]);
                    dt.Rows[i]["计划周期"] = iDay;
                    if (iDay < i托外周期)
                    {
                        dt.Rows[i]["托外周期压缩"] = iDay;
                    }
                }

                DataView dv = dt.DefaultView;
                string sSQL2 = " 1=1 ";

                if (chkDateNeed.Checked)
                {
                    sSQL2 = sSQL2 + " and date2 >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and date2 <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
                }
                else
                {
                    sSQL2 = sSQL2 + " and date2 >= '1900-01-01' and date2 <= '2099-12-31' ";
                }
                if (lookUpEditSOCode.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and SoCode = '" + lookUpEditSOCode.Text.Trim() + "' ";
                }
                if (lookUpEditiRow1.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and SoSeq >= '" + lookUpEditiRow1.Text.Trim() + "' ";
                }
                if (lookUpEditiRow2.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and SoSeq <= '" + lookUpEditiRow2.Text.Trim() + "' ";
                }
                if (!chkVen.Checked && txtVenCode.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and cVenCode = '" + txtVenCode.Text.Trim() + "' ";
                }
                if (lookUpEditVenDep.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and cDepCode = '" + lookUpEditVenDep.EditValue + "' ";
                }
                if (lookUpEditEnSure.Text.Trim() == "生管")
                {
                    sSQL2 = sSQL2 + " and (WorkDateDel < iInvAdvance and WorkDateDel > 0 or EnSureDepment = '生管') ";
                }
                if (lookUpEditEnSure.Text.Trim() == "采购")
                {
                    sSQL2 = sSQL2 + " and  (PODateDel < iInvAdvance and WorkDateDel > 0 or EnSureDepment = '采购') ";
                }
                if (lookUpEditEnSure.Text.Trim() == "委外")
                {
                    sSQL2 = sSQL2 + " and (OMDateDel < iInvAdvance and WorkDateDel > 0 or EnSureDepment = '委外') ";
                }
                //if (radio1.Checked)
                //{
                //    sSQL2 = sSQL2 + " and isnull(bCreateDayPlan,0) = 0 ";
                //}
                //if (radio2.Checked)
                //{
                //    sSQL2 = sSQL2 + " and isnull(bCreateDayPlan,0) = 1 ";
                //}

                dv.RowFilter = sSQL2;
                dtOMPlanDay = dv.ToTable();

                gridControl1.DataSource = dtOMPlanDay;

                if (radio1.Checked)
                {
                    radio1_CheckedChanged(null, null);
                }
                if (radio2.Checked)
                {
                    radio2_CheckedChanged(null, null);
                }
                if (radio3.Checked)
                {
                    radio3_CheckedChanged(null, null);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("获得委外计划信息失败！\n    " + ee.Message);
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            string sCode = DateTime.Parse(datePlan.Text).ToString("yyMMdd");


            //获得委外日计划表框架
            string sSQL = "select * from UFDLImport.dbo.OMPlanDay where 1=-1";
            DataTable dtOMPlanDay = clsSQLCommond.ExecQuery(sSQL);
            DataRow drOMPlanDay = null;
            string sMsg = "    ";
            ArrayList aLRow = new ArrayList();

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }


            sSQL = "select GETDATE()";
            DateTime d当前时间 = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (!Convert.ToBoolean( gridView1.GetRowCellValue(i, gridCol选择)))
                    continue;

                if (gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() == "")
                {
                    sMsg = sMsg + "行" + (i + 1) + "未设置供应商\n";
                    continue;
                }

              
                if (gridView1.GetRowCellValue(i, gridColdate2).ToString().Trim() == "")
                {
                    sMsg = sMsg + "行" + (i + 1) + "未设置计划日期\n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridColdate1).ToString().Trim() == "")
                {
                    sMsg = sMsg + "行" + (i + 1) + "未设置托外结束日期\n";
                    continue;
                }
                //if (gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim() == "")
                //{
                //    sMsg = sMsg + "行" + (i + 1) + "未设置单价\n";
                //    continue;
                //}
                if (gridView1.GetRowCellValue(i, gridColEnSureUser).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridColiType).ToString().Trim() == "无")
                {
                    sMsg = sMsg + "行 " + (i + 1) + " 需要确认才能保存 \n";
                    continue;
                }
                if (gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() == "")
                {
                    sMsg = sMsg + "行 " + (i + 1) + " 没有有效BOM，请核查 \n";
                    continue;
                }

                if (ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim(), 6) <= 0)
                {
                    string sInvCode = gridView1.GetRowCellValue(i, gridColInvCode).ToString().Trim();
                    string sVen = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();

                    DataTable dtPrice = GetVendPriceInfo(sInvCode, sVen);
                    if (dtPrice != null && dtPrice.Rows.Count > 0)
                    {
                        gridView1.SetRowCellValue(i, gridColiTaxPrice, dtPrice.Rows[0]["iTaxPrice"]);
                        gridView1.SetRowCellValue(i, gridColiTaxRate, dtPrice.Rows[0]["iTaxRate"]);
                    }

                    if (ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim(), 6) <= 0)
                    {
                        sMsg = sMsg + "行" + (i + 1) + "未设置单价\n";
                        continue;
                    }
                }

                drOMPlanDay = dtOMPlanDay.NewRow();
                drOMPlanDay["cCode"] = sCode;
                drOMPlanDay["iID"] = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                drOMPlanDay["Soid"] = gridView1.GetRowCellValue(i, gridColSoid).ToString().Trim();
                drOMPlanDay["Sodid"] = gridView1.GetRowCellValue(i, gridColSoDid).ToString().Trim();
                drOMPlanDay["SoCode"] = gridView1.GetRowCellValue(i, gridColSoCode).ToString().Trim();
                drOMPlanDay["SoSeq"] = gridView1.GetRowCellValue(i, gridColSoSeq).ToString().Trim();
                drOMPlanDay["PlanCode"] = gridView1.GetRowCellValue(i, gridColPlanCode).ToString().Trim();
                drOMPlanDay["InvCode"] = gridView1.GetRowCellValue(i, gridColInvCode).ToString().Trim();
                drOMPlanDay["InvName"] = gridView1.GetRowCellValue(i, gridColInvName).ToString().Trim();
                drOMPlanDay["InvStd"] = gridView1.GetRowCellValue(i, gridColInvStd).ToString().Trim();
                drOMPlanDay["ComUnitCode"] = gridView1.GetRowCellValue(i, gridColComUnitCode).ToString().Trim();
                drOMPlanDay["ComUnitName"] = gridView1.GetRowCellValue(i, gridColComUnitName).ToString().Trim();
                drOMPlanDay["PlanQty"] = gridView1.GetRowCellValue(i, gridColPlanQty).ToString().Trim();
                drOMPlanDay["QtyNow"] = gridView1.GetRowCellValue(i, gridColQtyNow).ToString().Trim();
                drOMPlanDay["StartDate2"] = gridView1.GetRowCellValue(i, gridColStartDate2).ToString().Trim();
                drOMPlanDay["DueDate2"] = gridView1.GetRowCellValue(i, gridColDueDate2).ToString().Trim();
                drOMPlanDay["cVenCode"] = gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim();
                drOMPlanDay["cVenName"] = gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim() != "")
                    drOMPlanDay["iTaxPrice"] = gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridColiTaxRate).ToString().Trim() != "")
                    drOMPlanDay["iTaxRate"] = gridView1.GetRowCellValue(i, gridColiTaxRate).ToString().Trim();
                drOMPlanDay["Accid"] = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);
                drOMPlanDay["AccYear"] = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4);
                drOMPlanDay["cAssComUnitCode"] = gridView1.GetRowCellValue(i, gridColComUnitCode).ToString().Trim();
                drOMPlanDay["CompScrap"] = gridView1.GetRowCellValue(i, gridColCompScrap).ToString().Trim();
                drOMPlanDay["BaseQtyD"] = gridView1.GetRowCellValue(i, gridColBaseQtyD).ToString().Trim();
                drOMPlanDay["BaseQtyN"] = gridView1.GetRowCellValue(i, gridColBaseQtyN).ToString().Trim();
                drOMPlanDay["bomID"] = gridView1.GetRowCellValue(i, gridColbomID).ToString().Trim();
                drOMPlanDay["cDefWareHouse"] = gridView1.GetRowCellValue(i, gridColcDefWareHouse).ToString().Trim();
                drOMPlanDay["ParentScrap"] = gridView1.GetRowCellValue(i, gridColParentScrap).ToString().Trim();
                drOMPlanDay["cInvCode"] = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                drOMPlanDay["cInvName"] = gridView1.GetRowCellValue(i, gridColcInvName).ToString().Trim();
                drOMPlanDay["cInvStd"] = gridView1.GetRowCellValue(i, gridColcInvStd).ToString().Trim();
                drOMPlanDay["iSupplyType"] = gridView1.GetRowCellValue(i, gridColiSupplyType).ToString().Trim();
                drOMPlanDay["OpComponentid"] = gridView1.GetRowCellValue(i, gridColOpComponentid).ToString().Trim();
                drOMPlanDay["使用数量"] = gridView1.GetRowCellValue(i, gridCol使用数量);
                drOMPlanDay["辅助使用数量"] = gridView1.GetRowCellValue(i, gridCol辅助使用数量);
                if (gridView1.GetRowCellValue(i, gridColChangeRate).ToString().Trim() == "")
                    drOMPlanDay["ChangeRate"] = DBNull.Value;
                else
                    drOMPlanDay["ChangeRate"] = gridView1.GetRowCellValue(i, gridColChangeRate).ToString().Trim();
                //drOMPlanDay["UseQty"] = gridView1.GetRowCellValue(i,       ).ToString().Trim();
                //drOMPlanDay["UseNum"] = gridView1.GetRowCellValue(i,       ).ToString().Trim();
                drOMPlanDay["cComUnitCodeI"] = gridView1.GetRowCellValue(i, gridColcComUnitCodeI).ToString().Trim();
                drOMPlanDay["cAssComUnitCodeI"] = gridView1.GetRowCellValue(i, gridColcAssComUnitCodeI).ToString().Trim();
                drOMPlanDay["unitCode1"] = gridView1.GetRowCellValue(i, gridColunitCode1).ToString().Trim();
                drOMPlanDay["unitCode2"] = gridView1.GetRowCellValue(i, gridColunitCode2).ToString().Trim();
                drOMPlanDay["iQuantityI"] = gridView1.GetRowCellValue(i, gridColiQuantityI).ToString().Trim();
                drOMPlanDay["date1"] = gridView1.GetRowCellValue(i, gridColdate1).ToString().Trim();
                drOMPlanDay["date2"] = gridView1.GetRowCellValue(i, gridColdate2).ToString().Trim();
                drOMPlanDay["invSM"] = gridView1.GetRowCellValue(i, gridColinvSM).ToString().Trim();
                drOMPlanDay["invSZ"] = gridView1.GetRowCellValue(i, gridColinvSZ).ToString().Trim();
                drOMPlanDay["iType"] = gridView1.GetRowCellValue(i, gridColiType);
                drOMPlanDay["ImportDate"] = d当前时间;
                drOMPlanDay["cDepCode"] = gridView1.GetRowCellValue(i, gridColcDepCode);
                if (gridView1.GetRowCellValue(i, gridColiNumI).ToString().Trim() == "")
                {
                    drOMPlanDay["iNumI"] = DBNull.Value;
                }
                else
                {
                    drOMPlanDay["iNumI"] = gridView1.GetRowCellValue(i, gridColiNumI).ToString().Trim();
                }
                drOMPlanDay["bUse"] = "true";

                dtOMPlanDay.Rows.Add(drOMPlanDay);

                aLRow.Add(gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
            }

            if (sMsg.Trim() != "")
            {
                throw new Exception(sMsg.Trim());
            }

            ArrayList aList = new ArrayList();
            if (dtOMPlanDay != null && dtOMPlanDay.Rows.Count > 0)
            {

                for (int i = 0; i < dtOMPlanDay.Rows.Count; i++)
                {
                    //删除已经生单的iid
                    string sSQL2 = "delete UFDLImport..OMPlanDay where cCode like '" + dtOMPlanDay.Rows[i]["cCode"].ToString().Trim() + "%' and iID = " + dtOMPlanDay.Rows[i]["iID"].ToString().Trim();
                    aList.Add(sSQL2);
                }
                for (int i = 0; i < dtOMPlanDay.Rows.Count; i++)
                {
                    //生成委外日计划
                    aList.Add(clsGetSQL.GetInsertSQL("UFDLImport", "OMPlanDay", dtOMPlanDay, i));
                }
            }

            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("生成日计划成功！");
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                for (int i = 0; i < aLRow.Count; i++)
                {
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        if (gridView1.GetRowCellValue(j, gridColiID).ToString().Trim() == aLRow[i].ToString().Trim())
                        {
                            gridView1.SetRowCellValue(j, gridColbCreateDayPlan, 1);
                        }
                    }
                }
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
            }
            else
            {
                throw new Exception("没有选择需要生成日计划的数据");
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            dtOMPlanDay = new DataTable();

            chkAll.Checked = false;

            int iCou = -1;
            if (radio1to1.Checked)
            {
                iCou = 1;
            }
            if (radio1toN.Checked)
            {
                iCou = 2;
            }
            if (radioAll.Checked)
            {
                iCou = 0;
            }
            if (iCou == -1)
                throw new Exception("取数出错");

            string sSQL = "exec @u8._Get委外日计划查询 '200','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'," + iCou + ",'" + datePlan.DateTime.ToString("yyMMdd") + "'";
            sSQL = sSQL + ";select cast(0 as bit) as 选择, * from @u8.TH_OMPlan_1 ";

            sSQL = sSQL + " where 1=1 ";
            if (!chkAllInfo.Checked)
            {
                sSQL = sSQL + " and isnull(iSendT,0) < isnull(PlanQty,0) ";
            }

            if (chkDateNeed.Checked)
            {
                sSQL = sSQL + " and date2 >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and date2 <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            else
            {
                sSQL = sSQL + " and date2 >= '1900-01-01' and date2 <= '2099-12-31' ";
            }
            if (lookUpEditSOCode.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoCode = '" + lookUpEditSOCode.Text.Trim() + "' ";
            }
            if (lookUpEditiRow1.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoSeq >= '" + lookUpEditiRow1.Text.Trim() + "' ";
            }
            if (lookUpEditiRow2.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoSeq <= '" + lookUpEditiRow2.Text.Trim() + "' ";
            }
            if (!chkVen.Checked && txtVenCode.Text.Trim() != "")
            {
                sSQL = sSQL + " and cVenCode = '" + txtVenCode.Text.Trim() + "' ";
            }
            if (lookUpEditVenDep.Text.Trim() != "")
            {
                sSQL = sSQL + " and cDepCode = '" + lookUpEditVenDep.EditValue + "' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "生管")
            {
                sSQL = sSQL + " and EnSureDepment = '生管' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "采购")
            {
                sSQL = sSQL + " and EnSureDepment = '采购' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "委外")
            {
                sSQL = sSQL + " and EnSureDepment = '委外' ";
            }

            sSQL = sSQL + " order by date2,date1,cInvCode,sodid,SoCode,SoSeq,ID ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["RemarkXB"].ToString().Trim() == "")
                {
                    dt.Rows[i]["RemarkXB"] = "无";
                }
            }

            DataView dvTemp = dt.DefaultView;

            if (radio1to1.Checked)
            {
                dvTemp.Sort = " RemarkXB,date2,date1,cInvCode,sodid,SoCode,SoSeq,ID ";
            }
            if (radio1toN.Checked)
            {
                dvTemp.Sort = " RemarkXB,date2,date1,sodid,SoCode,SoSeq,ID ";
            }
            if (radioAll.Checked)
            {

                dvTemp.Sort = " RemarkXB,date2,date1,sodid,SoCode,SoSeq,ID ";
            }

            DataTable dtTemp = dvTemp.ToTable().Copy();
            gridControl1.DataSource = dtTemp;

            GetQty();

            dt = (DataTable)gridControl1.DataSource;

            DataView dv = dt.DefaultView;
            string sRowFilter = " 1=1 ";
            if (!chkCurrQty.Checked)
            {
                string siID = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["iQtyCanOut"].ToString().Trim() == "" || Convert.ToDouble(dt.Rows[i]["iQtyCanOut"]) == 0)
                    {
                        if (siID.Trim() == string.Empty)
                        {
                            siID = "'" + dt.Rows[i]["iID"].ToString().Trim() + "'";
                        }
                        else
                        {
                            siID = siID + ",'" + dt.Rows[i]["iID"].ToString().Trim() + "'";
                        }
                    }
                }
                if (siID != "")
                {
                    sRowFilter = sRowFilter + " and iID not in (" + siID + ") ";
                }
            }
            dv.RowFilter = sRowFilter;
            dtOMPlanDay = dv.ToTable().Copy();
            gridControl1.DataSource = dtOMPlanDay;

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {

            }
            catch { }
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {

            }
            catch { }
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
            //for (int i = gridView1.RowCount - 1; i >= 0; i--)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        gridView1.DeleteRow(i);
            //    }
            //}
            ArrayList aList = new ArrayList();
            string sSQL = "";
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    sSQL = "delete UFDLImport..OMPlanDay where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and AccID = '200' and Accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";
                    aList.Add(sSQL);
                    
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删行成功！");
                btnLoad();
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {

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
            ArrayList aList = new ArrayList();
            string sSQL = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    if (gridView1.GetRowCellValue(i, gridColEnSureUser).ToString().Trim() == "" && gridView1.GetRowCellValue(i, gridColiType).ToString().Trim() == "3")
                    {
                        sErr = sErr + "行 " + (i + 1) + " 计划日期来源导入数据，需要确认才能保存 \n";
                        continue;
                    }

                    string sNumI = gridView1.GetRowCellValue(i, gridColiNumI).ToString().Trim();
                    if (sNumI == "" || sNumI == "0")
                    {
                        sNumI = "null";
                    }

                    decimal dPrice = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim(), 6);
                    if (dPrice <= 0)
                    {
                        sErr = sErr + "行 " + (i + 1) + "  单价不正确\n";
                        continue;
                    }

                    string sPrice = gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim();
                    if (sPrice == "" || sPrice == "0")
                    {
                        sPrice = "null";
                    }
                    string sTaxRate = gridView1.GetRowCellValue(i, gridColiTaxRate).ToString().Trim();
                    if (sTaxRate == "" || sTaxRate == "0")
                    {
                        sTaxRate = "null";
                    }
                    sSQL = "update UFDLImport..OMPlanDay set qtynow = " + gridView1.GetRowCellValue(i, gridColQtyNow).ToString().Trim() + ",date1 = '" + gridView1.GetRowCellValue(i, gridColdate1).ToString().Trim() + "',date2 = '" + gridView1.GetRowCellValue(i, gridColdate2).ToString().Trim() + "'," +
                                "cVenCode = '" + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() + "',cVenName = '" + gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() + "'," +
                                "iTaxPrice = " + sPrice + ",iTaxRate=" + sTaxRate + ",iQuantityI = " + gridView1.GetRowCellValue(i, gridColiQuantityI).ToString().Trim() + ",iNumI = " + sNumI + " " +
                           " where id = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();

                    aList.Add(sSQL);
                }
            }
            if (sErr != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "保存失败";
                fMsgBos.richTextBox1.Text = "保存失败，原因如下：\n" + sErr;
                fMsgBos.ShowDialog();
                return;
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！");
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
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                string sSQL = "select GETDATE()";
                string s当前时间 = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();

                DataTable dtView = ((DataTable)gridControl1.DataSource).Copy();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "一对多物料";
                dc.DefaultValue = 0;
                dtView.Columns.Add(dc);

                for (int i = 0; i < dtView.Rows.Count; i++)
                {
                    int iCou = 0;
                    string siID = dtView.Rows[i]["iID"].ToString().Trim();
                    for (int j = i; j < dtView.Rows.Count; j++)
                    {
                        if (siID == dtView.Rows[j]["iID"].ToString().Trim())
                        {
                            iCou = iCou + 1;
                        }
                    }
                    if (iCou > 1)
                    {
                        for (int j = i; j < dtView.Rows.Count; j++)
                        {
                            if (siID == dtView.Rows[j]["iID"].ToString().Trim())
                            {
                                dtView.Rows[j]["一对多物料"] = 1;
                            }
                        }
                    }
                }

                DataView dv = dtView.DefaultView;
                dv.RowFilter = " 一对多物料 <> '0' and 选择 = true ";
                dv.Sort = " 子件货位,cInvCode asc,RemarkXB";
                DataTable dt = dv.ToTable();
                int iRow = 0;
                decimal d子件数量汇总 = 0;
                if (dt.Rows.Count > 0)
                {
                    RepOMPlanDay rep = new RepOMPlanDay();
                    DataTable dtDetail = rep.dataSet1.Tables["dtDetail"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string siID = dt.Rows[i]["iID"].ToString().Trim();
                        if (Convert.ToBoolean( dt.Rows[i]["选择"].ToString().Trim()))
                        {
                            bool bPrint = false;
                            for (int j = 0; j < i; j++)
                            {
                                if (siID == dt.Rows[j]["iID"].ToString().Trim())
                                {
                                    bPrint = true;
                                    break;
                                }
                            }
                            if (bPrint)
                            {
                                continue;
                            }
                            iRow += 1;
                            DataRow dr = dtDetail.NewRow();
                            dr["Column1"] = dt.Rows[i]["InvCode"];
                            dr["Column2"] = dt.Rows[i]["InvName"];
                            dr["Column3"] = dt.Rows[i]["InvStd"];
                            dr["Column4"] = dt.Rows[i]["comUnitName"];
                            dr["Column5"] = decimal.Round(Convert.ToDecimal(dt.Rows[i]["PlanQty"]), 0);
                            dr["Column11"] = decimal.Round(Convert.ToDecimal(dt.Rows[i]["QtyNow"]), 0);
                            dr["Column6"] = dt.Rows[i]["cVenCode"] + " -- " + dt.Rows[i]["cVenName"];
                            if (dt.Rows[i]["date2"] != null && dt.Rows[i]["date2"].ToString().Trim() != "")
                            {
                                dr["Column7"] = Convert.ToDateTime(dt.Rows[i]["date2"]).ToString("yy-MM-dd");
                            }
                            dr["Column9"] = dt.Rows[i]["id"];
                            dr["Column10"] = dt.Rows[i]["SoCode"] + " -- " + dt.Rows[i]["SoSeq"];
                            dr["Column12"] = iRow;
                            dr["Column13"] = dt.Rows[i]["RemarkXB"];
                            dr["Column17"] = dt.Rows[i]["cInvName"];
                            dr["Column20"] = sUserName;


                            d子件数量汇总 = d子件数量汇总 + Convert.ToDecimal(dr["Column11"]);

                            dtDetail.Rows.Add(dr);
                        }
                    }

                    if (dtDetail.Rows.Count < 1)
                    {
                        MessageBox.Show("请选择需要打印的数据！");
                        return;
                    }
                    #region 登记打印

                    long i栈板1 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板1.Text.Trim());
                    long i栈板2 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板2.Text.Trim());
                    long i栈板3 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板3.Text.Trim());
                    long i栈板4 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板4.Text.Trim());
                    long i栈板5 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板5.Text.Trim());
                    long i栈板6 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板6.Text.Trim());
                    long i栈板7 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板7.Text.Trim());
                    long i栈板8 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板8.Text.Trim());
                    long i栈板9 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板9.Text.Trim());
                    long i栈板10 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板10.Text.Trim());

                    string sGuid = Guid.NewGuid().ToString();
                    sSQL = "insert into UFDLImport..栈板打印登记(GUID, 单据类型,  栈板1, 栈板2, 栈板3, 栈板4, 栈板5, 栈板6, 栈板7, 栈板8, 栈板9, 栈板10,数量)" +
                        "values('" + sGuid + "','委外日计划发料'," + i栈板1 + "," + i栈板2 + "," + i栈板3 + "," + i栈板4 + "," + i栈板5 + "," + i栈板6 + "," + i栈板7 + "," + i栈板8 + "," + i栈板9 + "," + i栈板10 + "," + dtDetail.Rows.Count + ")";
                    clsSQLCommond.ExecSql(sSQL);

                    sSQL = "select * from UFDLImport..栈板打印登记 where GUID = '" + sGuid + "'";
                    DataTable dt栈板打印登记 = clsSQLCommond.ExecQuery(sSQL);
                    string sID栈板打印登记 = "";
                    if (dt栈板打印登记 != null && dt栈板打印登记.Rows.Count > 0)
                        sID栈板打印登记 = dt栈板打印登记.Rows[0]["iID"].ToString().Trim();

                    #endregion

                    DataTable dtHead = rep.dataSet1.Tables["dtHead"];
                    DataRow dRowTe = dtHead.NewRow();
                    dRowTe["Column1"] = "计划日期：" + datePlan.DateTime.ToString("yy-MM-dd");
                    if (txtVenName.Text.Trim() != "" && txtVenCode.Text.Trim() != "")
                    {
                        dRowTe["Column2"] = "供应商：" + txtVenCode.Text.Trim() + " -- " + txtVenName.Text.Trim();
                    }
                    else
                    {
                        dRowTe["Column2"] = "";
                    }


                    dRowTe["Column4"] = d子件数量汇总;
                    dRowTe["Column5"] = s当前时间;
                    dRowTe["Column12"] = sID栈板打印登记;

                    string s栈板 = "";
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板1.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板1.Text + "[  " + txt栈板1.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板2.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板2.Text + "[  " + txt栈板2.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板3.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板3.Text + "[  " + txt栈板3.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板4.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板4.Text + "[  " + txt栈板4.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板5.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板5.Text + "[  " + txt栈板5.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板6.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板6.Text + "[  " + txt栈板6.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板7.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板7.Text + "[  " + txt栈板7.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板8.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板8.Text + "[  " + txt栈板8.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板9.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板9.Text + "[  " + txt栈板9.Text.Trim() + "  ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板10.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板10.Text + "[  " + txt栈板10.Text.Trim() + "  ]  ";
                    }
                    dRowTe["Column11"] = s栈板;
                    dtHead.Rows.Add(dRowTe);

                    rep.ShowPreview();
                    dt = null;
                }
                dv.RowFilter = " 一对多物料 = '0' and 选择 = true ";
                dv.Sort = "子件货位,cInvCode asc ,RemarkXB";
                DataTable dt2 = dv.ToTable();

                iRow = 0;
                d子件数量汇总 = 0;
                if (dt2.Rows.Count > 0)
                {
                    RepOMPlanDay2 rep = new RepOMPlanDay2();
                    DataTable dtDetail = rep.dataSet1.Tables["dtDetail"];
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        string siID = dt2.Rows[i]["iID"].ToString().Trim();
                        string sID = dt2.Rows[i]["ID"].ToString().Trim();
                        if (Convert.ToBoolean( dt2.Rows[i]["选择"].ToString().Trim() ))
                        {
                            bool bPrint = false;
                            for (int j = 0; j < i; j++)
                            {
                                if (siID == dt2.Rows[j]["iID"].ToString().Trim())
                                {
                                    bPrint = true;
                                    break;
                                }
                            }
                            if (bPrint)
                            {
                                continue;
                            }
                            iRow += 1;
                            DataRow dr = dtDetail.NewRow();
                            dr["Column12"] = iRow;
                            dr["Column10"] = dt2.Rows[i]["cInvCode"];
                            dr["Column1"] = dt2.Rows[i]["cInvStd"];
                            if (dt2.Rows[i]["CurrQtyI"] != null && dt2.Rows[i]["CurrQtyI"].ToString().Trim() != "")
                            {
                                dr["Column2"] = decimal.Round(Convert.ToDecimal(dt2.Rows[i]["CurrQtyI"]), 0);
                            }
                            dr["Column3"] = dt2.Rows[i]["SoCode"] + " -- " + dt2.Rows[i]["SoSeq"];
                            dr["Column4"] = dt2.Rows[i]["InvCode"];
                            dr["Column5"] = dt2.Rows[i]["InvName"];
                            if (dt2.Rows[i]["date2"] != null && dt2.Rows[i]["date2"].ToString().Trim() != "")
                            {
                                dr["Column6"] = Convert.ToDateTime(dt2.Rows[i]["date2"]).ToString("yyyy-MM-dd");
                            }
                            if (dt2.Rows[i]["date1"] != null && dt2.Rows[i]["date1"].ToString().Trim() != "")
                            {
                                dr["Column11"] = Convert.ToDateTime(dt2.Rows[i]["date1"]).ToString("yyyy-MM-dd");
                            }
                            //dr["Column7"] = decimal.Round(Convert.ToDecimal(dt2.Rows[i]["QtyNow"]), 0);
                            if (dt2.Rows[i]["CurrQtyI"] != null && dt2.Rows[i]["CurrQtyI"].ToString().Trim() != "" && dt2.Rows[i]["iQtyCanOut"] != null && dt2.Rows[i]["iQtyCanOut"].ToString().Trim() != "")
                            {
                                decimal d本次可托外 = decimal.Round((decimal.Round(Convert.ToDecimal(dt2.Rows[i]["iQtyCanOut"]), 6) / decimal.Round(Convert.ToDecimal(dt2.Rows[i]["使用数量"]), 6)), 0);
                                decimal d本次托外 = decimal.Round(Convert.ToDecimal(dt2.Rows[i]["QtyNow"]), 6);
                                if (d本次可托外 > d本次托外)
                                {
                                    dr["Column7"] = d本次托外;
                                    dr["Column8"] = decimal.Round(d本次托外 * decimal.Round(Convert.ToDecimal(dt2.Rows[i]["使用数量"]), 6), 6);
                                }
                                else
                                {
                                    dr["Column7"] = d本次可托外;
                                    dr["Column8"] = decimal.Round(d本次可托外 * decimal.Round(Convert.ToDecimal(dt2.Rows[i]["使用数量"]), 6), 6);
                                }


                                if (dt2.Rows[i]["ChangeRate"] != null && dt2.Rows[i]["ChangeRate"].ToString().Trim() != "")
                                {
                                    decimal d = decimal.Round(Convert.ToDecimal(dt2.Rows[i]["ChangeRate"]), 6);
                                    dr["Column14"] = decimal.Round(decimal.Round(Convert.ToDecimal(dt2.Rows[i]["iQtyCanOut"]), 6) / d, 6);
                                }
                            }
                            dr["Column13"] = dt2.Rows[i]["cVenCode"] + " -- " + dt2.Rows[i]["cVenName"];
                            if (dt2.Rows[i]["iQtyCanOut"] == null || dt2.Rows[i]["iQtyCanOut"].ToString().Trim() == "")
                            {
                                dr["Column9"] = dt2.Rows[i]["id"] + "-" + 0;
                            }
                            else
                            {
                                dr["Column9"] = dt2.Rows[i]["id"] + "-" + decimal.Round(Convert.ToDecimal(dr["Column8"]), 6);
                            }
                            dr["Column15"] = dt2.Rows[i]["RemarkXB"];
                            dr["Column16"] = dt2.Rows[i]["子件货位"];
                            dr["Column17"] = dt2.Rows[i]["cInvName"];
                            dr["Column20"] = sUserName;


                            d子件数量汇总 = d子件数量汇总 + Convert.ToDecimal(dr["Column7"]);


                            dtDetail.Rows.Add(dr);
                        }
                    }

                    if (dtDetail.Rows.Count < 1)
                    {
                        MessageBox.Show("请选择需要打印的数据！");
                        return;
                    }

                    #region 登记打印

                    long i栈板1 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板1.Text.Trim());
                    long i栈板2 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板2.Text.Trim());
                    long i栈板3 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板3.Text.Trim());
                    long i栈板4 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板4.Text.Trim());
                    long i栈板5 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板5.Text.Trim());
                    long i栈板6 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板6.Text.Trim());
                    long i栈板7 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板7.Text.Trim());
                    long i栈板8 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板8.Text.Trim());
                    long i栈板9 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板9.Text.Trim());
                    long i栈板10 = FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板10.Text.Trim());

                    string sGuid = Guid.NewGuid().ToString();
                    sSQL = "insert into UFDLImport..栈板打印登记(GUID, 单据类型,  栈板1, 栈板2, 栈板3, 栈板4, 栈板5, 栈板6, 栈板7, 栈板8, 栈板9, 栈板10,数量)" +
                        "values('" + sGuid + "','委外日计划发料'," + i栈板1 + "," + i栈板2 + "," + i栈板3 + "," + i栈板4 + "," + i栈板5 + "," + i栈板6 + "," + i栈板7 + "," + i栈板8 + "," + i栈板9 + "," + i栈板10 + "," + dtDetail.Rows.Count + ")";
                    clsSQLCommond.ExecSql(sSQL);

                    sSQL = "select * from UFDLImport..栈板打印登记 where GUID = '" + sGuid + "'";
                    DataTable dt栈板打印登记 = clsSQLCommond.ExecQuery(sSQL);
                    string sID栈板打印登记 = "";
                    if (dt栈板打印登记 != null && dt栈板打印登记.Rows.Count > 0)
                        sID栈板打印登记 = dt栈板打印登记.Rows[0]["iID"].ToString().Trim();

                    #endregion

                    DataTable dtHead = rep.dataSet1.Tables["dtHead"];
                    DataRow dRowTe = dtHead.NewRow();
                    dRowTe["Column1"] = "计划日期：" + datePlan.DateTime.ToString("yyyy-MM-dd");
                    if (txtVenName.Text.Trim() != "" && txtVenCode.Text.Trim() != "")
                    {
                        dRowTe["Column2"] = "供应商：" + txtVenCode.Text.Trim() + " -- " + txtVenName.Text.Trim();
                    }
                    else
                    {
                        dRowTe["Column2"] = "";
                    }
                    dRowTe["Column3"] = dtDetail.Rows.Count;
                    dRowTe["Column4"] = d子件数量汇总;
                    dRowTe["Column5"] = s当前时间;

                    string s栈板 = "";
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板1.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板1.Text + "[  " + txt栈板1.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板1.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板2.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板2.Text + "[  " + txt栈板2.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板2.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板3.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板3.Text + "[  " + txt栈板3.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板3.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板4.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板4.Text + "[  " + txt栈板4.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板4.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板5.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板5.Text + "[  " + txt栈板5.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板5.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板6.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板6.Text + "[  " + txt栈板6.Text.Trim() + " ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板6.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板7.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板7.Text + "[  " + txt栈板7.Text.Trim() + "  ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板7.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板8.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板8.Text + "[  " + txt栈板8.Text.Trim() + "  ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板8.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板9.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板9.Text + "[  " + txt栈板9.Text.Trim() + "  ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板9.Text + "[            ]  ";
                    }
                    if (FrameBaseFunction.ClsBaseDataInfo.ReturnLong(txt栈板10.Text.Trim()) > 0)
                    {
                        s栈板 = s栈板 + label栈板10.Text + "[  " + txt栈板10.Text.Trim() + "  ]  ";
                    }
                    else
                    {
                        s栈板 = s栈板 + label栈板10.Text + "[            ]  ";
                    }
                    dRowTe["Column11"] = s栈板;

                    dRowTe["Column12"] = sID栈板打印登记;

                    dtHead.Rows.Add(dRowTe);

                    rep.ShowPreview();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private new void SetBtnEnable(bool b)
        {
            //for (int i = 0; i < base.toolStrip1.Items.Count; i++)
            //{
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "createdayplan")
            //    {
            //        base.toolStrip1.Items[i].Enabled = b;
            //    }
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "print")
            //    {
            //        base.toolStrip1.Items[i].Enabled = !b;
            //    }
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "delrow")
            //    {
            //        base.toolStrip1.Items[i].Enabled = !b;
            //    }
            //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "save")
            //    {
            //        base.toolStrip1.Items[i].Enabled = !b;
            //    }
            //}
            //btnEnSure.Enabled = b;
            //btnUnEnSure.Enabled = b;
        }

        //protected override void BtnClick(string sBtnName, string sBtnText)
        //{
        //    try
        //    {
        //        switch (sBtnName.ToLower())
        //        {
        //            case "get":
        //                btnGet();
        //                bBtnType = false;
        //                SetBtnEnable(true);
        //                SetColEnable(true);
        //                bGetOrLoad = true;
        //                break;
        //            case "createdayplan":
        //                btnCreateDayPlan();
        //                break;
        //            case "load":
        //                btnLoad();
        //                bBtnType = true;
        //                SetBtnEnable(false);
        //                SetColEnable(true);
        //                bGetOrLoad = false;
        //                break;
        //            case "delrow":
        //                btnDelRow();
        //                break;
        //            case "save":
        //                btnSave();
        //                break;
        //            case "print":
        //                btnPrint();
        //                break;
        //            case "export":
        //                btnExport();
        //                break;
        //            case "close":
        //                btnClosed();
        //                break;
        //            default:
        //                MessageBox.Show("该功能尚未提供，请向管理员咨询！");
        //                break;
        //        }
        //    }
        //    catch (Exception ee)
        //    {
        //        MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnClosed()
        {
            ArrayList aList = new ArrayList();
            string sSQL = "";
            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    string sID = gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                    sSQL = "update UFDLImport..OMPlan set bClosed=1,ClosedUID='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ClosedDate='" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                             " where iID = " + sID;
                    aList.Add(sSQL);
                }
            }

            if (sErr != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "关闭计划失败";
                fMsgBos.richTextBox1.Text = "关闭计划失败，原因如下：\n" + sErr;
                fMsgBos.ShowDialog();
                return;
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭计划成功！");
            }
        }


        /// <summary>
        /// 当前日计划
        /// </summary>
        private void btnLoad()
        {
            dtOMPlanDay = new DataTable();

            chkAll.Checked = false;
  
            int iCou = -1;
            if (radio1to1.Checked)
            {
                iCou = 1;
            }
            if (radio1toN.Checked)
            {
                iCou=2;
            }
            if (radioAll.Checked)
            {
                iCou=0;
            }
            if (iCou == -1)
                throw new Exception("取数出错");

            string sSQL = "exec @u8._Get委外日计划查询 '200','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'," + iCou + ",'" + datePlan.DateTime.ToString("yyMMdd") + "'";
            sSQL = sSQL + ";select cast(0 as bit) as 选择,* from @u8.TH_OMPlan_1 ";

            sSQL = sSQL + " where 1=1 ";
            if (!chkAllInfo.Checked)
            {
                sSQL = sSQL + " and isnull(iSendT,0) < isnull(PlanQty,0) ";
            }

            if (chkDateNeed.Checked)
            {
                sSQL = sSQL + " and date2 >= '" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and date2 <= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
            }
            else
            {
                sSQL = sSQL + " and date2 >= '1900-01-01' and date2 <= '2099-12-31' ";
            }
            if (lookUpEditSOCode.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoCode = '" + lookUpEditSOCode.Text.Trim() + "' ";
            }
            if (lookUpEditiRow1.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoSeq >= '" + lookUpEditiRow1.Text.Trim() + "' ";
            }
            if (lookUpEditiRow2.Text.Trim() != "")
            {
                sSQL = sSQL + " and SoSeq <= '" + lookUpEditiRow2.Text.Trim() + "' ";
            }
            if (!chkVen.Checked && txtVenCode.Text.Trim() != "")
            {
                sSQL = sSQL + " and cVenCode = '" + txtVenCode.Text.Trim() + "' ";
            }
            if (lookUpEditVenDep.Text.Trim() != "")
            {
                sSQL = sSQL + " and cDepCode = '" + lookUpEditVenDep.EditValue + "' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "生管")
            {
                sSQL = sSQL + " and EnSureDepment = '生管' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "采购")
            {
                sSQL = sSQL + " and EnSureDepment = '采购' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "委外")
            {
                sSQL = sSQL + " and EnSureDepment = '委外' ";
            }

            sSQL = sSQL + " order by date2,date1,cInvCode,sodid,SoCode,SoSeq,ID ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["RemarkXB"].ToString().Trim() == "")
                {
                    dt.Rows[i]["RemarkXB"] = "无";
                }
            }

            DataView dvTemp = dt.DefaultView;

            if (radio1to1.Checked)
            {
                dvTemp.Sort = " RemarkXB,date2,date1,cInvCode,sodid,SoCode,SoSeq,ID ";
            }
            if (radio1toN.Checked)
            {
                dvTemp.Sort = " RemarkXB,date2,date1,sodid,SoCode,SoSeq,ID ";
            }
            if (radioAll.Checked)
            {

                dvTemp.Sort = " RemarkXB,date2,date1,sodid,SoCode,SoSeq,ID ";
            }

            gridControl1.DataSource = dvTemp.ToTable().Copy();

            GetQty();

            dt = (DataTable)gridControl1.DataSource;

            DataView dv = dt.DefaultView;
            string sRowFilter = " 1=1 ";
            if (!chkCurrQty.Checked)
            {
                string siID = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["iQtyCanOut"].ToString().Trim() == "" || Convert.ToDouble(dt.Rows[i]["iQtyCanOut"]) == 0)
                    {
                        if (siID.Trim() == string.Empty)
                        {
                            siID = "'" + dt.Rows[i]["iID"].ToString().Trim() + "'";
                        }
                        else
                        {
                            siID = siID + ",'" + dt.Rows[i]["iID"].ToString().Trim() + "'";
                        }
                    }
                }
                if (siID != "")
                {
                    sRowFilter = sRowFilter + " and iID not in (" + siID + ") ";
                }
            }
            dv.RowFilter = sRowFilter;
            dtOMPlanDay = dv.ToTable().Copy();
            gridControl1.DataSource = dtOMPlanDay;
        }



        private void FrmOMPlanDay_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select * from UFDLImport.dbo._Code where vchrType = '1' order by iOrder";
                DataTable dt栈板 = clsSQLCommond.ExecQuery(sSQL);
                if (dt栈板 == null || dt栈板.Rows.Count < 1)
                {
                    throw new Exception("请登记栈板档案");
                }
                for (int i = 0; i < dt栈板.Rows.Count; i++)
                {
                    string svchrInfo = dt栈板.Rows[i]["vchrInfo"].ToString().Trim();
                    if (label栈板1.Name == "label" + svchrInfo)
                    {
                        label栈板1.Visible = true;
                        txt栈板1.Visible = true;
                        label栈板1.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label栈板2.Name == "label" + svchrInfo)
                    {
                        label栈板2.Visible = true;
                        txt栈板2.Visible = true;
                        label栈板2.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label栈板3.Name == "label" + svchrInfo)
                    {
                        label栈板3.Visible = true;
                        txt栈板3.Visible = true;
                        label栈板3.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label栈板4.Name == "label" + svchrInfo)
                    {
                        label栈板4.Visible = true;
                        txt栈板4.Visible = true;
                        label栈板4.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label栈板5.Name == "label" + svchrInfo)
                    {
                        label栈板5.Visible = true;
                        txt栈板5.Visible = true;
                        label栈板5.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label栈板6.Name == "label" + svchrInfo)
                    {
                        label栈板6.Visible = true;
                        txt栈板6.Visible = true;
                        label栈板6.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label栈板7.Name == "label" + svchrInfo)
                    {
                        label栈板7.Visible = true;
                        txt栈板7.Visible = true;
                        label栈板7.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label栈板8.Name == "label" + svchrInfo)
                    {
                        label栈板8.Visible = true;
                        txt栈板8.Visible = true;
                        label栈板8.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label栈板9.Name == "label" + svchrInfo)
                    {
                        label栈板9.Visible = true;
                        txt栈板9.Visible = true;
                        label栈板9.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                    if (label栈板10.Name == "label" + svchrInfo)
                    {
                        label栈板10.Visible = true;
                        txt栈板10.Visible = true;
                        label栈板10.Text = dt栈板.Rows[i]["vchrRemark"].ToString().Trim();
                    }
                }


                GetDepInfo();
                GetlookUpEditEnSure();
 
                GetSoCode();
                dateEdit1.Text =FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dateEdit2.Text = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddDays(3).ToString("yyyy-MM-dd");

                dateNeed.Text =FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dateEnd.Text =FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                datePlan.Text =FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                 
                GetWareHouse();

                btnEnSure.Enabled = true;
                btnUnEnSure.Enabled = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！原因：" + ee.Message);
            }
        }

        private void lookUpEditSOCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select distinct cast(SoSeq as varchar(5)) as iID from UFDLImport..OMPlan where SoCode = '" + lookUpEditSOCode.EditValue.ToString().Trim() + "' ";
                lookUpEditiRow1.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditiRow2.Properties.DataSource = lookUpEditiRow1.Properties.DataSource;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得销售订单号失败！  " + ee.Message);
            }
        }

        private void lookUpEditiRow1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditiRow2.EditValue = lookUpEditiRow1.EditValue;
        }

        private void chkVen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVen.Checked)
            {
                txtVenCode.Text = "";
            }
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCode.Text = fVen.sVenCode;
                txtVenName.Text = fVen.sVenName;
            }
        }

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
            }
        }

        private void txtcInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmInvInfo fInv = new FrmInvInfo(txtcInvCode.Text.Trim());
            if (DialogResult.OK == fInv.ShowDialog())
            {
                txtcInvCode.Text = fInv.sInvCode;
                txtcInvName.Text = fInv.sInvName;
            }
        }

        private void txtcInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetcInvCode(txtcInvCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtcInvName.Text = dt.Rows[0]["iText"].ToString().Trim();
                }
                else
                {
                    txtcInvCode.Text = "";
                    txtcInvName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货信息失败！ " + ee.Message);
            }
        }

        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
            }
        }

        private DataTable GetcInvCode(string scInvCode)
        {
            try
            {
                string sSQL = "select cInvCode as iID,cInvName as iText from @u8.Inventory  where cInvCode = '" + scInvCode + "' order by cInvCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得存货信息失败！");
            }
        }

        /// <summary>
        /// 销售订单号
        /// </summary>
        private void GetSoCode()
        {
            try
            {
                string sSQL = "select distinct SoCode as iID from UFDLImport..OMPlan where SoCode is not null order by SoCode";
                lookUpEditSOCode.Properties.DataSource =clsGetSQL.GetLookUpEdit(sSQL);
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得销售订单号失败！  " + ee.Message);
            }
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if ((this.gridView1.GetDataRow(e.RowHandle1)["iID"].ToString() != this.gridView1.GetDataRow(e.RowHandle2)["iID"].ToString()))
                e.Handled = true;
        }

        DevExpress.XtraEditors.TextEdit tEditor;
        DevExpress.XtraEditors.ButtonEdit bEditor;
        DevExpress.XtraEditors.DateEdit dEditor;
        DevExpress.XtraEditors.DateEdit dEditor2;

        void CreateMergedEditControl()
        {
            dEditor = new DevExpress.XtraEditors.DateEdit();
            dEditor.Location = new System.Drawing.Point(12, 12);
            dEditor.Name = "dateEdit";
            dEditor.Properties.Appearance.Options.UseTextOptions = true;
            dEditor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            dEditor.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            dEditor.Properties.AutoHeight = false;
            dEditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            dEditor.KeyDown += new KeyEventHandler(dEditor_KeyDown);
            dEditor.Leave += new EventHandler(dEditor_Leave);
        }
        void CreateMerged2EditControl()
        {
            dEditor2 = new DevExpress.XtraEditors.DateEdit();
            dEditor2.Location = new System.Drawing.Point(12, 12);
            dEditor2.Name = "dateEdit2";
            dEditor2.Properties.Appearance.Options.UseTextOptions = true;
            dEditor2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            dEditor2.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            dEditor2.Properties.AutoHeight = false;
            dEditor2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            dEditor2.KeyDown += new KeyEventHandler(d2Editor_KeyDown);
            dEditor2.Leave += new EventHandler(dEditor2_Leave);
        }
        //this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
        void CreateMergetEditControl()
        {
            tEditor = new DevExpress.XtraEditors.TextEdit();
            tEditor.Location = new System.Drawing.Point(12, 12);
            tEditor.Name = "txtEdit";
            tEditor.Properties.Appearance.Options.UseTextOptions = true;
            tEditor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            tEditor.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tEditor.Properties.AutoHeight = false;
            tEditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            tEditor.KeyDown += new KeyEventHandler(tEditor_KeyDown);
            tEditor.Leave += new EventHandler(tEditor_Leave);
        }
        void CreateMergebEditControl()
        {
            bEditor = new DevExpress.XtraEditors.ButtonEdit();
            bEditor.Location = new System.Drawing.Point(12, 12);
            bEditor.Name = "buttonEdit";
            bEditor.Properties.Appearance.Options.UseTextOptions = true;
            bEditor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            bEditor.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            bEditor.Properties.AutoHeight = false;
            bEditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            bEditor.KeyDown += new KeyEventHandler(bEditor_KeyDown);
            bEditor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.bEditor_ButtonClick);
            bEditor.Leave += new System.EventHandler(this.bEditor_Leave);
        }

        void dEditor_Leave(object sender, EventArgs e)
        {
            try
            {
                gridControl1.Controls.Remove(dEditor);
                foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                {
                    gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
                }
            }
            catch { }
        }
        void tEditor_Leave(object sender, EventArgs e)
        {
            try
            {
                gridControl1.Controls.Remove(tEditor);
                foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                {
                    gridView1.SetRowCellValue(cellInfo.RowHandle, gridColQtyNow, tEditor.EditValue);
                }
            }
            catch { }
        }
        void dEditor2_Leave(object sender, EventArgs e)
        {
            try
            {
                gridControl1.Controls.Remove(dEditor2);
                foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                {
                    gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
                }
            }
            catch { }
        }
        void d2Editor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    gridControl1.Controls.Remove(dEditor2);
                    m_mergedCellsEdited = null;
                }

                if (e.KeyCode == Keys.Return)
                {
                    gridControl1.Controls.Remove(dEditor2);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
                    }
                }
            }
            catch { }
        }
        void dEditor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    gridControl1.Controls.Remove(dEditor);
                    m_mergedCellsEdited = null;
                }

                if (e.KeyCode == Keys.Return)
                {
                    gridControl1.Controls.Remove(dEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
                    }
                }
            }
            catch { }
        }


        void bEditor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                    iRow = gridView1.FocusedRowHandle;

                string sVen = gridView1.GetRowCellDisplayText(iRow, gridColcVenCode).ToString().Trim();
                FrmVenInfo fVen = new FrmVenInfo(sVen);
                if (DialogResult.OK == fVen.ShowDialog())
                {
                    try
                    {
                        gridControl1.Controls.Remove(bEditor);
                        foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                        {
                            gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, fVen.sVenCode);
                            gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenName, fVen.sVenName);
                        }
                    }
                    catch { }
                    try
                    {
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcVenCode, fVen.sVenCode);
                        gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColcVenName, fVen.sVenName);
                    }
                    catch { }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商参照失败！  " + ee.Message);
            }
        }
        void bEditor_Leave(object sender, EventArgs e)
        {
            try
            {
                string sVenCode = bEditor.Text.Trim();

                DataTable dt = GetVendor(sVenCode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    gridControl1.Controls.Remove(bEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, dt.Rows[0]["iID"].ToString().Trim());
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenName, dt.Rows[0]["iText"].ToString().Trim());
                    }
                }
                else
                {
                    gridControl1.Controls.Remove(bEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, cellInfo.Column, "");
                        gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenName, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
            }

        }
        void bEditor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    gridControl1.Controls.Remove(bEditor);
                    m_mergedCellsEdited = null;
                }

                if (e.KeyCode == Keys.Return)
                {
                    gridControl1.Controls.Remove(bEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, cellInfo.Column, bEditor.Text.Trim());
                    }
                    m_mergedCellsEdited = null;
                }
            }
            catch { }
        }

        GridCellInfoCollection m_mergedCellsEdited = null;

        void tEditor_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    gridControl1.Controls.Remove(tEditor);
                    m_mergedCellsEdited = null;
                }

                if (e.KeyCode == Keys.Return)
                {
                    gridControl1.Controls.Remove(tEditor);
                    foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                    {
                        gridView1.SetRowCellValue(cellInfo.RowHandle, cellInfo.Column, tEditor.EditValue);
                    }
                }
            }
            catch { }
        }
        GridHitInfo hInfo;
        GridView view;
        string sLastCol = "";
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                view = (GridView)sender;
                hInfo = view.CalcHitInfo(e.X, e.Y);
                if (hInfo.InRowCell)
                {
                    GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
                    GridCellInfo cInfo = vInfo.GetGridCellInfo(hInfo);

                    {
                        if (gridControl1.Contains(tEditor))
                        {
                            gridControl1.Controls.Remove(tEditor);
                            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                            {
                                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColQtyNow, tEditor.EditValue);
                            }
                        }
                        if (gridControl1.Contains(bEditor))
                        {
                            gridControl1.Controls.Remove(bEditor);
                            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                            {
                                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, bEditor.EditValue);
                            }
                        }
                        if (gridControl1.Contains(dEditor))
                        {
                            gridControl1.Controls.Remove(dEditor);
                            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                            {
                                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
                            }
                        }
                        if (gridControl1.Contains(dEditor2))
                        {
                            gridControl1.Controls.Remove(dEditor2);
                            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                            {
                                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
                            }
                        }
                    }
                    if (cInfo is GridMergedCellInfo)
                    {
                        if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "qtynow")
                        {
                            if (m_mergedCellsEdited != null)
                            {
                                gridControl1.Controls.Remove(tEditor);
                            }

                            tEditor.Bounds = cInfo.Bounds;
                            tEditor.Text = cInfo.CellValue.ToString();
                            gridControl1.Controls.Add(tEditor);
                            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
                        }
                        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "cvencode")
                        {
                            if (m_mergedCellsEdited != null)
                            {
                                gridControl1.Controls.Remove(bEditor);
                            }

                            bEditor.Bounds = cInfo.Bounds;
                            bEditor.Text = cInfo.CellValue.ToString();
                            gridControl1.Controls.Add(bEditor);
                            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
                        }
                        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "date2")
                        {
                            if (m_mergedCellsEdited != null)
                            {
                                gridControl1.Controls.Remove(dEditor2);
                            }

                            dEditor2.Bounds = cInfo.Bounds;
                            dEditor2.Text = cInfo.CellValue.ToString();
                            gridControl1.Controls.Add(dEditor2);
                            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
                        }
                        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "date1")
                        {
                            if (m_mergedCellsEdited != null)
                            {
                                gridControl1.Controls.Remove(dEditor);
                            }

                            dEditor.Bounds = cInfo.Bounds;
                            dEditor.Text = cInfo.CellValue.ToString();
                            gridControl1.Controls.Add(dEditor);
                            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            //view = (GridView)sender;
            //hInfo = view.CalcHitInfo(e.X, e.Y);
            //if (hInfo.InRowCell)
            //{
            //    GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
            //    GridCellInfo cInfo = vInfo.GetGridCellInfo(hInfo);
            //    if (cInfo is GridMergedCellInfo)
            //    {
            //        if (!bEnable && (cInfo.Column.FieldName.Trim().ToLower() != "qtynow" || cInfo.Column.FieldName.Trim().ToLower() != "cvencode" || cInfo.Column.FieldName.Trim().ToLower() != "date2" || cInfo.Column.FieldName.Trim().ToLower() != "date1"))
            //        {
            //            return;
            //        }
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "qtynow")
            //        {
            //            if (m_mergedCellsEdited != null)
            //            {
            //                gridControl1.Controls.Remove(tEditor);
            //            }

            //            tEditor.Bounds = cInfo.Bounds;
            //            tEditor.Text = cInfo.CellValue.ToString();
            //            gridControl1.Controls.Add(tEditor);
            //            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
            //        }
            //        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "cvencode")
            //        {
            //            if (m_mergedCellsEdited != null)
            //            {
            //                gridControl1.Controls.Remove(bEditor);
            //            }

            //            bEditor.Bounds = cInfo.Bounds;
            //            bEditor.Text = cInfo.CellValue.ToString();
            //            gridControl1.Controls.Add(bEditor);
            //            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
            //        }
            //        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "date2")
            //        {
            //            if (m_mergedCellsEdited != null)
            //            {
            //                gridControl1.Controls.Remove(dEditor2);
            //            }

            //            dEditor2.Bounds = cInfo.Bounds;
            //            dEditor2.Text = cInfo.CellValue.ToString();
            //            gridControl1.Controls.Add(dEditor2);
            //            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
            //        }
            //        else if (cInfo is GridMergedCellInfo && cInfo.Column.FieldName.Trim().ToLower() == "date1")
            //        {
            //            if (m_mergedCellsEdited != null)
            //            {
            //                gridControl1.Controls.Remove(dEditor);
            //            }

            //            dEditor.Bounds = cInfo.Bounds;
            //            dEditor.Text = cInfo.CellValue.ToString();
            //            gridControl1.Controls.Add(dEditor);
            //            m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
            //        }
            //        if (gridControl1.Contains(tEditor) && sLastCol != "qtynow")
            //        {
            //            gridControl1.Controls.Remove(tEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColQtyNow, tEditor.EditValue);
            //            }
            //        }
            //        if (gridControl1.Contains(bEditor) && sLastCol != "cvencode")
            //        {
            //            gridControl1.Controls.Remove(bEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, bEditor.EditValue);
            //            }
            //        }

            //        if (gridControl1.Contains(dEditor2) && sLastCol != "date2")
            //        {
            //            gridControl1.Controls.Remove(dEditor2);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
            //            }
            //        }

            //        if (gridControl1.Contains(dEditor) && sLastCol != "date1")
            //        {
            //            gridControl1.Controls.Remove(dEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "qtynow" && gridControl1.Contains(tEditor))
            //        {
            //            gridControl1.Controls.Remove(tEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColQtyNow, tEditor.EditValue);
            //            }
            //        }
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "cvencode" && gridControl1.Contains(bEditor))
            //        {
            //            gridControl1.Controls.Remove(bEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColcVenCode, bEditor.EditValue);
            //            }
            //        }
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "date1" && gridControl1.Contains(dEditor))
            //        {
            //            gridControl1.Controls.Remove(dEditor);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate1, dEditor.EditValue);
            //            }
            //        }
            //        if (cInfo.Column.FieldName.Trim().ToLower() == "date2" && gridControl1.Contains(dEditor2))
            //        {
            //            gridControl1.Controls.Remove(dEditor2);
            //            foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
            //            {
            //                gridView1.SetRowCellValue(cellInfo.RowHandle, gridColdate2, dEditor2.EditValue);
            //            }
            //        }
            //    }
            //    sLastCol = cInfo.Column.FieldName.Trim().ToLower();
            //}
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView1.RowCount == 1)
                    iRow = 0;
                else
                    iRow = gridView1.FocusedRowHandle;

                string sID = gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim();
                if (! Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridCol选择)))
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        double d = 0;
                        if (gridView1.GetRowCellValue(iRow, gridColiSendT).ToString().Trim() != "")
                        {
                            d = Convert.ToDouble(gridView1.GetRowCellValue(iRow, gridColiSendT));
                        }
                        double d1 = Convert.ToDouble(gridView1.GetRowCellValue(iRow, gridColPlanQty));

                        if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == sID && d1 > d)
                        {
                            gridView1.SetRowCellValue(i, gridCol选择, true);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == sID)
                        {
                            gridView1.SetRowCellValue(i, gridCol选择, false);
                        }
                    }
                }
            }
            catch (Exception ee)
            { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        double d = 0;

                        if (gridView1.GetRowCellValue(i, gridColiSendT).ToString().Trim()!="")
                        {
                            d = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColiSendT));
                        }
                        double d1 = Convert.ToDouble(gridView1.GetRowCellValue(i, gridColPlanQty));


                        if (d1 > d)
                        {
                            gridView1.SetRowCellValue(i, gridCol选择, true);
                        }
                    }
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridCol选择, false);
                    }
                }

            }
            catch
            { }
        }

        private void SetColEnable(bool b)
        {
            gridColQtyNow.OptionsColumn.AllowEdit = b;
            gridColStartDate2.OptionsColumn.AllowEdit = b;
            gridColcVenCode.OptionsColumn.AllowEdit = b;
            gridColdate1.OptionsColumn.AllowEdit = b;
            gridColdate2.OptionsColumn.AllowEdit = b;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridView1.Columns["iQuantityI"] && radioQuantity.Checked)
                {
                    decimal d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["使用数量"])), 6);
                    decimal d2 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iQuantityI"])), 6);
                    if (radioNum.Enabled == false)      //单计量单位radioNum的Enable为false
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["QtyNow"], decimal.Round(d2 / d1, 0));
                    }
                    else
                    {
                        decimal d = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ChangeRate"])), 6);

                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["QtyNow"], decimal.Round(d2 / d1, 0));
                        gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"], decimal.Round(d2 / d, 6));
                    }
                }
                if (e.Column == gridView1.Columns["iNumI"] && radioNum.Checked)
                {

                    decimal d = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ChangeRate"])), 6);
                    decimal d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["使用数量"])), 6);
                    decimal d3 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"])), 6);

                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["iQuantityI"], decimal.Round(d * d3, 6));

                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["QtyNow"], decimal.Round(d * d3 / d1, 0));
                }

                if (radioParent.Checked && e.Column == gridView1.Columns["QtyNow"])
                {
                    string siID = gridView1.GetRowCellValue(e.RowHandle, gridColiID).ToString().Trim();
                    decimal d4 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["QtyNow"])), 6);
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColInvCode) == null || gridView1.GetRowCellValue(i, gridColInvCode).ToString().Trim() == string.Empty)
                            continue;
                        if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == siID)
                        {
                            decimal d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["使用数量"])), 6);
                            if (radioNum.Enabled)
                            {
                                decimal d = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["ChangeRate"])), 6);
                                gridView1.SetRowCellValue(i, gridView1.Columns["iNumI"], decimal.Round(d4 * d1 / d, 6));
                            }

                            decimal d5 = d4 * d1;
                            gridView1.SetRowCellValue(i, gridColiQuantityI, d5);
                        }
                    }
                }

                if ((e.Column == gridView1.Columns["iNumI"] || e.Column == gridView1.Columns["iQuantityI"]) && !radioParent.Checked)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"]).ToString().Trim() != "" && Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"])) != 0)
                    {
                        double d1 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iQuantityI"]));
                        double d2 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"]));
                        double d3 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ChangeRate"]));

                        if (d3 * d2 / 1.15 > d1 || d1 > d3 * d2 * 1.15)
                        {
                            MessageBox.Show("第" + (e.RowHandle + 1) + "行数据不能超按换算率的15%");
                        }
                    }
                }

                if (e.Column == gridColcVenCode)
                {
                    try
                    {
                        string siID = gridView1.GetRowCellValue(e.RowHandle, gridColiID).ToString().Trim();
                        string sTxt = gridView1.GetRowCellValue(e.RowHandle, gridColcVenCode).ToString().Trim();
                        string sInvCode = gridView1.GetRowCellValue(e.RowHandle, gridColInvCode).ToString().Trim();
                        DataTable dt = GetVendor(sTxt);
                        DataTable dtPrice = GetVendPriceInfo(sInvCode, sTxt);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == siID)
                                {
                                    gridView1.SetRowCellValue(e.RowHandle, gridColcVenName, dt.Rows[0]["iText"].ToString().Trim());
                                    if (dtPrice != null && dtPrice.Rows.Count > 0)
                                    {
                                        gridView1.SetRowCellValue(e.RowHandle, gridColiTaxPrice, dtPrice.Rows[0]["iTaxPrice"]);
                                        gridView1.SetRowCellValue(e.RowHandle, gridColiTaxRate, dtPrice.Rows[0]["iTaxRate"]);
                                    }
                                    else
                                    {
                                        gridView1.SetRowCellValue(e.RowHandle, gridColiTaxPrice, DBNull.Value);
                                        gridView1.SetRowCellValue(e.RowHandle, gridColiTaxRate, DBNull.Value);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == siID)
                                {
                                    gridView1.SetRowCellValue(e.RowHandle, gridColcVenName, DBNull.Value);
                                    gridView1.SetRowCellValue(e.RowHandle, gridColiTaxPrice, DBNull.Value);
                                    gridView1.SetRowCellValue(e.RowHandle, gridColiTaxRate, DBNull.Value);
                                }
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("获得供应商信息失败！ " + ee.Message);
                    }
                }
                int iRow = e.RowHandle;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                decimal d1 = 0;
                if (gridView1.GetRowCellValue(e.RowHandle, gridColCanUseQty).ToString().Trim() != "")
                {
                    d1 = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColCanUseQty));
                }
                decimal d2 = 0;
                if (gridView1.GetRowCellValue(e.RowHandle, gridColiQuantityI).ToString().Trim() != "")
                {
                    d2 = Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColiQuantityI));
                }
                if (d2 > d1)
                {
                    e.Appearance.BackColor = Color.Tomato;
                }
            }
            catch { }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridCol选择)))
                {
                    if (chkNeedDate.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridColdate2, dateNeed.DateTime.ToString("yyyy-MM-dd"));
                    }
                    if (chkEndDate.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridColdate1, dateEnd.DateTime.ToString("yyyy-MM-dd"));
                    }
                    if (chkVenPG.Checked)
                    {
                        if (txtVenNamePG.Text.Trim() != "")
                        {
                            gridView1.SetRowCellValue(i, gridColcVenCode, txtVenCodePG.Text);
                            gridView1.SetRowCellValue(i, gridColcVenName, txtVenNamePG.Text);


                        }
                        else
                        {
                            MessageBox.Show("请选择批改供应商！");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 根据存货编码判断供应商 1. 供应商存货价格表，便宜者 2. 最后一次委外厂商
        /// </summary>
        /// <param name="p">存货编码</param>
        /// <returns></returns>
        private DataTable GetVendPriceInfo(string p)
        {
            try
            {
                DataView dv = new DataView(dt供应商存货价格);
                dv.RowFilter = " cInvCode = '" + p + "' ";
                return dv.ToTable();
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商物料信息失败！\n  " + ee.Message);
            }
        }

        /// <summary>
        /// 供应商存货价格表，便宜者
        /// </summary>
        /// <param name="p">存货编码</param>
        /// <param name="sVend">供应商编码</param>
        /// <returns></returns>
        private DataTable GetVendPriceInfo(string p, string sVend)
        {
            try
            {
                //if (dt供应商存货价格 == null)
                //{
                  Get供应商存货价格(sVend, p);
                //}

                //DataView dv = new DataView(dt供应商存货价格);
                //dv.RowFilter = " cInvCode = '" + p + "' and cVenCode = '" + sVend + "' ";
                //return dv.ToTable();
                  return dt供应商存货价格;
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商物料信息失败！\n  " + ee.Message);
            }
        }

        /// <summary>
        /// 供应商部门
        /// </summary>
        private void GetDepInfo()
        {
            try
            {
                string sSQL = "select distinct v.cVenDepart as iID,d.cDepName as iText from @u8.vendor v left join @u8.Department d on v.cVenDepart = d.cDepCode where v.cVenDepart is not null order by v.cVenDepart,d.cDepName ";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                ItemLookUpEditVenDepartment.DataSource = dt;
                lookUpEditVenDep.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得部门信息失败！" + ee.Message);
            }
        }


        private void GetlookUpEditEnSure()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "iID";
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                dr["iID"] = DBNull.Value;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = "生管";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = "采购";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = "委外";
                dt.Rows.Add(dr);

                lookUpEditEnSure.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得计划确认信息失败！" + ee.Message);
            }
        }

        private void btnEnSure_Click(object sender, EventArgs e)
        {
            try
            {
                string sCode = DateTime.Parse(datePlan.Text).ToString("yyMMdd");
                if (lookUpEditEnSure.Text.Trim() == "")
                {
                    MessageBox.Show("请选择计划确认！");
                    lookUpEditEnSure.Focus();
                    return;
                }
                ArrayList aList = new ArrayList();
                ArrayList aLRow = new ArrayList();
                string sSQL = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        sSQL = "if exists(select * from UFDLImport..OMPlanDay_Info where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and cCode = '" + sCode + "') " +
                                "	update UFDLImport..OMPlanDay_Info set EnSureUser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',EnSureDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',EnSureDepment = '" + lookUpEditEnSure.Text.Trim() + "'  where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and cCode = '" + sCode + "'" +
                                " else " +
                                "	insert into UFDLImport..OMPlanDay_Info(iID,EnSureUser,EnSureDate,EnSureDepment,cCode)values('" + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + "','" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "','" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "','" + lookUpEditEnSure.Text.Trim() + "','" + sCode + "') ";

                        aList.Add(sSQL);

                        aLRow.Add(gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("确认成功！");

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        for (int j = 0; j < aLRow.Count; j++)
                        {
                            if (aLRow[j].ToString().Trim() == gridView1.GetRowCellValue(i, gridColiID).ToString().Trim())
                            {
                                gridView1.SetRowCellValue(i, gridColcCode, sCode);
                                gridView1.SetRowCellValue(i, gridColEnSureDate,FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                                gridView1.SetRowCellValue(i, gridColEnSureDepment, lookUpEditEnSure.Text.Trim());
                                gridView1.SetRowCellValue(i, gridColEnSureUser,FrameBaseFunction.ClsBaseDataInfo.sUserName);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("确认失败!" + ee.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;
            string sVenCode = gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["cVenCode"]).ToString().ToLower();
            if (bBtnType && (sVenCode == "98" || sVenCode == "" || sVenCode == "0487" || sVenCode == "0462" || sVenCode == "0482" || sVenCode == "0415"))
            {
                gridColcVenCode.OptionsColumn.AllowEdit = true;
            }
            else
            {
                gridColcVenCode.OptionsColumn.AllowEdit = false;
            }
            if (!bBtnType)
            {
                gridColcVenCode.OptionsColumn.AllowEdit = true;
            }

            string s = gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["ChangeRate"]).ToString().Trim().ToLower();//53
            if (s == "")
            {
                gridColiNumI.OptionsColumn.AllowEdit = false;
            }
            else
            {
                gridColiNumI.OptionsColumn.AllowEdit = true;
            }

            if (gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["cAssComUnitCodeI"]) != null && gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["cAssComUnitCodeI"]).ToString().Trim() != string.Empty)
            {
                radioNum.Enabled = true;
            }
            else
            {
                radioNum.Enabled = false;
            }
            if (radioNum.Enabled == true)
            {
                gridView1.Columns["iNumI"].OptionsColumn.AllowEdit = true;
            }
            else
            {
                gridView1.Columns["iNumI"].OptionsColumn.AllowEdit = false;
            }

            if (radioQuantity.Checked || radioNum.Checked)
            {
                gridColiQuantityI.OptionsColumn.AllowEdit = true;
                gridColiNumI.OptionsColumn.AllowEdit = true;

                string sID = gridView1.GetRowCellValue(e.FocusedRowHandle, gridColiID).ToString().Trim();
                int iCou = 0;                //是否一对多物料
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColiID) != null && gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == sID)
                    {
                        iCou += 1;
                    }
                }
                if (iCou > 1)
                {
                    gridColiQuantityI.OptionsColumn.AllowEdit = false;
                    gridColiNumI.OptionsColumn.AllowEdit = false;
                }
            }

            if (e.FocusedRowHandle > 0)
            {
                string s子件编码 = gridView1.GetRowCellValue(e.FocusedRowHandle, gridColcInvCode).ToString().Trim();
                string s出货周 = gridView1.GetRowCellValue(e.FocusedRowHandle, gridColRemarkXB).ToString().Trim();
                bool b = true;
                for (int i = 0; i < e.FocusedRowHandle; i++)
                {
                    string s子件编码2 = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                    string s出货周2 = gridView1.GetRowCellValue(i, gridColRemarkXB).ToString().Trim();
                    string s本次下单2 = gridView1.GetRowCellValue(i, gridColQtyNow).ToString().Trim();
                    double d本次下单2 = 0;
                    try
                    {
                        if (s本次下单2 != "")
                        {
                            d本次下单2 = double.Parse(s本次下单2);
                        }
                    }
                    catch
                    {
                        d本次下单2 = -1;
                    }

                    if (s子件编码 == s子件编码2 && s出货周 != s出货周2)
                    {
                        if (s本次下单2 == "" || s本次下单2 == "0" || d本次下单2 == 0)
                        {
                            b = false;
                            break;
                        }
                    }
                }
                gridView1.OptionsBehavior.Editable = b;
            }
            else
            {
                gridView1.OptionsBehavior.Editable = true;
            }
        }

        private void GetWareHouse()
        {
            string sSQL = "select cWhCode,cWhName,bFreeze from @u8.Warehouse where bFreeze = 0 order by cWhCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditWoreHouse.DataSource = dt;
        }

        private void btnUnEnSure_Click(object sender, EventArgs e)
        {
            try
            {
                string sCode = DateTime.Parse(datePlan.Text).ToString("yyMMdd");
                ArrayList aList = new ArrayList();
                ArrayList aLRow = new ArrayList();
                string sSQL = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        sSQL = "update UFDLImport..OMPlanDay_Info set EnSureUser =null,EnSureDate = null,EnSureDepment = null where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and cCode = '" + sCode + "'";
                        aList.Add(sSQL);
                        aLRow.Add(gridView1.GetRowCellValue(i, gridColiID).ToString().Trim());
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("取消成功！");
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        for (int j = 0; j < aLRow.Count; j++)
                        {
                            if (aLRow[j].ToString().Trim() == gridView1.GetRowCellValue(i, gridColiID).ToString().Trim())
                            {
                                gridView1.SetRowCellValue(i, gridColcCode, DBNull.Value);
                                gridView1.SetRowCellValue(i, gridColEnSureDate, DBNull.Value);
                                gridView1.SetRowCellValue(i, gridColEnSureDepment, DBNull.Value);
                                gridView1.SetRowCellValue(i, gridColEnSureUser, DBNull.Value);
                            }
                        }
                    }
                }
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 获得累计托外量，余量信息
        /// </summary>
        private void GetQty()
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColiSumOutQty) != null && gridView1.GetRowCellValue(i, gridColiSumOutQty).ToString().Trim() != "")
                {
                    continue;
                }
                string sInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();
                decimal d1 = 0;     //现存量
                decimal d2 = 0;     //累计托外
                decimal d3 = 0;     //余量
                decimal d5 = 0;     //本次下单
                bool bCanOut = true;   //足够发料

                if (gridView1.GetRowCellValue(i, gridColCurrQtyI).ToString().Trim() != "")
                {
                    d1 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColCurrQtyI));
                }
                if (gridView1.GetRowCellValue(i, gridColiSumOutQty).ToString().Trim() != "")
                {
                    d2 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiSumOutQty));
                }
                if (gridView1.GetRowCellValue(i, gridColiYuQty).ToString().Trim() != "")
                {
                    d3 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiYuQty));
                }

                for (int j = i; j < gridView1.RowCount; j++)
                {
                    if (gridView1.GetRowCellValue(j, gridColiQuantityI).ToString().Trim() != "")
                    {
                        d5 = Convert.ToDecimal(gridView1.GetRowCellValue(j, gridColiQuantityI));
                    }
                    string sInvCode2 = gridView1.GetRowCellValue(j, gridColcInvCode).ToString().Trim();
                    if (i == j)
                    {
                        if (gridView1.GetRowCellValue(j, gridColiQuantityI).ToString().Trim() == "")
                            d2 = 0;
                        else
                            d2 = Convert.ToDecimal(gridView1.GetRowCellValue(j, gridColiQuantityI));
                    }
                    else
                    {
                        if (sInvCode != sInvCode2)
                        {
                            continue;
                        }
                        if (gridView1.GetRowCellValue(j, gridColiQuantityI).ToString().Trim() != "")
                            d2 = Convert.ToDecimal(gridView1.GetRowCellValue(j, gridColiQuantityI)) + d2;
                    }
                    d3 = d1 - d2;
                    gridView1.SetRowCellValue(j, gridColiSumOutQty, d2);
                    if (d3 > 0)
                    {
                        gridView1.SetRowCellValue(j, gridColiYuQty, d3);
                    }
                    else
                    {
                        d3 = 0;
                        gridView1.SetRowCellValue(j, gridColiYuQty, d3);
                    }

                    decimal d4 = 0;     //本次可托外数量
                    if (gridView1.GetRowCellValue(i, gridColiQuantityI).ToString().Trim() != "")
                    {
                        d4 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiQuantityI));
                    }
                    if (i == j)
                    {
                        if (d1 >= d5)
                        {
                            gridView1.SetRowCellValue(i, gridColiQtyCanOut, d5);
                            bCanOut = true;
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, gridColiQtyCanOut, d1);
                            bCanOut = false;
                        }
                    }
                    else
                    {
                        if (sInvCode != sInvCode2)
                        {
                            continue;
                        }
                        if (bCanOut)
                        {
                            if (d2 - d5 > d1)
                            {
                                gridView1.SetRowCellValue(j, gridColiQtyCanOut, d2 - d5);
                                bCanOut = true;
                            }
                            else
                            {
                                if (d1 - (d2 - d5) > d5)
                                {
                                    gridView1.SetRowCellValue(j, gridColiQtyCanOut, d5);
                                    bCanOut = true;
                                }
                                else
                                {
                                    gridView1.SetRowCellValue(j, gridColiQtyCanOut, d1 - (d2 - d5));
                                    bCanOut = false;
                                }
                            }
                        }
                        else
                        {
                            gridView1.SetRowCellValue(j, gridColiQtyCanOut, 0);
                            bCanOut = false;
                        }
                    }

                }
                for (int j = gridView1.RowCount - 1; j >= i ; j--)
                {
                    string sInvCode2 = gridView1.GetRowCellValue(j, gridColcInvCode).ToString().Trim();
                    if (sInvCode2 == sInvCode)
                    {
                        gridView1.SetRowCellValue(j, gridColiYuQty, d3);
                    }
                }
            }
        }

        private void chkDateNeed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateNeed.Checked)
            {
                dateEdit1.Enabled = true;
                dateEdit2.Enabled = true;
            }
            else
            {
                dateEdit1.Enabled = false;
                dateEdit2.Enabled = false;
            }
        }

        private void chkVenPG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVenPG.Checked)
            {
                txtVenCodePG.Text = "";
                txtVenCodePG.Enabled = true;
            }
            else
            {
                txtVenCodePG.Enabled = false;
            }
        }

        private void txtVenCodePG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCodePG.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCodePG.Text = fVen.sVenCode;
                txtVenNamePG.Text = fVen.sVenName;
            }
        }

        private void txtVenCodePG_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCodePG.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenCodePG.Text = dt.Rows[0]["iID"].ToString().Trim();
                    txtVenNamePG.Text = dt.Rows[0]["iText"].ToString().Trim();
                }
                else
                {
                    txtVenCodePG.Text = "";
                    txtVenCodePG.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
            }
        }

        private void chkNeedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNeedDate.Checked)
            {
                dateNeed.Enabled = true;
            }
            else
            {
                dateNeed.Enabled = false;
            }
        }

        private void chkEndDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEndDate.Checked)
            {
                dateEnd.Enabled = true;
            }
            else
            {
                dateEnd.Enabled = false;
            }
        }

        private void btnSaveVen_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList aList = new ArrayList();
                string sSQL = "";
                string sErr = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if  (Convert.ToBoolean( gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        if (gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() == "" || gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() == "")
                        {
                            sErr = sErr + "行 " + (i + 1) + " 供应商不能为空 \n";
                            continue;
                        }

                        if (gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim() == "" || gridView1.GetRowCellValue(i, gridColiTaxRate).ToString().Trim() == "")
                        {
                            sErr = sErr + "行 " + (i + 1) + " 未设置材料价格！\n";
                            continue;
                        }

                        sSQL = "update UFDLImport..OMPlan set cVenCode = '" + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() + "' " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + " and accid ='200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";

                        aList.Add(sSQL);
                    }
                }
                if (sErr != "")
                {
                    FrmMsgBox fMsgBos = new FrmMsgBox();
                    fMsgBos.Text = "保存失败";
                    fMsgBos.richTextBox1.Text = "保存失败，原因如下：\n" + sErr;
                    fMsgBos.ShowDialog();
                    return;
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败！ " + ee.Message);
            }
        }

        private void datePlan_EditValueChanged(object sender, EventArgs e)
        {
            dateEdit1.DateTime = datePlan.DateTime;
            dateEdit2.DateTime = datePlan.DateTime.AddDays(3);
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            if (!bGetOrLoad)
                return;

            if (dtOMPlanDay == null || dtOMPlanDay.Rows.Count == 0)
            {

                MessageBox.Show("没有数据");
                return;
            }
            dtOMPlanDay.DefaultView.RowFilter = ("isnull(bCreateDayPlan,0)=0");

            gridControl1.DataSource = dtOMPlanDay.DefaultView;
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            if (!bGetOrLoad)
                return;

            if (dtOMPlanDay == null || dtOMPlanDay.Rows.Count == 0)
            {

                MessageBox.Show("没有数据");
                return;
            }
            dtOMPlanDay.DefaultView.RowFilter = ("isnull(bCreateDayPlan,0)=1");

            gridControl1.DataSource = dtOMPlanDay.DefaultView;
        }

        private void radio3_CheckedChanged(object sender, EventArgs e)
        {
            if (!bGetOrLoad)
                return;

            if (dtOMPlanDay == null || dtOMPlanDay.Rows.Count == 0)
            {

                MessageBox.Show("没有数据");
                return;
            }
            dtOMPlanDay.DefaultView.RowFilter = ("1=1");

            gridControl1.DataSource = dtOMPlanDay.DefaultView;
        }

        private void radio1toN_CheckedChanged(object sender, EventArgs e)
        {
            if (radio1toN.Checked)
            {
                MessageBox.Show("一对多的数据使用排序请注意不要遗漏子件");
            }
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAll.Checked)
            {
                MessageBox.Show("一对多的数据使用排序请注意不要遗漏子件");
            }
        }


        private void Get供应商存货价格(string sVenCode,string sInvCode)
        {
            sSQL = @"
 select *,v.iunitprice as iUnitPrice,v.itaxunitprice as iTaxPrice from 
        ( 
            select max(Autoid) as Autoid from @u8.ven_inv_price group by cvencode,cInvCode 
        ) vT left join @u8.ven_inv_price v on v.Autoid = vT.autoid   
         left join @u8.vendor vd on vd.cVenCode = v.cVenCode                             
where v.iSupplyType = '2' 
    and v.cVenCode = '111111' and v.cInvCode = '222222'
order by v.iunitprice,v.Autoid
";
            sSQL = sSQL.Replace("111111", sVenCode);
            sSQL = sSQL.Replace("222222", sInvCode);
            dt供应商存货价格 = clsSQLCommond.ExecQuery(sSQL);
        }

        private void Frm委外日计划_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Width = this.Width - 20;
            //groupBox1.Height = this.Height - 160;
            gridControl1.Width = groupBox1.Width - 20;
            gridControl1.Height = groupBox1.Height - 280;
        }
    }
}