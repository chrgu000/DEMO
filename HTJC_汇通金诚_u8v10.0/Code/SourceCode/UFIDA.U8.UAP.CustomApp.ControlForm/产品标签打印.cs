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
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class ��Ʒ��ǩ��ӡ : UserControl
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

        public ��Ʒ��ǩ��ӡ()
        {
            InitializeComponent();

            sPrintLayOutMod = sProPath + "\\UAP\\Runtime\\print\\Model\\" + this.labelControl1.Text.Trim() + "Mod.dll";
            sPrintLayOutUser = sProPath + "\\UAP\\Runtime\\print\\User\\" + this.labelControl1.Text.Trim() + "User.dll";
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
                {
                    btnPrintSET.Visible = true;
                }
                else
                {
                    btnPrintSET.Visible = false;
                }
                txt�к�.EditValue = "1";

                SetLookup();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                SetNull();
                if (lookUpEdit����������1.Text.Trim() == "")
                {
                    MessageBox.Show("���������Ų���Ϊ��");
                    lookUpEdit����������1.Focus();
                    return;
                }

                if (txt�к�.Text.Trim() == "")
                {
                    MessageBox.Show("���������кŲ���Ϊ��");
                    txt�к�.Focus();
                    return;
                }

                string sSQL = @"
select * 
	,cast(d.������ as varchar(10)) as ������ ,case when d.guid is null then newid() else d.guid end as GUID
from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join Inventory c on b.InvCode = c.cInvCode
    left join ��������Ϣ  d on d.���������� = a.MoCode and d.�к� = b.SortSeq 
where 1=1
";

                sSQL = sSQL.Replace("1=1", "1=1 and a.MoCode = '" + lookUpEdit����������1.Text.Trim() + "' and b.SortSeq = '" + txt�к�.Text.Trim() + "' ");
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                if (dt == null || dt.Rows.Count < 1)
                {
                    MessageBox.Show("δ�ҵ���Ӧ�����������кţ����ʵ");
                    SetNull();
                    return;
                }



                txt�������.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                txt�������.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                txt����ͺ�.Text = dt.Rows[0]["cInvStd"].ToString().Trim();
                txt����.Text = dt.Rows[0]["Free1"].ToString().Trim();

                string s����=dt.Rows[0]["define25"].ToString().ToUpper().Trim();
                string[] arr = s����.Split(new string[] { "KG" },System.StringSplitOptions.None);
                if (arr.Length > 0)
                {
                    txtë��.Text = arr[0].Trim();
                }
                txtGuid.Text = Guid.NewGuid().ToString();
                //sSQL = "select top 1 cast(substring(����,11,3) as int) +1 as ���� from ��������Ϣ where ���������� like '" + lookUpEdit����������1.Text.Trim() + "' order by ���� desc";
                sSQL = "select isnull(max(����),0) as ����  from ��������Ϣ where ���������� = '" + lookUpEdit����������1.Text.Trim() + "' ";
                DataTable dtpro = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                if (dtpro.Rows.Count == 0)
                {
                    txt����.Text = lookUpEdit����������1.Text.Trim() + "001";
                }
                else
                {

                    string s���� = dtpro.Rows[0]["����"].ToString().Trim();
                    if (s����.Length == 1)
                    {
                        txt����.Text = lookUpEdit����������1.Text.Trim() + "001";
                    }
                    else
                    {
                        int iLeng = s����.Length;
                        s���� = s����.Substring(iLeng - 3);
                        s���� = (ReturnObjectToInt(s����) + 1).ToString().Trim();

                        if (s����.Length == 1)
                        {
                            txt����.Text = lookUpEdit����������1.Text.Trim() + "00" + s����;
                        }
                        else if (s����.Length == 2)
                        {
                            txt����.Text = lookUpEdit����������1.Text.Trim() + "0" + s����;
                        }
                        else if (s����.Length == 3)
                        {
                            txt����.Text = lookUpEdit����������1.Text.Trim() + s����;
                        }
                        else
                        {
                            throw new Exception("������ˮ������λ");
                        }
                    }
                }

                sSQL = @"
select e.cBatchProperty6
from mom_order a inner join mom_orderdetail b on a.moid = b.moid inner join Inventory c on b.InvCode = c.cInvCode
    inner join  mom_moallocate d on d.MoDId  = b.Modid 
	inner join rdrecords11 e on e.iMPoIds = d.AllocateId
where isnull(e.cBatchProperty6,'') <>'' and 1=1
";
                sSQL = sSQL.Replace("1=1", "1=1 and a.MoCode = '" + lookUpEdit����������1.Text.Trim() + "' and b.SortSeq = '" + txt�к�.Text.Trim() + "' ");
                DataTable dt¯�� = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];

                if (dt¯�� != null && dt¯��.Rows.Count > 0)
                    txt¯��.Text = dt¯��.Rows[0]["cBatchProperty6"].ToString().Trim();

                sState = "sel";

                btn�ذ�.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private int ReturnObjectToInt(object o)
        {
            int d = 0;
            try
            {
                d = Convert.ToInt32(o);
            }
            catch
            { }
            return d;
        }

        private decimal ReturnObjectToDecimal(object o, int i)
        {
            decimal d = 0;
            try
            {
                d = Convert.ToDecimal(o);
                d = decimal.Round(d, i);
            }
            catch
            { }
            return d;
        }

        private double ReturnObjectToDouble(object o)
        {
            double d = 0;
            try
            {
                d = Convert.ToDouble(o);
            }
            catch
            { }
            return d;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
         
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

        }



        private string ReturnBarCode(string sBarCode)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (sBarCode.Trim().Length < 10)
                    sBarCode = "0" + sBarCode;
                else
                    break;
            }
            return sBarCode;
        }


        #region ���ô�ӡģ��

        private void btnPrintSET_Click(object sender, EventArgs e)
        {
            bool bMod = false;
            if (sUserID == "admin" || sUserID == "system" || sUserID == "demo")
            {
                bMod = true;
            }

            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print");
            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print\\Model"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print\\Model");
            if (!Directory.Exists(sProPath + "\\UAP\\Runtime\\print\\User"))
                Directory.CreateDirectory(sProPath + "\\UAP\\Runtime\\print\\User");

            if (bMod)
            {
                if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }
            else
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
            }

            Rep.ShowDesignerDialog();

            DialogResult d = MessageBox.Show("�Ƿ񱣴�?ģ����������´δ򿪴���ʱ����\n�ǣ������ӡģ��\n�񣺻ָ�Ĭ�ϴ�ӡģ��\n", "��ʾ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == d)
            {
                if (bMod)
                {
                    Rep.SaveLayoutToXml(sPrintLayOutMod);
                }
                else
                {
                    Rep.SaveLayoutToXml(sPrintLayOutUser);
                }
            }
            else if (DialogResult.No == d)
            {
                if (File.Exists(sPrintLayOutUser))
                {
                    File.Delete(sPrintLayOutUser);
                }
            }
        }

        
        protected string sProPath = Application.StartupPath;    //����ִ��λ��
        string sPrintLayOutMod;
        string sPrintLayOutUser;
        RepBaseGrid Rep = new RepBaseGrid();
        DataSet dsPrint = new DataSet();          //��ӡģ������Դ



        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt�к�.Text.Trim() == "")
                {
                    MessageBox.Show("���������к�");
                    txt�к�.Focus();
                    return;
                }


                if (txt�������.Text.Trim() == "")
                {
                    MessageBox.Show("������������������Ϣ");
                    lookUpEdit����������1.Focus();
                    return;
                }

                decimal d���� = ReturnObjectToDecimal(txt����.Text.Trim(), 6);
                if (d���� <= 0)
                {
                    MessageBox.Show("��ò�Ʒ����ʧ��");
                    txt����.Focus();
                    return;
                }


                decimal dë�� = ReturnObjectToDecimal(txtë��.Text.Trim(), 6);
                if (dë�� <= 0)
                {
                    MessageBox.Show("�������ݲ���ȷ�����ʵ");
                    txtë��.Focus();
                    return;
                }

                string sSQL2 = "select getdate()";
                DateTime d��ǰ���� = Convert.ToDateTime(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL2));
                string s���뵥�ݺ� = d��ǰ����.ToString("yyyyMMddHHmmss");

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = "select a.*,b.cInvName,b.cInvStd,isnull(b.bInvBatch ,0) as bInvBatch ,isnull(b.bFree1 ,0) as bFree1  from ��������Ϣ a inner join inventory b on a.������� = b.cInvCode where guid = '" + txtGuid.Text.Trim() + "'";
                    DataTable dt = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DialogResult d = MessageBox.Show("�������Ѿ���ӡ\n  Y��������ӡ \n  N������ ", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (d == DialogResult.No)
                            return;
                    }

                    sSQL = "select * from inventory where cInvcode = '" + txt�������.Text.Trim() + "'";
                    DataTable dtinv = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dtinv == null || dtinv.Rows.Count < 1)
                    {
                        throw new Exception("�����Ϣ������");
                    }
                    int iBatch = ReturnObjectToInt(dtinv.Rows[0]["bInvBatch"]);
                    if (iBatch == 1 && txt����.Text.Trim() == "")
                    {
                        throw new Exception(txt�������.Text.Trim() + "�����ι�������������");
                    }

                    int iFree1 = ReturnObjectToInt(dtinv.Rows[0]["bFree1"]);
                    if (iFree1 == 1 && txt����.Text.Trim() == "")
                    {
                        throw new Exception(txt�������.Text.Trim() + "�������볤��");
                    }

                    if (dt.Rows.Count == 0)
                    {
                        sSQL = "INSERT INTO [��������Ϣ]([�������] ,[����],[����] ,[¯��] ,[����] ,[ë��]" +
                                          ",[������]  ,[��������],[��ӡ����],[����������],[�к�] " +
                                          " ,[���һ�δ�ӡ��]  ,[���һ�δ�ӡ����],���뵥�ݺ�,guid) " +
                                      " VALUES ('" + txt�������.Text.Trim() + "','" + txt����.Text.Trim() + "','" + txt����.Text.Trim() + "','" + txt¯��.Text.Trim() + "'," + txt����.Text.Trim() + "," + txtë��.Text.Trim() + "  " +
                                            ",'" + sUserID + "',getdate(),1,'" + lookUpEdit����������1.Text.Trim() + "','" + txt�к�.Text.Trim() + "' " +
                                            ",'" + sUserID + "',getdate(),'" + s���뵥�ݺ� + "','" + txtGuid.Text.Trim() + "')";
                        SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    sSQL = "select * from ��������Ϣ where guid = '" + txtGuid.Text.Trim() + "'";
                    DataTable dtTemp = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    txt������.Text = dtTemp.Rows[0]["������"].ToString().Trim();

                    Rep = new RepBaseGrid();
                    if (File.Exists(sPrintLayOutUser))
                    {
                        Rep.LoadLayout(sPrintLayOutUser);
                    }
                    else if (File.Exists(sPrintLayOutMod))
                    {
                        Rep.LoadLayout(sPrintLayOutMod);
                    }
                    else
                    {
                        MessageBox.Show("���ر���ģ��ʧ�ܣ��������Ա��ϵ");
                        return;
                    }
                    Rep.dsPrint.Tables["dtHead"].Rows.Clear();
                    Rep.dsPrint.Tables["dtHead"].Columns.Clear();
                    //���ñ����ͷ���ݱ���
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        DataColumn dcRep = new DataColumn();
                        dcRep.ColumnName = dt.Columns[i].ColumnName;
                        Rep.dsPrint.Tables["dtHead"].Columns.Add(dcRep);
                    }

                    DataRow dr = Rep.dsPrint.Tables["dtHead"].NewRow();
                    dr["������"] = ReturnBarCode(txt������.Text.Trim()); 
                    dr["�������"] = txt�������.Text.Trim();
                    dr["cInvName"] = txt�������.Text.Trim();
                    dr["cInvStd"] = txt����ͺ�.Text.Trim();
                    dr["����"] = txt����.Text.Trim();
                    dr["����"] = txt����.Text.Trim();
                    dr["¯��"] = txt¯��.Text.Trim();
                    dr["����"] = txt����.Text.Trim();
                    dr["ë��"] = txtë��.Text.Trim();
                    dr["����������"] = lookUpEdit����������1.Text.Trim() + " / " + txt�к�.Text.Trim();

                    Rep.dsPrint.Tables["dtHead"].Rows.Add(dr);

                    Rep.ShowPreview();
                    //Rep.Print();

                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

                string sSQL3 = "select * from ��������Ϣ where guid = '" + txtGuid.Text.Trim() + "'";
                DataTable dt2 = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL3).Tables[0];
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    txt������.Text = dt2.Rows[0]["������"].ToString().Trim();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            /*
             *     Rep = new RepBaseGrid();
                if (File.Exists(sPrintLayOutUser))
                {
                    Rep.LoadLayout(sPrintLayOutUser);
                }
                else if (File.Exists(sPrintLayOutMod))
                {
                    Rep.LoadLayout(sPrintLayOutMod);
                }
                else
                {
                    MessageBox.Show("���ر���ģ��ʧ�ܣ��������Ա��ϵ");
                    return;
                }
                Rep.dsPrint.Tables["dtHead"].Rows.Clear();
                Rep.dsPrint.Tables["dtHead"].Columns.Clear();
                //���ñ����ͷ���ݱ���
                //try
                //{
                //    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Columns.Count; i++)
                //    {
                //        DataColumn dc = new DataColumn();
                //        dc = this.dsPrint.Tables["dtHead"].Columns[i];
                //        DataColumn dcRep = new DataColumn();
                //        dcRep.ColumnName = dc.ColumnName;
                //        Rep.dsPrint.Tables["dtHead"].Columns.Add(dcRep);
                //    }
                //}
                //catch { }

                //if (this.dsPrint.Tables["dtHead"] != null)
                //{
                //    for (int i = 0; i < this.dsPrint.Tables["dtHead"].Rows.Count; i++)
                //    {
                //        DataRow dr = Rep.dsPrint.Tables["dtHead"].NewRow();
                //        for (int j = 0; j < Rep.dsPrint.Tables["dtHead"].Columns.Count; j++)
                //        {
                //            dr[j] = this.dsPrint.Tables["dtHead"].Rows[i][j];
                //        }
                //        Rep.dsPrint.Tables["dtHead"].Rows.Add(dr);
                //    }
                //}

                //���ñ���������ݱ���

                Rep.dsPrint.Tables["dtGrid"].Clear();
                Rep.dsPrint.Tables["dtGrid"].Columns.Clear();
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    DataColumn dcGrid = new DataColumn();
                    dcGrid.ColumnName = gridView1.Columns[i].Caption;
                    Rep.dsPrint.Tables["dtGrid"].Columns.Add(dcGrid);
                }
                if (grdDetail.DataSource != null)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                        {
                            DataRow dr = Rep.dsPrint.Tables["dtGrid"].NewRow();
                            for (int j = 0; j < Rep.dsPrint.Tables["dtGrid"].Columns.Count; j++)
                            {
                                if (gridView1.Columns[j].Caption == "������")
                                {
                                    dr[j] = ReturnBarCode(gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]));
                                }
                                else
                                {
                                    dr[j] = gridView1.GetRowCellDisplayText(i, gridView1.Columns[j]);
                                }
                            }
                            Rep.dsPrint.Tables["dtGrid"].Rows.Add(dr);
                        }
                    }
                }

                Rep.DataMember = "dtGrid";
                Rep.ShowPreview();


                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                //��������
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColѡ��)))
                        {
                            string sSQL = "update ��������Ϣ set ��ӡ���� = isnull(��ӡ����,0) + 1,���һ�δ�ӡ�� = '" + sUserID + "',���һ�δ�ӡ���� = getdate() where ������ = " + gridView1.GetRowCellValue(i, gridCol������).ToString().Trim();
                            SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

             */
        }



        #endregion


        private void SetNull()
        {
            txt�������.Text = "";
            txt�������.Text = "";
            txt����ͺ�.Text = "";
            txt����.Text = "";
            txt¯��.Text = "";
            txt����.Text = "";
            txt����.Text = "";
            txtë��.Text = "";
            txt������.Text = "";
            txtGuid.Text = "";
        }



        #region �ذ�
        //���� SerialPort����
        SerialPort port1;

        //��ʼ��SerialPort���󷽷�.PortNameΪCOM������,����"COM1","COM2"��,ע����string����
        public void InitCOM(string PortName)
        {
            port1 = new SerialPort(PortName);
            port1.BaudRate = 9600;//������
            port1.Parity = Parity.None;//����żУ��λ
            port1.StopBits = StopBits.One;//����ֹͣλ
            port1.Handshake = Handshake.RequestToSend;//����Э��
            port1.ReceivedBytesThreshold = 8;//���� DataReceived �¼�����ǰ�ڲ����뻺�����е��ֽ���
            port1.Encoding = Encoding.ASCII;
            port1.DataReceived += new SerialDataReceivedEventHandler(port1_DataReceived);//DataReceived�¼�ί��
        }
        //DataReceived�¼�ί�з���
        private void port1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //ѭ����������
                string s = "";
                while (port1.BytesToRead > 0 && s.Length<100)
                {
                    //MessageBox.Show(s);
                    char ch = (char)port1.ReadByte();
                    s = s + ch.ToString();
                }

                //MessageBox.Show("AA" + s);
                //MessageBox.Show(s.IndexOf("-+").ToString());
                //txtë��.Text = s.Substring(s.IndexOf(",+") + 1, 6);

                string s���� = s.Substring(s.IndexOf(",+") + 1, 6);
                txt����.Text = Math.Ceiling(ReturnObjectToDecimal(s����, 2)).ToString();

                ClosePort();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }

        //�򿪴��ڵķ���
        public void OpenPort()
        {
            try
            {
                port1.Open();
            }
            catch { }
            if (port1.IsOpen)
            {
                //label1.Text = port1.ReadExisting();
                //MessageBox.Show("the port is opened!");
            }
            else
            {
                //label1.Text = port1.ReadExisting();
                //MessageBox.Show("failure to open the port!");
            }
        }

        //�رմ��ڵķ���
        public void ClosePort()
        {
            port1.Close();
            if (!port1.IsOpen)
            {
                //Console.WriteLine("the port is already closed!");
            }
        }

        //�򴮿ڷ�������
        public void SendCommand(string CommandString)
        {
            byte[] WriteBuffer = Encoding.ASCII.GetBytes(CommandString);
            port1.Write(WriteBuffer, 0, WriteBuffer.Length);
        }

        private void btn�ذ�_Click(object sender, EventArgs e)
        {
            try
            {
                //�������õ�COM1�˿�,����Ҫ�ɸĳ�COM2,COM3
                InitCOM("COM5");
                OpenPort();

                if (ReturnObjectToDecimal(txt����.Text.Trim(), 2) > 0)
                {
                    btnPrint.Focus();
                }
                else
                {
                    btn�ذ�.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        #endregion


        private void lookUpEdit����������1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit����������1.Text.Trim() == "")
                    return;

                txt�к�.Text = "1";

                string sSQL = @"
select count(1) as ����
from mom_order a inner join mom_orderdetail b on a.moid = b.moid 
where a.mocode = '111111' and b.SortSeq = '222222' 
";
                sSQL = sSQL.Replace("111111", lookUpEdit����������1.Text.Trim());
                sSQL = sSQL.Replace("222222", txt�к�.Text.Trim());
                int iCou = ReturnObjectToInt(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL));
                if (iCou == 0)
                {
                    sSQL = @"
select b.SortSeq as �� 
from mom_order a inner join mom_orderdetail b on a.moid = b.moid 
where a.mocode = '111111' 
";
                    sSQL = sSQL.Replace("111111", lookUpEdit����������1.Text.Trim());
                    DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                    if (dt == null || dt.Rows.Count < 1)
                        throw new Exception("û��ƥ�����������");

                    if (dt.Rows.Count > 1)
                    {
                        throw new Exception("�����������ܳ���һ��");
                    }

                    txt�к�.Text = dt.Rows[0]["��"].ToString().Trim();
                }

                if (iCou > 1)
                {
                    throw new Exception("�����������ܳ���һ��");
                }

                btnSel_Click(null, null);

            }
            catch (Exception ee)
            {
                SetNull();
                MessageBox.Show("��õ����к�ʧ��:" + ee.Message);
            }
        }

        private void txt�к�_Validated(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit����������1.Text.Trim() == "")
                    return;

                if (txt�к�.Text.Trim() == "")
                    return;

                string sSQL = @"
