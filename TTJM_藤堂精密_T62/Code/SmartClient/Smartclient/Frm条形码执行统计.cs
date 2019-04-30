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
    public partial class Frm条形码执行统计 : FrmBase
    {
        public Frm条形码执行统计()
        {
            InitializeComponent();
        }

        public Frm条形码执行统计(string sBarCode)
        {
            InitializeComponent();

            this.txtBarCode2.Text = sBarCode;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                btnSEL_Click(null, null);
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                {
                    return;
                }

                btnSEL_Click(null, null);
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode2.Text.Trim() == "")
                {
                    txtBarCode2.Focus();
                    return;
                }

                if (txtBarCode2.Text.Trim().Length != 12 && txtBarCode2.Text.Trim().Length != 15)
                {
                    txtBarCode2.Focus();
                    throw new Exception("请扫描正确的条形码");
                }

                TH.Smart.WebService.ClsUseWebService cls = new TH.Smart.WebService.ClsUseWebService();
                DataTable dtBarCode = cls.dtBarCode执行统计(txtBarCode2.Text.Trim(), TH.Smart.BaseClass.ClsBaseDataInfo.sUFDataBaseName);

                if (dtBarCode == null || dtBarCode.Rows.Count == 0)
                {
                    throw new Exception("获得条形码信息失败");
                }


                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "工序";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "转移数";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "工序号";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "装箱数";
                dt.Columns.Add(dc);

                for (int i = 0; i < dtBarCode.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["工序号"] = dtBarCode.Rows[i]["WorkProcessNo"];
                    dr["工序"] = dtBarCode.Rows[i]["WorkProcessName"];
                    dr["装箱数"] = dtBarCode.Rows[i]["装箱数"];
                    dr["转移数"] = dtBarCode.Rows[i]["数量"];
                    dt.Rows.Add(dr);
                }

                txt信息.Text = "";
                txt信息.Text = txt信息.Text + "条形码  ：" + txtBarCode2.Text.Trim() + "\r\n";
                txt信息.Text = txt信息.Text + "订单号  ：" + dtBarCode.Rows[0]["WorkCode"].ToString().Trim() + "\r\n";
                txt信息.Text = txt信息.Text + "存货编码：" + dtBarCode.Rows[0]["cInvCode"].ToString().Trim() + "\r\n";
                txt信息.Text = txt信息.Text + "存货名称：" + dtBarCode.Rows[0]["cInvName"].ToString().Trim() + "\r\n";
                txt信息.Text = txt信息.Text + "规格型号：" + dtBarCode.Rows[0]["cInvStd"].ToString().Trim() + "\r\n";
                txt信息.Text = txt信息.Text + "订单数量：" + TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(dtBarCode.Rows[0]["WorkQty"], 0).ToString().Trim() + "\r\n";
                txt信息.Text = txt信息.Text + "装箱数  ：" + TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(dtBarCode.Rows[0]["数量"], 0).ToString().Trim() + "\r\n";

                dataGrid1.DataSource = dt;

                txtBarCode2.Text = "";
                txtBarCode2.Focus();
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }
    }
}