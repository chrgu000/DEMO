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
    public partial class FrmRDInPuSEL : Form
    {
        public string sCode = "";
        public string sConnString = "";
        public DataTable dt;

        public FrmRDInPuSEL()
        {
            InitializeComponent();
        }

        private void FrmRDInPuSEL_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = sConnString;

                SetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = @"
select cWhCode,cWhName from WareHouse order by cWhCode
            ";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditWH1.Properties.DataSource = dt;
            lookUpEditWH2.Properties.DataSource = dt;
            ItemLookUpEdit仓库.DataSource = dt;

            sSQL = @"
select cDepCode ,cDepName from department where bDepEnd = 1 order by cDepCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditDep1.Properties.DataSource = dt;
            lookUpEditDep2.Properties.DataSource = dt;
            ItemLookUpEdit部门.DataSource = dt;

            sSQL = @"
select cCode from PU_ArrivalVouch  order by cCode 
";//where isnull(cverifier,'') <> ''
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcCode1.Properties.DataSource = dt;
            lookUpEditcCode2.Properties.DataSource = dt;

            sSQL = @"
select cPOID from PO_Pomain  order by cPOID 
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditPOID1.Properties.DataSource = dt;
            lookUpEditPOID2.Properties.DataSource = dt;

            sSQL = @"
select cInvCode,cInvName from Inventory  order by cInvCode 
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcInvName1.Properties.DataSource = dt;
            lookUpEditcInvName2.Properties.DataSource = dt;

            dtm1.DateTime = DateTime.Today;
            dtm2.DateTime = DateTime.Today;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                bool b = false;
                sCode = "";
                for (int i = gridView1.RowCount - 1; i >= 0; i--)
                {
                    if (BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose)))
                    {
                        b = true;
                        if (sCode == "")
                        {
                            sCode = gridView1.GetRowCellValue(i, gridColcCode).ToString().Trim();
                        }
                        else
                        {
                            if (sCode != gridView1.GetRowCellValue(i, gridColcCode).ToString().Trim())
                            {
                                throw new Exception("请选择同一到货单");
                            }
                        }
                    }
                }
                if (b == true)
                {
                    for (int i = gridView1.RowCount - 1; i >= 0; i--)
                    {
                        if (BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColbChoose))==false)
                        {
                            gridView1.DeleteRow(i);
                        }
                    }
                }
                dt = (DataTable)gridControl1.DataSource;
                
                if (b == true)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new Exception("请选择单据");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select cast(0 as bit) as 选择, a.cCode,a.cDepCode,a.ID,a.cPersonCode,a.cMemo
,p.cPersonName,cOrderCode ,d.cPOID,a.dDate,b.cFree1,b.cFree2 ,b.cInvCode,i.cInvName
from PU_ArrivalVouch a inner join PU_ArrivalVouchs b on a.id = b.id
left join Inventory i on b.cInvCode=i.cInvCode
LEFT JOIN Person P ON a.cPersonCode=p.cPersonCode
left join PO_Podetails c on b.iPOsID =c.ID 
left join PO_Pomain d on c.POID=d.POID
where isnull(a.cCloser,'') = '' and 1=1 and (case when b.iNum>0 then b.iNum - isnull(fValidInNum,0) else b.iQuantity - isnull(fValidInQuan,0) end) >0  group by a.cCode,a.cDepCode,a.ID,a.cPersonCode,a.cMemo,p.cPersonName,cOrderCode,d.cPOID,a.dDate,b.cFree1,b.cFree2 ,b.cInvCode,i.cInvName
order by a.ID 
";
//                ,isnull(b.iQuantity,0) - isnull(fValidInQuan,0)-isnull(fRefuseQuantity,0)  as UniQty
//,isnull(b.iNum,0)-isnull(b.fValidInNum,0)-isnull(b.fRefuseNum,0)  as UniNum
//,isnull(cDefine26,0) as iSumQty,p.cPersonName
                if (lookUpEditcCode1.EditValue != null && lookUpEditcCode1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cCode >= '" + lookUpEditcCode1.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditcCode2.EditValue != null && lookUpEditcCode2.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cCode <= '" + lookUpEditcCode2.EditValue.ToString().Trim() + "'");
                }
                if (dtm1.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dDate >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                
                if (lookUpEditcInvName1.EditValue != null && lookUpEditcInvName1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode >= '" + lookUpEditcInvName1.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditcInvName2.EditValue != null && lookUpEditcInvName2.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode <= '" + lookUpEditcInvName2.EditValue.ToString().Trim() + "'");
                }
                if (dtm1.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dDate >= '" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
                }

                if (dtm2.Text != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and dDate <= '" + dtm2.DateTime.ToString("yyyy-MM-dd") + "'");
                }
                if (!chk包含已生单.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.iQuantity,0) - isnull(fValidInQuan,0)-isnull(fRefuseQuantity,0) >0 ");
                }
                if (lookUpEditDep1.EditValue != null && lookUpEditDep1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and a.cDepCode = '" + lookUpEditDep1.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditWH1.EditValue != null && lookUpEditWH1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cWhCode = '" + lookUpEditWH1.EditValue.ToString().Trim() + "'");
                }

                if (lookUpEditPOID1.EditValue != null && lookUpEditPOID1.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and d.cPOID >= '" + lookUpEditPOID1.EditValue.ToString().Trim() + "'");
                }
                if (lookUpEditPOID2.EditValue != null && lookUpEditPOID2.EditValue.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and d.cPOID <= '" + lookUpEditPOID2.EditValue.ToString().Trim() + "'");
                }

                if (txt长度.Text != null && txt长度.Text.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree2 = '" + txt长度.Text.ToString().Trim() + "'");
                }
                if (txt宽度.Text != null && txt宽度.Text.ToString().Trim() != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and b.cFree1 = '" + txt宽度.Text.ToString().Trim() + "'");
                }


                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEditWH1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditWH2.EditValue = lookUpEditWH1.EditValue;
        }

        private void lookUpEditWH2_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditWH1.EditValue = lookUpEditWH2.EditValue;
        }

        private void lookUpEditDep1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditDep2.EditValue = lookUpEditDep1.EditValue;
        }

        private void lookUpEditDep2_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditDep1.EditValue = lookUpEditDep2.EditValue;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnOK_Click(null, null);
            }
            catch { }
        }

        private void lookUpEditcCode1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCode2.EditValue = lookUpEditcCode1.EditValue;
        }

        private void lookUpEditcCode2_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditcCode1.EditValue = lookUpEditcCode2.EditValue;
        }

        private void lookUpEditPOID1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditPOID2.EditValue = lookUpEditPOID1.EditValue;
        }

        private void lookUpEditPOID2_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditPOID1.EditValue = lookUpEditPOID2.EditValue;
        }

    }
}
