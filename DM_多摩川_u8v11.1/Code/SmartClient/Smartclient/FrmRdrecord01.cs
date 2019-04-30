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
    public partial class FrmRdrecord01 : FrmBase
    {
        string sState = "";
        DataTable dtBarCode = new DataTable();
        DataTable dtRdrecord01 = new DataTable();
        string sRdCode = "";
        string sBarCodeScan = "";
        decimal dBarCodeQty = 0;

        public FrmRdrecord01()
        {
            InitializeComponent();


        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                labelBarCodeCount.Text = "0";
                txtBarCodeInfo.Text = "";
                txtcCode.Text = "";
                txtBarCodeInfo.ReadOnly = true;
                sBarCodeScan = "";
                dBarCodeQty = 0;
                txtBarCode.Text = "";
                txtcCode.Focus();
                dtRdrecord01 = null;
                Setdt();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败:" + ee.Message);
            }
        }

        private void Setdt()
        {
            dtBarCode = new DataTable();
            dtBarCode.TableName = "BarCodeList";

            DataColumn dc = new DataColumn();
            dc.ColumnName = "条形码";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "存货编码";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "存货名称";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "规格型号";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "数量";
            dc.DataType = System.Type.GetType("System.Decimal");
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "批号";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "序列号";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应商";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "部门";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "箱码";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "制单人";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "来源单据ID";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "单据号";
            dtBarCode.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "行号";
            dtBarCode.Columns.Add(dc);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScanCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcCode.Text.Trim() == "")
                {
                    txtcCode.Focus();
                    throw new Exception("请输入采购入库单号");
                }

                dtRdrecord01 = clsWeb.dtRdrecord01(txtcCode.Text.Trim());

                Setdt();

                if (dtRdrecord01 != null && dtRdrecord01.Rows.Count > 0)
                {
                    dtRdrecord01.TableName = "Rdrecord01";

                    string sAudit = dtRdrecord01.Rows[0]["审核人"].ToString().Trim();
                    if (sAudit != "" && radioRD.Checked)
                    {
                        sState = "单据已审核";
                        throw new Exception("采购入库单已审核");
                    }
                    if (sAudit != "" && radioOM.Checked)
                    {
                        sState = "单据已审核";
                        throw new Exception("委外订单未审核");
                    }

                    if (dtRdrecord01.Rows[0]["采购类型编码"].ToString().Trim() == "07")
                    {
                        radioOM.Checked = true;
                    }
                    else
                    {
                        radioRD.Checked = true;
                    }

                    decimal dQty1 = base.ReturnDecimal(dtRdrecord01.Compute("sum(数量)", ""), 6);
                    decimal dQty2 = base.ReturnDecimal(dtRdrecord01.Compute("sum(已入库)", ""), 6);
                    double dQty = base.ReturnDouble(dQty1 - dQty2);
                    if (dQty == 0)
                    {
                        sState = "本单据已经扫描完成，不需要继续扫描";
                        throw new Exception("本单据已经扫描完成，不需要继续扫描");
                    }

                    lQty.Text = "待入库：" + dQty.ToString();

                    sRdCode = txtcCode.Text.Trim();

                    sBarCodeScan = "";
                    dBarCodeQty = 0;
                    sState = "";

                    if(dtRdrecord01.Rows[0]["红蓝字"].ToString().Trim() == "0")
                    {
                        radioBlue.Checked=true;
                    }
                    else
                    {
                        radioRed.Checked = true;
                    }

                    txtBarCode.Text = "";
                    txtQty.Text = "";

                    txtBarCode.Focus();
                }
                else
                {
                    dtRdrecord01 = null;

                    MessageBox.Show("采购入库单信息验证失败");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("扫描条码失败：" + ee.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcCode.Text.Trim() != sRdCode)
                {
                    throw new Exception("单据号已经改变，请重新扫描");
                }

                if (dtBarCode.Rows.Count > 0)
                {
                    string s = clsWeb.sSaveRdrecord01ChkQty(txtcCode.Text.Trim(), dtBarCode, TH.Smart.BaseClass.ClsBaseDataInfo.sUid);
                    MessageBox.Show(s);

                    if (s.Length > 2 && s.Substring(0, 2) == "成功")
                    {
                        Setdt();
                        dtRdrecord01 = null;
                        txtcCode.Text = "";
                        txtBarCode.Text = "";
                        txtBarCodeInfo.Text = "";
                        labelBarCodeCount.Text = "0";
                        txtQty.Text = "";
                        lQty.Text = "待入库";
                        lScanQty.Text = "累计扫描";
                        sBarCodeScan = "";
                        dBarCodeQty = 0;
                    }
                }
                else
                {
                    MessageBox.Show("请扫描需要入库的条形码");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败:" + ee.Message);
            }
        }

        private void txtcCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnScanCode_Click(null, null);
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("获得入库单信息失败:" + ee.Message);
            }
        }

        private void btnScanBarCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (sState.Length > 0)
                {
                    throw new Exception(sState);
                }

                if (txtBarCode.Text.Trim().Length == 0)
                {
                    txtBarCode.Focus();
                    return;
                }

                //采购入库单不支持箱码
                if (txtBarCode.Text.Trim().Length != 12)
                {
                    throw new Exception("条形码长度不正确");
                }

                #region 蓝字单据
                if (radioBlue.Checked)
                {
                    for (int i = 0; i < dtBarCode.Rows.Count; i++)
                    {
                        string sBarCode = dtBarCode.Rows[i]["条形码"].ToString().Trim();
                        if (sBarCode == txtBarCode.Text.Trim())
                        {
                            txtBarCode.Text = "";
                            MessageBox.Show("本条码已扫描");
                            return;
                        }
                    }

                    DataTable dtTemp = clsWeb.dtScanBarCode(txtBarCode.Text.Trim());
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("获得条形码信息失败");
                    }

                    if (!base.ReturnBool(dtTemp.Rows[0]["是否有效"]))
                    {
                        MessageBox.Show("条码" + txtBarCode.Text.Trim() + "已失效");
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        return;
                    }

                    int iCou = 0;
                    iCou = clsWeb.iBarCodeUsed(txtBarCode.Text.Trim(), "采购入库单");

                    if (iCou == -1)
                    {
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        throw new Exception("核查条形码使用状态失败");
                    }
                    if (iCou > 0)
                    {
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        throw new Exception("该条形码已经采购入库");
                    }

                    string sCode = txtcCode.Text.Trim();

                    if (radioRD.Checked)
                    {
                        if (sCode.ToLower() != dtTemp.Rows[0]["单据号"].ToString().Trim().ToLower())
                        {
                            DialogResult d = MessageBox.Show("标签单据号与当前单据号不一致，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            if (d == DialogResult.No)
                            {
                                txtBarCode.Text = "";
                                txtBarCode.Focus();
                                return;
                            }
                        }
                    }


                    string sInvCode = dtTemp.Rows[0]["存货编码"].ToString().Trim();

                    //委外订单条码，需要验证是否关联单据
                    if (radioOM.Checked)
                    {
                        string sCode2 = dtTemp.Rows[0]["单据号"].ToString().Trim().ToLower();

                        DataTable dtOMTemp = clsWeb.dtOMRdrecord01(sCode, sInvCode);
                        if (dtOMTemp == null || dtOMTemp.Rows.Count == 0)
                        {
                            txtBarCode.Text = "";
                            txtBarCode.Focus();
                            throw new Exception("单据号与条形码不匹配");
                        }

                        if (sCode.ToLower() != dtOMTemp.Rows[0]["rdCode"].ToString().Trim().ToLower())
                        {
                            DialogResult d = MessageBox.Show("标签单据号与当前单据号不一致，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            if (d == DialogResult.No)
                            {
                                txtBarCode.Text = "";
                                txtBarCode.Focus();
                                return;
                            }
                        }
                    }


                    DataRow[] dr = dtRdrecord01.Select("存货编码 = '" + sInvCode + "'");
                    if (dr.Length == 0)
                    {
                        throw new Exception("条形码物料与单据不匹配");
                    }

                    decimal dQty = base.ReturnDecimal(dtTemp.Rows[0]["数量"], 6);

                    decimal dQtyCode = 0;                                               //单据数量(同一张单子相同的存货编码汇总判断)
                    decimal dQtyCodeScan = 0;                                           //单据已扫描数量

                    for (int i = 0; i < dr.Length; i++)
                    {
                        dQtyCode = dQtyCode + base.ReturnDecimal(dr[i]["数量"], 6);
                        dQtyCodeScan = dQtyCodeScan + base.ReturnDecimal(dr[i]["已入库"], 6);
                    }


                    decimal dQtyBarScan = 0;                                             //当前扫描数量
                    dr = dtBarCode.Select("存货编码 = '" + sInvCode + "'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dQtyBarScan = dQtyBarScan + base.ReturnDecimal(dr[i]["数量"], 6);
                    }


                    txtQty.Text = dQty.ToString().Trim();

                    if (dQtyCode - dQtyCodeScan - dQtyBarScan < dQty)
                    {
                        decimal d = dQtyCode - dQtyCodeScan - dQtyBarScan;
                        if (d <= 0)
                        {
                            throw new Exception("该物料已扫描足够数量");
                        }

                        MessageBox.Show("数量超出，自动调整数量为：" + d.ToString());
                        txtQty.Text = d.ToString();
                    }

                    string sBarInfo = "";
                    sBarInfo = sBarInfo + "条形码：" + dtTemp.Rows[0]["条形码"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　存货：" + dtTemp.Rows[0]["存货编码"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　名称：" + dtTemp.Rows[0]["存货名称"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　型号：" + dtTemp.Rows[0]["规格型号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　数量：" + dQty.ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　货位：" + dtTemp.Rows[0]["货位"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　批号：" + dtTemp.Rows[0]["批号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "序列号：" + dtTemp.Rows[0]["序列号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　仓库：" + "【" + dtTemp.Rows[0]["仓库编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["仓库"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "供应商：" + "【" + dtTemp.Rows[0]["供应商编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["供应商"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　部门：" + "【" + dtTemp.Rows[0]["部门编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["部门"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "单据类型：" + dtTemp.Rows[0]["单据类型"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "单据号：" + dtTemp.Rows[0]["单据号"].ToString().Trim() + "\r\n";

                    txtBarCodeInfo.Text = sBarInfo;

                    DataRow drBarCode = dtBarCode.NewRow();
                    drBarCode["条形码"] = txtBarCode.Text.Trim();
                    drBarCode["存货编码"] = dtTemp.Rows[0]["存货编码"].ToString().Trim();
                    drBarCode["存货名称"] = dtTemp.Rows[0]["存货名称"].ToString().Trim();
                    drBarCode["规格型号"] = dtTemp.Rows[0]["规格型号"].ToString().Trim();
                    if (dQtyCode - dQtyCodeScan - dQtyBarScan < dQty)
                    {
                        drBarCode["数量"] = dQtyCode - dQtyCodeScan - dQtyBarScan;
                    }
                    else
                    {
                        drBarCode["数量"] = dQty;
                    }
                    drBarCode["货位"] = dtTemp.Rows[0]["货位"].ToString().Trim();
                    drBarCode["批号"] = dtTemp.Rows[0]["批号"].ToString().Trim();
                    drBarCode["序列号"] = dtTemp.Rows[0]["序列号"].ToString().Trim();
                    drBarCode["仓库"] = dtTemp.Rows[0]["仓库"].ToString().Trim();
                    drBarCode["供应商"] = dtTemp.Rows[0]["供应商"].ToString().Trim();
                    drBarCode["部门"] = dtTemp.Rows[0]["部门"].ToString().Trim();
                    drBarCode["制单人"] = TH.Smart.BaseClass.ClsBaseDataInfo.sUid;
                    drBarCode["来源单据ID"] = dtTemp.Rows[0]["来源单据ID"].ToString().Trim();
                    drBarCode["单据号"] = dtTemp.Rows[0]["单据号"].ToString().Trim();
                    drBarCode["行号"] = dtTemp.Rows[0]["行号"].ToString().Trim();
                    dtBarCode.Rows.Add(drBarCode);


                    sBarCodeScan = txtBarCode.Text;
                    dBarCodeQty = base.ReturnDecimal(txtQty.Text.Trim());
                    txtBarCode.Text = "";

                    labelBarCodeCount.Text = dtBarCode.Rows.Count.ToString();

                    double dQty1 = base.ReturnDouble(dtBarCode.Compute("sum(数量)", ""));
                    lScanQty.Text = "累计扫描" + dQty1.ToString();
                }
                #endregion

                #region 红字单据
                if (radioRed.Checked)
                {
                    for (int i = 0; i < dtBarCode.Rows.Count; i++)
                    {
                        string sBarCode = dtBarCode.Rows[i]["条形码"].ToString().Trim();
                        if (sBarCode == txtBarCode.Text.Trim())
                        {
                            txtBarCode.Text = "";
                            MessageBox.Show("本条码已扫描");
                            return;
                        }
                    }

                    DataTable dtTemp = clsWeb.dtScanBarCode(txtBarCode.Text.Trim());
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("获得条形码信息失败");
                    }

                    int iCou = 0;
                    iCou = clsWeb.iBarCodeUsed(txtBarCode.Text.Trim(), "采购入库单");

                    if (iCou == -1)
                    {
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        throw new Exception("核查条形码使用状态失败");
                    }
                    if (iCou == 0)
                    {
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        throw new Exception("该条形码未采购入库");
                    }

                    string sCode = txtcCode.Text.Trim();

                    if (radioRD.Checked)
                    {
                        if (sCode.ToLower() != dtTemp.Rows[0]["单据号"].ToString().Trim().ToLower())
                        {
                            DialogResult d = MessageBox.Show("标签单据号与当前单据号不一致，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            if (d == DialogResult.No)
                            {
                                txtBarCode.Text = "";
                                txtBarCode.Focus();
                                return;
                            }
                        }
                    }

                    string sInvCode = dtTemp.Rows[0]["存货编码"].ToString().Trim();

                    DataRow[] dr = dtRdrecord01.Select("存货编码 = '" + sInvCode + "'");
                    if (dr.Length == 0)
                    {
                        throw new Exception("条形码物料与单据不匹配");
                    }

                    decimal dQty = -1 * clsWeb.dBarCodeQty(txtBarCode.Text.Trim());
                    if (dQty == 0)
                    {
                        throw new Exception("条形码可用量为0");
                    }
   
                    decimal dQtyCode = 0;                                               //单据数量(同一张单子相同的存货编码汇总判断)
                    decimal dQtyCodeScan = 0;                                           //单据已扫描数量

                    for (int i = 0; i < dr.Length; i++)
                    {
                        dQtyCode = dQtyCode + base.ReturnDecimal(dr[i]["数量"], 6);
                        dQtyCodeScan = dQtyCodeScan + base.ReturnDecimal(dr[i]["已入库"], 6);
                    }


                    decimal dQtyBarScan = 0;                                             //当前扫描数量
                    dr = dtBarCode.Select("存货编码 = '" + sInvCode + "'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dQtyBarScan = dQtyBarScan + base.ReturnDecimal(dr[i]["数量"], 6);
                    }


                    txtQty.Text = dQty.ToString().Trim();

                    if (dQtyCode - dQtyCodeScan - dQtyBarScan > dQty)
                    {
                        decimal d = dQtyCode - dQtyCodeScan - dQtyBarScan;
                        if (d >= 0)
                        {
                            throw new Exception("该物料已扫描足够数量");
                        }

                        MessageBox.Show("数量超出，自动调整数量为：" + d.ToString());
                        txtQty.Text = d.ToString();
                    }

                    string sBarInfo = "";
                    sBarInfo = sBarInfo + "条形码：" + dtTemp.Rows[0]["条形码"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　存货：" + dtTemp.Rows[0]["存货编码"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　名称：" + dtTemp.Rows[0]["存货名称"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　型号：" + dtTemp.Rows[0]["规格型号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　数量：" + dQty.ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　货位：" + dtTemp.Rows[0]["货位"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　批号：" + dtTemp.Rows[0]["批号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "序列号：" + dtTemp.Rows[0]["序列号"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　仓库：" + "【" + dtTemp.Rows[0]["仓库编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["仓库"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "供应商：" + "【" + dtTemp.Rows[0]["供应商编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["供应商"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "　部门：" + "【" + dtTemp.Rows[0]["部门编码"].ToString().Trim() + "】" + dtTemp.Rows[0]["部门"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "单据类型：" + dtTemp.Rows[0]["单据类型"].ToString().Trim() + "\r\n";
                    sBarInfo = sBarInfo + "单据号：" + dtTemp.Rows[0]["单据号"].ToString().Trim() + "\r\n";

                    txtBarCodeInfo.Text = sBarInfo;

                    DataRow drBarCode = dtBarCode.NewRow();
                    drBarCode["条形码"] = txtBarCode.Text.Trim();
                    drBarCode["存货编码"] = dtTemp.Rows[0]["存货编码"].ToString().Trim();
                    drBarCode["存货名称"] = dtTemp.Rows[0]["存货名称"].ToString().Trim();
                    drBarCode["规格型号"] = dtTemp.Rows[0]["规格型号"].ToString().Trim();
                    if (dQtyCode - dQtyCodeScan - dQtyBarScan > dQty)
                    {
                        drBarCode["数量"] = dQtyCode - dQtyCodeScan - dQtyBarScan;
                    }
                    else
                    {
                        drBarCode["数量"] = dQty;
                    }
                    drBarCode["货位"] = dtTemp.Rows[0]["货位"].ToString().Trim();
                    drBarCode["批号"] = dtTemp.Rows[0]["批号"].ToString().Trim();
                    drBarCode["序列号"] = dtTemp.Rows[0]["序列号"].ToString().Trim();
                    drBarCode["仓库"] = dtTemp.Rows[0]["仓库"].ToString().Trim();
                    drBarCode["供应商"] = dtTemp.Rows[0]["供应商"].ToString().Trim();
                    drBarCode["部门"] = dtTemp.Rows[0]["部门"].ToString().Trim();
                    drBarCode["制单人"] = TH.Smart.BaseClass.ClsBaseDataInfo.sUid;
                    drBarCode["来源单据ID"] = dtTemp.Rows[0]["来源单据ID"].ToString().Trim();
                    drBarCode["单据号"] = dtTemp.Rows[0]["单据号"].ToString().Trim();
                    drBarCode["行号"] = dtTemp.Rows[0]["行号"].ToString().Trim();
                    dtBarCode.Rows.Add(drBarCode);


                    sBarCodeScan = txtBarCode.Text;
                    dBarCodeQty = base.ReturnDecimal(txtQty.Text.Trim());
                    txtBarCode.Text = "";

                    labelBarCodeCount.Text = dtBarCode.Rows.Count.ToString();

                    double dQty1 = base.ReturnDouble(dtBarCode.Compute("sum(数量)", ""));
                    lScanQty.Text = "累计扫描" + dQty1.ToString();
                }

                #endregion
            }
            catch (Exception ee)
            {
                MessageBox.Show("扫描条码失败：" + ee.Message);
            }
        }

        private void btnExamine_Click(object sender, EventArgs e)
        {
            try
            {
                int iCou = base.ReturnInt(labelBarCodeCount.Text.Trim());
                if (iCou == 0)
                {
                    MessageBox.Show("请扫描条形码后查看");
                    return;
                }

                FrmRdrecord01BarCodeList f = new FrmRdrecord01BarCodeList();
                f.WindowState = FormWindowState.Maximized;
                f.dtGrid = this.dtBarCode.Copy();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.Yes)
                {
                    dtBarCode = f.dtGrid.Copy();
                    labelBarCodeCount.Text = dtBarCode.Rows.Count.ToString();
                }

                double dQty1 = base.ReturnDouble(dtBarCode.Compute("sum(数量)", ""));
                lScanQty.Text = "累计扫描" + dQty1.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show("查看扫描列表失败:" + ee.Message);
            }
        }

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnScanBarCode_Click(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("扫描条形码失败:" + ee.Message);
            }
        }

        private void btnRdrecord01_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtRdrecord01 == null || dtRdrecord01.Rows.Count < 1)
                {
                    throw new Exception("请先输入正确的单据号");
                }

                for (int i = 0; i < dtRdrecord01.Rows.Count; i++)
                {
                    dtRdrecord01.Rows[i]["当前扫描"] = 0;
                }

                //将扫描的数量分配到对应单据行
                for (int i = 0; i < dtBarCode.Rows.Count; i++)
                {
                    string sInvCode = dtBarCode.Rows[i]["存货编码"].ToString().Trim();
                    long lExsID = base.ReturnLong(dtBarCode.Rows[i]["来源单据ID"]);
                    string sExCode = dtBarCode.Rows[i]["单据号"].ToString().Trim();
                    string sExsRow = dtBarCode.Rows[i]["行号"].ToString().Trim();
                    decimal dQtyBarCode = base.ReturnDecimal(dtBarCode.Rows[i]["数量"], 6);


                    //条形码与采购入库单完全对应
                    DataRow[] drCode = dtRdrecord01.Select("单据号 = '" + sExCode + "' and 行 = '" + sExsRow + "' and autoid = " + lExsID + " and 存货编码 = '" + sInvCode + "'");
                    for (int j = 0; j < drCode.Length; j++)
                    {
                        if (dQtyBarCode == 0)
                            break;

                        decimal diQuantity = base.ReturnDecimal(drCode[j]["数量"]);
                        decimal dQtyScaned = base.ReturnDecimal(drCode[j]["已入库"]);
                        decimal dQtyNow = base.ReturnDecimal(drCode[j]["当前扫描"]);
                        decimal d = diQuantity - dQtyScaned - dQtyNow;

                        //条形码数量超出单据数量
                        if (dQtyBarCode >= d)
                        {
                            drCode[j]["当前扫描"] = base.ReturnDecimal(drCode[j]["当前扫描"]) + d;
                            dQtyBarCode = dQtyBarCode - d;
                        }
                        else
                        {
                            drCode[j]["当前扫描"] = base.ReturnDecimal(drCode[j]["当前扫描"]) + dQtyBarCode;
                            dQtyBarCode = 0;
                        }
                    }

                    #region 如果采购入库标签允许不一一对应，则启用这段代码

                    if (dQtyBarCode != 0)
                    {
                        //条形码中仅存货编码与入库单对应
                        drCode = dtRdrecord01.Select("存货编码 = '" + sInvCode + "'");

                        for (int j = 0; j < drCode.Length; j++)
                        {
                            if (dQtyBarCode == 0)
                                break;

                            decimal diQuantity = base.ReturnDecimal(drCode[j]["数量"]);
                            decimal dQtyScaned = base.ReturnDecimal(drCode[j]["已入库"]);
                            decimal dQtyNow = base.ReturnDecimal(drCode[j]["当前扫描"]);
                            decimal d = diQuantity - dQtyScaned - dQtyNow;


                            //条形码数量超出单据数量
                            if (dQtyBarCode >= d)
                            {
                                drCode[j]["当前扫描"] = base.ReturnDecimal(drCode[j]["当前扫描"]) + d;
                            }
                            else
                            {
                                drCode[j]["当前扫描"] = base.ReturnDecimal(drCode[j]["当前扫描"]) + dQtyBarCode;
                                dQtyBarCode = 0;
                            }
                        }
                    }

                    #endregion
                }

                FrmRdrecord01List f = new FrmRdrecord01List();
                f.WindowState = FormWindowState.Maximized;
                f.dtGrid = this.dtRdrecord01.Copy();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.Yes)
                {
                    dtRdrecord01 = f.dtGrid.Copy();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("查看单据明细失败:" + ee.Message);
            }
        }

        private void txtcCode_GotFocus(object sender, EventArgs e)
        {
            HoneyWellBarCode.TargetTextBox = txtcCode;
        }

        private void txtBarCode_GotFocus(object sender, EventArgs e)
        {
            HoneyWellBarCode.TargetTextBox = txtBarCode;
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if(sBarCodeScan=="")
                    {
                       throw new Exception("请扫描条形码");
                    }

                    if(dtRdrecord01 == null ||dtRdrecord01.Rows.Count ==0)
                    {
                        throw new Exception("请扫描单据");
                    }

                    DataRow[] dr = dtBarCode.Select("条形码 = '" + sBarCodeScan + "'");
                    decimal dQty = base.ReturnDecimal(txtQty.Text.Trim());
                    if (dBarCodeQty < dQty && radioBlue.Checked)
                    {
                        throw new Exception("修改数量不能大于标签数量");
                    }
                    if (dBarCodeQty > dQty && radioRed.Checked)
                    {
                        throw new Exception("修改数量不能大于标签数量");
                    }

                    for (int i = 0; i < dr.Length; i++)
                    {
                        dr[i]["数量"] = dQty;
                    }

                    double dQty1 = base.ReturnDouble(dtBarCode.Compute("sum(数量)", ""));
                    lScanQty.Text = "累计扫描" + dQty1.ToString();

                    MessageBox.Show("修改成功");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("扫描条形码失败:" + ee.Message);
            }
        }
    }
}