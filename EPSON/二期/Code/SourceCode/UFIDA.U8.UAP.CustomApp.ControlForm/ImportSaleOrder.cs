using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class ImportSaleOrder : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
                dateEdit1.DateTime = DateTime.Today;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public ImportSaleOrder()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

                    long lID = -1;
                    long lIDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'Somain',1,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDDetails.ToString());
                    sSQL = sSQL.Replace("dddddd", sAccID);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                    ////获得单据号
                    sSQL = "select * from VoucherHistory with (ROWLOCK) Where CardNumber='17' AND cContentRule = 'YYYY' AND cSeed = 'aaaaaa'";
                    sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.ToString("yyyy"));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lCode = 0;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                    }
                    else
                    {
                        lCode = 0;
                    }

                    ArrayList aList = new ArrayList();

                    string s销售订单号  = "";
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridView1.Columns["choose"])))
                            continue;

                        bool bExists = false;

                        string s客户订单号 = gridView1.GetRowCellValue(i, gridView1.Columns["custpo"]).ToString().Trim();
                        //判断本次是否已经导入
                        for (int j = 0 ; j < aList.Count; j++)
                        {
                            if (s客户订单号 == aList[j].ToString().Trim())
                            {
                                bExists = true;
                                break;
                            }
                        }

                        if (bExists)
                        {
                            continue;
                        }
                        else
                        {
                            aList.Add(s客户订单号);
                        }

                        //string sDODate = gridView1.GetRowCellValue(i, gridView1.Columns["DODate"]).ToString().Trim();
                        //if (sDODate.Length < 8)
                        //{
                        //    sErr = sErr + "row " + (i+1).ToString() + " DODate err\n";
                        //    continue;
                        //}
                        //sDODate = sDODate.Substring(0, 4) + "-" + sDODate.Substring(4, 2) + "-" + sDODate.Substring(6, 2);
                        DateTime dtm单据日期 = BaseFunction.ReturnDate(dateEdit1.DateTime.ToString("yyyy-MM-dd"));

                        int iYear = dtm单据日期.Year;
                        int iPeriod = dtm单据日期.Month;
                        //BaseFunction.ReturniYPeriod(dtm单据日期.Year, dtm单据日期.Month, out iYear, out iPeriod);
                        string s期间 = BaseFunction.ReturnDate(iYear.ToString() + "-" + iPeriod.ToString() + "-01").ToString("yyyyMM");
                        sSQL = "select isnull(bflag_SA,0) as bflag from GL_mend where iYPeriod = '" + s期间 + "'";
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            throw new Exception("Access module state failure");
                        }
                        int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                        if (i结账 > 0)
                        {
                            throw new Exception(dtm单据日期.ToString("yyyy-MM") + " have checked out");
                        }

                        int iCouRow = gridView1.RowCount;

                        UFIDA.U8.UAP.CustomApp.ControlForm.Model.SO_SOMain model = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.SO_SOMain();
                        lID += 1;

                        model.dDate = dtm单据日期;

                        lCode += 1;

                        string sCusCode = gridView1.GetRowCellValue(i, gridView1.Columns["custcode"]).ToString().Trim();
                        sSQL = @"
