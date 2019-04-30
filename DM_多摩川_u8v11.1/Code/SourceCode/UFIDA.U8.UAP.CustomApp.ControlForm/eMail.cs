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
    public partial class eMail : UserControl
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

        public eMail()
        {
            InitializeComponent();
        }




        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = @"
SELECT   cast(0 as bit) as choose,  sType, MailAddress, Subject
FROM       _MailAddress

";
                DataTable dt = DbHelperSQL.Query(sSQL);

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

                        if (gridView1.GetRowCellValue(i, gridColMailAddress).ToString().Trim() == "")
                        {
                            sErr = sErr + "行 " + (i + 1).ToString() + "地址不能为空\n";
                            continue;
                        }

                        string sSQL = "update _MailAddress set MailAddress = '111111',[Subject] = '222222' where sType = '333333'";
                        sSQL = sSQL.Replace("111111", gridView1.GetRowCellValue(i, gridColMailAddress).ToString().Trim());
                        sSQL = sSQL.Replace("222222", gridView1.GetRowCellValue(i, gridColSubject).ToString().Trim());
                        sSQL = sSQL.Replace("333333", gridView1.GetRowCellValue(i, gridColsType).ToString().Trim());
                    
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
