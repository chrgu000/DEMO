using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ϵͳ����._1000_BaseSet
{
    public partial class FrmMailSet : ϵͳ����.FrmBaseInfo
    {
        ϵͳ����.ClsDataBase clsSQL = ϵͳ����.ClsDataBaseFactory.Instance();

        public FrmMailSet()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "save":
                        btnSave();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void FrmMailSet_Load(object sender, EventArgs e)
        {
            try
            {
                   
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ�ܣ�  " + ee.Message);
            }
        }
    }
}