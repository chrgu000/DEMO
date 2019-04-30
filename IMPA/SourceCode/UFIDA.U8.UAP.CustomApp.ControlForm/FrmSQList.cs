using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmSQList : Form
    {
        public string sSQCode;

        public FrmSQList(string sConnString)
        {
            InitializeComponent();

            DbHelperSQL.connectionString = sConnString;
        }

        private void SetLookup()
        {
            string sSQL = @"
select cCusCode,cCusName,cCusAddress,cCusPerson ,cCusPPerson ,cCusDepart   
from Customer 
order by cCusCode
";

            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditAC.Properties.DataSource = dt;
            lookUpEditCustomer.Properties.DataSource = dt;

            dtm1.DateTime = DateTime.Today.AddMonths(-1);
            dtm2.DateTime = DateTime.Today;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
 select p.cDepCode,dep.cDepName 
	,b.irowno,b.cInvCode,inv.cInvName,b.iQuantity,b.iNum,inv.cComUnitCode,unit.cComUnitName,cus.cCusName
    ,cus.cCusName,p.cDepCode,cus.cCusAddress 
	,case when isnull(b.iNum,0) <> 0 then b.iQuantity / b.iNum end as Ratio
	,b.inum,curr.iQty as ATP
	,b.iUnitPrice as ListPrice
	,b.cDefine26 as HistPrice
	,a.cDefine7 as Disc
	,b.cdefine27 as Nett
	,b.cDefine28 as Supp
	,b.cDefine35 as Cost
	,cast(a.cdefine9 as decimal(16,2)) as Markup
	,(b.iUnitPrice - cast(0 as decimal(16,2)))* b.iQuantity  as EstGP
	,b.cDefine25 as Ref
	,a.*
from SA_QuoMain a inner join SA_QuoDetails b on a.ID = b.id
	inner join Inventory inv on inv.cInvCode =b.cInvCode
    left join Customer cus on a.cCusCode = cus.cCusCode 
    left join Person p on p.cPersonCode = a.cPersonCode
	left join ComputationUnit unit on unit.cComunitCode = inv.cComUnitCode
	left join (select cinvCode ,sum(iQuantity) as iQty from CurrentStock group by cinvCode) Curr on Curr.cInvCode = b.cInvCode
	left join department dep on p.cDepCode = dep.cDepCode
where 1=1
order by a.ccode, b.irowno
";
                if (txtSQ.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cCode like '%" + txtSQ.Text.Trim() + "%'");
                }
                if (dtm1.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dDate >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (dtm2.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dDate < '" + dtm2.DateTime.AddDays(1).ToString("yyyy-MM-dd") + "'");
                }
                if (lookUpEditAC.EditValue != null && lookUpEditAC.Text.Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cCusCode = '" +lookUpEditAC.EditValue.ToString().Trim()+ "'");
                }

                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControlSQ.DataSource = dt;

                gridViewSQ.BestFitColumns();
            }
            catch { }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                sSQCode = gridViewSQ.GetRowCellValue(gridViewSQ.FocusedRowHandle, gridColcCode).ToString().Trim();

                if(sSQCode!="")
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch { }
        }

        private void lookUpEditAC_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditCustomer.EditValue = lookUpEditAC.EditValue;
            }
            catch { }
        }

        private void lookUpEditCustomer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditAC.EditValue = lookUpEditCustomer.EditValue;
            }
            catch { }
        }

        private void gridViewSQ_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }

        private void gridViewSQ_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOK_Click(null, null);
            }
            catch { }
        }

        private void FrmSQList_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookup();
            }
            catch { }
        }
    }
}
