using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace ImportDLL
{
    public partial class Frm存货工艺路线 : Form
    {
        
        TH.DAL.ProcessRoute DAL = new TH.DAL.ProcessRoute();
        public string s版本 = "";
        string sInvCode;
        public Frm存货工艺路线(string scInvCode)
        {
            InitializeComponent();

            sInvCode = scInvCode;
        }

       
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = DAL.GetListInvCode(sInvCode);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                s版本 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridCol版本).ToString().Trim();
                if (s版本 != "")
                    this.DialogResult = DialogResult.OK;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(null, null);
        }

    }
}
