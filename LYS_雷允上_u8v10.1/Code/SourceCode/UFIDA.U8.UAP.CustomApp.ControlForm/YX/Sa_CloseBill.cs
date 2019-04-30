using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UFIDA.U8.UAP.CustomApp.ControlForm.Business;
using DevExpress.XtraEditors;
using System.Xml;
using System.Collections;
using UFIDA.U8.UAP.CustomApp.ControlForm;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Sa_CloseBill : UserControl
    {
        //public class CmbDataSource
        //    public string WareHouseCode;
        //    public string WareHouseName;
        //}

        //public class UserMsg
        //{
        //    public string UserCode;
        //    public string UserName;
        //}
        string sFilePath = "";

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Sa_CloseBill()
        {
            InitializeComponent();
        }


        private void Sa_CloseBill_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select cSSCode ,cSSName from SettleStyle ";
                DataTable dtSettleStyle = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                ItemLookUpEdit���㷽ʽ.Properties.Columns.Clear();
                ItemLookUpEdit���㷽ʽ.Properties.DataSource = dtSettleStyle;
                ItemLookUpEdit���㷽ʽ.Properties.ValueMember = "cSSCode";
                ItemLookUpEdit���㷽ʽ.Properties.DisplayMember = "cSSName";
                ItemLookUpEdit���㷽ʽ.Properties.NullText = "";
                ItemLookUpEdit���㷽ʽ.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSSCode", "���㷽ʽ����"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cSSName", "���㷽ʽ����")});

                sSQL = "select cCusCode  ,cCusName from Customer  ";
                DataTable dtCustomer = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                ItemLookUpEdit�ͻ�.Properties.Columns.Clear();
                ItemLookUpEdit�ͻ�.Properties.DataSource = dtCustomer;
                ItemLookUpEdit�ͻ�.Properties.ValueMember = "cCusCode";
                ItemLookUpEdit�ͻ�.Properties.DisplayMember = "cCusName";
                ItemLookUpEdit�ͻ�.Properties.NullText = "";
                ItemLookUpEdit�ͻ�.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusCode", "�ͻ�����"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cCusName", "�ͻ�����")});


                DateTime nowday = DateTime.Now;
                dateCreate.DateTime =nowday.AddDays(1 - nowday.Day);
                dateCreate2.DateTime = dateCreate.DateTime.AddMonths(1).AddDays(-1);
                //grdDetail.DataSource = Sa_CloseBillBLL.GetFormsData(GetFilterStr(), Conn);

                gridColChk.OptionsColumn.AllowEdit = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //gridView1.OptionsBehavior.Editable = false;

            if (dateCreate.Text.Trim() == "")
            {
                MessageBox.Show("Ʊ�����ڲ���Ϊ��");
                dateCreate.Focus();
                return;
            }
            if (dateCreate2.Text.Trim() == "")
            {
                MessageBox.Show("Ʊ�����ڲ���Ϊ��");
                dateCreate2.Focus();
                return;
            }
            if (dateCreate2.DateTime < dateCreate.DateTime)
            {
                MessageBox.Show("Ʊ�����ڱ����С����");
                dateCreate.Focus();
                return;
            }

            DataTable dt = Sa_CloseBillBLL.GetFormsData(GetFilterStr(), Conn);
            grdDetail.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("û���κ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            gridColChk.OptionsColumn.AllowEdit = true;
        }

        private string GetFilterStr()
        {
            List<string> filter = new List<string>();
            if (txtƱ�ݺ�.Text.Trim() != "")
                filter.Add(" and isnull(cVouchID,'') " + cmbƱ�ݺ�.Text + " '" + (cmbƱ�ݺ�.Text == "like" ? "%" : "") + txtƱ�ݺ�.Text + (cmbƱ�ݺ�.Text == "like" ? "%" : "") + "'");
            
            filter.Add(" and dVouchDate>='" + dateCreate.DateTime.ToString("yyyy-MM-dd") + "' and dVouchDate<='" + dateCreate2.DateTime.ToString("yyyy-MM-dd") + "' ");

            return string.Join("\r\n", filter.ToArray());
        }

        private void grvDetail_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {

            if (e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.PostEditor();
                this.Validate();

                string sErr = "";
                string outstr = "";
                bool b = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChk)) == true && outstr.IndexOf("," + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim() + ",") == -1)
                    {
                        if (outstr != "")
                        {
                            outstr = outstr + ",";
                        }
                        outstr = outstr + gridView1.GetRowCellValue(i, gridColiID).ToString().Trim();
                        b = true;

                    }
                }
                if (b == true)
                {
                    if (outstr != "")
                    {

                        DataTable dt = Sa_CloseBillBLL.GetFormsData(" and iID in(" + outstr + ")", Conn);
                        DataTable dts = Sa_CloseBillBLL.GetFormsData1(" and iID in (" + outstr + ")", Conn);
                        //sFilePath = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select Path from ������Ϣӳ���·�� ").Tables[0].Rows[0][0].ToString();
                        //if (System.IO.File.Exists(sFilePath) == false)//�������
                        //{
                        //MessageBox.Show("��ѡ�������Ϣӳ���·��");
                        OpenFileDialog saveFileDialog1 = new OpenFileDialog();
                        saveFileDialog1.Title = "��ѡ�������Ϣӳ���·��";
                        saveFileDialog1.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();
                        saveFileDialog1.Filter = "excel Files(*.xls)|*.xls|All Files(*.*)|*.*";
                        saveFileDialog1.FileName = "";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            sFilePath = saveFileDialog1.FileName;
                        }
                        else
                        {
                            MessageBox.Show("δѡ�������Ϣӳ������˳�����");
                            return;
                        }
                        //}
                        //if (System.IO.File.Exists(sFilePath) == false)
                        //{
                        //    throw new Exception("������Ϣӳ���·��ѡ��ʧ��");
                        //}
                        DataTable dt�Ƶ���ӳ���;
                        DataTable dt���㷽ʽӳ���;
                        DataTable dt�ͻ�ӳ���;
                        DataTable dt����;
                        DataTable dt���ŵ���ӳ���;
                        DataTable dt����Ĭ��ֵ��;
                        DataTable dt��Ա����ӳ���;

                        
                        try
                        {
                            dt�Ƶ���ӳ��� = NOPI.FromExcel(sFilePath, "�Ƶ���ӳ���", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("�Ƶ���ӳ���ȡֵʧ��:" + ee.Message);
                        }
                        try
                        {
                            dt���㷽ʽӳ��� = NOPI.FromExcel(sFilePath, "���㷽ʽӳ���", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("���㷽ʽӳ���ȡֵʧ��:" + ee.Message);
                        }
                        try
                        {
                            dt�ͻ�ӳ��� = NOPI.FromExcel(sFilePath, "�ͻ�ӳ���", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("�ͻ�ӳ���ȡֵʧ��:" + ee.Message);
                        }
                        try
                        {
                            dt���� = NOPI.FromExcel(sFilePath, "����", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("����ӳ���ȡֵʧ��:" + ee.Message);
                        }
                        try
                        {
                            dt���ŵ���ӳ��� = NOPI.FromExcel(sFilePath, "���ŵ���ӳ���", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("���ŵ���ӳ���ȡֵʧ��:" + ee.Message);
                        }
                        try
                        {
                            dt��Ա����ӳ��� = NOPI.FromExcel(sFilePath, "��Ա����ӳ���", 1, 0, 3);
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("��Ա����ӳ���ȡֵʧ��:" + ee.Message);
                        }

                        try
                        {
                            dt����Ĭ��ֵ�� = SqlHelper.ExecuteDataset(Conn, CommandType.Text, "select * from ����Ĭ��ֵ��").Tables[0];
                        }
                        catch (Exception ee)
                        {
                            throw new Exception("����Ĭ��ֵ��ȡֵʧ��:" + ee.Message);
                        }
                        XmlDocument doc = new XmlDocument();
                        XmlDeclaration xmldecl = doc.CreateXmlDeclaration("1.0", "GB2312", null);
                        doc.AppendChild(xmldecl);

                        XmlElement Node = doc.CreateElement("ufinterface");
                        Node.SetAttribute("roottag", "voucher");
                        Node.SetAttribute("billtype", "D4");
                        Node.SetAttribute("subtype", "run");
                        Node.SetAttribute("replace", "Y");
                        Node.SetAttribute("receiver", "220300000000");
                        Node.SetAttribute("sender", "szlys01");
                        Node.SetAttribute("proc", "add");
                        Node.SetAttribute("isexchange", "Y");
                        Node.SetAttribute("filename", "�տ���㵥ģ��demo.xml");
                        doc.AppendChild(Node);


                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            XmlElement Node1 = doc.CreateElement("voucher");
                            string s = "";
                            if (j < 10)
                            {
                                s = "000" + j;
                            }
                            else if (j < 100)
                            {
                                s = "00" + j;
                            }
                            else if (j < 1000)
                            {
                                s = "0" + j;
                            }
                            Node1.SetAttribute("id", dt.Rows[j]["iID"].ToString().Trim() + DateTime.Now.ToString("yyyyMMdd") + s);
                            Node.AppendChild(Node1);

                            #region Head
                            XmlElement NodeHead = doc.CreateElement("voucher_head");
                            Node1.AppendChild(NodeHead);

                            //�Ƿ�Ԥ��Ԥ����־ �ǿ��ֶ�
                            XmlElement N1 = doc.CreateElement("prepay");
                            N1.InnerText = "n";
                            NodeHead.AppendChild(N1);

                            //��λ����  �ǿ��ֶ�
                            XmlElement N2 = doc.CreateElement("corp");
                            N2.InnerText = "220300000000";
                            NodeHead.AppendChild(N2);

                            //ҵ������ �ǿ��ֶΣ�D4���տ���㵥,D5�Ǹ�����㵥,D6�ǻ��˽��㵥,sysid��Ӧ��Ϊ2����������Ҫ��Ҫ�������ݶ���(��������)
                            XmlElement N3 = doc.CreateElement("billTypeCode");
                            N3.InnerText = "D4";
                            NodeHead.AppendChild(N3);

                            XmlElement N4 = doc.CreateElement("businessType");
                            N4.InnerText = "D4";
                            NodeHead.AppendChild(N4);

                            //�������� �ǿ��ֶ�
                            XmlElement N5 = doc.CreateElement("billDate");
                            if (dt.Rows[j]["dVouchDate"].ToString().Trim() != "")
                            {
                                N5.InnerText = Convert.ToDateTime(dt.Rows[j]["dVouchDate"]).ToString("yyyy-MM-dd").Trim();
                            }
                            NodeHead.AppendChild(N5);

                            //ϵͳ��� 0Ӧ�� 1Ӧ�� 2�ֽ�ƽ̨  �ǿ��ֶ�
                            XmlElement N6 = doc.CreateElement("sysid");
                            N6.InnerText = "2";
                            NodeHead.AppendChild(N6);

                            //�Ƿ��ڳ����� �ǿ��ֶ�
                            XmlElement N7 = doc.CreateElement("initFlag");
                            N7.InnerText = "n";
                            NodeHead.AppendChild(N7);

                            //¼���� �ǿ��ֶ�
                            XmlElement N8 = doc.CreateElement("inputOp");
                            DataRow[] dw8 = dt�Ƶ���ӳ���.Select("trim(����)='" + sUserID.Trim() + "'");
                            if (dw8.Length > 0)
                            {
                                N8.InnerText = dw8[0]["����1"].ToString().Trim();
                                if (N8.InnerText == "")
                                {
                                    sErr = sErr + "��" + (j + 1) + "��" + "¼����" + sUserID.Trim() + "���ҵ�ӳ�����ӳ����ӦֵΪ��" + "\n";
                                }
                            }
                            else
                            {
                                N8.InnerText = "";
                                sErr = sErr + "��" + (j + 1) + "��" + "��¼��" + sUserID + "δ�ҵ�ӳ���" + "\n";
                            }
                            NodeHead.AppendChild(N8);

                            //�ɹ����ͱ���
                            XmlElement N9 = doc.CreateElement("saleType");
                            N9.InnerText = "";
                            NodeHead.AppendChild(N9);

                            #region freeitem
                            XmlElement NF1 = doc.CreateElement("freeitem1");
                            NF1.InnerText = "";
                            NodeHead.AppendChild(NF1);

                            XmlElement NF2 = doc.CreateElement("freeitem2");
                            NF2.InnerText = "";
                            NodeHead.AppendChild(NF2);

                            XmlElement NF3 = doc.CreateElement("freeitem3");
                            NF3.InnerText = "";
                            NodeHead.AppendChild(NF3);

                            XmlElement NF4 = doc.CreateElement("freeitem4");
                            NF4.InnerText = "";
                            NodeHead.AppendChild(NF4);

                            XmlElement NF5 = doc.CreateElement("freeitem5");
                            NF5.InnerText = "";
                            NodeHead.AppendChild(NF5);

                            XmlElement NF6 = doc.CreateElement("freeitem6");
                            NF6.InnerText = "";
                            NodeHead.AppendChild(NF6);

                            XmlElement NF7 = doc.CreateElement("freeitem7");
                            NF7.InnerText = "";
                            NodeHead.AppendChild(NF7);

                            XmlElement NF8 = doc.CreateElement("freeitem8");
                            NF8.InnerText = "";
                            NodeHead.AppendChild(NF8);

                            XmlElement NF9 = doc.CreateElement("freeitem9");
                            NF9.InnerText = "";
                            NodeHead.AppendChild(NF9);

                            XmlElement NF10 = doc.CreateElement("freeitem10");
                            NF10.InnerText = "";
                            NodeHead.AppendChild(NF10);

                            XmlElement NF11 = doc.CreateElement("freeitem11");
                            NF11.InnerText = "";
                            NodeHead.AppendChild(NF11);

                            XmlElement NF12 = doc.CreateElement("freeitem12");
                            NF12.InnerText = "";
                            NodeHead.AppendChild(NF12);

                            XmlElement NF13 = doc.CreateElement("freeitem13");
                            NF13.InnerText = "";
                            NodeHead.AppendChild(NF13);

                            XmlElement NF14 = doc.CreateElement("freeitem14");
                            NF14.InnerText = "";
                            NodeHead.AppendChild(NF14);

                            XmlElement NF15 = doc.CreateElement("freeitem15");
                            NF15.InnerText = "";
                            NodeHead.AppendChild(NF15);

                            XmlElement NF16 = doc.CreateElement("freeitem16");
                            NF16.InnerText = "";
                            NodeHead.AppendChild(NF16);

                            XmlElement NF17 = doc.CreateElement("freeitem17");
                            NF17.InnerText = "";
                            NodeHead.AppendChild(NF17);

                            XmlElement NF18 = doc.CreateElement("freeitem18");
                            NF18.InnerText = "";
                            NodeHead.AppendChild(NF18);

                            XmlElement NF19 = doc.CreateElement("freeitem19");
                            NF19.InnerText = "";
                            NodeHead.AppendChild(NF19);

                            XmlElement NF20 = doc.CreateElement("freeitem20");
                            NF20.InnerText = "";
                            NodeHead.AppendChild(NF20);
                            #endregion

                            //�ո�����
                            XmlElement N10 = doc.CreateElement("teller");
                            N10.InnerText = "";
                            NodeHead.AppendChild(N10);

                            //��Ŀ����
                            XmlElement N11 = doc.CreateElement("subject");
                            DataRow[] dw11 = dt����Ĭ��ֵ��.Select("iType=2");
                            if (dw11.Length > 0)
                            {
                                N11.InnerText = dw11[0]["s1"].ToString().Trim();
                            }
                            else
                            {
                                sErr = sErr + "��" + (j + 1) + "��" + "��ͷ��Ŀ����Ĭ��ֵδ����" + "\n";
                            }
                            NodeHead.AppendChild(N11);

                            //Ʊ�ݺ�
                            XmlElement N12 = doc.CreateElement("note_num");
                            N12.InnerText = "";
                            NodeHead.AppendChild(N12);

                            //Ʊ�ݽ��㷽ʽ
                            XmlElement N13 = doc.CreateElement("settleType");
                            DataRow[] dw13 = dt���㷽ʽӳ���.Select("trim(����)='" + dt.Rows[j]["cSSCode"].ToString().Trim() + "'");
                            if (dw13.Length > 0)
                            {
                                N13.InnerText = dw13[0]["����1"].ToString().Trim();
                                if (N13.InnerText == "")
                                {
                                    sErr = sErr + "��" + (j + 1) + "��" + "���㷽ʽ" + dt.Rows[j]["cSSCode"].ToString().Trim() + "���ҵ�ӳ�����ӳ����ӦֵΪ��" + "\n";
                                }
                            }
                            else
                            {
                                sErr = sErr + "��" + (j + 1) + "��" + "���㷽ʽ" + dt.Rows[j]["cSSCode"].ToString().Trim() + "δ�ҵ�ӳ���" + "\n";
                                N13.InnerText = "";
                            }
                            NodeHead.AppendChild(N13);

                            //ȷ����
                            XmlElement N14 = doc.CreateElement("affirmant");
                            N14.InnerText = "";
                            NodeHead.AppendChild(N14);

                            //����ȷ����  �������ĵ���״̬��ǩ��̬ �������¼������ȷ���ˣ�ҵ������Ϊǩ���ˣ�
                            XmlElement N15 = doc.CreateElement("bank_affirmant");
                            N15.InnerText = "";
                            NodeHead.AppendChild(N15);

                            //��ע
                            XmlElement N16 = doc.CreateElement("scomment");
                            N16.InnerText = "Ӧ���˿�";
                            NodeHead.AppendChild(N16);

                            //����������Ϊ�գ�Ĭ��Ϊ0
                            XmlElement N17 = doc.CreateElement("appendix");
                            N17.InnerText = "0";
                            NodeHead.AppendChild(N17);

                            //ԭ�ҽ�� �ǿ��ֶ�,����Ϊ0
                            XmlElement N18 = doc.CreateElement("original_sum");
                            N18.InnerText = dt.Rows[j]["iAmount_f"].ToString().Trim();
                            NodeHead.AppendChild(N18);

                            //���ҽ�� �ǿ��ֶΣ�Ĭ��Ϊ0
                            XmlElement N19 = doc.CreateElement("fractional_sum");
                            N19.InnerText = "0";
                            NodeHead.AppendChild(N19);

                            //���ҽ�� �ǿ��ֶΣ�Ӧ����ԭ�ҽ��original_sum��ͬ
                            XmlElement N20 = doc.CreateElement("local_sum");
                            N20.InnerText = dt.Rows[j]["iAmount_f"].ToString().Trim();
                            NodeHead.AppendChild(N20);

                            //V5 ����

                            //����״̬ 1���� 2��� 3ǩ��ȷ��
                            XmlElement N21 = doc.CreateElement("billstatus");
                            N21.InnerText = "1";
                            NodeHead.AppendChild(N21);

                            //�ڿ���������
                            XmlElement N22 = doc.CreateElement("inner_effect_date");
                            N22.InnerText = "";
                            NodeHead.AppendChild(N22);

                            //���̿�������
                            XmlElement N23 = doc.CreateElement("kskhyh");
                            N23.InnerText = "";
                            NodeHead.AppendChild(N23);

                            //��������������
                            XmlElement N24 = doc.CreateElement("sscause");
                            N24.InnerText = "";
                            NodeHead.AppendChild(N24);

                            //����������
                            XmlElement N25 = doc.CreateElement("lastshr");
                            N25.InnerText = "";
                            NodeHead.AppendChild(N25);

                            //����״̬
                            XmlElement N26 = doc.CreateElement("spzt");
                            N26.InnerText = "";
                            NodeHead.AppendChild(N26);

                            //֧����
                            XmlElement N27 = doc.CreateElement("payman");
                            N27.InnerText = "";
                            NodeHead.AppendChild(N27);

                            //֧������
                            XmlElement N28 = doc.CreateElement("paydate");
                            N28.InnerText = "";
                            NodeHead.AppendChild(N28);

                            //�ݹ�Ӧ����־
                            XmlElement N29 = doc.CreateElement("zgyf");
                            N29.InnerText = "";
                            NodeHead.AppendChild(N29);

                            #region freeitem
                            XmlElement NF21 = doc.CreateElement("freeitem21");
                            NF21.InnerText = "";
                            NodeHead.AppendChild(NF21);

                            XmlElement NF22 = doc.CreateElement("freeitem22");
                            NF22.InnerText = "";
                            NodeHead.AppendChild(NF22);

                            XmlElement NF23 = doc.CreateElement("freeitem23");
                            NF23.InnerText = "";
                            NodeHead.AppendChild(NF23);

                            XmlElement NF24 = doc.CreateElement("freeitem24");
                            NF24.InnerText = "";
                            NodeHead.AppendChild(NF24);

                            XmlElement NF25 = doc.CreateElement("freeitem25");
                            NF25.InnerText = "";
                            NodeHead.AppendChild(NF25);

                            XmlElement NF26 = doc.CreateElement("freeitem26");
                            NF26.InnerText = "";
                            NodeHead.AppendChild(NF26);

                            XmlElement NF27 = doc.CreateElement("freeitem27");
                            NF27.InnerText = "";
                            NodeHead.AppendChild(NF27);

                            XmlElement NF28 = doc.CreateElement("freeitem28");
                            NF28.InnerText = "";
                            NodeHead.AppendChild(NF28);

                            XmlElement NF29 = doc.CreateElement("freeitem29");
                            NF29.InnerText = "";
                            NodeHead.AppendChild(NF29);

                            XmlElement NF30 = doc.CreateElement("freeitem30");
                            NF30.InnerText = "";
                            NodeHead.AppendChild(NF30);
                            #endregion

                            #endregion

                            #region Body
                            XmlElement NodeBody = doc.CreateElement("voucher_body");
                            DataRow[] dwbody = dts.Select("iID='" + dt.Rows[j]["iID"].ToString() + "'");

                            for (int i = 0; i < dwbody.Length; i++)
                            {
                                XmlElement Nodes = doc.CreateElement("entry");
                                NodeBody.AppendChild(Nodes);

                                //���� �ǿ��ֶ�
                                XmlElement NS1 = doc.CreateElement("sum_direction");
                                NS1.InnerText = "1";
                                Nodes.AppendChild(NS1);

                                //ժҪ
                                XmlElement NS2 = doc.CreateElement("digest");
                                NS2.InnerText = N16.InnerText;
                                Nodes.AppendChild(NS2);

                                //��Ŀ���룬��Ҫ����
                                XmlElement NS3 = doc.CreateElement("subject");
                                DataRow[] dws3 = dt����Ĭ��ֵ��.Select("iType=3");
                                if (dws3.Length > 0)
                                {
                                    NS3.InnerText = dws3[0]["s1"].ToString();
                                }
                                else
                                {
                                    sErr = sErr + "��" + (j + 1) + "��" + "�����Ŀ����Ĭ��ֵδ����" + "\n";
                                }
                                Nodes.AppendChild(NS3);

                                //����������������㵥����Ϊ��
                                XmlElement NS4 = doc.CreateElement("customer");
                                DataRow[] dws4 = dt�ͻ�ӳ���.Select("trim(����)='" + dwbody[i]["cCusVen"].ToString().Trim() + "'");
                                if (dws4.Length > 0)
                                {
                                    NS4.InnerText = dws4[0]["����1"].ToString().Trim();
                                    if(NS4.InnerText=="")
                                    {
                                        sErr = sErr + "��" + (j + 1) + "��" + "�ͻ�" + dwbody[i]["cCusVen"].ToString().Trim() + "���ҵ�ӳ�����ӳ����ӦֵΪ��" + "\n";
                                    }
                                }
                                else
                                {
                                    sErr = sErr + "��" + (j + 1) + "��" + "�ͻ�" + dwbody[i]["cCusVen"].ToString().Trim() + "δ�ҵ�ӳ���" + "\n";
                                    NS4.InnerText = "";
                                }
                                Nodes.AppendChild(NS4);

                                //���ֱ��� �ǿ��ֶΣ���Ҫ����
                                XmlElement NS5 = doc.CreateElement("currencyId");
                                DataRow[] dws5 = dt����.Select("trim(����)='" + dt.Rows[j]["cexch_name"].ToString().Trim() + "'");
                                if (dws5.Length > 0)
                                {
                                    NS5.InnerText = dws5[0]["����1"].ToString().Trim();
                                    if (NS5.InnerText == "")
                                    {
                                        sErr = sErr + "��" + (j + 1) + "��" + "���ֱ���" + dt.Rows[j]["cexch_name"].ToString().Trim() + "���ҵ�ӳ�����ӳ����ӦֵΪ��" + "\n";
                                    }
                                }
                                else
                                {
                                    sErr = sErr + "��" + (j + 1) + "��" + "����" + dt.Rows[j]["cexch_name"].ToString().Trim() + "δ�ҵ�ӳ���" + "\n";
                                    NS5.InnerText = "";
                                }
                                Nodes.AppendChild(NS5);

                                //���һ��� �ǿ��ֶ�
                                XmlElement NS6 = doc.CreateElement("original_exchange_rate");
                                NS6.InnerText = "1";
                                Nodes.AppendChild(NS6);

                                //���һ��� �ǿ��ֶ�
                                XmlElement NS7 = doc.CreateElement("fractional_exchange_rate");
                                NS7.InnerText = "0.0";
                                Nodes.AppendChild(NS7);

                                //��Ŀ����
                                XmlElement NS8 = doc.CreateElement("job");
                                NS8.InnerText = "";
                                Nodes.AppendChild(NS8);

                                //�跽ԭ�ҽ�� �ǿ��ֶ�
                                XmlElement NS9 = doc.CreateElement("debit_original_sum");
                                NS9.InnerText = "0";
                                Nodes.AppendChild(NS9);

                                //�跽���ҽ�� �ǿ��ֶΣ�Ĭ��Ϊ0
                                XmlElement NS10 = doc.CreateElement("debit_fractional_sum");
                                NS10.InnerText = "0";
                                Nodes.AppendChild(NS10);

                                //�跽���ҽ�� �ǿ��ֶ�
                                XmlElement NS11 = doc.CreateElement("debit_local_sum");
                                NS11.InnerText = "0";
                                Nodes.AppendChild(NS11);

                                //ԭ����� �ǿ��ֶ�
                                XmlElement NS12 = doc.CreateElement("original_balance");
                                NS12.InnerText = dt.Rows[j]["iAmount_f"].ToString().Trim();
                                Nodes.AppendChild(NS12);

                                //������� �ǿ��ֶΣ�Ĭ��Ϊ0
                                XmlElement NS13 = doc.CreateElement("fractional_balance");
                                NS13.InnerText = "0";
                                Nodes.AppendChild(NS13);

                                //������� �ǿ��ֶ�
                                XmlElement NS14 = doc.CreateElement("local_balance");
                                NS14.InnerText = dt.Rows[j]["iAmount"].ToString().Trim();
                                Nodes.AppendChild(NS14);

                                //������� �ǿ��ֶ�
                                XmlElement NS15 = doc.CreateElement("quantity_balance");
                                NS15.InnerText = dwbody[i]["iRAmt_s"].ToString().Trim();
                                Nodes.AppendChild(NS15);

                                //�������
                                XmlElement NS16 = doc.CreateElement("inventoryId");
                                NS16.InnerText = "";
                                Nodes.AppendChild(NS16);

                                //��Ͷ�ʱ�־
                                XmlElement NS17 = doc.CreateElement("investFlag");
                                NS17.InnerText = "";
                                Nodes.AppendChild(NS17);

                                //�跽���� �ǿ��ֶ�
                                XmlElement NS18 = doc.CreateElement("debit_quantity");
                                NS18.InnerText = "0";
                                Nodes.AppendChild(NS18);

                                //����
                                XmlElement NS19 = doc.CreateElement("unit_price");
                                NS19.InnerText = "";
                                Nodes.AppendChild(NS19);

                                //˰��
                                XmlElement NS20 = doc.CreateElement("tax_rate");
                                NS20.InnerText = "0";
                                Nodes.AppendChild(NS20);

                                //�跽ԭ��˰�� �ǿ��ֶ�
                                XmlElement NS21 = doc.CreateElement("debit_original_tax");
                                NS21.InnerText = "0";
                                Nodes.AppendChild(NS21);

                                //�跽����˰�� �ǿ��ֶ�
                                XmlElement NS22 = doc.CreateElement("debit_fractional_tax");
                                NS22.InnerText = "0";
                                Nodes.AppendChild(NS22);

                                //�跽����˰�� �ǿ��ֶ�
                                XmlElement NS23 = doc.CreateElement("debit_local_tax");
                                NS23.InnerText = "0";
                                Nodes.AppendChild(NS23);

                                //������������
                                XmlElement NS24 = doc.CreateElement("pay_bankName");
                                NS24.InnerText = "";
                                Nodes.AppendChild(NS24);

                                //���������˻� �����⴦����ֶ�,Ҫ�����¼���ʺű���
                                XmlElement NS25 = doc.CreateElement("pay_accounts");
                                NS25.InnerText = "";
                                Nodes.AppendChild(NS25);

                                //�������е�ַ
                                XmlElement NS26 = doc.CreateElement("pay_bank_addr");
                                NS26.InnerText = "";
                                Nodes.AppendChild(NS26);

                                //�տ���������
                                XmlElement NS27 = doc.CreateElement("gather_bankName");
                                NS27.InnerText = "";
                                Nodes.AppendChild(NS27);

                                //�տ������˻�
                                XmlElement NS28 = doc.CreateElement("gather_accounts");
                                NS28.InnerText = "1102020409000161471";
                                Nodes.AppendChild(NS28);

                                //�տ����е�ַ
                                XmlElement NS29 = doc.CreateElement("gather_bank_addr");
                                NS29.InnerText = "";
                                Nodes.AppendChild(NS29);

                                #region freeitem
                                XmlElement NSF1 = doc.CreateElement("freeitem1");
                                NSF1.InnerText = "";
                                Nodes.AppendChild(NSF1);

                                XmlElement NSF2 = doc.CreateElement("freeitem2");
                                NSF2.InnerText = "";
                                Nodes.AppendChild(NSF2);

                                XmlElement NSF3 = doc.CreateElement("freeitem3");
                                NSF3.InnerText = "";
                                Nodes.AppendChild(NSF3);

                                XmlElement NSF4 = doc.CreateElement("freeitem4");
                                NSF4.InnerText = "";
                                Nodes.AppendChild(NSF4);

                                XmlElement NSF5 = doc.CreateElement("freeitem5");
                                NSF5.InnerText = "";
                                Nodes.AppendChild(NSF5);

                                XmlElement NSF6 = doc.CreateElement("freeitem6");
                                NSF6.InnerText = "";
                                Nodes.AppendChild(NSF6);

                                XmlElement NSF7 = doc.CreateElement("freeitem7");
                                NSF7.InnerText = "";
                                Nodes.AppendChild(NSF7);

                                XmlElement NSF8 = doc.CreateElement("freeitem8");
                                NSF8.InnerText = "";
                                Nodes.AppendChild(NSF8);

                                XmlElement NSF9 = doc.CreateElement("freeitem9");
                                NSF9.InnerText = "";
                                Nodes.AppendChild(NSF9);

                                XmlElement NSF10 = doc.CreateElement("freeitem10");
                                NSF10.InnerText = "";
                                Nodes.AppendChild(NSF10);

                                XmlElement NSF11 = doc.CreateElement("freeitem11");
                                NSF11.InnerText = "";
                                Nodes.AppendChild(NSF11);

                                XmlElement NSF12 = doc.CreateElement("freeitem12");
                                NSF12.InnerText = "";
                                Nodes.AppendChild(NSF12);

                                XmlElement NSF13 = doc.CreateElement("freeitem13");
                                NSF13.InnerText = "";
                                Nodes.AppendChild(NSF13);

                                XmlElement NSF14 = doc.CreateElement("freeitem14");
                                NSF14.InnerText = "";
                                Nodes.AppendChild(NSF14);

                                XmlElement NSF15 = doc.CreateElement("freeitem15");
                                NSF15.InnerText = "";
                                Nodes.AppendChild(NSF15);

                                XmlElement NSF16 = doc.CreateElement("freeitem16");
                                NSF16.InnerText = "";
                                Nodes.AppendChild(NSF16);

                                XmlElement NSF17 = doc.CreateElement("freeitem17");
                                NSF17.InnerText = "";
                                Nodes.AppendChild(NSF17);

                                XmlElement NSF18 = doc.CreateElement("freeitem18");
                                NSF18.InnerText = "";
                                Nodes.AppendChild(NSF18);

                                XmlElement NSF19 = doc.CreateElement("freeitem19");
                                NSF19.InnerText = "";
                                Nodes.AppendChild(NSF19);

                                XmlElement NSF20 = doc.CreateElement("freeitem20");
                                NSF20.InnerText = "";
                                Nodes.AppendChild(NSF20);
                                #endregion

                                //������
                                XmlElement NS30 = doc.CreateElement("orderId");
                                NS30.InnerText = "";
                                Nodes.AppendChild(NS30);

                                //��Ʊ����
                                XmlElement NS31 = doc.CreateElement("check_date");
                                NS31.InnerText = "";
                                Nodes.AppendChild(NS31);

                                //�跽������˰��� �ǿ��ֶ�
                                XmlElement NS32 = doc.CreateElement("debit_frac_noTax");
                                NS32.InnerText = "0";
                                Nodes.AppendChild(NS32);

                                //����������˰��� �ǿ��ֶ�
                                XmlElement NS33 = doc.CreateElement("credit_frac_noTax");
                                NS33.InnerText = "0";
                                Nodes.AppendChild(NS33);

                                //�跽������˰��� �ǿ��ֶ�
                                XmlElement NS34 = doc.CreateElement("debit_local_noTax");
                                NS34.InnerText = "0";
                                Nodes.AppendChild(NS34);

                                //�����־
                                XmlElement NS35 = doc.CreateElement("incomeFlag");
                                NS35.InnerText = "y";
                                Nodes.AppendChild(NS35);

                                //��֧��Ŀ
                                XmlElement NS36 = doc.CreateElement("accsubjId");
                                NS36.InnerText = "0101";
                                Nodes.AppendChild(NS36);

                                //�˻�����������Ϊ�գ������ֵһ��Ҫ��������
                                XmlElement NS37 = doc.CreateElement("accountid");
                                NS37.InnerText = "";
                                Nodes.AppendChild(NS37);

                                //�տ�Э���
                                XmlElement NS38 = doc.CreateElement("pay_agreementId");
                                NS38.InnerText = "";
                                Nodes.AppendChild(NS38);

                                //����ԭ�ҽ�� �ǿ��ֶ�
                                XmlElement NS39 = doc.CreateElement("credit_original_sum");
                                NS39.InnerText = dwbody[i]["iAmt_f"].ToString().Trim();
                                Nodes.AppendChild(NS39);

                                //�������ҽ�� �ǿ��ֶ�
                                XmlElement NS40 = doc.CreateElement("credit_frac_sum");
                                NS40.InnerText = "0";
                                Nodes.AppendChild(NS40);

                                //�������ҽ�� �ǿ��ֶ�
                                XmlElement NS41 = doc.CreateElement("credit_local_sum");
                                NS41.InnerText = dwbody[i]["iAmt"].ToString().Trim();
                                Nodes.AppendChild(NS41);

                                //�������� �ǿ��ֶ�
                                XmlElement NS42 = doc.CreateElement("credit_quantity");
                                NS42.InnerText = "0";
                                Nodes.AppendChild(NS42);

                                //����ԭ��˰�� �ǿ��ֶ�
                                XmlElement NS43 = doc.CreateElement("credit_original_Tax");
                                NS43.InnerText = "0";
                                Nodes.AppendChild(NS43);

                                //��������˰�� �ǿ��ֶ�
                                XmlElement NS44 = doc.CreateElement("credit_frac_Tax");
                                NS44.InnerText = "0";
                                Nodes.AppendChild(NS44);

                                //��������˰�� �ǿ��ֶ�
                                XmlElement NS45 = doc.CreateElement("credit_local_Tax");
                                NS45.InnerText = "0";
                                Nodes.AppendChild(NS45);

                                //�������� �ǿ��ֶΣ�0�ͻ���1��Ӧ�̣�2���ţ�3ҵ��Ա
                                XmlElement NS46 = doc.CreateElement("object");
                                NS46.InnerText = "0";
                                Nodes.AppendChild(NS46);

                                //�跽ԭ����˰��� �ǿ��ֶ�
                                XmlElement NS47 = doc.CreateElement("debit_original_noTax");
                                NS47.InnerText = "0";
                                Nodes.AppendChild(NS47);

                                //����ԭ����˰��� �ǿ��ֶ�
                                XmlElement NS48 = doc.CreateElement("credit_original_noTax");
                                NS48.InnerText = dwbody[i]["iAmt_f"].ToString().Trim();
                                Nodes.AppendChild(NS48);

                                //����������˰��� �ǿ��ֶ�
                                XmlElement NS49 = doc.CreateElement("credit_local_noTax");
                                NS49.InnerText = dwbody[i]["iAmt"].ToString().Trim();
                                Nodes.AppendChild(NS49);

                                //˰��
                                XmlElement NS50 = doc.CreateElement("tax_num");
                                NS50.InnerText = "";
                                Nodes.AppendChild(NS50);

                                //��Ŀ�׶�
                                XmlElement NS51 = doc.CreateElement("pk_jobobjpha");
                                NS51.InnerText = "";
                                Nodes.AppendChild(NS51);

                                //������;
                                XmlElement NS52 = doc.CreateElement("purpose_sum");
                                NS52.InnerText = "";
                                Nodes.AppendChild(NS52);

                                //���ű���
                                XmlElement NS53 = doc.CreateElement("deptid");
                                DataRow[] dws53 = dt���ŵ���ӳ���.Select("trim(����)='" + dwbody[i]["cDepCode"].ToString().Trim() + "'");
                                if (dws53.Length > 0)
                                {
                                    NS53.InnerText = dws53[0]["����1"].ToString().Trim();
                                    if (NS53.InnerText.Trim() == "")
                                    {
                                        sErr = sErr + "��" + (j + 1) + "��" + "����" + dwbody[i]["cDepCode"].ToString().Trim() + "���ҵ�ӳ�����ӳ����ӦֵΪ��" + "\n";
                                    }
                                }
                                else
                                {
                                    sErr = sErr + "��" + (j + 1) + "��" + "����" + dwbody[i]["cDepCode"].ToString().Trim() + "δ�ҵ�ӳ���" + "\n";
                                    //NS53.InnerText = "";
                                }
                                Nodes.AppendChild(NS53);

                                //ҵ��Ա����
                                XmlElement NS54 = doc.CreateElement("employeeId");
                                DataRow[] dws54 = dt��Ա����ӳ���.Select("trim(����)='" + dt.Rows[j]["cPerson"].ToString().Trim() + "'");
                                if (dws54.Length > 0)
                                {
                                    NS54.InnerText = dws54[0]["����1"].ToString().Trim();
                                    if (NS54.InnerText.Trim() == "")
                                    {
                                        sErr = sErr + "��" + (j + 1) + "��" + "ҵ��Ա" + dt.Rows[j]["cPerson"].ToString().Trim() + "���ҵ�ӳ�����ӳ����ӦֵΪ��" + "\n";
                                    }
                                }
                                else
                                {
                                    NS54.InnerText = "";
                                    sErr = sErr + "��" + (j + 1) + "��" + "ҵ��Ա" + dt.Rows[j]["cPerson"].ToString().Trim() + "δ�ҵ�ӳ���" + "\n";
                                }
                                Nodes.AppendChild(NS54);

                                //��˰����
                                XmlElement NS55 = doc.CreateElement("unit_price_WithTax");
                                //NS55.InnerText = "";
                                Nodes.AppendChild(NS55);

                                //��˰��𣬲���Ϊ�գ�Ĭ��Ϊ0
                                XmlElement NS56 = doc.CreateElement("Tax_Type");
                                NS56.InnerText = "0";
                                Nodes.AppendChild(NS56);

                                //ע�⣺���̡����š�ҵ��Ա����ͬʱΪ��
                                //V5����

                                //��������
                                XmlElement NS57 = doc.CreateElement("tradertype");
                                NS57.InnerText = "0";
                                Nodes.AppendChild(NS57);

                                //���κ�1
                                XmlElement NS58 = doc.CreateElement("seqnum");
                                //NS58.InnerText = "";
                                Nodes.AppendChild(NS58);

                                //ɢ��
                                XmlElement NS59 = doc.CreateElement("sanhu");
                                //NS59.InnerText = "";
                                Nodes.AppendChild(NS59);

                                //ʹ�ò���
                                XmlElement NS60 = doc.CreateElement("usedept");
                                //NS60.InnerText = "";
                                Nodes.AppendChild(NS60);

                                //�̶��ʲ���Ƭ��
                                XmlElement NS61 = doc.CreateElement("facardbh");
                                //NS61.InnerText = "";
                                Nodes.AppendChild(NS61);

                                //�ֽ�������Ŀ
                                XmlElement NS62 = doc.CreateElement("cashitem");
                                NS62.InnerText = "100011";
                                Nodes.AppendChild(NS62);

                                //֧��״̬
                                XmlElement NS63 = doc.CreateElement("payflag");
                                //NS63.InnerText = "";
                                Nodes.AppendChild(NS63);

                                //���۵�λ��˰����
                                XmlElement NS64 = doc.CreateElement("bjdwwsdj");
                                //NS64.InnerText = "";
                                Nodes.AppendChild(NS64);

                                //���ⵥ��
                                XmlElement NS65 = doc.CreateElement("ckdh");
                                //NS65.InnerText = "";
                                Nodes.AppendChild(NS65);

                                //֧����
                                XmlElement NS66 = doc.CreateElement("payman");
                                //NS66.InnerText = "";
                                Nodes.AppendChild(NS66);

                                //֧������
                                XmlElement NS67 = doc.CreateElement("paydate");
                                //NS67.InnerText = "";
                                Nodes.AppendChild(NS67);

                                //��Ŀ�׶ι�����id
                                XmlElement NS68 = doc.CreateElement("pk_jobobjpha");
                                //NS68.InnerText = "";
                                Nodes.AppendChild(NS68);

                                #region freeitem
                                XmlElement NSF21 = doc.CreateElement("freeitem21");
                                NSF21.InnerText = "";
                                Nodes.AppendChild(NSF21);

                                XmlElement NSF22 = doc.CreateElement("freeitem22");
                                NSF22.InnerText = "";
                                Nodes.AppendChild(NSF22);

                                XmlElement NSF23 = doc.CreateElement("freeitem23");
                                NSF23.InnerText = "";
                                Nodes.AppendChild(NSF23);

                                XmlElement NSF24 = doc.CreateElement("freeitem24");
                                NSF24.InnerText = "";
                                Nodes.AppendChild(NSF24);

                                XmlElement NSF25 = doc.CreateElement("freeitem25");
                                NSF25.InnerText = "";
                                Nodes.AppendChild(NSF25);

                                XmlElement NSF26 = doc.CreateElement("freeitem26");
                                NSF26.InnerText = "";
                                Nodes.AppendChild(NSF26);

                                XmlElement NSF27 = doc.CreateElement("freeitem27");
                                NSF27.InnerText = "";
                                Nodes.AppendChild(NSF27);

                                XmlElement NSF28 = doc.CreateElement("freeitem28");
                                NSF28.InnerText = "";
                                Nodes.AppendChild(NSF28);

                                XmlElement NSF29 = doc.CreateElement("freeitem29");
                                NSF29.InnerText = "";
                                Nodes.AppendChild(NSF29);

                                XmlElement NSF30 = doc.CreateElement("freeitem30");
                                NSF30.InnerText = "";
                                Nodes.AppendChild(NSF30);
                                #endregion

                                //
                                XmlElement NS69 = doc.CreateElement("settlementinfo");
                                NS69.InnerText = "";
                                Nodes.AppendChild(NS69);

                                XmlElement NSS1 = doc.CreateElement("settlement");
                                NSS1.InnerText = "";
                                NS69.AppendChild(NSS1);

                                XmlElement NSSS1 = doc.CreateElement("currency");
                                DataRow[] dwss1 = dt����.Select("trim(����)='" + dt.Rows[j]["cexch_name"].ToString().Trim() + "'");
                                if (dwss1.Length > 0)
                                {
                                    NSSS1.InnerText = dwss1[0]["����1"].ToString().Trim();
                                    if (NSSS1.InnerText.Trim() == "")
                                    {
                                        sErr = sErr + "��" + (j + 1) + "��" + "����" + dt.Rows[j]["cexch_name"].ToString().Trim() + "���ҵ�ӳ�����ӳ����ӦֵΪ��" + "\n";
                                    }
                                }
                                else
                                {
                                    sErr = sErr + "��" + (j + 1) + "��" + "����" + dt.Rows[j]["cexch_name"].ToString().Trim() + "δ�ҵ�ӳ���" + "\n";
                                    NSSS1.InnerText = "";
                                }
                                NSS1.AppendChild(NSSS1);

                                XmlElement NSSS2 = doc.CreateElement("corp");
                                NSSS2.InnerText = "220300000000";
                                NSS1.AppendChild(NSSS2);

                                XmlElement NSSS3 = doc.CreateElement("pay");
                                //NSSS3.InnerText = "";
                                NSS1.AppendChild(NSSS3);

                                XmlElement NSSS4 = doc.CreateElement("paylocal");
                                //NSSS4.InnerText = "";
                                NSS1.AppendChild(NSSS4);

                                XmlElement NSSS5 = doc.CreateElement("receive");
                                //NSSS5.InnerText = "";
                                NSS1.AppendChild(NSSS5);

                                XmlElement NSSS6 = doc.CreateElement("receivelocal");
                                //NSSS6.InnerText = "";
                                NSS1.AppendChild(NSSS6);

                                //���������˻�
                                XmlElement NSSS7 = doc.CreateElement("ownaccount");
                                //NSSS7.InnerText = "";
                                NSS1.AppendChild(NSSS7);

                                //�Է������˻� �����⴦����ֶ�,Ҫ�����¼���ʺű���
                                XmlElement NSSS8 = doc.CreateElement("oppaccount");
                                //NSSS8.InnerText = "";
                                NSS1.AppendChild(NSSS8);

                                XmlElement NSSS9 = doc.CreateElement("localrate");
                                NSSS9.InnerText = "1";
                                NSS1.AppendChild(NSSS9);

                                XmlElement NSSS10 = doc.CreateElement("tradertype");
                                NSSS10.InnerText = "0";
                                NSS1.AppendChild(NSSS10);

                                XmlElement NSSS11 = doc.CreateElement("balatype");
                                //NSSS11.InnerText = "";
                                NSS1.AppendChild(NSSS11);

                                XmlElement NSSS12 = doc.CreateElement("tradername");
                                NSSS12.InnerText = "������ҩҵ���޹�˾";
                                NSS1.AppendChild(NSSS12);

                                XmlElement NSSS13 = doc.CreateElement("memo");
                                NSSS13.InnerText = N16.InnerText;
                                NSS1.AppendChild(NSSS13);

                                XmlElement NSSS14 = doc.CreateElement("notetype");
                                //NSSS14.InnerText = "";
                                NSS1.AppendChild(NSSS14);

                                XmlElement NSSS15 = doc.CreateElement("notenumber");
                                //NSSS15.InnerText = "";
                                NSS1.AppendChild(NSSS15);

                                XmlElement NSSS16 = doc.CreateElement("billtype");
                                //NSSS16.InnerText = "";
                                NSS1.AppendChild(NSSS16);

                                XmlElement NSSS17 = doc.CreateElement("billcode");
                                //NSSS17.InnerText = "";
                                NSS1.AppendChild(NSSS17);

                                XmlElement NSSS18 = doc.CreateElement("billdate");
                                //NSSS18.InnerText = "";
                                NSS1.AppendChild(NSSS18);
                            }
                            Node1.AppendChild(NodeBody);
                            #endregion
                        }
                        bool issave = false;
                        if (sErr != "")
                        {
                            //DialogResult result = MessageBox.Show("�в�������Ϊ�ҵ�ӳ����Ƿ񱣴�?", "������ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            //if (result == DialogResult.OK)
                            //{
                            //    issave = true;
                            //}
                        }
                        else
                        {
                            issave = true;
                        }
                        if (issave == true)
                        {
                            SaveFileDialog sa = new SaveFileDialog();
                            sa.Filter = "xml files(*.xml)|*.xml|�����ļ�(*.*)|*.*";
                            sa.FileName = "�տ����";
                            DialogResult d = sa.ShowDialog();
                            string sPath = sa.FileName;
                            if (d == DialogResult.OK)
                            {
                                if (sPath != "")
                                {
                                    doc.Save(sPath);
                                    MessageBox.Show("�����б�ɹ���\n·����" + sPath);
                                }
                                else
                                {
                                    MessageBox.Show("��ѡ�񵼳�·��");
                                }
                            }
                        }
                        if (sErr != "")
                        {
                            Sa_CloseBillMsg frm = new Sa_CloseBillMsg(sErr,doc);
                            if (DialogResult.OK == frm.ShowDialog())
                            {
                                frm.Enabled = true;
                            }
                        }


                    }
                    //gridView1.OptionsBehavior.Editable = false;
                    
                }
                else
                {
                    MessageBox.Show("�տ�Ų�����Ϊ��");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                bool b = Convert.ToBoolean(gridView1.GetRowCellValue(iRow, gridColChk));
                string s = gridView1.GetRowCellValue(iRow, gridCol�տ��).ToString().Trim();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string s2 = gridView1.GetRowCellValue(i, gridCol�տ��).ToString().Trim();
                    if (s == s2)
                    {
                        gridView1.SetRowCellValue(i, gridColChk, !b);
                    }
                }
            }
            catch
            { }
        }
    }
}