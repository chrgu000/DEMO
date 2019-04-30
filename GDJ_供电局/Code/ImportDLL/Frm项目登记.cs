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
    public partial class Frm项目登记 : FrameBaseFunction.FrmBaseInfo
    {

        public Frm项目登记()
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

            string sSQL = @"
select cast(0 as bit) as [choose]
	,* 
from @u8.fitemss00
where 1=-1
order by i_id desc
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            for (int i = 0; i < 100; i++)
            {
                gridView1.AddNewRow();
            }

            gridView1.FocusedRowHandle = 0;
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
            string sErr = "";
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "Excel文件2003|*.xls|Excel文件2007|*.xlsx";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = oFile.FileName;
                string sSQL = "select distinct 项目编码 as citemcode,项目 as citemname,所属分类码 as citemccode,实施工程部,工程主键 from [项目导入$]";

                DataTable dtExcel = clsExcel.ExcelToDT(sFilePath, sSQL, true);
                DataColumn dc = new DataColumn();
                dc.ColumnName = "choose";
                dc.DataType = System.Type.GetType("System.Boolean");
                dtExcel.Columns.Add(dc);

                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    dtExcel.Rows[i]["choose"] = true;
                }

                gridControl1.DataSource = dtExcel;

                gridView1.OptionsBehavior.Editable = true;
                gridView1.OptionsBehavior.ReadOnly = false;
            }
            else
            {
                throw new Exception("取消导入");
            }
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

            string sInfo = "";

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (System.Text.Encoding.GetEncoding("GB2312").GetByteCount(gridView1.GetRowCellValue(i, gridColcitemcode).ToString().Trim()) > 20)
                {
                    if (sInfo == "")
                    {
                        sInfo = (i + 1).ToString();
                    }
                    else
                    {
                        sInfo = sInfo + " ， " + (i + 1).ToString();
                    }
                }
            }

            if (sInfo != "")
            {
                if (MessageBox.Show(sInfo, "项目编号超20位", MessageBoxButtons.YesNo, MessageBoxIcon.None) != DialogResult.Yes)
                {
                    throw new Exception("用户取消操作");
                }
            }

            int iCount = 0;
            string sErr = "";
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
                //string sSQL = "select * from SystemDB_GDJ.dbo.帐套数据库对照表";
                //DataTable dt帐套 = SqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    bool b = SqlHelper.ReturnObjectToBool(gridView1.GetRowCellValue(i, gridColchoose));
                    if (!b)
                        continue;

                    string s帐套 = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);

                    string 数据库 = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName;

                    string s工程主键 = gridView1.GetRowCellValue(i, gridCol工程主键).ToString().Trim();
                    //if (s工程主键 == "")
                    //{
                    //    sErr = sErr + "工程主键不能为空\n";
                    //    continue;
                    //}

                    string s项目编码 = gridView1.GetRowCellValue(i, gridColcitemcode).ToString().Trim();
                    if (s项目编码 == "")
                    {
                        sErr = sErr + "项目编码不能为空\n";
                        continue;
                    }

                    string s项目名称 = gridView1.GetRowCellValue(i, gridColcitemname).ToString().Trim();
                    if (s项目名称 == "")
                    {
                        sErr = sErr + "项目名称不能为空\n";
                        continue;
                    }

                    string s项目大类编码 = gridView1.GetRowCellValue(i, gridColcitemccode).ToString().Trim();
                    if (s项目大类编码 == "")
                    {
                        sErr = sErr + "项目大类编码不能为空\n";
                        continue;
                    }

                    sSQL = "select count(1) from aaa..fitemss00class where cItemCcode = '" + s项目大类编码 + "' and isnull(bItemCend,0) = 1";
                    sSQL = sSQL.Replace("aaa", 数据库);
                    int iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));

                    if (iCou == 0)
                    {
                        sErr = sErr + "项目分类不存在\n";
                        continue;
                    }

                    string s实施工程部 = gridView1.GetRowCellValue(i, gridCol实施工程部).ToString().Trim();

                    string s项目编号截断 = s项目编码;

                    if (System.Text.Encoding.GetEncoding("GB2312").GetByteCount(s项目编号截断) > 20)
                    {
                        s项目编号截断 = s项目编号截断.Substring(5);
                    }

                    if (System.Text.Encoding.GetEncoding("GB2312").GetByteCount(s项目编号截断) > 20)
                    {
                        s项目编号截断 = CutStr(s项目编号截断, 20);
                    }

                    if (System.Text.Encoding.GetEncoding("GB2312").GetByteCount(s项目名称) > 60)
                    {
                        s项目名称 = CutStr(s项目名称, 60);
                    }

                    sSQL = "select count(1) from aaa..fitemss00 where (citemcode = '" + s项目编码 + "' or citemcode = '" + s项目编号截断 + "')";
                    sSQL = sSQL.Replace("aaa", 数据库);
                    iCou = SqlHelper.ReturnObjectToInt(SqlHelper.ExecuteScalar(tran, CommandType.Text, sSQL));
                    if (iCou == 0)
                    {
                        sSQL = "insert into aaa..fitemss00(citemcode,citemname,bclose,citemccode,实施工程部,工程主键,原始编号)" +
                                "values('" + s项目编号截断 + "','" + CutStr(s项目名称, 60) + "',0,'" + s项目大类编码 + "','" + s实施工程部 + "','" + s工程主键 + "','" + s项目编码 + "')";

                        sSQL = sSQL.Replace("aaa", 数据库);
                        iCount = iCount + SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);


                        //sSQL = "insert into SystemDB_GDJ..项目帐套对照表(cItemCode,cItemName,工程主键,帐套)" +
                        //        "values('" + s项目编号截断 + "','" + s项目名称 + "','" + s工程主键 + "','" + s帐套 + "')";
                        //SqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }

                if (sErr.Trim().Length > 0)
                {
                    throw new Exception(sErr);
                }

                tran.Commit();
                if (iCount > 0)
                {
                    MessageBox.Show("保存成功");
                }

                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.ReadOnly = true;
            }
            catch (Exception error)
            {
                tran.Rollback();
                throw new Exception(error.Message);
            }

        }


        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.ReadOnly = true;
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


        private void GetGrid()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsBehavior.ReadOnly = true;

            string sSQL = @"
select cast(0 as bit) as [choose]
	,* 
from @u8.fitemss00
order by i_id desc
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;

            gridView1.FocusedRowHandle = 0;
        }

        private void GetLookUp()
        {
            string sSQL = @"
select cItemCcode,cItemCname from @u8.fitemss00class order by cItemCcode
";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditcItemCcode.DataSource = dt;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.ReadOnly = true;

                GetLookUp();
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gridColcitemcode)
                {
                    gridView1.SetRowCellValue(e.RowHandle, gridColchoose, true);
                }
            }
            catch { }
        }

        public string CutStr(string sInString, int iCutLength)
        {
            if (sInString == null || sInString.Length == 0 || iCutLength <= 0) return "";
            int iCount = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(sInString);
            if (iCount > iCutLength)
            {
                int iLength = 0;
                for (int i = 0; i < sInString.Length; i++)
                {
                    int iCharLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount(new char[] { sInString[i] });
                    iLength += iCharLength;
                    if (iLength == iCutLength)
                    {
                        sInString = sInString.Substring(0, i + 1);
                        break;
                    }
                    else if (iLength > iCutLength)
                    {
                        sInString = sInString.Substring(0, i);
                        break;
                    }
                }
            }
            return sInString;
        }
    }
}
