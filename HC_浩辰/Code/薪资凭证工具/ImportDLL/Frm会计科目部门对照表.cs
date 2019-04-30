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
    public partial class Frm会计科目部门对照表 : FrameBaseFunction.FrmBaseInfo
    {
        public Frm会计科目部门对照表()
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

        string s表名称 = "会计科目部门对照表";

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
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        private void btnAdd()
        {
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.ReadOnly = false;
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
            //string sErr = "";
            //OpenFileDialog oFile = new OpenFileDialog();
            //oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            //if (oFile.ShowDialog() == DialogResult.OK)
            //{
            //    string sFilePath = oFile.FileName;
            //    string sSQL = "select distinct 计量单位编码,计量单位名称,备注 from [" + s表名称 + "$]";

            //    DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);

            //    for (int i = 0; i < dtExcel.Rows.Count; i++)
            //    {
            //        string s编码 = dtExcel.Rows[i][";"].ToString().Trim();
            //        DataRow[] dr = dtBingGrid.Select("; = '" + s编码 + "'");
            //        if (dr.Length > 0)
            //        {
            //            dtExcel.Rows[i]["时间戳"] = dr[0]["时间戳"];
            //            sErr = sErr + s编码 + "\n";
            //        }
            //    }
            //    gridControl1.DataSource = dtExcel;

            //    if (sErr.Length > 0)
            //    {
            //        sErr = "以下计量单位已经存在，不能重复导入：\n" + sErr;
            //        MsgBox("提示", sErr);
            //    }
            //}
            //else
            //{
            //    throw new Exception("取消导入");
            //}
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetGridView();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
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
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            aList = new System.Collections.ArrayList();

            sSQL = "delete 会计科目部门对照表 where 财务帐套 = '" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "' and 薪资帐套 = '" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "' and 工资类别 = '" + lookUpEdit薪资类别.EditValue.ToString().Trim() + "'";
            aList.Add(sSQL);

            sSQL = "select * from dbo.会计科目部门对照表 where 1=-1";
            DataTable dt会计科目部门对照表 = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow dr = dt会计科目部门对照表.NewRow();
                dr["财务帐套"] = lookUpEdit财务帐套.EditValue.ToString().Trim();
                dr["薪资帐套"] = lookUpEdit薪资帐套.EditValue.ToString().Trim();
                dr["工资类别"] = lookUpEdit薪资类别.EditValue.ToString().Trim();
                dr["会计科目"] = gridView1.GetRowCellValue(i, gridCol会计科目).ToString().Trim();
                dr["部门"] = gridView1.GetRowCellValue(i, gridCol部门编码).ToString().Trim();

                dt会计科目部门对照表.Rows.Add(dr);
            }

            for (int i = 0; i < dt会计科目部门对照表.Rows.Count; i++)
            {
                sSQL = clsGetSQL.GetInsertSQL(s表名称, dt会计科目部门对照表, i);
                aList.Add(sSQL);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                GetGridView();
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            throw new NotImplementedException();
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

        private void Frm会计科目工资项目对照表_Load(object sender, EventArgs e)
        {
            try
            {
                GetAccInfo();
                GetDepartment();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
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

        private object ReturnValue(object a)
        {
            if (a.ToString().Trim() == "")
                return DBNull.Value;
            else
                return a;
        }


        /// <summary>
        /// 获得帐套数据,
        /// </summary>
        /// <param name="sSQL"></param>
        private void GetAccInfo()
        {
            try
            {
                string sSQL = "SELECT DISTINCT A.cAcc_Id as iID,'[' + A.cAcc_Id + ']' + A.cAcc_Name as iText  " +
                         "FROM UFSystem.dbo.UA_Account A,UFSystem.dbo.UA_period P   " +
                         "WHERE A.cAcc_Id=P.cAcc_Id AND (P.bIsDelete=0 OR P.bIsDelete IS NULL)  " +
                         "ORDER BY iID,iText";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEdit财务帐套.Properties.DataSource = dt;
                lookUpEdit薪资帐套.Properties.DataSource = dt;

                //lookUpEdit财务帐套.EditValue = "003";
                //lookUpEdit薪资帐套.EditValue = "004";
            }
            catch
            {
                throw new Exception("获得帐套信息失败！");
            }
        }

        private void lookUpEdit薪资帐套_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit薪资帐套.EditValue == null || lookUpEdit薪资帐套.EditValue.ToString().Trim() == "")
                {
                    throw new Exception("请选择薪资帐套");
                }
                string sSQL = "select cGZGradeNum,cGZGradeNum + '_' +cGzGradename as cGzGradename from aaa..WA_account where cGZGradeNum <> '000' and iLastYear = bbb order by cGZGradeNum";
                string sDBName = "UFDATA_" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "_" + Convert.ToDateTime( FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy");
                sSQL = sSQL.Replace("aaa", sDBName);
                sSQL = sSQL.Replace("bbb", Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy").ToString());
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                lookUpEdit薪资类别.Properties.DataSource = dt;
                lookUpEdit薪资类别.EditValue = "001";
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void lookUpEdit薪资类别_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select distinct iMonth from aaa..WA_GZData where iYear = '" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy") + "' order by iMonth";
                string sDBName = "UFDATA_" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "_" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy");
                sSQL = sSQL.Replace("aaa", sDBName);
                DataTable dtLook = clsSQLCommond.ExecQuery(sSQL);

                if (lookUpEdit薪资类别.EditValue != null && lookUpEdit薪资类别.EditValue.ToString().Trim() != "")
                {
                    GetGridView();
                }
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void lookUpEdit财务帐套_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string sSQL = "select ccode as iID,ccode_name as iText from aaa..code where isnull(bend,0) = 1 and iyear = bbb order by ccode";
                string sDBName = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy");
                sSQL = sSQL.Replace("aaa", sDBName);
                sSQL = sSQL.Replace("bbb", Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy").ToString());
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                ItemLookUpEdit会计科目.DataSource = dt;
                ItemLookUpEdit会计科目名称.DataSource = dt;

                GetDepartment();

                if (lookUpEdit财务帐套.EditValue != null && lookUpEdit财务帐套.EditValue.ToString().Trim() != "")
                {
                    GetGridView();
                }
            }
            catch (Exception ee)
            {
                MsgBox("提示", ee.Message);
            }
        }

        private void GetGridView()
        {
            if (lookUpEdit财务帐套.EditValue != null && lookUpEdit财务帐套.EditValue.ToString().Trim() != "" && lookUpEdit薪资类别.EditValue != null && lookUpEdit薪资类别.EditValue.ToString().Trim() != "")
            {
                string sSQL = "select * from  会计科目部门对照表 where 财务帐套 = '" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "' and 薪资帐套 = '" + lookUpEdit薪资帐套.EditValue.ToString().Trim() + "' and 工资类别 = '" + lookUpEdit薪资类别.EditValue.ToString().Trim() + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;

                gridView1.OptionsBehavior.Editable = false;

            }
        }

        private void GetDepartment()
        {
            if (lookUpEdit财务帐套.EditValue == null || lookUpEdit财务帐套.EditValue.ToString().Trim() == "")
                return;

            string sSQL = "select cDepCode as iID,cDepName as iText from aaa..department where bDepEnd = 1 order by cDepCode";
            string sDBName = "UFDATA_" + lookUpEdit财务帐套.EditValue.ToString().Trim() + "_" + Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyy");
            sSQL = sSQL.Replace("aaa", sDBName);
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit部门编码.DataSource = dt;
            ItemLookUpEdit部门名称.DataSource = dt;
        }
    }
}
