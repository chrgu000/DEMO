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
    public partial class SmartUser : UserControl
    {
        TH.BaseClass.ClsDES clsDES = TH.BaseClass.ClsDES.Instance();

        TH.BaseClass.GetBaseData getBaseData = new GetBaseData();
        DAL_SmartUser DAL = new DAL_SmartUser();
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
            }
            catch (Exception ee)
            {
                FrmMsgBox f = new FrmMsgBox();
                f.Text = "加载窗体失败";
                f.richTextBox1.Text = ee.Message;
                f.ShowDialog();
            }
        }

        public SmartUser()
        {
            InitializeComponent();
        }




        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
select cast(0 as bit) as choose,a.cUser_Id as UserID,a.cUser_Name as UserName,b.Pwd,b.Pwd as RePwd,b.EndDate
    ,cast(case when isnull(b.UserID,'') = '' then 0 else 1 end as bit) as bUser
from  UFSystem..UA_User a 
	left join dbo._User b on a.cUser_id = b.UserID
where 1=1
order by a.cUser_Id
";
                if (radioSmartUser.Checked)
                {
                    sSQL = sSQL.Replace("1=1", "a.cUser_Id in (select UserID from _User)");
                }

                DataTable dt = DbHelperSQL.Query(sSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sPwd = dt.Rows[i]["Pwd"].ToString().Trim();
                    if (sPwd != "")
                    {
                        dt.Rows[i]["Pwd"] = clsDES.Decrypt(sPwd);
                        dt.Rows[i]["RePwd"] = dt.Rows[i]["Pwd"];
                    }
                }

                gridControl1.DataSource = dt;

                chkAll.Checked = false;
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
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColchoose, chkAll.Checked);
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
                string sErr = "";

                int iCou = 0;
                DataTable dtGrid = (DataTable)gridControl1.DataSource;
                SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (!BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridColchoose)))
                        {
                            continue;
                        }

                        if (gridView1.GetRowCellValue(i, gridColPwd).ToString().Trim() != gridView1.GetRowCellValue(i, gridColRePwd).ToString().Trim())
                        {
                            sErr = "行" + (i + 1).ToString().Trim() + "两次密码不一致\n";
                            continue;
                        }

                        Model_SmartUser model = new Model_SmartUser();

                        string sUserID = gridView1.GetRowCellValue(i, gridColUserID).ToString().Trim();


                        DataRow[] drList = dtGrid.Select("UserID = '" + sUserID + "'");
                        model = DAL.DataRowToModel(drList[0]);

                        model.Pwd = clsDES.Encrypt(model.Pwd);

                        string sSQL = DAL.Exists(sUserID);
                        DataTable dt = DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
                        if (BaseFunction.ReturnInt(dt.Rows[0][0]) > 0)
                        {
                            sSQL = DAL.Update(model);
                        }
                        else
                        {
                            sSQL = DAL.Add(model);
                        }

                        iCou = iCou +  DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }

                    if (sErr.Length > 0)
                    {
                        throw new Exception(sErr);
                    }

                    tran.Commit();

                    if (iCou > 0)
                    {
                        MessageBox.Show("成功保存" + iCou.ToString() + "条记录");
                        btnRefresh_Click(null, null);
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column != gridColchoose)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColchoose, true);
                }
            }
            catch { }
        }
    }
}
