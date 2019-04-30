using System;
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

namespace ImportDLL
{
    public partial class Frm产品工序 : FrameBaseFunction.FrmFromModel
    {
        public Frm产品工序()
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
                    case "export":
                        btnExport();
                        break;
                
                    case "refresh":
                        btnRefresh();
                        break;
                    case "save":
                        btnSave();
                        break;

                    case "del":
                        btnDel();
                        break;

                    case "delrow":
                        btnDelRow();
                        break;

                    case "addrow":
                        btnAddRow();
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

        private void btnRefresh()
        {
            SetLookUp();

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
            int iRowFoc = gridView1.FocusedRowHandle;
            gridView1.DeleteRow(iRowFoc);
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            DialogResult d = MessageBox.Show("确定删除选定的项么？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != DialogResult.Yes)
                throw new Exception("取消删除");

            string sSQL = @"
delete _产品工序 where cInvCode = '111111'
";
            sSQL = sSQL.Replace("111111", lookUpEditcInvCode.EditValue.ToString().Trim());
            int iCou = DbHelperSQL.ExecuteSql(sSQL);

            if (iCou > 0)
            {
                MessageBox.Show("删除成功");
                GetGrid();
            }
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
                if (gridView1.RowCount == 0)
                {
                    throw new Exception("请登记单据");
                }

                string sErr = "";
                int iCou = 0;
                if (lookUpEditcInvCode .EditValue == null || lookUpEditcInvCode.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请选择产品");
                }

                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    sSQL = "select getdate()";
                    DateTime dtmNOW = BaseFunction.BaseFunction.ReturnDate(DbHelperSQL.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);

                    sSQL = @"
delete _产品工序 where cInvCode = '111111'
";
                    sSQL = sSQL.Replace("111111", lookUpEditcInvCode.EditValue.ToString().Trim());
                    DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                    for(int i=0;i<gridView1.RowCount;i++)
                    {
                        if (gridView1.GetRowCellValue(i, gridColWorkProcessNo).ToString().Trim() == "")
                            continue;

                        TH.Model._产品工序 model = new TH.Model._产品工序();
                        model.cInvCode = lookUpEditcInvCode.EditValue.ToString().Trim();
                        model.iRow = (i + 1).ToString();
                        model.WorkProcessNo = gridView1.GetRowCellValue(i, gridColWorkProcessNo).ToString().Trim();
                        model.Remark = gridView1.GetRowCellValue(i, gridColRemark).ToString().Trim();
                        model.CreateUid = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                        model.CreateDate = dtmNOW;


                        TH.DAL._产品工序 dal = new TH.DAL._产品工序();
                        sSQL = dal.Add(model);
                        iCou = iCou + DbHelperSQL.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                    

                    if (sErr.Length > 0)
                        throw new Exception(sErr);

                    if (iCou > 0)
                    {
                        tran.Commit();
                        MessageBox.Show("保存成功");

                        GetGrid();
                    }
                    else
                    {
                        throw new Exception("没有数据");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    iCou = 0;

                    throw new Exception(error.Message);
                }
            }
            catch (Exception ee)
            {
                MsgBox("保存失败", ee.Message);
            }
        }
       
        #endregion

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.WindowState = FormWindowState.Normal;

                SetLookUp();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookUp()
        {
            string sSQL = @"
select cInvCode,cInvName,cInvStd 
from @u8.Inventory
order by cInvCode
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            lookUpEditcInvCode.Properties.DataSource = dt;
            lookUpEditcInvName.Properties.DataSource = dt;
            lookUpEditcInvStd.Properties.DataSource = dt;

            sSQL = @"
select WorkProcessNo,WorkProcessName from dbo.WorkProcess order by WorkProcessNo
"; 
            dt = clsSQLCommond.ExecQuery(sSQL);
            dr = dt.NewRow();
            dt.Rows.InsertAt(dr, 0);
            ItemLookUpEditWorkProcessNo.DataSource = dt;
            ItemLookUpEditWorkProcessName.DataSource = dt;
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

        private void GetGrid()
        {
            string sInvCode = "";

            if (lookUpEditcInvCode.EditValue != null && lookUpEditcInvCode.EditValue.ToString().Trim() != "")
            {
                sInvCode = lookUpEditcInvCode.EditValue.ToString().Trim();
            }

            sSQL = @"
select * 
from dbo._产品工序 
where cInvCode = '111111' 
order by iID
";
            sSQL = sSQL.Replace("111111", sInvCode);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            while (gridView1.RowCount < 10)
            {
                gridView1.AddNewRow();
            }

            gridView1.FocusedRowHandle = 0;
        }

        private void lookUpEditcInvCode_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvName.EditValue = lookUpEditcInvCode.EditValue;
                lookUpEditcInvStd.EditValue = lookUpEditcInvCode.EditValue;

                GetGrid();
            }
            catch { }
        }

        private void lookUpEditcInvName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvCode.EditValue = lookUpEditcInvName.EditValue;
                lookUpEditcInvStd.EditValue = lookUpEditcInvName.EditValue;
            }
            catch { }
        }

        private void lookUpEditcInvStd_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                lookUpEditcInvCode.EditValue = lookUpEditcInvStd.EditValue;
                lookUpEditcInvName.EditValue = lookUpEditcInvStd.EditValue;
            }
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle == gridView1.RowCount - 1)
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedColumn = gridColWorkProcessNo;
                }

                if (gridView1.GetRowCellValue(e.RowHandle, gridColWorkProcessNo).ToString().Trim() != "" && gridColWorkProcessNo == e.Column)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColiRow, e.RowHandle + 1);
                }
            }
            catch { }
        }
    }
}
