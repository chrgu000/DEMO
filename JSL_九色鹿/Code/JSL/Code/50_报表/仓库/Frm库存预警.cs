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
    public partial class Frm库存预警 : 系统服务.FrmBaseInfo
    {
        DateTime Date1;
        DateTime Date2;
        string tablename = "Need";
        string tableid = "cInvCode";
        public Frm库存预警()
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
            try
            {
                gridView1.FocusedColumn = gridCol存货编码;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            sSQL = "select * from Need where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            string sErr = "";
            sSQL = "select isnull(max(iID)+1,1) as iID from Need";
            long iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            aList = new System.Collections.ArrayList();
            int scount = 0;
            sSQL = "select * from Need";
            DataTable dts = clsSQLCommond.ExecQuery(sSQL);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                #region 判断
                if (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "add" && gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() != "update")
                {
                    continue;
                }

                #endregion

                string sWhere = "";
                if (gridView1.GetRowCellValue(i, gridColM1).ToString().Trim() == "")
                {
                    sWhere = "cInvCode='" + gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim() + "'";
                }
                else
                {
                    sWhere = "cInvCode='" + gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim() + "' and M1='" + gridView1.GetRowCellValue(i, gridColM1).ToString().Trim() + "'";
                }
                DataRow[] dw = dts.Select(sWhere);
                
                scount = scount + 1;
                #region 生成table
                DataRow dr = dt.NewRow();
                if(dw.Length>0)
                {
                    dr["dVerifysysTime"] = GetSystemTime();
                    dr["dVerifysysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
                    dr["iID"] =dw[0]["iID"];
                }
                else
                {
                    dr["dCreatesysTime"] = GetSystemTime();
                    dr["dCreatesysPerson"] = 系统服务.ClsBaseDataInfo.sUid;
                    dr["iID"] = iID;
                    iID = iID + 1;
                }
                dr["cInvCode"] = gridView1.GetRowCellValue(i, gridCol存货编码).ToString().Trim();
                dr["M1"] = gridView1.GetRowCellValue(i, gridColM1).ToString().Trim();
                if (gridView1.GetRowCellValue(i, gridCol需求日期) != null && gridView1.GetRowCellValue(i, gridCol需求日期).ToString().Trim() != "")
                {
                    dr["NeedDate"] = gridView1.GetRowCellValue(i, gridCol需求日期).ToString().Trim();
                }
                
                if (gridView1.GetRowCellValue(i, gridCol需求数量).ToString().Trim() != "")
                {
                    dr["NeedQty"] = gridView1.GetRowCellValue(i, gridCol需求数量).ToString().Trim();
                }
                if (gridView1.GetRowCellValue(i, gridCol需求盒数).ToString().Trim() != "")
                {
                    dr["NeedBoxQty"] = gridView1.GetRowCellValue(i, gridCol需求盒数).ToString().Trim();
                }
                dt.Rows.Add(dr);
                #endregion

                if (dw.Length == 0)
                {
                    sSQL = clsGetSQL.GetInsertSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "Need", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }
                if (gridView1.GetRowCellDisplayText(i, gridColiSave).Trim() == "update")
                {
                    sSQL = clsGetSQL.GetUpdateSQL(系统服务.ClsBaseDataInfo.sDataBaseName, "Need", dt, dt.Rows.Count - 1);
                    aList.Add(sSQL);
                }

            }

            if (sErr.Trim().Length > 0)
            {
                throw new Exception(sErr);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("保存成功！\n合计执行语句:" + scount + "条");
                GetGrid();
            }
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

        private void Frm库存预警_Load(object sender, EventArgs e)
        {
            try
            {
                
                GetLayOut(layoutControl1, gridControl1);
                if (this.Text.IndexOf("半成品") >= 0)
                {
                    gridCol需求盒数.Visible = false;
                    gridCol现存盒数.Visible = false;
                    gridCol最低库存盒数.Visible = false;
                    gridCol最高库存盒数.Visible = false;
                }
                else if (this.Text.IndexOf("成品") >= 0)
                {
                    gridCol需求数量.Visible = false;
                    gridCol现存数量.Visible = false;
                    gridCol最低库存数量.Visible = false;
                    gridCol最高库存数量.Visible = false;
                }
                else if (this.Text.IndexOf("原料") >= 0)
                {
                    gridCol需求盒数.Visible = false;
                    gridCol现存盒数.Visible = false;
                    gridCol最低库存盒数.Visible = false;
                    gridCol最高库存盒数.Visible = false;
                    layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
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
            系统服务.LookUp.Inventory(lookUpEdit存货编码);
            系统服务.LookUp.InventoryClass(lookUpEdit存货分类);
            系统服务.LookUp.InventoryClass(ItemLookUpEdit存货分类);
            系统服务.LookUp.Inventory(ItemLookUpEdit存货名称);
            系统服务.LookUp.ColorNo(lookUpEditM1);
        }

        private void GetGrid()
        {
            string sErr = "";
            gridControl1.DataSource = Get();


            //gridView1.OptionsBehavior.Editable = false;
            sState = "sel";
        }

        private void GetShow(bool b)
        {
            gridView1.OptionsBehavior.Editable = false;
        }
       

        private DataTable Get()
        {
            sSQL = @"select b.cInvCode,b.M1,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty 
into #a from RdRecord01 a inner join RdRecords01 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode where 1=1 and a.dVerifysysPerson is not null group by b.cInvCode,b.M1

insert into #a
select b.cInvCode,b.M1,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty 
from RdRecord02 a inner join RdRecords02 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode where 1=1 and a.dVerifysysPerson is not null group by b.cInvCode,b.M1

insert into #a 
select b.cInvCode,b.M1,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty 
from RdRecord03 a inner join RdRecords03 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode where 1=1 and a.dVerifysysPerson is not null group by b.cInvCode,b.M1

insert into #a
select b.cInvCode,b.M1,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty 
from RdRecord05 a inner join RdRecords05 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode where 1=1 and a.dVerifysysPerson is not null group by b.cInvCode,b.M1

insert into #a
select b.cInvCode,b.M1,sum(-iQuantity) as iQuantity,sum(-sBoxQty) as sBoxQty 
from RdRecord11 a inner join RdRecords11 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode where 1=1 and a.dVerifysysPerson is not null group by b.cInvCode,b.M1

insert into #a
select b.cInvCode,b.M1,sum(-iQuantity) as iQuantity,sum(-sBoxQty) as sBoxQty 
from RdRecord12 a inner join RdRecords12 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode where 1=1 and a.dVerifysysPerson is not null group by b.cInvCode,b.M1

insert into #a
select b.cInvCode,b.M1,sum(-iQuantity) as iQuantity,sum(-sBoxQty) as sBoxQty 
from RdRecord13 a inner join RdRecords13 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode where 1=1 and a.dVerifysysPerson is not null group by b.cInvCode,b.M1

insert into #a
select b.cInvCode,b.M1,sum(-iQuantity) as iQuantity,sum(-sBoxQty) as sBoxQty 
from RdRecord15 a inner join RdRecords15 b on a.ID=b.ID left join Inventory i on b.cInvCode=i.cInvCode where 1=1 and a.dVerifysysPerson is not null group by b.cInvCode,b.M1

select cInvCode,M1,sum(iQuantity) as iQuantity,sum(sBoxQty) as sBoxQty into #b from #a a group by cInvCode,M1


";
            if (this.Text.IndexOf("半成品") >= 0 || this.Text.IndexOf("原料") >= 0)
            {
                sSQL = sSQL + @"
select cInvCode,cInvName,cInvStd,cGroupCode,cInvClassCode,convert(nvarchar(4000),M1) as M1 into #q from Inventory i where 3=3

SELECT distinct a.cInvCode,a.cInvName,a.cInvStd,a.cGroupCode,a.cInvClassCode,b.M1 into #w
FROM (SELECT cInvCode,cInvName,cInvStd,cGroupCode,cInvClassCode,M1=CAST('<v>'+REPLACE(M1,',','</v><v>')+'</v>' AS xml) FROM #q) a
OUTER APPLY (SELECT M1=T.C.value('.','varchar(50)') FROM a.M1.nodes('/v') AS T(C)) b where (ISNULL(b.M1, '') <> '') 

select a.cInvCode,a.cInvName,a.cInvStd,a.cGroupCode,a.cInvClassCode,a.M1,iSafeNum1, iSafeNum2, iSafeNumQty1, iSafeNumQty2 into #e
from #w a left join InventoryM1 b on a.cInvCode=b.cInvCode and a.M1=b.M1 

select *
,a.iSafeNum1 as 最低库存盒数,a.iSafeNum2 as 最高库存盒数,a.iSafeNumQty1 as 最低库存数量,a.iSafeNumQty2 as 最高库存数量
,case when isnull(iQuantity,0)<isnull(a.iSafeNumQty1,0) then '库存不足' 
when isnull(iQuantity,0)>isnull(a.iSafeNumQty2,0) then '库存超量' 
else '正常' end as 库存状态
,i.cInvClassCode ,n.NeedDate,case when n.NeedQty<>0 then n.NeedQty else null end NeedQty,case when n.NeedBoxQty<>0 then n.NeedBoxQty else null end NeedBoxQty , 'edit' as iSave 
from #e a left join #b b on a.cInvCode=b.cInvCode and a.M1=b.M1 left join  Inventory i on a.cInvCode=i.cInvCode left join Need n on a.cInvCode=n.cInvCode and  a.M1=n.M1
where 2=2 and  (select count(*) from Inventory b where a.cInvCode=b.cInvCode and ','+convert(varchar(4000),b.M1)+',' like '%,'+convert(varchar(4000),a.M1)+',%')>0";

            }
            else
            {
                sSQL = sSQL + @"
select cInvCode,cInvName,cInvStd,cGroupCode,cInvClassCode,convert(nvarchar(4000),M1) as M1 into #q from Inventory i where 3=3

SELECT distinct a.cInvCode,a.cInvName,a.cInvStd,a.cGroupCode,a.cInvClassCode,b.M1 into #w
FROM (SELECT cInvCode,cInvName,cInvStd,cGroupCode,cInvClassCode,M1=CAST('<v>'+REPLACE(M1,',','</v><v>')+'</v>' AS xml) FROM #q) a
OUTER APPLY (SELECT M1=T.C.value('.','varchar(50)') FROM a.M1.nodes('/v') AS T(C)) b where (ISNULL(b.M1, '') <> '') and 4=4

select a.cInvCode,a.cInvName,a.cInvStd,a.cGroupCode,a.cInvClassCode,a.M1,iSafeNum1, iSafeNum2, iSafeNumQty1, iSafeNumQty2 into #e
from #w a left join InventoryM1 b on a.cInvCode=b.cInvCode and a.M1=b.M1 

select *
,iSafeNum1 as 最低库存盒数,iSafeNum2 as 最高库存盒数,iSafeNumQty1 as 最低库存数量,iSafeNumQty2 as 最高库存数量
,case when isnull(sBoxQty,0)<isnull(iSafeNum1,0)  then '库存不足' 
when isnull(sBoxQty,0)>isnull(iSafeNum2,0) then '库存超量' 
else '正常' end as 库存状态
,i.cInvClassCode ,n.NeedDate,case when n.NeedQty<>0 then n.NeedQty else null end NeedQty,case when n.NeedBoxQty<>0 then n.NeedBoxQty else null end NeedBoxQty , 'edit' as iSave 
from #e a left join #b b on a.cInvCode=b.cInvCode and a.M1=b.M1 left join  Inventory i on a.cInvCode=i.cInvCode left join Need n on a.cInvCode=n.cInvCode and  a.M1=n.M1
where 2=2  and  (select count(*) from Inventory b where a.cInvCode=b.cInvCode and ','+convert(varchar(4000),b.M1)+',' like '%,'+convert(varchar(4000),a.M1)+',%')>0";
            }
            if (this.Text.IndexOf("半成品") >= 0)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvClassCode='02'");
                sSQL = sSQL.Replace("2=2", "2=2 and isnull(a.iSafeNumQty1,0)<>0 and isnull(a.iSafeNumQty2,0)<>0");
            }
            else if (this.Text.IndexOf("成品") >= 0)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvClassCode='01'");
                sSQL = sSQL.Replace("2=2", "2=2 and isnull(a.iSafeNum1,0)<>0 and isnull(a.iSafeNum2,0)<>0");
            }
            else if (this.Text.IndexOf("原料") >= 0)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and (i.cInvClassCode='03' or i.cInvClassCode='04')");
                sSQL = sSQL.Replace("2=2", "2=2 and isnull(a.iSafeNumQty1,0)<>0 and isnull(a.iSafeNumQty2,0)<>0");
            }
                
            if (lookUpEdit存货编码.EditValue != null && lookUpEdit存货编码.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
                sSQL = sSQL.Replace("3=3", "3=3 and cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
            }
            if (lookUpEdit存货分类.EditValue != null && lookUpEdit存货分类.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and i.cInvClassCode='" + lookUpEdit存货分类.EditValue.ToString().Trim() + "'");
            }
            if (this.Text.IndexOf("原料")==-1 && (lookUpEditM1.EditValue != null && lookUpEditM1.EditValue.ToString().Trim() != ""))
            {
                sSQL = sSQL.Replace("1=1", "1=1 and b.M1='" + lookUpEditM1.EditValue.ToString().Trim() + "'");
                sSQL = sSQL.Replace("4=4", "4=4 and b.M1='" + lookUpEditM1.EditValue.ToString().Trim() + "'");
            }
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            //for(int i=0;i<dt.Rows.Count;i++)
            //{
            //decimal d库存 = dt.Rows
            //}

            return dt;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
            {
                iRow = gridView1.FocusedRowHandle;
            }
            #region
            if (e.Column != gridColiSave  && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            }
            if (e.Column != gridColiSave  && gridView1.GetRowCellDisplayText(e.RowHandle, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
            #endregion
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {

                if (this.Text.IndexOf("成品") >= 0 && this.Text.IndexOf("半") == -1)
                {
                    string 库存状态 = gridView1.GetRowCellDisplayText(e.RowHandle, gridCol库存状态).ToString().Trim();

                    decimal d现存合数 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol现存盒数), 6);
                    decimal d最低 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol最低库存盒数), 6);
                    decimal d最高 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol最高库存盒数), 6);

                    if (d现存合数 < d最低)
                    {
                        e.Appearance.BackColor = Color.LightCoral;
                        //gridView1.SetRowCellValue(e.RowHandle, gridCol库存状态, "库存不足");
                    }
                    else if (d现存合数 > d最高)
                    {
                        e.Appearance.BackColor = Color.LightBlue;
                        //gridView1.SetRowCellValue(e.RowHandle, gridCol库存状态, "库存超量");
                    }
                }
                if (this.Text.IndexOf("半成品") >= 0 || this.Text.IndexOf("原料") >= 0)
                {
                    string 库存状态 = gridView1.GetRowCellDisplayText(e.RowHandle, gridCol库存状态).ToString().Trim();

                    decimal d现存数量 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol现存数量), 6);
                    decimal d最低 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol最低库存数量), 6);
                    decimal d最高 = ReturnDecimal(gridView1.GetRowCellValue(e.RowHandle, gridCol最高库存数量), 6);

                    if (d现存数量 < d最低)
                    {
                        e.Appearance.BackColor = Color.LightCoral;
                        //gridView1.SetRowCellValue(e.RowHandle, gridCol库存状态, "库存不足");
                    }
                    else if (d现存数量 > d最高)
                    {
                        e.Appearance.BackColor = Color.LightBlue;
                        //gridView1.SetRowCellValue(e.RowHandle, gridCol库存状态, "库存超量");
                    }
                }

            }
            catch { }
        }


    }
}
