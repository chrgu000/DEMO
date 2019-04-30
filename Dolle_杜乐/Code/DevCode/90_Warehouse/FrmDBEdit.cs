using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class FrmDBEdit : Form
    {
        public FrmDBEdit()
        {
            InitializeComponent();
        }

        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        public string sDepIn;
        public string sWhOut;
        public string sWhIn;
        public string sDepOut;
        public string sStyleOut;
        public string sStyleIn;
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEditDepIn.Text.Trim() == "")
                {
                    MessageBox.Show("转入部门不能为空！");
                    lookUpEditDepIn.Focus();
                    return;
                }
                if (lookUpEditDepOut.Text.Trim() == "")
                {
                    MessageBox.Show("转出部门不能为空！");
                    lookUpEditDepOut.Focus();
                    return;
                }
                if (lookUpEditWHOut.Text.Trim() == "")
                {
                    MessageBox.Show("转出仓库不能为空！");
                    lookUpEditWHOut.Focus();
                    return;
                }
                if (lookUpEditWHIn.Text.Trim() == "")
                {
                    MessageBox.Show("转入仓库不能为空！");
                    lookUpEditWHIn.Focus();
                    return;
                }
                if (lookUpEditRd_StyleOut.Text.Trim() == "")
                {
                    MessageBox.Show("出库类别不能为空！");
                    lookUpEditWHIn.Focus();
                    return;
                }
                if (lookUpEditRd_StyleIn.Text.Trim() == "")
                {
                    MessageBox.Show("入库类别不能为空！");
                    lookUpEditWHIn.Focus();
                    return;
                }

                sDepIn = lookUpEditDepIn.EditValue.ToString().Trim();
                sDepOut = lookUpEditDepOut.EditValue.ToString().Trim();

                sWhOut = lookUpEditWHOut.EditValue.ToString().Trim();
                sWhIn = lookUpEditWHIn.EditValue.ToString().Trim();

                sStyleOut = lookUpEditRd_StyleOut.EditValue.ToString().Trim();
                sStyleIn = lookUpEditRd_StyleIn.EditValue.ToString().Trim();

                DialogResult = DialogResult.OK;
                Close();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void FrmDBEdit_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select cDepCode,cDepName from @u8.Department where bDepEnd =1 order by cDepCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEditDepOut.Properties.DataSource = dt;
                lookUpEditDepIn.Properties.DataSource = dt;


                sSQL = "select cWhCode,cWhName from @u8.Warehouse order by cWhCode";
                dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEditWHOut.Properties.DataSource = dt;
                lookUpEditWHIn.Properties.DataSource = dt;

                sSQL = "select cRdCode,cRdName,bRdFlag from @u8.Rd_Style where bRdEnd = 1 and bRdFlag =1";
                dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEditRd_StyleIn.Properties.DataSource = dt;

                sSQL = "select cRdCode,cRdName,bRdFlag from @u8.Rd_Style where bRdEnd = 1 and bRdFlag =0";
                dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEditRd_StyleOut.Properties.DataSource = dt;


            }
            catch(Exception ee)
            {
                MessageBox.Show("获得基础资料失败！　\n    " + ee.Message);
            }
        }
    }
}