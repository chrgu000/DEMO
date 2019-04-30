using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FrameBaseFunction;

namespace Purchase
{
    public partial class FrmStockOrderCreateSel : Form
    {
        public DataTable dt1;
        public DataTable dt2;
        DataTable dtPriceList;
        string sUidDep;
        
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();
        FrameBaseFunction.ClsGetSQL clsGetSQL = FrameBaseFunction.ClsGetSQL.Instance();

        public FrmStockOrderCreateSel()
        {
            InitializeComponent();
        }

        private void FrmStockOrderCreateSel_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                dateEdit2.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddDays(5);
                dateAudit1.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-1);
                dateAudit2.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                GetPU_AppVouchCode();
                GetInvCode();
                GetItemCode();
                GetVenInfo();
                GetDepInfo();

                chkMergeSO.Checked = true;

                this.Text = "查询";

                ClsVenInvPrice clsPrice = new ClsVenInvPrice();
                dtPriceList = clsPrice.GetPrice(1);

                string sSQL = "select distinct cDepCode from _UserInfo where vchrUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    sUidDep = dt.Rows[0][0].ToString().Trim();
                    lookUp_Dep.EditValue = sUidDep;
                }
                lookUp_Dep.Enabled = true;
                lookUp_Dep.Properties.ReadOnly = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！  " + ee.Message);
            }
        }

        /// <summary>
        /// 供应商信息
        /// </summary>
        private void GetVenInfo()
        {
            string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where isnull(bVenCargo,0) =1 order by cVenCode";
            DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
            ItemLookUpEditVen.DataSource = dt;
        }

        /// <summary>
        /// 部门
        /// </summary>
        private void GetDepInfo()
        {
            try
            {
                string sSQL = "select distinct cDepCode as iID,cDepName as iText from @u8.Department order by cDepCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                lookUp_Dep.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得部门信息失败！" + ee.Message);
            }
        }

        /// <summary>
        /// 获得外销单号
        /// </summary>
        private void GetItemCode()
        {
            try
            {
                string sSQL = "select distinct ps.cItemCode as iID " +
                            "from @u8.PU_AppVouch p left join @u8.PU_AppVouchs ps on p.ID = ps.ID left join @u8. Inventory I on ps.cInvCode = i.cInvCode left join @u8.department d on d.cDepCode = p.cDepCode  " +
                            "where p.cVerifier is not null and p.cCloser is null and ps.cbcloser is null  " +
                            "order by ps.cItemCode";

                lookUpEditItemCode1 .Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditItemCode2.Properties.DataSource = lookUpEditItemCode1.Properties.DataSource;

            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货编码失败！  " + ee.Message);
            }

        }

        /// <summary>
        /// 获得存货编码
        /// </summary>
        private void GetInvCode()
        {
            try
            {
                string sSQL = "select cInvCode as iID,cInvName as iText " +
                            "from @u8.Inventory where isnull(bPurchase,0)=1 order by cInvCode ";

                lookUpEditInvCode1.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditInvCode2.Properties.DataSource = lookUpEditInvCode1.Properties.DataSource;

            }
            catch (Exception ee)
            {
                MessageBox.Show("获得存货编码失败！  " + ee.Message);
            }

        }

        private void GetPU_AppVouchCode()
        {
            try
            {
                string sSQL = @"
select distinct p.cCode as iID 
from @u8.PU_AppVouch p left join @u8.PU_AppVouchs ps on p.ID = ps.ID left join @u8. Inventory I on ps.cInvCode = i.cInvCode left join @u8.department d on d.cDepCode = p.cDepCode
where p.cVerifier is not null and p.cCloser is null and ps.cbcloser is null
    and p.cCode <> 'null'
order by p.cCode
";

                lookUpEditiCode1.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditiCode2.Properties.DataSource = lookUpEditiCode1.Properties.DataSource;

            }
            catch (Exception ee)
            {
                MessageBox.Show("获得请购单号失败！  " + ee.Message);
            }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        gridView3.SetRowCellValue(i, gridView3.Columns["bChoose"], "√");
                        gridView1.SetRowCellValue(i, gridView1.Columns["bChoose"], "√");
                    }
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView3.SetRowCellValue(i, gridView3.Columns["bChoose"], "");
                        gridView1.SetRowCellValue(i, gridView1.Columns["bChoose"], "");
                    }
                }
                SetGrid_1_2();
            }
            catch
            { }
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            try
            {
                gridControl1.DataSource = null;
                gridControl2.DataSource = null;
                gridControl3.DataSource = null;

                ClsVenInvPrice clsPrice = new ClsVenInvPrice();
                dtPriceList = clsPrice.GetPrice(1);

                string sSQL2 = "select  distinct ' ' as bChoose,p.cCode,p.dDate,p.cAuditDate " +
                                "from @u8.PU_AppVouch p left join @u8.PU_AppVouchs ps on p.ID = ps.ID left join @u8. Inventory I on ps.cInvCode = i.cInvCode left join @u8.department d on d.cDepCode = p.cDepCode  left join @u8.vendor  v on v.cVenCode = ps.cVenCode " +
                                "where p.dDate > '2000-1-1' and p.cVerifier is not null and p.cCloser is null and ps.cbcloser is null  ";

                if (lookUp_Dep.EditValue.ToString().Trim() != "")
                {
                    sSQL2 = sSQL2 + " and (v.cVenDepart = '" + lookUp_Dep.EditValue + "' or isnull(v.cVenDepart ,'') = '' or v.cVenDepart = '98') ";
                }

                if (!chkUnClosed.Checked)
                {
                    sSQL2 = sSQL2 + "  and isnull(ps.fQuantity,0)- isnull(ps.iReceivedQTY,0) > 0 and (isnull(ps.fNum,0)-isnull(ps.iReceivedNum,0) > 0 or ps.fNum is null  or (isnull(ps.fQuantity,0) <> 0 and isnull(ps.fNum,0) = 0)) ";
                }
                if (chkDate1.Checked)
                {
                    sSQL2 = sSQL2 + " and p.dDate >= '" + dateEdit1.DateTime + "' ";
                    sSQL2 = sSQL2 + " and p.dDate <= '" + dateEdit2.DateTime + "' ";
                }
                if (chkAudit.Checked)
                {
                    sSQL2 = sSQL2 + " and p.cAuditDate >= '" + dateAudit1.DateTime + "' ";
                    sSQL2 = sSQL2 + " and p.cAuditDate <= '" + dateAudit2.DateTime + "' "; 
                }

                if (lookUpEditItemCode1.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and  ps.cItemCode >= '" + lookUpEditItemCode1.Text.Trim() + "' ";
                }
                if (lookUpEditItemCode2.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and  ps.cItemCode <= '" + lookUpEditItemCode2.Text.Trim() + "' ";
                }
                if (lookUpEditiCode1.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and  p.cCode >= '" + lookUpEditiCode1.Text.Trim() + "' ";
                }
                if (lookUpEditiCode2.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and  p.cCode <= '" + lookUpEditiCode2.Text.Trim() + "' ";
                }
                if (lookUpEditInvCode1.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and  ps.cInvCode >= '" + lookUpEditInvCode1.Text.Trim() + "' ";
                }
                if (lookUpEditInvCode2.Text.Trim() != "")
                {
                    sSQL2 = sSQL2 + " and  ps.cInvCode <= '" + lookUpEditInvCode2.Text.Trim() + "' ";
                }

                sSQL2 = sSQL2 + "order by p.cCode ";
                DataTable dt2 = clsSQLCommond.ExecQuery(sSQL2);
                gridControl3.DataSource = dt2;

                chkAll.Checked = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("查询失败！  " + ee.Message);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridControl2.DataSource == null)
                {
                    MessageBox.Show("请先选择数据！");
                    return;
                }
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }
                try
                {
                    gridView3.FocusedRowHandle -= 1;
                    gridView3.FocusedRowHandle += 1;
                }
                catch { }

                DataView dv = ((DataTable)gridControl1.DataSource).Copy().DefaultView;
                dv.RowFilter = " bChoose = '√' ";
                dt1 = dv.ToTable().Copy();

                dv = ((DataTable)gridControl2.DataSource).Copy().DefaultView;
                dv.RowFilter = " bChoose = '√' ";
                dt2 = dv.ToTable().Copy();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
                MessageBox.Show("确定失败！  " + ee.Message);
            }
        }

        private void chkMergeSO_CheckedChanged(object sender, EventArgs e)
        {
            SetGrid2();
        }

        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridView2.GetRowCellValue(e.RowHandle, gridView1.Columns["bChoose"]).ToString().Trim();
                    if (s1 == "√")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }
                    if (s1 == "×")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetGrid2()
        {
            try
            {
                if (gridView1.RowCount == 0)
                {
                    return;
                }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns["iRow"], i);
                }

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                DataTable dtT = (DataTable)gridControl1.DataSource;

                DataView dv = dtT.Copy().DefaultView;
               
                dv.Sort = " cInvCode asc,cItemCode asc,dRequirDate asc,cVenCode ";

                DataTable dtView1 = dv.ToTable().Copy();
                DataTable dtView2 = dtView1.Copy();
                dtView2.Rows.Clear();

                int iDateLength = 0;
                if (chkDate.Checked)
                {
                    iDateLength = int.Parse(txtDate.Text.Trim());
                    if (iDateLength > 0)
                    {
                        for (int i = 0; i < dtView1.Rows.Count; i++)
                        {
                            string sUsed = dtView1.Rows[i]["bUsed2"].ToString().Trim();
                            if (sUsed != "1")
                            {
                                string sInvCode = dtView1.Rows[i]["cInvCode"].ToString().Trim();
                                string sVenCode = dtView1.Rows[i]["cVenCode"].ToString().Trim();
                                string sItemCode = dtView1.Rows[i]["cItemCode"].ToString().Trim();
                                string sItem_class = dtView1.Rows[i]["cItem_class"].ToString().Trim();
                                dtView1.Rows[i]["bUsed2"] = "1";
                                DateTime dReq = Convert.ToDateTime(dtView1.Rows[i]["dRequirDate"]);
                                for (int j = i + 1; j < dtView1.Rows.Count; j++)
                                {
                                    string sUsed2 = dtView1.Rows[j]["bUsed2"].ToString().Trim();
                                    if (sUsed2 != "1")
                                    {
                                        string sInvCode2 = dtView1.Rows[j]["cInvCode"].ToString().Trim();
                                        string sVenCode2 = dtView1.Rows[j]["cVenCode"].ToString().Trim();
                                        string sItemCode2 = dtView1.Rows[j]["cItemCode"].ToString().Trim();
                                        string sItem_class2 = dtView1.Rows[j]["cItem_class"].ToString().Trim();
                                        DateTime dReq2 = Convert.ToDateTime(dtView1.Rows[j]["dRequirDate"]);

                                        if (sInvCode == sInvCode2 && sVenCode2 == sVenCode && sItemCode2 == sItemCode && sItem_class2 == sItem_class)
                                        {

                                            if (dReq.AddDays((double)(iDateLength - 1)) >= dReq2)
                                            {
                                                dtView1.Rows[j]["dRequirDate"] = dReq;
                                                dtView1.Rows[i]["bUsed2"] = "1";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (!chkMergeSO.Checked)
                {
                    gridControl2.DataSource = dtView1;
                    return;
                }

                for (int i = 0; i < dtView1.Rows.Count; i++)
                {
                    dtView1.Rows[i]["iRow"] = i;
                    if (dtView1.Rows[i]["bChoose"].ToString().Trim() == "√")
                    {
                        if (dtView1.Rows[i]["bUsed"].ToString().Trim() == "1")
                        {
                            continue;
                        }
                        if (dtView1.Rows[i]["bUsed"].ToString().Trim() != "1")
                        {
                            dtView1.Rows[i]["bUsed"] = "1";
                            DataRow dr = dtView2.NewRow();
                            dr["bChoose"] = dtView1.Rows[i]["bChoose"];
                            dr["cVenCode"] = dtView1.Rows[i]["cVenCode"];
                            dr["cVenName"] = dtView1.Rows[i]["cVenName"];
                            dr["ID"] = dtView1.Rows[i]["ID"];
                            dr["AutoID"] = dtView1.Rows[i]["AutoID"].ToString().Trim();
                            dr["cCode"] = dtView1.Rows[i]["cCode"];
                            dr["dDate"] = dtView1.Rows[i]["dDate"];
                            dr["cDepCode"] = dtView1.Rows[i]["cDepCode"];
                            dr["cDepName"] = dtView1.Rows[i]["cDepName"];
                            dr["cInvCode"] = dtView1.Rows[i]["cInvCode"];
                            dr["cInvName"] = dtView1.Rows[i]["cInvName"];
                            dr["cInvStd"] = dtView1.Rows[i]["cInvStd"];
                            dr["fQuantity"] = dtView1.Rows[i]["fQuantity"];
                            dr["fNum"] = dtView1.Rows[i]["fNum"];
                            dr["iReceivedQTY"] = dtView1.Rows[i]["iReceivedQTY"];
                            dr["iReceivedNum"] = dtView1.Rows[i]["iReceivedNum"];
                            dr["iQty"] = dtView1.Rows[i]["iQty"];
                            dr["QtyNow"] = dtView1.Rows[i]["QtyNow"];
                            dr["iNum"] = dtView1.Rows[i]["iNum"];
                            dr["NumNow"] = dtView1.Rows[i]["iNum"];
                            dr["fTaxPrice"] = dtView1.Rows[i]["fTaxPrice"];
                            dr["fUnitPrice"] = dtView1.Rows[i]["fUnitPrice"];
                            dr["iPerTaxRate"] = dtView1.Rows[i]["iPerTaxRate"];
                            dr["fMoney"] = dtView1.Rows[i]["fMoney"];
                            dr["dRequirDate"] = dtView1.Rows[i]["dRequirDate"];
                            dr["cItem_class"] = dtView1.Rows[i]["cItem_class"];
                            dr["cItemCode"] = dtView1.Rows[i]["cItemCode"];
                            dr["CItemName"] = dtView1.Rows[i]["CItemName"];
                            dr["iTaxPrice"] = dtView1.Rows[i]["iTaxPrice"];
                            dr["bUsed"] = dtView1.Rows[i]["bUsed"];
                            dr["cDefine2"] = dtView1.Rows[i]["cDefine2"];
                            dr["cVenPPerson"] = dtView1.Rows[i]["cVenPPerson"];
                            dr["cVenPayCond"] = dtView1.Rows[i]["cVenPayCond"];
                            dr["cUnitID"] = dtView1.Rows[i]["cUnitID"];
                            dr["Remark"] = dtView1.Rows[i]["Remark"];
                            dr["SoDId"] = dtView1.Rows[i]["SoDId"];
                            dr["cComUnitName"] = dtView1.Rows[i]["cComUnitName"];
                            dr["cComUnitName2"] = dtView1.Rows[i]["cComUnitName2"];
                            dr["iRow"] = i;
                            dtView2.Rows.Add(dr);
                        }
                        for (int j = i + 1; j < dtView1.Rows.Count; j++)
                        {                         
                            if (dtView1.Rows[j]["bUsed"].ToString().Trim() == "1")
                            {
                                continue;
                            }


                            if (dtView1.Rows[i]["cInvCode"].ToString().Trim() != dtView1.Rows[j]["cInvCode"].ToString().Trim())
                            {
                                continue;
                            }

                            if (chkMergeSO.Checked)
                            {
                                if (dtView1.Rows[i]["cItem_class"].ToString().Trim() != dtView1.Rows[j]["cItem_class"].ToString().Trim() || dtView1.Rows[i]["cItemCode"].ToString().Trim() != dtView1.Rows[j]["cItemCode"].ToString().Trim())
                                {
                                    continue;
                                }
                                if (dtView1.Rows[i]["cVenCode"].ToString().Trim() != dtView1.Rows[j]["cVenCode"].ToString().Trim())
                                {
                                    continue;
                                }

                                if (chkDate.Checked)
                                {
                                    if (dtView1.Rows[i]["dRequirDate"].ToString().Trim() != dtView1.Rows[j]["dRequirDate"].ToString().Trim())
                                    {
                                        continue;
                                    }
                                }

                                dtView1.Rows[j]["bUsed"] = "1";


                                DateTime dTime1 = Convert.ToDateTime(dtView1.Rows[i]["dDate"]);
                                DateTime dTime2 = Convert.ToDateTime(dtView1.Rows[j]["dDate"]);
                                if (dTime1 > dTime2)
                                {
                                    dTime1 = dTime2;
                                }
                                dtView2.Rows[dtView2.Rows.Count - 1]["dDate"] = dTime1;

                                decimal d1 = Convert.ToDecimal(dtView2.Rows[dtView2.Rows.Count - 1]["fQuantity"]);
                                decimal d2 = Convert.ToDecimal(dtView1.Rows[j]["fQuantity"]);
                                dtView2.Rows[dtView2.Rows.Count - 1]["fQuantity"] = d1 + d2;
                           
                                if (dtView1.Rows[j]["fNum"] != null && dtView1.Rows[j]["fNum"].ToString().Trim() != string.Empty && dtView1.Rows[j]["fNum"].ToString().Trim() != "0")
                                {
                                    if (dtView2.Rows[dtView2.Rows.Count - 1]["fNum"] != null && dtView2.Rows[dtView2.Rows.Count - 1]["fNum"].ToString().Trim() != string.Empty)
                                    {
                                        d1 = Convert.ToDecimal(dtView2.Rows[dtView2.Rows.Count - 1]["fNum"]);
                                        d2 = Convert.ToDecimal(dtView1.Rows[j]["fNum"]);
                                        dtView2.Rows[dtView2.Rows.Count - 1]["fNum"] = d1 + d2;
                                    }
                                }

                                d1 = Convert.ToDecimal(dtView2.Rows[dtView2.Rows.Count - 1]["iReceivedQTY"]);
                                d2 = Convert.ToDecimal(dtView1.Rows[j]["iReceivedQTY"]);
                                dtView2.Rows[dtView2.Rows.Count - 1]["iReceivedQTY"] = d1 + d2;

                                if (dtView1.Rows[i]["iReceivedNum"] != null && dtView1.Rows[i]["iReceivedNum"].ToString().Trim() != string.Empty && dtView1.Rows[i]["iReceivedNum"].ToString().Trim() != "0")
                                {
                                    if (dtView1.Rows[j]["fNum"] != null && dtView1.Rows[j]["fNum"].ToString().Trim() != string.Empty)
                                    {
                                        d1 = Convert.ToDecimal(dtView2.Rows[dtView2.Rows.Count - 1]["iReceivedNum"]);
                                        d2 = Convert.ToDecimal(dtView1.Rows[j]["iReceivedNum"]);
                                        dtView2.Rows[dtView2.Rows.Count - 1]["iReceivedNum"] = d1 + d2;
                                    }
                                }

                                d1 = Convert.ToDecimal(dtView2.Rows[dtView2.Rows.Count - 1]["iQty"]);
                                d2 = Convert.ToDecimal(dtView1.Rows[j]["iQty"]);
                                dtView2.Rows[dtView2.Rows.Count - 1]["iQty"] = d1 + d2;


                                d1 = Convert.ToDecimal(dtView2.Rows[dtView2.Rows.Count - 1]["QtyNow"]);
                                if (dtView1.Rows[j]["QtyNow"].ToString().Trim() == "")
                                    d2 = 0;
                                else
                                    d2 = Convert.ToDecimal(dtView1.Rows[j]["QtyNow"]);
                                dtView2.Rows[dtView2.Rows.Count - 1]["QtyNow"] = d1 + d2;

                                if (dtView1.Rows[i]["iNum"] != null && dtView1.Rows[i]["iNum"].ToString().Trim() != string.Empty)
                                {
                                    if (dtView1.Rows[j]["fNum"] != null && dtView1.Rows[j]["fNum"].ToString().Trim() != string.Empty)
                                    {
                                        d1 = Convert.ToDecimal(dtView2.Rows[dtView2.Rows.Count - 1]["iNum"]);
                                        if (dtView1.Rows[j]["iNum"].ToString().Trim() == "")
                                            d2 = 0;
                                        else
                                            d2 = Convert.ToDecimal(dtView1.Rows[j]["iNum"]);
                                        dtView2.Rows[dtView2.Rows.Count - 1]["iNum"] = d1 + d2;
                                        dtView2.Rows[dtView2.Rows.Count - 1]["NumNow"] = d1 + d2;
                                    }
                                }

                                dTime1 = Convert.ToDateTime(dtView1.Rows[i]["dRequirDate"]);
                                dTime2 = Convert.ToDateTime(dtView1.Rows[j]["dRequirDate"]);
                                if (dTime1 > dTime2)
                                {
                                    dTime1 = dTime2;
                                }
                                dtView2.Rows[dtView2.Rows.Count - 1]["dRequirDate"] = dTime1;
                                dtView2.Rows[dtView2.Rows.Count - 1]["bUsed"] = "1";
                                dtView2.Rows[dtView2.Rows.Count - 1]["iRow"] = dtView2.Rows[dtView2.Rows.Count - 1]["iRow"].ToString().Trim() + "," + dtView1.Rows[j]["iRow"].ToString().Trim();
                                dtView2.Rows[dtView2.Rows.Count - 1]["cCode"] = dtView2.Rows[dtView2.Rows.Count - 1]["cCode"].ToString().Trim() + ";" + dtView1.Rows[j]["cCode"].ToString().Trim();
                                dtView2.Rows[dtView2.Rows.Count - 1]["AutoID"] = dtView2.Rows[dtView2.Rows.Count - 1]["AutoID"].ToString().Trim() + ";" + dtView1.Rows[j]["AutoID"].ToString().Trim();
                                dtView2.Rows[dtView2.Rows.Count - 1]["ID"] = dtView2.Rows[dtView2.Rows.Count - 1]["ID"].ToString().Trim() + ";" + dtView1.Rows[j]["ID"].ToString().Trim();

                            }
                        }
                    }
                }

                gridControl2.DataSource = dtView2;
            }
            catch (Exception ee)
            {
                MessageBox.Show("设置汇总信息失败！  " + ee.Message);
            }
        }

        private void SetGridView1()
        {
            try
            {
                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    //gridView1.SetRowCellValue(i, gridColbChoose, "");
                    gridView1.SetRowCellValue(i, gridColQtyNow, null);
                    gridView1.SetRowCellValue(i, gridColNumNow, null);
                    gridView1.SetRowCellValue(i, gridColfMoney, null);
                }

           
                string[] s;
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    string sInvCode = gridView2.GetRowCellValue(i, gridColcInvCode2).ToString().Trim();

                    double dQty = 0;
                    if (gridView2.GetRowCellValue(i, gridColQtyNow2).ToString().Trim() != "")
                        dQty = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColQtyNow2));
                    double dNum = 0;
                    bool bNum = false;
                    if (gridView2.GetRowCellValue(i, gridColNumNow2).ToString().Trim() != "")
                    {
                        dNum = Convert.ToDouble(gridView2.GetRowCellValue(i, gridColNumNow2));
                        if (dNum != 0)
                        {
                            bNum = true;
                        }
                    }
                    s = gridView2.GetRowCellValue(i, gridColAutoID2).ToString().Trim().Split(';');
                    for (int k = 0; k < s.Length; k++)
                    {
                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            if (s[k].Trim() == gridView1.GetRowCellValue(j, gridColAutoID2).ToString().Trim())
                            {
                                gridView1.SetRowCellValue(j, gridColiTaxPrice, gridView2.GetRowCellValue(i, gridColiTaxPrice2));
                                gridView1.SetRowCellValue(j, gridColiTaxRate, gridView2.GetRowCellValue(i, gridColiPerTaxRate2));
                            }
                        }
                    }

                    for (int k = 0; k < s.Length; k++)
                    {
                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            if (s[k].Trim() == gridView1.GetRowCellValue(j, gridColAutoID2).ToString().Trim())
                            {
                                if (dQty <= 0)
                                {
                                    break;
                                }

                                //gridView1.SetRowCellValue(j, gridColbChoose, "√");
                                gridView1.SetRowCellValue(j, gridColcVenCode, gridView2.GetRowCellValue(i, gridColcVenCode2));
                                gridView1.SetRowCellValue(j, gridColcVenName, gridView2.GetRowCellValue(i, gridColcVenName2).ToString().Trim());
                                gridView1.SetRowCellValue(j, gridColiTaxPrice, gridView2.GetRowCellValue(i, gridColiTaxPrice2));
                                gridView1.SetRowCellValue(j, gridColiTaxRate, gridView2.GetRowCellValue(i, gridColiPerTaxRate2));

                                if (k == s.Length - 1)
                                {
                                    gridView1.SetRowCellValue(j, gridColQtyNow, dQty);
                                    if (bNum)
                                    {
                                        gridView1.SetRowCellValue(j, gridColNumNow, dNum);
                                    }

                                    //gridView1.SetRowCellValue(j, gridColbChoose, "√");
                                    continue;
                                }

                                //gridView1.SetRowCellValue(j, gridColbChoose, "√");
                                double d1 = Convert.ToDouble(gridView1.GetRowCellValue(j, gridColiQty));
                                if (d1 >= dQty)
                                {
                                    gridView1.SetRowCellValue(j, gridColQtyNow, dQty);
                                    dQty = 0;
                                    if (bNum)
                                    {
                                        gridView1.SetRowCellValue(j, gridColNumNow, dNum);
                                        dNum = 0;
                                    }
                                    break;
                                }
                                gridView1.SetRowCellValue(j, gridColQtyNow, d1);

                                dQty = dQty - d1;
                                if (bNum)
                                {
                                    double d2 = Convert.ToDouble(gridView1.GetRowCellValue(j, gridColiNum));
                                    gridView1.SetRowCellValue(j, gridColNumNow, d2);
                                    dNum = dNum - d2;
                                }
                                if (dQty <= 0)
                                {
                                    gridView1.SetRowCellValue(j, gridColQtyNow, 0);
                                    if (bNum)
                                    {
                                        gridView1.SetRowCellValue(j, gridColNumNow, 0);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("设置请购单信息错误！  " + ee.Message);
            }
        }

        private void lookUpEditInvCode1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditInvCode2.EditValue = lookUpEditInvCode1.EditValue;
        }

        private void lookUpEditiCode1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditiCode2.EditValue = lookUpEditiCode1.EditValue;
        }

        private void lookUpEditItemCode1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditItemCode2.EditValue = lookUpEditItemCode1.EditValue;
        }

        /// <summary>
        /// 根据存货编码判断供应商 1. 供应商存货价格表，便宜者 2. 最后一次采购供应商
        /// </summary>
        /// <param name="sInvCode">存货编码</param>
        /// <param name="sVen">供应商编码</param>
        /// <returns></returns>
        private DataTable GetVendPriceInfo(string sInvCode,string sVen)
        {
            try
            {
                DataView dv = new DataView(dtPriceList);
                dv.RowFilter = " cInvCode = '" + sInvCode + "' and cVenCode = '" + sVen + "' ";
                DataTable dt = dv.ToTable();
                if (dt == null || dt.Rows.Count < 1)
                {
                    string sSQL = "select top 1 p.cVenCode,v.cVenName,pd.cInvCode,i.cInvName,i.cInvStd,i.cComUnitCode,pd.iUnitPrice,pd.iTaxPrice,pd.iPerTaxRate as itaxrate " +
                                    "from @u8.PO_Pomain p inner join @u8.PO_Podetails pd on p.poid = pd.poid inner join @u8.Vendor v on v.cVenCode = p.cVenCode inner join @u8.Inventory i on i.cInvCode = pd.cInvCode  " +
                                    "where pd.cInvCode = '" + sInvCode + "' and p.cVenCode = '" + sVen + "'  " +
                                    "order by id desc";
                    dt = clsSQLCommond.ExecQuery(sSQL);
                }
                return dt;
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商物料信息失败！\n  " + ee.Message);
            }
        }

        /// <summary>
        /// 根据存货编码判断供应商 1. 供应商存货价格表，便宜者 2. 最后一次采购供应商
        /// </summary>
        /// <param name="sInvCode">存货编码</param>
        /// <returns></returns>
        private DataTable GetVendPriceInfo(string sInvCode)
        {
            try
            {
                DataView dv = new DataView(dtPriceList);
                dv.RowFilter = " cInvCode = '" + sInvCode + "' ";
                DataTable dt = dv.ToTable();
                if (dt == null || dt.Rows.Count < 1)
                { 
                    string sSQL = "select top 1 p.cVenCode,v.cVenName,pd.cInvCode,i.cInvName,i.cInvStd,i.cComUnitCode,pd.iUnitPrice,pd.iTaxPrice,pd.iPerTaxRate as itaxrate " +
                                    "from @u8.PO_Pomain p inner join @u8.PO_Podetails pd on p.poid = pd.poid inner join @u8.Vendor v on v.cVenCode = p.cVenCode inner join @u8.Inventory i on i.cInvCode = pd.cInvCode  " +
                                    "where pd.cInvCode = '" + sInvCode + "' " +
                                    "order by id desc";
                    dt = clsSQLCommond.ExecQuery(sSQL);
                }
                return dt;
             
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商物料信息失败！\n  " + ee.Message);
            }
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView3.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView3.RowCount == 1)
                    iRow = 0;
                else
                    iRow = gridView3.FocusedRowHandle;

                if (gridView3.GetRowCellValue(iRow, gridColbChoose3).ToString().Trim() == "√")
                {
                    gridView3.SetRowCellValue(iRow, gridColbChoose3, "");
                }
                else
                {
                    gridView3.SetRowCellValue(iRow, gridColbChoose3, "√");
                }

                SetGrid_1_2();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void SetGrid1()
        {
            try
            {
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    string sCode = gridView3.GetRowCellValue(i, gridColcCode3).ToString().ToLower().Trim();
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        string sCode2 = gridView1.GetRowCellValue(j, gridColcCode).ToString().ToLower().Trim();

                        if (sCode == sCode2)
                        {
                            if (gridView3.GetRowCellValue(i, gridColbChoose3).ToString().Trim() == "√")
                            {
                                gridView1.SetRowCellValue(j, gridColbChoose, "√");
                            }
                            else
                            {
                                gridView1.SetRowCellValue(j, gridColbChoose, "");
                            }
                        }
                    }

                }

                SetGrid2();
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void gridView3_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    string s1 = gridView3.GetRowCellValue(e.RowHandle, gridView3.Columns["bChoose"]).ToString().Trim();
                    if (s1 == "√")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }
                    if (s1 == "×")
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            {

            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView2.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView2.RowCount == 1)
                    iRow = 0;
                else
                    iRow = gridView2.FocusedRowHandle;

                if (gridView2.GetRowCellValue(iRow, gridColbChoose2).ToString().Trim() == "√")
                {
                    gridView2.SetRowCellValue(iRow, gridColbChoose2, "");

                    string[] s = gridView2.GetRowCellValue(iRow, gridColAutoID2).ToString().Trim().Split(';');
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        for (int j = 0; j < s.Length; j++)
                        {
                            string sID = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                            if (s[j].Trim() == sID)
                            {
                                gridView1.SetRowCellValue(i, gridColbChoose, "");
                            }
                        }
                    }
                }
                else
                {
                    gridView2.SetRowCellValue(iRow, gridColbChoose2, "√");

                    string[] s = gridView2.GetRowCellValue(iRow, gridColAutoID2).ToString().Trim().Split(';');
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        for (int j = 0; j < s.Length; j++)
                        {
                            string sID = gridView1.GetRowCellValue(i, gridColAutoID).ToString().Trim();
                            if (s[j].Trim() == sID)
                            {
                                gridView1.SetRowCellValue(i, gridColbChoose, "√");
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        bool bItemButtonEditVen = false;      //ItemButtonEditVen 点击
        private void ItemButtonEditVen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                bItemButtonEditVen = true;
                int iRow = 0;
                if (gridView2.RowCount > 0)
                    iRow = gridView2.FocusedRowHandle;

                try
                {
                    gridView2.FocusedRowHandle -= 1;
                    gridView2.FocusedRowHandle += 1;
                }
                catch { }
                bItemButtonEditVen = false;

                string sVen = gridView2.GetRowCellValue(iRow, gridColcVenCode2).ToString().Trim();
                FrmVenInfo fVen = new FrmVenInfo(sVen);
                if (DialogResult.OK == fVen.ShowDialog())
                {
                    gridView2.SetRowCellValue(iRow, gridColcVenCode2, fVen.sVenCode);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商参照失败！  " + ee.Message);
            }
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                string sSQL = "";
                if (e.Column == gridColcVenCode2)
                {
                    if (!bItemButtonEditVen)
                    {
                        if (gridView2.GetRowCellDisplayText(e.RowHandle, gridColcVenCode2).ToString().Trim() == string.Empty)
                        {
                            gridView2.SetRowCellValue(e.RowHandle, gridColcVenName2, "");
                        }
                        else
                        {
                            sSQL = "select cVenName,v.cVenDepart,d.cDepName,v.cVenPPerson,v.cVenPayCond from @u8.vendor v LEFT JOIN @u8.Department d ON v.cVenDepart = d.cDepCode where v.cVenCode = '" + gridView2.GetRowCellDisplayText(e.RowHandle, gridColcVenCode2).ToString().Trim() + "' ";
                            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                gridView2.SetRowCellValue(e.RowHandle, gridColcVenName2, dt.Rows[0]["cVenName"]);
                                gridView2.SetRowCellValue(e.RowHandle, gridColcDepCode2, dt.Rows[0]["cVenDepart"]);
                                gridView2.SetRowCellValue(e.RowHandle, gridColcDepName2, dt.Rows[0]["cDepName"]);
                                gridView2.SetRowCellValue(e.RowHandle, gridColcVenPayCond2, dt.Rows[0]["cVenPayCond"]);
                                gridView2.SetRowCellValue(e.RowHandle, gridColcVenPPerson2, dt.Rows[0]["cVenPPerson"]);
                            }
                            else
                            {
                                gridView2.SetRowCellValue(e.RowHandle, gridColcVenCode2, "");
                                gridView2.SetRowCellValue(e.RowHandle, gridColcVenName2, "");
                                gridView2.SetRowCellValue(e.RowHandle, gridColcDepCode2, "");
                                gridView2.SetRowCellValue(e.RowHandle, gridColcDepName2, "");
                                gridView2.SetRowCellValue(e.RowHandle, gridColcVenPayCond2, "");
                                gridView2.SetRowCellValue(e.RowHandle, gridColcVenPPerson2, "");
                            }
                        }
                    }
                }
                if (e.Column == gridColQtyNow2 && radioQty.Checked)
                {
                    string s = gridView2.GetRowCellValue(e.RowHandle, gridColiNum2).ToString().Trim();
                    if (s != "")
                    {
                        double d = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiNum2));
                        double d1 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiQty2));
                        double d2 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColQtyNow2));
                        gridView2.SetRowCellValue(e.RowHandle, gridColNumNow2, d / d1 * d2);
                    }
                }
                if (e.Column == gridColNumNow2 && radioNum.Checked)
                {
                    double d = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiNum2));
                    double d1 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColiQty2));
                    double d2 = Convert.ToDouble(gridView2.GetRowCellValue(e.RowHandle, gridColNumNow2));
                    gridView2.SetRowCellValue(e.RowHandle, gridColQtyNow2, d1 / d * d2);
                }
                if (e.Column == gridColNumNow2 || e.Column == gridColQtyNow2 || e.Column == gridColcVenCode2 || e.Column == gridColiPerTaxRate2 || e.Column == gridColiTaxPrice2)
                {
                    SetGridView1();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                txtDate.Enabled = true;
            }
            else
            {
                txtDate.Enabled = false;
            }
            SetGrid2();
        }

        private void txtDate_EditValueChanged(object sender, EventArgs e)
        {
            SetGrid2();
        }

        private void chkDate1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate1.Checked)
            {
                dateEdit1.Enabled = true;
                dateEdit2.Enabled = true;
            }
            else
            {
                dateEdit1.Enabled = false;
                dateEdit2.Enabled = false;
            }
        }

        private void SetGrid_1_2()
        {
            int irow = 0;
            try
            {
                try
                {
                    gridView3.FocusedRowHandle -= 1;
                    gridView3.FocusedRowHandle += 1;
                }
                catch
                { }

                string sChoose = "";
                for (int i = 0; i < gridView3.RowCount; i++)
                {
                    if (gridView3.GetRowCellValue(i, gridColbChoose3).ToString().Trim() == "√")
                    {
                        if (sChoose == "")
                        {
                            sChoose ="'" + gridView3.GetRowCellValue(i, gridColcCode3).ToString().Trim() + "'";
                        }
                        else
                        {
                            sChoose = sChoose + ",'" + gridView3.GetRowCellValue(i, gridColcCode3).ToString().Trim() + "'";
                        }
                    }
                }

                if (sChoose == "")
                {
                    gridControl2.DataSource = null;
                    gridControl1.DataSource = null;
                }
                else
                {

                    string sSQL = "select ' ' as bUsed2,'√' as bChoose,' ' as bUsed,'' as cVenName, '' as iRow,'' as iTaxRate,'' as iTaxPrice,cast ('' as varchar(10)) as cVenCode, " +
                                            "cast(p.ID as varchar(10)) as [ID],cast(ps.AutoID as varchar(10)) as AutoID,p.cCode,p.dDate,'' as cDepCode,'' as cDepName,ps.cInvCode,i.cInvName,i.cInvStd,ps.fQuantity,ps.fNum,isnull(ps.iReceivedQTY,0) as iReceivedQTY,isnull(ps.iReceivedNum,0) as iReceivedNum,isnull(ps.fQuantity,0) - isnull(ps.iReceivedQTY,0) as iQty,isnull(ps.fNum,0)-isnull(ps.iReceivedNum,0) as iNum,isnull(ps.fQuantity,0)- isnull(ps.iReceivedQTY,0) as QtyNow,isnull(ps.fNum,0)-isnull(ps.iReceivedNum,0) as NumNow,ps.fTaxPrice,ps.fUnitPrice,ps.iPerTaxRate,cast(ps.fMoney as varchar(20)) as fMoney,ps.dRequirDate,ps.cItem_class,ps.cItemCode,ps.CItemName,'' as cVenPPerson,'' as cVenPayCond,p.cDefine2,ps.cUnitID,'' as Remark,SoDId,'' as cMemo,c.cComUnitName,c2.cComUnitName as cComUnitName2 " +
                                    "from @u8.PU_AppVouch p left join @u8.PU_AppVouchs ps on p.ID = ps.ID left join @u8. Inventory I on ps.cInvCode = i.cInvCode left join @u8.department d on d.cDepCode = p.cDepCode  left join @u8.ComputationUnit c on c.cComunitCode = i.cComUnitCode  left join @u8.ComputationUnit c2 on c2.cComunitCode = i.cAssComUnitCode left join @u8.vendor  v on v.cVenCode = ps.cVenCode " +
                                    "where p.cVerifier is not null and p.cCloser is null and ps.cbcloser is null and p.cCode in (" + sChoose + ")";

                    if (!chkUnClosed.Checked)
                    {
                        sSQL = sSQL + "  and isnull(ps.fQuantity,0)- isnull(ps.iReceivedQTY,0) > 0 and (isnull(ps.fNum,0)-isnull(ps.iReceivedNum,0) > 0 or cUnitID is null) ";
                    }
                    if (lookUp_Dep.EditValue.ToString().Trim() != "")
                    {
                        sSQL = sSQL + " and (v.cVenDepart = '" + lookUp_Dep.EditValue + "' or isnull(v.cVenDepart ,'') = '' or v.cVenDepart = '98') ";
                    }
                    if (chkDate1.Checked)
                    {
                        sSQL = sSQL + " and p.dDate >= '" + dateEdit1.DateTime + "' ";
                        sSQL = sSQL + " and p.dDate <= '" + dateEdit2.DateTime + "' ";
                    }
                    if (chkAudit.Checked)
                    {
                        sSQL = sSQL + " and p.cAuditDate >= '" + dateAudit1.DateTime + "' ";
                        sSQL = sSQL + " and p.cAuditDate <= '" + dateAudit2.DateTime + "' ";
                    }

                    if (lookUpEditItemCode1.Text.Trim() != "")
                    {
                        sSQL = sSQL + " and  ps.cItemCode >= '" + lookUpEditItemCode1.Text.Trim() + "' ";
                    }
                    if (lookUpEditItemCode2.Text.Trim() != "")
                    {
                        sSQL = sSQL + " and  ps.cItemCode <= '" + lookUpEditItemCode2.Text.Trim() + "' ";
                    }
                    if (lookUpEditiCode1.Text.Trim() != "")
                    {
                        sSQL = sSQL + " and  p.cCode >= '" + lookUpEditiCode1.Text.Trim() + "' ";
                    }
                    if (lookUpEditiCode2.Text.Trim() != "")
                    {
                        sSQL = sSQL + " and  p.cCode <= '" + lookUpEditiCode2.Text.Trim() + "' ";
                    }
                    if (lookUpEditInvCode1.Text.Trim() != "")
                    {
                        sSQL = sSQL + " and  ps.cInvCode >= '" + lookUpEditInvCode1.Text.Trim() + "' ";
                    }
                    if (lookUpEditInvCode2.Text.Trim() != "")
                    {
                        sSQL = sSQL + " and  ps.cInvCode <= '" + lookUpEditInvCode2.Text.Trim() + "' ";
                    }

                    if (chk_InvDefine1.Checked)
                    {
                        sSQL = sSQL + " and  ps.cInvCode in (select cInvCode from [_Inventory_Define] where isnull([iDefine1],0) = 1) ";
                    }

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("没有符合的数据！");
                        return;
                    }
                    string sInvErr = "";

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        irow = i;
                        string sInvCode = dt.Rows[i]["cInvCode"].ToString().Trim();
                        try
                        {
                            DataTable dtTemp = GetVendPriceInfo(dt.Rows[i]["cInvCode"].ToString().Trim());

                            dt.Rows[i]["cVenCode"] = dtTemp.Rows[0]["cVenCode"];
                            dt.Rows[i]["iTaxRate"] = dtTemp.Rows[0]["iTaxRate"];
                            dt.Rows[i]["iTaxPrice"] = dtTemp.Rows[0]["iTaxPrice"];
                            dt.Rows[i]["cVenName"] = dtTemp.Rows[0]["cVenName"];
                            decimal d = Convert.ToDecimal(dt.Rows[i]["iTaxPrice"]) * Convert.ToDecimal(dt.Rows[i]["QtyNow"]);
                            dt.Rows[i]["fMoney"] = d;

                            sSQL = "SELECT v.cVenDepart,d.cDepName,v.cVenPPerson,v.cVenPayCond FROM @u8.vendor v LEFT JOIN @u8.Department d ON v.cVenDepart = d.cDepCode " +
                                    "WHERE v.cVenCode = '" + dtTemp.Rows[0]["cVenCode"].ToString().Trim() + "' ";
                            DataTable dtDep = clsSQLCommond.ExecQuery(sSQL);
                            if (dtDep == null || dtDep.Rows.Count == 0)
                            {
                                dt.Rows[i]["cDepCode"] = DBNull.Value;
                                dt.Rows[i]["cDepName"] = DBNull.Value;
                                dt.Rows[i]["cVenPPerson"] = DBNull.Value;
                                dt.Rows[i]["cVenPayCond"] = DBNull.Value;
                            }
                            else
                            {
                                dt.Rows[i]["cDepCode"] = dtDep.Rows[0]["cVenDepart"];
                                dt.Rows[i]["cDepName"] = dtDep.Rows[0]["cDepName"];
                                dt.Rows[i]["cVenPPerson"] = dtDep.Rows[0]["cVenPPerson"];
                                dt.Rows[i]["cVenPayCond"] = dtDep.Rows[0]["cVenPayCond"];
                            }
                        }
                        catch
                        {
                            sInvErr = sInvErr + sInvCode + ";";
                        }
                    }

                    DataView dv = dt.DefaultView;

                    string sFilter = " 1=1 ";
                    if (lookUp_Dep.EditValue.ToString().Trim() != "")
                    {
                        sFilter = sFilter + " and (cDepCode = '" + lookUp_Dep.EditValue + "' or isnull(cDepCode ,'') = '' or cDepCode = '98') ";
                    }
                    dv.RowFilter = sFilter;
                    DataTable dtView1 = dv.ToTable().Copy();
                    gridControl1.DataSource = dtView1;

                    SetGrid2();
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("选择数据失败！  " + ee.Message);
            }
        }

        private void ItemButtonEditVenPrice_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.RowCount > 0)
                iRow = gridView2.FocusedRowHandle;

            string sInvCode = gridView2.GetRowCellValue(iRow, gridColcInvCode2).ToString().Trim();
            FrmInvPrice fPrice = new FrmInvPrice(sInvCode);
            fPrice.ShowDialog();

            if (fPrice.DialogResult == DialogResult.OK)
            {
                double dTaxPrice = fPrice.dTaxPrice;
                double dRate = fPrice.dTaxRate;
                //double dQty = Convert.ToDouble(gridView2.GetRowCellValue(iRow, gridColQtyNow2));
                gridView2.SetRowCellValue(iRow, gridColiTaxPrice, dTaxPrice);
                gridView2.SetRowCellValue(iRow, gridColiPerTaxRate2, fPrice.dTaxRate);
                //gridView2.SetRowCellValue(iRow, gridColfMoney2, dTaxPrice * dQty);
            }
        }

        private void chkAll2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll2.Checked)
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        gridView2.SetRowCellValue(i, gridView2.Columns["bChoose"], "√");
                    }

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridView1.Columns["bChoose"], "√");
                    }
                }
                if (!chkAll2.Checked)
                {
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        gridView2.SetRowCellValue(i, gridView2.Columns["bChoose"], "");
                    }
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridView1.Columns["bChoose"], "");
                    }
                }
            }
            catch
            { }
        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
                }
                else if (e.RowHandle < 0 && e.RowHandle > -1000)
                {
                    e.Info.Appearance.BackColor = System.Drawing.Color.AntiqueWhite;
                    e.Info.DisplayText = "G" + e.RowHandle.ToString();
                }
            }
        }

        private void chkAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAudit.Checked)
            {
                dateAudit1.Enabled = true;
                dateAudit2.Enabled = true;
            }
            else
            {
                dateAudit1.Enabled = false;
                dateAudit2.Enabled = false;
            }
        }

        private void dateAudit1_EditValueChanged(object sender, EventArgs e)
        {
            dateAudit2.EditValue = dateAudit1.EditValue;
        }
    }
}