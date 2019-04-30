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
    public partial class �տ���� : UserControl
    {

        string sState = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public �տ����()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                string sSQL = "select * from ERP_Link_SettleStyle a left join SettleStyle b on a.���㷽ʽ����=b.cSSCode";
                DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                ItemLookUpEdit���㷽ʽ.DataSource = dt;

                dateEdit��������.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                dateEdit��ʼ����.EditValue = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-01";

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message + "��������ʧ��");
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

                string sErr = "";
                string sSQL = "";

                DataTable dtGrid = (DataTable)gridControl1.DataSource;

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
                            sSQL = "select count(1) from ERP_IMPORT_AP where �տID = '" + dtGrid.Rows[i]["�տID"].ToString().Trim() + "' and  ��ƱID = '" + dtGrid.Rows[i]["��ƱID"].ToString().Trim() + "' ";
                            int iCou1 = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou1 > 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "���ݺ��ѵ���\n";
                                continue;
                            }

                            sSQL = "select count(1) from Ap_CloseBill where cDefine15  = '" + dtGrid.Rows[i]["�տID"].ToString().Trim() + "' ";
                            int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                            if (iCou > 0)
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "���ݺ��Ѵ���\n";
                                continue;
                            }


                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "SELECT * FROM UFSystem..UA_Identity where cVouchType = 'SK' and cAcc_Id = '" + sAccID + "'";
                    DataTable dtID = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long lID = 0;
                    long lIDMain = 0;
                    long lIDDetails = 0;
                    if (dtID != null && dtID.Rows.Count > 0)
                    {
                        lID = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iFatherId"]);
                        lIDDetails = SqlHelper.ReturnObjectToLong(dtID.Rows[0]["iChildId"]);
                    }

                    int scount = 0;
                    int ocount = 0;

                    sSQL = "SELECT max(cVouchID) as cVouchID,max(Auto_ID) as Auto_ID FROM  Ap_Vouch";
                    DataTable dtAp_Vouch = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long lvcode = 0;
                    long lvid=0;
                    if (dtAp_Vouch.Rows.Count > 0)
                    {
                        lvcode = SqlHelper.ReturnObjectToLong(dtAp_Vouch.Rows[0]["cVouchID"]);
                        lvid = SqlHelper.ReturnObjectToLong(dtAp_Vouch.Rows[0]["Auto_ID"]);
                    }

                    sSQL = "select isnull(cNumber,0) as Maxnumber From VoucherHistory  with (NOLOCK) Where  CardNumber='RR' and cContent is NULL";
                    DataTable dtcode = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long code = 0;
                    if (dtcode.Rows.Count > 0)
                    {
                        code = SqlHelper.ReturnObjectToLong(dtcode.Rows[0][0]);
                    }
                    
                    DataTable dtgroup = Group(dtGrid, new string[] { "�տID", "�ͻ�����", "��������", "����", "���ѷ�ʽ2", "�����Ŀ", "����" }, "ѡ��='True'");
                    for (int j = 0; j < dtgroup.Rows.Count; j++)
                    {

                        #region ������֤

                        sSQL = @"select bflag_AR,iyear ,iperiod,* from GL_mend 
where isnull(bflag_AR,0) = 0 and iperiod <> 0
order by iyear,iperiod ";
                        DataTable dt����״̬ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        DateTime d���� = Convert.ToDateTime(dt����״̬.Rows[0]["iyear"].ToString().Trim() + "-" + dt����״̬.Rows[0]["iperiod"].ToString().Trim() + "-1");
                        if (d���� > SqlHelper.ReturnObjectToDateTime(dtgroup.Rows[j]["��������"]))
                        {
                            sErr = sErr + "�õ�������"+dtgroup.Rows[j]["��������"]+"Ӧ��ģ���ѽ���\n";
                            continue;
                        }

                        string s�ͻ� = dtgroup.Rows[j]["�ͻ�����"].ToString().Trim();
                        sSQL = "select * from customer where cCusCode = '" + s�ͻ� + "' or cCusName = '" + s�ͻ� + "' or cCusAbbName = '" + s�ͻ� + "'";
                        DataTable dt�ͻ� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt�ͻ� == null || dt�ͻ�.Rows.Count < 1)
                        {
                            sErr = sErr +  "�ͻ�" + s�ͻ� + "������\n";
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
                            sErr = sErr + "����" + dtgroup.Rows[j]["����"].ToString().Trim() + "������\n";
                            continue;
                        }

                        string ���㷽ʽ = dtgroup.Rows[j]["���ѷ�ʽ2"].ToString().Trim();
                        if (���㷽ʽ == "")
                        {
                            sErr = sErr + "�տ" + dtgroup.Rows[j]["�տID"]  + "�Ľ��㷽ʽΪ��\n";
                        }
                        //sSQL = "select * from ERP_Link_SettleStyle a left join SettleStyle b on a.���㷽ʽ����=b.cSSCode where ҵ��ϵͳ���� = '" + dtgroup.Rows[j]["���ѷ�ʽ"].ToString().Trim() + "'";
                        //DataTable dt���㷽ʽ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        //if (dt���㷽ʽ.Rows.Count == 0)
                        //{
                        //    sErr = sErr + "���㷽ʽ" + dtgroup.Rows[j]["���ѷ�ʽ"].ToString().Trim() + "������\n";
                        //    continue;
                        //}
                        //else
                        //{
                        //    ���㷽ʽ = dt���㷽ʽ.Rows[0]["cSSCode"].ToString().Trim();
                        //}


                        #endregion

                        #region �����ͷ����

                        decimal ������� = 0;
                        decimal ���� = SqlHelper.ReturnObjectToDecimal(dtgroup.Rows[j]["����"]);
                        decimal ��Һ������ = 0;

                        string icode = "";
                        string ivcode = "";
                        if (���㷽ʽ != "5")
                        {
                            //cVouchType 48  ��ʾ�տ
                            lID += 1;
                            lIDMain = ReturnID(lID);

                            code += 1;
                            icode = sGetCode(code, 10);

                            sSQL = @"Insert Into Ap_CloseBill (cVouchType,cVouchID,dVouchDate,iPeriod,cDwCode,cDeptCode,cPerson,cItem_Class,cSSCode,cNoteNo
                                                            ,cCoVouchType,cCoVouchID,cBankAccount,cexch_name,iExchRate
                                                            ,iAmount,iAmount_f,iRAmount,iRAmount_f,cOperator
                            
                                                            ,cCancelMan,bStartFlag,cCode,iPayForOther,cFlag,iID,cCancelNo,cBank,bFromBank,bToBank
                                                            ,bSure,VT_ID,cCheckMan,iAmount_s,iSource,dcreatesystime,dverifysystime,dverifydate,cDefine10) " +
                                   "Values (N'48'," + ReturnDBString(icode) + "," + ReturnDBString(dtgroup.Rows[j]["��������"]) + "," + Convert.ToDateTime(dtgroup.Rows[j]["��������"]).Month + "," + ReturnDBString(dt�ͻ�.Rows[0]["cCusCode"]) + ",null,null,null," + ReturnDBString(���㷽ʽ) + ",null" +
                                            ",null,null," + ReturnDBString(dt�ͻ�.Rows[0]["cCusAccount"]) + "," + ReturnDBString(dt����.Rows[0]["cexch_name"]) + "," + ReturnDBString(dtgroup.Rows[j]["����"]) + "," +
                                            "" + ������� + "," + ��Һ������ + "," + ������� + "," + ��Һ������ + ",N'" + sUserName + "'" +

                                            ",null,0," + ReturnDBString(dtgroup.Rows[j]["�����Ŀ"]) + ",0,N'AR'," + lIDMain + ",null," + ReturnDBString(dt�ͻ�.Rows[0]["cCusBank"]) + ",0,0" +
                                            ",0,8052,null,0,null,GETDATE(),null,null,'Y') ";


                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            //
                            lvcode = lvcode + 1;
                            lvid = lvid + 1;
                            ivcode = sGetCode(lvcode, 10);


                            sSQL = @"INSERT into [Ap_Vouch] ([cLink],[cVouchType],[cVouchID],[dVouchDate],[cDwCode],[cCode],[cexch_name],[iExchRate],[bd_c],
