using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;

namespace 生产
{
    public partial class Frm生产流程卡 : 系统服务.FrmBaseInfo
    {
        public Frm生产流程卡()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            //gridView1.OptionsMenu.EnableColumnMenu = false;
            //gridView1.OptionsMenu.EnableFooterMenu = false;
            //gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //gridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            //gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

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

            GetLookUp();

            btnLast();
        }

        public Frm生产流程卡(string sCode)
        {
            InitializeComponent();

            #region 禁止用户调整表格
            //gridView1.OptionsMenu.EnableColumnMenu = false;
            //gridView1.OptionsMenu.EnableFooterMenu = false;
            //gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //gridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            //gridView1.OptionsBehavior.FocusLeaveOnTab = true;
            //gridView1.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

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


            GetLookUp();

            SetTxtValue(sCode);
        }

        string s表名称 = "生产流程卡";
        DataTable dt = new DataTable();

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
                    case "add":
                        btnAdd();
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

                if (sBtnName.ToLower() != "add")
                {
                    //gridView1.OptionsBehavior.Editable = false;
                }
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnAdd()
        {
            SetTxtNull();
            SetEnable(true);

            dtm单据日期.Text = DateTime.Now.ToString("yyyy-MM-dd");
            sState = "add";
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
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }

            //base.dsPrint.Tables.Clear();
            //DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
            //dtGrid.TableName = "dtGrid";

