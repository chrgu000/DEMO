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
    public partial class Frm出入库流水账 : 系统服务.FrmBaseInfo
    {
        DateTime Date1;
        DateTime Date2;
        
        public Frm出入库流水账()
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

        private void Frm出入库流水账_Load(object sender, EventArgs e)
        {
            try
            {
                GetLayOut(layoutControl1, gridControl1);

                SetLookUpEdit();
                //GetGrid();
            }
            catch (Exception ee)
            {
                throw new Exception("加载窗体失败\n" + ee.Message);
            }
        }

        private void SetLookUpEdit()
        {
            系统服务.LookUp.InventoryClass(ItemLookUpEdit存货分类);
            系统服务.LookUp.InventoryClass(lookUpEdit存货分类);
            系统服务.LookUp.Inventory(ItemLookUpEdit存货名称);
            系统服务.LookUp.Inventory(lookUpEdit存货编码);
            系统服务.LookUp.RdStyle(ItemLookUpEdit出入库类别);
            系统服务.LookUp.MOStyle(ItemLookUpEdit委外类别);
            系统服务.LookUp.ColorNo(lookUpEditM1);
            系统服务.LookUp.PO_PODetails(ItemLookUpEdit采购订单);

            系统服务.LookUp.Warehouse(ItemLookUpEdit仓库);
            系统服务.LookUp.Position(ItemLookUpEdit货位);
            系统服务.LookUp.Customer(ItemLookUpEdit客户);
        }

        private void GetGrid()
        {
            //Get红字销售出库单();
            string sd=dateEdit1.Text;
            string ed = dateEdit2.Text;


            sSQL = @"
select a.Flag,a.ID,b.AutoID,b.RdAutoID,b.MOsID,b.MOAutoID,b.POAutoID,a.cWhCode,b.cPosCode,a.cCusCode,a.cRdCode,convert(varchar(10),dDate,120) as dDate,a.cRSCode,cMSCode,b.cInvCode,b.M1,b.M2,b.BoxNo,b.sBoxNo,iQuantity,iMoney,sBoxQty,dVerifysysPerson,dClosesysPerson  into #rd 
from RdRecord01 a inner join RdRecords01 b on a.ID=b.ID 
where  dVerifysysPerson is not null and 4=4 

insert into #rd select a.Flag,a.ID,b.AutoID,b.RdAutoID,b.MOsID,b.MOAutoID,b.POAutoID,a.cWhCode,b.cPosCode,a.cCusCode,a.cRdCode,convert(varchar(10),dDate,120) as dDate,a.cRSCode,cMSCode,b.cInvCode,b.M1,b.M2,b.BoxNo,b.sBoxNo,iQuantity,iMoney,sBoxQty,dVerifysysPerson,dClosesysPerson from RdRecord02 a inner join RdRecords02 b on a.ID=b.ID 
where  dVerifysysPerson is not null and 4=4 

insert into #rd select a.Flag,a.ID,b.AutoID,b.RdAutoID,b.MOsID,b.MOAutoID,b.POAutoID,a.cWhCode,b.cPosCode,a.cCusCode,a.cRdCode,convert(varchar(10),dDate,120) as dDate,a.cRSCode,cMSCode,b.cInvCode,b.M1,b.M2,b.BoxNo,b.sBoxNo,iQuantity,iMoney,sBoxQty,dVerifysysPerson,dClosesysPerson from RdRecord03 a inner join RdRecords03 b on a.ID=b.ID 
where  dVerifysysPerson is not null and 4=4 

insert into #rd select a.Flag,a.ID,b.AutoID,b.RdAutoID,b.MOsID,b.MOAutoID,b.POAutoID,a.cWhCode,b.cPosCode,a.cCusCode,a.cRdCode,convert(varchar(10),dDate,120) as dDate,a.cRSCode,cMSCode,b.cInvCode,b.M1,b.M2,b.BoxNo,b.sBoxNo,iQuantity,iMoney,sBoxQty,dVerifysysPerson,dClosesysPerson from RdRecord05 a inner join RdRecords05 b on a.ID=b.ID 
where  dVerifysysPerson is not null and 4=4 

insert into #rd select a.Flag,a.ID,b.AutoID,b.RdAutoID,b.MOsID,b.MOAutoID,b.POAutoID,a.cWhCode,b.cPosCode,a.cCusCode,a.cRdCode,convert(varchar(10),dDate,120) as dDate,a.cRSCode,cMSCode,b.cInvCode,b.M1,b.M2,b.BoxNo,b.sBoxNo,iQuantity,iMoney,sBoxQty,dVerifysysPerson,dClosesysPerson from RdRecord11 a inner join RdRecords11 b on a.ID=b.ID 
where  dVerifysysPerson is not null and 4=4 

insert into #rd select a.Flag,a.ID,b.AutoID,b.RdAutoID,b.MOsID,b.MOAutoID,b.POAutoID,a.cWhCode,b.cPosCode,a.cCusCode,a.cRdCode,convert(varchar(10),dDate,120) as dDate,a.cRSCode,cMSCode,b.cInvCode,b.M1,b.M2,b.BoxNo,b.sBoxNo,iQuantity,iMoney,sBoxQty,dVerifysysPerson,dClosesysPerson from RdRecord12 a inner join RdRecords12 b on a.ID=b.ID 
where  dVerifysysPerson is not null and 4=4 

insert into #rd select a.Flag,a.ID,b.AutoID,b.RdAutoID,null as MOsID,null as MOAutoID,null as POAutoID,a.cWhCode,b.cPosCode,a.cCusCode,a.cRdCode,convert(varchar(10),dDate,120) as dDate,a.cRSCode,null as cMSCode,b.cInvCode,b.M1,b.M2,b.BoxNo,b.sBoxNo,iQuantity,iMoney,sBoxQty,dVerifysysPerson,dClosesysPerson from RdRecord13 a inner join RdRecords13 b on a.ID=b.ID 
where  dVerifysysPerson is not null and 4=4 

insert into #rd select a.Flag,a.ID,b.AutoID,b.RdAutoID,b.MOsID,b.MOAutoID,b.POAutoID,a.cWhCode,b.cPosCode,a.cCusCode,a.cRdCode,convert(varchar(10),dDate,120) as dDate,a.cRSCode,cMSCode,b.cInvCode,b.M1,b.M2,b.BoxNo,b.sBoxNo,iQuantity,iMoney,sBoxQty,dVerifysysPerson,dClosesysPerson from RdRecord15 a inner join RdRecords15 b on a.ID=b.ID 
where  dVerifysysPerson is not null and 4=4 

select case when r.收发标志=0 then '入库' else '出库' end 收发标志,case when a.Flag=1 then '蓝字' else '红字' end Flag,a.ID,a.AutoID,a.RdAutoID,a.cRdCode,convert(varchar(10),dDate,120) as dDate,a.cRSCode,cMSCode,cInvClassCode,a.cInvCode,a.M1,a.M2,a.BoxNo,a.sBoxNo,
case when r.收发标志=0 and Flag=1 then convert(decimal(18, 2),a.iQuantity) when r.收发标志=1 and Flag=2 then convert(decimal(18, 2),-a.iQuantity) end inQty,
case when r.收发标志=0 and Flag=1 then convert(decimal(18, 2),a.sBoxQty) when r.收发标志=1 and Flag=2 then convert(decimal(18, 2),-a.sBoxQty) end insBoxQty,
case when r.收发标志=0 and Flag=1 then a.cWhCode when r.收发标志=1 and Flag=2 then a.cWhCode end incWhCode,
case when r.收发标志=0 and Flag=1 then a.cPosCode when r.收发标志=1 and Flag=2 then a.cPosCode end incPosCode,

case when r.收发标志=1 and Flag=1 then convert(decimal(18, 2),a.iQuantity) when r.收发标志=0 and Flag=2 then convert(decimal(18, 2),-a.iQuantity) end outQty,
case when r.收发标志=1 and Flag=1 then convert(decimal(18, 2),a.sBoxQty) when r.收发标志=0 and Flag=2 then convert(decimal(18, 2),-a.sBoxQty) end outsBoxQty,
case when r.收发标志=1 and Flag=1 then a.cWhCode when r.收发标志=0 and Flag=2 then a.cWhCode end outcWhCode,
case when r.收发标志=1 and Flag=1 then a.cPosCode when r.收发标志=0 and Flag=2 then a.cPosCode end outcPosCode,


dVerifysysPerson,dClosesysPerson ,a.cCusCode
from #rd a left join Inventory i on a.cInvCode=i.cInvCode 
left join RdStyle r on a.cRSCode=r.cRSCode
where 1=1 and 2=2


";

            if (sd != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),dDate,120)>='" + DateTime.Parse(sd).ToString("yyyy-MM-dd") + "'");
                //sSQL = sSQL.Replace("4=4", "4=4 and convert(varchar(10),dDate,120)>='" + DateTime.Parse(sd).ToString("yyyy-MM-dd") + "'");
            }
            if (ed != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and convert(varchar(10),dDate,120)<='" + DateTime.Parse(ed).ToString("yyyy-MM-dd") + "'");
                //sSQL = sSQL.Replace("4=4", "4=4 and convert(varchar(10),dDate,120)<='" + DateTime.Parse(ed).ToString("yyyy-MM-dd") + "'");
            }

            if (lookUpEdit存货编码.EditValue != null && lookUpEdit存货编码.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
                sSQL = sSQL.Replace("4=4", "4=4 and b.cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit存货分类.EditValue != null && lookUpEdit存货分类.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvClassCode='" + lookUpEdit存货分类.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEditM1.EditValue != null && lookUpEditM1.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.M1='" + lookUpEditM1.EditValue.ToString().Trim() + "'");
                sSQL = sSQL.Replace("4=4", "4=4 and b.M1='" + lookUpEditM1.EditValue.ToString().Trim() + "'");
            }
            if (textEditM2.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.M2 like '%" + textEditM2.EditValue.ToString().Trim() + "%'");
                sSQL = sSQL.Replace("4=4", "4=4 and b.M2 like '%" + textEditM2.EditValue.ToString().Trim() + "%'");
            }
            if (textEdit盒号.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.sBoxNo like '%" + textEdit盒号.EditValue.ToString().Trim() + "%'");
                sSQL = sSQL.Replace("4=4", "4=4 and b.sBoxNo like '%" + textEdit盒号.EditValue.ToString().Trim() + "%'");
            }
            if (textEdit单据号.Text.Trim() != "")
            {
                sSQL = sSQL.Replace("2=2", "2=2 and a.cRdCode like '%" + textEdit单据号.EditValue.ToString().Trim() + "%'");
                sSQL = sSQL.Replace("3=3", "3=3 and a.cRDCode like '%" + textEdit单据号.EditValue.ToString().Trim() + "%'");
                sSQL = sSQL.Replace("4=4", "4=4 and a.cRDCode like '%" + textEdit单据号.EditValue.ToString().Trim() + "%'");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dt;

            GetShow(false);
        }

        private void GetShow(bool b)
        {
            gridView1.OptionsBehavior.Editable = false;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                if (iRow < 0)
                    return;

                long sID = Convert.ToInt64(gridView1.GetRowCellValue(iRow, gridColID));
                if (sID == -1)
                    return;

                string type = gridView1.GetRowCellValue(iRow, gridColcRSCode).ToString();
                string typename = gridView1.GetRowCellDisplayText(iRow, gridColcRSCode).ToString();
                string cMSCode = gridView1.GetRowCellDisplayText(iRow, gridColcMSCode).ToString();
                if (type == "01")
                {
                    仓库.Frm采购入库单 frm = new 仓库.Frm采购入库单(sID);
                    frm.Tag = frm.Name;
                    frm.MdiParent = this.MdiParent;

                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                else if (type == "02")
                {
                    仓库.Frm其他入库单 frm = new 仓库.Frm其他入库单(sID, typename);
                    frm.Tag = frm.Name;
                    frm.MdiParent = this.MdiParent;

                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                else if (type == "03")
                {
                    if (cMSCode == "成团")
                    {
                        仓库.Frm成团委外入库单 frm = new 仓库.Frm成团委外入库单(sID,"成团");
                        frm.Tag = frm.Name;
                        frm.MdiParent = this.MdiParent;
                        frm.Text = cMSCode + "委外入库单";
                        frm.Show();
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            frm.Enabled = true;
                        }
                    }
                    else
                    {
                        //仓库.Frm委外入库单 frm = new 仓库.Frm委外入库单(sID);
                        //frm.Tag = frm.Name;
                        //frm.MdiParent = this.MdiParent;
                        //frm.Text = cMSCode + "委外入库单";
                        //frm.Show();
                        //if (DialogResult.OK == frm.ShowDialog())
                        //{
                        //    frm.Enabled = true;
                        //}
                    }
                }
                else if (type == "11")
                {
                    仓库.Frm销售出库单 frm = new 仓库.Frm销售出库单(sID,"销售出库单");
                    frm.Tag = frm.Name;
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                else if (type == "13")
                {
                    仓库.Frm委外材料出库单 frm = new 仓库.Frm委外材料出库单(sID);
                    frm.Tag = frm.Name;
                    frm.MdiParent = this.MdiParent;
                    frm.Text = cMSCode + "委外材料出库单";
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                else if (type == "12")
                {
                    仓库.Frm销售出库单2 frm = new 仓库.Frm销售出库单2(sID);
                    frm.Tag = frm.Name;
                    frm.MdiParent = this.MdiParent;
                    frm.Text = "期初出库单";
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
                else if (type == "04")
                {
                    仓库.Frm其他入库单 frm = new 仓库.Frm其他入库单(sID);
                    frm.Tag = frm.Name;
                    frm.MdiParent = this.MdiParent;
                    frm.Text = "期初成品入库单";
                    frm.Show();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        frm.Enabled = true;
                    }
                }
            }
            catch (Exception ee)
            {
            }
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

        private void buttonEdit存货分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(7);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货分类.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEdit存货分类_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货分类.Text.Trim() != "")
                lookUpEdit存货分类.EditValue = buttonEdit存货分类.Text.Trim();
            else
                lookUpEdit存货分类.EditValue = null;
        }

        private void buttonEdit存货分类_Leave(object sender, EventArgs e)
        {
            if (buttonEdit存货分类.Text.Trim() == "")
                return;
            if (lookUpEdit存货分类.Text.Trim() == "")
            {
                buttonEdit存货分类.Text = "";
                buttonEdit存货分类.Focus();
            }
        }

        private void buttonEdit存货编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(1);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货编码.EditValue = frm.sID;

                frm.Enabled = true;
            }
        }

        private void buttonEdit存货编码_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货编码.Text.Trim() != "")
                lookUpEdit存货编码.EditValue = buttonEdit存货编码.Text.Trim();
            else
                lookUpEdit存货编码.EditValue = null;
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

        private void buttonEditM1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.Frm参照 frm = new 系统服务.Frm参照(24);
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEditM1.EditValue = frm.sID;
                frm.Enabled = true;
            }
        }

        private void buttonEditM1_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEditM1.Text.Trim() != "")
            {
                lookUpEditM1.EditValue = buttonEditM1.Text.Trim();
            }
            else
            {
                lookUpEditM1.EditValue = null;
            }
        }

        private void buttonEditM1_Leave(object sender, EventArgs e)
        {
            if (buttonEditM1.Text.Trim() == "")
                return;
            if (lookUpEditM1.Text.Trim() == "")
            {
                buttonEditM1.Text = "";
                buttonEditM1.Focus();
            }
        }

        private void bandedGridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //string 标识 = bandedGridView1.GetRowCellDisplayText(e.RowHandle, gridColFlag).ToString().Trim();
            //if (标识 == "红字")
            //{
            //    e.Appearance.BackColor = Color.Tomato;
            //}
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        //private void Get红字销售出库单()
        //{
        //    sSQL = "SELECT   sBoxNo from RdRecords13  WHERE (sBoxQty < 0) group by sBoxNo";
        //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        sSQL = "SELECT   *  from RdRecords13  WHERE (sBoxQty < 0) and sBoxNo='" + dt.Rows[i]["sBoxNo"].ToString() + "'";
        //        DataTable dts = clsSQLCommond.ExecQuery(sSQL);
        //        for (int j = 0; j < dts.Rows.Count; j++)
        //        {
        //            sSQL = "SELECT   * from RdRecords13  WHERE (sBoxQty > 0) and sBoxNo='" + dt.Rows[i]["sBoxNo"].ToString() + "' and  AutoID<'" + dts.Rows[j]["AutoID"].ToString() + "' order by AutoID desc";
        //            DataTable dtss = clsSQLCommond.ExecQuery(sSQL);
        //            if (dtss.Rows.Count > 0)
        //            {
        //                sSQL = "update RdRecords13 set  SOOutAutoID='" + dtss.Rows[0]["AutoID"].ToString() + "' where AutoID='" + dts.Rows[j]["AutoID"].ToString() + "'";
        //                clsSQLCommond.ExecSql(sSQL);
        //            }
        //            else
        //            {
        //                sSQL = "update RdRecords13 set  SOOutAutoID=null where AutoID='" + dts.Rows[j]["AutoID"].ToString() + "'";
        //                clsSQLCommond.ExecSql(sSQL);
        //            }
        //        }
        //    }
        //}
    }
}
