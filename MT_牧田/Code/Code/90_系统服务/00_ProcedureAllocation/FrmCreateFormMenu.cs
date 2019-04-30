using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Collections;

namespace 系统服务
{
    public partial class FrmCreateFormMenu : 系统服务.FrmBaseInfo
    {
        public FrmCreateFormMenu()
        {
            InitializeComponent();

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

            if (File.Exists(sLayoutHeadPath))
                layoutControl1.RestoreLayoutFromXml(sLayoutHeadPath);

            if (File.Exists(sLayoutGridPath))
            {
                gridControl1.MainView.RestoreLayoutFromXml(sLayoutGridPath);
            }
        }

        private void GetUpName()
        {
            string sSQL = "select fchrFrmNameID from dbo._Form where fchrfrmnameid not like 'frm%' order by fIntOrderID";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEditUpName.Properties.DataSource = dt;

        }
        private void FrmPersonInfo_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUpEnable();

                GetUpName();

                GetTree();

                GetBtnBaseInfo();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败！", "提示",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void GetLookUpEnable()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc); 
            dc = new DataColumn();
            dc.ColumnName = "iText";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["iID"] = 0;
            dr["iText"] = "不限";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = 1;
            dr["iText"] = "是";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = 2;
            dr["iText"] = "否";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = 3;
            dr["iText"] = "是不限";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = 4;
            dr["iText"] = "否不限";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = 5;
            dr["iText"] = "完全不限";
            dt.Rows.Add(dr);
            LookUpEditEnable.DataSource = dt;
        }

        #region 按钮基本信息

        DataTable dtBtn;
        private void GetBtnBaseInfo()
        {
            string sSQL = "select '' as bChoose,*,'' as FormText,'' as FormOrder,'' as FormEnable from _BtnBaseInfo order by iOrder";
            dtBtn = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBtn.Copy();
        }

        #endregion

        #region 创建功能树

        DataTable dtTree;
        private void GetTree()
        {
            treView.Nodes.Clear();
            string sSQL;
            if (系统服务.ClsBaseDataInfo.sUid == "admin" || 系统服务.ClsBaseDataInfo.sUid == "system")
            {
                sSQL = "select * from _Form ORDER BY fIntOrderID";
            }
            else
            {
                sSQL = "select * from _Form  WHERE (fbitHide = 0) AND (fbitNoUse = 0)ORDER BY fIntOrderID";
            }
            dtTree = clsSQLCommond.ExecQuery(sSQL);
            InitTree(treView.Nodes, "0");
        }

        /// <summary>
        /// 创建功能树
        /// </summary>
        /// <param name="Nds"></param>
        /// <param name="parentId"></param>
        private void InitTree(TreeNodeCollection Nds, string parentId)
        {
            try
            {
                DataView dv = new DataView();
                TreeNode tmpNd;
                string intId;
                dv.Table = dtTree;
                dv.RowFilter = "fchrFrmUpName='" + parentId + "'";
                foreach (DataRowView drv in dv)
                {
                    tmpNd = new TreeNode();
                    tmpNd.Name = drv["fchrFrmNameID"].ToString().Trim();
                    tmpNd.Text = drv["fchrFrmText"].ToString().Trim();
                    tmpNd.Tag = drv["fchrFrmNameID"].ToString().Trim();
                    Nds.Add(tmpNd);
                    intId = drv["fchrFrmUpName"].ToString().Trim();
                    InitTree(tmpNd.Nodes, tmpNd.Name);
                }
            }
            catch
            {
                throw new Exception("创建功能树失败！");
            }
        }
        #endregion