[iAmount],[iAmount_f],[iRAmount],[iRAmount_f],[cOperator],[bStartFlag],[cFlag],[cDefine1],[iAmount_s],[iRAmount_s],
[VT_ID],[Ufts],[iClosesID],[iCoClosesID],[dGatheringDate],[dcreatesystime],[Auto_ID],[iPrintCount]) 
VALUES ( N'R0" + ivcode + "',N'R0',N'" + ivcode + "'," + ReturnDBString(dtgroup.Rows[j]["��������"]) + "," + ReturnDBString(dt�ͻ�.Rows[0]["cCusCode"]) + ",N'2203',N" + ReturnDBString(dt����.Rows[0]["cexch_name"]) + ",1,1," +
    "" + ������� + "," + ��Һ������ + "," + ������� + "," + ��Һ������ + ",N'" + sUserName + "',0,N'AR',null,0,0," +
    "8054,null,0,0,null,'" + DateTime.Now.ToString() + "'," + lvid + ",0)";

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }

                        scount = scount + 1;

                        #endregion

                        #region �����������
                        for (int i = 0; i < dtGrid.Rows.Count; i++)
                        {
                            if (dtGrid.Rows[i]["ѡ��"].ToString().Trim() == "True" 
                                && dtGrid.Rows[i]["�տID"].ToString().Trim() == dtgroup.Rows[j]["�տID"].ToString().Trim()
                                && dtGrid.Rows[i]["�����Ŀ"].ToString().Trim() == dtgroup.Rows[j]["�����Ŀ"].ToString().Trim()
                                && dtGrid.Rows[i]["��������"].ToString().Trim() == dtgroup.Rows[j]["��������"].ToString().Trim()
                                && dtGrid.Rows[i]["���ѷ�ʽ2"].ToString().Trim() == dtgroup.Rows[j]["���ѷ�ʽ2"].ToString().Trim())
                            {
                                lIDDetails += 1;
                                decimal s������� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["�������"]);
                                decimal s��Һ������ = s������� * ����;

                                ������� = s������� + �������;
                                ��Һ������ = s��Һ������ + ��Һ������;

                                if (���㷽ʽ != "5")
                                {
                                    sSQL = "INSERT INTO Ap_CloseBills (iID,ID,iType,bPrePay,cCusVen,iAmt_f,iAmt,iRAmt_f,iRAmt,cKm," +
                                                "cXmClass,cDepCode,iAmt_s,iRAmt_s,iOrderType) " +
                                           "VALUES " +
                                        "(" + lIDMain + "," + ReturnID(lIDDetails) + ",0,0," + ReturnDBString(dt�ͻ�.Rows[0]["cCusCode"]) + "," + s��Һ������ + "," + s������� + "," + s��Һ������ + "," + s������� + "," + ReturnDBString(dtGrid.Rows[i]["������Ŀ"]) + "," +
                                                "NULL,NULL,0,0,NULL)";

                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "insert into ERP_IMPORT_AP(��Ʊ����,��ƱID,�տID,������ID,ERP�տID,ERP�տ���ݺ�) " +
                                "values(" + ReturnDBString(dtGrid.Rows[i]["��Ʊ����"]) + "," + ReturnDBString(dtGrid.Rows[i]["��ƱID"]) + "," + ReturnDBString(dtGrid.Rows[i]["�տID"]) + "," + ReturnDBString(dtGrid.Rows[i]["������ID"]) + "," +
                                "" + lID + ",'" + icode + "') ";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                                else
                                {
                                    sSQL = @"INSERT into [Ap_Vouchs] ([cLink],[cDwCode],[cDigest],[cCode],[cexch_name],[iExchRate],[bd_c],[iAmount],[iAmount_f],[iAmt_s]) 
                                VALUES ( N'R0" + ivcode + "'," + ReturnDBString(dt�ͻ�.Rows[0]["cCusCode"]) + ",N''," + ReturnDBString(dtGrid.Rows[i]["������Ŀ"]) + ",N" + ReturnDBString(dt����.Rows[0]["cexch_name"]) + ",1,0," + ������� + "," + ��Һ������ + ",0)";

                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                                    sSQL = "insert into ERP_IMPORT_AP(��Ʊ����,��ƱID,�տID,������ID,ERP�տID,ERP�տ���ݺ�) " +
                                "values(" + ReturnDBString(dtGrid.Rows[i]["��Ʊ����"]) + "," + ReturnDBString(dtGrid.Rows[i]["��ƱID"]) + "," + ReturnDBString(dtGrid.Rows[i]["�տID"]) + "," + ReturnDBString(dtGrid.Rows[i]["������ID"]) + "," +
                                "" + lID + ",'" + lvcode + "') ";
                                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                                }
                            }
                        }
                        if (���㷽ʽ != "5")
                        {
                            sSQL = "update Ap_CloseBill set iAmount=" + ������� + ",iAmount_f=" + ��Һ������ + ",iRAmount=" + ������� + ",iRAmount_f=" + ��Һ������ + " where iID='" + lIDMain + "'";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            sSQL = "update Ap_Vouch set iAmount=" + ������� + ",iAmount_f=" + ��Һ������ + " where cVouchID='" + ivcode + "'";
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        #endregion

                        
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetails + " where cVouchType = 'SK' and cAcc_Id = '" + sAccID + "'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "update VoucherHistory set cNumber = " + code + " Where  CardNumber='RR' and cContent is NULL";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();
                    otrans.Commit();
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

                string sSQL = @"select a.��ƱID,a.����ID as ������ID,a.�տID,a.��Ʊ����,��Ʊ����,���Ѵ���,�տ��,�տʱ��,�տ����,�տ���,�տ�ʺ�,����,1 as ����,����,����,������,
��Ʊ���,��Ʊ˰��,�������, ���ѷ�ʽ ,��ע,�ͻ�����,���Ѵ��� as �ͻ�����,��Ʊ�ص�,������־,����,�ָ�ʱ��,��Ʊ״̬,CHB_ARCHIVEFG,
���Ѻ�����־,���Ѻ�����,���Ѻ���ʱ��,����Ӧ�ձ�־,����Ӧ����,����Ӧ��ʱ��,CHB_RETURN_FLAG,��Ʊ��ӡ����,CHB_TERM_NAME,
CHB_CST_CSTMNM,CHB_IE_NAME,CHB_BANK_NAME,��Ʊ�ͳ�ʱ��,TO_CHAR(��Ʊ�տ�ʱ��,'yyyy-mm-dd') as ��������,BLA_HANDLE_TYPE from CW_RECE_MONEY_VW a left join CW_RECE_BILL_LISTS c on a.�տID=c.YRB_REL_ID 
where 1=1 ";

                if (textBox��ƱID.Text != "")
                {
                    sSQL = sSQL + " and a.��ƱID='" + textBox��ƱID.Text.Trim() + "'";
                }
                if (textBox��Ʊ����.Text != "")
                {
                    sSQL = sSQL + " and a.��Ʊ����='" + textBox��Ʊ����.Text.Trim() + "'";
                }
                if (textBox�ͻ�.Text != "")
                {
                    sSQL = sSQL + " and �ͻ��� like '%" + textBox�ͻ�.Text.Trim() + "%'";
                }
                if (textBox�տID.Text != "")
                {
                    sSQL = sSQL + " and a.�տID='" + textBox�տID.Text.Trim() + "'";
                }
                if (dateEdit��ʼ����.Text != "")
                {
                    sSQL = sSQL + " and ��Ʊ�տ�ʱ��>=to_date('" + dateEdit��ʼ����.DateTime.ToString("yyyy-MM-dd") + "','YYYY-MM-DD')";
                }
                if (dateEdit��������.Text != "")
                {
                    sSQL = sSQL + " and ��Ʊ�տ�ʱ��<to_date('" + dateEdit��������.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "','YYYY-MM-DD')";
                }



                DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

                sSQL = "select * from ERP_IMPORT_AP";
                DataTable dts = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (rdoδ����.Checked == true)
                    {
                        //sSQL = sSQL + " and c.YRB_REL_ID is  null ";
                        if (dts.Select("�տID='" + dt.Rows[i]["�տID"].ToString() + "' and ��ƱID='" + dt.Rows[i]["��ƱID"].ToString() + "'").Length > 0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }
                    else
                    {
                        //sSQL = sSQL + " and c.YRB_REL_ID is not null ";
                        if (dts.Select("�տID='" + dt.Rows[i]["�տID"].ToString() + "' and ��ƱID='" + dt.Rows[i]["��ƱID"].ToString() + "'").Length == 0)
                        {
                            dt.Rows.Remove(dt.Rows[i]);
                        }
                    }

                }

                dt.Columns.Add("�跽��Ŀ");
                dt.Columns.Add("������Ŀ");
                dt.Columns.Add("�����Ŀ");
                DataColumn dc = new DataColumn();
                dc.ColumnName = "ѡ��";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = false;
                dt.Columns.Add(dc);

                bool b = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["������Ŀ"] = "1122";

                    dt.Rows[i]["�����Ŀ"] = "10020101";
                    gridView1.SetRowCellValue(i, gridColChk, b);
                }

                dt.Columns.Add("���ѷ�ʽ2");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string ���㷽ʽ = "";
                    sSQL = "select * from ERP_Link_SettleStyle a left join SettleStyle b on a.���㷽ʽ����=b.cSSCode where ҵ��ϵͳ���� = '" + dt.Rows[i]["���ѷ�ʽ"].ToString().Trim() + "'";
                    DataTable dt���㷽ʽ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt���㷽ʽ.Rows.Count == 0)
                    {
                        //sErr = sErr + "���㷽ʽ" + dtGrid.Rows[i]["���ѷ�ʽ"].ToString().Trim() + "������\n";
                        //continue;
                    }
                    else
                    {
                        ���㷽ʽ = dt���㷽ʽ.Rows[0]["cSSCode"].ToString().Trim();
                    }
                    dt.Rows[i]["���ѷ�ʽ2"] = ���㷽ʽ;
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

        private string ReturnDBString(DateTime o)
        {
            return o.ToString("yyyy-MM-dd");
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
            try
            {
                GetChk(checkEdit1.Checked);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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
            try
            {
                CheckEdit edit = sender as CheckEdit;
                bool b = false;
                if (edit.Checked == true)
                {
                    b = true;
                }

                int iRow = gridView1.FocusedRowHandle;
                string code = gridView1.GetRowCellValue(iRow, gridCol��Ʊ����).ToString().Trim();
                decimal money = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridCol��Ʊ����).ToString().Trim() == code)
                    {
                        gridView1.SetRowCellValue(i, gridColChk, b);
                    }
                    if (gridView1.GetRowCellValue(i, gridColChk).ToString().Trim().ToUpper() == "TRUE")
                    {
                        money = money + SqlHelper.ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridCol�������));
                    }
                }
                txt�ܽ��.Text = money.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public static DataTable Group(DataTable dt, string[] ColumnName, string Sel)
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
            try
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
                    string sSQL = @"select a.��Ʊ����,a.��ƱID,a.�տID,����ID as ������ID from CW_RECE_MONEY_VW a 
