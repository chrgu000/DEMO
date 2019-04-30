using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 系统服务._1000_BaseSet
{
    public partial class FrmMailSet : 系统服务.FrmBaseInfo
    {
        系统服务.ClsDataBase clsSQL = 系统服务.ClsDataBaseFactory.Instance();

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
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("加载窗体失败！  " + ee.Message);
            }
        }
    }
}