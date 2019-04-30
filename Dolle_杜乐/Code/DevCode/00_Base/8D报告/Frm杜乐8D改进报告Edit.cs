using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;
using TH.Model;

namespace Base
{
    public partial class Frm����8D�Ľ�����Edit : FrameBaseFunction.Frm�б���ģ��
    {
        //TH.BaseClsInfo.ClsDataBase clsSQLCommond = TH.BaseClsInfo.ClsDataBaseFactory.Instance();
        //FrameBaseFunction.ClsGetSQL clsGetSQL = new FrameBaseFunction.ClsGetSQL();

        long lID = 0;

        public Frm����8D�Ľ�����Edit(long ID)
        {
            InitializeComponent();

            lID = ID;
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "refresh":
                        btnSel();
                        break;
                    //case "sendmail":
                    //    btnSendMail();
                    //    break;
                    case "edit":
                        btnEdit();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "alter":
                        btnPrint();
                        break;
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message);
            }
        }

        private void btnPrint()
        {
            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("��õ���IDʧ��");
            }

            DataTable dt = GetGrid();
            ����8D�Ľ�����Report rep = new ����8D�Ľ�����Report();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = rep.dataSet1.Tables[0].NewRow();

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string sColName = dt.Columns[j].ColumnName.Trim();

                    for (int k = 0; k < rep.dataSet1.Tables[0].Columns.Count; k++)
                    {
                        string sColName2 = rep.dataSet1.Tables[0].Columns[k].ColumnName.Trim();
                        if (sColName == sColName2)
                        {
                            if (sColName == "��������" || sColName == "�����������" || sColName == "��ʱ��ʩ���ʱ��" || sColName == "������ʩ���ʱ��" || sColName == "Ԥ����ʩ���ʱ��")
                            {
                                if (ReturnObjectToDatetime(dt.Rows[i][sColName]) > ReturnObjectToDatetime("2000-1-1"))
                                {
                                    dr[sColName] = ReturnObjectToDatetime(dt.Rows[i][sColName]).ToString("yyyy-MM-dd");
                                }
                            }
                            else
                            {
                                dr[sColName] = dt.Rows[i][sColName].ToString().Trim();
                            }
                            break;
                        }
                    }
                }

                rep.dataSet1.Tables[0].Rows.Add(dr);
            }


            rep.ShowPreview();
        }

        private void btnUnAudit()
        {
            if (sState == "edit")
            {
                throw new Exception("�༭״̬���ܷ��;ܾ�");
            }

            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("��õ���IDʧ��");
            }

            string sSQL = "select * from UFDLImport.._8D���� where idHead = " + txtIDHead.Text.Trim();
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("��õ���IDʧ��");
            }
            if (dt.Rows[0]["״̬"].ToString().Trim().ToLower() == "false" && dt.Rows[0]["������"].ToString().Trim() != "" && dt.Rows[0]["�ٴ��ύ"].ToString().Trim() == "")
            {
                throw new Exception("�����Ѿ��ܾ�");
            }

            sSQL = "update UFDLImport.._8D���� set �ٴ��ύ = null,�ٴ��ύ���� = null,״̬ = 0 ,������ = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,�������� = getdate() where idHead = " + txtIDHead.Text.Trim();
            int iCou = clsSQLCommond.ExecSql(sSQL);
            if (iCou > 0)
            {
                MessageBox.Show("�ܾ��ɹ�");
                label״̬.Text = "�ܾ�";
            }


            #region �����ʼ�����Ӧ��
            sSQL = "select distinct sEMail from UFDLImport.._vendUid where vendCode = '" + txt��Ӧ�̱���.Text.Trim() + "' and isnull(sEMail,'') <> ''";
            dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
            {
                throw new Exception("��ù�Ӧ������ʧ��");
            }

            string sMail = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                {
                    sMail = dt.Rows[i]["sEMail"].ToString().Trim();
                }
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["sEMail"].ToString().Trim();
                }
            }
            if (sMail.Trim() == "")
            {
                throw new Exception("��ù�Ӧ������ʧ��");
            }

            string sText =  "����8D�Ľ����棺" + txt���.Text.Trim() + " �Ѿܾ�";
            if (sMail.Trim() != "")
            {
                btnSendMail(sText, sMail);
            }
            #endregion
        }

        private void btnSave()
        {
            if (sState != "edit")
            {
                throw new Exception("���ȵ���༭�����༭���ݺ󱣴�");
            }
            if (label״̬.Text == "��׼")
            {
                throw new Exception("�Ѿ���׼�����ܱ༭");
            }

            txtIDHead.Focus();
            TH.Model._8D���� model = new TH.Model._8D����();

            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("��õ���IDʧ��");
            }

            string sSQL = "select * from UFDLImport.._8D���� where idHead = " + txtIDHead.Text.Trim();
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["״̬"].ToString().Trim().ToLower() == "true" && dt.Rows[0]["������"].ToString().Trim() != "")
            {
                throw new Exception("�����Ѿ���׼");
            }

            model.IDHead = ReturnObjectToLong(txtIDHead.Text.Trim());
            model.TaskID = ReturnObjectToLong(txtTaskID.Text.Trim());

            if (txt�鳤.Text.Trim() == "" && txtƷ�ܲ�.Text.Trim() == "" && txt���̲�.Text.Trim() == "" && txt���첿.Text.Trim() == "")
            {
                throw new Exception("�鳤��Ʒ�ܲ������̲������첿 ����������дһ��");
            }

            model.�鳤 = txt�鳤.Text.Trim();
            model.Ʒ�ܲ� = txtƷ�ܲ�.Text.Trim();
            model.���̲� = txt���̲�.Text.Trim();
            model.���첿 = txt���첿.Text.Trim();
          
            if(txt�������.Text.Trim() == "")
            {
                throw new Exception("������� ����");
            }
            model.������� = txt�������.Text.Trim();

            if (txtǩ��.Text.Trim() == "")
            {
                throw new Exception("ǩ�� ����");
            }
            model.�������ǩ�� = txtǩ��.Text.Trim();

            if (ReturnObjectToDatetime(dtmǩ������.DateTime.ToString("yyyy-MM-dd")) < ReturnObjectToDatetime("2000-1-1"))
            {
                throw new Exception("����ǩ������ ����");
            }
            model.����������� = ReturnObjectToDatetime(dtmǩ������.DateTime.ToString("yyyy-MM-dd"));

            if (txt��ʱ��ʩ.Text.Trim() == "")
            {
                throw new Exception("��ʱ��ʩ ����");
            }
            model.��ʱ��ʩ = txt��ʱ��ʩ.Text.Trim();

            if (txt��ʱ��ʩ������.Text.Trim() == "")
            {
                throw new Exception("��ʱ��ʩ������ ����");
            }
            model.��ʱ��ʩ������ = txt��ʱ��ʩ������.Text.Trim();

            if (ReturnObjectToDatetime(dtm��ʱ��ʩ���ʱ��.DateTime.ToString("yyyy-MM-dd")) < ReturnObjectToDatetime("2000-1-1"))
            {
                throw new Exception("��ʱ��ʩ���ʱ�� ����");
            }
            model.��ʱ��ʩ���ʱ�� = ReturnObjectToDatetime(dtm��ʱ��ʩ���ʱ��.DateTime.ToString("yyyy-MM-dd"));

            if (txt��ʱ��ʩ�����֤.Text.Trim() == "")
            {
                throw new Exception("��ʱ��ʩ�����֤ ����");
            }
            model.��ʱ��ʩ�����֤ = txt��ʱ��ʩ�����֤.Text.Trim();

            if (txtԭ�����.Text.Trim() == "")
            {
                throw new Exception("ԭ����� ����");
            }
            model.ԭ����� = txtԭ�����.Text.Trim();

            if (txt������ʩ.Text.Trim() == "")
            {
                throw new Exception("������ʩ ����");
            }
            model.������ʩ = txt������ʩ.Text.Trim();

            if (txt������ʩ������.Text.Trim() == "")
            {
                throw new Exception("������ʩ������ ����");
            }
            model.������ʩ������ = txt������ʩ������.Text.Trim();

            if (ReturnObjectToDatetime(dtm������ʩ���ʱ��.DateTime.ToString("yyyy-MM-dd")) < ReturnObjectToDatetime("2000-1-1"))
            {
                throw new Exception("������ʩ���ʱ�� ����");
            }
            model.������ʩ���ʱ�� = ReturnObjectToDatetime(dtm������ʩ���ʱ��.DateTime.ToString("yyyy-MM-dd"));

            if (txt������ʩ�����֤.Text.Trim() == "")
            {
                throw new Exception("������ʩ�����֤ ����");
            }
            model.������ʩ�����֤ = txt������ʩ�����֤.Text.Trim();

            if (txtԤ����ʩ.Text.Trim() == "")
            {
                throw new Exception("Ԥ����ʩ ����");
            }
            model.Ԥ����ʩ = txtԤ����ʩ.Text.Trim();

            if (txtԤ����ʩ������.Text.Trim() == "")
            {
                throw new Exception("Ԥ����ʩ������ ����");
            }
            model.Ԥ����ʩ������ = txtԤ����ʩ������.Text.Trim();

            if (ReturnObjectToDatetime(dtmԤ����ʩ���ʱ��.DateTime.ToString("yyyy-MM-dd")) < ReturnObjectToDatetime("2000-1-1"))
            {
                throw new Exception("Ԥ����ʩ���ʱ�� ����");
            }
            model.Ԥ����ʩ���ʱ�� = ReturnObjectToDatetime(dtmԤ����ʩ���ʱ��.DateTime.ToString("yyyy-MM-dd"));

            if (txtԤ����ʩ�����֤.Text.Trim() == "")
            {
                throw new Exception("Ԥ����ʩ�����֤ ����");
            }
            model.Ԥ����ʩ�����֤ = txtԤ����ʩ�����֤.Text.Trim();
            model.Ч�� = txtЧ��.Text.Trim();
            model.Ч��ǩ�� = txtЧ��ǩ��.Text.Trim();

            TH.DAL._8D���� dal = new TH.DAL._8D����();

            sSQL = "select count(1) from  UFDLImport.._8D���� where IDHead = " + model.IDHead.ToString();
            dt = clsSQLCommond.ExecQuery(sSQL);
            int iCou = ReturnObjectToInt(dt.Rows[0][0]);
            if (iCou == 0)
            {
                sSQL = dal.Add(model);
            }
            else
            {
                model.�ٴ��ύ = sUserName;
                model.�ٴ��ύ���� = DateTime.Now;

                sSQL = dal.Update(model);
            }
            iCou = clsSQLCommond.ExecSql(sSQL);
            if (iCou > 0)
            {
                MessageBox.Show("����ɹ�");
                SetEnable(false);
            }

            #region �����ʼ���Ʒ��
            sSQL = @"