left join CW_RECE_BILL_LISTS c on a.�տID=c.YRB_REL_ID  where c.YRB_REL_ID is  null";
                    DataTable dt = OracleHelp.ExecuteDataTable(sSQL);

                    SqlConnection conn = new SqlConnection(Conn);
                    conn.Open();
                    //��������
                    SqlTransaction tran = conn.BeginTransaction();

                    sSQL = @"select cVouchID,cPZNum,b.cbill,b.dbill_date,�տID from Ap_CloseBill a left join GL_accvouch b on a.cPzID=b.coutno_id 
left join ERP_IMPORT_AP c on a.cVouchID=c.erp�տ���ݺ� where cPZNum is not null ";
                    DataTable dts = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    int count = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow[] dw = dts.Select("�տID='" + dt.Rows[i]["�տID"].ToString().Trim() + "'");
                        if (dw.Length > 0)
                        {
                            ocmd.CommandText = @"insert into CW_RECE_BILL_LISTS(YRB_CHB_BILLID,YRB_RCV_RCVID,YRB_REL_ID,YRB_VOUCHER,
                        YRB_VOUCHER_TM,YRB_VOUCHER_EMPTID,YRB_TYPE) 
                        values('" + dt.Rows[i]["��ƱID"].ToString() + "','" + dt.Rows[i]["������ID"].ToString() + "','" + dt.Rows[i]["�տID"].ToString() + "','" + dw[0]["cPZNum"].ToString().Trim() + "'," +
                            "TO_DATE('" + DateTime.Parse(dw[0]["dbill_date"].ToString().Trim()).ToString("yyyy-MM-dd") + "','YYYY-MM-DD'),'" + dw[0]["cbill"].ToString().Trim() + "',null)";
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
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void rdoδ����_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
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
                        string �տID = gridView1.GetRowCellValue(i, gridCol�տID).ToString().Trim();
                        sSQL = "delete from ERP_IMPORT_AP where ��ƱID='" + ��ƱID + "' and ��Ʊ����='" + ��Ʊ���� + "' and �տID='" + �տID + "'";
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