select a.*,b.cTax 
from Customer a  left join AS_GSTTypeFile b on a.cCusDefine1 = b.cNo
where a.cCusCode = '" + sCusCode + "'";
                        DataTable dtCustomer = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtCustomer == null || dtCustomer.Rows.Count == 0)
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + " CustCode err\n";
                            continue;
                        }
                        if (dtCustomer.Rows[0]["cTax"].ToString().Trim() == "")
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + " tax err\n";
                            continue;
                        }

                        model.cCusCode = sCusCode;

                        sSQL = "select * from SaleType where cSTCode = '" + dtCustomer.Rows[0]["ccusdefine5"].ToString().Trim() + "'";
                        DataTable dtSaleType = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtSaleType == null || dtSaleType.Rows.Count == 0)
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + " Please set  SaleType\n";
                            continue;
                        }
                        model.cSTCode = dtSaleType.Rows[0]["cSTCode"].ToString().Trim();

                        string sCode = lCode.ToString();
                        while (sCode.Length < 6)
                        {
                            sCode = "0" + sCode;
                        }
                        sCode = "SO" + dtm单据日期.ToString("yyyy") + sCode;
                        model.cSOCode = sCode;

                        if (s销售订单号 == "")
                        {
                            s销售订单号 = model.cSOCode;
                        }
                        else
                        {
                            s销售订单号 =s销售订单号 + "," + model.cSOCode;
                        }

                        sSQL = "select * from Department where isnull(bDepEnd ,0) = 1 and cDepCode = '" + dtCustomer.Rows[0]["cCusDepart"] + "' order by cDepCode";
                        DataTable dtDep = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtDep == null || dtDep.Rows.Count == 0)
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + "Please set department err\n";
                            continue;
                        }
                        model.cDepCode = dtDep.Rows[0]["cDepCode"].ToString().Trim();  //需要默认值
                        //model.cPersonCode;
                        //model.cSCCode;
                        model.cCusOAddress = dtCustomer.Rows[0]["cCusAddress"].ToString().Trim();
                        model.cPayCode = dtCustomer.Rows[0]["cCusPayCond"].ToString().Trim();
                        if (model.cPayCode == "")
                        {
                            sErr = sErr + "row " + (i + 1).ToString() + " Please set paycode\n";
                            continue;
                        }

                        string sExchName = dtCustomer.Rows[0]["cCusExch_name"].ToString().Trim();
                        if (sExchName == "")
                        {
                            model.cexch_name = "SGD";           //默认币种
                        }
                        else
                        {
                            sSQL = "SELECT * FROM foreigncurrency WHERE cexch_code = 'aaaaaa' OR cexch_name = 'aaaaaa' ";
                            sSQL = sSQL.Replace("aaaaaa", sExchName);
                            DataTable dtCurrency = DbHelperSQL.Query(sSQL);

                            model.cexch_name = dtCurrency.Rows[0]["cexch_name"].ToString().Trim();
                        }
                        if (model.cexch_name.ToLower() == "sgd")
                        {
                            model.iExchRate = 1;                
                                            
                        }
                        else
                        {
                            sSQL = "SELECT * FROM exch WHERE iYear = aaaaaa AND iperiod = bbbbbb AND (cexch_name = 'cccccc' or cexch_name = 'cccccc')";
                            sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.Year.ToString());
                            sSQL = sSQL.Replace("bbbbbb", dateEdit1.DateTime.Month.ToString());
                            sSQL = sSQL.Replace("cccccc", model.cexch_name);
                            DataTable dtexch = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtexch == null || dtexch.Rows.Count == 0 || BaseFunction.ReturnDecimal(dtexch.Rows[0]["nflat"].ToString().Trim()) == 0)
                            {
                                sErr = sErr + "row " + (i + 1).ToString() + "Please set exchange rate err\n";
                                continue;
                            }

                            model.iExchRate = BaseFunction.ReturnDecimal(dtexch.Rows[0]["nflat"].ToString().Trim());
                        }
                        model.iTaxRate = BaseFunction.ReturnDecimal(dtCustomer.Rows[0]["cTax"]);
                        //model.iMoney;
                        model.cMemo = gridView1.GetRowCellValue(i, gridView1.Columns["remark1"]).ToString().Trim();
                        model.iStatus = 1;
                        model.cMaker = sUserName;
                        model.cVerifier = sUserName;
                        //model.cCloser;
                        model.bDisFlag = false;
                        //model.cDefine1;
                        model.cDefine2 = gridView1.GetRowCellValue(i, gridView1.Columns["custinvoice"]).ToString().Trim();
                        model.cDefine3 = gridView1.GetRowCellValue(i, gridView1.Columns["custpo"]).ToString().Trim();
                        model.cDefine4 = BaseFunction.ReturnDate(gridView1.GetRowCellValue(i, gridView1.Columns["custinvoicedate"]));
                        //model.cDefine5;
                        model.cDefine6 = dtm单据日期;
                        //model.cDefine7;
                        //model.cDefine8;
                        //model.cDefine9;
                        model.cDefine10 = gridView1.GetRowCellValue(i, gridView1.Columns["dono"]).ToString().Trim();
                        model.bReturnFlag = false;
                        model.cCusName = dtCustomer.Rows[0]["cCusName"].ToString().Trim();
                        model.bOrder = false;
                        model.ID = lID;
                        model.iVTid = 95;
                        //model.cChanger = DBNull.Value;
                        model.cBusType = "普通销售";
                        //model.cCreChpName; 
                        //model.cDefine11; 
                        //model.cDefine12; 
                        //model.cDefine13; 
                        //model.cDefine14; 
                        //model.cDefine15; 
                        //model.cDefine16;

                        //model.coppcode;
                        //model.cLocker; 
                        model.dPreMoDateBT = dtm单据日期;    //需要默认值
                        model.dPreDateBT = dtm单据日期;      //需要默认值
                        //model.cgatheringplan; 
                        //model.caddcode; 
                        model.iverifystate = 0;
                        //model.ireturncount;
                        model.iswfcontrolled = 0;
                        //model.icreditstate; 
                        //model.cmodifier; 
                        //model.dmoddate; 
                        model.dverifydate = dNowDate;
                        //model.ccusperson;
                        //model.dcreatesystime; 
                        model.dverifysystime = dNow;
                        //model.dmodifysystime;
                        //model.iflowid; 
                        model.bcashsale = false;
                        //model.cgathingcode; 
                        //model.cChangeVerifier;
                        //model.dChangeVerifyDate; 
                        //model.dChangeVerifyTime;
                        //model.outid;
                        //model.ccuspersoncode;
                        //model.dclosedate; 
                        //model.dclosesystime; 
                        //model.iPrintCount; 
                        //model.fbookratio; 
                        //model.bmustbook;
                        //model.fbooksum; 
                        //model.fbooknatsum;
                        //model.fgbooksum;
                        //model.fgbooknatsum;
                        //model.csvouchtype;
                        //model.cCrmPersonCode; 
                        //model.cCrmPersonName; 
                        //model.cMainPersonCode;
                        //model.cSysBarCode;
                        //model.ioppid;
                        //model.optnty_name;
                        //model.cCurrentAuditor; 
                        model.contract_status = 1;
                        //model.csscode; 
                        model.cinvoicecompany = dtCustomer.Rows[0]["cCusCode"].ToString().Trim();
                        //model.cAttachment;

                        UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SO_SOMain dal = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SO_SOMain();
                        sSQL = dal.Add(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        for (int j = i; j < gridView1.RowCount; j++)
                        {
                            if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(j, gridView1.Columns["choose"])))
                                continue;

                            //                        //判断是否历史导入
                            string s_LotNo = gridView1.GetRowCellValue(j, gridView1.Columns["lotno"]).ToString().Trim();
                            if (s_LotNo != "")
                            {
                                sSQL = @"
select *
from SO_SOMain a inner join SO_SOdetails b on a.ID = b.ID
where cDefine28 = 'aaaaaa' AND ISNULL(b.cSCloser,'') = ''
";
                                sSQL = sSQL.Replace("aaaaaa", s_LotNo);
                                dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    sErr = sErr + "row " + (j + 1).ToString() + " lotno is exists \n";
                                    continue;
                                }
                            }

                            string s客户订单号2 = gridView1.GetRowCellValue(j, gridView1.Columns["custpo"]).ToString().Trim();
                            if (s客户订单号 != s客户订单号2)
                                continue;

                            UFIDA.U8.UAP.CustomApp.ControlForm.Model.SO_SODetails models = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.SO_SODetails();

                            lIDDetails += 1;
                            models.AutoID = lIDDetails;
                            models.cSOCode = model.cSOCode;

                            sSQL = "select * from Inventory where cInvCode = '" + gridView1.GetRowCellValue(j, gridView1.Columns["itemno"]).ToString().Trim() + "'";
                            DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtInv == null || dtInv.Rows.Count == 0)
                            {
                                sErr = sErr + "row " + (j + 1).ToString() + " Item No err\n";
                                continue;
                            }

                            //按照销售类型 = 存货大类 判断是否允许导入
                            //if (dtInv.Rows[0]["cinvccode"].ToString().Trim() != model.cSTCode)
                            //{
                            //    sErr = sErr + "row " + (j + 1).ToString() + " Item No saletype err\n";
                            //    continue; 
                            //}
                            models.cInvCode = dtInv.Rows[0]["cInvCode"].ToString().Trim();

                            string sDODate2 = gridView1.GetRowCellValue(j, gridView1.Columns["dodate"]).ToString().Trim();
                            int iDays = BaseFunction.ReturnInt(dtInv.Rows[0]["iInvAdvance"]);
                            if (sDODate2.Length >= 8)
                            {
                                sDODate2 = sDODate2.Substring(0, 4) + "-" + sDODate2.Substring(4, 2) + "-" + sDODate2.Substring(6);

                                models.dPreDate = model.dDate.AddDays(iDays);    //需要默认值
                            }
                            else
                            {
                                models.dPreDate = DateTime.Today.AddDays(iDays);
                            }
                            models.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridView1.Columns["delqty"]));
                            if (models.iQuantity == 0)
                            {
                                sErr = sErr + "row " + (j + 1).ToString() + " DelQty err\n";
                                continue;
                            }

                            //价格需要设置

                            decimal diSalecost = 0;
                            decimal d价格 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridView1.Columns["price"]), 6);
                            if (d价格 <= 0)
                            {
                                sErr = sErr + "row " + (j + 1).ToString() + " no price\n";
                                continue;
                            }

                            models.iQuotedPrice = d价格;
                            models.iUnitPrice = d价格;
                            models.iTaxUnitPrice = d价格 * (1 + model.iTaxRate/100);
                            models.iMoney = models.iUnitPrice * models.iQuantity;
                            models.iSum = models.iTaxUnitPrice * models.iQuantity;
                            models.iTax = models.iSum - models.iMoney;
                            //models.iDisCount; 
                            models.iNatUnitPrice = models.iUnitPrice * model.iExchRate;
                            models.iNatMoney = models.iNatUnitPrice * models.iQuantity;
                            models.iNatSum = models.iNatMoney * (1 + model.iTaxRate/100);
                            models.iNatTax = models.iNatSum - models.iNatMoney;


                            models.fSaleCost = diSalecost;
                            models.fSalePrice = diSalecost * models.iQuantity;

                            //models.iNatDisCount; 
                            //models.iFHNum; 
                            //models.iFHQuantity; 
                            //models.iFHMoney;
                         
                            //models.iDisCount=0;
                       
                            //models.iNatDisCount; 
                            //models.iFHNum; 
                            //models.iFHQuantity; 
                            //models.iFHMoney;
                            //models.iKPQuantity; 
                            //models.iKPNum; 
                            //models.iKPMoney; 
                            models.cMemo = gridView1.GetRowCellValue(j, gridView1.Columns["remark2"]).ToString().Trim();


                            //models.cFree1; 
                            //models.cFree2; 
                            //models.bFH; 
                            models.iSOsID = lIDDetails;
                            models.KL = 100;
                            models.KL2 = 100;
                            models.cInvName = dtInv.Rows[0]["cInvName"].ToString().Trim();
                            models.iTaxRate = model.iTaxRate;                 //需要默认值
                            //models.cDefine22;
                            models.cDefine23 = gridView1.GetRowCellValue(j, gridView1.Columns["partcode"]).ToString().Trim();
                            models.cDefine24 = gridView1.GetRowCellValue(j, gridView1.Columns["modelno"]).ToString().Trim();
                            models.cDefine25 = gridView1.GetRowCellValue(j, gridView1.Columns["custlot"]).ToString().Trim();
                            if (models.cDefine25.Trim() == "")
                            {
                                models.cDefine25 = dNow.ToString("yyyyMMdd");
                            }
                            //models.cDefine26; 
                            //models.cDefine27; 
                            //models.cItemCode;
                            //models.cItem_class; 
                            //models.cItemName; 
                            //models.cItem_CName; 
                            //models.cFree3;
                            //models.cFree4; 
                            //models.cFree5; 
                            //models.cFree6; 
                            //models.cFree7; 
                            //models.cFree8; 
                            //models.cFree9; 
                            //models.cFree10; 
                            //models.iInvExchRate; 
                            models.cUnitID = dtInv.Rows[0]["cComUnitCode"].ToString().Trim();
                            models.ID = model.ID;
                            models.cDefine28 = gridView1.GetRowCellValue(j, gridView1.Columns["lotno"]).ToString().Trim();
                            models.cDefine29 = gridView1.GetRowCellValue(j, gridView1.Columns["marklot"]).ToString().Trim();
                            models.cDefine30 = gridView1.GetRowCellValue(j, gridView1.Columns["fromstation"]).ToString().Trim();
                            models.cDefine31 = gridView1.GetRowCellValue(j, gridView1.Columns["tostation"]).ToString().Trim();
                            models.cDefine32 = gridView1.GetRowCellValue(j, gridView1.Columns["nextstation"]).ToString().Trim();
                            models.cDefine33 = gridView1.GetRowCellValue(j, gridView1.Columns["productcode"]).ToString().Trim();
                            //models.cDefine34 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(j, gridView1.Columns["sepoperationcode"]));
                            //models.cDefine35 = BaseFunction.ReturnLong(gridView1.GetRowCellValue(j, gridView1.Columns["epjoperationcode"]).ToString().Trim());
                            //models.cDefine36; 
                            //models.cDefine37; 
                            //models.FPurQuan; 
                            //models.cQuoCode; 
                            //models.iQuoID; 
                            //models.cSCloser; 
                            models.dPreMoDate = models.dPreDate;    //需要默认值

                            sSQL = "select autoid from SO_SODetails where ID = " + model.ID.ToString();
                            DataTable dtSODetails = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtSODetails == null || dtSODetails.Rows.Count == 0)
                            {
                                models.iRowNo = 1;
                            }
                            else
                            {
                                models.iRowNo = dtSODetails.Rows.Count + 1;
                            }

                            //models.iCusBomID; 
                            //models.iMoQuantity; 
                            //models.cContractID; 
                            //models.cContractTagCode;
                            //models.cContractRowGuid; 
                            //models.iPPartSeqID; 
                            //models.iPPartID; 
                            //models.iPPartQty; 
                            //models.cCusInvCode; 
                            //models.cCusInvName; 
                            //models.iPreKeepQuantity; 
                            //models.iPreKeepNum;
                            //models.iPreKeepTotQuantity; 
                            //models.iPreKeepTotNum; 
                            //models.dreleasedate; 
                            models.fcusminprice = 0;
                            //models.fimquantity; 
                            //models.fomquantity; 
                            //models.ballpurchase;
                            //models.finquantity; 
                            //models.icostquantity; 
                            //models.icostsum; 
                            //models.foutquantity; 
                            //models.foutnum; 
                            //models.iexchsum; 
                            //models.imoneysum; 
                            ////models.dufts; 
                            //models.iaoids; 
                            //models.cpreordercode;
                            //models.fretquantity; 
                            //models.fretnum; 
                            //models.dbclosedate; 
                            //models.dbclosesystime; 
                            models.bOrderBOM = false;
                            models.bOrderBOMOver = 0;
                            //models.idemandtype; 
                            //models.cdemandcode;
                            //models.cdemandmemo; 
                            //models.fPurSum; 
                            //models.fPurBillQty; 
                            //models.fPurBillSum; 
                            //models.iimid; 
                            //models.ccorvouchtype; 
                            //models.icorrowno; 
                            models.busecusbom = false;
                            //models.body_outid;
                            //models.fVeriDispQty; 
                            //models.fVeriDispSum; 
                            models.bsaleprice = false;
                            //models.bgift; 
                            //models.forecastdid; 
                            //models.cdetailsdemandcode; 
                            //models.cdetailsdemandmemo; 
                            //models.fTransedQty;
                            // models.cbSysBarCode; 
                            //models.fappqty

                            UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SO_SODetails dals = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SO_SODetails();
                            sSQL = dals.Add(models);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            decimal dMaterialPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridView1.Columns["materialprice"]).ToString().Trim());
                            if (dMaterialPrice > 0)
                            {
                                sSQL = "update Inventory set cInvDefine13 = aaaaaa where cInvCode = 'bbbbbb'";
                                sSQL = sSQL.Replace("aaaaaa", dMaterialPrice.ToString().Trim());
                                sSQL = sSQL.Replace("bbbbbb", models.cInvCode);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }

                            UFIDA.U8.UAP.CustomApp.ControlForm.Model.SO_SODetails_extradefine models2 = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.SO_SODetails_extradefine();
                            models2.cbdefine1 = gridView1.GetRowCellValue(j, gridView1.Columns["parentcode"]).ToString().Trim();
                            models2.cbdefine2 = gridView1.GetRowCellValue(j, gridView1.Columns["platingspec"]).ToString().Trim();
                            models2.cbdefine3 = gridView1.GetRowCellValue(j, gridView1.Columns["dono"]).ToString().Trim();
                            models2.cbdefine4 = models.iQuantity;
                            models2.iSOsID = models.iSOsID;
                            models2.cbdefine9 = gridView1.GetRowCellValue(j, gridView1.Columns["sepoperationcode"]).ToString().Trim();
                            models2.cbdefine10 = gridView1.GetRowCellValue(j, gridView1.Columns["epjoperationcode"]).ToString().Trim();

                            UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SO_SODetails_extradefine dals2 = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.SO_SODetails_extradefine();
                            sSQL = dals2.Exists(models.iSOsID);
                            dt = DbHelperSQL.ExecuteDataset(tran,CommandType.Text,sSQL).Tables[0];
                            if (dt == null || dt.Rows.Count ==0)
                            {
                                sSQL = dals2.Add(models2);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else
                            {
                                sSQL = dals2.Update(models2);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }

                            decimal dMaterPrice = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j,gridView1.Columns["MaterialPrice".ToLower()]),5);
                            if(dMaterPrice > 0)
                            {
                                sSQL = "update Inventory set cInvDefine13 = " + dMaterPrice.ToString() + " where cInvCode = '" + models.cInvCode + "'";
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            //客户条码 不需要打印，但条码记录表里面需要有
                            string sLotNo = gridView1.GetRowCellValue(j, gridView1.Columns["lotno"]).ToString().Trim();
                            if (sLotNo.Trim() != "")
                            {
                                DAL._BarCodeLabel dalBar = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL._BarCodeLabel();
                                Model._BarCodeLabel modelBar = new UFIDA.U8.UAP.CustomApp.ControlForm.Model._BarCodeLabel();
                                modelBar.BarCode = sLotNo;
                                modelBar.SaleOrderNo = model.cSOCode;
                                modelBar.SaleOrderRowNo = models.iRowNo;
                                modelBar.iSOsID = models.iSOsID;
                                modelBar.cInvCode = models.cInvCode;
                                modelBar.cInvName = models.cInvName;
                                modelBar.DEPT = model.cDepCode;
                                modelBar.CUST = model.cCusCode;
                                modelBar.ORDERNO = model.cSOCode;
                                modelBar.CUSTDO = model.cDefine10;
                                modelBar.CUSTLOT = models.cDefine25;
                                modelBar.LOTNO = sLotNo;
                                modelBar.ORDERQTY = models.iQuantity;
                                modelBar.LOTQTY = models.iQuantity;
                                modelBar.DueDate = models.dPreDate;
                                modelBar.RECDate = model.dDate;
                                modelBar.Creater = sUserID;
                                modelBar.CreateDate = dNow;
                                modelBar.BarKG = "是";
                                modelBar.PrintCount = 1;
                                modelBar.Batch = gridView1.GetRowCellValue(j, gridView1.Columns["lotno"]).ToString().Trim();
                                modelBar.LotSize = 1;
                                modelBar.Status = "新增-客供条码";
                                sSQL = dalBar.Add(modelBar);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                Model.BarStatus modelBarStstus = new UFIDA.U8.UAP.CustomApp.ControlForm.Model.BarStatus();
                                modelBarStstus.BarCode = modelBar.BarCode;
                                modelBarStstus.iSOsID = models.iSOsID;
                                modelBarStstus.Type = "新增-客供条码";
                                modelBarStstus.QTY = modelBar.LOTQTY;
                                modelBarStstus.RoutingFrom = "新增";

                                sSQL = "select * from _SystemSet where cSTCode = 'aaaaaa' ";
                                sSQL = sSQL.Replace("aaaaaa", model.cSTCode);
                                DataTable dttmp_wh = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                if (dttmp_wh == null || dttmp_wh.Rows.Count == 0)
                                {
                                    sErr = sErr + "row " + (j + 1).ToString() + " warehouse err\n";
                                    continue;
                                }

                                modelBarStstus.RoutingTo = dttmp_wh.Rows[0]["cWhCode"].ToString().Trim();
                                modelBarStstus.UpdateTime = dNow;
                                modelBarStstus.CreateUid = sUserID;
                                modelBarStstus.CreateDate = dNow;

                                DAL.BarStatus dalbarstatus = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.BarStatus();
                                sSQL = dalbarstatus.Add(modelBarStstus);
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            }
                        }
                    }

                    if (sErr.Length > 0)
                        throw new Exception(sErr);

                    #region 同步生成其它入库单

                    string[] s单据号List = s销售订单号.Split(',');
                    string sRDInList = "";

                    for (int ii = 0; ii < s单据号List.Length; ii++)
                    {
                        string s单据号 = s单据号List[ii].Trim();
                        if (s单据号 == "")
                            continue;


                        sSQL = @"
select * ,e.iID as BarCodeID
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    left join _SystemSet c on a.cSTCode = c.cSTCode
    inner join Inventory d on b.cInvCode = d.cInvCode
    left join _BarCodeLabel e on e.iSOsID = b.iSOsID
where a.cSOCode = 'aaaaaa'
order by b.autoid
";
                        sSQL = sSQL.Replace("aaaaaa", s单据号);
                        DataTable dtSOMain = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dtSOMain == null || dtSOMain.Rows.Count == 0)
                        {
                            throw new Exception("Sale Order not exists err");
                        }

                        string sCTCode = dtSOMain.Rows[0]["cSTCode"].ToString().Trim();

                        sSQL = @"
