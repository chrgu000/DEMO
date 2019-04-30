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
    public partial class FrmOMPlanVen : FrameBaseFunction.Frm�б���ģ��
    {
        bool b1 = false;//��Ӧ��
        bool b2 = false;//������Ա
        bool b3 = false;//ά�������Ա

        public FrmOMPlanVen()
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
                    case "audit":
                        btnEnSure();
                        break;
                    case "unaudit":
                        btnUnEnSure();
                        break;
                    case "alter":
                        btnPrint();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(sBtnText + " ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint()
        {
            try
            {
                RepOMPlanVen rep = new RepOMPlanVen();

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                }
                catch { }

                DataTable dt = (DataTable)gridControl1.DataSource;
                int iRow = 0;
                if (dt.Rows.Count > 0)
                {
                    DataTable dtDetail = rep.dataSet1.Tables["dtDetail"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["bChoose"].ToString().Trim() == "��")
                        {
                            iRow += 1;
                            DataRow dr = dtDetail.NewRow();
                            dr["Column1"] = dt.Rows[i]["InvCode"];
                            dr["Column2"] = dt.Rows[i]["InvName"];
                            dr["Column3"] = dt.Rows[i]["InvStd"];
                            dr["Column4"] = dt.Rows[i]["comUnitName"];
                            dr["Column5"] = decimal.Round(Convert.ToDecimal(dt.Rows[i]["PlanQty"]), 0);
                            dr["Column6"] = Convert.ToDateTime(dt.Rows[i]["StartDate2"]).ToString("yyyy-MM-dd");
                            dr["Column7"] = Convert.ToDateTime(dt.Rows[i]["DueDate2"]).ToString("yyyy-MM-dd");
                            dr["Column8"] = Convert.ToDateTime(dt.Rows[i]["dVenCloseDate"]).ToString("yyyy-MM-dd");
                            dr["Column9"] = dt.Rows[i]["iID"];
                            dr["Column10"] = dt.Rows[i]["SoCode"];
                            dr["Column11"] = dt.Rows[i]["iOM_MOQty"];

                            dtDetail.Rows.Add(dr);
                        }
                    }

                    if (dtDetail.Rows.Count < 1)
                    {
                        MessageBox.Show("��ѡ����Ҫ��ӡ�����ݣ�");
                        return;
                    }

                    DataTable dtHead = rep.dataSet1.Tables["dtHead"];
                    DataRow dRowTe = dtHead.NewRow();
                    //dRowTe["Column1"] = "�������ڣ� " + dateEdit1.DateTime.ToString("yyyy-MM-dd") + " ---- " + dateEdit2.DateTime.ToString("yyyy-MM-dd");
                    dRowTe["Column1"] = "���̣�" + txtVenName.Text.Trim();
                    //dRowTe["Column3"] = "��ϵ�ˣ�";
                    //dRowTe["Column4"] = "�绰��";
                    //dRowTe["Column5"] = "��ˣ�";
                    dtHead.Rows.Add(dRowTe);

                    rep.ShowPreview();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش�ӡʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUnEnSure()
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
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "��")
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "" && gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "0")
                        {
                            sMsgErr = sMsgErr + "\n��" + (i + 1) + "�� " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " ��ʹ��;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bAudit"]).ToString().ToLower().Trim() == "true") 
                        {
                            sMsgErr = sMsgErr + "\n��" + (i + 1) + "�� " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " �����;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bBeSure"]).ToString().ToLower().Trim() == "false") 
                        {
                            sMsgErr = sMsgErr + "\n��" + (i + 1) + "�� " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " δȷ��;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n��" + (i + 1) + "�� " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " �ѹر�;  ";
                            continue;
                        }
                        sSQL = "update UFDLImport..OMPlan set bBeSure=0,BeSureUID=null,BeSureDate=null, " +
                                    " dVenPlanDate =null,dVenCloseDate  = null " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        aList.Add(sSQL);
                        sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";
                    }
                }

                if (sMsgErr.Trim() != "")
                {
                    if (MessageBox.Show("���ִ���\n" + sMsgErr + "�Ƿ����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("ȡ��ȷ�ϳɹ���");
                    btnGet();
                }
                else
                {
                    MessageBox.Show("��ѡ����Ҫȡ�������ݣ�");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("ȡ��ʧ�ܣ�\n  " + ee.Message);
            }
        }

        private void btnEnSure()
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
                    if (gridView1.GetRowCellValue(i, gridView1.Columns["bChoose"]).ToString().Trim() == "��")
                    {
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "" && gridView1.GetRowCellValue(i, gridView1.Columns["iOM_MOQty"]).ToString().ToLower().Trim() != "0")
                        {
                            sMsgErr = sMsgErr + "\n��" + (i+1) + "�� " +gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " ��ʹ��;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridColbSave).ToString().ToLower().Trim() != "" && gridView1.GetRowCellValue(i, gridColbSave).ToString().ToLower().Trim() != "true")
                        {
                            sMsgErr = sMsgErr + "\n��" + (i + 1) + "�� " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " δ����;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["dVenCloseDate"]).ToString().ToLower().Trim() == string.Empty) // && gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "false")
                        {
                            sMsgErr = sMsgErr + "\n��" + (i + 1) + "�� " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " ��������Ϊ��;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bBeSure"]).ToString().ToLower().Trim() == "true") // && gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "false")
                        {
                            sMsgErr = sMsgErr + "\n��" + (i + 1) + "�� " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " ��ȷ��;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bAudit"]).ToString().ToLower().Trim() == "true") // && gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "false")
                        {
                            sMsgErr = sMsgErr + "\n��" + (i + 1) + "�� " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " �����;  ";
                            continue;
                        }
                        if (gridView1.GetRowCellValue(i, gridView1.Columns["bClosed"]).ToString().ToLower().Trim() == "true")
                        {
                            sMsgErr = sMsgErr + "\n��" + (i + 1) + "�� " + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + " �ѹر�;  ";
                            continue;
                        }
                        sSQL = "update UFDLImport..OMPlan set bBeSure=1,BeSureUID='" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',BeSureDate='" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "', " +
                                    " dVenCloseDate  = '" + gridView1.GetRowCellValue(i, gridView1.Columns["dVenCloseDate"]).ToString().ToLower().Trim() + "' " +
                               " where iID = " + gridView1.GetRowCellValue(i, gridView1.Columns["iID"]);
                        aList.Add(sSQL);
                        sMsg = sMsg + gridView1.GetRowCellValue(i, gridView1.Columns["InvCode"]) + ",";
                    }
                }

                if (sMsgErr.Trim() != "")
                {
                    if (MessageBox.Show("���ִ���\n" + sMsgErr + "�Ƿ����", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                    {
                        return;
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("ȷ�ϳɹ���");
                    btnGet();   
                }
                else
                {
                    MessageBox.Show("��ѡ����Ҫȷ�ϵ����ݣ�");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show("ȷ��ʧ�ܣ�\n  " + ee.Message);
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
                        gridView1.SetRowCellValue(i, gridColbChoose, "��");

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

        int iBtnState = 0;      //0 ��ʼ״̬��1 �ѵ����ɾ��״̬��2 ����U8���ݿɵ���״̬

        private void btnGet()
        {
            try
            {
                chkAll.Checked = false;

                string sSQL = "select     o.iID, o.bChoose, o.DemandId, o.PartId, o.SoType, o.SoDId, o.SoId, o.SoCode, o.SoSeq, o.PlanCode, o.DueDate2, o.StartDate2, o.LUSD, o.LUCD, o.PlanQty, o.CrdQty, o.SupplyType, o.SchId, o.Ufts, o.ManualFlag, o.DelFlag, o.ModifyFlag, o.ProjectId, o.FirmDate, o.FirmUser, o.Status, o.SrpSoDId, o.SrpSoType, " +
                                    "o.OnHand, o.OnOrder, o.OnAllocate, o.InvCode, o.InvAddCode, o.InvName, o.InvStd, o.ComUnitCode, o.ComUnitName, o.IsRem, o.Police,  o.Free1, o.Free2, o.Free3, o.Free4, o.Free5, o.Free6, o.Free7, o.Free8, o.Free9, o.Free10, o.MinQty, o.MulQty, o.FixQty, o.SafeQty, o.PlannerName,  o.Planner, o.InvDefine1, o.InvDefine2, " +
                                    "o.InvDefine3, o.InvDefine4, o.InvDefine5, o.InvDefine6, o.InvDefine7, o.InvDefine8, o.InvDefine9, o.InvDefine10, " +
                                    "o.InvDefine11, o.InvDefine12, o.InvDefine13, o.InvDefine14, o.InvDefine15, o.InvDefine16, o.BasEngineerFigNo, o.OrderQty, o.AccID, o.AccYear, o.bClosed, o.bUsed, o.bAllBatchCreate, cast(o.cVenCode as varchar(20)) as cVenCode,  o.iTaxPrice, o.iTaxRate, o.iUnitPrice, oI.omplanid, oI.iOM_MOQty, v.cVenName,isnull(bSave,0) as bSave,isnull(bAudit,0) as bAudit,isnull(bBeSure,0) as bBeSure,dVenPlanDate,dVenCloseDate, " +
                                    " SvaeUID,SaveDate,AuditUID,AuditDate,BeSureUID,BeSureDate,ClosedUID,ClosedDate " +
                             "from UFDLImport..OMPlan o left join (select omplanid,sum(o.iQuantity) as iOM_MOQty from UFDLImport..OMPlan_Import om inner join @u8.OM_MODetails o on o.MODetailsID = om.OM_MODetailsID and accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' group by omplanid) oI on o.iid = oI.omplanID left join @u8.Vendor v on v.cVenCode = o.cVenCode " +
                           " where isnull(bSave,0) = 1 and isnull(bImport,0) = 1 and  isnull(bClosed,0) = 0 and accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "'  ";

             
                if (txtVenCode.Text != null && txtVenCode.Text.ToString().Trim() != string.Empty)
                {
                    sSQL = sSQL + " and o.cVenCode = '" + txtVenCode.Text.ToString().Trim() + "' ";
                }

                if (chkUnDid.Checked)
                {
                    sSQL = sSQL + " and (planQty > isnull(oI.iOM_MOQty,0))   ";
                }
                else
                {
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

                gridControl1.DataSource = dt;

                iBtnState = 1;
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ί��ƻ�ʧ�ܣ�\n  " + ee.Message);
            }
        }

        private void FrmOMPlanImport_Load(object sender, EventArgs e)
        {
            try
            {
                dVenPlan1.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                dVenPlan2.DateTime = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(1);


                b1 = true;
                gridColdVenCloseDate.OptionsColumn.AllowEdit = true;
                dVenPlan1.Visible = true;
                dVenPlan2.Visible = true;
                chkVenDate1.Visible = true;
                label7.Visible = true;
                label6.Visible = true;

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
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ��\n  " + ee.Message);
            }
        }

        //private bool GetAllBatch(string sInvCode)
        //{
        //    string sSQL = "select i.cAssComUnitCode,CompScrap,BaseQtyD,BaseQtyN,b.bomID,b.BomType,i.cDefWareHouse,bp.ParentScrap,bas2.invCode as cInvCode,i.iSupplyType,bo.OpComponentId,i.cAssComUnitCode,bo.AuxBaseQtyN,b.BomType, " +
        //                  "(isnull(BaseQtyN,0)/isnull(BaseQtyD,0))/(1-isnull(ParentScrap,0))*(1+isnull(CompScrap,0)) as ʹ������,AuxBaseQtyN/(1-isnull(ParentScrap,0))*(1+isnull(CompScrap,0)) as ����ʹ������ " +
        //            "from @u8.bom_bom b " +
        //               "	left join @u8.bom_parent bp on b.bomid = bp.bomid " +
        //               "	left join @u8.bom_opcomponent bo on bo.bomid = b.bomid " +
        //               "	left join @u8.bas_part bas on bas.partid = bp.parentid " +
        //               " left join @u8.bas_part bas2 on bas2.partid = bo.ComponentId " +
        //               " left join @u8.Inventory i on i.cInvCode = bas2.invCode " +
        //               "where bas.invcode = '" + sInvCode + "' and bo.effBegDate <= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' and bo.effEndDate >= '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
        //               "order by b.BomId,bp.ParentId,OpComponentId ";
        //    DataTable dtBom = clsSQLCommond.ExecQuery(sSQL);

        //    bool bInv;
        //    if (dtBom.Rows[0]["cAssComUnitCode"] == null || dtBom.Rows[0]["cAssComUnitCode"].ToString().Trim() == string.Empty)
        //    {
        //        bInv = true;
        //    }
        //    else
        //    {
        //        bInv = false;
        //    }
        //    return bInv;
        //}

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
                    gridView1.SetFocusedRowCellValue(gridColbChoose, "��");

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
                    if (gridView1.GetRowCellValue(e.RowHandle, gridColbChoose).ToString().Trim() == "��")
                    {
                        e.Appearance.BackColor = Color.MediumSeaGreen;
                    }
                }
            }
            catch
            { }
        }
       

        private void chkAudit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAudit.Checked)
            {
                chkVenSure.Checked = true;
            }
            else
            {
                chkUnDid.Checked = false;
            }

            btnGet();
        }

        private void chkVenSure_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkVenSure.Checked)
            {
                chkAudit.Checked = false;
            }

            btnGet();
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
                dVenPlan1.Properties.ReadOnly = false;
                dVenPlan2.Properties.ReadOnly = false;
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
                throw new Exception("��ù�Ӧ����Ϣʧ�ܣ�");
            }
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
                MessageBox.Show("��ù�Ӧ�̲���ʧ�ܣ�  " + ee.Message);
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

        private void chkUnDid_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnDid.Checked)
            {
                chkAudit.Checked = true;
                chkVenSure.Checked = true;
            }
            btnGet();
        }

        private void txtVenCode_Leave(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetVendor(txtVenCode.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtVenName.Text = dt.Rows[0]["iText"].ToString().Trim();
                    //btnGet();
                }
                else
                {
                    txtVenCode.Text = "";
                    txtVenName.Text = "";
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("��ù�Ӧ����Ϣʧ�ܣ� " + ee.Message);
            }
        }
    }
}