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
using System.Text.RegularExpressions;

namespace ImportDLL
{
    public partial class Frm生产工序排产2 : FrameBaseFunction.FrmFromModel
    {
        string tablename = "生产工序日计划Main";
        string tableid = "ID";
        //string tablecode = "cSOCode";
        string tablenames = "生产工序日计划";
        TH.DAL.sfc_optransform sfc = new TH.DAL.sfc_optransform();
        //public DataSet ds;

        long iID = -1;
        public string 单据号1 = "";
        public string 单据号2 = "";
        public string 制单日期1 = "";
        public string 制单日期2 = "";
        public string 审核日期1 = "";
        public string 审核日期2 = "";
        public string 物料1 = "";
        public string 物料2 = "";


        public Frm生产工序排产2(long siID)
        {
            iID = siID;
            InitializeComponent();

        }

        public Frm生产工序排产2()
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
            Frm生产工序排产_Add frm = new Frm生产工序排产_Add(单据号1, 单据号2, 制单日期1, 制单日期2, 审核日期1, 审核日期2, 物料1, 物料2);
            if (DialogResult.OK == frm.ShowDialog())
            {
                frm.Enabled = true;
                单据号1 = frm.单据号1;
                单据号2 = frm.单据号2;
                制单日期1 = frm.制单日期1;
                制单日期1 = frm.制单日期2;
                审核日期1 = frm.审核日期1;
                审核日期2 = frm.审核日期2;
                物料1 = frm.物料1;
                物料2 = frm.物料2;
                GetSel();
            }
        }

        private void GetSel()
        {
            string sSQL = "select * from  @u8.mom_order a left join ufdata_100_2014.dbo.mom_orderdetail b on a.MoId=b.MoId "
            + "left join (select 生产订单明细iID,max(制单日期) as 制单日期,max(审核日期) as 审核日期 from 生产工序日计划 group by 生产订单明细iID) c on b.MoDId=c.生产订单明细iID "
                + " where 1=1 and c.生产订单明细iID is not null";
            if (单据号1 != null && 单据号1 != "")
            {
                sSQL = sSQL + " and a.MoCode>='" + 单据号1 + "'";
            }
            if (单据号2 != null && 单据号2 != "")
            {
                sSQL = sSQL + " and a.MoCode<='" + 单据号2 + "'";
            }
            if (制单日期1 != null && 制单日期1 != "")
            {
                sSQL = sSQL + " and 制单日期>='" + 制单日期1 + "'";
            }
            if (制单日期2 != null && 制单日期2 != "")
            {
                sSQL = sSQL + " and 制单日期<='" + 制单日期2 + "'";
            }
            if (审核日期1 != "")
            {
                sSQL = sSQL + " and 审核日期>='" + 审核日期1 + "'";
            }
            if (审核日期2 != "")
            {
                sSQL = sSQL + " and 审核日期<='" + 审核日期2 + "'";
            }
            if (物料1 != "")
            {
                sSQL = sSQL + " and InvCode>='" + 物料1 + "'";
            }
            if (物料2 != "")
            {
                sSQL = sSQL + " and InvCode<='" + 物料2 + "'";
            }
            sSQL = sSQL + "  order by a.MoId";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            if (dtSel.Rows.Count > 0)
            {
                iID = Convert.ToInt64(dtSel.Rows[0]["MoDId"]);
                GetGrid();
            }
            else
            {
                btnLast();
            }

        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                sSQL = "select min(ID) as ID from " + tablename + "  where 1=1 ";

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
                    sSQL = "select ID as ID from " + tablename + " where ID<" + textEditID.EditValue.ToString().Trim() + "  ";
                    sSQL = sSQL + " order by ID desc";

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
                    sSQL = "select ID as ID from " + tablename + " where Id>" + textEditID.EditValue.ToString().Trim() + "  ";
                    sSQL = sSQL + " order by ID";

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
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                sSQL = "select isnull(max(ID),-1) as ID from " + tablename + " where 1=1 ";

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
            if (sState == "edit")
            {
                MessageBox.Show("单据已保存，不可修改");
            }
            else
            {
                Frm生产订单_New frm = new Frm生产订单_New((DataTable)gridControl1.DataSource);
                if (DialogResult.OK == frm.ShowDialog())
                {
                    frm.Enabled = true;
                    DataTable dt生产订单 = frm.dt;
                    gridControl3.DataSource = dt生产订单;
                    textEdit数量.EditValue =gridCol生产数量.SummaryText;
                    textEdit件数.EditValue = gridCol生产件数.SummaryText;
                    //dateEdit完工日期.EditValue = ReturnObjectToDatetime(gridCol完工日期.SummaryText).ToString("yyyy-MM-dd");
                    Get生产订单明细();
                }
            }
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
                gridView1.Focus();
            }
            catch { }
            dateEdit单据日期.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            dateEdit排产开始日期.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;

