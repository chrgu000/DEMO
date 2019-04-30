using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TH.BaseClass;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmCustomer : Form
    {
        public string sCusCode = "";
        public string sCusName = "";
        public bool isAll = false;
        public string streeid = "";
        public string Conn { get; set; }

        public FrmCustomer(string sCus, string conn, bool sisAll)
        {
            try
            {
                Conn = conn;
                InitializeComponent();
                textCusNew.Text = sCus;
                isAll = sisAll;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                checkBox1.Enabled = isAll;
                
                    GetInv();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得客户参照信息失败！  " + ee.Message);
            }
        }

        private void GetInv()
        {
            try
            {
                string sSQL = "select cast(0 as bit) as ischk,* from Customer a  where 1=1";
                if (textCusNew.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (cCusCode  like '%" + textCusNew.Text.Trim() + "%' or cCusName  like '%" + textCusNew.Text.Trim() + "%') ");
                }

                sSQL = sSQL + " order by cCusCode";
                DataTable dt = DbHelperSQL.Query(sSQL);
                gridControl1.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载数据失败:" + ee.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                sCusCode="";sCusName="";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChk)) == true)
                    {
                        if (sCusCode == "")
                        {
                            sCusCode = gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcCusName).ToString().Trim() != "")
                            {
                                sCusName = gridView1.GetRowCellValue(i, gridColcCusName).ToString().Trim();
                            }
                            else
                            {
                                sCusName = "Null";
                            }
                        }
                        else
                        {
                            sCusCode = sCusCode + "," + gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcCusName).ToString().Trim() != "")
                            {
                                sCusName = sCusName + "," + gridView1.GetRowCellValue(i, gridColcCusName).ToString().Trim();
                            }
                            else
                            {
                                sCusName = sCusName + "," + "Null";
                            }
                        }
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回客户信息失败！  " + ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }

                sCusCode = gridView1.GetRowCellValue(iRow, gridColcCusCode).ToString().Trim();
                sCusName = gridView1.GetRowCellValue(iRow, gridColcCusName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回客户信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void textInvNew_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (textCusNew.Text.Trim() != "")
                    GetInv();
            }
            catch
            {
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetChk(checkBox1.Checked);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetChk(bool b)
        {
            try
            {
                if (b == false)
                {
                    checkBox1.Text = "全选";
                }
                else
                {
                    checkBox1.Text = "全部取消";
                }
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColChk, b);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void ItemChk_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (isAll == false)
                {
                    int iRow = gridView1.FocusedRowHandle;
                    try
                    {
                        gridView1.FocusedRowHandle -= 1;
                        gridView1.FocusedRowHandle += 1;
                    }
                    catch { }

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (i == iRow)
                        {
                            continue;
                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, gridColChk, false);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}