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
        TH.BaseClass.ClsDES clsDES = TH.BaseClass.ClsDES.Instance();

        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();

        string sProPath = Application.StartupPath;

        UFIDA.U8.UAP.CustomApp.ControlForm.RepBaseGrid Rep = new RepBaseGrid();

        string sState = "";

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
                btnRefresh_Click(null, null);
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




        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "";
                label2.Text = "";

                string sSQL = @"
select a.cUser_Id as UserID,a.cUser_Name as UserName
from  UFSystem..UA_User a 
	left join dbo._User b on a.cUser_id = b.UserID
where 1=1 and a.cUser_Id in (select UserID from _User) and isnull(b.EndDate,'2099-12-31') > getdate()
order by a.cUser_Id
";
               
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;

                chkAll.Checked = false;

                sSQL = @"
select cast(0 as bit) as choose, * from _Form
order by FormID
";

                DataTable  dtForm = DbHelperSQL.Query(sSQL);
                gridControl2.DataSource = dtForm;
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载数据失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    gridView2.SetRowCellValue(i, gridCol_choose, chkAll.Checked);
                }
            }
            catch { }
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
                string sErr = "";

                int iCou = 0;
                DataTable dtGrid = (DataTable)gridControl1.DataSource;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    if (label1.Text.Trim() == "")
                        throw new Exception("请选择帐号");

                    string sSQL = "delete dbo._UserRight where UserID = '" + label1.Text.Trim() + "'";
                    iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView2.GetRowCellValue(i, gridCol_choose)))
                        {
                            continue;
                        }

                        sSQL = "insert into _UserRight(UserID,FormID)values('" + label1.Text.Trim() + "','" + gridView2.GetRowCellValue(i, gridCol_FormID).ToString().Trim() + "')";
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);                 
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("保存成功");
                    }

                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "保存数据失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                chkAll.Checked = false;
                chkAll_CheckedChanged(null, null);

                int iRow = gridView1.FocusedRowHandle;
                label1.Text = gridView1.GetRowCellValue(iRow, gridColUserID).ToString().Trim();
                label2.Text = gridView1.GetRowCellValue(iRow, gridColUserName).ToString().Trim();

                string sSQL = "select * from _UserRight where UserID = '" + label1.Text.Trim() + "'";
                DataTable dt = DbHelperSQL.Query(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sForm = dt.Rows[i]["FormID"].ToString().Trim();

                        for (int j = 0; j < gridView2.RowCount; j++)
                        {
                            string sForm2 = gridView2.GetRowCellValue(j, gridCol_FormID).ToString().Trim();
                            if (sForm2 == sForm)
                            {
                                gridView2.SetRowCellValue(j, gridCol_choose, true);
                                continue;
                            }
                        }
                    }
                }
            }
            catch { }
        }
    }
}
