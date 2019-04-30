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
    public partial class FrmOMPlanImport : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmOMPlanImport()
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
                    case "del":
                        btnDelRow();
                        break;
                    case "save":
                        btnSave();
                        break;
        //////////////////////////////////////////////
                    case "audit":
                        btnLoad();
                        break;
                    case "unaudit":
                        btnImport();
                        break;
                        ////////////////////////
                    case "lock":
                        btnOpen();
                        break;
                    case "unlock":
                        btnClose();
                        break;
                    default:
                        break;
                }
                SetConEnable(false);
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose()
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
                    btnGet();
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
                    btnGet();
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
                        if (Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColStartDate)) < DateTime.Today)
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 托外结束日期在当前日期之前;  ";
                            continue;
                        }

                        if (Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColDueDate)) < Convert.ToDateTime(gridView1.GetRowCellValue(i, gridColStartDate)))
                        {
                            sMsgErr = sMsgErr + "\n第" + (i + 1) + "行 需求日期在托外结束日期之前;  ";
                            continue;
                        }


                        sSQL = "update UFDLImport..OMPlan set socode = '" + gridView1.GetRowCellValue(i, gridColSoCode) + "',soseq = " + gridView1.GetRowCellValue(i, gridColSoSeq) + ",DueDate='" + gridView1.GetRowCellValue(i, gridView1.Columns["DueDate"]) + "',StartDate='" + gridView1.GetRowCellValue(i, gridView1.Columns["StartDate"]) + "',DueDate2='" + gridView1.GetRowCellValue(i, gridView1.Columns["DueDate"]) + "',StartDate2='" + gridView1.GetRowCellValue(i, gridView1.Columns["StartDate"]) + "',PlanQty=" + gridView1.GetRowCellValue(i, gridView1.Columns["PlanQty"]) + ", " +
                                    "bImport = 1,ImportUID='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',ImportDate='" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "',remark = '" + gridView1.GetRowCellValue(i, gridColRemark) + "' " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        aList.Add(sSQL);
                        sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";

                    }
                }
                if (sMsgErr.Trim() != string.Empty)
                {
                    FrmMsgBox fBox = new FrmMsgBox();
                    fBox.Text = "以下数据没有保存" ;
                    fBox.richTextBox1.Text = sMsgErr;
                    fBox.ShowDialog();
                }
                sMsg = "成功：\n" + sMsg;
                if (sMsgErr.Trim() != "")
                {
                    sMsgErr = "失败：\n" + sMsgErr;
                    sMsg = sMsg + "\n" + sMsgErr;
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("成功保存 "  + aList.Count + "条数据");
                    btnGet();
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
                        gridView1.SetRowCellValue(i, gridColbChoose, "");
                }

            }
            catch
            { }
        }

        int iBtnState = 0;      //0 初始状态；1 已导入可删除状态；2 加载U8数据可导入状态

        private void btnGet()
        {
            try
            {
                chkSave.Enabled = true;
                chkAll.Checked = false;

                string sSQL = "select    bImport,ImportUID,ImportDate, o.iID,cast(null as varchar(2)) as bChoose, o.DemandId, o.PartId, o.SoType, o.SoDId, o.SoId, o.SoCode, o.SoSeq, o.PlanCode, o.DueDate, o.StartDate, o.LUSD, o.LUCD, o.PlanQty, o.CrdQty, o.SupplyType, o.SchId, o.Ufts, o.ManualFlag, o.DelFlag, o.ModifyFlag, o.ProjectId, o.FirmDate, o.FirmUser, o.Status, o.SrpSoDId, o.SrpSoType, " +
                                   "o.OnHand, o.OnOrder, o.OnAllocate, o.InvCode, o.InvAddCode, o.InvName, o.InvStd, o.ComUnitCode, o.ComUnitName, o.IsRem, o.Police,  o.Free1, o.Free2, o.Free3, o.Free4, o.Free5, o.Free6, o.Free7, o.Free8, o.Free9, o.Free10, o.MinQty, o.MulQty, o.FixQty, o.SafeQty, o.PlannerName,  o.Planner, o.InvDefine1, o.InvDefine2, " +
                                   "o.InvDefine3, o.InvDefine4, o.InvDefine5, o.InvDefine6, o.InvDefine7, o.InvDefine8, o.InvDefine9, o.InvDefine10, " +
                                   "o.InvDefine11, o.InvDefine12, o.InvDefine13, o.InvDefine14, o.InvDefine15, o.InvDefine16, o.BasEngineerFigNo, o.OrderQty, o.AccID, o.AccYear, o.bClosed, o.bUsed, o.bAllBatchCreate, cast(o.cVenCode as varchar(20)) as cVenCode,  o.iTaxPrice, o.iTaxRate, o.iUnitPrice, oI.omplanid, oI.iOM_MOQty, v.cVenName,isnull(bSave,0) as bSave,isnull(bAudit,0) as bAudit,isnull(bBeSure,0) as bBeSure,dVenPlanDate,dVenCloseDate, " +
                                   " SvaeUID,SaveDate,AuditUID,AuditDate,BeSureUID,BeSureDate,ClosedUID,ClosedDate,Remark " +
                          "from UFDLImport..OMPlan o left join (select omplanid,sum(o.iQuantity) as iOM_MOQty from UFDLImport..OMPlan_Import om inner join @u8.OM_MODetails o on o.MODetailsID = om.OM_MODetailsID and accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' group by omplanid) oI on o.iid = oI.omplanID left join @u8.Vendor v on v.cVenCode = o.cVenCode " +
                          " where accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'  ";

                if (chkSave.Checked)
                {
                    sSQL = sSQL + " and isnull(bImport,0)=1 ";
                }
                else
                {
                    sSQL = sSQL + " and isnull(bImport,0)<>1 ";
                }
                if (chkClose.Checked)
                {
                    sSQL = sSQL + " and isnull(bClosed,0)=1 ";
                }
                else
                {
                    sSQL = sSQL + " and isnull(bClosed,0)<>1 ";
                }
           
                sSQL = sSQL + " order by  SoCode,SoSeq,invcode,demandid,PlanCode ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                DataView dv = dt.DefaultView;
                string sRowFilter = " 1=1 ";
                if (lookUpEditSOCode.EditValue != null && lookUpEditSOCode.EditValue.ToString().Trim() != string.Empty)
                {
                    sRowFilter = sRowFilter + " and socode >= '" + lookUpEditSOCode.EditValue.ToString().Trim() + "' ";
                }
                if (lookUpEditSOCode2.EditValue != null && lookUpEditSOCode2.EditValue.ToString().Trim() != string.Empty)
                {
                    sRowFilter = sRowFilter + " and socode <= '" + lookUpEditSOCode2.EditValue.ToString().Trim() + "' ";
                }
             
                dv.RowFilter = sRowFilter;

                gridControl1.DataSource = dv.Table;

                lookUpEditPlanCode.EditValue = null;

                iBtnState = 1;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, "");
                }

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "sel")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
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
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "lock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                }

                base.toolStripMenuBtn.Items["save"].Enabled = true;
                
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
                string sBtnText = "";
                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "del")
                    {
                        sBtnText = base.toolStripMenuBtn.Items[i].Text.Trim();
                    }
                }

                string sSQL = "";
                ArrayList aList = new ArrayList();
                string sMsg = "  ";

                if (sBtnText == "删除")
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                        {
                            sSQL = "delete UFDLImport..OMPlan  where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                            aList.Add(sSQL);
                            sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";
                        }
                    }
                }
                if (sBtnText == "撤销")
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "√")
                        {
                            sSQL = "update UFDLImport..OMPlan set bImport =0  where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                            aList.Add(sSQL);
                            sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";
                        }
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    sMsg = sBtnText + "成功：\n" + sMsg;
                    MessageBox.Show(sMsg);
                    btnGet();
                }
                else
                {
                    MessageBox.Show("请选择需要删除的数据！");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("删行失败！\n  " + ee.Message);
            }
        }

        private void btnImport()
        {
            try
            {
                if (iBtnState == 2)
                {
                    try
                    {
                        gridView1.FocusedRowHandle -= 1;
                        gridView1.FocusedRowHandle += 1;
                    }
                    catch { }

                    DataTable dt = (DataTable)gridControl1.DataSource;
                    bool biID = false;
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string sFileName = dt.Columns[i].ColumnName.Trim();
                        if (sFileName == "iID")
                        {
                            biID = true;
                        }
                    }

                    if (!biID)
                    {
                        DataColumn dc = new DataColumn();
                        dc.ColumnName = "iID";
                        dt.Columns.Add(dc);
                    }
                    string sSQL = "select max(iID) as iID from UFDLImport..OMPlan ";
                    //string sSQL = "select max(iID) as iID from UFDLImport..OMPlan where accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'";
                    DataTable dCol = clsSQLCommond.ExecQuery(sSQL);
                    long liID = 1;
                    try
                    {
                        liID = Convert.ToInt64(dCol.Rows[0]["iID"]);
                    }
                    catch(Exception ee) { }

                    ArrayList aList = new ArrayList();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["bChoose"].ToString().Trim() == "√")
                        {
                            if (dt.Rows[i]["socode"].ToString().Trim() == "" || dt.Rows[i]["soseq"].ToString().Trim() == "")
                            {
                                MessageBox.Show("行 " + (1+i).ToString() + " 未设定销售订单号或者行号，请先设定");
                                break;
                            }
                            liID += 1;
                            dt.Rows[i]["iID"] = liID;
                            dt.Rows[i]["bAllBatchCreate"] = GetAllBatch(dt.Rows[i]["InvCode"].ToString().Trim());
                            dt.Rows[i]["ImportUID"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                            dt.Rows[i]["ImportDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;

                            aList.Add(clsGetSQL.GetInsertSQL("UFDLImport", "OMPlan", dt, i));
                        }
                    }
                  
                    if (aList.Count > 0)
                    {
                        clsSQLCommond.ExecSqlTran(aList);
                        iBtnState = 0;
                        gridControl1.DataSource = null;
                        MessageBox.Show("成功导入" + aList.Count + "条记录！");
                    }
                    else
                    {
                        MessageBox.Show("没有数据不能导入！");
                        return;
                    }
                    chkAll.Checked = false;
                }
                else
                {
                    MessageBox.Show("不是加载的U8计划维护数据，不能导入！");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("导入失败！\n  " + ee.Message);
            }
        }

        private void btnLoad()
        {
            try
            {
                chkSave.Enabled = false;

                iBtnState = 2;
                chkAll.Checked = false;

                if (lookUpEditPlanCode.EditValue != null || lookUpEditPlanCode.Text.Trim() != string.Empty)
                {
                    string sSQL = @"
Select 
	null as bAllBatchCreate,'' as bChoose,n.DemandId,n.PartId, coalesce(n.SoType,0) As SoType, case isnull(sotype,0) when 1 then '销售订单' else '预测订单' end  as SoType2, coalesce(n.SoDId,0) As SoDId,coalesce(n.SoId,0) As SoId, 	n.SoCode,n.SoSeq, n.PlanCode,n.DueDate,n.StartDate,n.LUSD,n.LUCD,n.PlanQty,n.CrdQty,n.SupplyType,n.SchId,n.Ufts, 	n.ManualFlag,n.DelFlag,n.ModifyFlag,n.ProjectId,n.FirmDate,n.FirmUser,n.Status ,n.SrpSoDId,n.SrpSoType, 	convert(decimal(22,6),null) As OnHand,convert(decimal(22,6),null) AS OnOrder, 	convert(decimal(22,6),null) As OnAllocate, v.InvCode,v.InvAddCode,v.InvName,v.InvStd, 	v.ComUnitCode,v.ComUnitName,v.IsRem,v.Policy As Police, p.Free1,p.Free2,p.Free3,p.Free4,p.Free5, 	p.Free6,p.Free7,p.Free8,p.Free9,p.Free10,p.MinQty,p.MulQty,p.FixQty,p.SafeQty,  	PlannerName=Case When coalesce( i.cInvPersonCode,'''')='''' then psp.cPersonName else psi.cPersonName end,  	Planner=Case When coalesce( i.cInvPersonCode,'''')='''' then i.cPurPersonCode else i.cInvPersonCode end,  	v.InvDefine1,v.InvDefine2,v.InvDefine3,v.InvDefine4,v.InvDefine5,v.InvDefine6,v.InvDefine7,v.InvDefine8, v.InvDefine9,v.InvDefine10, 	v.InvDefine11,v.InvDefine12,v.InvDefine13,v.InvDefine14,v.InvDefine15,v.InvDefine16,  p.cBasEngineerFigNo as BasEngineerFigNo, '' as SvaeUID,'' as SvaeUID
    ,   200 as accid,222222 as accyear,  '' as cVenCode,'' as cVenName,'' as iTaxPrice,'' as iUnitPrice,'' as iTaxRate   ,'' as ImportUID, '' as ImportDate, '' as AuditUID, '' as AuditDate, '' as BeSureUID, '' as BeSureDate, '' as ClosedUID, '' as ClosedDate,'' as Remark 
from @u8.mps_netdemand n inner join @u8.bas_part p on n.PartId = p.PartId  	
	inner join @u8.mps_planproject j on n.ProjectId=j.ProjectId  	
	inner join @u8.v_bas_inventory v on p.InvCode = v.InvCode  	
	inner join @u8.Inventory i on v.InvCode=i.cInvCode  	
	inner join @u8.mps_plancode c on j.PlanCodeId=c.PlanCodeId  	
	left outer join @u8.person psp on i.cPurPersonCode=psp.cPersonCode  	
	left outer join @u8.person psi on i.cInvPersonCode=psi.cPersonCode 
	left join  (select DemandId from UFDLImport..OMPlan where accid = 111111 and accyear = 222222 and DemandId is not null)a on n.DemandId = a.DemandId
where  n.delflag = 0   and (0=0 or n.SoType =0) and ( 0 = 0 or n.SupplyType = 0 )  
	and (v.MpsFlag  = 0 )   	and (0=0 or n.Status=0) and supplytype = 2 
	And ActiveFlag = 1  and c.PlanCode = '333333'    
	and isnull(a.DemandId ,'') = ''
	and 1=1
Order by  SoCode,SoSeq,v.invcode,n.demandid,n.PlanCode 
";
                    sSQL = sSQL.Replace("111111", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                    sSQL = sSQL.Replace("222222", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                    sSQL = sSQL.Replace("333333", lookUpEditPlanCode.EditValue.ToString().Trim());

                    if (lookUpEditSOCode.EditValue != null && lookUpEditSOCode.EditValue.ToString().Trim() != string.Empty)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and socode >= '" + lookUpEditSOCode.EditValue.ToString().Trim() + "'");
                    }
                    if (lookUpEditSOCode2.EditValue != null && lookUpEditSOCode2.EditValue.ToString().Trim() != string.Empty)
                    {
                        sSQL = sSQL.Replace("1=1", "1=1 and socode <= '" + lookUpEditSOCode2.EditValue.ToString().Trim() + "'");
                    }
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    gridControl1.DataSource = dt;
                }
                else
                {
                    gridControl1.DataSource = null;
                    lookUpEditPlanCode.Select();
                    MessageBox.Show("请选择计划代号！");
                }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridColbChoose, "");
                }

                SetConEnable(false);
                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "sel")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
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
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "lock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得委外计划失败！\n  " + ee.Message);
            }

        }



        /// <summary>
        /// 获得计划代号
        /// </summary>
        private void GetPlanCode()
        {
            try
            {
                string sSQL = "select PlanCode,Description from @u8.mps_plancode order by PlanCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEditPlanCode.Properties.DataSource  = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得计划代号失败！\n  " + ee.Message);
            }
        }

      
        private void FrmOMPlanImport_Load(object sender, EventArgs e)
        {
            try
            {
                chkSave.Enabled = true;

                for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
                {
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "sel")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
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
                        base.toolStripMenuBtn.Items[i].Enabled = true;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unaudit")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "lock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                    if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "unlock")
                    {
                        base.toolStripMenuBtn.Items[i].Enabled = false;
                    }
                }

                //chkSave.Enabled = false;

                gridColDueDate.OptionsColumn.AllowEdit = true;
                gridColStartDate.OptionsColumn.AllowEdit = true;
                gridColcVenCode.OptionsColumn.AllowEdit = true;
                gridColPlanQty.OptionsColumn.AllowEdit = true;
                lookUpEditPlanCode.Properties.ReadOnly = false;

                lookUpEditPlanCode.Visible = true;
                label1.Visible = true;

                SetConEnable(true);

                GetPlanCode();

                GetSoCode();
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
          
            if (dtBom == null || dtBom.Rows.Count == 0 || dtBom.Rows[0]["cAssComUnitCode"] == null || dtBom.Rows[0]["cAssComUnitCode"].ToString().Trim() == string.Empty)
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
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 销售订单号
        /// </summary>
        private void GetSoCode()
        {
            try
            {
                string sSQL = "select distinct cSOCode as iID from @u8.SO_SOMain where 1=1 order by cSOCode";
                lookUpEditSOCode.Properties.DataSource = clsGetSQL.GetLookUpEdit(sSQL);
                lookUpEditSOCode2.Properties.DataSource = lookUpEditSOCode.Properties.DataSource;
                ItemLookUpEditSoCode.DataSource = lookUpEditSOCode.Properties.DataSource;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得销售订单号失败！  " + ee.Message);
            }
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

        private void chkSave_CheckedChanged(object sender, EventArgs e)
        {
            btnGet();



            for (int i = 0; i < base.toolStripMenuBtn.Items.Count; i++)
            {
                if (base.toolStripMenuBtn.Items[i].Name.ToLower().Trim() == "del")
                {
                    if (chkSave.Checked)
                    {
                        base.toolStripMenuBtn.Items[i].Text = "撤销";
                    }
                    else 
                    {
                        base.toolStripMenuBtn.Items[i].Text = "删除";
                    }
                }
            }
         
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                {
                    if (checkBox1.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridColStartDate, dateEdit1.DateTime.ToString("yyyy-MM-dd"));
                    }
                    if (checkBox2.Checked)
                    {
                        gridView1.SetRowCellValue(i, gridColDueDate, dateEdit2.DateTime.ToString("yyyy-MM-dd"));
                    }
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

        private void lookUpEditSOCode_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEditSOCode2.EditValue = lookUpEditSOCode.EditValue;
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

        /// <summary>
        /// 关闭母窗体的Enable设置
        /// </summary>
        /// <param name="b"></param>
        private void SetConEnable(bool b)
        {
            return;
        }
    }
}