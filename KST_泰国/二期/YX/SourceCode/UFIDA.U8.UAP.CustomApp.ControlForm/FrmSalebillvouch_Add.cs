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

                ϵͳ����.���.GetGridViewSet(gridView1);

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
                MessageBox.Show("��ȡ���۷�������ϸʧ�ܣ�  " + ee.Message);
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

                //1.  �ж��Ƿ����
                sSQL = "select * from gl_mend where iyear=year('" + sLogDate + "') and iperiod=month('" + sLogDate + "')";
                DataTable dtTemp = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                if (dtTemp == null || dtTemp.Rows.Count < 1)
                {
                    throw new Exception("�ж�ģ�����ʧ��");
                }
                string iR =dtTemp.Rows[0]["bflag_ST"].ToString();
                if (iR == "1")
                {
                    throw new Exception("��ǰ�·ݲֿ��Ѿ�����");
                }
                iR = dtTemp.Rows[0]["bflag_AR"].ToString();
                if (iR == "1")
                {
                    throw new Exception("��ǰ�·�Ӧ���Ѿ�����");
                }

                int Count = 0;
                if (dtGrid == null && dtGrid.Rows.Count == 0)
                {
                    throw new Exception("δ�鵽�����ɷ�Ʊ�ĵ���");
                }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                int ic = 0;
                try
                {
                    #region ����
                    if (cSBVCode == "")
                    {
                        //2. ��õ���ID
                        sSQL = "SELECT iFatherId,iChildId FROM UFSystem..UA_Identity WHERE cAcc_Id = '" + sAccID + "' AND cVouchType = 'BILLVOUCH'";
                        DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        long lID = ϵͳ����.���.ReturnObjectToLong(dt.Rows[0]["iFatherId"]);
                        lID++;
                        long lID_1 = sCode(lID);
                        long lIDDetail = ϵͳ����.���.ReturnObjectToLong(dt.Rows[0]["iChildId"]);
                        //3. ��õ��ݺ�
                        long iCode = 0;
                        sSQL = "select isnull(cNumber,0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='13' and cContent='��������' and cSeed=year('" + sLogDate + "')";
                        dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtTemp == null || dtTemp.Rows.Count < 1)
                        {
                            iCode = 1;
                        }
                        else
                        {
                            iCode = ϵͳ����.���.ReturnObjectToLong(dtTemp.Rows[0]["Maxnumber"]) + 1;
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
                        decimal d˰�� = ϵͳ����.���.ReturnDecimal(dtGrid.Rows[0]["iTaxRate"], 2);
                        decimal d���� = ϵͳ����.���.ReturnDecimal(dtGrid.Rows[0]["iExchRate"], 2);

                        #region ��Ʊ��ͷ
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
                        model.iTaxRate = d˰��;
                        model.iExchRate = d����;
                        model.bReturnFlag = false;
                        model.cMaker = sUserName;
                        model.cBusType = cBusType;
                        model.bFirst = false;
                        model.iDisp = 1;
                        model.cCusName = cCusName;
                        model.cSource = "����";

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
                            model.cDefine5 = ϵͳ����.���.ReturnInt(cDefine5);
                        }
                        if (cDefine6 != "")
                        {
                            model.cDefine6 = DateTime.Parse(cDefine6);
                        }
                        if (cDefine7 != "")
                        {
                            model.cDefine7 = ϵͳ����.���.ReturnDecimal(cDefine7);
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
                            model.cDefine15 = ϵͳ����.���.ReturnInt(cDefine15);
                        }
                        if (cDefine16 != "")
                        {
                            model.cDefine16 = ϵͳ����.���.ReturnDecimal(cDefine16);
                        }
                        #endregion

                        DAL.SaleBillVouch dal = new DAL.SaleBillVouch();
                        sSQL = dal.Add(model);
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        #endregion

                        #region ��Ʊ����
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            decimal d���� = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(i, gridColNewQty), 6);
                            if (d���� > 0)
                            {
                                decimal UniQty = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniQty), 6);

                                string cWhCode = gridView1.GetRowCellValue(i, gridColcWhCode).ToString();
                                string cInvCode = gridView1.GetRowCellValue(i, gridColcinvcode).ToString();
                                string cInvName = gridView1.GetRowCellValue(i, gridColcInvName).ToString();
                                string cDefine29 = gridView1.GetRowCellValue(i, gridColitem).ToString();
                                decimal iInvExchRate = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(i, gridColiInvExchRate).ToString(), 4);
                                string cUnitID = gridView1.GetRowCellValue(i, gridColcUnitID).ToString();


                                decimal old���� = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniQty), 6);
                                decimal d���� = ϵͳ����.���.ReturnDecimal(0, 2);

                                decimal dԭ�Һ�˰���� = 0;
                                decimal dԭ����˰���� = 0;
                                decimal dԭ�Һ�˰��� = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniSum).ToString(), 4) * d���� / old����;
                                decimal dԭ����˰��� = 0;
                                decimal dԭ��˰�� = 0;

                                decimal d���Һ�˰���� = 0;
                                decimal d������˰���� = 0;
                                decimal d���Һ�˰��� = 0;
                                decimal d������˰��� = 0;
                                decimal d����˰�� = 0;

                                GetMoney(d˰��, d����, d����, dԭ�Һ�˰���, dԭ����˰���,
                                    out dԭ�Һ�˰����, out dԭ����˰����, out dԭ�Һ�˰���, out dԭ����˰���, out dԭ��˰��,
                                    out d���Һ�˰����, out d������˰����, out d���Һ�˰���, out d������˰���, out d����˰��);

                                Model.SaleBillVouchs models = new Model.SaleBillVouchs();
                                lIDDetail++;
                                long lIDDetail_1 = sCode(lIDDetail);
                                models.AutoID = lIDDetail_1;
                                models.SBVID = lID_1;
                                models.cWhCode = cWhCode;
                                models.cInvCode = cInvCode;
                                models.iQuantity = d����;
                                models.iNum = d����;
                                models.iQuotedPrice = 0;
                                //models.iSOsID = iSOsID;
                                //models.iDLsID = iDLsID;
                                models.KL = 100;
                                models.KL2 = 100;
                                models.cInvName = cInvName;
                                //models.cSoCode = cSoCode;
                                models.iInvExchRate = iInvExchRate;
                                models.cUnitID = cUnitID;

                                models.iTaxRate = d˰��;

                                models.iTaxUnitPrice = dԭ�Һ�˰����;
                                models.iUnitPrice = dԭ����˰����;
                                models.iSum = dԭ�Һ�˰���;
                                models.iMoney = dԭ����˰���;
                                models.iTax = dԭ��˰��;
                                models.iDisCount = 0;

                                models.iNatUnitPrice = d������˰����;
                                models.iNatSum = d���Һ�˰���;
                                models.iNatMoney = d������˰���;
                                models.iNatTax = d����˰��;
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

                                #region ��д
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
                                    decimal fUniQty = ϵͳ����.���.ReturnDecimal(dtf.Rows[j]["UniQty"].ToString(), 6);
                                    decimal fUniNum = ϵͳ����.���.ReturnDecimal(dtf.Rows[j]["UniNum"].ToString(), 6);

                                    if (d���� > 0)
                                    {
                                        if (d���� >= fUniQty)
                                        {
                                            sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity+" + fUniQty + ",iSettleNum=iSettleNum+" + fUniNum + "  where AutoID='" + fAutoID + "'";
                                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            sSQL = @"INSERT INTO _DispatchLists_SaleBillVouchs(SaleBillsID,DLsID,DLsQty,SaleBillsQty,DLCode,SaleBillCode,Remark,CreateUid)
                                    VALUES ('" + lIDDetail_1 + "','" + fAutoID + "','" + fUniQty + "','" + fUniQty + "' ,'" + cDLCode + "' ,'" + cCode + "' ,'','" + sUserID + "')";
                                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            d���� = d���� - fUniQty;
                                            d���� = d���� - fUniNum;
                                        }
                                        else
                                        {
                                            sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity+" + d���� + ",iSettleNum=iSettleNum+" + d���� + "  where AutoID='" + fAutoID + "'";
                                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            sSQL = @"INSERT INTO _DispatchLists_SaleBillVouchs(SaleBillsID,DLsID,DLsQty,SaleBillsQty,DLCode,SaleBillCode,Remark,CreateUid)
                                    VALUES ('" + lIDDetail_1 + "','" + fAutoID + "','" + d���� + "','" + d���� + "' ,'" + cDLCode + "' ,'" + cCode + "' ,'','" + sUserID + "')";
                                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                            d���� = 0;
                                            d���� = 0;
                                            break;
                                        }
                                    }
                                }
                                if (d���� > 0)
                                {
                                    sErr = sErr + "��" + (i + 1) + "�г����ɿ���Ʊ����\n";
                                }
                                #endregion
                            }

                        }
                        #endregion

                        #region ���µ��ݺ�
                        sSQL = "UPDATE VoucherHistory SET cNumber = 111111 WHERE CardNumber='13' and cContent='��������' and cSeed=year('" + sLogDate + "')";
                        sSQL = sSQL.Replace("111111", iCode.ToString());
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        sSQL = "UPDATE UFSystem..UA_Identity SET iFatherId = 111111,iChildId = 222222 WHERE cAcc_Id = '" + sAccID + "' AND cVouchType = 'BILLVOUCH'";
                        sSQL = sSQL.Replace("111111", lID.ToString());
                        sSQL = sSQL.Replace("222222", lIDDetail.ToString());
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        #endregion

                        MessageBox.Show("���ɷ�Ʊ�ɹ�����Ʊ�ţ�" + cCode);
                    }
                    else
                    {
                        int iCount = 0;
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            decimal dold���� = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniQty), 6);
                            decimal d���� = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(i, gridColNewQty), 6);
                            string SaleBillsID=gridView1.GetRowCellValue(i, gridColSaleBillsID).ToString();

                            sSQL = "select * from SaleBillVouch a  left join SaleBillVouchs b on a.SBVID=b.SBVID where AutoID=" + SaleBillsID;
                            DataTable dtsv = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                            decimal dsvQty = ϵͳ����.���.ReturnDecimal(dtsv.Rows[0]["iQuantity"].ToString(), 6);
                            decimal dsvMoney = ϵͳ����.���.ReturnDecimal(dtsv.Rows[0]["iMoney"].ToString(), 6);
                            string cDefine29 = dtsv.Rows[0]["cDefine29"].ToString();
                            string cInvCode = dtsv.Rows[0]["cInvCode"].ToString();
                            if (d���� == 0)
                            {
                                //ɾ����
                                sSQL = "delete from SaleBillVouchs where AutoID=" + SaleBillsID;
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                sSQL = "select * from _DispatchLists_SaleBillVouchs where SaleBillsID=" + SaleBillsID;
                                DataTable dtf = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                for (int j = 0; j < dtf.Rows.Count; j++)
                                {
                                    string fDLsID = dtf.Rows[j]["DLsID"].ToString();
                                    decimal fDLsQty = ϵͳ����.���.ReturnDecimal(dtf.Rows[j]["DLsQty"].ToString(), 6);

                                    decimal d���� = ϵͳ����.���.ReturnDecimal(dtsv.Rows[0]["iExchRate"].ToString(), 6);
                                    decimal d˰�� = ϵͳ����.���.ReturnDecimal(dtsv.Rows[0]["iTaxRate"].ToString(), 6);

                                    decimal d���� = ϵͳ����.���.ReturnDecimal(0, 2);

                                    sSQL = "update DispatchLists set iSettleQuantity=iSettleQuantity-" + fDLsQty + ",iSettleNum=iSettleNum-" + 0 + "  where AutoID='" + fDLsID + "'";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }

                                sSQL = "delete from _DispatchLists_SaleBillVouchs where SaleBillsID=" + SaleBillsID;
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            else if (dsvQty != d����)
                            {
                                iCount = iCount + 1;
                                if (1 == 1)//���·�Ʊ
                                {
                                    decimal d���� = ϵͳ����.���.ReturnDecimal(dtsv.Rows[0]["iExchRate"].ToString(), 6);
                                    decimal d˰�� = ϵͳ����.���.ReturnDecimal(dtsv.Rows[0]["iTaxRate"].ToString(), 6);

                                    decimal d���� = ϵͳ����.���.ReturnDecimal(0, 2);

                                    decimal dԭ�Һ�˰���� = 0;
                                    decimal dԭ����˰���� = 0;
                                    decimal dԭ�Һ�˰��� = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(i, gridColUniSum).ToString(), 4) * d���� / dsvQty;
                                    decimal dԭ����˰��� = 0;
                                    decimal dԭ��˰�� = 0;

                                    decimal d���Һ�˰���� = 0;
                                    decimal d������˰���� = 0;
                                    decimal d���Һ�˰��� = 0;
                                    decimal d������˰��� = 0;
                                    decimal d����˰�� = 0;

                                    GetMoney(d˰��, d����, d����, dԭ�Һ�˰���, dԭ����˰���,
                                        out dԭ�Һ�˰����, out dԭ����˰����, out dԭ�Һ�˰���, out dԭ����˰���, out dԭ��˰��,
                                        out d���Һ�˰����, out d������˰����, out d���Һ�˰���, out d������˰���, out d����˰��);

                                    sSQL = "update SaleBillVouchs set iQuantity=" + d���� +
                                        ",iNum=" + 0 +
                                        ",iTaxUnitPrice=" + dԭ�Һ�˰���� +
                                        ",iUnitPrice=" + dԭ����˰���� +
                                        ",iSum=" + dԭ�Һ�˰��� +
                                        ",iMoney=" + dԭ����˰��� +
                                        ",iTax=" + dԭ��˰�� +
                                        ",iNatUnitPrice=" + d������˰���� +
                                        ",iNatSum=" + d���Һ�˰��� +
                                        ",iNatMoney=" + d������˰��� +
                                        " where AutoID=" + SaleBillsID;
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }

                                if (dsvQty > d����)//���ԭ����Ʊ���������ڱ���Ʊ����
                                {
                                    decimal sQty = dsvQty - d����;//��ȥ�����ݵ�����

                                    sSQL = "select * from _DispatchLists_SaleBillVouchs where SaleBillsID=" + SaleBillsID;
                                    DataTable dtf = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                                    for (int j = 0; j < dtf.Rows.Count; j++)
                                    {
                                        if (sQty > 0)
                                        {
                                            string fDLsID = dtf.Rows[j]["DLsID"].ToString();
                                            decimal fDLsQty = ϵͳ����.���.ReturnDecimal(dtf.Rows[j]["DLsQty"].ToString(), 6);

                                            if (sQty >= fDLsQty)//δ�ۼ����������м��������ɾ���м��
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
                                else if (dsvQty < d����)
                                {
                                    decimal sQty = d���� - dsvQty;//���ӱ����ݵ�����

                                    #region ��д
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
                                        decimal fUniQty = ϵͳ����.���.ReturnDecimal(dtf.Rows[j]["UniQty"].ToString(), 6);
                                        decimal fUniNum = ϵͳ����.���.ReturnDecimal(dtf.Rows[j]["UniNum"].ToString(), 6);

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
                            throw new Exception("���岻��Ϊ��");
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

        private string sCode(long lCode, DateTime d��������)
        {
            string sCode = lCode.ToString().Trim();
            while (sCode.Length < 5)
            {
                sCode = "0" + sCode;
            }
            sCode = "SI-" + d��������.ToString("yyyy") + sCode;

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

            return ϵͳ����.���.ReturnObjectToLong(sCode);
        }

        private void GetMoney(decimal d˰��, decimal d����, decimal d����, decimal ԭ�Һ�˰���, decimal ԭ����˰���,
            out decimal dԭ�Һ�˰����, out decimal dԭ����˰����, out decimal dԭ�Һ�˰���, out decimal dԭ����˰���, out decimal dԭ��˰��,
            out decimal d���Һ�˰����, out decimal d������˰����, out decimal d���Һ�˰���, out decimal d������˰���, out decimal d����˰��)
        {
            if (ԭ�Һ�˰��� != 0)
            {
                dԭ�Һ�˰��� = ϵͳ����.���.ReturnDecimal(ԭ�Һ�˰���, 2);
                dԭ����˰��� = ϵͳ����.���.ReturnDecimal(dԭ�Һ�˰��� / (1 + d˰�� / 100), 2);
                dԭ�Һ�˰���� = ϵͳ����.���.ReturnDecimal(dԭ�Һ�˰��� / d����, 4);
                dԭ����˰���� = ϵͳ����.���.ReturnDecimal(dԭ�Һ�˰��� / (1 + d˰�� / 100) / d����, 4);
                dԭ��˰�� = dԭ�Һ�˰��� - dԭ����˰���;

                d���Һ�˰��� = ϵͳ����.���.ReturnDecimal(dԭ�Һ�˰��� * d����, 2);
                d������˰��� = ϵͳ����.���.ReturnDecimal(dԭ����˰��� * d����, 2);
                d���Һ�˰���� = ϵͳ����.���.ReturnDecimal(dԭ�Һ�˰���� / d����, 4);
                d������˰���� = ϵͳ����.���.ReturnDecimal(dԭ����˰���� * d����, 4);
                d����˰�� = d���Һ�˰��� - d������˰���;
            }
            else if (ԭ����˰��� != 0)
            {
                dԭ����˰��� = ϵͳ����.���.ReturnDecimal(ԭ����˰���, 2);
                dԭ�Һ�˰��� = ϵͳ����.���.ReturnDecimal(dԭ����˰��� * (1 + d˰�� / 100), 2);
                dԭ�Һ�˰���� = ϵͳ����.���.ReturnDecimal(dԭ����˰��� * (1 + d˰�� / 100) / d����, 4);
                dԭ����˰���� = ϵͳ����.���.ReturnDecimal(dԭ����˰��� / d����, 4);
                dԭ��˰�� = dԭ�Һ�˰��� - dԭ����˰���;

                d���Һ�˰��� = ϵͳ����.���.ReturnDecimal(dԭ�Һ�˰��� * d����, 2);
                d������˰��� = ϵͳ����.���.ReturnDecimal(dԭ����˰��� * d����, 2);
                d���Һ�˰���� = ϵͳ����.���.ReturnDecimal(dԭ�Һ�˰���� / d����, 4);
                d������˰���� = ϵͳ����.���.ReturnDecimal(dԭ����˰���� * d����, 4);
                d����˰�� = d���Һ�˰��� - d������˰���;
            }
            else
            {
                dԭ����˰��� = 0;
                dԭ�Һ�˰��� = 0;
                dԭ�Һ�˰���� = 0;
                dԭ����˰���� = 0;
                dԭ��˰�� = 0;

                d���Һ�˰��� = 0;
                d������˰��� = 0;
                d���Һ�˰���� = 0;
                d������˰���� = 0;
                d����˰�� = 0;
            }
            dԭ�Һ�˰��� = ϵͳ����.���.ReturnDecimal(dԭ�Һ�˰���, 2);
            dԭ����˰��� = ϵͳ����.���.ReturnDecimal(dԭ����˰���, 2);
            dԭ�Һ�˰���� = ϵͳ����.���.ReturnDecimal(dԭ�Һ�˰����, 4);
            dԭ����˰���� = ϵͳ����.���.ReturnDecimal(dԭ����˰����, 4);
            dԭ��˰�� = ϵͳ����.���.ReturnDecimal(dԭ��˰��, 2);

            d���Һ�˰��� = ϵͳ����.���.ReturnDecimal(d���Һ�˰���, 2);
            d������˰��� = ϵͳ����.���.ReturnDecimal(d������˰���, 2);
            d���Һ�˰���� = ϵͳ����.���.ReturnDecimal(d���Һ�˰����, 4);
            d������˰���� = ϵͳ����.���.ReturnDecimal(d������˰����, 4);
            d����˰�� = ϵͳ����.���.ReturnDecimal(d����˰��, 2);
        }

        private void chkChoose_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal ���� = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColNewQty));
                decimal ԭ���� = ϵͳ����.���.ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridColUniQty));
                if (ԭ���� < ����)
                {
                    throw new Exception("���ɷ�Ʊ�������ɴ��ڿɿ�Ʊ����");
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