        #region 按钮操作
        protected override void BtnClick(string sBtnName, string sBtnText)
        {
            try
            {
                switch (sBtnName.ToLower())
                {
                    case "add":
                        btnAdd();
                        break;
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
                    //case "print":
                    //    btnPrint();
                    //    break;
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
                MessageBox.Show(sBtnText + " 失败! \n\n原因:\n  " + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #region 按钮模板

        //PurchaseModule.Report.RepHeadDetail Rep = new Report.RepHeadDetail();
        ///// <summary>
        ///// 打印设置
        ///// </summary>
        //private void btnPrintSet()
        //{
        //    DataTable dt1 = new DataTable();
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "th1";
        //    dt1.Columns.Add(dc);
        //    dc = new DataColumn();
        //    dc.ColumnName = "th2";
        //    dt1.Columns.Add(dc);
        //    Rep.dataSet1.Tables.Add(dt1);

        //    if (!Directory.Exists(base.sProPath + "\\print"))
        //        Directory.CreateDirectory(base.sProPath + "\\print");

        //    if (File.Exists(sPrintLayOut))
        //    {
        //        Rep.LoadLayout(sPrintLayOut);
        //    }
        //    Rep.ShowDesignerDialog();

        //    if (DialogResult.Yes == MessageBox.Show("是否保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
        //    {
        //        Rep.SaveLayoutToXml(sPrintLayOut);
        //    }
        //}

        ///// <summary>
        ///// 打印
        ///// </summary>
        //private void btnPrint()
        //{
        //    DataRow dr = Rep.dataSet1.Tables["table1"].NewRow();
        //    dr[0] = "1";
        //    dr[1] = "2";
        //    Rep.dataSet1.Tables["table1"].Rows.Add(dr);

        //    if (File.Exists(sPrintLayOut))
        //    {
        //        Rep.LoadLayout(sPrintLayOut);
        //    }
        //    Rep.ShowPreview();
        //}
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
            FrmPersonInfo_Load(null, null);
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
            DialogResult d = MessageBox.Show("确定删除窗体'" + txtFormCode.Text.Trim() + "'  '" + txtFormName.Text.Trim() + "' 及所属窗体按钮?\n是：删除\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d == System.Windows.Forms.DialogResult.Yes)
            {
                ArrayList aList = new ArrayList();
                string sSQL;

                if (txtFormCode.Text.Trim().ToLower().StartsWith("frm"))
                {
                    sSQL = "delete dbo._FormBtnInfo where fchrFrmNameID = '" + txtFormCode.Text.Trim() + "'";
                    aList.Add(sSQL);
                }
                sSQL = "delete _Form where fchrFrmNameID = '" + txtFormCode.Text.Trim() + "' ";
                aList.Add(sSQL);

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);

                    //treView.Nodes.RemoveByKey(txtFormCode.Text.Trim());

                    MessageBox.Show("删除窗体" + txtFormCode.Text.Trim() + " " + txtFormName.Text.Trim() + "成功\n合计执行语句:" + iCou + "条");
                }
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            ArrayList aList = new ArrayList();
            string sSQL;

            int iHide = 0; if (chkbHide.Checked) iHide = 1;
            int iNoUse = 0; if (chkbNoUse.Checked) iNoUse = 1;
            int iSystem = 0; if (chkbSystem.Checked) iSystem = 1;
            int iUse = 0; if (chkbUse.Checked) iUse = 1;

            sSQL = "if exists(select * from dbo._Form where fchrFrmNameID = '" + txtFormCode.Text.Trim() + "' and fchrFrmText = '" + txtFormName.Text.Trim() + "') " +
                        " update _Form set  fchrFrmText = '" + txtFormName.Text.Trim() + "', fchrNameSpace = '" + txtNameSpace.Text.Trim() + "', fchrFrmUpName = '" + lookUpEditUpName.Text.Trim() + "', " +
                                "fbitHide = " + iHide + ", fbitNoUse = " + iNoUse + ", fIntOrderID = " + txtOrder.Text.Trim() + ", " +
                                "bSystem = " + iSystem + ", bUse = " + iUse + " " +
                        " where fchrFrmNameID = '" + txtFormCode.Text.Trim() + "' and fchrFrmText = '" + txtFormName.Text.Trim() + "'; " +
                   "else " +
                   " insert into _Form( fchrFrmNameID, fchrFrmText, fchrNameSpace, fchrFrmUpName, fbitHide, fbitNoUse, fIntOrderID,  bSystem, bUse) values " +
                                      "('" + txtFormCode.Text.Trim() + "','" + txtFormName.Text.Trim() + "','" + txtNameSpace.Text.Trim() + "','" + lookUpEditUpName.Text.Trim() + "', " +
                                      "" + iHide + "," + iNoUse + "," + txtOrder.Text.Trim() + ", " + iSystem + "," + iUse + ")";
            aList.Add(sSQL);

            if (txtFormCode.Text.Trim().ToLower().StartsWith("frm"))
            {
                sSQL = "select * from _FormBtnInfo where 1=-1";
                DataTable dtBtn = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "delete _FormBtnInfo where fchrFrmNameID = '" + txtFormCode.Text.Trim() + "' ";
                aList.Add(sSQL);

                try
                {
                    gridView1.FocusedRowHandle -= 1;
                    gridView1.FocusedRowHandle += 1;
                }
                catch { }

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColbChoose).ToString().Trim() == "√")
                    {
                        DataRow dr = dtBtn.NewRow();
                        dr["fchrFrmNameID"] = txtFormCode.Text.Trim();
                        dr["vchrBtnID"] = gridView1.GetRowCellValue(i, gridColBtnCode).ToString().Trim();
                        dr["vchrBtnText"] = gridView1.GetRowCellValue(i, gridColFormText).ToString().Trim();
                        dr["intOrder"] = gridView1.GetRowCellValue(i, gridColFormOrder).ToString().Trim();
                        dr["bEnable"] = gridView1.GetRowCellValue(i, gridColFormEnable).ToString().Trim();
                        dtBtn.Rows.Add(dr);
                    }
                }
                for(int i=0;i<dtBtn.Rows.Count;i++)
                {
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "_FormBtnInfo", dtBtn, i);
                    aList.Add(sSQL);
                }
            }
            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存窗体" + txtFormCode.Text.Trim() + " " + txtFormName.Text.Trim() + "成功\n合计执行语句:" + iCou + "条");
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

