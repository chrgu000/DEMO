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
    public partial class Frm科目余额表 : FrameBaseFunction.FrmBaseInfo
    {

        public Frm科目余额表()
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
            throw new NotImplementedException();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            GetGridView();
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


        private void GetLookUp()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "年度";
            dt.Columns.Add(dc);

            for (int i = 0; i <= 9; i++)
            {
                DataRow dr = dt.NewRow();
                dr["年度"] = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).Year - i;
                dt.Rows.Add(dr);
            }
            lookUpEdit年度.Properties.DataSource = dt;

            dt = new DataTable();
            dc = new DataColumn();
            dc.ColumnName = "月";
            dt.Columns.Add(dc);

            for (int i = 1; i <= 12; i++)
            {
                DataRow dr = dt.NewRow();
                dr["月"] = i;
                dt.Rows.Add(dr);
            }
            lookUpEdit月份1.Properties.DataSource = dt;
            lookUpEdit月份2.Properties.DataSource = dt;

            dt = new DataTable();
            dc = new DataColumn();
            dc.ColumnName = "级次";
            dt.Columns.Add(dc);

            DataRow dr2 = dt.NewRow();
            dr2["级次"] = 1;
            dt.Rows.Add(dr2);

            for (int i = 2; i < 6; i++)
            {
                dr2 = dt.NewRow();
                dr2["级次"] = i;
                dt.Rows.Add(dr2);
            }

            lookUpEdit级次1.Properties.DataSource = dt;
            lookUpEdit级次1.EditValue = "1";
            lookUpEdit级次2.Properties.DataSource = dt;
            lookUpEdit级次2.EditValue = "1";
        }

        private void Frm科目余额表_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                lookUpEdit年度.EditValue = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).Year.ToString();
                lookUpEdit月份1.EditValue = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).Month.ToString();
                lookUpEdit月份2.EditValue = Convert.ToDateTime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).Month.ToString();
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

        private void GetGridView()
        {
            Frm用户默认帐套 f = new Frm用户默认帐套(FrameBaseFunction.ClsBaseDataInfo.sUid);
            f.ShowDialog();

            if (f.DialogResult != DialogResult.Yes)
            {
                throw new Exception("取消查询");
            }

            try
            {
                DataTable dt = f.dt.Copy();
                for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Columns[i].Caption.Trim() == "科目编码")
                        continue;


                    if (gridView1.Columns[i].Caption.Trim() == "科目")
                        continue;

                    gridView1.Columns.RemoveAt(i);
                }
                for (int i = gridView1.Bands.Count - 1; i >= 0; i--)
                {
                    if (gridView1.Bands[i].Caption.Trim() == "科目")
                        continue;

                    gridView1.Bands.RemoveAt(i);
                }

                string sCol = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dt.Rows[i]["选择"]))
                    {
                        string s帐套号 = dt.Rows[i]["帐套号"].ToString().Trim();
                        string s帐套名称 = dt.Rows[i]["帐套名称"].ToString().Trim();
                        string sCaption = "[" + s帐套号 + "]" + s帐套名称;

                        sCol = sCol + "," + s帐套号;

                        SetCol(sCaption, s帐套号, "AccID" + s帐套号, i + 6);
                    }
                }
                SetCol("累计", "累计", "累计", dt.Rows.Count + 6);

                
                SqlConnection con = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
                SqlCommand cmd = new SqlCommand();
                SqlTransaction trans;
                con.Open();
                cmd.Connection = con;
                trans = con.BeginTransaction();
                cmd.Transaction = trans;
                try
                {
                    //创建临时表
                    string sTableName = "RepTH" + FrameBaseFunction.ClsBaseDataInfo.sUid;

                    //sSQL = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + sTableName + "]') AND type in (N'U')) DROP TABLE [dbo].[" + sTableName + "]";

                    sSQL = @"if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[111111]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[111111]";
                    sSQL = sSQL.Replace("111111", sTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    string[] sColList = sCol.Split(',');
                    string s组装字段 = "";
                    for (int i = 0; i < sColList.Length; i++)
                    {
                        string s = sColList[i].Trim();
                        if (s == "")
                            continue;

                        s组装字段 = s组装字段 + ",期初借方" + s + " decimal(16,2)";
                        s组装字段 = s组装字段 + ",期初贷方" + s + " decimal(16,2)";
                        s组装字段 = s组装字段 + ",本期借方" + s + " decimal(16,2)";
                        s组装字段 = s组装字段 + ",本期贷方" + s + " decimal(16,2)";
                        s组装字段 = s组装字段 + ",期末借方" + s + " decimal(16,2)";
                        s组装字段 = s组装字段 + ",期末贷方" + s + " decimal(16,2)";
                    }

                    s组装字段 = s组装字段 + ",期初借方累计" + " decimal(16,2)";
                    s组装字段 = s组装字段 + ",期初贷方累计" + " decimal(16,2)";
                    s组装字段 = s组装字段 + ",本期借方累计" + " decimal(16,2)";
                    s组装字段 = s组装字段 + ",本期贷方累计" + " decimal(16,2)";
                    s组装字段 = s组装字段 + ",期末借方累计" + " decimal(16,2)";
                    s组装字段 = s组装字段 + ",期末贷方累计" + " decimal(16,2)";

                    sSQL = @"
create table RepTH(
类型 varchar(50),
科目编码 varchar(50),
科目 varchar(200)
111111
)
";
                    
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    sSQL = sSQL.Replace("111111", s组装字段);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    string sYear = lookUpEdit年度.Text.Trim();

                    for (int i = 0; i < sColList.Length; i++)
                    {
                        string s = sColList[i].Trim();
                        if (s == "")
                            continue;

                        string sAccID = sColList[i].Trim();
                        string sUFDBName = "UFDATA_" + sAccID + "_" + sYear;

                        int i包含未记账 = 1;
                        if (chk包含未记账.Checked)
                            i包含未记账 = 0;

                        int i级次1 = ReturnInt(lookUpEdit级次1.EditValue);
                        int i级次2 = ReturnInt(lookUpEdit级次2.EditValue);

                        int i开始月份 = ReturnInt(lookUpEdit月份1.Text.Trim());
                        int i结束月份 = ReturnInt(lookUpEdit月份2.Text.Trim());

                        if (FrameBaseFunction.ClsBaseDataInfo.sERPEdition == "u851a")
                        {
                            sSQL = "exec UFDATA..GL_P_FSEYEB 'aaaaaa','bbbbbb','cccccc', NULL, '我', '1', '1', 0, NULL, NULL, NULL, NULL, 'case when cclass =''资产'' then 1 else case when cclass =''负债'' then 2 else case when cclass =''权益'' then 3 else case when cclass =''成本'' then 4 else 5 end  end  end  end  as lx', 'YEB98612'";
                        }
                        else
                        {
                            if (chk末级科目.Checked)
                            {
                                sSQL = "exec UFDATA..GL_P_FSEYEB 'aaaaaa','bbbbbb','cccccc','1','1',NULL,'我',0,0,1,NULL,NULL,NULL,NULL,'case when cclass =''资产'' then 1 else case when cclass =''负债'' then 2 else case when cclass =''权益'' then 3 else case when cclass =''成本'' then 4 else 5 end  end  end  end  as lx','YEB58183'";
                            }
                            else
                            {
                                sSQL = "exec UFDATA..GL_P_FSEYEB 'aaaaaa','bbbbbb','cccccc','1','1',NULL,'我',dddddd,eeeeee,0,NULL,NULL,NULL,NULL,'case when cclass =''资产'' then 1 else case when cclass =''负债'' then 2 else case when cclass =''权益'' then 3 else case when cclass =''成本'' then 4 else 5 end  end  end  end  as lx','YEB58183'";
                            }
                        }
                        sSQL = sSQL.Replace("aaaaaa", i开始月份.ToString().Trim());
                        sSQL = sSQL.Replace("bbbbbb", i结束月份.ToString().Trim());
                        sSQL = sSQL.Replace("cccccc", i包含未记账.ToString().Trim());
                        sSQL = sSQL.Replace("dddddd", i级次1.ToString().Trim());
                        sSQL = sSQL.Replace("eeeeee", i级次2.ToString().Trim());
                        sSQL = sSQL.Replace("UFDATA", sUFDBName);
                        DataTable dtTemp = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                        if (dtTemp == null || dtTemp.Rows.Count < 1)
                            continue;

                        sSQL = "select * from UFDATA..code order by ccode";
                        sSQL = sSQL.Replace("UFDATA", sUFDBName);
                        DataTable dt科目 = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                        for (int j = 0; j < dtTemp.Rows.Count; j++)
                        {
                            string sCode = dtTemp.Rows[j]["cCode"].ToString().Trim();

                            decimal d期初借方 = ReturnDecimal(dtTemp.Rows[j]["sbb"], 2);
                            decimal d期初贷方 = ReturnDecimal(dtTemp.Rows[j]["sbb1"], 2);
                            decimal d本期借方 = ReturnDecimal(dtTemp.Rows[j]["smd"], 2);
                            decimal d本期贷方 = ReturnDecimal(dtTemp.Rows[j]["smc"], 2);
                            decimal d期末借方 = ReturnDecimal(dtTemp.Rows[j]["smm"], 2);
                            decimal d期末贷方 = ReturnDecimal(dtTemp.Rows[j]["smm1"], 2);


                            string s科目编码 = dtTemp.Rows[j]["ccode"].ToString().Trim();
                            string s科目 = dtTemp.Rows[j]["ccode_name"].ToString().Trim();
                            if (s科目编码.Length > 3 && s科目编码.Substring(0, 2) == "zz")
                            {
                                continue;
                            }

                            if (s科目编码 == "zz" && dtTemp.Rows[j]["lx"].ToString().Trim() == "1")
                            {
                                s科目编码 = "资产小计";
                            }
                            if (s科目编码 == "zz" && dtTemp.Rows[j]["lx"].ToString().Trim() == "2")
                            {
                                s科目编码 = "负债小计";
                            }
                            if (s科目编码 == "zz" && dtTemp.Rows[j]["lx"].ToString().Trim() == "3")
                            {
                                s科目编码 = "权益小计";
                            }
                            if (s科目编码 == "zz" && dtTemp.Rows[j]["lx"].ToString().Trim() == "4")
                            {
                                s科目编码 = "成本小计";
                            }
                            if (s科目编码 == "zz" && dtTemp.Rows[j]["lx"].ToString().Trim() == "5")
                            {
                                s科目编码 = "损益小计";
                            }
                            if (s科目编码 == "zz" && dtTemp.Rows[j]["lx"].ToString().Trim() == "9")
                            {
                                s科目编码 = "合计";
                            }

                            sSQL = @"
if exists (select * from RepTH where 科目编码 = 's科目编码') 
    update RepTH set 期初借方aaaaaa = d期初借方, 期初贷方aaaaaa = d期初贷方, 本期借方aaaaaa = d本期借方, 本期贷方aaaaaa = d本期贷方, 期末借方aaaaaa = d期末借方, 期末贷方aaaaaa = d期末贷方 where 科目编码 = 's科目编码'
else
    insert into RepTH(类型,科目编码,科目, 期初借方aaaaaa,期初贷方aaaaaa ,本期借方aaaaaa,本期贷方aaaaaa,期末借方aaaaaa,期末贷方aaaaaa)
    values('s类型','s科目编码','s科目',d期初借方,d期初贷方,d本期借方, d本期贷方,d期末借方, d期末贷方)
";
                            sSQL = sSQL.Replace("RepTH", sTableName);
                            sSQL = sSQL.Replace("aaaaaa", sColList[i].Trim());
                            sSQL = sSQL.Replace("s科目编码", s科目编码);
                            sSQL = sSQL.Replace("s科目", s科目);
                            sSQL = sSQL.Replace("s类型", dtTemp.Rows[j]["lx"].ToString().Trim());

                            //d期初借方 =(decimal) 0.00;
                            if (d期初借方 == 0)
                            {
                                sSQL = sSQL.Replace("d期初借方", "null");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("d期初借方", d期初借方.ToString());
                            }
                            if (d期初贷方 == 0)
                            {
                                sSQL = sSQL.Replace("d期初贷方", "null");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("d期初贷方", d期初贷方.ToString());
                            }

                            if (d本期借方 == 0)
                            {
                                sSQL = sSQL.Replace("d本期借方", "null");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("d本期借方", d本期借方.ToString());
                            }
                            if (d本期贷方 == 0)
                            {
                                sSQL = sSQL.Replace("d本期贷方", "null");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("d本期贷方", d本期贷方.ToString());
                            }

                            if (d期末借方 == 0)
                            {
                                sSQL = sSQL.Replace("d期末借方", "null");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("d期末借方", d期末借方.ToString());
                            }
                            if (d期末贷方 == 0)
                            {
                                sSQL = sSQL.Replace("d期末贷方", "null");
                            }
                            else
                            {
                                sSQL = sSQL.Replace("d期末贷方", d期末贷方.ToString());
                            }
                            cmd.CommandText = sSQL;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();
                    sSQL = "select * from RepTH order by 类型,科目编码";
                    sSQL = sSQL.Replace("RepTH", sTableName);
                    DataTable dtRep = SqlHelper.ExecuteDataset(trans, CommandType.Text, sSQL).Tables[0];

                    for (int i = 0; i < dtRep.Rows.Count; i++)
                    {
                        decimal d1 = 0;
                        decimal d2 = 0;
                        decimal d3 = 0;
                        decimal d4 = 0;
                        decimal d5 = 0;
                        decimal d6 = 0;

                        for (int j = 0; j < dtRep.Columns.Count; j++)
                        {
                            string sColC = dtRep.Columns[j].Caption.Trim();
                            if (sColC.Length > 4 && sColC.Substring(0, 4) == "期初借方" && sColC != "期初借方累计")
                                d1 = d1 + ReturnDecimal(dtRep.Rows[i][j]);
                            if (sColC.Length > 4 && sColC.Substring(0, 4) == "期初贷方" && sColC != "期初贷方累计")
                                d2 = d2 + ReturnDecimal(dtRep.Rows[i][j]);
                            if (sColC.Length > 4 && sColC.Substring(0, 4) == "本期借方" && sColC != "本期借方累计")
                                d3 = d3 + ReturnDecimal(dtRep.Rows[i][j]);
                            if (sColC.Length > 4 && sColC.Substring(0, 4) == "本期贷方" && sColC != "本期贷方累计")
                                d4 = d4 + ReturnDecimal(dtRep.Rows[i][j]);
                            if (sColC.Length > 4 && sColC.Substring(0, 4) == "期末借方" && sColC != "期末借方累计")
                                d5 = d5 + ReturnDecimal(dtRep.Rows[i][j]);
                            if (sColC.Length > 4 && sColC.Substring(0, 4) == "期末贷方" && sColC != "期末贷方累计")
                                d6 = d6 + ReturnDecimal(dtRep.Rows[i][j]);
                        }
                        if (d1 != 0)
                            dtRep.Rows[i]["期初借方累计"] = d1;
                        if (d2 != 0)
                            dtRep.Rows[i]["期初贷方累计"] = d2;
                        if (d3 != 0)
                            dtRep.Rows[i]["本期借方累计"] = d3;
                        if (d4 != 0)
                            dtRep.Rows[i]["本期贷方累计"] = d4;
                        if (d5 != 0)
                            dtRep.Rows[i]["期末借方累计"] = d5;
                        if (d6 != 0)
                            dtRep.Rows[i]["期末贷方累计"] = d6;
                    }

                    gridControl1.DataSource = dtRep;

                    sSQL = @"IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + sTableName + "]') AND type in (N'U')) DROP TABLE [dbo].[" + sTableName + "]";
                    sSQL = @"if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[111111]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[111111]";
                    sSQL = sSQL.Replace("111111", sTableName);
                    cmd.CommandText = sSQL;
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }
                catch (Exception ee)
                {
                    trans.Rollback();
                    throw new Exception(ee.Message);
                }
            }
            catch (Exception ee)
            {
                throw new Exception("加载报表列失败："+ee.Message);
            }
        }

        //private void AddGridCol(string sCatpion,string sName,string sFieldName,int sIndex)
        //{

        //    DevExpress.XtraGrid.Columns.GridColumn gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();

        //    gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gridColumn1 });
        //    gridColumn1.Caption = sCatpion;
        //    gridColumn1.Name = "gridCol" + sName;
        //    gridColumn1.FieldName = sFieldName;
        //    gridColumn1.Visible = true;
        //    gridColumn1.VisibleIndex = sIndex;
        //    gridColumn1.Width = 150;
        //    gridColumn1.ColumnEdit = this.ItemTextEditn2;
        //}


        private void SetCol(string sCatpion, string sName, string sFieldName, int sIndex)
        {
            #region 期初
            
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol期初借方 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridCol期初借方.Caption = "借方";
            gridCol期初借方.Name = "gridCol期初借方" + sName;
            gridCol期初借方.FieldName = "期初借方" + sName;
            gridCol期初借方.Visible = true;
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol期初贷方 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridCol期初贷方.Caption = "贷方";
            gridCol期初贷方.Name = "gridCol期初贷方" + sName;
            gridCol期初贷方.FieldName = "期初贷方" + sName;
            gridCol期初贷方.Visible = true;

            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand期初余额 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand期初余额.AppearanceHeader.Options.UseTextOptions = true;
            gridBand期初余额.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand期初余额.Caption = "期初余额";
            gridBand期初余额.Name = "gridBand期初余额" + sName;
            gridBand期初余额.Width = 150;

            #endregion

            #region 发生

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol本期借方 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridCol本期借方.Caption = "借方";
            gridCol本期借方.Name = "gridCol本期借方" + sName;
            gridCol本期借方.FieldName = "本期借方" + sName;
            gridCol本期借方.Visible = true;
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol本期贷方 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridCol本期贷方.Caption = "贷方";
            gridCol本期贷方.Name = "gridCol本期贷方" + sName;
            gridCol本期贷方.FieldName = "本期贷方" + sName;
            gridCol本期贷方.Visible = true;

            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand本期 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand本期.AppearanceHeader.Options.UseTextOptions = true;
            gridBand本期.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand本期.Caption = "本期发生";
            gridBand本期.Name = "gridBand本期" + sName;
            gridBand本期.Width = 150;

            #endregion


            #region 期末余额

            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol期末借方 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridCol期末借方.Caption = "借方";
            gridCol期末借方.Name = "gridCol期末借方" + sName;
            gridCol期末借方.FieldName = "期末借方" + sName;
            gridCol期末借方.Visible = true;
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCol期末贷方 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridCol期末贷方.Caption = "贷方";
            gridCol期末贷方.Name = "gridCol期末贷方" + sName;
            gridCol期末贷方.FieldName = "期末贷方" + sName;
            gridCol期末贷方.Visible = true;

            DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand期末余额 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gridBand期末余额.AppearanceHeader.Options.UseTextOptions = true;
            gridBand期末余额.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridBand期末余额.Caption = "期末余额";
            gridBand期末余额.Name = "gridBand期末余额" + sName;
            gridBand期末余额.Width = 150;

            #endregion

            DevExpress.XtraGrid.Views.BandedGrid.GridBand gBand帐套 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            gBand帐套.AppearanceHeader.Options.UseTextOptions = true;
            gBand帐套.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gBand帐套.Caption = sCatpion;
            gBand帐套.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand期初余额 });
            gBand帐套.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand本期 });
            gBand帐套.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand期末余额 });
            gBand帐套.MinWidth = 20;
            gBand帐套.Name = "gBand帐套";
            gBand帐套.Width = 346;

            gridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gBand帐套 });
            gridBand期初余额.Columns.Add(gridCol期初借方);
            gridBand期初余额.Columns.Add(gridCol期初贷方);

            gridBand本期.Columns.Add(gridCol本期借方);
            gridBand本期.Columns.Add(gridCol本期贷方);

            gridBand期末余额.Columns.Add(gridCol期末借方);
            gridBand期末余额.Columns.Add(gridCol期末贷方);
        }
    }
}
