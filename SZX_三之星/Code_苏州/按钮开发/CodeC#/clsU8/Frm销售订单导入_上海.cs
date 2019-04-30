using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;



namespace clsU8
{
    public partial class Frm销售订单导入_上海 : Form
    {
        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;
        int iTaxRate_All = 13;

        public Frm销售订单导入_上海()
        {
            InitializeComponent();
        }


        public Frm销售订单导入_上海(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserName = s6;

            sConnString = "server = " + s服务器 + ";uid=" + sSA + ";pwd=" + sPwd + ";database=" + s数据库 + ";timeout = 200";


            try
            {
                string sSQL = @"
select cValue  from AccInformation
Where cSysID=N'PU' and cid=N'166'
";
                DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iTaxRate_All = BaseFunction.ReturnInt(dt.Rows[0]["cValue"]);
                }

            }
            catch { }
        }
    
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = DateTime.Today;
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel2003|*.xls|Excel2010|*.xlsx|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string fName = openFileDialog.FileName;

                ClsExcel clsExcel = ClsExcel.Instance();

                string sSQL = "select * from [PUR_Export_POData$]";
                DataTable dt = clsExcel.ExcelToDT(fName, sSQL, true);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.Replace(".", "");
                    dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.Replace("#", "");
                    dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.Replace(" ", "");
                    dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.Replace("/", "");
                    dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.Replace("_", "");
                    dt.Columns[i].ColumnName = dt.Columns[i].ColumnName.Trim();
                }

                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["CustomerNo"].ToString().Trim() == "" && dt.Rows[i]["ItemNo"].ToString().Trim() == "")
                        dt.Rows.RemoveAt(i);
                }

           

                gridControl1.DataSource = dt;
                gridView1.OptionsView.AllowCellMerge = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "";
                try
                {
                    sSQL = "select isnull(bflag_SA,0) as bflag from GL_mend where iYPeriod = '" + dateEdit1.DateTime.ToString("yyyyMM") + "'";
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        throw new Exception("Access module state failure");
                    }
                    int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                    if (i结账 > 0)
                    {
                        throw new Exception(dateEdit1.DateTime.ToString("yyyy-MM") + " 已结帐");
                    }

                    int iCouRow = gridView1.RowCount;

                    ////获得单据号
                    //sSQL = "select cNumber from VoucherHistory with (ROWLOCK) Where CardNumber='17' and cContent is NULL";
                    //dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    //long lCode = 0;
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //    lCode = BaseFunction.ReturnLong(dt.Rows[0]["cNumber"]);
                    //}
                    //else
                    //{
                    //    lCode = 0;
                    //}
                    

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
                    sSQL = sSQL.Replace("dddddd", s数据库.Substring(7, 3));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                    ArrayList aList = new ArrayList();

                    string sMsg = "";

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        bool bExists = false;

                        string s客户订单号 = gridView1.GetRowCellValue(i, gridView1.Columns["CustPONo"]).ToString().Trim();

                        //判断本次是否已经导入
                        for (int j = 0; j < aList.Count; j++)
                        {
                            if (s客户订单号 == aList[j].ToString().Trim())
                            {
                                bExists = true;
                                break;
                            }
                        }

                        if (bExists)
                            continue;

                        sSQL = "select * from Customer where cCusCode = 'aaaaaaaa'";
                        sSQL = sSQL.Replace("aaaaaaaa", gridView1.GetRowCellDisplayText(i, gridView1.Columns["CustomerNo"]));
                        DataTable dtCustomer = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtCustomer == null || dtCustomer.Rows.Count == 0)
                        {
                            sErr = sErr + "行" + (i + 1).ToString() + "客户不存在\n";
                            continue;
                        }


                        //判断是否历史导入
                        sSQL = @"
select a.cSOCode 
from SO_SOMain a inner join SO_SOdetails b on a.ID = b.ID
where 1=1
	and a.cDefine10 = '111111'
