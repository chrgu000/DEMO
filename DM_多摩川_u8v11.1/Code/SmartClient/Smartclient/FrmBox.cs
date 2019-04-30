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
    public partial class FrmBox : FrmBase
    {

        DataTable dtBarCode = new DataTable();

        public FrmBox()
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

                txtBarCode.Text = "";
                txtBoxCode.Text = "";
                txtBoxCode.Focus();

                Setdt();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }
        }

        private void Setdt()
        {
            dtBarCode = new DataTable();
            dtBarCode.TableName = "BarCodeList";

            DataColumn dc = new DataColumn();
            dc.ColumnName = "条形码";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "存货编码";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "存货名称";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "规格型号";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "数量";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "批号";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "序列号";
            dtBarCode.Columns.Add(dc);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScanBoxCode_Click(object sender, EventArgs e)
        {
            try
            {
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
                    if (clsWeb.iBarCodeUsed(txtBoxCode.Text.Trim(), "") > 0)
                    {
                        MessageBox.Show("箱码" + txtBoxCode.Text.Trim() + "已使用，不能再装箱");
                        txtBoxCode.Text = "";
                        return;
                    }

                    txtBarCode.Focus();
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

                FrmBoxList f = new FrmBoxList();
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

        private void txtBoxCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnScanBoxCode_Click(null, null);
            }
        }

        private void btnScanBarCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode.Text.Trim().Length == 12)
                {
                    for (int i = 0; i < dtBarCode.Rows.Count; i++)
                    {
                        string sBarCode = dtBarCode.Rows[i]["条形码"].ToString().Trim();
                        if (sBarCode == txtBoxCode.Text.Trim())
                        {
                            txtBoxCode.Text = "";
                            MessageBox.Show("本条码已扫描");
                            return;
                        }
                    }

                    DataTable dtTemp = clsWeb.dtScanBarCode(txtBarCode.Text.Trim());
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("获得条形码信息失败");
                    }

                    if (!base.ReturnBool(dtTemp.Rows[0]["是否有效"]))
                    {
                        MessageBox.Show("条码" + txtBoxCode.Text.Trim() + "已失效");
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        return;
                    }

                    if (dtTemp.Rows[0]["箱码"].ToString().Trim().Length == 13)
                    {
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        throw new Exception("该条形码已经装箱");
                    }

                    string sBarInfo = "";
                    sBarInfo = sBarInfo + "条形码：" + dtTemp.Rows[0]["条形码"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　存货：" + dtTemp.Rows[0]["存货编码"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　名称：" + dtTemp.Rows[0]["存货名称"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　型号：" + dtTemp.Rows[0]["规格型号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "可数量：" + dtTemp.Rows[0]["数量"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　货位：" + dtTemp.Rows[0]["货位"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　批号：" + dtTemp.Rows[0]["批号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "序列号：" + dtTemp.Rows[0]["序列号"].ToString().Trim() + "\r\n";

                    DataRow drBarCode = dtBarCode.NewRow();
                    drBarCode["条形码"] = txtBarCode.Text.Trim();
                    drBarCode["存货编码"] = dtTemp.Rows[0]["存货编码"].ToString().Trim();
                    drBarCode["存货名称"] = dtTemp.Rows[0]["存货名称"].ToString().Trim();
                    drBarCode["规格型号"] = dtTemp.Rows[0]["规格型号"].ToString().Trim();
                    drBarCode["数量"] = dtTemp.Rows[0]["数量"].ToString().Trim();
                    drBarCode["货位"] = dtTemp.Rows[0]["货位"].ToString().Trim();
                    drBarCode["批号"] = dtTemp.Rows[0]["批号"].ToString().Trim();
                    drBarCode["序列号"] = dtTemp.Rows[0]["序列号"].ToString().Trim();
                    dtBarCode.Rows.Add(drBarCode);

                    txtBarCodeInfo.Text = sBarInfo;

                    txtBarCode.Text = "";

                    labelBarCodeCount.Text = dtBarCode.Rows.Count.ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("扫描条码失败：" + ee.Message);
            }
        }

        private void btnBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtBarCode.Rows.Count > 0)
                {
                    string s = clsWeb.sSaveBox(txtBoxCode.Text.Trim(), dtBarCode);
                    MessageBox.Show(s);

                    if (s.Length > 2 && s.Substring(0, 2) == "成功")
                    {
                        Setdt();
                        txtBarCode.Text = "";
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

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnScanBarCode_Click(null, null);
            }
        }

        private void txtBoxCode_GotFocus(object sender, EventArgs e)
        {
            HoneyWellBarCode.TargetTextBox = txtBoxCode;
        }

        private void txtBarCode_GotFocus(object sender, EventArgs e)
        {
            HoneyWellBarCode.TargetTextBox = txtBarCode;
        }
    }
}