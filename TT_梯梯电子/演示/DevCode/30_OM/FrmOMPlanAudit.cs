using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace OM
{
    public partial class FrmOMPlanAudit : FrameBaseFunction.Frm列表窗体模板
    {
        DataTable dtPriceList;

        bool b1 = false;//供应商
        bool b2 = false;//导入人员
        bool b3 = false;//维护审核人员

        public FrmOMPlanAudit()
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
                        btnGet();
                        break;
                    case "undo":
                        btnDelRow();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClosed();
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

        private void btnExport()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                SaveFileDialog sa = new SaveFileDialog();
                sa.Filter = "Excel文件2003|*.xls";
                sa.FileName = "委外计划列表";

                sa.ShowDialog();
                string sPath = sa.FileName;

                if (sPath.Trim() != string.Empty)
                {
                    gridView1.ExportToXls(sPath);
                    MessageBox.Show("导出列表成功！\n路径：" + sPath);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出列表失败：" + ee.Message);
            }

        }

        private void btnUnAudit()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "";
                ArrayList aList = new ArrayList();
                string sMsg = "  ";
                string sMsgErr = "  ";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "" && gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "0")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已使用;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bAudit"]).ToString().ToLower().Trim() == "false") 
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 未审核;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已关闭;  ";
                            continue;
                        }
                        sSQL = "update UFDLImport..OMPlan set bAudit=0, AuditUID=null,AuditDate=null " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        aList.Add(sSQL);
                        sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";
                    }
                }

                if (sMsgErr.Trim() != "")
                {
                    if (base.MsgBox("错误信息", sMsgErr) != DialogResult.OK)
                    {
                        return;
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("弃审成功" + aList.Count + "条数据！");
                    GetGrid();
                }
                else
                {
                    MessageBox.Show("请选择需要弃审的数据！");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("保存失败！\n  " + ee.Message);
            }
        }

        private void btnAudit()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }
                DataTable dtMailToVen = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "供应商";
                dtMailToVen.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "供应商编码";
                dtMailToVen.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "物料编码";
                dtMailToVen.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "物料名称";
                dtMailToVen.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "bUsed";
                dtMailToVen.Columns.Add(dc);
                DataRow dr;

                string sSQL = "";
                ArrayList aList = new ArrayList();
                string sMsg = "  ";
                string sMsgErr = "  ";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "" && gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "0")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已使用;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridColbSave).ToString().ToLower().Trim() == "false")//&& 
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 未保存;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bAudit"]).ToString().ToLower().Trim() == "true")//&& 
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已审核;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已关闭;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bBeSure"]).ToString().ToLower().Trim() == "false" && gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() != "")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 供应商未确认;  ";
                            continue;
                        }
                        
                        sSQL = "update UFDLImport..OMPlan set bAudit=1,AuditUID='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',AuditDate='" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        aList.Add(sSQL);
                        sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";

                        if (gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() != "")
                        {
                            dr = dtMailToVen.NewRow();
                            dr["供应商编码"] = gridView1.GetRowCellValue(i, gridColcVenCode);
                            dr["供应商"] = gridView1.GetRowCellValue(i, gridColcVenName);
                            dr["物料编码"] = gridView1.GetRowCellValue(i, gridColInvCode);
                            dr["物料名称"] = gridView1.GetRowCellValue(i, gridColInvName);
                            dr["bUsed"] = 0;
                            dtMailToVen.Rows.Add(dr);
                        }
                    }
                }

                if (sMsgErr.Trim() != "")
                {
                    if (base.MsgBox("错误信息", sMsgErr) != DialogResult.OK)
                    {
                        return;
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("审核成功" + aList.Count + "条数据！");

                    try
                    {
                        if (dtMailToVen != null && dtMailToVen.Rows.Count > 0)
                        {
                            SendMail(dtMailToVen);
                        }
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("邮件发送失败，请另行通知！  " + ee.Message);
                    }

                    GetGrid();
                }
                else
                {
                    MessageBox.Show("请选择需要审核的数据！");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("保存失败！\n  " + ee.Message);
            }
        }


        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="sMailToVen">发给供应商</param>
        private void SendMail(DataTable dtCodeMailToVen)
        {
            string sSQL = "";

            ArrayList aList = new ArrayList();

            if (dtCodeMailToVen != null && dtCodeMailToVen.Rows.Count > 0)
            {
                FrmMailListSend frmMail = new FrmMailListSend();
                for (int i = 0; i < dtCodeMailToVen.Rows.Count; i++)
                {
                    string sVen = "";
                    string sCode = "";
                    if (dtCodeMailToVen.Rows[i]["bUsed"].ToString().Trim() == "0")
                    {
                        sVen = dtCodeMailToVen.Rows[i]["供应商"].ToString().Trim();
                        sSQL = "select distinct * from UFDLImport.._vendUid v where  accid = 200 and accyear = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) +
                                " and vendCode = '" + dtCodeMailToVen.Rows[i]["供应商编码"].ToString().Trim() + "' ";
                        DataTable dtT = clsSQLCommond.ExecQuery(sSQL);


                        sCode = sCode + dtCodeMailToVen.Rows[i]["物料编码"].ToString().Trim() + "--" + dtCodeMailToVen.Rows[i]["物料名称"].ToString().Trim() + "; ";
                        dtCodeMailToVen.Rows[i]["bUsed"] = 1;

                        for (int j = i + 1; j < dtCodeMailToVen.Rows.Count; j++)
                        {
                            if (sVen == dtCodeMailToVen.Rows[j]["供应商"].ToString().Trim())
                            {
                                sCode = sCode + dtCodeMailToVen.Rows[j]["物料编码"].ToString().Trim() + "--" + dtCodeMailToVen.Rows[j]["物料名称"].ToString().Trim() + "; ";
                                dtCodeMailToVen.Rows[j]["bUsed"] = 1;
                            }
                        }

                        if (dtT.Rows[i]["sEMail"].ToString().Trim() == string.Empty)
                        {
                            MessageBox.Show("供应商" + sVen + "未设置邮箱！");
                            continue;
                        }

                        string sText = "尊敬的" + sVen + " ，您好 委外计划以下物料已经审核：" + sCode + " ，谢谢！ " + FrameBaseFunction.ClsBaseDataInfo.sUserName + " " + DateTime.Now.ToString("yyyy-MM-dd");

                        DataRow drMail = frmMail.dt.NewRow();
                        drMail["Subject"] = "委外计划审核";
                        drMail["sText"] = sText;
                        drMail["bUsed"] = "-1";
                        drMail["mailAddress"] = dtT.Rows[i]["sEMail"].ToString().Trim();

                        frmMail.dt.Rows.Add(drMail);
                    }
                }

                if (frmMail.dt.Rows != null && frmMail.dt.Rows.Count > 0)
                {
                    frmMail.FrmMailListSend_Load(null, null);
                    frmMail.btnOK_Click(null, null);
                }
            }
        }


        private void btnSave()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "";
                ArrayList aList = new ArrayList();
                string sMsg = "  ";
                string sMsgErr = "  ";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "" && gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "0")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已使用;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bAudit"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已审核;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bBeSure"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已确认;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已关闭;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["cVenCode"]).ToString().ToLower().Trim() == "")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 必须设置供应商;  ";
                            continue;
                        }

                        decimal d含税单价 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["iTaxPrice"]), 6);
                        decimal d税率 = ReturnObjectToDecimal(gridView1.GetRowCellValue(i, gridView1.Columns["iTaxRate"]), 6);
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["cVenCode"]).ToString().Trim() == "98")
                        {
                            sSQL = "update UFDLImport..OMPlan set PlanQty=" + gridView1.GetRowCellValue(i, gridView1.Columns["PlanQty"]) + ",cVenCode='" + gridView1.GetRowCellValue(i, gridView1.Columns["cVenCode"]) + "'" +
                                        ",SvaeUID='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',SaveDate='" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',bSave = 1 " +
                                        ",DueDate2='" + gridView1.GetRowCellValue(i, gridView1.Columns["DueDate2"]) + "',StartDate2='" + gridView1.GetRowCellValue(i, gridView1.Columns["StartDate2"]) + "' " +
                                   " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        }
                        else
                        {
                            sSQL = "update UFDLImport..OMPlan set PlanQty=" + gridView1.GetRowCellValue(i, gridView1.Columns["PlanQty"]) + ",cVenCode='" + gridView1.GetRowCellValue(i, gridView1.Columns["cVenCode"]) + "',iTaxPrice=" + d含税单价 + " ,iTaxRate=" + d税率 + " " +
                                        ",SvaeUID='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',SaveDate='" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',bSave = 1 " +
                                        ",DueDate2='" + gridView1.GetRowCellValue(i, gridView1.Columns["DueDate2"]) + "',StartDate2='" + gridView1.GetRowCellValue(i, gridView1.Columns["StartDate2"]) + "' " +
                                   " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        }
                        aList.Add(sSQL);
                        sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";

                    }
                }

                if (sMsgErr.Trim() != "")
                {
                    FrmMsgBox fMsgBos = new FrmMsgBox();
                    fMsgBos.Text = "保存失败";
                    fMsgBos.richTextBox1.Text ="出现错误请修正后重新保存\n" + sMsgErr;
                    fMsgBos.ShowDialog();
                    return;
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功" + aList.Count + "条数据！");
                    GetGrid();
                }
                else
                {
                    MessageBox.Show("请选择需要保存的数据！");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("保存失败！\n  " + ee.Message);
            }
        }

        private void btnClosed()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "";
                ArrayList aList = new ArrayList();
                string sMsg = "  ";
                string sMsgErr = "  ";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已关闭;  ";
                            continue;
                        }
                        sSQL = "update UFDLImport..OMPlan set bClosed=1,ClosedUID='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ClosedDate='" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        aList.Add(sSQL);
                        sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";
                    }
                }

                if (sMsgErr.Trim() != "")
                {
                    if (base.MsgBox("错误信息", sMsgErr) != DialogResult.OK)
                    {
                        return;
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("关闭成功" + aList.Count + "条数据！");
                    GetGrid();
                }
                else
                {
                    MessageBox.Show("请选择需要关闭的数据！");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("关闭失败！\n  " + ee.Message);
            }
        }

        private void btnOpen()
        {
            try
            {
                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                string sSQL = "";
                ArrayList aList = new ArrayList();
                string sMsg = "  ";
                string sMsgErr = "  ";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "false")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 未关闭;  ";
                            continue;
                        }
                        sSQL = "update UFDLImport..OMPlan set bClosed=0,ClosedUID=null,ClosedDate=null " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        aList.Add(sSQL);
                        sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";
                    }
                }

                if (sMsgErr.Trim() != "")
                {
                    if (base.MsgBox("错误信息", sMsgErr) != DialogResult.OK)
                    {
                        return;
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("打开成功" + aList.Count + "条数据！");
                    GetGrid();
                }
                else
                {
                    MessageBox.Show("请选择需要打开的数据！");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("确认失败！\n  " + ee.Message);
            }
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

                        if (b1)
                        {
                            gridView1.SetRowCellValue(i,gridColdVenCloseDate, gridView1.GetRowCellValue(i, gridColDueDate));
                        }
                    }
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

        int iBtnState = 0;      //0 初始状态；1 已导入可删除状态；2 加载U8数据可导入状态

        private void btnGet()
        {
            GetGrid();

            for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
            {
                if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "del")
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
                    base.toolStripMenuBtn.Items[i].Enabled = true;
                }
                if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "open")
                {
                    base.toolStripMenuBtn.Items[i].Enabled = true;
                }
                if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "closed")
                {
                    base.toolStripMenuBtn.Items[i].Enabled = true;
                }
            }
        }

        private void GetGrid()
        {
            try
            {
                chkAll.Checked = false;

                string sSQL = "select     o.iID, cast(null as varchar(2)) as bChoose, o.DemandId, o.PartId, o.SoType, o.SoDId, o.SoId, o.SoCode, o.SoSeq, o.PlanCode, o.DueDate2 as DueDate2, o.StartDate2 as StartDate2, o.LUSD, o.LUCD, o.PlanQty, o.CrdQty, o.SupplyType, o.SchId, o.Ufts, o.ManualFlag, o.DelFlag, o.ModifyFlag, o.ProjectId, o.FirmDate, o.FirmUser, o.Status, o.SrpSoDId, o.SrpSoType, " +
                                    "o.OnHand, o.OnOrder, o.OnAllocate, o.InvCode, o.InvAddCode, o.InvName, o.InvStd, o.ComUnitCode, o.ComUnitName, o.IsRem, o.Police,  o.Free1, o.Free2, o.Free3, o.Free4, o.Free5, o.Free6, o.Free7, o.Free8, o.Free9, o.Free10, o.MinQty, o.MulQty, o.FixQty, o.SafeQty, o.PlannerName,  o.Planner, o.InvDefine1, o.InvDefine2, " +
                                    "o.InvDefine3, o.InvDefine4, o.InvDefine5, o.InvDefine6, o.InvDefine7, o.InvDefine8, o.InvDefine9, o.InvDefine10, " +
                                    "o.InvDefine11, o.InvDefine12, o.InvDefine13, o.InvDefine14, o.InvDefine15, o.InvDefine16, o.BasEngineerFigNo, o.OrderQty, o.AccID, o.AccYear, o.bClosed, o.bUsed, o.bAllBatchCreate, cast(o.cVenCode as varchar(20)) as cVenCode,  o.iTaxPrice, o.iTaxRate, o.iUnitPrice, oI.omplanid, case when isnull(oI.Qty,0) > 0 then oI.Qty else oI2.Qty end as iOM_MOQty, v.cVenName,isnull(bSave,0) as bSave,isnull(bAudit,0) as bAudit,isnull(bBeSure,0) as bBeSure,dVenPlanDate,dVenCloseDate, " +
                                    " SvaeUID,SaveDate,AuditUID,AuditDate,BeSureUID,BeSureDate,ClosedUID,ClosedDate " +
                             "from UFDLImport..OMPlan o " +
                                  " 	left join (select a.OMPlanID,sum(b.Qty) as Qty from UFDLImport..OMPlan_Import a inner join (select min(iSendQTY/iUnitQuantity) as Qty,b.MODetailsID from @u8.OM_MODetails b inner join @u8.OM_MOMaterials  c on c.MoDetailsID = b.MODetailsID where c.iWIPtype = 3 group by b.MODetailsID) b on a.OM_MODetailsID = b.MODetailsID and a.accid =  '200'  and a.accyear =  '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' where isnull(a.OMPlanID,0) <> 0 group by a.OMPlanID) oI on o.iID = oI.OMPlanID " +
                                  "     left join (select a.OMPlanID,sum(b.Qty) as Qty from UFDLImport..OMPlan_Import a inner join (select min(iSendQTY/iUnitQuantity) as Qty,b.MODetailsID from @u8.OM_MODetails b inner join @u8.OM_MOMaterials  c on c.MoDetailsID = b.MODetailsID where c.iWIPtype = 1 group by b.MODetailsID) b on a.OM_MODetailsID = b.MODetailsID and a.accid =  '200' and a.accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and b.MODetailsID not in (select distinct b.MODetailsID from @u8.OM_MODetails b inner join @u8.OM_MOMaterials c on c.MoDetailsID = b.MODetailsID where c.iWIPtype = 3) where isnull(a.OMPlanID,0) <> 0 group by a.OMPlanID) oI2 on o.iID = oI2.OMPlanID " +
 
                                   "left join @u8.Vendor v on v.cVenCode = o.cVenCode " +
                           " where isnull(bImport,0) = 1 and o.accid = '200' and o.accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'  ";

                if (chkSave.Checked)
                {
                    sSQL = sSQL + " and isnull(bSave,0)=1 ";
                    gridColDueDate.OptionsColumn.AllowEdit = false;
                    gridColStartDate.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    sSQL = sSQL + " and isnull(bSave,0)<>1 ";
                    gridColDueDate.OptionsColumn.AllowEdit = true;
                    gridColStartDate.OptionsColumn.AllowEdit = true;
                }

                if (chkDid.Checked)
                {
                    sSQL = sSQL + " and (isnull(oI.Qty,0) <> 0 or isnull(bUsed,0)<>0) ";
                }

                if (chkClosed.Checked)
                {
                    sSQL = sSQL + " and isnull(bClosed,0) = 1 ";
                }
                else 
                {
                    sSQL = sSQL + " and isnull(bClosed,0) <> 1 ";
                }
               
                if (chkAudit.Checked)
                {
                    sSQL = sSQL + " and isnull(bAudit,0) = 1 ";
                }
                else
                {
                    sSQL = sSQL + " and isnull(bAudit,0) = 0 ";
                }

                if (chkVenSure.Checked)
                {
                    sSQL = sSQL + " and isnull(bBeSure,0) = 1 ";
                }
                else
                {
                    sSQL = sSQL + " and isnull(bBeSure,0) <> 1 ";
                }

                if (dVenPlan1.Visible == true)
                {
                    if (chkVenDate1.Checked)
                    {
                        sSQL = sSQL + " and o.DueDate2 >= '" + dVenPlan1.DateTime.ToString("yyyy-MM-dd") + "' ";

                        sSQL = sSQL + " and o.DueDate2 <= '" + dVenPlan2.DateTime.ToString("yyyy-MM-dd") + "' ";
                    }
                }

                sSQL = sSQL + " order by  SoCode,SoSeq,invcode,demandid,PlanCode ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);





                DataView dv = dt.DefaultView;
                string sRowFilter = " 1=1 ";
                if (lookUpEditSOCode.EditValue != null && lookUpEditSOCode.EditValue.ToString().Trim() != string.Empty)
                {
                    sRowFilter = sRowFilter + " and socode = '" + lookUpEditSOCode.EditValue.ToString().Trim() + "' ";
                }
                if (lookUpEditiRow1.EditValue != null && lookUpEditiRow1.EditValue.ToString().Trim() != string.Empty)
                {
                    if (lookUpEditiRow2.EditValue.ToString().Trim() == string.Empty)
                    {
                        lookUpEditiRow2.EditValue = lookUpEditiRow1.EditValue;
                    }

                    sRowFilter = sRowFilter + " and soseq >= '" + lookUpEditiRow1.EditValue.ToString().Trim() + "' and soseq <=  '" + lookUpEditiRow2.EditValue.ToString().Trim() + "'";
                }

                dv.RowFilter = sRowFilter;
                DataTable dt2 = dv.ToTable();

                if (!chkSave.Checked)
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        DataTable dt3 = GetVendPriceInfo(dt2.Rows[i]["InvCode"].ToString().Trim());
                        if (dt3 != null && dt3.Rows.Count > 0 && dt2.Rows[i]["cVenCode"].ToString().Trim() == "")
                        {
                            dt2.Rows[i]["cVenCode"] = dt3.Rows[0]["cVenCode"];
                            dt2.Rows[i]["cVenName"] = dt3.Rows[0]["cVenName"];
                            dt2.Rows[i]["iTaxPrice"] = dt3.Rows[0]["iTaxPrice"];
                            dt2.Rows[i]["iTaxRate"] = dt3.Rows[0]["iTaxRate"];
                            dt2.Rows[i]["iUnitPrice"] = dt3.Rows[0]["iUnitPrice"];
                        }
                    }
                }

                sRowFilter = " 1=1 ";
                if (txtVenCode.Text != null && txtVenCode.Text.ToString().Trim() != string.Empty)
                {
                    sRowFilter = sRowFilter + " and cVenCode = '" + txtVenCode.Text.ToString().Trim() + "' ";
                }
                DataView dv2 = dt2.DefaultView;
                dv2.RowFilter = sRowFilter;

                gridControl1.DataSource = dv2.ToTable().Copy();
                iBtnState = 1;

            }
            catch (Exception ee)
            {
                MessageBox.Show("获得委外计划失败！\n  " + ee.Message);
            }
        }

        private void btnDelRow()
        {
            try
            {
                string sSQL = "";
                ArrayList aList = new ArrayList();
                string sMsg = "  ";
                string sMsgErr = "  ";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bAudit"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已审核;  ";
                            continue;
                        }

                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bBeSure"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已确认;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "" && gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "0")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已使用;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " 已关闭;  ";
                            continue;
                        }
                        sSQL = "update UFDLImport..OMPlan  set bSave =null,SvaeUID=null,SaveDate=null where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        aList.Add(sSQL);
                        sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";

                    }
                }

                if (sMsgErr.Trim() != "")
                {
                    if (MessageBox.Show("出现错误\n" + sMsgErr + "是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                    {
                        return;
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("撤销成功！");
                    GetGrid();
                }
                else
                {
                    MessageBox.Show("请选择需要撤销的数据！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("删行失败！\n  " + ee.Message);
            }
        }

        private void SetColIndexAudit()
        {
            //gridColbChoose.VisibleIndex = 1;
            gridColSoCode.VisibleIndex = 2;
            gridColSoSeq.VisibleIndex = 3;
            gridColInvCode.VisibleIndex = 4;
            gridColInvName.VisibleIndex = 5;
            gridColInvStd.VisibleIndex = 6;
            gridColComUnitName.VisibleIndex = 7;
            gridColPlanQty.VisibleIndex = 8;
            //gridColiOM_MOQty.VisibleIndex = 9;
            gridColStartDate.VisibleIndex = 10;
            gridColDueDate.VisibleIndex = 11;
            gridColcVenCode.VisibleIndex = 12;
            gridColcVenName.VisibleIndex = 13;
            //gridColdVenCloseDate.VisibleIndex = 14;
            //gridColiTaxPrice.VisibleIndex = 15;
            //gridColiTaxRate.VisibleIndex = 16;
            gridColSvaeUID.VisibleIndex = 17;
            gridColSaveDate.VisibleIndex = 18;
            //gridColBeSureUID.VisibleIndex = 19;
            //gridColBeSureDate.VisibleIndex = 20;
            //gridColAuditUID.VisibleIndex = 21;
            //gridColAuditDate.VisibleIndex = 22;
            gridColClosedUID.VisibleIndex = 23;
            gridColClosedDate.VisibleIndex = 24;

        }
        private void FrmOMPlanImport_Load(object sender, EventArgs e)
        {
            try
            {
                dVenPlan1.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                dVenPlan2.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(1);
                b3 = true;
                SetColIndexAudit();
              
                gridColcVenCode.OptionsColumn.AllowEdit = true;

                dVenPlan1.Visible = true;
                dVenPlan2.Visible = true;
                chkVenDate1.Visible = true;
                label7.Visible = true;
                label6.Visible = true;
                SetConEnable(true);

                GetSoCode();

                string sSQL = "select vendCode,cVenName from UFDLImport.._vendUid left join @u8.Vendor on @u8.Vendor.cVenCode = vendCode where uid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' and accid =200 and accyear=" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + " ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (FrameBaseFunction.ClsBaseDataInfo.sUid == "admin" || dt.Rows.Count != 0)
                {
                    txtVenCode.Enabled = true;

                    if (dt.Rows.Count != 0 && dt.Rows[0]["vendCode"].ToString().Trim() != string.Empty)
                    {
                        txtVenCode.Enabled = false;
                        txtVenCode.Text = dt.Rows[0]["vendCode"].ToString().Trim();
                        txtVenCode_Leave(null, null);
                    }
                }
                else
                {
                    txtVenCode.Enabled = false;
                    chkClosed.Visible = false;
                    chkDid.Visible = false;
                }

                gridColbChoose.Visible = true;
                gridColbChoose.VisibleIndex = 1;
                gridColbChoose.Caption = "　";

                ClsVenInvPrice clsPrice = new ClsVenInvPrice();
                dtPriceList = clsPrice.GetPrice(2);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n  " + ee.Message);
            }
        }

        private bool GetAllBatch(string sInvCode)
        {
            string sSQL = "select i.cAssComUnitCode,CompScrap,BaseQtyD,BaseQtyN,b.bomID,b.BomType,i.cDefWareHouse,bp.ParentScrap,bas2.invCode as cInvCode,i.iSupplyType,bo.OpComponentId,i.cAssComUnitCode,bo.AuxBaseQtyN,b.BomType, " +
                          "(isnull(BaseQtyN,0)/isnull(BaseQtyD,0))/(1-isnull(ParentScrap,0))*(1+isnull(CompScrap,0)) as 使用数量,AuxBaseQtyN/(1-isnull(ParentScrap,0))*(1+isnull(CompScrap,0)) as 辅助使用数量 " +
                    "from @u8.bom_bom b " +
                       "	left join @u8.bom_parent bp on b.bomid = bp.bomid " +
                       "	left join @u8.bom_opcomponent bo on bo.bomid = b.bomid " +
                       "	left join @u8.bas_part bas on bas.partid = bp.parentid " +
                       " left join @u8.bas_part bas2 on bas2.partid = bo.ComponentId " +
                       " left join @u8.Inventory i on i.cInvCode = bas2.invCode " +
                       "where bas.invcode = '" + sInvCode + "' and bo.effBegDate <= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' and bo.effEndDate >= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
                       "order by b.BomId,bp.ParentId,OpComponentId ";
            DataTable dtBom = clsSQLCommond.ExecQuery(sSQL);

            bool bInv;
            if (dtBom.Rows[0]["cAssComUnitCode"] == null || dtBom.Rows[0]["cAssComUnitCode"].ToString().Trim() == string.Empty)
            {
                bInv = true;
            }
            else
            {
                bInv = false;
            }
            return bInv;
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

                    for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                    {
                        if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "ensure")
                        {
                            gridView1.SetFocusedRowCellValue(gridColdVenCloseDate, gridView1.GetFocusedRowCellValue(gridColDueDate));
                        }
                    }
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColbChoose).ToString().Trim() == "√")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }

                    DateTime d1 = Convert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, gridColDueDate));
                    DateTime d2 = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                    string sNum1 = gridView1.GetRowCellValue(e.RowHandle, gridColiOM_MOQty).ToString().Trim();
                    double dNum1 = 0;
                    if (sNum1 != string.Empty)
                    {
                        dNum1 = double.Parse(sNum1);
                    }
                    double dNum2 = Convert.ToDouble(gridView1.GetRowCellValue(e.RowHandle, gridColPlanQty));

                    if (d2 > d1 && dNum1 < dNum2)
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                        
                }
            }
            catch
            { }
        }

        private void chkDid_CheckedChanged(object sender, EventArgs e)
        {
            GetGrid();
        }

        /// <summary>
        /// 根据存货编码判断供应商 1. 供应商存货价格表，便宜者 2. 最后一次委外厂商
        /// </summary>
        /// <param name="p">存货编码</param>
        /// <returns></returns>
        private DataTable GetVendPriceInfo(string p)
        {
            try
            {
                DataView dv = new DataView(dtPriceList);
                dv.RowFilter = " cInvCode = '" + p + "' ";
                return dv.ToTable();
                //string sSQL = "select top 1 p.cvencode,p.cinvcode,p.iUnitPrice,p.itaxrate,p.itaxunitprice as iTaxPrice,v.cVenName from @u8.pu_veninvpricelst p left join @u8.Vendor v on v.cVenCode=p.cvencode where cInvCode = '" + p + "' order by iunitprice";
                //DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                //if (dt.Rows.Count > 0)
                //{
                //    return dt;
                //}
                //else
                //{
                //    sSQL = "select top 1 o.cVenCode,cinvcode,v.cVenName,iUnitPrice,itaxrate,iTaxPrice from @u8.OM_MODetails od inner join @u8.OM_MOMain o on o.MOID=od.MOID left join @u8.vendor v on v.cVenCode =  o.cVenCode " +
                //            "where cInvCode = '" + p + "' and iUnitPrice is not null order by MODetailsID desc";
                //    dt = clsSQLCommond.ExecQuery(sSQL);
                //    //if (dt.Rows.Count > 0)
                //    //{
                //        return dt;
                //    //}
                //    //else
                //    //{
                //    //    throw new Exception("获得供应商物料‘" + p + "’信息失败！");
                //    //}
                //}
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商物料信息失败！\n  " + ee.Message);
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
                
                DataView dv = new DataView(dtPriceList);
                dv.RowFilter = " cInvCode = '" + p + "' and cVenCode = '" + sVend + "' ";
                return dv.ToTable();
            //    string sSQL = "select top 1 p.cvencode,p.cinvcode,p.iUnitPrice,p.itaxrate,p.itaxunitprice as iTaxPrice,v.cVenName from @u8.pu_veninvpricelst p left join @u8.Vendor v on v.cVenCode=p.cvencode where cInvCode = '" + p + "' and p.cVenCode = '" + sVend + "' order by iunitprice";
            //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            //    if (dt.Rows.Count > 0)
            //    {
            //        return dt;
            //    }
            //    else
            //    {
            //        sSQL = "select top 1 o.cVenCode,cinvcode,iUnitPrice,itaxrate,iTaxPrice from @u8.OM_MODetails od inner join @u8.OM_MOMain o on o.MOID=od.MOID " +
            //                "where cInvCode = '" + p + "' and iUnitPrice is not null and cVenCode = '" + sVend + "' order by MODetailsID desc";
            //        dt = clsSQLCommond.ExecQuery(sSQL);
            //        if (dt.Rows.Count > 0)
            //        {
            //            return dt;
            //        }
            //        else
            //        {
            //            return null;
            //        }
            //    }
            }
            catch (Exception ee)
            {
                throw new Exception("获得供应商物料信息失败！\n  " + ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {

                if (e.Column == gridView1.Columns["cVenCode"])
                {
                    int iRow = 0;
                    if (gridView1.RowCount > 0)
                    {
                        iRow = gridView1.FocusedRowHandle;
                    }
                    string sVend = gridView1.GetRowCellDisplayText(iRow, gridView1.Columns["cVenCode"]).ToString().Trim();
                    string sInvCode = gridView1.GetRowCellValue(iRow, gridView1.Columns["InvCode"]).ToString().Trim();

                    if (sVend == string.Empty)
                    {
                        gridView1.SetRowCellValue(iRow, gridView1.Columns["cVenName"], null);
                        gridView1.SetRowCellValue(iRow, gridView1.Columns["iTaxRate"], null);
                        gridView1.SetRowCellValue(iRow, gridView1.Columns["iTaxPrice"], null);
                        gridView1.SetRowCellValue(iRow, gridView1.Columns["iUnitPrice"], null);
                    }
                    else
                    {
                        if (sVend == "98")
                        {
                            DataTable dt = clsSQLCommond.ExecQuery("select * from @u8.Vendor where cVenCode = '" + sVend + "'");
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["cVenName"], dt.Rows[0]["cVenName"]);
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["iTaxRate"], null);
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["iTaxPrice"], null);
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["iUnitPrice"], null);
                            }
                        }
                        else
                        {
                            DataTable dt = GetVendPriceInfo(sInvCode, sVend);

                            if (dt != null && dt.Rows.Count > 0)
                            {
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["cVenName"], dt.Rows[0]["cVenName"].ToString().Trim());
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["iTaxRate"], dt.Rows[0]["iTaxRate"].ToString().Trim());
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["iTaxPrice"], dt.Rows[0]["iTaxPrice"].ToString().Trim());
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["iUnitPrice"], dt.Rows[0]["iUnitPrice"].ToString().Trim());
                            }
                            else
                            {
                                MessageBox.Show("供应商 " + sVend + " 未设定存货 " + sInvCode + " 价格，不能使用！");
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["cVenCode"], null);
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["cVenName"], null);
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["iTaxRate"], null);
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["iTaxPrice"], null);
                                gridView1.SetRowCellValue(iRow, gridView1.Columns["iUnitPrice"], null);
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("赋值失败！  " + ee.Message);
            }
        }

        /// <summary>
        /// 销售订单号
        /// </summary>
        private void GetSoCode()
        {
            try
            {
                string sSQL = "select distinct cSOCode as iID from @u8.SO_SOMain where cCloser is null and cVerifier iS not null order by cSOCode";
                lookUpEditSOCode.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得销售订单号失败！  " + ee.Message);
            }
        }

        /// <summary>
        /// 获得销售订单行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lookUpEditSOCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select distinct cast(sd.iRowNo as varchar(4)) as iID " +
                                "from @u8.SO_SOMain s left join @u8.SO_SODetails sd on s.[ID] = sd.[ID] " +
                                "where cCloser is null and cVerifier iS not null and s.cSOCode = '" + lookUpEditSOCode.EditValue.ToString().Trim() + "' ";
                           
                lookUpEditiRow1.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditiRow2.Properties.DataSource = lookUpEditiRow1.Properties.DataSource;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得销售订单号失败！  " + ee.Message);
            }
        }

        private void lookUpEditiRow1_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditiRow2.EditValue = lookUpEditiRow1.EditValue;
        }

        private void chkClosed_CheckedChanged(object sender, EventArgs e)
        {
            GetGrid();

            if (chkClosed.Checked)
            {
                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "del")
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
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "open")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "closed")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                }
            }
            else
            {
                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "del")
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
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "open")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "closed")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                }
            }
        }

        private void chkAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAudit.Checked)
            {
                chkSave.Checked = true;
            }

            GetGrid();
        }

        private void chkVenSure_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVenSure.Checked)
            {
                chkSave.Checked = true;
            }

            GetGrid();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(e.FocusedRowHandle, gridColbBeSure)) || Convert.ToBoolean(gridView1.GetRowCellValue(e.FocusedRowHandle, gridColbClosed)))
                {
                    gridColcVenCode.OptionsColumn.AllowEdit = false;
                }
                else
                {
                    gridColcVenCode.OptionsColumn.AllowEdit = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void chkVenDate1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVenDate1.Checked)
            {
                dVenPlan1.Enabled = true;
                dVenPlan2.Enabled = true;
            }
            else
            {
                dVenPlan1.Enabled = false;
                dVenPlan2.Enabled = false;
            }
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

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSave.Checked)
            {
                chkVenSure.Checked = false;
                chkAudit.Checked = false;
            }

            GetGrid();
        }

        private void ItemButtonEditVen_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                    iRow = gridView1.FocusedRowHandle;

                string sVen = gridView1.GetRowCellDisplayText(iRow, gridColcVenCode).ToString().Trim();
                FrmVenInfo fVen = new FrmVenInfo(sVen);
                if (DialogResult.OK == fVen.ShowDialog())
                {
                    gridView1.SetRowCellValue(iRow, gridColcVenCode, fVen.sVenCode);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商参照失败！  " + ee.Message);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateEdit1.Enabled = true;
                dateEdit1.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            }
            else
                dateEdit1.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                dateEdit2.Enabled = true;
                dateEdit2.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            }
            else
                dateEdit2.Enabled = false;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                {
                    gridView1.FocusedRowHandle = i;
                    if (checkBox1.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridColStartDate, dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                    }
                    if (checkBox2.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridColDueDate, dateEdit2.DateTime.ToString("yyyy-MM-dd"));
                    }
                    if (chkVenPG.Checked)
                    {
                        if (txtVenNamePG.Text.Trim() != "")
                        {
                            gridView1.SetRowCellValue(i, gridColcVenCode, txtVenCodePG.Text);
                            gridView1.SetRowCellValue(i, gridColcVenName, txtVenNamePG.Text);
                        }
                        else
                        {
                            MessageBox.Show("请选择批改供应商！");
                        }
                    }
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
                    //GetGrid();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
            }
        }

        private void btnSaveVen_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList aList = new ArrayList();
                string sSQL = "";
                string sErr = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        if (gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() == "" || gridView1.GetRowCellValue(i, gridColcVenName).ToString().Trim() == "")
                        {
                            sErr = sErr + "行 " + (i + 1) + " 供应商不能为空 \n";
                            continue;
                        }

                        if (gridView1.GetRowCellValue(i, gridColiTaxPrice).ToString().Trim() == "" || gridView1.GetRowCellValue(i, gridColiTaxRate).ToString().Trim() == "")
                        {
                            sErr = sErr + "行 " + (i + 1) + " 未设置材料价格！\n";
                            continue;
                        }

                        sSQL = "update UFDLImport..OMPlan set cVenCode = '" + gridView1.GetRowCellValue(i, gridColcVenCode).ToString().Trim() + "' " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]) +" and accid ='200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";

                        aList.Add(sSQL);
                    }
                }
                if (sErr != "")
                {
                    FrmMsgBox fMsgBos = new FrmMsgBox();
                    fMsgBos.Text = "保存失败";
                    fMsgBos.richTextBox1.Text = "保存失败，原因如下：\n" + sErr;
                    fMsgBos.ShowDialog();
                    return;
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("保存失败！ " + ee.Message);
            }
        }

        private void chkVenPG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVenPG.Checked)
            {
                txtVenCodePG.Text = "";
                txtVenCodePG.Enabled = true;
            }
            else
            {
                txtVenCodePG.Enabled = false;
            }
        }

        private void txtVenCodePG_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmVenInfo fVen = new FrmVenInfo(txtVenCodePG.Text.Trim());
            if (DialogResult.OK == fVen.ShowDialog())
            {
                txtVenCodePG.Text = fVen.sVenCode;
                txtVenNamePG.Text = fVen.sVenName;
            }
        }

        private void txtVenCodePG_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCodePG.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenCodePG.Text = dt.Rows[0]["iID"].ToString().Trim();
                    txtVenNamePG.Text = dt.Rows[0]["iText"].ToString().Trim();
                }
                else
                {
                    txtVenCodePG.Text = "";
                    txtVenCodePG.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得供应商信息失败！ " + ee.Message);
            }
        }

        private void chkVenPG_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkVenPG.Checked)
            {
                txtVenCodePG.Enabled = true;
                txtVenCodePG.Properties.ReadOnly = false;
            }
            else
            {
                txtVenCodePG.Enabled = false;
                txtVenCodePG.Properties.ReadOnly = true;
            }
        }
    }
}