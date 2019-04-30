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
    public partial class Frm其他入库单 : Form
    {

        string s服务器;
        string sSA;
        string sPwd;
        string s数据库;
        string s单据号;
        string sConnString;
        string sUserName;


        public Frm其他入库单()
        {
            InitializeComponent();
        }


        public Frm其他入库单(string s1, string s2, string s3, string s4, string s5, string s6)
        {
            InitializeComponent();

            s服务器 = s1;
            sSA = s2;
            sPwd = s3;
            s数据库 = s4;
            s单据号 = s5;
            sUserName = s6;

            sConnString = "server = " + s服务器 + ";uid=" + sSA + ";pwd=" + sPwd + ";database=" + s数据库 + ";timeout = 200";
        }

        DataTable dtSOMain;

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = @"
select a.cCode,b.cSoCode 
from rdrecord08 a inner join rdrecords08 b on a.id = b.id
where b.cSoCode = 'aaaaaa'
";
            sSQL = sSQL.Replace("aaaaaa", s单据号);
            DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageBox.Show("exist \n" + dt.Rows[0]["cCode"].ToString().Trim());
                this.Close();
                return;
            }

            sSQL = @"
select * 
from SO_SOMain a inner join SO_SODetails b on a.ID = b.ID
    left join _SystemSet c on a.cSTCode = c.cSTCode
    left join Inventory d on b.cInvCode = d.cInvCode
