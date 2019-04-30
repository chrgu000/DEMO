using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace BarCode
{
    public partial class Frm委外生单发料 : FrmBase
    {
        
        DataTable dt = new DataTable();
        DataTable dtTable;

        int i栈板1 = 0;
        int i栈板2 = 0;
        int i栈板3 = 0;
        int i栈板4 = 0;
        int i栈板5 = 0;
        int i栈板6 = 0;
        int i栈板7 = 0;
        int i栈板8 = 0;

        public Frm委外生单发料()
        {
            InitializeComponent();

            dtTable = new DataTable();

            DataColumn dc = new DataColumn();
            dc.ColumnName = "序号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "存货编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次下单数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "子件编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "子件数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "子件件数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "托外结束日期";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "需求日期";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "计划数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "已生单数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "日计划ID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "日计划单据号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "委外计划ID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "销售订单ID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "销售订单子表ID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "销售订单号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "销售订单行号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "计划号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "存货名称";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "规格型号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "计量单位编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "计量单位";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "计划日期";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "结束日期";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应商编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应商编码OLD";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应商";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "含税单价";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "税率";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "cAssComUnitCode";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "CompScrap";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "BaseQtyD";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "BaseQtyN";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bomID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "ParentScrap";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "子件名称";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "子件规格";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "供应类型";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "OpComponentid";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "ChangeRate";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "UseQty";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "UseNum";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "cComUnitCodeI";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "cAssComUnitCodeI";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "unitCode1";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "unitCode2";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "使用数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "辅助使用数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "invSZ";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "invSM";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "fInExcess";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "CurrQtyI";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "CurrNumI";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "母件发料套数";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUse";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUse2";
            dtTable.Columns.Add(dc);

            dataGrid1.DataSource = dtTable;
        }


        private void Frm委外生单发料_Load(object sender, EventArgs e)
        {
            try
            {
                radio母件数量.Enabled = false;
                radio子件件数.Enabled = false;
                radio子件数量.Enabled = false;
                radio子件数量.Checked = true;

                dateTime单据日期.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txt栈板登记.Focus();
            }
            catch { }
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                try
                {
                    if (txt条形码.Text.Trim() == string.Empty)
                    {
                        return;
                    }


                    if (e.KeyCode == Keys.Enter)
                    {
                        string[] s = txt条形码.Text.Trim().Split('-');

                        string sBarCode = s[0].Trim();


                        string sSQL = "select * from UFDLImport..OMPlanDay where bUse = 1 and accid = '200' and accyear = '" + MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and [ID] = " + sBarCode;
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        string sCode = "";
                        string sID = "";
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            sCode = dt.Rows[0]["cCode"].ToString().Trim();
                            sID = dt.Rows[0]["iID"].ToString().Trim();
                        }
                        else
                        {
                            MessageBox.Show("该条码不存在，请核实！");
                            return;
                        }

                        string s货位 = clsDES.Decrypt(txt货位.Text.Trim());
                        sSQL = "select cast(null as int) as 序号,'" + s货位 + "' as 货位,o.ID as 日计划ID, o.cCode as 日计划单据号, o.iID as 委外计划ID, o.Soid as 销售订单ID, o.sodid as 销售订单子表ID, o.SoCode as 销售订单号, o.SoSeq as 销售订单行号, o.PlanCode as 计划号, o.InvCode as 存货编码, o.InvName as 存货名称, o.InvStd as 规格型号, o.ComUnitCode as 计量单位编码, o.ComUnitName as 计量单位, " +
                                          "o.PlanQty as 计划数量, ISNULL(oI.Qty, 0) AS 已生单数量, cast((o.PlanQty - ISNULL(a.iQty, 0)) as decimal(18, 6)) as 本次下单数量, o.StartDate2 as 计划日期, o.DueDate2 as 结束日期, o.date1 as 托外结束日期, o.date2 as 需求日期" +
                                          ", o.cVenCode as 供应商编码,o.cVenCode as 供应商编码OLD,v.cVenName as 供应商, " +
                                          "cast (null as decimal(16,6)) as 含税单价, cast (null as decimal(16,6)) as 税率, o.cAssComUnitCode, o.CompScrap, o.BaseQtyD, o.BaseQtyN, o.bomID, o.cDefWareHouse as 仓库, o.ParentScrap,  " +
                                          "o.cInvCode as 子件编码, o.cInvName as 子件名称, o.cInvStd as 子件规格, 3 as 供应类型, o.OpComponentid, o.ChangeRate, o.UseQty, o.UseNum, o.cComUnitCodeI, o.cAssComUnitCodeI,  " +
                                          "o.unitCode1, o.unitCode2, (cast((o.PlanQty - ISNULL(a.iQty, 0)) as decimal(18, 6)) * o.使用数量) as 子件数量,  (cast((o.PlanQty - ISNULL(a.iQty, 0)) as decimal(18, 6)) * o.辅助使用数量) as 子件件数, o.bUse, o.使用数量, o.辅助使用数量, o.invSZ, o.invSM ,isnull(i.fInExcess,0) as fInExcess,c.iQuantity as CurrQtyI,c.iNum as CurrNumI,a.iQty as 母件发料套数 " +
                                "from UFDLImport.dbo.OMPlanDay o " +
                                    " left join @u8.Vendor v on v.cVenCode = o.cVenCode " +
                                    " left join (select SUM(o.iQuantity) as Qty,OMPlanID from UFDLImport..OMPlan_Import om inner join  @u8.OM_MODetails o on o.MODetailsID = om.OM_MODetailsID and accid = '200' and accyear = '" + MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' group by OMPlanID) oI on o.iID = oI.OMPlanID " +
                                    " left join @u8.Inventory i on i.cInvCode = o.InvCode " +
                                    " left join (select cInvCode,cWhCode,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum from @u8.CurrentStock group by cInvCode,cWhCode) c on c.cInvCode = o.cInvCode and c.cWhCode = o.cDefWareHouse " +
                                    " left join (select a.OMPlanID,sum(b.Qty) as iQty from UFDLImport..OMPlan_Import a inner join (select min(iSendQTY/iUnitQuantity) as Qty,b.MODetailsID from @u8._V_OM_MODetails b inner join @u8._V_OM_MOMaterials  c on c.MoDetailsID = b.MODetailsID where c.iWIPtype = 3 group by b.MODetailsID) b on a.OM_MODetailsID = b.MODetailsID and a.accid = '200' and a.accyear = '" + MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' where isnull(a.OMPlanID,0) <> 0 group by a.OMPlanID) a on a.OMPlanID = o.iID " +
                                "where bUse = 1 and accid = '200' and accyear = '" + MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and o.[iID] = " + sID + " and o.cCode = '" + sCode + "' ";
                        dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt.Rows.Count < 1)
                        {
                            MessageBox.Show("数据错误，请检查！");
                            return;
                        }
                        if (dt.Rows.Count > 1)
                        {
                            MessageBox.Show("数据错误，仅可用于一对一物料！");
                            return;
                        }
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            DataTable dtVP = GetVendPriceInfo(dt.Rows[j]["存货编码"].ToString().Trim(), dt.Rows[j]["供应商编码"].ToString().Trim());
                            if (dtVP != null && dtVP.Rows.Count > 0)
                            {
                                dt.Rows[j]["含税单价"] = dtVP.Rows[0]["iTaxPrice"];
                                dt.Rows[j]["税率"] = dtVP.Rows[0]["iTaxRate"];
                            }
                        }

                        #region 根据条码打印中的可委外数量生成下单数量（只针对一对一情况）

                        if (s.Length > 1)
                        {
                            decimal d1 = decimal.Round(Convert.ToDecimal(dt.Rows[0]["使用数量"]), 6);
                            decimal d2 = decimal.Round(decimal.Parse(s[1].Trim()), 6);
                            dt.Rows[0]["子件数量"] = d2;
                            if (dt.Rows[0]["ChangeRate"].ToString().Trim() == "" || Convert.ToDouble(dt.Rows[0]["ChangeRate"]) == 0)      //判断是否单计量单位
                            {
                                decimal d = decimal.Round(d2 / d1, 0);
                                dt.Rows[0]["本次下单数量"] = decimal.Round(d2 / d1, 0);
                            }
                            else
                            {
                                decimal d = decimal.Round(Convert.ToDecimal(dt.Rows[0]["ChangeRate"]), 6);

                                dt.Rows[0]["本次下单数量"] = decimal.Round(d2 / d1, 0);
                                dt.Rows[0]["子件件数"] = decimal.Round(d2 / d, 6);

                                radio母件数量.Enabled = true;
                                radio子件件数.Enabled = true;
                                radio子件数量.Enabled = true;
                                radio子件数量.Checked = true;
                            }
                        }

                        #endregion

                        bool bHav = false;
                        for (int i = 0; i < dtTable.Rows.Count; i++)
                        {
                            if (dtTable.Rows[i]["日计划ID"].ToString().Trim() == sBarCode)
                            {
                                bHav = true;
                                break;
                            }
                        }

                        if (!bHav)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                DataRow dr = dtTable.NewRow();

                                for (int i = 0; i < dtTable.Columns.Count; i++)
                                {
                                    //防止列顺序不一致，循环判断列名一致的才赋值
                                    for (int ii = 0; ii < dt.Columns.Count; ii++)
                                    {
                                        string sColi = dtTable.Columns[i].ColumnName.Trim();
                                        string sColii = dt.Columns[ii].ColumnName.Trim();
                                        if (sColi == sColii)
                                        {
                                            dr[i] = dt.Rows[j][ii];
                                            break;
                                        }
                                    }
                                }
                                string sVenCode = dr["供应商编码"].ToString().Trim();
                                string sInvCode = dr["存货编码"].ToString().Trim();
                                DataTable dtPrice = GetVendPriceInfo(sInvCode, sVenCode);
                                if (dtPrice != null && dtPrice.Rows.Count > 0)
                                {
                                    dr["含税单价"] = dtPrice.Rows[0]["iTaxPrice"];
                                    dr["税率"] = dtPrice.Rows[0]["iTaxRate"];
                                }
                                dr["序号"] = dtTable.Rows.Count + 1;
                                dtTable.Rows.Add(dr);
                                DataView dv = dtTable.DefaultView;

                                dtTable = dv.ToTable();
                            
                                dataGrid1.DataSource = dtTable;
                            }
                        }
                        else
                        {
                            msgBox.textBox1.Text = "已扫描";
                            msgBox.ShowDialog();
                        }

                        txt条形码.Text = "";
                        txt条形码.Focus();
                    }
                    radio子件数量.Checked = true;
                }
                catch (Exception ee)
                {
                    msgBox.textBox1.Text = "条码输入失败:  " + ee.Message;
                    msgBox.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                txt条形码.Text = "";
                msgBox.textBox1.Text = "条码输入失败:" + ee.Message;
                msgBox.ShowDialog();
            }
        }

       

        private void btn删行_Click(object sender, EventArgs e)
        {
            for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
            {
                if (dataGrid1.IsSelected(i))
                    dtTable.Rows.RemoveAt(i);
            }
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                DataView dv = dtTable.Copy().DefaultView;
                dv.Sort = " 委外计划ID asc";

                DataTable dtData = dv.ToTable();

                DataColumn dc = new DataColumn();
                dc.ColumnName = "OMID";
                dtData.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "OMDeID";
                dtData.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "OMDeIID";
                dtData.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "RDID";
                dtData.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "RDDeID";
                dtData.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "委外订单号";
                dtData.Columns.Add(dc);

                #region 检查数据合法性

                decimal d本次累计 = 0;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    d本次累计 = d本次累计 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次下单数量"]);
                }

                DialogResult dRes = MessageBox.Show("本次下单数量：" + d本次累计.ToString(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (dRes != DialogResult.Yes)
                    return;

                int iYear = int.Parse(MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                int iYear2 = int.Parse(dateTime单据日期.Value.ToString("yyyy"));
                string sSQL = "select getdate()";
                DateTime dtmNow = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));

                if (iYear >= iYear2)
                {
                    sSQL = "select * from @u8.GL_mend where iperiod = month('" + dateTime单据日期.Value.ToString("yyyy-MM-dd") + "')";
                    DataTable dtTemp1 = clsSQLCommond.ExecQuery(sSQL);
                    if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_OM"]) == true)
                    {
                        MessageBox.Show("当月委外管理已结帐，不能录入数据！");
                        return;
                    }

                    if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_ST"]) == true)
                    {
                        MessageBox.Show("当月库存管理已结帐，不能录入数据！");
                        return;
                    }
                }

                string sErr = "";

                ArrayList aListRd11 = new ArrayList();
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    //已生单数量
                    decimal d1 = 0;
                    if (MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["已生单数量"]) != 0)
                        d1 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["已生单数量"]);
                    //本次下单数量
                    decimal d2 = 0;
                    if (MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次下单数量"]) != 0)
                        d2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次下单数量"],0);
                    //超单百分比
                    decimal d3 = 0;
                    if (MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["fInExcess"]) != 0)
                        d3 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["fInExcess"]);
                    //计划下单数量
                    decimal d4 = 0;
                    if (MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["计划数量"]) != 0)
                        d4 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["计划数量"],0);
                    //发料套数
                    decimal d5 = 0;
                    if (MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["母件发料套数"]) != 0)
                        d5 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["母件发料套数"],0);
                    if ((d5 + d2) > d4 * (1 + d3 / 100))
                    {
                        sErr = sErr + "行 " + (i + 1) + "不能超计划托外\r\n";
                    }
                }
                if (sErr.Length > 0)
                {
                    msgBox.textBox1.Text = sErr;
                    msgBox.ShowDialog();
                    return;
                }

                if (dtData.Rows.Count < 1)
                {
                    MessageBox.Show("请选择需要生成的单据！");
                    return;
                }

                ArrayList aList = new ArrayList();

                sErr = "";

                string sVenCode = "";
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    if (sVenCode == "")
                    {
                        sVenCode = dtData.Rows[i]["供应商编码"].ToString().Trim();
                    }

                    if (sVenCode != dtData.Rows[i]["供应商编码"].ToString().Trim())
                    {
                        throw new Exception("委外生单发料不支持多供应商同时生单");
                    }

                    if (dtData.Rows[i]["存货编码"] == null || dtData.Rows[i]["存货编码"].ToString().Trim() == "")
                    {
                        sErr = sErr + "行 " + (i + 1) + " 委外母件不能为空 \r\n";
                        continue;
                    }

                    if (dtData.Rows[i]["需求日期"].ToString().Trim() != "")
                    {
                        DateTime d1 = Convert.ToDateTime(dtData.Rows[i]["需求日期"]);
                        DateTime d2 = DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd"));
                        if (d2 > d1)
                        {
                            sErr = sErr + "行 " + (i + 1) + " 需求日期不能小于当天 \r\n";
                            continue;
                        }
                    }
                    if (dtData.Rows[i]["存货名称"].ToString().Trim() != "" && (dtData.Rows[i]["供应商编码"] == null || dtData.Rows[i]["供应商编码"].ToString().Trim() == "" || dtData.Rows[i]["供应商编码"].ToString().Trim() == "98"))
                    {
                        sErr = sErr + "行 " + (i + 1) + " " + dtData.Rows[i]["存货编码"].ToString() + "未设置供应商！\r\n";
                        continue;
                    }
                    if (dtData.Rows[i]["存货名称"].ToString().Trim() != "" && (dtData.Rows[i]["含税单价"] == null || dtData.Rows[i]["含税单价"].ToString().Trim() == "" || Convert.ToDecimal(dtData.Rows[i]["含税单价"]) == 0))
                    {
                        sErr = sErr + "行 " + (i + 1) + " " + dtData.Rows[i]["存货编码"].ToString() + "未设置材料价格！\r\n";
                        continue;
                    }
                    if (dtData.Rows[i]["存货名称"].ToString().Trim() != "" && (dtData.Rows[i]["税率"] == null || dtData.Rows[i]["税率"].ToString().Trim() == "" || Convert.ToDecimal(dtData.Rows[i]["税率"]) == 0))
                    {
                        sErr = sErr + "行 " + (i + 1) + " " + dtData.Rows[i]["存货编码"].ToString() + "未设置材料税率！\r\n";
                        continue;
                    }
                    if (dtData.Rows[i]["本次下单数量"].ToString().Trim() == "" || dtData.Rows[i]["本次下单数量"] == null || dtData.Rows[i]["本次下单数量"].ToString().Trim() == "0")
                    {
                        sErr = sErr + "行 " + (i + 1) + " " + dtData.Rows[i]["存货编码"].ToString() + "未设置生单数量！\r\n";
                        continue;
                    }
                    if (dtData.Rows[i]["子件件数"].ToString().Trim() == "" && MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtData.Rows[i]["子件件数"]) != 0)
                    {
                        decimal d1 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtData.Rows[i]["子件数量"]);
                        decimal d2 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtData.Rows[i]["子件件数"]);
                        decimal d3 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtData.Rows[i]["ChangeRate"]);
                        decimal d4 = (decimal)1.15;

                        if (d3 * d2 / d4 > d1 || d1 > d3 * d2 * d4)
                        {
                            sErr = sErr + "行 " + (i + 1) + " " + dtData.Rows[i]["存货编码"].ToString() + "不能超按换算率的15%";
                            continue;
                        }
                    }
                }
                if (sErr.Trim() != string.Empty)
                {
                    msgBox.textBox1.Text = "存在以下错误，请修正后继续：\r\n" + sErr;
                    msgBox.ShowDialog();

                    return;
                }

                #endregion

                long iID;
                long iIDDetail;
                long iIDDetailMe;


                sSQL = @"
