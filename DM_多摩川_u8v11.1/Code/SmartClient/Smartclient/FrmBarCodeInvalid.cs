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
    public partial class FrmBarCodeInvalid : FrmBase
    {

        DataTable dt = new DataTable();

        public FrmBarCodeInvalid()
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
                txtBarCode.Focus();

                Setdt();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }
        }

        private void Setdt()
        {
            dt = new DataTable();
            dt.TableName = "BarCodeList";

            DataColumn dc = new DataColumn();
            dc.ColumnName = "条形码";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "存货编码";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "存货名称";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "规格型号";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "数量";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "批号";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "序列号";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应商";
            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "部门";
            dt.Columns.Add(dc);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode.Text.Trim().Length == 12 || txtBarCode.Text.Trim().Length == 13)
                {
                    DataTable dtTemp = clsWeb.dtScanBarCode(txtBarCode.Text.Trim());
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("获得条形码信息失败");
                    }

                    if (!base.ReturnBool(dtTemp.Rows[0]["是否有效"]))
                    {
                        MessageBox.Show("条码" + txtBarCode.Text.Trim() + "已失效");
                        txtBarCode.Text = "";
                        return;
                    }

                    string sBarInfo = "";
                    sBarInfo = sBarInfo + "条形码：" + dtTemp.Rows[0]["条形码"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　存货：" + dtTemp.Rows[0]["存货编码"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　名称：" + dtTemp.Rows[0]["存货名称"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　型号：" + dtTemp.Rows[0]["规格型号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　数量：" + dtTemp.Rows[0]["数量"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　货位：" + dtTemp.Rows[0]["货位"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　批号：" + dtTemp.Rows[0]["批号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "序列号：" + dtTemp.Rows[0]["序列号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　仓库：" + "【" + dtTemp.Rows[0]["仓库编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["仓库"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "供应商：" + "【" + dtTemp.Rows[0]["供应商编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["供应商"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　部门：" + "【" + dtTemp.Rows[0]["部门编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["部门"].ToString().Trim() + "\r\n";

                    txtBarCodeInfo.Text = sBarInfo;


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sBarCode = dt.Rows[i]["条形码"].ToString().Trim();
                        if (sBarCode == txtBarCode.Text.Trim())
                        {
                            txtBarCode.Text = "";
                            MessageBox.Show("本条码已扫描");
                            return;
                        }
                    }

                    DataRow dr = dt.NewRow();
                    dr["条形码"] = txtBarCode.Text.Trim();
                    dr["存货编码"] = dtTemp.Rows[0]["存货编码"].ToString().Trim();
                    dr["存货名称"] = dtTemp.Rows[0]["存货名称"].ToString().Trim();
                    dr["规格型号"] = dtTemp.Rows[0]["规格型号"].ToString().Trim();
                    dr["数量"] = dtTemp.Rows[0]["数量"].ToString().Trim();
                    dr["货位"] = dtTemp.Rows[0]["货位"].ToString().Trim();
                    dr["批号"] = dtTemp.Rows[0]["批号"].ToString().Trim();
                    dr["序列号"] = dtTemp.Rows[0]["序列号"].ToString().Trim();
                    dr["仓库"] = dtTemp.Rows[0]["仓库"].ToString().Trim();
                    dr["供应商"] = dtTemp.Rows[0]["供应商"].ToString().Trim();
                    dr["部门"] = dtTemp.Rows[0]["部门"].ToString().Trim();
                    dt.Rows.Add(dr);

                    txtBarCode.Text = "";

                    labelBarCodeCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("扫描条码失败：" + ee.Message);
            }
        }

        private void btnInvalid_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    string s = clsWeb.sBarCodeInvalid(dt);
                    MessageBox.Show(s);

                    if (s.Length > 2 && s.Substring(0, 2) == "成功")
                    {
                        Setdt();
                        txtBarCode.Text = "";
                        txtBarCodeInfo.Text = "";
                        labelBarCodeCount.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show("请扫描需要作废的条形码");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("作废失败:" + ee.Message);
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

                FrmBarCodeInvalidList f = new FrmBarCodeInvalidList();
                f.WindowState = FormWindowState.Maximized;
                f.dtGrid = this.dt.Copy();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.Yes)
                {
                    dt = f.dtGrid.Copy();
                    labelBarCodeCount.Text = dt.Rows.Count.ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("查看扫描列表失败:" + ee.Message);
            }
        }

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnScan_Click(null, null);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarCode_GotFocus(object sender, EventArgs e)
        {
            HoneyWellBarCode.TargetTextBox = txtBarCode;
        }
    }
}