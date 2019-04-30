using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FrameBaseFunction;

namespace WorkInformation
{
    public partial class FrmWorkProcedureList : FrameBaseFunction.Frm�б���ģ��
    {
        DataTable dtTable;
        DateTime dtm1;
        int iType = 0;
        string sDepInfo = "";
 
        public FrmWorkProcedureList()
        {
            InitializeComponent();
        }

        private void FrmWorkProcedureList_Load(object sender, EventArgs e)
        {
            try
            {
                GetbTran();
                GetRdInType();

                string sSQL = "select isnull(b.cDepName,'') as cDepName from _UserInfo a left join @u8.Department b on a.cDepCode = b.cDepCode where vchruid = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows[0]["cDepName"].ToString().Trim() == "")
                {
                    MessageBox.Show("������Ա������");
                    return;
                }
                sDepInfo = dt.Rows[0]["cDepName"].ToString().Trim();
                if (sDepInfo == "�ֿ�")
                {
                    iType = 1;
                    radioButton1.Visible = false;
                    radioButton2.Visible = true;
                    radioButton2.Text = "δ���";
                    radioButton2.Checked = true;
                    radioButton3.Visible = true;
                    radioButton4.Visible = true;

                    gridColRDInTrans.Visible = true;
                    gridColRDTrans.Visible = true;

                    //for (int i = 0; i < base.toolStrip1.Items.Count; i++)
                    //{
                    //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "ensure")
                    //    {
                    //        base.toolStrip1.Items[i].Visible = false;
                    //    }
                    //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "unsure")
                    //    {
                    //        base.toolStrip1.Items[i].Visible = false;
                    //    }
                    //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "audit")
                    //    {
                    //        base.toolStrip1.Items[i].Visible = true;
                    //    }
                    //}
                }
                else
                {
                    iType = 2;
                    radioButton1.Visible = true;
                    radioButton2.Visible = true;
                    radioButton2.Text = "��ȷ��";
                    radioButton3.Visible = false;
                    radioButton4.Visible = false;

                    gridColRDInTrans.Visible = false;
                    gridColRDTrans.Visible = false;

                    //for (int i = 0; i < base.toolStrip1.Items.Count; i++)
                    //{
                    //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "ensure")
                    //    {
                    //        base.toolStrip1.Items[i].Visible = true;
                    //    }
                    //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "unsure")
                    //    {
                    //        base.toolStrip1.Items[i].Visible = true;
                    //    }
                    //    if (base.toolStrip1.Items[i].Name.ToLower().Trim() == "audit")
                    //    {
                    //        base.toolStrip1.Items[i].Visible = false;
                    //    }
                    //}
                }

                dtm1 = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);

                sSQL = "select '��' as RdTrans,'��' as RDInTrans,wd.WorkTime,w.cinvcode2,isnull(w.dtmPlan,'1900-1-1') as dtmPlan,isnull(w.bRDIn,0) as bRDIn,w.vchrPer,w.vchrEquipment,w.GUID ,w.AutoID,WorkOrderID,WorkOrderNO,WorkOrderRowNO,w.cInvCode,i.cInvName,i.cInvStd,wd.workDepmentNext2,isnull(w.iQuantity,0) as iQuantity,workProcedure,wp.fName as workProcedureName,workProcedureNext,wp2.fName as workProcedureNextName,w.workDepment,wDep.fName,isnull(wd.iQuantity,0) as wdiQty,null as wddiQty,null as QtyIng,null as QtyNow,wd.QtyRDIn,wd.QtyRDL,null as WorkQtyY,null as SoCode,cast(null as datetime) as dtm1,wd.EnSureUid,wd.EnSureDate,wd.AuditUid,wd.AuditDate  " +
                         "from UFDLImport..WorkPlan w left join UFDLImport..WorkPlanDetail wd on w.Guid = wd.GuidHead left join @u8.Inventory i on i.cInvcode = w.cInvCode left join UFDLImport..WorkDepment wDep on wDep.FCode = w.workDepment 	left join UFDLImport..WorkingProcedure wp on wp.fCode = w.workProcedure left join UFDLImport..WorkingProcedure wp2 on wp2.fCode = w.workProcedureNext  " +
                         "where 1=-1";
                dtTable = clsSQLCommond.ExecQuery(sSQL);

                GetFacility();
                GetWHInfo();

                btnSel();
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ش���ʧ��! \n\nԭ��:\n  " + ee.Message, "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "ensure":
                        btnEnSure();
                        break;
                    case "unsure":
                        btnUnSure();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "close":
                        btnClose();
                        break;
                    case "open":
                        btnOpen();
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

        private void btnOpen()
        {
            if (radioButton4.Checked)
            {
                string sSQL;
                ArrayList aList = new ArrayList();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        sSQL = " update UFDLImport.WorkPlanDetail set bClose = 0, CloseUser =null,CloseDate = null where id = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                        aList.Add(sSQL);
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    gridControl1.DataSource = null;
                    MessageBox.Show("�򿪳ɹ���");
                    btnSel();
                }
            }
        }

        private void btnClose()
        {
            if (radioButton2.Checked || radioButton3.Checked)
            {
                string sSQL;
                ArrayList aList = new ArrayList();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        sSQL = " update UFDLImport.WorkPlanDetail set bClose = 1, CloseUser = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',CloseDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where id = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                        aList.Add(sSQL);
                    }
                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    gridControl1.DataSource = null;
                    MessageBox.Show("�رճɹ���");
                    btnSel();
                }
            }
        }

        private void btnDel()
        {
            if (radioButton3.Checked)
            {
                MessageBox.Show("�Ѿ���ˣ�����ɾ��!");
                return;
            }
            if (radioButton4.Checked)
            {
                MessageBox.Show("�Ѿ��رգ�����ɾ��!");
                return;
            }
            int iCount = 0;
            
            ArrayList aList = new ArrayList();
            string sSQL = "";
            string sErr = "";

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                {
                    iCount += 1;

                    if (radioButton2.Checked && gridView1.GetRowCellValue(i, gEnSureUid).ToString().Trim().ToLower() == "l")
                    {
                        sSQL = "delete UFDLImport..WorkPlanDetail where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sErr = sErr + "��" + (i + 1) + " ����" + gridView1.GetRowCellValue(i, gEnSureUid).ToString() + "ȷ�ϣ���������ɾ��\n";
                        continue;
                    }
                    if (radioButton1.Checked)
                    {
                        sSQL = "delete UFDLImport..WorkPlanDetail where ID = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                        aList.Add(sSQL);
                    }
                }

            }

            if (iCount == 0)
            {
                MessageBox.Show("��ѡ����Ҫɾ��������");
                return;
            }

            if (MessageBox.Show("ɾ��ѡ�е�" + iCount.ToString() + "��ô��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
            {
                return;
            }

            if (sErr.Trim() != "")
            {
                FrmMsgBox fMsgBox = new FrmMsgBox();
                fMsgBox.Text = "����";
                fMsgBox.richTextBox1.Text = sErr;
                fMsgBox.ShowDialog();
                return;
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                btnSel();
            }
        }

        private void btnSel()
        {
            string sSQL = "select '' as bChoose,w.sOrder as SoCode,wd.ID,a.wdiQty,wd.WorkTime,w.cinvcode2,isnull(w.dtmPlan,'1900-1-1') as dtmPlan,isnull(w.bRDIn,0) as bRDIn,w.vchrPer,w.vchrEquipment,w.GUID ,w.AutoID,WorkOrderID,WorkOrderNO,WorkOrderRowNO,w.cInvCode,i.cInvName,i.cInvStd,wd.workDepmentNext2,isnull(w.iQuantity,0) as iQuantity,workProcedure,wp.fName as workProcedureName,workProcedureNext,(isnull(wd.QtyRDIn,0) +isnull(wd.QtyRDL,0)) as QtyNow,wd.QtyRDIn,wd.QtyRDL, " +
                        "	wp2.fName as workProcedureNextName,w.workDepment,wDep.fName,dtmDay as dtm1,i.iSupplyType,isnull(i.cDefWareHouse,'') as cDefWareHouse,'0F' as RdOutWh,'' as RdInCode,'' as RdID,wd.RDInType,cast(null as varchar(5)) as RdTrans,'��' as RDInTrans " +
                        "   ,wd.LZWorkOrder,wd.LZWorkNo,wd.AllocateId,wd.EnSureUid,wd.EnSureDate,wd.AuditUid,wd.AuditDate " +
                        "from UFDLImport..WorkPlan w inner join UFDLImport..WorkPlanDetail wd on w.Guid = wd.GuidHead  " +
                        "	left join @u8.Inventory i on i.cInvcode = w.cInvCode " +
                        "   left join UFDLImport..WorkDepment wDep on wDep.FCode = w.workDepment 	" +
                        "   left join UFDLImport..WorkingProcedure wp on wp.fCode = w.workProcedure " +
                        "   left join UFDLImport..WorkingProcedure wp2 on wp2.fCode = w.workProcedureNext    " +
                        "   left join (select GuidHead,sum(iQuantity) as wdiQty from UFDLImport..WorkPlanDetail group by GuidHead)a on a.GuidHead = w.Guid 	" +
                        "where  isnull(EnSureUid,'') <> 'system' and w.AccID='200' and w.AccYear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and isnull(bRDIn,0) <> 0 ";
            if (sDepInfo != "�ֿ�")
            {
                sSQL = sSQL + " and wd.workDepmentNext2 = '" + sDepInfo + "' ";
            }
            if (radioButton1.Checked)
            {
                sSQL = sSQL + " and isnull(w.bClose,0) = 0 and  isnull(wd.bClose,0) = 0 and isnull(EnSureUid,'') = '' ";
            }
            if (radioButton2.Checked)
            {
                sSQL = sSQL + " and isnull(w.bClose,0) = 0 and  isnull(wd.bClose,0) = 0 and isnull(EnSureUid,'') <> ''  and isnull(AuditUid,'') = '' ";
            }
            if (radioButton3.Checked)
            {
                sSQL = sSQL + " and isnull(w.bClose,0) = 0 and  isnull(wd.bClose,0) = 0 and isnull(AuditUid,'') <> '' ";
            }
            if (radioButton4.Checked)
            {
                sSQL = sSQL + " and (isnull(w.bClose,0) = 1 or  isnull(wd.bClose,0) = 1) ";
            }

            sSQL = sSQL + " order by wd.id,w.AutoID ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["workDepment"] = sDepU8Info(dt.Rows[i]["workDepment"].ToString().Trim());
                dt.Rows[i]["workDepmentNext2"] = sDepU8Info(dt.Rows[i]["workDepmentNext2"].ToString().Trim());
            }

            gridControl1.DataSource = dt;

            chkAll.Checked = false;
        }

        /// <summary>
        /// ����U8������ϵͳ�Ĳ��Ŷ�Ӧ��Ϣ
        /// </summary>
        /// <param name="sDep"></param>
        /// <returns></returns>
        private string sDepU8Info(string sDep)
        {
            string sDepU8Name = "";
            switch (sDep)
            {
                case "��ѹ��": sDepU8Name = "��ѹ"; break;
                case "������": sDepU8Name = "�纸"; break;
                case "��ѹ": sDepU8Name = "��ѹ"; break;
                case "����ѹ": sDepU8Name = "��ѹ"; break;
                case "�纸��": sDepU8Name = "�纸"; break;
                case "����": sDepU8Name = ""; break;
                case "�����": sDepU8Name = ""; break;
                case "������": sDepU8Name = "����"; break;
                case "Ʒ�ܲ�": sDepU8Name = "Ʒ��"; break;
                case "������": sDepU8Name = "������"; break;
                case "ά����": sDepU8Name = "ά����"; break;
                case "ί�ⲿ": sDepU8Name = "ί�ⲿ"; break;
                case "��ز�": sDepU8Name = "ί�ⲿ"; break;
                case "�з���": sDepU8Name = "�з�"; break;
                case "��װ": sDepU8Name = "��װ"; break;
                case "��װ��": sDepU8Name = "��װ"; break;
                case "�ɹ���": sDepU8Name = "�ɹ�"; break;
                case "���ܲ�": sDepU8Name = "���ܲ�"; break;
                case "����/���²�": sDepU8Name = "����"; break;
                case "����": sDepU8Name = "����"; break;
                case "������": sDepU8Name = "����"; break;
                case "������": sDepU8Name = "����--ͣ��"; break;
                case "�칫��": sDepU8Name = "����"; break;

                default: sDepU8Name = sDep; break;
            }
            return sDepU8Name;
        }

        private void btnDelRow()
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                gridView1.DeleteRow(iRow);
            }
            catch { }
        }

        private void btnAudit()
        {
            try
            {
                DateTime dtm1 = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                if (!radioButton2.Checked)
                {
                    MessageBox.Show("��ѡ����ȷ���б������˲�����");
                    return;
                }

                ArrayList aList = new ArrayList();
                string sSQL = "";
                string sErr = "";
                string sInfo = "";
                bool bTran = false;                      //�Ƿ�������ת��������ͷ

                bool bCreateRDIn = false;
                long iRdID = 0;
                long iRdIDDetail = 0;
                long iRdInCode = 0;
                long iRdOutCode = 0;
                long iRdOtherInCode = 0;
                long iRdOtherOutCode = 0;
                long iTrID = 0;
                long iTrID2 = 0;
                long iTrIDDetail = 0;
                long iTrCode = 0;
                string sTrCode1 = "";
                dtm1 = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate);
                if (dtm1 < Convert.ToDateTime("2000-1-1"))
                {
                    dtm1 = DateTime.Today;
                }

                if (MessageBox.Show("�ɿ⹤���Ƿ����ɲ���Ʒ��ⵥ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    int iYear = int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                    int iYear2 = int.Parse(dtm1.ToString("yyyy"));
                    if (iYear >= iYear2)
                    {
                        sSQL = "select * from @u8.GL_mend where iperiod = month('" + dtm1 + "')";
                        DataTable dttemp1 = clsSQLCommond.ExecQuery(sSQL);
                        if (Convert.ToBoolean(dttemp1.Rows[0]["bflag_ST"]) == true)
                        {
                            MessageBox.Show("���¿������ѽ��ʣ�����¼�����ݣ�");
                            return;
                        }
                    }
                    bCreateRDIn = true;

                    GetID("rd", out iRdID, out iRdIDDetail);
                    //����Ʒ��ⵥ��
                    sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0411'  and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
                    DataTable dtCode = clsSQLCommond.ExecQuery(sSQL);
                    iRdInCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);
                    //���ϳ��ⵥ��
                    sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412'  and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
                    dtCode = clsSQLCommond.ExecQuery(sSQL);
                    iRdOutCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);
                    //������ⵥ��
                    sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0301'   and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
                    dtCode = clsSQLCommond.ExecQuery(sSQL);
                    iRdOtherInCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);
                    //�������ⵥ��
                    sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0302'   and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
                    dtCode = clsSQLCommond.ExecQuery(sSQL);
                    iRdOtherOutCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);

                    GetID("tr", out iTrID, out iTrIDDetail);
                    sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0304'  and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
                    dtCode = clsSQLCommond.ExecQuery(sSQL);
                    iTrCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);
                }
                else
                {
                    return;
                }
                
                string s���������� = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "")
                        continue;

                    if (s���������� == "")
                    {
                        s���������� = "'" + gridView1.GetRowCellValue(i, gridColWorkOrderNO).ToString().Trim() + "'";
                    }
                    else
                    {
                        s���������� = s���������� + ",'" + gridView1.GetRowCellValue(i, gridColWorkOrderNO).ToString().Trim() + "'";
                    }
                }

                sSQL = @"
