using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
//using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Data.SqlClient;
using System.Data.OracleClient;
using TH.BaseClass;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class ���۷�Ʊ���� : UserControl
    {
        //public class CmbDataSource
        //{
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public ���۷�Ʊ����()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit��������.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                dateEdit��ʼ����.EditValue = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-01";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "��������ʧ��");
                //throw new Exception(ee.Message);
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

                DataTable dtGrid = (DataTable)gridControl1.DataSource;
                dtGrid = Select(dtGrid, "ѡ��='True'","");
                string sErr = "";
                string sSQL = "";

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();

                Config oconfig = new Config();
                OracleConnection ocon = new OracleConnection(oconfig.ConnectionString);
                OracleCommand ocmd = new OracleCommand();
                OracleTransaction otrans;
                ocon.Open();
                ocmd.Connection = ocon;
                otrans = ocon.BeginTransaction();
                ocmd.Transaction = otrans;

                try
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        if (dtGrid.Rows[i]["ѡ��"].ToString().Trim() == "True")
                        {
                            sSQL = "select count(1) from ERP_IMPORT_SALE where ��Ʊ���� = '" + dtGrid.Rows[i]["��Ʊ����"].ToString().Trim() + "' ";
                            int iCou1 = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou1 > 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "���ݺ��ѵ���\n";
                                continue;
                            }

                            sSQL = "select count(1) from Ap_Vouch where cDefine1 = '" + dtGrid.Rows[i]["��Ʊ����"].ToString().Trim() + "' ";
                            int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou > 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "��Ʊ���Ѵ���\n";
                                continue;
                            }
                        }
                    }

                    sSQL = @"select bflag_AR,iyear ,iperiod,* from GL_mend 
where isnull(bflag_AR,0) = 0 and iperiod <> 0
order by iyear,iperiod ";
                    DataTable dt����״̬ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    string iperiod = "";
                    string iyear = "";
                    string iyperiod="";
                    if (dt����״̬.Rows.Count > 0)
                    {
                        iperiod = dt����״̬.Rows[0]["iperiod"].ToString().Trim();
                        iyear = dt����״̬.Rows[0]["iyear"].ToString().Trim();
                        iyperiod = dt����״̬.Rows[0]["iyperiod"].ToString().Trim();
                    }

                    int iƾ֤�� = 0;
                    sSQL = "select isnull(max(ino_id),0) as ino_id from gl_accvouch where iperiod =" + iperiod + " and isignseq =1  and iyear=" + iyear + "";
                    DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        iƾ֤�� = SqlHelper.ReturnObjectToInt(dt.Rows[0]["ino_id"]);
                    }

                    sSQL = "SELECT iFatherId,iChildId FROM UFSystem..UA_Identity where cVouchType = 'RP' and cAcc_Id = '" + sAccID + "'";
                    DataTable dtID = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    long lID = 0;
                    long lIDMain = 0;
                    long lIDDetails = 0;
                    if (dtID != null && dtID.Rows.Count > 0)
                    {
                        lID = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iFatherId"]);
                        lIDDetails = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iChildId"]);
                    }

                    sSQL = "SELECT isnull(iCancelNo,0) as iCancelNo FROM Ap_CancelNo where cType='PZ' and cFlag='GL'";
                    DataTable dtgl = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long glid = SqlHelper.ReturnObjectToLong(dtgl.Rows[0]["iCancelNo"]);

                    sSQL = "select isnull(cNumber,0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='R0' and cContent is NULL";
                    DataTable dtcode = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long code = 0;
                    if (dtcode.Rows.Count > 0)
                    {
                        code = SqlHelper.ReturnObjectToLong(dtcode.Rows[0][0]);
                    }

                    int scount = 0;
                    int ocount = 0;
                    //Ӧ�տ�
                    DataTable dtgroup = Group(dtGrid, new string[] { "��Ʊ����", "ѡ��", "���Ѵ���", "���ѷ�ʽ", "����", "����", "��Ʊ�ܽ��", "�跽��Ŀ", "��ƱID", "������Ŀ˰", "��Ʊ��ӡʱ��" }, "���ѷ�ʽ<>'XJ'");
                    for (int j = 0; j < dtgroup.Rows.Count; j++)
                    {
                        #region ������֤

                        string s�ͻ� = dtgroup.Rows[j]["���Ѵ���"].ToString().Trim();
                        sSQL = "select * from customer where cCusCode = '" + s�ͻ� + "' or cCusName = '" + s�ͻ� + "' or cCusAbbName = '" + s�ͻ� + "'";
                        DataTable dt�ͻ� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt�ͻ� == null || dt�ͻ�.Rows.Count < 1)
                        {
                            sErr = sErr + "�ͻ�" + s�ͻ� + "������\n";
                            continue;
                        }
                        if (dt�ͻ�.Rows.Count > 1)
                        {
                            sErr = sErr + "�ͻ�" + s�ͻ� + "���ڶ������,��ʹ�ÿͻ�����Ψһָ��\n";
                            continue;
                        }

                        sSQL = "select * from foreigncurrency where cexch_code = '" + dtgroup.Rows[j]["����"].ToString().Trim() + "' or cexch_name = '" + dtgroup.Rows[j]["����"].ToString().Trim() + "'";
                        DataTable dt���� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt����.Rows.Count == 0)
                        {
                            sErr = sErr + "���ֲ�����\n";
                            continue;
                        }



                        #endregion

                        #region
                        lID += 1;
                        lIDMain = ReturnID(lID);

                        code += 1;
                        string icode = sGetCode(code, 10);


                        decimal ��Ʊ��� = SqlHelper.ReturnObjectToDecimal(dtgroup.Rows[j]["��Ʊ�ܽ��"]);
                        decimal ���� = SqlHelper.ReturnObjectToDecimal(dtgroup.Rows[j]["����"]);
                        decimal ��ҷ�Ʊ��� = ��Ʊ��� * ����;
                        string ���� = dt����.Rows[0]["cexch_name"].ToString().Trim();
                        string �ͻ� = dt�ͻ�.Rows[0]["cCusCode"].ToString().Trim();
                        string �跽��Ŀ = dtgroup.Rows[j]["�跽��Ŀ"].ToString().Trim();
                        string ��Ʊ���� = dtgroup.Rows[j]["��Ʊ����"].ToString().Trim();
                        string ������Ŀ˰ = dtgroup.Rows[j]["������Ŀ˰"].ToString().Trim();
                        string bd_c = "1";
                        if (��Ʊ��� < 0)
                        {
                            bd_c = "0";
                        }

                        sSQL = @"Insert Into Ap_Vouch (cLink,cVouchType,cVouchID,dVouchDate,cDwCode,cDeptCode,cPerson,cItem_Class,cItemCode,cCode,
