using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FrameBaseFunction
{
    public partial class FrmBuckUpDataBase : FrameBaseFunction.FrmFromModel
    {
        public FrmBuckUpDataBase()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "buckup":
                        BuckUpDataBase();
                        break;
                    case "autobuckup":
                        BuckUpDataBaseAuto();
                        break;
                    default:
                        break;
                }

                if (sBtnName.ToLower() == "add" || sBtnName.ToLower() == "edit")
                {
                    SetBtnEnable(false);
                }
                else
                {
                    SetBtnEnable(true);
                    SetConEnable(false);

                    if (sBtnName.ToLower() != "btnundo")
                        richTextBox1.Text = richTextBox1.Text + "���ݳɹ���    \n__________________________________________\n\n";
                }

            }
            catch (Exception ee)
            {
                richTextBox1.Text = richTextBox1.Text + "����ʧ�ܣ�    \n__________________________________________\n\n";
                MessageBox.Show(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuckUpDataBaseAuto()
        {
            
        }

        private void BuckUpDataBase()
        {
            if(!chkIsSer())
                throw new Exception("���ݲ���ֻ�������ڷ������У�");

            FrameBaseFunction.Query.ClsBuckUpDataBase clsBuckUp = new FrameBaseFunction.Query.ClsBuckUpDataBase();

            DateTime dTime = clsBuckUp.GetSerTime();
            string sFName = FrameBaseFunction.ClsBaseDataInfo.sDataBaseName + dTime.ToString("yyyyMMdd");//dTime.ToString("yyyyMMddHHmmss");

            SaveFileDialog sD = new SaveFileDialog();
            sD.AddExtension = false;
            sD.CheckFileExists = false;
            sD.DefaultExt = "bak";
            sD.Title = "�������ݿ�";

            sD.FileName = sFName;

            if (sD.ShowDialog() == DialogResult.OK)
            {

                clsBuckUp.BuckUpDataBase(sD.FileName);

                richTextBox1.Text = richTextBox1.Text + "�ļ����ƣ� " + sFName + " \n\n";
                richTextBox1.Text = richTextBox1.Text + "����·����" + sD.FileName + "\n\n";
                richTextBox1.Text = richTextBox1.Text + "�����У����Ժ�\n\n";
            }
            else
            {
                richTextBox1.Text = richTextBox1.Text + "������ȡ����\n\n";
                throw new Exception("������ȡ����");
            }
        }

        string sHostName = "";
        string sSerName = "";

        private bool chkIsSer()
        {

            bool b = false;

            try
            {
                if (sHostName != sSerName)
                {
                    throw new Exception("���ݲ���ֻ�������ڷ������У�");
                }

                b = true;
            }
            catch
            {
                throw new Exception("���ݲ���ֻ�������ڷ������У�");
            }

            return b;
        }

        private void GetName()
        {
            FrameBaseFunction.Query.ClsBuckUpDataBase clsBuckUp = new FrameBaseFunction.Query.ClsBuckUpDataBase();
            DataTable dt = clsBuckUp.GetSerHostName();

            sHostName = dt.Rows[0]["sHostName"].ToString().ToLower().Trim();
            sSerName = dt.Rows[0]["sSerName"].ToString().ToLower().Trim();
        }

        private void FrmBuckUpDataBase_Load(object sender, EventArgs e)
        {
            GetName();

            richTextBox1.BackColor = this.BackColor;
            richTextBox1.Text = "���ݲ���ֻ�������ڷ������ϣ�\n\n";

            if (sSerName == sHostName)
                richTextBox1.Text = richTextBox1.Text + "��֤ͨ�����Ա��ݣ�";
            else
            {
                richTextBox1.Text = richTextBox1.Text + "��֤δͨ������ȷ���ڷ����������У�";
                SetBtnEnable(false);
            }

            richTextBox1.Text = richTextBox1.Text + " \n__________________________________________\n\n";
               
        }
    }
}