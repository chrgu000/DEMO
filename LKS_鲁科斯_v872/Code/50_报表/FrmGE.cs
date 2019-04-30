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
    public partial class FrmGE : 系统服务.FrmBaseInfo
    {
        string Type = "";
        public FrmGE()
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

        private void FrmGE_Load(object sender, EventArgs e)
        {
            try
            {
                SetLookUpEdit();
                

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

        private void GetGrid()
        {
            成本计算 cb = new 成本计算();
            cb.type = " 1=1";
            if (lookUpEdit月份.Text == "")
            {
                throw new Exception("月份不可为空");
            }
            string sd = "";
            string ed = "";
            系统服务.GetUAPeriod p = new 系统服务.GetUAPeriod();
            int month = int.Parse(lookUpEdit月份.EditValue.ToString());
            p.GetPeriod(lookUpEdit月份.EditValue.ToString(), out sd, out ed);

            cb.GetQC(month);
            string sSQL1= cb.GetList(sd, ed, month);
            sSQL = @"exec dbo.GL_P_FSEYEB N'5555555555555555555555',N'5555555555555555555555',0,NULL,N'我',1,5,0,NULL,NULL,NULL,NULL,
N'case when cclass =N''资产'' then 1 else case when cclass =N''负债'' then 2 else case when cclass =N''权益'' then 3 else case when cclass =N''成本'' then 4 else 5 end  end  end  end  as lx',N'',NULL";
            sSQL = sSQL.Replace("5555555555555555555555", lookUpEdit月份.EditValue.ToString());
            sSQL = sSQL.Replace("dbo.", "@u8.");
            DataTable dtzz = clsSQLCommond.ExecQuery(sSQL);
            DataRow[] dwcg = dtzz.Select("ccode='410520'");
            string zzcg = "0";
            if (dwcg.Length > 0)
            {
                zzcg = dwcg[0]["smd"].ToString();
            }

            DataRow[] dwgs = dtzz.Select("ccode='410522'");
            string zzgs = "0";
            if (dwgs.Length > 0)
            {
                zzgs = dwgs[0]["smd"].ToString();
            }
            
            sSQL = @"
declare @zje as decimal(38,8)
SELECT  @zje=isnull(sum(dbo.SaleBillVouchs.iNatMoney),0) FROM         dbo.SaleBillVouchs WITH (nolock) left join dbo.SaleBillVouch WITH (nolock) on dbo.SaleBillVouchs.SBVID = dbo.SaleBillVouch.SBVID where 1=1 


declare @iPer1 as nvarchar(10)
declare @iPer2 as nvarchar(10)
set @iPer1=5555555555555555555555
set @iPer2=5555555555555555555555
/*exec GL_P_FSEYEB N'5555555555555555555555',N'5555555555555555555555',0,NULL,N'我',1,1,0,NULL,NULL,NULL,NULL,N'case when cclass =N''资产'' then 1 else case when cclass =N''负债'' then 2 else case when cclass =N''权益'' then 3 else case when cclass =N''成本'' then 4 else 5 end  end  end  end  as lx',N'YEB42108',NULL
SELECT dbo.gl_accsum.ccode,
Sum(case when (iperiod)=@iper1 then (case when cbegind_c=N'借' then mb end) else 0 end) AS 期初借方,
Sum(case when (iperiod)=@iper1 then (case when cbegind_c=N'贷' then mb end) else 0 end) AS 期初贷方,
Sum(case when (iperiod)=@iper1 then md else 0 end) AS 本期借方,
Sum(case when (iperiod)=@iper1 then mc else 0 end) AS 本期贷方,
Sum(case when (iperiod)=@iper1 then (case when cendd_c=N'借' then me end) else 0 end) AS 期末借方,
Sum(case when (iperiod)=@iper1 then (case when cendd_c=N'贷' then me end) else 0 end) AS 期末贷方
into #r FROM dbo.GL_accsum 
inner join dbo.code on dbo.gl_accsum.ccode=dbo.code.ccode
WHERE iperiod =@iper2 and igrade =2  GROUP BY dbo.gl_accsum.ccode*/

declare @cg as decimal(38,8)
declare @gs as decimal(38,8)
set @cg=1111111111/@zje
set @gs=2222222222/@zje

/*
select @cg=本期借方/@zje from #r where ccode='410520'
select @gs=本期借方/@zje from #r where ccode='410522'*/

SELECT   cexch_name , dbo.SaleBillVouchs.iNatSum  as 销售发票价税合计,dbo.SaleBillVouchs.iNatUnitPrice  as 无税单价,dbo.SaleBillVouchs.iNatMoney  as 无税金额,dbo.SaleBillVouch.cSBVCode as 发票号码,
dbo.SaleBillVouch.dDate as 发票日期, 
dbo.SaleBillVouch.cCusCode as 客户编号,dbo.SaleBillVouch.cCusName as 客户名称,dbo.SaleBillVouch.cPersonCode as 业务员编码,dbo.person.cPersonName as 业务员,dbo.SaleBillVouchs.cInvCode as 物料编码,dbo.Inventory.cInvName as 物料名称,
dbo.SaleBillVouchs.iQuantity as 数量,
convert(decimal(18,4),@cg*dbo.SaleBillVouchs.iMoney) as 运输,
convert(decimal(18,4),@gs*dbo.SaleBillVouchs.iMoney) as 关税,
convert(decimal(18,4),case when k.iquantity0202 <>0 then k.imoney0202/k.iquantity0202*dbo.SaleBillVouchs.iquantity else 0 end) as 销售成本,--k.iWork0202 工,k.iCost0202 费,k.sWork0202 工还原,k.sCost0202 费还原,h.iomoney/(case h.ionum when 0 then 1 else h.ionum end)*dbo.SaleBillVouchs.iquantity
convert(decimal(18,4),case when 发出数量<>0 then k.发出工金额/发出数量*dbo.SaleBillVouchs.iQuantity else 0 end) as 工,
convert(decimal(18,4),case when 发出数量<>0 then k.发出费金额/发出数量*dbo.SaleBillVouchs.iQuantity else 0 end) as 费,
convert(decimal(18,4),case when 发出数量<>0 then k.发出工还原/发出数量*dbo.SaleBillVouchs.iQuantity else 0 end) as 工还原,
convert(decimal(18,4),case when 发出数量<>0 then k.发出费还原/发出数量*dbo.SaleBillVouchs.iQuantity else 0 end) as 费还原,
datediff(d,dGatheringDate,getdate()) as 超期天数,icreditdays as 账期 into #q
FROM         dbo.SaleBillVouchs WITH (nolock) left join dbo.SaleBillVouch WITH (nolock) on dbo.SaleBillVouchs.SBVID = dbo.SaleBillVouch.SBVID INNER JOIN
dbo.Inventory WITH (nolock) ON dbo.SaleBillVouchs.cInvCode = dbo.Inventory.cInvCode LEFT OUTER JOIN
dbo.Warehouse WITH (nolock) ON dbo.SaleBillVouchs.cWhCode = dbo.Warehouse.cWhCode LEFT OUTER JOIN
dbo.ComputationUnit AS Unit1 ON dbo.Inventory.cComUnitCode = Unit1.cComunitCode LEFT OUTER JOIN
dbo.ComputationUnit AS Unit2 WITH (nolock) ON dbo.SaleBillVouchs.cUnitID = Unit2.cComunitCode LEFT OUTER JOIN
dbo.Vendor WITH (nolock) ON dbo.SaleBillVouchs.cvmivencode = dbo.Vendor.cVenCode LEFT OUTER JOIN
dbo.Inventory_Sub WITH (nolock) ON dbo.Inventory_Sub.cInvSubCode = dbo.SaleBillVouchs.cInvCode 
left join dbo.v_aa_enum enum1 on (dbo.SaleBillVouch.cVouchType = enum1.enumcode  and enum1.enumtype=N'SA.cVouchType')
left join dbo.ia_summary as h on dbo.SaleBillVouchs.cinvcode=h.cinvcode and h.imonth=5555555555555555555555 
left join dbo.Person on dbo.SaleBillVouch.cPersonCode=dbo.person.cPersonCode 
left join #k k on dbo.SaleBillVouchs.cInvCode=k.存货编码 
where 1=1 and 2=2 and isnull(Salebillvouch.cInvalider,'')='' and  isnull(Salebillvouch.cSTCode,'') <> '' 

select *,
isnull(销售成本,0)-isnull(工,0)-isnull(费,0) as 成本,isnull(销售成本,0)-isnull(工还原,0)-isnull(费还原,0) as 成本还原 
into #t from #q

select *,
convert(decimal(18,4),isnull(无税金额,0)-isnull(运输,0)-isnull(关税,0)-isnull(成本,0)) as GE,
case when 无税金额<>0 then convert(decimal(18,4),(isnull(无税金额,0)-isnull(运输,0)-isnull(关税,0)-isnull(成本,0))/isnull(无税金额,0)) else 0 end as GEPer,
convert(decimal(18,4),isnull(无税金额,0)-isnull(运输,0)-isnull(关税,0)-isnull(成本还原,0)) as GM,
case when 无税金额<>0 then convert(decimal(18,4),(isnull(无税金额,0)-isnull(运输,0)-isnull(关税,0)-isnull(成本还原,0))/isnull(无税金额,0)) else 0 end as GMPer from #t 
  ";

            if (lookUpEdit存货分类.Text.Trim() != "")
            {
                sSQL = sSQL.Replace(" 2=2 ", " 2=2 and dbo.SaleBillVouchs.cInvCode='" + lookUpEdit存货分类.EditValue.ToString().Trim() + "' ");
            }
            if (lookUpEdit存货编码.Text.Trim() != "")
            {
                sSQL = sSQL.Replace(" 2=2 ", " 2=2 and dbo.Inventory.cInvCode='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "' ");
            }
            if (sd != "")
            {
                sSQL = sSQL.Replace(" 1=1 ", " 1=1 and dbo.SaleBillVouch.dDate>='" + sd + "' ");
            }
            if (ed != "")
            {
                sSQL = sSQL.Replace(" 1=1 ", " 1=1 and dbo.SaleBillVouch.dDate<='" + ed + "' ");
            }
            sSQL = sSQL.Replace("5555555555555555555555", lookUpEdit月份.EditValue.ToString());

            sSQL = sSQL.Replace("1111111111", zzcg);
            sSQL = sSQL.Replace("2222222222", zzgs);

            sSQL = sSQL.Replace("1111111111111111111111", "'" + sd + "'");
            sSQL = sSQL.Replace("2222222222222222222222", "'" + ed + "'");
            sSQL = sSQL.Replace("3333333333333333333333", Type);
            sSQL = sSQL.Replace("4444444444444444444444", "'" + 系统服务.ClsBaseDataInfo.sUFDataBaseYear + "-01-01" + "'");

            sSQL = sSQL.Replace("dbo.", "@u8.");

            sSQL = sSQL1 + sSQL;
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            gridControl1.DataSource = dt;

            gridView1.ExpandAllGroups();
            
        }

        private decimal GetTemp(decimal d, decimal dTemp,decimal price, int i, int count,DataTable dt)
        {
            decimal tqty = 0;
            decimal tprice = 0;
            if (d > 0)
            {
                if (dTemp > 0)
                {
                    decimal qty = dTemp - d;

                    if (qty >= 0)
                    {
                        tqty = d;
                    }
                    else
                    {
                        tqty = dTemp;
                    }
                    dt.Rows[i]["数量" + count] = tqty;
                    tprice = ReturnDecimal(tqty * price, 2);
                    dt.Rows[i]["金额" + count] = tprice;
                }
                else
                {
                    dt.Rows[i]["数量" + count] = DBNull.Value;
                    dt.Rows[i]["金额" + count] = DBNull.Value;
                }
            }
            else
            {
                dt.Rows[i]["数量" + count] = DBNull.Value;
                dt.Rows[i]["金额" + count] = DBNull.Value;
            }
            dTemp = dTemp - tqty;
            return dTemp;
        }


        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            系统服务.LookUp.InventoryClass(lookUpEdit存货分类);
            系统服务.LookUp.Inventory(lookUpEdit存货编码);
            系统服务.LookUp._LoopUpData(lookUpEdit月份, "19");
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

        private void buttonEdit存货分类_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            系统服务.FrmInvClassInfo frm = new 系统服务.FrmInvClassInfo("");
            if (DialogResult.OK == frm.ShowDialog())
            {
                buttonEdit存货分类.EditValue = frm.id;

                frm.Enabled = true;
            }
        }

        private void buttonEdit存货分类_EditValueChanged(object sender, EventArgs e)
        {
            if (buttonEdit存货分类.Text.Trim() != "")
            {
                lookUpEdit存货分类.EditValue = buttonEdit存货分类.Text.Trim();
            }
            else
            {
                lookUpEdit存货分类.EditValue = "";
            }
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
            系统服务.FrmInvInfo frm = new 系统服务.FrmInvInfo("",false);
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
                lookUpEdit存货编码.EditValue = "";
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

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DevExpress.XtraGrid.GridSummaryItem itemge = gridColGEPer.SummaryItem;
            DevExpress.XtraGrid.GridSummaryItem itemgm = gridColGMPer.SummaryItem;
            decimal ge=ReturnDecimal(gridColGE.SummaryText);
            decimal gm=ReturnDecimal(gridColGM.SummaryText);
            decimal price=ReturnDecimal(gridColSalesAmount.SummaryText);
            if (price != 0)
            {
                itemge.DisplayFormat = ReturnDecimal((ge / price),4).ToString();
                itemgm.DisplayFormat = ReturnDecimal((gm / price),4).ToString();
            }
            else
            {
                itemge.DisplayFormat = "0";
                itemgm.DisplayFormat = "0";
            }

        }

    }
}
