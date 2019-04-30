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
    public partial class FrmWorkProcedureBarCode : FrameBaseFunction.Frm列表窗体模板
    {
        DataTable dtTable;
        public FrmWorkProcedureBarCode()
        {
            InitializeComponent();
        }

        private void FrmWorkProcedureBarCode_Load(object sender, EventArgs e)
        {
            try
            {
                GetworkDepment();
                GetRdInType();

                string sSQL = @"
select '缴库' as RDInType,wd.WorkTime,w.cinvcode2,isnull(w.dtmPlan,'1900-1-1') as dtmPlan,isnull(w.bRDIn,0) as bRDIn,w.vchrPer,w.vchrEquipment,w.GUID ,w.AutoID,WorkOrderID,WorkOrderNO,WorkOrderRowNO
    ,w.cInvCode,i.cInvName,i.cInvStd,wd.workDepmentNext2,isnull(w.iQuantity,0) as iQuantity,workProcedure,wp.fName as workProcedureName,workProcedureNext,wp2.fName as workProcedureNextName
    ,w.workDepment,wDep.fName,isnull(wd.iQuantity,0) as wdiQty,null as wddiQty,null as QtyIng,null as QtyNow,null as QtyRDIn,null as QtyRDL,null as WorkQtyY,cast(null as varchar(50)) as SoCode
    ,cast(null as datetime) as dtm1  
from UFDLImport..WorkPlan w left join UFDLImport..WorkPlanDetail wd on w.Guid = wd.GuidHead 
    left join @u8.Inventory i on i.cInvcode = w.cInvCode 
    left join UFDLImport..WorkDepment wDep on wDep.FCode = w.workDepment 	
    left join UFDLImport..WorkingProcedure wp on wp.fCode = w.workProcedure 
    left join UFDLImport..WorkingProcedure wp2 on wp2.fCode = w.workProcedureNext 
where 1=-1
";
                dtTable = clsSQLCommond.ExecQuery(sSQL);

                txtBarCode.ReadOnly = false;
                txtBarCode.Enabled = true;

                GetFacility();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "delrow":
                        btnDel();
                        break;
                    case "save":
                        btnSave();
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
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                gridView1.DeleteRow(iRow);
            }
            catch { }
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
                sa.FileName = "生产条码缴库";

                DialogResult d = sa.ShowDialog();
                if (d == DialogResult.OK)
                {
                    string sPath = sa.FileName;

                    if (sPath.Trim() != string.Empty)
                    {
                        gridView1.ExportToXls(sPath);
                        MessageBox.Show("导出列表成功！\n路径：" + sPath);
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("导出列表失败：" + ee.Message);
            }
        }

        private void btnSave()
        {
            if (gridView1.RowCount < 1)
            {
                MessageBox.Show("请扫描条码！");
                return;
            }
            try
            {
                gridView1.FocusedRowHandle -= 1;
            }
            catch { }

            DataTable dt = (DataTable)gridControl1.DataSource;
            DataRow drWorkPlanDetail = null;

            string sSQL = "select * from UFDLImport..WorkPlanDetail where 1=-1";
            DataTable dtWorkPlanDetail = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select * from UFDLImport..WorkPlanDetailDefective where 1=-1";
            DataTable dtWorkPlanDetailDefective = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";
            ArrayList aList = new ArrayList();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["vchrPer"].ToString().Trim() == string.Empty)
                {
                    sErr = sErr + "行 " + (i + 1) + " 员工信息不能为空！\n";
                }
                if (gridView1.GetRowCellDisplayText(i, gridColworkDepmentNext).ToString().Trim() == string.Empty)
                {
                    sErr = sErr + "行 " + (i + 1) + " 接受班组不能为空！\n";
                }
                if (dt.Rows[i]["workDepmentNext2"].ToString().Trim() == string.Empty)
                {
                    sErr = sErr + "行 " + (i + 1) + " 接受班组不能为空！\n";
                }
                if (dt.Rows[i]["workDepmentNext2"].ToString().Trim() == dt.Rows[i]["workDepment"].ToString().Trim())
                {
                    sErr = sErr + "行 " + (i + 1) + " 班组不能与接受班组一致！\n";
                }
                if (dt.Rows[i]["QtyNow"].ToString().Trim() == "")
                {
                    sErr = sErr + "行 " + (i + 1) + " 本次数量不能为空！\n";
                }
                if (Convert.ToDecimal(dt.Rows[i]["QtyNow"]) <= 0)
                {
                    sErr = sErr + "行 " + (i + 1) + " 本次数量必须为正数！\n";
                }
                if (dt.Rows[i]["WorkTime"].ToString().Trim() == "")
                {
                    sErr = sErr + "行 " + (i + 1) + " 工时必须要填写！\n";
                }
                //if (dt.Rows[i]["WorkTime"].ToString().Trim() != "" && Convert.ToDecimal(dt.Rows[i]["WorkTime"]) <= 0)
                //{
                //    sErr = sErr + "行 " + (i + 1) + " 工时必须为正数！\n";
                //}
                //判断现场库是否有足够物料，物料不足不允许保存
                sSQL = "select count(*) as iCount " +
                        "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId inner join @u8.mom_moallocate c on b.MoDId = c.MoDId " +
                        "	inner join @u8.bas_part d on c.ComponentId = d.PartId " +
                        "	inner join @u8.CurrentStock e on e.cInvCode = d.InvCode and cWhCode = '0F' " +
                        "where a.MoCode = '" + dt.Rows[i]["WorkOrderNo"] + "' and b.InvCode = '" + dt.Rows[i]["cInvCode"] + "' and " + dt.Rows[i]["QtyNow"] + " * (BaseQtyN * (1 + CompScrap)/(BaseQtyD * (1 - CompScrap))) > e.iQuantity";
                DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
                if (Convert.ToInt32(dtTemp.Rows[0]["iCount"]) > 0)
                {
                    sErr = sErr + "行 " + (i + 1) + " 现场仓材料不足！\n";
                    continue;
                }

                //判断材料是否入库道冲，不是不允许保存
                sSQL = "select count(*) as iCount " +
                        "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId inner join @u8.mom_moallocate c on b.MoDId = c.MoDId " +
                        "	inner join @u8.bas_part d on c.ComponentId = d.PartId " +
                        "	inner join @u8.CurrentStock e on e.cInvCode = d.InvCode and cWhCode = '0F' " +
                        "where a.MoCode = '" + dt.Rows[i]["WorkOrderNo"] + "' and b.InvCode = '" + dt.Rows[i]["cInvCode"] + "' and c.WIPType <> 1";
                DataTable dtTemp2 = clsSQLCommond.ExecQuery(sSQL);
                if (Convert.ToInt32(dtTemp.Rows[0]["iCount"]) > 0)
                {
                    sErr = sErr + "行 " + (i + 1) + " 材料" + dt.Rows[i]["cInvCode"].ToString().Trim() + "不是入库倒冲，请通知生管！\n";
                    continue;
                }

                string sGuid = Guid.NewGuid().ToString().Trim();
                //sSQL = "insert into dbo.WorkPlanDetail(WorkDep,iQuantity,GUIDHead,[GUID],dtmDay,vchruid,vchrPer,vchrFacility,workTime)values
                //('" + txtworkDepment2.Text.Trim() + "'," + txtQtyNow.Text.Trim() + ",'" + txtGuid.Text.Trim() + "','" + sGuid + "','" + dtm1.Text.Trim() + "','" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + txtPer.Text.Trim() + "','" + lookUpEquipment.Text.Trim() + "'," + txtTime.Text.Trim() + ")";
                drWorkPlanDetail = dtWorkPlanDetail.NewRow();

                drWorkPlanDetail["WorkDep"] = dt.Rows[i]["WorkDepment"];
                drWorkPlanDetail["iQuantity"] = dt.Rows[i]["QtyNow"];
                //drWorkPlanDetail["iNum"] = dt.Rows[i]["iNum"];
                drWorkPlanDetail["GUIDHead"] = dt.Rows[i]["GUID"];
                drWorkPlanDetail["GUID"] = sGuid;
                drWorkPlanDetail["dtmDay"] = dt.Rows[i]["dtm1"];
                drWorkPlanDetail["vchruid"] = FrameBaseFunction.ClsBaseDataInfo.sUid;
                drWorkPlanDetail["vchrPer"] = dt.Rows[i]["vchrPer"];
                drWorkPlanDetail["vchrFacility"] = dt.Rows[i]["vchrEquipment"];
                drWorkPlanDetail["workTime"] = dt.Rows[i]["WorkTime"];
                drWorkPlanDetail["RDInType"] = dt.Rows[i]["RDInType"];
                drWorkPlanDetail["workDepmentNext2"] = dt.Rows[i]["workDepmentNext2"];
                drWorkPlanDetail["QtyRDIn"] = dt.Rows[i]["QtyRDIn"];
                drWorkPlanDetail["QtyRDL"] = dt.Rows[i]["QtyRDL"];

                if (dt.Rows[i]["RDInType"].ToString().Trim() == "1" || dt.Rows[i]["workDepmentNext2"].ToString().Trim() == "仓库")
                {
                    drWorkPlanDetail["EnSureUid"] = "L";
                    drWorkPlanDetail["EnSureDate"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                }

                dtWorkPlanDetail.Rows.Add(drWorkPlanDetail);
            }

            if (sErr.Trim().Length > 0)
            {
                FrmMsgBox fMsgBos = new FrmMsgBox();
                fMsgBos.Text = "错误";
                fMsgBos.richTextBox1.Text = sErr;
                fMsgBos.richTextBox1.ReadOnly = true;
                fMsgBos.ShowDialog();
                return;
            }

            for (int i = 0; i < dtWorkPlanDetail.Rows.Count; i++)
            {
                sSQL = clsGetSQL.GetInsertSQL("UFDLImport", "WorkPlanDetail", dtWorkPlanDetail, i);
                aList.Add(sSQL);
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                gridControl1.DataSource = null;
                MessageBox.Show("工序转移成功！");
                dtTable.Clear();
            }
        }

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtBarCode.Text.Trim() == string.Empty)
                {
                    return;
                }
               
                if (e.KeyCode == Keys.Enter)
                {
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        if (txtBarCode.Text.Trim() == dtTable.Rows[i]["autoid"].ToString().Trim())
                        {
                            MessageBox.Show("本条码已经扫描！");
                            return;
                        }
                    }

                    string sSQL = "select isnull(w.bRDIn,0) as RDInType,isnull(wd.worktime,0) as WorkTime,w.cinvcode2,isnull(w.dtmPlan,'1900-1-1') as dtmPlan,isnull(w.bRDIn,0) as bRDIn,w.vchrPer,w.vchrEquipment,w.GUID ,w.AutoID,WorkOrderID,WorkOrderNO,WorkOrderRowNO,w.cInvCode,i.cInvName,i.cInvStd,case when isnull(w.bRDIn,0) = 1 then '仓库' else wd.workDepmentNext2 end as workDepmentNext2,isnull(w.iQuantity,0) as iQuantity,workProcedure,wp.fName as workProcedureName,workProcedureNext," +
                                     "wp2.fName as workProcedureNextName,w.workDepment,wDep.fName, 	sum(isnull(wd.iQuantity,0)) as wdiQty,null as wddiQty,null as QtyIng,null as QtyNow,null as QtyRDIn,null as QtyRDL,null as WorkQtyY,cast(null as varchar(50)) as SoCode,'" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' as dtm1  " +
                                     ",w.iQtyPlan as 预计计划数量 " +
                                     "from UFDLImport..WorkPlan w left join UFDLImport..WorkPlanDetail wd on w.Guid = wd.GuidHead left join @u8.Inventory i on i.cInvcode = w.cInvCode left join UFDLImport..WorkDepment wDep on wDep.FCode = w.workDepment 	left join UFDLImport..WorkingProcedure wp on wp.fCode = w.workProcedure left join UFDLImport..WorkingProcedure wp2 on wp2.fCode = w.workProcedureNext  " +
                                     "where 1=1 and isnull(bRDIn,0) <> 0 and w.autoid = " + txtBarCode.Text.Trim() + " and w.AccID='200' and w.AccYear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and isnull(w.bClose,0) = 0  " +
                                     "group by w.cinvcode2,w.dtmPlan,w.GUID ,w.bRDIn,w.AutoID,WorkOrderID,WorkOrderNO,WorkOrderRowNO,w.cInvCode,i.cInvName,i.cInvStd,wd.workDepmentNext2,w.iQuantity,w.iQtyPlan,workProcedure,wp.fName,workProcedureNext,wp2.fName,w.workDepment,wDep.fName,w.vchrPer,w.vchrEquipment,worktime ";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("该条码不存在，或该条码用于工序转移！");
                        return;
                    }

                    sSQL = "select sum(isnull(wdd.iQuantity,0)) as iQuantity from UFDLImport..WorkPlan w left join UFDLImport..WorkPlanDetail wd on w.guid = wd.guidhead  " +
                                "	left join UFDLImport..WorkPlanDetailDefective wdd on wd.guid = wdd.guidhead " +
                                "where 1=1 and w.autoid = " + txtBarCode.Text.Trim() + " and AccID='200' and AccYear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' and isnull(w.bClose,0) = 0  ";
                    DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);
                    if (dt2.Rows.Count > 0)
                    {
                        dt.Rows[0]["wddiQty"] = dt2.Rows[0]["iQuantity"];
                        dt.Rows[0]["QtyIng"] = (Convert.ToInt64(dt.Rows[0]["iQuantity"]) - Convert.ToInt64(dt.Rows[0]["wdiQty"]) - Convert.ToInt64(dt2.Rows[0]["iQuantity"])).ToString().Trim();
                        dt.Rows[0]["QtyNow"] = dt.Rows[0]["QtyIng"];
                        if (Convert.ToInt32(dt.Rows[0]["bRDIn"]) == 1)
                        {
                            dt.Rows[0]["QtyRDIn"] = dt.Rows[0]["QtyIng"];
                            dt.Rows[0]["QtyRDL"] = 0; 
                        }
                        if (Convert.ToInt32(dt.Rows[0]["bRDIn"]) == 2)
                        {
                            dt.Rows[0]["QtyRDIn"] = 0;
                            dt.Rows[0]["QtyRDL"] = dt.Rows[0]["QtyIng"];
                        }

                        if (dt.Rows[0]["QtyIng"] != null && dt.Rows[0]["QtyIng"].ToString().Trim() != "" && Convert.ToDouble(dt.Rows[0]["QtyIng"]) == 0)
                        {
                            DialogResult d = MessageBox.Show("生产订单余量为0，是否继续执行？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk);
                            if (d == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }

                    sSQL = "select (sum(isnull(Qty,0))-sum(isnull(QualifiedInQty,0))) as QualifiedInQty,InvCode,sum(Qty) as Qty,cast(max(SoCode) as varchar(50)) as SoCode " +
                            "from @u8.mom_order m left join @u8.mom_orderdetail md on m.moid = md.moid " +
                            "where mocode = '" + dt.Rows[0]["WorkOrderNO"].ToString().Trim() + "' and (InvCode = '" + dt.Rows[0]["cinvcode2"].ToString().Trim() + "' or invCode = '" + dt.Rows[0]["cinvcode"].ToString().Trim() + "') " +
                            "group by InvCode";
                    dt2 = clsSQLCommond.ExecQuery(sSQL);
                    if (dt2.Rows.Count > 0)
                    {
                        dt.Rows[0]["WorkQtyY"] = dt2.Rows[0]["QualifiedInQty"];
                        dt.Rows[0]["SoCode"] = dt2.Rows[0]["SoCode"];
                    }

                    DataRow dr = dtTable.NewRow();
                    for (int i = 0; i < dtTable.Columns.Count; i++)
                    {
                        dr[i] = dt.Rows[0][i];
                    }
                    dtTable.Rows.Add(dr);
                    gridControl1.DataSource = dtTable;

                    txtBarCode.Text = "";
                    txtBarCode.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("条码输入失败！ \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 获得设备信息
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
                throw new Exception("获得设备信息失败！" + ee.Message);
            }
        }

        /// <summary>
        /// 班组信息
        /// </summary>
        private void GetworkDepment()
        { 
            try
            {
                string sSQL = "select cDepCode as FCode,cDepName as FName from @u8.Department where bDepEnd = 1 ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                ItemLookUpEditworkDepmentNext.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception("获得设备信息失败！" + ee.Message);
            }
        }

        /// <summary>
        ///获得缴库类型
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
                dr["RdInName"] = "缴库";
                dr["RdInType"] = "1";
                dt.Rows.Add(dr); 
                dr = dt.NewRow();
                dr["RdInName"] = "流转";
                dr["RdInType"] = "2";
                dt.Rows.Add(dr);

                ItemLookUpRdInType.DataSource = dt;
            }
            catch (Exception ee)
            {
                throw new Exception("获得缴库类型信息失败！" + ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iRow = 0;
                if (gridView1.RowCount > 0)
                {
                    iRow = gridView1.FocusedRowHandle;
                }
                if (e.Column == gridColRDInType)
                {
                    if (Convert.ToInt32(gridView1.GetRowCellValue(iRow, gridColRDInType)) == 1)
                    {
                        gridView1.SetRowCellValue(iRow, gridColworkDepmentNext, "仓库");
                        gridColworkDepmentNext.OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        gridColworkDepmentNext.OptionsColumn.AllowEdit = true;
                    }
                }
                if (e.Column == gridColworkDepmentNext)
                {
                    if (Convert.ToInt32(gridView1.GetRowCellValue(iRow, gridColRDInType)) == 1 && gridView1.GetRowCellValue(iRow, gridColworkDepmentNext).ToString().Trim() != "仓库")
                    {
                        gridView1.SetRowCellValue(iRow, gridColworkDepmentNext, "仓库");
                    }
                    if (Convert.ToInt32(gridView1.GetRowCellValue(iRow, gridColRDInType)) != 1 && gridView1.GetRowCellValue(iRow, gridColworkDepmentNext).ToString().Trim() == "仓库")
                    {
                        gridView1.SetRowCellValue(iRow, gridColRDInType, 1);
                    }
                }
                if (e.Column == gridColQtyRDIn)
                {
                    decimal d1 = 0;
                    decimal d2 = 0;
                    if (gridView1.GetRowCellValue(iRow, gridColQtyRDIn).ToString().Trim() != "")
                    {
                        d1 = Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridColQtyRDIn));
                    }
                    if (gridView1.GetRowCellValue(iRow, gridColQtyRDL).ToString().Trim() != "")
                    {
                        d2 = Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridColQtyRDL));
                    }
                    gridView1.SetRowCellValue(iRow, gridColQtyNow, d1 + d2);
                }
                if (e.Column == gridColQtyRDL)
                {
                    decimal d1 = 0;
                    decimal d2 = 0;
                    if (gridView1.GetRowCellValue(iRow, gridColQtyRDIn).ToString().Trim() != "")
                    {
                        d1 = Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridColQtyRDIn));
                    }
                    if (gridView1.GetRowCellValue(iRow, gridColQtyRDL).ToString().Trim() != "")
                    {
                        d2 = Convert.ToDecimal(gridView1.GetRowCellValue(iRow, gridColQtyRDL));
                    }
                    gridView1.SetRowCellValue(iRow, gridColQtyNow, d1 + d2);
                }
            }
            catch { }
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
    }
}