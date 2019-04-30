using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace WorkInformation
{
    public partial class Frm生产缺料过滤 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm生产缺料过滤()
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

        private void btnSave()
        {
           
        }


        #region 按钮模板

        /// <summary>
        /// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
            DataTable dtState = (DataTable)ItemLookUpEdit设备.DataSource;
            DataColumn dc = new DataColumn();
            dc.ColumnName = "StateText";
            dt.Columns.Add(dc);
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
                if (drState.Length > 0)
                {
                    dt.Rows[i]["StateText"] = drState[0]["State"];
                }

            }

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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            string sSQL = @"

select distinct a.产品编码,a.出货周,a.销售订单号,a.销售订单行号,b.制造令号码,b.物料编码,h.cInvName as 物料名称, b.数量,b.制造令数量
	,d.累计入库,d.子件编码,f.cInvName as 子件名称,f.bPurchase as 采购,f.bProxyForeign as 委外,f.bSelf as 生产, d.子件数量,d.已领数量,d.子件数量-isnull(d.已领数量,0) as 待领数量
	,e.iQuantity as 原料库现存量,g.iQuantity as 现场库现存量,isnull(e.iQuantity,0)  + isnull(g.iQuantity,0) as 现存量, cast (null as decimal(18,6)) as 缺料数量
from dbo.生产计划 a inner join dbo.生产计划明细 b on a.单据号 = b.表头单据号 and a.帐套号 = b.帐套号 and a.帐套号 ='444444' 
	inner join 
	(
		select 生产计划明细iID,MAX(数量) as 数量
		from 生产日计划 
		where 排产日期 = '111111' and 计划生产日期 >= '222222' and 计划生产日期 <= '333333'
		group by 生产计划明细iID
	)c on b.iID = c.生产计划明细iID
	left join 
	(
		select a.MoId, a.MoCode as 生产订单号, b.InvCode as 母件编码,sum(b.Qty) as 订单数量,sum(b.QualifiedInQty) as 累计入库
			,c.InvCode as 子件编码, sum(c.Qty) as 子件数量,sum(c.IssQty) as 已领数量
		from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid 
			inner join @u8.mom_moallocate c on b.modid = c.modid
		where isnull(b.Status,0) = 3 
		group by a.MoId, a.MoCode ,b.InvCode,c.InvCode
	)d on d.母件编码 = b.物料编码 and d.生产订单号 = b.制造令号码
	left join @u8.CurrentStock e on e.cInvCode = d.子件编码 and e.cWhCode = '01'
	left join @u8.CurrentStock g on g.cInvCode = d.子件编码 and g.cWhCode = '0F'
    inner join @u8.Inventory f on f.cInvCode = d.子件编码 
    inner join  @u8.Inventory h on h.cInvCode = b.物料编码 
order by a.出货周,d.子件编码,b.制造令号码,b.物料编码,a.销售订单号,a.销售订单行号

";
            sSQL = sSQL.Replace("111111", dtm最新排产日期.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("222222", dtm生产日期1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("333333", dtm生产日期2.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("444444", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);


            sSQL = @"
select 子件编码,sum(待领数量) as 待领数量 ,sum(现存量) as 现存量,sum(待领数量) - isnull(现存量,0) as 缺料数量
from
(
select distinct a.产品编码,a.出货周,a.销售订单号,a.销售订单行号,b.物料编码,b.数量,b.制造令数量,b.制造令号码
	,d.累计入库,d.子件编码, d.子件数量,d.已领数量,d.子件数量-isnull(d.已领数量,0) as 待领数量
	,isnull(e.iQuantity,0) + isnull(g.iQuantity,0) as 现存量,cast (null as decimal(18,6)) as 缺料数量
from dbo.生产计划 a inner join dbo.生产计划明细 b on a.单据号 = b.表头单据号 and a.帐套号 = b.帐套号 and a.帐套号 ='444444' 
	inner join 
	(
		select 生产计划明细iID,MAX(数量) as 数量
		from 生产日计划 
		where 排产日期 = '111111' and 计划生产日期 >= '222222' and 计划生产日期 <= '333333'
		group by 生产计划明细iID
	)c on b.iID = c.生产计划明细iID
	left join 
	(
		select a.MoId, a.MoCode as 生产订单号, b.InvCode as 母件编码,sum(b.Qty) as 订单数量,sum(b.QualifiedInQty) as 累计入库
			,c.InvCode as 子件编码, sum(c.Qty) as 子件数量,sum(c.IssQty) as 已领数量
		from @u8.mom_order a inner join @u8.mom_orderdetail b on a.moid = b.moid 
			inner join @u8.mom_moallocate c on b.modid = c.modid
		where isnull(b.Status,0) = 3
		group by a.MoId, a.MoCode ,b.InvCode,c.InvCode
	)d on d.母件编码 = b.物料编码 and d.生产订单号 = b.制造令号码
	left join @u8.CurrentStock e on e.cInvCode = d.子件编码 and e.cWhCode = '01'
	left join @u8.CurrentStock g on g.cInvCode = d.子件编码 and g.cWhCode = '0F'
    inner join @u8.Inventory f on f.cInvCode = d.子件编码
) a
group by 子件编码,现存量
";
            sSQL = sSQL.Replace("111111", dtm最新排产日期.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("222222", dtm生产日期1.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("333333", dtm生产日期2.DateTime.ToString("yyyy-MM-dd"));
            sSQL = sSQL.Replace("444444", FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));

            DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s子件编码 = dt.Rows[i]["子件编码"].ToString().Trim();

                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    string s子件编码2 = dtTemp.Rows[j]["子件编码"].ToString().Trim();
                    if (s子件编码 == s子件编码2)
                    {
                        decimal d = ReturnObjectToDecimal(dtTemp.Rows[j]["缺料数量"], 6);
                        if (d > 0)
                            dt.Rows[i]["缺料数量"] = d;
                    }
                }

            }

            gridControl1.DataSource = dt;
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
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

        private void Frm生产缺料过滤_Load(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select max(排产日期) from dbo.生产日计划";
                DateTime d = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));
                dtm最新排产日期.DateTime = d;
                dtm最新排产日期.Enabled = true;
                dtm生产日期1.DateTime = d.AddDays(1);
                dtm生产日期2.DateTime = d.AddDays(3);

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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    decimal d = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns["缺料数量"]), 6);
                    if (d > 0)
                    {
                        e.Appearance.BackColor = Color.Tomato;
                    }
                }
            }
            catch
            { }
        }
    }
}
