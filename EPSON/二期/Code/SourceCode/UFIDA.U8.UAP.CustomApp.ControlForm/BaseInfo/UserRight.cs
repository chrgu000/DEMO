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
using DevExpress.XtraReports.UI;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class UserRight : UserControl
    {
        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

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
                labelUserID.Text = "";
                labelUserName.Text = "";

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

        public UserRight()
        {
            InitializeComponent();
        }

        private void GetGrid()
        {
            string sSQL = @"
select cUser_Id,cUser_Name,cDept from UA_User order by cUser_Id
";
            DataTable dtUser = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dtUser;
            gridView1.BestFitColumns();

            labelUserID.Text = "";
            labelUserName.Text = "";
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

        private void btnRefresh_Click(object sender, EventArgs e)
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

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                labelUserID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColcUser_ID).ToString().Trim();
                labelUserName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridcUser_Name).ToString().Trim();

                string sSQL = @"
select cast (case when b.MenuID is null then 0 else 1 end as bit) as Selected,a.MenuID,a.FormName,a.FormButton
from [dbo].[_MenuRight] a
	left join [dbo].[_UserRight] b on a.MenuID = b.MenuID and b.UserID = '{0}'
where 1=1
order by a.MenuID 
";
                sSQL = string.Format(sSQL, labelUserID.Text.Trim());
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl2.DataSource = dt;
                gridView2.BestFitColumns();
            }
            catch(Exception ee) 
            {
            
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
            try
            {
                string sUserID = labelUserID.Text.Trim();
                if(sUserID == "")
                {
                    throw new Exception("Please choose user");
                }

                int iCou = 0;
                SqlConnection conn = new SqlConnection(Conn);
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sSQL = @"

delete _UserRight where UserID = '{0}'
";
                    sSQL = string.Format(sSQL, sUserID);
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        bool b = BaseFunction.ReturnBool(gridView2.GetRowCellValue(i, gridColSelected));
                        if (!b)
                        {
                            continue;
                        }

                        sSQL = @"
insert into [_UserRight](UserID,MenuID)
values('{0}','{1}')
";
                        sSQL = string.Format(sSQL, sUserID, gridView2.GetRowCellValue(i, gridColMenuID).ToString().Trim());
                        iCou = DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (iCou > 0)
                    {
                        tran.Commit();

                        MessageBox.Show("OK");
                    }
                    else
                    {
                        MessageBox.Show("No data"); 
                    }
                }
                catch(Exception ee)
                {
                    tran.Rollback();

                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = ee.Message;
                frm.ShowDialog();
            }
        }

    }
}
