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
    public partial class Frm货位调拨_Edit : FrmBase
    {
        public DataTable dtGrid;

        public Frm货位调拨_Edit(DataTable dt)
        {
            InitializeComponent();

            dtGrid = dt;
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt条形码.Text.Trim() == "")
                    return;

                if (txt货位1.Text.Trim() == "")
                {
                    txt货位1.Focus();
                    throw new Exception("请输入调整前货位");
                }

                if (txt货位2.Text.Trim() == "")
                {
                    txt货位2.Focus();
                    throw new Exception("请输入调整后货位");
                }

                if (txt数量.Text.Trim() == "" || txt数量.Text.Trim() == "0")
                {
                    txt数量.Focus();
                    throw new Exception("请输入调整数量");
                }

                bool b = false;
                if (dtGrid != null)
                {
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        if (dtGrid.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                        {
                            throw new Exception("该条形码已经存在");
                        }

                    }
                }

                DataRow dr = dtGrid.NewRow();
                dr["存货编码"] = txt存货编码.Text.Trim();
                dr["存货名称"] = txt存货名称.Text.Trim();
                dr["规格型号"] = txt规格型号.Text.Trim();
                dr["批号"] = txt批号.Text.Trim();
                dr["数量"] = txt数量.Text.Trim();
                dr["件数"] = txt件数.Text.Trim();
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
                dr["条形码"] = txt条形码.Text.Trim();
                dr["调整前仓库"] = txt仓库1.Text.Trim();
                dr["调整后仓库"] = txt仓库2.Text.Trim();
                dr["调整前货位"] = txt货位1.Text.Trim();
                dr["调整后货位"] = txt货位2.Text.Trim();
                dr["制单人"] = sUserName;
                dtGrid.Rows.Add(dr);

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
            txt工艺要求.Text = "";
            txt统一号.Text = "";
            txt渗层.Text = "";
            txt换算率.Text = "";
            txt件数.Text = "";

            txt仓库1.Text = "";
            txt仓库2.Text = "";
            txt货位1.Text = "";
            txt货位2.Text = "";
        }

        private void Frm货位调整单_Edit_Load(object sender, EventArgs e)
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
                    txt条形码_Validated(null, null);
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
                    txt条形码.Text = "";
                    SetNull();
                    txt条形码.Focus();
                    throw new Exception("条码长度不对");
                }

                sBarCode = ReturnObjectToLong(sBarCode).ToString().Trim();
                DataTable dt = clsWeb.dt存货条码信息(sBarCode);
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

                    DataTable dtinv = clsWeb.dt存货信息(txt存货编码.Text.Trim());
                    if (dtinv == null || dtinv.Rows.Count < 1)
                    {
                        throw new Exception("获得存货信息失败");
                    }
                    else
                    {
                        txt换算率.Text = dtinv.Rows[0]["iChangRate"].ToString().Trim();
                    }

                    txt货位1.Focus();
                }
                else
                {
                    txt条形码.Text = "";
                    SetNull();
                    txt条形码.Focus();
                    throw new Exception("获得条码信息失败，或条码与生产订单不匹配");
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

        private void msgBox_Load(object sender, EventArgs e)
        {

        }


        private void txt货位1_Validated(object sender, EventArgs e)
        {
            try
            {
                string 货仓 = txt货位1.Text.Trim();

                DataTable dt = clsWeb.dt货仓(货仓);
                if (dt == null || dt.Rows.Count < 1)
                {
                    txt货位1.Text = "";
                    throw new Exception("获得仓库，货位信息失败");
                }
                else
                {
                    txt仓库1.Text = dt.Rows[0]["cWhCode"].ToString().Trim();
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "获得货位失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;

                txt仓库1.Text = "";
                txt货位1.Text = "";
            }
        }

        private void txt货位2_Validated(object sender, EventArgs e)
        {
            
            try
            {
                if (txt货位1.Text == "")
                {
                    throw new Exception("请先输入调整前货仓");
                }
                string 货仓 = txt货位2.Text.Trim();

                DataTable dt = clsWeb.dt货仓(货仓);
                if (dt == null || dt.Rows.Count < 1)
                {
                    txt货位2.Text = "";
                    throw new Exception("获得仓库，货位信息失败");
                }
                else
                {
                    txt仓库2.Text = dt.Rows[0]["cWhCode"].ToString().Trim();
                    if (txt货位2.Text == txt货位1.Text)
                    {
                        throw new Exception("调整后货仓必须与调整前不一致");
                    }
                }
                txt数量.Focus();
            }
            catch (Exception ee)
            {
                msgBox.Text = "获得货位失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;

                txt仓库2.Text = "";
                txt货位2.Text = "";
            }
        }

        private void txt仓库1_Validated(object sender, EventArgs e)
        {

        }

        private void txt仓库2_Validated(object sender, EventArgs e)
        {
        }

        private void txt数量_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txt换算率.Text != "")
                {
                    txt件数.Text = ReturnObjectToDecimal(ReturnObjectToDecimal(txt数量.Text, 6) / ReturnObjectToDecimal(txt换算率.Text, 6), 6).ToString();
                }
            }
            catch (Exception ee)
            {
                msgBox.Text = "获得货位失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;

                txt仓库1.Text = "";
                txt货位1.Text = "";
                
            }
        }


    }
}