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
    public partial class Frm材料出库单核查 : FrmBase
    {
        public string s生产订单号;
        public string s行号;
        public Frm材料出库单核查(string sCode, string sRowNo)
        {
            
            InitializeComponent();
            s生产订单号 = sCode;
            s行号 = sRowNo;
            txt单据号.Text = s生产订单号;
        }

        private void Frm材料出库单核查_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtGrid = clsWeb.dt生产订单子件未出库信息(txt单据号.Text.Trim(), "");
                
            }
            catch (Exception ee)
            {
                msgBox.Text = "加载采购入库单失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //btn确定.Focus();

                //if (txt条形码.Text.Trim() == "")
                //    return;

                //if (txt货仓.Text.Trim() == "")
                //{
                //    txt货仓.Focus();
                //    throw new Exception("请输入货仓信息");
                //}

                //if (dt材料出库 != null)
                //{
                //    for (int i = 0; i < dt材料出库.Rows.Count; i++)
                //    {
                //        //条形码只能扫描一次出库
                //        if (dt材料出库.Rows[i]["条形码"].ToString().Trim() == txt条形码.Text.Trim())
                //        {
                //            throw new Exception("该条形码已经存在");
                //        }

                //        //同一张材料出库单必须同一个仓库发料
                //        string s仓库 = dt材料出库.Rows[i]["仓库"].ToString().Trim();
                //        string s存货编码 = dt材料出库.Rows[i]["存货编码"].ToString().Trim();
                //        if (s仓库 != txt仓库.Text.Trim())
                //        {
                //            throw new Exception("同一张材料出库单，仓库必须一致");
                //        }

                //        //物料与生产订单是否一致
                //    }
                //}

                ////仓库、货位现存量是否足够
                //decimal d现存量 = clsWeb.d仓库现存量(txt存货编码.Text.Trim(), txt批号.Text.Trim(), txt材质.Text.Trim(), txt渗层.Text.Trim(), txt统一号.Text.Trim(), txt工艺要求.Text.Trim(), txt仓库.Text.Trim());
                //if (d现存量 < ReturnObjectToDecimal(txt数量.Text.Trim(), 6))
                //{
                //    throw new Exception("存货" + txt存货编码.Text.Trim() + "仓库现存量不足");
                //}
                //d现存量 = clsWeb.d货位现存量(txt存货编码.Text.Trim(), txt批号.Text.Trim(), txt材质.Text.Trim(), txt渗层.Text.Trim(), txt统一号.Text.Trim(), txt工艺要求.Text.Trim(), txt货位.Text.Trim());
                //if (d现存量 < ReturnObjectToDecimal(txt数量.Text.Trim(), 6))
                //{
                //    throw new Exception("存货" + txt存货编码.Text.Trim() + "货位现存量不足");
                //}

                //DataRow dr = dt材料出库.NewRow();
                //dr["存货编码"] = txt存货编码.Text.Trim();
                //dr["存货名称"] = txt存货名称.Text.Trim();
                //dr["规格型号"] = txt规格型号.Text.Trim();
                //dr["批号"] = txt批号.Text.Trim();
                //dr["cFree1"] = txt材质.Text.Trim();
                //dr["cFree2"] = txt渗层.Text.Trim();
                //dr["cFree3"] = txt统一号.Text.Trim();
                //dr["cFree4"] = txt工艺要求.Text.Trim();
                ////dr["cFree5"] = sFree5;
                ////dr["cFree6"] = sFree6;
                ////dr["cFree7"] = sFree7;
                ////dr["cFree8"] = sFree8;
                ////dr["cFree9"] = sFree9;
                ////dr["cFree10"] = sFree10;
                //dr["数量"] = txt数量.Text.Trim();
                //dr["单据号"] = s生产订单号;
                //dr["行号"] = s行号;
                //dr["条形码"] = txt条形码.Text.Trim();
                //dr["仓库"] = txt仓库.Text.Trim();
                //dr["货位"] = txt货位.Text.Trim();
                //dr["制单人"] = sUserName;
                //dt材料出库.Rows.Add(dr);

                //SetNull();
                //txt条形码.Focus();
            }
            catch (Exception ee)
            {
                msgBox.Text = "操作失败";
                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
                msgBox.WindowState = FormWindowState.Maximized;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      

        private void dataGrid1_Click(object sender, EventArgs e)
        {

        }

        private void Frm材料出库单核查_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }
    }
}