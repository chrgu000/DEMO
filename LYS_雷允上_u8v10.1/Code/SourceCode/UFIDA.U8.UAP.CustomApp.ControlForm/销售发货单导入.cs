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
    public partial class ���۷��������� : UserControl
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

        public ���۷���������()
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
                        sSQL = "select count(1) from DispatchList where cDLCode = '" + dtGrid.Rows[i]["���ݺ�"].ToString().Trim() + "' ";
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

                    sSQL = "SELECT * FROM UFSystem..UA_Identity where cVouchType = 'DISPATCH' and cAcc_Id = '" + sAccID + "'";
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

                        string s������� = dtGrid.Rows[i]["�������"].ToString().Trim();
                        sSQL = "select * from Inventory a inner join Inventory_Sub b on a.cinvcode = b.cinvsubcode  where a.cInvCode = '" + s������� + "'";
                        DataTable dt������� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt������� == null || dt�������.Rows.Count < 1)
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "���" + s������� + "������\n";
                            continue;
                        }

                        decimal d���� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["����"]);
                        if (d���� <= 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "���������������0\n";
                            continue;
                        }

                        DateTime d�������� = SqlHelper.ReturnObjectToDateTime(dtGrid.Rows[i]["��������"]);
                        if (d�������� < Convert.ToDateTime("2000-01-01"))
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "�������ڸ�ʽ����ȷ\n";
                            continue;
                        }

                        sSQL = @"select bflag_SA,iyear ,iperiod,* from GL_mend 
