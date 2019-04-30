using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace 报表
{
    public partial class Frm订单部周报 : 系统服务.FrmBaseInfo
    {
        DateTime Date1;
        DateTime Date2;
        
        public Frm订单部周报()
        {

            InitializeComponent();

            #region 禁止用户调整表格
            //bandedGridView1.OptionsMenu.EnableColumnMenu = false;
            //bandedGridView1.OptionsMenu.EnableFooterMenu = false;
            //bandedGridView1.OptionsMenu.EnableGroupPanelMenu = false;
            //bandedGridView1.OptionsMenu.ShowAutoFilterRowItem = false;
            //bandedGridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            //bandedGridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
            //bandedGridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
            //bandedGridView1.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            //bandedGridView1.OptionsBehavior.FocusLeaveOnTab = true;
            //bandedGridView1.OptionsCustomization.AllowColumnMoving = false;
            //bandedGridView1.OptionsCustomization.

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
                bandedGridView1.FocusedRowHandle -= 1;
                bandedGridView1.FocusedRowHandle += 1;
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
                    bandedGridView1.ExportToXls(sF.FileName);
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

                bandedGridView1.OptionsMenu.EnableColumnMenu = true;
                bandedGridView1.OptionsMenu.EnableFooterMenu = true;
                bandedGridView1.OptionsMenu.EnableGroupPanelMenu = true;
                //bandedGridView1.OptionsMenu.ShowAddNewSummaryItem = true;
                bandedGridView1.OptionsMenu.ShowAutoFilterRowItem = true;
                bandedGridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
                bandedGridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
                bandedGridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
                bandedGridView1.OptionsCustomization.AllowColumnMoving = true;
            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;
                bandedGridView1.OptionsMenu.EnableColumnMenu = false;
                bandedGridView1.OptionsMenu.EnableFooterMenu = false;
                bandedGridView1.OptionsMenu.EnableGroupPanelMenu = false;
                //bandedGridView1.OptionsMenu.ShowAddNewSummaryItem = false;
                bandedGridView1.OptionsMenu.ShowAutoFilterRowItem = false;
                bandedGridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
                bandedGridView1.OptionsMenu.ShowGroupSortSummaryItems = false;
                bandedGridView1.OptionsMenu.ShowGroupSummaryEditorItem = false;
                bandedGridView1.OptionsCustomization.AllowColumnMoving = false;


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

        private void Frm订单部周报_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                lookUpEdit年.EditValue = DateTime.Now.Year.ToString();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.Person(lookUpEdit业务员);
            系统服务.LookUp.Department(lookUpEdit部门);
            系统服务.LookUp._LoopUpData(lookUpEdit月, "19");
            系统服务.LookUp._LoopUpData(lookUpEdit周, "20");
            系统服务.LookUp.Department(ItemLookUpEditDeptID);
            系统服务.LookUp.Year(lookUpEdit年);

        }

        private void GetGrid()
        {
            string sErr = "";
            if (lookUpEdit月.Enabled && lookUpEdit月.Text.Trim() == "")
            {
                sErr = sErr + "计划类型月份不能为空\n";
            }
            if (lookUpEdit周.Enabled && lookUpEdit周.Text.Trim() == "")
            {
                sErr = sErr + "计划类型周不能为空\n";
            }
            
            gridControl1.DataSource = null;
            if (sErr == "")
            {
                gridControl1.DataSource = Get();

                sState = "sel";
            }
        }

        private DataTable Get()
        {

            string sDate = "";
            string eDate = "";

            string sDatew = "";
            string eDatew = "";

            sSQL = "select * from SAPlan where I1=2 and I2='" + lookUpEdit月.EditValue.ToString().Trim() + "' and s5 = '" + lookUpEdit年.EditValue.ToString().Trim() + "' order by S1,S3";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            if (dts.Rows.Count > 0)
            {
                sDate = dts.Rows[0]["Date1"].ToString();
                eDate = dts.Rows[0]["Date2"].ToString();
            }
            else
            {
                //throw new Exception("无月计划");
            }

            sSQL = "select * from SAPlan where I1=3 and I2='" + lookUpEdit月.EditValue.ToString().Trim() + "' and I3='" + lookUpEdit周.EditValue.ToString().Trim() + "' and s5 = '" + lookUpEdit年.EditValue.ToString().Trim() + "'  order by S1,S3";
            DataTable dtss = clsSQLCommond.ExecQuery(sSQL);
            if (dtss.Rows.Count > 0)
            {
                sDatew = dtss.Rows[0]["Date1"].ToString();
                eDatew = dtss.Rows[0]["Date2"].ToString();
            }
            else
            {
                //throw new Exception("无周计划");
            }

            sSQL = @"
select PersonCode,PersonName as 名称,a.S1 as DeptID
        ,cast(null as decimal(16,6))  as 计划出货,cast(null as decimal(16,6))  as 	实际出货,cast(null as decimal(16,6))  as 	销售额
        ,cast(null as decimal(16,6))  as 计划收款,cast(null as decimal(16,6))  as 	实际收款,cast(null as decimal(16,6))  as 	本月计划出货量,cast(null as decimal(16,6))  as 	出货量
        ,cast(null as decimal(16,6))  as 本月计划收款,cast(null as decimal(16,6))  as 	本月销售额,cast(null as decimal(16,6))  as 收款	,cast(null as decimal(16,6))  as 应收款	,cast(null as decimal(16,6))  as 出货	
        ,cast(null as decimal(16,6))  as 变更出货量,cast(null as decimal(16,6))  as 本月变更出货量,cast(null as decimal(16,6))  as 收款 ,'' as 情况沟通
from SAPlan a left join Person b on a.S3=b.PersonCode 
where a.I1=3 and a.I2='" + lookUpEdit月.EditValue.ToString().Trim() + "' and a.I3='" + lookUpEdit周.EditValue.ToString().Trim() + "' and a.s5 = '" + lookUpEdit年.EditValue.ToString().Trim() + "'  ";

            
            if (lookUpEdit部门.EditValue != null && lookUpEdit部门.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and a.S1='" + lookUpEdit部门.EditValue.ToString().Trim() + "'";
            }
            if (lookUpEdit业务员.EditValue != null && lookUpEdit业务员.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL + " and b.PersonCode = '" + lookUpEdit业务员.EditValue.ToString().Trim() + "'";
            }
            sSQL = sSQL + " order by a.S1,b.PersonName";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            

            DataTable dt周计划 = 计划.周计划出货(lookUpEdit年.EditValue.ToString().Trim(), lookUpEdit月.EditValue.ToString().Trim(), lookUpEdit周.EditValue.ToString().Trim());

            DataTable dt月计划 = 计划.月计划出货(lookUpEdit年.EditValue.ToString().Trim(), lookUpEdit月.EditValue.ToString().Trim());

            DataTable dt出货 = 出货.Table(sDatew, eDatew);

            DataTable dt出货all = 出货.Table(sDate, eDatew);

            DataTable dt销售 = 销售.Table(sDatew, eDatew);

            DataTable dt销售all = 销售.Table(sDate, eDatew);

            DataTable dt收款 = 收款.Table(sDatew, eDatew);

            DataTable dt收款all = 收款.Table(sDate, eDatew);

            DataTable dt应收款 = 应收款.Table(eDatew, "", "");

            DataTable dt出货变更 = 出货.Table出货变更(sDatew, eDatew);

            DataTable dt出货变更all = 出货.Table出货变更(sDate, eDatew);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                    dt.Rows[i]["计划出货"] = dt周计划.Compute("sum(D2)", "S3='" + dt.Rows[i]["PersonCode"].ToString() + "'");
                    dt.Rows[i]["本月计划出货量"] = dt月计划.Compute("sum(D2)", "S3='" + dt.Rows[i]["PersonCode"].ToString() + "'");

                    dt.Rows[i]["计划收款"] = ReturnDecimal(dt周计划.Compute("sum(D1)", "S3='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2);
                    dt.Rows[i]["本月计划收款"] = ReturnDecimal(dt月计划.Compute("sum(D1)", "S3='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2);

                    dt.Rows[i]["实际出货"] = dt出货.Compute("sum(iQuantity)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'  and Flag='1'");

                    dt.Rows[i]["出货量"] = dt出货all.Compute("sum(iQuantity)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'  and Flag='1'");
                    //dt.Rows[i]["出货量"] = dt出货all.Compute("sum(iQuantity)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "' ");

                    dt.Rows[i]["销售额"] = ReturnDecimal(dt销售.Compute("sum(iMoney)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2) + ReturnDecimal(dt出货变更.Compute("sum(iMoney)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2);
                    dt.Rows[i]["本月销售额"] = ReturnDecimal(dt销售all.Compute("sum(iMoney)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2) + ReturnDecimal(dt出货变更all.Compute("sum(iMoney)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2);

                    dt.Rows[i]["实际收款"] = ReturnDecimal(dt收款.Compute("sum(iAmount)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2);

                    dt.Rows[i]["收款"] = ReturnDecimal(dt收款all.Compute("sum(iAmount)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2);

                    dt.Rows[i]["应收款"] = ReturnDecimal(dt应收款.Compute("sum(iMoney)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2);

                    dt.Rows[i]["变更出货量"] = ReturnDecimal(dt出货变更.Compute("sum(iQuantity)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2);
                    dt.Rows[i]["本月变更出货量"] = ReturnDecimal(dt出货变更all.Compute("sum(iQuantity)", "cPersonCode='" + dt.Rows[i]["PersonCode"].ToString() + "'"), 2);
            }

            return dt;
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

        private void lookUpEdit月_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }


        private void buttonEdit部门_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                系统服务.Frm参照 frm = new 系统服务.Frm参照(3);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit部门.EditValue = frm.sID;
                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit部门_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit部门.Text.Trim() != "")
                    lookUpEdit部门.EditValue = buttonEdit部门.Text.Trim();
                else
                    lookUpEdit部门.EditValue = null;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit部门_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit部门.Text.Trim() == "")
                    return;
                if (lookUpEdit部门.Text.Trim() == "")
                {
                    buttonEdit部门.Text = "";
                    buttonEdit部门.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit业务员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                系统服务.Frm参照 frm = new 系统服务.Frm参照(2);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    buttonEdit业务员.EditValue = frm.sID;

                    frm.Enabled = true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit业务员_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit业务员.Text.Trim() != "")
                {
                    lookUpEdit业务员.EditValue = buttonEdit业务员.Text.Trim();
                    if (lookUpEdit业务员.Text.Trim() != "")
                    {
                        DataTable dt = 系统服务.LookUp.PersonDepartment(buttonEdit业务员.Text.Trim());
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            buttonEdit部门.EditValue = dt.Rows[0]["cDepCode"];
                        }
                    }
                }
                else
                {
                    lookUpEdit业务员.EditValue = null;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void buttonEdit业务员_Leave(object sender, EventArgs e)
        {
            try
            {
                if (buttonEdit业务员.Text.Trim() == "")
                    return;
                if (lookUpEdit业务员.Text.Trim() == "")
                {
                    buttonEdit业务员.Text = "";
                    buttonEdit业务员.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lookUpEdit年_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetGrid();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

    }
}
