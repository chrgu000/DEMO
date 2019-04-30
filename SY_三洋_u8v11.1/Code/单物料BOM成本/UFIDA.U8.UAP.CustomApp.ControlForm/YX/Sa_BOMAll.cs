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


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Sa_BOMAll : UserControl
    {

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        public Sa_BOMAll()
        {
            InitializeComponent();
        }


        private void ProjectManager_Load(object sender, EventArgs e)
        {
            try
            {
                
                dateEdit1.Text = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                dateEdit2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ////GetLookUp();
                //double o1 = 1.100101;
                //double o2 = 1.10011;
                //double o3 = 1.10014;
                //textEdit2.Text = ���.����һ��(o1).ToString();
                //textEdit3.Text = ���.����һ��(o2).ToString();
                //textEdit4.Text = ���.����һ��(o3).ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show("��������ʧ��");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetGrid();
        }

        private void GetGrid()
        {
            try
            {
                if (buttonEditInvCode.Text == "")
                {
                    MessageBox.Show("������벻��Ϊ��");
                }
                else
                {
                    treeList1.Nodes.Clear();
                    if (dateEdit1.Text != "" && dateEdit1.Text != "")
                    {
                        Projects projects = Sa_BOMAllBLL.GetFormsData(Conn, buttonEditInvCode.Text, cmb����.Text, cmb����2.Text, dateEdit1.DateTime, dateEdit2.DateTime);

                        treeList1.DataSource = projects;
                        treeList1.BestFitColumns();
                        //treeList1.ExpandAll();
                        if (treeList1.Nodes.Count > 0)
                        {
                            GetCS(Sa_BOMAllBLL.type);
                            for (int i = 0; i < treeList1.Nodes.Count; i++)
                            {
                                GetOpen(treeList1.Nodes[i], 1);
                            }
                            if (Sa_BOMAllBLL.hasprice > 0)
                            {
                                MessageBox.Show("����" + Sa_BOMAllBLL.hasprice.ToString() + "��û�м۸�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("û���κ�����", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("��ѡ��Ʊ��������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //treeList1.ExpandAll();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetCS(int c)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("��");
            for (int i = 1; i < c; i++)
            {
                DataRow dw = dt.NewRow();
                dw[0] = i.ToString();
                dt.Rows.Add(dw);
            }
            lookUp����.Properties.DataSource = dt;
            lookUp����.EditValue = "2";

        }


        private void GetOpen(DevExpress.XtraTreeList.Nodes.TreeListNode tn,int t)
        {
            if (lookUp����.EditValue != "")
            {
                if (t < double.Parse(lookUp����.EditValue.ToString()))
                {
                    tn.Expanded = true;
                }
                else
                {
                    tn.Expanded = false;
                }
                for (int i = 0; i < tn.Nodes.Count; i++)
                {
                    DevExpress.XtraTreeList.Nodes.TreeListNode tnn = tn.Nodes[i];
                    
                    GetOpen(tnn, t + 1);
                }
            }
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
                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel�ļ�2003|*.xls";
                sa.FileName = Sa_BOMAllBLL.exlname;

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        treeList1.ExportToXls(sPath);
                        MessageBox.Show("�����б�ɹ���\n·����" + sPath);
                    }
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("�����б�ʧ�ܣ�" + ee.Message);
            }
        }

        private void cmb����_EditValueChanged(object sender, EventArgs e)
        {
            if (cmb����.Text == "�ο��ɱ�")
            {
                cmb����2.Visible = false;
            }
            else
            {
                cmb����2.Visible = true;
            }
            if (cmb����.Text == "��Ʊ����")
            {
                for (int i = cmb����2.Properties.Items.Count - 1; i >= 0; i--)
                {
                    cmb����2.Properties.Items.Remove(cmb����2.Properties.Items[i]);
                }
                cmb����2.Properties.Items.AddRange(new object[] { "��߼�", "ƽ����", "���¼�" });
            }
            else
            {
                for (int i = cmb����2.Properties.Items.Count - 1; i >= 0; i--)
                {
                    cmb����2.Properties.Items.Remove(cmb����2.Properties.Items[i]);
                }
                cmb����2.Properties.Items.AddRange(new object[] { "��߼�", "ƽ����" });
            }
        }

        //private void lookUp�������_EditValueChanged(object sender, EventArgs e)
        //{
        //    lookUp�������.EditValue = lookUp�������.EditValue;
        //    lookUp����ͺ�.EditValue = lookUp�������.EditValue;
        //}

        //private void lookUp�������_EditValueChanged(object sender, EventArgs e)
        //{
        //    lookUp�������.EditValue = lookUp�������.EditValue;
        //    lookUp����ͺ�.EditValue = lookUp�������.EditValue;
        //}

        //private void lookUp����ͺ�_EditValueChanged(object sender, EventArgs e)
        //{
        //    lookUp�������.EditValue = lookUp����ͺ�.EditValue;
        //    lookUp�������.EditValue = lookUp����ͺ�.EditValue;
        //}

        private void lookUp����_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < treeList1.Nodes.Count; i++)
                {
                    GetOpen(treeList1.Nodes[i], 1);
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("��״չ��ʧ��:" + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEditInvCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo fInv = new FrmInvInfo(buttonEditInvCode.Text, Conn,true);
                if (DialogResult.OK == fInv.ShowDialog())
                {
                    buttonEditInvCode.Text = fInv.sInvCode;
                    buttonEditInvName.Text = fInv.sInvName;
                    buttonEditInvStd.Text = fInv.sInvStd;
                }
                else
                {
                    buttonEditInvCode.Text = "";
                    buttonEditInvName.Text = "";
                    buttonEditInvStd.Text = "";
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEditInvName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo fInv = new FrmInvInfo(buttonEditInvCode.Text, Conn,true);
                if (DialogResult.OK == fInv.ShowDialog())
                {
                    buttonEditInvCode.Text = fInv.sInvCode;
                    buttonEditInvName.Text = fInv.sInvName;
                    buttonEditInvStd.Text = fInv.sInvStd;
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEditInvStd_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                FrmInvInfo fInv = new FrmInvInfo(buttonEditInvCode.Text, Conn,true);
                if (DialogResult.OK == fInv.ShowDialog())
                {
                    buttonEditInvCode.Text = fInv.sInvCode;
                    buttonEditInvName.Text = fInv.sInvName;
                    buttonEditInvStd.Text = fInv.sInvStd;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEditInvCode_Validated(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select cInvCode,cInvName,cInvStd from Inventory ";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
                string[] split = buttonEditInvCode.EditValue.ToString().Split(',');
                string cInvName = "";
                string cInvStd = "";
                for (int i = 0; i < split.Length; i++)
                {
                    DataRow[] dw = dt.Select("cInvCode='" + split[i].Trim() + "'");
                    if (dw.Length > 0)
                    {
                        if (cInvName != "")
                        {
                            cInvName = cInvName + ",";
                            cInvStd = cInvStd + ",";
                        }
                        cInvName = cInvName + dw[0]["cInvName"].ToString();
                        cInvStd = cInvStd + dw[0]["cInvStd"].ToString();

                    }
                }
                if (cInvName != "")
                {
                    buttonEditInvName.Text = cInvName;
                    buttonEditInvStd.Text = cInvStd;
                }
                else
                {
                    buttonEditInvName.Text = "";
                    buttonEditInvStd.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}