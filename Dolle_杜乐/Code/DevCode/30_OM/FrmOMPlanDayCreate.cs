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
using FrameBaseFunction;

namespace OM
{
    public partial class FrmOMPlanDayCreate : FrameBaseFunction.Frm列表窗体模板
    {
        bool bCanCreate = true;

        ClsVenInvPrice clsPrice = new ClsVenInvPrice();
        string sFocusCol = "";
        public DataTable dtOM;
        DataTable dtVenPrice = null;


        public FrmOMPlanDayCreate()
        {
            InitializeComponent();

            CreateMergetEditControl();
            CreateMergebEditControl();
            CreateMergedEditControl();
            CreateMerged2EditControl();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "save":
                        btnImport();
                        break;
                    case "delrow":
                        btnDel();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImport()
        {
                ArrayList aList材料出库 = new ArrayList();

            int iYear = int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            int iYear2 = int.Parse(date1.DateTime.ToString("yyyy"));
            string sSQL = "";

            if (iYear >= iYear2)
            {
                sSQL = "select * from @u8.GL_mend where iperiod = month('" + date1.DateTime.ToString("yyyy-MM-dd") + "')";
                DataTable dtTemp1 = clsSQLCommond.ExecQuery(sSQL);
                if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_OM"]) == true)
                {
                    MessageBox.Show("当月委外管理已结帐，不能录入数据！");
                    return;
                }

                if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_ST"]) == true)
                {
                    MessageBox.Show("当月库存管理已结帐，不能录入数据！");
                    return;
                }
            }
            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }
            DataTable dt = (DataTable)gridControl1.DataSource;

            FrmMailListSend frmMail = new FrmMailListSend();

            if (!bCanCreate)
            {
                return;
            }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                //已生单数量
                decimal d1 = 0;
                if (gridView1.GetRowCellValue(i, gridColDidQty).ToString().Trim() != "")
                    d1 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColDidQty));
                //本次下单数量
                decimal d2 = 0;
                if (gridView1.GetRowCellValue(i, gridColQtyNow).ToString().Trim() != "")
                    d2 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColQtyNow));
                //超单百分比
                decimal d3 = 0;
                if (gridView1.GetRowCellValue(i, gridColfInExcess).ToString().Trim() != "")
                    d3 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColfInExcess));
                //计划下单数量
                decimal d4 = 0;
                if (gridView1.GetRowCellValue(i, gridColPlanQty).ToString().Trim() != "")
                    d4 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColPlanQty));
                //发料套数
                decimal d5 = 0;
                if (gridView1.GetRowCellValue(i, gridColiSendT).ToString().Trim() != "")
                    d5 = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColiSendT));
                if (((d5 + d2) > d4 * (1 + d3 / 100)) && (d5 - d1 >1))
                {
                    throw new Exception("行 " + (i + 1) + "不能超计划托外");
                }
            }

            //获得委外订单主表框架
            sSQL = "select * from @u8.OM_MOMain where 1=-1";
            DataTable dtOM_MOMain = clsSQLCommond.ExecQuery(sSQL);
            //获得委外订单子表框架
            sSQL = "select * from @u8.OM_MODetails  where 1=-1";
            DataTable dtOM_MODetails = clsSQLCommond.ExecQuery(sSQL);
            //获得委外订单用料表框架
            sSQL = "select * from @u8.OM_MOMaterials where 1=-1";
            DataTable dtOM_MOMaterials = clsSQLCommond.ExecQuery(sSQL);
            //获得收发记录主表框架
            sSQL = " select * from @u8.rdrecord11 where 1=-1";
            DataTable dtRdRecord = clsSQLCommond.ExecQuery(sSQL);
            //获得收发记录子表框架
            sSQL = " select * from @u8.rdrecords11 where 1=-1";
            DataTable dtRdRecords = clsSQLCommond.ExecQuery(sSQL);

            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }

            bool bCreateRD = false;
            if (MessageBox.Show("是否同步生成材料出库单", "选择", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                bCreateRD = true;
            }

            DataTable dt2 = (DataTable)gridControl1.DataSource;
            if (dt2 == null)
            {
                MessageBox.Show("没有数据，不能生成单据！");
                return;
            }

            DataView dv = dt2.Copy().DefaultView;
            dv.Sort = " iID asc";

            DataTable dtData = dv.ToTable();



            if (dtData.Rows.Count < 1)
            {
                MessageBox.Show("请选择需要生成的单据！");
                gridControl1.DataSource = dt2;
                return;
            }

            //--------------------------------------------------------委外订单-------------------------------------------------------------------------------------
            long iID;
            long iIDDetail;
            long iIDDetailMe;

            sSQL = @"
declare @p5 int
set @p5=1000043137
declare @p6 int
set @p6=1000043137
exec @u8.sp_GetID @RemoteId=N'00',@cAcc_Id=N'200',@cVouchType=N'OM_MO',@iAmount=1,@iFatherId=@p5 output,@iChildId=@p6 output
select @p5, @p6
";

//            sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = 'OM_MO'";
            DataTable dtID = clsSQLCommond.ExecQuery(sSQL);

            if (dtID == null || dtID.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dtID.Rows[0][0]);
                iIDDetail = Convert.ToInt64(dtID.Rows[0][1]);
            }
            // OM_Materials

            sSQL = @"
