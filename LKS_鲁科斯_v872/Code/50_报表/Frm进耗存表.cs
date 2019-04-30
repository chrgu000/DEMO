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
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.HPSF;
namespace 报表
{
    public partial class Frm进耗存表 : 系统服务.FrmBaseInfo
    {
        DataTable dtrd;
        public string Type = "";
        int col = 0;
        public Frm进耗存表()
        {
            InitializeComponent();

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                //gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
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

        private void Frm进耗存表_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                sSQL = "select * from @u8.Rd_Style where len(cRdCode)=4 order by cRdCode ";
                dtrd = clsSQLCommond.ExecQuery(sSQL);
                GetCol();

                sSQL = @"if exists(Select id from @u8.sysobjects where name= N'TEMPBom') Drop Table @u8.TEMPBom
                exec  @u8.Usp_BO_BO02007 1,'','','','', 0,99999999 ,'2000-01-01','2099-12-31','"+DateTime.Now.ToString("yyyy-MM-dd")+"',1.00, 0, '','','','','','','','','','','','','','','','','','','','', 0, 3, 0, 0, 1, ''   ,'TEMPBom'";
                sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");
                clsSQLCommond.ExecSql(sSQL);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }
        #region 表列
        private void GetCol()
        {
            #region 低值易耗品进耗存表
            if (this.Text == "低值易耗品进耗存表")
            {
                GetCol("期初数量", "期初数量");
                GetCol("期初单价", "期初单价");
                GetCol("期初金额", "期初金额");

                GetCol("收入数量", "收入数量");
                GetCol("收入单价", "收入单价");
                GetCol("收入金额", "收入金额");

                GetCol("发出数量", "发出数量");
                GetCol("发出单价", "发出单价");
                GetCol("发出金额", "发出金额");

                GetCol("结存数量", "结存数量");
                GetCol("结存单价", "结存单价");
                GetCol("结存金额", "结存金额");
                GetCol("入库总金额", "入库总金额", false);
                GetCol("出库总金额", "出库总金额", false);
                Type = "dbo.inventoryClass.cInvCCode like '4%'";
                col = 19;
            }
            #endregion

            #region 贸易成品进耗存表
            if (this.Text == "贸易品进耗存表")
            {
                GetCol("期初数量", "期初数量");
                GetCol("期初数量(贵)", "期初数量贵");
                GetCol("期初单价", "期初单价");
                GetCol("期初单价(贵)", "期初单价贵");
                GetCol("期初金额", "期初金额");
                GetCol("期初金额(贵)", "期初金额贵");

                GetCol("收入数量", "收入数量");
                GetCol("收入数量(贵)", "收入数量贵");
                GetCol("收入单价", "收入单价");
                GetCol("收入单价(贵)", "收入单价贵");
                GetCol("收入金额", "收入金额");
                GetCol("收入金额(贵)", "收入金额贵");

                GetCol("发出数量", "发出数量");
                GetCol("发出数量(贵)", "发出数量贵");
                GetCol("发出单价", "发出单价");
                GetCol("发出单价(贵)", "发出单价贵");
                GetCol("发出金额", "发出金额");
                GetCol("发出金额(贵)", "发出金额贵");

                GetCol("结存数量", "结存数量");
                GetCol("结存数量(贵)", "结存数量贵");
                GetCol("结存单价", "结存单价");
                GetCol("结存单价(贵)", "结存单价贵");
                GetCol("结存金额", "结存金额");
                GetCol("结存金额(贵)", "结存金额贵");
                GetCol("入库总金额", "入库总金额", false);
                GetCol("出库总金额", "出库总金额", false);
                Type = "dbo.inventoryClass.cInvCCode like '6%'";
                col = 31;

            }
            #endregion

            #region 原材料进耗存表
            if (this.Text == "原材料进耗存表")
            {
                GetCol("期初数量", "期初数量");
                GetCol("期初数量(贵)", "期初数量贵");
                GetCol("期初单价", "期初单价");
                GetCol("期初单价(贵)", "期初单价贵");
                GetCol("期初金额", "期初金额");
                GetCol("期初金额(贵)", "期初金额贵");

                GetCol("收入数量", "收入数量");
                GetCol("收入数量(贵)", "收入数量贵");
                GetCol("收入单价", "收入单价");
                GetCol("收入单价(贵)", "收入单价贵");
                GetCol("收入金额", "收入金额");
                GetCol("收入金额(贵)", "收入金额贵");

                GetCol("发出数量", "发出数量");
                GetCol("发出数量(贵)", "发出数量贵");
                GetCol("发出单价", "发出单价");
                GetCol("发出单价(贵)", "发出单价贵");
                GetCol("发出金额", "发出金额");
                GetCol("发出金额(贵)", "发出金额贵");

                GetCol("结存数量", "结存数量");
                GetCol("结存数量(贵)", "结存数量贵");
                GetCol("结存单价", "结存单价");
                GetCol("结存单价(贵)", "结存单价贵");
                GetCol("结存金额", "结存金额");
                GetCol("结存金额(贵)", "结存金额贵");
                GetCol("入库总金额", "入库总金额", false);
                GetCol("出库总金额", "出库总金额", false);
                Type = "dbo.inventoryClass.cInvCCode like '3%'";
                col = 31;
            }
            #endregion

            #region 自制成品进耗存表
            if (this.Text == "自制成半成品进耗存表")
            {
                GetCol("期初数量", "期初数量");
                GetCol("期初数量(贵)", "期初数量贵");
                GetCol("期初金额", "期初金额");
                GetCol("期初单价", "期初单价");
                GetCol("期初单价(贵)", "期初单价贵");
                GetCol("期初料金额", "期初料金额");
                GetCol("期初料还原", "期初料还原");
                GetCol("期初料金额(贵)", "期初金额贵");
                GetCol("期初工金额", "期初工金额");
                GetCol("期初工还原", "期初工还原");
                GetCol("期初费金额", "期初费金额");
                GetCol("期初费还原", "期初费还原");

                GetCol("收入数量", "收入数量");
                GetCol("收入数量(贵)", "收入数量贵");
                GetCol("收入金额", "收入金额");
                GetCol("收入单价", "收入单价");
                GetCol("收入单价(贵)", "收入单价贵");
                GetCol("收入料金额", "收入料金额");
                GetCol("收入料还原", "收入料还原");
                GetCol("收入料金额(贵)", "收入金额贵");
                GetCol("收入工金额", "收入工金额");
                GetCol("收入工还原", "收入工还原");
                GetCol("收入费金额", "收入费金额");
                GetCol("收入费还原", "收入费还原");

                GetCol("发出数量", "发出数量");
                GetCol("发出数量(贵)", "发出数量贵");
                GetCol("发出金额", "发出金额");
                GetCol("发出单价", "发出单价");
                GetCol("发出单价(贵)", "发出单价贵");
                GetCol("发出料金额", "发出料金额");
                GetCol("发出料还原", "发出料还原");
                GetCol("发出料金额(贵)", "发出金额贵");
                GetCol("发出工金额", "发出工金额");
                GetCol("发出工还原", "发出工还原");
                GetCol("发出费金额", "发出费金额");
                GetCol("发出费还原", "发出费还原");

                GetCol("结存数量", "结存数量");
                GetCol("结存数量(贵)", "结存数量贵");
                GetCol("结存金额", "结存金额");
                GetCol("结存单价", "结存单价");
                GetCol("结存单价(贵)", "结存单价贵");
                GetCol("结存料金额", "结存料金额");
                GetCol("结存料还原", "结存料还原");
                GetCol("结存料金额(贵)", "结存金额贵");
                GetCol("结存工金额", "结存工金额");
                GetCol("结存工还原", "结存工还原");
                GetCol("结存费金额", "结存费金额");
                GetCol("结存费还原", "结存费还原");
                GetCol("入库总金额", "入库总金额", false);
                GetCol("出库总金额", "出库总金额", false);
                GetCol("工汇总", "工汇总", false);
                GetCol("费汇总", "费汇总", false);
                col = 57;
                Type = "(dbo.inventoryClass.cInvCCode like '1%' or dbo.inventoryClass.cInvCCode like '2%')";
            }
            #endregion
        }
        private void GetColC(string Name, string id)
        {
            GetCol(Name + "数量", "iquantity" + id);
            GetCol(Name + "单价", "iunit" + id);
            GetCol(Name + "金额", "imoney" + id);
        }
        private void GetColB(string Name, string id)
        {
            GetCol(Name + "数量", "iquantity" + id);
            GetCol(Name + "数量(贵)", "iquantityM" + id);
            GetCol(Name + "单价", "iunit" + id);
            GetCol(Name + "单价(贵)", "iunitM" + id);
            GetCol(Name + "金额", "imoney" + id);
            GetCol(Name + "金额(贵)", "imoneyM" + id);
        }
        private void GetColA(string Name, string id)
        {
            GetCol(Name + "数量", "iquantity" + id);
            GetCol(Name + "数量(贵)", "iquantityM" + id);
            GetCol(Name + "单价", "iunit" + id);
            GetCol(Name + "单价(贵)", "iunitM" + id);
            GetCol(Name + "金额", "imoney" + id);
            GetCol(Name + "料金额", "iPriceA" + id);
            GetCol(Name + "料还原", "iPrice" + id);
            GetCol(Name + "金额(贵)", "imoneyM" + id);
            GetCol(Name + "工金额", "iWork" + id);
            GetCol(Name + "工还原", "sWork" + id);
            GetCol(Name + "费金额", "iCost" + id);
            GetCol(Name + "费还原", "sCost" + id);
        }

