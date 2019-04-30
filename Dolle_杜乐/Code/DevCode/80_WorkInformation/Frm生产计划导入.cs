using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WorkInformation
{
    public partial class Frm生产计划导入 : Form
    {

        DataTable dtWorkPlanDay = new DataTable();
        bool bCheck = false;
        FrameBaseFunction.ClsDataBase clsSQLCommond = FrameBaseFunction.ClsDataBaseFactory.Instance();


        public Frm生产计划导入(DataTable dt)
        {
            InitializeComponent();

            dtWorkPlanDay = dt.Copy();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string sText = "";
            try
            {

                if (gridView1.RowCount < 1)
                {
                    MessageBox.Show("请先加载数据！");
                    return;
                }


                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    try
                    {
                        if (gridView1.GetRowCellDisplayText(i, g班组).ToString().Trim() == "裁切")
                        {

                        }

                        if (gridView1.GetRowCellDisplayText(i, g班组).ToString().Trim() == "")
                        {
                            gridView1.SetRowCellValue(i, g选择, "×");
                            continue;
                        }

                        if (gridView1.GetRowCellDisplayText(i, g下一班组).ToString().Trim() == "")
                        {
                            gridView1.SetRowCellValue(i, g选择, "×");
                            continue;
                        }

                        string sSQL = "select [Status],MoCode,InvCode,md.modid, i.cInvName,i.cInvStd " +
                                        "from @u8.mom_orderdetail md inner join @u8.mom_order m on m.MoId=md.moid  inner join @u8.Inventory i on i.cInvCode = md.invCode " +
                                        "where [Status] = 3 and m.mocode = '" + gridView1.GetRowCellValue(i, g制造令号码).ToString().Trim() + "' and InvCode = '" + gridView1.GetRowCellValue(i, g物料编码).ToString().Trim() + "' " +
                                        "order by m.mocode,md.SortSeq";
                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

                        if (gridView1.GetRowCellValue(i, g下道工序).ToString().Trim() != "完工入库" && dtTemp.Rows.Count < 1)
                        {
                            sSQL = "select '' as modid,cInvName,cInvStd from @u8.Inventory where cInvCode = '" + gridView1.GetRowCellValue(i, g物料编码).ToString().Trim() + "' ";

                            dtTemp = clsSQLCommond.ExecQuery(sSQL);

                            if (dtTemp.Rows.Count == 0)
                            {
                                DataRow dr = dtTemp.NewRow();
                                dr["modid"] = "";
                                dr["cInvName"] = gridView1.GetRowCellDisplayText(i, g产品名称).ToString().Trim();
                                dr["cInvStd"] = gridView1.GetRowCellDisplayText(i, g产品规格).ToString().Trim();

                                dtTemp.Rows.Add(dr);
                            }
                        }

                        if (dtTemp.Rows.Count >= 1)
                        {
                            gridView1.SetRowCellValue(i, g行号, i + 1);
                            gridView1.SetRowCellValue(i, g生产订单ID, dtTemp.Rows[0]["modid"]);
                            gridView1.SetRowCellValue(i, g产品名称, dtTemp.Rows[0]["cInvName"]);
                            gridView1.SetRowCellValue(i, g产品规格, dtTemp.Rows[0]["cInvStd"]);
                            if (gridView1.GetRowCellDisplayText(i, g计划日期).ToString().Trim() != "" && gridView1.GetRowCellDisplayText(i, g下一班组).ToString().Trim() != "" && gridView1.GetRowCellDisplayText(i, g班组).ToString().Trim() != "" && gridView1.GetRowCellDisplayText(i, g工序).ToString().Trim() != "" && gridView1.GetRowCellDisplayText(i, g制造令数量).ToString().Trim() != "")
                            {
                                gridView1.SetRowCellValue(i, g选择, "√");
                            }
                            else
                            {
                                gridView1.SetRowCellValue(i, g选择, "×");
                            }

                            if (!isNumber(gridView1.GetRowCellDisplayText(i, g制造令数量).ToString().Trim()))
                            {
                                gridView1.SetRowCellValue(i, g选择, "×");
                            }

                        }
                        else
                        {
                            gridView1.SetRowCellValue(i, g选择, "×");
                        }
                        sSQL = "select * from UFDLImport.dbo.WorkPlan " +
                                "where workorderno = '" + gridView1.GetRowCellValue(i, g制造令号码).ToString().Trim() + "' and cinvcode = '" + gridView1.GetRowCellValue(i, g物料编码).ToString().Trim() + "' and workprocedure = '" + gridView1.GetRowCellValue(i, g工序).ToString().Trim() + "' " +
                                        " and dtmPlan = '" + gridView1.GetRowCellValue(i, g计划日期).ToString().Trim() + "' and accid = '200' ";
                        DataTable dtTemp2 = clsSQLCommond.ExecQuery(sSQL);
                        if (dtTemp2.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(i, g选择, "已导入！");
                        }
                    }
                    catch (Exception ee)
                    {
                        gridView1.SetRowCellValue(i, g选择, "×");

                        sText = sText + "\n" + ee.Message;
                    }
                }

                if (sText.Trim() != string.Empty)
                {
                    throw new Exception(sText);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            bCheck = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount < 1)
                {
                    MessageBox.Show("请先加载数据！");
                    return;
                }

                if (!bCheck)
                {
                    MessageBox.Show("请先验证数据！");
                    return;
                }

                ArrayList aList = new ArrayList();
                string sSQL = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, g选择).ToString().Trim() == "√")
                    {
                        int bRDIn = 0;      //是否需要入库
                        if (gridView1.GetRowCellValue(i, g是否入库).ToString().ToUpper().Trim() == "Y" || gridView1.GetRowCellValue(i, g是否入库).ToString().ToUpper().Trim() == "是")
                        {
                            bRDIn = 1;
                        }
                        if (gridView1.GetRowCellValue(i, g是否入库).ToString().ToUpper().Trim() == "L" || gridView1.GetRowCellValue(i, g是否入库).ToString().ToUpper().Trim() == "流")
                        {
                            bRDIn = 2;
                        }

                        string s托外结束时间 = "null";
                        if (gridView1.GetRowCellValue(i, g托外结束时间).ToString().Trim() != "")
                        {
                            try
                            {
                                s托外结束时间 = "'" + Convert.ToDateTime(gridView1.GetRowCellValue(i, g托外结束时间)).ToString("yyyy-MM-dd") + "'";
                            }
                            catch { }
                        }

                        string s = gridView1.GetRowCellValue(i, g理论工时).ToString().Trim();
                        if (s == "")
                            s = "null";
                        else
                            s = "'" + s + "'";


                        sSQL = "INSERT INTO UFDLImport..[WorkPlan] ( [WorkOrderNO] ,[cInvCode] ,[iQuantity2] , " +
                                    "[workProcedure] ,[workProcedureNext] , " +
                                    "[AccID] ,[AccYear] ,[sOrder] ,[sUid] , " +
                                    "[workDepment] ,[workDepmentNext] , " +
                                    "[dtmPlan] ,[cInvCode2] ,[cInvCode3] ,[cInvName] ,[cInvStd] ,[iQtyPlan], " +
                                    "[iQuantity],vchrPer,vchrEquipment,dtmTime ,bRDIn,vchrRemark,托外结束时间) VALUES (" +
                        "'" + gridView1.GetRowCellValue(i, g制造令号码) + "','" + gridView1.GetRowCellValue(i, g物料编码) + "','" + gridView1.GetRowCellValue(i, g制造令数量) + "' " +
                        ",'" + gridView1.GetRowCellValue(i, g工序) + "','" + gridView1.GetRowCellValue(i, g下道工序) + "' " +
                        ",'200','" + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11,4) + "','" + gridView1.GetRowCellValue(i, g外销订单) + "','" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' " +
                        ",'" + gridView1.GetRowCellValue(i, g班组) + "','" + gridView1.GetRowCellValue(i, g下一班组) + "' " +
                        ",'" + gridView1.GetRowCellValue(i, g计划日期) + "','" + gridView1.GetRowCellValue(i, g产品编码) + "'  " +
                        ",'" + gridView1.GetRowCellValue(i, g半成品编码) + "','" + gridView1.GetRowCellValue(i, g产品名称) + "'  " +
                        ",'" + gridView1.GetRowCellValue(i, g产品规格) + "','" + gridView1.GetRowCellValue(i, g预计计划数量) + "','" + gridView1.GetRowCellValue(i, g计划数量) + "' " +
                        ",'" + gridView1.GetRowCellValue(i, g人员) + "','" + gridView1.GetRowCellValue(i, g设备) + "'," + s + "," + bRDIn + ",'" + gridView1.GetRowCellValue(i, g备注) + "'," + s托外结束时间 + ") ";

                        aList.Add(sSQL);
                    }
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("导入失败:" + ee.Message);
            }
        }

        private void Frm生产计划导入_Load(object sender, EventArgs e)
        {
            try
            {
                GetDepartment();

                gridControl1.DataSource = dtWorkPlanDay;

                gridControl1.Enabled = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private bool isNumber(object o)
        {
            bool b = false;
            try
            {
                double d = Convert.ToDouble(o);
                b = true;
            }
            catch { }
            return b;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
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
            catch { }
        }
        /// <summary>
        /// 建立U8与吕云系统的部门对应信息
        /// </summary>
        /// <param name="sDep"></param>
        /// <returns></returns>
        private string sDepInfo(string sDep)
        {
            string sDepU8Name = "";
            switch (sDep)
            {
                case "冲压组": sDepU8Name = "冲压"; break;
                case "焊接组": sDepU8Name = "电焊"; break;
                case "冲压": sDepU8Name = "冲压"; break;
                case "出冲压": sDepU8Name = "冲压"; break;
                case "电焊组": sDepU8Name = "电焊"; break;
                case "拉伸": sDepU8Name = ""; break;
                case "拉伸孔": sDepU8Name = ""; break;
                case "铝件组": sDepU8Name = "铝件"; break;
                case "品管部": sDepU8Name = "品检"; break;
                case "铁件组": sDepU8Name = "铁件组"; break;
                case "维护组": sDepU8Name = "维护组"; break;
                case "委外部": sDepU8Name = "委外部"; break;
                case "物控部": sDepU8Name = "委外部"; break;
                case "研发部": sDepU8Name = "研发"; break;
                case "组装": sDepU8Name = "组装"; break;
                case "组装组": sDepU8Name = "组装"; break;
                case "采购部": sDepU8Name = "采购"; break;
                case "生管部": sDepU8Name = "生管部"; break;
                case "销售/人事部": sDepU8Name = "人事"; break;
                case "财务部": sDepU8Name = "财务"; break;
                case "生产部": sDepU8Name = "生产"; break;
                case "裁切组": sDepU8Name = "裁切"; break;
                case "办公室": sDepU8Name = "人事"; break;

                default: sDepU8Name = sDep; break;
            }
            return sDepU8Name;
        }
        private void GetDepartment()
        {
            string sSQL = "select * from @u8.Department order by cDepCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditDepartment.DataSource = dt;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
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
    }
}
