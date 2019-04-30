using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmJournalVoucher : Form
    {
        public FrmJournalVoucher()
        {
            InitializeComponent();
        }

        public DataTable dtGrid;
        private void FrmJournalVoucher_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dtGrid = (DataTable)gridControl1.DataSource;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
