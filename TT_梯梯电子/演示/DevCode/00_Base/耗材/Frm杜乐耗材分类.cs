using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Base
{
    public partial class Frm���ֺĲķ��� : FrameBaseFunction.Frm�б���ģ��
    {  
        DataTable dtSel = new DataTable();
        int iPage = 0;
        ArrayList aList;
        string sSQL;

        public Frm���ֺĲķ���()
        {
            InitializeComponent();
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
                   
                    case "del":
                        btnDel();
                        break;
                    case "save":
                        btnSave();
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

        private void btnSave()
        {
            string sSQL = "";
            DataTable dtTemp = new DataTable();
            string sCode = txt�������.Text.Trim();
            if (sCode.Length == 2 || sCode.Length == 4 || sCode.Length == 6 || sCode.Length == 8)
            {
                string sUpCode = sCode.Substring(0, sCode.Length - 2);
                if (sCode.Length == 2)
                {
                    sUpCode = "0";
                }
                else
                {
                    sSQL = "select * from UFDLImport..InvcodeClassHC where cInvCCode = '" + sUpCode + "'";
                    dtTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        txt�������.Focus();
                        throw new Exception("�ϼ����벻����");
                    }
                }

                sSQL = "select count(1) from UFDLImport..InvcodeClassHC where cInvCCode = '" + sCode + "'";
                 dtTemp = clsSQLCommond.ExecQuery(sSQL);
                long iCou = ReturnObjectToLong(dtTemp.Rows[0][0]);
                if (iCou == 0)
                {
                    sSQL = "select count(1) from UFDLImport..InvcodeClassHC where cInvCName = '" + txt��������.Text.Trim() + "'";
                    dtTemp = clsSQLCommond.ExecQuery(sSQL);
                    iCou = ReturnObjectToLong(dtTemp.Rows[0][0]);
                    if (iCou > 0)
                    {
                        throw new Exception("���Ʋ����ظ�");
                    }

                    sSQL = "insert into UFDLImport..InvcodeClassHC(cInvCCode, cInvCName, cInvCCodeUp)" +
                        "values('" + sCode + "','" + txt��������.Text.Trim() + "','" + sUpCode + "')";
                }
                else
                {
                    sSQL = "update UFDLImport..InvcodeClassHC set cInvCName = '" + txt��������.Text.Trim() + "', cInvCCodeUp = '" + sUpCode + "' where cInvCCode = '" + sCode + "'";
                        
                }
                iCou = clsSQLCommond.ExecSql(sSQL);
                if (iCou == 1)
                {
                    MessageBox.Show("����ɹ�");
                    btnSel();
                }
                else
                {
                    MessageBox.Show("����ʧ��");
                }
            }
            else
            {
                txt�������.Focus();
                throw new Exception("������볤�Ȳ���ȷ");
            }
        }

        private void btnDel()
        {
            string sCCode = txt�������.Text.Trim();
            if (sCCode == "")
                throw new Exception("���벻��Ϊ��");

            string sSQL = "select count(1) from UFDLImport..InventoryHC where cInvCCode = '" + sCCode + "'";
            DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
            long iCou = ReturnObjectToLong(dtTemp.Rows[0][0]);
            if (iCou > 0)
            {
                throw new Exception("�����Ѿ�ʹ�ò���ɾ��");
            }
            sSQL = "select count(1) from UFDLImport..InvcodeClassHC where cInvCCodeUp = '" + sCCode + "'";
            dtTemp = clsSQLCommond.ExecQuery(sSQL);
            iCou = ReturnObjectToLong(dtTemp.Rows[0][0]);
            if (iCou > 0)
            {
                throw new Exception("�����¼����벻��ɾ��");
            }

            sSQL = "delete UFDLImport..InvcodeClassHC where cInvCCode = '" + sCCode + "'";
            iCou = clsSQLCommond.ExecSql(sSQL);

            if (iCou > 0)
            {
                MessageBox.Show("ɾ���ɹ�");
                btnSel();
            }
            else
            {

                MessageBox.Show("ɾ��ʧ��");
            }
        }

        private void btnSel()
        {
            txt�������.Enabled = true;
            txt��������.Enabled = true;
            txt�������.ReadOnly = false;
            txt��������.ReadOnly = false;
            SetTree();
            treView.ExpandAll();
        }

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


        DataTable dt = new DataTable();
        private void SetTree()
        {
            try
            {
                treView.Nodes.Clear();

                string sSQL = "SELECT * from UFDLImport..InvcodeClassHC order by cInvCCode";
                dt = clsSQLCommond.ExecQuery(sSQL);

                InitTree(treView.Nodes, "0");
      
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="Nds"></param>
        /// <param name="parentId"></param>
        private void InitTree(TreeNodeCollection Nds, string parentId)
        {
            try
            {
                DataView dv = new DataView();
                TreeNode tmpNd;
                dv.Table = dt;
                dv.RowFilter = "cInvCCodeUp='" + parentId + "'";
                foreach (DataRowView drv in dv)
                {
                    tmpNd = new TreeNode();
                    tmpNd.Name = drv["cInvCCode"].ToString().Trim();
                    tmpNd.Text = drv["cInvCName"].ToString().Trim();
                    tmpNd.Tag = drv["cInvCCodeUp"].ToString().Trim();
                    Nds.Add(tmpNd);
                    InitTree(tmpNd.Nodes, tmpNd.Name);
                }
            }
            catch
            {
                throw new Exception("����������ʧ�ܣ�");
            }
        }

        private void treView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Name.Trim() != null)
                {
                    txt�������.Text = e.Node.Name.Trim();
                    txt��������.Text = e.Node.Text.Trim();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}