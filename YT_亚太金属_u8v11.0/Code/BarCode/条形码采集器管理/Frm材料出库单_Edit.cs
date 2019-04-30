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
                btn确定.Focus();

                if (txt条形码.Text.Trim() == "")
                    return;

                if(txt货仓.Text.Trim() == "")
                {
                    txt货仓.Focus();
                    throw new Exception("请输入货仓信息");
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
                        string s仓库 = dt材料出库.Rows[i]["仓库"].ToString().Trim();
                        string s存货编码 = dt材料出库.Rows[i]["存货编码"].ToString().Trim();
                        if (s仓库 != txt仓库.Text.Trim())
                        {
                            throw new Exception("同一张材料出库单，仓库必须一致");
                        }
                       
                        //物料与生产订单是否一致
                    }
                }

                //仓库、货位现存量是否足够
                decimal d现存量 = clsWeb.d仓库现存量(txt存货编码.Text.Trim(), txt批号.Text.Trim(), txt材质.Text.Trim(), txt渗层.Text.Trim(), txt统一号.Text.Trim(), txt工艺要求.Text.Trim(), txt仓库.Text.Trim());
                if (d现存量 < ReturnObjectToDecimal(txt数量.Text.Trim(), 6))
                {
                    throw new Exception("存货" + txt存货编码.Text.Trim() + "仓库现存量不足");
                }
                d现存量 = clsWeb.d货位现存量(txt存货编码.Text.Trim(), txt批号.Text.Trim(), txt材质.Text.Trim(), txt渗层.Text.Trim(), txt统一号.Text.Trim(), txt工艺要求.Text.Trim(), txt货位.Text.Trim());
                if (d现存量 < ReturnObjectToDecimal(txt数量.Text.Trim(), 6))
                {
                    throw new Exception("存货" + txt存货编码.Text.Trim() + "货位现存量不足");
                }

                DataRow dr = dt材料出库.NewRow();
                dr["存货编码"] = txt存货编码.Text.Trim();
                dr["存货名称"] = txt存货名称.Text.Trim();
                dr["规格型号"] = txt规格型号.Text.Trim();
                dr["批号"] = txt批号.Text.Trim();
                dr["cFree1"] = txt材质.Text.Trim();
                dr["cFree2"] = txt渗层.Text.Trim();
                dr["cFree3"] = txt统一号.Text.Trim();
                dr["cFree4"] = txt工艺要求.Text.Trim();
                //dr["cFree5"] = sFree5;
                //dr["cFree6"] = sFree6;
                //dr["cFree7"] = sFree7;
                //dr["cFree8"] = sFree8;
                //dr["cFree9"] = sFree9;
                //dr["cFree10"] = sFree10;
                dr["数量"] = txt数量.Text.Trim();
                dr["单据号"] = s生产订单号;
                //dr["行号"] = s行号;
                dr["条形码"] = txt条形码.Text.Trim();
                dr["仓库"] = txt仓库.Text.Trim();
                dr["货位"] = txt货位.Text.Trim();
                dr["制单人"] = sUserName;
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
            txt数量.Text = "";
            txt条形码.Text = "";
            txt材质.Text = "";
            txt仓库.Text = "";
            txt货位.Text = "";
            txt货仓.Text = "";
        }

        private void Frm采购入库单_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                SetNull();
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
                txt条形码_Validated(null, null);
            }
        }

        private void txt货仓_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                txt货仓_Validated(null, null);
            }
        }

        //private decimal d仓库现存量(string sInvCode, string sBatch, string sFree1, string sWhCode)
        //{
        //    decimal d = 0;

        //    try
        //    {
        //        d = clsWeb.d仓库现存量(sInvCode, sBatch, sFree1,"","","", sWhCode);
        //    }
        //    catch { }

        //    return d;
        //}


        //private decimal d货位现存量(string sInvCode, string sBatch, string sFree1, string sWhPos)
        //{
        //    decimal d = 0;

        //    try
        //    {
        //        d = clsWeb.d货位现存量(sInvCode, sBatch, sFree1, sWhPos);
        //    }
        //    catch { }

        //    return d;
        //}

        private void txt货仓_Validated(object sender, EventArgs e)
        {
            try
            {
                string 货仓 = txt货仓.Text.Trim();

                DataTable dt = clsWeb.dt货仓(货仓);
                if (dt == null || dt.Rows.Count < 1)
                {
                    txt货仓.Text = "";
                    txt仓库.Text = "";
                    txt货位.Text = "";
                    txt货仓.Focus();
                    throw new Exception("获得仓库，货位信息失败");
                }
                else
                {
                    txt仓库.Text = dt.Rows[0]["cWhCode"].ToString().Trim();
                    int iPos = ReturnObjectToInt(dt.Rows[0]["bWhPos"]);
                    if (iPos == 1 && dt.Rows[0]["cPosCode"].ToString().Trim() == "")
                    {
                        throw new Exception("该仓库有货位管理，请输入货位");
                    }
                    else
                    {
                        txt货位.Text = dt.Rows[0]["cPosCode"].ToString().Trim();
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
                txt仓库.Text = "";
                txt货位.Text = "";
                txt货仓.Focus();
            }
        }

        private void txt条形码_Validated(object sender, EventArgs e)
        {
            try
            {
                string sBarCode = txt条形码.Text.Trim();
                if (sBarCode.Length <= 0)
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
                    SetNull();
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

                sBarCode = ReturnObjectToLong(sBarCode).ToString().Trim();
                DataTable dt = clsWeb.dt材料出库条码信息(sBarCode, s生产订单号, "");
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt存货编码.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                    txt存货名称.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                    txt规格型号.Text = dt.Rows[0]["cInvStd"].ToString().Trim();
                    txt批号.Text = dt.Rows[0]["cBatch"].ToString().Trim();
                    txt材质.Text = dt.Rows[0]["cFree1"].ToString().Trim();
                    txt渗层.Text = dt.Rows[0]["cFree2"].ToString().Trim();
                    txt统一号.Text = dt.Rows[0]["cFree3"].ToString().Trim();
                    txt工艺要求.Text = dt.Rows[0]["cFree4"].ToString().Trim();
                    txt数量.Text = ReturnObjectToDecimal(dt.Rows[0]["iQuantity"], 2).ToString();
                    

                    txt货位.Focus();
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