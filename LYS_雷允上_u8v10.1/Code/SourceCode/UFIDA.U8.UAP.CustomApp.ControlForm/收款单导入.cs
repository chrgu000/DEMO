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
using TH.BaseClass;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class �տ���� : UserControl
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

        public �տ����()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ee)
            {
                //MessageBox.Show("��������ʧ��");
                throw new Exception(ee.Message);
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

                try
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        sSQL = "select count(1) from Ap_CloseBill where cVouchID = '" + dtGrid.Rows[i]["���ݺ�"].ToString().Trim() + "' ";
                        int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou > 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "���ݺ��Ѵ���\n";
                            continue;
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

                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        #region ������֤

                        sSQL = @"select bflag_AR,iyear ,iperiod,* from GL_mend 
where isnull(bflag_AR,0) = 0 and iperiod <> 0
order by iyear,iperiod ";
                        DataTable dt����״̬ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        DateTime d���� = Convert.ToDateTime(dt����״̬.Rows[0]["iyear"].ToString().Trim() + "-" + dt����״̬.Rows[0]["iperiod"].ToString().Trim() + "-1");
                        if (d���� > SqlHelper.ReturnObjectToDateTime(dtGrid.Rows[i]["��������"]))
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "�õ�������Ӧ��ģ���ѽ���\n";
                            continue;
                        }

                        string s�ͻ� = dtGrid.Rows[i]["�ͻ�����"].ToString().Trim();
                        sSQL = "select * from customer where cCusCode = '" + s�ͻ� + "' or cCusName = '" + s�ͻ� + "' or cCusAbbName = '" + s�ͻ� + "'";
                        DataTable dt�ͻ� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt�ͻ� == null || dt�ͻ�.Rows.Count < 1)
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "�ͻ�" + s�ͻ� + "������\n";
                            continue;
                        }
                        if (dt�ͻ�.Rows.Count > 1)
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "�ͻ�" + s�ͻ� + "���ڶ������,��ʹ�ÿͻ�����Ψһָ��\n";
                            continue;
                        }

                        sSQL = "select * from foreigncurrency where cexch_code = '" + dtGrid.Rows[i]["����"].ToString().Trim() + "' or cexch_name = '" + dtGrid.Rows[i]["����"].ToString().Trim() + "'";
                        DataTable dt���� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt����.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "���ֲ�����\n";
                            continue;
                        }

                        sSQL = "select * from SettleStyle where cSSCode = '" + dtGrid.Rows[i]["���㷽ʽ"].ToString().Trim() + "' or cSSName = '" + dtGrid.Rows[i]["���㷽ʽ"].ToString().Trim() + "'";
                        DataTable dt���㷽ʽ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt���㷽ʽ.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "���㷽ʽ������\n";
                            continue;
                        }

                        sSQL = "select * from person where cPersonCode = '" + dtGrid.Rows[i]["ҵ��Ա"].ToString().Trim() + "' or cPersonName = '" + dtGrid.Rows[i]["ҵ��Ա"].ToString().Trim() + "'";
                        DataTable dtҵ��Ա = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtҵ��Ա.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "ҵ��Ա������\n";
                            continue;
                        }

                        sSQL = "select * from Department where isnull(bDepEnd,0) = 1 and  (cDepCode  = '" + dtGrid.Rows[i]["����"].ToString().Trim() + "' or cDepName = '" + dtGrid.Rows[i]["����"].ToString().Trim() + "')";
                        DataTable dt���� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt����.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "���Ų����ڣ�����ĩ������\n";
                            continue;
                        }
                        #endregion

                        #region �����ͷ����


                        sSQL = "select * from Ap_CloseBill where cVouchID = '" + dtGrid.Rows[i]["���ݺ�"].ToString().Trim() + "'";
                        DataTable dt�տ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt�տ.Rows.Count == 0)
                        {
                            lID += 1;
                            lIDMain = ReturnID(lID);

                            //cVouchType 48  ��ʾ�տ
                            sSQL = @"Insert Into Ap_CloseBill (cVouchType,cVouchID,dVouchDate,iPeriod,cDwCode,cDeptCode,cPerson,cItem_Class,cSSCode,cNoteNo" +
                                            ",cCoVouchType,cCoVouchID,cBankAccount,cexch_name,iExchRate,iAmount,iAmount_f,iRAmount,iRAmount_f,cOperator" +

                                            ",cCancelMan,bStartFlag,cCode,iPayForOther,cFlag,iID,cCancelNo,cBank,bFromBank,bToBank" +
                                            ",bSure,VT_ID,cCheckMan,iAmount_s,iSource,dcreatesystime,dverifysystime,dverifydate) " +
                                   "Values (N'48'," + ReturnDBString(dtGrid.Rows[i]["���ݺ�"]) + "," + ReturnDBString(dtGrid.Rows[i]["��������"]) + "," + Convert.ToDateTime(dtGrid.Rows[i]["��������"]).Month + "," + ReturnDBString(dt�ͻ�.Rows[0]["cCusCode"]) + ",'" + dt����.Rows[0]["cDepCode"].ToString().Trim() + "','" + dtҵ��Ա.Rows[0]["cPersonCode"].ToString().Trim() + "',null," + ReturnDBString(dt���㷽ʽ.Rows[0]["cSSCode"]) + ",null" +
                                            ",null,null," + ReturnDBString(dt�ͻ�.Rows[0]["cCusAccount"]) + "," + ReturnDBString(dt����.Rows[0]["cexch_name"]) + "," + ReturnDBString(dtGrid.Rows[i]["����"]) + "," + ReturnDBString(dtGrid.Rows[i]["���ҽ��"]) + "," + ReturnDBString(dtGrid.Rows[i]["ԭ�ҽ��"]) + "," + ReturnDBString(dtGrid.Rows[i]["���ҽ��"]) + "," + ReturnDBString(dtGrid.Rows[i]["ԭ�ҽ��"]) + ",N'" + sUserName + "'" +

                                            ",null,0," + ReturnDBString(dtGrid.Rows[i]["�����Ŀ"]) + ",0,N'AR'," + lIDMain + ",null," + ReturnDBString(dt�ͻ�.Rows[0]["cCusBank"]) + ",0,0" +
                                            ",0,8052,null,0,null,GETDATE(),null,null) ";


                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            lIDMain = SqlHelper.ReturnObjectToLong(dt�տ.Rows[0]["iID"]);
                        }


                        #endregion


                        #region �����������

                        lIDDetails += 1;

                        sSQL = "INSERT INTO Ap_CloseBills (iID,ID,iType,bPrePay,cCusVen,iAmt_f,iAmt,iRAmt_f,iRAmt,cKm," +
                                    "cXmClass,cDepCode,iAmt_s,iRAmt_s,iOrderType) " +
                               "VALUES " +
                            "(" + lIDMain + "," + ReturnID(lIDDetails) + ",0,0," + ReturnDBString(dt�ͻ�.Rows[0]["cCusCode"]) + "," + ReturnDBString(dtGrid.Rows[i]["ԭ�ҽ��"]) + "," + ReturnDBString(dtGrid.Rows[i]["���ҽ��"]) + "," + ReturnDBString(dtGrid.Rows[i]["ԭ�ҽ��"]) + "," + ReturnDBString(dtGrid.Rows[i]["���ҽ��"]) + "," + ReturnDBString(dtGrid.Rows[i]["������Ŀ"]) + "," +
                                    "NULL,NULL,0,0,NULL)";
                     
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    #endregion

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetails + " where cVouchType = 'SK' and cAcc_Id = '" + sAccID + "'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();
                    MessageBox.Show("����ɹ�", "��ʾ");

                    gridControl1.DataSource = null;
                }
                catch (Exception error)
                {
                    tran.Rollback();
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
                TH.BaseClass.ClsExcel clsExcel = TH.BaseClass.ClsExcel.Instance();

                OpenFileDialog oFile = new OpenFileDialog();
                oFile.Filter = "Excel�ļ�|*.xls|Excel�ļ�|*.xlsx";
                if (oFile.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = oFile.FileName;
                    string sSQL = "select * from [�տ$]";

                    DataTable dt = clsExcel.ExcelToDT(sFilePath, sSQL, true);

                    gridView1.Columns.Clear();

                    gridControl1.DataSource = dt;


                    if (dt == null || dt.Rows.Count < 1)
                        throw new Exception("���ص��ļ�û�����ݣ����ʵ�����");
                }
                else
                {
                    throw new Exception("ȡ������");
                }
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
    }
}