select a.MoId,a.MoCode,b.WhCode as WorkWhCode,b.MoDId,b.SortSeq,b.InvCode as cInvCode,b.Qty,isnull(b.QualifiedInQty,0) as QualifiedInQty,b.AuxQty as MDAuxQty,b.ChangeRate as MDChangeRate,b.AuxUnitCode as MDAuxUnitCode,
    cast(null as decimal(16,6)) as QtyNow,isnull(g.fInExcess,0) as fInExcess,b.MDeptCode,b.WIPType, 
    b.CostItemCode,b.CostItemName,b.SoCode,b.SoDId,b.SoSeq 
from @u8.mom_order a inner join @u8.mom_orderdetail b on b.MoId = a.MoId 
	inner join @u8.mom_morder c on c.MoDId= b.MoDId 
	left join (select distinct WorkOrderNo,cInvCode,max(dtmPlan)as dtmPlan from UFDLImport.dbo.WorkPlan where WorkOrderNo in (111111) group by WorkOrderNo,cInvCode) e on e.WorkOrderNo = a.MoCode and e.cInvCode = b.InvCode 
    left join @u8.Inventory g on g.cInvCode = b.InvCode 
where b.Status = 3 and a.mocode in (111111)
order by e.dtmPlan,c.StartDate,a.CreateDate 
";
                sSQL = sSQL.Replace("111111", s����������);
                DataTable dtWorkOrder = clsSQLCommond.ExecQuery(sSQL);
                //�������������ϸ��Ϣ����������������
                sSQL = @"
select a.MoId,a.MoCode,b.WhCode as WorkWhCode,b.MoDId,b.SortSeq,b.InvCode as cInvCode,b.Qty,isnull(b.QualifiedInQty,0) as QualifiedInQty,b.AuxQty as MDAuxQty,b.ChangeRate as MDChangeRate,b.AuxUnitCode as MDAuxUnitCode,
    cast(null as decimal(16,6)) as QtyNow,isnull(g.fInExcess,0) as fInExcess,b.MDeptCode,d.WIPType, 
    b.CostItemCode,b.CostItemName,b.SoCode,b.SoDId,b.SoSeq,d.AllocateId,d.InvCode,h.cInvName as InvName,isnull(d.TransQty,0) as TransQty,f.WIPType as bomWIPType, 
    h.cDefWareHouse as cDefWHCode,isnull(i.iQuantity,0) as iCurrQty,isnull(i.iNum,0) as iCurrNum,isnull(j.iQuantity,0) as i01CurrQty,isnull(j.iNum,0) as i01CurrNum,d.qty/b.qty as useQty,d.ChangeRate,d.AuxUnitCode,d.OpSeq,isnull(d.IssQty,0) as IssQty,isnull(h.cInvDefine12,0) as cInvDefine12 
from @u8.mom_order a inner join @u8.mom_orderdetail b on b.MoId = a.MoId 
    inner join @u8.mom_morder c on c.MoDId= b.MoDId 
    inner join @u8.mom_moallocate d on d.MoDId = b.MoDId 
    left join (select distinct WorkOrderNo,cInvCode,max(dtmPlan)as dtmPlan from UFDLImport.dbo.WorkPlan where WorkOrderNo in (111111) group by WorkOrderNo,cInvCode) e on e.WorkOrderNo = a.MoCode and e.cInvCode = b.InvCode 
    left join @u8.bom_opcomponentopt f on f.OptionsId = d.OpComponentId
    left join @u8.Inventory g on g.cInvCode = b.InvCode 
    left join @u8.Inventory h on h.cInvCode = d.InvCode 
    left join (select cWhCode,cInvCode,isnull(sum(iQuantity),0) as iQuantity,isnull(sum(iNum),0) as iNum from @u8.CurrentStock group by cWhCode,cInvCode) i on i.cWhCode = '0F' and i.cInvCode = d.InvCode 
    left join (select cWhCode,cInvCode,isnull(sum(iQuantity),0) as iQuantity,isnull(sum(iNum),0) as iNum from @u8.CurrentStock group by cWhCode,cInvCode) j on j.cWhCode = '01' and j.cInvCode = d.InvCode 