select a.cCode,b.cSoCode 
from rdrecord08 a inner join rdrecords08 b on a.id = b.id
where b.cSoCode = 'aaaaaa'
";
                        sSQL = sSQL.Replace("aaaaaa", s单据号);
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            throw new Exception("exist \n" + dt.Rows[0]["cCode"].ToString().Trim());
                        }

                        DateTime dDate = BaseFunction.ReturnDate(dtSOMain.Rows[0]["dDate"]);

                        sSQL = "select isnull(bflag_ST,0) as bflag from GL_mend where iYPeriod = '" + dDate.ToString("yyyyMM") + "'";
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt == null || dt.Rows.Count == 0)
                        {
                            throw new Exception("Access module state failure");
                        }
                        int i结账RD = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                        if (i结账RD > 0)
                        {
                            throw new Exception(dDate.ToString("yyyy-MM") + " have checked out");
                        }

                        //获得单据号
                        sSQL = "select cNumber from VoucherHistory with (ROWLOCK) WHERE (CardNumber = '0301') AND (cContent = '日期') AND (cContentRule = 'YYYY') AND (cSeed = 'aaaaaa') ORDER BY cNumber DESC";
                        sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.ToString("yyyy"));
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        long lCodeRD = 0;
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            lCodeRD = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                        }
                        else
                        {
                            lCodeRD = 0;
                        }

                        long lIDRD = -1;
                        long lIDRDDetails = -1;
                        sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'rd',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                        sSQL = sSQL.Replace("aaaaaa", lIDRD.ToString());
                        sSQL = sSQL.Replace("bbbbbb", lIDRDDetails.ToString());
                        sSQL = sSQL.Replace("cccccc", 1.ToString());
                        sSQL = sSQL.Replace("dddddd", sAccID);
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        lIDRD = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                        lIDRDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                        //ArrayList aList = new ArrayList();

                        Model.RdRecord08 modelRD = new Model.RdRecord08();
                        lIDRD += 1;
                        modelRD.ID = lIDRD;

                        modelRD.bRdFlag = 1;
                        modelRD.cVouchType = "08";
                        modelRD.cBusType = "其他入库";
                        modelRD.cSource = "库存";
                        //modelRD.cBusCode = 


                        modelRD.cWhCode = dtSOMain.Rows[0]["cWhCode"].ToString().Trim();        //需要仓库默认值
                        if (dtSOMain.Rows[0]["cWhCode"].ToString().Trim() == "")
                        {
                            throw new Exception("Please set default warehouse");
                        }

                        modelRD.dDate = dDate;        //需要默认值

                        lCodeRD += 1;
                        string sCodeRD = lCodeRD.ToString();
                        while (sCodeRD.Length < 6)
                        {
                            sCodeRD = "0" + sCodeRD;
                        }
                        modelRD.cCode ="MI" + dateEdit1.DateTime.Year.ToString() + sCodeRD;
                        if (sRDInList == "")
                        {
                            sRDInList = modelRD.cCode;
                        }
                        else
                        {
                            sRDInList = sRDInList + "," + modelRD.cCode;
                        }

                        modelRD.cRdCode = dtSOMain.Rows[0]["cRdCode"].ToString().Trim();      //需要默认值
                        if (dtSOMain.Rows[0]["cRdCode"].ToString().Trim() == "")
                        {
                            throw new Exception("Please set RdCode");
                        }
                        //modelRD.cDepCode = ""
                        //modelRD.cPersonCode; 
                        //modelRD.cPTCode; 
                        //modelRD.cSTCode; 
                        //modelRD.cCusCode; 
                        //modelRD.cVenCode; 
                        //modelRD.cOrderCode; 
                        //modelRD.cARVCode; 
                        //modelRD.cBillCode; 
                        //modelRD.cDLCode; 
                        //modelRD.cProBatch; 
                        modelRD.cHandler = sUserName;
                        //modelRD.cMemo; 
                        modelRD.bTransFlag = false;
                        //modelRD.cAccounter; 
                        modelRD.cMaker = sUserName;
                        modelRD.cDefine1 = dtSOMain.Rows[0]["cDefine1"].ToString();
                        modelRD.cDefine2 = dtSOMain.Rows[0]["cDefine2"].ToString();
                        modelRD.cDefine3 = dtSOMain.Rows[0]["cDefine3"].ToString();

                        if (dtSOMain.Rows[0]["cDefine4"].ToString().Trim() != "")
                        {
                            modelRD.cDefine4 = BaseFunction.ReturnDate(dtSOMain.Rows[0]["cDefine4"]);
                        }
                        if (dtSOMain.Rows[0]["cDefine5"].ToString().Trim() != "")
                        {
                            modelRD.cDefine5 = BaseFunction.ReturnLong(dtSOMain.Rows[0]["cDefine5"]);
                        }
                        if (dtSOMain.Rows[0]["cDefine6"].ToString().Trim() != "")
                        {
                            modelRD.cDefine6 = BaseFunction.ReturnDate(dtSOMain.Rows[0]["cDefine6"]);
                        }
                        if (dtSOMain.Rows[0]["cDefine7"].ToString().Trim() != "")
                        {
                            modelRD.cDefine7 = BaseFunction.ReturnDecimal(dtSOMain.Rows[0]["cDefine7"]);
                        }
                        modelRD.cDefine8 = dtSOMain.Rows[0]["cDefine8"].ToString();
                        modelRD.cDefine9 = dtSOMain.Rows[0]["cDefine9"].ToString();
                        modelRD.cDefine10 = dtSOMain.Rows[0]["cDefine10"].ToString();
                        //modelRD.dKeepDate; 
                        modelRD.dVeriDate = dDate;
                        modelRD.bpufirst = false;
                        modelRD.biafirst = false;
                        //modelRD.iMQuantity; 
                        //modelRD.dARVDate; 
                        //modelRD.cChkCode; 
                        //modelRD.dChkDate; 
                        //modelRD.cChkPerson; 
                        modelRD.VT_ID = 67;
                        modelRD.bIsSTQc = false;
                        modelRD.cDefine11 = dtSOMain.Rows[0]["cDefine11"].ToString();
                        modelRD.cDefine12 = dtSOMain.Rows[0]["cDefine12"].ToString();
                        modelRD.cDefine13 = dtSOMain.Rows[0]["cDefine13"].ToString();
                        //modelRD.cDefine14 = dtSOMain.Rows[0]["cDefine14"].ToString();
                        modelRD.cDefine14 = dtSOMain.Rows[0]["cSOCode"].ToString();

                        if (dtSOMain.Rows[0]["cDefine15"].ToString() != "")
                        {
                            modelRD.cDefine15 = BaseFunction.ReturnLong(dtSOMain.Rows[0]["cDefine15"]);
                        }
                        if (dtSOMain.Rows[0]["cDefine16"].ToString() != "")
                        {
                            modelRD.cDefine16 = BaseFunction.ReturnDecimal(dtSOMain.Rows[0]["cDefine16"]);
                        }
                        //modelRD.gspcheck; 
                        //modelRD.ufts; 
                        //modelRD.iExchRate; 
                        //modelRD.cExch_Name; 
                        modelRD.bOMFirst = false;
                        modelRD.bFromPreYear = false;
                        modelRD.bIsLsQuery = false;
                        modelRD.bIsComplement = 0;
                        modelRD.iDiscountTaxType = 0;
                        modelRD.ireturncount = 0;
                        modelRD.iverifystate = 0;
                        modelRD.iswfcontrolled = 0;
                        //modelRD.cModifyPerson; 
                        //modelRD.dModifyDate; 
                        //modelRD.dnmaketime; 
                        //modelRD.dnmodifytime; 
                        //modelRD.dnverifytime; 
                        modelRD.bredvouch = 0;
                        //modelRD.iFlowId; 
                        //modelRD.cPZID; 
                        //modelRD.cSourceLs; 
                        //modelRD.cSourceCodeLs; 
                        modelRD.iPrintCount = 0;
                        //modelRD.ctransflag; 
                        //modelRD.csysbarcode;
                        //modelRD.cCurrentAuditor;
                        DAL.RdRecord08 dalRD = new UFIDA.U8.UAP.CustomApp.ControlForm.DAL.RdRecord08();
                        sSQL = dalRD.Add(modelRD);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        for (int i = 0; i < dtSOMain.Rows.Count; i++)
                        {
                            lIDRDDetails += 1;


                            Model.rdrecords08 modelsRD = new Model.rdrecords08();
                            modelsRD.AutoID = lIDRDDetails;


                            modelsRD.ID = modelRD.ID;
                            modelsRD.cInvCode = dtSOMain.Rows[i]["cInvCode"].ToString().Trim();

                            if (dtSOMain.Rows[i]["iNum"].ToString().Trim() != "")
                            {
                                modelsRD.iNum = BaseFunction.ReturnDecimal(dtSOMain.Rows[i]["iNum"]);
                            }
                            modelsRD.iQuantity = BaseFunction.ReturnDecimal(dtSOMain.Rows[i]["iQuantity"]);
                            //modelsRD.iUnitCost; 
                            //modelsRD.iPrice; 
                            //modelsRD.iAPrice; 
                            //modelsRD.iPUnitCost; 
                            //modelsRD.iPPrice; 

                            bool bBatch = BaseFunction.ReturnBool(dtSOMain.Rows[i]["bInvBatch"]);
                            if (bBatch)
                            {
                                modelsRD.cBatch = dtSOMain.Rows[i]["cDefine25"].ToString().Trim();
                            }
                            //modelsRD.cVouchCode; 
                            //modelsRD.cInVouchCode; 
                            //modelsRD.cinvouchtype; 
                            //modelsRD.iSOutQuantity; 
                            //modelsRD.iSOutNum; 
                            //modelsRD.cFree1; 
                            //modelsRD.cFree2; 
                            modelsRD.iFlag = 0;
                            //modelsRD.iFNum; 
                            //modelsRD.iFQuantity; 
                            //modelsRD.dVDate; 
                            //modelsRD.iTrIds; 
                            //modelsRD.cPosition; 
                            //modelsRD.cDefine22; 
                            //modelsRD.cDefine23; 
                            //modelsRD.cDefine24; 
                            //modelsRD.cDefine25; 
                            //modelsRD.cDefine26; 
                            //modelsRD.cDefine27; 
                            //modelsRD.cItem_class; 
                            //modelsRD.cItemCode; 
                            //modelsRD.cName; 
                            //modelsRD.cItemCName; 
                            //modelsRD.cFree3; 
                            //modelsRD.cFree4; 
                            //modelsRD.cFree5; 
                            //modelsRD.cFree6; 
                            //modelsRD.cFree7; 
                            //modelsRD.cFree8; 
                            //modelsRD.cFree9; 
                            //modelsRD.cFree10; 
                            //modelsRD.cBarCode; 
                            //modelsRD.iNQuantity; 
                            //modelsRD.iNNum; 
                            //modelsRD.cAssUnit; 
                            //modelsRD.dMadeDate; 
                            //modelsRD.iMassDate; 
                            //modelsRD.cDefine28; 
                            //modelsRD.cDefine29; 
                            //modelsRD.cDefine30;
                            //modelsRD.cDefine31; 
                            //modelsRD.cDefine32; 
                            //modelsRD.cDefine33; 
                            //modelsRD.cDefine34; 
                            //modelsRD.cDefine35; 
                            //modelsRD.cDefine36; 
                            //modelsRD.cDefine37; 
                            //modelsRD.iCheckIds; 
                            //modelsRD.cBVencode; 
                            //modelsRD.chVencode; 
                            //modelsRD.bGsp; 
                            //modelsRD.cGspState; 
                            //modelsRD.cCheckCode; 
                            //modelsRD.iCheckIdBaks; 
                            //modelsRD.cRejectCode; 
                            //modelsRD.iRejectIds; 
                            //modelsRD.cCheckPersonCode; 
                            //modelsRD.dCheckDate; 
                            //modelsRD.cMassUnit; 
                            //modelsRD.bChecked; 
                            modelsRD.bLPUseFree = false;
                            //modelsRD.iRSRowNO; 
                            //modelsRD.iOriTrackID; 
                            //modelsRD.coritracktype; 
                            //modelsRD.cbaccounter; 
                            //modelsRD.dbKeepDate; 
                            modelsRD.bCosting = true;
                            modelsRD.bVMIUsed = false;
                            //modelsRD.iVMISettleQuantity; 
                            //modelsRD.iVMISettleNum; 
                            //modelsRD.cvmivencode; 
                            //modelsRD.iInvSNCount; 
                            //modelsRD.cwhpersoncode; 
                            //modelsRD.cwhpersonname; 
                            //modelsRD.cserviceoid; 
                            //modelsRD.cbserviceoid; 
                            //modelsRD.iinvexchrate; 
                            //modelsRD.corufts;
                            //modelsRD.strContractGUID; 
                            modelsRD.iExpiratDateCalcu = 0;
                            //modelsRD.cExpirationdate; 
                            //modelsRD.dExpirationdate; 
                            //modelsRD.cciqbookcode; 
                            //modelsRD.iBondedSumQty; 
                            //modelsRD.iorderdid; 
                            modelsRD.iordertype = 0;
                            //modelsRD.iordercode; 
                            //modelsRD.iorderseq; 
                            modelsRD.isodid = dtSOMain.Rows[i]["isosid"].ToString().Trim();
                            modelsRD.isotype = 0;
                            modelsRD.csocode = s单据号;
                            modelsRD.isoseq = BaseFunction.ReturnInt(dtSOMain.Rows[i]["iRowNo"]);
                            //modelsRD.cBatchProperty1; 
                            //modelsRD.cBatchProperty2; 
                            //modelsRD.cBatchProperty3; 
                            //modelsRD.cBatchProperty4; 
                            //modelsRD.cBatchProperty5; 
                            //modelsRD.cBatchProperty6; 
                            //modelsRD.cBatchProperty7; 
                            //modelsRD.cBatchProperty8; 
                            //modelsRD.cBatchProperty9; 
                            //modelsRD.cBatchProperty10; 
                            //modelsRD.cbMemo; 
                            modelsRD.irowno = i + 1;
                            //modelsRD.strowguid; 
                            //modelsRD.rowufts; 
                            //modelsRD.ipreuseqty; 
                            //modelsRD.ipreuseinum; 
                            //modelsRD.cbsourcecodels; 
                            //modelsRD.iGroupNO; 
                            //modelsRD.iDebitIDs; 
                            //modelsRD.idebitchildids; 
                            //modelsRD.OutCopiedQuantity; 
                            //modelsRD.cbsysbarcode

                            DAL.rdrecords08 dalsRD = new DAL.rdrecords08();
                            sSQL = dalsRD.Add(modelsRD);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            sSQL = @"
if exists
    (select * from  CurrentStock where cInvCode = '@cInvCode' and cWhCode = '@cWhCode'
        and isnull(cFree1,'') = @cFree1 
        and isnull(cFree2,'') = @cFree2
        and isnull(cFree3,'') = @cFree3
        and isnull(cFree4,'') = @cFree4
        and isnull(cFree5,'') = @cFree5
        and isnull(cFree6,'') = @cFree6
        and isnull(cFree7,'') = @cFree7
        and isnull(cFree8,'') = @cFree8
        and isnull(cFree9,'') = @cFree9
        and isnull(cFree10,'') = @cFree10
        and isnull(cBatch,'') = @cBatch 
    )
  	update  CurrentStock set iQuantity = isnull(iQuantity,0) + @iQuantity  
    where cInvCode = '@cInvCode' and cWhCode = '@cWhCode' 
        and isnull(cFree1,'') = @cFree1 
        and isnull(cFree2,'') = @cFree2
        and isnull(cFree3,'') = @cFree3
        and isnull(cFree4,'') = @cFree4
        and isnull(cFree5,'') = @cFree5
        and isnull(cFree6,'') = @cFree6
        and isnull(cFree7,'') = @cFree7
        and isnull(cFree8,'') = @cFree8
        and isnull(cFree9,'') = @cFree9
        and isnull(cFree10,'') = @cFree10
        and isnull(cBatch,'') = @cBatch 
else 
    begin 
        declare @itemid varchar(20); 
        declare @iCount int;  
        select @iCount=count(itemid) from CurrentStock where cInvCode = '@cInvCode';
        if( @iCount > 0 )
	        select @itemid=itemid from CurrentStock where cInvCode = '@cInvCode';
        else  
            select @itemid=max(itemid+1) from CurrentStock  
            insert into CurrentStock(cWhCode,cInvCode,iQuantity,itemid, cFree1, cFree2, cFree3, cFree4, cFree5, cFree6, cFree7, cFree8, cFree9, cFree10,cBatch,iSoDid)
            values('@cWhCode','@cInvCode', @iQuantity,isnull(@itemid,1), @cFree1, @cFree2, @cFree3, @cFree4, @cFree5, @cFree6, @cFree7, @cFree8, @cFree9, @cFree10,@cBatch,'') 
    end
";
                            sSQL = sSQL.Replace("@cInvCode", modelsRD.cInvCode);
                            sSQL = sSQL.Replace("@cWhCode", modelRD.cWhCode);
                            sSQL = sSQL.Replace("@iQuantity", modelsRD.iQuantity.ToString());
                            sSQL = sSQL.Replace("@iNum", modelsRD.iNum.ToString());
                            sSQL = sSQL.Replace("@cFree10", modelsRD.cFree10 == null ? "''" : "'" + modelsRD.cFree10 + "'");
                            sSQL = sSQL.Replace("@cFree1", modelsRD.cFree1 == null ? "''" : "'" + modelsRD.cFree1 + "'");
                            sSQL = sSQL.Replace("@cFree2", modelsRD.cFree2 == null ? "''" : "'" + modelsRD.cFree2 + "'");
                            sSQL = sSQL.Replace("@cFree3", modelsRD.cFree3 == null ? "''" : "'" + modelsRD.cFree3 + "'");
                            sSQL = sSQL.Replace("@cFree4", modelsRD.cFree4 == null ? "''" : "'" + modelsRD.cFree4 + "'");
                            sSQL = sSQL.Replace("@cFree5", modelsRD.cFree5 == null ? "''" : "'" + modelsRD.cFree5 + "'");
                            sSQL = sSQL.Replace("@cFree6", modelsRD.cFree6 == null ? "''" : "'" + modelsRD.cFree6 + "'");
                            sSQL = sSQL.Replace("@cFree7", modelsRD.cFree7 == null ? "''" : "'" + modelsRD.cFree7 + "'");
                            sSQL = sSQL.Replace("@cFree8", modelsRD.cFree8 == null ? "''" : "'" + modelsRD.cFree8 + "'");
                            sSQL = sSQL.Replace("@cFree9", modelsRD.cFree9 == null ? "''" : "'" + modelsRD.cFree9 + "'");
                            sSQL = sSQL.Replace("@cBatch", modelsRD.cBatch == null ? "''" : "'" + modelsRD.cBatch + "'");
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            if (dtSOMain.Rows[i]["BarCodeID"].ToString().Trim() != "")
                            {
                                sSQL = "update _BarCodeLabel set Process = '" + modelRD.cWhCode + "', RDType = 'rdrecord08', RDsID = " + modelsRD.AutoID.ToString() + " where iID = " + dtSOMain.Rows[i]["BarCodeID"].ToString().Trim();
                                DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                        }

                        sSQL = @"
exec ST_SaveForStock N'08',N'aaaaaa',1,0 ,1
";
                        sSQL = sSQL.Replace("aaaaaa", lIDRD.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
exec ST_SaveForTrackStock N'08',N'aaaaaa', 0 ,1
";
                        sSQL = sSQL.Replace("aaaaaa", lIDRD.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = @"
exec IA_SP_WriteUnAccountVouchForST 'aaaaaa',N'08'
";
                        sSQL = sSQL.Replace("aaaaaa", lIDRD.ToString());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        if (lIDRD > 1000000000)
                        {
                            lIDRD = lIDRD - 1000000000;
                        }
                        if (lIDRDDetails > 1000000000)
                        {
                            lIDRDDetails = lIDRDDetails - 1000000000;
                        }
                        sSQL = "update UFSystem..UA_Identity set iFatherId = " + lIDRD.ToString() + ",iChildId = " + lIDRDDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'rd'";
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        sSQL = @"
if exists(select * from VoucherHistory where  (CardNumber = '0301') AND (cContent = '日期') AND (cContentRule = 'YYYY') AND (cSeed = 'bbbbbb'))
	update VoucherHistory set cNumber = aaaaaa  where  (CardNumber = '0301') AND (cContent = '日期') AND (cContentRule = 'YYYY') AND (cSeed = 'bbbbbb')
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('0301','日期','YYYY','bbbbbb','1',0)
";
                        sSQL = sSQL.Replace("aaaaaa", lCodeRD.ToString());
                        sSQL = sSQL.Replace("bbbbbb", dateEdit1.DateTime.ToString("yyyy"));
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    #endregion


                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (lID > 1000000000)
                    {
                        lID = lID - 1000000000;
                    }
                    if (lIDDetails > 1000000000)
                    {
                        lIDDetails = lIDDetails - 1000000000;
                    }
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + sAccID + "' and cVouchType = 'Somain'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
                    if exists(select * from VoucherHistory where CardNumber='17' AND cContentRule = 'YYYY' AND cSeed = 'bbbbbb')
                    	update VoucherHistory set cNumber = aaaaaa  where CardNumber = '17' AND cContentRule = 'YYYY' AND cSeed = 'bbbbbb'
                    else
                    	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
                    	values('17','单据日期','YYYY',null,'aaaaaa',0)
                    ";
                    sSQL = sSQL.Replace("aaaaaa", lCode.ToString());
                    sSQL = sSQL.Replace("bbbbbb", dateEdit1.DateTime.ToString("yyyy"));
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount > 0)
                    {
                        tran.Commit();

                        string sMsg = "OK\n" + s销售订单号 + "\n" + sRDInList;
                        MessageBox.Show(sMsg);

                        gridControl1.DataSource = null;
                    }
                    else
                    {
                        throw new Exception("Save failed");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
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

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                chkAll.Checked = false;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel2010|*.xlsx|Excel2003|*.xls|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                DataTable dtSheets = clsExcel.GetSheetName(fName);
                if(dtSheets == null || dtSheets.Rows.Count ==0)
                {
                    throw new Exception("Get excel err");  
                }
                lookUpEditSheetName.Properties.DataSource = dtSheets;
                lookUpEditSheetName.EditValue = dtSheets.Rows[0]["TABLE_NAME"].ToString();

                if (lookUpEditSheetName.EditValue == null || lookUpEditSheetName.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("Please check excel");
                }

                string sSQL = "select * from [" + lookUpEditSheetName.EditValue.ToString().Trim() + "]";
                //DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);

                TH.BaseClass.ExcelHelper excel = new ExcelHelper(fName);
                DataTable dt = excel.ExcelToDataTable(lookUpEditSheetName.EditValue.ToString().Trim(), true);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("Load excel err");
                }

                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dt.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "price";
                dc.DataType = System.Type.GetType("System.Decimal");
                dt.Columns.Add(dc);

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.ToLower().Trim().Replace(" ", "");
                    dt.Columns[i].Caption = dt.Columns[i].Caption.Replace(" ", "");
                    
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal d_Price = 0;
                    if (dt.Rows[i]["ToStation"].ToString().Trim() != "")
                    {
                        string sFromStation = dt.Rows[i]["ToStation"].ToString().Trim();
                        d_Price = dPrice(sFromStation, dt.Rows[i]["ItemNo"].ToString().Trim());
                        dt.Rows[i]["price"] = d_Price;
                    }
                    if (d_Price == 0)
                    {

                        string sCusCode = dt.Rows[i]["CustCode"].ToString().Trim();
                        string sInvCode = dt.Rows[i]["ItemNo"].ToString().Trim();
                        decimal dQty = BaseFunction.ReturnDecimal(dt.Rows[i]["DelQty"]);

                        sSQL = @"
SELECT distinct cCusExch_name
from dbo.Customer
where cCusCode = 'aaaaaa'
";
                        sSQL = sSQL.Replace("aaaaaa", sCusCode);
                        DataTable dtPrice = DbHelperSQL.Query(sSQL);
                        if (dtPrice != null && dtPrice.Rows.Count > 0)
                        {
                            string sCurr = dtPrice.Rows[0]["cCusExch_name"].ToString().Trim();
                            string sDate = BaseFunction.ReturnDate(dateEdit1.DateTime).ToString("yyyy-MM-dd");

                            if (sDate.Length < 8)
                                continue;

                            decimal d2 = 0;
                            decimal d = dPrice(sCusCode, sInvCode, dQty, sCurr, sDate, out d2);
                            dt.Rows[i]["Price"] = d;
                        }
                    }
                }

                gridControl1.DataSource = dt;
                gridView1.Columns["choose"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridView1.Columns["price"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                }
                gridView1.Columns["choose"].OptionsColumn.AllowEdit = true;

                chkAll.Checked = true;

                

                gridView1.BestFitColumns();

                gridView1.Columns["delqty"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["choose"], chkAll.Checked);
                }
            }
            catch { }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (radioCustomerPrice.Checked)
            //    {
            //        for (int i = 0; i < gridView1.RowCount; i++)
            //        {
            //            gridView1.SetRowCellValue(i, gridView1.Columns["PriceType"], "Customer Price");
            //        }
            //    }
            //    if (radioFromWorkCenter.Checked)
            //    {
            //        for (int i = 0; i < gridView1.RowCount; i++)
            //        {
            //            gridView1.SetRowCellValue(i, gridView1.Columns["PriceType"], "From WorkCenter");
            //        }
            //    }
            //}
            //catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                gridView1.PostEditor();

                int iRow = e.RowHandle;

                if (e.Column == gridView1.Columns["PriceType"])
                {
                    string sPriceType = gridView1.GetRowCellValue(iRow, gridView1.Columns["PriceType"]).ToString();
//                    if (sPriceType == "From WorkCenter")
//                    {
//                        string sFromStation = gridView1.GetRowCellValue(iRow, gridView1.Columns["FromStation"]).ToString();
//                        decimal d = dPrice(sFromStation);
//                        gridView1.SetRowCellValue(iRow, gridView1.Columns["Price"], d);
//                    }
//                    if (sPriceType == "Customer Price")
//                    {
//                        string sCusCode = gridView1.GetRowCellValue(iRow, gridView1.Columns["CustCode"]).ToString().Trim();
//                        string sInvCode = gridView1.GetRowCellValue(iRow, gridView1.Columns["ItemNo"]).ToString().Trim();
//                        decimal dQty = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(iRow, gridView1.Columns["DelQty"]));

//                        string sSQL = @"
//SELECT distinct cCusExch_name
//from dbo.Customer
//where cCusCode = 'aaaaaa'
//";
//                        sSQL = sSQL.Replace("aaaaaa",sCusCode);
//                        DataTable dt = DbHelperSQL.Query(sSQL);
//                        if(dt != null && dt.Rows.Count >0)
//                        {
//                            string sCurr = dt.Rows[0]["cCusExch_name"].ToString().Trim();
//                            string sDate = gridView1.GetRowCellValue(iRow, gridView1.Columns["DODate"]).ToString().Trim();
//                            sDate = sDate.Substring(0, 4) + "-" + sDate.Substring(4, 2) + "-" + sDate.Substring(6, 2);

//                            decimal d2 = 0;
//                            decimal d = dPrice(sCusCode, sInvCode, dQty, sCurr, sDate,out d2);
//                            gridView1.SetRowCellValue(iRow, gridView1.Columns["Price"], d);
//                        }
//                    }
                }
            }
            catch(Exception ee)
            {
            
            }
        }

        private decimal dPrice(string sFromStation,string sInvCode)
        {

            decimal d = 0;
             string sSQL = @"
select a.* 
from _InvProcessPrice a inner join Inventory b on a.CaseType = b.cInvDefine2
where FromWorkCenter = 'aaaaaa' and cInvCode = 'bbbbbb'
";
             sSQL = sSQL.Replace("aaaaaa", sFromStation);
             sSQL = sSQL.Replace("bbbbbb", sInvCode);
             DataTable dtInvProcessPrice = DbHelperSQL.Query(sSQL);
             if (dtInvProcessPrice != null && dtInvProcessPrice.Rows.Count > 0)
             {
                 d = BaseFunction.ReturnDecimal(dtInvProcessPrice.Rows[0]["Price"]);
             }
            return d;
        }

        private decimal dPrice(string sCusCode, string sInvCode, decimal dQty,string sCurr,string sDate,out decimal iSalecost)
        {
            decimal d = 0;
            string sSQL = @"
declare @p17 float
set @p17=0
declare @p18 float
set @p18=0
declare @p19 float
set @p19=0
declare @p20 float
set @p20=0
declare @p21 float
set @p21=0
declare @p22 nvarchar(200)
set @p22=NULL
declare @p23 bit
set @p23=1
exec SA_FetchPrice N'aaaaaa',N'bbbbbb',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'','eeeeee',N'dddddd',cccccc,0,@p17 output,@p18 output,@p19 output,@p20 output,@p21 output,@p22 output,@p23 output,N''
select @p17, @p18, @p19, @p20, @p21, @p22, @p23

";
            sSQL = sSQL.Replace("aaaaaa", sCusCode);
            sSQL = sSQL.Replace("bbbbbb", sInvCode);
            sSQL = sSQL.Replace("cccccc", dQty.ToString());
            sSQL = sSQL.Replace("dddddd", sCurr);
            sSQL = sSQL.Replace("eeeeee", sDate);

            DbHelperSQL.connectionString = Conn;
            DataTable dt = DbHelperSQL.Query(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                d = BaseFunction.ReturnDecimal(dt.Rows[0][0], 5);
            }

            iSalecost = BaseFunction.ReturnDecimal(dt.Rows[0][0], 5);

            return d;
        }
    }

}