";
                        sSQL = sSQL.Replace("111111", s客户订单号);
                        dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            sErr = sErr + "行 " + (i+1).ToString() + " 单据已存在 err\n";
                            continue;
                        }

                        aList.Add(s客户订单号);
                        TH.clsU8.Model.SO_SOMain model = new TH.clsU8.Model.SO_SOMain();

                        //string sSTCode = gridView1.GetRowCellValue(i,gridCol销售类型).ToString().Trim();
                        //if (sSTCode == "")
                        //{
                        //    sErr = sErr + "行 " + (i + 1).ToString() + " 销售类型不存在 err\n";
                        //    continue; 
                        //}

                        if (BaseFunction.ReturnBool(dtCustomer.Rows[0]["bCusDomestic"]))
                        {
                            model.cSTCode = "01";
                        }
                        else if (BaseFunction.ReturnBool(dtCustomer.Rows[0]["bCusOverseas"]))
                        {
                            model.cSTCode = "02";
                        }

                        
                        //如果区分
                        model.dDate = BaseFunction.ReturnDate(dateEdit1.DateTime.ToString("yyyy-MM-dd"));

                        //lCode += 1;
                        //string sCode = lCode.ToString();
                        //while (sCode.Length < 8)
                        //{
                        //    sCode = "0" + sCode;
                        //}
                        //sCode = "SZ" + sCode;
                        //model.cSOCode = sCode;

                        model.cSOCode = s客户订单号;
                        model.cCusCode = dtCustomer.Rows[0]["cCusCode"].ToString().Trim();

                        sSQL = "select * from Person where cPersonCode = '1111111111' or cPersonName = '1111111111'";
                        sSQL = sSQL.Replace("1111111111", sUserName);
                        DataTable dtPer = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtPer != null && dtPer.Rows.Count > 0)
                        {
                            model.cPersonCode = dtPer.Rows[0]["cPersonCode"].ToString().Trim();
                            model.cDepCode = dtPer.Rows[0]["cDepCode"].ToString().Trim();

                            if (model.cDepCode == null || model.cDepCode.ToString().Trim() == "")
                            {
                                sErr = sErr + "行 " + (i + 1).ToString() + " 请设置人员归属部门 err\n";
                                continue;
                            }
                        }
                        else
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 请设置人员档案 err\n";
                            continue;
                        }


                        string sCexch_Code = dtCustomer.Rows[0]["cCusExch_name"].ToString().Trim();
                        sCexch_Code = sJapToChina(sCexch_Code);
                        sSQL = "select * from foreigncurrency where cexch_code = 'aaaaaa' or cexch_name = 'aaaaaa'";
                        sSQL = sSQL.Replace("aaaaaa", sCexch_Code);
                        DataTable dtForeigncurrency = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtForeigncurrency == null || dtForeigncurrency.Rows.Count == 0)
                        {
                            sErr = sErr + "行 " + (i+1).ToString() + " 币种不存在 err\n";
                            continue;
                        }
                        model.cexch_name = dtForeigncurrency.Rows[0]["cexch_name"].ToString().Trim();
                        if (BaseFunction.ReturnInt(dtForeigncurrency.Rows[0]["iotherused"]) == -1)
                        {
                            model.iExchRate = 1;
                        }
                        else
                        {
                            sSQL = "select * from exch where iYear = aaaaaa and iPeriod = bbbbbb and cexch_name = 'cccccc'";
                            sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.ToString("yyyy"));
                            sSQL = sSQL.Replace("bbbbbb", dateEdit1.DateTime.Month.ToString());
                            sSQL = sSQL.Replace("cccccc", model.cexch_name);
                            DataTable dtExch = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtExch == null || dtExch.Rows.Count == 0)
                            {
                                sErr = sErr + "行 " + (i + 1).ToString() + " 请设置汇率 err\n";
                                continue;
                            }
                            model.iExchRate = BaseFunction.ReturnDecimal(dtExch.Rows[0]["nflat"]);
                        }

                        if (model.cexch_name == "人民币" || model.cexch_name.ToUpper() == "RMB" || model.cexch_name.ToUpper() == "CNY")
                        {
                            model.iTaxRate = iTaxRate_All;
                            model.cSTCode = "01";
                        }
                        else
                        {
                            model.iTaxRate = 0; 
                            model.cSTCode = "02";
                        }
                        //model.iMoney;
                        //model.cMemo;
                        //model.iStatus = 1;
                        model.cMaker = sUserName;
                        //model.cVerifier;
                        //model.cCloser;
                        model.bDisFlag = false;
                        //model.cDefine1;
                        //model.cDefine2;
                        //model.cDefine3;


                        string s_预发货 = gridView1.GetRowCellValue(i, gridView1.Columns["ScheduleDate(yyyymmdd)"]).ToString().Trim();
                        if (s_预发货.Length == 8)
                        {
                            model.cDefine4 = BaseFunction.ReturnDate(s_预发货.Substring(0, 4) + "-" + s_预发货.Substring(4, 2) + "-" + s_预发货.Substring(6, 2));
                        }
                     
                        //model.cDefine5;
                        //model.cDefine6;
                        //model.cDefine7;
                        //model.cDefine8;
                        //model.cDefine9;
                        model.cDefine10 = s客户订单号;
                        model.bReturnFlag = false;
                        model.cCusName = dtCustomer.Rows[0]["cCusName"].ToString().Trim();
                        model.bOrder = false;
                        lID += 1;
                        model.ID = lID;
                        model.iVTid = 95;
                        //model.cChanger = DBNull.Value;

                        string s业务类型 = gridView1.GetRowCellDisplayText(i, gridView1.Columns["业务类型"]).ToString().Trim();
                        if (s业务类型 == "普通销售" || s业务类型 == "直运销售")
                        {
                            model.cBusType = s业务类型;
                        }
                        else
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + " 请设置业务类型 err\n";
                            continue;
                        }
                        //model.cCreChpName; 
                        //model.cDefine11; 
                        //model.cDefine12; 
                        //model.cDefine13; 
                        //model.cDefine14; 
                        //model.cDefine15; 
                        //model.cDefine16;

                        //model.coppcode;
                        //model.cLocker; 
                        //model.dPreMoDateBT = BaseFunction.ReturnDate(dateEdit1.DateTime.ToString("yyyy-MM-dd"));    //需要默认值
                        //model.dPreDateBT = BaseFunction.ReturnDate(dateEdit1.DateTime.ToString("yyyy-MM-dd"));      //需要默认值
                        //model.cgatheringplan; 
                        //model.caddcode; 
                        model.iverifystate = 0;
                        //model.ireturncount;
                        model.iswfcontrolled = 0;
                        //model.icreditstate; 
                        //model.cmodifier; 
                        //model.dmoddate; 
                        //model.dverifydate; 
                        //model.ccusperson;
                        //model.dcreatesystime; 
                        //model.dverifysystime;
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

                        TH.clsU8.DAL.SO_SOMain dal = new TH.clsU8.DAL.SO_SOMain();
                        sSQL = dal.Add(model);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            if (s客户订单号 != gridView1.GetRowCellValue(j, gridView1.Columns["CustPONo"]).ToString().Trim())
                            {
                                continue;
                            }

                            TH.clsU8.Model.SO_SODetails models = new TH.clsU8.Model.SO_SODetails();

                            lIDDetails += 1;
                            models.AutoID = lIDDetails;
                            models.cSOCode = model.cSOCode;
                            models.ID = lID;

                            //sSQL = "select * from Inventory where cInvCode = '" + gridView1.GetRowCellValue(j, gridCol存货编码).ToString().Trim() + "'";

                            //普通销售取客户存货对照表
                            if (model.cBusType == "普通销售")
                            {
                                sSQL = @"
select a.*,b.cCusInvName,b.cCusInvCode
from Inventory a inner join CusInvContrapose b on a.cInvCode = b.cInvCode and b.cCusCode = '111111'
where b.cCusInvCode = '222222'
";
                                sSQL = sSQL.Replace("111111", model.cCusCode);
                                sSQL = sSQL.Replace("222222", gridView1.GetRowCellValue(j, gridView1.Columns["ItemNo"]).ToString().Trim());
                            }
                                
                            //直运业务只核对存货档案是否存在
                            else
                            {
                                sSQL = @"
select a.*,cast(null as varchar(50)) as cCusInvCode,cast(null as varchar(50)) as cCusInvName
from Inventory a 
where a.cInvCode = '222222' 
";
                                sSQL = sSQL.Replace("222222", gridView1.GetRowCellValue(j, gridView1.Columns["ItemNo"]).ToString().Trim());
                            }

                            DataTable dtInv = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            if (dtInv == null || dtInv.Rows.Count == 0)
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 存货编码不存在或对照表不存在\n";
                                continue;
                            }
                            models.cInvCode = dtInv.Rows[0]["cInvCode"].ToString().Trim();
                           

                            string s预发货 = gridView1.GetRowCellValue(j, gridView1.Columns["RequestDate(yyyymmdd)"]).ToString().Trim();
                            if (s预发货.Length == 8)
                            {
                                models.dPreDate = BaseFunction.ReturnDate(s预发货.Substring(0, 4) + "-" + s预发货.Substring(4, 2) + "-" + s预发货.Substring(6, 2));
                            }
                            else
                            {
                                models.dPreDate = dateEdit1.DateTime;
                            }

                            models.iQuantity = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridView1.Columns["OrderQTY"]).ToString().Trim());

                            decimal d汇率 = model.iExchRate;


                            sSQL = @"
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
set @p23=0
exec SA_FetchPrice N'cccccc',N'aaaaaa',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'bbbbbb',N'dddddd',10,0,@p17 output,@p18 output,@p19 output,@p20 output,@p21 output,@p22 output,@p23 output,N''
select @p17, @p18, @p19, @p20, @p21, @p22, @p23
";
                            sSQL = sSQL.Replace("aaaaaa", models.cInvCode);
                            sSQL = sSQL.Replace("bbbbbb", model.dDate.ToString("yyyy-MM-dd"));
                            sSQL = sSQL.Replace("cccccc", model.cCusCode);
                            sSQL = sSQL.Replace("dddddd", model.cexch_name);
                            DataTable dtPrice = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                            //decimal d原币含税单价 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridView1.Columns["UnitPrice"])); //Excel获得单价

                            if (dtPrice == null || dtPrice.Rows.Count == 0 )
                            {
                                sMsg = sMsg + "行" + (j + 1).ToString() + "单价请确认。客户编码：" + model.cCusCode + " 存货编码：" + models.cInvCode + " \n";
                                continue;
                            }
                            decimal d原币含税单价 = BaseFunction.ReturnDecimal(dtPrice.Rows[0][2]);
                            if(d原币含税单价 <= 0 )
                            {
                                sMsg = sMsg + "行" + (j + 1).ToString() + "单价请确认。客户编码：" + model.cCusCode + " 存货编码：" + models.cInvCode + " \n";
                                continue;
                            }


                            decimal d数量 = BaseFunction.ReturnDecimal(gridView1.GetRowCellValue(j, gridView1.Columns["OrderQTY"]));


                            decimal d原币含税金额 = BaseFunction.ReturnDecimal(d原币含税单价 * d数量, 3);
                            decimal d原币无税单价 = BaseFunction.ReturnDecimal(d原币含税单价 / (1 + model.iTaxRate / 100), 6);
                            decimal d原币无税金额 = BaseFunction.ReturnDecimal(d原币无税单价 * d数量, 3);
                            decimal d原币税额 = d原币含税金额 - d原币无税金额;

                            decimal d本币含税单价 = BaseFunction.ReturnDecimal(d原币含税单价 * d汇率, 6);
                            decimal d本币含税金额 = BaseFunction.ReturnDecimal(d本币含税单价 * d数量, 3);
                            decimal d本币无税单价 = BaseFunction.ReturnDecimal(d本币含税单价 / (1 + model.iTaxRate / 100), 6);
                            decimal d本币无税金额 = BaseFunction.ReturnDecimal(d本币无税单价 * d数量, 3);
                            decimal d本币税额 = d本币含税金额 - d本币无税金额;

                            //价格需要设置
                            models.iUnitPrice = d原币无税单价;
                            models.iTaxUnitPrice = d原币含税单价;
                            models.iMoney = d原币无税金额;
                            models.iTax = d原币税额;
                            models.iSum = d原币含税金额;

                            models.iNatUnitPrice = d本币无税单价;
                            models.iNatMoney = d本币无税金额;
                            models.iNatTax = d本币税额;
                            models.iNatSum = d本币含税金额;
                            models.iNatUnitPrice = d本币无税单价;
                            models.iNatMoney = d本币无税金额;
                            models.iNatTax = d本币税额;
                            models.iTaxRate = model.iTaxRate;

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
                            //models.iDisCount; 
                            //models.cMemo; 
                            //models.iQuotedPrice;


                            //models.cFree1; 
                            //models.cFree2; 
                            //models.bFH; 
                            models.iSOsID = lIDDetails;
                            models.KL = 100;
                            models.KL2 = 100;
                            models.cInvName = dtInv.Rows[0]["cInvName"].ToString().Trim();
                            //models.iTaxRate = 7;                  //需要默认值
                            models.cDefine22 = s客户订单号;
                            //models.cDefine23; 
                            //models.cDefine24; 
                            //models.cDefine25; 
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
                            //models.cDefine28; 
                            //models.cDefine29; 
                            //models.cDefine30;
                            //models.cDefine31; 
                            //models.cDefine32; 
                            //models.cDefine33; 
                            //models.cDefine34; 
                            //models.cDefine35; 
                            //models.cDefine36; 
                            //models.cDefine37; 
                            //models.FPurQuan; 
                            //models.fSaleCost; 
                            //models.fSalePrice;
                            //models.cQuoCode; 
                            //models.iQuoID; 
                            //models.cSCloser; 

                            DateTime? d预完工日期 = models.dPreDate;
                            if (d预完工日期 > BaseFunction.ReturnDate("2000-1-1"))
                            {
                                models.dPreMoDate = d预完工日期;
                            }
                            else
                            {
                                sErr = sErr + "行 " + (j + 1).ToString() + " 预完工日期不正确\n";
                                continue;
                            }

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

                            if (dtInv.Rows[0]["cCusInvCode"].ToString().Trim() != "")
                            {
                                models.cCusInvCode = dtInv.Rows[0]["cCusInvCode"].ToString().Trim();
                                models.cCusInvName = dtInv.Rows[0]["cCusInvName"].ToString().Trim();
                            }
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
                            models.bsaleprice = true;
                            //models.bgift; 
                            //models.forecastdid; 
                            //models.cdetailsdemandcode; 
                            //models.cdetailsdemandmemo; 
                            //models.fTransedQty;
                            // models.cbSysBarCode; 
                            //models.fappqty

                            TH.clsU8.DAL.SO_SODetails dals = new TH.clsU8.DAL.SO_SODetails();
                            sSQL = dals.Add(models);
                            iCount = iCount + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            TH.clsU8.Model.SO_SODetails_extradefine modelsE = new TH.clsU8.Model.SO_SODetails_extradefine();
                            modelsE.iSOsID = models.iSOsID;
                            modelsE.cbdefine1 = model.dDate;
                            modelsE.cbdefine2 = model.cDefine4;
                            modelsE.cbdefine5 = 0;
                            TH.clsU8.DAL.SO_SODetails_extradefine dalsE = new TH.clsU8.DAL.SO_SODetails_extradefine();
                            sSQL = dalsE.Add(modelsE);
                            DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }

                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    if (sMsg.Trim() != "")
                    {
                        MsgBox msg = new MsgBox();
                        msg.richTextBox1.Text = "是否继续导入：\n" + sMsg;
                        msg.btn确定.Text = "是";
                        msg.btnCancel.Text = "否";
                        msg.Text = "提示";
                        DialogResult d = msg.ShowDialog();
                        if (d != DialogResult.Yes)
                        { 
                            throw new Exception("请设置价格");
                        }
                    }

                    if (lID > 1000000000)
                    {
                        lID = lID - 1000000000;
                    }
                    if (lIDDetails > 1000000000)
                    {
                        lIDDetails = lIDDetails - 1000000000;
                    }
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDDetails + " where cAcc_Id = '" + s数据库.Substring(7, 3) + "' and cVouchType = 'Somain'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

