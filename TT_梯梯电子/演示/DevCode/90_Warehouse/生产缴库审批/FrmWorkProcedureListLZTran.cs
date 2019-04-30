using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FrameBaseFunction;

namespace Warehouse
{
    public partial class FrmWorkProcedureListLZTran : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        
        string sInvCode;
        public string sWorkCode;
        public string sWorkCodeNo;
        public long lAllocateId;
        public bool bLZ;

        public FrmWorkProcedureListLZTran(string sCode)
        {
            InitializeComponent();
            this.sInvCode = sCode;
        }

        private void FrmWorkProcedureListTran_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string sSQL = "select a.MoCode,b.SortSeq,b.SoCode,b.SoSeq,b.InvCode,e.cInvName,e.cInvStd,d.InvCode as cInvCode,c.AllocateId,b.Qty,b.QualifiedInQty, b.Qty - isnull(b.QualifiedInQty,0) as UnQualifiedInQty " +
                       "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId inner join @u8.mom_moallocate c on b.MoDId = c.MoDId inner join @u8.bas_part d on c.ComponentId = d.PartId inner join @u8.Inventory e on e.cInvCode = b.InvCode " +
                       "where d.InvCode = '" + sInvCode + "' and b.Status = 3 " +
                       "order by a.MoCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (gridView1.RowCount <= 0)
                {
                    bLZ = false;
                    MessageBox.Show("没有匹配单据，不能流转");
                    radioButton2.Checked = true;
                    return;
                }
                else
                {
                    bLZ = true;
                    int iRow = 0;
                    if (gridView1.RowCount > 0)
                        iRow = gridView1.FocusedRowHandle;
                    sWorkCode = gridView1.GetRowCellDisplayText(iRow, gridColMoCode).ToString().Trim();
                    sWorkCodeNo = gridView1.GetRowCellDisplayText(iRow, gridColSortSeq).ToString().Trim();
                    lAllocateId = Convert.ToInt64(gridView1.GetRowCellDisplayText(iRow, gridColAllocateId));
                }
                
            }
            if (radioButton2.Checked)
            {
                bLZ = false;
            }
            this.Close();
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }
    }
}