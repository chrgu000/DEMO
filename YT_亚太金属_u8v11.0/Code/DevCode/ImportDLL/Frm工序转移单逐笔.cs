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
    public partial class Frm工序转移单逐笔 : FrameBaseFunction.FrmFromModel
    {
        string tablename = "@u8.sfc_optransform";
        string tableid = "TransformId";
        //string tablecode = "cSOCode";
        //string tablenames = "SO_SODetails";

        //public DataSet ds;

        TH.DAL.sfc_optransform sfc_optransform = new TH.DAL.sfc_optransform();

        long iID = -1;
        //public string 单据号1 = "";
        //public string 单据号2 = "";
        //public string 单据日期1 = "";
        //public string 单据日期2 = "";
        //public string 制单日期1 = "";
        //public string 制单日期2 = "";
        //public string 业务员 = "";
        //public string 部门 = "";
        //public string 客户1 = "";
        //public string 客户2 = "";
        //public string 审核日期1 = "";
        //public string 审核日期2 = "";
        //public string 制单人1 = "";
        //public string 制单人2 = "";
        //public string 审核人1 = "";
        //public string 审核人2 = "";
        //public string 物料1 = "";
        //public string 物料2 = "";


        public Frm工序转移单逐笔(long siID)
        {
            //iID = siID;
            InitializeComponent();

        }

        public Frm工序转移单逐笔()
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

            }
            else
            {
                //layoutControl1.HideCustomizationForm();
                layoutControl1.AllowCustomizationMenu = false;

                if (!Directory.Exists(base.sProPath + "\\layout"))
                    Directory.CreateDirectory(base.sProPath + "\\layout");

                base.toolStripMenuBtn.Items["Layout"].Text = "布局";

                DialogResult d = MessageBox.Show("是否保存?\n是：保存界面样式\n否：恢复默认界面样式,下次加载时将以默认样式打开\n", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (d == DialogResult.Yes)
                {
                    layoutControl1.SaveLayoutToXml(sLayoutHeadPath);
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
            //if (审核日期2 != "")
            //{
            //    sSQL = sSQL + " and dVerifysysTime<='" + 审核日期2 + "'";
            //}
            //if (制单人1 != "")
            //{
            //    sSQL = sSQL + " and dCreatesysPerson>='" + 制单人1 + "'";
            //}
            //if (制单人2 != "")
            //{
            //    sSQL = sSQL + " and dCreatesysPerson<='" + 制单人2 + "'";
            //}
            //if (审核人1 != "")
            //{
            //    sSQL = sSQL + " and dVerifysysPerson>='" + 审核人1 + "'";
            //}
            //if (审核人2 != "")
            //{
            //    sSQL = sSQL + " and dVerifysysPerson<='" + 审核人2 + "'";
            //}
            //if (物料1 != "")
            //{
            //    sSQL = sSQL + " and cInvCode>='" + 物料1 + "'";
            //}
            //if (物料2 != "")
            //{
            //    sSQL = sSQL + " and cInvCode<='" + 物料2 + "'";
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
                sSQL = "select min(TransformId) as TransformId from " + tablename + "  where 1=1 ";
                sSQL = sSQL + " order by TransformId";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    txtTransformId.EditValue = Convert.ToInt64(dt.Rows[0]["TransformId"]); 
                    iID = Convert.ToInt64(dt.Rows[0]["TransformId"]);
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
                    sSQL = "select TransformId from " + tablename + " where TransformId<" + txtTransformId.EditValue.ToString().Trim() + " ";
                    sSQL = sSQL + " order by TransformId desc";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        txtTransformId.EditValue = Convert.ToInt64(dt.Rows[0]["TransformId"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["TransformId"]); ;
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
                    sSQL = "select TransformId from " + tablename + " where TransformId>" + txtTransformId.EditValue.ToString().Trim() + " ";

                    sSQL = sSQL + " order by TransformId";

                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt.Rows.Count > 0)
                    {
                        txtTransformId.EditValue = Convert.ToInt64(dt.Rows[0]["TransformId"]); ;
                        iID = Convert.ToInt64(dt.Rows[0]["TransformId"]); ;
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
                sSQL = "select isnull(max(TransformId),-1) as TransformId from " + tablename + " where 1=1 ";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt.Rows.Count > 0)
                {
                    txtTransformId.EditValue = Convert.ToInt64(dt.Rows[0]["TransformId"]); 
                    iID = Convert.ToInt64(dt.Rows[0]["TransformId"]); ;
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
        }
        /// <summary>
        /// 新增
        /// </summary>
        private void btnAdd()
        {
            GetNull();
            SetEnabled(true);

            sSQL = "select a.*,'' as cInvCode,'' as cInvName,'' as cInvStd, '' as OpSeq,'' as 转入工序,'edit' as iSave,'' as 可用数量,'' as 订单数量 from " + tablename + " a where 1=-1";
            dtBingGrid = clsSQLCommond.ExecQuery(sSQL);
            txtTransformId.Focus();
            sState = "add";

        }
        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {

        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {

        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {

            try
            {
                for (int j = dtBingGrid.Rows.Count - 1; j >= 0; j--)
                {
                    dtBingGrid.Rows.Remove(dtBingGrid.Rows[j]);
                }


                DataRow dw = dtBingGrid.NewRow();
                dw["MoId"] = txtMoId.EditValue;
                dw["MoDId"] = txtMoDId.EditValue;
                dw["MoRoutingDId"] = txtMoRoutingDId.EditValue;
                dw["MoRoutingId"] = txtMoRoutingId.EditValue;
                dw["InMoRoutingDId"] = lookUp移入工序.EditValue;
                dw["DocDate"] = txt单据日期.EditValue;
                dw["OpSeq"] = txt移出工序.EditValue;
                dw["TransformType"] = lookUp移动类型.EditValue;
                dw["OpStatus"] = lookUp转出状态.EditValue;
                dw["OutQcFlag"] = chk是否转出检验.Checked;
                dw["QcFlag"] = chk是否转入检验.Checked;

                dw["可用数量"] = txt可用数量.Text;
                dw["订单数量"] = txt订单数量.Text;
                if (txt合格数量.EditValue != "")
                {
                    dw["QualifiedQty"] = txt合格数量.EditValue;
                }
                if (txt报废数量.EditValue != "")
                {
                    dw["ScrapQty"] = txt报废数量.EditValue;
                }
                if (txt拒绝数量.EditValue != "")
                {
                    dw["RefusedQty"] = txt拒绝数量.EditValue;
                }
                if (txt报检数量.EditValue != "")
                {
                    dw["DeclareQty"] = txt报检数量.EditValue;
                }
                if (txt加工数量.EditValue != "")
                {
                    dw["MachiningQty"] = txt加工数量.EditValue;
                }
                if (txt报检数量.EditValue != "")
                {
                    dw["DeclaredQty"] = txt报检数量.EditValue;
                }
                if (txt报废数量.EditValue != "")
                {
                    dw["ScrapQty"] = txt报废数量.EditValue;
                }
                if (txt定额工时.EditValue != "")
                {
                    dw["Define7"] = txt定额工时.EditValue;
                }
                if (txt劳动工时.EditValue != "")
                {
                    dw["Define16"] = txt劳动工时.EditValue;
                }
                if (txt移入工作中心.EditValue != "")
                {
                    dw["Define11"] = txt移入工作中心.EditValue;
                }
                if (txt移出工作中心.EditValue != "")
                {
                    dw["Define12"] = txt移出工作中心.EditValue;
                }
                dw["Define9"] = lookUp工厂.Text;
                dtBingGrid.Rows.Add(dw);
                DataTable dt = dtBingGrid.Copy();
                TH.DAL.sfc_optransform sfc_optransform = new TH.DAL.sfc_optransform();
                string iCou = sfc_optransform.Save(dt,1);

                if (iCou == "")
                {
                    MessageBox.Show("保存成功");
                    GetNull();
                    sState = "sel";
                    SetEnabled(false);
                }
                else
                    throw new Exception(iCou);

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
            GetGrid();
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
           
        }

        #endregion

        private void Frm工序转移单逐笔_Load(object sender, EventArgs e)
        {
            try
            {
                SetEnabled(false);
                SetLookUpEdit();
                GetNull();
                GetGrid();
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
                sSQL = @"select * from " + tablename + "  where TransformId=" + iID + " ";

                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt.Rows.Count > 0)
                {
                    txtTransformId.EditValue = dt.Rows[0]["TransformId"].ToString();
                    
                    txtMoId.EditValue = dt.Rows[0]["MoId"].ToString();
                    txtMoDId.EditValue = dt.Rows[0]["MoDId"].ToString();
                    txtMoRoutingId.EditValue = dt.Rows[0]["MoRoutingId"].ToString();
                    string MoRoutingDId = dt.Rows[0]["MoRoutingDId"].ToString();
                    txtDocCode.EditValue = dt.Rows[0]["DocCode"].ToString();
                    if (MoRoutingDId.Length != 10)
                    {
                        MoRoutingDId = sGetCode(ReturnObjectToLong(dt.Rows[0]["MoRoutingDId"].ToString()), 10);
                    }
                    txtMoRoutingDId.EditValue = MoRoutingDId;

                    txtMoRoutingDId_Validated(null, null);

                    lookUp移入工序.EditValue = ReturnObjectToInt(dt.Rows[0]["MoRoutingDId"].ToString());
                    txt单据日期.EditValue = dt.Rows[0]["DocDate"].ToString();

                    //txt移出工序.EditValue = dt.Rows[0]["OpSeq"].ToString();
                    lookUp移动类型.EditValue = dt.Rows[0]["TransformType"].ToString();
                    lookUp转出状态.EditValue = dt.Rows[0]["OpStatus"].ToString();
                    if (dt.Rows[0]["OutQcFlag"].ToString() == "True")
                    {
                        chk是否转出检验.Checked = true;
                    }
                    else
                    {
                        chk是否转出检验.Checked = false;
                    }

                    if (dt.Rows[0]["QcFlag"].ToString() == "True")
                    {
                        chk是否转入检验.Checked = true;
                    }
                    else
                    {
                        chk是否转入检验.Checked = false;
                    }

                    txt合格数量.EditValue = dt.Rows[0]["QualifiedQty"].ToString();

                    txt报废数量.EditValue = dt.Rows[0]["ScrapQty"].ToString();
                    txt拒绝数量.EditValue = dt.Rows[0]["RefusedQty"].ToString();
                    txt报检数量.EditValue = dt.Rows[0]["DeclareQty"].ToString();
                    txt加工数量.EditValue = dt.Rows[0]["MachiningQty"].ToString();
                    txt报检数量.EditValue = dt.Rows[0]["DeclaredQty"].ToString();

                    txt定额工时.EditValue = dt.Rows[0]["Define7"].ToString();
                    txt劳动工时.EditValue = dt.Rows[0]["Define16"].ToString();

                    txt移入工作中心.EditValue = dt.Rows[0]["Define11"].ToString();
                    txt移出工作中心.EditValue = dt.Rows[0]["Define12"].ToString();
                    lookUp工厂.EditValue = dt.Rows[0]["Define9"].ToString();

                    

                    SetEnabled(false);

                    sState = "sel";


                }
                else
                {
                    GetNull();
                    SetEnabled(false);

                }
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

            lookUp转出状态.Properties.DataSource = dtOpStatus;

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

            lookUp移动类型.Properties.DataSource = dtTransformType;

            sSQL = @"Select cast(0 as bit) as bRefSelectColumn,[UserdefineEntity_UserDefine].[cAlias] as ID,[UserdefineEntity_UserDefine].[cValue] as Name
 
FROM @u8.[UserDefine] AS [UserdefineEntity_UserDefine]
 
 WHERE   [UserdefineEntity_UserDefine].[cID]='09'";
            DataTable dt工厂 = clsSQLCommond.ExecQuery(sSQL);
            lookUp工厂.Properties.DataSource = dt工厂;
        }

        private void SetEnabled(bool b)
        {
            txtTransformId.Enabled = b;
            txtMoDId.Enabled = false;
            txtMoId.Enabled = false;
            txtMoRoutingDId.Enabled = b;
            txtMoRoutingId.Enabled = false;
            txt报废数量.Enabled = b;
            txt备注.Enabled = b;
            txtDocCode.Enabled = false;
            txt单据日期.Enabled = b;
            txt订单数量.Enabled = false;
            txt定额工时.Enabled = b;
            txt合格数量.Enabled = b;
            txt加工数量.Enabled = b;
            txt拒绝数量.Enabled = b;
            txt可用数量.Enabled = false;
            txt劳动工时.Enabled = b;
            txt生产订单.Enabled = false;
            txt生产订单行号.Enabled = false;
            txt物料编码.Enabled = false;
            txt物料规格.Enabled = false;
            txt物料名称.Enabled = false;
            txt移出工序.Enabled = false;
            txt报检数量.Enabled = b;
            lookUp移动类型.Enabled = b;
            lookUp移入工序.Enabled = b;
            lookUp转出状态.Enabled = b;
            chk是否转出检验.Enabled = b;
            chk是否转入检验.Enabled = b;
            lookUp工厂.Enabled = b;

        }

        private void GetNull()
        {
            txtMoDId.EditValue = "";
            txtMoId.EditValue = "";
            txtMoRoutingDId.EditValue = "";
            txtMoRoutingId.EditValue = "";
            txt报废数量.EditValue = "";
            txt备注.EditValue = "";
            txt单据日期.EditValue = null;
            txt订单数量.EditValue = "";
            txt定额工时.EditValue = "";
            txt合格数量.EditValue = "";
            txt加工数量.EditValue = "";
            txt拒绝数量.EditValue = "";
            txt可用数量.EditValue = "";
            txt劳动工时.EditValue = "";
            txt生产订单.EditValue = "";
            txt生产订单行号.EditValue = "";
            txt物料编码.EditValue = "";
            txt物料规格.EditValue = "";
            txt物料名称.EditValue = "";
            txt移出工序.EditValue = "";
            txt报检数量.EditValue = "";
            lookUp移动类型.EditValue = "";
            lookUp移入工序.EditValue = "";
            lookUp转出状态.EditValue = "";
            chk是否转出检验.Checked = true;
            chk是否转入检验.Checked = true;
            lookUp工厂.EditValue = "";
            textEdit移出工序说明.EditValue = "";
            textEdit移入工序说明.EditValue = "";
            txtDocCode.EditValue = "";
            txtTransformId.EditValue = "";

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

        private void txtMoRoutingDId_Validated(object sender, EventArgs e)
        {
            try
            {
                string sBarCode = txtMoRoutingDId.Text.Trim();
                
                if (sBarCode.Length == 0)
                {
                    return;
                }
                if (sBarCode.Length != 10)
                {
                    throw new Exception("条形码长度不正确");
                }
                sBarCode = ReturnObjectToLong(sBarCode).ToString().Trim();
                
                string sSQL = @"select a.*,b.*,i.cInvCode,i.cInvName,i.cInvStd,mm.MoCode,m.SortSeq,e.Define35  from  @u8.sfc_morouting a 
left join @u8.sfc_moroutingdetail b on a.MoRoutingId =b.MoRoutingId 
left join @u8.mom_orderdetail m on b.MoDId=m.MoDId 
left join @u8.mom_order mm on mm.MoId=m.MoId
inner join @u8.sfc_moroutingdetail d on d.modid = m.modid
inner join @u8.sfc_operation e on e.OperationId = d.OperationId 
left join dbo.生产工序日计划 r on b.MoRoutingDId=r.生产订单工艺路线明细ID 
left join @u8.Inventory i on m.InvCode=i.cInvCode where b.MoRoutingDId=" +ReturnObjectToLong( sBarCode);


                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtMoId.EditValue = dt.Rows[0]["MoId"];
                    txtMoDId.EditValue = dt.Rows[0]["MoDId"];
                    txtMoRoutingId.EditValue = dt.Rows[0]["MoRoutingId"];
                    txt单据日期.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                    txt物料编码.EditValue = dt.Rows[0]["cInvCode"];
                    txt物料名称.EditValue = dt.Rows[0]["cInvName"];
                    txt物料规格.EditValue = dt.Rows[0]["cInvStd"];
                    txt移出工序.EditValue = dt.Rows[0]["OpSeq"];
                    lookUp移动类型.EditValue = "1";
                    lookUp转出状态.EditValue = "1";
                    chk是否转出检验.Checked = true;
                    chk是否转入检验.Checked = true;
                    txt订单数量.EditValue = dt.Rows[0]["Qty"];
                    txt生产订单.EditValue = dt.Rows[0]["MoCode"];
                    txt生产订单行号.EditValue = dt.Rows[0]["SortSeq"]; 
                    
                }
                else
                {
                    throw new Exception("获得条码信息失败");
                }
                txtTransformId.Focus();
                //txtTransformId.Text = "";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

        /// <summary>
        /// 根据序号组装单据号
        /// </summary>
        /// <param name="l"></param>
        /// <param name="iLength"></param>
        /// <param name="s前缀"></param>
        /// <returns></returns>
        private string sGetCode(long l, int iLength)
        {
            string sCode = l.ToString();
            for (int i = 0; i < iLength; i++)
            {
                if (sCode.Length < iLength)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return sCode;
        }
        private void txt移出工序_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMoDId.EditValue.ToString() != null && txtMoDId.EditValue.ToString() != "")
            {
                string sSQL = @" SELECT cast(0 as bit) as bRefSelectColumn,MoRoutingDId,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[OpSeq] as OpSeq,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[Description] as Description,[MMMomOrderdetailEntity_mom_orderdetail].[Qty] as Qty,[MMVBasInventoryEntity_v_bas_inventory].[ComUnitName] as ComUnitName,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[DueDate] as DueDate,[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[StartDate] as StartDate,[MMWorkCenterEntity_sfc_workcenter].[WcCode] as WcCode,[MMWorkCenterEntity_sfc_workcenter].[Description] as WcDescription 
                    FROM @u8.[sfc_morouting] AS [MMSfcMoroutingEntity_sfc_morouting]
                    LEFT JOIN @u8.[v_mom_orderdetail_all] AS [MMMomOrderdetailEntity_mom_orderdetail] ON [MMSfcMoroutingEntity_sfc_morouting].[MoDId]=[MMMomOrderdetailEntity_mom_orderdetail].[MoDId]
                    LEFT JOIN @u8.[bas_part] AS [MMPartEntity_bas_part] ON [MMMomOrderdetailEntity_mom_orderdetail].[PartId]=[MMPartEntity_bas_part].[PartId]
                    LEFT JOIN @u8.[v_bas_inventory] AS [MMVBasInventoryEntity_v_bas_inventory] ON [MMPartEntity_bas_part].[InvCode]=[MMVBasInventoryEntity_v_bas_inventory].[InvCode]
                    LEFT JOIN @u8.[sfc_moroutingdetail] AS [MMSfcMoroutingdetailEntity_sfc_moroutingdetail] ON [MMSfcMoroutingEntity_sfc_morouting].[MoRoutingId]=[MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[MoRoutingId]
                    LEFT JOIN @u8.[sfc_workcenter] AS [MMWorkCenterEntity_sfc_workcenter] ON [MMSfcMoroutingdetailEntity_sfc_moroutingdetail].[WcId]=[MMWorkCenterEntity_sfc_workcenter].[WcId]
                     
                     WHERE 1=1  and [MMSfcMoroutingEntity_sfc_morouting].MoDId = " + txtMoDId.EditValue.ToString() + " order by OpSeq ";
                DataTable dt工序 = clsSQLCommond.ExecQuery(sSQL);
                lookUp移入工序.Properties.DataSource = dt工序;
                lookUp移入工序.EditValue = txt移出工序.EditValue;
                textEdit移出工序说明.EditValue = sfc_optransform.Get工序名称(txt移出工序.EditValue.ToString().Trim());
                if (txt移出工序.Text != "")
                {
                    
                    DataTable dt工作中心 = sfc_optransform.Get工序明细(lookUp移入工序.EditValue.ToString(), txtMoDId.EditValue.ToString());
                    if (dt工作中心.Rows.Count > 0)
                    {
                        txt移出工作中心.Text = dt工作中心.Rows[0]["WcDescription"].ToString();
                        textEdit移出工序说明.Text = dt工作中心.Rows[0]["Description"].ToString();
                        if (dt工作中心.Rows[0]["SubFlag"].ToString() == "True")
                        {
                            MessageBox.Show("委外工序已启用，委外工序正向移出状态不可为检验和加工");
                            txt移出工序.EditValue = "";
                            GetNull();
                        }
                    }
                }
                else
                {
                    txt移出工作中心.Text = "";
                    textEdit移出工序说明.EditValue = "";
                }
            }
        }

        private void lookUp转出状态_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMoDId.EditValue.ToString() != null && txtMoDId.EditValue.ToString() != "" && lookUp转出状态.EditValue.ToString()!="")
            {
                txt可用数量.EditValue = sfc_optransform.GetQty(txtMoDId.EditValue.ToString(), lookUp移入工序.EditValue.ToString(), lookUp转出状态.EditValue.ToString());
            }
        }

        private void lookUp移入工序_EditValueChanged(object sender, EventArgs e)
        {
            if (txtMoDId.EditValue.ToString() != null && txtMoDId.EditValue.ToString() != "" && lookUp移入工序.EditValue != null && lookUp转出状态.EditValue.ToString() != "")
            {
                txt可用数量.EditValue = sfc_optransform.GetQty(txtMoDId.EditValue.ToString(), lookUp移入工序.EditValue.ToString(), lookUp转出状态.EditValue.ToString());

                if (lookUp移入工序.Text != "")
                {
                    DataTable dt工作中心 = sfc_optransform.Get工序明细(lookUp移入工序.EditValue.ToString().Trim(), txtMoDId.EditValue.ToString());
                    if (dt工作中心.Rows.Count > 0)
                    {
                        txt移入工作中心.Text = dt工作中心.Rows[0]["WcDescription"].ToString();
                        textEdit移入工序说明.Text = dt工作中心.Rows[0]["Description"].ToString();
                        if (dt工作中心.Rows[0]["SubFlag"].ToString() == "True")
                        {
                            MessageBox.Show("委外工序已启用，不可正向移入委外工序");
                            lookUp移入工序.EditValue = null;
                        }
                    }
                }
                else
                {
                    txt移入工作中心.Text = "";
                    textEdit移入工序说明.EditValue = "";
                }
            }
        }

    }
}
