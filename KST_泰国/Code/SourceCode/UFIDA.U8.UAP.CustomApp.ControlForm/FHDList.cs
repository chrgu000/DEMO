using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TH.BaseClass;
using System.Data.SqlClient;
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FHDList : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }


        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = DateTime.Today.AddDays(-7);
                dateEdit2.DateTime = DateTime.Today;

                DbHelperSQL.connectionString = Conn;

                GetGrid();
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }


        public FHDList()
        {
            InitializeComponent();
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


        private void btnReflash_Click(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void GetGrid()
        {
            string sSQL = @"
select cDefine10 as ProjectName,cDefine11 as ContackInfo,cDefine4 as PickUpdate,cDefine2 as PickUpTime,cus.cCusName,a.cDefine3 as SiteQty
	,* 
	,case when ISNULL(cVerifier,'') = '' then 'Saved' when b.iCou > 0 and ISNULL(cVerifier,'') <> '' then 'Audit' else 'Closed' end as [Status]
from DispatchList a inner join Customer cus on a.cCusCode = cus.cCusCode
	left join (select count(1) as iCou,DLID from DispatchLists where isnull(fOutQuantity ,0) < isnull(iquantity,0) group by DLID) b on a.DLID = b.DLID
where dDate >= 'aaaaaa' and dDate < 'bbbbbb'    and isnull(a.cDefine15,0) = 1
order by cDLCode desc
";
            sSQL = sSQL.Replace("aaaaaa", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("bbbbbb", dateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd"));
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            gridView1.BestFitColumns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmFHDEdit frm = new FrmFHDEdit(DbHelperSQL.connectionString, sUserID, sUserName, sAccID, BaseFunction.ReturnDate(sLogDate), 1, "");
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColcDLCode).ToString().Trim();
                if (sCode == "")
                {
                    throw new Exception("Please choose data");
                }

                FrmFHDEdit frm = new FrmFHDEdit(DbHelperSQL.connectionString, sUserID, sUserName, sAccID, BaseFunction.ReturnDate(sLogDate), 2, sCode);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel(*.xls)|*.xls|All files(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("OK\n\tPath：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "Export Excel Err";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }
    }
}
