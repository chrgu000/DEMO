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
    public partial class Frm产品入库 : FrmBase
    {
        DataTable dt仓库;
        DataTable dt入库类别;

        public Frm产品入库()
        {
            InitializeComponent();
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                TH.Smart.WebService.ClsUseWebService cls = new TH.Smart.WebService.ClsUseWebService();
                dt入库类别 = cls.dt入库类别(TH.Smart.BaseClass.ClsBaseDataInfo.sUFDataBaseName);
                if (dt入库类别 != null && dt入库类别.Rows.Count > 0)
                {
                    for (int i = 0; i < dt入库类别.Rows.Count; i++)
                    {
                        combo入库类别.Items.Add(dt入库类别.Rows[i]["cRdName"].ToString().Trim());
                    }
                }

                dt仓库 = cls.dt仓库(TH.Smart.BaseClass.ClsBaseDataInfo.sUFDataBaseName);
                if (dt仓库 != null && dt仓库.Rows.Count > 0)
                {
                    for (int i = 0; i < dt仓库.Rows.Count; i++)
                    {
                        combo仓库.Items.Add(dt仓库.Rows[i]["cWhName"].ToString().Trim());
                    }
                }

                combo仓库.Focus();

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
                if (combo仓库.Text.Trim() == "")
                {
                    combo仓库.Focus();
                    throw new Exception("获得仓库信息失败");
                }

                if (combo入库类别.Text.Trim() == "")
                {
                    combo入库类别.Focus();
                    throw new Exception("获得入库类别信息失败");
                }

                if (label生产订单IDs.Text.Trim() == "")
                {
                    throw new Exception("获得生产订单信息失败");
                }
             
                if (txtBarCode2.Text.Trim() == "")
                {
                    txtBarCode2.Focus();
                    throw new Exception("请扫描条形码");
                }
             

                decimal d数量 = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(txt数量.Text.Trim());
                if (d数量 <= 0)
                {
                    txt数量.Focus();
                    throw new Exception("请输入数量");
                }

                txtBarCode2.Focus();

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
                dc = new DataColumn();
                dc.ColumnName = "仓库";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "入库类别";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "单据日期";
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                dr["WorkDetailsID"] = label生产订单IDs.Text.Trim();
                dr["BarCode2"] = txtBarCode2.Text.Trim();
                dr["工序"] = combo仓库.Text.Trim();
                dr["数量"] = txt数量.Text.Trim();
                dr["iID"] = label工序流转iID.Text.Trim();
                dr["仓库"] = combo仓库.Text.Trim();
                dr["入库类别"] = combo入库类别.Text.Trim();
                dr["单据日期"] = TH.Smart.BaseClass.ClsBaseDataInfo.sLogDate;
                dt.Rows.Add(dr);

                TH.Smart.WebService.ClsUseWebService cls = new TH.Smart.WebService.ClsUseWebService();
                string sReturn = cls.sSave产品入库(dt, TH.Smart.BaseClass.ClsBaseDataInfo.sUid, TH.Smart.BaseClass.ClsBaseDataInfo.sUFDataBaseName);

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

                if (combo仓库.Text.Trim() == "")
                {
                    combo仓库.Focus();
                    throw new Exception("请选择工序");
                }

                TH.Smart.WebService.ClsUseWebService cls = new TH.Smart.WebService.ClsUseWebService();
                DataTable dtBarCode = cls.dtGetBarCode(txtBarCode2.Text.Trim(), TH.Smart.BaseClass.ClsBaseDataInfo.sUFDataBaseName);

                int iFocRow = -1;
                for (int i = 0; i < dtBarCode.Rows.Count; i++)
                {
                    if (TH.Smart.BaseClass.ClsBaseDataInfo.ReturnBool(dtBarCode.Rows[i]["入库"]))
                    {
                        iFocRow = i;
                    }
                }


                if (dtBarCode != null && dtBarCode.Rows.Count > 0)
                {
                    label生产订单IDs.Text = dtBarCode.Rows[iFocRow]["WorkDetailsID"].ToString().Trim();
                    if (label生产订单IDs.Text.Trim() == "")
                    {
                        throw new Exception("获得生产订单信息失败");
                    }
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
                    else
                    {
                        txt数量.Text = dtBarCode.Rows[iFocRow - 1]["数量"].ToString().Trim();
                    }

                    txt数量.Text = TH.Smart.BaseClass.ClsBaseDataInfo.ReturnDecimal(txt数量.Text.Trim(), 0).ToString();

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

        private void SetNull()
        {
            txtBarCode2.Text = "";
            txtWorkCode.Text = "";
            txtcInvCode.Text = "";
            txtcInvName.Text = "";
            txtcInvStd.Text = "";
            txt订单数.Text = "";
            txt数量.Text = "";
            chk入库.Checked = false;
            chk入库.Visible = false;

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