select distinct sEMail
from dbo._UserInfo left join UFDLImport.._vendUid on vchrUid=uid and accid = 200 and accyear = 111111 
	left join @u8.vendor on cVenCode = vendCode 
	left join @u8.Department d on d.cDepCode=_UserInfo.cDepCode 
where d.cdepcode = '6'and isnull(sEMail,'') <> ''
            ";
            sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
            {
                throw new Exception("���Ʒ������ʧ��");
            }

            string sMail = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                {
                    sMail = dt.Rows[i]["sEMail"].ToString().Trim();
                }
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["sEMail"].ToString().Trim();
                }
            }
            if (sMail.Trim() == "")
            {
                throw new Exception("��ù�Ӧ������ʧ��");
            }

            string sText = "����8D�Ľ����棺" + txt���.Text.Trim() + " �Ѿܾ�";
            if (sMail.Trim() != "")
            {
                btnSendMail(sText, sMail);
            }
            #endregion
        }

        private void btnSendMail(string sMailText,string sMailAddress)
        {
            try
            {
                string sHead = "����8D�Ľ����棺" + txt���.Text.Trim();
                string sText = sMailText;

                //Base.FrmSendMail fSendMail = new FrmSendMail(sMailAddress, sHead, sText);
                //fSendMail.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("�ʼ�����ʧ�ܣ� " + ee.Message);
            }
        }

        private void btnAudit()
        {
            if (sState == "edit")
            {
                throw new Exception("�༭״̬���ܷ�����׼");
            }

            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("��õ���IDʧ��");
            }

            string sSQL = "select * from UFDLImport.._8D���� where idHead = " + txtIDHead.Text.Trim();
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count == 0)
            {
                throw new Exception("��õ���IDʧ��");
            }
            if (dt.Rows[0]["״̬"].ToString().Trim().ToLower() == "true" && dt.Rows[0]["������"].ToString().Trim() != "")
            {
                throw new Exception("�����Ѿ���׼");
            }

            sSQL = "update    UFDLImport.._8D���� set ״̬ = 1 ,������ = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,�������� = getdate() where idHead = " + txtIDHead.Text.Trim();
            int iCou = clsSQLCommond.ExecSql(sSQL);
            if (iCou > 0)
            {
                MessageBox.Show("��׼�ɹ�");
            }

            label״̬.Text = "��׼";


            #region �����ʼ�����Ӧ��

            sSQL = "select distinct sEMail from UFDLImport.._vendUid where vendCode = '" + txt��Ӧ�̱���.Text.Trim() + "' and isnull(sEMail,'') <> ''";
            dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
            {
                throw new Exception("��ù�Ӧ������ʧ��");
            }

            string sMail = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sMail == "")
                {
                    sMail = dt.Rows[i]["sEMail"].ToString().Trim();
                }
                else
                {
                    sMail = sMail + ";" + dt.Rows[i]["sEMail"].ToString().Trim();
                }
            }
            if (sMail.Trim() == "")
            {
                throw new Exception("��ù�Ӧ������ʧ��");
            }

            string sText = "����8D�Ľ����棺" + txt���.Text.Trim() + " ����׼";
            if (sMail.Trim() != "")
            {
                btnSendMail(sText, sMail);
            }

            #endregion
        }

      

        private void btnEdit()
        {
            if (txtIDHead.Text.Trim() == "")
            {
                throw new Exception("��õ���IDʧ��");
            }
            //if (dt.Rows[0]["״̬"].ToString().Trim().ToLower() == "true" && dt.Rows[0]["������"].ToString().Trim() != "")
            //{
            //    throw new Exception("�����Ѿ���׼");
            //}

            SetEnable(true);
        }

        private void btnSel()
        {
            DataTable dt = GetGrid();
            SetValue(dt);

        }

        private DataTable GetGrid()
        {
            string sSQL = @"
select cast(0 as bit) as ѡ��
    ,* 
from DolleDatabase.dbo._Bai_��������Ʒ�������� a
	left join UFDLImport.._8D���� b on a.id = b.idhead
where �Ƿ��ύ8D�Ľ����� = '��' and 1=1
Order by id
";
            sSQL = sSQL.Replace("1=1", "1=1 and ID = " + lID.ToString());

            return clsSQLCommond.ExecQuery(sSQL);
        }

        private void SetValue(DataTable dt)
        {
            if (dt == null || dt.Rows.Count < 1)
            {
                throw new Exception("��ȡ����ʧ��");
            }

            SetEnable(false);

            txtIDHead.Text = dt.Rows[0]["ID"].ToString().Trim();
            txtTaskID.Text = dt.Rows[0]["TaskID"].ToString().Trim();
            txt��Ӧ��.Text = "[" + dt.Rows[0]["���̱���"].ToString().Trim() + "]" + dt.Rows[0]["��Ӧ��"].ToString().Trim();
            txt������.Text = dt.Rows[0]["������"].ToString().Trim();
            txt������.Text = dt.Rows[0]["��������"].ToString().Trim();
            txt������.Text = dt.Rows[0]["������"].ToString().Trim();
            txt��������.Text = dt.Rows[0]["��������"].ToString().Trim();
            txt���ϴ���.Text = dt.Rows[0]["���ϱ���"].ToString().Trim();
            txt����.Text = dt.Rows[0]["����"].ToString().Trim();
            txt���.Text = dt.Rows[0]["���ݺ�"].ToString().Trim();
            txt������.Text = dt.Rows[0]["������"].ToString().Trim();
            dtm��������.Text = dt.Rows[0]["��������"].ToString().Trim();
            txt��������.Text = dt.Rows[0]["ԭ��"].ToString().Trim();
            txt�鳤.Text = dt.Rows[0]["�鳤"].ToString().Trim();
            txtƷ�ܲ�.Text = dt.Rows[0]["Ʒ�ܲ�"].ToString().Trim();
            txt���̲�.Text = dt.Rows[0]["���̲�"].ToString().Trim();
            txt���첿.Text = dt.Rows[0]["���첿"].ToString().Trim();
            txt�������.Text = dt.Rows[0]["�������"].ToString().Trim();
            txtǩ��.Text = dt.Rows[0]["�������ǩ��"].ToString().Trim();
            dtmǩ������.Text = dt.Rows[0]["�����������"].ToString().Trim();
            txt��ʱ��ʩ.Text = dt.Rows[0]["��ʱ��ʩ"].ToString().Trim();
            txt��ʱ��ʩ������.Text = dt.Rows[0]["��ʱ��ʩ������"].ToString().Trim();
            dtm��ʱ��ʩ���ʱ��.Text = dt.Rows[0]["��ʱ��ʩ���ʱ��"].ToString().Trim();
            txt��ʱ��ʩ�����֤.Text = dt.Rows[0]["��ʱ��ʩ�����֤"].ToString().Trim();
            txtԭ�����.Text = dt.Rows[0]["ԭ�����"].ToString().Trim();
            txt������ʩ.Text = dt.Rows[0]["������ʩ"].ToString().Trim();
            txt������ʩ������.Text = dt.Rows[0]["������ʩ������"].ToString().Trim();
            dtm������ʩ���ʱ��.Text = dt.Rows[0]["������ʩ���ʱ��"].ToString().Trim();
            txt������ʩ�����֤.Text = dt.Rows[0]["������ʩ�����֤"].ToString().Trim();
            txtԤ����ʩ.Text = dt.Rows[0]["Ԥ����ʩ"].ToString().Trim();
            txtԤ����ʩ������.Text = dt.Rows[0]["Ԥ����ʩ������"].ToString().Trim();
            dtmԤ����ʩ���ʱ��.Text = dt.Rows[0]["Ԥ����ʩ���ʱ��"].ToString().Trim();
            txtԤ����ʩ�����֤.Text = dt.Rows[0]["Ԥ����ʩ�����֤"].ToString().Trim();
            txtЧ��.Text = dt.Rows[0]["Ч��"].ToString().Trim();
            txtЧ��ǩ��.Text = dt.Rows[0]["Ч��ǩ��"].ToString().Trim();
            txt��Ӧ�̱���.Text = dt.Rows[0]["���̱���"].ToString().Trim();

            if (ReturnObjectToInt(dt.Rows[0]["״̬"]) == 0 && dt.Rows[0]["������"].ToString().Trim() != "")
            {
                label״̬.Text = "�ܾ�";
            }
            else if (ReturnObjectToInt(dt.Rows[0]["״̬"]) == 1 && dt.Rows[0]["������"].ToString().Trim() != "")
            {
                label״̬.Text = "��׼";
            }
            else
            {
                label״̬.Text = "";
            }

        }

        #region ��ťģ��

      
        /// <summary>
        /// ���
        /// </summary>
        private void btnExport()
        {
            //try
            //{
            //    SaveFileDialog sF = new SaveFileDialog();
            //    sF.DefaultExt = "xls";
            //    sF.FileName = this.Text;
            //    sF.Filter = "Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
            //    DialogResult dRes = sF.ShowDialog();
            //    if (DialogResult.OK == dRes)
            //    {
            //        gridView1.ExportToExcel(sF.FileName);
            //        MessageBox.Show("����Excel�ɹ�\n\t·����" + sF.FileName);
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }

      
        #endregion






        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ��\n" + ee.Message);
            }
        }

        private void SetTxtNull()
        {
            txtIDHead.Text = "";
            txt��Ӧ�̱���.Text = "";
            txt��Ӧ��.Text = "";
            txt������.Text = "";
            txt������.Text = "";
            txt������.Text = "";
            txt��������.Text = "";
            txt���ϴ���.Text = "";
            txt����.Text = "";
            txt���.Text = "";
            txt������.Text = "";
            dtm��������.Text = "";
            txt��������.Text = "";
            txt�鳤.Text = "";
            txtƷ�ܲ�.Text = "";
            txt���̲�.Text = "";
            txt���첿.Text = "";
            txt�������.Text = "";
            txtǩ��.Text = "";
            dtmǩ������.Text = "";
            txt��ʱ��ʩ.Text = "";
            txt��ʱ��ʩ������.Text = "";
            dtm��ʱ��ʩ���ʱ��.Text = "";
            txt��ʱ��ʩ�����֤.Text = "";
            txtԭ�����.Text = "";
            txt������ʩ.Text = "";
            txt������ʩ������.Text = "";
            dtm������ʩ���ʱ��.Text = "";
            txt������ʩ�����֤.Text = "";
            txtԤ����ʩ.Text = "";
            txtԤ����ʩ������.Text = "";
            dtmԤ����ʩ���ʱ��.Text = "";
            txtԤ����ʩ�����֤.Text = "";
            txtЧ��.Text = "";
            txtЧ��ǩ��.Text = "";
        }

        private void SetEnable(bool b)
        {
            txt��Ӧ��.Enabled = false;
            txt������.Enabled = false;
            txt������.Enabled = false;
            txt������.Enabled = false;
            txt��������.Enabled = false;
            txt���ϴ���.Enabled = false;
            txt����.Enabled = false;
            txt���.Enabled = false;
            txt������.Enabled = false;
            dtm��������.Enabled = false;
            txt��������.Enabled = false;
            txt�鳤.Enabled = b;
            txtƷ�ܲ�.Enabled = b;
            txt���̲�.Enabled = b;
            txt���첿.Enabled = b;
            txt�������.Enabled = b;
            txtǩ��.Enabled = b;
            dtmǩ������.Enabled = b;
            txt��ʱ��ʩ.Enabled = b;
            txt��ʱ��ʩ������.Enabled = b;
            dtm��ʱ��ʩ���ʱ��.Enabled = b;
            txt��ʱ��ʩ�����֤.Enabled = b;
            txtԭ�����.Enabled = b;
            txt������ʩ.Enabled = b;
            txt������ʩ������.Enabled = b;
            dtm������ʩ���ʱ��.Enabled = b;
            txt������ʩ�����֤.Enabled = b;
            txtԤ����ʩ.Enabled = b;
            txtԤ����ʩ������.Enabled = b;
            dtmԤ����ʩ���ʱ��.Enabled = b;
            txtԤ����ʩ�����֤.Enabled = b;
            txtЧ��.Enabled = b;
            txtЧ��ǩ��.Enabled = b;


            txt��Ӧ��.Properties.ReadOnly = !b;
            txt������.Properties.ReadOnly = !b;
            txt������.Properties.ReadOnly = !b;
            txt������.Properties.ReadOnly = !b;
            txt��������.Properties.ReadOnly = !b;
            txt���ϴ���.Properties.ReadOnly = !b;
            txt����.Properties.ReadOnly = !b;
            txt���.Properties.ReadOnly = !b;
            txt������.Properties.ReadOnly = !b;
            dtm��������.Properties.ReadOnly = !b;
            txt��������.ReadOnly = !b;
            txt�鳤.Properties.ReadOnly = !b;
            txtƷ�ܲ�.Properties.ReadOnly = !b;
            txt���̲�.Properties.ReadOnly = !b;
            txt���첿.Properties.ReadOnly = !b;
            txt�������.ReadOnly = !b;
            txtǩ��.Properties.ReadOnly = !b;
            dtmǩ������.Properties.ReadOnly = !b;
            txt��ʱ��ʩ.ReadOnly = !b;
            txt��ʱ��ʩ������.Properties.ReadOnly = !b;
            dtm��ʱ��ʩ���ʱ��.Properties.ReadOnly = !b;
            txt��ʱ��ʩ�����֤.Properties.ReadOnly = !b;
            txtԭ�����.ReadOnly = !b;
            txt������ʩ.ReadOnly = !b;
            txt������ʩ������.Properties.ReadOnly = !b;
            dtm������ʩ���ʱ��.Properties.ReadOnly = !b;
            txt������ʩ�����֤.Properties.ReadOnly = !b;
            txtԤ����ʩ.ReadOnly = !b;
            txtԤ����ʩ������.Properties.ReadOnly = !b;
            dtmԤ����ʩ���ʱ��.Properties.ReadOnly = !b;
            txtԤ����ʩ�����֤.Properties.ReadOnly = !b;
            txtЧ��.ReadOnly = !b;
            txtЧ��ǩ��.Properties.ReadOnly = !b;
        }
    }
}