cexch_name,iExchRate,bd_c,iAmount,iAmount_f,iRAmount,iRAmount_f,cOperator,bStartFlag,cFlag,
cDefine1,iAmount_s,iRAmount_s,VT_ID,cItemName,iCreditPeriod,dGatheringDate,dcreatesystime,Auto_ID,cDefine10) Values (
N'R0" + icode + "',N'R0',N'" + icode + "','" + DateTime.Parse(dtgroup.Rows[j]["��Ʊ��ӡʱ��"].ToString()).ToString("yyyy-MM-dd") + "',N'" + �ͻ� + "',null,null,null,null,N'" + �跽��Ŀ + "'," +
"N'" + ���� + "','" + ���� + "'," + bd_c + "," + System.Math.Abs(��Ʊ���) + "," + System.Math.Abs(��ҷ�Ʊ���) + "," + System.Math.Abs(��Ʊ���) + "," + System.Math.Abs(��ҷ�Ʊ���) + ",N'" + sUserName + "',0,N'AR'," +
"N'" + ��Ʊ���� + "',0,0,8054,null,null,'" + DateTime.Parse(dtgroup.Rows[j]["��Ʊ��ӡʱ��"].ToString()).AddDays(15).ToString("yyyy-MM-dd") + "',GETDATE()," + lIDMain + ",'Y')";

                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        scount = scount + 1;
                        DataTable dt���� = Group(dtGrid, new string[] { "����ͳ��������" }, "���ѷ�ʽ<>'XJ' and ��Ʊ����='" + ��Ʊ���� + "'");
                        for (int i = 0; i < dt����.Rows.Count; i++)
                        {
                            #region
                            //sSQL = "select * from salebillvouch where csbvcode = '" + dtGrid.Rows[i]["��Ʊ��"].ToString().Trim() + "'";
                            //DataTable dt���۷�Ʊ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                            //if (dt���۷�Ʊ.Rows.Count == 0)
                            //{


                            lIDDetails += 1;
                            string ������Ŀ = dt����.Rows[i]["����ͳ��������"].ToString().Trim();

                            string �����Ŀ = "";

                            DataTable dt�����Ŀ = Select(dtGrid, "���ѷ�ʽ<>'XJ' and ��Ʊ����='" + ��Ʊ���� + "' and ����ͳ��������='" + ������Ŀ + "'", "��Ʊ�ܽ�� desc");
                            if (dt�����Ŀ.Rows.Count > 0)
                            {
                                �����Ŀ = dt�����Ŀ.Rows[0]["�����Ŀ"].ToString();
                            }
                            decimal ��� = 0;
                            decimal ˰�� = 0;

                            DataRow[] dw��� = dtGrid.Select("���ѷ�ʽ<>'XJ' and ��Ʊ����='" + ��Ʊ���� + "' and ����ͳ��������='" + ������Ŀ + "'");
                            for (int s = 0; s < dw���.Length; s++)
                            {
                                ��� = ��� + SqlHelper.ReturnObjectToDecimal(dw���[s]["���"], 6);
                                ˰�� = ˰�� + SqlHelper.ReturnObjectToDecimal(dw���[s]["˰��"], 6);
                            }
                            ��� = SqlHelper.ReturnObjectToDecimal(���, 2);
                            ˰�� = SqlHelper.ReturnObjectToDecimal(˰��, 2);

                            decimal ˰ = ��� - ˰��;

                            decimal ���˰�� = ˰�� * ����;
                            decimal ���˰ = ˰ * ����;

                            sSQL = "select  count(*) from code where ccode='" + ������Ŀ + "' and bend=1";
                            int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou == 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "������Ŀ������\n";
                                continue;
                            }

                            sSQL = @"INSERT INTO Ap_Vouchs(cLink,cDwCode,cDeptCode,cPerson,cItem_Class,cItemCode,cDigest,cCode,cexch_name,iExchRate,
bd_c,iAmount,iAmount_f,cItemName,iAmt_s,cDefine22,cDefine23,cDefine24,cDefine25,cDefine26,
cDefine27,cDefine28,cDefine29,cDefine30,cDefine31,cDefine32,cDefine33,cDefine34,cDefine35,cDefine36,cDefine37) VALUES (
N'R0" + icode + "',N'" + �ͻ� + "',NULL,NULL,NULL,NULL,'" + �����Ŀ + "',N'" + ������Ŀ + "',N'" + ���� + "'," + ���� + "," +
"0," + ˰�� + "," + ���˰�� + ",NULL,0,NULL,NULL,NULL,NULL,NULL," +
"NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            if (˰ != 0)
                            {
                                lIDDetails += 1;

                                sSQL = @"INSERT INTO Ap_Vouchs(cLink,cDwCode,cDeptCode,cPerson,cItem_Class,cItemCode,cDigest,cCode,cexch_name,iExchRate,
bd_c,iAmount,iAmount_f,cItemName,iAmt_s,cDefine22,cDefine23,cDefine24,cDefine25,cDefine26,
cDefine27,cDefine28,cDefine29,cDefine30,cDefine31,cDefine32,cDefine33,cDefine34,cDefine35,cDefine36,cDefine37) VALUES (
N'R0" + icode + "',N'" + �ͻ� + "',NULL,NULL,NULL,NULL,'" + �����Ŀ + "',N'" + ������Ŀ˰ + "',N'" + ���� + "'," + ���� + "," +
"0," + ˰ + "," + ���˰ + ",NULL,0,NULL,NULL,NULL,NULL,NULL," +
"NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)";
                                SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                            }
                            #endregion
                        }

                        sSQL = @"insert into ERP_IMPORT_SALE(��Ʊ����,��ƱID,cVouchID) 
                                    values(" + ReturnDBString(��Ʊ����) + "," + ReturnDBString(dtgroup.Rows[j]["��ƱID"]) + ",'" + icode + "') ";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        #endregion
                    }
                    //�ֽ�
                    DataTable dtg���� = Group(dtGrid, new string[] { "ѡ��", "����", "����", "�跽��Ŀ", "������Ŀ˰", "��Ʊ��ӡʱ��" }, "���ѷ�ʽ='XJ'");
                    for (int j = 0; j < dtg����.Rows.Count; j++)
                    {
                        #region ������֤
                        sSQL = "select * from foreigncurrency where cexch_code = '" + dtg����.Rows[j]["����"].ToString().Trim() + "' or cexch_name = '" + dtg����.Rows[j]["����"].ToString().Trim() + "'";
                        DataTable dt���� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt����.Rows.Count == 0)
                        {
                            sErr = sErr + "���ֲ�����\n";
                            continue;
                        }

                        DataTable dt��Ʊ��� = Group(dtGrid, new string[] { "��Ʊ��ӡʱ��", "��Ʊ�ܽ��", "��Ʊ����" }, "��Ʊ��ӡʱ��='" + dtg����.Rows[j]["��Ʊ��ӡʱ��"] + "' and ���ѷ�ʽ='XJ'");

                        decimal ��Ʊ��� = 0;
                        string ��Ʊ���� = "";
                        for (int i = 0; i < dt��Ʊ���.Rows.Count; i++)
                        {
                            ��Ʊ��� = ��Ʊ��� + SqlHelper.ReturnObjectToDecimal(dt��Ʊ���.Rows[i]["��Ʊ�ܽ��"]);
                            //if (��Ʊ���� != "")
                            //{
                            //    ��Ʊ���� = ��Ʊ���� + ",";
                            //}
                            //else
                            //{
                            //    ��Ʊ���� = ��Ʊ���� + dt��Ʊ���.Rows[i]["��Ʊ����"].ToString().Trim();
                            //}
                        }
                        
                        decimal ���� = SqlHelper.ReturnObjectToDecimal(dtg����.Rows[j]["����"]);
                        decimal ��ҷ�Ʊ��� = ��Ʊ��� * ����;
                        string ���� = dt����.Rows[0]["cexch_name"].ToString().Trim();
                        //string �ͻ� = dt�ͻ�.Rows[0]["cCusCode"].ToString().Trim();
                        string �跽��Ŀ = dtg����.Rows[j]["�跽��Ŀ"].ToString().Trim();
                        string ������Ŀ˰ = dtg����.Rows[j]["������Ŀ˰"].ToString().Trim();
                        
                        string ��Ʊ��ӡʱ�� = dtg����.Rows[j]["��Ʊ��ӡʱ��"].ToString().Trim();
                        int inid = 1;
                        iƾ֤�� = iƾ֤�� + 1;
                        glid = glid + 1;
                        string �Է���Ŀ = "";
                        DataTable dtdf = Group(dtGrid, new string[] { "����ͳ��������" }, "��Ʊ��ӡʱ��='" + dtg����.Rows[j]["��Ʊ��ӡʱ��"] + "' and ���ѷ�ʽ='XJ'");
                        for (int i = 0; i < dtdf.Rows.Count; i++)
                        {
                            if (�Է���Ŀ != "")
                            {
                                �Է���Ŀ = �Է���Ŀ + ",";
                            }
                            else
                            {
                                �Է���Ŀ = �Է���Ŀ + dtdf.Rows[i]["����ͳ��������"].ToString().Trim();
                            }
                        }

                        DataTable dt��¼ = Group(dtGrid, new string[] { "��Ʊ����" }, "��Ʊ��ӡʱ��='" + dtg����.Rows[j]["��Ʊ��ӡʱ��"] + "' and ���ѷ�ʽ='XJ'");
                        int ��¼ = dt��¼.Rows.Count;
                        //�跽
                        sSQL = @" declare @id as nvarchar
                            select @id='GL'+REPLICATE('0',13-len(" + glid + "+convert(varchar," + glid + ")))+convert(varchar," + glid + ") " +
                        "INSERT INTO gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                          ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                          "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                          ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                          ",iyear,iYPeriod ,ctext1,cDefine10,coutno_id ) " +
                               "values(" + iperiod + ",'��','1'," + iƾ֤�� + ",'1','" + ��Ʊ��ӡʱ�� + "'," + ��¼ + ",'" + sUserName + "',null,null" +
                                        ",0,null,null,null,'�ֽ�����','" + �跽��Ŀ + "','" + ���� + "'," + SqlHelper.ReturnObjectToDecimal(��Ʊ���, 2) + ",0" +
                                        "," + SqlHelper.ReturnObjectToDecimal(��ҷ�Ʊ���, 2) + ",0," + ���� + ",0,0,null,null,null,null,null" +
                                        ",null,null,null,null,null,'" + �Է���Ŀ + "',null,null,null,null" +
                                        ",'" + iyear + "','" + iperiod + "','" + ��Ʊ���� + "','Y',@id)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        scount = scount + 1;

                        //��Ŀ�������ϱ�
                        sSQL = @"insert into Gl_coderemark(iyperiod,iyear,iperiod,csign,ino_id,inid) values('" + iyperiod + "','" + iyear + "','" + iperiod + "','��'," + iƾ֤�� + ",'" + inid + "')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        decimal z˰ = 0;
                        decimal z���˰ = 0;
                        string ˰��ժҪ = "";

                        DataTable dt˰��ժҪ = Select(dtGrid,"��Ʊ��ӡʱ��='" + dtg����.Rows[j]["��Ʊ��ӡʱ��"] + "' and ���ѷ�ʽ='XJ'", "��Ʊ�ܽ�� desc");
                        if (dt˰��ժҪ.Rows.Count > 0)
                        {
                            ˰��ժҪ = dt˰��ժҪ.Rows[0]["�����Ŀ"].ToString()+"��";
                        }

                        #region
                        DataTable dtBack = Group(dtGrid, new string[] { "��Ʊ����", "��ƱID" }, "���ѷ�ʽ='XJ' and ��Ʊ��ӡʱ��='" + dtg����.Rows[j]["��Ʊ��ӡʱ��"].ToString() + "'");
                        for (int s = 0; s < dtBack.Rows.Count; s++)
                        {
                            #region
                            //��¼
                            sSQL = @"insert into ERP_IMPORT_SALE(��Ʊ����,��ƱID,iperiod ,ino_id,iyear ) 
                                    values(" + ReturnDBString(dtBack.Rows[s]["��Ʊ����"]) + "," + ReturnDBString(dtBack.Rows[s]["��ƱID"]) + ",'" + iperiod + "','" + iƾ֤�� + "','" + iyear + "') ";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            string ƾ֤ = ("0000" + iƾ֤��);
                            ƾ֤ = "��-" + ƾ֤.Substring(ƾ֤.Length - 4, 4);
                            ocmd.CommandText = @"insert into CW_SEND_CHB_LISTS(YSB_CHB_BILLID,YSB_VOUCHER,YSB_VOUCHER_TM,YSB_VOUCHER_EMPTID) values(
" + ReturnDBString(dtBack.Rows[s]["��ƱID"]) + ",'" + ƾ֤ + "',TO_DATE('" + DateTime.Now.ToString("yyyy-MM-dd") + "','YYYY-MM-DD'),'" + sUserName + "')";
                            ocmd.ExecuteNonQuery();
                            #endregion
                        }
                        //����
                        DataTable dtg������Ŀ = Group(dtGrid, new string[] { "ѡ��", "����", "����", "����ͳ��������",  "��Ʊ��ӡʱ��" }, "���ѷ�ʽ='XJ' and ��Ʊ��ӡʱ��='" + dtg����.Rows[j]["��Ʊ��ӡʱ��"].ToString() + "'");
                        for (int i = 0; i < dtg������Ŀ.Rows.Count; i++)
                        {
                            #region
                            string ������Ŀ = dtg������Ŀ.Rows[i]["����ͳ��������"].ToString().Trim();
                            string �����Ŀ = "";
                            DataTable dt�����Ŀ = Select(dtGrid, "���ѷ�ʽ='XJ' and ��Ʊ��ӡʱ��='" + dtg����.Rows[j]["��Ʊ��ӡʱ��"].ToString() + "' and ����ͳ��������='" + ������Ŀ + "'", "��Ʊ�ܽ�� desc");
                            if (dt�����Ŀ.Rows.Count > 0)
                            {
                                �����Ŀ = dt�����Ŀ.Rows[0]["�����Ŀ"].ToString();
                            }
                            decimal ˰�� = 0;
                            decimal ˰ = 0;
                            DataRow[] dw��� = dtGrid.Select("���ѷ�ʽ='XJ' and ��Ʊ��ӡʱ��='" + ��Ʊ��ӡʱ�� + "' and ����ͳ��������='" + ������Ŀ + "'");
                            for (int s = 0; s < dw���.Length; s++)
                            {
                                ˰�� = ˰�� + SqlHelper.ReturnObjectToDecimal(dw���[s]["˰��"], 2);
                                ˰ = ˰ + SqlHelper.ReturnObjectToDecimal(dw���[s]["˰"], 2);
                            }

                            
                            decimal ���˰�� = ˰�� * ����;
                            decimal ���˰ = ˰ * ����;

                            z˰ = ˰ + z˰;
                            z���˰ = ���˰ + z���˰;

                            sSQL = "select  count(*) from code where ccode='" + ������Ŀ + "' and bend=1";
                            int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou == 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "������Ŀ������\n";
                                continue;
                            }
                            inid = inid + 1;
                            sSQL = @"declare @id as nvarchar
                            select @id='GL'+REPLICATE('0',13-len(" + glid + "+convert(varchar," + glid + ")))+convert(varchar," + glid + ") " +
                    "INSERT INTO gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                      ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                      "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                      ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                      ",iyear,iYPeriod ,ctext1,cDefine10,coutno_id) " +
                           "values(" + iperiod + ",'��','1'," + iƾ֤�� + ",'" + inid + "','" + ��Ʊ��ӡʱ�� + "'," + ��¼ + ",'" + sUserName + "',null,null" +
                                    ",0,null,null,null,'" + �����Ŀ + "','" + ������Ŀ + "','" + ���� + "',0," + SqlHelper.ReturnObjectToDecimal(˰��, 2) + "," +
                                    "0," + SqlHelper.ReturnObjectToDecimal(���˰��, 2) + "," + ���� + ",0,0,null,null,null,null,null," +
                                    "null,null,null,null,null,'" + �跽��Ŀ + "',null,null,null,null" +
                                    ",'" + iyear + "','" + iperiod + "','" + ��Ʊ���� + "','Y',@id)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            //��Ŀ�������ϱ�
                            sSQL = @"insert into Gl_coderemark(iyperiod,iyear,iperiod,csign,ino_id,inid) values('" + iyperiod + "','" + iyear + "','" + iperiod + "','��'," + iƾ֤�� + ",'" + inid + "')";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                            

                            #endregion
                        }
                        #endregion
                        //˰
                        if (z˰ > 0)
                        {
                            inid = inid + 1;
                            sSQL = @"declare @id as nvarchar
                                                        select @id='GL'+REPLICATE('0',13-len(" + glid + "+convert(varchar," + glid + ")))+convert(varchar," + glid + ") " +
                    "INSERT INTO gl_accvouch (iperiod, csign, isignseq, ino_id, inid, dbill_date, idoc, cbill, ccheck, cbook" +
                                      ", ibook, ccashier, iflag, ctext2, cdigest, ccode, cexch_name, md, mc, " +
                                      "md_f, mc_f, nfrat, nd_s, nc_s, csettle, cn_id, dt_date, cdept_id, cperson_id" +
                                      ", ccus_id, csup_id, citem_id, citem_class, cname, ccode_equal, iflagbank, iflagPerson,bdelete, coutaccset " +
                                      ",iyear,iYPeriod ,ctext1,cDefine10,coutno_id) " +
                           "values(" + iperiod + ",'��','1'," + iƾ֤�� + ",'" + inid + "','" + ��Ʊ��ӡʱ�� + "'," + ��¼ + ",'" + sUserName + "',null,null" +
                                    ",0,null,null,null,'" + ˰��ժҪ + "','" + ������Ŀ˰ + "','" + ���� + "',0," + SqlHelper.ReturnObjectToDecimal(z˰, 2) + "," +
                                    "0," + SqlHelper.ReturnObjectToDecimal(z���˰, 2) + "," + ���� + ",0,0,null,null,null,null,null," +
                                    "null,null,null,null,null,'" + �跽��Ŀ + "',null,null,null,null" +
                                    ",'" + iyear + "','" + iperiod + "','" + ��Ʊ���� + "','Y',@id)";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        //��Ŀ�������ϱ�
                        sSQL = @"insert into Gl_coderemark(iyperiod,iyear,iperiod,csign,ino_id,inid) values('" + iyperiod + "','" + iyear + "','" + iperiod + "','��'," + iƾ֤�� + ",'" + inid + "')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        #endregion
                        #region

                        //�ֽ�����
                        sSQL = @"insert into GL_CashTable (RowGuid,iYear,iPeriod,iSignSeq,csign,iNo_id,inid,cCashItem,md,mc,
ccode,md_f,mc_f,nd_s,nc_s,cdept_id,cperson_id,ccus_id,csup_id,citem_class,
citem_id,cDefine1,cDefine2,cDefine3,cDefine4,cDefine5,cDefine6,cDefine7,cDefine8,cDefine9,
cDefine10,cDefine11,cDefine12,cDefine13,cDefine14,cDefine15,dbill_date,cDefine16) values(
newid(),'" + iyear + "','" + iperiod + "',1,N'��'," + iƾ֤�� + ",1,N'01'," + ��Ʊ��� + ",0," +
"N'" + �跽��Ŀ + "',0,0,0,0,Null,Null,Null,Null,Null," +
"Null,Null,Null,Null,Null,Null,Null,Null,Null,Null," +
"'Y',Null,Null,Null,Null,Null,N'" + DateTime.Now.ToString("yyyy-MM-dd") + "',Null)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        
                        
                        #endregion
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    sSQL = "update  UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetails + " where cVouchType = 'RP' and cAcc_Id = '" + sAccID + "'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update VoucherHistory set cNumber = " + code + " Where  CardNumber='R0' and cContent is NULL";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update Ap_CancelNo set iCancelNo = " + glid + " Where  cType='PZ' and cFlag='GL'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    otrans.Commit();
                    tran.Commit();

                    MessageBox.Show("����ɹ�,��" + scount + "��");

                    gridControl1.DataSource = null;

                }
                catch (Exception error)
                {
                    tran.Rollback();
                    otrans.Rollback();
                    throw new Exception(error.Message);
                }

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private long ReturnID(long l)
        {
            long l1 = 1000000000;
            return l1 + l;
        }

        private string GetColValue(object o)
        { 
            string s = "null";
            if (o.ToString().Trim() != "")
            {
                s = "'" + o.ToString().Trim() + "'";
            }
            return s;
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();

                string sSQL = "select * from ERP_Link_TaxSub where ���='SaleBillVouch'";
                DataTable dt��Ŀ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                string s��Ŀ = "";
                if (dt��Ŀ.Rows.Count > 0)
                {
                    s��Ŀ = dt��Ŀ.Rows[0]["��Ŀ����"].ToString();
                }
                if (s��Ŀ == "")
                {
                    throw new Exception("������ֵ˰��Ŀδ����");
                }

                sSQL = @"select ��Ʊ�ص�,����,����,������,����ʱ��,���ѷ�ʽ,��Ʊ����,a.��Ʊ����,���Ѵ���,������,����,1 as ����,��Ʊ�ܽ��,��Ʊ˰��,TO_CHAR(��Ʊ��ӡʱ��,'YYYY-MM-DD') as ��Ʊ��ӡʱ��,��Ʊ��,
һ����Ŀ����,һ����Ŀ,����ͳ��������,����ͳ�����,������Ŀ,�����Ŀ,��Ʊ����,����,����,�ۿ�,
˰��,���,���-round(˰��,6) ˰,round(˰��,6) as ˰��,�ߴ�,����,����ó,����,����,��׼,����,CHB_BILLID as ��ƱID  from CW_SEND_BILL_VW a left join CW_SEND_CHB_LISTS b on a.CHB_BILLID=b.YSB_CHB_BILLID 
where  1=1 ";
                if (textBox��ƱID.Text != "")
                {
                    sSQL = sSQL + " and CHB_BILLID='" + textBox��ƱID.Text.Trim() + "'";
                }
                if (textBox��Ʊ����.Text != "")
                {
                    sSQL = sSQL + " and a.��Ʊ����='" + textBox��Ʊ����.Text.Trim() + "'";
                }
                if (textBox�ͻ�.Text != "")
                {
                    sSQL = sSQL + " and ���Ѵ��� like '%" + textBox�ͻ�.Text.Trim() + "%'";
                }

                if (dateEdit��ʼ����.Text != "")
                {
                    sSQL = sSQL + " and ��Ʊ��ӡʱ��>=to_date('"+dateEdit��ʼ����.DateTime.ToString("yyyy-MM-dd")+"','YYYY-MM-DD')";
                }
                if (dateEdit��������.Text != "")
                {
                    sSQL = sSQL + " and ��Ʊ��ӡʱ��<to_date('" + dateEdit��������.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "','YYYY-MM-DD')";
                }
                

                DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

                sSQL = "select * from ERP_IMPORT_SALE";
                DataTable dts = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                for (int i = dt.Rows.Count -1 ; i >= 0; i--)
                {
                    if (rdoδ����.Checked == true)
                    {
                        if (dts.Select("��ƱID='" + dt.Rows[i]["��ƱID"].ToString() + "'").Length > 0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                    else
                    {
                        if (dts.Select("��ƱID='" + dt.Rows[i]["��ƱID"].ToString() + "'").Length == 0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                    
                }
                dt.Columns.Add("�跽��Ŀ");
                dt.Columns.Add("������Ŀ");
                dt.Columns.Add("������Ŀ˰");

                DataColumn dc = new DataColumn();
                dc.ColumnName = "ѡ��";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);
                //dt.Columns.Add("ѡ��",typeof(bool));
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["���ѷ�ʽ"].ToString().ToUpper().Trim() == "XJ")
                    {
                        dt.Rows[i]["�跽��Ŀ"] = "1001";
                        dt.Rows[i]["������Ŀ˰"] = s��Ŀ;
                    }
                    else
                    {
                        dt.Rows[i]["�跽��Ŀ"] = "1122";
                        dt.Rows[i]["������Ŀ˰"] = s��Ŀ;
                    }

                    string ������Ŀ = dt.Rows[i]["����ͳ��������"].ToString().Trim();

                    sSQL = "select  count(*) from code where ccode='" + ������Ŀ + "' and bend=1";
                    int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                    if (iCou == 0)
                    {
                        sSQL = "select  count(*) from code where ccode=left('" + ������Ŀ + "',LEN('" + ������Ŀ + "')-2) and bend=1";
                        int iCou1 = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou1 > 0)
                        {
                            dt.Rows[i]["����ͳ��������"] = ������Ŀ.Substring(0, ������Ŀ.Length - 2);
                        }
                    }

                    
                    
                }

                gridControl1.DataSource = dt;

            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.richTextBox1.Text = ee.Message;
                f.Text = "����ʧ��";
                f.ShowDialog();
            }
        }


        //������ʷ�����������µ��ݺ�
        private string ReturnCode(DateTime d, long o)
        {
            string s = o.ToString();
            int iLength = 4;

            for (int i = 0; i < iLength; i++)
            {
                if (s.Length < iLength)
                {
                    s = "0" + s;
                }
                else
                {
                    break;
                }
            }

            s = d.ToString("yyMM") + s;
            return s;
        }

        private string ReturnID(object o)
        {
            string s = o.ToString().Trim();
            for (int i = 0; i < 10; i++)
            {
                if (s.Length < 9)
                    s = "0" + s;
                else if (s.Length == 9)
                    s = "1" + s;
                else
                    break;
            }
            return s;
        }

        private string ReturnDBString(decimal o)
        {
            return o.ToString();
        }

        private string ReturnDBString(object o)
        {
            if (o.ToString().Trim() == "")
                return "null";
            else
            {
                return "'" + o.ToString().Trim() + "'";
            }
        }

        /// <summary>
        /// ���������װ���ݺ�
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <returns></returns>
        private string sGetCode(long l, int iLength)
        {
            string sCode = l.ToString();
            for (int i = 0; i < iLength; i++)
            {
                if (sCode.Length < iLength)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return sCode;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            GetChk(checkEdit1.Checked);
        }

        private void GetChk(bool b)
        {
            if (b == false)
            {
                checkEdit1.Text = "ȫѡ";
            }
            else
            {
                checkEdit1.Text = "ȫ��ȡ��";
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridColChk, b);
            }

        }

        private void ItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            bool b = false;
            if (edit.Checked == true)
            {
                b = true;
            }
            decimal money = 0;
            int iRow = gridView1.FocusedRowHandle;
            string code = gridView1.GetRowCellValue(iRow, gridCol��Ʊ����).ToString().Trim();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridCol��Ʊ����).ToString().Trim() == code)
                {
                    gridView1.SetRowCellValue(i, gridColChk, b);
                }
                if (gridView1.GetRowCellValue(i, gridColChk).ToString().Trim().ToUpper() == "TRUE")
                {
                    money = money + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol���));
                }
            }
            txt�ܽ��.Text = money.ToString();
        }

        public static DataTable Group(DataTable dt, string[] ColumnName,string Sel)
        {
            DataRow[] dw = dt.Select(Sel);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            DataView dv = new DataView(dts);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            return dtgroup;
        }

        public static DataTable Select(DataTable dt, string Sel, string Order)
        {
            DataRow[] dw = dt.Select(Sel, Order);
            DataTable dts = new DataTable();
            foreach (DataColumn dc in dt.Columns)
            {
                dts.Columns.Add(dc.ColumnName);
            }
            foreach (DataRow dws in dw)
            {
                dts.ImportRow(dws);
            }
            return dts;
        }



        private void tsbGet_Click(object sender, EventArgs e)
        {
            Config oconfig = new Config();
            OracleConnection ocon = new OracleConnection(oconfig.ConnectionString);
            OracleCommand ocmd = new OracleCommand();
            OracleTransaction otrans;
            ocon.Open();
            ocmd.Connection = ocon;
            otrans = ocon.BeginTransaction();
            ocmd.Transaction = otrans;

            try
            {
                string sSQL = @"select distinct ��Ʊ����,a.CHB_BILLID as ��ƱID from CW_SEND_BILL_VW a 
left join CW_SEND_CHB_LISTS c on a.CHB_BILLID=c.YSB_CHB_BILLID  where c.YSB_CHB_BILLID is  null";
                DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

                
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();

                sSQL = @"select a.cVouchID,a.cPzID,cPZNum,b.cbill,b.dbill_date,c.��Ʊid,a.Auto_ID,c.* from Ap_Vouch a left join GL_accvouch b on a.cPzID=b.coutno_id 
left join ERP_IMPORT_SALE c on a.cVouchID=c.cVouchID
where cPZNum is not null AND c.cVouchID IS NOT NULL";
                DataTable dts = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow[] dw = dts.Select("��Ʊid='" + dt.Rows[i]["��ƱID"].ToString().Trim() + "'");
                    if (dw.Length > 0)
                    {
                        ocmd.CommandText = @"insert into CW_SEND_CHB_LISTS(YSB_CHB_BILLID,YSB_VOUCHER,YSB_VOUCHER_TM,YSB_VOUCHER_EMPTID) values(
'" + dt.Rows[i]["��ƱID"].ToString() + "','" + dw[0]["cPZNum"].ToString().Trim() + "',TO_DATE('" +DateTime.Parse(dw[0]["dbill_date"].ToString().Trim()).ToString("yyyy-MM-dd") + "','YYYY-MM-DD'),'" + dw[0]["cbill"].ToString().Trim() + "')";
                        ocmd.ExecuteNonQuery();
                        count = count + 1;
                    }
                }
                otrans.Commit();
                if (count > 0)
                {
                    MessageBox.Show("ƾ֤��д�ɹ�,��" + count + "��");
                }
                else
                {
                    MessageBox.Show("����Ҫ��д��ƾ֤");
                }
            }
            catch (Exception error)
            {
                otrans.Rollback();
                MessageBox.Show(error.Message);
            }
        }

        private void rdoδ����_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoδ����.Checked == true)
            {
                btnSave.Enabled = true;
                simpleButton1.Enabled = false;
                gridControl1.DataSource = null;
            }
            else
            {
                btnSave.Enabled = false;
                simpleButton1.Enabled = true;
                gridControl1.DataSource = null;
            }
        }

        private void rdo�ѵ���_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();
            //��������
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSQL = "";
                int scount = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColChk).ToString().Trim().ToUpper() == "TRUE")
                    {

                        string ��ƱID = gridView1.GetRowCellValue(i, gridCol��ƱID).ToString().Trim();
                        string ��Ʊ���� = gridView1.GetRowCellValue(i, gridCol��Ʊ����).ToString().Trim();

                        sSQL = "delete from ERP_IMPORT_SALE where ��ƱID='" + ��ƱID + "' and ��Ʊ����='" + ��Ʊ���� + "'";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        scount = scount + 1;
                    }

                }

                tran.Commit();

                MessageBox.Show("ȡ������ɹ�,��" + scount + "��");

                gridControl1.DataSource = null;

            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }


        }

    }
}