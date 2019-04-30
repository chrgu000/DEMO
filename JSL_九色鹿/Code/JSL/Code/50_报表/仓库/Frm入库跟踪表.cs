using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using DevExpress.XtraEditors;
using 采购;
namespace 报表
{
    public partial class Frm入库跟踪表 : 系统服务.FrmBaseInfo
    {

        public Frm入库跟踪表()
        {
            InitializeComponent();


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
                    case "add":
                        btnAdd();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            SetLookUpEdit();
            GetGrid();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
        }

        private void GetSel()
        {
            throw new NotImplementedException();

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
        /// 解锁  生成出库
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            int iFocRow = gridView1.FocusedRowHandle;
            GetGrid();
            gridView1.FocusedRowHandle = iFocRow;
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm入库跟踪表_Load(object sender, EventArgs e)
        {
            try
            {
                GetLayOut(layoutControl1, gridControl1);

                SetLookUpEdit();
                dateEdit1.EditValue = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                dateEdit2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                GetGrid();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {

            sSQL = @"
if exists (select 1 from  sysobjects where  id = object_id('temp入库跟踪表_0')   and   type = 'U')   drop table temp入库跟踪表_0  
select AutoID as AutoID_0 ,a.cRSCode as cRSCode_0,a.cRdCode as cRdCode_0,cInvCode as cInvCode_0,b.M1 as M1_0,b.iQuantity as iQuantity_0,b.iMoney as iMoney_0  into #a
from RdRecord a left join RdRecords b on a.ID=b.ID 
                     where 1=1  and dVerifysysPerson is not null and cRSCode='01' 
                     
select * into temp入库跟踪表_0 from #a left join 
(
select AutoID as AutoID出库_1,a.cRSCode as cRSCode出库_1,a.cRdCode as cRdCode出库_1,b.RdAutoID as RdAutoID出库_1,b.MOsID as MOsID出库_1,cInvCode as cInvCode出库_1,b.M1 as M1出库_1,b.iQuantity as iQuantity出库_1,b.iMoney as iMoney出库_1  
from RdRecord a left join RdRecords b on a.ID=b.ID 
                     where  dVerifysysPerson is not null 
) b on #a.AutoID_0=b.RdAutoID出库_1 left join
(
select b.AutoID as MoAutoID委外_1,c.sID as sID委外_1,a.cMOCode as cMOCode委外_1,a.cMSCode as cMSCode委外_1,c.RdAutoID as RdAutoID委外_1,b.iQuantity as iQuantity委外_1,b.iMoney as iMoney委外_1  
from MO_MOMain a left join MO_MODetails b on a.ID=b.ID left join MO_MOSublist c on b.AutoID=c.AutoID
                     where dVerifysysPerson is not null 
) c on b.MOsID出库_1=c.sID委外_1 left join
(
select AutoID as AutoID入库_2,a.cRSCode as cRSCode入库_2,a.cRdCode as cRdCode入库_2,b.MOAutoID as MOAutoID入库_2,cInvCode as cInvCode入库_2,b.M1 as M1入库_2,b.iQuantity as iQuantity入库_2,b.iMoney as iMoney入库_2  
from RdRecord a left join RdRecords b on a.ID=b.ID 
                     where dVerifysysPerson is not null 
) d on c.MoAutoID委外_1=d.MOAutoID入库_2 

select * from temp入库跟踪表_0 ";

            if (dateEdit1.EditValue != null && dateEdit1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and convert(varchar(10),a.dDate,120)>='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'";
            }
            if (dateEdit2.EditValue != null && dateEdit2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and convert(varchar(10),a.dDate,120)<='" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'";
            }

            if (lookUpEdit供应商.EditValue != null && lookUpEdit供应商.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cVenCode='" + lookUpEdit供应商.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit业务员.EditValue != null && lookUpEdit业务员.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cPersonCode='" + lookUpEdit业务员.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit部门.EditValue != null && lookUpEdit部门.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cDepCode='" + lookUpEdit部门.EditValue.ToString().Trim() + "'");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            int icount=2;
            dt = GetList(dt, icount);
            AddCol("0");
            for (int i = 1; i < icount; i = i + 2)
            {
                AddCol1(i.ToString());
                AddCol2(i.ToString());
                AddCol3((i + 1).ToString());
            }
            gridControl1.DataSource = dt;
            GetShow(false);
        }

        private void GetShow(bool b)
        {
            gridView1.OptionsBehavior.Editable = false;
        }

        public DataTable GetList(DataTable dt, int icount)
        {
            DataRow[] dw = dt.Select("AutoID入库_" + icount + " is not null");
            if (dw.Length == 0)
            {
                return dt;
            }
            else
            {
                sSQL = @"
select * into #a from temp入库跟踪表_a a left join 
(
select AutoID as AutoID出库_c,a.cRSCode as cRSCode出库_c,a.cRdCode as cRdCode出库_c,b.RdAutoID as RdAutoID出库_c,b.MOsID as MOsID出库_c,cInvCode as cInvCode出库_c,b.M1 as M1出库_c,b.iQuantity as iQuantity出库_c,b.iMoney as iMoney出库_c  
from RdRecord a left join RdRecords b on a.ID=b.ID 
                     where 1=1 and dVerifysysPerson is not null 
) b on a.AutoID入库_e=b.RdAutoID出库_c left join
(
select b.AutoID as MoAutoID委外_c,c.sID as sID委外_c,a.cMOCode as cMOCode委外_c,a.cMSCode as cMSCode委外_c,c.RdAutoID as RdAutoID委外_c,b.iQuantity as iQuantity委外_c,b.iMoney as iMoney委外_c 
from MO_MOMain a left join MO_MODetails b on a.ID=b.ID left join MO_MOSublist c on b.AutoID=c.AutoID
                     where 1=1 and dVerifysysPerson is not null 
) c on b.MOsID出库_c=c.sID委外_c left join
(
select AutoID as AutoID入库_d,a.cRSCode as cRSCode入库_d,a.cRdCode as cRdCode入库_d,b.MOAutoID as MOAutoID入库_d,cInvCode as cInvCode入库_d,b.M1 as M1入库_d,b.iQuantity as iQuantity入库_d,b.iMoney as iMoney入库_d  
from RdRecord a left join RdRecords b on a.ID=b.ID 
                     where 1=1 and dVerifysysPerson is not null 
) d on c.MoAutoID委外_c=d.MOAutoID入库_d
if exists (select 1 from  sysobjects where  id = object_id('temp入库跟踪表_b')   and   type = 'U')   drop table temp入库跟踪表_b 
select * into temp入库跟踪表_b from #a 
select * from temp入库跟踪表_b 
";
                sSQL = sSQL.Replace("_a", "_" + (icount / 2 - 1));
                sSQL = sSQL.Replace("_b", "_" + (icount / 2));
                sSQL = sSQL.Replace("_c", "_" + (icount + 1));
                sSQL = sSQL.Replace("_d", "_" + (icount + 2));
                sSQL = sSQL.Replace("_e", "_" + (icount));
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                return GetList(dts, icount + 2);
            }
        }

        private void AddCol(string i)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.Caption = "采购入库";
            gridBand.MinWidth = 20;
            gridBand.Name = "gridBandtemp采购入库单" + i;
            gridBand.Width = 50;

            gridView1.Bands.Add(gridBand);
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "采购入库单号";
            gridColumn1.Name = "cRdCode_" + i;
            gridColumn1.FieldName = "cRdCode_" + i;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn1);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn2.Caption = "入库数量";
            gridColumn2.Name = "iQuantity_" + i;
            gridColumn2.FieldName = "iQuantity_" + i;
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = gridView1.Columns.Count;
            gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn2);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn3.Caption = "金额";
            gridColumn3.Name = "iMoney_" + i;
            gridColumn3.FieldName = "iMoney_" + i;
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = gridView1.Columns.Count;
            gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridBand.Columns.Add(gridColumn3);
        }

