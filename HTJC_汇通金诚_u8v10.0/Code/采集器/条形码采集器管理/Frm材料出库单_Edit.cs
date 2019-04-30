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
    public partial class Frm材料出库单_Edit : FrmBase
    {
        public DataTable dt材料出库;
        public string s生产订单号;
        public string s行号;

        string s仓库 = "";
        string s货位 = "";
        string s存货编码 = "";
        string s存货名称 = "";
        string s规格型号 = "";
        string s批号 = "";
        decimal d数量 = (decimal)0.00;
        string s长度 = "";
        string s炉号 = "";


        public Frm材料出库单_Edit(string sCode,string sRowNo, DataTable dt)
        {
            InitializeComponent();

            dt材料出库 = dt;
            s生产订单号 = sCode;
            s行号 = sRowNo;
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

                if(txt货仓.Text.Trim() == "")
                {
                    txt货仓.Focus();
                    throw new Exception("请输入货仓信息");
                }
                if (s存货编码.Trim() == "")
                {
                    return;
                }
                
                if (dt材料出库 != null)
                {
                    for (int i = 0; i < dt材料出库.Rows.Count; i++)
                    {
                        //条形码只能扫描一次出库
                        if (dt材料出库.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                        {
                            throw new Exception("该条形码已经存在");
                        }

                        //同一张材料出库单必须同一个仓库发料
                        if (s仓库 != dt材料出库.Rows[i]["仓库"].ToString().Trim())
                        {
                            throw new Exception("同一张材料出库单，仓库必须一致");
                        }
                       
                        //物料与生产订单是否一致
                    }
                }

                //仓库、货位现存量是否足够
                decimal d现存量 = clsWeb.d仓库现存量(s存货编码, s批号, s长度, s仓库);
                if (d现存量 * (decimal)1.2 < d数量)
                {
                    throw new Exception("存货" + s存货编码 + "仓库现存量不足");
                }
                d现存量 = clsWeb.d货位现存量(s存货编码, s批号, s长度, s货位);
                if (d现存量 * (decimal)1.2 < d数量)
                {
                    throw new Exception("存货" + s存货编码 + "货位现存量不足");
                }

                DataRow dr = dt材料出库.NewRow();
                dr["存货编码"] = s存货编码;
                dr["存货名称"] = s存货名称;
                dr["规格型号"] = s规格型号;
                dr["批号"] = s批号;
                dr["炉号"] = s炉号;
                dr["数量"] = d数量;
                dr["长度"] = s长度;
                dr["单据号"] = s生产订单号;
                dr["行号"] = s行号;
                dr["条形码"] = txt条形码.Text.Trim();
                dr["仓库"] = s仓库;
                dr["货位"] = s货位;
                dr["制单人"] = sUserID;
                dt材料出库.Rows.Add(dr);

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
        }

        private void Frm材料出库单_Edit_Load(object sender, EventArgs e)
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

        private void txt货仓_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt条形码.Focus();
            }
        }

        private decimal d仓库现存量(string sInvCode, string sBatch, string sFree1, string sWhCode)
        {
            decimal d = 0;

            try
            {
                d = clsWeb.d仓库现存量(sInvCode, sBatch, sFree1, sWhCode);
            }
            catch { }

            return d;
        }


        private decimal d货位现存量(string sInvCode, string sBatch, string sFree1, string sWhPos)
        {
            decimal d = 0;

            try
            {
                d = clsWeb.d货位现存量(sInvCode, sBatch, sFree1, sWhPos);
            }
            catch { }

            return d;
        }

        private void txt货仓_Validated(object sender, EventArgs e)
        {
            try
            {
                string 货仓 = txt货仓.Text.Trim();

                DataTable dt = clsWeb.dt货仓(货仓);
                if (dt == null || dt.Rows.Count < 1)
                {
                    SetNull();
                    txt货仓.Focus();
                    throw new Exception("获得仓库，货位信息失败");
                }
                else
                {
                    if (s仓库 == "")
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
                    SetNull();
                    txt条形码.Focus();
                    throw new Exception("条码长度不对");
                }

                int iCou = ReturnObjectToInt(clsWeb.Chk材料出库条码是否已经使用(txt条形码.Text.Trim()));
                if (iCou > 0)
                {
                    txt条形码.Text = "";
                    txtInfo.Text = "";
                    txt条形码.Focus();
                    throw new Exception("该条形码已经使用");
                }

                for (int i = 0; i < dt材料出库.Rows.Count; i++)
                {
                    if (dt材料出库.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                    {
                        txt条形码.Text = "";
                        SetNull();
                        txt条形码.Focus();
                        throw new Exception("本条码已经加载");
                    }
                }

                txtInfo.Text = "";
                sBarCode = ReturnObjectToLong(sBarCode).ToString().Trim();
                DataTable dt = clsWeb.dt材料出库条码信息(sBarCode, s生产订单号, s行号);
                if (dt != null && dt.Rows.Count > 0)
                {;
                    s存货编码 = dt.Rows[0]["存货编码"].ToString().Trim();
                    s存货名称 = dt.Rows[0]["cInvName"].ToString().Trim();
                    s规格型号 = dt.Rows[0]["cInvStd"].ToString().Trim();
                    s批号 = dt.Rows[0]["cBatch"].ToString().Trim();
                    d数量 = base.ReturnObjectToDecimal(dt.Rows[0]["iQuantity"], 6);
                    s长度 = dt.Rows[0]["cFree1"].ToString().Trim();
                    s炉号 = dt.Rows[0]["cBatchProperty6"].ToString().Trim();

                    txtInfo.Text = txtInfo.Text + "条形码:   " + txt条形码.Text.Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "生产订单号:   " + s生产订单号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "原料编码：" + s存货编码 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "原料名称：" + s存货名称 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "原料规格：" + s规格型号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "批号：    " + s批号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "炉号：    " + s炉号 + "\r\n";
                    txtInfo.Text = txtInfo.Text + "数量：    " + d数量.ToString().Trim() + "\r\n";
                    txtInfo.Text = txtInfo.Text + "长度：    " + s长度 + "\r\n";

                    btn确定.Focus();
                }
                else
                {
                    txt条形码.Text = "";
                    SetNull();
                    txt条形码.Focus();
                    throw new Exception("获得条码信息失败，或批次不匹配");
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