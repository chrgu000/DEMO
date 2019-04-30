using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;
using System.Xml;

namespace ImportDLL
{
    public partial class Frm开料单 : FrameBaseFunction.FrmBaseInfo
    {
        public string 开料单号1;
        public string 开料单号2;
        public string 开料日期1;
        public string 开料日期2;
        decimal d密度 = (decimal)3.14;

        public Frm开料单()
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
                    case "add":
                        btnAdd();
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

        private void btnAdd()
        {
            Frm开料单_Add fAdd = new Frm开料单_Add();
            fAdd.ShowDialog();
            if (fAdd.DialogResult == DialogResult.OK)
            {
                txt开料单号.Text = "";
                string sAutoID = fAdd.sAutoID;
                //销售订单信息
                sSQL = @"select a.cSOCode,b.iRowNo,b.autoid,b.cDefine28,case when right(b.cInvCode,1)='A' then left(b.cInvCode,len(b.cInvCode)-1) else b.cInvCode end  cInvCode,d.cInvName,d.cInvStd,b.cDefine34 as isum,b.cItemCode,a.cDefine2,b.dPreDate,a.cCusCode,c.cCusName,b.dPreMoDate,b.cDefine36,b.iQuantity,b.iNum,d.cInvDefine13,b.cDefine33,a.cMemo 
                        from @u8.SO_SODetails b INNER JOIN @u8.SO_SOMain a ON a.ID = b.ID left join @u8.Customer c on a.cCusCode = c.cCusCode left join @u8.Inventory d on (case when right(b.cInvCode,1)='A' then left(b.cInvCode,len(b.cInvCode)-1) else b.cInvCode end)=d.cInvCode 
                        where b.autoid = " + sAutoID+"";
                DataTable dtSO = clsSQLCommond.ExecQuery(sSQL);
                if (dtSO == null || dtSO.Rows.Count < 1)
                {
                    throw new Exception("获得销售订单失败");
                }

                try
                {
                    SetTextNull();
                }
                catch
                {
                }

                string s1 = ""; ; string s2 = ""; string s3 = "";
                GetSize(dtSO.Rows[0]["cDefine28"].ToString().Trim(), out s1, out s2, out s3);
                if (dtSO.Rows[0]["cDefine28"].ToString().Trim().Split('*').Length == 2)
                {
                    lookUpEdit材料类型.EditValue = "棒";
                }
                else
                {
                    lookUpEdit材料类型.EditValue = "板";
                }
                //if (s1 == "")
                //{
                //    throw new Exception("材料厚度，宽度，长度必须设置");
                //}

                lookUpEdit公司名称.EditValue = dtSO.Rows[0]["cCusCode"].ToString().Trim();
                if (s1 != "")
                {
                    txt厚度2.Text = ReturnDecimal(s1,3).ToString();
                }
                else
                {
                    txt厚度2.Text = "1";
                }
                if (s2 != "")
                {
                    txt宽度2.Text = ReturnDecimal(s2, 2).ToString();
                }
                else
                {
                    txt宽度2.Text = "2";
                }
                if (s3 != "")
                {
                    txt长度2.Text = ReturnDecimal(s3, 3).ToString();
                }
                else
                {
                    txt长度2.Text = "3";
                }
                txt存货编码.Text = dtSO.Rows[0]["cInvCode"].ToString().Trim();
                txt合金属性.Text = dtSO.Rows[0]["cInvName"].ToString().Trim();
                txt交货说明.Text = dtSO.Rows[0]["cMemo"].ToString().Trim();
                if (dtSO.Rows[0]["isum"].ToString().Trim() != "")
                {
                    txt数量2.Text = Math.Round(double.Parse(dtSO.Rows[0]["isum"].ToString().Trim()), 0).ToString();
                    sSQL = "select sum(数量2) from @u8.开料单表头 where 销售订单ID= " + sAutoID;
                    DataTable dthave = clsSQLCommond.ExecQuery(sSQL);
                    if (dthave.Rows.Count > 0)
                    {
                        if(dthave.Rows[0][0].ToString()!="")
                        {
                            txt数量2.Text = Math.Round(double.Parse(dtSO.Rows[0]["isum"].ToString().Trim()) - double.Parse(dthave.Rows[0][0].ToString()), 0).ToString();
                        }
                            
                    }

                }
                txt销售订单子表ID.Text = dtSO.Rows[0]["AutoID"].ToString().Trim();

                dtm交货日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dtm切割日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                dtm算料日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                txt算料人.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                if (dtSO.Rows[0]["cInvDefine13"].ToString().Trim() != "")
                {
                    txt密度.Text = Math.Round(double.Parse(dtSO.Rows[0]["cInvDefine13"].ToString().Trim()), 2).ToString();
                }
                
                if (dtSO.Rows[0]["cDefine33"].ToString() != "")
                {
                    txt产品密度.Text = Math.Round(double.Parse(dtSO.Rows[0]["cDefine33"].ToString().Trim()), 2).ToString();
                }

                SetEnable(true);
                sSQL = "SELECT     a.开料单号, a.公司编码, a.交货日期, a.交货说明, convert(float,a.密度) as 密度, a.合金属性, a.切割员,a.大锯床签字,a.带锯床签字,a.推锯床签字,a.厂长签字,a.切割日期, a.算料人, convert(varchar(10),a.算料日期,120) as 算料日期, b.iID, b.类型, b.存放区域, " +
                                              "b.存货编码1, b.序列号1, convert(float,b.厚度1) as 厚度1, convert(float,b.宽度1) as 宽度1, convert(float ,b.长度1) as 长度1, convert(float,b.数量1) as 数量1, convert(float,b.厚度2) as 厚度2, convert(float,b.宽度2) as 宽度2, convert(float,b.长度2) as 长度2, b.数量2,  b.存货编码3, b.序列号3, convert(float,b.厚度3) as 厚度3, convert(float,b.宽度3) as 宽度3, convert(float,b.长度3) as 长度3, b.数量3, " +
                                              "b.存放区域3,isnull('" + txt密度.Text.Trim() + "',0)*isnull(b.长度1,0)*isnull(b.宽度1,0)*isnull(b.厚度1,0) as  重量1," +
                                              "isnull('" + txt密度.Text.Trim() + "',0)*isnull(b.长度2,0)*isnull(b.宽度2,0)*isnull(b.厚度2,0) as  重量2," +
                                              "isnull('" + txt密度.Text.Trim() + "',0)*isnull(b.长度3,0)*isnull(b.宽度3,0)*isnull(b.厚度3,0) as  重量3 " +
                        "FROM         @u8.开料单表头 AS a INNER JOIN " +
                                              "@u8.开料单表体 AS b ON a.开料单号 = b.开料单号 " +
                        "WHERE        1=-1";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = 0;
                GetIDList();


                sState = "add";
            }
            else
            {
                throw new Exception(" 未新增单据! \n\n原因:\n  ");
            }
        }

        private void SetText(string sCode)
        {
            string sSQL = "select * from @u8.开料单表头 where 开料单号 = '" + sCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                //lookUpEdit合金属性.EditValue = dt.Rows[0]["合金属性"].ToString().Trim();
                txt厚度2.Text = dt.Rows[0]["厚度2"].ToString().Trim();
                txt交货说明.Text = dt.Rows[0]["交货说明"].ToString().Trim();
                txt存货编码.Text = dt.Rows[0]["存货编码"].ToString().Trim();
                sSQL = "select * from  @u8.Inventory where cInvCode='" + dt.Rows[0]["存货编码"].ToString().Trim() + "'";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                txt合金属性.Text = dts.Rows[0]["cInvName"].ToString().Trim();
                txt开料单号.Text = dt.Rows[0]["开料单号"].ToString().Trim();
                txt宽度2.Text = dt.Rows[0]["宽度2"].ToString().Trim();
                txt密度.Text = dt.Rows[0]["密度"].ToString().Trim();
                txt产品密度.Text = dt.Rows[0]["产品密度"].ToString().Trim();
                txt切割员.Text = dt.Rows[0]["切割员"].ToString().Trim();
                text大锯床签字.Text = dt.Rows[0]["大锯床签字"].ToString().Trim();
                text带锯床签字.Text = dt.Rows[0]["带锯床签字"].ToString().Trim();
                text推锯床签字.Text = dt.Rows[0]["推锯床签字"].ToString().Trim();
                text厂长签字.Text = dt.Rows[0]["厂长签字"].ToString().Trim();
                txt数量2.Text = dt.Rows[0]["数量2"].ToString().Trim();
                txt算料人.Text = dt.Rows[0]["算料人"].ToString().Trim();
                txt长度2.Text = dt.Rows[0]["长度2"].ToString().Trim();
                lookUpEdit公司名称.EditValue = dt.Rows[0]["公司编码"].ToString().Trim();
                dtm交货日期.Text = Convert.ToDateTime(dt.Rows[0]["交货日期"]).ToString("yyyy-MM-dd");
                timeEdit交货时间.Text = Convert.ToDateTime(dt.Rows[0]["交货日期"]).ToString("hh:mm:ss");
                dtm切割日期.Text = dt.Rows[0]["切割日期"].ToString().Trim();
                dtm算料日期.Text = dt.Rows[0]["算料日期"].ToString().Trim();
                txt销售订单子表ID.Text = dt.Rows[0]["销售订单ID"].ToString().Trim();
            }

            sSQL = "select * from @u8.开料单表体 where 开料单号 = '" + sCode + "' order by iID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }

        private void SetTextNull()
        {
            txt开料单号.Text = "";
            GetGrid(""); 
            
            //lookUpEdit合金属性.EditValue = null;
            txt厚度2.Text = null;
            txt交货说明.Text = "";
            
            txt宽度2.Text = "";
            txt密度.Text = "";
            txt产品密度.Text = "";
            txt切割员.Text = "";
            text厂长签字.Text = "";
            text大锯床签字.Text = "";
            text带锯床签字.Text = "";
            text推锯床签字.Text = "";
            txt数量2.Text = "";
            txt算料人.Text = "";
            txt长度2.Text = "";
            lookUpEdit公司名称.EditValue = null;
            dtm交货日期.Text = "";
            timeEdit交货时间.Text = "";
            dtm切割日期.Text = "";
            txt销售订单子表ID.Text = "";

            textEdit原始尺寸材料重量.Text = "";
            textEdit原始尺寸产品重量.Text = "";
            textEdit剩下尺寸材料重量.Text = "";
            textEdit剩下尺寸产品重量.Text = "";
            textEdit切割材料重量.Text = "";
            textEdit切割产品重量.Text = "";

            txt审核.Text = "";
            dtm审核日期.Text = "";

            txt记账.Text = "";
            dtm记账日期.Text = "";

            sSQL = "select * from @u8.开料单表体 where 1 = -1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            gridControl1.DataSource = dt;
        }


        #region 按钮模板

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

            //base.dsPrint.Tables.Clear();
            //DataTable dtGrid = SetPrintData(((DataTable)gridControl1.DataSource).Copy());
            //dtGrid.TableName = "dtGrid";

