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

namespace 报表
{
    public partial class Frm损耗表 : 系统服务.FrmBaseInfo
    {
        DataTable dtmo成团;
        DataTable dtin成团;
        DataTable dtout成团;
        DataTable dtmo;
        DataTable dtin;
        DataTable dtout;
        DataTable dtsub;
        public Frm损耗表()
        {
            InitializeComponent();

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

        private void Frm损耗表_Load(object sender, EventArgs e)
        {
            try
            {
                GetLayOut(layoutControl1, gridControl1);
                SetLookUpEdit();
                dateEdit1.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                dateEdit2.EditValue = DateTime.Now.ToString("yyyy-MM-dd");

                GetGrid();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            dtmo成团 = new DataTable();
            dtin成团 = new DataTable();
            dtout成团 = new DataTable();
            dtmo = new DataTable();
            dtin = new DataTable();
            dtout = new DataTable();
            dtsub = new DataTable();

            sSQL = @"select a.ID,b.AutoID,a.cMOCode 委外订单号,MOStyle.cMSName as 委外类别,Vendor.cVenName as 委外供应商名称,Inventory.cInvName as 存货名称,b.M1 as 色号,b.M2 as 缸号,b.iQuantity as 委外订单重量 from MO_MOMain a left join MO_MODetails b on a.ID=b.ID 
left join MOStyle on a.cMSCode=MOStyle.cMSCode
left join Vendor on a.cVenCode=vendor.cVenCode
left join Inventory on b.cInvCode=Inventory.cInvCode
where a.cMSCode='0004' ";

            if (dateEdit1.EditValue != null && dateEdit1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and convert(varchar(10),a.dDate,120)>='" + dateEdit1.DateTime.ToString("yyyy-MM-dd") + "'";
            }
            if (dateEdit2.EditValue != null && dateEdit2.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and convert(varchar(10),a.dDate,120)<='" + dateEdit2.DateTime.ToString("yyyy-MM-dd") + "'";
            }

            if (lookUpEdit供应商.EditValue != null && lookUpEdit供应商.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.cVenCode='" + lookUpEdit供应商.EditValue.ToString().Trim() + "'";
            }
            if (textEdit缸号.Text.Trim() != "")
            {
                sSQL = sSQL + " and a.cPersonCode='" + textEdit缸号.Text.Trim() + "'";
            }
            if (lookUpEdit色号.EditValue != null && lookUpEdit色号.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and b.M1='" + lookUpEdit色号.EditValue.ToString().Trim() + "'";
            }
            dtmo成团= clsSQLCommond.ExecQuery(sSQL);

            sSQL=@"select a.ID,b.AutoID,b.MOAutoID,b.iQuantity,b.D1 from RdRecord a left join RdRecords b on a.ID=b.ID where a.cRSCode='03' and a.cMSCode='0004'";
            dtin成团= clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"select a.ID,b.AutoID,b.iQuantity,b.MOsID,b.MOAutoID,b.D1 from RdRecord a left join RdRecords b on a.ID=b.ID where a.cRSCode='13' and a.cMSCode='0004'";
            dtout成团= clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"select a.ID,b.AutoID,a.cVenCode,a.cPersonCode,a.cPersonCode,b.iQuantity from MO_MOMain a left join MO_MODetails b on a.ID=b.ID where cMSCode<>'0004'  ";
            dtmo= clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"select a.ID,b.AutoID,b.MOAutoID,b.iQuantity,b.D1 from RdRecord a left join RdRecords b on a.ID=b.ID where a.cRSCode='03' and a.cMSCode<>'0004'";
            dtin= clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"select a.ID,b.AutoID,b.iQuantity,b.MOsID,b.MOAutoID,b.D1 from RdRecord a left join RdRecords b on a.ID=b.ID where a.cRSCode='13' and a.cMSCode<>'0004'";
            dtout= clsSQLCommond.ExecQuery(sSQL);

            sSQL = "select a.ID,b.AutoID,b.RdAutoID,c.MOAutoID,b.iQuantity from RdRecord a left join RdRecords b on a.ID=b.ID left join RdRecords c on b.RdAutoID=c.AutoID where c.MOAutoID is not null ";
            dtsub = clsSQLCommond.ExecQuery(sSQL);

            dtmo成团.Columns.Add("成团入库重量");
            dtmo成团.Columns.Add("成团入库绞数");
            dtmo成团.Columns.Add("成团出库重量");
            dtmo成团.Columns.Add("成团出库绞数");
            dtmo成团.Columns.Add("成团损耗重量");
            dtmo成团.Columns.Add("成团损耗重量比率");
            dtmo成团.Columns.Add("成团损耗绞数");
            dtmo成团.Columns.Add("成团损耗绞数比率");

            dtmo成团.Columns.Add("绞纱入库重量");
            dtmo成团.Columns.Add("绞纱入库绞数");
            dtmo成团.Columns.Add("绞纱出库重量");
            dtmo成团.Columns.Add("绞纱出库绞数");
            dtmo成团.Columns.Add("绞纱损耗重量");
            dtmo成团.Columns.Add("绞纱损耗重量比率");
            dtmo成团.Columns.Add("绞纱损耗绞数");
            dtmo成团.Columns.Add("绞纱损耗绞数比率");

            for (int i = 0; i < dtmo成团.Rows.Count; i++)
            {
                decimal inQty;
                decimal inD1;
                Get成团In(dtmo成团.Rows[i]["AutoID"].ToString(), out inQty, out inD1);
                dtmo成团.Rows[i]["成团入库重量"] = inQty;
                dtmo成团.Rows[i]["成团入库绞数"] = inD1;

                decimal outQty;
                decimal outD1;
                Get成团Out(dtmo成团.Rows[i]["AutoID"].ToString(), out outQty, out outD1);
                dtmo成团.Rows[i]["成团出库重量"] = outQty;
                dtmo成团.Rows[i]["成团出库绞数"] = outD1;

                dtmo成团.Rows[i]["成团损耗重量"] = inQty - outQty;
                if (outQty != 0)
                {
                    dtmo成团.Rows[i]["成团损耗重量比率"] = 1 - ((inQty - outQty) / outQty);
                }
                dtmo成团.Rows[i]["成团损耗绞数"] = inD1 - outD1;
                if (outD1 != 0)
                {
                    dtmo成团.Rows[i]["成团损耗重量比率"] = 1 - ((inD1 - outD1) / outD1);
                }

                decimal sInQty;
                decimal sInD1;
                decimal sOutQty;
                decimal sOutD1;
                Get绞纱(dtmo成团.Rows[i]["AutoID"].ToString(), out sInQty, out sInD1, out sOutQty, out sOutD1);
                dtmo成团.Rows[i]["绞纱入库重量"] = sInQty;
                dtmo成团.Rows[i]["绞纱入库绞数"] = sInD1;
                dtmo成团.Rows[i]["绞纱出库重量"] = sOutQty;
                dtmo成团.Rows[i]["绞纱出库绞数"] = sOutD1;

                dtmo成团.Rows[i]["绞纱损耗重量"] = sInQty - sOutQty;
                if (sOutQty != 0)
                {
                    dtmo成团.Rows[i]["成团损耗重量比率"] = 1 - ((sInQty - sOutQty) / sOutQty);
                }
                dtmo成团.Rows[i]["绞纱损耗绞数"] = sInD1 - sOutD1;
                if (outQty != 0)
                {
                    dtmo成团.Rows[i]["成团损耗重量比率"] = 1 - ((inQty - outQty) / outQty);
                }
            }
            

            dtmo成团.Columns.Remove(dtmo成团.Columns["ID"]);
            dtmo成团.Columns.Remove(dtmo成团.Columns["AutoID"]);
            gridControl1.DataSource = dtmo成团;
            GetShow(false);
        }

        private void GetShow(bool b)
        {
            gridView1.OptionsBehavior.Editable = false;
        }

        private void Get成团In(string MOAutoID, out decimal iQty, out decimal D1)
        {
            iQty = ReturnDecimal(dtin成团.Compute("sum(iQuantity)", "MOAutoID=" + MOAutoID));
            D1 = ReturnDecimal(dtin成团.Compute("sum(D1)", "MOAutoID=" + MOAutoID));
        }

        private void Get成团Out(string MOAutoID, out decimal iQty, out decimal D1)
        {
            iQty = ReturnDecimal(dtout成团.Compute("sum(iQuantity)", "MOAutoID=" + MOAutoID));
            D1 = ReturnDecimal(dtout成团.Compute("sum(D1)", "MOAutoID=" + MOAutoID));
        }

        private void Get绞纱(string MOAutoID, out decimal inQty, out decimal inD1,out decimal outQty,out decimal outD1)
        {
            inQty = 0;
            inD1 = 0;
            outQty = 0;
            outD1 = 0;
            DataRow[] dw = dtout成团.Select("MOAutoID=" + MOAutoID);
            for (int i = 0; i < dw.Length; i++)
            {
                string RdOutAutoID = dw[i]["AutoID"].ToString();//成团材料出库单号

                DataRow[] dwin = dtsub.Select("AutoID=" + RdOutAutoID);//成团的材料出库单来源的委外订单子表ID
                for (int s = 0; s < dwin.Length; s++)
                {
                    string sMOAutoID = dwin[s]["MOAutoID"].ToString();

                    decimal tempInQty;
                    decimal tempInD1;
                    Get绞纱In(sMOAutoID, out tempInQty, out tempInD1);
                    inQty = inQty + tempInQty;
                    inD1 = inD1 + tempInD1;

                    decimal tempOutQty;
                    decimal tempOutD1;
                    Get绞纱Out(sMOAutoID, out tempOutQty, out tempOutD1);
                    outQty = outQty + tempOutQty;
                    outD1 = outD1 + tempOutD1;
                }
            }
        }

        private void Get绞纱In(string MOAutoID, out decimal iQty, out decimal D1)
        {
            iQty =ReturnDecimal(dtin.Compute("sum(iQuantity)", "MOAutoID=" + MOAutoID));
            D1 =ReturnDecimal(dtin.Compute("sum(D1)", "MOAutoID=" + MOAutoID));
        }

        private void Get绞纱Out(string MOAutoID, out decimal iQty, out decimal D1)
        {
            iQty =ReturnDecimal(dtout.Compute("sum(iQuantity)", "MOAutoID=" + MOAutoID));
            D1 = ReturnDecimal(dtout.Compute("sum(D1)", "MOAutoID=" + MOAutoID));
        }

        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.Inventory(ItemLookUpEdit产品);
            系统服务.LookUp.ShippingChoice(ItemLookUpEdit送货方式);

            系统服务.LookUp.Person(ItemLookUpEdit业务员);
            系统服务.LookUp.Customer(ItemLookUpEdit客户);
            系统服务.LookUp.Department(ItemLookUpEdit部门);

            系统服务.LookUp.Vendor(lookUpEdit供应商);
            系统服务.LookUp.ColorNo(lookUpEdit色号);
            
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
        }


        private void buttonEdit客户_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(9);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit供应商.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }


        private void buttonEdit客户_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() != "")
            {
                lookUpEdit供应商.EditValue = buttonEdit供应商.Text.Trim();
                
            }
            else
            {
                buttonEdit供应商.EditValue = null;
                lookUpEdit供应商.EditValue = null;
            }
        }

        private void buttonEdit客户_Leave(object sender, EventArgs e)
        {
            if (buttonEdit供应商.Text.Trim() == "")
                return;
            if (lookUpEdit供应商.Text.Trim() == "")
            {
                buttonEdit供应商.Text = "";
                buttonEdit供应商.Focus();
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

        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit色号.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit色号.Text.Trim() != "")
                lookUpEdit色号.EditValue = buttonEdit色号.Text.Trim();
            else
                lookUpEdit色号.EditValue = null;
        }

        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            if (buttonEdit色号.Text.Trim() == "")
                return;
            if (lookUpEdit色号.Text.Trim() == "")
            {
                buttonEdit色号.Text = "";
                buttonEdit色号.Focus();
            }
        }

    }
}
