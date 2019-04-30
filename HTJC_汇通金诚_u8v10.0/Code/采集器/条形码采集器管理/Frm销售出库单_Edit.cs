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
    public partial class Frm销售出库单_Edit : FrmBase
    {
        public DataTable dt单据;
        public DataTable dt销售出库单;
        string s单据号;
        string s行号 = "1";
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
        string s客户 = "";
        string s单据体ID = "";

        public Frm销售出库单_Edit(string sCode, DataTable dt,DataTable dt2)
        {
            InitializeComponent();

            dt单据 = dt;
            s单据号 = sCode;
            dt销售出库单 = dt2;

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

                if (dt单据 != null)
                {
                    for (int i = 0; i < dt单据.Rows.Count; i++)
                    {
                        if (dt单据.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                        {
                            throw new Exception("该条形码已经存在");
                        }

                        if (s仓库 == "")
                        {
                            s仓库 = dt单据.Rows[i]["仓库"].ToString().Trim();
                        }

                        if (s仓库 != dt单据.Rows[i]["仓库"].ToString().Trim())
                        {
                            throw new Exception("同一张采购入库单，仓库必须一致");
                        }
                    }
                }

              
                DataRow dr = dt单据.NewRow();
                dr["存货编码"] = s存货编码;
                dr["存货名称"] = s存货名称;
                dr["规格型号"] = s规格型号;
                dr["批号"] = s批号;
                dr["炉号"] = s炉号;
                dr["数量"] = d数量;
                dr["毛重"] = d毛重;
                dr["长度"] = s长度;
                dr["行号"] = s行号;
                dr["单据号"] = s单据号;
                dr["条形码"] = txt条形码.Text.Trim();
                dr["仓库"] = s仓库;
                dr["货位"] = s货位;
                dr["制单人"] = sUserID;
                dr["客户"] = s客户;
                dr["单据体ID"] = s单据体ID;
                dt单据.Rows.Add(dr);

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
            s客户 = "";
        }

        private void Frm销售出库单_Edit_Load(object sender, EventArgs e)
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

                int iCou = ReturnObjectToInt(clsWeb.Chk销售出库条码是否已经使用(txt条形码.Text.Trim()));
                if (iCou > 0)
                {
                    txt条形码.Text = "";
                    txtInfo.Text = "";
                    txt条形码.Focus();
                    throw new Exception("该条形码已经使用");
                }

                for (int i = 0; i < dt单据.Rows.Count; i++)
                {
                    if (dt单据.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                    {
                        txt条形码.Text = "";
                        txtInfo.Text = "";
                        txt条形码.Focus();
                        throw new Exception("本条码已经加载");
                    }
                }
                

                txtInfo.Text = "";

                DataTable dt = clsWeb.dt销售出库条码信息(sBarCode);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (ReturnObjectToDecimal(dt.Rows[0]["iQty"], 2) > 0)
                    {
                        throw new Exception("对应单据已扫描或已手工出库");
                    }

                    s存货编码 = dt.Rows[0]["存货编码"].ToString().Trim();
                    s存货名称 = dt.Rows[0]["cInvName"].ToString().Trim();
                    s规格型号 = dt.Rows[0]["cInvStd"].ToString().Trim();
                    s批号 = dt.Rows[0]["批号"].ToString().Trim();
                    d数量 = base.ReturnObjectToDecimal(dt.Rows[0]["数量"], 6);
                    d毛重 = base.ReturnObjectToDecimal(dt.Rows[0]["毛重"], 6);
                    s长度 = dt.Rows[0]["长度"].ToString().Trim();
                    s炉号 = dt.Rows[0]["炉号"].ToString().Trim();
                    s客户 = dt销售出库单.Rows[0]["cCusCode"].ToString().Trim();

                    string sWhere = "cInvCode = '" + s存货编码 + "' and 批次号 = '" + s批号.Substring(0, s批号.Length - 3) + "' and isnull(cBarcode,'') = ''";
                    DataRow[] dr销售出库 = dt销售出库单.Select(sWhere);
                    if (dr销售出库.Length > 0)
                    {
                        string sRDsID = dr销售出库[0]["autoid"].ToString().Trim();
                        s单据体ID = sRDsID;

                        for (int i = 0; i < dt销售出库单.Rows.Count; i++)
                        {
                            string sRDsID2 = dt销售出库单.Rows[i]["autoid"].ToString().Trim();

                            if (sRDsID == sRDsID2)
                            {
                                dt销售出库单.Rows[i]["cBarCode"] = txt条形码.Text.Trim();
                                dt销售出库单.Rows[i]["cBatch"] = s批号;
                                dt销售出库单.Rows[i]["iQuantity"] = d数量;
                                break;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("单据已扫描或条码不匹配");
                    }

                    txtInfo.Text = txtInfo.Text + "条形码:   " + txt条形码.Text.Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "销售出库单:   " + s单据号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "客户:   [" + s客户 + "]" + dt销售出库单.Rows[0]["cCusName"].ToString().Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "原料编码：" + s存货编码 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "原料名称：" + s存货名称 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "原料规格：" + s规格型号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "批号：    " + s批号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "炉号：    " + s炉号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "数量：    " + d数量.ToString().Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "毛重：    " + d毛重.ToString().Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "长度：    " + s长度 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "ID：    " + s单据体ID + "\r\n";

                    btn确定.Focus();
                }
                else
                {
                    txt条形码.Text = "";
                    txtInfo.Text = "";
                    txt条形码.Focus();
                    throw new Exception("获得条码信息失败，或条码与销售订单不匹配");
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