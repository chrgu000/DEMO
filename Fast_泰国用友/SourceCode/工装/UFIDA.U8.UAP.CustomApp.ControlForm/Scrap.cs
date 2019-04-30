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

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class Scrap : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        clsUserRigth clsUserRight = new clsUserRigth();
        
        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        public DateTime dSerToday { get; set; }

        public string Conn { get; set; }

        public string sUserID { get; set; }

        public string sUserName { get; set; }

        public string sLogDate { get; set; }

        public string sAccID { get; set; }

        private void SetLookUp()
        {
            string sSQL = @"
select cCode from _Scrap order by cCode
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditCode1.Properties.DataSource = dt;
            lookUpEditCode2.Properties.DataSource = dt;

            sSQL = @"
select cPersonCode,cPersonName from Person order by cPersonCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditPerson.Properties.DataSource = dt;

            sSQL = @"
select cDepCode,cDepName from Department where bDepEnd = 1 order by cDepCode
";
            dt = DbHelperSQL.Query(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditDep.Properties.DataSource = dt;

            dtm1.DateTime = DateTime.Today.AddMonths(-1);
            dtm2.DateTime = DateTime.Today;

            //iState 0 新增,1 可用，2 已领用，3 维修，4 报废
            sSQL = @"
select SerialNo,InvName,InvStd from _FrockClamp order by SerialNo
";
            dt = DbHelperSQL.Query(sSQL);
            ItemLookUpEditInvName.DataSource = dt;
            ItemLookUpEditInvStd.DataSource = dt;
            ItemLookUpEditSerialNo.DataSource = dt;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                DbHelperSQL.connectionString = Conn;
                SetLookUp();
                GetGrid();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public Scrap()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 7090))
                    throw new Exception("没有权限");

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "导出Excel失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
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

        private void GetGrid()
        {
            int iRow = gridView1.FocusedRowHandle;

            string sSQL = @"
select cast(0 as bit) as bChoose, a.[GUID],a.iID,a.cCode,a.dDate,a.Person,a.DepCode,a.Remark,a.CreateUserName,a.CreateDate,a.AuditUserName,a.AuditDate
	,b.GUIDHead,b.iID as iIDDetails,b.SerialNo,b.Remark as Remarks
from [dbo].[_Scrap] a inner join [dbo].[_Scraps] b on a.[cCode] = b.cCode
where 1=1
order by a.iID,b.iID
";
            if (lookUpEditCode1.EditValue != null && lookUpEditCode1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCode >=N '" + lookUpEditCode1.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEditCode2.EditValue != null && lookUpEditCode2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cCode <=N '" + lookUpEditCode2.EditValue.ToString().Trim() + "'");
            }
            if (dtm1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate >= N'" + dtm1.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (dtm2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.dDate <= N'" + dtm2.DateTime.ToString("yyyy-MM-dd") + "'");
            }
            if (lookUpEditPerson.EditValue != null && lookUpEditPerson.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.Person = N'" + lookUpEditPerson.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEditDep.EditValue != null && lookUpEditDep.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.DepCode = N'" + lookUpEditDep.EditValue.ToString().Trim() + "'");
            }
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            gridView1.FocusedRowHandle = iRow;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 7010))
                    throw new Exception("没有权限");

                GetGrid();
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        
        private void btnDEL_Click(object sender, EventArgs e)
        {

            try
            {
                if (!clsUserRight.chkRight(sUserID, 7040))
                    throw new Exception("没有权限");

                string sErr = "";
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                int iCou = 0;

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColcCode).ToString().Trim();
                    if (sCode == "")
                        throw new Exception("no data");

                    string sSQL = "select * from _Scrap where cCode = N'111111'";
                    sSQL = sSQL.Replace("111111", sCode);
                    DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                    if (dt == null && dt.Rows.Count == 0)
                    {
                        throw new Exception("单据不存在");
                    }

                    if (dt.Rows[0]["AuditUserName"].ToString().Trim() != "")
                    {
                        throw new Exception("单据已审核");
                    }

                    sSQL = "delete _Scraps where cCode = N'111111' ";
                    sSQL = sSQL.Replace("111111", sCode);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    sSQL = "delete _Scrap where cCode = N'111111' ";
                    sSQL = sSQL.Replace("111111", sCode);
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("OK\n");

                        GetGrid();
                    }
                    else
                    {
                        throw new Exception("no data");
                    }
                }
                catch(Exception ee) 
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 7020))
                    throw new Exception("没有权限");

                Scrap_Edit frm = new Scrap_Edit(Conn, "");
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.sUserName = this.sUserName;
                frm.sUserID = this.sUserID;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    GetGrid();
                }
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
                if (!clsUserRight.chkRight(sUserID, 7030))
                    throw new Exception("没有权限");

                string sCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColcCode).ToString().Trim();
                if (sCode == "")
                {
                    throw new Exception("请选择单据");
                }

                Scrap_Edit frm = new Scrap_Edit(Conn, sCode);
                frm.sUserName = this.sUserName;
                frm.sUserID = this.sUserID;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    GetGrid();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnEdit_Click(null, null);

                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEditPerson_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select cDepCode  from person 
";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt.Rows.Count > 0)
                {
                    lookUpEditDep.EditValue = dt.Rows[0][0].ToString();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
    }
}
