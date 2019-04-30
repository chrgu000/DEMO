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
    public partial class Frm排产日期比对 : FrameBaseFunction.FrmFromModel
    {
        DateTime Date1;
        DateTime Date2;
        
        public Frm排产日期比对()
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

        private void Frm排产日期比对_Load(object sender, EventArgs e)
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
            LookUp.Inventory(ItemLookUpEdit存货名称);
            LookUp.Inventory(lookUpEdit存货编码);
        }

        private void GetGrid()
        {
            string sErr = "";
            gridControl1.DataSource = Get();


            gridView1.OptionsBehavior.Editable = false;
            sState = "sel";
        }
       

        private DataTable Get()
        {
            string sd = dateEdit1.Text;
            string ed = dateEdit2.Text;


            sSQL = @"
select a.moid,c.modid,d.MoRoutingId,d.MoRoutingDId
    ,a.MoCode as 生产订单号,c.SortSeq as 生产订单行号,c.InvCode as 物料编码,h.cInvName as 物料名称,h.cInvStd as 物料规格
    ,c.Qty as 生产订单数量,c.QualifiedInQty  as 入库数量,c.SoCode as 销售订单号,c.SoSeq as 销售订单行号,c.Define26 as 单重
    ,d.OpSeq as 工序行号,d.Operationid as 标准工序ID,d.Description as 工序说明
    ,d.BalQualifiedQty as 可用合格数量,d.LastFlag as 末道工序,d.FirstFlag as 首道工序
    ,d.WcID as 工作中心ID,f.WcCode  as 工作中心代号,f.Description as 工作中心名称
    ,case when d.SubFlag  = 1 then '是' else '否' end as 委外工序
    ,isnull(d.Define27,0) as 单件加工工时,isnull(d.Define34,0) as 工序分类,isnull(d.Define35,0) as 是否瓶颈工序
    ,d.StartDate as 工序开工日期,d.DueDate as 工序完成日期
    ,case when isnull(g.iID,0) = 0 then d.StartDate else g.计划生产开工日期 end as 计划生产开工日期
    ,case when isnull(g.iID,0) = 0 then c.Qty - isnull(c.QualifiedInQty,0) else g.数量 end as 工序排产数量
    ,d.CompleteQty  as 工序完成数量,c.MoLotCode  as 零件号  ,isnull(工票打印次数,0) as 工票打印次数,null as 定额工时,机床,人员 ,调度安排时间 ,计划生产完工日期 ,实际完工日期
, 生产工票打印.审核人 as 工票审核人  
from @u8.mom_order a 
    inner join @u8.mom_morder b on a.moid = b.moid
    inner join @u8.mom_orderdetail c on b.moid = a.moid and b.modid = c.modid
    inner join @u8.sfc_moroutingdetail d on d.modid = c.modid
    inner join @u8.sfc_operation e on e.OperationId = d.OperationId 
    inner join @u8.sfc_workcenter f on f.WcId = d.WcID
    left join dbo.生产工序日计划 g on g.生产订单工艺路线明细ID = d.MoRoutingDId
    inner join @u8.Inventory h on h.cInvCode = c.InvCode
left join 生产工票打印 on d.MoRoutingDId=生产工票打印.MoRoutingDId 
left join (select MoRoutingDId,MIN(DocDate) as 实际完工日期 from @u8.sfc_optransform group by MoRoutingDId) sfc on d.MoRoutingDId=sfc.MoRoutingDId
where c.Status = 3 and c.MoLotCode is not null and g.审核人 is not null and 1=1 and g.计划生产完工日期 is not null 
order by a.moid,c.modid,d.OpSeq";

            if (sd != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 计划生产完工日期>='" + sd + "'");
            }

            if (ed != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and 计划生产完工日期<='" + ed + "'");
            }
            if (checkEdit1.Checked != true)
            {
                sSQL = sSQL.Replace("1=1", "1=1 and isnull(c.CloseUser,'')=''");
            }
            if (lookUpEdit存货编码.EditValue != null && lookUpEdit存货编码.EditValue.ToString().Trim() != "")
            {
                sSQL = sSQL.Replace("1=1", "1=1 and a.存货编码='" + lookUpEdit存货编码.EditValue.ToString().Trim() + "'");
            }

            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            //dt.Columns.Add("State");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    sSQL = "select * from UFDATA_100_2014.dbo.sfc_moroutingdetail where MoDId='" + dt.Rows[i]["MoDId"] + "' order by MoRoutingDId ";
            //    DataTable dtsfc = clsSQLCommond.ExecQuery(sSQL);
            //    for (int j = 0; j < dtsfc.Rows.Count; j++)
            //    {
            //        if (ReturnObjectToDecimal(dtsfc.Rows[j]["BalQualifiedQty"].ToString(),2) > 0)
            //        {
            //            dt.Rows[i]["State"] = dtsfc.Rows[j]["Description"].ToString();
            //        }
            //        else if (ReturnObjectToDecimal(dtsfc.Rows[j]["BalMachiningQty"].ToString(), 2) > 0)
            //        {
            //            dt.Rows[i]["State"] = dtsfc.Rows[j]["Description"].ToString();
            //        }
            //    }
            //    if (dt.Rows[i]["State"].ToString() == "")
            //    {
            //        dt.Rows[i]["State"] = dtsfc.Rows[dtsfc.Rows.Count - 1]["Description"].ToString() + "完";
            //    }
            //}
            return dt;
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

       
    }
}
