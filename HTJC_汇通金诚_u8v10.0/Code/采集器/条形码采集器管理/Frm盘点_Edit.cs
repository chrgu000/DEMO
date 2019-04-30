using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BarCode
{
    public partial class Frm盘点_Edit : FrmBase
    {
        public DataTable dt盘点;
        public string s盘点单号;
        string s仓库 = "04";
        string s货位 = "C050";
        string s存货编码 = "";
        string s存货名称 = "";
        string s规格型号 = "";
        string s批号 = "";
        decimal d数量 = (decimal)0.00;
        decimal d毛重 = (decimal)0.00;
        string s长度 = "";
        string s炉号 = "";

        public Frm盘点_Edit(string sCode, DataTable dt)
        {
            InitializeComponent();

            dt盘点 = dt;
            s盘点单号 = sCode;
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt条形码.Text.Trim() == "")
                {
                    txt条形码.Focus();
                    return;
                }
                
                if (dt盘点 != null)
                {
                    for (int i = 0; i < dt盘点.Rows.Count; i++)
                    {
                        //条形码只能扫描一次
                        if (dt盘点.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                        {
                            throw new Exception("该条形码已经存在");
                        }
                    }
                }

                DataRow dr = dt盘点.NewRow();
                dr["存货编码"] = s存货编码;
                dr["存货名称"] = s存货名称;
                dr["规格型号"] = s规格型号;
                dr["批号"] =  s批号;
                dr["炉号"] = s炉号;
                dr["数量"] = d数量;
                dr["长度"] = s长度;
                dr["单据号"] = s盘点单号;
                dr["条形码"] = txt条形码.Text.Trim();
                dr["制单人"] = sUserID;
                dt盘点.Rows.Add(dr);

                SetNull();
                txt条形码.Focus();
            }
            catch (Exception ee)
            {
                msgBox.Text = "操作失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void btn返回_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ee)
            {
                msgBox.Text = "返回失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void SetNull()
        {
            s存货编码 = "";
            s存货名称 = "";
            s规格型号 = "";
            s批号 = "";
            d数量 = 0.00M;
            txt条形码.Text = "";
            s炉号 = "";
            d毛重 = 0.00M;
            s长度 = "";
        }

        private void Frm盘点_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                txt条形码.Focus();
            }
            catch (Exception ee)
            {
                msgBox.Text = "加载窗体失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txt条形码.Text.Trim() == "")
                {
                    txt条形码.Focus();
                }
                else
                {
                    btn确定.Focus();
                }
            }
        }


        private void txt条形码_Validated(object sender, EventArgs e)
        {
            try
            {
                string sBarCode = txt条形码.Text.Trim();
                if (sBarCode == "")
                {
                    return;
                }

                if (sBarCode.Length != 10)
                {
                    txt条形码.Text = "";
                    SetNull();
                    txt条形码.Focus();
                    throw new Exception("条码长度不对");
                }

                //int iCou = ReturnObjectToInt(clsWeb.Chk销售出库条码是否已经使用(txt条形码.Text.Trim()));
                //if (iCou > 0)
                //{
                //    txt条形码.Text = "";
                //    SetNull();
                //    txt条形码.Focus();
                //    throw new Exception("该条形码已经使用");
                //}

                for (int i = 0; i < dt盘点.Rows.Count; i++)
                {
                    if (dt盘点.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                    {
                        txt条形码.Text = "";
                        SetNull();
                        txt条形码.Focus();
                        throw new Exception("本条码已经加载");
                    }
                }

                txtInfo.Text = "";
                sBarCode = ReturnObjectToLong(sBarCode).ToString().Trim();
                DataTable dt = clsWeb.dt盘点条码信息(sBarCode, s盘点单号);
                if (dt != null && dt.Rows.Count > 0)
                {
                    s存货编码 = dt.Rows[0]["存货编码"].ToString().Trim();
                    s存货名称 = dt.Rows[0]["cInvName"].ToString().Trim();
                    s规格型号 = dt.Rows[0]["cInvStd"].ToString().Trim();
                    s批号 = dt.Rows[0]["批号"].ToString().Trim();
                    s炉号 = dt.Rows[0]["炉号"].ToString().Trim();
                    d数量 = ReturnObjectToDecimal(dt.Rows[0]["数量"].ToString().Trim(), 2);
                    d毛重 = ReturnObjectToDecimal(dt.Rows[0]["毛重"].ToString().Trim(), 2);
                    s长度 = dt.Rows[0]["长度"].ToString().Trim();

                    txtInfo.Text = txtInfo.Text + "条形码:   " + txt条形码.Text.Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "产品编码：" + s存货编码 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "产品名称：" + s存货名称 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "规格型号：" + s规格型号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "批号：    " + s批号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "炉号：    " + s炉号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "数量：    " + d数量.ToString().Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "毛重：    " + d毛重.ToString().Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "长度：    " + s长度 + "\r\n";

                    btn确定.Focus();
                }
                else
                {
                    txt条形码.Text = "";
                    SetNull();
                    txt条形码.Focus();
                    throw new Exception("获得条码信息失败，或条码与采购订单不匹配");
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "加载数据失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }
    }
}