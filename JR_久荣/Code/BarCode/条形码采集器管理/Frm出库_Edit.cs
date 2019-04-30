using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BarCode
{
    public partial class Frm出库_Edit : FrmBase
    {
        public string sBarCode;
        public DataTable dtGrid;

        public Frm出库_Edit(string BarCode, DataTable dt)
        {
            InitializeComponent();
            sBarCode = BarCode;
            dtGrid = dt;
        }   

        private void btn确定_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt二维码.Text.Trim() != "")
                {
                    DataRow dw = dtGrid.NewRow();
                    dw["供应商"] = txt供应商.Text.Trim();
                    dw["产品名称"] = txt产品名称.Text.Trim();
                    dw["品番"] = txt品番.Text.Trim();
                    dw["数量"] = txt数量.Text.Trim();
                    dw["箱数"] = txt箱数.Text.Trim();
                    dw["单据号"] = txt单据号.Text.Trim();
                    dw["单据子表序号"] = txt单据子表序号.Text.Trim();
                    dw["单据序号"] = txt单据序号.Text.Trim();
                    dw["登记人"] = sUserID;
                    dw["仓库"] = txt仓库.Text.Trim();
                    dtGrid.Rows.Add(dw);

                    txt二维码.Text = "";

                    Interaction.Beep();

                    txt二维码.Focus();
                }
            }
            catch (Exception ee)
            {
                Msg("操作失败 " + ee.Message);

                SetNull();
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
                Msg("返回失败 " + ee.Message);
            }
        }

        private void SetNull()
        {
            txt供应商.Text = "";
            txt产品名称.Text = "";
            txt品番.Text = "";
            txt数量.Text = "";
            txt箱数.Text = "";
            txt单据号.Text = "";
            txt单据子表序号.Text = "";
            txt单据序号.Text = "";
            txt仓库.Text = "";
            txt条形码.Text = "";
        }

        private void Frm出库_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                SetNull();
                txt二维码.Focus();
            }
            catch (Exception ee)
            {
                Msg("加载窗体失败 " + ee.Message);
            }
        }

        

        private void txt二维码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string iUsedAutoID = "";
                    for (int i = 0; i < dtGrid.Rows.Count; i++)
                    {
                        string AutoID = dtGrid.Rows[i]["单据子表序号"].ToString();
                        if (AutoID != "")
                        {
                            if (iUsedAutoID != "")
                            {
                                iUsedAutoID = iUsedAutoID + ",";
                            }
                            iUsedAutoID = iUsedAutoID + AutoID;
                        }
                    }
                    DataTable dt = clsWeb.dt发货计划(sBarCode, txt二维码.Text, iUsedAutoID);
                    if (dt == null || dt.Rows.Count < 1)
                    {
                        throw new Exception("发货计划不存在或发货计划已出库");
                    }

                    if (txt仓库.Text == "")
                    {
                        txt仓库.Text = dt.Rows[0]["cDefWareHouse"].ToString();
                    }
                    else
                    {
                        if (dt.Rows[0]["cDefWareHouse"].ToString() != txt仓库.Text.Trim())
                        {
                            throw new Exception("不允许从不同仓库出库");
                        }
                    }

                    SetNull();

                    txt供应商.Text = dt.Rows[0]["VenCode"].ToString();
                    txt产品名称.Text = dt.Rows[0]["cInvName"].ToString();
                    txt品番.Text = dt.Rows[0]["InvCode"].ToString();
                    txt数量.Text = dt.Rows[0]["leftQty"].ToString();
                    txt箱数.Text = dt.Rows[0]["leftXS"].ToString();
                    txt单据号.Text = dt.Rows[0]["cCode"].ToString();
                    txt单据子表序号.Text = dt.Rows[0]["AutoID"].ToString();
                    txt单据序号.Text = dt.Rows[0]["ID"].ToString();
                    txt条形码.Text = txt二维码.Text.Trim();
                    txt仓库.Text = dt.Rows[0]["cDefWareHouse"].ToString();

                    btn确定_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                Msg(ee.Message);

                SetNull();
                txt二维码.Text = "";
                txt二维码.Focus();
            }
        }

        private void msgBox_Load(object sender, EventArgs e)
        {

        }
    }
}