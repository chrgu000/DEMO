﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using FrameBaseFunction;
using System.Data.SqlClient;

namespace SaleOrder
{
    public partial class Frm评审状态查看 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm评审状态查看()
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
            gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            }

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
                    case "addrow":
                        btnAddRow();
                        break;
                    case "alter":
                        btnAlter();
                        break;
                    case "audit":
                        btnAudit();
                        break;
                    case "add":
                        btnAdd();
                        break;
                    case "del":
                        btnDel();
                        break;
                    case "delrow":
                        btnDelRow();
                        break;
                    case "edit":
                        btnEdit();
                        break;
                    case "export":
                        btnExport();
                        break;
                    case "first":
                        btnFirst();
                        break;
                    case "import":
                        btnImport();
                        break;
                    case "last":
                        btnLast();
                        break;
                    case "lock":
                        btnLock();
                        break;
                    case "next":
                        btnNext();
                        break;
                    case "prev":
                        btnPrev();
                        break;
                    case "print":
                        btnPrint();
                        break;
                    //case "printset":
                    //    btnPrintSet();
                    //    break;
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;
                    case "sel":
                        btnSel();
                        break;
                    case "unaudit":
                        btnUnAudit();
                        break;
                    case "undo":
                        btnUnDo();
                        break;
                    case "unlock":
                        btnUnLock();
                        break;
                    case "open":
                        btnOpen();
                        break;
                    case "close":
                        btnClose();
                        break;
                    case "layout":
                        btnLayout(sBtnText);
                        break;
                    default:
                        break;
                }

                sState = sBtnName.ToLower();
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        DataTable dt评审 = new DataTable();

        private void btnAdd()
        {
           
        }

        #region 按钮模板

        ///// <summary>
        ///// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
        //    DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "StateText";
        //    dt.Columns.Add(dc);
           
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
        //        if (drState.Length > 0)
        //        {
        //            dt.Rows[i]["StateText"] = drState[0]["State"];
        //        }

        //    }

            return dt;
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


                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
                    gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
                }
                else if (d == DialogResult.No)
                {
                    if (File.Exists(sLayoutHeadPath))
                        File.Delete(sLayoutHeadPath);

                    if (File.Exists(sLayoutGridPath))
                        File.Delete(sLayoutGridPath);
                }
            }
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {

        }

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            string sSQL = @"
select  cast(0 as bit) as 选择, a.销售订单号, a.外销订单号, a.客户订单号, a.客户编号, a.评审备注
		, a.制单人, a.制单日期
		, a.审核人, a.审核日期
		, a.关闭人, a.关闭日期
		,case when isnull(a.下达请购人,'') = '' and isnull(b.采购,0) = 0 then '√' else a.下达请购人 end as 下达请购人, a.下达请购日期
		,case when isnull(a.下达委外人,'') = '' and isnull(b.委外,0) = 0 then '√' else a.下达委外人 end as 下达委外人, a.下达委外日期
		,case when isnull(a.下达生产人,'') = '' and isnull(b.自制,0) = 0 then '√' else a.下达生产人 end as 下达生产人, a.下达生产日期
        , a.维护审核人, a.维护审核日期
        , a.备注
        ,isnull(a.已维护,0) as 已维护
from dbo.订单评审运算1 a inner join 
	(
		select 销售订单ID,SUM(采购) as 采购,SUM(委外) as 委外,SUM(自制) as 自制
		from
		(
		select 销售订单ID,case when 子件属性 = '采购' then COUNT(1) end as 采购
			,case when 子件属性 = '委外' then COUNT(1) end as 委外
			,case when 子件属性 = '自制' then COUNT(1) end as 自制
		from 订单评审运算3
		group by 销售订单ID,子件属性
		)a
		group by 销售订单ID
	)b on a.销售订单ID = b.销售订单ID
where 帐套号 = '200' and 1=1 and a.制单日期 >= '2013-09-30' and a.制单日期 <= '2013-11-13' 
";

            sSQL = sSQL.Replace("200", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
            sSQL = sSQL.Replace("2013-09-30", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("2013-11-13", dateEdit2.DateTime.ToString("yyyy-MM-dd"));


            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            for(int i=0;i<gridView1.Columns.Count;i++)
            {
                if (gridView1.Columns[i].FieldName == "选择")
                {
                    gridView1.Columns[i].OptionsColumn.ReadOnly = false;
                }
                else
                {
                    gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {

            }
            catch { }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {

            }
            catch { }

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {

            }
            catch { }
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {

            }
            catch { }
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridView1.Columns["选择"])))
                {
                    sSQL = "update dbo.订单评审运算1 set 已维护 = 1 where 销售订单号 = '" + gridView1.GetRowCellValue(i, gridView1.Columns["销售订单号"]).ToString().Trim() + "'";
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("标记处理成功");
            }
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            aList = new System.Collections.ArrayList();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (Convert.ToBoolean(gridView1.GetRowCellValue(i, gridView1.Columns["选择"])))
                {
                    sSQL = "update dbo.订单评审运算1 set 已维护 = null where 销售订单号 = '" + gridView1.GetRowCellValue(i, gridView1.Columns["销售订单号"]).ToString().Trim() + "'";
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("取消标记成功");
            }
        }
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {
            gridView1.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {

        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {

        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
          

        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {

        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {

        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {

        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm订单评审查看_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = DateTime.Today.AddMonths(-6);
                dateEdit2.DateTime = DateTime.Today;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView评审_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
