using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace Warehouse
{
    public partial class FrmTransVouchAudit : FrameBaseFunction.Frm列表窗体模板
    {
        DataTable dtTable ;
        public FrmTransVouchAudit()
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
                        MessageBox.Show("该功能尚未提供，请向管理员咨询！");
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSel()
        {
            SetGrid();
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

        private void btnUnAudit()
        {
            if (radioUnAudit.Checked)
            {
                MessageBox.Show("请选择已审核列表");
            }

            string sSQL = "";
            string sErr = "";
            ArrayList aList = new ArrayList();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "")
                {
                    continue;
                }
                sSQL = "select * from @u8.GL_mend where iperiod = month('" + Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColdTVDate)) + "')";
                DataTable dtTemp1 = clsSQLCommond.ExecQuery(sSQL);

                if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_ST"]) == true)
                {
                    sErr = sErr + "行" + (i + 1) + "单据所在月已结帐\n";
                    continue;
                }

                if (i != 0 && gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() == gridView1.GetRowCellValue(i - 1, gridColcTVCode).ToString().Trim())
                {
                    continue;
                }

                sSQL = "select distinct [ID],cCode,cBusType,cSource,bRdFlag,cHandler,cAccounter from @u8.rdrecord r where cSource = '调拨' and cBusCode = '" + gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() + "'";
                dtTemp1 = clsSQLCommond.ExecQuery(sSQL);

                if (dtTemp1 != null && dtTemp1.Rows.Count > 0)
                {
                    string sErrTemp1 = "";
                    for (int j = 0; j < dtTemp1.Rows.Count; j++)
                    {
                        if (dtTemp1.Rows[j]["cHandler"].ToString().Trim() != "")
                        {
                            sErrTemp1 = sErrTemp1 + "行" + (i + 1) + "单据关联的" + dtTemp1.Rows[j]["cBusType"].ToString().Trim() + dtTemp1.Rows[j]["cCode"].ToString().Trim() + "已审核";
                        }
                        if (dtTemp1.Rows[j]["cAccounter"].ToString().Trim() != "")
                        {
                            sErrTemp1 = sErrTemp1 + "行" + (i + 1) + "单据关联的" + dtTemp1.Rows[j]["cBusType"].ToString().Trim() + dtTemp1.Rows[j]["cCode"].ToString().Trim() + "已结帐";
                        }
                    }

                    if (sErrTemp1 != "")
                    {
                        sErr = sErr + sErrTemp1 + "\n";
                        continue;
                    }
                }
                if (dtTemp1 != null && dtTemp1.Rows.Count > 0)
                {
                    for (int j = 0; j < dtTemp1.Rows.Count; j++)
                    {
                        sSQL = "select r.cWhCode,rs.* from @u8.RdRecord r inner join @u8.RdRecords rs on r.id = rs.id where r.[ID] = " + dtTemp1.Rows[j]["ID"].ToString().Trim();
                        DataTable dtRdRecords = clsSQLCommond.ExecQuery(sSQL);
                        if (dtRdRecords != null && dtRdRecords.Rows.Count > 0)
                        {
                            for (int k = 0; k < dtRdRecords.Rows.Count; k++)
                            {
                                if (dtRdRecords.Rows[k]["iNum"] == null || dtRdRecords.Rows[k]["iNum"].ToString().Trim() == "")
                                {
                                    sSQL = clsGetSQL.SetCurrQty(dtRdRecords.Rows[k]["cInvCode"].ToString().Trim(), dtRdRecords.Rows[k]["cWhCode"].ToString().Trim(), Convert.ToDouble(dtRdRecords.Rows[k]["iQuantity"]) * (-1));
                                }
                                else
                                {
                                    sSQL = clsGetSQL.SetCurrQty(dtRdRecords.Rows[k]["cInvCode"].ToString().Trim(), dtRdRecords.Rows[k]["cWhCode"].ToString().Trim(), Convert.ToDouble(dtRdRecords.Rows[k]["iQuantity"]) * (-1), Convert.ToDouble(dtRdRecords.Rows[k]["iNum"]) * (-1));
                                }
                                aList.Add(sSQL);
                            }
                        }

                        sSQL = "delete @u8.RdRecords where [ID] = " + dtTemp1.Rows[j]["ID"].ToString().Trim();
                        aList.Add(sSQL);

                        sSQL = "delete @u8.RdRecord where [ID] = " + dtTemp1.Rows[j]["ID"].ToString().Trim();
                        aList.Add(sSQL);
                    }
                }
                sSQL = "update @u8.TransVouch set cVerifyPerson = null ,dVerifyDate = null ,dnverifytime = null where cTVCode = '" + gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() + "'";
                aList.Add(sSQL);
            }
            if (sErr.Trim() != string.Empty)
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "错误";
                fMsgBos.richTextBox1.Text = "存在以下错误，请修正后继续：\n" + sErr;
                fMsgBos.ShowDialog();
                return;
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！");
                SetGrid();
            }
        }

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型  PuArrival，</param>
        public void GetID(string sType, out long iID, out long iIDDetail)
        {
            string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity with (nolock) where cAcc_Id = '200' and cVouchType = '" + sType + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0]["iFatherID"]);
                iIDDetail = Convert.ToInt64(dt.Rows[0]["iChildID"]);
            }
        }

        private void btnAudit()
        {
            if (radioAudit.Checked)
            {
                MessageBox.Show("请选择未审核列表");
            }

            string sSQL = "";
            string sErr = "";
            ArrayList aList = new ArrayList();

            long iID = 0;
            long iIDDetail = 0;
            GetID("rd", out iID, out iIDDetail);
            sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0301' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            DataTable dtCodeBack = clsSQLCommond.ExecQuery(sSQL);
            long iInCode = Convert.ToInt64(dtCodeBack.Rows[0]["Maxnumber"]);

            sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0302' and (cContent='日期' or cContent='单据日期') and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
            dtCodeBack = clsSQLCommond.ExecQuery(sSQL);
            long iOutCode = Convert.ToInt64(dtCodeBack.Rows[0]["Maxnumber"]);
     
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "")
                {
                    continue;
                }
                sSQL = "select * from @u8.GL_mend where iperiod = month('" + Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColdTVDate)) + "')";
                DataTable dtTemp1 = clsSQLCommond.ExecQuery(sSQL);

                if (Convert.ToBoolean(dtTemp1.Rows[0]["bflag_ST"]) == true)
                {
                    sErr = sErr + "行" + (i + 1) + "单据所在月已结帐\n";
                    continue;
                }

                if (i != 0 && gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() == gridView1.GetRowCellValue(i-1, gridColcTVCode).ToString().Trim())
                {
                    continue;
                }

                sSQL = "update @u8.TransVouch set cVerifyPerson = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,dVerifyDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' ,dnverifytime = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where cTVCode = '" + gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() + "'";
                aList.Add(sSQL);

                DataTable dtHead = clsSQLCommond.ExecQuery("select * from @u8.TransVouch where cTVCode = '" + gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() + "'");
                DataTable dtDetail = clsSQLCommond.ExecQuery("select * from @u8.TransVouchs where cTVCode = '" + gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() + "'");
                try
                {
                    long iID2 = 0; long iIDDetail2 = 0; long iInCode2 = 0; long iOutCode2 = 0;
                    ClsU8Function clsU8 = new ClsU8Function();
                    ArrayList aRDList = clsU8.GenInvChangeRD(dtHead, dtDetail, iID, iIDDetail, out iID2, out iIDDetail2, iInCode,out iInCode2, iOutCode,out iOutCode2);
                    iID = iID2; iIDDetail = iIDDetail2; iInCode = iInCode2; iOutCode = iOutCode2;

                    for (int j = 0; j < aRDList.Count; j++)
                    {
                        aList.Add(aRDList[j].ToString().Trim());
                    }
                }
                catch (Exception ee)
                {
                    sErr = sErr + "行" + (i + 1) + ee.Message + "\n";
                    continue;
                }
                
            }
            if (sErr.Trim() != string.Empty)
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "错误";
                fMsgBos.richTextBox1.Text = "存在以下错误，请修正后继续：\n" + sErr;
                fMsgBos.ShowDialog();
                return;
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！");
                SetGrid();
            }
        }

        private void FrmTransVouchAudit_Load(object sender, EventArgs e)
        {
            GetLookUpInfo();
            dateEdit1.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            dateEdit1.Enabled = true; dateEdit1.Properties.ReadOnly = false;

            SetGrid();
        }

        private void SetGrid()
        {
            string sSQL = "select cast(null as varchar(2) ) as bChoose,* " +
                            "from @u8.TransVouch t inner join @u8.TransVouchs ts on t.cTVCode = ts.cTVCode inner join @u8.Inventory I on I.cInvCode = ts.cInvCode " +
                            "where year(dTVDate) = '" + dateEdit1.DateTime.Year + "' and month(dTVDate) = '" + dateEdit1.DateTime.Month + "' ";

            if (radioAudit.Checked)
            {
                sSQL = sSQL + " and isnull(cVerifyPerson,'') <> '' ";
            }
            if (radioUnAudit.Checked)
            {
                sSQL = sSQL + " and isnull(cVerifyPerson,'') = '' ";
            }
            sSQL = sSQL + "order by t.cTVCode,ts.cInvCode";

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            chkAll.Checked = false;
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if ((this.gridView1.GetDataRow(e.RowHandle1)["cTVCode"].ToString() != this.gridView1.GetDataRow(e.RowHandle2)["cTVCode"].ToString()))
                e.Handled = true;
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

                string sID = gridView1.GetRowCellValue(iRow, gridColcTVCode).ToString().Trim();
                if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "")
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() == sID)
                        {
                            gridView1.SetRowCellValue(i, gridColbChoose, "√");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColcTVCode).ToString().Trim() == sID)
                        {
                            gridView1.SetRowCellValue(i, gridColbChoose, "");
                        }
                    }
                }
            }
            catch (Exception ee)
            { }
        }

        private void GetLookUpInfo()
        {
            string sSQL = "select cDepCode as iID,cDepName as iText from @u8.Department  order by cDepCode";
            ItemLookUpEditDep.DataSource = clsGetSQL.GetLookUpEdit(sSQL);

            sSQL = "select cWhCode as iID,cWhName as iText from @u8.Warehouse   order by cWhCode";
            ItemLookUpEditWH.DataSource = clsGetSQL.GetLookUpEdit(sSQL);

            sSQL = "select cRdCode as iID,cRdName as iText  from @u8.Rd_Style   order by cRdCode";
            ItemLookUpEditRd_Style.DataSource = clsGetSQL.GetLookUpEdit(sSQL);

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

        private void radioAudit_CheckedChanged(object sender, EventArgs e)
        {
            SetGrid();
        }

        private void radioUnAudit_CheckedChanged(object sender, EventArgs e)
        {
            SetGrid();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridColbChoose, "√");
                    }
                }
                if (!chkAll.Checked)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridView1.Columns["bChoose"], "");
                    }
                }
            }
            catch
            { }
        }
    }
}