declare @p5 int
set @p5=0
declare @p6 int
set @p6=0
exec @u8.sp_GetId N'',N'200',N'OM_MO',1,@p5 output,@p6 output,default
select @p5, @p6
";
                DataTable dtID = clsSQLCommond.ExecQuery(sSQL);

                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iID = 0;
                    iIDDetail = 0;
                }
                else
                {
                    iID = Convert.ToInt64(dtID.Rows[0][0]);
                    iIDDetail = Convert.ToInt64(dtID.Rows[0][1]);
                }

                sSQL = @"
declare @p5 int
set @p5=0
declare @p6 int
set @p6=0
exec @u8.sp_GetId N'',N'200',N'OM_Materials',1,@p5 output,@p6 output,default
select @p5, @p6
";
                dtID = clsSQLCommond.ExecQuery(sSQL);
                if (dtID == null || dtID.Rows.Count < 1)
                {
                    iIDDetailMe = 0;
                }
                else
                {
                    iIDDetailMe = Convert.ToInt64(dtID.Rows[0][1]);
                }

                //获得委外订单历史最大单据号
                long iVouNumber;
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='OM01' and cSeed = '" + dateTime单据日期.Value.ToString("yyyyMM") + "'";
                dt = clsSQLCommond.ExecQuery(sSQL);
                iVouNumber = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);

                bool bVouNumber = false;            //当月第一张单据
                if (iVouNumber == 0)
                {
                    bVouNumber = true;
                }

                long iRDID = 0;
                long iRDIDDetail = 0;
                bool bVouNO = false;                //当月第一张单据
                long iVouN0 = 0;


                sSQL = @"