declare @p5 int
set @p5=1000043137
declare @p6 int
set @p6=1000043137
exec @u8.sp_GetID @RemoteId=N'00',@cAcc_Id=N'200',@cVouchType=N'OM_Materials',@iAmount=1,@iFatherId=@p5 output,@iChildId=@p6 output
select @p5, @p6
";
            //sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = 'OM_Materials'";
            dtID = clsSQLCommond.ExecQuery(sSQL);
            if (dtID == null || dtID.Rows.Count < 1)
            {
                iIDDetailMe = 0;
            }
            else
            {
                iIDDetailMe = Convert.ToInt64(dtID.Rows[0][1]);
            }

            //获得委外订单历史最大单据号
            long iVouNumber;
            sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='OM01' and cSeed = '" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "'";
            dt = clsSQLCommond.ExecQuery(sSQL);
            iVouNumber = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);

            bool bVouNumber = false;            //当月第一张单据
            if (iVouNumber == 0)
            {
                bVouNumber = true;
            }

            long iRDID = 0;
            long iRDIDDetail = 0;
            bool bVouNO = false;                //当月第一张单据
            long iVouN0 = 0;

            if (bCreateRD)
            {
                sSQL = @"
declare @p5 int
set @p5=1000043137
declare @p6 int
set @p6=1000043137
exec @u8.sp_GetID @RemoteId=N'00',@cAcc_Id=N'200',@cVouchType=N'rd',@iAmount=1,@iFatherId=@p5 output,@iChildId=@p6 output
select @p5, @p6
";

                //sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = 'rd'";
                dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt == null || dt.Rows.Count < 1)
                {
                    iRDID = 0;
                    iRDIDDetail = 0;
                }
                else
                {
                    iRDID = Convert.ToInt64(dt.Rows[0][0]);
                    iRDIDDetail = Convert.ToInt64(dt.Rows[0][1]);
                }

                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412'  and cSeed = '" + Convert.ToDateTime(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "' and ccontent = '日期' ";
                dt = clsSQLCommond.ExecQuery(sSQL);


                iVouN0 = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);
                if (iVouN0 == 0)
                {
                    bVouNO = true;
                }
            }

            DataRow drOM_MOMain = null;
            DataRow drOM_MODetails = null;
            DataRow drOM_MOMaterials = null;
            ArrayList aList = new ArrayList();
            ArrayList aListEnd = new ArrayList();
            string sCode = "";
            string sCodeRD = "";

            DataColumn dc = new DataColumn();
            dc.ColumnName = "OMID";
            dtData.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "OMDeID";
            dtData.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "OMDeIID";
            dtData.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "RDID";
            dtData.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "RDDeID";
            dtData.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "委外订单号";
            dtData.Columns.Add(dc);

            string sErr = "";

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                if (dtData.Rows[i]["invCode"] == null || dtData.Rows[i]["invCode"].ToString().Trim() == "")
                {
                    sErr = sErr + "行 " + dtData.Rows[i]["iRow"].ToString().Trim() + " 委外母件不能为空 \n";
                    continue;
                }
                else
                {
                    if (dtData.Rows[i]["date2"].ToString().Trim() != "")
                    {
                        DateTime d1 = Convert.ToDateTime(dtData.Rows[i]["date2"]);
                        DateTime d2 = DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd"));
                        if (d2 > d1)
                        {
                            sErr = sErr + "行 " + dtData.Rows[i]["iRow"].ToString().Trim() + " 需求日期不能小于当天 \n";
                            continue;
                        }
                    }
                    if (dtData.Rows[i]["invName"].ToString().Trim() != "" && (dtData.Rows[i]["cVenCode"] == null || dtData.Rows[i]["cVenCode"].ToString().Trim() == "" || dtData.Rows[i]["cVenCode"].ToString().Trim() == "98"))
                    {
                        sErr = sErr + "行 " + dtData.Rows[i]["iRow"].ToString().Trim() + " " + dtData.Rows[i]["invCode"].ToString() + "未设置供应商！\n";
                        continue;
                    }
                    if (dtData.Rows[i]["invName"].ToString().Trim() != "" && (dtData.Rows[i]["iTaxPrice"] == null || dtData.Rows[i]["iTaxPrice"].ToString().Trim() == "" || Convert.ToDecimal(dtData.Rows[i]["iTaxPrice"]) == 0))
                    {
                        sErr = sErr + "行 " + dtData.Rows[i]["iRow"].ToString().Trim() + " " + dtData.Rows[i]["invCode"].ToString() + "未设置材料价格！\n";
                        continue;
                    }
                    if (dtData.Rows[i]["invName"].ToString().Trim() != "" && (dtData.Rows[i]["iTaxRate"] == null || dtData.Rows[i]["iTaxRate"].ToString().Trim() == "" || Convert.ToDecimal(dtData.Rows[i]["iTaxRate"]) == 0))
                    {
                        sErr = sErr + "行 " + dtData.Rows[i]["iRow"].ToString().Trim() + " " + dtData.Rows[i]["invCode"].ToString() + "未设置材料税率！\n";
                        continue;
                    }
                    if (dtData.Rows[i]["QtyNow"].ToString().Trim() == "" || dtData.Rows[i]["QtyNow"] == null || dtData.Rows[i]["QtyNow"].ToString().Trim() == "0")
                    {
                        sErr = sErr + "行 " + dtData.Rows[i]["iRow"].ToString().Trim() + " " + dtData.Rows[i]["invCode"].ToString() + "未设置生单数量！\n";
                        continue;
                    }
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["iNumI"]).ToString().Trim() != "" && Convert.ToDouble(gridView1.GetRowCellValue(i, gridView1.Columns["iNumI"])) != 0)
                    {
                        decimal d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["iQuantityI"])), 6);
                        decimal d2 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["iNumI"])), 6);
                        decimal d3 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["ChangeRate"])), 6);
                        decimal d4 = (decimal)1.15;

                        if (d3 * d2 / d4 > d1 || d1 > d3 * d2 * d4)
                        {
                            sErr = sErr + "行 " + dtData.Rows[i]["iRow"].ToString().Trim() + " " + dtData.Rows[i]["invCode"].ToString() + "不能超按换算率的15%";
                            continue;
                        }
                    }
                    if (!chkRDOut.Checked && bCreateRD)
                    { 
                        double d1 = 0;
                        if (dtData.Rows[i]["CurrQtyI"].ToString().Trim() != "")
                        {
                            d1 = Convert.ToDouble(dtData.Rows[i]["CurrQtyI"]);
                        }
                        double d2 = 0;
                        if (dtData.Rows[i]["iQuantityI"].ToString().Trim() != "")
                        {
                            d2 = Convert.ToDouble(dtData.Rows[i]["iQuantityI"]);
                        }
                        if (d2 > d1)
                        {
                            sErr = sErr + "行 " + dtData.Rows[i]["iRow"].ToString().Trim() + " " + dtData.Rows[i]["cinvCode"].ToString() + "超现存量出库！\n";
                            continue;
                        }
                    }
                }
            }
            if (sErr.Trim() != string.Empty)
            {
                FrmMsgBox fMsgBox = new FrmMsgBox();
                fMsgBox.Text = "错误";
                fMsgBox.richTextBox1.Text = "存在以下错误，请修正后继续：\n" + sErr;
                fMsgBox.ShowDialog();
                return;
            }
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                decimal dtemp1 = 0;
                if (dtData.Rows[i]["QtyNow"].ToString().Trim() != "")
                {
                    dtemp1 = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["QtyNow"]), 6);
                }
                if (dtemp1 == 0)
                {
                    DialogResult d = MessageBox.Show("母件数量不能为空或者小于等于0，是否继续？是：跳过本数据继续生单；否：停止生单", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d != DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                decimal dtemp2 = 0;
                if (dtData.Rows[i]["iQuantityI"].ToString().Trim() != "")
                {
                    dtemp2 = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["iQuantityI"]), 6);
                }
                if (dtemp2 == 0)
                {
                    DialogResult d = MessageBox.Show("子件数量不能为空或者小于等于0，是否继续？是：跳过本数据继续生单；否：停止生单", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (d != DialogResult.Yes)
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (i == 0)
                {
                    iID += 1;
                    iVouNumber += 1;

                    drOM_MOMain = dtOM_MOMain.NewRow();
                    drOM_MOMain["MOID"] = iID;
                    drOM_MOMain["cCode"] = GetcCode(iVouNumber.ToString());
                    drOM_MOMain["cVenCode"] = dtData.Rows[i]["cVenCode"];
                    drOM_MOMain["dDate"] = date1.DateTime.ToString("yyyy-MM-dd");
                    drOM_MOMain["cDepCode"] = "905";
                    drOM_MOMain["cPTCode"] = "02";
                    drOM_MOMain["cexch_name"] = "人民币";
                    drOM_MOMain["nflat"] = "1.0000000000";
                    //drOM_MOMain["iTaxRate"] = "16";
                    drOM_MOMain["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    drOM_MOMain["iVerifyStateNew"] = 0;
                    drOM_MOMain["iVTid"] = "30770";
                    drOM_MOMain["cBusType"] = "委外加工";
                    drOM_MOMain["cState"] = 0;
                    drOM_MOMain["iReturnCount"] = 0;
                    drOM_MOMain["IsWfControlled"] = 0;
                    drOM_MOMain["dCreateTime"] = date1.DateTime.ToString("yyyy-MM-dd");
                    dtData.Rows[i]["OMID"] = drOM_MOMain["MOID"];
                    if (bCreateRD)
                    {
                        drOM_MOMain["cVerifier"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        drOM_MOMain["iVerifyStateNew"] = 2;
                        drOM_MOMain["dVerifyDate"] = date1.DateTime.ToString("yyyy-MM-dd");
                        drOM_MOMain["dVerifyTime"] = date1.DateTime.ToString("yyyy-MM-dd");
                        drOM_MOMain["cState"] = 1;
                    }

                    dtOM_MOMain.Rows.Add(drOM_MOMain);

                    dtData.Rows[i]["OMID"] = iID;
                    dtData.Rows[i]["委外订单号"] = drOM_MOMain["cCode"];


                    //设定邮件发送
                    sSQL = " SELECT u.uid, u.vendCode, u.bVend, u.sEMail, u.POAduditGrade, u.AccID, u.AccYear, v.cVenName " +
                            "FROM UFDLImport.._vendUid u LEFT OUTER JOIN @u8.Vendor v ON v.cVenCode = u.vendCode " +
                            "WHERE accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and (vendCode = '" + drOM_MOMain["cVenCode"].ToString().Trim() + "')";
                    DataTable dtMailAddress = clsSQLCommond.ExecQuery(sSQL);
                    if (dtMailAddress != null && dtMailAddress.Rows.Count > 0)
                    {
                        DataRow drMail = frmMail.dt.NewRow();
                        drMail["cCode"] = drOM_MOMain["cCode"];
                        drMail["Subject"] = "委外订单生成";
                        drMail["sText"] = "";
                        drMail["bUsed"] = "-1";
                        drMail["mailAddress"] = dtMailAddress.Rows[0]["sEMail"];
                        drMail["mailPerID"] = dtMailAddress.Rows[0]["vendCode"];
                        drMail["mailPer"] = dtMailAddress.Rows[0]["cVenName"];
                        drMail["sMailCC"] = "dolle_sz@126.com";

                        frmMail.dt.Rows.Add(drMail);
                    }
                }
                else
                {
                    bool bVend = false;
                    for (int j = 0; j < i && j < dtOM_MOMain.Rows.Count; j++)
                    {
                        if (dtOM_MOMain.Rows[j]["cVenCode"].ToString().Trim().ToLower() == dtData.Rows[i]["cVenCode"].ToString().Trim().ToLower())
                        {
                            bVend = true;
                            dtData.Rows[i]["OMID"] = dtOM_MOMain.Rows[j]["MOID"];
                            dtData.Rows[i]["委外订单号"] = dtData.Rows[j]["委外订单号"];
                            break;
                        }
                    }
                    if (!bVend)
                    {
                        iID += 1;
                        iVouNumber += 1;

                        drOM_MOMain = dtOM_MOMain.NewRow();
                        drOM_MOMain["MOID"] = iID;
                        drOM_MOMain["cCode"] = GetcCode(iVouNumber.ToString());
                        drOM_MOMain["cVenCode"] = dtData.Rows[i]["cVenCode"];
                        drOM_MOMain["dDate"] = date1.DateTime.ToString("yyyy-MM-dd");
                        drOM_MOMain["cDepCode"] = "905";
                        drOM_MOMain["cPTCode"] = "02";
                        drOM_MOMain["cexch_name"] = "人民币";
                        drOM_MOMain["nflat"] = "1.0000000000";
                        drOM_MOMain["iTaxRate"] = "iTaxRate_All";
                        drOM_MOMain["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        drOM_MOMain["iVTid"] = "30770";
                        drOM_MOMain["cBusType"] = "委外加工";
                        drOM_MOMain["cState"] = 0;
                        drOM_MOMain["iReturnCount"] = 0;
                        drOM_MOMain["iVerifyStateNew"] = 0;
                        drOM_MOMain["IsWfControlled"] = 0;
                        drOM_MOMain["dCreateTime"] = date1.DateTime.ToString("yyyy-MM-dd");


                        dtData.Rows[i]["OMID"] = drOM_MOMain["MOID"];

                        if (bCreateRD)
                        {
                            drOM_MOMain["cVerifier"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                            drOM_MOMain["iVerifyStateNew"] = 2;
                            drOM_MOMain["dVerifyDate"] = date1.DateTime.ToString("yyyy-MM-dd");
                            drOM_MOMain["dVerifyTime"] = date1.DateTime.ToString("yyyy-MM-dd");
                            drOM_MOMain["cState"] = 1;
                        }

                        dtOM_MOMain.Rows.Add(drOM_MOMain);
                        dtData.Rows[i]["OMID"] = iID;
                        dtData.Rows[i]["委外订单号"] = drOM_MOMain["cCode"];


                        //设定邮件发送
                        sSQL = " SELECT u.uid, u.vendCode, u.bVend, u.sEMail, u.POAduditGrade, u.AccID, u.AccYear, v.cVenName " +
                                "FROM _vendUid u LEFT OUTER JOIN @u8.Vendor v ON v.cVenCode = u.vendCode " +
                                "WHERE accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and (vendCode = '" + drOM_MOMain["cVenCode"].ToString().Trim() + "')";
                        DataTable dtMailAddress = clsSQLCommond.ExecQuery(sSQL);
                        if (dtMailAddress != null && dtMailAddress.Rows.Count > 0)
                        {
                            DataRow drMail = frmMail.dt.NewRow();
                            drMail["cCode"] = drOM_MOMain["cCode"];
                            drMail["Subject"] = "委外订单生成";
                            frmMail.sDO = "委外订单生成";
                            drMail["sText"] = "";
                            drMail["bUsed"] = "-1";
                            drMail["mailAddress"] = dtMailAddress.Rows[0]["sEMail"];
                            drMail["mailPerID"] = dtMailAddress.Rows[0]["vendCode"];
                            drMail["mailPer"] = dtMailAddress.Rows[0]["cVenName"];
                            drMail["sMailCC"] = "13862024986@139.com;13814847552@139.com;dolle_sz@126.com";

                            frmMail.dt.Rows.Add(drMail);
                        }
                    }
                }
            }
            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                if (dtData.Rows[i]["invName"] == null || dtData.Rows[i]["invName"].ToString().Trim() == "")
                {
                    continue;
                }

                DataTable dtcItemCode = null;
                if (dtData.Rows[i]["SoCode"] != null && dtData.Rows[i]["SoCode"].ToString().Trim() != string.Empty)
                {
                    sSQL = "select sd.cItemCode,sd.cItemName,sd.cItem_class,sd.cItem_CName from @u8.SO_SOMain s inner join @u8.SO_SODetails sd on s.id = sd.id where s.cSOCode = '" + dtData.Rows[i]["SoCode"].ToString().Trim() + "' and sd.iRowNo =  " + dtData.Rows[i]["SoSeq"].ToString().Trim();
                    dtcItemCode = clsSQLCommond.ExecQuery(sSQL);
                }

                if (i == 0)
                {
                    iIDDetail += 1;
                    drOM_MODetails = dtOM_MODetails.NewRow();
                    drOM_MODetails["MODetailsID"] = iIDDetail;
                    drOM_MODetails["MOID"] = dtData.Rows[i]["OMID"];
                    drOM_MODetails["cInvCode"] = dtData.Rows[i]["InvCode"];
                    drOM_MODetails["iQuantity"] = dtData.Rows[i]["QtyNow"];
                    drOM_MODetails["iSum"] = Convert.ToDouble(dtData.Rows[i]["iTaxPrice"]) * Convert.ToDouble(dtData.Rows[i]["QtyNow"]);
                    //drOM_MODetails["iMoney"] = Convert.ToDouble(drOM_MODetails["iSum"]) / (1 + (Convert.ToDouble(dtData.Rows[i]["iTaxRate"]) / 100));
                    //drOM_MODetails["iMoney"] = decimal.Round(Convert.ToDecimal(drOM_MODetails["iMoney"]), 2);
                    //drOM_MODetails["iTax"] = Convert.ToDecimal(drOM_MODetails["iSum"]) - Convert.ToDecimal(drOM_MODetails["iMoney"]);
                    drOM_MODetails["iUnitPrice"] = Convert.ToDouble(dtData.Rows[i]["iTaxPrice"]) / (1 + (Convert.ToDouble(dtData.Rows[i]["iTaxRate"]) / 100));
                    drOM_MODetails["iUnitPrice"] = decimal.Round(Convert.ToDecimal(drOM_MODetails["iUnitPrice"]), 6);
                    drOM_MODetails["iNatUnitPrice"] = drOM_MODetails["iUnitPrice"];
                    drOM_MODetails["iNatMoney"] = drOM_MODetails["iMoney"];
                    //drOM_MODetails["iNatTax"] = drOM_MODetails["iTax"];
                    drOM_MODetails["iNatSum"] = drOM_MODetails["iSum"];
                    drOM_MODetails["dStartDate"] = dtData.Rows[i]["date1"];
                    drOM_MODetails["dArriveDate"] = dtData.Rows[i]["date2"];
                    drOM_MODetails["iPerTaxRate"] = dtData.Rows[i]["iTaxRate"];
                    if (dtcItemCode != null && dtcItemCode.Rows.Count > 0)
                    {
                        drOM_MODetails["cItemCode"] = dtcItemCode.Rows[0]["cItemCode"];
                        drOM_MODetails["cItem_class"] = dtcItemCode.Rows[0]["cItem_class"];
                        drOM_MODetails["cItemName"] = dtcItemCode.Rows[0]["cItemName"];
                    }
                    drOM_MODetails["bGsp"] = 0;
                    drOM_MODetails["iTaxPrice"] = dtData.Rows[i]["iTaxPrice"];
                    drOM_MODetails["bTaxCost"] = 1;
                    drOM_MODetails["BomID"] = dtData.Rows[i]["bomID"];
                    drOM_MODetails["fParentScrp"] = dtData.Rows[i]["ParentScrap"];

                    drOM_MODetails["iVTids"] = 8159;

                    dtData.Rows[i]["OMDeID"] = drOM_MODetails["MODetailsID"];

                    sSQL = "select i.iGroupType,i.cGroupCode,i.cComUnitCode,isnull(i.cAssComUnitCode,'') as cAssComUnitCode,u.iChangRate " +
                            "from @u8.Inventory I left join @u8.ComputationUnit u on u.cGroupCode = i.cGroupCode and u.cComunitCode = i.cAssComUnitCode " +
                            "where i.cInvCode = '" + dtData.Rows[i]["InvCode"].ToString().Trim() + "' ";
                    DataTable dtChangRate = clsSQLCommond.ExecQuery(sSQL);
                    if (dtChangRate != null && dtChangRate.Rows.Count > 0 && dtChangRate.Rows[0]["cAssComUnitCode"].ToString().Trim() != "")
                    {
                        drOM_MODetails["cUnitID"] = dtChangRate.Rows[0]["cAssComUnitCode"];
                        decimal dChangRate = Convert.ToDecimal(dtData.Rows[i]["QtyNow"]) / decimal.Round(Convert.ToDecimal(dtChangRate.Rows[0]["iChangRate"]), 2);
                        drOM_MODetails["iNum"] = decimal.Round(dChangRate, 6);
                    }

                    dtOM_MODetails.Rows.Add(drOM_MODetails);

                    sSQL = "insert into UFDLImport..OMPlan_Import(OMPlanID,Qty,OM_MODetailsID,UserID,dDate,accid,accyear)values" +
                            "(" + dtData.Rows[i]["iID"] + "," + Convert.ToDouble(dtData.Rows[i]["QtyNow"]) + "," + iIDDetail + ",'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "','" + date1.DateTime.ToString("yyyy-MM-dd") + "','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "')";
                    aList.Add(sSQL);

                    sSQL = "insert into UFDLImport..OMPlanDay_Import(OMPlanDayID,OMPlanID,Qty,OM_MODetailsID,UserID,dDate,accid,accyear,cInvCode)values" +
                          "(" + dtData.Rows[i]["ID"] + "," + dtData.Rows[i]["iID"] + "," + Convert.ToDouble(dtData.Rows[i]["QtyNow"]) + "," + iIDDetail + ",'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "','" + date1.DateTime.ToString("yyyy-MM-dd") + "'," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + ",'" + dtData.Rows[i]["InvCode"] + "')";
                    aList.Add(sSQL);
                }
                else
                {
                    if (dtData.Rows[i - 1]["iID"].ToString().Trim().ToLower() == dtData.Rows[i]["iID"].ToString().Trim().ToLower())
                    {
                        continue;
                    }
                    iIDDetail += 1;
                    drOM_MODetails = dtOM_MODetails.NewRow();
                    drOM_MODetails["MODetailsID"] = iIDDetail;
                    drOM_MODetails["MOID"] = dtData.Rows[i]["OMID"];
                    drOM_MODetails["cInvCode"] = dtData.Rows[i]["InvCode"];
                    drOM_MODetails["iQuantity"] = dtData.Rows[i]["QtyNow"];
                    drOM_MODetails["iSum"] = Convert.ToDouble(dtData.Rows[i]["iTaxPrice"]) * Convert.ToDouble(dtData.Rows[i]["QtyNow"]);
                    drOM_MODetails["iMoney"] = Convert.ToDouble(drOM_MODetails["iSum"]) / (1 + (Convert.ToDouble(dtData.Rows[i]["iTaxRate"]) / 100));
                    drOM_MODetails["iMoney"] = decimal.Round(Convert.ToDecimal(drOM_MODetails["iMoney"]), 2);
                    //drOM_MODetails["iTax"] = Convert.ToDecimal(drOM_MODetails["iSum"]) - Convert.ToDecimal(drOM_MODetails["iMoney"]);
                    drOM_MODetails["iUnitPrice"] = Convert.ToDouble(dtData.Rows[i]["iTaxPrice"]) / (1 + (Convert.ToDouble(dtData.Rows[i]["iTaxRate"]) / 100));
                    drOM_MODetails["iUnitPrice"] = decimal.Round(Convert.ToDecimal(drOM_MODetails["iUnitPrice"]), 6);
                    drOM_MODetails["iNatUnitPrice"] = drOM_MODetails["iUnitPrice"];
                    drOM_MODetails["iNatMoney"] = drOM_MODetails["iMoney"];
                    drOM_MODetails["iNatTax"] = drOM_MODetails["iTax"];
                    drOM_MODetails["iNatSum"] = drOM_MODetails["iSum"];
                    drOM_MODetails["dStartDate"] = dtData.Rows[i]["date1"];
                    drOM_MODetails["dArriveDate"] = dtData.Rows[i]["date2"];
                    drOM_MODetails["iPerTaxRate"] = dtData.Rows[i]["iTaxRate"];
                    if (dtcItemCode != null && dtcItemCode.Rows.Count > 0)
                    {
                        drOM_MODetails["cItemCode"] = dtcItemCode.Rows[0]["cItemCode"];
                        drOM_MODetails["cItem_class"] = dtcItemCode.Rows[0]["cItem_class"];
                        drOM_MODetails["cItemName"] = dtcItemCode.Rows[0]["cItemName"];
                    }
                    drOM_MODetails["bGsp"] = 0;
                    drOM_MODetails["iTaxPrice"] = dtData.Rows[i]["iTaxPrice"];
                    drOM_MODetails["bTaxCost"] = 1;
                    drOM_MODetails["BomID"] = dtData.Rows[i]["bomID"];
                    drOM_MODetails["fParentScrp"] = dtData.Rows[i]["ParentScrap"];

                    drOM_MODetails["iVTids"] = 8159;

                    dtData.Rows[i]["OMDeID"] = drOM_MODetails["MODetailsID"];

                    sSQL = "select i.iGroupType,i.cGroupCode,i.cComUnitCode,isnull(i.cAssComUnitCode,'') as cAssComUnitCode,u.iChangRate " +
                            "from @u8.Inventory I left join @u8.ComputationUnit u on u.cGroupCode = i.cGroupCode and u.cComunitCode = i.cAssComUnitCode " +
                            "where i.cInvCode = '" + dtData.Rows[i]["InvCode"].ToString().Trim() + "' ";
                    DataTable dtChangRate = clsSQLCommond.ExecQuery(sSQL);
                    if (dtChangRate != null && dtChangRate.Rows.Count > 0 && dtChangRate.Rows[0]["cAssComUnitCode"].ToString().Trim() != "")
                    {
                        drOM_MODetails["cUnitID"] = dtChangRate.Rows[0]["cAssComUnitCode"];
                        decimal dChangRate = Convert.ToDecimal(dtData.Rows[i]["QtyNow"]) / decimal.Round(Convert.ToDecimal(dtChangRate.Rows[0]["iChangRate"]), 2);
                        drOM_MODetails["iNum"] = decimal.Round(dChangRate, 6);
                    }

                    dtOM_MODetails.Rows.Add(drOM_MODetails);

                    sSQL = "insert into UFDLImport..OMPlan_Import(OMPlanID,Qty,OM_MODetailsID,UserID,dDate,accid,accyear)values" +
                        "(" + dtData.Rows[i]["iID"] + "," + Convert.ToDouble(dtData.Rows[i]["QtyNow"]) + "," + iIDDetail + ",'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "','" + date1.DateTime.ToString("yyyy-MM-dd") + "'," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + ")";
                    aList.Add(sSQL);

                    sSQL = "insert into UFDLImport..OMPlanDay_Import(OMPlanDayID,OMPlanID,Qty,OM_MODetailsID,UserID,dDate,accid,accyear,cInvCode)values" +
                          "(" + dtData.Rows[i]["ID"] + "," + dtData.Rows[i]["iID"] + "," + Convert.ToDouble(dtData.Rows[i]["QtyNow"]) + "," + iIDDetail + ",'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "','" + date1.DateTime.ToString("yyyy-MM-dd") + "'," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "," + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + ",'" + dtData.Rows[i]["InvCode"] + "')";
                    aList.Add(sSQL);
                }
            }

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                for (int j = i + 1; j < dtData.Rows.Count; j++)
                {
                    if (dtData.Rows[i]["iID"].ToString().Trim() == dtData.Rows[j]["iID"].ToString().Trim())
                    {
                        dtData.Rows[j]["OMID"] = dtData.Rows[i]["OMID"];
                        dtData.Rows[j]["OMDeID"] = dtData.Rows[i]["OMDeID"];
                    }
                }
            }

            string siSupplyType = "";

            for (int i = 0; i < dtData.Rows.Count; i++)
            {
                DataTable dtcItemCode = null;
                if (dtData.Rows[i]["SoCode"] != null && dtData.Rows[i]["SoCode"].ToString().Trim() != string.Empty)
                {
                    sSQL = "select sd.cItemCode,sd.cItemName,sd.cItem_class,sd.cItem_CName from @u8.SO_SOMain s inner join @u8.SO_SODetails sd on s.id = sd.id where s.cSOCode = '" + dtData.Rows[i]["SoCode"].ToString().Trim() + "' and sd.iRowNo =  " + dtData.Rows[i]["SoSeq"].ToString().Trim();
                    dtcItemCode = clsSQLCommond.ExecQuery(sSQL);
                }
                iIDDetailMe += 1;
                drOM_MOMaterials = dtOM_MOMaterials.NewRow();
                drOM_MOMaterials["MOMaterialsID"] = iIDDetailMe;

                dtData.Rows[i]["OMDeiID"] = iIDDetailMe;

                drOM_MOMaterials["MoDetailsID"] = dtData.Rows[i]["OMDeID"];
                drOM_MOMaterials["MOID"] = dtData.Rows[i]["OMID"];
                drOM_MOMaterials["cInvCode"] = dtData.Rows[i]["cInvCode"];

                //辅助基本用量/基础数量/（1-母件损耗率）*（1+子件损耗率）*换算率
                drOM_MOMaterials["iQuantity"] = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["iQuantityI"]), 6);
                drOM_MOMaterials["dRequiredDate"] = dtData.Rows[i]["StartDate2"];
                drOM_MOMaterials["iSendQTY"] = drOM_MOMaterials["iQuantity"];
                drOM_MOMaterials["fBaseQtyN"] = dtData.Rows[i]["BaseQtyN"];
                drOM_MOMaterials["fBaseQtyD"] = dtData.Rows[i]["BaseQtyD"];
                drOM_MOMaterials["fCompScrp"] = dtData.Rows[i]["CompScrap"];
                drOM_MOMaterials["bFVQty"] = 0;
                drOM_MOMaterials["iWIPtype"] = 3;
                if (dtData.Rows[i]["iSupplyType"].ToString().Trim() == "1")
                {
                    drOM_MOMaterials["iWIPtype"] = 1;
                }
                else
                {
                    drOM_MOMaterials["iWIPtype"] = 3;
                }
                drOM_MOMaterials["cWhCode"] = dtData.Rows[i]["cDefWareHouse"];
                if (dtData.Rows[i]["cDefWareHouse"] == null || dtData.Rows[i]["cDefWareHouse"].ToString().Trim() == string.Empty)
                {
                    MessageBox.Show("请定义物料‘" + dtData.Rows[i]["cInvCode"] + "’默认仓库");
                    return;
                }
                drOM_MOMaterials["iUnitQuantity"] = dtData.Rows[i]["使用数量"];
                drOM_MOMaterials["OpComponentId"] = dtData.Rows[i]["OpComponentId"];
                drOM_MOMaterials["SubFlag"] = 0;
                drOM_MOMaterials["fbasenumn"] = dtData.Rows[i]["辅助使用数量"];
                drOM_MOMaterials["iUnitNum"] = dtData.Rows[i]["辅助使用数量"];

                if (dtData.Rows[i]["辅助使用数量"] != null && dtData.Rows[i]["辅助使用数量"].ToString().Trim() != string.Empty)
                {
                    drOM_MOMaterials["iNum"] = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["iNumI"]), 6);
                    //drOM_MOMaterials["iSendNum"] = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["iNumI"]), 6);
                }

                drOM_MOMaterials["cUnitID"] = dtData.Rows[i]["unitCode2"];

                dtData.Rows[i]["OMDeIID"] = dtData.Rows[i]["OMDeiID"];

                dtOM_MOMaterials.Rows.Add(drOM_MOMaterials);

                if (!bCreateRD || (bCreateRD && dtData.Rows[i]["iSupplyType"].ToString().Trim() != "3"))
                {
                    dtOM_MOMaterials.Rows[dtOM_MOMaterials.Rows.Count - 1]["iSendNum"] = 0;
                    dtOM_MOMaterials.Rows[dtOM_MOMaterials.Rows.Count - 1]["iSendQTY"] = 0;
                    dtOM_MODetails.Rows[dtOM_MODetails.Rows.Count - 1]["iMaterialSendQty"] = 0;
                    //for (int iOM = 0; iOM < dtOM_MOMaterials.Rows.Count; iOM++)
                    //{
                    //    dtOM_MOMaterials.Rows[iOM]["iSendNum"] = 0;
                    //    dtOM_MOMaterials.Rows[iOM]["iSendQTY"] = 0;
                    //}
                    //for (int iOM = 0; iOM < dtOM_MODetails.Rows.Count; iOM++)
                    //{
                    //    dtOM_MODetails.Rows[iOM]["iMaterialSendQty"] = 0;
                    //}

                }

                if (bCreateRD)
                {
                    //-------------------------------------------------材料出库单-----------------------------------------------------------------------------------

                    if (dtData.Rows[i]["iSupplyType"].ToString().Trim() != "3")
                    {
                        siSupplyType = siSupplyType + dtData.Rows[i]["cInvCode"].ToString().Trim() + ",";
                        continue;
                    }

                    DataRow drRdRecord = null;
                    DataRow drRdRecords = null;

                    sSQL = "select * from @u8.Inventory where cInvCode = '" + dtData.Rows[i]["cInvCode"].ToString().Trim() + "'";
                    DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);
                    if (dtInv.Rows[0]["cDefWareHouse"] == null || dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() == string.Empty)
                    {
                        MessageBox.Show("请定义物料‘" + dtInv.Rows[0]["cInvCode"] + "’默认仓库");
                        return;
                    }

                    drRdRecord = dtRdRecord.NewRow();

                    if (i == 0)
                    {
                        iRDID += 1;
                        iVouN0 += 1;

                        drRdRecord["ID"] = iRDID;

                        dtData.Rows[i]["RDID"] = iRDID;

                        drRdRecord["bRdFlag"] = 0;
                        drRdRecord["cVouchType"] = 11;
                        drRdRecord["cBusType"] = "委外发料";
                        drRdRecord["cSource"] = "委外订单";
                        drRdRecord["cWhCode"] = dtData.Rows[i]["cDefWareHouse"];
                        drRdRecord["dDate"] = date1.DateTime.ToString("yyyy-MM-dd");
                        drRdRecord["cCode"] = GetRDCode(iVouN0);
                        drRdRecord["cRdCode"] = 211;
                        drRdRecord["cDepCode"] = 905;
                        drRdRecord["cVenCode"] = dtData.Rows[i]["cVenCode"];
                        drRdRecord["bTransFlag"] = 0;
                        drRdRecord["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        drRdRecord["bpufirst"] = 0;
                        drRdRecord["biafirst"] = 0;
                        drRdRecord["iMQuantity"] = dtData.Rows[i]["QtyNow"];
                        drRdRecord["VT_ID"] = 65;
                        drRdRecord["bIsSTQc"] = 0;
                        drRdRecord["cPsPcode"] = dtData.Rows[i]["InvCode"];
                        drRdRecord["bFromPreYear"] = 0;
                        drRdRecord["bIsComplement"] = 0;
                        drRdRecord["iDiscountTaxType"] = 0;
                        //drRdRecord["iBG_OverFlag"] = 0;
                        //drRdRecord["ControlResult"] = -1;
                        drRdRecord["ireturncount"] = 0;
                        drRdRecord["iverifystate"] = 0;
                        drRdRecord["iswfcontrolled"] = 0;
                        drRdRecord["dnmaketime"] = Get当前服务器时间();
                        drRdRecord["bredvouch"] = 0;
                        drRdRecord["cMpocode"] = dtData.Rows[i]["委外订单号"];

                        dtData.Rows[i]["RDID"] = drRdRecord["ID"];

                        dtRdRecord.Rows.Add(drRdRecord);

                        aList材料出库.Add(iRDID);
                    }
                    else
                    {
                        bool bRD = false;
                        for (int j = 0; j < i && j < dtRdRecord.Rows.Count; j++)
                        {
                            if ((dtRdRecord.Rows[j]["cVenCode"].ToString().Trim().ToLower() == dtData.Rows[i]["cVenCode"].ToString().Trim().ToLower() && dtRdRecord.Rows[j]["cWhCode"].ToString().Trim().ToLower() == dtData.Rows[i]["cDefWareHouse"].ToString().Trim().ToLower()))
                            {
                                bRD = true;

                                dtData.Rows[i]["RDID"] = dtRdRecord.Rows[j]["ID"];
                                break;
                            }
                        }
                        if (!bRD)
                        {
                            iRDID += 1;
                            iVouN0 += 1;

                            drRdRecord["ID"] = iRDID;

                            dtData.Rows[i]["RDID"] = iRDID;

                            drRdRecord["bRdFlag"] = 0;
                            drRdRecord["cVouchType"] = 11;
                            drRdRecord["cBusType"] = "委外发料";
                            drRdRecord["cSource"] = "委外订单";
                            drRdRecord["cWhCode"] = dtData.Rows[i]["cDefWareHouse"];
                            drRdRecord["dDate"] = date1.DateTime.ToString("yyyy-MM-dd");
                            drRdRecord["cCode"] = GetRDCode(iVouN0);
                            drRdRecord["cRdCode"] = 211;
                            drRdRecord["cDepCode"] = 905;
                            drRdRecord["cVenCode"] = dtData.Rows[i]["cVenCode"];
                            drRdRecord["bTransFlag"] = 0;
                            drRdRecord["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                            drRdRecord["bpufirst"] = 0;
                            drRdRecord["biafirst"] = 0;
                            drRdRecord["iMQuantity"] = dtData.Rows[i]["QtyNow"];
                            drRdRecord["VT_ID"] = 65;
                            drRdRecord["bIsSTQc"] = 0;
                            drRdRecord["cPsPcode"] = dtData.Rows[i]["InvCode"];
                            drRdRecord["bFromPreYear"] = 0;
                            drRdRecord["bIsComplement"] = 0;
                            drRdRecord["iDiscountTaxType"] = 0;
                            //drRdRecord["iBG_OverFlag"] = 0;
                            //drRdRecord["ControlResult"] = -1;
                            drRdRecord["ireturncount"] = 0;
                            drRdRecord["iverifystate"] = 0;
                            drRdRecord["iswfcontrolled"] = 0;
                            drRdRecord["dnmaketime"] = Get当前服务器时间();
                            drRdRecord["bredvouch"] = 0;
                            drRdRecord["cMpocode"] = dtData.Rows[i]["委外订单号"];
                            dtData.Rows[i]["RDID"] = drRdRecord["ID"];

                            dtRdRecord.Rows.Add(drRdRecord);


                            aList材料出库.Add(iRDID);

                        }
                    }
                    drRdRecords = dtRdRecords.NewRow();
                    iRDIDDetail += 1;

                    dtData.Rows[i]["RDDeID"] = iRDIDDetail;
                    drRdRecords["AutoID"] = iRDIDDetail;
                    drRdRecords["ID"] = dtData.Rows[i]["RDID"];
                    drRdRecords["cInvCode"] = dtData.Rows[i]["cInvCode"];

                    if (dtData.Rows[i]["辅助使用数量"] != null && dtData.Rows[i]["辅助使用数量"].ToString().Trim() != string.Empty)
                    {
                        drRdRecords["iNum"] = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["iNumI"]), 6);
                    }
                    drRdRecords["iQuantity"] = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["iQuantityi"]), 6);
                    drRdRecords["iFlag"] = 0;
                    //drRdRecords["iTax"] = 0;
                    drRdRecords["iSQuantity"] = 0;
                    drRdRecords["iSNum"] = 0;
                    //drRdRecords["iMoney"] = 0;
                    drRdRecords["iSOutQuantity"] = 0;
                    drRdRecords["comcode"] = dtData.Rows[i]["委外订单号"];
                    drRdRecords["iSOutNum"] = 0;
                    drRdRecords["iFNum"] = 0;
                    drRdRecords["iFQuantity"] = 0;
                    if (dtcItemCode != null && dtcItemCode.Rows.Count > 0)
                    {
                        drRdRecords["cItem_class"] = dtcItemCode.Rows[0]["cItem_class"];
                        drRdRecords["cItemCode"] = dtcItemCode.Rows[0]["cItemCode"];
                        drRdRecords["cName"] = dtcItemCode.Rows[0]["cItemName"];
                        drRdRecords["cItemCName"] = "外销订单项目";
                    }
                    //drRdRecords["iSendQuantity"] = 0;
                    //drRdRecords["iSendNum"] = 0;
                    drRdRecords["iNQuantity"] = dtData.Rows[i]["iQuantityi"];
                    if (dtData.Rows[i]["iNumI"] != null && dtData.Rows[i]["iNumI"].ToString().Trim() != "")
                        drRdRecords["iNNum"] = dtData.Rows[i]["iNumI"];
                    drRdRecords["cAssUnit"] = dtData.Rows[i]["unitCode2"];
                    //drRdRecords["iTaxRate"] = 0;
                    drRdRecords["iOMoDID"] = dtData.Rows[i]["OMDeID"];
                    drRdRecords["iOMoMID"] = dtData.Rows[i]["OMDeiID"];
                    //drRdRecords["iMatSettleState"] = 0;
                    //drRdRecords["iBillSettleCount"] = 0;
                    drRdRecords["iRSRowNO"] = 0;
                    drRdRecords["iOriTrackID"] = 0;
                    drRdRecords["bCosting"] = 1;
                    //drRdRecords["iSumBillQuantity"] = 0;
                    drRdRecords["bVMIUsed"] = 0;
                    drRdRecords["iVMISettleQuantity"] = 0;
                    drRdRecords["iVMISettleNum"] = 0;
                    //drRdRecords["iBG_Ctrl"] = 0;
                    drRdRecords["invcode"] = dtData.Rows[i]["invcode"];
                    drRdRecords["iSoType"] = 0;

                    if (drRdRecords["iQuantity"].ToString().Trim() != "" && Convert.ToDecimal(drRdRecords["iQuantity"]) != 0 && drRdRecords["iNum"].ToString().Trim() != "" && Convert.ToDecimal(drRdRecords["iNum"]) != 0)
                    {
                        drRdRecords["iinvexchrate"] = decimal.Round(Convert.ToDecimal(drRdRecords["iQuantity"]) / Convert.ToDecimal(drRdRecords["iNum"]), 8);
                    }

                    dtRdRecords.Rows.Add(drRdRecords);

                    if (bCreateRD && dtData.Rows[i]["iSupplyType"].ToString().Trim() == "3")
                    {
                        sSQL = "update @u8.OM_MODetails set iMaterialSendQty = isnull(iMaterialSendQty,0) + " + drRdRecords["iQuantity"] + " where MODetailsID = " + drRdRecords["iOMoDID"];
                        aListEnd.Add(sSQL);
                    }

                    string sNum = dtOM_MOMaterials.Rows[i]["iNum"].ToString().Trim();
                    if (sNum == string.Empty)
                        sNum = "null";
                    if (sNum == "null")
                    {
                        sSQL = "if exists(select * from @u8.CurrentStock where cWhCode = '" + dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["cInvCode"] + "') " +
                                    "update @u8.CurrentStock set iQuantity = iQuantity - " + dtOM_MOMaterials.Rows[i]["iQuantity"] + " where  cWhCode = '" + dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["cInvCode"] + "' " +
                                "else " +
                                    "insert into @u8.CurrentStock(itemid,cWhCode,cInvCode,iQuantity,iSoType)values" +
                                "(999999,'" + dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() + "','" + dtData.Rows[i]["cInvCode"] + "',-" + dtOM_MOMaterials.Rows[i]["iQuantity"].ToString().Trim() + ",1)";
                    }
                    else
                    {
                        sSQL = "if exists(select * from @u8.CurrentStock where cWhCode = '" + dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["cInvCode"] + "') " +
                                    "update @u8.CurrentStock set iQuantity = iQuantity - " + dtOM_MOMaterials.Rows[i]["iQuantity"] + ",iNum = iNum - " + sNum + " where  cWhCode = '" + dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["cInvCode"] + "' " +
                                "else " +
                                    "insert into @u8.CurrentStock(itemid,cWhCode,cInvCode,iQuantity,iNum,iSoType)values" +
                                "(999999,'" + dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() + "','" + dtData.Rows[i]["cInvCode"] + "',-" + dtOM_MOMaterials.Rows[i]["iQuantity"].ToString().Trim() + ",-" + sNum + ",1)";
                    }
                    aList.Add(sSQL);
                }
            }
            //    //----------------------------------------------------------------------------------------------------------------------------------------------

            if (dtOM_MOMain.Rows.Count < 1 || dtOM_MODetails.Rows.Count < 1)
            {
                MessageBox.Show("没有合格数据，不能生单！");
                return;
            }

            for (int i = 0; i < dtOM_MOMain.Rows.Count; i++)
            {
                //生成委外订单表头
                aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "OM_MOMain", dtOM_MOMain, i));

                if (sCode == string.Empty)
                {
                    sCode = dtOM_MOMain.Rows[i]["cCode"].ToString();
                }
                else
                {
                    sCode = sCode + ";" + dtOM_MOMain.Rows[i]["cCode"].ToString();
                }
            }
            for (int i = 0; i < dtOM_MODetails.Rows.Count; i++)
            {
                //生成委外订单表体
                aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "OM_MODetails", dtOM_MODetails, i));
            }
            for (int i = 0; i < dtOM_MOMaterials.Rows.Count; i++)
            {
                //生成委外订单用料表
                aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "OM_MOMaterials", dtOM_MOMaterials, i));
            }
            sCodeRD = "";

            if (bCanCreate && bCreateRD)
            {
                for (int i = 0; i < dtRdRecord.Rows.Count; i++)
                {
                    //生成出库单表头
                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "rdrecord11", dtRdRecord, i));

                    if (sCodeRD == string.Empty)
                    {
                        sCodeRD = dtRdRecord.Rows[i]["cCode"].ToString();
                    }
                    else
                    {
                        sCodeRD = sCodeRD + ";" + dtRdRecord.Rows[i]["cCode"].ToString();
                    }
                }
                for (int i = 0; i < dtRdRecords.Rows.Count; i++)
                {
                    //生成出库单表体
                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "rdrecords11", dtRdRecords, i));
                }
                if (iRDID >= 1000000000)
                    iRDID = iRDID - 1000000000;
                if (iRDIDDetail >= 1000000000)
                    iRDIDDetail = iRDIDDetail - 1000000000;
                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iRDID + ",iChildID=" + iRDIDDetail + " where  cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'rd'";
                aList.Add(sSQL);


                if (bVouNO)
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,cContent,cContentRule,cSeed,cNumber,bEmpty) " +
                            "values('0412','日期','月','" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouN0.ToString().Trim() + "' where  CardNumber='0412' and cSeed = '" + Convert.ToDateTime(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + "' and ccontent = '日期' ";
                    aList.Add(sSQL);
                }
            }

            if (bVouNumber)
            {
                sSQL = "insert into @u8.VoucherHistory(cardnumber,cContent,cContentRule,cSeed,cNumber,bEmpty) " +
                        "values('OM01','单据日期','月','" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "','1',0)";
                aList.Add(sSQL);
            }
            else
            {
                sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouNumber + "' where  CardNumber='OM01' and cSeed = '" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyyyMM") + "'";
                aList.Add(sSQL);
            }

            if (iID >= 1000000000)
                iID = iID - 1000000000;
            if (iIDDetail >= 1000000000)
                iIDDetail = iIDDetail - 1000000000;
            sSQL = "update UFSystem..UA_Identity set iFatherID=" + iID + ",iChildID=" + iIDDetail + " where  cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'OM_MO'";
            aList.Add(sSQL);

            if (iIDDetailMe >= 1000000000)
                iIDDetailMe = iIDDetailMe - 1000000000;
            if (iIDDetail >= 1000000000)
                iIDDetail = iIDDetail - 1000000000;
            sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDDetail + ",iChildID=" + iIDDetailMe + " where  cAcc_Id = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and cVouchType = 'OM_Materials'";
            aList.Add(sSQL);

            for (int i = 0; i < aList材料出库.Count; i++)
            {

                sSQL = "exec @u8.IA_SP_WriteUnAccountVouchForST 'aaaaaaaa',N'11'";
                sSQL = sSQL.Replace("aaaaaaaa", aList材料出库[i].ToString());
                aList.Add(sSQL);
            }

            bool bRun = true;
            if (sErr.Trim() != "")
            {
                DialogResult d = MessageBox.Show("存在如下错误，是否继续？\n" + sErr, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                    bRun = true;
                else
                    bRun = false;
            }

            for (int iAlist = 0; iAlist < aListEnd.Count; iAlist++)
            {
                aList.Add(aListEnd[iAlist]);
            }

            if (bRun)
            {
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    gridControl1.DataSource = null;
                    dtTable.Rows.Clear();

                    FrmMsgBox fMsgBox = new FrmMsgBox();
                    fMsgBox.Text = "生成委外订单成功！";
                    if (siSupplyType.Trim() != "")
                    {
                        siSupplyType = "非领用物料，不能生成材料出库单：" + siSupplyType;
                    }
                    fMsgBox.richTextBox1.Text = "委外订单号：" + sCode + "\n" + "材料出库单：" + sCodeRD + "\n" + siSupplyType;
                    fMsgBox.ShowDialog();

                    try
                    {
                        frmMail.sDO = "您已有新的订单，请注意查收";
                        frmMail.FrmMailListSend_Load(null, null);
                        frmMail.btnOK_Click(null, null);
                        //frmMail.ShowDialog();
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("没有数据生成单据！");
                }
            }
        }
        

        private string GetcCode(string s)
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
            return "AM" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + s;
        }

        private void btnDel()
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                string siID = gridView1.GetRowCellValue(iRow, gridColiID).ToString().Trim();
                for (int i = gridView1.RowCount-1; i >=0; i--)
                {
                    if (gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() == siID)
                    {
                        gridView1.DeleteRow(i);
                    }
                }
            }
            catch { }
        }

        private void GetiSupplyType()
        {
            //1入库/2工序/3领料/4虚拟
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "iText";
            dt.Columns.Add(dc);

            DataRow dr = dt.NewRow();
            dr["iID"] = "1";
            dr["iText"] = "入库倒冲";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["iID"] = "3";
            dr["iText"] = "领用";
            dt.Rows.Add(dr);


            lookUpEditiChange.Properties.DataSource = dt;
            lookUpEditiChange.Properties.ReadOnly = false;
            ItemLookUpEditiSupplyType.DataSource = dt;
        }
        DataTable dtTable;
        //DataTable dtTemp;
        private void FFrmOMPlanDayCreate_Load(object sender, EventArgs e)
        {
            lookUpEditWareHouse.Enabled = false;
            lookUpEditWareHouse.Properties.ReadOnly = false;
            ItemLookUpEditWoreHouse.ReadOnly = false;
            gridColiQuantityI.OptionsColumn.AllowEdit = false;
            gridColiNumI.OptionsColumn.AllowEdit = false;
            GetWareHouse();
            txtBarCode.Focus();

            date1.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            date1.Properties.ReadOnly = false;

            try
            {
                GetiSupplyType();

                //GetcWhCode();

                //必须与后续条码扫描的字段顺序一致 cast(o.QtyNow as decimal(18, 6))
                string sSQL ="select 0 as iRow,'' AS bChoose, o.ID, o.cCode, o.iID, o.Soid, o.sodid, o.SoCode, o.SoSeq, o.PlanCode, o.InvCode, o.InvName, o.InvStd, o.ComUnitCode, o.ComUnitName, " +
                                      "o.PlanQty, ISNULL(oI.Qty, 0) AS DidQty, cast(o.QtyNow as decimal(18, 6)) as QtyNow , o.StartDate2, o.DueDate2, o.date1, o.date2, o.cVenCode, o.cVenCode as cVenCodeOLD,o.cVenName, " +
                                      "o.iTaxPrice, o.iTaxRate, o.Accid, o.AccYear, o.cAssComUnitCode, o.CompScrap, o.BaseQtyD, o.BaseQtyN, o.bomID, o.cDefWareHouse, o.ParentScrap,  " +
                                      "o.cInvCode, o.cInvName, o.cInvStd, o.iSupplyType, o.OpComponentid, o.ChangeRate, o.UseQty, o.UseNum, o.cComUnitCodeI, o.cAssComUnitCodeI,  " +
                                      "o.unitCode1, o.unitCode2, o.iQuantityI, o.iNumI, o.bUse, o.使用数量, o.辅助使用数量, o.invSZ, o.invSM ,isnull(i.fInExcess,0) as fInExcess,c.iQuantity as CurrQtyI,c.iNum as CurrNumI,null as iSendT " +
                            "from UFDLImport..OMPlanDay o " +
                                " left join (select SUM(o.iQuantity) as Qty,OMPlanID from UFDLImport..OMPlan_Import om inner join  @u8.OM_MODetails o on o.MODetailsID = om.OM_MODetailsID and accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' group by OMPlanID) oI on o.iID = oI.OMPlanID " +
                                " left join @u8.Inventory i on i.cInvCode = o.InvCode " +
                                " left join (select cInvCode,cWhCode,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum from @u8.CurrentStock group by cInvCode,cWhCode) c on c.cInvCode = o.cInvCode and c.cWhCode = o.cDefWareHouse " +
                            "where 1=-1";
                   
                dtTable = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dtTable;

                txtBarCode.Enabled = true;
                txtBarCode.ReadOnly = false;

                dtVenPrice = clsPrice.GetPrice(2);

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！原因：" + ee.Message);
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
            dEditor2.KeyDown += new KeyEventHandler(dEditor2_KeyDown);
            dEditor2.Leave += new EventHandler(dEditor2_Leave);
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

        void CreateMergetEditControl()
        {
            try
            {
                tEditor = new DevExpress.XtraEditors.TextEdit();
                tEditor.Location = new System.Drawing.Point(12, 12);
                tEditor.Name = "txtEdit";
                tEditor.Properties.Appearance.Options.UseTextOptions = true;
                tEditor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                tEditor.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                tEditor.Properties.AutoHeight = false;
                //tEditor.Properties.Mask.EditMask =
                tEditor.Properties.DisplayFormat.FormatString = "n2";
                tEditor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                tEditor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric; 
                tEditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                tEditor.KeyDown += new KeyEventHandler(tEditor_KeyDown);
                tEditor.Leave += new EventHandler(tEditor_Leave);
                tEditor.Enter += new EventHandler(tEditor_Enter);
            }
            catch { }
        }

        void tEditor_Enter(object sender, EventArgs e)
        {
            TextEdit obj = sender as TextEdit;
            obj.SelectAll();
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

        void CreateMergebEditControl()
        {
            try
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
        void dEditor2_KeyDown(object sender, KeyEventArgs e)
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


        void bEditor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                    iRow = gridView1.FocusedRowHandle;

                string sInvCode = gridView1.GetRowCellDisplayText(iRow, gridColInvCode).ToString().Trim();

                FrmVenHavPriceInfo fVen = new FrmVenHavPriceInfo(sInvCode,2);
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
                    //m_mergedCellsEdited = null;
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

                try
                {
                    GridViewInfo vInfo = view.GetViewInfo() as GridViewInfo;
                    GridCellInfo cInfo = vInfo.GetGridCellInfo(hInfo);
                    m_mergedCellsEdited = ((GridMergedCellInfo)cInfo).MergedCells;
                }
                catch { m_mergedCellsEdited = null; }
                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
                {
                    if (m_mergedCellsEdited != null)
                    {
                        gridControl1.Controls.Remove(tEditor);
                        foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                        {
                            gridView1.SetRowCellValue(cellInfo.RowHandle, gridColbChoose, "√");
                        }
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridColbChoose, "√");
                    }
                }
                else
                {
                    //if (hInfo.InRowCell)
                    if (m_mergedCellsEdited != null)
                    {
                        gridControl1.Controls.Remove(tEditor);
                        foreach (GridCellInfo cellInfo in m_mergedCellsEdited)
                        {
                            gridView1.SetRowCellValue(cellInfo.RowHandle, gridColbChoose, "");
                        }
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridColbChoose, "");
                    }
                }
            }
            catch (Exception ee)
            { }
        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColcDefWareHouse)
                {
                    string sCode = gridView1.GetRowCellValue(e.RowHandle, gridColcDefWareHouse).ToString().Trim();
                    string sSQL = "select cInvCode,cWhCode,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum from @u8.CurrentStock where cWhCode = '" + gridView1.GetRowCellValue(e.RowHandle, gridColcDefWareHouse).ToString().Trim() + "' and  cInvCode = '" + gridView1.GetRowCellValue(e.RowHandle, gridColcInvCode).ToString().Trim() + "' group by cInvCode,cWhCode";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (Convert.ToDouble( dt.Rows[0]["iQuantity"]) != 0)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridColCurrQtyI, dt.Rows[0]["iQuantity"].ToString().Trim());
                        }
                        else
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridColCurrQtyI, DBNull.Value);
                        }
                        if (Convert.ToDouble(dt.Rows[0]["iNum"]) != 0)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridColCurrNumI, dt.Rows[0]["iNum"].ToString().Trim());
                        }
                        else
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridColCurrNumI, DBNull.Value);
                        }
                    }
                    else
                    {
                        gridView1.SetRowCellValue(e.RowHandle, gridColCurrQtyI, DBNull.Value);
                        gridView1.SetRowCellValue(e.RowHandle, gridColCurrNumI, DBNull.Value);
                    }
                }

                if (e.Column == gridColQtyNow)
                {
                    double d1 = 0;
                    if (Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColQtyNow)) == 0)
                        return;

                    if (gridView1.GetRowCellValue(e.RowHandle, gridColQtyNow).ToString().Trim() != "")
                    {
                        d1 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColQtyNow));
                    }
                    double d2 = 0;
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColPlanQty).ToString().Trim() != "")
                    {
                        d2 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColPlanQty));
                    }
                    double d3 = 0;
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColfInExcess).ToString().Trim() != "")
                    {
                        d3 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColfInExcess));
                    }
                    double d4 = 0;
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColDidQty).ToString().Trim() != "")
                    {
                        d4 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColDidQty));
                    }
                    if ((d1 + d4) > (1 + d3) * d2)
                    {
                        long l = Convert.ToInt64(gridView1.GetRowCellValue(e.RowHandle, gridColiID));
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (l == Convert.ToInt64(gridView1.GetRowCellValue(i, gridColiID)))
                            {
                                gridView1.SetRowCellValue(i, gridColQtyNow, 0);
                            }
                        }
                        MessageBox.Show("超限额！");
                    }
                }
                
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

                    //gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, "√");
                }
                if (e.Column == gridView1.Columns["iNumI"] && radioNum.Checked)
                {

                    decimal d = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ChangeRate"])), 6);
                    decimal d1 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["使用数量"])), 6);
                    decimal d3 = decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["iNumI"])), 6);

                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["iQuantityI"], decimal.Round(d * d3, 6));

                    gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["QtyNow"], decimal.Round(d * d3 / d1, 0));

                    //gridView1.SetRowCellValue(e.RowHandle, gridColbChoose, "√");
                }

                if (radioParent.Checked && e.Column == gridView1.Columns["QtyNow"] )
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

        private bool ChkNumber(object oNum)
        {
            bool b = false;
            try
            {
                if (oNum.ToString().Trim() != string.Empty)
                {
                    double d = Convert.ToDouble(oNum);
                }

                b = true;
            }
            catch
            { }
            return b;
        }


        private void GetcWhCode()
        {
            //string sSQL = "select cWhCode,cWhName from @u8.Warehouse  order by cWhCode";
            //DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        }

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtBarCode.Text.Trim() == string.Empty)
                {
                    return;
                }

                
                if (e.KeyCode == Keys.Enter)
                {
                    string[] s = txtBarCode.Text.Trim().Split('-');

                    string sBarCode = s[0].Trim();


                    string sSQL = "select * from UFDLImport..OMPlanDay where bUse = 1 and accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and [ID] = " + sBarCode;
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    string sCode = "";
                    string sID = "";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        sCode = dt.Rows[0]["cCode"].ToString().Trim();
                        sID = dt.Rows[0]["iID"].ToString().Trim();
                    }
                    else
                    {
                        MessageBox.Show("该条码不存在，请核实！");
                        return;
                    }

                    sSQL = "select cast (null as decimal(18,0)) as iRow,'' AS bChoose, o.ID, o.cCode, o.iID, o.Soid, o.sodid, o.SoCode, o.SoSeq, o.PlanCode, o.InvCode, o.InvName, o.InvStd, o.ComUnitCode, o.ComUnitName, " +
                                      "o.PlanQty, ISNULL(oI.Qty, 0) AS DidQty, cast((o.PlanQty - ISNULL(a.iQty, 0)) as decimal(18, 6)) as QtyNow, o.StartDate2, o.DueDate2, o.date1, o.date2, o.cVenCode,o.cVenCode as cVenCodeOLD,v.cVenName, " +
                                      "cast (null as decimal(18,6)) as iTaxPrice, cast (null as decimal(18,6)) as iTaxRate, o.Accid, o.AccYear, o.cAssComUnitCode, o.CompScrap, o.BaseQtyD, o.BaseQtyN, o.bomID, o.cDefWareHouse, o.ParentScrap,  " +
                                      "o.cInvCode, o.cInvName, o.cInvStd, 3 as iSupplyType, o.OpComponentid, o.ChangeRate, o.UseQty, o.UseNum, o.cComUnitCodeI, o.cAssComUnitCodeI,  " +
                                      "o.unitCode1, o.unitCode2, (cast((o.PlanQty - ISNULL(a.iQty, 0)) as decimal(18, 6)) * o.使用数量) as iQuantityI,  (cast((o.PlanQty - ISNULL(a.iQty, 0)) as decimal(18, 6)) * o.辅助使用数量) as iNumI, o.bUse, o.使用数量, o.辅助使用数量, o.invSZ, o.invSM ,isnull(i.fInExcess,0) as fInExcess,c.iQuantity as CurrQtyI,c.iNum as CurrNumI,a.iQty as iSendT " +
                            "from UFDLImport..OMPlanDay o " +
                                " left join @u8.Vendor v on v.cVenCode = o.cVenCode " +
                                " left join (select SUM(o.iQuantity) as Qty,OMPlanID from UFDLImport..OMPlan_Import om inner join  @u8.OM_MODetails o on o.MODetailsID = om.OM_MODetailsID and accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' group by OMPlanID) oI on o.iID = oI.OMPlanID " +
                                " left join @u8.Inventory i on i.cInvCode = o.InvCode " +
                                " left join (select cInvCode,cWhCode,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum from @u8.CurrentStock group by cInvCode,cWhCode) c on c.cInvCode = o.cInvCode and c.cWhCode = o.cDefWareHouse " +
                                //" left join (select OMPlanID,min(iQty) as iQty from (select oI.OMPlanID,od.cInvCode,sum(odM.iSendQTY/cast((odM.iQuantity/od.iQuantity) as decimal(18,6))) as iQty from @u8.OM_MODetails od inner join @u8.OM_MOMaterials odM on od.MoDetailsID = odM.MODetailsID inner join @u8.OM_MOMain o on o.MOID = od.MOID inner join UFDLImport.dbo.OMPlan_Import oI on oI.OM_MODetailsID = od.MoDetailsID and accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' group by od.cInvCode,oI.OMPlanID,odm.cInvCode ) a group by OMPlanID) a on a.OMPlanID = o.iID " +
                                " left join (select a.OMPlanID,sum(b.Qty) as iQty from UFDLImport..OMPlan_Import a inner join (select min(iSendQTY/iUnitQuantity) as Qty,b.MODetailsID from @u8.OM_MODetails b inner join @u8.OM_MOMaterials  c on c.MoDetailsID = b.MODetailsID where c.iWIPtype = 3 group by b.MODetailsID) b on a.OM_MODetailsID = b.MODetailsID and a.accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and a.accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' where isnull(a.OMPlanID,0) <> 0 group by a.OMPlanID) a on a.OMPlanID = o.iID " +
                            "where bUse = 1 and accid = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3) + "' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and o.[iID] = " + sID + " and o.cCode = '" + sCode + "' ";
                    dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count < 1)
                    {
                        MessageBox.Show("数据错误，请检查！");
                        return;
                    }
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataTable dtVP = GetVendPriceInfo(dt.Rows[j]["invCode"].ToString().Trim(), dt.Rows[j]["cVenCode"].ToString().Trim());
                        if (dtVP != null && dtVP.Rows.Count > 0)
                        {
                            dt.Rows[j]["iTaxPrice"] = dtVP.Rows[0]["iTaxPrice"];
                            dt.Rows[j]["iTaxRate"] = dtVP.Rows[0]["iTaxRate"];
                        }
                    }

                    #region 根据条码打印中的可委外数量生成下单数量（只针对一对一情况）

                    if (s.Length > 1)
                    {
                        decimal d1 = decimal.Round(Convert.ToDecimal(dt.Rows[0]["使用数量"]), 6);
                        decimal d2 = decimal.Round(decimal.Parse(s[1].Trim()), 6);
                        dt.Rows[0]["iQuantityI"] = d2;
                        if (dt.Rows[0]["ChangeRate"].ToString().Trim() == "" || Convert.ToDouble(dt.Rows[0]["ChangeRate"]) == 0)      //判断是否单计量单位
                        {
                            dt.Rows[0]["QtyNow"] = decimal.Round(d2 / d1, 0);
                        }
                        else
                        {
                            decimal d = decimal.Round(Convert.ToDecimal(dt.Rows[0]["ChangeRate"]), 6);

                            dt.Rows[0]["QtyNow"] = decimal.Round(d2 / d1, 0);
                            dt.Rows[0]["iNumI"] = decimal.Round(d2 / d, 6);
                        }

                    }

                    #endregion
                        
                    bool bHav = false;
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        if (dtTable.Rows[i]["ID"].ToString().Trim() == sBarCode)
                        {
                            bHav = true;
                            break;
                        }
                    }

                    if (!bHav)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            DataRow dr = dtTable.NewRow();

                            for (int i = 0; i < dtTable.Columns.Count; i++)
                            {
                                dr[dtTable.Columns[i].ColumnName.Trim()] = dt.Rows[j][dtTable.Columns[i].ColumnName.Trim()];
                            }
                            string sVenCode = dr["cVenCode"].ToString().Trim();
                            string sInvCode = dr["InvCode"].ToString().Trim();
                            DataTable dtPrice = GetVendPriceInfo(sInvCode, sVenCode);
                            if (dtPrice != null && dtPrice.Rows.Count > 0)
                            {
                                dr["iTaxPrice"] = dtPrice.Rows[0]["iTaxPrice"];
                                dr["iTaxRate"] = dtPrice.Rows[0]["iTaxRate"];
                            }
                            dtTable.Rows.Add(dr);
                            DataView dv = dtTable.DefaultView;

                            dtTable = dv.ToTable();
                            for (int ii = 1; ii < dtTable.Rows.Count + 1; ii++)
                            {
                                dtTable.Rows[ii - 1]["iRow"] = ii;
                            }
                            gridControl1.DataSource = dtTable;
                        }
                    }
                    else
                    {
                        MessageBox.Show("本条码已经扫描！");
                    }
                    gridColiQuantityI.OptionsColumn.AllowEdit = true;
                    //gridColiNumI.OptionsColumn.AllowEdit = false;
                    txtBarCode.Text = "";
                    txtBarCode.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("条码输入失败！ \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataView dv = new DataView(dtVenPrice);
                dv.RowFilter = " cInvCode = '" + p + "' and cVenCode = '" + sVend + "' ";
                return dv.ToTable();
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商物料信息失败！\n  " + ee.Message);
            }
        }

        private string GetRDCode(long iCode)
        {
            string sVouNumber = iCode.ToString().Trim();
            for (int i = 0; i < 10; i++)
            {
                if (sVouNumber.Length < 4)
                {
                    sVouNumber = "0" + sVouNumber;
                }
                else
                {
                    break;
                }
            }
            return "OP" + DateTime.Parse(date1.DateTime.ToString("yyyy-MM-dd")).ToString("yyMM") + sVouNumber;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (chkiChange.Checked)
                {
                    gridView1.SetRowCellValue(i, gridColiSupplyType, lookUpEditiChange.EditValue);
                }
                if (chkWH.Checked)
                {
                    gridView1.SetRowCellValue(i, gridColcDefWareHouse, lookUpEditWareHouse.EditValue);
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;
            //string sVenCode = gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["cVenCodeOLD"]).ToString().Trim();
            //if (sVenCode == "98" || sVenCode == "" || sVenCode == "" || sVenCode == "0487" || sVenCode == "0462" || sVenCode == "0482" || sVenCode == "0415")
            //{
            //    gridColcVenCode.OptionsColumn.AllowEdit = true;
            //}
            //else
            //{
            //    gridColcVenCode.OptionsColumn.AllowEdit = false;
            //}

            string s = gridView1.GetRowCellValue(e.FocusedRowHandle, gridView1.Columns["ChangeRate"]).ToString().Trim().ToLower();//53
            if (s == "")
            {
                gridColiNumI.OptionsColumn.AllowEdit = false;
            }
            else
            {
                gridColiNumI.OptionsColumn.AllowEdit = gridColiQuantityI.OptionsColumn.AllowEdit;
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
        }

        private void GetWareHouse()
        {
            string sSQL = "select cWhCode,cWhName,bFreeze from @u8.Warehouse where bFreeze = 0 order by cWhCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditWoreHouse.DataSource = dt;
            lookUpEditWareHouse.Properties.DataSource = dt;
        }

        private void chkWH_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWH.Checked)
            {
                lookUpEditWareHouse.Enabled = true;
            }
            else
            {
                lookUpEditWareHouse.Enabled = false;
            }
        }

        private void chkiChange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkiChange.Checked)
            {
                lookUpEditiChange.Enabled = true;
            }
            else
            {
                lookUpEditiChange.Enabled = false;
            }
        }

        private void ItemButtonEditcvenCode_EditValueChanged(object sender, EventArgs e)
        {

            double d1 = 0;
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColQtyNow).ToString().Trim() != "")
            {
                d1 = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColQtyNow));
            }
            double d2 = 0;
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColPlanQty).ToString().Trim() != "")
            {
                d2 = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColPlanQty));
            }
            double d3 = 0;
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColfInExcess).ToString().Trim() != "")
            {
                d3 = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColfInExcess));
            }
            double d4 = 0;
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColDidQty).ToString().Trim() != "")
            {
                d4 = Convert.ToDouble(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColDidQty));
            }
            if ((d1 + d4) > (1 + d3) * d2)
            {
                //int iRow = e.Row
                MessageBox.Show("超限额！");
                //gridView1.SetRowCellValue(e.RowHandle, gridColQtyNow, "");
                //gridView1.FocusedColumn = 
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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
    }
}