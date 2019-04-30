using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace ImportDLL
{
    public partial class Frm生产日报 : FrameBaseFunction.FrmFromModel
    {
        TH.Model.Equipment Model = new TH.Model.Equipment();
        TH.DAL._GetBaseData DALGetBaseData = new TH.DAL._GetBaseData();
        TH.DAL.生产日报表 DAL = new TH.DAL.生产日报表();

        Guid guid;

        public Frm生产日报()
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
           
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetGrid();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGrid();
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
            //判断是否审核

            if (lookUpEdit班组.EditValue == null || lookUpEdit班组.EditValue.ToString().Trim() == "")
            {
                lookUpEdit班组.Focus();
                throw new Exception("请选择班组");
            }

            if (lookUpEdit工序.EditValue == null || lookUpEdit工序.EditValue.ToString().Trim() == "")
            {
                lookUpEdit工序.Focus();
                throw new Exception("请选择工序");
            }

            if (dateEdit1.Text == "")
            {
                throw new Exception("请设置日期"); 
            }

            if (buttonEdit生产订单序号.Text == "")
            {
                throw new Exception("请设置生产订单序号");
            }

            SetEnable(true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            //try
            //{
            //    gridView1.FocusedRowHandle -= 1;
            //    gridView1.FocusedRowHandle += 1;
            //}
            //catch { }

            //DialogResult d = MessageBox.Show("确定删除选定的项么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            //if (d != DialogResult.Yes)
            //    throw new Exception("取消删除");

            //try
            //{
            //    dtBingGrid = (DataTable)gridControl1.DataSource;

            //    int iCou = DAL.Del(dtBingGrid);

            //    if (iCou > 0)
            //    {
         
            //            MessageBox.Show("删除成功");
     

            //        GetGrid();
            //    }
            //    else
            //    {
            //       MessageBox.Show("请选择需要删除的数据");
                    
            //    }
            //}
            //catch (Exception ee)
            //{
            //    MsgBox("删除失败", ee.Message);
            //}
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

            try
            {
                dtBingGrid = (DataTable)gridControl1.DataSource;

                TH.Model.生产日报表 model = new TH.Model.生产日报表();
                model.班次 = lookUpEdit班组.EditValue.ToString().Trim();
                model.工序 = lookUpEdit工序.EditValue.ToString().Trim();
                model.日期 = dateEdit1.DateTime;
                model.生产订单序号 = BaseFunction.BaseFunction.ReturnInt(buttonEdit生产订单序号.Text.Trim());
                model.工艺路线顺序 = lookUpEdit工艺路线顺序.EditValue.ToString().Trim();
            
                model.iID = BaseFunction.BaseFunction.ReturnInt(txtID.Text);
                model.制单人 = textEdit制单人.Text;
                model.制单日期 = BaseFunction.BaseFunction.ReturnDate(dateEdit制单日期.DateTime);
                model.存货编码 = lookUpEdit存货编码.EditValue.ToString().Trim();
              
                
                model.GUID = guid;

                int iCou = DAL.Save(model, dtBingGrid);

                if (iCou > 0)
                {

                    MessageBox.Show("保存成功");

                    buttonEdit生产订单序号_Validated(null, null);
                }
                else
                {
                    MessageBox.Show("请选择需要保存的数据");

                }
            }
            catch (Exception ee)
            {
                MsgBox("保存失败", ee.Message);
            }
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                TH.Model.生产日报表 model = new TH.Model.生产日报表();
                model.审核人 = FrameBaseFunction.ClsBaseDataInfo.sUid;
                model.GUID = guid;

                int iCou = DAL.Audit(model);

                if (iCou > 0)
                {

                    MessageBox.Show("审核成功");


                    buttonEdit生产订单序号_Validated(null, null);
                }
                else
                {
                    MessageBox.Show("请选择需要审核的数据");
                }
            }
            catch (Exception ee)
            {
                MsgBox("审核失败", ee.Message);
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                TH.Model.生产日报表 model = new TH.Model.生产日报表();
                model.审核人 = FrameBaseFunction.ClsBaseDataInfo.sUid;
                model.GUID = guid;

                int iCou = DAL.UnAudit(model);

                if (iCou > 0)
                {

                    MessageBox.Show("弃审成功");


                    buttonEdit生产订单序号_Validated(null, null);
                }
                else
                {
                    MessageBox.Show("请选择需要弃审的数据");
                }
            }
            catch (Exception ee)
            {
                MsgBox("审核失败", ee.Message);
            }
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

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                SetEnable(false);
                GetLookup();
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
            //int iFocRow = 0;
            //if (gridView1.FocusedRowHandle > 0)
            //    iFocRow = gridView1.FocusedRowHandle;

            //dtBingGrid = DAL.GetList("");
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "choose";
            //dc.DataType = System.Type.GetType("System.Boolean");
            //dc.DefaultValue = false;
            //dtBingGrid.Columns.Add(dc);

            //gridControl1.DataSource = dtBingGrid;
            //gridView1.AddNewRow();

            //gridView1.FocusedRowHandle = iFocRow;
            //chkAll.Checked = false;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, gridCol选择, chkAll.Checked);
            }
        }

        private void SetEnable(bool b)
        {
            try
            {
                lookUpEdit班组.Enabled = true;
                lookUpEdit工序.Enabled = true;
                dateEdit1.Enabled = true;
                buttonEdit生产订单序号.Enabled = true;

                lookUpEdit工艺路线顺序.Enabled = false;

                lookUpEdit生产订单号.Enabled = false;
                textEdit订单数量.Enabled = false;
                lookUpEdit存货编码.Enabled = false;
                lookUpEdit存货名称.Enabled = false;
                lookUpEdit规格型号.Enabled = false;

                textEdit制单人.Enabled = false;
                textEdit审核人.Enabled = false;
                dateEdit制单日期.Enabled = false;
                dateEdit审核日期.Enabled = false;

                txtID.Enabled = false;

                gridView1.OptionsBehavior.Editable = b;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void GetLookup()
        {
            dateEdit1.DateTime = DateTime.Today;

            DataTable dt = DALGetBaseData.GetInventory("and 1=1");
            lookUpEdit存货编码.Properties.DataSource = dt;
            lookUpEdit存货名称.Properties.DataSource = dt;
            lookUpEdit规格型号.Properties.DataSource = dt;

            dt = DALGetBaseData.GetWorkGroupPeople("and 1=1");
            lookUpEdit班组.Properties.DataSource = dt;

            dt = DALGetBaseData.GetWorkProcess("and 1=1");
            lookUpEdit工序.Properties.DataSource = dt;

            dt = DALGetBaseData.GetProductPO("");
            lookUpEdit生产订单号.Properties.DataSource = dt;
        }

        private void buttonEdit生产订单序号_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (lookUpEdit班组.EditValue == null || lookUpEdit班组.EditValue.ToString().Trim() == "")
                {
                    lookUpEdit班组.Focus();
                    throw new Exception("请选择班组");
                }

                if (lookUpEdit工序.EditValue == null || lookUpEdit工序.EditValue.ToString().Trim() == "")
                {
                    lookUpEdit工序.Focus();
                    throw new Exception("请选择工序");
                }

                Frm生产日报订单查询 f = new Frm生产日报订单查询(lookUpEdit工序.EditValue.ToString().Trim(), lookUpEdit班组.EditValue.ToString().Trim());
                DialogResult d = f.ShowDialog();
                if (d == DialogResult.OK)
                {
                    buttonEdit生产订单序号.Text = f.s生产订单序号;

                    lookUpEdit工艺路线顺序.EditValue = f.s工艺路线顺序;

                    buttonEdit生产订单序号_Validated(null, null);

                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit生产订单序号_Validated(object sender, EventArgs e)
        {
            try
            {
                string s生产订单序号 = buttonEdit生产订单序号.Text.Trim();
                if (s生产订单序号 == "")
                {
                    buttonEdit生产订单序号.Focus();
                    return;
                }

                string s班组 = lookUpEdit班组.EditValue.ToString().Trim();
                string s工艺路线顺序 = lookUpEdit工艺路线顺序.EditValue.ToString().Trim();
                string s工序 = lookUpEdit工序.EditValue.ToString().Trim();

                DataTable dtWork = DAL.Get生产报工(s生产订单序号, s班组, s工艺路线顺序, s工序,dateEdit1.DateTime);
                if (dtWork == null || dtWork.Rows.Count < 1)
                {
                    throw new Exception("获得生产订单信息失败");
                }

                lookUpEdit生产订单号.EditValue = dtWork.Rows[0]["生产订单号"];
                textEdit订单数量.Text = dtWork.Rows[0]["生产订单数量"].ToString().Trim();
                lookUpEdit存货编码.EditValue = dtWork.Rows[0]["存货编码"].ToString().Trim();
                lookUpEdit存货名称.EditValue = dtWork.Rows[0]["存货编码"].ToString().Trim();
                lookUpEdit规格型号.EditValue = dtWork.Rows[0]["存货编码"].ToString().Trim();
            
                textEdit制单人.Text = dtWork.Rows[0]["制单人"].ToString().Trim();
                textEdit审核人.Text = dtWork.Rows[0]["审核人"].ToString().Trim();
                txtID.Text = dtWork.Rows[0]["iID"].ToString().Trim();
              

                if (dtWork.Rows[0]["GUID"].ToString().Trim() == "")
                    guid = Guid.NewGuid();
                else
                    guid = (Guid)dtWork.Rows[0]["GUID"];

                DateTime dTime =  BaseFunction.BaseFunction.ReturnDate(dtWork.Rows[0]["制单日期"]);
                if(dTime>Convert.ToDateTime("2014-1-1"))
                {
                    dateEdit制单日期.Text = dTime.ToString("yyyy-MM-dd");
                }
                dTime = BaseFunction.BaseFunction.ReturnDate(dtWork.Rows[0]["审核日期"]);
                if (dTime > Convert.ToDateTime("2014-1-1"))
                {
                    dateEdit审核日期.Text = dTime.ToString("yyyy-MM-dd");
                }

                //获得未报工的箱号
                DataTable dt未报工箱号 = DAL.Get未报工箱号(s生产订单序号, s工艺路线顺序, s工序);

                //将当前报工信息添加进未报工信息
                for (int i = 0; i < dtWork.Rows.Count; i++)
                {
                    string s箱号 = dtWork.Rows[i]["箱号"].ToString().Trim();
                    if (s箱号 != "")
                    {
                        DataRow dr = dt未报工箱号.NewRow();
                        dr["选择"] = true;
                        dr["箱号"] = s箱号;
                        dr["装箱数"] = BaseFunction.BaseFunction.ReturnDecimal(dtWork.Rows[i]["装箱数"], 2);
                        dt未报工箱号.Rows.Add(dr);
                    }
                }

                DataView dv = dt未报工箱号.DefaultView;
                dv.Sort = "箱号 asc";
                DataTable dtTemp = dv.ToTable().Copy();
                gridControl1.DataSource = dtTemp;

                if (textEdit审核人.Text.Trim() != "")
                {
                    SetEnable(false);
                }
                else
                {
                    SetEnable(true);
                }

                gridView1_CellValueChanged(null, null);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void 单据关键字段_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                buttonEdit生产订单序号.Text = "";
                lookUpEdit工艺路线顺序.EditValue = DBNull.Value;
                lookUpEdit生产订单号.EditValue = DBNull.Value;
                textEdit订单数量.Text = "";
                lookUpEdit存货编码.EditValue = DBNull.Value;
                lookUpEdit存货名称.EditValue = DBNull.Value;
                lookUpEdit规格型号.EditValue = DBNull.Value;
             

                textEdit制单人.Text = "";
                dateEdit制单日期.Text = "";
                textEdit审核人.Text = "";
                dateEdit审核日期.Text = "";

            
                txtID.Text = "";

                chkAll.Checked = false;

                guid = Guid.Empty;

                
                gridControl1.DataSource = null;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int iCou = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (BaseFunction.BaseFunction.ReturnBool(gridView1.GetRowCellValue(i, gridCol选择)))
                    {
                        iCou = iCou + 1;
                    }
                }
            }
            catch { }
        }
    }
}
