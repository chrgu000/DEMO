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
    public partial class Frm现品票登记_Edit : FrmBase
    {
        public DataTable dtGrid;

        public Frm现品票登记_Edit(DataTable dt)
        {
            InitializeComponent();
            dtGrid = dt;
        }

        private void btn确定_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt条形码.Text.Trim() != "")
                {
                    DataRow dw = dtGrid.NewRow();
                    dw["供应商"] = txt供应商.Text.Trim();
                    dw["门号"] = txt门号.Text.Trim();
                    dw["产品名称"] = txt产品名称.Text.Trim();
                    dw["品番"] = txt品番.Text.Trim();
                    dw["箱种"] = txt箱种.Text.Trim();
                    dw["收容数"] = txt收容数.Text.Trim();
                    dw["送货数量"] = txt送货数量.Text.Trim();
                    dw["纳入指示日期"] = txt纳入指示日期.Text.Trim();
                    dw["箱数"] = txt箱数.Text.Trim();
                    dw["订单编号"] = txt订单编号.Text.Trim();
                    dw["条形码"] = txt条形码.Text.Trim();
                    dw["登记人"] = sUserID;
                    dtGrid.Rows.Add(dw);

                    txt条形码扫描.Text = "";

                    Interaction.Beep();

                    txt条形码扫描.Focus();

                }
            }
            catch (Exception ee)
            {
                Msg("确定失败 " + ee.Message);
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
            txt门号.Text = "";
            txt产品名称.Text = "";
            txt品番.Text = "";
            txt箱种.Text = "";
            txt送货数量.Text = "";
            txt纳入指示日期.Text = "";
            txt箱数.Text = "";
            txt订单编号.Text = "";
            txt条形码.Text = "";
            txt收容数.Text = "";
        }

        private void Frm现品票登记_Edit_Load(object sender, EventArgs e)
        {
            try
            {
                SetNull();
                txt条形码扫描.Focus();
            }
            catch (Exception ee)
            {
                Msg("加载窗体失败 " + ee.Message);
            }
        }

    //    private void GetBar(string sBarCode, out string VenCode,  out string InvName, out string InvCode, out string iHZ
    //, out string iQty, out string iSheDate, out string iBoxQty, out string OrderNo, out string iPlace)
    //    {
    //        VenCode = sBarCode.Substring(53 - 1, 12);
    //        InvName = "";
    //        InvCode = sBarCode.Substring(4 - 1, 10);
    //        iHZ = sBarCode.Substring(1 - 1, 2);
    //        iQty = sBarCode.Substring(46 - 1, 7);
    //        iSheDate = sBarCode.Substring(38 - 1, 8);
    //        iBoxQty = "0";
    //        OrderNo = sBarCode.Substring(30 - 1, 8);
    //        iPlace = sBarCode.Substring(66 - 1, 5);
    //    }



        private void txt单据号扫描_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //txt条形码.Text = txt条形码扫描.Text;
                    string sBarCode = txt条形码扫描.Text;
                    if (sBarCode.Length < 82)
                    {
                        throw new Exception("条码不正确");
                    }

                    string VenCode = sBarCode.Substring(53 - 1, 12);
                    //string Door = "";
                    //string InvName = "";
                    string InvCode = sBarCode.Substring(4 - 1, 10);
                    string iHZ = sBarCode.Substring(1 - 1, 2);
                    string iQty = sBarCode.Substring(46 - 1, 7);
                    string iSheDate = sBarCode.Substring(38 - 1, 8);
                    //string iBoxQty = "0";
                    string OrderNo = sBarCode.Substring(30 - 1, 8);
                    string iPlace = sBarCode.Substring(65 - 1, 6);
                    //拆分条形码
                    //GetBar(sBarCode, out VenCode, out  InvName, out  InvCode, out  iHZ, out  iQty, out iSheDate, out iBoxQty, out OrderNo, out iPlace);

                    //MessageBox.Show(InvCode + "●" + iHZ + "●" + iQty + "●" + iSheDate + "●" + OrderNo + "●" + iPlace);

                    DataTable dtDoor = clsWeb.sDoor(InvCode, iPlace);
                    if (dtDoor == null || dtDoor.Rows.Count == 0)
                    {
                        throw new Exception("门号不存在");
                    }

                    DataTable dtInv = clsWeb.dtInventory(InvCode);
                    if (dtInv.Rows.Count == 0)
                    {
                        throw new Exception("存货编码不存在");
                    }

                    SetNull();

                    int i收容数 = BaseDllMobile.ClsRetrunValue.ReturnInt(dtDoor.Rows[0]["srs"].ToString().Trim());
                    txt收容数.Text = dtDoor.Rows[0]["srs"].ToString().Trim();
                    txt供应商.Text = VenCode;
                    txt门号.Text = dtDoor.Rows[0]["iDoor"].ToString().Trim();
                    txt产品名称.Text = dtInv.Rows[0]["cInvName"].ToString().Trim();
                    txt品番.Text = InvCode;
                    txt箱种.Text = dtDoor.Rows[0]["xz"].ToString().Trim();
                    txt送货数量.Text = BaseDllMobile.ClsRetrunValue.ReturnDecimal(iQty.Trim()).ToString();
                    txt纳入指示日期.Text = Convert.ToInt32(iSheDate).ToString();


                    txt箱数.Text = Math.Ceiling(Convert.ToDouble(Convert.ToDecimal(iQty)) / i收容数).ToString();
                    txt订单编号.Text = OrderNo;
                    txt条形码.Text = txt条形码扫描.Text.Trim();
                    txt条形码扫描.Text = string.Empty;


                    //Interaction.Beep();

                    btn确定_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                Msg(ee.Message);

                SetNull();
                txt条形码扫描.Text = "";
                txt条形码扫描.Focus();
            }
        }

    }
}