            //base.dsPrint.Tables.Add(dtGrid);
            //DataTable dtHead = dtBingHead.Copy();
            //dtHead.TableName = "dtHead";
            //base.dsPrint.Tables.Add(dtHead);
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
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            try
            {
                string sSQL = "select * from @u8.开料单表头 where 开料单号 = '" + txt开料单号.Text.Trim() + "'";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt == null || dt.Rows.Count == 0)
                {
                    throw new Exception("获得开料单信息失败");
                }
                else
                {
                    if (dt.Rows[0]["审核"].ToString().Trim() == "")
                    {
                        throw new Exception("单据尚未审核，不能打印");
                    }
                }

                Replist2 rep = new Replist2();
                if (base.dsPrint.Tables[0].Rows.Count > 0 && base.dsPrint.Tables[1].Rows.Count > 0)
                {

                    rep.dsPrint.Tables.Clear();
                    DataTable dthead = base.dsPrint.Tables[0].Copy();

                    dthead.TableName = "dtHead";
                    DataTable dtGrid = base.dsPrint.Tables[1].Copy();
                    dtGrid.TableName = "dtGrid";
                    rep.dsPrint.Tables.Add(dthead);
                    rep.dsPrint.Tables.Add(dtGrid);
                    rep.ShowPreview();
                }
            }
            catch(Exception ee)
            {

                MessageBox.Show("开料单打印失败：" + ee.Message); ;
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            GetLookUp();
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm开料单_Add1 frm = new Frm开料单_Add1();
            frm.Get(开料单号1, 开料单号2, 开料日期1, 开料日期2);
            if (DialogResult.OK == frm.ShowDialog())
            {

                frm.Enabled = true;
                开料单号1 = frm.开料单号1;
                开料单号2 = frm.开料单号2;
                开料日期1 = frm.开料日期1;
                开料日期2 = frm.开料日期2;
            }
            GetSel();
            开料单号1 = "";
            开料单号2 = "";
            开料日期1 = "";
            开料日期2 = "";
        }

