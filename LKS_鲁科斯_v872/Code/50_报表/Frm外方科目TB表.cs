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
    public partial class Frm外方科目TB表 : 系统服务.FrmBaseInfo
    {
        IWorkbook book;
        string Type = "";
        public Frm外方科目TB表()
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
            if (book != null)
            {
                SaveFileDialog sF = new SaveFileDialog();
                sF.DefaultExt = "xls";
                sF.FileName = this.Text;
                sF.Filter = "Excel文件(*.xls)|*.xls|所有文件(*.*)|*.*";
                DialogResult dRes = sF.ShowDialog();
                if (DialogResult.OK == dRes)
                {
                    using (FileStream fs = File.OpenWrite(sF.FileName)) //打开一个xls文件，如果没有则自行创建，如果存在myxls.xls文件则在创建是不要打开该文件！
                    {
                        book.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
                        MessageBox.Show("导出Excel成功\n\t路径：" + sF.FileName);
                    }
                }
            }
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

        private void Frm外方科目TB表_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                lookUpEdit开始月份.EditValue = DateTime.Now.Month;
                lookUpEdit类别.EditValue = "1";
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }



        private void GetCol(string ColText, string FieldName)
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = FieldName;
            Col.Name = "gridCol" + FieldName;
            Col.Caption = ColText;
            Col.OptionsColumn.AllowEdit = false;
            Col.Width = 108;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count - 1;
            Col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Col.SummaryItem.FieldName = FieldName;
            gridView1.Columns.Add(Col);
        }

        private string Month(string m,int type)
        {
            string s = "";
            if (type == 1)
            {
                switch (m)
                {
                    case "1":
                        s = "January";
                        break;
                    case "2":
                        s = "February";
                        break;
                    case "3":
                        s = "March";
                        break;
                    case "4":
                        s = "April";
                        break;
                    case "5":
                        s = "May";
                        break;
                    case "6":
                        s = "June";
                        break;
                    case "7":
                        s = "July";
                        break;
                    case "8":
                        s = "August";
                        break;
                    case "9":
                        s = "September";
                        break;
                    case "10":
                        s = "October";
                        break;
                    case "11":
                        s = "November";
                        break;
                    case "12":
                        s = "December";
                        break;
                }
            }
            else
            {
                switch (m)
                {
                    case "1":
                        s = "Jan";
                        break;
                    case "2":
                        s = "Feb";
                        break;
                    case "3":
                        s = "Mar";
                        break;
                    case "4":
                        s = "Apr";
                        break;
                    case "5":
                        s = "May";
                        break;
                    case "6":
                        s = "June";
                        break;
                    case "7":
                        s = "July";
                        break;
                    case "8":
                        s = "Aug";
                        break;
                    case "9":
                        s = "Sept";
                        break;
                    case "10":
                        s = "Oct";
                        break;
                    case "11":
                        s = "Nov";
                        break;
                    case "12":
                        s = "Dec";
                        break;
                }
            }
            return s;
        }
        private void GetGrid()
        {
            int type = 0;
            if (lookUpEdit类别.EditValue.ToString() == "1")
            {
                type = 1;
            }
            else
            {
                type = 2;
            }
            if (lookUpEdit开始月份.Text == "")
            {
                throw new Exception("请选择月份");
            }

            FileStream fileStream = new FileStream(Application.StartupPath + "/模板/外方科目TB表.xls", FileMode.Open, FileAccess.Read);
            book = new NPOI.HSSF.UserModel.HSSFWorkbook(fileStream);
            ISheet sheetIS = book.GetSheet("IS");
            ISheet sheetBS = book.GetSheet("BS");

            string mon=Month(lookUpEdit开始月份.EditValue.ToString().Trim(),1);
            ICell iscell = sheetIS.GetRow(3).GetCell(3);
            iscell.SetCellValue(mon +" "+ 系统服务.ClsBaseDataInfo.sUFDataBaseYear + " Income Statement Analysis");

            ICell bscell = sheetBS.GetRow(2).GetCell(3);
            bscell.SetCellValue(mon + " " + 系统服务.ClsBaseDataInfo.sUFDataBaseYear + " Balance Sheet Analysis");


            string mon2 = Month(lookUpEdit开始月份.EditValue.ToString().Trim(), 1);
            ICell iscell1 = sheetIS.GetRow(6).GetCell(3);
            iscell1.SetCellValue(mon2);

            ICell bscell1 = sheetBS.GetRow(5).GetCell(3);
            bscell1.SetCellValue(mon2);

            ISheet sheethyp = book.GetSheet("Hyp");
            DataTable dthyp = new DataTable();
            dthyp.Columns.Add("中方科目");
            dthyp.Columns.Add("外方科目");
            dthyp.Columns.Add("外方科目名称");
            dthyp.Columns.Add("余额方向");
            for (int i = 2; i < sheethyp.LastRowNum; i++)
            {
                NPOI.SS.UserModel.IRow rowhyp = sheethyp.GetRow(i);
                if (rowhyp.GetCell(0) != null)
                {
                    DataRow dw = dthyp.NewRow();
                    dw["中方科目"] = rowhyp.GetCell(0);
                    dw["外方科目"] = rowhyp.GetCell(2);
                    dw["外方科目名称"] = rowhyp.GetCell(3);
                    dw["余额方向"] = rowhyp.GetCell(5);
                    dthyp.Rows.Add(dw);
                }
                
            }

            ISheet sheetnc = book.GetSheet("年初调整");
            DataTable dtnc = new DataTable();
            dtnc.Columns.Add("中方科目");
            dtnc.Columns.Add("调整数字",typeof(decimal));

            for (int i = 1; i <= sheetnc.LastRowNum; i++)
            {
                NPOI.SS.UserModel.IRow rownc = sheetnc.GetRow(i);
                if (rownc.GetCell(0) != null)
                {
                    DataRow dw = dtnc.NewRow();
                    dw["中方科目"] = rownc.GetCell(0);
                    dw["调整数字"] = rownc.Cells[1].NumericCellValue;
                    dtnc.Rows.Add(dw);
                }
            }


            ISheet sheetlm = book.GetSheet("L-M Suzhou #220505");


            sSQL = @"exec dbo.GL_P_FSEYEB N'5555555555555555555555',N'5555555555555555555555',0,NULL,N'我',1,5,0,NULL,NULL,NULL,NULL,
N'case when cclass =N''资产'' then 1 else case when cclass =N''负债'' then 2 else case when cclass =N''权益'' then 3 else case when cclass =N''成本'' then 4 else 5 end  end  end  end  as lx',N'',NULL";
//            sSQL = @"
//declare @iPer1 as nvarchar(10)
//declare @iPer2 as nvarchar(10)
//set @iPer1=5555555555555555555555
//set @iPer2=5555555555555555555555
//
//select ccode into #a from dbo.code where igrade >= 1  and igrade <= 5 and cclass<>N'表外科目'
//
//select distinct #a.ccode into #b from dbo.code inner join #a on #a.ccode like (#a.ccode+'%') where bend=1
//
//SELECT 1 as flag,dbo.gl_accsum.ccode,
//Sum(case when cbegind_c=N'借' then mb end) AS 期初借方,
//Sum(case when cbegind_c=N'贷' then mb end) AS 期初贷方,
//Sum(md) AS 本期借方,
//Sum(mc) AS 本期贷方,
//Sum(case when cendd_c=N'借' then me end) AS 期末借方,
//Sum(case when cendd_c=N'贷' then me end) AS 期末贷方,bd_c as 余额方向 ,
//Sum(case when bd_c=0 then mc-md else md-mc end) as 本期,
//Sum(case when bd_c=0 and cendd_c=N'贷' then me when bd_c=1 and cendd_c=N'借' then me  else -me end) as 期末
//FROM dbo.GL_accsum 
//inner join dbo.code on dbo.gl_accsum.ccode=dbo.code.ccode inner join #b on dbo.GL_accsum.ccode=#b.ccode
//WHERE iperiod =@iper2 --and code.cclass<>N'表外科目' and code.bend=1
//GROUP BY dbo.gl_accsum.ccode ,bd_c
//";
            sSQL = sSQL.Replace("5555555555555555555555", lookUpEdit开始月份.EditValue.ToString());


            sSQL = sSQL.Replace("dbo.", "@u8.");
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            dt.Columns["sbb"].ColumnName = "期初借方";
            dt.Columns["sbb1"].ColumnName = "期初贷方";
            dt.Columns["smd"].ColumnName = "本期借方";
            dt.Columns["smc"].ColumnName = "本期贷方";
            dt.Columns["smm"].ColumnName = "期末借方";
            dt.Columns["smm1"].ColumnName = "期末贷方";
            dt.Columns["sld"].ColumnName = "年度累计金额";
            dt.Columns["slc"].ColumnName = "年度累计金额2";

            dt.Columns.Add("外方科目");
            dt.Columns.Add("外方科目1");
            dt.Columns.Add("外方科目名称");
            dt.Columns.Add("余额方向");
            dt.Columns.Add("本期", typeof(decimal));
            dt.Columns.Add("期末", typeof(decimal));
            dt.Columns.Add("本期2", typeof(decimal));
            dt.Columns.Add("期末2", typeof(decimal));
            dt.Columns.Add("调整数字", typeof(decimal));

            sSQL = "select * from dbo.code";

            sSQL = sSQL.Replace("dbo.", "@u8.");
            DataTable dtcode = clsSQLCommond.ExecQuery(sSQL);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] dw = dthyp.Select("中方科目='" + dt.Rows[i]["ccode"].ToString() + "'");
                if (dw.Length > 0)
                {
                    if (dw[0]["外方科目"].ToString().Split('/').Length == 1)
                    {
                        dt.Rows[i]["外方科目"] = dw[0]["外方科目"].ToString();
                        dt.Rows[i]["外方科目1"] = dw[0]["外方科目"].ToString();
                        dt.Rows[i]["外方科目名称"] = dw[0]["外方科目名称"].ToString();
                    }
                    else if (dw[0]["外方科目"].ToString().Split('/').Length == 2)
                    {
                        dt.Rows[i]["外方科目"] = dw[0]["外方科目"].ToString().Split('/')[0];
                        dt.Rows[i]["外方科目1"] = dw[0]["外方科目"].ToString().Split('/')[1];
                        dt.Rows[i]["外方科目名称"] = dw[0]["外方科目名称"].ToString();
                    }
                    dt.Rows[i]["余额方向"] = dw[0]["余额方向"].ToString();
                }
                dt.Rows[i]["本期"] = ReturnDecimal(dt.Rows[i]["本期借方"]) - ReturnDecimal(dt.Rows[i]["本期贷方"]);
                dt.Rows[i]["期末"] = ReturnDecimal(dt.Rows[i]["期末借方"]) - ReturnDecimal(dt.Rows[i]["期末贷方"]);
                DataRow[] dwnc = dtnc.Select("中方科目='" + dt.Rows[i]["ccode"].ToString() + "'");
                if (dwnc.Length > 0)
                {
                    dt.Rows[i]["期末"] = ReturnDecimal(dt.Rows[i]["期末"]) - ReturnDecimal(dwnc[0]["调整数字"]);
                    dt.Rows[i]["调整数字"] = ReturnDecimal(dwnc[0]["调整数字"]);
                }
                if (dt.Rows[i]["外方科目"].ToString().Trim() != "")
                {
                    string JD = dt.Rows[i]["外方科目"].ToString().Substring(0, 1);
                    if (JD == "1" || JD == "5" || JD == "6" || JD == "7" || JD == "8")
                    {
                        dt.Rows[i]["本期2"] = ReturnDecimal(dt.Rows[i]["本期"]);
                        dt.Rows[i]["期末2"] = ReturnDecimal(dt.Rows[i]["期末"]);
                    }
                    else
                    {
                        dt.Rows[i]["本期2"] = -ReturnDecimal(dt.Rows[i]["本期"]);
                        dt.Rows[i]["期末2"] = -ReturnDecimal(dt.Rows[i]["期末"]);
                    }
                }
                
            }

            for (int i = 5; i <= sheetIS.LastRowNum; i++)
            {
                try
                {
                    NPOI.SS.UserModel.IRow rowl = sheetIS.GetRow(i);
                    if (rowl.GetCell(1) != null)
                    {
                        string km = rowl.GetCell(1).StringCellValue;
                        double je = ReturnDouble(dt.Compute("sum(本期2)", "外方科目='" + km + "' or 外方科目1='" + km + "'"));
                        if (je != 0)
                        {
                            ICell ic1 = rowl.GetCell(3);
                            ic1.SetCellValue(je);
                        }
                        double lj = ReturnDouble(dt.Compute("sum(期末2)", "外方科目='" + km + "' or 外方科目1='" + km + "'"));
                        if (lj != 0)
                        {
                            ICell ic1 = rowl.GetCell(5);
                            ic1.SetCellValue(lj);
                        }
                    }
                }
                catch
                {
                }
            }

            for (int i = 5; i <= sheetBS.LastRowNum; i++)
            {
                try
                {
                    NPOI.SS.UserModel.IRow rowl = sheetBS.GetRow(i);
                    if (rowl.GetCell(1) != null)
                    {
                        string km = rowl.GetCell(1).StringCellValue;

                        double je = ReturnDouble(dt.Compute("sum(期末2)", "外方科目='" + km + "' or 外方科目1='" + km + "'"));
                        if (je != 0)
                        {
                            ICell ic1 = rowl.GetCell(3);
                            ic1.SetCellValue(je);
                        }
                    }
                }
                catch
                {
                }
            }
            for (int i = 0; i <= sheetlm.LastRowNum; i++)
            {
                try
                {
                    NPOI.SS.UserModel.IRow rowl = sheetlm.GetRow(i);

                    double je = ReturnDouble(dt.Compute("sum(期末)", "外方科目='" + rowl.GetCell(0).ToString() + "'"));
                    if (je != 0)
                    {
                        ICell ic0 = rowl.CreateCell(2);
                        ic0.SetCellValue(je);
                    }
                }
                catch
                {
                }
            }

            ISheet sheetlist = book.CreateSheet("明细");
            NPOI.SS.UserModel.IRow rowlmx = sheetlist.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell ic1 = rowlmx.CreateCell(i);
                ic1.SetCellValue(dt.Columns[i].ColumnName);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NPOI.SS.UserModel.IRow rowl = sheetlist.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell ic1 = rowl.CreateCell(j);
                    ic1.SetCellValue(dt.Rows[i][j].ToString());
                }
            }
            
            
            sheetIS.ForceFormulaRecalculation = true;
            sheetBS.ForceFormulaRecalculation = true;
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("外方科目");
            dtnew.Columns.Add("外方科目名称");
            dtnew.Columns.Add("金额");
            dtnew.Columns.Add("年度累计金额");
            if (type == 1)
            {
                for (int i = 9; i <= sheetIS.LastRowNum; i++)
                {
                    try
                    {
                        NPOI.SS.UserModel.IRow rowl = sheetIS.GetRow(i);
                        DataRow dw = dtnew.NewRow();
                        dw["外方科目"] = rowl.GetCell(1);
                        dw["外方科目名称"] = rowl.GetCell(2);
                        if (rowl.GetCell(3) != null)
                        {
                            dw["金额"] = getCellFormatValue(rowl.GetCell(3));
                        }
                        if (rowl.GetCell(5) != null)
                        {
                            dw["年度累计金额"] = getCellFormatValue(rowl.GetCell(5));
                        }
                        dtnew.Rows.Add(dw);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                for (int i = 9; i <= sheetBS.LastRowNum; i++)
                {
                    try
                    {
                        NPOI.SS.UserModel.IRow rowl = sheetBS.GetRow(i);
                        DataRow dw = dtnew.NewRow();
                        dw["外方科目"] = rowl.GetCell(1);
                        dw["外方科目名称"] = rowl.GetCell(2);
                        if (rowl.GetCell(3) != null)
                        {
                            dw["金额"] = getCellFormatValue(rowl.GetCell(3));
                        }
                        //if (rowl.GetCell(4) != null)
                        //{
                        //    dw["年度累计金额"] = rowl.GetCell(4).StringCellValue;
                        //}
                        dtnew.Rows.Add(dw);
                    }
                    catch
                    {
                    }
                }
            }

            gridControl1.DataSource = dtnew;
        }

        private String getCellFormatValue(ICell cell)
        {
            string s = "";
            switch (cell.CellType)
            {
                case CellType.BLANK: //空数据类型处理
                    s = "";
                    break;
                case CellType.STRING: //字符串类型
                    s = cell.StringCellValue;
                    break;
                case CellType.NUMERIC: //数字类型                  
                    s = cell.NumericCellValue.ToString();
                    break;
                case CellType.FORMULA:
                    HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(book);
                    s = e.EvaluateInCell(cell).ToString();
                    break;
                default:
                    s = "";
                    break;
            }
            return s;
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp._LoopUpData(lookUpEdit开始月份,"19");
            系统服务.LookUp._LoopUpData(lookUpEdit类别, "30");
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string type = gridView1.GetRowCellDisplayText(e.RowHandle, gridColType).ToString().Trim();
            if (type == "1")
            {

                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);

            }
        }

        private void lookUpEdit类别_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit类别.EditValue.ToString() == "2")
            {
                gridCol年度累计金额.Visible = false;
            }
            else
            {
                gridCol年度累计金额.Visible = true;
            }
        }

    }
}
