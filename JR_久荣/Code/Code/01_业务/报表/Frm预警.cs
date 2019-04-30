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


namespace 业务
{
    public partial class Frm预警 : 系统服务.FrmBaseInfo
    {
        string Type = "";
        public Frm预警()
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

        private void Frm预警_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime d = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                for (int i = 0; i < 30; i++)
                {
                    GetCol(d.AddDays(i).ToString("MM-dd"), i.ToString());
                }
                //for (DateTime d = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")); d <= DateTime.Parse(DateTime.Now.AddDays(29).ToString("yyyy-MM-dd")); d = d.AddDays(1))
                //{
                //    GetCol(d.ToString("MM-dd"), i.ToString());
                //    i = i + 1;
                //}
                chk1_EditValueChanged(null, null);
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            string sSQL1 = "";
            string sSQL2 = "";
            int s = 0;
            if (chk1.Checked == true)
            {
                s = 7;
            }
            else
            {
                s = 30;
            }
            DateTime d = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            for (int i = 0; i < s; i++)
            {
                if (sSQL2 != "")
                {
                    sSQL2 = sSQL2 + "+";
                }

                if (i == 0)
                {
                    sSQL1 = sSQL1 + ",isnull(convert(int,sum(case when a.iSheDate<='" + d.AddDays(i).ToString("yyyy-MM-dd") + "' then (isnull(a.iQty,0) - isnull(bb.iQtyRD,0)) end)),0) as [" + i + "]";

                    sSQL2 = sSQL2 + "isnull(convert(int,sum(case when a.iSheDate<='" + d.AddDays(i).ToString("yyyy-MM-dd") + "' then (isnull(a.iQty,0) - isnull(bb.iQtyRD,0)) end)),0)";
                }
                else
                {
                    sSQL1 = sSQL1 + ",isnull(convert(int,sum(case when a.iSheDate='" + d.AddDays(i).ToString("yyyy-MM-dd") + "' then (isnull(a.iQty,0) - isnull(bb.iQtyRD,0)) end)),0) as [" + i + "]";

                    sSQL2 = sSQL2 + "isnull(convert(int,sum(case when a.iSheDate='" + d.AddDays(i).ToString("yyyy-MM-dd") + "' then (isnull(a.iQty,0) - isnull(bb.iQtyRD,0)) end)),0)";
                }
            }
            string sSQL = @"
select a.VenCode,i.cInvName,a.InvCode,convert(int,NowQty) NowQty
        1111111111111111111,2222222222222222222,3333333333333333333
from Registers a left join ShipmentPlans b on a.ID=b.rID 
    left join @u8.Inventory i on a.InvCode=i.cInvCode
    left join (select cInvCode,SUM(iQuantity) NowQty from @u8.CurrentStock group by cInvCode) cs on a.InvCode=cs.cInvCode
	left join (
		select ship.rID, sum(iQuantity) as iQtyRD 
		from ShipmentPlans ship inner join @u8.rdrecords rds on ship.AutoID = rds.cDefine34
		where isnull(cDefine34,-1) <> -1 
		group by ship.rID
	) bb on a.ID = bb.rID
where  isnull(a.iQty,0) - isnull(bb.iQtyRD,0) <> 0  and 1=1
group by a.VenCode,i.cInvName,a.InvCode,NowQty
order by a.VenCode,a.InvCode
";
            sSQL = sSQL.Replace("1111111111111111111", sSQL1);
            sSQL = sSQL.Replace("2222222222222222222", sSQL2+" as iSumQty");
            sSQL = sSQL.Replace("3333333333333333333", "convert(int,NowQty)-(" + sSQL2 + ") as iLeftQty");
            if (lookUpEdit供应商.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.VenCode like '%" + lookUpEdit供应商.EditValue.ToString().Trim() + "%' ");
            }
            if (lookUpEdit品番.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.InvCode like '%" + lookUpEdit品番.EditValue.ToString().Trim() + "%' ");
            }
            sSQL = sSQL.Replace("@u8.", 系统服务.ClsBaseDataInfo.sUFDataBaseName + ".dbo.");

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dt;

            gridView1.BestFitColumns();
        }

        private void GetCol(string ColText, string FieldName)
        {
            DevExpress.XtraGrid.Columns.GridColumn Col = new DevExpress.XtraGrid.Columns.GridColumn();
            Col.FieldName = FieldName;
            Col.Name = "gridColDay_" + FieldName;
            Col.Caption = ColText;
            Col.OptionsColumn.AllowEdit = false;
            Col.Width = 70;
            Col.Visible = true;
            Col.VisibleIndex = gridView1.Columns.Count - 1;
            Col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Col.SummaryItem.FieldName = FieldName;
            gridView1.Columns.Add(Col);

            gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, FieldName, Col);
        }


        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.Vendor(lookUpEdit供应商);
            系统服务.LookUp.Inventory(lookUpEdit品番);
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

        private void chk1_EditValueChanged(object sender, EventArgs e)
        {
            if (chk1.Checked == true && chk2.Checked == true)
            {
                chk2.Checked = false;
            }
            if (chk1.Checked == true)
            {
                for (int i = 7; i < 30; i++)
                {
                    for (int j = 0; j < gridView1.Columns.Count; j++)
                    {
                        if (gridView1.Columns[j].Name == "gridColDay_" + i)
                        {
                            DevExpress.XtraGrid.Columns.GridColumn Col = gridView1.Columns[j];
                            Col.Visible = false;
                        }
                    }
                }
                gridCol出库展望合计.VisibleIndex = gridView1.Columns.Count ;
                gridCol可用量结余.VisibleIndex = gridView1.Columns.Count;
                GetGrid();
            }
        }

        private void chk2_EditValueChanged(object sender, EventArgs e)
        {
            if (chk1.Checked == true && chk2.Checked == true)
            {
                chk1.Checked = false;
            }
            if (chk2.Checked == true)
            {
                for (int i = 7; i < 30; i++)
                {
                    for (int j = 0; j < gridView1.Columns.Count; j++)
                    {
                        if (gridView1.Columns[j].Name == "gridColDay_" + i)
                        {
                            DevExpress.XtraGrid.Columns.GridColumn Col = gridView1.Columns[j];
                            Col.Visible = true;
                            Col.VisibleIndex = gridView1.Columns.Count;
                        }
                    }
                }
                gridCol出库展望合计.VisibleIndex = gridView1.Columns.Count;
                gridCol可用量结余.VisibleIndex = gridView1.Columns.Count;
                GetGrid();
            }
        }

        
    }
}
