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
        public string s到货单号;
        string s默认仓库 = "";
        string s默认货位 = "";
        decimal d到货数量 = 0;
        decimal d到货件数 = 0;
        decimal d换算率 = 0;
        decimal d超订单百分比 = 0;
        string sFree1 = "";
        string sFree2 = "";
        string sFree3 = "";
        string sFree4 = "";
        string sFree5 = "";
        string sFree6 = "";
        string sFree7 = "";
        string sFree8 = "";
        string sFree9 = "";
        string sFree10 = "";
        string s条形码 = "";
        string s采购到货单子表ID = "";
        string s采购订单子表ID = "";

        public Frm采购入库单_Edit(string sCode,DataTable dt)
        {
            InitializeComponent();

            dt采购入库 = dt;
            s到货单号 = sCode;
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt条形码.Text.Trim() == "")
                    return;

                if(txt货仓.Text.Trim() == "")
                {
                    txt货仓.Focus();
                    throw new Exception("请输入货仓信息");
                }
                
                string sBarCode = txt条形码.Text.Trim();
                DataTable dt = clsWeb.dt到货单明细信息(s到货单号, " d.AutoID = '" + sBarCode + "'");
                if (dt != null && dt.Rows.Count == 1)
                {

                    DataRow dr = dt采购入库.NewRow();
                    dr["存货编码"] = txt存货编码.Text.Trim();
                    dr["存货名称"] = txt存货名称.Text.Trim();
                    dr["规格型号"] = txt规格型号.Text.Trim();
                    dr["批号"] = txt批号.Text.Trim();
                    if (txt入库数量.Text.Trim() != "")
                    {
                        dr["入库数量"] = txt入库数量.Text.Trim();
                    }
                    if (txt入库件数.Text.Trim() != "")
                    {
                        dr["入库件数"] = txt入库件数.Text.Trim();
                    }
                    if (txt拒收数量.Text.Trim() != "")
                    {
                        dr["拒收数量"] = txt拒收数量.Text.Trim();
                    }
                    if (txt拒收件数.Text.Trim() != "")
                    {
                        dr["拒收件数"] = txt拒收件数.Text.Trim();
                    }
                    dr["换算率"] = d换算率;
                    dr["单据号"] = s到货单号;
                    dr["仓库"] = s默认仓库;
                    dr["货位"] = s默认货位;
                    dr["制单人"] = sUserName;
                    dr["cFree1"] = sFree1;
                    dr["cFree2"] = sFree2;
                    dr["cFree3"] = sFree3;
                    dr["cFree4"] = sFree4;
                    dr["cFree5"] = sFree5;
                    dr["cFree6"] = sFree6;
                    dr["cFree7"] = sFree7;
                    dr["cFree8"] = sFree8;
                    dr["cFree9"] = sFree9;
                    dr["cFree10"] = sFree10;
                    dr["条形码"] = s条形码;
                    dr["采购到货单子表ID"] = s采购到货单子表ID;
                    dr["采购订单子表ID"] = s采购订单子表ID;
                    dt采购入库.Rows.Add(dr);
                }
                else if (dt.Rows.Count > 0)
                {
                    decimal d入库数量 = ReturnObjectToDecimal(txt入库数量.Text, 2);
                    decimal d入库件数 = ReturnObjectToDecimal(txt入库件数.Text, 2);
                    decimal d拒收数量 = ReturnObjectToDecimal(txt拒收数量.Text, 2);
                    decimal d拒收件数 = ReturnObjectToDecimal(txt拒收件数.Text, 2);
                    decimal 换算率 = d入库件数 / d入库数量;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        decimal d到货数量 = ReturnObjectToDecimal(dt.Rows[0]["iQuantity"], 2) - ReturnObjectToDecimal(dt.Rows[0]["fValidInQuan"], 2) - ReturnObjectToDecimal(dt.Rows[0]["fRefuseQuantity"], 2);
                        decimal d到货件数 = ReturnObjectToDecimal(dt.Rows[0]["iNum"], 2) - ReturnObjectToDecimal(dt.Rows[0]["fValidInNum"], 2) - ReturnObjectToDecimal(dt.Rows[0]["fRefuseNum"], 2);

                        DataRow dr = dt采购入库.NewRow();
                        dr["存货编码"] = txt存货编码.Text.Trim();
                        dr["存货名称"] = txt存货名称.Text.Trim();
                        dr["规格型号"] = txt规格型号.Text.Trim();
                        dr["批号"] = txt批号.Text.Trim();

                        if (d入库数量 > 0)
                        {
                            decimal d数量 = 0;
                            decimal d件数 = 0;
                            if (d到货数量 > d入库数量)
                            {
                                d数量 = d入库数量;
                            }
                            else
                            {
                                d数量 = d到货数量;
                            }
                            d件数 = d数量 * 换算率;
                            d入库数量 = d入库数量 - d数量;
                            d入库件数 = d入库件数 - d件数;
                            d到货数量 = d到货数量 - d数量;
                            d到货件数 = d到货件数 - d件数;
                            dr["入库数量"] = d数量;
                            if (d件数 != 0)
                            {
                                dr["入库件数"] = d件数;
                            }
                        }
                        if (d拒收数量 > 0 && d到货数量>0)
                        {
                            decimal d数量 = 0;
                            decimal d件数 = 0;
                            if (d到货数量 > d拒收数量)
                            {
                                d数量 = d拒收数量;
                            }
                            else
                            {
                                d数量 = d到货数量;
                            }
                            d件数 = d数量 * 换算率;
                            d拒收数量 = d拒收数量 - d数量;
                            d拒收件数 = d拒收件数 - d件数;
                            d到货数量 = d到货数量 - d数量;
                            d到货件数 = d到货件数 - d件数;
                            dr["拒收数量"] = d数量;
                            if (d件数 != 0)
                            {
                                dr["拒收件数"] = d件数;
                            }
                        }
                        dr["换算率"] = d换算率;
                        dr["单据号"] = s到货单号;
                        dr["仓库"] = s默认仓库;
                        dr["货位"] = s默认货位;
                        dr["制单人"] = sUserName;
                        dr["cFree1"] = sFree1;
                        dr["cFree2"] = sFree2;
                        dr["cFree3"] = sFree3;
                        dr["cFree4"] = sFree4;
                        dr["cFree5"] = sFree5;
                        dr["cFree6"] = sFree6;
                        dr["cFree7"] = sFree7;
                        dr["cFree8"] = sFree8;
                        dr["cFree9"] = sFree9;
                        dr["cFree10"] = sFree10;
                        dr["条形码"] = s条形码;
                        dr["采购到货单子表ID"] = dt.Rows[i]["AutoID"].ToString().Trim();
                        dr["采购订单子表ID"] = dt.Rows[i]["iPOsID"].ToString().Trim();
                        dt采购入库.Rows.Add(dr);
                    }
                }
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
            txt存货编码.Text = "";
            txt存货名称.Text = "";
            txt规格型号.Text = "";
            txt批号.Text = "";
            txt入库数量.Text = "";
            txt入库件数.Text = "";
            txt拒收数量.Text = "";
            txt拒收件数.Text = "";
            txt条形码.Text = "";
            s默认仓库 = "";
            s默认货位 = "";
            d换算率 = 0;
            d超订单百分比 = 0;
            txt货仓.Text = "";
            sFree1 = "";
            sFree2 = "";
            sFree3 = "";
            sFree4 = "";
            sFree5 = "";
            sFree6 = "";
            sFree7 = "";
            sFree8 = "";
            sFree9 = "";
            sFree10 = "";
            s条形码 = "";
            s采购到货单子表ID = "";
            s采购订单子表ID = "";
        }

        private void Frm采购入库单_Edit_Load(object sender, EventArgs e)
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
            try
            {
                if (e.KeyValue == 13)
                {
                    //txt条形码_Validated(null, null);
                    txt货仓.Focus();
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

        private void txt条形码_Validated(object sender, EventArgs e)
        {
            try
            {
                string sBarCode = txt条形码.Text.Trim();
                if (sBarCode.Length == 0)
                {
                    return;
                }
                if (sBarCode.Length != 10)
                {
                    throw new Exception("条形码长度不正确");
                }
                sBarCode = ReturnObjectToLong(sBarCode).ToString().Trim();

                for (int i = 0; i < dt采购入库.Rows.Count; i++)
                {
                    if (dt采购入库.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                    {
                        DialogResult d = MessageBox.Show("该条码在本次扫描已经存在，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1);
                        if (d == DialogResult.Yes)
                        {
                            break;
                        }
                        else
                        {
                            return;
                        }
                    }
                }



                DataTable dt = clsWeb.dt到货单明细信息(s到货单号, " d.AutoID = '" + sBarCode + "'");
                if (dt != null && dt.Rows.Count > 0)
                {

                    txt存货编码.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                    txt存货名称.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                    txt规格型号.Text = dt.Rows[0]["cInvStd"].ToString().Trim();

                    if (dt.Rows[0]["是否批次管理"].ToString() == "False")
                    {
                        txt批号.Enabled = false;
                    }
                    else
                    {
                        txt批号.Enabled = true;
                        txt批号.Text = dt.Rows[0]["cBatch"].ToString().Trim();
                    }
                    txt货仓.Text = dt.Rows[0]["cPosition"].ToString().Trim();
                    s默认仓库 = dt.Rows[0]["cDefWareHouse"].ToString().Trim();
                    s默认货位 = dt.Rows[0]["cPosition"].ToString().Trim();
                    //到货单数量 - 入库数量 - 拒收数量;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        d到货数量 = d到货数量 + ReturnObjectToDecimal(dt.Rows[0]["iQuantity"], 2) - ReturnObjectToDecimal(dt.Rows[0]["fValidInQuan"], 2) - ReturnObjectToDecimal(dt.Rows[0]["fRefuseQuantity"], 2);
                        d到货件数 = d到货件数 + ReturnObjectToDecimal(dt.Rows[0]["iNum"], 2) - ReturnObjectToDecimal(dt.Rows[0]["fValidInNum"], 2) - ReturnObjectToDecimal(dt.Rows[0]["fRefuseNum"], 2);
                    }
                    txt入库数量.Text = d到货数量.ToString();
                    txt入库件数.Text = d到货件数.ToString();
                    txt拒收数量.Text = "";
                    txt拒收件数.Text = "";
                    d超订单百分比 = ReturnObjectToDecimal(dt.Rows[0]["fInExcess"], 2);
                    d换算率 = ReturnObjectToDecimal(dt.Rows[0]["iinvexchrate"], 6);
                    if (d换算率 == 0)
                    {
                        txt入库件数.Text = "";
                        txt拒收件数.Text = "";
                    }
                    sFree1 = dt.Rows[0]["cFree1"].ToString().Trim();
                    sFree2 = dt.Rows[0]["cFree2"].ToString().Trim();
                    sFree3 = dt.Rows[0]["cFree3"].ToString().Trim();
                    sFree4 = dt.Rows[0]["cFree4"].ToString().Trim();
                    //sFree5 = dt.Rows[0]["cFree5"].ToString().Trim();
                    //sFree6 = dt.Rows[0]["cFree6"].ToString().Trim();
                    //sFree7 = dt.Rows[0]["cFree7"].ToString().Trim();
                    //sFree8 = dt.Rows[0]["cFree8"].ToString().Trim();
                    //sFree9 = dt.Rows[0]["cFree9"].ToString().Trim();
                    //sFree10 = dt.Rows[0]["cFree10"].ToString().Trim();
                    s条形码 = txt条形码.Text.Trim();
                    txtAutoID.Text = dt.Rows[0]["AutoID"].ToString().Trim();
                    s采购到货单子表ID = txtAutoID.Text.Trim();
                    s采购订单子表ID = dt.Rows[0]["iPOsID"].ToString().Trim();

                    //提示货仓信息

                    try
                    {
                        DataTable dthw = clsWeb.dt货位(dt.Rows[0]["cInvCode"].ToString().Trim());
                        if (dthw != null && dthw.Rows.Count > 0)
                        {
                            txt提示货位.Text = dthw.Rows[0]["货位"].ToString();
                            if (dt.Rows.Count > 1)
                            {
                                txt提示货位.Text = txt提示货位.Text + "," + dthw.Rows[0]["货位"].ToString();
                            }
                        }
                    }
                    catch
                    {
                    }
                    txt货仓.Focus();
                }
                else
                {
                    txt条形码.Text = "";
                    SetNull();
                    txt条形码.Focus();
                    throw new Exception("获得条码信息失败，或条码与到货单不匹配");
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

        private void txt货仓_Validated(object sender, EventArgs e)
        {
            try
            {
                string 货仓 = txt货仓.Text.Trim();
                if (货仓 == "")
                {
                    return;
                }

                DataTable dt = clsWeb.dt货仓(货仓);
                if (dt == null || dt.Rows.Count < 1)
                {
                    txt货仓.Text = "";
                    s默认仓库 = "";
                    s默认货位 = "";
                    txt货仓.Focus();
                    throw new Exception("获得仓库，货位信息失败");
                }
                else
                {
                    s默认仓库 = dt.Rows[0]["cWhCode"].ToString().Trim();
                    int iPos = ReturnObjectToInt(dt.Rows[0]["bWhPos"]);
                    if (iPos == 1 && dt.Rows[0]["cPosCode"].ToString().Trim() == "")
                    {
                        throw new Exception("该仓库有货位管理，请输入货位");
                    }
                    else
                    {
                        s默认货位 = dt.Rows[0]["cPosCode"].ToString().Trim();
                    }
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "获得货位失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;

                txt货仓.Text = "";
                s默认仓库 = "";
                s默认货位 = "";
                txt货仓.Focus();
            }
        }

        private void txt入库数量_Validated(object sender, EventArgs e)
        {
            try
            {
                
                decimal d合格数量 = ReturnObjectToDecimal(txt入库数量.Text.Trim(), 0);
                txt入库数量.Text = d合格数量.ToString();
                decimal d合格件数 =  ReturnObjectToDecimal(txt入库件数.Text.Trim(), 6);
                if (d合格数量 != 0)
                {
                    d合格件数 = ReturnObjectToDecimal(d到货件数 / d到货数量 * d合格数量, 6);
                    txt入库件数.Text = d合格件数.ToString();
                }
                else
                {
                    txt入库数量.Text = "0";
                    txt入库件数.Text = "0";
                }


                decimal d拒收数量 = ReturnObjectToDecimal(txt拒收数量.Text.Trim(), 6);
                decimal d拒收件数 = ReturnObjectToDecimal(txt拒收件数.Text.Trim(), 6);
                if (d合格数量 + d拒收数量 > d到货数量 * (1 + d超订单百分比 / 100))
                {

                    txt入库数量.Text = "";
                    txt入库件数.Text = "";
                    throw new Exception("数量超出到货单数量");
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = ee.Message;
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void txt拒收数量_Validated(object sender, EventArgs e)
        {
            try
            {
                decimal d合格数量 = ReturnObjectToDecimal(txt入库数量.Text.Trim(), 6);
                decimal d合格件数 = ReturnObjectToDecimal(txt入库件数.Text.Trim(), 6);

                decimal d拒收数量 = ReturnObjectToDecimal(txt拒收数量.Text.Trim(), 0);
                txt拒收数量.Text = d拒收数量.ToString();

                decimal d拒收件数 = ReturnObjectToDecimal(txt拒收件数.Text.Trim(), 6);

                if (d拒收数量 != 0)
                {
                    d合格件数 = ReturnObjectToDecimal(d到货件数 / d到货数量 * d拒收数量, 6);
                    txt拒收件数.Text = d合格件数.ToString();
                }

                if (d合格数量 + d拒收数量 > d到货数量 * (1 + d超订单百分比 / 100))
                {
                   
                    txt拒收数量.Text = "";
                    throw new Exception("数量超出到货单数量");
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = ee.Message;
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

    }
}