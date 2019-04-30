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
    public partial class UserRight : UserControl
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

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                labelUid.Text = "";
                labelUserName.Text = "";

                DbHelperSQL.connectionString = Conn;

                GetGrid();
            }
            catch
            { 
            
            }
        }

        public UserRight()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 1020))
                    throw new Exception("没有权限");

                string sErr = "";
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string UserID = labelUid.Text.Trim();
                    if (UserID == "")
                    {
                        throw new Exception("请选择账号");
                    }

                    string sSQL = "delete _UserRight where UserID = N'111111'";
                    sSQL = sSQL.Replace("111111", UserID);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int j = 0; j < gridView2.RowCount; j++)
                    {
                        bool bBtn = BaseFunction.ReturnBool(gridView2.GetRowCellValue(j, gridColbChoose));
                        if (!bBtn)
                            continue;

                        sSQL = @"
insert into _UserRight(UserID, BtnID)
values(N'111111',N'222222')                            
                            ";
                        sSQL = sSQL.Replace("111111", UserID);
                        sSQL = sSQL.Replace("222222", gridView2.GetRowCellValue(j, gridColBtnID).ToString().Trim());
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    tran.Commit();

                    MessageBox.Show("保存成功");
                }
                catch (Exception ee)
                {
                    tran.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL = @"
select cast(0 as bit) as bChoose, cUser_Id as UserUid,cUser_Name as UserName,nState  from [UFSystem]..UA_User where isnull(nState,0) = 0 order by cUser_ID
";
            DataTable dt = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dt;

            sSQL = @"

select cast(case when isnull(b.BtnID,0) = 0 then 0 else 1 end as bit) as bChoose
	, a.* 
from _FormBtn a
	left join _UserRight b on a.BtnID = b.BtnID and b.UserID = N'111111'
where 1=1
ORDER BY a.OrderID,a.BtnID

";
            sSQL = sSQL.Replace("111111", labelUid.Text.Trim());
            dt = DbHelperSQL.Query(sSQL);
            gridControl2.DataSource = dt;
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 1010))
                    throw new Exception("没有权限");

                GetGrid();
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
                int iFocRow = gridView1.FocusedRowHandle;

                labelUid.Text = gridView1.GetRowCellValue(iFocRow, gridCol_UserUid).ToString().Trim();
                labelUserName.Text = gridView1.GetRowCellValue(iFocRow, gridCol_UserName).ToString().Trim();

                string sSQL = @"

select cast(case when isnull(b.BtnID,0) = 0 then 0 else 1 end as bit) as bChoose
	, a.* 
from _FormBtn a
	left join _UserRight b on a.BtnID = b.BtnID and b.UserID = N'111111'
where 1=1
ORDER BY a.BtnID
";
                sSQL = sSQL.Replace("111111", labelUid.Text.Trim());
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl2.DataSource = dt;
            }
            catch { }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsUserRight.chkRight(sUserID, 1090))
                    throw new Exception("没有权限");

                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView2.ExportToXls(sF.FileName);
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
    }
}
