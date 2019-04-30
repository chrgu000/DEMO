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
    public partial class Frm排产明细 : FrameBaseFunction.FrmFromModel
    {
        DateTime Date1;
        DateTime Date2;
        
        public Frm排产明细()
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
                throw new Exception(ee.Message);
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
            try
            {
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("刷新窗体失败\n" + ee.Message);
            }
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
            GetGrid();
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

        private void Frm排产明细_Load(object sender, EventArgs e)
        {
            try
            {
                dateEdit1.EditValue = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                dateEdit2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                SetLookUpEdit();
                GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookUpEdit()
        {
            LookUp.mom_order(lookUpEdit生产订单1);
            LookUp.mom_order(lookUpEdit生产订单2);
            LookUp.Inventory(lookUpEdit存货编码);
            LookUp.Customer(lookUpEdit客户);
        }

        private void GetGrid()
        {
            string sErr = "";
            if (dateEdit1.EditValue == null && dateEdit2.EditValue == null)
            {
                throw new Exception("时间区域不可为空");
            }

            gridControl1.DataSource = Get();

            gridView1.Columns[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns[1].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns[2].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns[3].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns[4].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.Columns[0].Width = 100;
            gridView1.Columns[3].Width = 100;
            gridView1.OptionsBehavior.Editable = false;
            sState = "sel";
        }
       

        private DataTable Get()
        {
            string sd = dateEdit1.Text;
            string ed = dateEdit2.Text;

            for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
            {
                gridView1.Columns.Remove(gridView1.Columns[i]);
            }

                sSQL = @"select f.ID,d.cCusCode as 客户编码,c.MoCode 生产订单,b.InvCode as 物料编码,g.cInvName as 物料名称,f.批号范围 as 批号,max(h.件数) as 件数,
convert(varchar(10),e.DueDate,120) as 交货期,a.生产订单明细iID,b.SortSeq   from 生产工序日计划 a 
left join UFDATA_100_2014.dbo.mom_orderdetail b on a.生产订单明细iID=b.MoDId 
left join UFDATA_100_2014.dbo.mom_order c on b.MoId=c.MoId 
left join UFDATA_100_2014.dbo.SO_SOMain d on b.SoCode=d.cSOCode 
left join UFDATA_100_2014.dbo.mom_morder e on b.MoDId=e.MoDId 
left join  生产工序日计划Main f on a.ID=f.ID 
left join UFDATA_100_2014.dbo.Inventory g on b.InvCode=g.cInvCode 
left join 
(select ID,max(数量) as 件数 from 生产工序日计划 group by ID) h on h.ID=f.ID
where 1=1  and f.审核人 is not null 
group by f.ID,d.cCusCode,c.MoCode,b.InvCode,f.批号范围,e.DueDate,g.cInvName,a.生产订单明细iID,b.SortSeq ";
            if (lookUpEdit生产订单1.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and c.MoCode>='" + lookUpEdit生产订单1.Text.Trim() + "'");
            }
            if (lookUpEdit生产订单2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and c.MoCode<='" + lookUpEdit生产订单2.Text.Trim() + "'");
            }
            if (lookUpEdit存货编码.EditValue != null && lookUpEdit存货编码.EditValue.ToString() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.InvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit客户.EditValue != null && lookUpEdit客户.EditValue.ToString() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and d.cCusCode='" + lookUpEdit客户.EditValue.ToString().Trim() + "'");
            }
            if (dateEdit1.Text != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and f.单据日期>='" + dateEdit1.EditValue + "'");
            }
            if (dateEdit2.Text != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and f.单据日期<='" + dateEdit2.EditValue + "'");
            }
            if (chk关闭.Checked != true)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(b.CloseUser,'')=''");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            TH.DAL.sfc_optransform sfc = new TH.DAL.sfc_optransform();
            DataTable dts = sfc.Get工序转移();

            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("1");
            dtnew.Columns.Add("2");
            dtnew.Columns.Add("3");
            dtnew.Columns.Add("4");
            dtnew.Columns.Add("5");
            dtnew.Columns.Add("6");
            int icol = 6;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dw = dtnew.NewRow();
                dw[0] = "客户名称：";
                dw[1] = dt.Rows[i]["客户编码"].ToString();
                dw[2] = "生产订单：";
                dw[3] = dt.Rows[i]["生产订单"].ToString();
                dw[4] = dt.Rows[i]["SortSeq"].ToString();
                dtnew.Rows.Add(dw);

                DataRow dw1 = dtnew.NewRow();
                dw1[0] = "名称";
                dw1[1] = "图号";
                dw1[2] = "件数";
                dw1[3] = "零件编号";
                dw1[4] = "完工日期";
                dtnew.Rows.Add(dw1);

                DataRow dw2 = dtnew.NewRow();
                dw2[0] = dt.Rows[i]["物料名称"].ToString();
                dw2[1] = dt.Rows[i]["物料编码"].ToString();
                dw2[2] = double.Parse(dt.Rows[i]["件数"].ToString());
                dw2[3] = dt.Rows[i]["批号"].ToString();
                dw2[4] = dt.Rows[i]["交货期"].ToString();

                DataRow dw3 = dtnew.NewRow();
                dw3[0] = "安排加工天数";

                DataRow dw4 = dtnew.NewRow();
                dw4[0] = "计划完成日期";

                DataRow dw5 = dtnew.NewRow();
                dw5[0] = "完工日期";

                DataRow[] dwplan = dts.Select("MoDId='" + dt.Rows[i]["生产订单明细iID"].ToString() + "'", "OpSeq");
                for (int j = 0; j < dwplan.Length; j++)
                {
                    if (dtnew.Columns.Count < j + icol)
                    {
                        dtnew.Columns.Add((j + icol).ToString());
                    }
                    dw2[j + icol - 1] = dwplan[j]["Description"].ToString();
                    dw3[j + icol - 1] = dwplan[j]["计划生产天数"].ToString();
                    dw4[j + icol - 1] = dwplan[j]["计划生产完工日期"].ToString();
                    dw5[j + icol - 1] = dwplan[j]["完工日期"].ToString();
                }
                

                dtnew.Rows.Add(dw2);
                dtnew.Rows.Add(dw3);
                dtnew.Rows.Add(dw4);
                dtnew.Rows.Add(dw5);

                DataRow dw0 = dtnew.NewRow();
                dtnew.Rows.Add(dw0);
            }

            return dtnew;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
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


        private void buttonEdit存货编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmInvInfo frm = new FrmInvInfo(buttonEdit存货编码.Text.ToString(),false);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货编码.EditValue = frm.sInvCode;

                frm.Enabled = true;
            }
        }

        private void buttonEdit存货编码_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货编码.Text.Trim() != "")
            {
                lookUpEdit存货编码.EditValue = buttonEdit存货编码.Text.Trim();
            }
            else
            {
                lookUpEdit存货编码.EditValue = null;
            }
        }

        private void buttonEdit存货编码_Leave(object sender, EventArgs e)
        {
            if (buttonEdit存货编码.Text.Trim() == "")
                return;
            if (lookUpEdit存货编码.Text.Trim() == "")
            {
                buttonEdit存货编码.Text = "";
                buttonEdit存货编码.Focus();
            }
        }

        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmCustomer frm = new FrmCustomer(buttonEdit客户.Text.Trim(), false);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit客户.EditValue = frm.sCusCode;

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
                lookUpEdit客户.EditValue = null;
            }
        }

        private void buttonEdit客户_Enter(object sender, EventArgs e)
        {
            if (buttonEdit客户.Text.Trim() == "")
                return;
            if (lookUpEdit客户.Text.Trim() == "")
            {
                buttonEdit客户.Text = "";
                buttonEdit客户.Focus();
            }
        }

        //private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{
        //    //string str = gridView1.GetRowCellDisplayText(e.RowHandle, "").ToString().Trim();
        //    //if (str == "")
        //    //{
        //    //    e.Appearance.BackColor = Color.White;
        //    //}
        //}

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int iRow = e.RowHandle;

            if (e.CellValue != "" && iRow>0 && e.Column.VisibleIndex>5 && gridView1.GetRowCellValue(iRow - 1, e.Column).ToString() != "" && gridView1.GetRowCellValue(iRow,"1").ToString() == "完工日期")
            {
                DateTime d1= ReturnObjectToDatetime(e.CellValue);
                DateTime d2= ReturnObjectToDatetime(gridView1.GetRowCellValue(iRow - 1, e.Column).ToString());
                TimeSpan ts = d2.Subtract(d1);
                if(ts.TotalDays<0)
                {
                DevExpress.Utils.AppearanceDefault appRed = new DevExpress.Utils.AppearanceDefault
                     (Color.Black, Color.Red, Color.Empty, Color.SeaShell, System.Drawing.Drawing2D.LinearGradientMode.Horizontal);
                DevExpress.Utils.AppearanceHelper.Apply(e.Appearance, appRed);
                }
            }
        }
        

      

       
    }
}
