using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;
using System.Data.SqlClient;

namespace OM
{
    public partial class FrmRDInChkOM_Red : FrameBaseFunction.Frm列表窗体模板
    {
        bool bCheck = false;

        public FrmRDInChkOM_Red()
        {
            InitializeComponent();
        }

        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "undo":
                        btnDel();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "export":
                        btnExport();
                        break;
                  
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDel()
        {
            bCheck = false;

            ArrayList aList = new ArrayList();
            string sSQL = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                    continue;

                sSQL = @"select * from UFDLImport..Records_Import where RDID = " + gridView1.GetRowCellValue(i, gridColRdsID).ToString().Trim();
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 加载数据失败\n";
                    continue;
                }
                if (dt.Rows[0]["Auditer_Red"].ToString().Trim() != "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 已经审核\n";
                    continue;
                }

                sSQL = @"update UFDLImport..Records_Import set Saver_Red = null,dtmSave_Red = null, where RDID = " + gridView1.GetRowCellValue(i, gridColRdsID).ToString().Trim();
                aList.Add(sSQL);
            }

            if (sErr.Trim() != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "撤销确认";
                fMsgBos.richTextBox1.Text = sErr;
                fMsgBos.ShowDialog();
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("撤销确认" + aList.Count + "条数据成功！");
                GetGrid();
            }
        }

        private void btnPrint()
        {
            try
            {
                RepRDInChk rep = new RepRDInChk();

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                decimal d1 = 0;
                decimal d2 = 0;

                DataTable dt = (DataTable)gridControl1.DataSource;
                int iRow = 0;
                if (dt.Rows.Count > 0)
                {
                    DataTable dtDetail = rep.dataSet1.Tables["dtDetail"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["bChoose"].ToString().Trim() == "√")
                        {
                            iRow += 1;
                            DataRow dr = dtDetail.NewRow();
                            dr["Column1"] = dt.Rows[i]["cPOID"];
                            dr["Column2"] = dt.Rows[i]["cCode"];
                            dr["Column3"] = Convert.ToDateTime(dt.Rows[i]["dDate"]).ToString("yyyy-MM-dd");
                            dr["Column4"] = dt.Rows[i]["cInvCode"];
                            dr["Column5"] = dt.Rows[i]["cInvName"];
                            dr["Column6"] = dt.Rows[i]["cInvStd"];
                            dr["Column7"] = dt.Rows[i]["iPrice"];

                            if (dt.Rows[i]["Qty"].ToString().Trim() != "")
                            {
                                dr["Column8"] = decimal.Round( Convert.ToDecimal(dt.Rows[i]["Qty"]),6);
                                d1 = d1 + decimal.Round(Convert.ToDecimal(dt.Rows[i]["Qty"]), 6);
                            }
                            if (dt.Rows[i]["iArrSum"].ToString().Trim() != "")
                            {
                                dr["Column9"] = decimal.Round( Convert.ToDecimal(dt.Rows[i]["iArrSum"]),6);
                                d2 = d2 + decimal.Round(Convert.ToDecimal(dt.Rows[i]["iArrSum"]), 6);
                            }

                            dtDetail.Rows.Add(dr);
                        }
                    }

                    if (dtDetail.Rows.Count < 1)
                    {
                        MessageBox.Show("请选择需要打印的数据！");
                        return;
                    }

                    DataTable dtHead = rep.dataSet1.Tables["dtHead"];
                    DataRow dRowTe = dtHead.NewRow();
                    dRowTe["Column1"] = "对账日期： " + dateEdit1.DateTime.ToString("yyyy-MM-dd") + " ---- " + dateEdit2.DateTime.ToString("yyyy-MM-dd");
                    dRowTe["Column2"] = "厂商：" + txtVenName.Text.Trim();
                    dRowTe["Column3"] = "联系人：";
                    dRowTe["Column4"] = "电话：";
                    dRowTe["Column5"] = "审核：";
                    dRowTe["Column6"] = d1;
                    dRowTe["Column7"] = d2;
                    dtHead.Rows.Add(dRowTe);

                    rep.ShowPreview();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载打印失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport()
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    gridView1.ExportToXls(sF.FileName);
                    MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnSel()
        {
            try
            {
                GetGrid();

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表失败！  " + ee.Message);
            }
        }

        private void btnUnAudit()
        {
            bCheck = false;

            ArrayList aList = new ArrayList();
            string sSQL = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                    continue;

                sSQL = @"select * from UFDLImport..Records_Import where RDID = " + gridView1.GetRowCellValue(i, gridColRdsID).ToString().Trim();
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 加载数据失败\n";
                    continue;
                }
                if (dt.Rows[0]["Saver_Red"].ToString().Trim() == "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 尚未确认\n";
                    continue;
                }
                if (dt.Rows[0]["Auditer_Red"].ToString().Trim() == "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 尚未审核\n";
                    continue;
                }

                sSQL = @"update UFDLImport..Records_Import set Auditer_Red = null,dtmSave_Red = null, where RDID = " + gridView1.GetRowCellValue(i, gridColRdsID).ToString().Trim();
                aList.Add(sSQL);
            }

            if (sErr.Trim() != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "弃审";
                fMsgBos.richTextBox1.Text = sErr;
                fMsgBos.ShowDialog();
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审" + aList.Count + "条数据成功！");
                GetGrid();
            }
        }

        private void btnAudit()
        {
            bCheck = false;

            ArrayList aList = new ArrayList();
            string sSQL = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                    continue;

                sSQL = @"select * from UFDLImport..Records_Import where RDID = " + gridView1.GetRowCellValue(i, gridColRdsID).ToString().Trim();
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 加载数据失败\n";
                    continue;
                }
                if (dt.Rows[0]["Saver_Red"].ToString().Trim() == "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 尚未确认\n";
                    continue;
                }

                sSQL = @"update UFDLImport..Records_Import set Auditer_Red = '" + sUid + "',dtmSave_Red = getdate(), where RDID = " + gridView1.GetRowCellValue(i, gridColRdsID).ToString().Trim();
                aList.Add(sSQL);
            }

            if (sErr.Trim() != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "审核";
                fMsgBos.richTextBox1.Text = sErr;
                fMsgBos.ShowDialog();
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核" + aList.Count + "条数据成功！");
                GetGrid();
            }
        }

        private void btnSave()
        {
            bCheck = false;

            ArrayList aList = new ArrayList();
            string sSQL = "";

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            string sErr = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() != "√")
                    continue;

                sSQL = @"select * from UFDLImport..Records_Import where RDID = " + gridView1.GetRowCellValue(i,gridColRdsID).ToString().Trim();
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 加载数据失败\n";
                    continue;
                }
                if (dt.Rows[0]["Auditer_Red"].ToString().Trim() != "")
                {
                    sErr = sErr + "行 " + (i + 1).ToString() + " 已经审核\n";
                    continue; 
                }

                sSQL = @"update UFDLImport..Records_Import set Saver_Red = '" + sUid + "',dtmSave_Red = getdate(), where RDID = " + gridView1.GetRowCellValue(i, gridColRdsID).ToString().Trim();
                aList.Add(sSQL);
            }

            if (sErr.Trim() != "")
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "确认";
                fMsgBos.richTextBox1.Text = sErr;
                fMsgBos.ShowDialog();
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("确认" + aList.Count + "条数据成功！");
                GetGrid();
            }
        }

        private void FrmRDInChkOM_Load(object sender, EventArgs e)
        {
            try
            {
                chkDate.Checked = false;
                base.SetConEnable(true);

                dateEdit1.DateTime = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-1);
                dateEdit2.DateTime = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                string sSQL = "select cCode as iID,cCode as iText from @u8.OM_MOMain where 1=1 order by cCode";
                lookUpEditOrder1.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditOrder2.Properties.DataSource = lookUpEditOrder1.Properties.DataSource;

                sSQL = "select distinct cCode as iID,cCode as iText from @u8.rdrecord01 where cBusType = '委外加工' AND csource = '委外订单' order by cCode";
                lookUpEditRDIn1.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditRDIn2.Properties.DataSource = lookUpEditRDIn1.Properties.DataSource;

                bCheck = false;

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                }

                string sVend = GetUidVend();
                if (sVend == "all")
                {
                    txtVenCode.Enabled = true;
                }
                else
                {
                    txtVenCode.Text = sVend;
                    txtVenCode.Enabled = false;
                    txtVenCode_Leave(null, null);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！\n\t原因：" + ee.Message);
            }
        }

        /// <summary>
        /// 获得当前帐号对应供应商
        /// </summary>
        /// <returns></returns>
        private string GetUidVend()
        {
            try
            {
                string s = "all";

                if (FrameBaseFunction.ClsBaseDataInfo.sUid.ToLower() == "admin")
                {
                    return s;
                }

                string sSQL = "select * from UFDLImport.._vendUid where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' and accid =200 and accyear=" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    s = dt.Rows[0]["vendCode"].ToString().Trim();
                }

                if (s == string.Empty)
                {
                    s = "all";
                }

                return s;
            }
            catch (Exception ee)
            {
                throw new Exception("获得帐号供应商信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void GetGrid()
        {
            if (txtVenCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择供应商！");
                return;
            }

            bCheck = false;

            string sSQL = @"
select '' as bChoose,i.iInvWeight,rs.cbarvcode,CONVERT(varchar(100), r.dDate, 111)  as dDate,autoid,rs.iPOsID,rs.cPOID,r.cCode
    ,rs.cInvCode,i.cInvName,i.cInvStd
	,cast(rs.iProcessCost as DECIMAL(16,6)) as price		--	加工费单价
	,cast(rs.iQuantity as DECIMAL(16,6)) as iQuantity
    ,cast(rs.iProcessFee as DECIMAL(16,6)) as iSum			--	加工费
    ,cUnit.cComUnitName
from @u8.rdrecord01 r left join @u8.rdrecords01 rs on r.id = rs.id 
    inner join @u8.Inventory i on i.cinvcode = rs.cInvCode 
    inner join @u8.ComputationUnit cUnit on cUnit.cComunitCode = i.cComunitCode 
    inner join @u8.OM_MODetails os on os.MODetailsID = rs.iOMoDID left join @u8.OM_MOMain o on o.moid = os.moid	
    inner join UFDLImport..Records_Import rI on rI.RDId = rs.autoid and rI.accid =200 and rI.accyear = aaaaaa
where r.cVenCode = 'bbbbbb' and r.cbustype = '委外加工' and r.cMemo like '%原材料不良%'
";

            sSQL = sSQL.Replace("aaaaaa", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
            sSQL = sSQL.Replace("bbbbbb", txtVenCode.Text.ToString().Trim());

         
            if (lookUpEditOrder1.Text.Trim() != "")
            {
                sSQL = sSQL + " and o.cCode >= '" + lookUpEditOrder1.Text.Trim() + "' ";
            }
            if (lookUpEditOrder2.Text.Trim() != "")
            {
                sSQL = sSQL + " and o.cCode <= '" + lookUpEditOrder2.Text.Trim() + "' ";
            }

            if (lookUpEditRDIn1.Text.Trim() != "")
            {
                sSQL = sSQL + " and r.cCode >= '" + lookUpEditRDIn1.Text.Trim() + "' ";
            }
            if (lookUpEditRDIn2.Text.Trim() != "")
            {
                sSQL = sSQL + " and r.cCode <= '" + lookUpEditRDIn2.Text.Trim() + "' ";
            }


            if (radioUnSure.Checked)
            {
                sSQL = sSQL + " and isnull(rI.Saver_Red,'') = '' and isnull(rI.Auditer_Red,'') = ''  ";
            }
            if (radioEnSure.Checked)
            {
                sSQL = sSQL + " and isnull(rI.Saver_Red,'') <> '' and isnull(rI.Auditer_Red,'') = '' ";
            }
            if (radioAudit.Checked)
            {
                sSQL = sSQL + " and isnull(rI.Saver_Red,'') <> '' and isnull(rI.Auditer_Red,'') <> '' ";
            }

            if (chkDate.Checked)
            {
                sSQL = sSQL + " and r.dDate >='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "' and r.dDate<= '" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "' ";
            }

            sSQL = sSQL + " order by rs.cbarvcode,r.cCode,rs.autoid";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            
            gridControl1.DataSource = dt;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                    return;
                int iRow = 1;
                if (gridView1.RowCount == 1)
                    iRow = 0;
                else
                    iRow = gridView1.FocusedRowHandle;

                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
                {
                    gridView1.SetFocusedRowCellValue(gridColbChoose, "√");
                }
                else
                {
                    gridView1.SetFocusedRowCellValue(gridColbChoose, "");
                    return;
                }
            }
            catch
            { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                        gridView1.SetRowCellValue(i, gridColbChoose, "√");
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                        gridView1.SetRowCellValue(i, gridColbChoose, "");
                }

            }
            catch
            { }
        }

        private void lookUpEditOrder1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditOrder2.EditValue = lookUpEditOrder1.EditValue;
        }

        private void lookUpEditRDIn1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditRDIn2.EditValue = lookUpEditRDIn1.EditValue;
        }

        private void txtVenCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCode.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCode.Text = fVen.sVenCode;
                txtVenName.Text = fVen.sVenName;
            }
        }

        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
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

        private void radioUnSure_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioUnSure.Checked)
                {
                    GetGrid();

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "undo")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void radioEnSure_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioEnSure.Checked)
                {
                    GetGrid();

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "undo")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void radioAudit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioAudit.Checked)
                {
                    GetGrid();

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "save")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "audit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = true;
                        }
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "undo")
                        {
                            base.toolStripMenuBtn.Items[i].Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得列表信息失败！\n\t原因：" + ee.Message);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    GetGrid();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！   " + ee.Message);
            }
        }


    }
}