            gridView1.OptionsBehavior.Editable = true;
            sState = "add";
            btnAddRow();
            

        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (textEdit审核人.EditValue.ToString().Trim() != "")
            {
                throw new Exception("已审核，不能修改");
            } 
            sState = "edit";
            SetEnabled(true);
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (textEditID.Text.Trim() == "")
                throw new Exception("请选择需要删除的单据");

            if (textEditID.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }

            int iRe = CheState(textEditID.Text.Trim());
            if (iRe == -1)
            {
                throw new Exception("检查单据状态出错");
            }
            if (iRe == 0)
            {
                throw new Exception("单据不存在");
            }
            //if (iRe == 1)
            //{
            //    throw new Exception("单据已保存");
            //} 
            if (iRe == 2)
            {
                throw new Exception("单据已审核");
            }
            if (iRe == 3)
            {
                throw new Exception("单据已关闭");
            }

            DialogResult result = MessageBox.Show("是否删除?", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                string sErr = "";

                aList = new System.Collections.ArrayList();
                sSQL = "delete " + tablename + " where ID = '" + textEditID.EditValue.ToString().Trim() + "' ";
                aList.Add(sSQL);

                sSQL = "delete  " + tablenames + " where ID = '" + textEditID.EditValue.ToString().Trim() + "' ";
                aList.Add(sSQL);


                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                    btnLast();
                    sState = "del";
                }
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

            aList = new System.Collections.ArrayList();
            string sList = "";
            string sErr = "";
            
