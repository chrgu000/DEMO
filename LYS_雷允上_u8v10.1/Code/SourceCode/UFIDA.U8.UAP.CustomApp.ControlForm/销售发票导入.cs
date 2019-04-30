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

                DataTable dtGrid = (DataTable)gridControl1.DataSource;

                string sErr = "";
                string sSQL = "";

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        sSQL = "select count(1) from SaleBillVouch where cSBVCode = '" + dtGrid.Rows[i]["��Ʊ��"].ToString().Trim() + "' ";
                        int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        if (iCou > 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "��Ʊ���Ѵ���\n";
                            continue;
                        }
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    sSQL = "SELECT iFatherId,iChildId FROM UFSystem..UA_Identity where cVouchType = 'BILLVOUCH' and cAcc_Id = '" + sAccID + "'";
                    DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    long lID=0;
                    long lIDMain=0;
                     long lIDDetail=0;
                     if (dt != null && dt.Rows.Count > 0)
                     {
                         lID = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iFatherId"]);

                         lIDMain = lID;
                         lIDDetail = SqlHelper.ReturnObjectToLong(dt.Rows[0]["iChildId"]);
                     }

                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        #region ������֤

                        sSQL = "select * from Inventory where cInvCode = '" + dtGrid.Rows[i]["�������"].ToString().Trim() + "'";
                        DataTable dt��� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt���.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "���������\n";
                            continue;
                        }

                        sSQL = "select * from SaleType  where cSTCode  = '" + dtGrid.Rows[i]["��������"].ToString().Trim() + "'";
                        DataTable dt�������� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt��������.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "�������Ͳ�����\n";
                            continue;
                        }

                        sSQL = "select * from Customer where cCusCode = '" + dtGrid.Rows[i]["�ͻ�����"].ToString().Trim() + "'";
                        DataTable dt�ͻ� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt�ͻ�.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "�ͻ����벻����\n";
                            continue;
                        }

                        sSQL = "select * from Department where cDepCode = '" + dtGrid.Rows[i]["���۲���"].ToString().Trim() + "'";
                        DataTable dt���� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt����.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "���۲��Ų�����\n";
                            continue;
                        }

                        sSQL = "select * from Warehouse where cWhCode = '" + dtGrid.Rows[i]["�ֿ����"].ToString().Trim() + "'";
                        DataTable dt�ֿ� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt�ֿ�.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "�ֿ���벻����\n";
                            continue;
                        }

                        sSQL = "select * from foreigncurrency where cexch_code = '" + dtGrid.Rows[i]["����"].ToString().Trim() + "' or cexch_name = '" + dtGrid.Rows[i]["����"].ToString().Trim() + "'";
                        DataTable dt���� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt����.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "���ֲ�����\n";
                            continue;
                        }

                        sSQL = "select * from person where cPersonCode = '" + dtGrid.Rows[i]["ҵ��Ա"].ToString().Trim() + "' or cPersonName = '" + dtGrid.Rows[i]["ҵ��Ա"].ToString().Trim() + "'";
                        DataTable dtҵ��Ա = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dtҵ��Ա.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "ҵ��Ա������\n";
                            continue;
                        }


                        #endregion


                        sSQL = "select * from salebillvouch where csbvcode = '" + dtGrid.Rows[i]["��Ʊ��"].ToString().Trim() + "'";
                        DataTable dt���۷�Ʊ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt���۷�Ʊ.Rows.Count == 0)
                        {
                            lID += 1;
                            lIDMain = ReturnID(lID);

                            sSQL = "select * from Bank";
                            DataTable dt�������� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


                            string s��Ʊ���� = "";
                            if (dtGrid.Rows[i]["��������"].ToString().Trim() == "��ֵ˰ר�÷�Ʊ")           //0 ר�÷�Ʊ��1 ��ͨ��Ʊ
                                s��Ʊ���� = "26";

                            if (dtGrid.Rows[i]["��������"].ToString().Trim() == "��ֵ˰��ͨ��Ʊ")
                                s��Ʊ���� = "27";

                            if (s��Ʊ���� == "")
                            {
                                sErr = sErr + "��" + (i + 1).ToString() + "�������Ͳ�����\n";
                                continue;
                            }


                            int i������־ = 0;
                            if (SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["����"], 2) < 0 || SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["ԭ�Ҽ�˰�ϼ�"], 2) < 0)
                            {
                                i������־ = 1;
                            }

                            sSQL = " Insert Into salebillvouch(ivtid,csource,cstcode,cdepcode,ccuscode,ccusbank,ccusaccount,bcashsale,sbvid,csbvcode" +
                                        ",cvouchtype,ddate,csocode,cdefine2,cmaker,cverifier,iexchrate,itaxrate,breturnflag,bfirst" +

                                        ",cbustype,cbcode,cexch_name,ccusname,idisp,cdlcode,cchecker,iflowid,bcredit,ioutgolden" +
                                        ",iverifystate,iswfcontrolled,iprintcount,cgatheringplan,icreditdays,cPersonCode ) " +

                                   "Values (53,N'����',N'" + dtGrid.Rows[i]["��������"].ToString().Trim() + "',N'" + dtGrid.Rows[i]["���۲���"].ToString().Trim() + "',N'" + dtGrid.Rows[i]["�ͻ�����"].ToString().Trim() + "',N'" + dt�ͻ�.Rows[0]["cCusBank"].ToString().Trim() + "',N'" + dt�ͻ�.Rows[0]["cCusAccount"].ToString().Trim() + "',0," + lIDMain + ",N'" + dtGrid.Rows[i]["��Ʊ��"].ToString().Trim() + "'" +
                                   ",N'" + s��Ʊ���� + "','" + dtGrid.Rows[i]["��Ʊ����"].ToString().Trim() + "',Null,Null,N'" + sUserName + "',Null," + dtGrid.Rows[i]["����"].ToString().Trim() + "," + dtGrid.Rows[i]["˰��"].ToString().Trim() + "," + i������־ + ",0" +

                                   ",N'��ͨ����',N'" + dt��������.Rows[0]["cBCode"].ToString().Trim() + "',N'" + dt����.Rows[0]["cexch_name"].ToString().Trim() + "',N'" + dt�ͻ�.Rows[0]["cCusName"].ToString().Trim() + "',0,Null,Null,Null,0,Null" +
                                   ",0,0,Null,Null,Null,'" + dtҵ��Ա.Rows[0]["cPersonCode"].ToString().Trim() + "')";

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            lIDMain = SqlHelper.ReturnObjectToLong(dt���۷�Ʊ.Rows[0]["SBVID"]);
                        }

                        lIDDetail += 1;

                        decimal d���� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["����"]);
                        decimal d���� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["����"]);
                        decimal d������ = 0;
                        if (d���� != 0)
                        {
                            d������ = SqlHelper.ReturnObjectToDecimal(d���� / d����, 6);
                        }

                        sSQL = "Insert Into salebillvouchs(sbvid,autoid,cwhcode,cinvcode,iquantity,inum,iquotedprice,iunitprice,itaxunitprice,imoney" +
                                        ",itax,isum,idiscount,inatunitprice,inatmoney,inattax,inatsum,inatdiscount,isbvid,imoneysum" +
                                        ",iexchsum,cclue,cincomesub,ctaxsub,ibatch,cbatch,bsettleall,rdsid,itb,tbquantity" +
                                        ",isosid,idlsid,kl,kl2,cinvname,itaxrate,foutquantity,foutnum,fsalecost,fsaleprice" +

                                        ",iinvexchrate,cunitid,ipbvsid,ccode,csocode,bgsp,ccontractid,ccontracttagcode,ccontractrowguid,cmassunit" +
                                        ",bqaneedcheck,bqaurgency,cbaccounter,bcosting,cordercode,iorderrowno,fcusminprice,irowno,iexpiratdatecalcu,idemandtype" +
                                        ",cdemandcode,cdemandmemo,cdemandid,idemandseq,cbdlcode,iinvsncount,bneedsign,cgathingcode,ftaxpasum,fpasum" +
                                        ",fnattaxpasum,fnatpasum,body_outid,cinvouchtype,icostquantity,icostsum)" +
                              " Values (" + lIDMain + "," + ReturnID(lIDDetail) + ",N'" + dtGrid.Rows[i]["�ֿ����"].ToString().Trim() + "',N'" + dtGrid.Rows[i]["�������"].ToString().Trim() + "'," + d���� + "," + d���� + ",0," + SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["ԭ����˰����"]) + "," + SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["ԭ�Һ�˰����"]) + "," + SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["ԭ����˰���"]) + "" +
                                        "," + dtGrid.Rows[i]["ԭ��˰��"].ToString().Trim() + "," + dtGrid.Rows[i]["ԭ�Ҽ�˰�ϼ�"].ToString().Trim() + ",0," + dtGrid.Rows[i]["������˰����"].ToString().Trim() + "," + dtGrid.Rows[i]["������˰���"].ToString().Trim() + "," + dtGrid.Rows[i]["����˰��"].ToString().Trim() + "," + dtGrid.Rows[i]["���Ҽ�˰�ϼ�"].ToString().Trim() + ",0,0,0" +
                                        ",0,Null,Null,Null,Null,Null,0,Null,0,0" +
                                        ",Null,Null,100,100,N'" + dt���.Rows[0]["cInvName"].ToString().Trim() + "'," + dtGrid.Rows[i]["˰��"].ToString().Trim() + ",0,0,0,0" +
                                        "," + d������ + ",N'" + dt���.Rows[0]["cComUnitCode"].ToString().Trim() + "',Null,Null,Null,0,Null,Null,Null,0" +
                                        ",0,0,Null,1,Null,Null,0,1,0,Null" +
                                        ",Null,Null,Null,Null,Null,0,0,Null,0,Null" +
                                        ",0,0,Null,Null,Null,Null)";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }


                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }


                    sSQL = "update  UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetail + " where cVouchType = 'BILLVOUCH' and cAcc_Id = '" + sAccID + "'";
                    SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    tran.Commit();
                    MessageBox.Show("����ɹ�");
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
                    string sSQL = "select * from [���۷�Ʊ$]";

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