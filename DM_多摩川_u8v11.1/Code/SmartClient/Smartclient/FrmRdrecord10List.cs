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
    public partial class FrmRdrecord10List : FrmBase
    {
        public DataTable dtGrid = new DataTable();

        public FrmRdrecord10List()
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}