declare @p5 int
set @p5=0
declare @p6 int
set @p6=0
exec @u8.sp_GetId N'',N'200',N'rd',1,@p5 output,@p6 output,default
select @p5, @p6
";

                dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                {
                    iRDID = 0;
                    iRDIDDetail = 0;
                }
                else
                {
                    iRDID = Convert.ToInt64(dt.Rows[0][0]);
                    iRDIDDetail = Convert.ToInt64(dt.Rows[0][1]);
                }

                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412'  and cSeed = '" + dateTime单据日期.Value.ToString("yyMM") + "' and ccontent = '日期' ";
                dt = clsSQLCommond.ExecQuery(sSQL);

                iVouN0 = Convert.ToInt64(dt.Rows[0]["Maxnumber"]);
                if (iVouN0 == 0)
                {
                    bVouNO = true;
                }

                string sCodeRD = "";
                string sCode委外订单号 = "";
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    #region MyRegion 判断生单数量
                    decimal dtemp1 = 0;
                    if (dtData.Rows[i]["本次下单数量"].ToString().Trim() != "")
                    {
                        dtemp1 = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["本次下单数量"]), 6);
                    }
                    if (dtemp1 == 0)
                    {
                        DialogResult d = MessageBox.Show("母件数量不能为空或者小于等于0，是否继续？是：跳过本数据继续生单；否：停止生单", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        if (d != DialogResult.Yes)
                        {
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    decimal dtemp2 = 0;
                    if (dtData.Rows[i]["子件数量"].ToString().Trim() != "")
                    {
                        dtemp2 = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["子件数量"]), 6);
                    }
                    if (dtemp2 == 0)
                    {
                        DialogResult dRes2 = MessageBox.Show("子件数量不能为空或者小于等于0，是否继续？是：跳过本数据继续生单；否：停止生单", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        if (dRes2 != DialogResult.Yes)
                        {
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    #endregion

                    if (i == 0)
                    {
                        #region 委外订单表头

                        iID += 1;
                        iVouNumber += 1;

                        string s委外订单 = GetcCode(iVouNumber.ToString());
                        if (sCode委外订单号 == "")
                        {
                            sCode委外订单号 = s委外订单;
                        }
                        else
                        {
                            sCode委外订单号 = sCode委外订单号 + ";" + s委外订单;
                        }

                        Model.OM_MOMain ModelOM = new BarCode.Model.OM_MOMain();
                        ModelOM.MOID = iID;
                        ModelOM.cCode = s委外订单;
                        ModelOM.dDate = Convert.ToDateTime(dateTime单据日期.Value.ToString("yyyy-MM-dd"));
                        ModelOM.cVenCode = sVenCode;
                        ModelOM.cDepCode = "905";
                        ModelOM.cPTCode = "02";
                        ModelOM.cexch_name = "人民币";
                        ModelOM.iTaxRate = 13;
                        ModelOM.cMaker = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                        ModelOM.cVerifier = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                        ModelOM.iVTid = 30770;
                        ModelOM.cBusType = "委外加工";
                        ModelOM.cState = 1;
                        ModelOM.iReturnCount = 0;
                        ModelOM.iVerifyStateNew = 2;
                        ModelOM.IsWfControlled = 0;
                        ModelOM.dCreateTime = dtmNow;
                        ModelOM.dVerifyDate = Convert.ToDateTime(dateTime单据日期.Value.ToString("yyyy-MM-dd"));
                        ModelOM.dVerifyTime = Convert.ToDateTime(dateTime单据日期.Value.ToString("yyyy-MM-dd")); ;
                        ModelOM.iPrintCount = 0;
                        ModelOM.iOrderType = 0;
                        ModelOM.nflat = 1;
                        DAL.OM_MOMain DalOM = new BarCode.DAL.OM_MOMain();
                        sSQL = DalOM.Add(ModelOM);
                        aList.Add(sSQL);

                        dtData.Rows[i]["OMID"] = iID;
                        dtData.Rows[i]["委外订单号"] = ModelOM.cCode;

                        #endregion

                        #region 材料出库单表头

                        sSQL = "select * from @u8.Inventory where cInvCode = '" + dtData.Rows[i]["子件编码"].ToString().Trim() + "'";
                        DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);
                        if (dtInv.Rows[0]["cDefWareHouse"] == null || dtInv.Rows[0]["cDefWareHouse"].ToString().Trim() == string.Empty)
                        {
                            MessageBox.Show("请定义物料‘" + dtInv.Rows[0]["cInvCode"] + "’默认仓库");
                            return;
                        }

                        iRDID += 1;
                        iVouN0 += 1;

                        string s材料出库 = GetRDCode(iVouN0);
                        if (sCodeRD == "")
                        {
                            sCodeRD = s材料出库;
                        }
                        else
                        {
                            sCodeRD = sCodeRD + ";" + s材料出库;
                        }

                        Model.rdrecord11 modelRd11 = new BarCode.Model.rdrecord11();
                        modelRd11.ID = iRDID;
                        modelRd11.bRdFlag = 0;
                        modelRd11.cVouchType = "11";
                        modelRd11.cBusType = "委外发料";
                        modelRd11.cSource = "委外订单";
                        modelRd11.cWhCode = dtData.Rows[i]["仓库"].ToString().Trim();
                        modelRd11.dDate = Convert.ToDateTime(dateTime单据日期.Value.ToString("yyyy-MM-dd"));
                        modelRd11.cCode = s材料出库;
                        modelRd11.cRdCode = "211";
                        modelRd11.cDepCode = "905";
                        modelRd11.cVenCode = dtData.Rows[i]["供应商编码"].ToString();
                        modelRd11.cMaker = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                        modelRd11.bpufirst = false;
                        modelRd11.biafirst = false;
                        modelRd11.VT_ID = 65;
                        modelRd11.bIsSTQc = false;
                        modelRd11.cMPoCode = dtData.Rows[i]["委外订单号"].ToString();
                        modelRd11.iproorderid = ModelOM.MOID;
                        modelRd11.bFromPreYear = false;
                        modelRd11.bIsSTQc = false;
                        modelRd11.iDiscountTaxType = 0;
                        modelRd11.ireturncount = 0;
                        modelRd11.iverifystate = 0;
                        modelRd11.iswfcontrolled = 0;
                        modelRd11.dnmaketime = dtmNow;
                        modelRd11.bredvouch = 0;
                        modelRd11.iPrintCount = 0;
                        //modelRd11.iMQuantity = ReturnDecimal(dtData.Rows[i]["本次下单数量"]);
                        DAL.rdrecord11 DalRd11 = new BarCode.DAL.rdrecord11();
                        sSQL = DalRd11.Add(modelRd11);
                        aList.Add(sSQL);

                        aListRd11.Add(modelRd11.ID);

                        dtData.Rows[i]["RDID"] = modelRd11.ID;
                    }


                        #endregion

                    DataTable dtcItemCode = null;
                    if (dtData.Rows[i]["销售订单号"] != null && dtData.Rows[i]["销售订单号"].ToString().Trim() != string.Empty)
                    {
                        sSQL = "select sd.cItemCode,sd.cItemName,sd.cItem_class,sd.cItem_CName from @u8.SO_SOMain s inner join @u8.SO_SODetails sd on s.id = sd.id where s.cSOCode = '" + dtData.Rows[i]["销售订单号"].ToString().Trim() + "' and sd.iRowNo =  " + dtData.Rows[i]["销售订单行号"].ToString().Trim();
                        dtcItemCode = clsSQLCommond.ExecQuery(sSQL);
                    }

                    iIDDetail += 1;

                    #region 委外订单表体

                    Model.OM_MODetails ModelOMD = new BarCode.Model.OM_MODetails();
                    ModelOMD.MODetailsID = iIDDetail;
                    ModelOMD.MOID = RetrunLong(dtData.Rows[0]["OMID"]);
                    ModelOMD.cInvCode = dtData.Rows[i]["存货编码"].ToString().Trim();
                    ModelOMD.iQuantity = ReturnDecimal(dtData.Rows[i]["本次下单数量"], 0);
                    ModelOMD.iUnitPrice = ReturnDecimal(ReturnDecimal(dtData.Rows[i]["含税单价"]) / (1 + (ReturnDecimal(dtData.Rows[i]["税率"]) / 100)));
                    ModelOMD.iSum = ReturnDecimal(ReturnDecimal(dtData.Rows[i]["含税单价"]) * ReturnDecimal(dtData.Rows[i]["本次下单数量"]));
                    ModelOMD.iMoney = ReturnDecimal(ModelOMD.iSum / (1 + (ReturnDecimal(dtData.Rows[i]["税率"]) / 100)), 2);
                    ModelOMD.iTax = ModelOMD.iSum - ModelOMD.iMoney;
                    ModelOMD.iNatUnitPrice = ModelOMD.iUnitPrice;
                    ModelOMD.iNatMoney = ModelOMD.iMoney;
                    ModelOMD.iNatTax = ModelOMD.iTax;
                    ModelOMD.iNatSum = ModelOMD.iSum;
                    ModelOMD.dStartDate = Convert.ToDateTime(dtData.Rows[i]["托外结束日期"]);
                    ModelOMD.dArriveDate = Convert.ToDateTime(dtData.Rows[i]["需求日期"]);
                    ModelOMD.iPerTaxRate = ReturnDecimal(dtData.Rows[i]["税率"]);
                    //ModelOMD.cDefine24 = 
                    //ModelOMD.cDefine25 = 
                    ModelOMD.cItemCode = dtcItemCode.Rows[0]["cItemCode"].ToString().Trim();
                    ModelOMD.cItem_class = dtcItemCode.Rows[0]["cItem_class"].ToString();
                    ModelOMD.cItemName = dtcItemCode.Rows[0]["cItemName"].ToString();
                    ModelOMD.bGsp = 0;
                    ModelOMD.iTaxPrice = ReturnDecimal(dtData.Rows[i]["含税单价"]);
                    ModelOMD.bTaxCost = true;
                    ModelOMD.BomID = RetrunLong(dtData.Rows[i]["bomID"]);
                    ModelOMD.fParentScrp = 0;
                    ModelOMD.iMaterialSendQty = 0;
                    ModelOMD.iVTids = 8159;
                    ModelOMD.iVouchRowNo = i + 1;
                    ModelOMD.BomType = 1;
                    ModelOMD.imrpqty = ModelOMD.iQuantity;
                    DAL.OM_MODetails DalOMD = new BarCode.DAL.OM_MODetails();
                    sSQL = DalOMD.Add(ModelOMD);
                    aList.Add(sSQL);

                    dtData.Rows[i]["OMDeID"] = ModelOMD.MODetailsID;

                    sSQL = @"
select i.iGroupType,i.cGroupCode,i.cComUnitCode,isnull(i.cAssComUnitCode,'') as cAssComUnitCode,u.iChangRate 
from @u8.Inventory I left join @u8.ComputationUnit u on u.cGroupCode = i.cGroupCode and u.cComunitCode = i.cAssComUnitCode 
where i.cInvCode = '" + dtData.Rows[i]["存货编码"].ToString().Trim() + "' ";
                    DataTable dtChangRate = clsSQLCommond.ExecQuery(sSQL);
                    if (dtChangRate != null && dtChangRate.Rows.Count > 0 && dtChangRate.Rows[0]["cAssComUnitCode"].ToString().Trim() != "")
                    {
                        ModelOMD.cUnitID = dtChangRate.Rows[0]["cAssComUnitCode"].ToString();

                        decimal dChangRate = Convert.ToDecimal(dtData.Rows[i]["本次下单数量"]) / decimal.Round(Convert.ToDecimal(dtChangRate.Rows[0]["iChangRate"]), 2);
                        ModelOMD.iNum = decimal.Round(dChangRate, 6);
                    }

                    sSQL = "insert into UFDLImport.dbo.OMPlan_Import(OMPlanID,Qty,OM_MODetailsID,UserID,dDate,accid,accyear)values" +
                            "(" + dtData.Rows[i]["委外计划ID"] + "," + Convert.ToDouble(dtData.Rows[i]["本次下单数量"]) + "," + iIDDetail + ",'" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "','" + dateTime单据日期.Value.ToString("yyyy-MM-dd") + "','200','" + MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "')";
                    aList.Add(sSQL);

                    sSQL = "insert into UFDLImport.dbo.OMPlanDay_Import(OMPlanDayID,OMPlanID,Qty,OM_MODetailsID,UserID,dDate,accid,accyear,cInvCode)values" +
                          "(" + dtData.Rows[i]["日计划ID"] + "," + dtData.Rows[i]["委外计划ID"] + "," + Convert.ToDouble(dtData.Rows[i]["本次下单数量"]) + "," + iIDDetail + ",'" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "','" + dateTime单据日期.Value.ToString("yyyy-MM-dd") + "',200," + MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + ",'" + dtData.Rows[i]["存货编码"] + "')";
                    aList.Add(sSQL);

                    #endregion
                    #region 委外订单用料表

                    iIDDetailMe += 1;

                    Model.OM_MOMaterials ModelOMMs = new BarCode.Model.OM_MOMaterials();
                    ModelOMMs.MOMaterialsID = iIDDetailMe;
                    ModelOMMs.MoDetailsID = ModelOMD.MODetailsID;
                    ModelOMMs.MOID = RetrunLong(dtData.Rows[0]["OMID"]);
                    ModelOMMs.cInvCode = dtData.Rows[i]["子件编码"].ToString().Trim();
                    ModelOMMs.iQuantity = ReturnDecimal(dtData.Rows[i]["子件数量"]);
                    ModelOMMs.dRequiredDate = Convert.ToDateTime(dtData.Rows[i]["计划日期"]);
                    ModelOMMs.iSendQTY = ModelOMMs.iQuantity;
                    ModelOMMs.fBaseQtyN = ReturnDecimal(dtData.Rows[i]["BaseQtyN"]);
                    ModelOMMs.fBaseQtyD = ReturnDecimal(dtData.Rows[i]["BaseQtyD"]);
                    ModelOMMs.fCompScrp = 0;
                    ModelOMMs.bFVQty = 0;
                    ModelOMMs.iWIPtype = 3;
                    ModelOMMs.cWhCode = dtData.Rows[i]["仓库"].ToString();
                    ModelOMMs.iUnitQuantity = ReturnDecimal(dtData.Rows[i]["使用数量"]);
                    ModelOMMs.OpComponentId = RetrunLong(dtData.Rows[i]["OpComponentId"]);
                    ModelOMMs.SubFlag = 0;
                    ModelOMMs.fbasenumn = ReturnDecimal(dtData.Rows[i]["辅助使用数量"]);
                    ModelOMMs.iUnitNum = ReturnDecimal(dtData.Rows[i]["辅助使用数量"]);
                    if (ReturnDecimal(dtData.Rows[i]["子件件数"]) != 0)
                    {
                        ModelOMMs.iNum = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["子件件数"]), 6);
                        ModelOMMs.iSendNum = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["子件件数"]), 6);
                    }
                    ModelOMMs.cUnitID = dtData.Rows[i]["unitCode2"].ToString().Trim();
                    DAL.OM_MOMaterials DalOMMs = new BarCode.DAL.OM_MOMaterials();
                    sSQL = DalOMMs.Add(ModelOMMs);
                    aList.Add(sSQL);

                    dtData.Rows[i]["OMDeIID"] = iIDDetailMe;
                    #endregion

                    #region 材料出库单表体

                    iRDIDDetail += 1;

                    dtData.Rows[i]["RDDeID"] = iRDIDDetail;

                    Model.rdrecords11 ModelRds11 = new BarCode.Model.rdrecords11();

                    ModelRds11.AutoID = iRDIDDetail;
                    ModelRds11.ID = RetrunLong(dtData.Rows[0]["RDID"]);
                    ModelRds11.cInvCode = dtData.Rows[i]["子件编码"].ToString().Trim();


                    if (dtData.Rows[i]["辅助使用数量"] != null && dtData.Rows[i]["辅助使用数量"].ToString().Trim() != string.Empty)
                    {
                        ModelRds11.iNum = ReturnDecimal(dtData.Rows[i]["子件件数"]);
                    }
                    ModelRds11.iQuantity = decimal.Round(Convert.ToDecimal(dtData.Rows[i]["子件数量"]), 6);
                    ModelRds11.iNum = ReturnDecimal(dtData.Rows[i]["子件件数"]);
                    ModelRds11.iFlag = 0;
                    ModelRds11.comcode = dtData.Rows[0]["委外订单号"].ToString();
                    if (dtcItemCode != null && dtcItemCode.Rows.Count > 0)
                    {
                        ModelRds11.cItem_class = dtcItemCode.Rows[0]["cItem_class"].ToString();
                        ModelRds11.cItemCode = dtcItemCode.Rows[0]["cItemCode"].ToString();
                        ModelRds11.cItemCName = "外销订单项目";
                        ModelRds11.cName = dtcItemCode.Rows[0]["cItemName"].ToString();
                    }
                    ModelRds11.iNQuantity = ReturnDecimal(dtData.Rows[i]["子件数量"]);
                    if (dtData.Rows[i]["子件件数"] != null && dtData.Rows[i]["子件件数"].ToString().Trim() != "")
                    {
                        ModelRds11.iNNum = ReturnDecimal(dtData.Rows[i]["子件件数"]);
                    }
                    ModelRds11.iOMoDID = RetrunInt(dtData.Rows[i]["OMDeID"]);
                    ModelRds11.ipesodid = dtData.Rows[i]["OMDeID"].ToString();
                    ModelRds11.ipesotype = 8;
                    ModelRds11.iOriTrackID = 0;
                    ModelRds11.bLPUseFree = false;
                    ModelRds11.bCosting = true;
                    ModelRds11.bVMIUsed = false;
                    ModelRds11.invcode = dtData.Rows[i]["存货编码"].ToString();
                    ModelRds11.iExpiratDateCalcu = 0;
                    ModelRds11.iordertype = 0;
                    ModelRds11.isotype = 0;
                    ModelRds11.iOMoMID = ModelOMMs.MOMaterialsID;

                    if (dtData.Rows[i]["仓库"].ToString().Trim() == "01")
                    {
                        ModelRds11.cPosition = dtData.Rows[i]["货位"].ToString().Trim();
                        ModelRds11.iposflag = 1;
                    }

                    if (dtChangRate.Rows[0]["cAssComUnitCode"].ToString().Trim() != "")
                    {
                        ModelRds11.cAssUnit = dtChangRate.Rows[0]["cAssComUnitCode"].ToString().Trim();
                    }

                    ModelRds11.cpesocode = dtData.Rows[0]["委外订单号"].ToString();
                    ModelRds11.irowno = i + 1;

                    DAL.rdrecords11 DalRds11 = new BarCode.DAL.rdrecords11();
                    sSQL = DalRds11.Add(ModelRds11);
                    aList.Add(sSQL);

                    sSQL = "update @u8.OM_MODetails set iMaterialSendQty = " + ModelRds11.iQuantity + " where MODetailsID = " + ModelRds11.iOMoDID;
                    aList.Add(sSQL);

                    string sNum = "null";
                    if (ReturnDecimal(ModelRds11.iNum) != 0)
                    {
                        sNum = ModelRds11.iNum.ToString();
                    }
                    if (sNum == "null")
                    {
                        sSQL = "if exists(select * from @u8.CurrentStock where cWhCode = '" + dtData.Rows[i]["仓库"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["子件编码"] + "') " +
                                    "update @u8.CurrentStock set iQuantity = iQuantity - " + ModelRds11.iQuantity.ToString() + " where  cWhCode = '" + dtData.Rows[i]["仓库"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["子件编码"] + "' " +
                                "else " +
                                    "insert into @u8.CurrentStock(itemid,cWhCode,cInvCode,iQuantity,iSoType)values" +
                                "(999999,'" + dtData.Rows[i]["仓库"].ToString().Trim() + "','" + dtData.Rows[i]["子件编码"] + "',-" + ModelRds11.iQuantity.ToString() + ",1)";
                    }
                    else
                    {
                        sSQL = "if exists(select * from @u8.CurrentStock where cWhCode = '" + dtData.Rows[i]["仓库"].ToString().Trim().ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["子件编码"] + "') " +
                                    "update @u8.CurrentStock set iQuantity = iQuantity - " + ModelRds11.iQuantity.ToString() + ",iNum = iNum - " + sNum + " where  cWhCode = '" + dtData.Rows[i]["仓库"].ToString().Trim() + "' and cInvCode = '" + dtData.Rows[i]["子件编码"] + "' " +
                                "else " +
                                    "insert into @u8.CurrentStock(itemid,cWhCode,cInvCode,iQuantity,iNum,iSoType)values" +
                                "(999999,'" + dtData.Rows[i]["仓库"].ToString().Trim() + "','" + dtData.Rows[i]["子件编码"] + "',-" + ModelRds11.iQuantity.ToString() + ",-" + sNum + ",1)";
                    }
                    aList.Add(sSQL);

                    string s辅计量编码 = "null";
                    if (ModelRds11.cAssUnit != "")
                        s辅计量编码 = ModelRds11.cAssUnit;

                    Model.InvPosition model = new BarCode.Model.InvPosition();
                    model.RdsID = iRDIDDetail;
                    model.RdID = iRDID;
                    model.cWhCode = dtData.Rows[i]["仓库"].ToString().Trim();
                    model.cPosCode = dtData.Rows[i]["货位"].ToString().Trim();
                    model.cInvCode = ModelRds11.cInvCode;
                    model.iQuantity = ModelRds11.iQuantity;

                    if (ModelRds11.iNum != 0)
                        model.iNum = ModelRds11.iNum;

                    model.cHandler = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                    model.dDate = MobileBaseDLL.ClsBaseDataInfo.ReturnDate(dateTime单据日期.Value.ToString("yyyy-MM-dd"));
                    model.bRdFlag = 0;
                    model.cAssUnit = s辅计量编码;
                    model.iTrackId = 0;
                    model.iExpiratDateCalcu = 0;
                    model.cvouchtype = "11";
                    model.dVouchDate = MobileBaseDLL.ClsBaseDataInfo.ReturnDate(dateTime单据日期.Value.ToString("yyyy-MM-dd"));

                    DAL.InvPosition dal = new BarCode.DAL.InvPosition();
                    sSQL = dal.Add(model);
                    aList.Add(sSQL);

                    sSQL = @"
if exists (select * from @u8.InvPositionSum where  cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb')
    update @u8.InvPositionSum set iQuantity = isnull(iQuantity,0) - dddddddddd,iNum = isnull(iNum,0) - eeeeeeeeee where cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb'
else
    insert into @u8.InvPositionSum(cInvCode,cWhCode,cPosCode,iQuantity,iNum)
    values('aaaaaaaaaa','cccccccccc','bbbbbbbbbb',-dddddddddd,-eeeeeeeeee)
";
                    sSQL = sSQL.Replace("aaaaaaaaaa", model.cInvCode);
                    sSQL = sSQL.Replace("bbbbbbbbbb", model.cPosCode);
                    sSQL = sSQL.Replace("cccccccccc", model.cWhCode);
                    sSQL = sSQL.Replace("dddddddddd", model.iQuantity.ToString());

                    if (ReturnDecimal(model.iNum) == 0)
                    {
                        sSQL = sSQL.Replace("eeeeeeeeee", "0");
                    }
                    else
                    {
                        sSQL = sSQL.Replace("eeeeeeeeee", model.iNum.ToString());
                    }
                    aList.Add(sSQL);

                    #endregion
                }

                if (iRDID > 1000000000)
                    iRDID = iRDID - 1000000000;
                if (iRDIDDetail > 1000000000)
                    iRDIDDetail = iRDIDDetail - 1000000000;

                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iRDID + ",iChildID=" + iRDIDDetail + " where  cAcc_Id = '200' and cVouchType = 'rd'";
                aList.Add(sSQL);


                if (iIDDetail > 1000000000)
                    iIDDetail = iIDDetail - 1000000000;
                if (iID > 1000000000)
                    iID = iID - 1000000000;
                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iID + ",iChildID=" + iIDDetail + " where  cAcc_Id = '200' and cVouchType = 'OM_MO'";
                aList.Add(sSQL);

                if (iIDDetailMe > 1000000000)
                    iIDDetailMe = iIDDetailMe - 1000000000;
                sSQL = "update UFSystem..UA_Identity set iFatherID=" + iIDDetail + ",iChildID=" + iIDDetailMe + " where  cAcc_Id = '200' and cVouchType = 'OM_Materials'";
                aList.Add(sSQL);

                if (bVouNO)
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,cContent,cContentRule,cSeed,cNumber,bEmpty) " +
                            "values('0412','日期','月','" + DateTime.Parse(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouN0.ToString().Trim() + "' where  CardNumber='0412' and cSeed = '" + Convert.ToDateTime(dateTime单据日期.Value.ToString("yyyy-MM-dd")).ToString("yyMM") + "' and ccontent = '日期' ";
                    aList.Add(sSQL);
                }

                if (bVouNumber)
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,cContent,cContentRule,cSeed,cNumber,bEmpty) " +
                            "values('OM01','单据日期','月','" + dateTime单据日期.Value.ToString("yyyyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iVouNumber + "' where  CardNumber='OM01' and cSeed = '" + dateTime单据日期.Value.ToString("yyyyMM") + "'";
                    aList.Add(sSQL);
                }

                if (aListRd11.Count > 0)
                {
                    for (int i = 0; i < aListRd11.Count; i++)
                    {
                        sSQL = "exec @u8.IA_SP_WriteUnAccountVouchForST 'aaaaaaaa',N'11'";
                        sSQL = sSQL.Replace("aaaaaaaa", aListRd11[i].ToString());
                        aList.Add(sSQL);
                    }
                }

                sSQL = "insert into [UFDLImport].[dbo].[栈板厂商收发登记表]( 厂商编码, 单据类型, 单据号, 栈板1, 栈板2, 栈板3, 栈板4, 栈板5, 栈板6, 栈板7, 栈板8, 日期, 制单人, 制单日期, 审核人, 审核日期)" +
                 "values('" + dtData.Rows[0]["供应商编码"].ToString().Trim() + "','委外发料','" + sCodeRD + "'," + -1 * i栈板1 + "," + -1 * i栈板2 + "," + -1 * i栈板3 + "," + -1 * i栈板4 + "," + -1 * i栈板5 + "," + -1 * i栈板6 + "," + -1 * i栈板7 + "," + -1 * i栈板8 + ",'" + dateTime单据日期.Value + "','" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "',getdate(),'" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "',getdate())";
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    dtTable.Rows.Clear();

                    txt编辑.Text = "";
                    txt条形码.Text = "";
                    txt货位.Text = "";
                    txt栈板登记.Text = "";

                    txt栈板登记.Focus();

                    i栈板1 = 0;
                    i栈板2 = 0;
                    i栈板3 = 0;
                    i栈板4 = 0;
                    i栈板5 = 0;
                    i栈板6 = 0;
                    i栈板7 = 0;
                    i栈板8 = 0;

                    msgBox.textBox1.Text = "委外订单号：" + sCode委外订单号 + "\r\n" + "材料出库单：" + sCodeRD;
                    msgBox.ShowDialog();

                    radio母件数量.Enabled = false;
                    radio子件件数.Enabled = false;
                    radio子件数量.Enabled = false;
                    radio子件数量.Checked = true;
                }
                else
                {
                    msgBox.textBox1.Text = "保存失败:没有数据生成单据";
                    msgBox.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                msgBox.textBox1.Text = "保存失败:" + ee.Message;
                msgBox.ShowDialog();
            }
        }
    
        int iRow = -1;
        int iCol = -1;
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridCell editCell = dataGrid1.CurrentCell;
                Rectangle cellPos = new Rectangle();
                iRow = editCell.RowNumber;
                iCol = editCell.ColumnNumber;

                if (iCol == 2 || iCol == 4 || iCol == 5 || iCol == 6)
                {
                    if ((iCol == 2 && radio母件数量.Checked) || (iCol == 5 && radio子件数量.Checked) || (iCol == 7 && radio子件件数.Checked) || iCol == 4)
                    {
                        cellPos = dataGrid1.GetCellBounds(iRow, iCol);
                        txt编辑.Left = cellPos.Left;
                        txt编辑.Top = cellPos.Top + dataGrid1.Top;
                        txt编辑.Width = cellPos.Width;
                        txt编辑.Height = cellPos.Height;
                        txt编辑.Visible = true;
                        txt编辑.Text = dtTable.Rows[editCell.RowNumber][editCell.ColumnNumber].ToString().Trim();
                        txt编辑.Focus();
                    }
                }
                else if (iCol == 7 || iCol == 8)
                {
                    cellPos = dataGrid1.GetCellBounds(iRow, iCol);
                    date编辑.Left = cellPos.Left;
                    date编辑.Top = cellPos.Top + dataGrid1.Top;
                    date编辑.Width = cellPos.Width;
                    date编辑.Height = cellPos.Height;
                    date编辑.Visible = true;
                    date编辑.Text = dtTable.Rows[editCell.RowNumber][editCell.ColumnNumber].ToString().Trim();
                    date编辑.Focus();
                }
                else
                {
                    txt编辑.Text = "";
                    txt编辑.Visible = false;
                    date编辑.Text = "";
                    date编辑.Visible = false;
                    iRow = -1;
                    iCol = -1;
                }
            }
            catch
            {
                txt编辑.Text = "";
                txt编辑.Visible = false;
                date编辑.Text = "";
                date编辑.Visible = false;
                iRow = -1;
                iCol = -1;
            }
        }

        private void txt条形码_LostFocus(object sender, EventArgs e)
        {
            txt编辑.Text = "";
            txt编辑.Visible = false;
        }

        private void txt条数_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    i栈板1 = 0;
                    i栈板2 = 0;
                    i栈板3 = 0;
                    i栈板4 = 0;
                    i栈板5 = 0;
                    i栈板6 = 0;
                    i栈板7 = 0;
                    i栈板8 = 0;

                    if (txt条数.Text.Trim() == "")
                        return;

                    int iR = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim());
                    if (iR <= 0)
                    {
                        throw new Exception("条数必须大于0");
                    }
                    txt货位.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                if (txt条数.Text.Trim() != "")
                {
                    txt条数.Text = "";
                }
            }
        }

        private void txt货位_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt货位.Text.Trim() == "")
                    {
                        return;
                    }
                    string s货位 = clsDES.Decrypt(txt货位.Text.Trim());
                    DataTable dt货位 = clsu8.Chk货位(s货位);
                    if (dt货位 == null || dt货位.Rows.Count < 1)
                    {
                        throw new Exception("货位信息失败");
                    }
                    if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
                    {
                        throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());
                    }

                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("货物错误:" + ee.Message);
                if (txt货位.Text.Trim() != "")
                {
                    txt货位.Text = "";
                }
            }
        }

        /// <summary>
        /// 供应商存货价格表，便宜者
        /// </summary>
        /// <param name="p">存货编码</param>
        /// <param name="sVend">供应商编码</param>
        /// <returns></returns>
        private DataTable GetVendPriceInfo(string p, string sVend)
        {
            try
            {
                 string sSQL = @" 
select distinct *,v.iunitprice as iUnitPrice,v.itaxunitprice as iTaxPrice 
from 
	( 
        select max(dEnableDate) as dEnableDate 
	    from @u8.ven_inv_price 
	    where cInvCode = 'bbbbbb' and cVenCode = 'aaaaaa' 
	    group by cvencode,cInvCode 
    ) vT 
	left join @u8.ven_inv_price v on v.dEnableDate = vT.dEnableDate   
	left join @u8.vendor vd on vd.cVenCode = v.cVenCode 
where v.iSupplyType = '2' 
	and v.cInvCode = 'bbbbbb' and v.cVenCode = 'aaaaaa' 
order by v.iunitprice,v.Autoid 
                ";

                            sSQL =sSQL.Replace("aaaaaa",sVend);
                            sSQL =sSQL.Replace("bbbbbb",p);
                 return clsSQLCommond.ExecQuery(sSQL);
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商物料信息失败！\r\n  " + ee.Message);
            }
        }

        private string GetcCode(string s)
        {
            for (int i = 0; i < 5; i++)
            {
                if (s.Length < 3)
                {
                    s = "0" + s;
                }
                else
                {
                    break;
                }
            }
            return "AM" + dateTime单据日期.Value.ToString("yyMM") + s;
        }

        private string GetRDCode(long iCode)
        {
            string sVouNumber = iCode.ToString().Trim();
            for (int i = 0; i < 10; i++)
            {
                if (sVouNumber.Length < 4)
                {
                    sVouNumber = "0" + sVouNumber;
                }
                else
                {
                    break;
                }
            }
            return "OP" + dateTime单据日期.Value.ToString("yyMM") + sVouNumber;
        }

        private void date编辑_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (iRow == -1 || iCol == -1)
                    return;

                dtTable.Rows[iRow][iCol] = date编辑.Value.ToString("yyyy-MM-dd");
                iRow = -1;
                iCol = -1;
                date编辑.Visible = false;
                date编辑.Text = "";
            }
            catch
            { }
        }

        private void date编辑_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (iRow == -1 || iCol == -1)
                        return;

                    dtTable.Rows[iRow][iCol] = date编辑.Value.ToString("yyyy-MM-dd");
                    iRow = -1;
                    iCol = -1;
                    date编辑.Visible = false;
                    date编辑.Text = "";
                }
            }
            catch
            { }
        }

        private void txt编辑_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (iCol < 0 || iRow < 0)
            //        return;

            //    decimal d = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text.Trim());
            //    if (iCol == 2 && radio母件数量.Checked)
            //    {
            //        decimal d使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["使用数量"]);
            //        decimal d辅助使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["辅助使用数量"]);
            //        dtTable.Rows[iRow]["子件数量"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d * d使用数量);
            //        if (d辅助使用数量 != 0)
            //        {
            //            dtTable.Rows[iRow]["子件件数"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d * d辅助使用数量);
            //        }
            //    }
            //    if (iCol == 5 && radio子件数量.Checked)
            //    {
            //        decimal d使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["使用数量"]);
            //        decimal d辅助使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["辅助使用数量"]);
            //        dtTable.Rows[iRow]["本次下单数量"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d / d使用数量);
            //        if (d辅助使用数量 != 0)
            //        {
            //            dtTable.Rows[iRow]["子件件数"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d / d使用数量 * d辅助使用数量);
            //        }
            //    }
            //    if (iCol == 6 && radio子件件数.Checked)
            //    {
            //        decimal d使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["使用数量"]);
            //        decimal d辅助使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["辅助使用数量"]);
            //        dtTable.Rows[iRow]["本次下单数量"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d / d辅助使用数量);
            //        dtTable.Rows[iRow]["子件数量"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d / d辅助使用数量 * d使用数量);
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }

        private void txt编辑_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    txt编辑_LostFocus(null, null);
                }
            }
            catch
            { }
        }


        private void txt编辑_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (iRow == -1 || iCol == -1)
                    return;

                if (iCol == 2 && radio母件数量.Checked)
                {
                    decimal d = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text.Trim());
                    decimal d使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["使用数量"]);
                    decimal d辅助使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["辅助使用数量"]);
                    dtTable.Rows[iRow]["子件数量"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d * d使用数量);
                    if (d辅助使用数量 != 0)
                    {
                        dtTable.Rows[iRow]["子件件数"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d * d辅助使用数量);
                    }
                }
                if (iCol == 5 && radio子件数量.Checked)
                {
                    decimal d = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text.Trim());
                    decimal d使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["使用数量"]);
                    decimal d辅助使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["辅助使用数量"]);
                    dtTable.Rows[iRow]["本次下单数量"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d / d使用数量);
                    if (d辅助使用数量 != 0)
                    {
                        dtTable.Rows[iRow]["子件件数"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d / d使用数量 * d辅助使用数量);
                    }
                }
                if (iCol == 6 && radio子件件数.Checked)
                {
                    decimal d = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text.Trim());
                    decimal d使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["使用数量"]);
                    decimal d辅助使用数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["辅助使用数量"]);
                    dtTable.Rows[iRow]["本次下单数量"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d / d辅助使用数量);
                    dtTable.Rows[iRow]["子件数量"] = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(d / d辅助使用数量 * d使用数量);
                }

                if (iCol == 4)
                {
                    //判断货位
                    string s货位 = txt编辑.Text.Trim();
                    DataTable dt货位 = clsu8.Chk货位(s货位);
                    if (dt货位 == null || dt货位.Rows.Count < 1)
                    {
                        throw new Exception("货位信息失败");
                    }
                    if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
                    {
                        throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());
                    }


                    dtTable.Rows[iRow]["货位"] = s货位;
                    dtTable.Rows[iRow]["仓库"] = dt货位.Rows[0]["仓库编码"].ToString().Trim();
                }

                dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                iRow = -1;
                iCol = -1;
                txt编辑.Visible = false;
                txt编辑.Text = "";
            }
            catch
            { }
        }

        private void txt栈板登记_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt栈板登记.Text.Trim() == "")
                        return;

                    long iR = MobileBaseDLL.ClsBaseDataInfo.ReturnLong(txt栈板登记.Text.Trim());
                    string sSQL = "select * from [UFDLImport]..栈板打印登记 where iID = " + iR;
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        i栈板1 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板1"]);
                        i栈板2 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板2"]);
                        i栈板3 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板3"]);
                        i栈板4 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板4"]);
                        i栈板5 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板5"]);
                        i栈板6 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板6"]);
                        i栈板7 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板7"]);
                        i栈板8 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["栈板8"]);
                        txt条数.Text = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt.Rows[0]["数量"]).ToString().Trim();
                    }
                    txt货位.Focus();
                }
            }
            catch (Exception ee)
            {
                txt条数.Text = "";

                msgBox.textBox1.Text = ee.Message;
                msgBox.ShowDialog();
            }
        }

        private void btn栈板_Click(object sender, EventArgs e)
        {

            Frm栈板 f = new Frm栈板();
            f.txt栈板1.Text = i栈板1.ToString().Trim();
            f.txt栈板2.Text = i栈板2.ToString().Trim();
            f.txt栈板3.Text = i栈板3.ToString().Trim();
            f.txt栈板4.Text = i栈板4.ToString().Trim();
            f.txt栈板5.Text = i栈板5.ToString().Trim();
            f.txt栈板6.Text = i栈板6.ToString().Trim();
            f.txt栈板7.Text = i栈板7.ToString().Trim();
            f.txt栈板8.Text = i栈板8.ToString().Trim();
            f.ShowDialog();

            i栈板1 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板1.Text.Trim());
            i栈板2 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板2.Text.Trim());
            i栈板3 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板3.Text.Trim());
            i栈板4 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板4.Text.Trim());
            i栈板5 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板5.Text.Trim());
            i栈板6 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板6.Text.Trim());
            i栈板7 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板7.Text.Trim());
            i栈板8 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(f.txt栈板8.Text.Trim());
        }
    }
}