        private void treView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                gridControl1.DataSource = dtBtn.Copy();

                string sSQL = "select * from _Form where fchrFrmNameID = '" + e.Node.Name.Trim() + "' ORDER BY fIntOrderID";
                DataTable dtFormNew = clsSQLCommond.ExecQuery(sSQL);
                if (e.Node.Name.Trim() != null)
                {
                    txtFormCode.Text = dtFormNew.Rows[0]["fchrFrmNameID"].ToString().Trim();
                    txtFormName.Text = dtFormNew.Rows[0]["fchrFrmText"].ToString().Trim();
                    txtNameSpace.Text = dtFormNew.Rows[0]["fchrNameSpace"].ToString().Trim();
                    lookUpEditUpName.EditValue = dtFormNew.Rows[0]["fchrFrmUpName"].ToString().Trim();
                    txtOrder.Text = dtFormNew.Rows[0]["fIntOrderID"].ToString().Trim();

                    chkbHide.Checked = Convert.ToBoolean(dtFormNew.Rows[0]["fbitHide"]);
                    chkbNoUse.Checked = Convert.ToBoolean(dtFormNew.Rows[0]["fbitNoUse"]);
                    chkbSystem.Checked = Convert.ToBoolean(dtFormNew.Rows[0]["bSystem"]);
                    chkbUse.Checked = Convert.ToBoolean(dtFormNew.Rows[0]["bUse"]);
                }

                if (dtFormNew.Rows[0]["fchrFrmNameID"].ToString().Trim().ToLower().StartsWith("frm"))
                {
                    sSQL = "select *,vchrBtnText as FormText,intOrder as FormOrder from dbo._FormBtnInfo where fchrFrmNameID = '" + txtFormCode.Text + "'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < gridView1.RowCount; j++)
                        {
                            if (dt.Rows[i]["vchrBtnID"].ToString().Trim().ToLower() == gridView1.GetRowCellValue(j, gridColBtnCode).ToString().Trim().ToLower())
                            {
                                gridView1.SetRowCellValue(j, gridColbChoose, "√");
                                gridView1.SetRowCellValue(j, gridColFormText, dt.Rows[i]["vchrBtnText"].ToString().Trim());
                                gridView1.SetRowCellValue(j, gridColFormOrder, dt.Rows[i]["intOrder"].ToString().Trim());
                                gridView1.SetRowCellValue(j, gridColFormEnable, dt.Rows[i]["bEnable"].ToString().Trim());
                                break;
                            }
                        }
                    }
                }
                txtFormCode.Focus();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtFormCode.Text.ToLower().Trim().StartsWith("frm"))
                {
                    int iRow = gridView1.FocusedRowHandle;
                    if (gridView1.GetRowCellValue(iRow, gridColbChoose).ToString().Trim() == "√")
                    {
                        gridView1.SetRowCellValue(iRow, gridColFormText, "");
                        gridView1.SetRowCellValue(iRow, gridColFormOrder, "");
                        gridView1.SetRowCellValue(iRow, gridColbChoose, "");
                        gridView1.SetRowCellValue(iRow, gridColFormEnable, DBNull.Value);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridColFormText, gridView1.GetRowCellValue(iRow, gridColbtnName).ToString().Trim());
                        gridView1.SetRowCellValue(iRow, gridColFormOrder, gridView1.GetRowCellValue(iRow, gridColiOrder).ToString().Trim());
                        gridView1.SetRowCellValue(iRow, gridColFormEnable, gridView1.GetRowCellValue(iRow, gridColbEnable).ToString().Trim());
                        gridView1.SetRowCellValue(iRow, gridColbChoose, "√");
                    }
                }
            }
            catch (Exception ee)
            { }
        }

        private void txtFormCode_EditValueChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = dtBtn.Copy();
        }

        //private void SetReadOnly(bool b)
        //{
        //    txtFormCode.Properties.ReadOnly = b;
        //    lookUpEditUpName.Properties.ReadOnly = b;
        //    txtFormName.Properties.ReadOnly = b;
        //    txtNameSpace.Properties.ReadOnly = b;
        //    txtOrder.Properties.ReadOnly = b;
        //    chkbHide.Properties.ReadOnly = b;
        //    chkbNoUse.Properties.ReadOnly = b;
        //    chkbSystem.Properties.ReadOnly = b;
        //    chkbUse.Properties.ReadOnly = b;
        //}
    }
}