        private void GetSel()
        {
            string sSQL = "select 开料单号 from @u8.开料单表头 where 1=1";
            if (开料单号1 != null && 开料单号1 != "")
            {
                sSQL = sSQL + " and 开料单号>='" + 开料单号1 + "'";
            }
            if (开料单号2 != null && 开料单号2 != "")
            {
                sSQL = sSQL + " and 开料单号<='" + 开料单号2 + "'";
            }
            if (开料日期1 != null && 开料日期1 != "")
            {
                sSQL = sSQL + " and convert(varchar(10),交货日期,120)>=convert(varchar(10),'" + 开料日期1 + "',120)";
            }
            if (开料日期2 != null && 开料日期2 != "")
            {
                sSQL = sSQL + " and convert(varchar(10),交货日期,120)<=convert(varchar(10),'" + 开料日期2 + "',120)";
            }
            sSQL = sSQL + "  order by 开料单号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            if (dtSel.Rows.Count > 0)
            {
                GetGrid(dtSel.Rows[0]["开料单号"].ToString().Trim());

                gridView1.OptionsBehavior.Editable = false;
            }
            else
            {
                //lookUpEdit合金属性.EditValue = "";
                txt厚度2.Text = "";
                txt存货编码.Text = "";
                txt合金属性.Text = "";
                txt交货说明.Text = "";
                txt开料单号.Text = "";
                txt宽度2.Text = "";
                txt密度.Text = "";
                txt产品密度.Text = "";
                txt切割员.Text = "";
                text厂长签字.Text = "";
                text大锯床签字.Text = "";
                text带锯床签字.Text = "";
                text推锯床签字.Text = "";
                txt数量2.Text = "";
                txt算料人.Text = "";
                txt长度2.Text = "";
                lookUpEdit公司名称.EditValue = "";
                dtm交货日期.Text = "";
                timeEdit交货时间.Text = "";
                dtm切割日期.Text = "";
                dtm算料日期.Text = "";
                txt销售订单子表ID.Text = "";
                lookUpEdit材料类型.Text = "";

                textEdit原始尺寸材料重量.Text = "";
                textEdit原始尺寸产品重量.Text = "";
                textEdit剩下尺寸材料重量.Text = "";
                textEdit剩下尺寸产品重量.Text = "";
                textEdit切割材料重量.Text = "";
                textEdit切割产品重量.Text = "";
                 

                gridControl1.DataSource = null;
                btnLast();

            }
            sSQL = "select 开料单号 from @u8.开料单表头 where 1=1";
            dtSel = clsSQLCommond.ExecQuery(sSQL);
            
        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = 0;
                GetGrid(dtSel.Rows[iPage]["开料单号"].ToString().Trim());
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                if (iPage > 0)
                    iPage -= 1;
                GetGrid(dtSel.Rows[iPage]["开料单号"].ToString().Trim());
            }
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                if (iPage < dtSel.Rows.Count - 1)
                    iPage += 1;
                GetGrid(dtSel.Rows[iPage]["开料单号"].ToString().Trim());
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
                GetGrid(dtSel.Rows[iPage]["开料单号"].ToString().Trim());
            }
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
            gridView1.AddNewRow();
            int newrow = gridView1.RowCount - 1;
            gridView1.FocusedRowHandle = newrow;
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView1.RowCount - 1; i >= 0; i--)
            {
                if (gridView1.IsRowSelected(i))
                {
                    gridView1.DeleteRow(i);
                }
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            if (txt开料单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要修改的单据");
            }
            if (txt审核.Text.Trim() != "")
            {
                throw new Exception("已经审核不能修改");
            }
            SetEnable(true);
            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            string sErr = "";
            string sErrInfo = "";

            DialogResult d = MessageBox.Show("确定删除选中的开料单么： " + txt开料单号.Text + " ？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                sSQL = "select * from @u8.开料单表体 where 存货编码1='" + gridView1.GetRowCellValue(i, GridCol存货编码3).ToString().Trim() + "' and 序列号1='" + gridView1.GetRowCellValue(i, GridCol序列号3).ToString().Trim() + "'";
                DataTable dts = clsSQLCommond.ExecQuery(sSQL);
                if (dts.Rows.Count > 0)
                {
                    throw new Exception("已经使用不能删除");
                }
            }


            aList = new System.Collections.ArrayList();
            sSQL = "delete @u8.开料单表体 where 开料单号 = '" + txt开料单号.Text.Trim() + "'";
            aList.Add(sSQL);
            sSQL = "delete @u8.开料单表头 where 开料单号 = '" + txt开料单号.Text.Trim() + "'";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                string djh = "";
                if (dtSel != null && dtSel.Rows.Count > 0)
                {
                    if (iPage < dtSel.Rows.Count - 1)
                    {
                        iPage += 1;
                    }
                    else if (iPage == dtSel.Rows.Count - 1)
                    {
                        iPage = dtSel.Rows.Count - 2;
                    }
                    djh = dtSel.Rows[iPage]["开料单号"].ToString().Trim();
                }
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");
                GetSel();
                GetGrid(djh);
                //GetSel();
                //GetGrid(dtSel.Rows[iPage]["开料单号"].ToString().Trim());
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
            DataTable dt = new DataTable();
            string sErr = "";
            if (gridView1.RowCount < 1)
            {
                throw new Exception("表体没有数据，不能保存");
            }

            if (txt厚度2.Text.Trim() == "" && lookUpEdit材料类型.Text.Trim() == "板")
            {
                throw new Exception("厚度不能为空");
            }
            if (txt宽度2.Text.Trim() == "")
            {
                throw new Exception("宽度不能为空");
            }
            if (txt长度2.Text.Trim() == "")
            {
                throw new Exception("长度不能为空");
            }
            if (txt密度.Text.Trim() == "")
            {
                throw new Exception("材料密度不能为空");
            }
            if (txt产品密度.Text.Trim() == "")
            {
                throw new Exception("产品密度不能为空");
            }
            //if (lookUpEdit合金属性.EditValue == null)
            //{
            //    throw new Exception("合金属性不能为空");
            //}
            #region 判断是否有此销售订单
            sSQL = "select a.cSOCode,b.iRowNo,b.autoid,b.cDefine28,b.cInvCode,d.cInvName,d.cInvStd,b.iQuantity,b.cItemCode,a.cDefine2,b.dPreDate,a.cCusCode,c.cCusName,b.dPreMoDate,b.cDefine36,b.iQuantity,b.iNum,d.cInvDefine13,b.cDefine34 as isum " +
                    "from @u8.SO_SODetails b INNER JOIN @u8.SO_SOMain a ON a.ID = b.ID left join @u8.Customer c on a.cCusCode = c.cCusCode left join @u8.Inventory d on b.cInvCode=d.cInvCode " +
                    "where b.autoid = " + txt销售订单子表ID.Text.Trim();
            DataTable dtSO = clsSQLCommond.ExecQuery(sSQL);
            if (dtSO.Rows.Count == 0)
            {
                throw new Exception("获取销售订单错误");
            }
            #region 判断是是否超出订单数量
            sSQL = "select sum(数量2) as 数量 from @u8.开料单表头 where 销售订单ID= " + txt销售订单子表ID.Text.Trim() + " and 开料单号<>'" + txt开料单号.Text + "'";
            DataTable dthave = clsSQLCommond.ExecQuery(sSQL);

            double isum = double.Parse(dtSO.Rows[0]["isum"].ToString());
            if (dthave.Rows.Count > 0)
            {
                if (dthave.Rows[0]["数量"].ToString() != "")
                {
                    isum = isum - double.Parse(dthave.Rows[0]["数量"].ToString());
                }
            }
            isum = isum - double.Parse(txt数量2.Text.Trim());

            if (isum < 0)
            {
                throw new Exception("超出订单数量，请重新输入");
            }
            #endregion


            string cInvCode = dtSO.Rows[0]["cInvCode"].ToString();

            sSQL = "SELECT a.*, b.*,c.cInvName,c.cInvStd " +
                          " FROM @u8.SO_SODetails b INNER JOIN @u8.SO_SOMain a ON a.ID = b.ID left join @u8.Inventory c on b.cInvCode = c.cInvCode where b.cInvCode='" + cInvCode + "' ";
            sSQL = sSQL + " and b.iQuantity-(select isnull(sum(@u8.开料单表头.数量2),0) from @u8.开料单表头 where @u8.开料单表头.销售订单ID=b.AutoID ";
            if (txt开料单号.EditValue != null && txt开料单号.EditValue.ToString().Trim()!="")
            {
                sSQL = sSQL + " and @u8.开料单表头.开料单号<>'" + txt开料单号.EditValue.ToString().Trim() + "' ";
            }
            sSQL = sSQL + ")>0  ";

            DataTable dts = (DataTable)gridControl1.DataSource;
            DataView dv = new DataView(dts);
            DataTable dtg = dv.ToTable(true,new string[] { "存放区域","序列号1","数量1" });
            DataView dv1 = new DataView(dtg);
            DataTable dtgnew = dv1.ToTable(true, new string[] { "存放区域", "序列号1" });
            for (int i = 0; i < dtgnew.Rows.Count; i++)
            {
                if (dtgnew.Rows[i]["存放区域"].ToString() != "" && dtgnew.Rows[i]["序列号1"].ToString()!="")
                {
                    double sum1 = double.Parse(dtg.Compute("sum(数量1)", "序列号1='" + dtgnew.Rows[i]["序列号1"].ToString() + "'").ToString());//存放区域='" + dtgnew.Rows[i]["存放区域"].ToString() + "' and 

                    sSQL = "select isnull(sum(数量),0) from  (select 存货编码,'' as 开料单号,序列号,数量,存放区域  from @u8.材料入库单表体2 left join @u8.材料入库单表头 on @u8.材料入库单表体2.入库单号=@u8.材料入库单表头.入库单号  where 审核 is not null  "
                   + " union all select 存货编码1,开料单号,序列号1,数量1*-1,存放区域 from @u8.开料单表体  union all select 存货编码3,@u8.开料单表体.开料单号,序列号3,数量3,存放区域3 from @u8.开料单表体  left join @u8.开料单表头 on @u8.开料单表体.开料单号=@u8.开料单表头.开料单号  where 审核 is not null  "
                   + " ) a where 存货编码='" + txt存货编码.Text + "' and 序列号='" + dtgnew.Rows[i]["序列号1"].ToString() + "' and 存放区域='" + dtgnew.Rows[i]["存放区域"].ToString() + "' ";
                    if (txt开料单号.Text != "")
                    {
                        sSQL = sSQL + " and (开料单号<>'" + txt开料单号.Text + "' or 开料单号 is null)  ";
                    }
                    sSQL=sSQL+" group by 序列号 ";
                    DataTable dt1= clsSQLCommond.ExecQuery(sSQL);
                    double sum = 0;
                    if (dt1.Rows.Count>0)
                    {
                        sum = double.Parse(dt1.Rows[0][0].ToString());
                    }
                    if (sum - sum1 < 0)
                    {
                        throw new Exception("存放区域" + dtgnew.Rows[i]["存放区域"].ToString() + "序列号" + dtgnew.Rows[i]["序列号1"].ToString() + "开料数量大于现存量，现存" + sum.ToString());
                    }
                }
            }
            #endregion

            if (sState == "add" || txt开料单号.Text=="")
            {
                sSQL = "select case when isnull(max(开料单号)+1,1) = 1 then '" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "0001' else  isnull(max(开料单号)+1,1) end as 开料单号 from @u8.开料单表头 where 开料单号 like '" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMM") + "%'";
                dt = clsSQLCommond.ExecQuery(sSQL);
                txt开料单号.Text = dt.Rows[0]["开料单号"].ToString().Trim();
            }

            sSQL = "select * from @u8.开料单表头 where 1=-1";
            dt = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from @u8.开料单表体 where 1=-1";
            DataTable dtDetail = clsSQLCommond.ExecQuery(sSQL);

            

            aList = new System.Collections.ArrayList();

            

            DataRow dr = dt.NewRow();
            dr["开料单号"] = txt开料单号.Text.Trim();
            dr["公司编码"] =  lookUpEdit公司名称.EditValue.ToString().Trim();
            dr["交货日期"] =dtm交货日期.DateTime.ToString("yyyy-MM-dd") + " " + timeEdit交货时间.Time.ToString("hh:mm:ss");
            dr["交货说明"] =txt交货说明.Text.Trim();
            dr["存货编码"] = txt存货编码.Text.Trim();
            dr["密度"] =  txt密度.Text.Trim();
            dr["产品密度"] = txt产品密度.Text.Trim();
            //dr["合金属性"] = lookUpEdit合金属性.EditValue.ToString().Trim();
            dr["切割员"] = txt切割员.Text;
            dr["厂长签字"] = text厂长签字.Text;
            dr["大锯床签字"] = text大锯床签字.Text;
            dr["带锯床签字"] = text带锯床签字.Text;
            dr["推锯床签字"] = text推锯床签字.Text;
            dr["切割日期"] =  dtm切割日期.Text;
            dr["算料人"] =  txt算料人.Text.Trim();
            dr["算料日期"] = dtm算料日期.Text;
            dr["厚度2"] = txt厚度2.Text.Trim();
            dr["宽度2"] = txt宽度2.Text.Trim();
            dr["长度2"] = txt长度2.Text.Trim();
            dr["数量2"] = txt数量2.Text.Trim();
            dr["销售订单ID"] = txt销售订单子表ID.Text.Trim();
            dr["材料类型"] = lookUpEdit材料类型.Text.Trim();
            dt.Rows.Add(dr);
            if (sState == "add")
            {
                sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "开料单表头", dt, 0);
                aList.Add(sSQL);
            }
            if (sState == "edit")
            {
                sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "开料单表头", dt, 0);
                aList.Add(sSQL);

                sSQL = "delete @u8.开料单表体 where 开料单号 = '" + txt开料单号.Text.Trim() + "'";
                aList.Add(sSQL);
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (txt存货编码.Text.ToString().Trim() == "")
                {
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, GridCol类型).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "类型不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, GridCol存放区域).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "存放区域不能为空\n";
                    continue;
                }
                if (gridView1.GetRowCellDisplayText(i, GridCol序列号1).ToString().Trim() == "")
                {
                    sErr = sErr + "行" + (i + 1) + "序列号1不能为空\n";
                    continue;
                }

                if (gridView1.GetRowCellValue(i, GridColiID).ToString().Trim() == "")
                {
                    sSQL = "select * from  (select 存货编码,'' as 开料单号,序列号  from @u8.材料入库单表体2 "
                   + " union all select 存货编码1,开料单号,序列号1 from @u8.开料单表体 union all select 存货编码3,开料单号,序列号3 from @u8.开料单表体  "
                   + " ) a where 存货编码='" + txt存货编码.Text + "' and 序列号='" + gridView1.GetRowCellValue(i, GridCol序列号3).ToString().Trim() + "' and 开料单号<>'" + txt开料单号.Text.Trim() + "'";

                    if (txt开料单号.Text != "")
                    {
                        sSQL = sSQL + " and 开料单号 <> '" + txt开料单号.Text.Trim() + "'";
                    }

                    DataTable dtid = clsSQLCommond.ExecQuery(sSQL);
                    if (dtid.Rows.Count > 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "序列号3重复，已重新刷新序列号\n";
                        gridView1.SetRowCellValue(i, GridCol序列号3, GetID(txt存货编码.Text));
                        continue;
                    }
                }

                DataRow drDetail = dtDetail.NewRow();
                drDetail["开料单号"] = txt开料单号.Text.Trim();
                drDetail["类型"] = gridView1.GetRowCellValue(i, GridCol类型).ToString().Trim();
                drDetail["存放区域"] = gridView1.GetRowCellValue(i, GridCol存放区域).ToString().Trim();
                drDetail["存货编码1"] = txt存货编码.Text.ToString().Trim();
                if (gridView1.GetRowCellValue(i, GridCol序列号1).ToString().Trim() != "")
                    drDetail["序列号1"] = gridView1.GetRowCellValue(i, GridCol序列号1).ToString().Trim();

                sSQL = "select iID as 来源iI from @u8.材料入库单表体2 where 存货编码='" + txt存货编码.Text.ToString().Trim() + "' and 序列号='" + gridView1.GetRowCellValue(i, GridCol序列号1).ToString().Trim() + "'"
                    + "union all select 来源iID from @u8.开料单表体 where 存货编码3='" + txt存货编码.Text.ToString().Trim() + "' and 序列号3='" + gridView1.GetRowCellValue(i, GridCol序列号1).ToString().Trim() + "' ";
                DataTable dtiID = clsSQLCommond.ExecQuery(sSQL);
                if (dtiID.Rows.Count > 0)
                {
                    drDetail["来源iID"] = dtiID.Rows[0]["来源iI"].ToString();
                }
                else
                {
                    sErr = sErr + "行" + (i + 1) + "无法找到来源单据\n";
                }


                decimal d厚度1 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol厚度1).ToString().Trim());
                decimal d宽度1 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol宽度1).ToString().Trim());
                decimal d长度1 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol长度1).ToString().Trim());
                decimal d数量1 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol数量1).ToString().Trim());
                if (d厚度1 <= 0 && lookUpEdit材料类型.Text.Trim() == "板")
                {
                    sErr = sErr + "行" + (i + 1) + "厚度1必须大于0\n";
                    continue;
                }
                if (d宽度1 <= 0)
                {
                    sErr = sErr + "行" + (i + 1) + "宽度1必须大于0\n";
                    continue;
                }
                if (d长度1 <= 0)
                {
                    sErr = sErr + "行" + (i + 1) + "长度1必须大于0\n";
                    continue;
                }
                if (d数量1 <= 0)
                {
                    sErr = sErr + "行" + (i + 1) + "数量1必须大于0\n";
                    continue;
                }

                decimal d厚度2 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol厚度2).ToString().Trim());
                decimal d宽度2 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol宽度2).ToString().Trim());
                decimal d长度2 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol长度2).ToString().Trim());
                decimal d数量2 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol数量2).ToString().Trim());
                if (d厚度2 <= 0 && lookUpEdit材料类型.Text.Trim() == "板")
                {
                    sErr = sErr + "行" + (i + 1) + "厚度2必须大于0\n";
                    continue;
                }
                if (d宽度2 <= 0)
                {
                    sErr = sErr + "行" + (i + 1) + "宽度2必须大于0\n";
                    continue;
                }
                if (d长度2 <= 0)
                {
                    sErr = sErr + "行" + (i + 1) + "长度2必须大于0\n";
                    continue;
                }
                if (d数量2 <= 0)
                {
                    sErr = sErr + "行" + (i + 1) + "数量2必须大于0\n";
                    continue;
                }

                //if ((d宽度1 < d宽度2 && d宽度1 < d长度2) || (d长度1 < d宽度2 && d长度1 < d长度2) && d宽度1 * d长度1 < d宽度2 * d长度2)
                //{
                //    sErr = sErr + "行" + (i + 1) + "不能将小板开成大板\n";
                //    continue;
                //}

                decimal d厚度3 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol厚度3).ToString().Trim());
                decimal d宽度3 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol宽度3).ToString().Trim());
                decimal d长度3 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol长度3).ToString().Trim());
                decimal d数量3 = ReturnDecimal(gridView1.GetRowCellValue(i, GridCol数量3).ToString().Trim());



                drDetail["厚度1"] = d厚度1;
                drDetail["宽度1"] = d宽度1;
                drDetail["长度1"] = d长度1;
                drDetail["数量1"] = d数量1;

                drDetail["厚度2"] = d厚度2;
                drDetail["宽度2"] = d宽度2;
                drDetail["长度2"] = d长度2;
                drDetail["数量2"] = d数量2;


                if (gridView1.GetRowCellValue(i, GridCol序列号3).ToString().Trim() != "")
                {
                    drDetail["序列号3"] = gridView1.GetRowCellValue(i, GridCol序列号3).ToString().Trim();
                    drDetail["存货编码3"] = txt存货编码.Text.ToString().Trim();
                    drDetail["厚度3"] = d厚度3;
                    drDetail["宽度3"] = d宽度3;
                    drDetail["长度3"] = d长度3;
                    drDetail["数量3"] = d数量3;

                    if (d厚度3 <= 0 && lookUpEdit材料类型.Text.Trim() == "板")
                    {
                        sErr = sErr + "行" + (i + 1) + "厚度3必须大于0\n";
                        continue;
                    }
                    if (d宽度3 <= 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "宽度3必须大于0\n";
                        continue;
                    }
                    if (d长度3 <= 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "长度3必须大于0\n";
                        continue;
                    }
                    if (d数量3 <= 0)
                    {
                        sErr = sErr + "行" + (i + 1) + "数量3必须大于0\n";
                        continue;
                    }



                    if (gridView1.GetRowCellValue(i, GridCol存放区域3).ToString().Trim() != "")
                        drDetail["存放区域3"] = gridView1.GetRowCellValue(i, GridCol存放区域3).ToString().Trim();
                    else
                        drDetail["存放区域3"] = gridView1.GetRowCellValue(i, GridCol存放区域).ToString().Trim();

                }
                dtDetail.Rows.Add(drDetail);
            }
            if (sErr.Trim().Length > 0)
            {
                throw new Exception(sErr);
            }

            if (dtDetail.Rows.Count==0)
            {
                throw new Exception("表体没有数据，不能保存");
            }

            if (sErr.Trim().Length > 0)
            {
                throw new Exception(sErr);
            }

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    sSQL = clsGetSQL.GetInsertSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName,"开料单表体", dtDetail, i);
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                    GetGrid(txt开料单号.Text.Trim());
                }
            }
        }
        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            if (txt开料单号.Text.Trim() == "")
            {
                
                btnLast();
            }
            else
            {
                int iFocRow = gridView1.FocusedRowHandle;
                GetGrid(txt开料单号.Text.Trim());
                gridView1.FocusedRowHandle = iFocRow;
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            if (txt开料单号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能审核");
            }
            if (txt审核.Text.Trim() != "")
            {
                throw new Exception("已经审核");
            }

            sSQL = "select * from @u8.开料单表头 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dr["开料单号"] = txt开料单号.Text.Trim();
            dr["公司编码"] = lookUpEdit公司名称.EditValue.ToString().Trim();
            dr["交货日期"] = dtm交货日期.DateTime.ToString("yyyy-MM-dd") + " " + timeEdit交货时间.Time.ToString("hh:mm:ss");
            dr["交货说明"] = txt交货说明.Text.Trim();
            dr["存货编码"] = txt存货编码.Text.Trim();
            dr["密度"] = txt密度.Text.Trim();
            dr["产品密度"] = txt产品密度.Text.Trim();
            //dr["合金属性"] = lookUpEdit合金属性.EditValue.ToString().Trim();
            dr["切割员"] = txt切割员.Text;
            dr["厂长签字"] = text厂长签字.Text;
            dr["大锯床签字"] = text大锯床签字.Text;
            dr["带锯床签字"] = text带锯床签字.Text;
            dr["推锯床签字"] = text推锯床签字.Text;
            dr["切割日期"] = dtm切割日期.Text;
            dr["算料人"] = txt算料人.Text.Trim();
            dr["算料日期"] = dtm算料日期.Text;
            dr["厚度2"] = txt厚度2.Text.Trim();
            dr["宽度2"] = txt宽度2.Text.Trim();
            dr["长度2"] = txt长度2.Text.Trim();
            dr["数量2"] = txt数量2.Text.Trim();
            dr["销售订单ID"] = txt销售订单子表ID.Text.Trim();

            dr["审核"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
            dr["审核日期"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;

            dr["材料类型"] = lookUpEdit材料类型.EditValue.ToString();
            dt.Rows.Add(dr);

            aList = new System.Collections.ArrayList();
            sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "开料单表头", dt, 0);
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("审核成功！\n合计执行语句:" + iCou + "条");
                GetGrid(txt开料单号.Text.Trim());
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            if (txt开料单号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能弃审");
            }
            if (txt审核.Text.Trim() == "")
            {
                throw new Exception("尚未审核，不能弃审");
            }
            if (txt记账.Text.Trim() != "")
            {
                throw new Exception("已经记账，不能弃审");
            }
            sSQL = "select * from @u8.开料单表头 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dr["开料单号"] = txt开料单号.Text.Trim();
            dr["公司编码"] = lookUpEdit公司名称.EditValue.ToString().Trim();
            dr["交货日期"] = dtm交货日期.DateTime.ToString("yyyy-MM-dd") + " " + timeEdit交货时间.Time.ToString("hh:mm:ss");
            dr["交货说明"] = txt交货说明.Text.Trim();
            dr["存货编码"] = txt存货编码.Text.Trim();
            dr["密度"] = txt密度.Text.Trim();
            dr["产品密度"] = txt产品密度.Text.Trim();
            //dr["合金属性"] = lookUpEdit合金属性.EditValue.ToString().Trim();
            dr["切割员"] = txt切割员.Text;
            dr["厂长签字"] = text厂长签字.Text;
            dr["大锯床签字"] = text大锯床签字.Text;
            dr["带锯床签字"] = text带锯床签字.Text;
            dr["推锯床签字"] = text推锯床签字.Text;
            dr["切割日期"] = dtm切割日期.Text;
            dr["算料人"] = txt算料人.Text.Trim();
            dr["算料日期"] = dtm算料日期.Text;
            dr["厚度2"] = txt厚度2.Text.Trim();
            dr["宽度2"] = txt宽度2.Text.Trim();
            dr["长度2"] = txt长度2.Text.Trim();
            dr["数量2"] = txt数量2.Text.Trim();
            dr["销售订单ID"] = txt销售订单子表ID.Text.Trim();

            dr["审核"] = "";
            dr["审核日期"] = DBNull.Value;

            dr["材料类型"] = lookUpEdit材料类型.EditValue.ToString();

            dt.Rows.Add(dr);

            aList = new System.Collections.ArrayList();
            sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "开料单表头", dt, 0);
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("弃审成功！\n合计执行语句:" + iCou + "条");
                GetGrid(txt开料单号.Text.Trim());
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            if (txt开料单号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能审核");
            }
            if (txt审核.Text.Trim() == "")
            {
                throw new Exception("未审核,不可记账");
            }
            if (txt记账.Text.Trim() != "")
            {
                throw new Exception("已经记账");
            }

            sSQL = "select * from @u8.开料单表头 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dr["开料单号"] = txt开料单号.Text.Trim();
            dr["公司编码"] = lookUpEdit公司名称.EditValue.ToString().Trim();
            dr["交货日期"] = dtm交货日期.DateTime.ToString("yyyy-MM-dd") + " " + timeEdit交货时间.Time.ToString("hh:mm:ss");
            dr["交货说明"] = txt交货说明.Text.Trim();
            dr["存货编码"] = txt存货编码.Text.Trim();
            dr["密度"] = txt密度.Text.Trim();
            dr["产品密度"] = txt产品密度.Text.Trim();
            //dr["合金属性"] = lookUpEdit合金属性.EditValue.ToString().Trim();
            dr["切割员"] = txt切割员.Text;
            dr["厂长签字"] = text厂长签字.Text;
            dr["大锯床签字"] = text大锯床签字.Text;
            dr["带锯床签字"] = text带锯床签字.Text;
            dr["推锯床签字"] = text推锯床签字.Text;
            dr["切割日期"] = dtm切割日期.Text;
            dr["算料人"] = txt算料人.Text.Trim();
            dr["算料日期"] = dtm算料日期.Text;
            dr["厚度2"] = txt厚度2.Text.Trim();
            dr["宽度2"] = txt宽度2.Text.Trim();
            dr["长度2"] = txt长度2.Text.Trim();
            dr["数量2"] = txt数量2.Text.Trim();
            dr["销售订单ID"] = txt销售订单子表ID.Text.Trim();

            dr["审核"] = txt审核.Text.Trim();
            dr["审核日期"] = dtm审核日期.Text.Trim();
            dr["记账"] = FrameBaseFunction.ClsBaseDataInfo.sUserName;
            dr["记账日期"] = FrameBaseFunction.ClsBaseDataInfo.sLogDate;

            dr["材料类型"] = lookUpEdit材料类型.EditValue.ToString();
            dt.Rows.Add(dr);

            aList = new System.Collections.ArrayList();
            sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "开料单表头", dt, 0);
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("记账成功！\n合计执行语句:" + iCou + "条");
                GetGrid(txt开料单号.Text.Trim());
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }

            if (txt开料单号.Text.Trim() == "")
            {
                throw new Exception("没有单据号，不能弃审");
            }
            if (txt审核.Text.Trim() == "")
            {
                throw new Exception("尚未审核，不能撤销记账");
            }
            if (txt记账.Text.Trim() == "")
            {
                throw new Exception("未记账，不能撤销记账");
            }
            sSQL = "select * from @u8.开料单表头 where 1=-1";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            DataRow dr = dt.NewRow();
            dr["开料单号"] = txt开料单号.Text.Trim();
            dr["公司编码"] = lookUpEdit公司名称.EditValue.ToString().Trim();
            dr["交货日期"] = dtm交货日期.DateTime.ToString("yyyy-MM-dd") + " " + timeEdit交货时间.Time.ToString("hh:mm:ss");
            dr["交货说明"] = txt交货说明.Text.Trim();
            dr["存货编码"] = txt存货编码.Text.Trim();
            dr["密度"] = txt密度.Text.Trim();
            dr["产品密度"] = txt产品密度.Text.Trim();
            //dr["合金属性"] = lookUpEdit合金属性.EditValue.ToString().Trim();
            dr["切割员"] = txt切割员.Text;
            dr["厂长签字"] = text厂长签字.Text;
            dr["大锯床签字"] = text大锯床签字.Text;
            dr["带锯床签字"] = text带锯床签字.Text;
            dr["推锯床签字"] = text推锯床签字.Text;
            dr["切割日期"] = dtm切割日期.Text;
            dr["算料人"] = txt算料人.Text.Trim();
            dr["算料日期"] = dtm算料日期.Text;
            dr["厚度2"] = txt厚度2.Text.Trim();
            dr["宽度2"] = txt宽度2.Text.Trim();
            dr["长度2"] = txt长度2.Text.Trim();
            dr["数量2"] = txt数量2.Text.Trim();
            dr["销售订单ID"] = txt销售订单子表ID.Text.Trim();

            dr["审核"] = txt审核.Text.Trim();
            dr["审核日期"] = dtm审核日期.Text.Trim();
            dr["记账"] = "";
            dr["记账日期"] = DBNull.Value;
            dr["材料类型"] = lookUpEdit材料类型.EditValue.ToString();
            dt.Rows.Add(dr);

            aList = new System.Collections.ArrayList();
            sSQL = clsGetSQL.GetUpdateSQL(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName, "开料单表头", dt, 0);
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("撤销记账成功！\n合计执行语句:" + iCou + "条");
                GetGrid(txt开料单号.Text.Trim());
            }
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void Frm开料单_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                SetEnable(false);

                //btnSel();
                GetSel();
                btnLast();

            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            } 
        }

        private void GetGrid(string sCode)
        {
            base.dsPrint = new DataSet();

            SetEnable(false);

            sSQL = "select a.cSOCode,@u8.开料单表头.*,convert(float,密度) as 材料密度_1,convert(float,产品密度) as 产品密度_1,CONVERT(varchar(10),交货日期,120) as 交货日期1,CONVERT(varchar(8),交货日期,114) as 交货日期2,@u8.Customer.cCusName,convert(varchar(10),切割日期,120) as 切割日期1,convert(varchar(10),算料日期,120) as 算料日期1,convert(varchar(10),审核日期,120) as 审核日期1,c.iText as 合金属性名称"
            + ",convert(float,宽度2) as 宽度2_1,convert(float,厚度2) as 厚度2_1,convert(float,长度2) as 长度2_1,"
            + "convert(float,数量2) as 数量2_1,@u8.Inventory.cInvName,convert(float,产品密度) as 产品密度_1,convert(float,密度) as 数量_1 from @u8.开料单表头 left join @u8.Customer on @u8.开料单表头.公司编码=@u8.Customer.cCusCode  left join @u8.Inventory on @u8.开料单表头.存货编码 = @u8.Inventory.cInvCode left join (select * from dbo._LookUpDate where iType = 7) as c on 合金属性=c.iID "
            + " left join @u8.SO_SODetails b on  @u8.开料单表头.销售订单ID=b.AutoID left JOIN @u8.SO_SOMain a ON a.ID = b.ID"
            + " where 开料单号 = '" + sCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataTable dtnew = dt.Copy();
            if (dt.Rows.Count > 0)
            {
                //lookUpEdit合金属性.EditValue = dt.Rows[0]["合金属性"].ToString();
                lookUpEdit材料类型.EditValue = dt.Rows[0]["材料类型"].ToString().Trim();
                txt厚度2.Text = Math.Round(double.Parse(dt.Rows[0]["厚度2"].ToString().Trim()),3).ToString();
                txt存货编码.Text = dt.Rows[0]["存货编码"].ToString().Trim();
                txt合金属性.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                txt交货说明.Text = dt.Rows[0]["交货说明"].ToString().Trim();
                txt开料单号.Text = dt.Rows[0]["开料单号"].ToString().Trim();
                txt宽度2.Text = ReturnFloat(dt.Rows[0]["宽度2"].ToString()).ToString();
                txt密度.Text = ReturnFloat(dt.Rows[0]["密度"].ToString()).ToString();
                txt产品密度.Text = ReturnFloat(dt.Rows[0]["产品密度"].ToString()).ToString();
                txt切割员.Text = dt.Rows[0]["切割员"].ToString().Trim();
                text厂长签字.Text = dt.Rows[0]["厂长签字"].ToString().Trim();
                text大锯床签字.Text = dt.Rows[0]["大锯床签字"].ToString().Trim();
                text带锯床签字.Text = dt.Rows[0]["带锯床签字"].ToString().Trim();
                text推锯床签字.Text = dt.Rows[0]["推锯床签字"].ToString().Trim();
                txt数量2.Text = Math.Round(double.Parse(dt.Rows[0]["数量2"].ToString().Trim()),0).ToString();
                txt算料人.Text = dt.Rows[0]["算料人"].ToString().Trim();
                txt长度2.Text = Math.Round(double.Parse(dt.Rows[0]["长度2"].ToString().Trim()),2).ToString();
                lookUpEdit公司名称.EditValue = dt.Rows[0]["公司编码"].ToString().Trim();
                if (dt.Rows[0]["交货日期"].ToString() != "")
                {
                    dtm交货日期.Text = Convert.ToDateTime(dt.Rows[0]["交货日期"].ToString()).ToString("yyyy-MM-dd");
                    timeEdit交货时间.Text = Convert.ToDateTime(dt.Rows[0]["交货日期"].ToString()).ToString("hh:mm:ss");
                }
                dtm切割日期.Text = dt.Rows[0]["切割日期"].ToString().Trim();
                dtm算料日期.Text = dt.Rows[0]["算料日期"].ToString().Trim();
                txt销售订单子表ID.Text = dt.Rows[0]["销售订单ID"].ToString().Trim();

                txt审核.Text = dt.Rows[0]["审核"].ToString().Trim();
                dtm审核日期.Text = dt.Rows[0]["审核日期"].ToString().Trim();

                txt记账.Text = dt.Rows[0]["记账"].ToString().Trim();
                dtm记账日期.Text = dt.Rows[0]["记账日期"].ToString().Trim();
                
                string txt1 = txt密度.Text;
                if (txt1 == "")
                {
                    txt1 = "0";
                }
                GetIDList();
                if (lookUpEdit材料类型.Text.Trim() == "板")
                {
                    sSQL = "select   @u8.开料单表体.iID, 开料单号, 类型, 存放区域, 存货编码1, 序列号1, convert(float,厚度1) as 厚度1,convert(float,宽度1) as  宽度1, convert(float,长度1) as 长度1,convert(int, 数量1) as 数量1, convert(float,厚度2) as 厚度2, convert(float,宽度2) as 宽度2, convert(float,长度2) as 长度2, convert(int, 数量2) as 数量2, 存货编码3, 序列号3, convert(float,厚度3) as 厚度3, convert(float ,宽度3) as 宽度3, convert(float,长度3) as 长度3, convert(int , 数量3) as 数量3, 存放区域3, 来源iID,"
                        + "convert(float,convert(decimal(18, 2),isnull(长度1,0)*isnull(厚度1,0)*isnull(宽度1,0)*isnull(数量1,0)*" + txt1 + "/1000000)) as 重量1,"
                    + "convert(float,convert(decimal(18, 2),isnull(长度2,0)*isnull(厚度2,0)*isnull(宽度2,0)*isnull(数量2,0)*" + txt1 + "/1000000)) as 重量2,"
                    + "convert(float,convert(decimal(18, 2),isnull(长度3,0)*isnull(厚度3,0)*isnull(宽度3,0)*isnull(数量3,0)*" + txt1 + "/1000000)) as 重量3, "
                        + "b.iText as 类型名称,c.iText as 存放区域名称,d.iText as 存放区域3名称 from @u8.开料单表体 "
                        + " left join (select * from dbo._LookUpDate where iType = 6) b on  @u8.开料单表体.类型=b.iID "
                        + " left join (select * from dbo._LookUpDate where iType = 5) c on  @u8.开料单表体.存放区域=c.iID "
                        + " left join (select * from dbo._LookUpDate where iType = 5) d on  @u8.开料单表体.存放区域3=d.iID "
                        + " where 开料单号 = '" + sCode + "' order by @u8.开料单表体.iID";
                }
                if (lookUpEdit材料类型.Text.Trim() == "棒")
                {
                    sSQL = "select   @u8.开料单表体.iID, 开料单号, 类型, 存放区域, 存货编码1, 序列号1, convert(float,厚度1) as 厚度1,convert(float,宽度1) as  宽度1, convert(float,长度1) as 长度1, convert(int, 数量1) as 数量1, convert(float,厚度2) as 厚度2, convert(float,宽度2) as 宽度2, convert(float,长度2) as 长度2, convert(int, 数量2) as 数量2, 存货编码3, 序列号3, convert(float,厚度3) as 厚度3, convert(float ,宽度3) as 宽度3, convert(float,长度3) as 长度3, convert(int , 数量3) as 数量3, 存放区域3, 来源iID,"
                        + "convert(float,convert(decimal(18, 2),isnull(" + txt1 + ",0)*isnull(长度1,0)*(isnull(宽度1,0)/2)*(isnull(宽度1,0)/2)*3.14*isnull(数量1,0)/1000000)) as 重量1,"
                    + "convert(float,convert(decimal(18, 2),isnull(" + txt1 + ",0)*isnull(长度2,0)*(isnull(宽度2,0)/2)*(isnull(宽度2,0)/2)*3.14*isnull(数量2,0)/1000000)) as 重量2,"
                    + "convert(float,convert(decimal(18, 2),isnull(" + txt1 + ",0)*isnull(长度3,0)*(isnull(宽度3,0)/2)*(isnull(宽度3,0)/2)*3.14*isnull(数量3,0)/1000000)) as 重量3, "
                        + "b.iText as 类型名称,c.iText as 存放区域名称,d.iText as 存放区域3名称 from @u8.开料单表体 "
                        + " left join (select * from dbo._LookUpDate where iType = 6) b on  @u8.开料单表体.类型=b.iID "
                        + " left join (select * from dbo._LookUpDate where iType = 5) c on  @u8.开料单表体.存放区域=c.iID "
                        + " left join (select * from dbo._LookUpDate where iType = 5) d on  @u8.开料单表体.存放区域3=d.iID "
                        + " where 开料单号 = '" + sCode + "' order by @u8.开料单表体.iID";
                }
                dt = clsSQLCommond.ExecQuery(sSQL);
                gridControl1.DataSource = dt;

                GetWeight();
                
                

                dtnew.Columns.Add("材料密度");
                dtnew.Rows[0]["材料密度"] = txt密度.Text;

                //dtnew.Columns.Add("产品密度");
                //dtnew.Rows[0]["材料密度"] = txt产品密度.Text;

                dtnew.Columns.Add("原始尺寸材料重量");
                dtnew.Rows[0]["原始尺寸材料重量"] = textEdit原始尺寸材料重量.Text;

                dtnew.Columns.Add("原始尺寸产品重量");
                dtnew.Rows[0]["原始尺寸产品重量"] = textEdit原始尺寸产品重量.Text;

                dtnew.Columns.Add("切割材料重量");
                dtnew.Rows[0]["切割材料重量"] = textEdit切割材料重量.Text;

                dtnew.Columns.Add("切割产品重量");
                dtnew.Rows[0]["切割产品重量"] = textEdit切割产品重量.Text;

                dtnew.Columns.Add("剩下尺寸材料重量");
                dtnew.Rows[0]["剩下尺寸材料重量"] = textEdit剩下尺寸材料重量.Text;

                dtnew.Columns.Add("剩下尺寸产品重量");
                dtnew.Rows[0]["剩下尺寸产品重量"] = textEdit剩下尺寸产品重量.Text;

                dtnew.Columns.Add("实际用料重量");
                dtnew.Rows[0]["实际用料重量"] = txt实际用料重量.Text;

                dtnew.Columns.Add("废料重量");
                dtnew.Rows[0]["废料重量"] = txt废料重量.Text;

                dtnew.Columns.Add("废料重量百分率");
                dtnew.Rows[0]["废料重量百分率"] = txt废料重量百分率.Text;

                base.dsPrint.Tables.Add(dtnew);
                base.dsPrint.Tables[0].TableName = "dtHead";

                

                DataTable dtgrid = dt.Copy();

                int s = 10 - dtgrid.Rows.Count % 10;
                for (int i = 0; i <s ; i++)
                {
                    DataRow dw = dtgrid.NewRow();
                    dtgrid.Rows.Add(dw);
                }

                

                DataTable dtgridnew = dtgrid.Copy();
                for (int i = 1; i < dtgrid.Rows.Count; i++)
                {
                    string now序列号1 = dtgrid.Rows[i]["序列号1"].ToString();
                    string last序列号1 = dtgrid.Rows[i-1]["序列号1"].ToString();
                    if (now序列号1 == last序列号1)
                    {
                        if (dtgrid.Rows[i-1]["类型"].ToString() == dtgrid.Rows[i]["类型"].ToString()
                            && dtgrid.Rows[i-1]["存放区域"].ToString() == dtgrid.Rows[i]["存放区域"].ToString()
                            && dtgrid.Rows[i - 1]["数量1"].ToString() == dtgrid.Rows[i]["数量1"].ToString())
                        {
                            dtgridnew.Rows[i]["类型名称"] = DBNull.Value;
                            dtgridnew.Rows[i]["存放区域名称"] = DBNull.Value;
                            dtgridnew.Rows[i]["序列号1"] = DBNull.Value;
                            dtgridnew.Rows[i]["厚度1"] = DBNull.Value;
                            dtgridnew.Rows[i]["长度1"] = DBNull.Value;
                            dtgridnew.Rows[i]["宽度1"] = DBNull.Value;
                            dtgridnew.Rows[i]["数量1"] = DBNull.Value;
                            dtgridnew.Rows[i]["重量1"] = DBNull.Value;
                        }
                        if (dtgrid.Rows[i - 1]["数量2"].ToString() == dtgrid.Rows[i]["数量2"].ToString())
                        {
                            dtgridnew.Rows[i]["厚度2"] = DBNull.Value;
                            dtgridnew.Rows[i]["宽度2"] = DBNull.Value;
                            dtgridnew.Rows[i]["长度2"] = DBNull.Value;
                            dtgridnew.Rows[i]["数量2"] = DBNull.Value;
                            dtgridnew.Rows[i]["重量2"] = DBNull.Value;
                        }
                    }
                    if (dtgrid.Rows[i]["数量1"].ToString() == "" || dtgrid.Rows[i]["数量1"].ToString() == "0")
                    {
                        dtgridnew.Rows[i]["类型名称"] = DBNull.Value;
                        dtgridnew.Rows[i]["存放区域名称"] = DBNull.Value;
                        dtgridnew.Rows[i]["序列号1"] = DBNull.Value;
                        dtgridnew.Rows[i]["厚度1"] = DBNull.Value;
                        dtgridnew.Rows[i]["长度1"] = DBNull.Value;
                        dtgridnew.Rows[i]["宽度1"] = DBNull.Value;
                        dtgridnew.Rows[i]["数量1"] = DBNull.Value;
                        dtgridnew.Rows[i]["重量1"] = DBNull.Value;
                    }
                    if (dtgrid.Rows[i]["数量2"].ToString() == "" || dtgrid.Rows[i]["数量2"].ToString() == "0")
                    {
                        dtgridnew.Rows[i]["厚度2"] = DBNull.Value;
                        dtgridnew.Rows[i]["宽度2"] = DBNull.Value;
                        dtgridnew.Rows[i]["长度2"] = DBNull.Value;
                        dtgridnew.Rows[i]["数量2"] = DBNull.Value;
                        dtgridnew.Rows[i]["重量2"] = DBNull.Value;
                    }
                    if (dtgrid.Rows[i]["数量3"].ToString() == "" || dtgrid.Rows[i]["数量3"].ToString() == "0")
                    {
                        dtgridnew.Rows[i]["厚度3"] = DBNull.Value;
                        dtgridnew.Rows[i]["宽度3"] = DBNull.Value;
                        dtgridnew.Rows[i]["长度3"] = DBNull.Value;
                        dtgridnew.Rows[i]["数量3"] = DBNull.Value;
                        dtgridnew.Rows[i]["重量3"] = DBNull.Value;
                    }
                }

                base.dsPrint.Tables.Add(dtgridnew.Copy());
                base.dsPrint.Tables[1].TableName = "dtGrid";
            }

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int iRow = 0;
            if (gridView1.FocusedRowHandle >= 0)
                iRow = gridView1.FocusedRowHandle;
            
            

            string cinvcode = txt存货编码.Text.ToString().Trim();
            string cid = "";
            if (gridView1.GetRowCellDisplayText(iRow, GridCol序列号1) != null && gridView1.GetRowCellDisplayText(iRow, GridCol序列号1).ToString().Trim() != "")
            {
                cid = gridView1.GetRowCellDisplayText(iRow, GridCol序列号1).ToString().Trim();
            }
            string carea = "";
            if (gridView1.GetRowCellDisplayText(iRow, GridCol存放区域) != null && gridView1.GetRowCellDisplayText(iRow, GridCol存放区域).ToString().Trim() != "")
            {
                carea = gridView1.GetRowCellValue(iRow, GridCol存放区域).ToString().Trim();
            }
            if (e.Column == GridCol序列号1)
            {
                if (cinvcode != "" )
                {
                    decimal dH = 0; decimal dK = 0; decimal dC = 0; string 类型 = ""; string 区域 = "";
                    GetInvXLH(txt存货编码.Text.ToString().Trim(), cid, out dH, out dK, out dC, out 类型, out 区域);
                    if (dH != 0)
                    {
                        gridView1.SetRowCellValue(iRow, GridCol厚度1, dH);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, GridCol厚度1, DBNull.Value);
                    }
                    if (dK != 0)
                    {
                        gridView1.SetRowCellValue(iRow, GridCol宽度1, dK);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, GridCol宽度1, DBNull.Value);
                    }
                    if (dC != 0)
                    {
                        gridView1.SetRowCellValue(iRow, GridCol长度1, dC);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(iRow, GridCol长度1, DBNull.Value);
                    }
                    gridView1.SetRowCellValue(iRow, GridCol类型, 类型);
                    gridView1.SetRowCellValue(iRow, GridCol存放区域, 区域);
                    gridView1.SetRowCellValue(iRow, GridCol存放区域3, 区域);
                    double dCurr = GetCurr(txt存货编码.Text.ToString().Trim(), cid, 区域);
                    gridView1.SetRowCellValue(iRow, GridCol数量1, dCurr);

                }
                if (txt厚度2.Text != "")
                {
                    gridView1.SetRowCellValue(iRow, GridCol厚度2, txt厚度2.Text.Trim());
                }
                if (txt宽度2.Text != "")
                {
                    gridView1.SetRowCellValue(iRow, GridCol宽度2, txt宽度2.Text.Trim());
                    if (lookUpEdit材料类型.Text == "棒")
                    {
                        gridView1.SetRowCellValue(iRow, GridCol宽度1, txt宽度2.Text.Trim());
                        gridView1.SetRowCellValue(iRow, GridCol宽度3, txt宽度2.Text.Trim());
                    }
                }
                if (txt长度2.Text != "")
                {
                    gridView1.SetRowCellValue(iRow, GridCol长度2, txt长度2.Text.Trim());
                }
                if (txt数量2.Text != "")
                {
                    gridView1.SetRowCellValue(iRow, GridCol数量2, txt数量2.Text.Trim());
                }
                if (gridView1.GetRowCellDisplayText(iRow, GridCol厚度3) == "")
                {
                    gridView1.SetRowCellValue(iRow, GridCol厚度3, txt厚度2.Text.Trim());
                }
            }
            #region 得到重量
            if (txt密度.Text.Trim() != "")
            {
                decimal d材料密度 = ReturnObjectToDecimal(txt密度.Text, 6);
                if (e.Column == GridCol厚度1 || e.Column == GridCol宽度1 || e.Column == GridCol长度1 || e.Column == GridCol数量1)
                {
                    decimal d厚度1 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol厚度1), 6);
                    decimal d宽度1 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol宽度1), 6);
                    decimal d长度1 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol长度1), 6);
                    decimal d数量1 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol数量1), 6);
                    decimal d = 0;
                    if (lookUpEdit材料类型.Text == "板")
                    {
                        d = d材料密度 * d厚度1 * d长度1 * d长度1 * d数量1 / 1000000;
                    }
                    if (lookUpEdit材料类型.Text == "棒")
                    {
                        d = d密度 * (d宽度1 / 2) * (d宽度1 / 2) * d长度1 * d材料密度 * d数量1 / 1000000;
                    }
                    gridView1.SetRowCellValue(iRow, GridCol重量1, ReturnFloat(d));
                }
                if (e.Column == GridCol厚度2 || e.Column == GridCol宽度2 || e.Column == GridCol长度2 || e.Column == GridCol数量2)
                {
                    decimal d厚度2 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol厚度2), 6);
                    decimal d宽度2 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol宽度2), 6);
                    decimal d长度2 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol长度2), 6);
                    decimal d数量2 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol数量2), 6);
                    decimal d = 0;
                    if (lookUpEdit材料类型.Text == "板")
                    {
                        d = d材料密度 * d厚度2 * d长度2 * d长度2 * d数量2 / 1000000;
                    }
                    if (lookUpEdit材料类型.Text == "棒")
                    {
                        d = d密度 * (d宽度2 / 2) * (d宽度2 / 2) * d长度2 * d材料密度 * d数量2 / 1000000;
                    }
                    gridView1.SetRowCellValue(iRow, GridCol重量2,  ReturnFloat(d));
                }
                if (e.Column == GridCol厚度3 || e.Column == GridCol宽度3 || e.Column == GridCol长度3 || e.Column == GridCol数量3)
                {
                    decimal d厚度3 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol厚度3), 6);
                    decimal d宽度3 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol宽度3), 6);
                    decimal d长度3 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol长度3), 6);
                    decimal d数量3 = ReturnObjectToDecimal(gridView1.GetRowCellValue(iRow, GridCol数量3), 6);
                    decimal d = 0;
                    if (lookUpEdit材料类型.Text == "板")
                    {
                        d = d材料密度 * d厚度3 * d长度3 * d长度3 * d数量3 / 1000000;
                    }
                    if (lookUpEdit材料类型.Text == "棒")
                    {
                        d = d密度 * (d宽度3 / 2) * (d宽度3 / 2) * d长度3 * d材料密度 * d数量3 / 1000000;
                    }
                    gridView1.SetRowCellValue(iRow, GridCol重量3,  ReturnFloat(d));
                }
            }
            #endregion

            
            #region 判断数量生成多行
            if (e.Column == GridCol数量3)
            {
                if (gridView1.GetRowCellValue(iRow, GridCol数量3) != null && gridView1.GetRowCellValue(iRow, GridCol数量3).ToString() != "")
                {
                    if (gridView1.GetRowCellValue(iRow, GridCol数量3).ToString() != "1")
                    {
                        double sum = double.Parse(gridView1.GetRowCellValue(iRow, GridCol数量3).ToString().Trim());
                        int thisrow = iRow;
                        if (sum > 1)
                        {
                            decimal newid = GetID(cinvcode);
                            gridView1.SetRowCellValue(thisrow, GridCol数量3, "1");
                            //if (gridView1.GetRowCellValue(thisrow, GridCol序列号3) == null || gridView1.GetRowCellValue(thisrow, GridCol序列号3).ToString().Trim() == "")
                            //{
                                gridView1.SetRowCellValue(thisrow, GridCol序列号3, newid);
                                newid = newid + 1;
                            //}
                            
                            for (int i = 2; i <= sum; i++)
                            {
                                gridView1.AddNewRow();

                                int newrow = gridView1.RowCount - 1;
                                gridView1.FocusedRowHandle = newrow;
                                gridView1.SetRowCellValue(newrow, GridCol存货编码1, gridView1.GetRowCellValue(thisrow, GridCol存货编码1).ToString());
                                gridView1.SetRowCellValue(newrow, GridCol存放区域, gridView1.GetRowCellValue(thisrow, GridCol存放区域));
                                gridView1.SetRowCellValue(newrow, GridCol序列号1, gridView1.GetRowCellValue(thisrow, GridCol序列号1));
                                gridView1.SetRowCellValue(newrow, GridCol类型, gridView1.GetRowCellValue(thisrow, GridCol类型));
                                gridView1.SetRowCellValue(newrow, GridCol厚度1, gridView1.GetRowCellValue(thisrow, GridCol厚度1));
                                gridView1.SetRowCellValue(newrow, GridCol长度1, gridView1.GetRowCellValue(thisrow, GridCol长度1));
                                gridView1.SetRowCellValue(newrow, GridCol宽度1, gridView1.GetRowCellValue(thisrow, GridCol宽度1));
                                gridView1.SetRowCellValue(newrow, GridCol数量1, gridView1.GetRowCellValue(thisrow, GridCol数量1));
                                gridView1.SetRowCellValue(newrow, GridCol重量1, gridView1.GetRowCellValue(thisrow, GridCol重量1));

                                gridView1.SetRowCellValue(newrow, GridCol厚度2, gridView1.GetRowCellValue(thisrow, GridCol厚度2));
                                gridView1.SetRowCellValue(newrow, GridCol长度2, gridView1.GetRowCellValue(thisrow, GridCol长度2));
                                gridView1.SetRowCellValue(newrow, GridCol宽度2, gridView1.GetRowCellValue(thisrow, GridCol宽度2));
                                gridView1.SetRowCellValue(newrow, GridCol数量2, gridView1.GetRowCellValue(thisrow, GridCol数量2));
                                gridView1.SetRowCellValue(newrow, GridCol重量2, gridView1.GetRowCellValue(thisrow, GridCol重量2));

                                gridView1.SetRowCellValue(newrow, GridCol厚度3, gridView1.GetRowCellValue(thisrow, GridCol厚度3));
                                gridView1.SetRowCellValue(newrow, GridCol长度3, gridView1.GetRowCellValue(thisrow, GridCol长度3));
                                gridView1.SetRowCellValue(newrow, GridCol宽度3, gridView1.GetRowCellValue(thisrow, GridCol宽度3));
                                gridView1.SetRowCellValue(newrow, GridCol重量3, gridView1.GetRowCellValue(thisrow, GridCol重量3));
                                gridView1.SetRowCellValue(newrow, GridCol存放区域3, gridView1.GetRowCellValue(thisrow, GridCol存放区域3));

                                gridView1.SetRowCellValue(newrow, GridCol数量3, "1");
                                gridView1.SetRowCellValue(newrow, GridCol序列号3, GetID(cinvcode));
                                newid = newid + 1;
                            }
                        }
                    }
                    else if (gridView1.GetRowCellValue(iRow, GridCol数量3).ToString() == "1")
                    {
                        if (gridView1.GetRowCellValue(iRow, GridCol序列号3).ToString().Trim() == "")
                        {
                            gridView1.SetRowCellValue(iRow, GridCol序列号3, GetID(cinvcode));
                        }
                    }
                }
                GetWeight();
            }
            #endregion

            if (e.Column == GridCol重量1 || e.Column == GridCol重量2 || e.Column == GridCol重量3)
            {
                GetWeight();
            }
        }
        /// <summary>
        /// 得到序号
        /// </summary>
        /// <param name="cinvcode"></param>
        /// <returns></returns>
        private int GetID(string cinvcode)
        {
            int d = 0;
            if (1==1)
            {
                string sSQL = "select  isnull(MAX(序列号),0) as 序列号 from @u8.材料入库单表体2 where 存货编码 = '" + cinvcode + "' ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                d = int.Parse(dt.Rows[0]["序列号"].ToString());

                sSQL = "select isnull(MAX(序列号1),0) as 序列号 from " +
                    "( " +
                    "select 序列号1 from @u8.开料单表体 where 存货编码1 = '" + cinvcode + "' " +
                    "union all " +
                    "select 序列号3 from @u8.开料单表体 where 存货编码3 = '" + cinvcode + "' " +
                    ")a "; 
                dt = clsSQLCommond.ExecQuery(sSQL);

                int s = int.Parse(dt.Rows[0]["序列号"].ToString());
                if (d < s)
                {
                    d = s;
                }
            }
            DataTable dts = (DataTable)gridControl1.DataSource;
            for (int i = 0; i < dts.Rows.Count; i++)
            {
                if (dts.Rows[i]["序列号1"].ToString() != "")
                {
                    int s = int.Parse(dts.Rows[i]["序列号1"].ToString());
                    if (s > d)
                    {
                        d = s;
                    }
                }

                if (dts.Rows[i]["序列号3"].ToString() != "")
                {
                    int s = int.Parse(dts.Rows[i]["序列号3"].ToString());
                    if (s > d)
                    {
                        d = s;
                    }
                }
            }
            d = d + 1;
            return d;
        }

        /// <summary>
        /// 根据存货编码，序列号获得厚度，宽度，长度
        /// </summary>
        /// <param name="sInvCode">存货编码</param>
        /// <param name="sXLH">序列号</param>
        /// <param name="dH">厚度</param>
        /// <param name="dK">宽度</param>
        /// <param name="dC">长度</param>
        private void GetInvXLH(string sInvCode, string sXLH,out decimal dH,out decimal dK,out decimal dC,out string 类型,out string 区域)
        {
            dH = 0; dK = 0; dC = 0; 类型 = ""; 区域 = "";

            string sSQL = "select 存货编码1,序列号1,厚度1,宽度1, 长度1,存放区域,类型 from @u8.开料单表体 where 存货编码1 = '" + sInvCode + "' and 序列号1 = '" + sXLH + "' " +
                            "union all select 存货编码3,序列号3,厚度3,宽度3, 长度3,存放区域3,类型 from @u8.开料单表体 where 存货编码3 = '" + sInvCode + "' and 序列号3 = '" + sXLH + "'" +
                            "union all select 存货编码,序列号,厚度,宽度, 长度,存放区域,类型 from @u8.材料入库单表体2 where 存货编码 = '" + sInvCode + "' and 序列号 = '" + sXLH + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                dH = ReturnObjectToDecimal(dt.Rows[0]["厚度1"], 6);
                dK = ReturnObjectToDecimal(dt.Rows[0]["宽度1"], 6);
                dC = ReturnObjectToDecimal(dt.Rows[0]["长度1"], 6);
                类型 = dt.Rows[0]["类型"].ToString();
                区域 = dt.Rows[0]["存放区域"].ToString();
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        /// <summary>
        /// 获得参照下拉框数据
        /// </summary>
        private void GetLookUp()
        {
            string sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit公司名称.Properties.DataSource = dt;

            sSQL = "select * from dbo._LookUpDate where iType = 5";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit存放区域.DataSource = dt;

            sSQL = "select * from dbo._LookUpDate where iType = 6";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit类型.DataSource = dt;

            sSQL = "select * from @u8.Inventory order by cInvCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditcInvCode.DataSource = dt;

            sSQL = "select cValue as iID from @u8.UserDefine where cID = 52 ";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit材料类型.Properties.DataSource = dt;
        }

        private void GetIDList()
        {
            sSQL = @"select 序列号 as 序列号1,宽度,厚度,长度,sum(数量) as 数量,iText as 区域 from  (
                select 存货编码,'' as 开料单号,序列号,数量,宽度,厚度,长度,存放区域,材料类型  from @u8.材料入库单表体2 left join @u8.材料入库单表头 on @u8.材料入库单表体2.入库单号=@u8.材料入库单表头.入库单号  where 审核 is not null  
                union all select 存货编码1,@u8.开料单表体.开料单号,序列号1,数量1*-1,宽度1,厚度1,长度1,存放区域,材料类型 from @u8.开料单表体 left join @u8.开料单表头 on @u8.开料单表体.开料单号=@u8.开料单表头.开料单号  where 审核 is not null   
                union all select 存货编码3,@u8.开料单表体.开料单号,序列号3,数量3,宽度3,厚度3,长度3,存放区域3,材料类型 from @u8.开料单表体  left join @u8.开料单表头 on @u8.开料单表体.开料单号=@u8.开料单表头.开料单号  where 审核 is not null   
                ) a left join (select * from dbo._LookUpDate where iType = 5) b on a.存放区域=b.iID where 存货编码='" + txt存货编码.Text + "' and 序列号<>''";


            if (txt开料单号.Text != "")
            {
                sSQL = sSQL + " and 开料单号 <> '" + txt开料单号.Text.Trim() + "'";
            }

            if (lookUpEdit材料类型.Text.Trim() != "")
            {
                sSQL = sSQL + " and 材料类型 = '" + lookUpEdit材料类型.Text.Trim() + "'";
            }
            sSQL = sSQL + " group by 序列号,宽度,厚度,长度,iText having sum(数量)>0";
            DataTable dtid = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit序列号1.DataSource = dtid;
        }

        private void SetEnable(bool b)
        {
            txt开料单号.Enabled = false;
            //lookUpEdit合金属性.Enabled = b;
            txt厚度2.Enabled = false;
            txt交货说明.Enabled = b;
            txt存货编码.Enabled = false;
            txt合金属性.Enabled = false;
            txt宽度2.Enabled = false;
            txt密度.Enabled = b;
            txt产品密度.Enabled = b;
            txt切割员.Enabled = b;
            text厂长签字.Enabled = b;
            text大锯床签字.Enabled = b;
            text带锯床签字.Enabled = b;
            text推锯床签字.Enabled = b;
            text大锯床签字.Enabled = b;
            text带锯床签字.Enabled = b;
            text推锯床签字.Enabled = b;
            txt算料人.Enabled = b;
            txt数量2.Enabled = b;
            lookUpEdit公司名称.Enabled = false;
            timeEdit交货时间.Enabled = b;
            dtm切割日期.Enabled = b;
            dtm算料日期.Enabled = b;
            dtm交货日期.Enabled = b;
            txt销售订单子表ID.Enabled = false;
            txt审核.Enabled = false;
            dtm审核日期.Enabled = false;
            txt记账.Enabled = false;
            dtm记账日期.Enabled = false;
            lookUpEdit材料类型.Enabled = false;

            gridView1.OptionsBehavior.Editable = b;
        }

        private void GetSize(string s, out string s1, out string s2, out string s3)
        {
            if (s.Split('*').Length == 2 )
            {
                s1 = ""; s2 = ""; s3 = "";
                string[] sS = s.Split('*');
                if (sS.Length == 2)
                {
                    s2 = sS[0];
                    s3 = sS[1];
                }
                lookUpEdit材料类型.EditValue = "棒";
            }
            else
            {
                s1 = ""; s2 = ""; s3 = "";
                string[] sS = s.Split('*');
                if (sS.Length == 3)
                {
                    s1 = sS[0];
                    s2 = sS[1];
                    s3 = sS[2];
                }
                lookUpEdit材料类型.EditValue = "板";
            }
        }

        private void ItemButtonEdit存货编码_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                gridView1.FocusedRowHandle -= 1;
                gridView1.FocusedRowHandle += 1;
            }
            catch { }
            int iRow = gridView1.FocusedRowHandle;
            string cinvcode = "";
            if (txt存货编码.Text != null)
            {
                cinvcode = txt存货编码.Text.ToString().Trim();
            }
            FrmInvInfo fInv = new FrmInvInfo(cinvcode);
            if (DialogResult.OK == fInv.ShowDialog())
            {
                fInv.Enabled = true;

                decimal dH = 0; decimal dK = 0; decimal dC = 0; string 类型 = ""; string 区域 = "";
                GetInvXLH(txt存货编码.Text.ToString().Trim(), gridView1.GetRowCellDisplayText(iRow, GridCol序列号1).ToString().Trim(), out dH, out dK, out dC, out 类型, out 区域);
                if (dH != 0)
                {
                    gridView1.SetRowCellValue(iRow, GridCol厚度1, dH);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, GridCol厚度1, DBNull.Value);
                }
                if (dK != 0)
                {
                    gridView1.SetRowCellValue(iRow, GridCol宽度1, dK);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, GridCol宽度1, DBNull.Value);
                }
                if (dC != 0)
                {
                    gridView1.SetRowCellValue(iRow, GridCol长度1, dC);
                }
                else
                {
                    gridView1.SetRowCellValue(iRow, GridCol长度1, DBNull.Value);
                }
                gridView1.SetRowCellValue(iRow, GridCol类型, 类型);
                gridView1.SetRowCellValue(iRow, GridCol存放区域, 区域);
            }
        }

        private double GetCurr(string s存货编码, string s序号, string s存放区域)
        {
            string sql =
              @"SELECT 存货编码,序列号,类型,存放区域,厚度,宽度,长度, SUM(数量) AS 现存量,b.cInvName as 存货名称
FROM
(
SELECT 存货编码,序列号,类型,存放区域,厚度,宽度,长度,数量,'' as 开料单号
FROM @u8.材料入库单表体2 
UNION ALL
SELECT distinct 存货编码1,序列号1,类型,存放区域,厚度1,宽度1,长度1,数量1 * -1,开料单号
FROM @u8.开料单表体
UNION ALL 
SELECT 存货编码3,序列号3,类型,存放区域3,厚度3,宽度3,长度3,数量3,开料单号
FROM @u8.开料单表体
)a left join @u8.Inventory b on a.存货编码 = b.cInvCode
WHERE 1=1 ";

            sql = sql.Replace("1=1", "1=1 and 存货编码 = '" + s存货编码 + "' and 序列号 = " + s序号 + " and 存放区域 = '" + s存放区域 + "'  ");

            if (txt开料单号.Text != "")
            {
                sql  =sql+" and (开料单号<>'" + txt开料单号.Text + "' or 开料单号 is null) ";
            }
            sql  =sql+" GROUP BY a.存货编码,序列号,类型,存放区域,厚度,宽度,长度,b.cInvName";
            DataTable dt = clsSQLCommond.ExecQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToDouble(dt.Rows[0]["现存量"]);
            }
            else
            {
                return 0;
            }
        }

        private void txt密度_EditValueChanged(object sender, EventArgs e)
        {
            GetWeight();
        }


        private void txt产品密度_EditValueChanged(object sender, EventArgs e)
        {
            GetWeight();
        }

        private void txt厚度2_EditValueChanged(object sender, EventArgs e)
        {
            GetWeight();
        }

        private void txt宽度2_EditValueChanged(object sender, EventArgs e)
        {
            GetWeight();
        }

        private void txt长度2_EditValueChanged(object sender, EventArgs e)
        {
            GetWeight();
        }

        private void txt数量2_EditValueChanged(object sender, EventArgs e)
        {
            GetWeight();
        }

        private void GetWeight()
        {
            try
            {
                DataTable dts = (DataTable)gridControl1.DataSource;
                if (dts != null)
                {
                    decimal sum1 = 0;
                    decimal count1 = 0;
                    decimal sum2 = 0;
                    decimal count2 = 0;
                    decimal 材料密度 = ReturnDecimal(txt密度.Text, 6);
                    decimal 产品密度 = ReturnDecimal(txt产品密度.Text, 6);
                    decimal d厚度2 = ReturnDecimal(txt厚度2.Text, 6);
                    decimal d宽度2 = ReturnDecimal(txt宽度2.Text, 6);
                    decimal d长度2 = ReturnDecimal(txt长度2.Text, 6);
                    decimal d数量2 = ReturnDecimal(txt数量2.Text, 6);
                    decimal d = 0;
                    if (lookUpEdit材料类型.Text == "板")
                    {
                        sum2 = d厚度2 * d宽度2 * d长度2 * 材料密度 * d数量2 / 1000000;
                        count2 = d厚度2 * d宽度2 * d长度2 * 产品密度 * d数量2 / 1000000;
                    }
                    if (lookUpEdit材料类型.Text == "棒")
                    {
                        sum2 = d密度 * (d宽度2 / 2) * (d宽度2 / 2) * d长度2 * 材料密度 * d数量2 / 1000000;
                        count2 = d密度 * (d宽度2 / 2) * (d宽度2 / 2) * d长度2 * 产品密度 * d数量2 / 1000000;
                    }
                    decimal sum3 = 0;
                    decimal count3 = 0;
                    DataTable dtid = new DataTable();
                    dtid.Columns.Add("id");
                    for (int i = 0; i < dts.Rows.Count; i++)
                    {
                        if (dts.Rows[i]["序列号1"].ToString() != "")
                        {
                            if (dtid.Select("ID='" + dts.Rows[i]["序列号1"].ToString() + "'").Length == 0)
                            {
                                decimal d厚度1 = ReturnDecimal(dts.Rows[i]["厚度1"].ToString(), 6);
                                decimal d宽度1 = ReturnDecimal(dts.Rows[i]["宽度1"].ToString(), 6);
                                decimal d长度1 = ReturnDecimal(dts.Rows[i]["长度1"].ToString(), 6);
                                decimal d数量1 = ReturnDecimal(dts.Rows[i]["数量1"].ToString(), 6);
                                
                                if (lookUpEdit材料类型.Text == "板")
                                {
                                    sum1 = sum1 + d厚度1 * d宽度1 * d长度1 * d数量1 * 材料密度 / 1000000;
                                    count1 = count1 + d厚度1 * d宽度1 * d长度1 * d数量1 * 产品密度 / 1000000;
                                }
                                if (lookUpEdit材料类型.Text == "棒")
                                {
                                    sum1 = sum1 + d密度 * (d宽度1 / 2) * (d宽度1 / 2) * d长度1 * 材料密度 * d数量1 / 1000000;
                                    count1 =count1+ d密度 * (d宽度1 / 2) * (d宽度1 / 2) * d长度1 * 产品密度 * d数量1 / 1000000;
                                }
                                DataRow dw = dtid.NewRow();
                                dw["id"] = dts.Rows[i]["序列号1"].ToString();
                                dtid.Rows.Add(dw);
                            }
                        }
                        if (dts.Rows[i]["序列号3"].ToString() != "" && dts.Rows[i]["重量3"].ToString() != "")
                        {
                            decimal d厚度3 = ReturnDecimal(dts.Rows[i]["厚度3"].ToString(), 6);
                            decimal d宽度3 = ReturnDecimal(dts.Rows[i]["宽度3"].ToString(), 6);
                            decimal d长度3 = ReturnDecimal(dts.Rows[i]["长度3"].ToString(), 6);
                            decimal d数量3 = ReturnDecimal(dts.Rows[i]["数量3"].ToString(), 6);

                            
                            if (lookUpEdit材料类型.Text == "板")
                            {
                                sum3 = sum3 + d厚度3 * d宽度3 * d长度3 * d数量3 * 材料密度 / 1000000;
                                count3 = count3 + d厚度3 * d宽度3 * d长度3 * d数量3 * 产品密度 / 1000000;
                            }
                            if (lookUpEdit材料类型.Text == "棒")
                            {
                                sum3 = sum3 + d密度 * (d宽度3 / 2) * (d宽度3 / 2) * d长度3 * 材料密度 * d数量3 / 1000000;
                                count3 = count3 + d密度 * (d宽度3 / 2) * (d宽度3 / 2) * d长度3 * 产品密度 * d数量3 / 1000000;
                            }
                        }
                    }
                    textEdit原始尺寸材料重量.Text =ReturnFloat(sum1).ToString();
                    textEdit原始尺寸产品重量.Text = ReturnFloat(count1).ToString();
                    textEdit切割材料重量.Text = ReturnFloat(sum2).ToString();
                    textEdit切割产品重量.Text = ReturnFloat(count2).ToString();
                    textEdit剩下尺寸材料重量.Text = ReturnFloat(sum3).ToString();
                    textEdit剩下尺寸产品重量.Text = ReturnFloat(count3).ToString();

                    float 废料重量 = ReturnFloat(sum1-sum2-sum3);
                    txt废料重量.Text = ReturnFloat(废料重量).ToString();
                    if (sum2 != 0)
                    {
                        float per = ReturnFloat(废料重量 * 100 / ReturnFloat(sum2));
                        txt废料重量百分率.Text = per.ToString();
                    }

                    if (txt产品密度.Text != "")
                    {
                        txt实际用料重量.Text = ReturnFloat((sum1 - sum3)).ToString();
                    }

                }
            }
            catch
            {
            }
        }

        protected float ReturnFloat(object o)
        {
            float d = 0;
            try
            {
                d = float.Parse(Math.Round(Convert.ToDecimal(o), 2).ToString());
            }
            catch { }
            return d;
        }

        private void lookUpEdit合金属性_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected decimal ReturnDecimal(object o)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), 6);
            }
            catch { }
            return d;
        }
        protected decimal ReturnDecimal(object o, int iLength)
        {
            decimal d = 0;
            try
            {
                d = decimal.Round(Convert.ToDecimal(o), iLength);
            }
            catch { }
            return d;
        }

        private void lookUpEdit材料类型_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit材料类型.Text.Trim() == "板")
            {
                GridCol厚度1.Visible = true;
                GridCol宽度1.Caption = "宽度1";

                GridCol厚度2.Visible = true;
                GridCol宽度2.Caption = "宽度2";

                GridCol厚度3.Visible = true;
                GridCol宽度3.Caption = "宽度3";

                layoutControlItem14.Text = "宽度";

                GridCol宽度2.OptionsColumn.AllowEdit = true;
            }
            if (lookUpEdit材料类型.Text.Trim() == "棒")
            {
                GridCol厚度1.Visible = false;
                GridCol宽度1.Caption = "直径1";

                GridCol厚度2.Visible = false;
                GridCol宽度2.Caption = "直径2";

                GridCol厚度3.Visible = false;
                GridCol宽度3.Caption = "直径3";

                layoutControlItem14.Text = "直径";

                GridCol宽度2.OptionsColumn.AllowEdit = false;
            }
            GetIDList();
            for (int i = gridView1.RowCount-1; i >=0 ; i--)
            {
                gridView1.DeleteRow(i);
            }
            gridView1.AddNewRow();
            gridView1.FocusedRowHandle = 0;
        }
    }
}
