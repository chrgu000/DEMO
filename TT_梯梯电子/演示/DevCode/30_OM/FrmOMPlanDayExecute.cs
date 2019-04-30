using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FrameBaseFunction;

namespace OM
{
    public partial class FrmOMPlanDayExecute : FrameBaseFunction.Frm列表窗体模板
    {
        public DataTable dtOM;

        public FrmOMPlanDayExecute()
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
                        btnLoad();
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

 
        /// <summary>
        /// 当前日计划
        /// </summary>
        private void btnLoad()
        {
            string sSQL = "select o.cDepCode,o.ImportDate,oII.cCode,cast (null as decimal(16,2)) as iSumOutQty,cast (null as decimal(16,2)) as iYuQty,'' as bChoose,o.ID,o.cCode,o.iID,o.Soid,o.sodid,o.SoCode,o.SoSeq,o.PlanCode,o.InvCode,o.InvName,o.InvStd,o.ComUnitCode,o.ComUnitName,o.PlanQty,o.QtyNow,o.StartDate2, " +
                                      "o.DueDate2,o.date1,o.date2,o.cVenCode,o.cVenName,o.iTaxPrice,o.iTaxRate,o.Accid,o.AccYear,o.cAssComUnitCode,o.CompScrap,o.BaseQtyD,o.BaseQtyN,o.bomID,  " +
                                      "o.cDefWareHouse,o.ParentScrap,o.cInvCode,o.cInvName,o.cInvStd,o.iSupplyType,o.OpComponentid,o.ChangeRate,o.UseQty,o.UseNum,o.cComUnitCodeI,  " +
                                      "o.cAssComUnitCodeI,o.unitCode1,o.unitCode2,o.iQuantityI,o.iNumI,o.bUse,o.使用数量,o.辅助使用数量 ,oI.Qty as DidQty,o.invSZ,o.invSM ," +
                                      "isnull(i.fInExcess,0) as fInExcess,a.iQty as  iSendT,isnull(oII.EnSureUser,'') as EnSureUser,oII.EnSureDate,oII.EnSureDepment,o.iType,cast(null as decimal(16,6)) as CurrQtyI,cast(null as decimal(16,6)) as CurrNumI,cast (null as decimal(16,2)) as iQtyCanOut " +
                        "from UFDLImport..OMPlanDay o " +
                                " left join (select SUM(o.iQuantity) as Qty,OMPlanID from UFDLImport..OMPlan_Import om inner join  @u8.OM_MODetails o on o.MODetailsID = om.OM_MODetailsID and accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' group by OMPlanID) oI on o.iID = oI.OMPlanID " +
                                " left join @u8.Inventory i on i.cInvCode = o.InvCode " + 
                                " left join (select cInvCode,cWhCode,sum(isnull(iQuantity,0)) as iQuantity,sum(isnull(iNum,0)) as iNum from @u8.CurrentStock group by cInvCode,cWhCode) c on c.cInvCode = o.cInvCode and c.cWhCode = o.cDefWareHouse " +
                                " left join (select OMPlanID,min(iQty) as iQty from (select oI.OMPlanID,od.cInvCode,sum(odM.iSendQTY/(odM.iQuantity/od.iQuantity)) as iQty from @u8.OM_MODetails od inner join @u8.OM_MOMaterials odM on od.MoDetailsID = odM.MODetailsID inner join @u8.OM_MOMain o on o.MOID = od.MOID inner join UFDLImport.dbo.OMPlan_Import oI on oI.OM_MODetailsID = od.MoDetailsID and accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' group by od.cInvCode,oI.OMPlanID ) a group by OMPlanID) a on a.OMPlanID = o.iID " +
                                " left join UFDLImport..OMPlanDay_Info oII on oII.iID = o.iID and o.cCode = oII.cCode " +
                           "where o.cCode like '" + datePlan.DateTime.ToString("yyMMdd") + "%' and accid = '200' and accyear = '" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4) + "' ";
            
            if (lookUpEditVenDep.Text.Trim() != "")
            {
                sSQL = sSQL + " and O.cDepCode = '" + lookUpEditVenDep.EditValue + "' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "生管")
            {
                sSQL = sSQL + " and  oII.EnSureDepment = '生管' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "采购")
            {
                sSQL = sSQL + " and   oII.EnSureDepment = '采购' ";
            }
            if (lookUpEditEnSure.Text.Trim() == "委外")
            {
                sSQL = sSQL + " and  oII.EnSureDepment = '委外' ";
            }

            sSQL = sSQL + " order by o.sodid,o.SoCode,o.SoSeq,o.ID ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            sSQL = "@u8.[_procDolleBalance] '" + datePlan.DateTime.ToString("yyyy-MM-dd") + "','" + datePlan.DateTime.ToString("yyyy-MM-dd") + "',1";
            DataTable dtCurr = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string siInvCode = dt.Rows[i]["cInvCode"].ToString().Trim();
                for (int j = 0; j < dtCurr.Rows.Count; j++)
                {
                    string siInvCode2 = dtCurr.Rows[j]["物料编码"].ToString().Trim();
                    if (siInvCode == siInvCode2)
                    {
                        dt.Rows[i]["CurrQtyI"] = dtCurr.Rows[j]["期末结余"];
                    }
                }
            }

            gridControl1.DataSource = dt;
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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOMPlanDayExecute_Load(object sender, EventArgs e)
        {
            try
            {
                GetDepInfo();
                GetlookUpEditEnSure();
                GetWareHouse();

                datePlan.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！原因：" + ee.Message);
            }
        }

     
        /// <summary>
        /// 获得供应商信息
        /// </summary>
        /// <param name="sVenCode"></param>
        /// <returns></returns>
        private DataTable GetVendor(string sVenCode)
        {
            try
            {
                string sSQL = "select cVenCode as iID,cVenName as iText from @u8.Vendor where cVenCode = '" + sVenCode + "' order by cVenCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                return dt;
            }
            catch
            {
                throw new Exception("获得供应商信息失败！");
            }
        }

       

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if ((this.gridView1.GetDataRow(e.RowHandle1)["iID"].ToString() != this.gridView1.GetDataRow(e.RowHandle2)["iID"].ToString()))
                e.Handled = true;
        }

    
  
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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
        /// 供应商部门
        /// </summary>
        private void GetDepInfo()
        {
            try
            {
                string sSQL = "select distinct v.cVenDepart as iID,d.cDepName as iText from @u8.vendor v left join @u8.Department d on v.cVenDepart = d.cDepCode where v.cVenDepart is not null order by v.cVenDepart,d.cDepName ";
                DataTable dt = clsGetSQL.GetLookUpEdit(sSQL);
                ItemLookUpEditVenDepartment.DataSource = dt;
                lookUpEditVenDep.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得部门信息失败！" + ee.Message);
            }
        }


        private void GetlookUpEditEnSure()
        {
            try
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "iID";
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                dr["iID"] = DBNull.Value;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = "生管";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = "采购";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["iID"] = "委外";
                dt.Rows.Add(dr);

                lookUpEditEnSure.Properties.DataSource = dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show("获得计划确认信息失败！" + ee.Message);
            }
        }

        private void GetWareHouse()
        {
            string sSQL = "select cWhCode,cWhName,bFreeze from @u8.Warehouse where bFreeze = 0 order by cWhCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditWoreHouse.DataSource = dt;
        }
    }
}