            //base.dsPrint.Tables.Add(dtGrid);
            //DataTable dtHead = dtBingHead.Copy();
            //dtHead.TableName = "dtHead";
            //base.dsPrint.Tables.Add(dtHead);
        }
        /// <summary>
        /// 输出
        /// </summary>
        private void btnExport()
        {
            //try
            //{
            //    SaveFileDialog sF = new SaveFileDialog();
            //    sF.DefaultExt = "xls";
            //    sF.FileName = this.Text;
            //    sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
            //    DialogResult dRes = sF.ShowDialog();
            //    if (DialogResult.OK == dRes)
            //    {
            //        gridView1.ExportToXls(sF.FileName);
            //        MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.Message);
            //}
        }

        private void btnLayout(string sText)
        {
            //if (layoutControl1 == null) return;
            //if (sText == "布局")
            //{
            //    //layoutControl1.ShowCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = true;
            //    base.toolStripMenuBtn.Items["Layout"].Text = "保存布局";

            //    gridView1.OptionsMenu.EnableColumnMenu = true;
            //    gridView1.OptionsMenu.EnableFooterMenu = true;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = true;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = true;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            //    gridView1.OptionsCustomization.AllowColumnMoving = true;
            //}
            //else
            //{
            //    //layoutControl1.HideCustomizationForm();
            //    layoutControl1.AllowCustomizationMenu = false;
            //    gridView1.OptionsMenu.EnableColumnMenu = false;
            //    gridView1.OptionsMenu.EnableFooterMenu = false;
            //    gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //    //gridView1.OptionsMenu.ShowAddNewSummaryItem = false;
            //    gridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //    gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //    gridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //    gridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //    gridView1.OptionsCustomization.AllowColumnMoving = false;


            //    if (!Directory.Exists(base.sProPath + "\\layout"))
            //        Directory.CreateDirectory(base.sProPath + "\\layout");

            //    base.toolStripMenuBtn.Items["Layout"].Text = "布局";

            //    DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            //    if (d == DialogResult.Yes)
            //    {
            //        layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
            //        gridControl1.MainView.SaveLayoutToXml(sLayoutGridPath);
            //    }
            //    else if (d == DialogResult.No)
            //    {
            //        if (File.Exists(sLayoutHeadPath))
            //            File.Delete(sLayoutHeadPath);

            //        if (File.Exists(sLayoutGridPath))
            //            File.Delete(sLayoutGridPath);
            //    }
            //}
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
            try
            {
                Frm生产流程卡列表 frm = new Frm生产流程卡列表();
                frm.Tag = frm.Name;
                //frm.MdiParent = this.MdiParent;

                frm.ShowDialog();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            { }
        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            sSQL = "select 单据号 from dbo.生产流程卡 order by 单据号 ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                SetTxtValue(dt.Rows[0][0].ToString().Trim());
            }
            else
            {
                SetTxtNull();
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            if (txt单据号.Text.Trim() == "")
            {
                btnFirst();
            }
            else
            {
                sSQL = "select 单据号 from dbo.生产流程卡 where 单据号 < '" + txt单据号.Text.Trim() + "' order by 单据号 ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    SetTxtValue(dt.Rows[dt.Rows.Count - 1][0].ToString().Trim());
                }
                else
                {
                    btnFirst();
                }
            }
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            if (txt单据号.Text.Trim() == "")
            {
                btnLast();
            }
            else
            {
                sSQL = "select 单据号 from dbo.生产流程卡 where 单据号 > '" + txt单据号.Text.Trim() + "' order by 单据号 ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    SetTxtValue(dt.Rows[0][0].ToString().Trim());
                }
                else
                {
                    btnLast();
                }
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            sSQL = "select 单据号 from dbo.生产流程卡 order by 单据号 ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                SetTxtValue(dt.Rows[dt.Rows.Count -1][0].ToString().Trim());
            }
            else
            {
                SetTxtNull();
            }
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

        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {

        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            sState = "edit";
            SetEnable(true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (txt单据号.Text.Trim() != "")
            {
                DialogResult d = MessageBox.Show("是否删除单据：" + txt单据号.Text.Trim() + "\n删除 Y\n取消 N", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    sSQL = "delete 生产流程卡 where 单据号 = '" + txt单据号.Text.Trim() + "'";
                    clsSQLCommond.ExecSql(sSQL);
                    btnNext();
                }
            }
        }

        /// <summary>
        /// 判断是否已经使用
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private bool CheckCanDel(string p,out string sErr)
        {
            bool b = true;
            sErr = "";

            return b;
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                if (lookUpEdit客户.EditValue == null || lookUpEdit客户.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("客户不能为空");
                }
                if (lookUpEdit物料名称.EditValue == null || lookUpEdit物料名称.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("品名不能为空");
                }
                if (lookUpEdit色号.EditValue == null || lookUpEdit色号.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("色号不能为空");
                }


                aList = new System.Collections.ArrayList();

                sSQL = "select * from 生产流程卡 where 1=-1";
                DataTable dt生产流程卡 = clsSQLCommond.ExecQuery(sSQL);
                DataRow dr生产流程卡 = dt生产流程卡.NewRow();
                if (sState == "add")
                    txt单据号.Text = GetCode();

                dr生产流程卡["单据号"] = txt单据号.Text.Trim();
                dr生产流程卡["单据日期"] = dtm单据日期.DateTime.ToString("yyyy-MM-dd");
                dr生产流程卡["客户"] = lookUpEdit客户.EditValue.ToString().Trim();
                dr生产流程卡["品名"] = lookUpEdit物料名称.EditValue.ToString().Trim();
                dr生产流程卡["色号"] = lookUpEdit色号.EditValue.ToString().Trim();
                dr生产流程卡["缸号"] = lookUpEdit缸号.EditValue.ToString().Trim();
                if (txt染厂称重.Text.Trim() != "")
                    dr生产流程卡["染厂称重"] = ReturnDecimal(txt染厂称重.Text);
                if (txt染厂绞数.Text.Trim() != "")
                    dr生产流程卡["染厂绞数"] = ReturnDecimal(txt染厂绞数.Text);
                if (txt染厂绞重.Text.Trim() != "")
                    dr生产流程卡["染厂绞重"] = ReturnDecimal(txt染厂绞重.Text);
                if (txt检验后称重.Text.Trim() != "")
                    dr生产流程卡["检验后称重"] = ReturnDecimal(txt检验后称重.Text);
                if (txt检验后绞数.Text.Trim() != "")
                    dr生产流程卡["检验后绞数"] = ReturnDecimal(txt检验后绞数.Text);
                if (txt检验后绞重.Text.Trim() != "")
                    dr生产流程卡["检验后绞重"] = ReturnDecimal(txt检验后绞重.Text);
                dr生产流程卡["次品原因"] = txt次品原因.Text.Trim();
                dr生产流程卡["备注"] = txt备注.Text.Trim();
                if (txt回潮后称重.Text.Trim() != "")
                    dr生产流程卡["回潮后称重"] = ReturnDecimal(txt回潮后称重.Text);
                if (txt糟筒后称重.Text.Trim() != "")
                    dr生产流程卡["糟筒后称重"] = ReturnDecimal(txt糟筒后称重.Text);
                if (txt成团后称重.Text.Trim() != "")
                    dr生产流程卡["成团后称重"] = ReturnDecimal(txt成团后称重.Text);
                dr生产流程卡["制单人"] = 系统服务.ClsBaseDataInfo.sUid;
                dr生产流程卡["制单日期"] = DateTime.Now;
                dt生产流程卡.Rows.Add(dr生产流程卡);

                if (sState == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL(s表名称, dt生产流程卡, 0);
                    aList.Add(sSQL);
                }
                if (sState == "edit")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(s表名称, dt生产流程卡, 0);
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    SetEnable(false);
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                }
            }
            catch (Exception ee)
            {
                throw new Exception("保存失败:" + ee.Message);
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
        //    int iFocRow = gridView1.FocusedRowHandle;
        //    GetGrid();
        //    gridView1.FocusedRowHandle = iFocRow;
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

        private void Frm生产流程卡_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripMenuBtn.Items["save"].Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Normal;

                dtm单据日期.Text = DateTime.Now.ToString("yyyy-MM-dd");

                SetEnable(false);
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        /// <summary>
        /// 获得参照
        /// </summary>
        private void GetState()
        {
            //DataTable dt = new DataTable();
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "类型";
            //dt.Columns.Add(dc);

            //DataRow dr = dt.NewRow();
            //dr["类型"] = "正式";
            //dt.Rows.Add(dr);
            //dr = dt.NewRow();
            //dr["类型"] = "临时";
            //dt.Rows.Add(dr);

            //LookUpEdit类型.DataSource = dt;
        }

        private void SetTxtValue(string s单据号)
        {
            string sSQL = "select * from 生产流程卡 where 单据号 = " + s单据号;
            dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt == null || dt.Rows.Count < 1)
            {
                SetTxtNull();
                return;
            }

            txt单据号.Text = dt.Rows[0]["单据号"].ToString().Trim();
            dtm单据日期.Text = Convert.ToDateTime(dt.Rows[0]["单据日期"]).ToString("yyyy-MM-dd");
            buttonEdit客户.EditValue = dt.Rows[0]["客户"].ToString().Trim();
            buttonEdit物料编码.EditValue = dt.Rows[0]["品名"].ToString().Trim();
            lookUpEdit色号.EditValue=dt.Rows[0]["色号"].ToString().Trim();
            lookUpEdit缸号.EditValue = dt.Rows[0]["缸号"].ToString().Trim();
            txt染厂称重.Text = ReturnDecimal(dt.Rows[0]["染厂称重"],-1).ToString().Trim();
            txt染厂绞数.Text = ReturnDecimal(dt.Rows[0]["染厂绞数"], -1).ToString().Trim();
            txt染厂绞重.Text = ReturnDecimal(dt.Rows[0]["染厂绞重"], -1).ToString().Trim();
            txt检验后称重.Text = ReturnDecimal(dt.Rows[0]["检验后称重"], -1).ToString().Trim();
            txt检验后绞数.Text = ReturnDecimal(dt.Rows[0]["检验后绞数"], -1).ToString().Trim();
            txt检验后绞重.Text = ReturnDecimal(dt.Rows[0]["检验后绞重"], -1).ToString().Trim();
            txt次品原因.Text = dt.Rows[0]["次品原因"].ToString().Trim();
            txt备注.Text =dt.Rows[0]["备注"].ToString().Trim();
            txt回潮后称重.Text = ReturnDecimal(dt.Rows[0]["回潮后称重"], -1).ToString().Trim();
            txt糟筒后称重.Text = ReturnDecimal(dt.Rows[0]["糟筒后称重"], -1).ToString().Trim();
            txt成团后称重.Text = ReturnDecimal(dt.Rows[0]["成团后称重"], -1).ToString().Trim();
        }
        private void SetTxtNull()
        {
            txt单据号.EditValue = DBNull.Value;
            dtm单据日期.EditValue = DBNull.Value;
            buttonEdit客户.EditValue = DBNull.Value;
            lookUpEdit客户.EditValue = DBNull.Value;
            buttonEdit物料编码.EditValue = DBNull.Value;
            lookUpEdit物料名称.EditValue = DBNull.Value;
            lookUpEdit色号.EditValue = DBNull.Value;
            lookUpEdit缸号.EditValue = DBNull.Value;
            txt染厂称重.EditValue = DBNull.Value;
            txt染厂绞数.EditValue = DBNull.Value;
            txt染厂绞重.EditValue = DBNull.Value;
            txt检验后称重.EditValue = DBNull.Value;
            txt检验后绞数.EditValue = DBNull.Value;
            txt检验后绞重.EditValue = DBNull.Value;
            txt次品原因.EditValue = DBNull.Value;
            txt备注.EditValue = DBNull.Value;
            txt回潮后称重.EditValue = DBNull.Value;
            txt糟筒后称重.EditValue = DBNull.Value;
            txt成团后称重.EditValue = DBNull.Value;
        }

        private object ReturnValue(object a)
        {
            if (a.ToString().Trim() == "")
                return DBNull.Value;
            else
                return a;
        }

        private void GetLookUp()
        {
            系统服务.LookUp.ColorNo(lookUpEdit色号);
            系统服务.LookUp.Dyelot(lookUpEdit缸号);
            系统服务.LookUp.Customer(lookUpEdit客户);
            系统服务.LookUp.Inventory(lookUpEdit物料名称);
        }

        private void txt染厂数据计算_EditValueChanged(object sender, EventArgs e)
        {
            decimal d染厂绞数 = ReturnDecimal(txt染厂绞数.Text);
            decimal d染厂绞重 = ReturnDecimal(txt染厂绞重.Text);
            txt染厂标重.Text = ReturnDecimal(d染厂绞数 * d染厂绞重).ToString().Trim();
        }

        private void txt检验数据计算_EditValueChanged(object sender, EventArgs e)
        {
            decimal d检验后绞数 = ReturnDecimal(txt检验后绞数.Text);
            decimal d检验后绞重 = ReturnDecimal(txt检验后绞重.Text);
            txt检验后标重.Text = ReturnDecimal(d检验后绞数 * d检验后绞重).ToString().Trim();
        }

        private void txt合格次品计算_EditValueChanged(object sender, EventArgs e)
        {
            decimal d染厂标重 = ReturnDecimal(txt染厂标重.Text);
            decimal d检验后标重 = ReturnDecimal(txt检验后标重.Text);
            decimal d次品重量 = d染厂标重 - d检验后标重;
            if (d次品重量 < 0)
                d次品重量 = 0;
            txt次品重量.Text = d次品重量.ToString().Trim();

            decimal d合格率 = 0;
            if (d检验后标重 != 0)
                d合格率 = ReturnDecimal(d染厂标重 * 100 / d检验后标重, 2);

            if (d合格率 < 95)
            {
                txt合格率.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                this.txt合格率.Properties.Appearance.BackColor = System.Drawing.Color.Yellow;
                this.txt合格率.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            else
            {
                txt合格率.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                this.txt合格率.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
                this.txt合格率.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            }

            txt合格率.Text = d合格率.ToString().Trim() + "%";
        }

        private string GetCode()
        {
            sSQL = "select isnull(max(单据号),0) from 生产流程卡 where 单据号 like '" + dtm单据日期.DateTime.ToString("yyMM") + "%'";
            string sCode = clsSQLCommond.ExecGetScalar(sSQL).ToString().Trim();

            if (sCode == "0")
            {
                return dtm单据日期.DateTime.ToString("yyMM") + "0001";
            }
            else
            {
                string sID = sCode.Substring(4);
                long l = long.Parse(sID);
                l += 1;
                string sL = l.ToString().Trim();
                for (int i = 0; i < 4; i++)
                {
                    if (sL.Length < 4)
                        sL = "0" + sL;
                }
                return dtm单据日期.DateTime.ToString("yyMM") + sL;
            }

        }

        private void SetEnable(bool b)
        {
            txt单据号.Enabled = false;
            dtm单据日期.Enabled = false;
            buttonEdit客户.Enabled = b;
            lookUpEdit客户.Enabled = false;
            buttonEdit物料编码.Enabled = b;
            lookUpEdit物料名称.Enabled = false;
            lookUpEdit色号.Enabled = b;
            lookUpEdit缸号.Enabled = b;
            txt染厂称重.Enabled = b;
            txt染厂绞数.Enabled = b;
            txt染厂绞重.Enabled = b;
            txt检验后称重.Enabled = b;
            txt检验后绞数.Enabled = b;
            txt检验后绞重.Enabled = b;
            txt次品原因.Enabled = b;
            txt备注.Enabled = b;
            txt回潮后称重.Enabled = b;
            txt糟筒后称重.Enabled = b;
            txt成团后称重.Enabled = b;
        }


        private void buttonEdit物料编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit物料编码.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit物料编码_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit物料编码.Text.Trim() != "")
                lookUpEdit物料名称.EditValue = buttonEdit物料编码.Text.Trim();
            else
                lookUpEdit物料名称.EditValue = null;
        }

        private void buttonEdit物料编码_Leave(object sender, EventArgs e)
        {
            if (buttonEdit物料编码.Text.Trim() == "")
                return;
            if (lookUpEdit物料名称.Text.Trim() == "")
            {
                buttonEdit物料编码.Text = "";
                buttonEdit物料编码.Focus();
            }
        }

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() != "")
            {
                lookUpEdit客户.EditValue = buttonEdit客户.Text.Trim();
            }
            else
            {
                buttonEdit客户.EditValue = null;
            }
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() == "")
                return;
            if (lookUpEdit客户.Text.Trim() == "")
            {
                buttonEdit客户.Text = "";
                buttonEdit客户.Focus();
            }
        }
    }
}
