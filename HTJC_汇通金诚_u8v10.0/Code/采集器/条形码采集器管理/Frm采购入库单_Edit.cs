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
    public partial class Frm采购入库单_Edit : FrmBase
    {
        public DataTable dt采购入库;
        string s采购入库单号;
        string s仓库 = "";
        string s货位 = "";
        string s存货编码 = "";
        string s存货名称 = "";
        string s规格型号 = "";
        string s批号 = "";
        decimal d数量 = (decimal)0.00;
        string s长度 = "";
        string s炉号 = "";
        string s供应商 = "";

        public Frm采购入库单_Edit()
        {
            InitializeComponent();
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

                if (txt货仓.Text.Trim() == "")
                {
                    txt货仓.Focus();
                    throw new Exception("请输入货仓信息");
                }
                if (s存货编码.Trim() == "")
                {
                    return;
                }

                bool b = false;
                if (dt采购入库 != null)
                {
                    for (int i = 0; i < dt采购入库.Rows.Count; i++)
                    {
                        if (dt采购入库.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                        {
                            throw new Exception("该条形码已经存在");
                        }
                    }
                }

                DataRow dr = dt采购入库.NewRow();
                dr["存货编码"] = s存货编码;
                dr["存货名称"] = s存货名称;
                dr["规格型号"] = s规格型号;
                dr["批号"] = s批号;
                dr["炉号"] = s炉号;
                dr["数量"] = d数量;
                dr["长度"] = s长度;
                dr["供应商"] = s供应商;
                dr["单据号"] = s采购入库单号;
                dr["条形码"] = txt条形码.Text.Trim();
                dr["仓库"] = s仓库;
                dr["货位"] = s货位;
                dr["制单人"] = sUserID;
                dt采购入库.Rows.Add(dr);

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
                if (txtInfo.Text.Trim() != "")
                {
                    btn确定_Click(null, null);

                }

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
            txt条形码.Text = "";
            txtInfo.Text = "";

            s存货编码 = "";
            s存货名称 = "";
            s规格型号 = "";
            s批号 = "";
            d数量 = (decimal)0.00;
            s长度 = "";
            s炉号 = "";
            s供应商 = "";
        }

        private void Frm采购入库单_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                txt货仓.Focus();
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
            try
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
            catch (Exception ee)
            {
                msgBox.Text = "加载数据失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void txt货仓_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "获得货位失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;

                SetNull();
                txt货仓.Focus();
            }
        }

        private void txt条形码_Validated(object sender, EventArgs e)
        {
            try
            {
                if (s仓库 == "")
                {
                    txt货仓.Focus();
                    throw new Exception("仓库不能为空");
                }

                string sBarCode = txt条形码.Text.Trim();
                if (sBarCode == "")
                {
                    return;
                }
                if (sBarCode.Length != 10)
                {
                    txt条形码.Text = "";
                    txtInfo.Text = "";
                    txt条形码.Focus();
                    throw new Exception("条码长度不对");
                }

                int iCou = ReturnObjectToInt(clsWeb.Chk采购入库条码是否已经使用(txt条形码.Text.Trim()));
                if (iCou > 0)
                {
                    txt条形码.Text = "";
                    txtInfo.Text = "";
                    txt条形码.Focus();
                    throw new Exception("该条形码已经使用");
                }

                for (int i = 0; i < dt采购入库.Rows.Count; i++)
                {
                    if (dt采购入库.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                    {
                        txt条形码.Text = "";
                        txtInfo.Text = "";
                        txt条形码.Focus();
                        throw new Exception("本条码已经加载");
                    }
                }

                txtInfo.Text = "";

                sBarCode = ReturnObjectToLong(sBarCode).ToString().Trim();
                DataTable dt = clsWeb.dt采购条码信息(sBarCode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (base.ReturnObjectToDecimal(dt.Rows[0]["iPosQty"],2) > 0)
                    {
                        throw new Exception("条形码对应单据已手工录入货位"); 
                    }

                    s采购入库单号 = dt.Rows[0]["采购入库单号"].ToString().Trim();
                    s存货编码 = dt.Rows[0]["存货编码"].ToString().Trim();
                    s存货名称 = dt.Rows[0]["cInvName"].ToString().Trim();
                    s规格型号 = dt.Rows[0]["cInvStd"].ToString().Trim();
                    s批号 = dt.Rows[0]["批号"].ToString().Trim();
                    d数量 = base.ReturnObjectToDecimal(dt.Rows[0]["iQuantity"], 6);
                    s长度 =  dt.Rows[0]["长度"].ToString().Trim() ;
                    s炉号 = dt.Rows[0]["炉号"].ToString().Trim();
                    s供应商 = dt.Rows[0]["cVenCode"].ToString().Trim();

                    txtInfo.Text = txtInfo.Text + "条形码:   " + txt条形码.Text.Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "采购入库单:   " + s采购入库单号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "供应商:   [" + s供应商 + "]" + dt.Rows[0]["cVenName"].ToString().Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "原料编码：" + s存货编码 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "原料名称：" + s存货名称 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "原料规格：" + s规格型号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "批号：    " + s批号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "炉号：    " + s炉号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "数量：    " + d数量.ToString().Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "长度：    " + s长度 + "\r\n";

                    //txt条形码.Text = "";
                    btn确定.Focus();
                }
                else
                {
                    txt条形码.Text = "";
                    txtInfo.Text = "";
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

                txt条形码.Focus();
            }
        }

        private void txt货仓_Validated(object sender, EventArgs e)
        {
            try
            {
                string 货仓 = txt货仓.Text.Trim();
                if (货仓 == "")
                {
                    MessageBox.Show("货仓不能为空");
                    return;
                }

                DataTable dt = clsWeb.dt货仓(货仓);
                if (dt == null || dt.Rows.Count < 1)
                {
                    SetNull();
                    txt货仓.Focus();
                    throw new Exception("获得仓库，货位信息失败");
                }
                else
                {
                    if (s仓库.Trim() == "")
                    {
                        s仓库 = dt.Rows[0]["cWhCode"].ToString().Trim();
                    }

                    if (s仓库 != dt.Rows[0]["cWhCode"].ToString().Trim())
                    {
                        throw new Exception("一次操作必须同一个仓库");
                    }

                    int iPos = ReturnObjectToInt(dt.Rows[0]["bWhPos"]);
                    if (iPos == 1 && dt.Rows[0]["cPosCode"].ToString().Trim() == "")
                    {
                        throw new Exception("该仓库有货位管理，请输入货位");
                    }
                    else
                    {
                        s货位 = dt.Rows[0]["cPosCode"].ToString().Trim();

                        txt条形码.Focus();
                    }
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "获得货位失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;

                SetNull();
                txt货仓.Focus();
            }
        }
    }
}