using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmSalebillvouch_Add : Form
    {
        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public DataTable dtGrid;
        public string cDLCode;
        public string cSBVCode = "";

        public FrmSalebillvouch_Add(string conn, string userid, string username, string logdate, string accid)
        {
            InitializeComponent();
            Conn = conn;
            sUserID = userid;
            sUserName = username;
            sLogDate = logdate;
            sAccID = accid;
        }

        public FrmSalebillvouch_Add(string conn, string userid, string username, string logdate, string accid, string scSBVCode)
        {
            InitializeComponent();
            Conn = conn;
            sUserID = userid;
            sUserName = username;
            sLogDate = logdate;
            sAccID = accid;
            cSBVCode = scSBVCode;
            txtInvoice.Text = cSBVCode;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                dtGrid = new DataTable();

                系统服务.规格化.GetGridViewSet(gridView1);

                SetLookUp();
                if (cSBVCode != "")
                {
                    string sSQL = "select * from _DispatchLists_SaleBillVouchs where SaleBillCode='" + cSBVCode + "'";
                    dtGrid = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                    if (dtGrid.Rows.Count > 0)
                    {
                        lookUpEditcCode1.Text = dtGrid.Rows[0]["DLCode"].ToString();
                        lookUpEditcCode1.Enabled = false;
                        btnSel_Click(null, null);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获取销售发货单明细失败！  " + ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = "select cDLCode from DispatchList order by cDLCode desc";
            DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCode1.Properties.DataSource = dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                dtGrid = new DataTable();

                if (lookUpEditcCode1.Text.Trim() != "")
                {
                    cDLCode = lookUpEditcCode1.Text.Trim();
                }
                string sSQL = "";
                if (cSBVCode == "")
                {
                    sSQL = @"
select cast(0 as bit) as choose,b.cDefine29 as item,a.DLID,a.cDLCode,a.cDepCode,a.cPersonCode,a.cSOCode,a.cexch_name,a.cBusType,a.cCusCode
,b.iTaxRate,a.iExchRate,b.iInvExchRate,b.cUnitID,b.cinvcode,i.cInvName,c.cCusName,b.cWhCode
,sum(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0))  as UniQty,sum(isnull(b.iNum,0) - isnull(iSettleNum,0))  as UniNum
,SUM(b.iSum*(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0))) as UniSum
,convert(decimal(18, 6),null) as NewQty
,a.cDefine1,a.cDefine2,a.cDefine3,a.cDefine4,a.cDefine5,a.cDefine6,a.cDefine7,a.cDefine8,a.cDefine9,a.cDefine10
,a.cDefine11,a.cDefine12,a.cDefine13,a.cDefine14,a.cDefine15,a.cDefine16 
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
left join Inventory i on b.cInvCode=i.cInvCode 
LEFT JOIN Person P ON a.cPersonCode=p.cPersonCode 
left join Customer c on a.cCusCode=c.cCusCode 
where isnull(b.cDefine29,'')<>'' and isnull(b.cSCloser,'') = '' and isnull(a.cCloser,'') = ''  and isnull(a.cVerifier,'') <> '' and 1=1 
group by a.DLID,a.cDLCode,a.cDepCode,a.cPersonCode,a.cSOCode,a.cexch_name,a.cBusType,a.cCusCode
,b.iTaxRate,a.iExchRate,b.iInvExchRate,b.cUnitID,b.cinvcode,i.cInvName,c.cCusName,b.cWhCode
,a.cDefine1,a.cDefine2,a.cDefine3,a.cDefine4,a.cDefine5,a.cDefine6,a.cDefine7,a.cDefine8,a.cDefine9,a.cDefine10
,a.cDefine11,a.cDefine12,a.cDefine13,a.cDefine14,a.cDefine15,a.cDefine16
,b.cDefine29 
having sum(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0)) >0 and SUM(b.iSum*(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0)))>0
order by b.cDefine29,a.DLID
";

                    if (cDLCode != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode = '" + cDLCode + "'");
                    }
                }
                else
                {
                    sSQL = @"
select c.*,c.SaleBillsID from SaleBillVouch a  
left join SaleBillVouchs b on a.SBVID=b.SBVID 
left join (
select cast(0 as bit) as choose,b.cDefine29 as item,a.DLID,a.cDLCode,a.cDepCode,a.cPersonCode,a.cSOCode,a.cexch_name,a.cBusType,a.cCusCode,ds.SaleBillsID
,b.iTaxRate,a.iExchRate,b.iInvExchRate,b.cUnitID,b.cinvcode,i.cInvName,c.cCusName,b.cWhCode
,sum(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0) + ISNULL(ds.DLsQty,0))  as UniQty,sum(isnull(b.iNum,0) - isnull(iSettleNum,0))  as UniNum
,SUM(b.iSum*(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0) + ISNULL(ds.DLsQty,0))) as UniSum
,SUM(ds.DLsQty) as NewQty
,a.cDefine1,a.cDefine2,a.cDefine3,a.cDefine4,a.cDefine5,a.cDefine6,a.cDefine7,a.cDefine8,a.cDefine9,a.cDefine10
,a.cDefine11,a.cDefine12,a.cDefine13,a.cDefine14,a.cDefine15,a.cDefine16 
from DispatchList a inner join DispatchLists b on a.DLID = b.DLID
left join Inventory i on b.cInvCode=i.cInvCode 
LEFT JOIN Person P ON a.cPersonCode=p.cPersonCode 
left join Customer c on a.cCusCode=c.cCusCode 
left join (select SaleBillsID,DLsID,SUM(DLsQty) as DLsQty from  _DispatchLists_SaleBillVouchs where 2=2  group by SaleBillsID,DLsID) ds on b.AutoID=ds.DLsID
where isnull(b.cDefine29,'')<>'' and isnull(b.cSCloser,'') = '' and isnull(a.cCloser,'') = ''  and isnull(a.cVerifier,'') <> '' and 1=1
group by a.DLID,a.cDLCode,a.cDepCode,a.cPersonCode,a.cSOCode,a.cexch_name,a.cBusType,a.cCusCode,ds.SaleBillsID
,b.iTaxRate,a.iExchRate,b.iInvExchRate,b.cUnitID,b.cinvcode,i.cInvName,c.cCusName,b.cWhCode
,a.cDefine1,a.cDefine2,a.cDefine3,a.cDefine4,a.cDefine5,a.cDefine6,a.cDefine7,a.cDefine8,a.cDefine9,a.cDefine10
,a.cDefine11,a.cDefine12,a.cDefine13,a.cDefine14,a.cDefine15,a.cDefine16
,b.cDefine29 
having sum(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0)) >0 and SUM(b.iSum*(isnull(b.iQuantity,0) - isnull(iSettleQuantity,0)))>0 and sum(DLsQty)>0
) c on b.cDefine29=c.item and b.cInvCode=c.cInvCode
where 3=3 
";

                    if (cDLCode != "")
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode = '" + cDLCode + "'");
                    }
                    if (cSBVCode != "")
                    {
                        sSQL = sSQL.Replace("2=2", "2=2 and SaleBillCode = '" + cSBVCode + "'");
                        sSQL = sSQL.Replace("3=3", "3=3 and a.cSBVCode = '" + cSBVCode + "'");
                    }
                }
                dtGrid = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                gridControl1.DataSource = dtGrid;
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
                    gridView1.SetRowCellValue(i, gridColNewQty, gridView1.GetRowCellValue(i, gridColUniQty));
                }
            }
            catch { }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "";
                string sErr = "";

                //1.  判断是否结账
                sSQL = "select * from gl_mend where iyear=year('" + sLogDate + "') and iperiod=month('" + sLogDate + "')";
                DataTable dtTemp = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count < 1)
                {
                    throw new Exception("判断模块结账失败");
                }
                string iR =dtTemp.Rows[0]["bflag_ST"].ToString();
                if (iR == "1")
                {
                    throw new Exception("当前月份仓库已经结账");
                }
                iR = dtTemp.Rows[0]["bflag_AR"].ToString();
                if (iR == "1")
                {
                    throw new Exception("当前月份应收已经结账");
                }

                int Count = 0;
                if (dtGrid == null && dtGrid.Rows.Count == 0)
                {
                    throw new Exception("未查到可生成发票的单据");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                int ic = 0;
                try
                {
                    #region 新增
                    if (cSBVCode == "")
                    {
                        //2. 获得单据ID
                        sSQL = "SELECT iFatherId,iChildId FROM UFSystem..UA_Identity WHERE cAcc_Id = '" + sAccID + "' AND cVouchType = 'BILLVOUCH'";
                        DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        long lID = 系统服务.规格化.ReturnObjectToLong(dt.Rows[0]["iFatherId"]);
                        lID++;
                        long lID_1 = sCode(lID);
                        long lIDDetail = 系统服务.规格化.ReturnObjectToLong(dt.Rows[0]["iChildId"]);
                        //3. 获得单据号
                        long iCode = 0;
                        sSQL = "select isnull(cNumber,0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='13' and cContent='单据日期' and cSeed=year('" + sLogDate + "')";
                        dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtTemp == null || dtTemp.Rows.Count < 1)
                        {
                            iCode = 1;
                        }
                        else
                        {
                            iCode = 系统服务.规格化.ReturnObjectToLong(dtTemp.Rows[0]["Maxnumber"]) + 1;
                        }
                        DateTime sDate = DateTime.Parse(sLogDate);

                        string cCode = sCode(iCode, sDate);
                        string cDepCode = dtGrid.Rows[0]["cDepCode"].ToString().Trim();
                        string cPersonCode = dtGrid.Rows[0]["cPersonCode"].ToString().Trim();
                        string cSOCode = dtGrid.Rows[0]["cSOCode"].ToString().Trim();
                        string cCusCode = dtGrid.Rows[0]["cCusCode"].ToString().Trim();
                        string cexch_name = dtGrid.Rows[0]["cexch_name"].ToString().Trim();
                        string cCusName = dtGrid.Rows[0]["cCusName"].ToString().Trim();
                        string DLID = dtGrid.Rows[0]["DLID"].ToString().Trim();
                        string cBusType = dtGrid.Rows[0]["cBusType"].ToString().Trim();

                        #region cDefine
                        string cDefine1 = dtGrid.Rows[0]["cDefine1"].ToString().Trim();
                        string cDefine2 = dtGrid.Rows[0]["cDefine2"].ToString().Trim();
                        string cDefine3 = dtGrid.Rows[0]["cDefine3"].ToString().Trim();
                        string cDefine4 = dtGrid.Rows[0]["cDefine4"].ToString().Trim();
                        string cDefine5 = dtGrid.Rows[0]["cDefine5"].ToString().Trim();
                        string cDefine6 = dtGrid.Rows[0]["cDefine6"].ToString().Trim();
                        string cDefine7 = dtGrid.Rows[0]["cDefine7"].ToString().Trim();
                        string cDefine8 = dtGrid.Rows[0]["cDefine8"].ToString().Trim();
                        string cDefine9 = dtGrid.Rows[0]["cDefine9"].ToString().Trim();
                        string cDefine10 = dtGrid.Rows[0]["cDefine10"].ToString().Trim();
                        string cDefine11 = dtGrid.Rows[0]["cDefine11"].ToString().Trim();
                        string cDefine12 = dtGrid.Rows[0]["cDefine12"].ToString().Trim();
                        string cDefine13 = dtGrid.Rows[0]["cDefine13"].ToString().Trim();
                        string cDefine14 = dtGrid.Rows[0]["cDefine14"].ToString().Trim();
                        string cDefine15 = dtGrid.Rows[0]["cDefine15"].ToString().Trim();
                        string cDefine16 = dtGrid.Rows[0]["cDefine16"].ToString().Trim();
                        #endregion
                        decimal d税率 = 系统服务.规格化.ReturnDecimal(dtGrid.Rows[0]["iTaxRate"], 2);
                        decimal d汇率 = 系统服务.规格化.ReturnDecimal(dtGrid.Rows[0]["iExchRate"], 2);

                        #region 发票表头
                        Model.SaleBillVouch model = new Model.SaleBillVouch();

                        model.SBVID = lID_1;
                        model.cSBVCode = cCode;
                        model.cVouchType = "27";
                        model.cSTCode = "10";
                        model.iVTid = 17;
                        model.dDate = sDate;
                        model.cDepCode = cDepCode;
                        model.cPersonCode = cPersonCode;
                        model.cSOCode = cSOCode;
                        model.cCusCode = cCusCode;
                        model.cexch_name = cexch_name;
                        model.iTaxRate = d税率;
                        model.iExchRate = d汇率;
                        model.bReturnFlag = false;
                        model.cMaker = sUserName;
                        model.cBusType = cBusType;
                        model.bFirst = false;
                        model.iDisp = 1;
                        model.cCusName = cCusName;
                        model.cSource = "销售";

                        #region cDefine
                        model.cDefine1 = cDefine1;
                        model.cDefine2 = cDefine2;
                        model.cDefine3 = cDefine3;
                        if (cDefine4 != "")
                        {
                            model.cDefine4 = DateTime.Parse(cDefine4);
                        }
                        if (cDefine5 != "")
                        {
                            model.cDefine5 = 系统服务.规格化.ReturnInt(cDefine5);
                        }
                        if (cDefine6 != "")
                        {
                            model.cDefine6 = DateTime.Parse(cDefine6);
                        }
                        if (cDefine7 != "")
                        {
                            model.cDefine7 = 系统服务.规格化.ReturnDecimal(cDefine7);
                        }
                        model.cDefine8 = cDefine8;
                        model.cDefine9 = cDefine9;
                        model.cDefine10 = cDefine10;
                        model.cDefine11 = cDefine11;
                        model.cDefine12 = cDefine12;
                        model.cDefine13 = cDefine13;
                        model.cDefine14 = cDefine14;
                        if (cDefine15 != "")
                        {
                            model.cDefine15 = 系统服务.规格化.ReturnInt(cDefine15);
                        }
                        if (cDefine16 != "")
                        {
                            model.cDefine16 = 系统服务.规格化.ReturnDecimal(cDefine16);
                        }
                        #endregion

                        DAL.SaleBillVouch dal = new DAL.SaleBillVouch();
                        sSQL = dal.Add(model);
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        #endregion

                        #region 发票表体
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            decimal d数量 = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(i, gridColNewQty), 6);
                            if (d数量 > 0)
                            {
                                decimal UniQty = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniQty), 6);

                                string cWhCode = gridView1.GetRowCellValue(i, gridColcWhCode).ToString();
                                string cInvCode = gridView1.GetRowCellValue(i, gridColcinvcode).ToString();
                                string cInvName = gridView1.GetRowCellValue(i, gridColcInvName).ToString();
                                string cDefine29 = gridView1.GetRowCellValue(i, gridColitem).ToString();
                                decimal iInvExchRate = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiInvExchRate).ToString(), 4);
                                string cUnitID = gridView1.GetRowCellValue(i, gridColcUnitID).ToString();


                                decimal old数量 = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniQty), 6);
                                decimal d件数 = 系统服务.规格化.ReturnDecimal(0, 2);

                                decimal d原币含税单价 = 0;
                                decimal d原币无税单价 = 0;
                                decimal d原币含税金额 = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniSum).ToString(), 4) * d数量 / old数量;
                                decimal d原币无税金额 = 0;
                                decimal d原币税额 = 0;

                                decimal d本币含税单价 = 0;
                                decimal d本币无税单价 = 0;
                                decimal d本币含税金额 = 0;
                                decimal d本币无税金额 = 0;
                                decimal d本币税额 = 0;

                                GetMoney(d税率, d汇率, d数量, d原币含税金额, d原币无税金额,
                                    out d原币含税单价, out d原币无税单价, out d原币含税金额, out d原币无税金额, out d原币税额,
                                    out d本币含税单价, out d本币无税单价, out d本币含税金额, out d本币无税金额, out d本币税额);

                                Model.SaleBillVouchs models = new Model.SaleBillVouchs();
                                lIDDetail++;
                                long lIDDetail_1 = sCode(lIDDetail);
                                models.AutoID = lIDDetail_1;
                                models.SBVID = lID_1;
                                models.cWhCode = cWhCode;
                                models.cInvCode = cInvCode;
                                models.iQuantity = d数量;
                                models.iNum = d件数;
                                models.iQuotedPrice = 0;
                                //models.iSOsID = iSOsID;
                                //models.iDLsID = iDLsID;
                                models.KL = 100;
                                models.KL2 = 100;
                                models.cInvName = cInvName;
                                //models.cSoCode = cSoCode;
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

                                #region cDefine
                                //models.cDefine22 = cDefine22;
                                //models.cDefine23 = cDefine23;
                                //models.cDefine24 = cDefine24;
                                //models.cDefine25 = cDefine25;
                                //models.cDefine26 = cDefine26;
                                //models.cDefine27 = cDefine27;
                                //models.cDefine28 = cDefine28;
                                models.cDefine29 = cDefine29;
                                //models.cDefine30 = cDefine30;
                                //models.cDefine31 = cDefine31;
                                //models.cDefine32 = cDefine32;
                                //models.cDefine33 = cDefine33;
                                //models.cDefine34 = cDefine34;
                                //models.cDefine35 = cDefine35;
                                //if (cDefine36.ToString() != "1900/1/1 0:00:00")
                                //{
                                //    models.cDefine36 = cDefine36;
                                //}
                                //if (cDefine37.ToString() != "1900/1/1 0:00:00")
                                //{
                                //    models.cDefine37 = cDefine37;
                                //}
                                #endregion

                                DAL.SaleBillVouchs dals = new DAL.SaleBillVouchs();
                                sSQL = dals.Add(models);
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                #region 反写
                                sSQL = @"select AutoID,iQuantity,iNum,iSettleQuantity,iSettleNum,isnull(b.iQuantity,0) - isnull(iSettleQuantity,0)  as UniQty,isnull(b.iNum,0) - isnull(iSettleNum,0)  as UniNum 
                        from DispatchList a inner join DispatchLists b on a.DLID = b.DLID where b.cDefine29='" + cDefine29 + "' and b.cinvcode='" + cInvCode + "' and 1=1 ";
                                if (cDLCode != "")
                                {
                                    sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode = '" + cDLCode + "'");
                                }
                                DataTable dtf = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                for (int j = 0; j < dtf.Rows.Count; j++)
                                {
                                    string fAutoID = dtf.Rows[j]["AutoID"].ToString();
                                    decimal fUniQty = 系统服务.规格化.ReturnDecimal(dtf.Rows[j]["UniQty"].ToString(), 6);
                                    decimal fUniNum = 系统服务.规格化.ReturnDecimal(dtf.Rows[j]["UniNum"].ToString(), 6);

                                    if (d数量 > 0)
                                    {
                                        if (d数量 >= fUniQty)
                                        {
                                            sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity+" + fUniQty + ",iSettleNum=iSettleNum+" + fUniNum + "  where AutoID='" + fAutoID + "'";
                                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            sSQL = @"INSERT INTO _DispatchLists_SaleBillVouchs(SaleBillsID,DLsID,DLsQty,SaleBillsQty,DLCode,SaleBillCode,Remark,CreateUid)
                                    VALUES ('" + lIDDetail_1 + "','" + fAutoID + "','" + fUniQty + "','" + fUniQty + "' ,'" + cDLCode + "' ,'" + cCode + "' ,'','" + sUserID + "')";
                                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            d数量 = d数量 - fUniQty;
                                            d件数 = d件数 - fUniNum;
                                        }
                                        else
                                        {
                                            sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity+" + d数量 + ",iSettleNum=iSettleNum+" + d件数 + "  where AutoID='" + fAutoID + "'";
                                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            sSQL = @"INSERT INTO _DispatchLists_SaleBillVouchs(SaleBillsID,DLsID,DLsQty,SaleBillsQty,DLCode,SaleBillCode,Remark,CreateUid)
                                    VALUES ('" + lIDDetail_1 + "','" + fAutoID + "','" + d数量 + "','" + d数量 + "' ,'" + cDLCode + "' ,'" + cCode + "' ,'','" + sUserID + "')";
                                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            d数量 = 0;
                                            d件数 = 0;
                                            break;
                                        }
                                    }
                                }
                                if (d数量 > 0)
                                {
                                    sErr = sErr + "第" + (i + 1) + "行超出可开发票数量\n";
                                }
                                #endregion
                            }

                        }
                        #endregion

                        #region 更新单据号
                        sSQL = "UPDATE VoucherHistory SET cNumber = 111111 WHERE CardNumber='13' and cContent='单据日期' and cSeed=year('" + sLogDate + "')";
                        sSQL = sSQL.Replace("111111", iCode.ToString());
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "UPDATE UFSystem..UA_Identity SET iFatherId = 111111,iChildId = 222222 WHERE cAcc_Id = '" + sAccID + "' AND cVouchType = 'BILLVOUCH'";
                        sSQL = sSQL.Replace("111111", lID.ToString());
                        sSQL = sSQL.Replace("222222", lIDDetail.ToString());
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        #endregion

                        MessageBox.Show("生成发票成功，发票号：" + cCode);
                    }
                    else
                    {
                        int iCount = 0;
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            decimal dold数量 = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniQty), 6);
                            decimal d数量 = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(i, gridColNewQty), 6);
                            string SaleBillsID=gridView1.GetRowCellValue(i, gridColSaleBillsID).ToString();

                            sSQL = "select * from SaleBillVouch a  left join SaleBillVouchs b on a.SBVID=b.SBVID where AutoID=" + SaleBillsID;
                            DataTable dtsv = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            decimal dsvQty = 系统服务.规格化.ReturnDecimal(dtsv.Rows[0]["iQuantity"].ToString(), 6);
                            decimal dsvMoney = 系统服务.规格化.ReturnDecimal(dtsv.Rows[0]["iMoney"].ToString(), 6);
                            string cDefine29 = dtsv.Rows[0]["cDefine29"].ToString();
                            string cInvCode = dtsv.Rows[0]["cInvCode"].ToString();
                            if (d数量 == 0)
                            {
                                //删除行
                                sSQL = "delete from SaleBillVouchs where AutoID=" + SaleBillsID;
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "select * from _DispatchLists_SaleBillVouchs where SaleBillsID=" + SaleBillsID;
                                DataTable dtf = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                for (int j = 0; j < dtf.Rows.Count; j++)
                                {
                                    string fDLsID = dtf.Rows[j]["DLsID"].ToString();
                                    decimal fDLsQty = 系统服务.规格化.ReturnDecimal(dtf.Rows[j]["DLsQty"].ToString(), 6);

                                    decimal d汇率 = 系统服务.规格化.ReturnDecimal(dtsv.Rows[0]["iExchRate"].ToString(), 6);
                                    decimal d税率 = 系统服务.规格化.ReturnDecimal(dtsv.Rows[0]["iTaxRate"].ToString(), 6);

                                    decimal d件数 = 系统服务.规格化.ReturnDecimal(0, 2);

                                    sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity-" + fDLsQty + ",iSettleNum=iSettleNum-" + 0 + "  where AutoID='" + fDLsID + "'";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }

                                sSQL = "delete from _DispatchLists_SaleBillVouchs where SaleBillsID=" + SaleBillsID;
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else if (dsvQty != d数量)
                            {
                                iCount = iCount + 1;
                                if (1 == 1)//更新发票
                                {
                                    decimal d汇率 = 系统服务.规格化.ReturnDecimal(dtsv.Rows[0]["iExchRate"].ToString(), 6);
                                    decimal d税率 = 系统服务.规格化.ReturnDecimal(dtsv.Rows[0]["iTaxRate"].ToString(), 6);

                                    decimal d件数 = 系统服务.规格化.ReturnDecimal(0, 2);

                                    decimal d原币含税单价 = 0;
                                    decimal d原币无税单价 = 0;
                                    decimal d原币含税金额 = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniSum).ToString(), 4) * d数量 / dsvQty;
                                    decimal d原币无税金额 = 0;
                                    decimal d原币税额 = 0;

                                    decimal d本币含税单价 = 0;
                                    decimal d本币无税单价 = 0;
                                    decimal d本币含税金额 = 0;
                                    decimal d本币无税金额 = 0;
                                    decimal d本币税额 = 0;

                                    GetMoney(d税率, d汇率, d数量, d原币含税金额, d原币无税金额,
                                        out d原币含税单价, out d原币无税单价, out d原币含税金额, out d原币无税金额, out d原币税额,
                                        out d本币含税单价, out d本币无税单价, out d本币含税金额, out d本币无税金额, out d本币税额);

                                    sSQL = "update SaleBillVouchs set iQuantity=" + d数量 +
                                        ",iNum=" + 0 +
                                        ",iTaxUnitPrice=" + d原币含税单价 +
                                        ",iUnitPrice=" + d原币无税单价 +
                                        ",iSum=" + d原币含税金额 +
                                        ",iMoney=" + d原币无税金额 +
                                        ",iTax=" + d原币税额 +
                                        ",iNatUnitPrice=" + d本币无税单价 +
                                        ",iNatSum=" + d本币含税金额 +
                                        ",iNatMoney=" + d本币无税金额 +
                                        " where AutoID=" + SaleBillsID;
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }

                                if (dsvQty > d数量)//如果原来发票的数量大于本发票数量
                                {
                                    decimal sQty = dsvQty - d数量;//减去本单据的数量

                                    sSQL = "select * from _DispatchLists_SaleBillVouchs where SaleBillsID=" + SaleBillsID;
                                    DataTable dtf = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    for (int j = 0; j < dtf.Rows.Count; j++)
                                    {
                                        if (sQty > 0)
                                        {
                                            string fDLsID = dtf.Rows[j]["DLsID"].ToString();
                                            decimal fDLsQty = 系统服务.规格化.ReturnDecimal(dtf.Rows[j]["DLsQty"].ToString(), 6);

                                            if (sQty >= fDLsQty)//未扣减数量大于中间表数量，删除中间表
                                            {
                                                sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity-" + fDLsQty + ",iSettleNum=iSettleNum-" + 0 + "  where AutoID='" + fDLsID + "'";
                                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                                sSQL = "delete from _DispatchLists_SaleBillVouchs where SaleBillsID=" + SaleBillsID + " and DLsID=" + fDLsID;
                                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                                sQty = sQty - fDLsQty;
                                            }
                                            else
                                            {
                                                sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity-" + sQty + ",iSettleNum=iSettleNum-" + 0 + "  where AutoID='" + fDLsID + "'";
                                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                                sSQL = "update _DispatchLists_SaleBillVouchs set DLsQty=DLsQty-" + sQty + ",SaleBillsQty=SaleBillsQty-" + sQty + " where SaleBillsID=" + SaleBillsID + " and DLsID=" + fDLsID;
                                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                                sQty = 0;
                                            }
                                        }
                                        
                                    }
                                }
                                else if (dsvQty < d数量)
                                {
                                    decimal sQty = d数量 - dsvQty;//增加本单据的数量

                                    #region 反写
                                    sSQL = @"select AutoID,iQuantity,iNum,iSettleQuantity,iSettleNum,isnull(b.iQuantity,0) - isnull(iSettleQuantity,0)  as UniQty,isnull(b.iNum,0) - isnull(iSettleNum,0)  as UniNum 
                        from DispatchList a inner join DispatchLists b on a.DLID = b.DLID where b.cDefine29='" + cDefine29 + "' and b.cinvcode='" + cInvCode + "' and 1=1  and  isnull(b.iQuantity,0) - isnull(iSettleQuantity,0)  > 0";
                                    if (cDLCode != "")
                                    {
                                        sSQL = sSQL.Replace("1=1", "1=1 and a.cDLCode = '" + cDLCode + "'");
                                    }
                                    DataTable dtf = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    for (int j = 0; j < dtf.Rows.Count; j++)
                                    {
                                        string fAutoID = dtf.Rows[j]["AutoID"].ToString();
                                        decimal fUniQty = 系统服务.规格化.ReturnDecimal(dtf.Rows[j]["UniQty"].ToString(), 6);
                                        decimal fUniNum = 系统服务.规格化.ReturnDecimal(dtf.Rows[j]["UniNum"].ToString(), 6);

                                        if (sQty > 0)
                                        {
                                            if (sQty >= fUniQty)
                                            {
                                                sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity-" + fUniQty + ",iSettleNum=iSettleNum+" + fUniNum + "  where AutoID='" + fAutoID + "'";
                                                ic = SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                                sSQL = @"INSERT INTO _DispatchLists_SaleBillVouchs(SaleBillsID,DLsID,DLsQty,SaleBillsQty,DLCode,SaleBillCode,Remark,CreateUid)
                                    VALUES ('" + SaleBillsID + "','" + fAutoID + "','" + fUniQty + "','" + fUniQty + "' ,'" + cDLCode + "' ,'" + cSBVCode + "' ,'','" + sUserID + "')";
                                                ic = SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                                sQty = sQty - fUniQty;
                                            }
                                            else
                                            {
                                                sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity+" + sQty + ",iSettleNum=iSettleNum+" + 0 + "  where AutoID='" + fAutoID + "'";
                                                ic = SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                                sSQL = "select * from _DispatchLists_SaleBillVouchs where SaleBillsID=" + SaleBillsID + " and DLsID='" + fAutoID + "'";
                                                DataTable dtds = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                                if (dtds.Rows.Count == 0)
                                                {
                                                    sSQL = @"INSERT INTO _DispatchLists_SaleBillVouchs(SaleBillsID,DLsID,DLsQty,SaleBillsQty,DLCode,SaleBillCode,Remark,CreateUid)
                                    VALUES ('" + SaleBillsID + "','" + fAutoID + "','" + sQty + "','" + sQty + "' ,'" + cDLCode + "' ,'" + cSBVCode + "' ,'','" + sUserID + "')";
                                                    ic = SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                                }
                                                else
                                                {
                                                    sSQL = "update _DispatchLists_SaleBillVouchs set DLsQty=DLsQty+" + sQty + ", SaleBillsQty=SaleBillsQty+" + sQty + " where SaleBillsID=" + SaleBillsID + " and DLsID='" + fAutoID + "'";
                                                    ic = SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                                }
                                                sQty = 0;
                                                break;
                                            }
                                        }
                                    }
                                    #endregion

                                }
                            }
                        }
                        if (iCount == 0)
                        {
                            throw new Exception("表体不能为空");
                        }
                    }
                    #endregion


                    tran.Commit();

                    
                    btnSel_Click(null, null);
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

        private string sCode(long lCode, DateTime d单据日期)
        {
            string sCode = lCode.ToString().Trim();
            while (sCode.Length < 5)
            {
                sCode = "0" + sCode;
            }
            sCode = "SI-" + d单据日期.ToString("yyyy") + sCode;

            return sCode;
        }

        private long sCode(long lCode)
        {
            string sCode = lCode.ToString().Trim();
            while (sCode.Length < 9)
            {
                sCode = "0" + sCode;
            }
            sCode = "1" + sCode;

            return 系统服务.规格化.ReturnObjectToLong(sCode);
        }

        private void GetMoney(decimal d税率, decimal d汇率, decimal d数量, decimal 原币含税金额, decimal 原币无税金额,
            out decimal d原币含税单价, out decimal d原币无税单价, out decimal d原币含税金额, out decimal d原币无税金额, out decimal d原币税额,
            out decimal d本币含税单价, out decimal d本币无税单价, out decimal d本币含税金额, out decimal d本币无税金额, out decimal d本币税额)
        {
            if (原币含税金额 != 0)
            {
                d原币含税金额 = 系统服务.规格化.ReturnDecimal(原币含税金额, 2);
                d原币无税金额 = 系统服务.规格化.ReturnDecimal(d原币含税金额 / (1 + d税率 / 100), 2);
                d原币含税单价 = 系统服务.规格化.ReturnDecimal(d原币含税金额 / d数量, 4);
                d原币无税单价 = 系统服务.规格化.ReturnDecimal(d原币含税金额 / (1 + d税率 / 100) / d数量, 4);
                d原币税额 = d原币含税金额 - d原币无税金额;

                d本币含税金额 = 系统服务.规格化.ReturnDecimal(d原币含税金额 * d汇率, 2);
                d本币无税金额 = 系统服务.规格化.ReturnDecimal(d原币无税金额 * d汇率, 2);
                d本币含税单价 = 系统服务.规格化.ReturnDecimal(d原币含税单价 / d汇率, 4);
                d本币无税单价 = 系统服务.规格化.ReturnDecimal(d原币无税单价 * d汇率, 4);
                d本币税额 = d本币含税金额 - d本币无税金额;
            }
            else if (原币无税金额 != 0)
            {
                d原币无税金额 = 系统服务.规格化.ReturnDecimal(原币无税金额, 2);
                d原币含税金额 = 系统服务.规格化.ReturnDecimal(d原币无税金额 * (1 + d税率 / 100), 2);
                d原币含税单价 = 系统服务.规格化.ReturnDecimal(d原币无税金额 * (1 + d税率 / 100) / d数量, 4);
                d原币无税单价 = 系统服务.规格化.ReturnDecimal(d原币无税金额 / d数量, 4);
                d原币税额 = d原币含税金额 - d原币无税金额;

                d本币含税金额 = 系统服务.规格化.ReturnDecimal(d原币含税金额 * d汇率, 2);
                d本币无税金额 = 系统服务.规格化.ReturnDecimal(d原币无税金额 * d汇率, 2);
                d本币含税单价 = 系统服务.规格化.ReturnDecimal(d原币含税单价 / d汇率, 4);
                d本币无税单价 = 系统服务.规格化.ReturnDecimal(d原币无税单价 * d汇率, 4);
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
            d原币含税金额 = 系统服务.规格化.ReturnDecimal(d原币含税金额, 2);
            d原币无税金额 = 系统服务.规格化.ReturnDecimal(d原币无税金额, 2);
            d原币含税单价 = 系统服务.规格化.ReturnDecimal(d原币含税单价, 4);
            d原币无税单价 = 系统服务.规格化.ReturnDecimal(d原币无税单价, 4);
            d原币税额 = 系统服务.规格化.ReturnDecimal(d原币税额, 2);

            d本币含税金额 = 系统服务.规格化.ReturnDecimal(d本币含税金额, 2);
            d本币无税金额 = 系统服务.规格化.ReturnDecimal(d本币无税金额, 2);
            d本币含税单价 = 系统服务.规格化.ReturnDecimal(d本币含税单价, 4);
            d本币无税单价 = 系统服务.规格化.ReturnDecimal(d本币无税单价, 4);
            d本币税额 = 系统服务.规格化.ReturnDecimal(d本币税额, 2);
        }

        private void chkChoose_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal 数量 = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColNewQty));
                decimal 原数量 = 系统服务.规格化.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColUniQty));
                if (原数量 < 数量)
                {
                    throw new Exception("生成发票数量不可大于可开票数量");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void lookUpEditcCode1_EditValueChanged(object sender, EventArgs e)
        {
            btnSel_Click(null, null);
        }
    }
}