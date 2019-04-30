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
    public partial class FrmUnBox : FrmBase
    {

        DataTable dtBarCode = new DataTable();

        public FrmUnBox()
        {
            InitializeComponent();


        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                labelBarCodeCount.Text = "0";
                txtBarCodeInfo.Text = "";
                txtBarCodeInfo.ReadOnly = true;

                txtBoxCode.Text = "";
                txtBoxCode.Focus();
                dtBarCode = new DataTable();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScanBoxCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBoxCode.Text.Trim().Length == 0)
                {
                    txtBoxCode.Focus();
                    return;
                }

                if (txtBoxCode.Text.Trim().Length == 13 && txtBoxCode.Text.Trim().Substring(0, 1).ToLower() == "x")
                {
                    DataTable dtTemp = clsWeb.dtScanBarCode(txtBoxCode.Text.Trim());
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("获得箱码信息失败");
                    }

                    if (!base.ReturnBool(dtTemp.Rows[0]["是否有效"]))
                    {
                        MessageBox.Show("箱码" + txtBoxCode.Text.Trim() + "已失效");
                        txtBoxCode.Text = "";
                        return;
                    }

                    dtBarCode = clsWeb.dtSBoxBarCode(txtBoxCode.Text.Trim());
                    if (dtBarCode != null)
                    {
                        labelBarCodeCount.Text = dtBarCode.Rows.Count.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("请扫描正确箱码");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("扫描条码失败：" + ee.Message);
            }
        }

        private void txtBoxCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnScanBoxCode_Click(null, null);
            }
        }


        private void btnUnBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtBarCode.Rows.Count > 0)
                {
                    string s = clsWeb.sSaveUnBox(txtBoxCode.Text.Trim());
                    MessageBox.Show(s);

                    if (s.Length > 2 && s.Substring(0, 2) == "成功")
                    {
                        dtBarCode = new DataTable();
                        txtBoxCode.Text = "";
                        txtBarCodeInfo.Text = "";
                        labelBarCodeCount.Text = "0";
                        txtBoxCode.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("请扫描需要盘点的条形码");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败:" + ee.Message);
            }
        }

        private void btnExamine_Click(object sender, EventArgs e)
        {
            try
            {
                int iCou = base.ReturnInt(labelBarCodeCount.Text.Trim());
                if (iCou == 0)
                {
                    MessageBox.Show("请扫描条形码后查看");
                    return;
                }

                FrmUnBoxList f = new FrmUnBoxList();
                f.WindowState = FormWindowState.Maximized;
                f.dtGrid = this.dtBarCode.Copy();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.Yes)
                {
                    dtBarCode = f.dtGrid.Copy();
                    labelBarCodeCount.Text = dtBarCode.Rows.Count.ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("查看扫描列表失败:" + ee.Message);
            }
        }

        private void txtBoxCode_GotFocus(object sender, EventArgs e)
        {
            HoneyWellBarCode.TargetTextBox = txtBoxCode;
        }
    }
}