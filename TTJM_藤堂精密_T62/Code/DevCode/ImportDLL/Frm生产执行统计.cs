using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Data.SqlClient;
using FrameBaseFunction;

namespace ImportDLL
{
    public partial class Frm生产执行统计 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL._GetBaseData DALGetBaseData = new TH.DAL._GetBaseData();

        DataTable dtGridInfo;

        string sTable = "";

        public Frm生产执行统计()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            gridView1.OptionsCustomization.AllowColumnMoving = true;
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            //sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            //sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            //if (File.Exists(sLayoutHeadPath))
            //    layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            //if (File.Exists(sLayoutGridPath))
            //{
            //    gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            //}

            dtBingGrid = new DataTable();
            dtBingHead = new DataTable();

        }

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "sel":
                        btnSel();
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
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnSel()
        {
            GetGrid();
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            //DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "StateText";
            //dt.Columns.Add(dc);
           
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
            //    if (drState.Length > 0)
            //    {
            //        dt.Rows[i]["StateText"] = drState[0]["State"];
            //    }

            //}

            //return dt;
            return null;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            base.dsPrint.Tables.Clear();
            DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
            dtGrid.TableName = "dtGrid";

            base.dsPrint.Tables.Add(dtGrid);
            DataTable dtHead = dtBingHead.Copy();
            dtHead.TableName = "dtHead";
            base.dsPrint.Tables.Add(dtHead);
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
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

        private void btnLayout(string sText)
        {
            if (layoutControl1 == null) return;
            if (sText == "布局")
            {
                //layoutControl1.ShowCustomizationForm();
                layoutControl1.AllowCustomizationMenu = true;
                base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

                gridView1.OptionsMenu.EnableColumnMenu = true;
                gridView1.OptionsMenu.EnableFooterMenu = true;
                gridView1.OptionsMenu.EnableGroupPanelMenu = true;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
                gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
                gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
                gridView1.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                gridView1.OptionsMenu.EnableColumnMenu = false;
                gridView1.OptionsMenu.EnableFooterMenu = false;
                gridView1.OptionsMenu.EnableGroupPanelMenu = false;
                //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
                gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
                gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
                gridView1.OptionsCustomization.AllowColumnMoving = false;


                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：取消保存", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    int iCou = 0;
                    SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                    conn.Open();
                    //启用事务
                    SqlTransaction tran = conn.BeginTransaction();
                    try
                    {
                        sSQL = @"update [dbo].[列表设置] set [可见] = 0 where 库名 = '.' and [表名] = '111111'";
                        sSQL = sSQL.Replace("111111", sTable);
                        DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                        for (int i = 0; i < gridView1.Columns.Count; i++)
                        {
                            int iW = gridView1.Columns[i].Width;
                            string sColName = gridView1.Columns[i].FieldName.Trim();
                            string sColText = gridView1.Columns[i].Caption.Trim();
                            int iIndex = gridView1.Columns[i].VisibleIndex;
                            bool bVis = gridView1.Columns[i].Visible;

                            sSQL = @"update [dbo].[列表设置] set [排序] = 444444,[可见] = 555555, [宽度] = " + iW + " where 库名 = '.' and [表名] = '111111' and [列名] = '222222' and [列标题] = '333333'";
                            sSQL = sSQL.Replace("111111", sTable);
                            sSQL = sSQL.Replace("222222", sColName);
                            sSQL = sSQL.Replace("333333", sColText);
                            sSQL = sSQL.Replace("444444", iIndex.ToString().Trim());
                            if (bVis)
                            {
                                sSQL = sSQL.Replace("555555", "1");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("555555", "0");
                            }
                            iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        }
                        if (iCou > 0)
                        {
                            tran.Commit();
                        }
                        else
                        {
                            tran.Rollback();
                        }
                    }
                    catch (Exception error)
                    {
                        tran.Rollback();

                        throw new Exception(error.Message);
                    }
                }
            }
        }
        #endregion

     
      
        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                sTable = this.Text;

                gridView1.OptionsNavigation.EnterMoveNextColumn = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
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

       
        private void GetGrid()
        {
            try
            {
                Frm生产订单列表 frm = new Frm生产订单列表();
                frm.WindowState = FormWindowState.Normal;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {


                    long lIDDetails = frm.lIDDetails;

                    sSQL = @"
select distinct a.WorkProcessNo as 编码,b.WorkProcessName as 工序
from _产品工序 a inner join [WorkProcess] b on a.WorkProcessNo = b.WorkProcessNo 
where a.cInvCode in (

	select distinct b.cInvCode
	from @u8.PP_ProductPO a inner join @u8.PP_POMain b on a.ID = b.ID
	where 1=1 
		and b.MainId = aaaaaa 
)
order by a.WorkProcessNo 
";
                    sSQL = sSQL.Replace("aaaaaa", lIDDetails.ToString());
                    DataTable dtGridInfo = DbHelperSQL.Query(sSQL);

                    for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
                    {
                        if (gridView1.Columns[i].FieldName.IndexOf("gridCol_") == 0)
                        {
                            gridView1.Columns.RemoveAt(i);
                        }
                    }

                    for (int i = 0; i < dtGridInfo.Rows.Count; i++)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();

                        gridColumn1.Caption = dtGridInfo.Rows[i]["工序"].ToString().Trim();
                        gridColumn1.Name = "gridCol_" + dtGridInfo.Rows[i]["编码"].ToString().Trim();
                        gridColumn1.FieldName = "gridCol_" + dtGridInfo.Rows[i]["编码"].ToString().Trim();
                        gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gridColumn1.Visible = true;
                        gridColumn1.Width = 100;

                        gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1 });
                    }

                    sSQL = @"
select a.cCode as 生产订单号,b.MainId as 生产订单ID,c.箱号,b.cInvCode as 产品编码,i.cInvName as 产品名称,i.cInvStd as 规格型号,cast(b.fQuantity as decimal(16,2)) as 订单数量,b.cDefine26 as 装箱数
	,AddCol
from @u8.PP_ProductPO a inner join @u8.PP_POMain b on a.ID = b.ID
	left join 车间工序日报 c on b.MainId = c.生产订单ID
	left join [WorkProcess] d on c.工序 = d.WorkProcessNo
	left join @u8.Inventory i on b.cInvCode = i.cInvCode 
where 1=1 
    and b.MainId = aaaaaa 
group by a.cCode,b.MainId,c.箱号,b.cInvCode,i.cInvName,i.cInvStd,b.fQuantity,b.cDefine26
order by b.MainId,c.箱号
";
                    sSQL = sSQL.Replace("aaaaaa", lIDDetails.ToString());
                    for (int i = 0; i < dtGridInfo.Rows.Count; i++)
                    {
                        sSQL = sSQL.Replace(",AddCol", ",AddCol , min(case when c.工序 = '" + dtGridInfo.Rows[i]["编码"].ToString().Trim() + "' then CONVERT(varchar(100), c.登记日期, 102) end) as gridCol_" + dtGridInfo.Rows[i]["编码"].ToString().Trim());
                    }

                    sSQL = sSQL.Replace(",AddCol", "");

                    DataTable dtGrid = DbHelperSQL.Query(sSQL);
                    gridControl1.DataSource = dtGrid;

                    gridView1.BestFitColumns();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
