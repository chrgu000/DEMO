using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;

namespace ImportDLL
{
    public partial class Frm工序转移单批量 : FrameBaseFunction.FrmFromModel
    {
        string tablename = "@u8.sfc_optransform";
        string tableid = "moid";
        long iID = -1;
        public DataTable dt人员;
        TH.DAL.sfc_optransform sfc = new TH.DAL.sfc_optransform();

        //public Frm工序转移单批量(long siID)
        //{
        //    //iID = siID;
        //    InitializeComponent();

        //}

        public Frm工序转移单批量()
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
            //gridView合并.OptionsCustomization.

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
            //DataTable dtState = (DataTable)ItemLookUpEditPerState.DataSource;
            //DataTable dtType = (DataTable)ItemLookUpEditType.DataSource;
            DataColumn dc = new DataColumn();
            dc.ColumnName = "StateText";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "TypeText";
            dt.Columns.Add(dc);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
                //if (drState.Length > 0)
                //{
                //    dt.Rows[i]["StateText"] = drState[0]["State"];
                //}

                //DataRow[] drType = dtType.Select("iID = '" + dt.Rows[i]["Type"].ToString().Trim() + "'");
                //if (drType.Length > 0)
                //{
                //    dt.Rows[i]["TypeText"] = drType[0]["Type"];
                //}
            }