            if (gridView3.RowCount==0)
            {
                throw new Exception("请选择生产订单");
            }
            string s数量 = textEdit数量.EditValue.ToString().Trim();
            string s件数=textEdit件数.EditValue.ToString().Trim();
            string s存货编码 = textEdit物料编码.EditValue.ToString().Trim();
            if (sState == "add")
            {
                sSQL = "select isnull(max(ID),0)+1 as ID from " + tablename;
                iID = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));

                sSQL = @"insert into 生产工序日计划Main(ID,数量,件数,制单人,制单日期,单据日期,排产开始日期,批号范围,备注) values(
                '" + iID + "','" + s数量 + "','" + s件数 + "'," +
                   "'" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',"+
                   "'" + dateEdit单据日期.EditValue + "','" + dateEdit排产开始日期.EditValue + "','" + txt批号范围.EditValue.ToString().Trim() + "','" + txt备注.EditValue.ToString().Trim() + "')";
                aList.Add(sSQL);
            }
            else
            {
                iID = Convert.ToInt64(textEditID.Text);
                sSQL = "update 生产工序日计划Main set 数量='" + s数量 + "',件数='" + s件数 + "',单据日期='" + dateEdit单据日期.EditValue + "',排产开始日期='" + dateEdit排产开始日期.EditValue + "'  "+
                    ",批号范围='" + txt批号范围.EditValue.ToString().Trim() + "',备注='" + txt备注.EditValue.ToString().Trim() + "'"
                    + "where ID='" + iID + "'";
                aList.Add(sSQL);
            }

            for (int j = 0; j < gridView3.RowCount; j++)
            {
                string 生产订单明细ID = gridView3.GetRowCellValue(j, gridCol生产订单明细ID).ToString().Trim();
                string 数量 = gridView3.GetRowCellValue(j, gridCol生产数量).ToString().Trim();
                string 件数 = gridView3.GetRowCellValue(j, gridCol生产件数).ToString().Trim();
                sSQL = "select * from 生产工序日计划 where 生产订单明细iID='" + 生产订单明细ID + "'";
                DataTable dt日计划 = clsSQLCommond.ExecQuery(sSQL);

                DataTable dt工序明细 = sfc.Get工序明细("", 生产订单明细ID);

                for (int i = 1; i < gridView1.Columns.Count; i++)
                {
                    string 工序代号 = gridView1.Columns[i].FieldName.Split('_')[1];
                    //string 工作中心 = gridView1.Columns[i].FieldName.Split('_')[2];
                    //string 标准工序 = gridView1.Columns[i].FieldName.Split('_')[3];
                    string 工作中心 = "";
                    string 标准工序 = "";
                    string Caption = gridView1.Columns[i].Caption;
                    string 天数 = gridView1.GetRowCellValue(0, gridView1.Columns[i]).ToString();
                    if (天数 == "0" || 天数 == "")
                    {
                        sErr = sErr + "行" + (i + 1) + Caption + "未填写\n";
                        continue;
                    }
                    string 计划生产开工日期 = gridView1.GetRowCellValue(1, gridView1.Columns[i]).ToString();
                    string 计划生产完工日期 = gridView1.GetRowCellValue(2, gridView1.Columns[i]).ToString();
                    string 备注 = gridView1.GetRowCellValue(3, gridView1.Columns[i]).ToString();
                    string 生产订单工艺路线明细ID = "";
                    DataRow[] dw工序明细 = dt工序明细.Select("OpSeq='" + 工序代号 + "'");
                    if (dw工序明细.Length > 0)
                    {
                        生产订单工艺路线明细ID = dw工序明细[0]["MoRoutingDId"].ToString().Trim();
                    }
                    DataRow[] dw = dt日计划.Select("工序代号='" + 工序代号 + "'");
                    if (dw.Length == 0)
                    {
                        sSQL = @"insert into 生产工序日计划(ID,生产订单明细iID,生产订单工艺路线明细ID,存货编码,排产日期,计划生产开工日期,计划生产完工日期,计划生产天数,备注,制单人,制单日期,CreateDate,数量,件数,工序代号,工作中心,标准工序)
                        values('" + iID + "','" + 生产订单明细ID + "','" + 生产订单工艺路线明细ID + "','" + s存货编码 + "','" + dateEdit单据日期.EditValue + "','" + 计划生产开工日期 + "','" + 计划生产完工日期 + "',"
                        + "'" + 天数 + "','" + 备注 + "','" + FrameBaseFunction.ClsBaseDataInfo.sUid + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + 数量 + "','" + 件数 + "','" + 工序代号 + "','" + 工作中心 + "','" + 标准工序 + "')";
                        aList.Add(sSQL);
                    }
                    else
                    {
                        sSQL = "update 生产工序日计划 set 存货编码='" + s存货编码 + "',排产日期='" + dateEdit单据日期.EditValue + "',计划生产开工日期='" + 计划生产开工日期 + "',计划生产完工日期='" + 计划生产完工日期 + "', "
                        + "计划生产天数='" + 天数 + "',备注='" + 备注 + "',数量='" + 数量 + "',件数='" + 件数 + "',工序代号='" + 工序代号 + "',工作中心='" + 工作中心 + "',标准工序='" + 标准工序 + "' "
                        + "where iID='" + dw[0]["iID"].ToString() + "'";
                        aList.Add(sSQL);
                    }

                }

                sSQL = "update @u8.mom_orderdetail set Define29='" + txt批号范围.Text.Trim() + "' where MoDId='" + 生产订单明细ID + "'";
                aList.Add(sSQL);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MsgBox("保存成功", sErr + "\n" + sList);
                GetGrid();
                sState = "sel";
            }
            else
            {
                throw new Exception(sErr);
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
            if (textEditID.Text == "")
            {
                throw new Exception("无需审核的生产订单");
            }

            sSQL = "select * from 生产工序日计划 where ID='" + textEditID.EditValue + "' and 审核人 is null";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            int i = dt.Rows.Count;
            if (i > 0)
            {
                aList = new System.Collections.ArrayList();

                sSQL = "update 生产工序日计划 set 审核日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "',审核人='" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' where ID='" + textEditID.EditValue + "' ";
                aList.Add(sSQL);
                sSQL = "update 生产工序日计划Main set 审核日期='" + DateTime.Now.ToString("yyyy-MM-dd") + "',审核人='" + FrameBaseFunction.ClsBaseDataInfo.sUid + "' where ID='" + textEditID.EditValue + "' ";
                aList.Add(sSQL);
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功");
                GetGrid();
            }
            else
            {
                MessageBox.Show("请选择需要审核的数据");
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            if (textEditID.Text == "")
            {
                throw new Exception("无需弃审的生产订单");
            }

            sSQL = "select * from 生产工序日计划Main where ID='" + textEditID.EditValue + "' and 审核人 is not null";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            int i = dt.Rows.Count;
            if (i > 0)
            {
                aList = new System.Collections.ArrayList();

                sSQL = "update 生产工序日计划 set 审核日期=null,审核人=null where ID='" + textEditID.EditValue + "' ";
                aList.Add(sSQL);

                sSQL = "update 生产工序日计划Main set 审核日期=null,审核人=null where ID='" + textEditID.EditValue + "' ";
                aList.Add(sSQL);
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功");
                GetGrid();
            }
            else
            {
                MessageBox.Show("请选择需要弃审的数据");
            }
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

        }

        #endregion

        private void Frm生产工序排产2_Load(object sender, EventArgs e)
        {
            try
            {
                //SetEnabled(false);
                SetLookUpEdit();
                //GetNull();
                if (iID != -1)
                {
                    GetGrid();
                }
                else
                {
                    btnLast();
                }
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
                string sSQL = @"select a.*,u1.vchrName as s制单人,u2.vchrName as s审核人,convert(varchar(10),单据日期,120) as s单据日期,
convert(varchar(10),制单日期,120) as s制单日期,convert(varchar(10),审核日期,120) as s审核日期,convert(varchar(10),排产开始日期,120) as s排产开始日期 from " + tablename + " a "
                + @"left join _UserInfo u1 on a.制单人=u1.vchrUid left join _UserInfo u2 on a.审核人=u2.vchrUid where  ID=" + iID;
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    textEditID.EditValue = Convert.ToInt64(dt.Rows[0]["ID"]);

                    dateEdit单据日期.EditValue = dt.Rows[0]["s单据日期"].ToString();
                    dateEdit排产开始日期.EditValue = dt.Rows[0]["s排产开始日期"].ToString();
                    dateEdit制单日期.EditValue = dt.Rows[0]["s制单日期"].ToString();
                    dateEdit审核日期.EditValue = dt.Rows[0]["s审核日期"].ToString();

                    textEdit制单人.EditValue = dt.Rows[0]["s制单人"].ToString();
                    textEdit审核人.EditValue = dt.Rows[0]["s审核人"].ToString();
                    txt批号范围.EditValue = dt.Rows[0]["批号范围"].ToString();
                    txt备注.EditValue = dt.Rows[0]["备注"].ToString();

                    sSQL = @"select a.*,b.*,i.cInvCode,i.cInvName,i.cInvStd,c.StartDate,c.DueDate, cast(0 as bit) as iChk from  
@u8.mom_orderdetail a 
left join @u8.mom_order b on a.MoId=b.MoId
left join @u8.mom_morder c on a.MoDId=c.MoDId
left join @u8.Inventory i on a.InvCode=i.cInvCode left join (select ID,生产订单明细iID from 生产工序日计划 group by ID,生产订单明细iID) e on a.MoDId=e.生产订单明细iID where e.ID ='" + iID + "'  ";
                    DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                    gridControl3.DataSource = dts;

                    Get生产订单明细();
                }
                else
                {
                    GetNull();
                }
            }
            else
            {
                GetNull();
            }
            SetEnabled(false);
            sState = "sel";
        }


        /// <summary>
        /// 下拉列表框
        /// </summary>
        private void SetLookUpEdit()
        {
            
        }

        private void SetEnabled(bool b)
        {
            dateEdit单据日期.Enabled = b;
            txt备注.Enabled = b;
            txt批号范围.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;
            gridView3.OptionsBehavior.Editable = false;
            dateEdit排产开始日期.Enabled = b;
        }

        private void GetNull()
        {
            textEdit制单人.EditValue = "";
            textEdit审核人.EditValue = "";
            dateEdit制单日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            textEdit规格型号.EditValue = "";
            textEdit件数.EditValue = "";
            textEdit数量.EditValue = "";
            textEdit物料编码.EditValue = "";
            textEdit物料名称.EditValue = "";
            dateEdit排产开始日期.EditValue = DBNull.Value;
            dateEdit审核日期.EditValue = DBNull.Value;
            txt备注.EditValue = "";
            txt批号范围.EditValue = "";
            dateEdit单据日期.EditValue = DBNull.Value;
            gridControl1.DataSource = null;
            gridControl3.DataSource = null;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;
            gridView1.FocusedRowHandle = 1;

            if (dateEdit排产开始日期.EditValue.ToString() != "" && iRow == 0)
            {
                if (gridView1.GetRowCellValue(iRow, e.Column) != null)
                {
                    string 天数 = gridView1.GetRowCellValue(iRow, e.Column).ToString().Trim();
                    string regexString = @"^[0-9]$|^[1-2][0-9]$|^3[0-6]$";
                    if (Regex.IsMatch(天数, regexString) == false)
                    {
                        gridView1.SetRowCellValue(0, e.Column, null);
                        throw new Exception("请输入正确的天数");

                    }
                    Get排产();
                }
            }

        }

        private void Get排产()
        {
            if (sState == "add" || sState == "edit")
            {
                DataTable dtday = clsSQLCommond.ExecQuery("select * from Holidays");

                DateTime d = ReturnObjectToDatetime(dateEdit排产开始日期.EditValue.ToString());
                for (int i = 1; i <= gridView1.Columns.Count - 1; i++)
                {
                    int d1 = ReturnObjectToInt(gridView1.GetRowCellValue(0, gridView1.Columns[i]));
                    if (d1 != 0)
                    {
                        gridView1.SetRowCellValue(1, gridView1.Columns[i], d.ToString("yyyy-MM-dd"));
                        d = d.AddDays(d1 - 1);

                        gridView1.SetRowCellValue(2, gridView1.Columns[i], d.ToString("yyyy-MM-dd"));
                        d = d.AddDays(1);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(1, gridView1.Columns[i], null);
                    }
                }
                string sErr = "";
                for (int i = 2; i < gridView1.Columns.Count; i++)
                {
                    decimal i当前天数 = 1;
                    DateTime d1 = ReturnObjectToDatetime(gridView1.GetRowCellValue(1, gridView1.Columns[i]));
                    DateTime d2 = ReturnObjectToDatetime(gridView1.GetRowCellValue(2, gridView1.Columns[i]));
                    string 工序代号 = gridView1.Columns[i].FieldName.Split('_')[1];
                    string 工作中心 = gridView1.Columns[i].FieldName.Split('_')[2];
                    string Description = gridView1.Columns[i].Caption.Trim();
                    string sErr1 = "工作中心:" + 工作中心 + ";    工序:" + 工序代号 + "[" + Description + "]" + ",    ";
                    string 产能 = "";
                    string sErr2 = "";
                    for (DateTime j = d1; j <= d2; j = j.AddDays(1))
                    {
                        decimal i基础天数 = 0;
                        decimal i已用天数 = 0;
                        if (GetCheck(工序代号, j, i当前天数, out i基础天数, out i已用天数) == false)
                        {
                            sErr2 = sErr2 + "日期" + j.ToString("yyyy-MM-dd") + ",    超出产能" + ((i当前天数 + i已用天数) * 8 - i基础天数) + "小时,\n";
                            产能 = i基础天数.ToString();
                        }
                    }
                    sErr1 = sErr1 + "产能:" + 产能 + "小时\n";
                    if (sErr2 != "")
                    {
                        sErr = sErr + sErr1 + sErr2 + "\n";
                    }
                }
                if (sErr != "")
                {
                    MessageBox.Show(sErr);
                }
            }
        }

        private bool GetCheck(string 工序代号, DateTime i日期, decimal i当前天数, out decimal i基础天数, out decimal i已用天数)
        {
            string sSQL = "select isnull(sum(iDays),0) as iDays from dbo.Workcenter a left join (select * from EQ where dDate='" + i日期.ToString("yyyy-MM-dd") + "' and State='1') b on a.cEQCode=b.cEQCode where [LineNo]='" + 工序代号 + "'";
            DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);
            i基础天数 = ReturnObjectToDecimal(dtTemp.Rows[0]["iDays"].ToString(), 2);
            sSQL = "select ID,工序代号 from 生产工序日计划 where 工序代号='" + 工序代号 + "' and 计划生产开工日期>='" + i日期 + "' and  计划生产完工日期<='" + i日期 + "' ";
            if(textEditID.Text.ToString().Trim()!="")
            {
                sSQL = sSQL + " and ID<>'" + textEditID.Text.ToString().Trim() + "'";
            }
            sSQL = sSQL + " group by ID,工序代号";
            DataTable dt1 = clsSQLCommond.ExecQuery(sSQL);
            i已用天数 = dt1.Rows.Count;
            if (i基础天数 < (i当前天数 + i已用天数) * 8)
            {
                return false;
            }
            return true;
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

        private void AddCol(string MoRoutingDId, string Description)
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = Description;
            gridColumn1.Name = "gridCol_" + MoRoutingDId;
            gridColumn1.FieldName = "gridCol_" + MoRoutingDId;
            gridColumn1.Visible = true;
            gridColumn1.Width = 100;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            //gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
            gridView1.Columns.Add(gridColumn1);

        }

        private void AddCol()
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn1.Caption = " ";
            gridColumn1.Name = "Type";
            gridColumn1.FieldName = "Type";
            gridColumn1.Visible = true;
            gridColumn1.VisibleIndex = gridView1.Columns.Count;
            gridColumn1.Width = 100;
            //gridColumn1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum) });
            gridView1.Columns.Add(gridColumn1);

        }


        private void textEdit生产订单明细ID_EditValueChanged(object sender, EventArgs e)
        {
            Get生产订单明细();
        }

        private void Get生产订单明细()
        {
            if (gridView3.RowCount > 0)
            {
                string 生产订单明细ID = gridView3.GetRowCellValue(0, gridCol生产订单明细ID).ToString().Trim();
                if (textEditID.Text != "")
                {
                    sSQL = @"select a.*,b.*,i.cInvCode,i.cInvName,i.cInvStd,c.StartDate,c.DueDate from  
@u8.mom_orderdetail a 
left join @u8.mom_order b on a.MoId=b.MoId
left join @u8.mom_morder c on a.MoDId=c.MoDId
left join @u8.Inventory i on a.InvCode=i.cInvCode where a.MoDId=" + 生产订单明细ID;
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        //textEdit生产订单号.EditValue = dt.Rows[0]["MoCode"].ToString();

                        textEdit物料编码.EditValue = dt.Rows[0]["cInvCode"].ToString();
                        textEdit物料名称.EditValue = dt.Rows[0]["cInvName"].ToString();
                        textEdit规格型号.EditValue = dt.Rows[0]["cInvStd"].ToString();
                        textEdit数量.EditValue = dt.Rows[0]["Qty"].ToString();
                        textEdit件数.EditValue = dt.Rows[0]["AuxQty"].ToString();
                        //dateEdit完工日期.EditValue = DateTime.Parse(dt.Rows[0]["DueDate"].ToString()).ToString("yyyy-MM-dd");
                        //textEdit生产订单行号.EditValue = dt.Rows[0]["SortSeq"].ToString();
                    }


                    DataTable dts = sfc.Get工序明细("", 生产订单明细ID);

                    for (int i = gridView1.Columns.Count - 1; i >= 0; i--)
                    {
                        gridView1.Columns.Remove(gridView1.Columns[i]);
                    }
                    dtBingGrid = new DataTable();
                    dtBingGrid.Columns.Add("Type");

                    AddCol();
                    dtBingGrid.Columns.Add("gridCol_0000");
                    AddCol("0000","坯料");
                    for (int i = 0; i < dts.Rows.Count; i++)
                    {
                        dtBingGrid.Columns.Add("gridCol_" + dts.Rows[i]["OpSeq"].ToString());
                        AddCol(dts.Rows[i]["OpSeq"].ToString(), dts.Rows[i]["Description"].ToString());
                    }

                    for (int i = 0; i <= 5; i++)
                    {
                        DataRow dw = dtBingGrid.NewRow();
                        dtBingGrid.Rows.Add(dw);
                    }
                    dtBingGrid.Rows[0][0] = "安排加班天数";
                    dtBingGrid.Rows[1][0] = "计划开始日期";
                    dtBingGrid.Rows[2][0] = "计划完成日期";
                    dtBingGrid.Rows[3][0] = "异常情况说明";
                    dtBingGrid.Rows[4][0] = "是否已完工";
                    dtBingGrid.Rows[5][0] = "完工工时";

                    sSQL = "select * from 生产工序日计划 a left join  生产工序日计划Main b on a.ID=b.ID where 生产订单明细iID='" + 生产订单明细ID + "'";
                    DataTable dt日计划 = clsSQLCommond.ExecQuery(sSQL);
                    for (int i = 0; i < dt日计划.Rows.Count; i++)
                    {
                        string 工序代号 = dt日计划.Rows[i]["工序代号"].ToString();
                        string 工作中心 = dt日计划.Rows[i]["工作中心"].ToString();
                        string 标准工序 = dt日计划.Rows[i]["标准工序"].ToString();

                        dtBingGrid.Rows[0]["gridCol_" + 工序代号] = dt日计划.Rows[i]["计划生产天数"];
                        dtBingGrid.Rows[1]["gridCol_" + 工序代号] = ReturnObjectToDatetime(dt日计划.Rows[i]["计划生产开工日期"]).ToString("yyyy-MM-dd");
                        dtBingGrid.Rows[2]["gridCol_" + 工序代号] = ReturnObjectToDatetime(dt日计划.Rows[i]["计划生产完工日期"]).ToString("yyyy-MM-dd");
                        dtBingGrid.Rows[3]["gridCol_" + 工序代号] = dt日计划.Rows[i]["备注"];
                        dtBingGrid.Rows[4]["gridCol_" + 工序代号] = "";

                        if (i > 0)
                        {
                            DataRow[] dw = dts.Select("OpSeq='" + 工序代号 + "'");
                            if (dw.Length > 0)
                            {
                                if (ReturnObjectToDecimal(dw[0]["未完成数量"].ToString(), 2) == 0)
                                {
                                    dtBingGrid.Rows[4]["gridCol_" + 工序代号 + "_" + 工作中心 + "_" + 标准工序] = "已完工";
                                }
                            }
                            sSQL = "select sum(Define16) as 工时 from ufdata_100_2014.dbo.sfc_optransform  where MoRoutingDId='" + dt日计划.Rows[i]["生产订单工艺路线明细ID"].ToString() + "'";
                            DataTable dt2 = clsSQLCommond.ExecQuery(sSQL);
                            if (dt2.Rows.Count > 0)
                            {
                                dtBingGrid.Rows[5]["gridCol_" + 工序代号] = dt2.Rows[0]["工时"];
                            }
                        }

                    }

                    gridControl1.DataSource = dtBingGrid;
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ((e.FocusedRowHandle == 0 || e.FocusedRowHandle == 3) && (sState == "add" || sState=="edit"))
            {
                gridView1.OptionsBehavior.Editable = true;
            }
            else
            {
                gridView1.OptionsBehavior.Editable = false;
            }
        }
        /// <summary>
        /// 判断单据状态
        /// </summary>
        /// <param name="sCode">单据号</param>
        /// <returns>-1：出错</returns>
        /// <returns>0 ：不存在单据</returns>
        /// <returns>1 ：已保存</returns>
        /// <returns>2 ：已审核</returns>
        /// <returns>3 ：已关闭</returns>
        private int CheState(string sCode)
        {
            int iReturn = -1;
            try
            {
                sSQL = "select  isnull(制单人,'') as 制单人,isnull(审核人,'') as 审核人 from " + tablename + " where ID = '" + sCode + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count < 1)
                    iReturn = 0;
                else
                {
                    if (dt.Rows[0]["制单人"].ToString().Trim() != "")
                    {
                        iReturn = 1;
                    }
                    if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                    {
                        iReturn = 2;
                    }
                }
            }
            catch (Exception ee)
            { }
            return iReturn;
        }

        private void dateEdit排产开始日期_EditValueChanged(object sender, EventArgs e)
        {
            Get排产();
        }
    }
}
