using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    public partial class FrmWarehouse : Form
    {
        public string sPerCode = "";
        public string sPerName = "";
        public bool isAll = false;
        public string streeid = "";
        public string Conn { get; set; }

        public FrmWarehouse(string sCus, string conn, bool sisAll)
        {
            try
            {
                Conn = conn;
                InitializeComponent();
                textPerNew.Text = sCus;
                isAll = sisAll;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void FrmWarehouse_Load(object sender, EventArgs e)
        {
            try
            {
                checkBox1.Enabled = isAll;
                
                    GetPer();
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得部门参照信息失败！  " + ee.Message);
            }
        }

        private void GetPer()
        {
            try
            {
                string sSQL = "select cast(0 as bit) as ischk,* from Warehouse a  where 1=1";
                if (textPerNew.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (cWhCode  like '%" + textPerNew.Text.Trim() + "%' or cWhName   like '%" + textPerNew.Text.Trim() + "%') ");
                }


                sSQL = sSQL + " order by cWhCode";
                DataTable dt = SqlHelper.ExecuteDataset(Conn, CommandType.Text, sSQL).Tables[0];
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
                sPerCode="";sPerName="";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridColChk)) == true)
                    {
                        if (sPerCode == "")
                        {
                            sPerCode = gridView1.GetRowCellValue(i, gridColcWhCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcWhName).ToString().Trim() != "")
                            {
                                sPerName = gridView1.GetRowCellValue(i, gridColcWhName).ToString().Trim();
                            }
                            else
                            {
                                sPerName = "Null";
                            }
                        }
                        else
                        {
                            sPerCode = sPerCode + "," + gridView1.GetRowCellValue(i, gridColcWhCode).ToString().Trim();
                            if (gridView1.GetRowCellValue(i, gridColcWhName).ToString().Trim() != "")
                            {
                                sPerName = sPerName + "," + gridView1.GetRowCellValue(i, gridColcWhName).ToString().Trim();
                            }
                            else
                            {
                                sPerName = sPerName + "," + "Null";
                            }
                        }
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回部门信息失败！  " + ee.Message);
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

                sPerCode = gridView1.GetRowCellValue(iRow, gridColcWhCode).ToString().Trim();
                sPerName = gridView1.GetRowCellValue(iRow, gridColcWhName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回部门信息失败！  " + ee.Message);
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
                if (textPerNew.Text.Trim() != "")
                    GetPer();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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