where b.Status = 3 and a.mocode in (111111)
order by e.dtmPlan,c.StartDate,a.CreateDate
";

                sSQL = sSQL.Replace("111111", s����������);
                DataTable dtWorkOrderDetail = clsSQLCommond.ExecQuery(sSQL);

                //gridView1ѭ��
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                    {
                        if (gridView1.GetRowCellValue(i, gridColQtyRDL).ToString().Trim() != "" && Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColQtyRDL)) != 0 && gridView1.GetRowCellValue(i, gridColRDTrans).ToString().Trim() != "��")
                        {
                            sErr = sErr + " �� " + (i + 1) + " ����ת��������δȷ����ת��Ӧ������������˲飡\n";
                            continue;
                        }

                        sSQL = "select * from @u8.TransVouch  where 1=-1";
                        DataTable dtTransVouch = clsSQLCommond.ExecQuery(sSQL);
                        DataTable dtTransVouch2 = clsSQLCommond.ExecQuery(sSQL);
                        DataTable dtTransVouch3 = clsSQLCommond.ExecQuery(sSQL);
                        sSQL = "select * from @u8.TransVouchs where 1=-1";
                        DataTable dtTransVouchs = clsSQLCommond.ExecQuery(sSQL);
                        DataTable dtTransVouchs2 = clsSQLCommond.ExecQuery(sSQL);
                        DataTable dtTransVouchs3 = clsSQLCommond.ExecQuery(sSQL);

                        //�ɿ⹤���Ƿ����ɲ���Ʒ��ⵥ��ѡ������������ݲ�ִ��
                        //sSQL = " update WorkPlanDetail set AuditUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',AuditDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where id = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                        //aList.Add(sSQL);

                        if (bCreateRDIn)
                        {
                            //if (gridView1.GetRowCellValue(i,gridColInvCode).ToString().Trim() == "")
                            //{
                            //    if (MessageBox.Show("ĸ������Ϊ�գ��Ƿ������", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                            //    {
                            //        throw new Exception("������ĸ�����룡");
                            //    }
                            //}

                            string sWorkOrder = gridView1.GetRowCellValue(i, gridColWorkOrderNO).ToString().Trim(); //����������
                            string scInvCode = gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim();     //�������ϱ���
                            decimal dQtyNow = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColQtyNow));       //�����������


                            DataRow[] drWorkOrder = dtWorkOrder.Select(" MoCode = '" + sWorkOrder + "' and cInvCode = '" + scInvCode + "' ");
                            if (drWorkOrder.Length < 1)
                            {
                                sErr = sErr + " �� " + (i + 1) + " û�ж�Ӧ�������������ʵ����⣡\n";
                                continue;
                            }
                            string sWorkDep = drWorkOrder[0]["MDeptCode"].ToString().Trim();                                         //����
                            string sWorkWhCode = drWorkOrder[0]["WorkWhCode"].ToString().Trim();                                     //�������ֿ�

                            if (sWorkDep == string.Empty)
                            {
                                sSQL = "select * from @u8.Department where cDepName like '%" + gridView1.GetRowCellValue(i, gridColworkDepment).ToString().Trim() + "%'";
                                DataTable dtDep = clsSQLCommond.ExecQuery(sSQL);
                                if (dtDep != null && dtDep.Rows.Count > 0)
                                {
                                    sWorkDep = dtDep.Rows[0]["cDepCode"].ToString().Trim();
                                }
                                else
                                {
                                    MessageBox.Show("U8ϵͳ��û�в���:" + gridView1.GetRowCellValue(i, gridColworkDepment).ToString().Trim() + " ���ʵ�����");
                                    return;
                                }
                            }

                            #region ���ɲ���Ʒ��ⵥ�����ϳ��ⵥ��������

                            //����Ʒ��ⵥ��ͷ
                            iRdID += 1;
                            iRdInCode += 1;
                            string sRdInCode = sSetRdInCode(iRdInCode);
                            sSQL = " update UFDLImport.WorkPlanDetail set RDInCode = '" + sRdInCode + "',AuditUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',AuditDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where id = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                            aList.Add(sSQL);

                            long i������ⵥ��ͷid = iRdID;

                            sSQL = "insert into @u8.rdrecord10(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate," +
                                     "ccode,crdcode,cdepcode,cmaker,vt_id," +
                                     "cdefine11,cmpocode,iswfcontrolled,dnmaketime,cpspcode) values " +
                                 "(" + i������ⵥ��ͷid + ",1,N'10',N'��Ʒ���',N'��������',N'" + sWorkWhCode + "',N'" + dtm1 + "'" +
                                     ",N'" + sRdInCode + "',N'104',N'" + sWorkDep + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',63," +
                                     "N'" + drWorkOrder[0]["SoCode"] + "',N'" + sWorkOrder + "',0,  GETDATE(),'" + gridView1.GetRowCellValue(i, gridColcInvCode).ToString().Trim() + "')";
                            aList.Add(sSQL);
                            sInfo = sInfo + " ���ɲ���Ʒ��ⵥ " + sRdInCode + "\n";


                            //����Ʒ��ⵥ����
                            decimal dQty = 0;                                   //��������
                            decimal dQualifiedInQty = 0;                        //�������������
                            decimal dNeedQty = 0;                               //����δ�������
                            decimal dfInExcess = 0;                             //���������ٷֱ�
                            for (int j = 0; j < drWorkOrder.Length; j++)
                            {
                                dQty = dQty + Convert.ToDecimal(drWorkOrder[j]["Qty"]);
                                dQualifiedInQty = dQualifiedInQty + Convert.ToDecimal(drWorkOrder[j]["QualifiedInQty"]);
                                dfInExcess = Convert.ToDecimal(drWorkOrder[j]["fInExcess"]);
                            }
                            dNeedQty = dQty - dQualifiedInQty;
                            if (dQty * (1 + dfInExcess) < dQualifiedInQty + dQtyNow)
                            {
                                sErr = sErr + " �� " + (i + 1) + " ��������������⣬���ʵ�����";
                                continue;
                            }
                            else
                            {
                                decimal dQtyNowRow = 0;                        //���α����������
                                decimal dNumNowRow = 0;                        //���α���������
                                bool bCloseWork = false;                       //�Ƿ�رն���
                                for (int j = 0; j < drWorkOrder.Length; j++)
                                {
                                    dQty = Convert.ToDecimal(drWorkOrder[j]["Qty"]);
                                    dQualifiedInQty = Convert.ToDecimal(drWorkOrder[j]["QualifiedInQty"]);
                                    dNeedQty = dQty - dQualifiedInQty;
                                    dfInExcess = Convert.ToDecimal(drWorkOrder[j]["fInExcess"]);
                                    if (dQtyNow <= 0)
                                    {
                                        continue;
                                    }
                                    if (dNeedQty >= dQtyNow)
                                    {
                                        dQtyNowRow = dQtyNow;
                                        dQtyNow = 0;
                                        if (dNeedQty > dQtyNow)
                                        {
                                            bCloseWork = false;
                                        }
                                        else
                                        {
                                            bCloseWork = true;
                                        }
                                    }
                                    else
                                    {
                                        if (j == drWorkOrder.Length - 1)
                                        {
                                            dQtyNowRow = dQtyNow;
                                            dQtyNow = 0;
                                            bCloseWork = true;
                                        }
                                        else
                                        {
                                            dQtyNowRow = dNeedQty;
                                            dQtyNow = dQtyNow - dNeedQty;
                                            bCloseWork = true;
                                        }
                                    }

                                    sSQL = "select top 1 iQuantity,iNquantity,(isnull(iNquantity,0)-isnull(iQuantity,0)) as iQty,* " +
                                           "from @u8.rdrecords10 rs left join @u8.rdrecord10 r on r.id = rs.id " +
                                           " where cmocode='" + sWorkOrder + "' and cInvCode = '" + scInvCode + "' " +
                                           "order by autoid desc";
                                    DataTable dtTemp4 = clsSQLCommond.ExecQuery(sSQL);
                                    string sNQty = "0";
                                    if (dtTemp4.Rows.Count > 0)
                                    {
                                        sNQty = dtTemp4.Rows[0]["iQty"].ToString().Trim();
                                        if (Convert.ToDouble(sNQty) < 0)
                                        {
                                            //����sNQtyΪ0�д���֤��������ʹ���ݱ�ɺ��֣�
                                            sNQty = "0";
                                        }
                                    }

                                    iRdIDDetail += 1;
                                    sSQL = "Insert Into @u8.rdrecords10(autoid,id,cinvcode,iquantity," +
                                              "impoids,brelated,iordertype," +
                                              "bcosting,iordercode,corufts,cmocode," +
                                              "imoseq,isodid,isotype,csocode,isoseq,inquantity,cdefine24) " +
                                          "Values (" + iRdIDDetail + "," + i������ⵥ��ͷid + ",N'" + scInvCode + "'," + dQtyNowRow + "," +
                                              "" + drWorkOrder[j]["MoDId"] + ",0,1," +
                                              "1,N'" + drWorkOrder[j]["SoCode"] + "',N'1653.4411',N'" + drWorkOrder[j]["MoCode"] + "'," +
                                              "" + drWorkOrder[j]["SortSeq"] + ",N'" + drWorkOrder[j]["SoDId"] + "',1,N'" + drWorkOrder[j]["SoCode"] + "','" + drWorkOrder[j]["SoSeq"] + "'," + sNQty + ",'" + gridView1.GetRowCellValue(i, gridColworkProcedureNext).ToString().Trim() + "')";
                                    aList.Add(sSQL);

                                    drWorkOrder[j]["QualifiedInQty"] = Convert.ToDecimal(drWorkOrder[j]["QualifiedInQty"]) + dQtyNowRow;

                                    sSQL = "update  @u8.rdrecords10 set iNum = cast((iQuantity/mD.Qty*AuxQty) as decimal(18, 6)),cAssUnit=i.cAssComUnitCode ,iinvexchrate=cast((mD.Qty/AuxQty) as decimal(18, 6)),iExpiratDateCalcu=0,iNNum=cast((inQuantity/mD.Qty*AuxQty) as decimal(18, 6)) " +
                                            " from  @u8.mom_orderdetail mD inner join  @u8.Inventory I on md.invcode = i.cInvCode " +
                                            "where mD.MoDId = iMPoIds and  autoid = " + iRdIDDetail;
                                    aList.Add(sSQL);

                                    //��ת��Ʒ��⣬����ָ����λ
                                    if (Convert.ToInt32(gridView1.GetRowCellValue(i, gridColRDInType)) == 2)
                                    {
                                        sSQL = "select isnull(bWhPos,0) as bWhPos from @u8.Warehouse  where cWhCode = '" + sWorkWhCode + "'";
                                        DataTable dtWhPos = clsSQLCommond.ExecQuery(sSQL);
                                        if (dtWhPos != null && Convert.ToBoolean(dtWhPos.Rows[0]["bWhPos"]))
                                        {
                                            sSQL = "select * from @u8.Inventory  where cInvCode = '" + scInvCode + "'";
                                            DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);
       
                                            sSQL = "Insert Into @u8.InvPosition(rdsid,rdid,cwhcode,cposcode,cinvcode,cbatch,cfree1,cfree2,dvdate,iquantity" +
                                                           ",inum,cmemo,chandler,ddate,brdflag,csource,cfree3,cfree4,cfree5,cfree6" +
                                                           ",cfree7,cfree8,cfree9,cfree10,cassunit,cbvencode,itrackid,dmadedate,imassdate,cmassunit" +
                                                           ",cvmivencode,iexpiratdatecalcu,cexpirationdate,dexpirationdate) " +
                                                       "Values (" + iRdIDDetail + ",N'" + i������ⵥ��ͷid + "',N'" + sWorkWhCode + "',N'" + dtInv.Rows[0]["cPosition"].ToString().Trim() + "',N'" + scInvCode + "',Null,Null,Null,Null," + dQtyNowRow + " " +
                                                           ",null,Null,N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',N'" + dtm1.ToString("yyyy-MM-dd") + "',0,Null,Null,Null,Null,Null" +
                                                           ",Null,Null,Null,Null,N'" + dtInv.Rows[0]["cAssComUnitCode"].ToString().Trim() + "',Null,Null,Null,Null,Null" +
                                                           ",Null,0,Null,Null)";
                                            aList.Add(sSQL);

                                            sSQL = "update @u8.InvPosition set inum = b.iNum from @u8.rdrecords b where b.autoid = @u8.InvPosition.rdsid and b.autoid = " + iRdIDDetail;
                                            aList.Add(sSQL);
                                        }
                                    }

                                    //�����ִ���
                                    sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + scInvCode + "' and cWhCode = '" + sWorkWhCode + "') " +
                                           "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + dQtyNowRow + "  where cInvCode = '" + scInvCode + "' and cWhCode = '" + sWorkWhCode + "' " +
                                           "else " +
                                               "begin " +
                                                   "declare @itemid varchar(20); " +
                                                   "declare @iCount int;  " +
                                                   "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + scInvCode + "';   " +
                                                   "if( @iCount > 0 ) " +
                                                   "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + scInvCode + "';  " +
                                                   "else  " +
                                                   "	select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                                   "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + sWorkWhCode + "','" + scInvCode + "'," + dQtyNowRow + ",@itemid) " +
                                               "end";
                                    aList.Add(sSQL);

                                    //1. �޸����������������   
                                    sSQL = "update @u8.mom_orderdetail  set QualifiedInQty = isnull(QualifiedInQty,0) + " + dQtyNowRow + " where MoDId = " + drWorkOrder[j]["MoDId"];
                                    aList.Add(sSQL);

                                    if (bCloseWork)
                                    {
                                        //2. �����Ѿ���ȫ��⣬�رն���
                                        sSQL = "update @u8.mom_orderdetail set Status = 4,CloseTime = '" + dtm1.ToString("yyyy-MM-dd") + "',CloseUser = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',OrgClsTime = '" + dtm1 + "',CloseDate = '" + dtm1 + "',OrgClsDate = '" + dtm1 + "' " +
                                          "where modid = " + drWorkOrder[j]["MoDId"];
                                        aList.Add(sSQL);
                                    }


                                    #region ���ϳ��ⵥ��һ�в�Ʒ�������һ�Ų��ϳ��ⵥ�����������Ӽ���
                                    
                                    //���ϳ��ⵥ��ͷ
                                    DataRow[] drWorkOrderDetail = dtWorkOrderDetail.Select(" MoDId = '" + drWorkOrder[j]["MoDId"] + "' and ((WIPType =5 and  (bomWIPType =1 or bomWIPType =2)) or WIPType =1 or WIPType =2)");
                                    if (drWorkOrderDetail.Length <= 0)
                                    {
                                        continue;
                                    }
                                    iRdOutCode += 1;
                                    string sRdOutCode = sSetRdOutCode(iRdOutCode);
                                    iRdID += 1;

                                    sSQL = "insert into @u8.rdrecord11(id,brdflag,cvouchtype,cbustype,csource,cbuscode,cwhcode,ddate," +
                                            "ccode,crdcode,cdepcode,cmaker,vt_id,bisstqc,cpspcode,cmpocode," +
                                            "biscomplement,iswfcontrolled,dnmaketime,dnmodifytime,dnverifytime,bmotran) " +
                                            "values (" + iRdID + ",0,N'11',N'��������',N'����Ʒ��ⵥ',N'" + sRdInCode + "',N'0F',N'" + dtm1 + "'," +
                                            "N'" + sRdOutCode + "',N'201',N'" + sWorkDep + "',N'" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',65,0,N'" + scInvCode + "',N'" + sWorkOrder + "'," +
                                            "0,0,  GETDATE(), Null , Null ,N'')";
                                    aList.Add(sSQL);
                                    sSQL = " update UFDLImport..WorkPlanDetail set RDOutCode = RDOutCode + '," + sRdOutCode + "' where id = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                                    aList.Add(sSQL);
                                    sInfo = sInfo + " ���ɲ��ϳ��ⵥ " + sRdOutCode + "\n";
                            
                                    //���ϳ��ⵥ���壬���ݲ���Ʒ��ⵥ����ϸ����չ�����ϳ��ⵥ�����������Ӽ���
                                    //�������������Ӽ�ѭ��
                                    for (int k = 0; k < drWorkOrderDetail.Length; k++)
                                    {
                                        bool bQtyOrNum = true;
                                        try
                                        {
                                            if (Convert.ToInt64(drWorkOrderDetail[k]["cInvDefine12"]) != 0)
                                            {
                                                bQtyOrNum = false;
                                            }
                                        }
                                        catch { }

                                        decimal d1 = 0;     //����
                                        decimal d2 = 0;     //����

                                        d1 = dQtyNowRow * Convert.ToDecimal(drWorkOrderDetail[k]["useQty"]);        //���ϳ�������=��ǰ����Ʒ��ⵥ����*ʹ������
                                        d1 = decimal.Round(d1, 6);
                                        d2 = 0;
                                        if (drWorkOrderDetail[k]["ChangeRate"] != null && drWorkOrderDetail[k]["ChangeRate"].ToString().Trim() != "")
                                        {
                                            d2 = d1 / Convert.ToDecimal(drWorkOrderDetail[k]["ChangeRate"]);
                                            d2 = decimal.Round(d2, 6);
                                        }
                                        
                                        string sd2 = "";
                                        if (d2 == 0)
                                        {
                                            sd2 = "null";
                                        }
                                        else
                                        {
                                            sd2 = d2.ToString();
                                        }
                                        iRdIDDetail += 1;
                                        string sChangeRate = "null";
                                        if (drWorkOrderDetail[k]["ChangeRate"].ToString().Trim() != "")
                                        {
                                            sChangeRate = drWorkOrderDetail[k]["ChangeRate"].ToString().Trim();
                                        }
                                        sSQL = "Insert Into @u8.rdrecords11(autoid,id,cinvcode,inum,iquantity," +
                                                 "cassunit,impoids,bcosting,bvmiused,iinvexchrate," +
                                                 "corufts,cmocode,invcode,imoseq,iopseq," +
                                                 "iexpiratdatecalcu,isotype) " +
                                            "Values (" + iRdIDDetail + "," + iRdID + ",N'" + drWorkOrderDetail[k]["InvCode"] + "'," + sd2 + "," + d1 + "," +
                                                 "N'" + drWorkOrderDetail[k]["AuxUnitCode"].ToString().Trim() + "'," + drWorkOrderDetail[k]["AllocateId"].ToString().Trim() + ",1,0," + sChangeRate + "," +
                                                 "N'2969.6763',N'" + sWorkOrder + "',N'" + scInvCode + "'," + drWorkOrderDetail[k]["SortSeq"].ToString().Trim() + ",N'" + drWorkOrderDetail[k]["OpSeq"] + "'," +
                                                 "0,0)";
                                        aList.Add(sSQL);

                                        drWorkOrderDetail[k]["iCurrQty"] = Convert.ToDecimal(drWorkOrderDetail[k]["iCurrQty"]) - d1;
                                        if (sd2.ToLower() != "null" && drWorkOrderDetail[k]["iCurrNum"] != null && drWorkOrderDetail[k]["iCurrNum"].ToString().Trim() != "")
                                        {
                                            drWorkOrderDetail[k]["iCurrNum"] = Convert.ToDecimal(drWorkOrderDetail[k]["iCurrNum"]) - d2;
                                        }

                                        //--�����ִ���
                                        sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + drWorkOrderDetail[k]["InvCode"] + "' and cWhCode = '0F') " +
                                               "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + d1 + ",iNum = isnull(iNum,0) + " + d2 + "  where cInvCode = '" + drWorkOrderDetail[k]["InvCode"] + "' and cWhCode = '0F' " +
                                               "else " +
                                                   "begin " +
                                                   "    declare @itemid varchar(20); " +
                                                         "declare @iCount int;  " +
                                                           "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + drWorkOrderDetail[k]["InvCode"] + "';   " +
                                                           "if( @iCount > 0 ) " +
                                                           "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + drWorkOrderDetail[k]["InvCode"] + "';  " +
                                                           "else  " +
                                                           "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                                           "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('0F','" + drWorkOrderDetail[k]["InvCode"] + "'," + d1 + "," + d2 + ",@itemid) " +
                                                   "end";
                                        aList.Add(sSQL);

                                        //�������������Ӽ�����
                                        sSQL = "update @u8.mom_moallocate set IssQty = IssQty + " + d1 + " where AllocateId = " + drWorkOrderDetail[k]["AllocateId"];
                                        aList.Add(sSQL);

                                        if (gridView1.GetRowCellDisplayText(i, gridColRDInTrans).ToString().Trim() == "��")
                                        {
                                            if (Convert.ToDecimal(drWorkOrderDetail[k]["TransQty"]) - Convert.ToDecimal(drWorkOrderDetail[k]["IssQty"]) < d1)
                                            {
                                                #region �ֳ��ֿ�����������㣬�������������ɿ�棬�����������Ӧ����

                                                //�ѵ���δʹ������
                                                decimal dUnTransQty = Convert.ToDecimal(drWorkOrderDetail[k]["TransQty"]) - Convert.ToDecimal(drWorkOrderDetail[k]["IssQty"]);
                                                if (dUnTransQty <= 0)
                                                    dUnTransQty = 0;
                                                decimal dDTQty = d1 - dUnTransQty;     //��Ҫ����������

                                                if (Convert.ToDecimal(drWorkOrderDetail[k]["iCurrQty"]) < dDTQty)
                                                {
                                                    //dDTQty = d1 - Convert.ToDecimal(drWorkOrderDetail[k]["iCurrQty"]);
                                                    sErr = sErr + " �� " + (i + 1) + " �ֳ������ϲ��㣬���ܵ���!\n";
                                                    continue;
                                                }
                                                else
                                                {
                                                    //�������
                                                    //if (k == 0)
                                                    //{
                                                    #region �����������ͷ

                                                    DataRow drTransVouch = dtTransVouch3.NewRow();
                                                    if (dtTransVouch3 == null || dtTransVouchs3.Rows.Count == 0)
                                                    {
                                                        iTrCode += 1;
                                                        sTrCode1 = sSetTransVouchCode(iTrCode);
                                                        iTrID += 1;
                                                        drTransVouch["cTVCode"] = sTrCode1;
                                                        drTransVouch["dTVDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                                        drTransVouch["cOWhCode"] = "01";
                                                        drTransVouch["cIWhCode"] = "0F";
                                                        drTransVouch["cODepCode"] = GetDepCode(gridView1.GetRowCellValue(i, gridColworkDepment).ToString().Trim());
                                                        drTransVouch["cIDepCode"] = GetDepCode(gridView1.GetRowCellValue(i, gridColworkDepment).ToString().Trim());
                                                        drTransVouch["cPersonCode"] = DBNull.Value;
                                                        drTransVouch["cIRdCode"] = 113;
                                                        drTransVouch["cORdCode"] = 213;
                                                        drTransVouch["cTVMemo"] = DBNull.Value;
                                                        drTransVouch["cDefine1"] = DBNull.Value;
                                                        drTransVouch["cDefine2"] = DBNull.Value;
                                                        drTransVouch["cDefine3"] = DBNull.Value;
                                                        drTransVouch["cDefine4"] = DBNull.Value;
                                                        drTransVouch["cDefine5"] = DBNull.Value;
                                                        drTransVouch["cDefine6"] = DBNull.Value;
                                                        drTransVouch["cDefine7"] = DBNull.Value;
                                                        drTransVouch["cDefine8"] = DBNull.Value;
                                                        drTransVouch["cDefine9"] = DBNull.Value;
                                                        drTransVouch["cDefine10"] = DBNull.Value;
                                                        drTransVouch["cAccounter"] = DBNull.Value;
                                                        drTransVouch["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                                                        drTransVouch["iNetLock"] = 0;
                                                        drTransVouch["ID"] = iTrID;
                                                        drTransVouch["VT_ID"] = 89;
                                                        drTransVouch["cVerifyPerson"] = DBNull.Value;
                                                        drTransVouch["dVerifyDate"] = DBNull.Value;
                                                        drTransVouch["cPSPCode"] = gridView1.GetRowCellValue(i, gridColInvCode);
                                                        drTransVouch["cMPoCode"] = DBNull.Value;
                                                        drTransVouch["iQuantity"] = DBNull.Value;
                                                        drTransVouch["bTransFlag"] = DBNull.Value;
                                                        drTransVouch["cDefine11"] = DBNull.Value;
                                                        drTransVouch["cDefine12"] = DBNull.Value;
                                                        drTransVouch["cDefine13"] = DBNull.Value;
                                                        drTransVouch["cDefine14"] = DBNull.Value;
                                                        drTransVouch["cDefine15"] = DBNull.Value;
                                                        drTransVouch["cDefine16"] = DBNull.Value;
                                                        //drTransVouch["ufts"] = DBNull.Value;
                                                        drTransVouch["iproorderid"] = DBNull.Value;
                                                        drTransVouch["cOrderType"] = "��������";
                                                        drTransVouch["cTranRequestCode"] = DBNull.Value;
                                                        drTransVouch["cVersion"] = DBNull.Value;
                                                        drTransVouch["BomId"] = DBNull.Value;
                                                        drTransVouch["cFree1"] = DBNull.Value;
                                                        drTransVouch["cFree2"] = DBNull.Value;
                                                        drTransVouch["cFree3"] = DBNull.Value;
                                                        drTransVouch["cFree4"] = DBNull.Value;
                                                        drTransVouch["cFree5"] = DBNull.Value;
                                                        drTransVouch["cFree6"] = DBNull.Value;
                                                        drTransVouch["cFree7"] = DBNull.Value;
                                                        drTransVouch["cFree8"] = DBNull.Value;
                                                        drTransVouch["cFree9"] = DBNull.Value;
                                                        drTransVouch["cFree10"] = DBNull.Value;
                                                        drTransVouch["cAppTVCode"] = DBNull.Value;
                                                        drTransVouch["csource"] = 1;
                                                        drTransVouch["itransflag"] = "����";
                                                        drTransVouch["cModifyPerson"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                                                        drTransVouch["dModifyDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                                        drTransVouch["dnmaketime"] = Get��ǰ������ʱ��();
                                                        drTransVouch["dnmodifytime"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                                        drTransVouch["dnverifytime"] = DBNull.Value;
                                                        drTransVouch["ireturncount"] = 0;
                                                        drTransVouch["iverifystate"] = 0;
                                                        drTransVouch["iswfcontrolled"] = 0;
                                                    }
                                                    #endregion
                                                    //}
                                                    #region �������������

                                                    DataRow drTransVouchs = dtTransVouchs3.NewRow();
                                                    //*Convert.ToDecimal(drWorkOrderDetail[k]["ChangeRate"]);
                                                    //d2 = decimal.Round(d2, 6);

                                                    if (dtTransVouch3 == null || dtTransVouch3.Rows.Count == 0)
                                                    {
                                                        drTransVouchs["cTVCode"] = sTrCode1;
                                                        drTransVouchs["ID"] = iTrID;
                                                    }
                                                    else
                                                    {
                                                        drTransVouchs["cTVCode"] = dtTransVouch3.Rows[0]["cTVCode"];
                                                        drTransVouchs["ID"] = dtTransVouch3.Rows[0]["ID"];
                                                    }

                                                    drTransVouchs["cInvCode"] = drWorkOrderDetail[k]["InvCode"];
                                                    drTransVouchs["RdsID"] = DBNull.Value;
                                                    drTransVouchs["iTVQuantity"] = dDTQty;
                                                    if (drWorkOrderDetail[k]["ChangeRate"] != null && drWorkOrderDetail[k]["ChangeRate"].ToString().Trim() != "")
                                                    {
                                                        decimal iTVNum = dDTQty / Convert.ToDecimal(drWorkOrderDetail[k]["ChangeRate"]);
                                                        drTransVouchs["iTVNum"] = decimal.Round(iTVNum, 6);
                                                        drTransVouchs["iinvexchrate"] = drWorkOrderDetail[k]["ChangeRate"];
                                                        drTransVouchs["cAssUnit"] = drWorkOrderDetail[k]["AuxUnitCode"];
                                                    }
                                                    drTransVouchs["iTVACost"] = DBNull.Value;
                                                    drTransVouchs["iTVAPrice"] = DBNull.Value;
                                                    drTransVouchs["iTVPCost"] = DBNull.Value;
                                                    drTransVouchs["iTVPPrice"] = DBNull.Value;
                                                    drTransVouchs["cTVBatch"] = DBNull.Value;
                                                    drTransVouchs["dDisDate"] = DBNull.Value;
                                                    drTransVouchs["cFree1"] = DBNull.Value;
                                                    drTransVouchs["cFree2"] = DBNull.Value;
                                                    drTransVouchs["cDefine22"] = DBNull.Value;
                                                    drTransVouchs["cDefine23"] = DBNull.Value;
                                                    drTransVouchs["cDefine24"] = DBNull.Value;
                                                    drTransVouchs["cDefine25"] = DBNull.Value;
                                                    drTransVouchs["cDefine26"] = DBNull.Value;
                                                    drTransVouchs["cDefine27"] = DBNull.Value;
                                                    drTransVouchs["cItemCode"] = DBNull.Value;
                                                    drTransVouchs["cItem_class"] = DBNull.Value;
                                                    drTransVouchs["fSaleCost"] = 0;
                                                    drTransVouchs["fSalePrice"] = 0;
                                                    drTransVouchs["cName"] = DBNull.Value;
                                                    drTransVouchs["cItemCName"] = DBNull.Value;

                                                    iTrIDDetail += 1;
                                                    drTransVouchs["autoID"] = iTrIDDetail;
                                                    drTransVouchs["iMassDate"] = DBNull.Value;
                                                    drTransVouchs["cBarCode"] = DBNull.Value;
                                                    drTransVouchs["cFree3"] = DBNull.Value;
                                                    drTransVouchs["cFree4"] = DBNull.Value;
                                                    drTransVouchs["cFree5"] = DBNull.Value;
                                                    drTransVouchs["cFree6"] = DBNull.Value;
                                                    drTransVouchs["cFree7"] = DBNull.Value;
                                                    drTransVouchs["cFree8"] = DBNull.Value;
                                                    drTransVouchs["cFree9"] = DBNull.Value;
                                                    drTransVouchs["cFree10"] = DBNull.Value;
                                                    drTransVouchs["cDefine28"] = DBNull.Value;
                                                    drTransVouchs["cDefine29"] = DBNull.Value;
                                                    drTransVouchs["cDefine30"] = DBNull.Value;
                                                    drTransVouchs["cDefine31"] = DBNull.Value;
                                                    drTransVouchs["cDefine32"] = DBNull.Value;
                                                    drTransVouchs["cDefine33"] = DBNull.Value;
                                                    drTransVouchs["cDefine34"] = DBNull.Value;
                                                    drTransVouchs["cDefine35"] = DBNull.Value;
                                                    drTransVouchs["cDefine36"] = DBNull.Value;
                                                    drTransVouchs["cDefine37"] = DBNull.Value;
                                                    drTransVouchs["iMPoIds"] = DBNull.Value;
                                                    drTransVouchs["cBVencode"] = DBNull.Value;
                                                    drTransVouchs["cInVouchCode"] = DBNull.Value;
                                                    drTransVouchs["dMadeDate"] = DBNull.Value;
                                                    drTransVouchs["cMassUnit"] = DBNull.Value;
                                                    drTransVouchs["iTRIds"] = DBNull.Value;
                                                    drTransVouchs["AppTransIDS"] = DBNull.Value;
                                                    drTransVouchs["iSSoType"] = 0;
                                                    drTransVouchs["iSSodid"] = DBNull.Value;
                                                    drTransVouchs["iDSoType"] = 0;
                                                    drTransVouchs["iDSodid"] = DBNull.Value;
                                                    drTransVouchs["bCosting"] = 1;
                                                    drTransVouchs["cvmivencode"] = DBNull.Value;
                                                    drTransVouchs["cinposcode"] = DBNull.Value;
                                                    drTransVouchs["coutposcode"] = DBNull.Value;
                                                    drTransVouchs["iinvsncount"] = DBNull.Value;
                                                    drTransVouchs["comcode"] = DBNull.Value;
                                                    drTransVouchs["cmocode"] = sWorkOrder;
                                                    drTransVouchs["invcode"] = gridView1.GetRowCellValue(i, gridColInvCode);
                                                    drTransVouchs["imoseq"] = drWorkOrderDetail[k]["SortSeq"];
                                                    drTransVouchs["iomids"] = DBNull.Value;
                                                    drTransVouchs["imoids"] = drWorkOrderDetail[k]["MoDId"];
                                                    //drTransVouchs["corufts"] = DBNull.Value;
                                                    drTransVouchs["iExpiratDateCalcu"] = 0;
                                                    drTransVouchs["cExpirationdate"] = DBNull.Value;
                                                    drTransVouchs["dExpirationdate"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty1"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty2"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty3"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty4"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty5"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty6"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty7"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty8"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty9"] = DBNull.Value;
                                                    drTransVouchs["cBatchProperty10"] = DBNull.Value;
                                                    drTransVouchs["cciqbookcode"] = DBNull.Value;

                                                    dtTransVouchs3.Rows.Add(drTransVouchs);

                                                    //���б��嵥��ʱ���ɱ�ͷ
                                                    if (dtTransVouch3 == null || dtTransVouch3.Rows.Count == 0)
                                                    {
                                                        dtTransVouch3.Rows.Add(drTransVouch);
                                                        sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouch", dtTransVouch3, dtTransVouch3.Rows.Count - 1);
                                                        aList.Add(sSQL);
                                                        sInfo = sInfo + " ������������� " + sTrCode1 + "\n";
                                                    }
                                                    //

                                                    sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouchs", dtTransVouchs3, dtTransVouchs3.Rows.Count - 1);
                                                    aList.Add(sSQL);

                                                    sSQL = "update @u8.mom_moallocate set TransQty = isnull(TransQty,0)  + " + d1 + " where AllocateId = " + drWorkOrderDetail[k]["AllocateId"];
                                                    aList.Add(sSQL);

                                                    #endregion

                                                    DataRow[] drWorkOrderDetailDB = dtWorkOrderDetail.Select(" InvCode = '" + drWorkOrderDetail[k]["InvCode"] + "' and TransQty > 0 ");

                                                    #region ���������  ������ϲ��㣬���������������򽫲��ϵ�������ǰ����

                                                    #region �����������ͷ

                                                    DataRow drTransVouch2 = dtTransVouch2.NewRow();
                                                    if (dtTransVouchs2 == null || dtTransVouchs2.Rows.Count == 0)
                                                    {

                                                        iTrCode = iTrCode + 1;
                                                        sTrCode1 = sSetTransVouchCode(iTrCode);
                                                        iTrID = iTrID + 1;
                                                        drTransVouch2["cTVCode"] = sTrCode1;
                                                        drTransVouch2["dTVDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                                        drTransVouch2["ID"] = iTrID;
                                                        drTransVouch2["cOWhCode"] = "0F";
                                                        drTransVouch2["cIWhCode"] = "01";
                                                        drTransVouch2["cODepCode"] = GetDepCode(gridView1.GetRowCellValue(i, gridColworkDepment).ToString().Trim());
                                                        drTransVouch2["cIDepCode"] = GetDepCode(gridView1.GetRowCellValue(i, gridColworkDepment).ToString().Trim());
                                                        drTransVouch2["cPersonCode"] = DBNull.Value;
                                                        drTransVouch2["cIRdCode"] = 113;
                                                        drTransVouch2["cORdCode"] = 213;
                                                        drTransVouch2["cTVMemo"] = DBNull.Value;
                                                        drTransVouch2["cDefine1"] = DBNull.Value;
                                                        drTransVouch2["cDefine2"] = DBNull.Value;
                                                        drTransVouch2["cDefine3"] = DBNull.Value;
                                                        drTransVouch2["cDefine4"] = DBNull.Value;
                                                        drTransVouch2["cDefine5"] = DBNull.Value;
                                                        drTransVouch2["cDefine6"] = DBNull.Value;
                                                        drTransVouch2["cDefine7"] = DBNull.Value;
                                                        drTransVouch2["cDefine8"] = DBNull.Value;
                                                        drTransVouch2["cDefine9"] = DBNull.Value;
                                                        drTransVouch2["cDefine10"] = DBNull.Value;
                                                        drTransVouch2["cAccounter"] = DBNull.Value;
                                                        drTransVouch2["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                                                        drTransVouch2["iNetLock"] = 0;
                                                        drTransVouch2["VT_ID"] = 89;
                                                        drTransVouch2["cVerifyPerson"] = DBNull.Value;
                                                        drTransVouch2["dVerifyDate"] = DBNull.Value;
                                                        drTransVouch2["cPSPCode"] = gridView1.GetRowCellValue(i, gridColInvCode);
                                                        drTransVouch2["cMPoCode"] = DBNull.Value;
                                                        drTransVouch2["iQuantity"] = DBNull.Value;
                                                        drTransVouch2["bTransFlag"] = DBNull.Value;
                                                        drTransVouch2["cDefine11"] = DBNull.Value;
                                                        drTransVouch2["cDefine12"] = DBNull.Value;
                                                        drTransVouch2["cDefine13"] = DBNull.Value;
                                                        drTransVouch2["cDefine14"] = DBNull.Value;
                                                        drTransVouch2["cDefine15"] = DBNull.Value;
                                                        drTransVouch2["cDefine16"] = DBNull.Value;
                                                        //drTransVouch2["ufts"] = DBNull.Value;
                                                        drTransVouch2["iproorderid"] = DBNull.Value;
                                                        drTransVouch2["cOrderType"] = "��������";
                                                        drTransVouch2["cTranRequestCode"] = DBNull.Value;
                                                        drTransVouch2["cVersion"] = DBNull.Value;
                                                        drTransVouch2["BomId"] = DBNull.Value;
                                                        drTransVouch2["cFree1"] = DBNull.Value;
                                                        drTransVouch2["cFree2"] = DBNull.Value;
                                                        drTransVouch2["cFree3"] = DBNull.Value;
                                                        drTransVouch2["cFree4"] = DBNull.Value;
                                                        drTransVouch2["cFree5"] = DBNull.Value;
                                                        drTransVouch2["cFree6"] = DBNull.Value;
                                                        drTransVouch2["cFree7"] = DBNull.Value;
                                                        drTransVouch2["cFree8"] = DBNull.Value;
                                                        drTransVouch2["cFree9"] = DBNull.Value;
                                                        drTransVouch2["cFree10"] = DBNull.Value;
                                                        drTransVouch2["cAppTVCode"] = DBNull.Value;
                                                        drTransVouch2["csource"] = 1;
                                                        drTransVouch2["itransflag"] = "����";
                                                        drTransVouch2["cModifyPerson"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                                                        drTransVouch2["dModifyDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                                        drTransVouch2["dnmaketime"] = Get��ǰ������ʱ��();
                                                        drTransVouch2["dnmodifytime"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                                        drTransVouch2["dnverifytime"] = DBNull.Value;
                                                        drTransVouch2["ireturncount"] = 0;
                                                        drTransVouch2["iverifystate"] = 0;
                                                        drTransVouch2["iswfcontrolled"] = 0;
                                                    }
                                                    #endregion
                                                    #region �������������
                                                    for (int l = drWorkOrderDetailDB.Length - 1; l >= 0; l--)
                                                    {
                                                        if (dDTQty <= 0)
                                                        {
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToDecimal(drWorkOrderDetailDB[l]["IssQty"]) >= Convert.ToDecimal(drWorkOrderDetailDB[l]["TransQty"]))
                                                            {
                                                                continue;
                                                            }

                                                            ///�������ɵ�������
                                                            decimal dCanTransQty = Convert.ToDecimal(drWorkOrderDetailDB[l]["TransQty"]) - Convert.ToDecimal(drWorkOrderDetailDB[l]["IssQty"]);
                                                            decimal d3 = 0; //���ε�������
                                                            if (dDTQty > dCanTransQty)
                                                            {
                                                                d3 = dCanTransQty;
                                                                dDTQty = dDTQty - d3;
                                                                drWorkOrderDetailDB[l]["TransQty"] = Convert.ToDecimal(drWorkOrderDetailDB[l]["IssQty"]);
                                                            }
                                                            else
                                                            {
                                                                d3 = dDTQty;
                                                                dDTQty = 0;
                                                                drWorkOrderDetailDB[l]["TransQty"] = Convert.ToDecimal(drWorkOrderDetailDB[l]["TransQty"]) - dDTQty;
                                                            }
                                                            #region �������������

                                                            DataRow drTransVouchs2 = dtTransVouchs2.NewRow();
                                                            if (dtTransVouch2 == null || dtTransVouch2.Rows.Count == 0)
                                                            {
                                                                drTransVouchs2["cTVCode"] = sTrCode1;
                                                                drTransVouchs2["ID"] = iTrID;
                                                            }
                                                            else
                                                            {
                                                                drTransVouchs2["cTVCode"] = dtTransVouch2.Rows[0]["cTVCode"];
                                                                drTransVouchs2["ID"] = dtTransVouch2.Rows[0]["ID"];
                                                            }

                                                            drTransVouchs2["cInvCode"] = drWorkOrderDetailDB[l]["InvCode"];
                                                            drTransVouchs2["RdsID"] = DBNull.Value;
                                                            drTransVouchs2["iTVQuantity"] = d3;
                                                            if (drWorkOrderDetailDB[l]["ChangeRate"] != null && drWorkOrderDetailDB[l]["ChangeRate"].ToString().Trim() != "")
                                                            {
                                                                decimal iTVNum = d3 / Convert.ToDecimal(drWorkOrderDetailDB[l]["ChangeRate"]);
                                                                drTransVouchs2["iTVNum"] = decimal.Round(iTVNum, 6);
                                                            }
                                                            drTransVouchs2["iTVACost"] = DBNull.Value;
                                                            drTransVouchs2["iTVAPrice"] = DBNull.Value;
                                                            drTransVouchs2["iTVPCost"] = DBNull.Value;
                                                            drTransVouchs2["iTVPPrice"] = DBNull.Value;
                                                            drTransVouchs2["cTVBatch"] = DBNull.Value;
                                                            drTransVouchs2["dDisDate"] = DBNull.Value;
                                                            drTransVouchs2["cFree1"] = DBNull.Value;
                                                            drTransVouchs2["cFree2"] = DBNull.Value;
                                                            drTransVouchs2["cDefine22"] = DBNull.Value;
                                                            drTransVouchs2["cDefine23"] = DBNull.Value;
                                                            drTransVouchs2["cDefine24"] = DBNull.Value;
                                                            drTransVouchs2["cDefine25"] = DBNull.Value;
                                                            drTransVouchs2["cDefine26"] = DBNull.Value;
                                                            drTransVouchs2["cDefine27"] = DBNull.Value;
                                                            drTransVouchs2["cItemCode"] = DBNull.Value;
                                                            drTransVouchs2["cItem_class"] = DBNull.Value;
                                                            drTransVouchs2["fSaleCost"] = 0;
                                                            drTransVouchs2["fSalePrice"] = 0;
                                                            drTransVouchs2["cName"] = DBNull.Value;
                                                            drTransVouchs2["cItemCName"] = DBNull.Value;

                                                            iTrIDDetail += 1;
                                                            drTransVouchs2["autoID"] = iTrIDDetail;
                                                            drTransVouchs2["iMassDate"] = DBNull.Value;
                                                            drTransVouchs2["cBarCode"] = DBNull.Value;
                                                            drTransVouchs2["cAssUnit"] = DBNull.Value;
                                                            drTransVouchs2["cFree3"] = DBNull.Value;
                                                            drTransVouchs2["cFree4"] = DBNull.Value;
                                                            drTransVouchs2["cFree5"] = DBNull.Value;
                                                            drTransVouchs2["cFree6"] = DBNull.Value;
                                                            drTransVouchs2["cFree7"] = DBNull.Value;
                                                            drTransVouchs2["cFree8"] = DBNull.Value;
                                                            drTransVouchs2["cFree9"] = DBNull.Value;
                                                            drTransVouchs2["cFree10"] = DBNull.Value;
                                                            drTransVouchs2["cDefine28"] = DBNull.Value;
                                                            drTransVouchs2["cDefine29"] = DBNull.Value;
                                                            drTransVouchs2["cDefine30"] = DBNull.Value;
                                                            drTransVouchs2["cDefine31"] = DBNull.Value;
                                                            drTransVouchs2["cDefine32"] = DBNull.Value;
                                                            drTransVouchs2["cDefine33"] = DBNull.Value;
                                                            drTransVouchs2["cDefine34"] = DBNull.Value;
                                                            drTransVouchs2["cDefine35"] = DBNull.Value;
                                                            drTransVouchs2["cDefine36"] = DBNull.Value;
                                                            drTransVouchs2["cDefine37"] = DBNull.Value;
                                                            drTransVouchs2["iMPoIds"] = DBNull.Value;
                                                            drTransVouchs2["cBVencode"] = DBNull.Value;
                                                            drTransVouchs2["cInVouchCode"] = DBNull.Value;
                                                            drTransVouchs2["dMadeDate"] = DBNull.Value;
                                                            drTransVouchs2["cMassUnit"] = DBNull.Value;
                                                            drTransVouchs2["iTRIds"] = DBNull.Value;
                                                            drTransVouchs2["AppTransIDS"] = DBNull.Value;
                                                            drTransVouchs2["iSSoType"] = 0;
                                                            drTransVouchs2["iSSodid"] = DBNull.Value;
                                                            drTransVouchs2["iDSoType"] = 0;
                                                            drTransVouchs2["iDSodid"] = DBNull.Value;
                                                            drTransVouchs2["bCosting"] = 1;
                                                            drTransVouchs2["cvmivencode"] = DBNull.Value;
                                                            drTransVouchs2["cinposcode"] = DBNull.Value;
                                                            drTransVouchs2["coutposcode"] = DBNull.Value;
                                                            drTransVouchs2["iinvsncount"] = DBNull.Value;
                                                            drTransVouchs2["iinvexchrate"] = DBNull.Value;
                                                            drTransVouchs2["comcode"] = DBNull.Value;
                                                            drTransVouchs2["cmocode"] = sWorkOrder;
                                                            drTransVouchs2["invcode"] = gridView1.GetRowCellValue(i, gridColInvCode);
                                                            drTransVouchs2["imoseq"] = drWorkOrderDetailDB[l]["SortSeq"];
                                                            drTransVouchs2["iomids"] = DBNull.Value;
                                                            drTransVouchs2["imoids"] = drWorkOrderDetailDB[l]["MoDId"];
                                                            //drTransVouchs2["corufts"] = DBNull.Value;
                                                            drTransVouchs2["iExpiratDateCalcu"] = 0;
                                                            drTransVouchs2["cExpirationdate"] = DBNull.Value;
                                                            drTransVouchs2["dExpirationdate"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty1"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty2"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty3"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty4"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty5"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty6"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty7"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty8"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty9"] = DBNull.Value;
                                                            drTransVouchs2["cBatchProperty10"] = DBNull.Value;
                                                            drTransVouchs2["cciqbookcode"] = DBNull.Value;

                                                            dtTransVouchs2.Rows.Add(drTransVouchs2);


                                                            //����������ʱ���ɱ�ͷ
                                                            if (dtTransVouch2 == null || dtTransVouch2.Rows.Count == 0)
                                                            {
                                                                dtTransVouch2.Rows.Add(drTransVouch2);
                                                                sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouch", dtTransVouch2, dtTransVouch2.Rows.Count - 1);
                                                                aList.Add(sSQL);

                                                                sInfo = sInfo + " ���ɷ�������� " + sTrCode1 + "\n";
                                                            }
                                                            //

                                                            sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouchs", dtTransVouchs2, dtTransVouchs2.Rows.Count - 1); ;
                                                            aList.Add(sSQL);

                                                            #endregion

                                                            sSQL = "update @u8.mom_moallocate set TransQty = isnull(TransQty,0)  - " + d3 + " where AllocateId = " + drWorkOrderDetailDB[l]["AllocateId"];
                                                            aList.Add(sSQL);

                                                            drWorkOrderDetailDB[l]["TransQty"] = Convert.ToDecimal(drWorkOrderDetailDB[l]["TransQty"]) - d3;
                                                        }
                                                    }

                                                    //���ն���ѭ����������û�����յ����꣬��ʾ���ϲ��㣬Ҫ���ֹ�����
                                                    if (dDTQty > 0)
                                                    {
                                                        DataRow drTransVouchs2 = dtTransVouchs2.NewRow();

                                                        if (dtTransVouch2 == null || dtTransVouch2.Rows.Count == 0)
                                                        {
                                                            drTransVouchs2["cTVCode"] = sTrCode1;
                                                            drTransVouchs2["ID"] = iTrID;
                                                        }
                                                        else
                                                        {
                                                            drTransVouchs2["cTVCode"] = dtTransVouch2.Rows[0]["cTVCode"];
                                                            drTransVouchs2["ID"] = dtTransVouch2.Rows[0]["ID"];
                                                        }

                                                        drTransVouchs2["cInvCode"] = drWorkOrderDetail[k]["InvCode"];
                                                        drTransVouchs2["RdsID"] = DBNull.Value;
                                                        drTransVouchs2["iTVQuantity"] = dDTQty;
                                                        dDTQty = 0;
                                                        if (drWorkOrderDetail[k]["ChangeRate"] != null && drWorkOrderDetail[k]["ChangeRate"].ToString().Trim() != "")
                                                        {
                                                            decimal iTVNum = dDTQty / Convert.ToDecimal(drWorkOrderDetail[k]["ChangeRate"]);
                                                            drTransVouchs2["iTVNum"] = decimal.Round(iTVNum, 6);
                                                        }
                                                        drTransVouchs2["iTVACost"] = DBNull.Value;
                                                        drTransVouchs2["iTVAPrice"] = DBNull.Value;
                                                        drTransVouchs2["iTVPCost"] = DBNull.Value;
                                                        drTransVouchs2["iTVPPrice"] = DBNull.Value;
                                                        drTransVouchs2["cTVBatch"] = DBNull.Value;
                                                        drTransVouchs2["dDisDate"] = DBNull.Value;
                                                        drTransVouchs2["cFree1"] = DBNull.Value;
                                                        drTransVouchs2["cFree2"] = DBNull.Value;
                                                        drTransVouchs2["cDefine22"] = DBNull.Value;
                                                        drTransVouchs2["cDefine23"] = DBNull.Value;
                                                        drTransVouchs2["cDefine24"] = DBNull.Value;
                                                        drTransVouchs2["cDefine25"] = DBNull.Value;
                                                        drTransVouchs2["cDefine26"] = DBNull.Value;
                                                        drTransVouchs2["cDefine27"] = DBNull.Value;
                                                        drTransVouchs2["cItemCode"] = DBNull.Value;
                                                        drTransVouchs2["cItem_class"] = DBNull.Value;
                                                        drTransVouchs2["fSaleCost"] = 0;
                                                        drTransVouchs2["fSalePrice"] = 0;
                                                        drTransVouchs2["cName"] = DBNull.Value;
                                                        drTransVouchs2["cItemCName"] = DBNull.Value;

                                                        iTrIDDetail += 1;
                                                        drTransVouchs2["autoID"] = iTrIDDetail;
                                                        drTransVouchs2["iMassDate"] = DBNull.Value;
                                                        drTransVouchs2["cBarCode"] = DBNull.Value;
                                                        drTransVouchs2["cAssUnit"] = DBNull.Value;
                                                        drTransVouchs2["cFree3"] = DBNull.Value;
                                                        drTransVouchs2["cFree4"] = DBNull.Value;
                                                        drTransVouchs2["cFree5"] = DBNull.Value;
                                                        drTransVouchs2["cFree6"] = DBNull.Value;
                                                        drTransVouchs2["cFree7"] = DBNull.Value;
                                                        drTransVouchs2["cFree8"] = DBNull.Value;
                                                        drTransVouchs2["cFree9"] = DBNull.Value;
                                                        drTransVouchs2["cFree10"] = DBNull.Value;
                                                        drTransVouchs2["cDefine28"] = DBNull.Value;
                                                        drTransVouchs2["cDefine29"] = DBNull.Value;
                                                        drTransVouchs2["cDefine30"] = DBNull.Value;
                                                        drTransVouchs2["cDefine31"] = DBNull.Value;
                                                        drTransVouchs2["cDefine32"] = DBNull.Value;
                                                        drTransVouchs2["cDefine33"] = DBNull.Value;
                                                        drTransVouchs2["cDefine34"] = DBNull.Value;
                                                        drTransVouchs2["cDefine35"] = DBNull.Value;
                                                        drTransVouchs2["cDefine36"] = DBNull.Value;
                                                        drTransVouchs2["cDefine37"] = DBNull.Value;
                                                        drTransVouchs2["iMPoIds"] = DBNull.Value;
                                                        drTransVouchs2["cBVencode"] = DBNull.Value;
                                                        drTransVouchs2["cInVouchCode"] = DBNull.Value;
                                                        drTransVouchs2["dMadeDate"] = DBNull.Value;
                                                        drTransVouchs2["cMassUnit"] = DBNull.Value;
                                                        drTransVouchs2["iTRIds"] = DBNull.Value;
                                                        drTransVouchs2["AppTransIDS"] = DBNull.Value;
                                                        drTransVouchs2["iSSoType"] = 0;
                                                        drTransVouchs2["iSSodid"] = DBNull.Value;
                                                        drTransVouchs2["iDSoType"] = 0;
                                                        drTransVouchs2["iDSodid"] = DBNull.Value;
                                                        drTransVouchs2["bCosting"] = 1;
                                                        drTransVouchs2["cvmivencode"] = DBNull.Value;
                                                        drTransVouchs2["cinposcode"] = DBNull.Value;
                                                        drTransVouchs2["coutposcode"] = DBNull.Value;
                                                        drTransVouchs2["iinvsncount"] = DBNull.Value;
                                                        drTransVouchs2["iinvexchrate"] = DBNull.Value;
                                                        drTransVouchs2["comcode"] = DBNull.Value;
                                                        drTransVouchs2["cmocode"] = sWorkOrder;
                                                        drTransVouchs2["invcode"] = gridView1.GetRowCellValue(i, gridColInvCode);
                                                        drTransVouchs2["imoseq"] = drWorkOrderDetail[k]["SortSeq"];
                                                        drTransVouchs2["iomids"] = DBNull.Value;
                                                        drTransVouchs2["imoids"] = drWorkOrderDetail[k]["MoDId"];
                                                        //drTransVouchs2["corufts"] = DBNull.Value;
                                                        drTransVouchs2["iExpiratDateCalcu"] = 0;
                                                        drTransVouchs2["cExpirationdate"] = DBNull.Value;
                                                        drTransVouchs2["dExpirationdate"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty1"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty2"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty3"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty4"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty5"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty6"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty7"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty8"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty9"] = DBNull.Value;
                                                        drTransVouchs2["cBatchProperty10"] = DBNull.Value;
                                                        drTransVouchs2["cciqbookcode"] = DBNull.Value;

                                                        dtTransVouchs2.Rows.Add(drTransVouchs2);


                                                        //����������ʱ���ɱ�ͷ
                                                        if (dtTransVouch2 == null || dtTransVouch2.Rows.Count == 0)
                                                        {
                                                            dtTransVouch2.Rows.Add(drTransVouch2);
                                                            sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouch", dtTransVouch2, dtTransVouch2.Rows.Count - 1);
                                                            aList.Add(sSQL);

                                                            sInfo = sInfo + " ���ɷ�������� " + sTrCode1 + "\n";
                                                        }
                                                        //

                                                        sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouchs", dtTransVouchs2, dtTransVouchs2.Rows.Count - 1);
                                                        aList.Add(sSQL);

                                                        sSQL = "update @u8.mom_moallocate set TransQty = isnull(TransQty,0)  - " + dDTQty + " where AllocateId = " + drWorkOrderDetail[k]["AllocateId"];
                                                        aList.Add(sSQL);

                                                    }
                                                    #endregion

                                                    #endregion

                                                    if (dtTransVouchs2 == null || dtTransVouchs2.Rows.Count == 0)
                                                    {
                                                        sErr = sErr + " �� " + (i + 1) + " û�ж�Ӧ����������������������ʵ��������\n";
                                                    }
                                                }
                                                #endregion
                                            }

                                        }
                                    }

                                    #endregion

                                }

                                #region ����ת����������������հ���

                                if (gridView1.GetRowCellValue(i, gridColRDTrans).ToString().Trim() == "��" && Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColQtyRDL)) > 0)
                                {
                                    if (dtTransVouch == null || dtTransVouch.Rows.Count == 0)
                                    {
                                        #region ��ת��������ͷ
                                        DataRow drTransVouch = dtTransVouch.NewRow();

                                        iTrCode += 1;
                                        sTrCode1 = sSetTransVouchCode(iTrCode);
                                        iTrID += 1;
                                        drTransVouch["cTVCode"] = sTrCode1;
                                        drTransVouch["dTVDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                        drTransVouch["cOWhCode"] = sWorkWhCode;
                                        drTransVouch["cIWhCode"] = "0F";
                                        drTransVouch["cODepCode"] = sWorkDep;
                                        drTransVouch["cIDepCode"] = GetDepCode(gridView1.GetRowCellValue(i, gridColworkDepmentNext2).ToString().Trim());
                                        drTransVouch["cPersonCode"] = DBNull.Value;
                                        drTransVouch["cIRdCode"] = 113;
                                        drTransVouch["cORdCode"] = 213;
                                        drTransVouch["cTVMemo"] = DBNull.Value;
                                        drTransVouch["cDefine1"] = DBNull.Value;
                                        drTransVouch["cDefine2"] = DBNull.Value;
                                        drTransVouch["cDefine3"] = DBNull.Value;
                                        drTransVouch["cDefine4"] = DBNull.Value;
                                        drTransVouch["cDefine5"] = DBNull.Value;
                                        drTransVouch["cDefine6"] = DBNull.Value;
                                        drTransVouch["cDefine7"] = DBNull.Value;
                                        drTransVouch["cDefine8"] = DBNull.Value;
                                        drTransVouch["cDefine9"] = DBNull.Value;
                                        drTransVouch["cDefine10"] = DBNull.Value;
                                        drTransVouch["cAccounter"] = DBNull.Value;
                                        drTransVouch["cMaker"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                                        drTransVouch["iNetLock"] = 0;
                                        drTransVouch["ID"] = iTrID;
                                        drTransVouch["VT_ID"] = 89;
                                        drTransVouch["cVerifyPerson"] = DBNull.Value;
                                        drTransVouch["dVerifyDate"] = DBNull.Value;
                                        drTransVouch["cPSPCode"] = gridView1.GetRowCellValue(i, gridColInvCode);
                                        drTransVouch["cMPoCode"] = DBNull.Value;
                                        drTransVouch["iQuantity"] = DBNull.Value;
                                        drTransVouch["bTransFlag"] = DBNull.Value;
                                        drTransVouch["cDefine11"] = DBNull.Value;
                                        drTransVouch["cDefine12"] = DBNull.Value;
                                        drTransVouch["cDefine13"] = DBNull.Value;
                                        drTransVouch["cDefine14"] = DBNull.Value;
                                        drTransVouch["cDefine15"] = DBNull.Value;
                                        drTransVouch["cDefine16"] = DBNull.Value;
                                        //drTransVouch["ufts"] = DBNull.Value;
                                        drTransVouch["iproorderid"] = DBNull.Value;
                                        drTransVouch["cOrderType"] = "��������";
                                        drTransVouch["cTranRequestCode"] = DBNull.Value;
                                        drTransVouch["cVersion"] = DBNull.Value;
                                        drTransVouch["BomId"] = DBNull.Value;
                                        drTransVouch["cFree1"] = DBNull.Value;
                                        drTransVouch["cFree2"] = DBNull.Value;
                                        drTransVouch["cFree3"] = DBNull.Value;
                                        drTransVouch["cFree4"] = DBNull.Value;
                                        drTransVouch["cFree5"] = DBNull.Value;
                                        drTransVouch["cFree6"] = DBNull.Value;
                                        drTransVouch["cFree7"] = DBNull.Value;
                                        drTransVouch["cFree8"] = DBNull.Value;
                                        drTransVouch["cFree9"] = DBNull.Value;
                                        drTransVouch["cFree10"] = DBNull.Value;
                                        drTransVouch["cAppTVCode"] = DBNull.Value;
                                        drTransVouch["csource"] = 1;
                                        drTransVouch["itransflag"] = "����";
                                        drTransVouch["cModifyPerson"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                                        drTransVouch["dModifyDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                        drTransVouch["dnmaketime"] = Get��ǰ������ʱ��();
                                        drTransVouch["dnmodifytime"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                                        drTransVouch["dnverifytime"] = DBNull.Value;
                                        drTransVouch["ireturncount"] = 0;
                                        drTransVouch["iverifystate"] = 0;
                                        drTransVouch["iswfcontrolled"] = 0;

                                        dtTransVouch.Rows.Add(drTransVouch);
                                        aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouch", dtTransVouch, dtTransVouch.Rows.Count - 1));

                                        sInfo = sInfo + " ������ת������ " + sTrCode1 + "\n";
                                        #endregion
                                    }

                                    #region ��ת����������      ȱ�ٵ���˫���� ������ֵ

                                    DataRow drTransVouchs = dtTransVouchs.NewRow();
                                    drTransVouchs["cTVCode"] = sTrCode1;
                                    drTransVouchs["cInvCode"] = gridView1.GetRowCellValue(i, gridColcInvCode);
                                    drTransVouchs["RdsID"] = DBNull.Value;
                                    decimal dQtyRDL = Convert.ToDecimal(gridView1.GetRowCellValue(i, gridColQtyRDL));
                                    drTransVouchs["iTVQuantity"] = dQtyRDL;
                                    if (drWorkOrder[0]["MDChangeRate"] != null && drWorkOrder[0]["MDChangeRate"].ToString().Trim() != "")
                                    {
                                        decimal iTVNum = dQtyRDL / Convert.ToDecimal(drWorkOrder[0]["MDChangeRate"]);
                                        drTransVouchs["iTVNum"] = decimal.Round(iTVNum, 6);
                                        drTransVouchs["iinvexchrate"] = drWorkOrder[0]["MDChangeRate"];
                                        drTransVouchs["cAssUnit"] = drWorkOrder[0]["MDAuxUnitCode"];
                                    }
                                    drTransVouchs["iTVACost"] = DBNull.Value;
                                    drTransVouchs["iTVAPrice"] = DBNull.Value;
                                    drTransVouchs["iTVPCost"] = DBNull.Value;
                                    drTransVouchs["iTVPPrice"] = DBNull.Value;
                                    drTransVouchs["cTVBatch"] = DBNull.Value;
                                    drTransVouchs["dDisDate"] = DBNull.Value;
                                    drTransVouchs["cFree1"] = DBNull.Value;
                                    drTransVouchs["cFree2"] = DBNull.Value;
                                    drTransVouchs["cDefine22"] = DBNull.Value;
                                    drTransVouchs["cDefine23"] = DBNull.Value;
                                    drTransVouchs["cDefine24"] = DBNull.Value;
                                    drTransVouchs["cDefine25"] = DBNull.Value;
                                    drTransVouchs["cDefine26"] = DBNull.Value;
                                    drTransVouchs["cDefine27"] = DBNull.Value;
                                    drTransVouchs["cItemCode"] = DBNull.Value;
                                    drTransVouchs["cItem_class"] = DBNull.Value;
                                    drTransVouchs["fSaleCost"] = 0;
                                    drTransVouchs["fSalePrice"] = 0;
                                    drTransVouchs["cName"] = DBNull.Value;
                                    drTransVouchs["cItemCName"] = DBNull.Value;

                                    iTrIDDetail += 1;
                                    drTransVouchs["autoID"] = iTrIDDetail;
                                    drTransVouchs["ID"] = iTrID;
                                    drTransVouchs["iMassDate"] = DBNull.Value;
                                    drTransVouchs["cBarCode"] = DBNull.Value;
                                    drTransVouchs["cFree3"] = DBNull.Value;
                                    drTransVouchs["cFree4"] = DBNull.Value;
                                    drTransVouchs["cFree5"] = DBNull.Value;
                                    drTransVouchs["cFree6"] = DBNull.Value;
                                    drTransVouchs["cFree7"] = DBNull.Value;
                                    drTransVouchs["cFree8"] = DBNull.Value;
                                    drTransVouchs["cFree9"] = DBNull.Value;
                                    drTransVouchs["cFree10"] = DBNull.Value;
                                    drTransVouchs["cDefine28"] = DBNull.Value;
                                    drTransVouchs["cDefine29"] = DBNull.Value;
                                    drTransVouchs["cDefine30"] = DBNull.Value;
                                    drTransVouchs["cDefine31"] = DBNull.Value;
                                    drTransVouchs["cDefine32"] = DBNull.Value;
                                    drTransVouchs["cDefine33"] = DBNull.Value;
                                    drTransVouchs["cDefine34"] = DBNull.Value;
                                    drTransVouchs["cDefine35"] = DBNull.Value;
                                    drTransVouchs["cDefine36"] = DBNull.Value;
                                    drTransVouchs["cDefine37"] = DBNull.Value;
                                    drTransVouchs["iMPoIds"] = DBNull.Value;
                                    drTransVouchs["cBVencode"] = DBNull.Value;
                                    drTransVouchs["cInVouchCode"] = DBNull.Value;
                                    drTransVouchs["dMadeDate"] = DBNull.Value;
                                    drTransVouchs["cMassUnit"] = DBNull.Value;
                                    drTransVouchs["iTRIds"] = DBNull.Value;
                                    drTransVouchs["AppTransIDS"] = DBNull.Value;
                                    drTransVouchs["iSSoType"] = 0;
                                    drTransVouchs["iSSodid"] = DBNull.Value;
                                    drTransVouchs["iDSoType"] = 0;
                                    drTransVouchs["iDSodid"] = DBNull.Value;
                                    drTransVouchs["bCosting"] = 1;
                                    drTransVouchs["cvmivencode"] = DBNull.Value;
                                    drTransVouchs["cinposcode"] = DBNull.Value;
                                    drTransVouchs["coutposcode"] = DBNull.Value;
                                    drTransVouchs["iinvsncount"] = DBNull.Value;
                                    drTransVouchs["comcode"] = DBNull.Value;
                                    drTransVouchs["cmocode"] = gridView1.GetRowCellDisplayText(i, gridColLZWorkOrder);
                                    drTransVouchs["imoseq"] = gridView1.GetRowCellDisplayText(i, gridColLZWorkNo);
                                    drTransVouchs["invcode"] = gridView1.GetRowCellValue(i, gridColInvCode);
                                    drTransVouchs["iomids"] = DBNull.Value;
                                    drTransVouchs["imoids"] = gridView1.GetRowCellDisplayText(i, gridColAllocateId);
                                    //drTransVouchs["corufts"] = DBNull.Value;
                                    drTransVouchs["iExpiratDateCalcu"] = 0;
                                    drTransVouchs["cExpirationdate"] = DBNull.Value;
                                    drTransVouchs["dExpirationdate"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty1"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty2"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty3"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty4"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty5"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty6"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty7"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty8"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty9"] = DBNull.Value;
                                    drTransVouchs["cBatchProperty10"] = DBNull.Value;
                                    drTransVouchs["cciqbookcode"] = DBNull.Value;

                                    dtTransVouchs.Rows.Add(drTransVouchs);

                                    aList.Add(clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "TransVouchs", dtTransVouchs, dtTransVouchs.Rows.Count - 1));
                                    #endregion

                                    sSQL = "update @u8.mom_moallocate set TransQty = isnull(TransQty,0)  + " + dQtyNowRow + " where AllocateId = " + gridView1.GetRowCellDisplayText(i, gridColAllocateId);
                                    aList.Add(sSQL);
                                }
                                #endregion

                                #region ��ת���������

                                if (dtTransVouch != null && dtTransVouchs.Rows.Count > 0)
                                {
                                    sSQL = " update UFDLImport..WorkPlanDetail set TranLCode = '" + dtTransVouch.Rows[0]["cTVCode"] + "' where id = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                                    aList.Add(sSQL);

                                    sSQL = "update @u8.TransVouch set cVerifyPerson = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,dVerifyDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' ,dnverifytime = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where cTVCode = '" + dtTransVouch.Rows[0]["cTVCode"] + "'";
                                    aList.Add(sSQL);

                                    long iID2 = 0; long iIDDetail2 = 0; long iInCode2 = 0; long iOutCode2 = 0;
                                    TH.BaseClassProInfo.ClsU8Function clsU8 = new TH.BaseClassProInfo.ClsU8Function();
                                    ArrayList aRDList = clsU8.GenInvChangeRD(dtTransVouch, dtTransVouchs, iRdID, iRdIDDetail, out iID2, out iIDDetail2, iRdOtherInCode, out iInCode2, iRdOtherOutCode, out iOutCode2);
                                    iRdID = iID2; iRdIDDetail = iIDDetail2; iRdOtherInCode = iInCode2; iRdOtherOutCode = iOutCode2;

                                    for (int jj = 0; jj < aRDList.Count; jj++)
                                    {
                                        aList.Add(aRDList[jj].ToString().Trim());
                                    }
                                }

                                #endregion


                                #region ������������

                                if (dtTransVouchs3.Rows.Count > 0 && dtTransVouch3.Rows.Count > 0)
                                {
                                    sSQL = "update @u8.TransVouch set cVerifyPerson = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,dVerifyDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' ,dnverifytime = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where cTVCode = '" + dtTransVouch3.Rows[0]["cTVCode"] + "'";
                                    aList.Add(sSQL);

                                    long iID2 = 0; long iIDDetail2 = 0; long iInCode2 = 0; long iOutCode2 = 0;
                                    TH.BaseClassProInfo.ClsU8Function clsU8 = new TH.BaseClassProInfo.ClsU8Function();
                                    ArrayList aRDList = clsU8.GenInvChangeRD(dtTransVouch3, dtTransVouchs3, iRdID, iRdIDDetail, out iID2, out iIDDetail2, iRdOtherInCode, out iInCode2, iRdOtherOutCode, out iOutCode2);
                                    iRdID = iID2; iRdIDDetail = iIDDetail2; iRdOtherInCode = iInCode2; iRdOtherOutCode = iOutCode2;

                                    for (int jj = 0; jj < aRDList.Count; jj++)
                                    {
                                        aList.Add(aRDList[jj].ToString().Trim());
                                    }
                                }

                                #region ������������

                                if (dtTransVouch2.Rows.Count > 0 && dtTransVouchs2.Rows.Count > 0)
                                {
                                    sSQL = "update @u8.TransVouch set cVerifyPerson = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,dVerifyDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' ,dnverifytime = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where cTVCode = '" + dtTransVouchs2.Rows[0]["cTVCode"] + "'";
                                    aList.Add(sSQL);

                                    long iID2 = 0; long iIDDetail2 = 0; long iInCode2 = 0; long iOutCode2 = 0;
                                    TH.BaseClassProInfo.ClsU8Function clsU8 = new TH.BaseClassProInfo.ClsU8Function();
                                    ArrayList aRDList2 = clsU8.GenInvChangeRD(dtTransVouch2, dtTransVouchs2, iRdID, iRdIDDetail, out iID2, out iIDDetail2, iRdOtherInCode, out iInCode2, iRdOtherOutCode, out iOutCode2);
                                    iRdID = iID2; iRdIDDetail = iIDDetail2; iRdOtherInCode = iInCode2; iRdOtherOutCode = iOutCode2;

                                    for (int jj = 0; jj < aRDList2.Count; jj++)
                                    {
                                        aList.Add(aRDList2[jj].ToString().Trim());
                                    }
                                }

                                #endregion
                                #endregion
                            }
                            #endregion
                        }
                    }
                }

                sSQL = "update UFSystem..UA_Identity set iFatherID = " + iRdID + ",iChildID=" + iRdIDDetail + "  where cAcc_Id = '200' and cVouchType = 'rd'";
                aList.Add(sSQL);

                if (iTrID2 > iTrID)
                    iTrID = iTrID2;
                sSQL = "update UFSystem..UA_Identity set iFatherID = " + iTrID + ",iChildID=" + iTrIDDetail + "  where cAcc_Id = '200' and cVouchType = 'tr'";
                aList.Add(sSQL);

                //���ĵ������ݺ�
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0304'  and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
                DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                if (dtCodeTemp.Rows[0]["Maxnumber"].ToString().Trim() == "0")
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0304','����','��','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                    aList.Add(sSQL);
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iTrCode.ToString().Trim() + "' Where CardNumber='0304' and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                    aList.Add(sSQL);
                }

                //���Ĳ��ϳ��ⵥ�ݺ�
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412'  and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
                dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                if (dtCodeTemp.Rows[0]["Maxnumber"].ToString().Trim() == "0")
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0412','����','��','" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "','1',0)";
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iRdOutCode.ToString().Trim() + "' Where CardNumber='0412' and (cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "' or cSeed='" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyMM") + "')";
                }
                aList.Add(sSQL);

                //���²���Ʒ��ⵥ��󵥾ݺ�
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0411'  and (cSeed = '" + dtm1.ToString("yyMM") + "' or cSeed = '" + dtm1.ToString("yyyyMM") + "')";
                dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                if (dtCodeTemp.Rows[0]["Maxnumber"].ToString().Trim() == "0")
                {
                    sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0411','����','��','" + dtm1.ToString("yyMM") + "','1',0)";
                }
                else
                {
                    sSQL = "update @u8.VoucherHistory set cNumber = '" + iRdInCode.ToString().Trim() + "' Where  CardNumber='0411' and cContent='����' and cSeed='" + dtm1.ToString("yyMM") + "'  ";
                }
                aList.Add(sSQL);

                if (sErr.Trim() != "")
                {
                    FrmMsgBox fMsgBos = new FrmMsgBox();
                    fMsgBos.Text = "���ݴ����������������";
                    fMsgBos.richTextBox1.Text = sErr;
                    fMsgBos.ShowDialog();
                    return;
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    gridControl1.DataSource = null;

                    //�����ر�����ɶ���
                    sSQL = "update @u8.mom_orderdetail set Status = 4,CloseTime = '" + dtm1.ToString("yyyy-MM-dd") + "',CloseUser = '" + FrameBaseFunction.ClsBaseDataInfo.sUid + "',OrgClsTime = '" + dtm1 + "',CloseDate = '" + dtm1 + "',OrgClsDate = '" + dtm1 + "' " +
                           "where  Status = 3 and isnull(Qty,0) <= isnull(QualifiedInQty,0)";
                    aList = new ArrayList();
                    aList.Add(sSQL);
                    clsSQLCommond.ExecSqlTran(aList);

                    FrmMsgBox fMsgBos = new FrmMsgBox();
                    fMsgBos.Text = "��˳ɹ�";
                    fMsgBos.richTextBox1.Text = sInfo;
                    fMsgBos.ShowDialog();
                    btnSel();
                }
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private void btnUnSure()
        {
            if (!radioButton2.Checked)
            {
                MessageBox.Show("��ѡ����ȷ���б����ȡ��ȷ�ϲ�����");
                return;
            }
            string sSQL;
            ArrayList aList = new ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                {
                    sSQL = " update UFDLImport..WorkPlanDetail set EnSureUid = null,EnSureDate = null where id = '" + gridView1.GetRowCellValue(i, gridColID).ToString().Trim() + "'";
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                gridControl1.DataSource = null;
                MessageBox.Show("ȡ��ȷ�ϳɹ���");
                btnSel();
            }
        }

        private void btnEnSure()
        {
            if (!radioButton1.Checked)
            {
                MessageBox.Show("��ѡ��δȷ���б����ȷ�ϲ�����");
                return;
            }
            string sSQL;
            ArrayList aList = new ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "��")
                {
                    sSQL = " update UFDLImport..WorkPlanDetail set EnSureUid = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',EnSureDate = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' where id = " + gridView1.GetRowCellValue(i, gridColID).ToString().Trim();
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                gridControl1.DataSource = null;
                MessageBox.Show("ȷ�ϳɹ���");
                btnSel();
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
                sa.Filter = "Excel�ļ�2003|*.xls";
                sa.FileName = "������Ϣ";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView1.ExportToXls(sPath);
                        MessageBox.Show("�����б�ɹ���\n·����" + sPath);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("�����б�ʧ�ܣ�" + ee.Message);
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

        private void ItemButtonEditvchrPer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmWorkPer fPer = new FrmWorkPer( gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridColvchrPer).ToString().Trim());

            if (DialogResult.OK == fPer.ShowDialog())
            {
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridColvchrPer, fPer.sFName);
            }
        }

        /// <summary>
        /// ����豸��Ϣ
        /// </summary>
        private void GetFacility()
        {
            try
            {
                string sSQL = "select FCode,FName from UFDLImport..FacilityInfo order by FName,FCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                ItemlookUpEquipment.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception("����豸��Ϣʧ�ܣ�" + ee.Message);
            }
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
                    gridView1.SetFocusedRowCellValue(gridColbChoose, "��");
                }
                else
                {
                    gridView1.SetFocusedRowCellValue(gridColbChoose, "");
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
                    {
                        gridView1.SetRowCellValue(i, gridColbChoose, "��");
                    }
                }
                else
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, gridColbChoose, "");
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����" + ee.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnSel();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnSel();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnSel();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            btnSel();
        }

        private void GetWHInfo()
        {
            string sSQL = "select cWhCode,cWhName,* from @u8.Warehouse order by cWhCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditWarehouse.DataSource = dt;

        }

        /// <summary>
        /// ��õ���ID
        /// </summary>
        /// <param name="sType">��������</param>
        private void GetID(string sType, out long iID, out long iIDDetail)
        {
            string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = '" + sType + "'";
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


        /// <summary>
        /// ������ⵥ���ݺ�
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private string sSetRdInCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "CP" + dtm1.ToString("yyMM") + sCode;
        }

        /// <summary>
        /// ���ص�������
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string sSetTransVouchCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 6; i++)
            {
                if (sCode.Length < 6)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "TR" + dtm1.ToString("yyMM") + sCode;
        }

        /// <summary>
        /// ���ز��ϳ��ⵥ���ݺ�
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string sSetRdOutCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 10; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return "OP" + dtm1.ToString("yyMM") + sCode;
        }

        /// <summary>
        ///��ýɿ�����
        /// </summary>
        private void GetRdInType()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "RdInType";
                dt.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "RdInName";
                dt.Columns.Add(dc);
                DataRow dr = dt.NewRow();
                dr["RdInName"] = "�ɿ�";
                dr["RdInType"] = "1";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["RdInName"] = "��ת";
                dr["RdInType"] = "2";
                dt.Rows.Add(dr);

                ItemLookUpRdInType.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception("��ýɿ�������Ϣʧ�ܣ�" + ee.Message);
            }
        }

        private void GetbTran()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "bTran";
                dt.Columns.Add(dc);
                DataRow dr = dt.NewRow();
                dr["bTran"] = "��";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["bTran"] = "��";
                dt.Rows.Add(dr);

                ItemLookUpEditTrans.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception("��ýɿ�������Ϣʧ�ܣ�" + ee.Message);
            }
        }

        private void ItemButtonEditTrans_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                FrmWorkProcedureListRdTran frm = new FrmWorkProcedureListRdTran(dt.Rows[gridView1.FocusedRowHandle]);
                frm.ShowDialog();
            }
            catch (Exception ee) 
            {
                MessageBox.Show("���ص����б�ʧ��!");
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //try
            //{
            //    int iRow = 0;
            //    if (gridView1.RowCount > 0)
            //    {
            //        iRow = gridView1.FocusedRowHandle;
            //    }
            //    if (gridView1.GetRowCellValue(iRow, gridColRDInType).ToString().Trim() == "��ת")
            //    {
            //        gridColRDTrans.OptionsColumn.AllowEdit = true;
            //    }
            //    else
            //    {
            //        gridColRDTrans.OptionsColumn.AllowEdit = false;
            //    }
            //}
            //catch (Exception ee)
            //{

            //}
        }

        private string GetDepCode(string sDepName)
        {
            string sSQL = "select * from @u8.Department where cDepName = '" + sDepName + "' ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["cDepCode"].ToString().Trim();
            }
            else
            {
                return null;
            }
        }

        private void ItemButtonEditLZTrans_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)gridControl1.DataSource;

                string sInvCode = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridColcInvCode);
                FrmWorkProcedureListLZTran frm = new FrmWorkProcedureListLZTran(sInvCode);
                frm.ShowDialog();
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                if (frm.bLZ)
                {
                    gridView1.SetRowCellValue(iRow, gridColLZWorkOrder, frm.sWorkCode);
                    gridView1.SetRowCellValue(iRow, gridColLZWorkNo, frm.sWorkCodeNo);
                    gridView1.SetRowCellValue(iRow, gridColAllocateId, frm.lAllocateId);
                    gridView1.SetRowCellValue(iRow, gridColRDTrans, "��");
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, gridColLZWorkOrder, DBNull.Value);
                    gridView1.SetRowCellValue(iRow, gridColLZWorkNo, DBNull.Value);
                    gridView1.SetRowCellValue(iRow, gridColAllocateId, DBNull.Value);
                    gridView1.SetRowCellValue(iRow, gridColRDTrans, DBNull.Value);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("���ص����б�ʧ��!");
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridView1_CustomDrawRowIndicator_1(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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


        private decimal ReturnObjectToDecimal(object o)
        {
            decimal i = 0;
            try
            {
                i = Convert.ToDecimal(o);
                i = decimal.Round(i, 6);
            }
            catch { }
            return i;
        }
    }
}