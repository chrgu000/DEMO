using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;



namespace Smartclient
{
    public partial class FrmCheckVouchBarCodeList : FrmBase
    {


        public DataTable dtGrid = new DataTable();

        public FrmCheckVouchBarCodeList()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                labelBarCodeCount.Text = dtGrid.Rows.Count.ToString().Trim();

                dataGrid1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
                {
                    if (dataGrid1.IsSelected(i))
                    {
                        dtGrid.Rows.RemoveAt(i);
                        labelBarCodeCount.Text = dtGrid.Rows.Count.ToString();
                        break;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("删行失败:" + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnEnSure_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}