        private void GetCol(string ColText, string FieldName)
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = FieldName;
            Col.Name = "gridCol" + FieldName;
            Col.Caption = ColText;
            Col.OptionsColumn.AllowEdit = false;
            Col.Width = 70;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count - 1;
            Col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Col.SummaryItem.FieldName = FieldName;
            gridView1.Columns.Add(Col);

            gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, FieldName,Col);
        }

        private void GetCol(string ColText, string FieldName,bool Visable)
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = FieldName;
            Col.Name = "gridCol" + FieldName;
            Col.Caption = ColText;
            Col.OptionsColumn.AllowEdit = false;
            Col.Width = 70;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count - 1;
            Col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Col.SummaryItem.FieldName = FieldName;
            gridView1.Columns.Add(Col);
            Col.Visible = Visable;
            gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, FieldName, Col);
        }
        #endregion
        private void GetGrid()
        {
            成本计算 cb = new 成本计算();
            cb.type = Type;
            if (lookUpEdit月份.Text == "")
            {
                throw new Exception("月份不可为空");
            }
            
            
            if (this.Text == "自制成半成品进耗存表")
            {
                string now = 系统服务.ClsBaseDataInfo.sUFDataBaseYear + "-" + lookUpEdit月份.EditValue.ToString() + "-1";
                if (DateTime.Parse(now) < DateTime.Parse("2014-01-01"))
                {
                    throw new Exception("不可查询本月数据，只能查询2014年1月之后的数据");
                }
            }

            string sd = "";
            string ed = "";
            int month = int.Parse(lookUpEdit月份.EditValue.ToString());
            系统服务.GetUAPeriod p = new 系统服务.GetUAPeriod();
            p.GetPeriod(lookUpEdit月份.EditValue.ToString(), out sd, out ed);
            string sysdate = 系统服务.ClsBaseDataInfo.sUFDataBaseYear + "-01-01";
            cb.GetQC(month);

            sSQL = cb.GetList(sd, ed, month);
            
            sSQL = sSQL + @"
select * from #k where 5=5 and 6=6 ";
            if (lookUpEdit存货分类.Text.Trim() != "")
            {
                sSQL = sSQL.Replace(" 5=5 ", " 存货分类代码='" + lookUpEdit存货分类.EditValue.ToString().Trim() + "' ");
            }
            if (lookUpEdit存货编码.Text.Trim() != "")
            {
                sSQL = sSQL.Replace(" 6=6 ", " 存货编码='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "' ");
            }
            try
            {
                dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            }
            catch (Exception ee)
            {
                throw new Exception("取值有误" + ee.Message+sSQL);
            }
            for (int i = gridView1.Columns.Count - 1; i >= col+2; i--)
            {
                gridView1.Columns.Remove(gridView1.Columns[i]);
            }
            for (int i = 0; i < dtrd.Rows.Count; i++)
            {
                string id = dtrd.Rows[i]["cRdCode"].ToString();
                if (ReturnDecimal(dtBingGrid.Compute("max(iquantity" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(iquantity" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(iquantityM" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(iquantityM" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(iunit" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(iunit" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(iunitM" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(iunitM" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(imoney" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(imoney" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(imoneyM" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(imoneyM" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(iPrice" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(iPrice" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(iWork" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(iWork" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(sWork" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(sWork" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(iCost" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(iCost" + id + ")", "")) != 0
                    || ReturnDecimal(dtBingGrid.Compute("max(sCost" + id + ")", "")) != 0 || ReturnDecimal(dtBingGrid.Compute("min(sCost" + id + ")", "")) != 0
                    )
                {
                    if (this.Text == "低值易耗品进耗存表")
                    {
                        GetColC(dtrd.Rows[i]["cRdName"].ToString(), id);
                    }
                    else if (this.Text == "贸易品进耗存表")
                    {
                        GetColB(dtrd.Rows[i]["cRdName"].ToString(), id);
                    }
                    else if (this.Text == "原材料进耗存表")
                    {
                        GetColB(dtrd.Rows[i]["cRdName"].ToString(), id);
                    }
                    else if (this.Text == "自制成半成品进耗存表")
                    {
                        GetColA(dtrd.Rows[i]["cRdName"].ToString(), id);
                    }
                }
            }

            gridControl1.DataSource = dtBingGrid;

            gridView1.ExpandAllGroups();

        }


        

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.InventoryClass(lookUpEdit存货分类);
            系统服务.LookUp.Inventory(lookUpEdit存货编码);
            系统服务.LookUp._LoopUpData(lookUpEdit月份, "19");
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
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

        private void buttonEdit存货分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.FrmInvClassInfo frm = new 系统服务.FrmInvClassInfo("");
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货分类.EditValue = frm.id;

                frm.Enabled = true;
            }
        }

        private void buttonEdit存货分类_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货分类.Text.Trim() != "")
            {
                lookUpEdit存货分类.EditValue = buttonEdit存货分类.Text.Trim();
            }
        }

        private void buttonEdit存货分类_Leave(object sender, EventArgs e)
        {
            if (buttonEdit存货分类.Text.Trim() == "")
                return;
            if (lookUpEdit存货分类.Text.Trim() == "")
            {
                buttonEdit存货分类.Text = "";
                buttonEdit存货分类.Focus();
            }
        }

        private void buttonEdit存货编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.FrmInvInfo frm = new 系统服务.FrmInvInfo("",false);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货编码.EditValue = frm.sInvCode;

                frm.Enabled = true;
            }
        }

        private void buttonEdit存货编码_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货编码.Text.Trim() != "")
            {
                lookUpEdit存货编码.EditValue = buttonEdit存货编码.Text.Trim();
            }
            else
            {
                lookUpEdit存货编码.EditValue = "";
            }
        }

        private void buttonEdit存货编码_Leave(object sender, EventArgs e)
        {
            if (buttonEdit存货编码.Text.Trim() == "")
                return;
            if (lookUpEdit存货编码.Text.Trim() == "")
            {
                buttonEdit存货编码.Text = "";
                buttonEdit存货编码.Focus();
            }
        }

    }
}