        private void AddCol1(string i)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.Caption = "出库";
            gridBand.MinWidth = 20;
            gridBand.Name = "gridBandtemp出库" + i;
            gridBand.Width = 50;

            gridView1.Bands.Add(gridBand);
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "出库单号";
            gridColumn1.Name = "cRdCode出库_" + i;
            gridColumn1.FieldName = "cRdCode出库_" + i;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn1);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn2.Caption = "出库数量";
            gridColumn2.Name = "iQuantity出库_" + i;
            gridColumn2.FieldName = "iQuantity出库_" + i;
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = gridView1.Columns.Count;
            gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn2);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn3.Caption = "出库金额";
            gridColumn3.Name = "iMoney出库_" + i;
            gridColumn3.FieldName = "iMoney出库_" + i;
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = gridView1.Columns.Count;
            gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridBand.Columns.Add(gridColumn3);
        }

        private void AddCol2(string i)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.Caption = "委外订单";
            gridBand.MinWidth = 20;
            gridBand.Name = "gridBandtemp委外订单" + i;
            gridBand.Width = 50;

            gridView1.Bands.Add(gridBand);
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "委外订单号";
            gridColumn1.Name = "cMOCode委外_" + i;
            gridColumn1.FieldName = "cMOCode委外_" + i;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn1);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn2.Caption = "委外数量";
            gridColumn2.Name = "iQuantity委外_" + i;
            gridColumn2.FieldName = "iQuantity委外_" + i;
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = gridView1.Columns.Count;
            gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn2);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn3.Caption = "委外金额";
            gridColumn3.Name = "iMoney委外_" + i;
            gridColumn3.FieldName = "iMoney委外_" + i;
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = gridView1.Columns.Count;
            gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridBand.Columns.Add(gridColumn3);
        }

        private void AddCol3(string i)
        {
            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand.Caption = "入库";
            gridBand.MinWidth = 20;
            gridBand.Name = "gridBandtemp入库" + i;
            gridBand.Width = 50;

            gridView1.Bands.Add(gridBand);
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = "入库单号";
            gridColumn1.Name = "cRdCode入库_" + i;
            gridColumn1.FieldName = "cRdCode入库_" + i;
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn1);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn2.Caption = "入库数量";
            gridColumn2.Name = "iQuantity入库_" + i;
            gridColumn2.FieldName = "iQuantity入库_" + i;
            gridColumn2.Visible = true;
            gridColumn2.VisibleIndex = gridView1.Columns.Count;
            gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.Columns.Add(gridColumn2);

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn3.Caption = "入库金额";
            gridColumn3.Name = "iMoney入库_" + i;
            gridColumn3.FieldName = "iMoney入库_" + i;
            gridColumn3.Visible = true;
            gridColumn3.VisibleIndex = gridView1.Columns.Count;
            gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });

            gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridBand.Columns.Add(gridColumn3);
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            //系统服务.LookUp.PurchaseType(ItemLookUpEdit采购类型);
            ////系统服务.LookUp.Inventory(ItemLookUpEdit产品);
            ////系统服务.LookUp.ShippingChoice(ItemLookUpEdit送货方式);

            //系统服务.LookUp.Person(ItemLookUpEdit业务员);
            //系统服务.LookUp.Vendor(ItemLookUpEdit供应商);
            //系统服务.LookUp.Department(ItemLookUpEdit部门);

            //系统服务.LookUp.Person(lookUpEdit业务员);
            //系统服务.LookUp.Vendor(lookUpEdit供应商);
            //系统服务.LookUp.Department(lookUpEdit部门);
            //系统服务.LookUp.Inventory(ItemLookUpEdit物料编码);
            
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
        }



        private void buttonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit业务员.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEdit供应商_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(10);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit供应商.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() != "")
            {
                lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
            }
            else
            {
                lookUpEdit业务员.EditValue = null;
            }
        }

        private void buttonEdit供应商_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() != "")
            {
                lookUpEdit供应商.EditValue = buttonEdit供应商.Text.Trim();
                
            }
            else
            {
                buttonEdit供应商.EditValue = null;
                lookUpEdit供应商.EditValue = null;
            }
        }

        private void buttonEdit供应商_Leave(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() == "")
                return;
            if (lookUpEdit供应商.Text.Trim() == "")
            {
                buttonEdit供应商.Text = "";
                buttonEdit供应商.Focus();
            }
        }

        private void buttonEdit业务员_Leave(object sender, EventArgs e)
        {
            if (buttonEdit业务员.Text.Trim() == "")
                return;
            if (lookUpEdit业务员.Text.Trim() == "")
            {
                buttonEdit业务员.Text = "";
                buttonEdit业务员.Focus();
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

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit部门.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() != "")
                lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
            else
                lookUpEdit部门.EditValue = null;
        }

        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            if (buttonEdit部门.Text.Trim() == "")
                return;
            if (lookUpEdit部门.Text.Trim() == "")
            {
                buttonEdit部门.Text = "";
                buttonEdit部门.Focus();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ee)
            { }
        }

    }
}
