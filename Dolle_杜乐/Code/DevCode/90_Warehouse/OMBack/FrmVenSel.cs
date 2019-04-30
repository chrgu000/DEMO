using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Warehouse.OMBack
{
    public partial class frmVenSel : Form
    {
        public string VenCode = "";
        public string VenName = "";
        private string _invCode = "";
        public frmVenSel(string invCode)
        {
            InitializeComponent();
            _invCode = invCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grvDetail.SelectedRowsCount == 0)
            {
                MessageBox.Show("请选择供应商");
                return;
            }
            VenCode = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colVenCode).ToString();
            VenName = grvDetail.GetRowCellValue(grvDetail.FocusedRowHandle, colVenName).ToString();
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmVenSel_Load(object sender, EventArgs e)
        {
            GetVenList();
        }

        private void GetVenList()
        {
            string sql =@"
                    select  v.cVenCode ,
                            v.cVenName
                    from    dbo.PO_Pomain P
                            left join dbo.PO_Podetails D on P.POID = D.POID
                            left join dbo.Vendor V on p.cVenCode = v.cVenCode
                    where   d.cInvCode = '{0}'
                    group by v.cVenCode ,
                            v.cVenName
                    union 
                    select  v.cVenCode ,
                            v.cVenName
                    from    dbo.OM_MOMain P
                            left join dbo.OM_MODetails D on P.MOID = D.MOID
                            left join dbo.Vendor V on p.cVenCode = v.cVenCode
                    where   d.cInvCode = '{0}'
                    group by v.cVenCode ,
                            v.cVenName
";
            sql = string.Format(sql, _invCode);
            DataTable dt = SqlHelper.ExecuteDataset(Assistanter.U8ConnectString, CommandType.Text, sql).Tables [0];
            grdDetail.DataSource = dt;
            
        }

        private void grvDetail_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }
    }
}
