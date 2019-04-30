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

namespace ImportDLL
{
    public partial class Frm车间看板 : FrameBaseFunction.FrmFromModel
    {
        TH.DAL._GetBaseData DALGetBaseData = new TH.DAL._GetBaseData();

        public Frm车间看板()
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
            gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
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
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
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
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = oFile.FileName;
                string sSQL = @"
select 序号 as LineNo,产线 as LineName,默认人数 as PeopleNO,备注 as Remark,归属部门 as cDepCode
from [产线档案$]";

                DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dc.DefaultValue = true;
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "iID";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "GUID";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "CreateUid";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "CreateDate";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "UpdataUid";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "UpdataDate";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "AuditUid";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "AuditDate";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "CloseUid";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "CloseDate";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Remark2";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Remark3";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Remark4";
                dtExcel.Columns.Add(dc);

                dc = new DataColumn();
                dc.ColumnName = "Remark5";
                dtExcel.Columns.Add(dc);

                gridControl1.DataSource = dtExcel;


            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            long l = BaseFunction.BaseFunction.ReturnLong(txtWorkiID.Text.Trim());
            if (l > 0)
            {
                GetGrid(l);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {

        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {
            throw new NotImplementedException();
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
            //for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        gridView1.DeleteRow(i);
            //    }
            //}
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            throw new NotImplementedException();
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }


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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {

            }
            catch (Exception ee)
            {
                MsgBox("打开失败", ee.Message);
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {

            }
            catch (Exception ee)
            {
                MsgBox("关闭失败", ee.Message);
            }
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.DateTime = DateTime.Today;

                GetGrid(0);
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

        private void GetGrid(long lIDDetails)
        {
            sSQL = @"
select cast(0 as bit) as bChoose,a.cCode,a.dDate,b.cInvCode,i.cInvName,i.cInvStd
	,cast(b.fQuantity as decimal(16,2)) as fQuantity,b.dStartDate,b.dEndDate,cast(b.cDefine26 as int) as cDefine26
    ,a.ID,b.MainId,a.cDepCode,dep.cDepName,a.cPersonCode,per.cPersonName,a.iState
from @u8.PP_ProductPO a inner join @u8.PP_POMain b on a.ID = b.ID
	left join @u8.Inventory I on I.cInvCode = b.cInvCode
    left join @u8.Department dep on dep.cDepCode = a.cDepCode
    left join @u8.Person per on per.cPersonCode = a.cPersonCode
where 1=1 and a.iState = 2
order by b.ID
";
            sSQL = sSQL.Replace("1=1", "1=1 and b.MainId = " + lIDDetails.ToString());
            DataTable dt = DbHelperSQL.Query(sSQL);

            if (dt != null && dt.Rows.Count > 0)
            {
                buttonEdit生产订单号.Text = dt.Rows[0]["cCode"].ToString().Trim();
                txtWorkiID.Text = dt.Rows[0]["MainId"].ToString().Trim();
                txtcInvCode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                txtcInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                txtcInvStd.Text = dt.Rows[0]["cInvStd"].ToString().Trim();
                txtQty.Text = dt.Rows[0]["fQuantity"].ToString().Trim();
                txtQtyBox.Text = dt.Rows[0]["cDefine26"].ToString().Trim();

                AddCol();
            }
            else
            {
                buttonEdit生产订单号.Text = null;
                txtWorkiID.Text = null;
                txtcInvCode.Text = null;
                txtcInvName.Text = null;
                txtcInvStd.Text = null;
                txtQty.Text = null;
                txtQtyBox.Text = null;

                AddCol();
            }

            sSQL = @"
select * 
from @u8._车间看板
where 1=1 and dtm = '111111'
order by iID
";
            sSQL = sSQL.Replace("1=1", "1=1 and  MainID = " + BaseFunction.BaseFunction.ReturnLong(txtWorkiID.Text.Trim()));
            sSQL = sSQL.Replace("111111", dateEdit1.DateTime.ToString("yyyy-MM-dd"));
            DataTable dtGrid = DbHelperSQL.Query(sSQL);
            gridControl1.DataSource = dtGrid;
        }

        private void AddCol()
        {
            sSQL = @"
select b.cindex, c.opcode,c.opname
from @u8.pp_routmain a inner join @u8.pp_routdetail b on a.routid = b.routid 
	inner join @u8.pp_standop c on b.opid = c.opid
where a.cinvCode  = '111111'
order by b.autoid
";
            sSQL = sSQL.Replace("111111", txtcInvCode.Text.Trim());
            DataTable dtGridInfo = DbHelperSQL.Query(sSQL);

            for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
            { 
                string sColName = gridView1.Columns[i].Name.Trim();
                if (sColName.Length > 9 && sColName.Substring(9).ToLower() == "gridcolPP")
                {
                    gridView1.Columns.RemoveAt(i);
                }
            }

            for (int i = 0; i < dtGridInfo.Rows.Count; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();

                gridColumn1.Caption = dtGridInfo.Rows[i]["opname"].ToString().Trim();
                gridColumn1.Name = "gridColPP[" + dtGridInfo.Rows[i]["opcode"].ToString().Trim() + "]" + dtGridInfo.Rows[i]["opname"].ToString().Trim();
                gridColumn1.FieldName = "GX" + (i + 1).ToString();
                gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;


                gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1 });
            }
        }

        private void buttonEdit生产订单号_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                Frm生产订单列表 frm = new Frm生产订单列表();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    long lIDDetails = frm.lIDDetails;

                    GetGrid(lIDDetails);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