where a.cSOCode = 'aaaaaa'
order by b.autoid
";
            sSQL = sSQL.Replace("aaaaaa", s单据号);
            dtSOMain = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];

            if (dtSOMain == null || dtSOMain.Rows.Count == 0)
            {
                throw new Exception("Please check sale order");
            }
            string sAudit = dtSOMain.Rows[0]["cVerifier"].ToString().Trim();
            string sClose = dtSOMain.Rows[0]["cCloser"].ToString().Trim();
            if (sClose != "")
            {
                DialogResult d = MessageBox.Show("Sale order is closed ,is continue？", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    this.Close();
                }
            }
            if (sAudit == "")
            {
                DialogResult d = MessageBox.Show("Sale order is not approve ,is continue？", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d != DialogResult.Yes)
                {
                    this.Close();
                }
            }

            lookUpEditcWhCode.EditValue = dtSOMain.Rows[0]["cWhCode"].ToString().Trim();
            lookUpEditRd_Style.EditValue = dtSOMain.Rows[0]["cRdCode"].ToString().Trim();

            gridControl1.DataSource = dtSOMain;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.BestFitColumns();
        }

        private void SetLookup()
        {
            string sSQL = @"
SELECT cRdCode,cRdName FROM Rd_Style WHERE bRdEnd = 1 AND bRdFlag = 1 ORDER BY cRdCode
";
            DataTable dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            lookUpEditRd_Style.Properties.DataSource = dt;

            sSQL = @"
select cWhCode,cWhName from Warehouse order by cWhCode
";
            dt = DbHelperSQL.ExecuteDataset(sConnString, CommandType.Text, sSQL).Tables[0];
            lookUpEditcWhCode.Properties.DataSource = dt;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                if (lookUpEditRd_Style.EditValue == null || lookUpEditRd_Style.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("Please choose inventory-in type");
                }
                if (lookUpEditcWhCode.EditValue == null || lookUpEditcWhCode.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("Please choose warehouse");
                }

                string sErr = "";
                int iCount = 0;
                SqlConnection conn = new SqlConnection(sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select getdate()";
                    DateTime dNow = BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                    DateTime dNowDate = BaseFunction.ReturnDate(dNow.ToString("yyyy-MM-dd"));

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
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
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
                    int i结账 = BaseFunction.ReturnInt(dt.Rows[0]["bflag"]);
                    if (i结账 > 0)
                    {
                        throw new Exception(dDate.ToString("yyyy-MM") + " have checked out");
                    }

                    //获得单据号
                    sSQL = "select cNumber from VoucherHistory with (ROWLOCK) WHERE (CardNumber = '0301') AND (cContent = '日期') AND (cContentRule = 'YYYY') AND (cSeed = 'aaaaaa')";
                    sSQL = sSQL.Replace("aaaaaa", dDate.ToString("yyyy"));
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

                    long lID = -1;
                    long lIDRDDetails = -1;
                    sSQL = @"
declare @p5 int
set @p5=aaaaaa
declare @p6 int
set @p6=bbbbbb
exec sp_GetId N'00',N'dddddd',N'rd',cccccc,@p5 output,@p6 output,default
select @p5, @p6
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    sSQL = sSQL.Replace("bbbbbb", lIDRDDetails.ToString());
                    sSQL = sSQL.Replace("cccccc", 1.ToString());
                    sSQL = sSQL.Replace("dddddd", s数据库.Substring(7, 3));
                    dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    lID = BaseFunction.ReturnLong(dt.Rows[0][0]) - 1;
                    lIDRDDetails = BaseFunction.ReturnLong(dt.Rows[0][1]) - 1;

                    //ArrayList aList = new ArrayList();

                    TH.clsU8.Model.RdRecord08 model = new TH.clsU8.Model.RdRecord08();
                    lID += 1;
                    model.ID = lID;

                    model.bRdFlag = 1;
                    model.cVouchType = "08";
                    model.cBusType = "其他入库";
                    model.cSource = "库存";
                    //model.cBusCode = 
                    model.cWhCode = lookUpEditcWhCode.EditValue.ToString().Trim();       //需要仓库默认值
                    model.dDate = dDate;        //需要默认值

                    lCodeRD += 1;
                    string sCodeRD = lCodeRD.ToString();
                    while (sCodeRD.Length < 6)
                    {
                        sCodeRD = "0" + sCodeRD;
                    }
                    model.cCode = "MI" + model.dDate.Year.ToString() + sCodeRD; 
                    model.cRdCode = lookUpEditRd_Style.EditValue.ToString().Trim();      //需要默认值
                    //model.cDepCode = ""
                    //model.cPersonCode; 
                    //model.cPTCode; 
                    //model.cSTCode; 
                    //model.cCusCode; 
                    //model.cVenCode; 
                    //model.cOrderCode; 
                    //model.cARVCode; 
                    //model.cBillCode; 
                    //model.cDLCode; 
                    //model.cProBatch; 
                    model.cHandler = sUserName;
                    //model.cMemo; 
                    model.bTransFlag = false;
                    //model.cAccounter; 
                    model.cMaker = sUserName;
                    model.cDefine1 = dtSOMain.Rows[0]["cDefine1"].ToString();
                    model.cDefine2 = dtSOMain.Rows[0]["cDefine2"].ToString();
                    model.cDefine3 = dtSOMain.Rows[0]["cDefine3"].ToString();

                    if (dtSOMain.Rows[0]["cDefine4"].ToString().Trim() != "")
                    {
                        model.cDefine4 = BaseFunction.ReturnDate(dtSOMain.Rows[0]["cDefine4"]);
                    }
                    if (dtSOMain.Rows[0]["cDefine5"].ToString().Trim() != "")
                    {
                        model.cDefine5 = BaseFunction.ReturnLong(dtSOMain.Rows[0]["cDefine5"]);
                    }
                    if (dtSOMain.Rows[0]["cDefine6"].ToString().Trim() != "")
                    {
                        model.cDefine6 = BaseFunction.ReturnDate(dtSOMain.Rows[0]["cDefine6"]);
                    }
                    if (dtSOMain.Rows[0]["cDefine7"].ToString().Trim() != "")
                    {
                        model.cDefine7 = BaseFunction.ReturnDecimal(dtSOMain.Rows[0]["cDefine7"]);
                    }
                    model.cDefine8 = dtSOMain.Rows[0]["cDefine8"].ToString();
                    model.cDefine9 = dtSOMain.Rows[0]["cDefine9"].ToString();
                    model.cDefine10 = dtSOMain.Rows[0]["cDefine10"].ToString();
                    //model.dKeepDate; 
                    model.dVeriDate = dDate;
                    model.bpufirst = false;
                    model.biafirst = false;
                    //model.iMQuantity; 
                    //model.dARVDate; 
                    //model.cChkCode; 
                    //model.dChkDate; 
                    //model.cChkPerson; 
                    model.VT_ID = 67;
                    model.bIsSTQc = false;
                    model.cDefine11 = dtSOMain.Rows[0]["cDefine11"].ToString();
                    model.cDefine12 = dtSOMain.Rows[0]["cDefine12"].ToString();
                    model.cDefine13 = dtSOMain.Rows[0]["cDefine13"].ToString();
                    //model.cDefine14 = dtSOMain.Rows[0]["cDefine14"].ToString();
                    model.cDefine14 = dtSOMain.Rows[0]["cSOCode"].ToString();

                    if (dtSOMain.Rows[0]["cDefine15"].ToString() != "")
                    {
                        model.cDefine15 = BaseFunction.ReturnLong(dtSOMain.Rows[0]["cDefine15"]);
                    }
                    if (dtSOMain.Rows[0]["cDefine16"].ToString() != "")
                    {
                        model.cDefine16 = BaseFunction.ReturnDecimal(dtSOMain.Rows[0]["cDefine16"]);
                    }
                    //model.gspcheck; 
                    //model.ufts; 
                    //model.iExchRate; 
                    //model.cExch_Name; 
                    model.bOMFirst = false;
                    model.bFromPreYear = false;
                    model.bIsLsQuery = false;
                    model.bIsComplement = 0;
                    model.iDiscountTaxType = 0;
                    model.ireturncount = 0;
                    model.iverifystate = 0;
                    model.iswfcontrolled = 0;
                    //model.cModifyPerson; 
                    //model.dModifyDate; 
                    //model.dnmaketime; 
                    //model.dnmodifytime; 
                    //model.dnverifytime; 
                    model.bredvouch = 0;
                    //model.iFlowId; 
                    //model.cPZID; 
                    //model.cSourceLs; 
                    //model.cSourceCodeLs; 
                    model.iPrintCount = 0;
                    //model.ctransflag; 
                    //model.csysbarcode;
                    //model.cCurrentAuditor;
                    TH.clsU8.DAL.RdRecord08 dal = new TH.clsU8.DAL.RdRecord08();
                    sSQL = dal.Add(model);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < dtSOMain.Rows.Count; i++)
                    {
                        lIDRDDetails += 1;

                        TH.clsU8.Model.rdrecords08 modelsRD = new TH.clsU8.Model.rdrecords08();
                        modelsRD.AutoID = lIDRDDetails;


                        modelsRD.ID = model.ID;
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
                            if (modelsRD.cBatch == "")
                            {
                                modelsRD.cBatch = dNow.ToString("yyyyMMdd");
                            }
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

                        TH.clsU8.DAL.rdrecords08 dalsRD = new TH.clsU8.DAL.rdrecords08();
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
                        sSQL = sSQL.Replace("@cWhCode", model.cWhCode);
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

                    }


                    if (sErr != "")
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = @"
exec ST_SaveForStock N'08',N'aaaaaa',1,0 ,1
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
exec ST_SaveForTrackStock N'08',N'aaaaaa', 0 ,1
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
exec IA_SP_WriteUnAccountVouchForST 'aaaaaa',N'08'
";
                    sSQL = sSQL.Replace("aaaaaa", lID.ToString());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                    if (lID > 1000000000)
                    {
                        lID = lID - 1000000000;
                    }
                    if (lIDRDDetails > 1000000000)
                    {
                        lIDRDDetails = lIDRDDetails - 1000000000;
                    }
                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID.ToString() + ",iChildId = " + lIDRDDetails + " where cAcc_Id = '" + s数据库.Substring(7, 3) + "' and cVouchType = 'rd'";
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = @"
if exists(select * from VoucherHistory where  (CardNumber = '0301') AND (cContent = '日期') AND (cContentRule = 'YYYY') AND (cSeed = 'bbbbbb'))
	update VoucherHistory set cNumber = aaaaaa  where  (CardNumber = '0301') AND (cContent = '日期') AND (cContentRule = 'YYYY') AND (cSeed = 'bbbbbb')
else
	insert into VoucherHistory(CardNumber,cContent,cContentRule,cSeed,cNumber,bEmpty)
	values('0301','日期','YYYY','bbbbbb','1',0)
";
                    sSQL = sSQL.Replace("aaaaaa", lCodeRD.ToString());
                    sSQL = sSQL.Replace("bbbbbb", model.dDate.ToString("yyyy"));
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCount > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n" + model.cCode);
                        this.Close();
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
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
    }
}