where isnull(bflag_SA,0) = 0 and iperiod <> 0
order by iyear,iperiod ";
                        DataTable dt����״̬ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        DateTime d���� = Convert.ToDateTime(dt����״̬.Rows[0]["iyear"].ToString().Trim() + "-" + dt����״̬.Rows[0]["iperiod"].ToString().Trim() + "-1");
                        if (d���� > d��������)
                        {
                            sErr = sErr + "��" + (i + 1).ToString().Trim() + "�õ�����������ģ���ѽ���\n";
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


                        sSQL = "select * from Warehouse where cWhCode = '" + dtGrid.Rows[i]["�ֿ����"].ToString().Trim() + "'";
                        DataTable dt�ֿ� = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (dt�ֿ�.Rows.Count == 0)
                        {
                            sErr = sErr + "��" + (i + 1).ToString() + "�ֿ���벻����\n";
                            continue;
                        }
                        #endregion

                        #region �����ͷ����

                        string s�������ͱ��� = dtGrid.Rows[i]["��������"].ToString().Trim();


                        sSQL = "select * from dispatchlist where cDLCode = '" + dtGrid.Rows[i]["���ݺ�"].ToString().Trim() + "'";
                        DataTable dt������ = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        if (dt������.Rows.Count == 0)
                        {
                            lID += 1;
                            lIDMain = ReturnID(lID);


                            sSQL = @"
 Insert Into dispatchlist(cbustype,caccounter
    ,ivtid,outid,ccrechpname,cdlcode,cvouchtype
    ,cstcode,ddate,cdepcode,cpersoncode,csbvcode
    ,csocode,ccuscode,cpaycode,csccode,cshipaddress
    ,cexch_name,iexchrate,itaxrate,cmemo,cdefine1
    ,cdefine2,inetlock,breturnflag,dlid,cverifier
    ,cmaker,bfirst,sbvid,cdefine3,cdefine5
    ,cdefine7,cdefine8,cdefine9,cdefine10,cdefine11
    ,cdefine12,cdefine13,cdefine14,cdefine15,cdefine16
    ,cmodifier,isale,ccusname,ccusperson,ccuspersoncode
    ,cbooktype,cbookdepcode,crdcode,ccloser,caddcode
    ,csvouchtype,iflowid,cgatheringplan,icreditdays,bcredit
    ,bmustbook,ioutgolden,iverifystate,ireturncount,icreditstate
    ,iswfcontrolled,cchanger,cchangememo,bcashsale,cgathingcode
    ,bsigncreate,bneedbill,iprintcount,baccswitchflag) 
";

                            sSQL = sSQL + "Values (N'" + dtGrid.Rows[i]["ҵ������"].ToString().Trim() + "',Null" +
    ",71,Null,Null,N'" + dtGrid.Rows[i]["���ݺ�"].ToString().Trim() + "',N'05'" +
    "," + ReturnDBString(dtGrid.Rows[i]["��������"]) + ",'" + d��������.ToString("yyyy-MM-dd") + "'," + ReturnDBString(dtGrid.Rows[i]["���۲���"]) + "," + ReturnDBString(sUserID) + ",Null" +
    ",Null," + ReturnDBString(dt�ͻ�.Rows[0]["cCusCode"]) + ",null," + ReturnDBString(dtGrid.Rows[i]["���˷�ʽ"]) + ",Null" +
    "," + ReturnDBString(dt����.Rows[0]["cexch_name"]) + "," + ReturnDBString(dtGrid.Rows[i]["����"]) + "," + ReturnDBString(dtGrid.Rows[i]["˰��"]) + ",Null,Null " +
    ",Null,Null,0," + lIDMain + ",Null" +
    ",N'" + sUserID + "',0,0,Null,Null" +
    ",Null,Null,Null,Null,Null" +
    ",Null,Null,Null,Null,Null" +
    ",Null,0," + ReturnDBString(dt�ͻ�.Rows[0]["cCusName"]) + ",Null,Null" +
    ",Null,Null,Null,Null,Null" +
    ",Null,0,Null,Null,0" +
    ",0,Null,0,Null,Null" +
    ",0,Null,Null,0,Null" +
    ",0,1,Null,0)    ";


                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                        else
                        {
                            lIDMain = SqlHelper.ReturnObjectToLong(dt������.Rows[0]["DLID"]);
                        }


                        #endregion


                        #region �����������

                        string s�ֿ� = dt�ֿ�.Rows[0]["cWhCode"].ToString().Trim();

                        sSQL = "select count(1) from dispatchlists where dlid = " + lIDMain;
                        int i�к� = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                        i�к� += 1;
                      
                            lIDDetails += 1;


                            //decimal d���� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["����"]);
                            decimal d���� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["����"]);
                            decimal dԭ����˰���� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["ԭ����˰����"]);
                            decimal dԭ�Һ�˰���� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["ԭ�Һ�˰����"]);
                            decimal dԭ����˰��� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["ԭ����˰���"]);
                            decimal dԭ��˰�� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["ԭ��˰��"]);
                            decimal dԭ�Ҽ�˰�ϼ� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["ԭ�Ҽ�˰�ϼ�"]);
                            decimal d������˰���� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["������˰����"]);
                            decimal d���Һ�˰���� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["���Һ�˰����"]);
                            decimal d������˰��� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["������˰���"]);
                            decimal d����˰�� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["����˰��"]);
                            decimal d���Ҽ�˰�ϼ� = SqlHelper.ReturnObjectToDecimal(dtGrid.Rows[i]["���Ҽ�˰�ϼ�"]);


                            decimal d������ = 0;
                            if (d���� != 0)
                            {
                                d������ = SqlHelper.ReturnObjectToDecimal(d���� / d����, 6);
                            }

                            sSQL = @"
 Insert Into dispatchlists(dlid,cwhcode,cinvcode,iquantity,inum,iquotedprice,iunitprice,itaxunitprice,imoney,itax
        ,isum,idiscount,inatunitprice,inatmoney,inattax,inatsum,inatdiscount,ibatch,cbatch,cfree1
        ,cfree2,itb,tbquantity,isosid,idlsid,kl,kl2,cinvname,itaxrate,fsalecost
        ,fsaleprice,cfree3,cfree4,cfree5,cfree6,cfree7,cfree8,cfree9,cfree10,cunitid
        ,ccode,bgsp,csocode,imassdate,cmassunit,bqaneedcheck,bqaurgency,bcosting,cordercode,iorderrowno
        ,fcusminprice,cvmivencode,irowno,iexpiratdatecalcu,cexpirationdate,cbatchproperty1,cbatchproperty2,cbatchproperty3,cbatchproperty4,cbatchproperty5
        ,cbatchproperty6,cbatchproperty7,cbatchproperty8,cbatchproperty9,creasoncode,bneedsign,frlossqty,cinvouchtype) 
";
                            sSQL = sSQL + "Values (" + lIDMain + ",N'" + s�ֿ� + "',N'" + s������� + "'," + d���� + "," + d���� + "," + dԭ����˰���� + "," + dԭ����˰���� + "," + dԭ�Һ�˰���� + "," + dԭ����˰��� + "," + dԭ��˰�� + " " +
        "," + dԭ�Ҽ�˰�ϼ� + ",0," + d������˰���� + "," + d������˰��� + "," + d����˰�� + "," + d���Ҽ�˰�ϼ� + ",0,Null,Null,Null" +
        ",Null,0,0,null," + ReturnID(lIDDetails) + ",100,100," + ReturnDBString(dt�������.Rows[0]["cInvName"]) + ",17,0" +
        ",0,Null,Null,Null,Null,Null,Null,Null,Null,Null" +
        ",Null,0,Null,Null,0,0,0,0,Null,Null" +
        ",0,Null," + i�к�.ToString() + ",0,Null,Null,Null,Null,Null,Null" +
        ",Null,Null,Null,Null,Null,0,0,Null)";

                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    #endregion

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    sSQL = "update UFSystem..UA_Identity set iFatherId = " + lID + ",iChildId = " + lIDDetails + " where cVouchType = 'DISPATCH' and cAcc_Id = '" + sAccID + "'";
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
                    string sSQL = "select * from [���۷�����$]";

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