            return dt;
        }


        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            try
            {
            }
            catch { }
        }
        /// <summary>
        /// 输出 
        /// </summary>
        private void btnExport()
        {
            throw new NotImplementedException();
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
        /// 导入 打印销售订单
        /// </summary>
        private void btnImport()
        {

            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            
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
            
        }

        private void GetSel()
        {
            //string sSQL = "select * from " + tablename + " a left join " + tablenames + "  b on a.ID=b.ID where 1=1 ";
            //if (FrameBaseFunction.ClsBaseDataInfo.sUid != "admin")
            //{
            //    sSQL = sSQL + " and cSTCode in (select cSTCode from SaleRole where vchrUid='" + FrameBaseFunction.ClsBaseDataInfo.sUid + "') ";
            //}
            //if (单据号1 != null && 单据号1 != "")
            //{
            //    sSQL = sSQL + " and a." + tablecode + ">='" + 单据号1 + "'";
            //}
            //if (单据号2 != null && 单据号2 != "")
            //{
            //    sSQL = sSQL + " and a." + tablecode + "<='" + 单据号2 + "'";
            //}
            //if (单据日期1 != null && 单据日期1 != "")
            //{
            //    sSQL = sSQL + " and dDate>='" + 单据日期1 + "'";
            //}
            //if (单据日期2 != null && 单据日期2 != "")
            //{
            //    sSQL = sSQL + " and dDate<='" + 单据日期2 + "'";
            //}
            //if (制单日期1 != null && 制单日期1 != "")
            //{
            //    sSQL = sSQL + " and dCreatesysTime>='" + 制单日期1 + "'";
            //}
            //if (制单日期2 != null && 制单日期2 != "")
            //{
            //    sSQL = sSQL + " and dCreatesysTime<='" + 制单日期2 + "'";
            //}
            //if (业务员 != null && 业务员 != "")
            //{
            //    sSQL = sSQL + " and cPersonCode='" + 业务员 + "'";
            //}
            //if (部门 != "")
            //{
            //    sSQL = sSQL + " and cDepCode='" + 部门 + "'";
            //}
            //if (客户1 != "")
            //{
            //    sSQL = sSQL + " and cCusCode>='" + 客户1 + "'";
            //}
            //if (客户2 != "")
            //{
            //    sSQL = sSQL + " and cCusCode<='" + 客户2 + "'";
            //}
            //if (审核日期1 != "")
            //{
            //    sSQL = sSQL + " and dVerifysysTime>='" + 审核日期1 + "'";
            //}
            //sSQL = sSQL + "  order by a.ID";
            //dtSel = clsSQLCommond.ExecQuery(sSQL);
            //if (dtSel.Rows.Count > 0)
            //{
            //    iID = Convert.ToInt64(dtSel.Rows[0]["ID"]);
            //    GetGrid();
            //}
            //else
            //{
            //    btnLast();
            //}

        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                sSQL = "select isnull(min(MoDId),0) as ID from " + tablename + " a left join 工序转移单 b on a.TransformId=b.TransformId  where 1=1  and b.TransformId is not null ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                }
                GetGrid();
            }
            catch
            {
                MessageBox.Show("翻页失败");
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (iID != -1)
                {
                    sSQL = "select MoDId as ID from " + tablename + "  a left join 工序转移单 b on a.TransformId=b.TransformId where MoDId<" + textEditID.EditValue.ToString().Trim() + "  and b.TransformId is not null";
                    sSQL = sSQL + " order by MoDId desc";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    }
                    GetGrid();
                }
            }
            catch
            {
                MessageBox.Show("翻页失败");
            }
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (iID != -1)
                {
                    sSQL = "select MoDId as ID from " + tablename + "  a left join 工序转移单 b on a.TransformId=b.TransformId where MoDId>" + textEditID.EditValue.ToString().Trim() + "  and b.TransformId is not null";
                    sSQL = sSQL + " order by ID";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);
                        iID = Convert.ToInt64(dt.Rows[0]["ID"]);
                    }
                    GetGrid();
                }
            }
            catch
            {
                MessageBox.Show("翻页失败");
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                sSQL = "select isnull(max(MoDId),-1) as ID from " + tablename + "  a left join 工序转移单 b on a.TransformId=b.TransformId where 1=1 and b.TransformId is not null  ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                    iID = Convert.ToInt64(dt.Rows[0]["ID"]); ;
                }
                GetGrid();
            }
            catch
            {
                MessageBox.Show("翻页失败");
            }
        }

        /// <summary>
        /// 锁定 折扣率审核
        /// </summary>
        private void btnLock()
        {
 
        }
        /// <summary>
        /// 解锁  折扣率弃审
        /// </summary>
        private void btnUnLock()
        {
           
        }
        /// <summary>
        /// 增行 引用
        /// </summary>
        private void btnAddRow()
        {
            
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            string sErr = "";
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {

                    gridView1.DeleteRow(i);

                }
            }
            if (sErr != "")
            {
                MessageBox.Show(sErr);
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            GetNull();
            SetEnabled(true);
            //dateEdit单据日期.EditValue = FrameBaseFunction.ClsBaseDataInfo.sLogDate;

            int iFocRow = gridView1.FocusedRowHandle;

            sSQL = "select a.*,'' as cInvCode,'' as cInvName,'' as cInvStd,'' as 零件号, '' as OpSeq,'' as 移入工序,'edit' as iSave,'' as 可用数量,'' as 订单数量,'' as 移出工序说明,'' as 移入工序说明 "
            + ",b.试样号,b.材质,b.重量,b.渗层,b.人员列表,b.工时列表,b.人员,b.工时,b.备注,b.设备,b.炉号 from " + tablename + " a left join 工序转移单 b on a.TransformId=b.TransformId where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dtBingGrid;
            try
            {
                gridView1.FocusedColumn = gridColMoRoutingId;
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }

            gridView1.OptionsBehavior.Editable = true;
            textEdit单据号.Focus();
            sState = "add";

        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            sState = "edit";
            
            SetEnabled(true);
            textEdit单据号.Enabled = false;
            
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            try
            {
                Frm工序转移单批量_New frm = new Frm工序转移单批量_New();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                    string iType = frm.iType;
                    string iValue = frm.iValue;
                    if (iType == "1")
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, gridColMoRoutingDId).ToString() != "")
                            {
                                gridView1.SetRowCellValue(i, gridCol设备, iValue);
                            }
                        }
                    }
                    else if (iType == "2")
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            if (gridView1.GetRowCellValue(i, gridColMoRoutingDId).ToString() != "")
                            {
                                gridView1.SetRowCellValue(i, gridCol人员列表, iValue);
                            }
                        }
                    }


                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("批量修改失败" + ee.Message);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            try
            {
                DataTable dt = (DataTable)gridControl1.DataSource;
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i]["MoId"].ToString() == "")
                    {
                        dt.Rows.Remove(dt.Rows[i]);
                    }
                }
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("无需要保存的工序转移单");
                }
                int iCou = sfc.Save(dt, 2);
                if (iCou == 0)
                {
                    MessageBox.Show("无需要保存的单据");
                    
                }
                else
                {
                    MessageBox.Show("保存成功,共" + iCou + "条");
                }
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, gridColiSave) != null && (gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() == "add"||gridView1.GetRowCellValue(i, gridColiSave).ToString().Trim() == "update"))
                    {
                        gridView1.SetRowCellValue(i, gridColiSave, "edit");
                    }
                }
                sState = "sel";
                
                SetEnabled(false);

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }

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
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {

        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            try
            {
                Frm工序批量_New frm = new Frm工序批量_New();
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                    string OpCode = frm.OpCode;
                    string 炉号 = frm.炉号;
                    if (OpCode != "" || 炉号 != "")
                    {
                        DataTable dt工序 = sfc.GetImport(OpCode, 炉号);
                        if (dt工序.Rows.Count == 0)
                        {
                            MessageBox.Show("未找到需引入的单据");
                        }
                        else
                        {
                            for (int i = 0; i < dt工序.Rows.Count; i++)
                            {
                                bool b = true;
                                string MoRoutingDId = dt工序.Rows[0]["MoRoutingDId"].ToString();
                                for (int j = 0; j < gridView1.RowCount; j++)
                                {
                                    if (gridView1.GetRowCellValue(j, gridColMoRoutingId) != null)
                                    {
                                        if (MoRoutingDId == gridView1.GetRowCellValue(j, gridColMoRoutingId).ToString())
                                        {
                                            b = false;
                                        }
                                    }
                                }
                                if (b == true)
                                {
                                    Add(dt工序.Rows[i]["MoRoutingDId"].ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("引入可移移工序失败" + ee.Message);
            }
        }

        #endregion

        private void Frm工序转移单批量_Load(object sender, EventArgs e)
        {
            try
            {
                SetEnabled(false);
                SetLookUpEdit();
                GetNull();
                btnLast();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void GetGrid()
        {
            if (iID != -1)
            {
                sSQL = @"select *,c.InvCode as 物料编码,h.cInvName as 物料名称,h.cInvStd as 物料规格,c.MoLotCode  as 零件号, b.设备,b.炉号,b.备注,
sfc.OpSeq ,sfc.Description as 移出工序说明 ,sfc2.OpSeq  as 移入工序 ,sfc2.Description as 移入工序说明 ,'edit' as iSave 
from ufdata_100_2014.dbo.sfc_optransform a left join 工序转移单 b on a.TransformId=b.TransformId
 inner join ufdata_100_2014.dbo.mom_orderdetail c on a.MoDId = c.MoDId
  inner join ufdata_100_2014.dbo.Inventory h on h.cInvCode = c.InvCode
left join ufdata_100_2014.dbo.sfc_moroutingdetail sfc on a.MoRoutingDId=sfc.MoRoutingDId 
left join ufdata_100_2014.dbo.sfc_moroutingdetail sfc2 on a.InMoRoutingDId=sfc2.MoRoutingDId 
where b.TransformId is not null and a.MoDId=" + iID;
                dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dtBingGrid;
                SetEnabled(false);
            }
            else
            {
                GetNull();
                SetEnabled(false);
            }
        }


        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            DataTable dtOpStatus = new DataTable();
            dtOpStatus.Columns.Add("ID");
            dtOpStatus.Columns.Add("Name");
            DataRow dw1= dtOpStatus.NewRow();
            dw1[0] = "1";
            dw1[1] = "加工";
            dtOpStatus.Rows.Add(dw1);

            DataRow dw2 = dtOpStatus.NewRow();
            dw2[0] = "2";
            dw2[1] = "检验";
            dtOpStatus.Rows.Add(dw2);

            DataRow dw3 = dtOpStatus.NewRow();
            dw3[0] = "3";
            dw3[1] = "合格";
            dtOpStatus.Rows.Add(dw3);

            DataRow dw4 = dtOpStatus.NewRow();
            dw4[0] = "4";
            dw4[1] = "拒绝";
            dtOpStatus.Rows.Add(dw4);

            DataRow dw5 = dtOpStatus.NewRow();
            dw5[0] = "5";
            dw5[1] = "报废";
            dtOpStatus.Rows.Add(dw5);

            ItemLookUpEdit状态.DataSource = dtOpStatus;

            LookUp.Person(ItemLookUpEdit人员);
            LookUp.Person2(ItemLookUpEdit人员3);
            LookUp.EQ_EQData(ItemLookUpEdit设备);
            
            LookUp.Person(ItemLookUpEdit人员2);
            ItemLookUpEdit人员2.Properties.DisplayMember = "PersonCode";
            LookUp.EQ_EQData(ItemLookUpEdit设备2);
            ItemLookUpEdit设备2.Properties.DisplayMember = "cEQCode";

            DataTable dtTransformType = new DataTable();
            dtTransformType.Columns.Add("ID");
            dtTransformType.Columns.Add("Name");
            DataRow dww1 = dtTransformType.NewRow();
            dww1[0] = "1";
            dww1[1] = "正向";
            dtTransformType.Rows.Add(dww1);

            DataRow dww2 = dtTransformType.NewRow();
            dww2[0] = "2";
            dww2[1] = "反向";
            dtTransformType.Rows.Add(dww2);

            ItemLookUpEdit类型.DataSource = dtTransformType;

//            string sSQL = @" SELECT cast(0 as bit) as bRefSelectColumn,MoRoutingDId,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[OpSeq] as OpSeq,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[Description] as Description,[MMMomOrderdetailEntity_mom_orderdetail].[Qty] as Qty,[MMVBasInventoryEntity_v_bas_inventory].[ComUnitName] as ComUnitName,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[DueDate] as DueDate,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[StartDate] as StartDate,[MMWorkCenterEntity_sfc_workcenter].[WcCode] as WcCode,[MMWorkCenterEntity_sfc_workcenter].[Description] as WcDescription 
// 
//FROM @u8.[sfc_morouting] AS [MMSfcMoroutingEntity_sfc_morouting]
//LEFT JOIN @u8.[v_mom_orderdetail_all] AS [MMMomOrderdetailEntity_mom_orderdetail] ON [MMSfcMoroutingEntity_sfc_morouting].[MoDId]=[MMMomOrderdetailEntity_mom_orderdetail].[MoDId]
//LEFT JOIN @u8.[bas_part] AS [MMPartEntity_bas_part] ON [MMMomOrderdetailEntity_mom_orderdetail].[PartId]=[MMPartEntity_bas_part].[PartId]
//LEFT JOIN @u8.[v_bas_inventory] AS [MMVBasInventoryEntity_v_bas_inventory] ON [MMPartEntity_bas_part].[InvCode]=[MMVBasInventoryEntity_v_bas_inventory].[InvCode]
//LEFT JOIN @u8.[sfc_moroutingdetail] AS [MMSfcMoroutingdetailEntity_sfc_moroutingdetail] ON [MMSfcMoroutingEntity_sfc_morouting].[MoRoutingId]=[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[MoRoutingId]
//LEFT JOIN @u8.[sfc_workcenter] AS [MMWorkCenterEntity_sfc_workcenter] ON [MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[WcId]=[MMWorkCenterEntity_sfc_workcenter].[WcId]
// 
// WHERE 1=1   ";//and [MMSfcMoroutingEntity_sfc_morouting].MoDId = 11839 
//            DataTable dt工序 = clsSQLCommond.ExecQuery(sSQL);
//            ItemLookUpEdit工序.DataSource = dt工序;
            //ItemLookUpEdit移入工序.DataSource = dt工序;

            sSQL = @"Select cast(0 as bit) as bRefSelectColumn,[UserdefineEntity_UserDefine].[cAlias] as ID,[UserdefineEntity_UserDefine].[cValue] as Name
 
FROM @u8.[UserDefine] AS [UserdefineEntity_UserDefine]
 
 WHERE   [UserdefineEntity_UserDefine].[cID]='09'";
            
            DataTable dt工厂 = clsSQLCommond.ExecQuery(sSQL);
            DataRow dwg = dt工厂.NewRow();
            dt工厂.Rows.Add(dwg);
            ItemLookUpEdit工厂.Properties.DataSource = dt工厂;

            //sSQL = "select OpCode,Description  from @u8.sfc_operation";
            //DataTable dtwork = clsSQLCommond.ExecQuery(sSQL);
            //lookUp工序.Properties.DataSource = dtwork;
        }

        private void SetEnabled(bool b)
        {
            textEdit单据号.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;

            if (sState == "edit")
            {
                gridColTransformType.OptionsColumn.AllowEdit = false;
                gridColOpStatus.OptionsColumn.AllowEdit = false;

                gridCol移入工序.OptionsColumn.AllowEdit = false;
                gridCol合格数量.OptionsColumn.AllowEdit = false;
                gridCol报废数量.OptionsColumn.AllowEdit = false;
                gridCol拒绝数量.OptionsColumn.AllowEdit = false;
                gridCol报检数量.OptionsColumn.AllowEdit = false;
                gridCol加工数量.OptionsColumn.AllowEdit = false;
                gridColQcFlag.OptionsColumn.AllowEdit = false;
                gridColOutQcFlag.OptionsColumn.AllowEdit = false;
                gridCol是否瓶颈工序.OptionsColumn.AllowEdit = false;
                gridCol工厂.OptionsColumn.AllowEdit = false;
                gridCol定额工时.OptionsColumn.AllowEdit = false;
                gridColOutQcFlag.OptionsColumn.AllowEdit = false;
                gridColOutQcFlag.OptionsColumn.AllowEdit = false;
            }
            else
            {
                gridColTransformType.OptionsColumn.AllowEdit = true;
                gridColOpStatus.OptionsColumn.AllowEdit = true;

                gridCol移入工序.OptionsColumn.AllowEdit = true;
                gridCol合格数量.OptionsColumn.AllowEdit = true;
                gridCol报废数量.OptionsColumn.AllowEdit = true;
                gridCol拒绝数量.OptionsColumn.AllowEdit = true;
                gridCol报检数量.OptionsColumn.AllowEdit = true;
                gridCol加工数量.OptionsColumn.AllowEdit = true;
                gridColQcFlag.OptionsColumn.AllowEdit = true;
                gridColOutQcFlag.OptionsColumn.AllowEdit = true;
                gridCol是否瓶颈工序.OptionsColumn.AllowEdit = true;
                gridCol工厂.OptionsColumn.AllowEdit = true;
                gridCol定额工时.OptionsColumn.AllowEdit = true;
                gridColOutQcFlag.OptionsColumn.AllowEdit = true;
                gridColOutQcFlag.OptionsColumn.AllowEdit = true;
            }
        }

        private void GetNull()
        {
            gridControl1.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (e.RowHandle >= 0)
                iRow = e.RowHandle;
            string MoDId = "";
            if (gridView1.GetRowCellValue(iRow, gridColMoDId) != null)
            {
                MoDId=gridView1.GetRowCellValue(iRow, gridColMoDId).ToString();
            }
            string OpStatus = "";
            if (gridView1.GetRowCellValue(iRow, gridColOpStatus) != null)
            {
                OpStatus = gridView1.GetRowCellValue(iRow, gridColOpStatus).ToString();
            }
            string InMoRoutingDId = "";
            if (gridView1.GetRowCellValue(iRow, gridCol移入工序序号) != null)
            {
                InMoRoutingDId = gridView1.GetRowCellValue(iRow, gridCol移入工序序号).ToString();
            }
            string MoRoutingDId = "";
            if (gridView1.GetRowCellValue(iRow, gridColMoRoutingDId) != null)
            {
                MoRoutingDId = gridView1.GetRowCellValue(iRow, gridColMoRoutingDId).ToString();
            }
            string 移出工序 = "";
            if (gridView1.GetRowCellValue(iRow, gridCol移出工序) != null)
            {
                移出工序 = gridView1.GetRowCellValue(iRow, gridCol移出工序).ToString();
            }
            string 移入工序 = "";
            if (gridView1.GetRowCellDisplayText(iRow, gridCol移入工序) != null)
            {
                移入工序 = gridView1.GetRowCellDisplayText(iRow, gridCol移入工序).ToString();
            }
            if (e.Column == gridCol移出工序)
            {
                if (MoDId != "")
                {

                    if (移出工序 != "" && MoRoutingDId != "" && MoDId!="")
                    {
                        DataTable dt工作中心 = sfc.Get工序明细(MoRoutingDId, MoDId);
                        if (dt工作中心.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol移出工作中心, dt工作中心.Rows[0]["WcDescription"].ToString());
                            gridView1.SetRowCellValue(iRow, gridCol移出工序说明, dt工作中心.Rows[0]["Description"].ToString());
                            if (dt工作中心.Rows[0]["SubFlag"].ToString() == "True")
                            {
                                MessageBox.Show("委外工序已启用，委外工序正向移出状态不可为检验和加工");
                                gridView1.SetRowCellValue(iRow, gridCol移出工序, null);
                            }
                        }
                    }
                }
            }

            if (e.Column == gridCol移入工序序号 || e.Column == gridColOpStatus || e.Column == gridColMoDId)
            {
                if (MoDId != "" && OpStatus != "" && InMoRoutingDId != "")
                {
                    decimal qty = sfc.GetQty(MoDId, InMoRoutingDId, OpStatus);
                    gridView1.SetRowCellValue(iRow, gridCol可用数量, qty);
                }
            }

            if (e.Column == gridCol移入工序序号 || e.Column == gridColOpStatus)
            {
                if (MoDId != "" && InMoRoutingDId != "" && OpStatus != "")
                {
                    decimal qty = sfc.GetQty(MoDId, MoRoutingDId, OpStatus);
                    gridView1.SetRowCellValue(iRow, gridCol可用数量, qty);
                    if (移入工序 != "")
                    {
                        DataTable dt工作中心 = sfc.Get工序明细(InMoRoutingDId, MoDId);
                        if (dt工作中心.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol移入工作中心, dt工作中心.Rows[0]["WcDescription"].ToString());
                            gridView1.SetRowCellValue(iRow, gridCol移入工序说明, dt工作中心.Rows[0]["Description"].ToString());
                            if (dt工作中心.Rows[0]["SubFlag"].ToString() == "True")
                            {
                                MessageBox.Show("委外工序已启用，不可正向移入委外工序");
                                gridView1.SetRowCellValue(iRow, gridCol移入工序,null);
                            }
                        }
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, gridCol移入工作中心, null);
                    }
                }
            }
            
            if (e.Column == gridCol人员)
            {
                gridView1.SetRowCellValue(iRow, gridCol人员列表, "");
                gridView1.SetRowCellValue(iRow, gridCol工时列表, "");
            }

            #region
            if (e.Column != gridColiSave && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "add");
            }
            if (e.Column != gridColiSave && e.Column != gridColMoRoutingId && gridView1.GetRowCellDisplayText(iRow, gridColiSave).ToString().Trim() == "edit")
            {
                gridView1.SetRowCellValue(iRow, gridColiSave, "update");
            }
            #endregion
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

        private void textEdit单据号_Validated(object sender, EventArgs e)
        {
            try
            {
                string sBarCode = textEdit单据号.Text.Trim();
                if (sBarCode.Length == 0)
                {
                    return;
                }
                if (sBarCode.Length != 10)
                {
                    throw new Exception("条形码长度不正确");
                }
                sBarCode = ReturnObjectToLong(sBarCode).ToString().Trim();
                Add(sBarCode);
                textEdit单据号.Focus();
                textEdit单据号.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

        private void Add(string sBarCode)
        {
            bool b = false;
            if (sState == "edit")
            {
                throw new Exception("在修改状态下不可添加新工序转移单");
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, gridColMoRoutingDId).ToString().Trim() == sBarCode)
                {
                    b = true;
                }
            }
            if (b == true)
            {
                throw new Exception("条形码已存在");
            }
            else
            {
                string sSQL = @"select a.*,b.*,i.cInvCode,i.cInvName,i.cInvStd,mm.MoCode,m.SortSeq,isnull(e.Define35,0) as  是否瓶颈工序,
机床 as Define2, 人员 as  Define3,null as Define8 ,m.MoLotCode  as 零件号,AuxQty as 重量, m.Free1 as 材质 
from  @u8.sfc_morouting a 
left join @u8.sfc_moroutingdetail b on a.MoRoutingId =b.MoRoutingId 
left join @u8.mom_orderdetail m on b.MoDId=m.MoDId 
left join @u8.mom_order mm on mm.MoId=m.MoId
inner join @u8.sfc_moroutingdetail d on d.modid = m.modid
inner join @u8.sfc_operation e on e.OperationId = d.OperationId 
left join dbo.生产工序日计划 r on b.MoRoutingDId=r.生产订单工艺路线明细ID 
left join 生产工票打印 s on b.MoRoutingDId=s.MoRoutingDId
left join @u8.Inventory i on m.InvCode=i.cInvCode  where b.MoRoutingDId=" + sBarCode;


                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    gridView1.AddNewRow();
                    
                    int iRow = gridView1.RowCount - 1;
                    gridView1.FocusedRowHandle = iRow;
                    gridView1.SetRowCellValue(iRow, gridColDocCode, "");
                    gridView1.SetRowCellValue(iRow, gridColMoId, dt.Rows[0]["MoId"]);
                    gridView1.SetRowCellValue(iRow, gridColMoDId, dt.Rows[0]["MoDId"]);
                    gridView1.SetRowCellValue(iRow, gridColMoRoutingDId, dt.Rows[0]["MoRoutingDId"]);
                    gridView1.SetRowCellValue(iRow, gridColMoRoutingId, dt.Rows[0]["MoRoutingId"]);
                    gridView1.SetRowCellValue(iRow, gridColDocDate, DateTime.Now.ToString("yyyy-MM-dd"));
                    gridView1.SetRowCellValue(iRow, gridCol物料编码, dt.Rows[0]["cInvCode"]);
                    gridView1.SetRowCellValue(iRow, gridCol物料名称, dt.Rows[0]["cInvName"]);
                    gridView1.SetRowCellValue(iRow, gridCol物料规格, dt.Rows[0]["cInvStd"]);
                    gridView1.SetRowCellValue(iRow, gridCol移出工序, dt.Rows[0]["OpSeq"]);
                    gridView1.SetRowCellValue(iRow, gridColTransformType, "1");
                    gridView1.SetRowCellValue(iRow, gridColOpStatus, "1");
                    gridView1.SetRowCellValue(iRow, gridColQcFlag, true);
                    gridView1.SetRowCellValue(iRow, gridColOutQcFlag, true);
                    gridView1.SetRowCellValue(iRow, gridCol是否瓶颈工序, dt.Rows[0]["是否瓶颈工序"]);
                    gridView1.SetRowCellValue(iRow, gridCol零件号, dt.Rows[0]["零件号"]);
                    gridView1.SetRowCellValue(iRow, gridCol材质, dt.Rows[0]["材质"]);
                    gridView1.SetRowCellValue(iRow, gridCol重量, dt.Rows[0]["重量"]);
                    gridView1.SetRowCellValue(iRow, gridColiSave, "add");

                    sSQL = "select * from  @u8.sfc_moroutingdetail a where MoRoutingDId>'" + dt.Rows[0]["MoRoutingDId"] + "'";
                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                    if (ReturnObjectToDecimal(dt.Rows[0]["BalMachiningQty"], 0) > 0 || ReturnObjectToDecimal(dt.Rows[0]["BalDeclareQty"], 0) > 0)//移入本道合格数量
                    {
                        if (dts.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol移入工序序号, dt.Rows[0]["MoRoutingDId"]);
                            gridView1.SetRowCellValue(iRow, gridCol移入工序, dt.Rows[0]["OpSeq"]);
                            gridView1.SetRowCellValue(iRow, gridCol合格数量, dt.Rows[0]["BalMachiningQty"]);
                        }
                        gridView1.SetRowCellValue(iRow, gridColOpStatus, "1");

                    }
                    else if (ReturnObjectToDecimal(dt.Rows[0]["BalQualifiedQty"], 0) > 0)//移入下道完工数量
                    {
                        if (dts.Rows.Count > 0)
                        {
                            gridView1.SetRowCellValue(iRow, gridCol移入工序序号, dts.Rows[0]["MoRoutingDId"]);
                            gridView1.SetRowCellValue(iRow, gridCol移入工序, dts.Rows[0]["OpSeq"]);
                            
                        }
                        if (gridView1.GetRowCellValue(iRow, gridCol移入工作中心).ToString().Trim().IndexOf("热处理") > -1)//热处理转加工，其他转合格
                        {
                            gridView1.SetRowCellValue(iRow, gridColOpStatus, "1");
                            gridView1.SetRowCellValue(iRow, gridCol合格数量, dt.Rows[0]["BalMachiningQty"]);
                        }
                        else
                        {
                            gridView1.SetRowCellValue(iRow, gridColOpStatus, "3");
                            gridView1.SetRowCellValue(iRow, gridCol合格数量, dt.Rows[0]["BalQualifiedQty"]);
                        }

                    }
                }
                else
                {
                    throw new Exception("获得条码信息失败");
                }
                
            }
        }

        private void ItemButtonEdit移入工序_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;
            string MoDId = gridView1.GetRowCellValue(iRow, gridColMoDId).ToString();
            Frm工序_New frm = new Frm工序_New(MoDId);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol移入工序, frm.OpSeq);
                sSQL = @"select MoRoutingDId from  @u8.sfc_morouting a left join @u8.sfc_moroutingdetail b on a.MoRoutingId =b.MoRoutingId 
