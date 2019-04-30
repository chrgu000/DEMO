using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Smartclient
{
    public partial class Frm工序转移 : FrmBase
    {
        DataTable dt工序;

        public Frm工序转移()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService cls = new TH.Smart.WebService.ClsUseWebService();
                dt工序 = cls.s标准工序();
                if (dt工序 != null && dt工序.Rows.Count > 0)
                {
                    for (int i = 0; i < dt工序.Rows.Count; i++)
                    {
                        combo工序.Items.Add(dt工序.Rows[i]["WorkProcessNo"].ToString().Trim());
                    }
                }

                combo工序.Focus();

                labelUid.Text = labelUid.Text.Replace("111111", TH.Smart.BaseClass.ClsBaseDataInfo.sUid);
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (label生产订单IDs.Text.Trim() == "")
                {
                    throw new Exception("获得生产订单信息失败");
                }
                if (combo工序.Text.Trim() == "")
                {
                    combo工序.Focus();
                    throw new Exception("请选择工序");
                }
                if (txtBarCode2.Text.Trim() == "")
                {
                    txtBarCode2.Focus();
                    throw new Exception("请扫描条形码");
                }
                if (txtBarCode.Text.Trim().Length != 12 && txtBarCode.Text.Trim().Length != 15)
                {
                    txtBarCode.Focus();
                    throw new Exception("请扫描原条码");
                }

                if (chk分包.Checked && txtBarCode2.Text.Trim().Length != 15)
                {
                    txtBarCode2.Focus();
                    throw new Exception("条码不正确");
                }

                decimal d数量 = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(txt数量.Text.Trim());
                if (d数量 <= 0)
                {
                    txt数量.Focus();
                    throw new Exception("请输入数量");
                }
                decimal d装箱数 = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(txt装箱数.Text.Trim());
                if (d数量 > d装箱数)
                {
                    txt数量.Focus();
                    throw new Exception("数量不能超过装箱数");
                }

                combo工序.Focus();

                DataTable dt = new DataTable();
                dt.TableName = "条形码数量";
                DataColumn dc = new DataColumn();
                dc.ColumnName = "WorkDetailsID";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "BarCode";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "BarCode2";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "工序";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "数量";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "iID";
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                dr["WorkDetailsID"] = label生产订单IDs.Text.Trim();
                dr["BarCode"] = txtBarCode.Text.Trim();
                dr["BarCode2"] = txtBarCode2.Text.Trim();
                dr["工序"] = combo工序.Text.Trim();
                dr["数量"] = txt数量.Text.Trim();
                dr["iID"] = label工序流转iID.Text.Trim();
                dt.Rows.Add(dr);

                TH.Smart.WebService.ClsUseWebService cls = new TH.Smart.WebService.ClsUseWebService();
                string sReturn = cls.sSave工序流转(dt, TH.Smart.BaseClass.ClsBaseDataInfo.sUid, TH.Smart.BaseClass.ClsBaseDataInfo.sUFDataBaseName);

                if (sReturn.Length > 1)
                {
                    string s = sReturn.Substring(0, 2);
                    if (s.ToLower() == "ok")
                    {
                        MessageBox.Show("保存成功");
                        SetNull();
                    }
                    else
                    {
                        throw new Exception(sReturn);
                    }
                }
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter)
                {
                    return;
                }

                btnSEL_Click(null, null);
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode2.Text.Trim() == "")
                {
                    txtBarCode2.Focus();
                    return;
                }

                if (combo工序.Text.Trim() == "")
                {
                    combo工序.Focus();
                    throw new Exception("请选择工序");
                }

                TH.Smart.WebService.ClsUseWebService cls = new TH.Smart.WebService.ClsUseWebService();
                DataTable dtBarCode = cls.dtGetBarCode(txtBarCode2.Text.Trim(), TH.Smart.BaseClass.ClsBaseDataInfo.sUFDataBaseName);

                int iFocRow = -1;
                int iRowCanEdit = -1;
                int iRow分包 = -1;
                for (int i = 0; i < dtBarCode.Rows.Count; i++)
                {
                    if (TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(dtBarCode.Rows[i]["数量"], 0) == 0 && iRowCanEdit == -1)
                    {
                        iRowCanEdit = i;
                    }

                    if (dtBarCode.Rows[i]["WorkProcessNo"].ToString().Trim() == combo工序.Text.Trim() && iFocRow ==-1)
                    {
                        iFocRow = i;
                    }
                    if (TH.Smart.BaseClass.ClsBaseDataInfo.ReturnBool(dtBarCode.Rows[i]["分包"]) && iRow分包 == -1)
                    {
                        iRow分包 = i;
                    }
                }


                if (dtBarCode != null && dtBarCode.Rows.Count > 0)
                {
                    label生产订单IDs.Text = dtBarCode.Rows[iFocRow]["WorkDetailsID"].ToString().Trim();
                    if (label生产订单IDs.Text.Trim() == "")
                    {
                        throw new Exception("获得生产订单信息失败");
                    }

                    string s分包工序 = "";
                    DataRow[] dr = dtBarCode.Select("isnull(分包,0) = 1");
                    if (dr.Length > 0)
                    {
                        s分包工序 = dr[0]["WorkProcessNo"].ToString().Trim();
                    }
                    chk分包.Checked = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnBool(dtBarCode.Rows[iFocRow]["分包"]);

                    if(txtBarCode2.Text.Trim().Length != 15 && txtBarCode2.Text.Trim().Length !=12 )
                    {
                        txtBarCode2.Focus();
                        throw new Exception("请扫描正确的条形码");
                    }

                    txtWorkCode.Text = dtBarCode.Rows[iFocRow]["WorkCode"].ToString().Trim();
                    txtcInvCode.Text = dtBarCode.Rows[iFocRow]["cInvCode"].ToString().Trim();
                    txtcInvName.Text = dtBarCode.Rows[iFocRow]["cInvName"].ToString().Trim();
                    txtcInvStd.Text = dtBarCode.Rows[iFocRow]["cInvStd"].ToString().Trim();
                    txt订单数.Text = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(dtBarCode.Rows[iFocRow]["WorkQty"], 0).ToString().Trim();
                    txt装箱数.Text = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(dtBarCode.Rows[iFocRow]["iQty"], 0).ToString().Trim();
                    txt分包数.Text = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(dtBarCode.Rows[iFocRow]["分包数"], 0).ToString().Trim();
                    label生产订单IDs.Text = dtBarCode.Rows[iFocRow]["WorkDetailsID"].ToString().Trim();
                    label工序流转iID.Text = dtBarCode.Rows[iFocRow]["iID"].ToString().Trim();

                    bool b入库 = ReturnBool(dtBarCode.Rows[iFocRow]["入库"]);
                    chk入库.Visible = b入库;
                    chk入库.Checked = b入库;

                    decimal d数量 = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(dtBarCode.Rows[iFocRow]["数量"], 0);
                    if (d数量 > 0)
                    {
                        txt数量.Text = d数量.ToString();
                    }
                    else if (iFocRow ==0)
                    {
                        txt数量.Text = txt装箱数.Text;
                    }
                    else if (iFocRow == iRow分包)
                    {
                        txt数量.Text = txt分包数.Text;
                    }
                    else
                    {
                        txt数量.Text = dtBarCode.Rows[iFocRow - 1]["数量"].ToString().Trim();
                    }

                    txt数量.Text = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(txt数量.Text.Trim(), 0).ToString();

                    if (!chk分包.Checked)
                        txtBarCode.Text = txtBarCode2.Text;
                }

                txt数量.Focus();
            }
            catch (Exception ee)
            {
                SetNull();
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }

        private void combo工序_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] dr = dt工序.Select("WorkProcessNo = '" + combo工序.Text.Trim() + "'");
                if (dr.Length > 0)
                {
                    txt工序.Text = dr[0]["WorkProcessName"].ToString().Trim();

                    btnSEL_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }

        private void txt数量_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }

        private void chk分包_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                txtBarCode.Enabled = chk分包.Checked;
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }
        }

        private void SetNull()
        {
            txtBarCode.Text = "";
            txtBarCode2.Text = "";
            txtWorkCode.Text = "";
            txtcInvCode.Text = "";
            txtcInvName.Text = "";
            txtcInvStd.Text = "";
            txt订单数.Text = "";
            txt装箱数.Text = "";
            txt分包数.Text = "";
            txt数量.Text = "";
            chk分包.Checked = false;

            txtBarCode2.Focus();
        }

        private void btnSEL2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode2.Text.Trim() != "")
                {
                    Frm条形码执行统计 f = new Frm条形码执行统计(txtBarCode2.Text.Trim());

                    f.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                MsgBox m = new MsgBox();
                m.textBox1.Text = ee.Message;
                m.ShowDialog();
                m.Text = "提示";
            }

        }
    }
}