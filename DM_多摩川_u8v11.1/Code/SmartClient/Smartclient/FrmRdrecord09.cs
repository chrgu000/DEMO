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
    public partial class FrmRdrecord09 : FrmBase
    {
        string sState = "";
        DataTable dtBarCode = new DataTable();
        DataTable dtRdrecord09 = new DataTable();
        string sRdCode = "";
        string sBarCodeScan = "";
        decimal dBarCodeQty = 0;

        public FrmRdrecord09()
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

                txtBarCode.Text = "";
                txtcCode.Focus();
                dtRdrecord09 = null;
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
                    throw new Exception("请输入其他出库单号");
                }

                dtRdrecord09 = clsWeb.dtRdrecord09(txtcCode.Text.Trim());

                Setdt();

                if (dtRdrecord09 != null && dtRdrecord09.Rows.Count > 0)
                {
                    dtRdrecord09.TableName = "Rdrecord09";

                    string sAudit = dtRdrecord09.Rows[0]["审核人"].ToString().Trim();
                    if (sAudit != "")
                    {
                        sState = "单据已审核";
                        throw new Exception("单据已审核");
                    }

                    decimal dQty1 = base.ReturnDecimal(dtRdrecord09.Compute("sum(数量)", ""), 6);
                    decimal dQty2 = base.ReturnDecimal(dtRdrecord09.Compute("sum(已出库)", ""), 6);
                    double dQty = base.ReturnDouble(dQty1 - dQty2);
                    if (dQty == 0)
                    {
                        sState = "本单据已经扫描完成，不需要继续扫描";
                        throw new Exception("本单据已经扫描完成，不需要继续扫描");
                    }

                    lQty.Text = "待出库：" + dQty.ToString();

                    sRdCode = txtcCode.Text.Trim();

                    sState = "";
                    txtBarCode.Focus();
                }
                else
                {
                    dtRdrecord09 = null;

                    MessageBox.Show("其他出库单信息验证失败");
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
                    string s = clsWeb.sSaveRdrecord09ChkQty(txtcCode.Text.Trim(), dtBarCode, TH.Smart.BaseClass.ClsBaseDataInfo.sUid);
                    MessageBox.Show(s);

                    if (s.Length > 2 && s.Substring(0, 2) == "成功")
                    {
                        Setdt();
                        dtRdrecord09 = null;
                        txtcCode.Text = "";
                        txtBarCode.Text = "";
                        txtBarCodeInfo.Text = "";
                        labelBarCodeCount.Text = "0";
                        txtQty.Text = "";
                        lQty.Text = "待出库";
                        lScanQty.Text = "累计扫描";
                    }
                }
                else
                {
                    MessageBox.Show("请扫描需要出库的条形码");
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
                MessageBox.Show("获得出库单信息失败:" + ee.Message);
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

                if (txtBarCode.Text.Trim().Length != 12 && txtBarCode.Text.Trim().Length != 13)
                {
                    throw new Exception("条形码长度不正确");
                }

                #region 条形码
                
                if (txtBarCode.Text.Trim().Length == 12)
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

                    string sInvCode = dtTemp.Rows[0]["存货编码"].ToString().Trim();
                    decimal dQty = clsWeb.dBarCodeQty(txtBarCode.Text.Trim());          //使用条形码可用量，可用于多次出库
                    if (dQty == 0)
                    {
                        throw new Exception("该条形码未生效或已经完全出库");
                    }

                    decimal dQtyCode = 0;                                               //单据数量(同一张单子相同的存货编码汇总判断)
                    decimal dQtyCodeScan = 0;                                           //单据已扫描数量
                    DataRow[] dr = dtRdrecord09.Select("存货编码 = '" + sInvCode + "'");
                    if (dr.Length == 0)
                    {
                        throw new Exception("条形码物料与单据不匹配");
                    }
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dQtyCode = dQtyCode + base.ReturnDecimal(dr[i]["数量"], 6);
                        dQtyCodeScan = dQtyCodeScan + base.ReturnDecimal(dr[i]["已出库"], 6);
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
                        if (d == 0)
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
                    drBarCode["部门"] = dtTemp.Rows[0]["部门"].ToString().Trim();
                    drBarCode["制单人"] = TH.Smart.BaseClass.ClsBaseDataInfo.sUid;
                    drBarCode["来源单据ID"] = dtTemp.Rows[0]["来源单据ID"].ToString().Trim();
                    drBarCode["单据号"] = dtTemp.Rows[0]["单据号"].ToString().Trim();
                    drBarCode["行号"] = dtTemp.Rows[0]["行号"].ToString().Trim();
                    dtBarCode.Rows.Add(drBarCode);

                    txtBarCode.Text = "";


                    labelBarCodeCount.Text = dtBarCode.Rows.Count.ToString();

                    double dQty1 = base.ReturnDouble(dtBarCode.Compute("sum(数量)", ""));
                    lScanQty.Text = "累计扫描" + dQty1.ToString();

                    if (chkPrint.Checked)
                    {
                        if (dQty <= 0)
                        {
                            MessageBox.Show("标签数量用完，不需要打印");
                        }
                        else
                        {
                            BarCodePrint(dtTemp.Rows[0]["条形码"].ToString().Trim(), ReturnDecimal(drBarCode["数量"]));
                        }
                    }

                }

                #endregion



                #region 扫描箱码

                if (txtBarCode.Text.Trim().Length == 13)
                {
                    string s = txtBarCode.Text.Trim().Substring(0, 1);
                    if (s.ToUpper() != "X")
                    {
                        throw new Exception("箱码信息不正确");
                    }

                    for (int i = 0; i < dtBarCode.Rows.Count; i++)
                    {
                        string sBarCode = dtBarCode.Rows[i]["箱码"].ToString().Trim();
                        if (sBarCode == txtBarCode.Text.Trim())
                        {
                            txtBarCode.Text = "";
                            MessageBox.Show("本箱码已扫描");
                            return;
                        }
                    }

                    DataTable dtTemp = clsWeb.dtScanBarCode(txtBarCode.Text.Trim());
                    if (dtTemp == null || dtTemp.Rows.Count < 1)
                    {
                        throw new Exception("获得箱码信息失败");
                    }

                    if (!base.ReturnBool(dtTemp.Rows[0]["是否有效"]))
                    {
                        MessageBox.Show("箱码" + txtBarCode.Text.Trim() + "已失效");
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        return;
                    }

                    int iCou = clsWeb.iBarCodeUsed(txtBarCode.Text.Trim(), "材料出库单");
                    if (iCou == -1)
                    {
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        throw new Exception("核查箱码使用状态失败");
                    }
                    if (iCou > 0)
                    {
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        throw new Exception("该箱码已经材料出库");
                    }
                    txtQty.Enabled = false;

                    DataTable dtBoxBarCode = clsWeb.dtSBoxBarCode(txtBarCode.Text.Trim());
                    if (dtBoxBarCode == null || dtBoxBarCode.Rows.Count == 0)
                    {
                        txtBarCode.Text = "";
                        txtBarCode.Focus();
                        throw new Exception("该箱码并未装箱");
                    }

                    for (int i = 0; i < dtBoxBarCode.Rows.Count; i++)
                    {
                        string sInvCode = dtBoxBarCode.Rows[i]["存货编码"].ToString().Trim();
                        decimal dQty = clsWeb.dBarCodeQty(dtBoxBarCode.Rows[i]["条形码"].ToString().Trim());          //使用条形码可用量，可用于多次出库
                        decimal dQtyCode = 0;                                               //单据数量(同一张单子相同的存货编码汇总判断)
                        decimal dQtyCodeScan = 0;                                           //单据已扫描数量
                        DataRow[] dr = dtRdrecord09.Select("存货编码 = '" + sInvCode + "'");
                        for (int j = 0; j < dr.Length; j++)
                        {
                            dQtyCode = dQtyCode + base.ReturnDecimal(dr[j]["数量"], 6);
                            dQtyCodeScan = dQtyCodeScan + base.ReturnDecimal(dr[j]["已出库"], 6);
                        }
                        decimal dQtyBarScan = 0;                                             //当前扫描数量
                        dr = dtBarCode.Select("存货编码 = '" + sInvCode + "'");
                        for (int j = 0; j < dr.Length; j++)
                        {
                            dQtyBarScan = dQtyBarScan + base.ReturnDecimal(dr[j]["数量"], 6);
                        }

                        if (dQtyCode - dQtyCodeScan - dQtyBarScan < dQty)
                        {
                            decimal d = dQtyCode - dQtyCodeScan - dQtyBarScan;
                            if (d == 0)
                            {
                                throw new Exception("该物料已扫描足够数量");
                            }

                            MessageBox.Show("数量超出，自动调整数量为：" + d.ToString());
                            txtQty.Text = d.ToString();
                        }


                        DataRow drBarCode = dtBarCode.NewRow();
                        drBarCode["条形码"] = dtBoxBarCode.Rows[i]["条形码"].ToString().Trim();
                        drBarCode["箱码"] = txtBarCode.Text.Trim();
                        drBarCode["存货编码"] = dtBoxBarCode.Rows[i]["存货编码"].ToString().Trim();
                        drBarCode["存货名称"] = dtBoxBarCode.Rows[i]["存货名称"].ToString().Trim();
                        drBarCode["规格型号"] = dtBoxBarCode.Rows[i]["规格型号"].ToString().Trim();
                        drBarCode["数量"] = dQty;
                        drBarCode["货位"] = dtBoxBarCode.Rows[i]["货位"].ToString().Trim();
                        drBarCode["批号"] = dtBoxBarCode.Rows[i]["批号"].ToString().Trim();
                        drBarCode["序列号"] = dtBoxBarCode.Rows[i]["序列号"].ToString().Trim();
                        drBarCode["仓库"] = dtBoxBarCode.Rows[i]["仓库"].ToString().Trim();
                        drBarCode["部门"] = dtBoxBarCode.Rows[i]["部门"].ToString().Trim();
                        drBarCode["制单人"] = TH.Smart.BaseClass.ClsBaseDataInfo.sUid;
                        drBarCode["来源单据ID"] = dtBoxBarCode.Rows[i]["来源单据ID"].ToString().Trim();
                        drBarCode["单据号"] = dtBoxBarCode.Rows[i]["单据号"].ToString().Trim();
                        drBarCode["行号"] = dtBoxBarCode.Rows[i]["行号"].ToString().Trim();
                        dtBarCode.Rows.Add(drBarCode);



                        labelBarCodeCount.Text = dtBarCode.Rows.Count.ToString();

                        double dQty1 = base.ReturnDouble(dtBarCode.Compute("sum(数量)", ""));
                        lScanQty.Text = "累计扫描" + dQty1.ToString();

                    }

                    DataTable dtBoxInv = clsWeb.dtSBoxInvCode(txtBarCode.Text.Trim());
                    string sBarInfo = "";
                    sBarInfo = sBarInfo + "箱码：" + dtTemp.Rows[0]["条形码"].ToString().Trim() + "\r\n";
                    for (int i = 0; i < dtBoxInv.Rows.Count; i++)
                    {
                        sBarInfo = sBarInfo + "　存货：" + "【" + dtBoxInv.Rows[i]["存货编码"].ToString().Trim() + "】" + dtBoxInv.Rows[i]["存货名称"].ToString().Trim() + "\r\n";
                        sBarInfo = sBarInfo + "　型号：" + dtBoxInv.Rows[i]["规格型号"].ToString().Trim() + "\r\n";
                        sBarInfo = sBarInfo + "　数量：" + dtBoxInv.Rows[i]["数量"].ToString().Trim() + "\r\n";
                    }
                    txtBarCodeInfo.Text = sBarInfo;


                    sBarCodeScan = txtBarCode.Text;
                    dBarCodeQty = base.ReturnDecimal(txtQty.Text.Trim());

                    txtBarCode.Text = "";
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

                FrmRdrecord09BarCodeList f = new FrmRdrecord09BarCodeList();
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

        private void btnRdrecord09_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtRdrecord09 == null || dtRdrecord09.Rows.Count < 1)
                {
                    throw new Exception("请先输入正确的单据号");
                }


                for (int i = 0; i < dtRdrecord09.Rows.Count; i++)
                {
                    dtRdrecord09.Rows[i]["当前扫描"] = 0;
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
                    DataRow[] drCode = dtRdrecord09.Select("单据号 = '" + sExCode + "' and 行 = '" + sExsRow + "' and autoid = " + lExsID + " and 存货编码 = '" + sInvCode + "'");
                    for (int j = 0; j < drCode.Length; j++)
                    {
                        if (dQtyBarCode == 0)
                            break;

                        decimal diQuantity = base.ReturnDecimal(drCode[j]["数量"]);
                        decimal dQtyScaned = base.ReturnDecimal(drCode[j]["已出库"]);
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
                        drCode = dtRdrecord09.Select("存货编码 = '" + sInvCode + "'");

                        for (int j = 0; j < drCode.Length; j++)
                        {
                            if (dQtyBarCode == 0)
                                break;

                            decimal diQuantity = base.ReturnDecimal(drCode[j]["数量"]);
                            decimal dQtyScaned = base.ReturnDecimal(drCode[j]["已出库"]);
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

                FrmRdrecord09List f = new FrmRdrecord09List();
                f.WindowState = FormWindowState.Maximized;
                f.dtGrid = this.dtRdrecord09.Copy();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.Yes)
                {
                    dtRdrecord09 = f.dtGrid.Copy();
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
                    if (sBarCodeScan == "")
                    {
                        throw new Exception("请扫描条形码");
                    }

                    if (dtRdrecord09 == null || dtRdrecord09.Rows.Count == 0)
                    {
                        throw new Exception("请扫描单据");
                    }

                    DataRow[] dr = dtBarCode.Select("条形码 = '" + sBarCodeScan + "'");
                    decimal dQty = base.ReturnDecimal(txtQty.Text.Trim());
                    if (dBarCodeQty < dQty)
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

        private void BarCodePrint(string sBarCode, decimal dQty)
        {
            try
            {
                if (sBarCode.Length != 12)
                {
                    throw new Exception("条码长度不正确");
                }

                string s = clsWeb.PrintBarCodeQTY(sBarCode, dQty);

                if (s.Length >= 2 && s.Substring(0, 2) == "成功")
                {

                }

                s = clsWeb.PrintBarCodeQTYSecond(sBarCode, dQty);
            }
            catch (Exception ee)
            {
                MessageBox.Show("打印失败:" + ee.Message);
            }
        }
    }
}