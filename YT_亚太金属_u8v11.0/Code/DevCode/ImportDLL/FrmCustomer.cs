using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ImportDLL
{
    public partial class FrmCustomer : Form
    {
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        public string sCusCode = "";
        public string sCusName = "";
        public bool isAll = false;

        public FrmCustomer(string sCus,bool sisAll)
        {
            InitializeComponent();
            textCusNew.Text = sCus;
            isAll = sisAll;
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
                MessageBox.Show("获得存货参照失败！  " + ee.Message);
            }
        }

        private void GetInv()
        {
            try
            {
                string sSQL = "select cast(0 as bit) as ischk,* from @u8.Customer a  where 1=1";
                if (textCusNew.Text.Trim() != string.Empty)
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and (cCusCode  like '%" + textCusNew.Text.Trim() + "%' or cCusName  like '%" + textCusNew.Text.Trim() + "%') ");
                }


                sSQL = sSQL + " order by cCusCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
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
                            //if (gridView1.GetRowCellValue(i, gridColcCusName).ToString().Trim() != "")
                            //{
                            //    sCusName = gridView1.GetRowCellValue(i, gridColcCusName).ToString().Trim();
                            //}
                            //else
                            //{
                            //    sCusName = "Null";
                            //}
                        }
                        else
                        {
                            sCusCode = sCusCode + "," + gridView1.GetRowCellValue(i, gridColcCusCode).ToString().Trim();
                            //if (gridView1.GetRowCellValue(i, gridColcCusName).ToString().Trim() != "")
                            //{
                            //    sCusName = sCusName + "," + gridView1.GetRowCellValue(i, gridColcCusName).ToString().Trim();
                            //}
                            //else
                            //{
                            //    sCusName = sCusName + "," + "Null";
                            //}
                        }
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回存货信息失败！  " + ee.Message);
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
                //sCusName = gridView1.GetRowCellValue(iRow, gridColcCusName).ToString().Trim();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("返回存货信息失败！  " + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textInvNew_EditValueChanged(object sender, EventArgs e)
        {
            if (textCusNew.Text.Trim() != "")
                GetInv();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GetChk(checkBox1.Checked);
        }

        private void GetChk(bool b)
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

        private void ItemChk_CheckedChanged(object sender, EventArgs e)
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
    }
}