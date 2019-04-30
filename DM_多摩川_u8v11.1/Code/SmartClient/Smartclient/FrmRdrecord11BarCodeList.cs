using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;



namespace Smartclient
{
    public partial class FrmRdrecord11BarCodeList : FrmBase
    {


        public DataTable dtGrid = new DataTable();

        public FrmRdrecord11BarCodeList()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                labelBarCodeCount.Text = dtGrid.Rows.Count.ToString().Trim();

                dataGrid1.DataSource = dtGrid;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }
        }

        private void btnDelRow_Click(object sender, EventArgs e)
        {
            try
            {
                string s箱码 = "";
                bool bDelBox = false;
                for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
                {
                    if (dataGrid1.IsSelected(i))
                    {
                        s箱码 = dtGrid.Rows[i]["箱码"].ToString().Trim();
                        if (s箱码 == "")
                        {
                            dtGrid.Rows.RemoveAt(i);
                            labelBarCodeCount.Text = dtGrid.Rows.Count.ToString();
                            break;
                        }
                        else
                        {
                            DialogResult d = MessageBox.Show("条码属于箱码" + s箱码 + "是否整箱删除", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            if (d == DialogResult.Yes)
                            {
                                bDelBox = true;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
                {
                    if (bDelBox && s箱码 != "" && s箱码 == dtGrid.Rows[i]["箱码"].ToString().Trim())
                    {
                        dtGrid.Rows.RemoveAt(i);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("删行失败:" + ee.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnEnSure_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}