namespace TH.Model
{
	/// <summary>
	/// _8D����:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class _8D����
	{
		public _8D����()
		{}
		#region Model
		private long? _idhead;
		private long? _taskid;
		private string _�鳤;
		private string _Ʒ�ܲ�;
		private string _���̲�;
		private string _���첿;
		private string _�������;
		private string _�������ǩ��;
		private DateTime _�����������;
		private string _��ʱ��ʩ;
		private string _��ʱ��ʩ������;
		private DateTime _��ʱ��ʩ���ʱ��;
		private string _��ʱ��ʩ�����֤;
		private string _ԭ�����;
		private string _������ʩ;
		private string _������ʩ������;
		private DateTime _������ʩ���ʱ��;
		private string _������ʩ�����֤;
		private string _Ԥ����ʩ;
		private string _Ԥ����ʩ������;
		private DateTime _Ԥ����ʩ���ʱ��;
		private string _Ԥ����ʩ�����֤;
		private string _Ч��;
		private string _Ч��ǩ��;
		private bool _״̬= false;
		private string _������;
        private DateTime? _��������;
        private string _�ٴ��ύ;
        private DateTime? _�ٴ��ύ����;
		/// <summary>
		/// 
		/// </summary>
		public long? IDHead
		{
			set{ _idhead=value;}
			get{return _idhead;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? TaskID
		{
			set{ _taskid=value;}
			get{return _taskid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string �鳤
		{
			set{ _�鳤=value;}
			get{return _�鳤;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ʒ�ܲ�
		{
			set{ _Ʒ�ܲ�=value;}
			get{return _Ʒ�ܲ�;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ���̲�
		{
			set{ _���̲�=value;}
			get{return _���̲�;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ���첿
		{
			set{ _���첿=value;}
			get{return _���첿;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string �������
		{
			set{ _�������=value;}
			get{return _�������;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string �������ǩ��
		{
			set{ _�������ǩ��=value;}
			get{return _�������ǩ��;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime �����������
		{
			set{ _�����������=value;}
			get{return _�����������;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ��ʱ��ʩ
		{
			set{ _��ʱ��ʩ=value;}
			get{return _��ʱ��ʩ;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ��ʱ��ʩ������
		{
			set{ _��ʱ��ʩ������=value;}
			get{return _��ʱ��ʩ������;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ��ʱ��ʩ���ʱ��
		{
			set{ _��ʱ��ʩ���ʱ��=value;}
			get{return _��ʱ��ʩ���ʱ��;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ��ʱ��ʩ�����֤
		{
			set{ _��ʱ��ʩ�����֤=value;}
			get{return _��ʱ��ʩ�����֤;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ԭ�����
		{
			set{ _ԭ�����=value;}
			get{return _ԭ�����;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ������ʩ
		{
			set{ _������ʩ=value;}
			get{return _������ʩ;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ������ʩ������
		{
			set{ _������ʩ������=value;}
			get{return _������ʩ������;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ������ʩ���ʱ��
		{
			set{ _������ʩ���ʱ��=value;}
			get{return _������ʩ���ʱ��;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ������ʩ�����֤
		{
			set{ _������ʩ�����֤=value;}
			get{return _������ʩ�����֤;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ԥ����ʩ
		{
			set{ _Ԥ����ʩ=value;}
			get{return _Ԥ����ʩ;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ԥ����ʩ������
		{
			set{ _Ԥ����ʩ������=value;}
			get{return _Ԥ����ʩ������;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Ԥ����ʩ���ʱ��
		{
			set{ _Ԥ����ʩ���ʱ��=value;}
			get{return _Ԥ����ʩ���ʱ��;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ԥ����ʩ�����֤
		{
			set{ _Ԥ����ʩ�����֤=value;}
			get{return _Ԥ����ʩ�����֤;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ч��
		{
			set{ _Ч��=value;}
			get{return _Ч��;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ч��ǩ��
		{
			set{ _Ч��ǩ��=value;}
			get{return _Ч��ǩ��;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool ״̬
		{
			set{ _״̬=value;}
			get{return _״̬;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ������
		{
			set{ _������=value;}
			get{return _������;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ��������
		{
			set{ _��������=value;}
			get{return _��������;}
        }
        /// <summary>
        /// 
        /// </summary>
        public string �ٴ��ύ
        {
            set { _�ٴ��ύ = value; }
            get { return _�ٴ��ύ; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? �ٴ��ύ����
        {
            set { _�ٴ��ύ���� = value; }
            get { return _�ٴ��ύ����; }
        }
		#endregion Model

	}
}


namespace TH.DAL
{
    /// <summary>
    /// ���ݷ�����:_8D����
    /// </summary>
    public partial class _8D����
    {
        public _8D����()
        { }
        #region  Method

        /// <summary>
        /// ����һ������
        /// </summary>
        public string Add(TH.Model._8D���� model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.IDHead != null)
            {
                strSql1.Append("IDHead,");
                strSql2.Append("" + model.IDHead + ",");
            }
            if (model.TaskID != null)
            {
                strSql1.Append("TaskID,");
                strSql2.Append("" + model.TaskID + ",");
            }
            if (model.�鳤 != null)
            {
                strSql1.Append("�鳤,");
                strSql2.Append("'" + model.�鳤 + "',");
            }
            if (model.Ʒ�ܲ� != null)
            {
                strSql1.Append("Ʒ�ܲ�,");
                strSql2.Append("'" + model.Ʒ�ܲ� + "',");
            }
            if (model.���̲� != null)
            {
                strSql1.Append("���̲�,");
                strSql2.Append("'" + model.���̲� + "',");
            }
            if (model.���첿 != null)
            {
                strSql1.Append("���첿,");
                strSql2.Append("'" + model.���첿 + "',");
            }
            if (model.������� != null)
            {
                strSql1.Append("�������,");
                strSql2.Append("'" + model.������� + "',");
            }
            if (model.�������ǩ�� != null)
            {
                strSql1.Append("�������ǩ��,");
                strSql2.Append("'" + model.�������ǩ�� + "',");
            }
            if (model.����������� != null && model.����������� != DateTime.MinValue)
            {
                strSql1.Append("�����������,");
                strSql2.Append("'" + model.����������� + "',");
            }
            if (model.��ʱ��ʩ != null)
            {
                strSql1.Append("��ʱ��ʩ,");
                strSql2.Append("'" + model.��ʱ��ʩ + "',");
            }
            if (model.��ʱ��ʩ������ != null)
            {
                strSql1.Append("��ʱ��ʩ������,");
                strSql2.Append("'" + model.��ʱ��ʩ������ + "',");
            }
            if (model.��ʱ��ʩ���ʱ�� != null && model.��ʱ��ʩ���ʱ�� != DateTime.MinValue)
            {
                strSql1.Append("��ʱ��ʩ���ʱ��,");
                strSql2.Append("'" + model.��ʱ��ʩ���ʱ�� + "',");
            }
            if (model.��ʱ��ʩ�����֤ != null)
            {
                strSql1.Append("��ʱ��ʩ�����֤,");
                strSql2.Append("'" + model.��ʱ��ʩ�����֤ + "',");
            }
            if (model.ԭ����� != null)
            {
                strSql1.Append("ԭ�����,");
                strSql2.Append("'" + model.ԭ����� + "',");
            }
            if (model.������ʩ != null)
            {
                strSql1.Append("������ʩ,");
                strSql2.Append("'" + model.������ʩ + "',");
            }
            if (model.������ʩ������ != null)
            {
                strSql1.Append("������ʩ������,");
                strSql2.Append("'" + model.������ʩ������ + "',");
            }
            if (model.������ʩ���ʱ�� != null && model.������ʩ���ʱ�� != DateTime.MinValue)
            {
                strSql1.Append("������ʩ���ʱ��,");
                strSql2.Append("'" + model.������ʩ���ʱ�� + "',");
            }
            if (model.������ʩ�����֤ != null)
            {
                strSql1.Append("������ʩ�����֤,");
                strSql2.Append("'" + model.������ʩ�����֤ + "',");
            }
            if (model.Ԥ����ʩ != null)
            {
                strSql1.Append("Ԥ����ʩ,");
                strSql2.Append("'" + model.Ԥ����ʩ + "',");
            }
            if (model.Ԥ����ʩ������ != null)
            {
                strSql1.Append("Ԥ����ʩ������,");
                strSql2.Append("'" + model.Ԥ����ʩ������ + "',");
            }
            if (model.Ԥ����ʩ���ʱ�� != null && model.Ԥ����ʩ���ʱ�� != DateTime.MinValue)
            {
                strSql1.Append("Ԥ����ʩ���ʱ��,");
                strSql2.Append("'" + model.Ԥ����ʩ���ʱ�� + "',");
            }
            if (model.Ԥ����ʩ�����֤ != null)
            {
                strSql1.Append("Ԥ����ʩ�����֤,");
                strSql2.Append("'" + model.Ԥ����ʩ�����֤ + "',");
            }
            if (model.Ч�� != null)
            {
                strSql1.Append("Ч��,");
                strSql2.Append("'" + model.Ч�� + "',");
            }
            if (model.Ч��ǩ�� != null)
            {
                strSql1.Append("Ч��ǩ��,");
                strSql2.Append("'" + model.Ч��ǩ�� + "',");
            }

            strSql.Append("insert into UFDLImport.._8D����(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return strSql.ToString();
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public string Update(TH.Model._8D���� model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UFDLImport.._8D���� set ");
            if (model.TaskID != null)
            {
                strSql.Append("TaskID=" + model.TaskID + ",");
            }
            else
            {
                strSql.Append("TaskID= null ,");
            }
            if (model.�鳤 != null)
            {
                strSql.Append("�鳤='" + model.�鳤 + "',");
            }
            else
            {
                strSql.Append("�鳤= null ,");
            }
            if (model.Ʒ�ܲ� != null)
            {
                strSql.Append("Ʒ�ܲ�='" + model.Ʒ�ܲ� + "',");
            }
            else
            {
                strSql.Append("Ʒ�ܲ�= null ,");
            }
            if (model.���̲� != null)
            {
                strSql.Append("���̲�='" + model.���̲� + "',");
            }
            else
            {
                strSql.Append("���̲�= null ,");
            }
            if (model.���첿 != null)
            {
                strSql.Append("���첿='" + model.���첿 + "',");
            }
            else
            {
                strSql.Append("���첿= null ,");
            }
            if (model.������� != null)
            {
                strSql.Append("�������='" + model.������� + "',");
            }
            if (model.�������ǩ�� != null)
            {
                strSql.Append("�������ǩ��='" + model.�������ǩ�� + "',");
            }
            if (model.����������� != null && model.����������� != DateTime.MinValue)
            {
                strSql.Append("�����������='" + model.����������� + "',");
            }
            if (model.��ʱ��ʩ != null)
            {
                strSql.Append("��ʱ��ʩ='" + model.��ʱ��ʩ + "',");
            }
            if (model.��ʱ��ʩ������ != null)
            {
                strSql.Append("��ʱ��ʩ������='" + model.��ʱ��ʩ������ + "',");
            }
            if (model.��ʱ��ʩ���ʱ�� != null && model.��ʱ��ʩ���ʱ�� != DateTime.MinValue)
            {
                strSql.Append("��ʱ��ʩ���ʱ��='" + model.��ʱ��ʩ���ʱ�� + "',");
            }
            if (model.��ʱ��ʩ�����֤ != null)
            {
                strSql.Append("��ʱ��ʩ�����֤='" + model.��ʱ��ʩ�����֤ + "',");
            }
            if (model.ԭ����� != null)
            {
                strSql.Append("ԭ�����='" + model.ԭ����� + "',");
            }
            if (model.������ʩ != null)
            {
                strSql.Append("������ʩ='" + model.������ʩ + "',");
            }
            if (model.������ʩ������ != null)
            {
                strSql.Append("������ʩ������='" + model.������ʩ������ + "',");
            }
            if (model.������ʩ���ʱ�� != null && model.������ʩ���ʱ�� != DateTime.MinValue)
            {
                strSql.Append("������ʩ���ʱ��='" + model.������ʩ���ʱ�� + "',");
            }
            if (model.������ʩ�����֤ != null)
            {
                strSql.Append("������ʩ�����֤='" + model.������ʩ�����֤ + "',");
            }
            if (model.Ԥ����ʩ != null)
            {
                strSql.Append("Ԥ����ʩ='" + model.Ԥ����ʩ + "',");
            }
            if (model.Ԥ����ʩ������ != null)
            {
                strSql.Append("Ԥ����ʩ������='" + model.Ԥ����ʩ������ + "',");
            }
            if (model.Ԥ����ʩ���ʱ�� != null && model.Ԥ����ʩ���ʱ�� != DateTime.MinValue)
            {
                strSql.Append("Ԥ����ʩ���ʱ��='" + model.Ԥ����ʩ���ʱ�� + "',");
            }
            if (model.Ԥ����ʩ�����֤ != null)
            {
                strSql.Append("Ԥ����ʩ�����֤='" + model.Ԥ����ʩ�����֤ + "',");
            }
            if (model.Ч�� != null)
            {
                strSql.Append("Ч��='" + model.Ч�� + "',");
            }
            if (model.Ч��ǩ�� != null)
            {
                strSql.Append("Ч��ǩ��='" + model.Ч��ǩ�� + "',");
            }
            if (model.�ٴ��ύ != null)
            {
                strSql.Append("�ٴ��ύ='" + model.�ٴ��ύ + "',");
            }
            if (model.�ٴ��ύ���� != null && model.�ٴ��ύ���� != DateTime.MinValue)
            {
                strSql.Append("�ٴ��ύ����='" + model.�ٴ��ύ���� + "',");
            }
           
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where IDHead=" + model.IDHead + " ");
            return strSql.ToString();
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