left join @u8.mom_orderdetail m on b.MoDId=m.MoDId 
left join dbo.生产工序日计划 r on b.MoRoutingDId=r.生产订单工艺路线明细ID 
left join @u8.Inventory i on m.InvCode=i.cInvCode where b.MoDId=" + MoDId + " and OpSeq=" + frm.OpSeq;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    gridView1.SetRowCellValue(iRow, gridCol移入工序序号, dt.Rows[0]["MoRoutingDId"]);
                }
                frm.Enabled = true;
            }
        }

        private void ItemButtonEdit人员_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;
            string 人员 = gridView1.GetRowCellValue(iRow, gridCol人员列表).ToString();
            string 人员工时 = "";
            if (gridView1.GetRowCellValue(iRow, gridCol工时列表) != null)
            {
                人员工时 = gridView1.GetRowCellValue(iRow, gridCol工时列表).ToString();
            }

            Frm人员工时_New frm = new Frm人员工时_New(人员, 人员工时);
            if (DialogResult.OK == frm.ShowDialog())
            {
                gridView1.SetRowCellValue(iRow, gridCol人员列表, frm.人员);
                gridView1.SetRowCellValue(iRow, gridCol工时列表, frm.工时);
                string[] sp1 = frm.工时.Split(',');
                decimal sum工时 = 0;
                for (int i = 0; i < sp1.Length; i++)
                {
                    sum工时 = sum工时 + ReturnObjectToDecimal(sp1[i], 2);
                }
                gridView1.SetRowCellValue(iRow, gridCol劳动工时, sum工时);
                frm.Enabled = true;
            }
        }

        private void textEdit单据号_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textEdit单据号_Validated(null, null);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle > 0)
                iRow = gridView1.FocusedRowHandle;
            if (gridView1.GetRowCellValue(iRow, gridColiSave) != null)
            {
                //if (gridView1.GetRowCellValue(iRow, gridColiSave).ToString() == "add" || gridView1.GetRowCellValue(iRow, gridColiSave).ToString() == "update" || gridView1.GetRowCellValue(iRow, gridColiSave).ToString() == "edit")
                //{
                //    if (gridView1.GetRowCellValue(iRow, gridCol人员列表) != null && gridView1.GetRowCellValue(iRow, gridCol人员列表).ToString() != "")
                //    {
                //        gridCol劳动工时.OptionsColumn.AllowEdit = false;
                //    }
                //    else
                //    {
                //        gridCol劳动工时.OptionsColumn.AllowEdit = true;
                //    }
                //}
                //else
                //{
                //    gridCol劳动工时.OptionsColumn.AllowEdit = false;
                //}

            }
        }

    }
}
