using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Drawing;




namespace Smartclient
{
    public partial class FrmBarCodeAdjust : FrmBase
    {

        DataTable dt = new DataTable();

        public FrmBarCodeAdjust()
        {
            InitializeComponent();


        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                txtBarCodeInfo.Text = "";
                txtBarCodeInfo.ReadOnly = true;

                txtQty.Text = "";
                txtUseQty.Text = "";

                txtBarCode.Text = "";
                txtBarCode.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }
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
                    sBarInfo = sBarInfo + "　数量：" + dtTemp.Rows[0]["可用量"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　货位：" + dtTemp.Rows[0]["货位"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　批号：" + dtTemp.Rows[0]["批号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "序列号：" + dtTemp.Rows[0]["序列号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　仓库：" + "【" + dtTemp.Rows[0]["仓库编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["仓库"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "供应商：" + "【" + dtTemp.Rows[0]["供应商编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["供应商"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　部门：" + "【" + dtTemp.Rows[0]["部门编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["部门"].ToString().Trim() + "\r\n";

                    txtBarCodeInfo.Text = sBarInfo;
                    txtQty.Text = dtTemp.Rows[0]["可用量"].ToString().Trim();
                    txtUseQty.Text = dtTemp.Rows[0]["可用量"].ToString().Trim();
                    txtUseQty.Focus();
                }
            }
            catch (Exception ee)
            {
                txtQty.Text = "";
                txtUseQty.Text = "";
                txtBarCodeInfo.Text = "";
                txtBarCode.Focus();
                MessageBox.Show("扫描条码失败：" + ee.Message);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal dQty1 = base.ReturnDecimal(txtUseQty.Text.Trim());
                decimal dQty2 = base.ReturnDecimal(txtQty.Text.Trim());
                if (dQty2 < 0)
                {
                    MessageBox.Show("调整后数量必须不小于0");
                    return;
                }

                decimal dQty = dQty1 - dQty2;
                if (dQty == 0)
                {
                    MessageBox.Show("数量一致，不需要调整");
                    return;
                }

                string s = clsWeb.sSaveBarCodeAdjust(txtBarCode.Text.Trim(), dQty,dQty1, TH.Smart.BaseClass.ClsBaseDataInfo.sUid);


                MessageBox.Show(s);

                if (chkPrint.Checked)
                {
                    PrintBarCode();
                }

                txtBarCode.Text = "";
                txtBarCodeInfo.Text = "";
                txtUseQty.Text = "";
                txtQty.Text = "";
                
            }
            catch (Exception ee)
            {
                MessageBox.Show("作废失败:" + ee.Message);
            }
        }

        private void PrintBarCode()
        {
            try
            {
                string sBarCode = txtBarCode.Text.Trim();
                if (sBarCode.Length != 12)
                {
                    throw new Exception("条码长度不正确");
                }

                string s = clsWeb.PrintBarCodeAdjust(sBarCode);
            }
            catch (Exception ee)
            {
                MessageBox.Show("打印失败:" + ee.Message);
            }
        }
    }
}