select count(1) as ����
from mom_order a inner join mom_orderdetail b on a.moid = b.moid 
where a.mocode = '111111' and b.SortSeq = '222222' 
";
                sSQL = sSQL.Replace("111111", lookUpEdit����������1.Text.Trim());
                sSQL = sSQL.Replace("222222", txt�к�.Text.Trim());
                int iCou = ReturnObjectToInt(SqlHelper.ExecuteScalar(Conn, CommandType.Text, sSQL));
                if (iCou == 0)
                {
                    SetNull();
                    throw new Exception("�кŲ���ȷ");
                }

                if (iCou > 1)
                {
                    SetNull();
                    throw new Exception("�����������ܳ���һ��");
                }

                btnSel_Click(null, null);

            }
            catch (Exception ee)
            {
                SetNull();
                MessageBox.Show("��õ����к�ʧ��:" + ee.Message);
            }
        }
        private void SetLookup()
        {
            try
            {
                string sSQL = @"
select distinct a.MoCode
from mom_order a inner join mom_orderdetail b on a.moid = b.moid
where b.Status = 3
order by a.MoCode
";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                DataRow dr = dt.NewRow();
                dt.Rows.InsertAt(dr, 0);

                lookUpEdit����������1.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("�������������ʧ��");
            }
        }

        private void lookUpEdit����������1_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (lookUpEdit����������1.Text.Trim() == "")
            //    {
            //        lookUpEdit����������1.Focus();
            //        throw new Exception("��ѡ����������");
            //    }

            //    btnSel_Click(null, null);
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }
    }
}