//                    sSQL = @"
//if exists(select * from VoucherHistory where CardNumber = '17' and cContent is null)
//	update VoucherHistory set cNumber = aaaaaa  where CardNumber = '17' and cContent is null
//else
//	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
//	values('17',null,null,null,'aaaaaa',0)
//";
//                    sSQL = sSQL.Replace("aaaaaa", lCode.ToString());
//                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK\n");
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
                MsgBox msgbox = new MsgBox();
                msgbox.richTextBox1.Text = ee.Message;
                msgbox.ShowDialog();
            }
        }

        private string sJapToChina(object o)
        {
            string s = o.ToString().Trim();

            string sReturn = "";
            switch (s)
            {
                //case "choose": sReturn = "选择"; break;
                case "得意先コード": sReturn = "客户编号"; break;
                case "得意先名称": sReturn = "客户名称"; break;
                case "顧客オーダー№": sReturn = "客户定单号码"; break;
                case "受注№": sReturn = "接受定单号"; break;
                case "受注日": sReturn = "接受订单日期"; break;
                case "製品コード": sReturn = "成品编码"; break;
                case "仕様(分析コード２)": sReturn = "样品（分析编码2）"; break;
                case "仕様２(分析コード３)": sReturn = "样品（分析编码3）"; break;
                case "製品備考": sReturn = "成品备注"; break;
                case "製品備考拡張": sReturn = "成品备注追加"; break;
                case "クラス": sReturn = "类别"; break;
                case "納期": sReturn = "交货期"; break;
                case "通貨": sReturn = "币种"; break;
                case "受注金額合計": sReturn = "接受订单金额合计"; break;
                case "受注金額合計(税抜き)": sReturn = "接受订单金额合计（不含税）"; break;
                case "原価合計": sReturn = "成本合计"; break;
                case "限界利益": sReturn = "边际贡献"; break;
                case "": sReturn = ""; break;
                case "受注数量": sReturn = "接受订单数量"; break;
                case "出荷済数量": sReturn = "发货完成数量"; break;
                case "受注残": sReturn = "接受订单后尚未发货数量"; break;
                case "CNY": sReturn = "RMB"; break;

                //case "USD": sReturn = "$"; break;
                //case "JPY": sReturn = "￥"; break;
                //case "ECB": sReturn = "€"; break;         

                default:
                    sReturn = s; break;
            }

            return sReturn;
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

        //private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        //{
        //    try
        //    {
        //        string s1 = gridView1.GetRowCellValue(e.RowHandle1, gridCol销售订单号).ToString().Trim();
        //        string s2 = gridView1.GetRowCellValue(e.RowHandle2, gridCol销售订单号).ToString().Trim();
        //        if (s1 == s2)
        //        {
        //            e.Merge = true;
        //            e.Handled = true;
        //        }
        //        else
        //        {
        //            e.Merge = false;
        //            e.Handled = true;
        //        }
        //    }
        //    catch { }
        //}

        

        private decimal dPrice(string sCusCode, string sInvCode, decimal dQty, string sCurr, string sDate, out decimal iSalecost)
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

            DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                d = BaseFunction.ReturnDecimal(dt.Rows[0][0], 4);
            }

            iSalecost = BaseFunction.ReturnDecimal(dt.Rows[0][0], 4);

            return d;
        }
    }
}
