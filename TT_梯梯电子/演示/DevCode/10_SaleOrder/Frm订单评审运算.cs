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
using System.Collections;

namespace SaleOrder
{
    public partial class Frm订单评审运算 : FrameBaseFunction.Frm列表窗体模板
    {
        public Frm订单评审运算()
        {
            InitializeComponent();

            #region 禁止用户调整表格
            gridView评审计算.OptionsMenu.EnableColumnMenu = false;
            gridView评审计算.OptionsMenu.EnableFooterMenu = false;
            gridView评审计算.OptionsMenu.EnableGroupPanelMenu = false;
            gridView评审计算.OptionsMenu.ShowAutoFilterRowItem = false;
            gridView评审计算.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            gridView评审计算.OptionsMenu.ShowGroupSortSummaryItems = false;
            gridView评审计算.OptionsMenu.ShowGroupSummaryEditorItem = false;
            gridView评审计算.OptionsMenu.ShowAddNewSummaryItem  = DevExpress.Utils.DefaultBoolean.False;
            gridView评审计算.OptionsBehavior.FocusLeaveOnTab = true;
            gridView评审计算.OptionsCustomization.AllowColumnMoving = false;
            //gridView1.OptionsCustomization.

            #endregion

            sLayoutHeadPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Head.xml";
            sLayoutGridPath = base.sProPath + "\\layout\\" + this.Text.Trim() + "Grid.xml";

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

                sState = sBtnName.ToLower();

                btn变更部门.Text = "变更部门";
                gridCol生产部门编码.OptionsColumn.AllowEdit = false;
                gridCol生产部门名称.OptionsColumn.AllowEdit = false;
            }
            catch (Exception ee)
            {
                throw new Exception(sBtnText + " 失败! \n\n原因:\n  " + ee.Message);
            }
        }

        DataTable dt评审 = new DataTable();
        DataTable dt评审计算 = new DataTable();

        private void btnAdd()
        {
            try
            {
                dt评审 = new DataTable(); 
                dt评审计算 = new DataTable();
                //btnLock();

                radio逆排.Checked = true;

                string sErrInfo = "";
                DateTime d服务器时间 = ReturnObjectToDatetime(clsSQLCommond.ExecGetScalar("select getdate()"));

                Frm订单评审运算_SEL fSEL = new Frm订单评审运算_SEL();
                fSEL.ShowDialog();
                if (fSEL.DialogResult != DialogResult.OK)
                    throw new Exception("");

                sSQL = @"
select cast(1 as bit) as 选择,cast(0 as bit) as 锁定,cast(null as int) as 优先级
    ,a.ID as 销售订单ID,a.cSOCode as 销售订单号,a.dDate as 单据日期,b.cItemCode as 外销订单号,a.cDefine2 as 客户订单号
    ,a.cCusCode as 客户编码,a.dPreDateBT as 船期,a.dPreMoDateBT as 预完工日期,b.cDefine36 as 国外要求交期,a.cMemo as 备注 
    ,b.iRowNo as 销售订单行号,b.AutoID as 订单子表ID,b.cInvCode as 存货编码,b.cUnitID as 主计量编码,b.iQuantity as 数量,b.dPreDate as 船期 
    ,b.cDefine36 as 国外要求交期,b.dPreMoDate as 预完工日期,b.dPreMoDate as 评审下达完工日期,b.iQuantity as 评审数量 ,b.iSOsID
from @u8.SO_SOMain a inner join @u8.SO_SODetails b on a.ID = b.ID
where b.isosid in ({0})
order by a.dPreMoDateBT,b.AutoID
";

                sSQL = string.Format(sSQL, fSEL.sSOsID);
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                for(int i=0;i<dt.Rows.Count;i++)
                {
                    string siSOsID = dt.Rows[i]["iSOsID"].ToString().Trim();

                    for (int j = 0; j < fSEL.dtSO.Rows.Count; j++)
                    {
                        string sSOsID2 = fSEL.dtSO.Rows[j]["iSOsID"].ToString().Trim();

                        if (siSOsID == sSOsID2)
                        {
                            dt.Rows[i]["锁定"] = fSEL.dtSO.Rows[j]["锁定"];
                            dt.Rows[i]["优先级"] = fSEL.dtSO.Rows[j]["优先级"];
                        }
                    }
                }

                DataView dv = dt.DefaultView;
                dv.Sort = "锁定 desc,优先级";

                dt = dv.ToTable();

                //sSQL = "exec @u8.SP_ClearCurrentStock_ST ";
                //clsSQLCommond.ExecSql(sSQL);

                if (dt == null || dt.Rows.Count < 1)
                    throw new Exception("新增失败");

                object[] obj = new object[dt评审计算.Columns.Count];
                SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString2);
                conn.Open();
                //启用事务
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtBom = new DataTable();
                        dtBom = GetBomSQL(tran, dt.Rows[i]["存货编码"].ToString().Trim(),dt.Rows[i]["销售订单号"].ToString().Trim(), ReturnObjectToInt(dt.Rows[i]["销售订单行号"]), Convert.ToInt64(dt.Rows[i]["订单子表ID"]));

                        if (dtBom == null)
                        {
                            sErrInfo = sErrInfo + "物料" + dt.Rows[i]["存货编码"].ToString().Trim() + " 未设置BOM，不能展开\n";
                        }

                        for (int j = 0; j < dtBom.Rows.Count; j++)
                        {
                            int i级别 = dtBom.Rows[j]["级别"].ToString().Trim().Length;
                            string s母件 = dtBom.Rows[j]["母件编码"].ToString().Trim();
                            string s子件 = dtBom.Rows[j]["子件编码"].ToString().Trim();
                            string s母子对应 = dtBom.Rows[j]["母子对应"].ToString().Trim();

                            //decimal d数量 = BaseFunction.ReturnDecimal(dt.Rows[i]["数量"]);
                            //decimal d使用数量 =  BaseFunction.ReturnDecimal( dtBom.Rows[j]["使用数量"]);
                            //decimal d展开数量 = d数量 * d使用数量;

                            //dtBom.Rows[j]["净需求"] = d展开数量;

                            for (int k = j + 1; k < dtBom.Rows.Count; k++)
                            {
                                int i级别2 = dtBom.Rows[k]["级别"].ToString().Trim().Length;
                                if (i级别2 != i级别 + 1)
                                    continue;

                                string s母件2 = dtBom.Rows[k]["母件编码"].ToString().Trim();
                                string s子件2 = dtBom.Rows[k]["子件编码"].ToString().Trim();
                                string s母子对应2 = s母子对应 + "→" + s母件2;
                              
                                dtBom.Rows[k]["母子对应"] = s母子对应2;
                            }
                        }

                        for (int j = dtBom.Rows.Count - 1; j >= 0; j--)
                        {
                            if (dtBom.Rows[j]["供应类型"].ToString().Trim() != "虚拟件")
                                continue;
                            string s子件 = dtBom.Rows[j]["子件编码"].ToString().Trim();
                            string s母件 = dtBom.Rows[j]["母件编码"].ToString().Trim();
                            string s母子 = dtBom.Rows[j]["母子对应"].ToString().Trim();
                            int i销售订单行号 = ReturnObjectToInt(dtBom.Rows[j]["销售订单行号"]);
                            string s销售订单号 = dtBom.Rows[j]["销售订单号"].ToString().Trim();
                            decimal d使用 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtBom.Rows[j]["使用数量"]);

                            DataRow[] drListBom = dtBom.Select(" 母件编码 = '" + s子件 + "' and 销售订单号 = '" + s销售订单号 + "' and 销售订单行号 = " + i销售订单行号 + " and 母子对应 like '" + s母子 + "%'");
                            for (int k = 0; k < drListBom.Length; k++)
                            {
                                decimal d使用2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(drListBom[k]["使用数量"]);
                                drListBom[k]["使用数量"] = decimal.Round(d使用 * d使用2, 6);
                                drListBom[k]["母件编码"] = s母件;
                            }

                            dtBom.Rows.RemoveAt(j);
                        }

                        for (int j = 0; j < dtBom.Rows.Count; j++)
                        {
                            try
                            {
                                sSQL = "select isnull(cInvDefine3,0.00) as 最小批量,isnull(cInvDefine13,0.00) as 调整数量 from @u8.Inventory where cInvCode = '" + dtBom.Rows[j]["子件编码"].ToString().Trim() + "'";
                                DataTable dt最小批量 = clsSQLCommond.ExecQuery(sSQL);
                                decimal d1 = 0;
                                if (dt最小批量 != null && dt最小批量.Rows.Count > 0 && dt最小批量.Rows[0][0].ToString().Trim() != "")
                                {
                                    d1 = GetQTYRet0(dt最小批量.Rows[0][0]);
                                }
                                dtBom.Rows[j]["最小批量"] = d1;
                                dtBom.Rows[j]["调整数量"] = GetQTYRet0(dt最小批量.Rows[0]["调整数量"]);
                            }
                            catch { }

                            Frm物料供需分析 fSELQty = new Frm物料供需分析();

                            //if (dtBom.Rows[j]["子件编码"].ToString().Trim() == "B001")
                            //{ 
                            
                            //}
                            DataTable dtQty = fSELQty.Get物料供需分析汇总表(dtBom.Rows[j]["子件编码"].ToString().Trim(), dt.Rows[i]["销售订单号"].ToString().Trim(), 1);
                            if (dtQty != null && dtQty.Rows.Count > 0)
                            {
                                dtBom.Rows[j]["仓库现存量"] = GetQTYRet0(dtQty.Rows[0]["现存量"]);
                                dtBom.Rows[j]["待入库量"] = GetQTYRet0(dtQty.Rows[0]["待入库"]);
                                dtBom.Rows[j]["待出库量"] = GetQTYRet0(dtQty.Rows[0]["待出库"]);
                            }
                        }


                        //DataTable dt工时工序Temp = Get工时工序(tran, dt.Rows[i]["存货编码"].ToString().Trim(), dt.Rows[i]["销售订单行号"].ToString().Trim());
                        //if (dt工时工序Temp == null || dt工时工序Temp.Rows.Count < 1)
                        //{
                        //    //DialogResult d = MessageBox.Show("物料 " + dt.Rows[i]["存货编码"].ToString().Trim() + " 工时工序不存在，是否继续\n是：继续运算，需要手工调整日期\n否：退出", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        //    //if (d != DialogResult.Yes)
                        //    //{
                        //        //sErrInfo = sErrInfo + "物料 " + dt.Rows[i]["存货编码"].ToString().Trim() + " 工时工序不存在，需要手工调整日期\n";
                        //    //}
                        //}

                        if (i == 0)
                        {
                            dt评审计算 = dtBom.Copy();
                            //dt工时工序 = dt工时工序Temp.Copy();
                            obj = new object[dt评审计算.Columns.Count];
                        }
                        else
                        {
                            for (int j = 0; j < dtBom.Rows.Count; j++)
                            {
                                dtBom.Rows[j].ItemArray.CopyTo(obj, 0);
                                dt评审计算.Rows.Add(obj);
                            }
                            //for (int j = 0; j < dt工时工序Temp.Rows.Count; j++)
                            //{
                            //    object[] obj2 = new object[dt工时工序.Columns.Count];
                            //    dt工时工序Temp.Rows[j].ItemArray.CopyTo(obj2, 0);
                            //    dt工时工序.Rows.Add(obj2);
                            //}
                        }
                    }

                    for (int i = dt评审计算.Rows.Count - 1; i >= 0; i--)
                    {
                        if (dt评审计算.Rows[i]["级别"].ToString().Trim() == "")
                            dt评审计算.Rows[i]["级别"] = 0;
                        else
                        {
                            try
                            {
                                int i级别 = ReturnObjectToInt(dt评审计算.Rows[i]["级别"]);
                            }
                            catch
                            {
                                dt评审计算.Rows[i]["级别"] = dt评审计算.Rows[i]["级别"].ToString().Trim().Length;
                            }
                        }
                    }

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DateTime dtm = Convert.ToDateTime(dt.Rows[i]["评审下达完工日期"]);
                        string sSOCode = dt.Rows[i]["销售订单号"].ToString().Trim();
                        decimal dQty = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt.Rows[i]["数量"]);
                        int iRowNO = ReturnObjectToInt(dt.Rows[i]["销售订单行号"]);

                        InitBomN(tran, "--", "--", dQty, dtm, sSOCode, iRowNO, dQty);
                    }

                    bool b执行 = true;
                    if(sErrInfo.Trim().Length > 0)
                    {
                        if (DialogResult.OK == MsgBox("提示", sErrInfo))
                        {
                            b执行 = true;
                        }
                        else
                        {
                            b执行 = false;
                        }
                    }

                    if (b执行)
                    {
                        tran.Commit();
                    }
                    else
                    {
                        throw new Exception("新增动作已取消");
                    }
                }
                catch (Exception error)
                {
                    tran.Rollback();
                    throw new Exception(error.Message);
                }

                txt备注.Text = dt.Rows[0]["备注"].ToString().Trim();
                txt客户订单号.Text = dt.Rows[0]["客户订单号"].ToString().Trim();
                lookUpEdit客户.EditValue = dt.Rows[0]["客户编码"].ToString().Trim();
                txt外销订单号.Text = dt.Rows[0]["外销订单号"].ToString().Trim();
                txt销售订单ID.Text = dt.Rows[0]["销售订单ID"].ToString().Trim();
                txt销售订单号.Text = dt.Rows[0]["销售订单号"].ToString().Trim();
                txt评审备注.Text = "";
                txt制单人.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dtm制单日期.Text = d服务器时间.ToString("yyyy-MM-dd hh:mm:ss");

                gridControl销售订单列表.DataSource = dt;

                DataView dvSort = dt评审计算.DefaultView;
                //dvSort.Sort = " 子件编码,销售订单行号 ";
                dt评审 = dvSort.ToTable().Copy();

                bool bExists本次下单数量存档 = false;
                for (int i = 0; i < dt评审.Columns.Count; i++)
                {
                    if (dt评审.Columns[i].ColumnName.Trim() == "本次下单数量存档")
                    {
                        bExists本次下单数量存档 = true;
                        break;
                    }
                }

                if (!bExists本次下单数量存档)
                {
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "本次下单数量存档";
                    dt评审.Columns.Add(dc);
                    for (int i = 0; i < dt评审.Rows.Count; i++)
                    {
                        dt评审.Rows[i]["本次下单数量存档"] = BaseFunction.ReturnDecimal(dt评审.Rows[i]["本次下单数量"]);
                    }
                }
                gridControl评审计算.DataSource = dt评审;

                gridView评审计算.BestFitColumns();

                SetColEdit(true);

                sState = "add";
                //radio手工.Checked = true;

                save原始评审计算数据();
                //MessageBox.Show(save原始评审计算数据());
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }

        private string save原始评审计算数据()
        {
            try
            {
                ArrayList aList = new ArrayList();
                string sSQL = "select * from 订单评审运算原始数据 where 1=-1";
                DataTable dt订单评审运算原始数据 = clsSQLCommond.ExecQuery(sSQL);

                sSQL = "TRUNCATE TABLE [dbo].[订单评审运算原始数据]"; 
                aList.Add(sSQL);

                string s记录时间 = DateTime.Now.ToString();
                sSQL = "select getdate() ";
                DateTime d记录时间 = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));

                for (int i = 0; i < gridView评审计算.RowCount; i++)
                {
                    DataRow dr订单评审运算原始数据 = dt订单评审运算原始数据.NewRow();
                    dr订单评审运算原始数据["销售订单号"] = txt销售订单号.Text.Trim();
                    dr订单评审运算原始数据["销售订单行号"] = gridView评审计算.GetRowCellValue(i, gridCol销售订单行号).ToString().Trim();
                    dr订单评审运算原始数据["帐套号"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                    dr订单评审运算原始数据["销售订单子表ID"] = gridView评审计算.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim();
                    dr订单评审运算原始数据["根母件"] = gridView评审计算.GetRowCellValue(i, gridCol根母件).ToString().Trim();
                    dr订单评审运算原始数据["级别"] = gridView评审计算.GetRowCellValue(i, gridCol级别).ToString().Trim();
                    dr订单评审运算原始数据["母件编码"] = gridView评审计算.GetRowCellValue(i, gridCol母件编码).ToString().Trim();
                    dr订单评审运算原始数据["母件属性"] = gridView评审计算.GetRowCellValue(i, gridCol母件属性).ToString().Trim();
                    dr订单评审运算原始数据["子件行号"] = gridView评审计算.GetRowCellValue(i, gridCol子件行号).ToString().Trim();
                    dr订单评审运算原始数据["工序行号"] = gridView评审计算.GetRowCellValue(i, gridCol工序行号).ToString().Trim();
                    dr订单评审运算原始数据["子件编码"] = gridView评审计算.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                    if (gridView评审计算.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr订单评审运算原始数据["换算率"] = gridView评审计算.GetRowCellValue(i, gridCol换算率).ToString().Trim();
                    }
                    dr订单评审运算原始数据["供应类型"] = gridView评审计算.GetRowCellValue(i, gridCol供应类型).ToString().Trim();
                    dr订单评审运算原始数据["使用数量"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol使用数量));
                    dr订单评审运算原始数据["子件属性"] = gridView评审计算.GetRowCellValue(i, gridCol子件属性).ToString().Trim();
                    dr订单评审运算原始数据["仓库代号"] = gridView评审计算.GetRowCellValue(i, gridCol仓库代号).ToString().Trim();
                    dr订单评审运算原始数据["领料部门代号"] = gridView评审计算.GetRowCellValue(i, gridCol领料部门代号).ToString().Trim();
                    dr订单评审运算原始数据["生产部门编码"] = gridView评审计算.GetRowCellValue(i, gridCol生产部门编码).ToString().Trim();
                    dr订单评审运算原始数据["备注"] = gridView评审计算.GetRowCellValue(i, gridCol备注).ToString().Trim();
                    dr订单评审运算原始数据["需求数量"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol需求数量));
                    dr订单评审运算原始数据["本次下单数量"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol本次下单数量));
                    dr订单评审运算原始数据["开始日期"] = gridView评审计算.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    dr订单评审运算原始数据["完成日期"] = gridView评审计算.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    dr订单评审运算原始数据["置办周期"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol置办周期));
                    dr订单评审运算原始数据["质检周期"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol质检周期));
                    dr订单评审运算原始数据["生产日工时"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol生产日工时));
                    dr订单评审运算原始数据["单件生产工时"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol单件生产工时));
                    dr订单评审运算原始数据["生产工时"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol生产工时));
                    dr订单评审运算原始数据["母子对应"] = gridView评审计算.GetRowCellValue(i, gridCol母子对应).ToString().Trim();
                    dr订单评审运算原始数据["运算人"] = txt制单人.Text.Trim();
                    dr订单评审运算原始数据["运算时间"] = d记录时间;

                    dt订单评审运算原始数据.Rows.Add(dr订单评审运算原始数据);


                    sSQL = clsGetSQL.GetInsertSQL("订单评审运算原始数据", dt订单评审运算原始数据, dt订单评审运算原始数据.Rows.Count - 1);
                    aList.Add(sSQL);

                }
                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    return "保存原始成功";
                }
                else
                {
                    return "没有需要保存的原始数据";
                }
            }
            catch (Exception ee)
            {
                return "保持原始数据失败" + ee.Message;
            }
        }

        #region 新增状态排程计算

        DataTable dtBom = new DataTable();
        DataTable dt工时工序 = new DataTable();


        //private void InitBom上级母件(SqlTransaction tran, string sInvCode,string sInvCode2)
        //{
        //     string sWhere = " 母件编码 = '" + sInvCode + "' ";

        //    DataRow[] drList = dt评审计算.Select(sWhere);

        //    foreach (DataRow dr in drList)
        //    {
        //        dr["上级母件"] = sInvCode2 + dr["子件编码"].ToString().Trim();

        //        InitBom上级母件(tran, dr["子件编码"].ToString().Trim(), dr["上级母件"].ToString().Trim());
        //    }
        //}


        /// <summary>
        /// 新增状态逆排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="dQty">母件下单数量</param>
        /// <param name="dDate1">计划结束日期</param>
        /// <param name="dQty">母件净需求数量</param>
        private void InitBomN(SqlTransaction tran, string sInvCode,string  sInvCode2,decimal dQty, DateTime dDate1,string sSaleCode,int iSaleRow,decimal dQty2)
        {
            string sWhere = " 母件编码 = '" + sInvCode + "' and 母子对应 like '" + sInvCode2 + "%' and 销售订单号 = '" + sSaleCode + "' and 销售订单行号 = " + iSaleRow;

            DataRow[] drList = dt评审计算.Select(sWhere);

            if (sInvCode == "B001")
            { 
            
            }

            foreach (DataRow dr in drList)
            {
                decimal d当前物料累计下单 = 0;
                decimal d累计下单 = 0;
                for (int i = 0; i < dt评审计算.Rows.Count; i++)
                {
                    string s本次下单 = dt评审计算.Rows[i]["本次下单数量"].ToString().Trim();
                    if (s本次下单.Length == 0)
                        continue;
                    string s子件编码 = dt评审计算.Rows[i]["子件编码"].ToString().Trim();
                    if (s子件编码 != dr["子件编码"].ToString().Trim())
                        continue;
                    decimal d1 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt评审计算.Rows[i]["本次下单数量"]);
                    decimal d2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt评审计算.Rows[i]["需求数量"]);
                    d当前物料累计下单 = d当前物料累计下单 + d2 - d1 ;
                    d累计下单 = d累计下单 + d1;
                }
               
                decimal d需求数量 = decimal.Round(dQty * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["使用数量"]), 6);
                decimal d现存量 = GetQTYRet0(dr["仓库现存量"]);
                if (d现存量 <=FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(0.000001))
                    d现存量 = 0;

                decimal d待入库 = GetQTYRet0(dr["待入库量"]);
                decimal d待出库 = GetQTYRet0(dr["待出库量"]);
                decimal d最小批量 = GetQTYRet0(dr["最小批量"]);
                decimal d调整数量 = GetQTYRet0(dr["调整数量"]);
                decimal d当前行可用量 = d现存量 + d待入库 - d待出库 - d当前物料累计下单 - d调整数量;
                decimal d本次下单数量 = 0;

                dr["需求数量"] = d需求数量;
                dr["净需求"] = dQty2 * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["使用数量"]);

                if (d需求数量 == 0)
                {
                    d本次下单数量 = 0;
                }
                else
                {
                    if (d需求数量 > d当前行可用量)
                    {
                        d本次下单数量 = d需求数量 - d当前行可用量;
                        if (d累计下单 + d本次下单数量 < d最小批量)
                        {
                            d本次下单数量 = d最小批量;
                        }
                    }
                    else
                        d本次下单数量 = 0;
                }
                dr["本次下单数量"] = d本次下单数量;

                int i质检 = 0;
                if (dr["质检周期"].ToString().Trim() != "")
                {
                    i质检 = ReturnObjectToInt(dr["质检周期"]);
                }

                if (sInvCode == "--")
                {
                    dr["完成日期"] = dDate1;
                }
                else
                {
                    if (dr["子件属性"].ToString().Trim() == "自制")
                        dr["完成日期"] = dDate1.AddDays(-1);
                    else
                        dr["完成日期"] = dDate1.AddDays(-1 * i质检).AddDays(-1);
                }

                if (dr["置办周期"].ToString().Trim() == "")
                {
                    dr["置办周期"] = 1;
                }

                int i周期 = ReturnObjectToInt(dr["置办周期"]) ;
                dr["开始日期"] = Convert.ToDateTime(dr["完成日期"]).AddDays(-1 * i周期);

                InitBomN(tran, dr["子件编码"].ToString().Trim(), dr["母子对应"].ToString().Trim(), decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["本次下单数量"]), 6), Convert.ToDateTime(Convert.ToDateTime(dr["开始日期"]).ToString("yyyy-MM-dd")), sSaleCode, iSaleRow, BaseFunction.ReturnDecimal(dr["净需求"]));
            }
        }

        ///// <summary>
        ///// 顺排计划
        ///// </summary>
        ///// <param name="tran"></param>
        ///// <param name="sInvCode">子件编码</param>
        ///// <param name="dQty">本次下单数量</param>
        ///// <param name="dDate1">计划开始日期</param>
        //private void InitBomS(SqlTransaction tran, string sInvCode, decimal dQty, DateTime dDate1)
        //{
        //    DataRow[] drList = dtBom.Select(" 子件编码 = '" + sInvCode + "' ");

        //    foreach (DataRow dr in drList)
        //    {
        //        if (dr["子件属性"].ToString().Trim() == "自制")
        //        {
        //            DataRow[] dr工时List = dt工时工序.Select(" 物料编码 = '" + sInvCode + "' ");
        //            if (dr工时List.Length < 1)
        //            {
        //                //未设置母件工时工序，需要中其他母件工时工序表获得资料
        //            }

        //            double d工时 = 0;
        //            for (int i = 0; i < dr工时List.Length; i++)
        //            {
        //                if (dr工时List[i]["单位工时"].ToString().Trim() != "")
        //                {
        //                    d工时 = d工时 + Convert.ToDouble(dr工时List[i]["单位工时"]) * Convert.ToDouble(dr["本次下单数量"]) / Convert.ToDouble(dr工时List[i]["作业人员数量"]);
        //                }
        //            }
        //            double i置办周期 = Math.Ceiling(d工时 / Convert.ToDouble(dr["生产日工时"]));
        //            dr["置办周期"] = i置办周期;
        //        }
        //        if (dr["开始日期"].ToString().Trim() != "")
        //        {
        //            if (Convert.ToDateTime(dr["开始日期"]) < dDate1)
        //            {
        //                dr["开始日期"] = dDate1;
        //            }
        //        }
        //        else
        //        {
        //            dr["开始日期"] = dDate1;
        //        }
        //        int i质检 = 0;
        //        if (dr["质检周期"].ToString().Trim() != "")
        //        {
        //            i质检 = ReturnObjectToInt(dr["质检周期"]);
        //        }
        //        int i周期 = ReturnObjectToInt(dr["置办周期"]) + i质检;

        //        dr["完成日期"] = Convert.ToDateTime(dr["开始日期"]).AddDays(i周期);

        //        InitBomS(tran, dr["母件编码"].ToString().Trim(), decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["需求数量"]), 6), Convert.ToDateTime(Convert.ToDateTime(dr["完成日期"]).ToString("yyyy-MM-dd")).AddDays(1));
        //    }
        //}
        #endregion

        #region 获得BOM，工时工序
        
        private DataTable GetBomSQL(SqlTransaction tran, string sInvCode,string s销售订单号,int i销售订单行号,long i订单子表ID)
        {
            string sSQL = @"
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[TH_TMPUF_BOM_ERP2]') AND type in (N'U'))
	drop table TH_TMPUF_BOM_ERP2
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[TH_TMPUF_BOM_ERP]') AND type in (N'U'))
	drop table TH_TMPUF_BOM_ERP

exec  Usp_BO_ExpandByParent ' and  1=1   And ((c.InvCode >= N''aaabbbccc'') And (c.InvCode <= N''aaabbbccc''))', '1900-08-30',1, 0,  0, 3, 0, 0,  0, 0,1, '', ''   ,'TH_TMPUF_BOM_ERP2'

select  IDENTITY(INT,1,1) AS 序号,* into TH_TMPUF_BOM_ERP from TH_TMPUF_BOM_ERP2

select * 
    ,cast(null as decimal(16,2)) as 净需求
    ,cast(null as decimal(16,2)) as 需求数量
    ,cast(null as decimal(16,2)) as 本次下单数量
    ,cast(null as decimal(16,2)) as 历史超单数量
    ,cast(null as decimal(16,2)) as 仓库现存量
    ,cast(null as decimal(16,2)) as 待入库量
    ,cast(null as decimal(16,2)) as 待出库量
    ,cast(null as decimal(16,2)) as 累计待入库
    ,cast(null as decimal(16,2)) as 下单量
    ,cast(null as decimal(16,2)) as 累计下单量
    ,cast(null as decimal(16,2)) as 调整数量
    ,cast(null as decimal(16,2)) as 最小批量
    ,cast(null as decimal(16,2)) as 累计可用数量
    ,cast(null as decimal(16,2)) as Week1
    ,cast(null as decimal(16,2)) as Week2
    ,cast(null as decimal(16,2)) as Week3
    ,cast(null as decimal(16,2)) as Week4
    ,cast(null as decimal(16,2)) as Week5
    ,cast(null as decimal(16,2)) as Week6
    ,cast(0 as int) as 已使用
    ,case when 子件属性 = '采购' or  子件属性 = '委外' then b.iInvAdvance else null end as 置办周期
    ,case when 子件属性 = '自制' then 8 else null end as 生产日工时
    ,cast(null as decimal(16,10)) as 单件生产工时
    ,cast(null as decimal(16,10)) as 生产工时
    ,case when isnull(b.cInvDefine12,0) <> 0 then b.cInvDefine12 when 子件属性 = '采购' then 3 when 子件属性 = '委外' then 2 else null end as 质检周期
    ,cast(null as datetime) as 开始日期
    ,cast(null as datetime) as 完成日期
    ,aaabbbcccSOCode as 销售订单号
    ,aaabbbccciRowNo as 销售订单行号
    ,aabbcciRowNoID as 销售订单子表ID
    ,b.cInvDepCode as 生产部门编码
    ,母件编码 as 母子对应
from TH_TMPUF_BOM_ERP a 
    left join Inventory b on a.子件编码 = b.cInvCode
order by 序号
";

            sSQL = sSQL.Replace("1900-08-30", FrameBaseFunction.ClsBaseDataInfo.sLogDate);
            sSQL = sSQL.Replace("aaabbbccciRowNo", i销售订单行号.ToString());
            sSQL = sSQL.Replace("aabbcciRowNoID", i订单子表ID.ToString());
            sSQL = sSQL.Replace("aaabbbcccSOCode", s销售订单号);
            sSQL = sSQL.Replace("aaabbbccc", sInvCode);

            DataTable dt =  ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];


            sSQL = "select * from @u8.Inventory where cInvCode = '" + sInvCode + "'";
            DataTable dtInv = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
            if (dtInv != null && dtInv.Rows.Count > 0)
            {
                if ((dt.Rows.Count < 1 && Convert.ToBoolean(dtInv.Rows[0]["bPurchase"])) || dt.Rows.Count > 0)
                {

                    DataRow dr = dt.NewRow();
                    dr["母件编码"] = "--";
                    dr["使用数量"] = 1;
                    dr["子件编码"] = sInvCode;
                    if (dt.Rows.Count < 1)
                    {
                        dr["子件属性"] = "采购";
                        dr["质检周期"] = 1;
                    }
                    else
                    {
                        string s母件属性 = dt.Rows[0]["母件属性"].ToString().Trim();
                        dr["子件属性"] = s母件属性;
                    }
                    dr["根母件编码"] = sInvCode;
                    dr["销售订单号"] = s销售订单号;
                    dr["销售订单行号"] = i销售订单行号;
                    dr["销售订单子表ID"] = i订单子表ID;
                    dr["生产日工时"] = 8;
                    dr["仓库代号"] = dtInv.Rows[0]["cDefWareHouse"];
                    dr["生产部门编码"] = dtInv.Rows[0]["cInvDepCode"];
                    dr["母子对应"] = "--";
                    if (dt.Rows.Count > 0)
                    {
                        dr["根母件"] = dt.Rows[0]["根母件"];
                    }
                    else
                    {
                        dr["根母件"] = -999999;
                    }
                    dr["已使用"] = 0;

                    dt.Rows.InsertAt(dr, 0);
                }
            }

            return dt;
        }


        private DataTable Get工时工序(SqlTransaction tran, string sInvCode,string sSaleRow)
        {
            sSQL = "select " + sSaleRow + " as 行号,cast(null as varchar(50)) as BOM中物料作为子件时供应类型, cast('0' as varchar(50)) as 手工计划,a.*,b.cInvName,cast(null as decimal(16,1)) as 结束时间,cast(null as varchar(50)) as 制造令号码,cast(null as decimal(16,6)) as 制造令数量,cast(null as decimal(16,10)) as 总工时,cast(null as decimal(16,0)) as 开工日期,cast(null as decimal(16,0)) as 结束日期,cast(null as datetime) as 日计划起,cast(null as decimal(16,3)) as 订单数量,null as 订单需求量 " +
                       "from XWSystemDB_DL..ProProcess a left join Inventory b on a.产品编码 = b.cInvName " +
                       "where a.产品编码 = 'aaabbbccc' order by a.母件顺序,a.加工顺序";

            sSQL = sSQL.Replace("aaabbbccc", sInvCode);

            return ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];
        }

        #endregion

        #region 按钮模板

        ///// <summary>
        ///// 将表格中Lookup之类的保存ID的数据转换成Text用于打印
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        private DataTable SetPrintData(DataTable dt)
        {
        //    DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
        //    DataColumn dc = new DataColumn();
        //    dc.ColumnName = "StateText";
        //    dt.Columns.Add(dc);
           
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
        //        if (drState.Length > 0)
        //        {
        //            dt.Rows[i]["StateText"] = drState[0]["State"];
        //        }

        //    }

            return dt;
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void btnPrint()
        {
            QT();
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
                    gridView评审计算.ExportToXls(sF.FileName);
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
          
        }
        #endregion

        /// <summary>
        /// 导入
        /// </summary>
        private void btnImport()
        {
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {

        }

        private string sFrmSEL = "";

        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            Frm订单评审运算_SEL2 fSel = new Frm订单评审运算_SEL2();
            fSel.ShowDialog();
            if (fSel.DialogResult != DialogResult.OK)
            {
                throw new Exception("取消查询");
            }
            GetGrid(fSel.i销售订单ID);
        }

        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = 0;
                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage > 0)
                {
                    iPage -= 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);
                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                if (iPage < dtSel.Rows.Count - 1)
                {
                    iPage += 1;
                    long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                    GetGrid(i);

                    lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            try
            {
                if (dtSel == null || dtSel.Rows.Count < 1)
                {
                    throw new Exception("没有可以查看的单据");
                }

                iPage = dtSel.Rows.Count - 1;

                long i = Convert.ToInt64(dtSel.Rows[iPage]["销售订单ID"]);
                GetGrid(i);
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
            }
            catch(Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }
        /// <summary>
        /// 锁定
        /// </summary>
        private void btnLock()
        {
            aList = new System.Collections.ArrayList();
            string sSQL = "exec @u8._Get已下销售未生单物料分析 '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)).Trim() + "'";
            aList.Add(sSQL);

            clsSQLCommond.ExecSqlTran(aList);
        }
        /// <summary>
        /// 解锁
        /// </summary>
        private void btnUnLock()
        {
            aList = new System.Collections.ArrayList();
            string sSQL = "exec @u8._Get已下销售未生单物料分析 '" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + "','" + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4)).Trim() + "'";
            aList.Add(sSQL);

            int iCou = clsSQLCommond.ExecSqlTran(aList);
            //if (iCou > 0)
            //{
                MessageBox.Show("重展成功");
            //}
        }
        /// <summary>
        /// 增行
        /// </summary>
        private void btnAddRow()
        {
            gridView评审计算.AddNewRow();
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView评审计算.RowCount - 1; i >= 0 ; i--)
            {
                if (gridView评审计算.IsRowSelected(i))
                {
                    gridView评审计算.DeleteRow(i);
                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void btnEdit()
        {
            sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dtErr订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
            if (dtErr订单评审运算1 == null || dtErr订单评审运算1.Rows.Count < 1)
            {
                throw new Exception("请选择需要修改的单据");
            }
            if (dtErr订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "" || dtErr订单评审运算1.Rows[0]["审核人"].ToString().Trim() != "")
            {
                throw new Exception("已经维护不能修改");
            }
            if (dtErr订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
            {
                throw new Exception("已经关闭，不能修改");
            }
            if (dtErr订单评审运算1.Rows[0]["下达请购人"].ToString().Trim() != "")
            {
                throw new Exception("已经下达请购，不能修改");
            }
            if (dtErr订单评审运算1.Rows[0]["下达委外人"].ToString().Trim() != "")
            {
                throw new Exception("已经下达委外，不能修改");
            }
            if (dtErr订单评审运算1.Rows[0]["下达生产人"].ToString().Trim() != "")
            {
                throw new Exception("已经下达生产，不能修改");
            }

            SetColEdit(true);

            dt评审 = (DataTable)gridControl评审计算.DataSource;

            sState = "edit";
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dtErr订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);

            if (dtErr订单评审运算1 == null || dtErr订单评审运算1.Rows.Count < 1)
            {
                throw new Exception("请选择需要删除的单据");
            }
            if (dtErr订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "" || dtErr订单评审运算1.Rows[0]["审核人"].ToString().Trim() != "")
            {
                throw new Exception("已经维护不能删除");
            }
            if (dtErr订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
            {
                throw new Exception("已经关闭，不能删除");
            }
            if (dtErr订单评审运算1.Rows[0]["下达请购人"].ToString().Trim() != "")
            {
                throw new Exception("已经下达请购，不能删除");
            }
            if (dtErr订单评审运算1.Rows[0]["下达委外人"].ToString().Trim() != "")
            {
                throw new Exception("已经下达委外，不能删除");
            }
            if (dtErr订单评审运算1.Rows[0]["下达生产人"].ToString().Trim() != "")
            {
                throw new Exception("已经下达生产，不能删除");
            }

            if (MessageBox.Show("确定删除评审单据：" + txt销售订单号.Text.Trim() + "?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
            {
                throw new Exception("取消删除");
            }

            aList = new System.Collections.ArrayList();
            sSQL = "delete 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            aList.Add(sSQL);

            sSQL = "delete 订单评审运算2 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            aList.Add(sSQL);

            sSQL = "delete 订单评审运算3 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");

                GetSelList();
                iPage = dtSel.Rows.Count - 1;
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();
                btnLast();

                sState = "del";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void btnSave()
        {
            try
            {
                gridView评审计算.FocusedRowHandle -= 1;
                gridView评审计算.FocusedRowHandle += 1;

                gridView销售订单列表.FocusedRowHandle -= 1;
                gridView销售订单列表.FocusedRowHandle += 1; 
            }
            catch { }

            string sInfo = "";
            for (int i = 0; i < gridView评审计算.RowCount; i++)
            {
                decimal d本次 = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol本次下单数量));
                decimal d归档 = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol本次下单数量存档));

                if (d本次 > d归档 * (decimal)1.1 || d本次 < d归档 * (decimal)0.9)
                {
                    sInfo = sInfo + "行" + (i + 1).ToString() + "数量改变超10%\n";
                }
            }

            if (sInfo != "")
            {
                FrmMsgBox frm = new FrmMsgBox();
                frm.richTextBox1.Text = sInfo;
                frm.Text = "数量修改超10%，是否继续保存";
                frm.btnOK.Text = "继续";

                DialogResult d = frm.ShowDialog();
                if (d != DialogResult.OK)
                {
                    throw new Exception("取消保存");
                }
            }

            if (sState != "add")
            {
                sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                DataTable dtErr订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
                if (dtErr订单评审运算1 == null || dtErr订单评审运算1.Rows.Count < 1)
                {
                    throw new Exception("请选择需要保存的单据");
                }
                if (dtErr订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "" || dtErr订单评审运算1.Rows[0]["审核人"].ToString().Trim() != "")
                {
                    throw new Exception("已经审核");
                }
                if (dtErr订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
                {
                    throw new Exception("已经关闭，不能保存");
                }
            }

            string sErr = "";
            for (int i = 0; i < gridView评审计算.RowCount; i++)
            {
                decimal d = ReturnObjectToDecimal(gridView评审计算.GetRowCellValue(i, gridCol本次下单数量), 6);
                if (d > 0)
                {
                    DateTime dTime = ReturnObjectToDatetime(gridView评审计算.GetRowCellValue(i, gridCol完成日期));
                    if (dTime < DateTime.Today)
                    {
                        sErr = sErr + "行" + (i + 1).ToString() + " 日期不正确\n";
                    }
                }
            }

            if (sErr.Length > 0)
            {
                throw new Exception(sErr);
            }

            sSQL = "select * from dbo.订单评审运算1 where 1 = -1";
            DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from dbo.订单评审运算2 where 1 = -1";
            DataTable dt订单评审运算2 = clsSQLCommond.ExecQuery(sSQL);
            sSQL = "select * from dbo.订单评审运算3 where 1 = -1";
            DataTable dt订单评审运算3 = clsSQLCommond.ExecQuery(sSQL);

            aList = new System.Collections.ArrayList();
            if (sState == "add" || sState == "edit")
            {
                DataRow dr订单评审运算1 = dt订单评审运算1.NewRow();
                dr订单评审运算1["帐套号"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                dr订单评审运算1["销售订单ID"] = txt销售订单ID.Text.Trim();
                dr订单评审运算1["销售订单号"] = txt销售订单号.Text.Trim();
                dr订单评审运算1["外销订单号"] = txt外销订单号.Text.Trim();
                dr订单评审运算1["客户订单号"] = txt客户订单号.Text.Trim();
                dr订单评审运算1["客户编号"] = lookUpEdit客户.EditValue.ToString().Trim();
                dr订单评审运算1["备注"] = txt备注.Text.Trim();
                dr订单评审运算1["评审备注"] = txt评审备注.Text.Trim();
                dr订单评审运算1["制单人"] = txt制单人.Text.Trim();
                dr订单评审运算1["制单日期"] = dtm制单日期.Text.Trim();
             
                dt订单评审运算1.Rows.Add(dr订单评审运算1);

                for (int i = 0; i < gridView销售订单列表.RowCount; i++)
                {
                    DataRow dr订单评审运算2 = dt订单评审运算2.NewRow();
                    dr订单评审运算2["帐套号"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                    dr订单评审运算2["销售订单ID"] = txt销售订单ID.Text.Trim();
                    dr订单评审运算2["销售订单行号"] =gridView销售订单列表.GetRowCellValue(i,gridCol1销售订单行号).ToString();
                    dr订单评审运算2["存货编码"] =gridView销售订单列表.GetRowCellValue(i, gridCol1存货编码 ).ToString();
                    dr订单评审运算2["船期"] =gridView销售订单列表.GetRowCellValue(i, gridCol1船期).ToString();
                    if (gridView销售订单列表.GetRowCellValue(i, gridCol1国外要求交期).ToString() != "")
                    {
                        dr订单评审运算2["国外要求交期"] = gridView销售订单列表.GetRowCellValue(i, gridCol1国外要求交期).ToString();
                    }
                    dr订单评审运算2["预完工日期"] =gridView销售订单列表.GetRowCellValue(i, gridCol1预完工日期).ToString();
                    dr订单评审运算2["数量"] =gridView销售订单列表.GetRowCellValue(i, gridCol1数量).ToString();
                    dr订单评审运算2["评审数量"] = gridView销售订单列表.GetRowCellValue(i, gridCol1评审数量).ToString();
                    dr订单评审运算2["评审下达完工日期"] = gridView销售订单列表.GetRowCellValue(i, gridCol1评审下达完工日期).ToString();
                    dt订单评审运算2.Rows.Add(dr订单评审运算2);
                }


                for (int i = 0; i < gridView评审计算.RowCount; i++)
                {
                    DataRow dr订单评审运算3 = dt订单评审运算3.NewRow();
                    dr订单评审运算3["帐套号"] = (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                    dr订单评审运算3["销售订单ID"] = txt销售订单ID.Text.Trim();
                    dr订单评审运算3["销售订单子表ID"] = gridView评审计算.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim();
                    dr订单评审运算3["销售订单行号"] = gridView评审计算.GetRowCellValue(i, gridCol销售订单行号).ToString().Trim();
                    dr订单评审运算3["根母件"] = gridView评审计算.GetRowCellValue(i, gridCol根母件).ToString().Trim();
                    dr订单评审运算3["级别"] = gridView评审计算.GetRowCellValue(i, gridCol级别).ToString().Trim();
                    dr订单评审运算3["母件编码"] = gridView评审计算.GetRowCellValue(i, gridCol母件编码).ToString().Trim();
                    dr订单评审运算3["母件属性"] = gridView评审计算.GetRowCellValue(i, gridCol母件属性).ToString().Trim();
                    dr订单评审运算3["子件行号"] = gridView评审计算.GetRowCellValue(i, gridCol子件行号).ToString().Trim();
                    dr订单评审运算3["工序行号"] = gridView评审计算.GetRowCellValue(i, gridCol工序行号).ToString().Trim();
                    dr订单评审运算3["子件编码"] = gridView评审计算.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                    if (gridView评审计算.GetRowCellValue(i, gridCol换算率).ToString().Trim() != "")
                    {
                        dr订单评审运算3["换算率"] = gridView评审计算.GetRowCellValue(i, gridCol换算率).ToString().Trim();
                    }
                    dr订单评审运算3["供应类型"] = gridView评审计算.GetRowCellValue(i, gridCol供应类型).ToString().Trim();
                    dr订单评审运算3["使用数量"] = gridView评审计算.GetRowCellValue(i, gridCol使用数量).ToString().Trim();
                    dr订单评审运算3["子件属性"] = gridView评审计算.GetRowCellValue(i, gridCol子件属性).ToString().Trim();
                    dr订单评审运算3["仓库代号"] = gridView评审计算.GetRowCellValue(i, gridCol仓库代号).ToString().Trim();
                    dr订单评审运算3["领料部门代号"] = gridView评审计算.GetRowCellValue(i, gridCol领料部门代号).ToString().Trim();
                    dr订单评审运算3["生产部门编码"] = gridView评审计算.GetRowCellValue(i, gridCol生产部门编码).ToString().Trim();
                    dr订单评审运算3["备注"] = gridView评审计算.GetRowCellValue(i, gridCol备注).ToString().Trim();
                    dr订单评审运算3["需求数量"] = ReturnObjectToDecimal(gridView评审计算.GetRowCellValue(i, gridCol需求数量),6);
                    dr订单评审运算3["本次下单数量"] = ReturnObjectToDecimal(gridView评审计算.GetRowCellValue(i, gridCol本次下单数量),6);
                    dr订单评审运算3["开始日期"] = gridView评审计算.GetRowCellValue(i, gridCol开始日期).ToString().Trim();
                    dr订单评审运算3["完成日期"] = gridView评审计算.GetRowCellValue(i, gridCol完成日期).ToString().Trim();
                    dr订单评审运算3["母子对应"] = gridView评审计算.GetRowCellValue(i, gridCol母子对应).ToString().Trim();
                    if (gridView评审计算.GetRowCellValue(i, gridCol置办周期).ToString().Trim() != "")
                    {
                        dr订单评审运算3["置办周期"] = gridView评审计算.GetRowCellValue(i, gridCol置办周期).ToString().Trim();
                    }
                    else
                    {
                        dr订单评审运算3["置办周期"] = 0;
                    }
                    if (gridView评审计算.GetRowCellValue(i, gridCol质检周期).ToString().Trim() != "")
                    {
                        dr订单评审运算3["质检周期"] = gridView评审计算.GetRowCellValue(i, gridCol质检周期).ToString().Trim();
                    }
                    if (gridView评审计算.GetRowCellValue(i, gridCol生产日工时).ToString().Trim() != "")
                    {
                        dr订单评审运算3["生产日工时"] = gridView评审计算.GetRowCellValue(i, gridCol生产日工时).ToString().Trim();
                    }
                    if (gridView评审计算.GetRowCellValue(i, gridCol单件生产工时).ToString().Trim() != "")
                    {
                        dr订单评审运算3["单件生产工时"] = gridView评审计算.GetRowCellValue(i, gridCol单件生产工时).ToString().Trim();
                    }
                    if (gridView评审计算.GetRowCellValue(i, gridCol生产工时).ToString().Trim() != "")
                    {
                        dr订单评审运算3["生产工时"] = gridView评审计算.GetRowCellValue(i, gridCol生产工时).ToString().Trim();
                    }
                    dt订单评审运算3.Rows.Add(dr订单评审运算3);
                }
            }
            for (int i = 0; i < dt订单评审运算1.Rows.Count; i++)
            {
                if (sState == "add")
                {
                    sSQL = clsGetSQL.GetInsertSQL("订单评审运算1", dt订单评审运算1, i);
                    aList.Add(sSQL);
                }
                if (sState == "edit")
                {
                    sSQL = clsGetSQL.GetUpdateSQL("订单评审运算1", dt订单评审运算1, i);
                    aList.Add(sSQL);
                }
            }

            if (sState == "edit")
            {
                sSQL = "delete 订单评审运算2 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                aList.Add(sSQL);
            }
            for (int i = 0; i < dt订单评审运算2.Rows.Count; i++)
            {
                sSQL = clsGetSQL.GetInsertSQL("订单评审运算2", dt订单评审运算2, i);
                aList.Add(sSQL);
            }
            if (sState == "edit")
            {
                sSQL = "delete 订单评审运算3 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
                aList.Add(sSQL);
            }
            for (int i = 0; i < dt订单评审运算3.Rows.Count; i++)
            {
                sSQL = clsGetSQL.GetInsertSQL("订单评审运算3", dt订单评审运算3, i);
                aList.Add(sSQL);
            }

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);

                GetSelList();
                iPage = dtSel.Rows.Count - 1;
                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();

                MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");

                SetColEdit(false);
                sState = "save";
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            SetColEdit(false);

            if (txt销售订单ID.Text.Trim() != "")
            {
                GetGrid(Convert.ToInt64(txt销售订单ID.Text));
            }
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            if (txt销售订单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要审核的单据");
            }

            sSQL = "select * from dbo.订单评审运算1  where 销售订单ID = " + txt销售订单ID.Text.Trim() + " and 帐套号 = " + FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);
            DataTable dtErr = clsSQLCommond.ExecQuery(sSQL);
            if (dtErr == null || dtErr.Rows.Count < 1)
            {
                throw new Exception("没有需要审核的单据");
            }
            if (dtErr.Rows.Count > 0)
            {
                if (dtErr.Rows[0]["审核人"].ToString().Trim() != "")
                    throw new Exception("已经审核");
                if (dtErr.Rows[0]["关闭人"].ToString().Trim() != "")
                    throw new Exception("已经关闭不能审核");
            }

            sSQL = "update 订单评审运算1 set 审核人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "' ,审核日期 = getdate() where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            int iRow = clsSQLCommond.ExecSql(sSQL);
            MessageBox.Show("审核成功，执行语句" + iRow + "行");
            txt审核人.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
            dtm审核日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;


            sSQL = "select distinct vchrName,sEMail as sMailAddress from UFDLImport.dbo._vendUid a inner join _UserInfo b on a.uid = b.vchrUID where vchrName in('殷雪静','李智','白震华','陈晓兰','朱建荣') and sEMail is not null";
            DataTable dtMail = clsSQLCommond.ExecQuery(sSQL);
            if (dtMail == null || dtMail.Rows.Count < 1)
            {
                MessageBox.Show("请设置邮箱");
            }
            else
            {
                string s1 = "";
                string s2 = "";
                for (int i = 0; i < dtMail.Rows.Count; i++)
                {
                    s1 = s1 + dtMail.Rows[i]["vchrName"] + ",";
                    s2 = s2 + dtMail.Rows[i]["sMailAddress"] + ";";
                }
              
//                sSQL = @"Exec msdb.dbo.sp_send_dbmail @profile_name='dolle',
//                        @recipients='111111',
//                        @subject='222222',
//                        @body='" + "请评审销售订单" + txt销售订单号.Text ;

//                sSQL = sSQL.Replace("111111", s2);
//                sSQL = sSQL.Replace("222222", "订单评审");
//                clsSQLCommond.ExecSql(sSQL);

                try
                {
                    ClseMail clseMail = new ClseMail();
                    clseMail.MailSend(s2, "订单评审", "请评审销售订单" + txt销售订单号.Text);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "发送邮件失败");
                }
            }

        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            if (txt销售订单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要弃审的单据");
            }

            sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dtErr订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
            if (dtErr订单评审运算1 == null || dtErr订单评审运算1.Rows.Count < 1)
            {
                throw new Exception("请选择需要弃审的单据");
            }
            if (dtErr订单评审运算1.Rows[0]["维护审核人"].ToString().Trim() != "")
            {
                throw new Exception("已经维护不能弃审");
            }
            if (dtErr订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
            {
                throw new Exception("已经关闭，不能弃审");
            }
            if (dtErr订单评审运算1.Rows[0]["下达请购人"].ToString().Trim() != "")
            {
                throw new Exception("已经下达请购，不能弃审");
            }
            if (dtErr订单评审运算1.Rows[0]["下达委外人"].ToString().Trim() != "")
            {
                throw new Exception("已经下达委外，不能弃审");
            }
            if (dtErr订单评审运算1.Rows[0]["下达生产人"].ToString().Trim() != "")
            {
                throw new Exception("已经下达生产，不能弃审");
            }

            sSQL = "update 订单评审运算1 set 审核人 = null,审核日期 = null where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            int iRow = clsSQLCommond.ExecSql(sSQL);
            MessageBox.Show("弃审成功，执行语句" + iRow + "行");

            txt审核人.Text = "";
            dtm审核日期.Text = "";
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            if (txt销售订单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要打开的单据");
            }
            sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dtErr订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
            if (dtErr订单评审运算1 == null || dtErr订单评审运算1.Rows.Count < 1)
            {
                throw new Exception("请选择需要打开的单据");
            }
            if (dtErr订单评审运算1.Rows[0]["关闭人"].ToString().Trim() == "")
            {
                throw new Exception("尚未关闭，不能打开");
            }

            sSQL = "update 订单评审运算1 set 关闭人 = null ,关闭日期 = null where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            int iRow = clsSQLCommond.ExecSql(sSQL);
            MessageBox.Show("打开成功，执行语句" + iRow + "行");

            txt关闭人.Text = "";
            dtm关闭日期.Text = "";
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            if (txt销售订单号.Text.Trim() == "")
            {
                throw new Exception("请选择需要关闭的单据");
            }

            sSQL = "select * from 订单评审运算1 where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            DataTable dtErr订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);
            if (dtErr订单评审运算1 == null || dtErr订单评审运算1.Rows.Count < 1)
            {
                throw new Exception("请选择需要关闭的单据");
            }
            if (dtErr订单评审运算1.Rows[0]["关闭人"].ToString().Trim() != "")
            {
                throw new Exception("已经关闭");
            }

            sSQL = "update 订单评审运算1 set 关闭人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',关闭日期 = getdate()  where 销售订单ID = '" + txt销售订单ID.Text.Trim() + "' and 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim();
            int iRow = clsSQLCommond.ExecSql(sSQL);
            MessageBox.Show("关闭成功，执行语句" + iRow + "行");

            txt关闭人.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
            dtm关闭日期.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
        }

        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            Frm缺料_demo frm = new Frm缺料_demo();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        #endregion

        private void Frm订单评审运算_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();

                SetCol();

                GetSelList();

                btn日期检查.Enabled = true;
                btn15天核查.Enabled = true;
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView销售订单列表_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void gridView评审计算_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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

        private void GetLookUp()
        {
            string sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            DataRow drInv = dt.NewRow();
            drInv["cInvCode"] = "--";
            dt.Rows.Add(drInv);
            ItemLookUpEdit1存货编码.DataSource = dt;
            ItemLookUpEdit1存货名称.DataSource = dt;
            ItemLookUpEdit1规格型号.DataSource = dt;

            ItemLookUpEdit物料编码.DataSource = dt;
            ItemLookUpEdit物料名称.DataSource = dt;
            ItemLookUpEdit规格型号.DataSource = dt;

            sSQL = "select cCusCode,cCusName,cCusAbbName from @u8.Customer order by cCusCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            lookUpEdit客户.Properties.DataSource = dt;

            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "iID";
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr["iID"] = "采购";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "委外";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "自制";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["iID"] = "虚拟件";
            dt.Rows.Add(dr);
            ItemLookUpEdit子件属性.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit部门编码.DataSource = dt;
            ItemLookUpEdit部门名称.DataSource = dt;

            sSQL = "select cWhCode,cWhName from @u8.Warehouse  order by cWhCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit仓库编号.DataSource = dt;
            ItemLookUpEdit仓库名称.DataSource = dt;
        }

        private void gridView评审计算_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                //int i1 = ReturnObjectToInt(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol销售订单行号));
                //int i2 = i1%2;

                //if (i2 == 0)
                //{
                //    e.Appearance.BackColor = Color.AliceBlue;
                //}
                //else
                //{
                //    e.Appearance.BackColor = Color.AntiqueWhite; 
                //}

                DateTime d1 = Convert.ToDateTime(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol开始日期));
                if (d1 < DateTime.Today && BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle,gridCol本次下单数量)) > 0)
                {
                    e.Appearance.BackColor = Color.Tomato;
                }
            }
            catch
            { }
        }


        private decimal GetQTYRet0(object d)
        {
            try
            {
                return FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(d);
            }
            catch
            {
                return 0;
            }
        }

  
        private void SetColEdit(bool b)
        {
            gridCol1评审下达完工日期.OptionsColumn.AllowEdit = b;
            gridCol1评审数量.OptionsColumn.AllowEdit = b;

            gridCol本次下单数量.OptionsColumn.AllowEdit = b;
            gridCol开始日期.OptionsColumn.AllowEdit = b;
            gridCol完成日期.OptionsColumn.AllowEdit = b;
            gridCol置办周期.OptionsColumn.AllowEdit = b;
            gridCol质检周期.OptionsColumn.AllowEdit = b;
            gridCol生产日工时.OptionsColumn.AllowEdit = b;
            gridCol生产工时.OptionsColumn.AllowEdit = b;

            radio逆排.Enabled = b;
            radio顺排.Enabled = b;
            radio手工.Enabled = b;


            txt存货编码.Enabled = b;
            chk开始日期.Enabled = b;
            chk完成日期.Enabled = b;
            dtm开始日期.Enabled = false;
            dtm完成日期.Enabled = false;
            btnChange.Enabled = b;

            txt评审备注.Enabled = b;
        }

        private void gridView评审计算_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (radio手工.Checked && (sState == "edit" || sState == "add"))
                {
                    string s子件编码 = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol子件编码).ToString().Trim();
                    string s母子 = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol母子对应).ToString().Trim();
                    decimal d本次下单 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol本次下单数量));
                    int i行号 = ReturnObjectToInt(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol销售订单行号));
                    InitEditSG(s子件编码, s母子, d本次下单, i行号);

                    if (s子件编码.Substring(0, 2).ToLower() == "yz" && e.Column == gridCol本次下单数量)
                    {
                        string s母件编码 = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol母件编码).ToString().Trim();

                        string sSQL = "select count(1) as iCou from dbo._LookUpDate where iType = 19 and isnull(bClose,0) = 1 and iID = '" + s子件编码 + "' and iText = '" + s母件编码 + "'";
                        int iCou = ReturnObjectToInt(clsSQLCommond.ExecGetScalar(sSQL));
                        if (iCou == 0)
                        {
                            string s销售订单子表ID = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol销售订单子表ID).ToString().Trim();
                            for (int i = 0; i < gridView评审计算.RowCount; i++)
                            {
                                string s子件编码2 = gridView评审计算.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                                string s销售订单子表ID2 = gridView评审计算.GetRowCellValue(i, gridCol销售订单子表ID).ToString().Trim();
                                decimal d使用数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol使用数量));
                                decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol本次下单数量));

                                #region 对比母子对应关系一致的才属于同一BOM分支，由于虚拟件的关系，假设有三层虚拟件需要去除

                                if (s销售订单子表ID2 == s销售订单子表ID && s母件编码 == s子件编码2)
                                {
                                    string s母子2 = gridView评审计算.GetRowCellValue(i, gridCol母子对应).ToString().Trim();

                                    int iLast = s母子.LastIndexOf("→");
                                    if (iLast > 0)
                                    {
                                        s母子 = s母子.Substring(0, iLast);
                                    }
                                    while (s母子 != s母子2 && iLast > 0)
                                    {
                                        iLast = s母子.LastIndexOf("→");
                                        if (iLast > 0)
                                        {
                                            s母子 = s母子.Substring(0, iLast);
                                        }
                                    }

                                    if (s母子 == s母子2)
                                    {
                                        gridView评审计算.SetRowCellValue(i, gridCol本次下单数量, decimal.Round(d本次下单数量 / d使用数量, 6));
                                    }
                                    s母子 = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol母子对应).ToString().Trim();
                                }
                                #endregion
                            }
                        }
                    }
                }
                if (radio逆排.Checked && (sState == "edit" || sState == "add"))
                {
                    gridControl评审计算.Refresh();
                    if (e.Column == gridCol完成日期 || e.Column == gridCol本次下单数量 || e.Column == gridCol置办周期 || e.Column == gridCol生产日工时 || e.Column == gridCol质检周期)
                    {
                        string s子件编码 = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol子件编码).ToString().Trim();
                        string s母子 = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol母子对应).ToString().Trim();
                        decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol本次下单数量));
                        DateTime d完成日期 = Convert.ToDateTime(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol完成日期));
                        int i置办周期 = 0;
                        int i周期 = 0;

                        if (gridView评审计算.GetRowCellValue(e.RowHandle, gridCol子件属性).ToString().Trim() == "自制" && e.Column != gridCol置办周期)
                        {
                            i置办周期 = ReturnObjectToInt(Math.Ceiling(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol单件生产工时)) * d本次下单数量 / FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol生产日工时))));
                        }
                        else
                        {
                            i置办周期 = ReturnObjectToInt(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol置办周期));
                        }
                        if (gridView评审计算.GetRowCellValue(e.RowHandle, gridCol质检周期).ToString().Trim() != "")
                        {
                            i周期 = i置办周期 + ReturnObjectToInt(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol质检周期));
                        }
                        else
                        {
                            i周期 = i置办周期;
                        }
                        DateTime d开始日期 = d完成日期.AddDays(-1 * i周期);
                        gridView评审计算.SetRowCellValue(e.RowHandle, gridCol开始日期, d开始日期);

                        int i行号 = ReturnObjectToInt(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol销售订单行号));

                        InitEditN(s子件编码, s母子, d本次下单数量, d开始日期, i行号);

                        gridControl评审计算.DataSource = dt评审;
                    }
                }
                if (radio顺排.Checked && (sState == "edit" || sState == "add"))
                {
                    if (e.Column == gridCol开始日期 || e.Column == gridCol本次下单数量 || e.Column == gridCol置办周期 || e.Column == gridCol生产日工时 || e.Column == gridCol质检周期)
                    {
                        string s母件编码 = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol母件编码).ToString().Trim();
                        decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol本次下单数量));
                        DateTime d开始日期 = Convert.ToDateTime(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol开始日期));
                        int i行号 = ReturnObjectToInt(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol销售订单行号));
                        int i置办周期 = 0;
                        int i周期 = 0;
                        if (gridView评审计算.GetRowCellValue(e.RowHandle, gridCol子件属性).ToString().Trim() == "自制" && e.Column != gridCol置办周期)
                        {
                            i置办周期 = ReturnObjectToInt(Math.Ceiling(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol单件生产工时)) * d本次下单数量 / FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol生产日工时))));
                        }
                        else
                        {
                            i置办周期 = ReturnObjectToInt(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol置办周期));
                        }
                        if (gridView评审计算.GetRowCellValue(e.RowHandle, gridCol质检周期).ToString().Trim() != "")
                        {
                            i周期 = i置办周期 + ReturnObjectToInt(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol质检周期));
                        }
                        else
                        {
                            i周期 = i置办周期;
                        }
                        DateTime d完成日期 = d开始日期.AddDays(i置办周期);
                        gridView评审计算.SetRowCellValue(e.RowHandle, gridCol完成日期, d完成日期);
                        string s母子 = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol母子对应).ToString().Trim();

                        string s销售订单子表ID = gridView评审计算.GetRowCellValue(e.RowHandle, gridCol销售订单行号).ToString().Trim();

                        for (int i = 0; i < gridView评审计算.RowCount; i++)
                        {
                            string s子件编码2 = gridView评审计算.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                            string s销售订单子表ID2 = gridView评审计算.GetRowCellValue(i, gridCol销售订单行号).ToString().Trim();
                            string s母子2 = gridView评审计算.GetRowCellValue(i, gridCol母子对应).ToString().Trim();

                            if (s销售订单子表ID2 == s销售订单子表ID && s母件编码 == s子件编码2)
                            {
                                int iLast = s母子.LastIndexOf("→");
                                if (iLast > 0)
                                {
                                    s母子 = s母子.Substring(0, iLast);
                                }
                                while (s母子 != s母子2 && iLast > 0)
                                {
                                    iLast = s母子.LastIndexOf("→");
                                    if (iLast > 0)
                                    {
                                        s母子 = s母子.Substring(0, iLast);
                                    }
                                }
                                if (s母子 == s母子2)
                                {
                                    InitEditS(s母件编码, s母子, d开始日期.AddDays(i周期).AddDays(1), i行号);
                                    break;
                                }
                            }
                        }
                        if (s母子 == "--")
                            InitEditS(s母件编码, s母子, d开始日期.AddDays(i周期).AddDays(1), i行号);

                        gridControl评审计算.DataSource = dt评审;
                    }
                }

                if (e.Column == gridCol本次下单数量)
                {
                    decimal d本次 = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol本次下单数量));
                    decimal d存档 = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(e.RowHandle, gridCol本次下单数量存档));

                    if (d本次 > d存档 * (decimal)1.1 || d本次 < d存档 * (decimal)0.9)
                    {
                        MessageBox.Show("行" + (e.RowHandle + 1).ToString() + "数量修改超10%");
                    }
                }
            }
            catch (Exception ee)
            {
                MsgBox("错误提示", ee.Message);
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (radio顺排.Checked)
            {
                gridCol开始日期.OptionsColumn.AllowEdit = true;
                gridCol完成日期.OptionsColumn.AllowEdit = false;
                gridCol本次下单数量.OptionsColumn.AllowEdit = false;
            }
            if (radio逆排.Checked)
            {
                gridCol开始日期.OptionsColumn.AllowEdit = false;
                gridCol完成日期.OptionsColumn.AllowEdit = true;
                gridCol本次下单数量.OptionsColumn.AllowEdit = true;
            }
            if (radio手工.Checked)
            {
                gridCol开始日期.OptionsColumn.AllowEdit = true;
                gridCol完成日期.OptionsColumn.AllowEdit = true;
                gridCol本次下单数量.OptionsColumn.AllowEdit = true;
            }
        }

        /// <summary>
        /// 手工计划需要逆排下一层的需求数量
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="sInvCode2">母子对应</param>
        /// <param name="dQty">母件下单数量</param>
        /// <param name="dDate1">计划结束日期</param>
        /// <param name="i行号">销售订单行号</param>
        private void InitEditSG(string sInvCode, string sInvCode2, decimal dQty, int i行号)
        {
            DataRow[] drList = dt评审.Select(" 母件编码 = '" + sInvCode + "' and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");

            foreach (DataRow dr in drList)
            {
                decimal d需求数量 = decimal.Round(dQty * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["使用数量"]), 6);
                dr["需求数量"] = d需求数量;
           }
        }

        /// <summary>
        /// 编辑状态逆排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">母件编码</param>
        /// <param name="sInvCode2">母子对应</param>
        /// <param name="dQty">母件下单数量</param>
        /// <param name="dDate1">计划结束日期</param>
        /// <param name="i行号">销售订单行号</param>
        private void InitEditN(string sInvCode, string sInvCode2, decimal dQty, DateTime dDate1, int i行号)
        {
            DataRow[] drList = dt评审.Select(" 母件编码 = '" + sInvCode + "' and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");

            foreach (DataRow dr in drList)
            {
                decimal d当前物料累计下单 = 0;
                decimal d当前物料累计需求 = 0;

                for (int i = 0; i < dt评审.Rows.Count; i++)
                {
                    string s本次下单 = dt评审.Rows[i]["本次下单数量"].ToString().Trim();
                    if (s本次下单.Length == 0)
                        continue;
                    string s子件编码 = dt评审.Rows[i]["子件编码"].ToString().Trim();
                    if (s子件编码 == dr["子件编码"].ToString().Trim())
                    {
                        decimal d1 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt评审.Rows[i]["本次下单数量"]);
                        d当前物料累计下单 = d当前物料累计下单 + d1;
                        decimal d2 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt评审.Rows[i]["需求数量"]);
                        d当前物料累计需求 = d当前物料累计需求 + d2;
                    }
                }

                decimal d当前需求 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["需求数量"]);
                decimal d当前下单 = GetQTYRet0(dr["本次下单数量"]);
                d当前物料累计需求 = d当前物料累计需求 - d当前需求;
                d当前物料累计下单 = d当前物料累计下单 - d当前下单;

                decimal d现存量 = GetQTYRet0(dr["仓库现存量"]);
                if (d现存量 <= FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(0.000001))
                    d现存量 = 0;


                decimal d待入库 = GetQTYRet0(dr["待入库量"]);
                decimal d待出库 = GetQTYRet0(dr["待出库量"]);
                decimal d最小批量 = GetQTYRet0(dr["最小批量"]);
                decimal d调整数量 = GetQTYRet0(dr["调整数量"]);
                decimal d当前行可用量 = d现存量 - d调整数量 + d待入库 - d待出库 - (d当前物料累计需求 - d当前物料累计下单);
                decimal d本次下单数量 = 0;

                decimal d需求数量 = decimal.Round(dQty * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["使用数量"]), 6);
                dr["需求数量"] = d需求数量;
                if (d需求数量 == 0)
                {
                    d本次下单数量 = 0;
                }
                else
                {
                    if (d需求数量 > d当前行可用量)
                    {
                        d本次下单数量 = d需求数量 - d当前行可用量;
                        if (d当前物料累计下单 < d最小批量)
                        {
                            d本次下单数量 = d最小批量;
                        }
                    }
                    else
                        d本次下单数量 = 0;
                }
                dr["本次下单数量"] = d本次下单数量;

                int i置办周期 = 0;
                if (dr["子件属性"].ToString().Trim() == "自制")
                {
                    decimal d单件生产工时 = ReturnObjectToDecimal(dr["单件生产工时"], 10);
                    decimal d生产日工时 =  ReturnObjectToDecimal(dr["生产日工时"],10);
                    i置办周期 = ReturnObjectToInt(Math.Ceiling(d单件生产工时 * d本次下单数量 / d生产日工时));
                }
                else
                {
                    i置办周期 = ReturnObjectToInt(dr["置办周期"]);
                }

                int i质检周期 = ReturnObjectToInt(dr["质检周期"]);

                int i周期 = i置办周期 + i质检周期;

                dr["完成日期"] = dDate1.AddDays(-1 * i质检周期).AddDays(-1);
                dr["开始日期"] = dDate1.AddDays(-1 * i周期).AddDays(-1);
                
                InitEditN(dr["子件编码"].ToString().Trim(), dr["母子对应"].ToString().Trim(), decimal.Round(FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dr["本次下单数量"]), 6), Convert.ToDateTime(dr["开始日期"]), i行号);
            }
        }

        /// <summary>
        /// 编辑状态顺排计划
        /// </summary>
        /// <param name="tran"></param>
        /// <param name="sInvCode">子件编码</param>
        /// <param name="dQty">本次下单数量</param>
        /// <param name="dDate1">计划开始日期</param>
        private void InitEditS(string sInvCode, string sInvCode2, DateTime dDate1, int i行号)
        {
            DataRow[] drList = dt评审.Select(" 子件编码 = '" + sInvCode + "'  and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");
            while (drList.Length == 0)
            {
                int iLast = sInvCode2.LastIndexOf("→");
                if (iLast > 0)
                {
                    sInvCode2 = sInvCode2.Substring(0, iLast);
                    drList = dt评审.Select(" 子件编码 = '" + sInvCode + "'  and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");
                }
                else
                {
                    break;
                }

            }

            //日期减少时，确保使用同阶最大日期来推算，避免产品提前至其子件之前
            DataRow[] drList2 = dt评审.Select(" 母件编码 = '" + sInvCode + "'  and 销售订单行号 = " + i行号 + " and 母子对应 like '" + sInvCode2 + "%'");
            foreach (DataRow dr in drList2)
            {
                DateTime d1 = FrameBaseFunction.ClsBaseDataInfo.ReturnDate(dr["完成日期"]) .AddDays(1);
                int i质检周期 = FrameBaseFunction.ClsBaseDataInfo.ReturnInt(dr["质检周期"]);      //作为母件的开工时间，必须考虑子件的质检周期
                d1 = d1.AddDays(i质检周期);

                if(dDate1<d1)
                    dDate1 = d1;
            }

            foreach (DataRow dr in drList)
            {
                int i置办周期 = 0;
                if (dr["子件属性"].ToString().Trim() == "自制")
                {
                    i置办周期 = ReturnObjectToInt(Math.Ceiling(ReturnObjectToDecimal(dr["单件生产工时"], 10) * (ReturnObjectToDecimal((dr["本次下单数量"]), 6) / ReturnObjectToDecimal(dr["生产日工时"], 2))));
                }
                else
                {
                    i置办周期 = ReturnObjectToInt(dr["置办周期"]);
                }
                int i周期 = 0;
                int i质检周期 = 0;
                if (dr["质检周期"].ToString().Trim() != "")
                {
                    i质检周期 =  ReturnObjectToInt(dr["质检周期"]);
                    i周期 = i置办周期 + i质检周期;
                }
                else
                {
                    i周期 = i置办周期;
                }

                dr["开始日期"] = dDate1;
                dr["完成日期"] = dDate1.AddDays(i置办周期);

                string s母子 = dr["母子对应"].ToString().Trim();
                int iLast = s母子.LastIndexOf("→");
                if (iLast > 0)
                {
                    s母子 = s母子.Substring(0, iLast);
                    InitEditS(dr["母件编码"].ToString().Trim(), s母子, Convert.ToDateTime(Convert.ToDateTime(dr["完成日期"]).ToString("yyyy-MM-dd")).AddDays(1).AddDays(i质检周期), i行号);
                }
            }
        }

        private void GetGrid(long i销售订单ID)
        {
            string sSQL = @"
select * from dbo.订单评审运算1 where 销售订单ID = 111111 and 帐套号 = 222222
";
            sSQL = sSQL.Replace("111111", i销售订单ID.ToString().Trim());
            sSQL = sSQL.Replace("222222", (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim());
            DataTable dt订单评审运算1 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"
select * from dbo.订单评审运算2 
where 销售订单ID = 111111 and 帐套号 = 222222 
order by iID";
            sSQL = sSQL.Replace("111111", i销售订单ID.ToString().Trim());
            sSQL = sSQL.Replace("222222", (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim());
            DataTable dt订单评审运算2 = clsSQLCommond.ExecQuery(sSQL);

            sSQL = @"
select *,cast(null as decimal(16,6)) as 仓库现存量,cast(null as decimal(16,6)) as 待入库量,cast(null as decimal(16,6)) as 待出库量,cast(null as decimal(16,6)) as 最小批量,cast(b.cInvDefine13 as decimal(16,6)) as 调整数量
from dbo.订单评审运算3 a left join @u8.Inventory b on a.子件编码 = b.cInvCode 
where 销售订单ID = 111111 and 帐套号 = 222222 
order by a.iID
";

            sSQL = sSQL.Replace("111111", i销售订单ID.ToString().Trim());
            sSQL = sSQL.Replace("222222", (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim());
            DataTable dt订单评审运算3 = clsSQLCommond.ExecQuery(sSQL);

            if (dt订单评审运算1 != null && dt订单评审运算1.Rows.Count > 0 && dt订单评审运算2 != null && dt订单评审运算2.Rows.Count > 0 && dt订单评审运算3 != null && dt订单评审运算3.Rows.Count > 0)
            {
                txt销售订单号.Text = dt订单评审运算1.Rows[0]["销售订单号"].ToString().Trim();
                txt外销订单号.Text = dt订单评审运算1.Rows[0]["外销订单号"].ToString().Trim();
                txt客户订单号.Text = dt订单评审运算1.Rows[0]["客户订单号"].ToString().Trim();
                lookUpEdit客户.EditValue = dt订单评审运算1.Rows[0]["客户编号"];
                txt备注.Text = dt订单评审运算1.Rows[0]["备注"].ToString().Trim();
                txt销售订单ID.Text = dt订单评审运算1.Rows[0]["销售订单ID"].ToString().Trim();
                txt评审备注.Text = dt订单评审运算1.Rows[0]["评审备注"].ToString().Trim();
                txt制单人.Text = dt订单评审运算1.Rows[0]["制单人"].ToString().Trim();
                dtm制单日期.Text = dt订单评审运算1.Rows[0]["制单日期"].ToString().Trim();
                txt审核人.Text = dt订单评审运算1.Rows[0]["审核人"].ToString().Trim();
                dtm审核日期.Text = dt订单评审运算1.Rows[0]["审核日期"].ToString().Trim();
                txt关闭人.Text = dt订单评审运算1.Rows[0]["关闭人"].ToString().Trim();
                dtm关闭日期.Text = dt订单评审运算1.Rows[0]["关闭日期"].ToString().Trim();

                gridControl销售订单列表.DataSource = dt订单评审运算2;

                bool bExists本次下单数量存档 = false;
                for (int i = 0; i < dt订单评审运算3.Columns.Count; i++)
                {
                    if (dt订单评审运算3.Columns[i].ColumnName.Trim() == "本次下单数量存档")
                    {
                        bExists本次下单数量存档 = true;
                        break;
                    }
                }

                if (!bExists本次下单数量存档)
                {
                    DataColumn dc = new DataColumn();
                    dc.ColumnName = "本次下单数量存档";
                    dt订单评审运算3.Columns.Add(dc);
                }
                for (int i = 0; i < dt订单评审运算3.Rows.Count; i++)
                {
                    dt订单评审运算3.Rows[i]["本次下单数量存档"] = BaseFunction.ReturnDecimal(dt订单评审运算3.Rows[i]["本次下单数量"]);
                }
                
                gridControl评审计算.DataSource = dt订单评审运算3;

                //Get实时数据();

                for (int j = 0; j < dt订单评审运算3.Rows.Count; j++)
                {
                    try
                    {
                        sSQL = "select isnull(cInvDefine3,0.00) as 最小批量,isnull(cInvDefine13,0.00) as 调整数量 from @u8.Inventory where cInvCode = '" + dt订单评审运算3.Rows[j]["子件编码"].ToString().Trim() + "'";
                        DataTable dt最小批量 = clsSQLCommond.ExecQuery(sSQL);
                        decimal d1 = 0;
                        if (dt最小批量 != null && dt最小批量.Rows.Count > 0 && dt最小批量.Rows[0][0].ToString().Trim() != "")
                        {
                            d1 = GetQTYRet0(dt最小批量.Rows[0][0]);
                        }
                        dt订单评审运算3.Rows[j]["最小批量"] = d1;
                        dt订单评审运算3.Rows[j]["调整数量"] = GetQTYRet0(dt最小批量.Rows[0]["调整数量"]);
                    }
                    catch { }

                    Frm物料供需分析 fSELQty = new Frm物料供需分析();

                    DataTable dtQty = fSELQty.Get物料供需分析汇总表(dt订单评审运算3.Rows[j]["子件编码"].ToString().Trim(), txt销售订单号.Text.Trim(), 1);
                    if (dtQty != null && dtQty.Rows.Count > 0)
                    {
                        dt订单评审运算3.Rows[j]["仓库现存量"] = GetQTYRet0(dtQty.Rows[0]["现存量"]);
                        dt订单评审运算3.Rows[j]["待入库量"] = GetQTYRet0(dtQty.Rows[0]["待入库"]);
                        dt订单评审运算3.Rows[j]["待出库量"] = GetQTYRet0(dtQty.Rows[0]["待出库"]);
                    }
                }

                SetColEdit(false);
            }
            else
            {
                throw new Exception("获得单据失败");
            }
        }

        private void GetSelList()
        {
            string sSQL = "select 销售订单ID from 订单评审运算1 where 帐套号 = " + (FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3)).Trim() + " order by 销售订单号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
            }
        }

        private void gridView评审计算_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView评审计算.FocusedRowHandle;
                string sInvCode = "";

                if (iRow >= 0)
                {
                    sInvCode = gridView评审计算.GetRowCellValue(iRow, gridCol子件编码).ToString().Trim();
                    if (sInvCode != string.Empty)
                    {
                        Frm物料供需分析 fSel = new Frm物料供需分析(sInvCode);
                        fSel.sInvCode = sInvCode;
                        fSel.sSaleOrder = txt销售订单号.Text.Trim();
                        fSel.ShowDialog();
                    }
                }
            }
            catch { }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            bool b = false;
            if (chk开始日期.Checked && dtm开始日期.Text.Trim() != "")
            {
                b = true;
            }
            if (chk完成日期.Checked && dtm完成日期.Text.Trim() != "")
            {
                b = true;
            }
            if (!b)
            {
                MessageBox.Show("请选择要批改的内容");
                return;
            }

            if (txt存货编码.Text.Trim() != "")
            {
                string s = txt存货编码.Text.ToLower().Trim();
                int iLength = s.Length;

                for (int i = 0; i < gridView评审计算.RowCount; i++)
                {
                    string s物料 = gridView评审计算.GetRowCellValue(i, gridCol子件编码).ToString().Trim().ToLower();
                    if (s物料.Substring(0, iLength) == s)
                    {
                        if (chk开始日期.Checked)
                        {
                            gridView评审计算.SetRowCellValue(i, gridCol开始日期, dtm开始日期.DateTime);
                        }
                        if (chk完成日期.Checked)
                        {
                            gridView评审计算.SetRowCellValue(i, gridCol完成日期, dtm完成日期.DateTime);
                        }
                    }
                }
            }
        }

        private void chk开始日期_CheckedChanged(object sender, EventArgs e)
        {
            if (chk开始日期.Checked)
                dtm开始日期.Enabled = true;
            else
            {
                dtm开始日期.Enabled = false;
                dtm开始日期.Text = "";
            }

        }

        private void chk完成日期_CheckedChanged(object sender, EventArgs e)
        {

            if (chk完成日期.Checked)
                dtm完成日期.Enabled = true;
            else
            {
                dtm完成日期.Enabled = false;
                dtm完成日期.Text = "";
            }
        }

        private void btn日期检查_Click(object sender, EventArgs e)
        {
            try
            {
                string sErr = "";
                string sErr1 = "";
                string sErr2 = "";
                string sErr3 = "";

                DataTable dtTemp = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "单据号";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "存货编码";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "存货名称";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "属性";
                dtTemp.Columns.Add(dc);
                //dc = new DataColumn();
                //dc.ColumnName = "主计量单位";
                //dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "数量";
                dtTemp.Columns.Add(dc);
                //dc = new DataColumn();
                //dc.ColumnName = "件数";
                //dtTemp.Columns.Add(dc);
                //dc = new DataColumn();
                //dc.ColumnName = "计划到货日期";
                //dtTemp.Columns.Add(dc);
                //dc = new DataColumn();
                //dc.ColumnName = "对应请购单";
                //dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "外销单号";
                dtTemp.Columns.Add(dc);
                //dc = new DataColumn();
                //dc.ColumnName = "销售订单行号";
                //dtTemp.Columns.Add(dc);
                //dc = new DataColumn();
                //dc.ColumnName = "累计下单数量";
                //dtTemp.Columns.Add(dc);
                //dc = new DataColumn();
                //dc.ColumnName = "未到货数量";
                //dtTemp.Columns.Add(dc);
                //dc = new DataColumn();
                //dc.ColumnName = "请购日期";
                //dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "是否最小批量";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "最近入料日期";
                dtTemp.Columns.Add(dc);
                dc = new DataColumn();


                for (int i = 0; i < gridView评审计算.RowCount; i++)
                {
                    decimal d需求数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol需求数量));
                    decimal d本次下单数量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol本次下单数量));

                    if (d需求数量 >= d本次下单数量)
                        continue;

                    decimal d最小批量 = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(gridView评审计算.GetRowCellValue(i, gridCol最小批量));
               
                    DateTime d完成日期 = FrameBaseFunction.ClsBaseDataInfo.ReturnDate(gridView评审计算.GetRowCellValue(i, gridCol完成日期));
                    DateTime d开始日期 = FrameBaseFunction.ClsBaseDataInfo.ReturnDate(gridView评审计算.GetRowCellValue(i, gridCol开始日期));
                    string s子件属性 = gridView评审计算.GetRowCellValue(i, gridCol子件属性).ToString().Trim();
                    string s子件编码 = gridView评审计算.GetRowCellValue(i, gridCol子件编码).ToString().Trim();
                    string s子件名称 = gridView评审计算.GetRowCellDisplayText(i, gridCol子件名称).ToString().Trim();

                    if (i > 0)
                    {
                        string s子件编码上一行 = gridView评审计算.GetRowCellValue(i - 1, gridCol子件编码).ToString().Trim();
                        if (s子件编码上一行 == s子件编码)
                            continue;
                    }

                    if (s子件属性 == "采购")
                    {
                        string sSQL = @"
select distinct c.cCode,fqty,a.cItemCode from 
(                                  
    select cDefine11,cinvcode,sum(b.fQuantity) as fQty,cItemCode,a.ccode
    from @u8.PU_AppVouch a inner join @u8.PU_AppVouchs b on a.id = b.id 
    where b.cinvcode = '111111111111' and isnull(b.cbcloser,'') <> '' and isnull(a.cCloser,'') <> '' and b.dArriveDate > '333333'
    group by cDefine11,cinvcode,cItemCode,a.ccode
) a left join 
(
    select b.cInvCode,b.cItemCode, sum(isnull(b.iQuantity,0)) as iQty
    from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id 
    where a.cBusType = '普通采购' 
    group by b.cInvCode,b.cItemCode
) b on a.cInvCode = b.cInvCode and a.cDefine11 = b.cItemCode
inner join 
(
    select a.ccode,cDefine11,b.cinvcode from @u8.PU_AppVouch a inner join @u8.PU_AppVouchs b on a.id = b.id
) c on a.cDefine11 = c.cDefine11 and a.cInvCode = c.cInvCode and a.ccode = c.ccode
where a.fQty > isnull(b.iQty,0) 
";
                        sSQL = sSQL.Replace("111111111111", s子件编码);
                        sSQL = sSQL.Replace("333333", ReturnObjectToDatetime(FrameBaseFunction.ClsBaseDataInfo.sLogDate).AddMonths(-2).ToString("yyyy-MM-dd"));
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        string sRow = "行" + (i + 1).ToString() + "采购物料：'【" + s子件编码 + "】 " + s子件名称 + "'，是否需要提前：";
                        string sInfo = "";
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                DataRow dr = dtTemp.NewRow();
                                dr["单据号"] = dt.Rows[j]["cCode"];
                                dr["存货编码"] = s子件编码;
                                dr["存货名称"] = s子件名称;
                                dr["属性"] = s子件属性;
                                dr["数量"] = dt.Rows[j]["fQty"];
                                dr["外销单号"] = dt.Rows[j]["cItemCode"];

                                sSQL = @"
select min(case when isnull(cDefine36,'') <> '' then cDefine36 when isnull(cDefine37,'') <> '' then cDefine37 else dArriveDate end) as 入料日期
from @u8.PO_Podetails 
where cItemCode = '111111' and cInvCode = '222222'
";
                                sSQL = sSQL.Replace("111111", dr["外销单号"].ToString().Trim());
                                sSQL = sSQL.Replace("222222", s子件编码);

                                DataTable dtTime = clsSQLCommond.ExecQuery(sSQL);
                                if (dtTime != null && dtTime.Rows.Count > 0 && dtTime.Rows[0][0].ToString().Trim() != "")
                                {
                                    dr["最近入料日期"] = ReturnObjectToDatetime(dtTime.Rows[0][0]).ToString("yyyy-MM-dd");
                                }
                                
                                if (d最小批量 > 0)
                                {
                                    dr["是否最小批量"] = "是";
                                }
                                else
                                {
                                    dr["是否最小批量"] = "否";
                                }
                                dtTemp.Rows.Add(dr);
                            }
                        }
                    }
                    if (s子件属性 == "委外")
                    {
                        string sSQL = @" 
select distinct c.iID,fQty,a.socode
from 
(                                  
    select SoCode,InvCode,sum(PlanQty) as fQty
    from UFDLImport..OMPlan
    where InvCode = '111111111111' and StartDate > '22222222222'
    group by SoCode,InvCode,socode
) a left join 
(
    select b.cInvCode,b.cItemCode, sum(isnull(b.iQuantity,0)) as iQty
    from @u8.PU_ArrivalVouch a inner join @u8.PU_ArrivalVouchs b on a.id = b.id 
    where a.cBusType = '委外加工' 
    group by b.cInvCode,b.cItemCode
) b on a.InvCode = b.cInvCode and a.SoCode = b.cItemCode
inner join 
(
    select iID,SoCode,InvCode from UFDLImport..OMPlan
) c on a.SoCode = c.SoCode and a.InvCode = c.InvCode
where a.fQty > isnull(b.iQty,0)
";
                        sSQL = sSQL.Replace("111111111111", s子件编码);
                        sSQL = sSQL.Replace("22222222222", d完成日期.ToString("yyyy-MM-dd"));
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        string sRow = "行" + (i + 1).ToString() + "委外物料：'【" + s子件编码 + "】 " + s子件名称 + "'，是否需要提前：";
                        string sInfo = "";
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                DataRow dr = dtTemp.NewRow();
                                dr["单据号"] = dt.Rows[j]["iID"];
                                dr["存货编码"] = s子件编码;
                                dr["存货名称"] = s子件名称;
                                dr["属性"] = s子件属性;
                                dr["数量"] = dt.Rows[j]["fQty"];
                                dr["外销单号"] = dt.Rows[j]["socode"];

                                sSQL = @"
select min(case when isnull(cDefine36,'') <> '' then cDefine36 when isnull(cDefine37,'') <> '' then cDefine37 else dArriveDate end) as 入料日期
from @u8.OM_MODetails 
where cItemCode = '111111' and cInvCode = '222222'
";
                                sSQL = sSQL.Replace("111111", dr["外销单号"].ToString().Trim());
                                sSQL = sSQL.Replace("222222", s子件编码);

                                DataTable dtTime = clsSQLCommond.ExecQuery(sSQL);
                                if (dtTime != null && dtTime.Rows.Count > 0 && dtTime.Rows[0][0].ToString().Trim() != "")
                                {

                                    dr["最近入料日期"] = ReturnObjectToDatetime(dtTime.Rows[0][0]).ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    sSQL = @"
select min(DueDate2) from UFDLImport..omplan 
where SoCode = '111111' and InvCode = '222222'
";
                                    sSQL = sSQL.Replace("111111", dr["外销单号"].ToString().Trim());
                                    sSQL = sSQL.Replace("222222", s子件编码);
                                    dtTime = clsSQLCommond.ExecQuery(sSQL);

                                    if (dtTime != null && dtTime.Rows.Count > 0 && dtTime.Rows[0][0].ToString().Trim() != "")
                                    {
                                        dr["最近入料日期"] = ReturnObjectToDatetime(dtTime.Rows[0][0]).ToString("yyyy-MM-dd");
                                    }
                                }

                                if (d最小批量 > 0)
                                {
                                    dr["是否最小批量"] = "是";
                                }
                                else
                                {
                                    dr["是否最小批量"] = "否";
                                }
                                dtTemp.Rows.Add(dr);
                            }
                        }
                    }
                    if (s子件属性 == "自制")
                    {
                        string sSQL = "select MoCode,b.Qty,SoCode " +
                                "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.moid inner join @u8.mom_morder c on c.modid = b.modid " +
                                "where b.invcode = '" + s子件编码 + "' and c.StartDate > '" + d开始日期.ToString("yyyy-MM-dd") + "' and b.Qty > ISNULL(b.QualifiedInQty,0)";
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        string sRow = "行" + (i + 1).ToString() + "自制物料：'【" + s子件编码 + "】 " + s子件名称 + "'，是否需要提前：";
                        string sInfo = "";
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                DataRow dr = dtTemp.NewRow();
                                dr["单据号"] = dt.Rows[j]["MoCode"];
                                dr["存货编码"] = s子件编码;
                                dr["存货名称"] = s子件名称;
                                dr["属性"] = s子件属性;
                                dr["数量"] = dt.Rows[j]["Qty"];
                                dr["外销单号"] = dt.Rows[j]["SoCode"];


                                sSQL = @"
select min(DueDate) as 入料日期
from @u8.mom_morder a inner join @u8.mom_orderdetail b on a.modid = b.modid
where SoCode = '111111' and InvCode = '222222'
";
                                sSQL = sSQL.Replace("111111", dr["外销单号"].ToString().Trim());
                                sSQL = sSQL.Replace("222222", s子件编码);

                                DataTable dtTime = clsSQLCommond.ExecQuery(sSQL);
                                if (dtTime != null && dtTime.Rows.Count > 0)
                                {
                                    dr["最近入料日期"] = ReturnObjectToDatetime(dtTime.Rows[0][0]).ToString("yyyy-MM-dd");
                                }

                                if (d最小批量 > 0)
                                {
                                    dr["是否最小批量"] = "是";
                                }
                                else
                                {
                                    dr["是否最小批量"] = "否";
                                }
                                dtTemp.Rows.Add(dr);
                            }
                        }
                    }
                }
                if (dtTemp != null && dtTemp.Rows.Count > 0)
                {
                    DataView dv = dtTemp.DefaultView;
                    dv.Sort = " 是否最小批量,属性,存货编码,单据号 ";

                    Frm物料时间检查 frm = new Frm物料时间检查();
                    frm.dtSEL = dv.ToTable().Copy();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("检查结束，没有需要关注的物料");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btn15天核查_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    gridView评审计算.FocusedRowHandle -= 1;
                    gridView评审计算.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[table15Days]') AND type in (N'U'))
	delete table15Days
else
	create table table15Days(
		存货编码 varchar(100),
		需求日期 datetime,
		数量 decimal(16,6),
		外销单号 varchar(100),
		单据号 varchar(100),
        行号 int,
        类型 varchar(10)
	)";
                aList.Add(sSQL);

                for (int i = 0; i < gridView评审计算.RowCount; i++)
                {
                    //string s子件属性 = gridView评审计算.GetRowCellValue(i, gridCol子件属性).ToString().Trim();

                    //if (s子件属性 != "采购")
                    //    continue;

                    string s存货编码 = gridView评审计算.GetRowCellValue(i, gridCol子件编码).ToString().Trim();

                    if(gridView评审计算.GetRowCellValue(i,gridCol完成日期).ToString().Trim() == "")
                        continue;

                    DateTime d完成日期 = Convert.ToDateTime(gridView评审计算.GetRowCellValue(i,gridCol完成日期));
                    sSQL = @"
insert into table15Days
select b.cInvCode as 存货编码,b.dRequirDate as 需求日期,b.fQuantity as 数量,b.cItemCode as 外销单号,a.cCode as 请购单号,222222,'采购'
from @u8.PU_AppVouch a inner join @u8.PU_AppVouchs b on a.id = b.id
where ISNULL(cCloser,'') = '' and  b.cInvCode = '111111'  and '333333' <= b.dRequirDate and '444444' >=  b.dRequirDate
    and b.cItemCode <> '555555'

insert into table15Days
select b.InvCode,c.StartDate,b.Qty,b.SoCode,a.MoCode,222222,'自制'
from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId
	inner join @u8.mom_morder c on b.MoDId =  c.MoDId
where b.Status = '3' and b.InvCode = '111111'  and '333333' <= c.StartDate and '444444' >=  c.StartDate
    and b.SoCode <>  '555555'

insert into table15Days
select InvCode,DueDate,PlanQty,SoCode,iID,222222,'委外'
from UFDLImport..omplan
where ISNULL(ClosedUID,'') = '' and InvCode = '111111'  and '333333' <= DueDate and '444444' >=  DueDate
    and SoCode <>  '555555'
";
                    sSQL = sSQL.Replace("222222", (i + 1).ToString());
                    sSQL = sSQL.Replace("111111", s存货编码);
                    sSQL = sSQL.Replace("333333", d完成日期.AddDays(-15).ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("444444", d完成日期.AddDays(15).ToString("yyyy-MM-dd"));
                    sSQL = sSQL.Replace("555555", txt外销订单号.Text.Trim());
                    aList.Add(sSQL);
                }

                clsSQLCommond.ExecSqlTran(aList);
                sSQL = "select * from table15Days";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                Frm15天分析 f = new Frm15天分析();
                f.dtSEL = dt.Copy();
                f.ShowDialog();

            }
            catch (Exception ee)
            {
                MessageBox.Show("核查失败:" + ee.Message);
            }
        }

        private void btn变更部门_Click(object sender, EventArgs e)
        {
            if (btn变更部门.Text == "变更部门")
            {
                gridCol生产部门编码.OptionsColumn.AllowEdit = true;
                gridCol生产部门名称.OptionsColumn.AllowEdit = true;
                gridCol子件属性.OptionsColumn.AllowEdit = true;

                btn变更部门.Text = "保存部门";
            }
            else
            {
                gridCol生产部门编码.OptionsColumn.AllowEdit = true;
                gridCol生产部门名称.OptionsColumn.AllowEdit = true;

                try
                {
                    gridView评审计算.FocusedRowHandle -= 1;
                    gridView评审计算.FocusedRowHandle += 1;
                }
                catch { }

                ArrayList aList = new ArrayList();
                string sSQL = "";
                for (int i = 0; i < gridView评审计算.RowCount; i++)
                {
                    sSQL = "update 订单评审运算3 set 生产部门编码 = '" + gridView评审计算.GetRowCellValue(i,gridCol生产部门编码).ToString().Trim() + "',子件属性 = '" + gridView评审计算.GetRowCellValue(i,gridCol子件属性).ToString().Trim() + "' where iID = " + gridView评审计算.GetRowCellDisplayText(i, gridColiID).ToString().Trim();
                    aList.Add(sSQL);
                }

                clsSQLCommond.ExecSqlTran(aList);

                btn变更部门.Text = "变更部门";
                gridCol生产部门编码.OptionsColumn.AllowEdit = false;
                gridCol生产部门名称.OptionsColumn.AllowEdit = false;
                gridCol子件属性.OptionsColumn.AllowEdit = false;
            }

        }

        private void chk开始日期_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (chk开始日期.Checked)
                {
                    dtm开始日期.Enabled = true;
                }
                else
                {
                    dtm开始日期.Enabled = false;
                }
            }
            catch { }
        }

        private void chk完成日期_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (chk完成日期.Checked)
                {
                    dtm完成日期.Enabled = true;
                }
                else
                {
                    dtm完成日期.Enabled = false;
                }
            }
            catch { }
        }

        DateTime dtmStart;

        private void SetCol()
        {
            string sSQL = "select * from dbo._LookUpDate where iType = '16' and iID like '201801'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                DateTime d周日期 = ReturnObjectToDatetime(dt.Rows[0]["iText"]);
                DateTime dNow = DateTime.Today;
                DateTime dWeek1 = BaseFunction.ReturnDate("2000-01-01");
                int iWeek = 0;

                for (int i = 0; i < 52; i++)
                {
                    dWeek1 = d周日期.AddDays(7 * i);
                    dtmStart = dWeek1;
                    if (dWeek1 <= dNow && dWeek1 > dNow.AddDays(-7))
                    {
                        iWeek = i + 1;
                        break;
                    }
                }


                gridColWeek1.Caption = (iWeek + 0).ToString() + "周" + @"/" + dWeek1.AddDays(7 * 0).ToString("yyMMdd");
                gridColWeek2.Caption = (iWeek + 1).ToString() + "周" + @"/" + dWeek1.AddDays(7 * 1).ToString("yyMMdd");
                gridColWeek3.Caption = (iWeek + 2).ToString() + "周" + @"/" + dWeek1.AddDays(7 * 2).ToString("yyMMdd");
                gridColWeek4.Caption = (iWeek + 3).ToString() + "周" + @"/" + dWeek1.AddDays(7 * 3).ToString("yyMMdd");
                gridColWeek5.Caption = (iWeek + 4).ToString() + "周" + @"/" + dWeek1.AddDays(7 * 4).ToString("yyMMdd");
                gridColWeek6.Caption = (iWeek + 5).ToString() + "周" + @"/" + dWeek1.AddDays(7 * 5).ToString("yyMMdd");
                gridColWeek7.Caption = (iWeek + 6).ToString() + "周" + @"/" + dWeek1.AddDays(7 * 6).ToString("yyMMdd");
                gridColWeek8.Caption = (iWeek + 7).ToString() + "周" + @"/" + dWeek1.AddDays(7 * 7).ToString("yyMMdd");

                gridView评审计算.BestFitColumns();
            }

        }

        private void QT()
        {
            SqlConnection conn = new SqlConnection(FrameBaseFunction.ClsBaseDataInfo.sConnString);
            conn.Open();
            //启用事务
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string sSQL = @"
truncate table [dbo].[_齐套计算临时表];
";
                ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                for (int ii = 0; ii < gridView评审计算.RowCount; ii++)
                {
                    gridView评审计算.SetRowCellValue(ii, gridColWeek1, DBNull.Value);
                    gridView评审计算.SetRowCellValue(ii, gridColWeek2, DBNull.Value);
                    gridView评审计算.SetRowCellValue(ii, gridColWeek3, DBNull.Value);
                    gridView评审计算.SetRowCellValue(ii, gridColWeek4, DBNull.Value);
                    gridView评审计算.SetRowCellValue(ii, gridColWeek5, DBNull.Value);
                    gridView评审计算.SetRowCellValue(ii, gridColWeek6, DBNull.Value);

                    string s属性 = gridView评审计算.GetRowCellValue(ii, gridCol子件属性).ToString().Trim();
                    if (s属性 != "自制")
                        continue;

                    string sInvCode = gridView评审计算.GetRowCellValue(ii, gridCol子件编码).ToString().Trim();
                    decimal d数量 = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridCol本次下单数量));
                    if (d数量 <= 0)
                        continue;

                    sSQL = @"
select {1} as 优先级,'{2}' as InvCode, d.InvCode as cInvCode,BaseQtyN/BaseQtyD/(1-isnull(ParentScrap,0))*(1+isnull(CompScrap,0))*{0} as 使用数量,BaseQtyN/BaseQtyD/(1-isnull(ParentScrap,0))*(1+isnull(CompScrap,0)) as BomQTY
from @u8.bom_bom a inner join @u8.bom_opcomponent b on a.bomID = b.bomid inner join @u8.bom_parent c on c.bomid = a.bomid  
    inner join @u8.bom_opcomponentopt f on f.OptionsId = b.OptionsId 
    inner join @u8.bas_part d on d.PartId = b.ComponentId 
    inner join @u8.Inventory e on e.cInvCode = d.InvCode
    inner join @u8.bas_part g on g.PartId = c.ParentId 
where g.InvCode = '" + sInvCode + "' and a.[Status] = 3 and b.EffBegDate < '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' and b.EffEndDate > '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "'";

                    sSQL = string.Format(sSQL, d数量, ii + 1, sInvCode);
                    DataTable dt = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        sSQL = @"
if not exists(select * from [_齐套计算临时表] where cInvCode = '{0}' )
begin
	exec UFDATA_200_2015.._Get供需分析 '{0}','200','2015','';

	insert into [dbo].[_齐套计算临时表](cInvCode, iQty, dtm)
    select 存货编码,sum(isnull(现存量,0) + isnull(待入库,0)) as 可用量,isnull(供需日期,'2000-01-01') as 供需日期  
    from UFDATA_200_2015..Get供需分析 
    group by 存货编码,供需日期
end 
";
                        sSQL = string.Format(sSQL, dt.Rows[j]["cInvCode"].ToString().Trim());
                        ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);
                    }
                }


                for (int ii = 0; ii < gridView评审计算.RowCount; ii++)
                {
                    string s属性 = gridView评审计算.GetRowCellValue(ii, gridCol子件属性).ToString().Trim();
                    if (s属性 != "自制")
                        continue;

                    bool bConJS = true; //是否继续计算

                    string sInvCode = gridView评审计算.GetRowCellValue(ii, gridCol子件编码).ToString().Trim();
                    decimal d数量 = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridCol本次下单数量));
                    if (d数量 <= 0)
                    {
                        continue;
                    }

                    sSQL = @"
select count(1) as iCou
from _GetBOM
where InvCode = '{0}'
";
                    sSQL = string.Format(sSQL, sInvCode);
                    int iBomCout = BaseFunction.ReturnInt(ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]); // BOM子件种类数

                    //当产品齐套未完成时持续计算到齐套结束或材料不足
                    while (d数量 > 0)
                    {
                        // 获得齐套计算过程BOM子件种类数，用于齐套扣料后存在的部分子件不足的情况
                        sSQL = @"
	select count(1)
	from 
	(
		SELECT  cInvCode, min(dtm) as dtm
		FROM      _齐套计算临时表
		where isnull(iQty,0) - isnull(iUseQty,0) > 0
		group by cInvCode
	) a left join _齐套计算临时表 b on a.cInvCode = b.cInvCode and a.dtm = b.dtm
		inner join 
		(
			select InvCode,cInvCode,BomQTY,iCou
			from _GetBOM
			where InvCode = '{0}'
		) bom on b.cInvCode = bom.cInvCode
";
                        sSQL = string.Format(sSQL, sInvCode);
                        int iQTBomCount = BaseFunction.ReturnInt(ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0].Rows[0][0]);
                        if (iBomCout != iQTBomCount)
                        {
                            bConJS = false;
                            break;
                        }

                        //获得当前过程齐套的数量及日期（最小数量及最大日期，木桶原理）
                        sSQL = @"
select MIN(bomT) AS bomT,MAX(dtm) as dtm
from
(
	select b.*,b.iQty - isnull(b.iUseQty,0) as iUseCan,bom.BomQTY,FLOOR(((b.iQty - isnull(b.iUseQty,0)) / bom.BomQTY)) as bomT
	from 
	(
		SELECT  cInvCode, min(dtm) as dtm
		FROM      _齐套计算临时表
		where isnull(iQty,0) - isnull(iUseQty,0) > 0
		group by cInvCode
	) a left join _齐套计算临时表 b on a.cInvCode = b.cInvCode and a.dtm = b.dtm
		inner join 
		(
			select InvCode,cInvCode,BomQTY,iCou
			from _GetBOM
			where InvCode = '{0}'
		) bom on b.cInvCode = bom.cInvCode
) QT
";
                        sSQL = string.Format(sSQL, sInvCode);
                        DataTable dtQT = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        //
                        sSQL = @"
select b.*,b.iQty - isnull(b.iUseQty,0) as iUseCan,bom.BomQTY,FLOOR(((b.iQty - isnull(b.iUseQty,0)) / bom.BomQTY)) as bomT
	from 
	(
		SELECT  cInvCode, min(dtm) as dtm
		FROM      _齐套计算临时表
		where isnull(iQty,0) - isnull(iUseQty,0) > 0
		group by cInvCode
	) a left join _齐套计算临时表 b on a.cInvCode = b.cInvCode and a.dtm = b.dtm
		inner join 
		(
			select InvCode,cInvCode,BomQTY,iCou
			from _GetBOM
			where InvCode = '{0}'
		) bom on b.cInvCode = bom.cInvCode
";
                        sSQL = string.Format(sSQL, sInvCode);
                        DataTable dtTemp = ClsSqlHelper.ExecuteDataset(tran, CommandType.Text, sSQL).Tables[0];

                        //
                        decimal dQty = BaseFunction.ReturnDecimal(dtQT.Rows[0]["bomT"]);
                        DateTime dtm = BaseFunction.ReturnDate(dtQT.Rows[0]["dtm"]);

                        if (dQty <= 0)
                            break;

                        //当齐套数据超出订单需求，只需要满足订单需求即可
                        if (dQty > d数量)
                        {
                            dQty = d数量;
                        }

                        //将齐套数据记录进_齐套计算临时表，避免下次计算重复使用
                        sSQL = @"
update a set a.iUseQty = isnull(a.iUseQty,0) + b.bomQTY * {1}
from _齐套计算临时表 a 
	inner join 
	(
		select b.iID,bom.BomQTY
		from 
		(
			SELECT  cInvCode, min(dtm) as dtm
			FROM      _齐套计算临时表
			where isnull(iQty,0) - isnull(iUseQty,0) > 0
			group by cInvCode
		) a left join _齐套计算临时表 b on a.cInvCode = b.cInvCode and a.dtm = b.dtm
			inner join 
			(
				select InvCode,cInvCode,BomQTY,iCou
				from _GetBOM
				where InvCode = '{0}'
			) bom on b.cInvCode = bom.cInvCode
	) b on a.iID = b.iID
";
                        sSQL = string.Format(sSQL, sInvCode, dQty);
                        ClsSqlHelper.ExecuteNonQuery(tran, CommandType.Text, sSQL);

                        string sTemp = gridColWeek1.Caption.Substring(4);
                        DateTime dtmWeek1 = BaseFunction.ReturnDate("20" + sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2)); 
                        
                        sTemp = gridColWeek2.Caption.Substring(4);
                        DateTime dtmWeek2 = BaseFunction.ReturnDate("20" + sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2)); 
                        
                        sTemp = gridColWeek3.Caption.Substring(4);
                        DateTime dtmWeek3 = BaseFunction.ReturnDate("20" + sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2)); 
                        
                        sTemp = gridColWeek4.Caption.Substring(4);
                        DateTime dtmWeek4 = BaseFunction.ReturnDate("20" + sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2)); 
                        
                        sTemp = gridColWeek5.Caption.Substring(4);
                        DateTime dtmWeek5 = BaseFunction.ReturnDate("20" + sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2)); 
                        
                        sTemp = gridColWeek6.Caption.Substring(4);
                        DateTime dtmWeek6 = BaseFunction.ReturnDate("20" + sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2)); 
                        
                        sTemp = gridColWeek7.Caption.Substring(4);
                        DateTime dtmWeek7 = BaseFunction.ReturnDate("20" + sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2)); 
                        
                        sTemp = gridColWeek8.Caption.Substring(4);
                        DateTime dtmWeek8 = BaseFunction.ReturnDate("20" + sTemp.Substring(0, 2) + "-" + sTemp.Substring(2, 2) + "-" + sTemp.Substring(4, 2));


                        if (dtm < dtmWeek1)
                            dtm = dtmWeek1;

                        if (dtm >= dtmWeek1 && dtm < dtmWeek2)
                        {
                            decimal dTemp = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridColWeek1));
                            dTemp = dTemp + dQty;
                            gridView评审计算.SetRowCellValue(ii, gridColWeek1, dTemp);
                        }
                        else if (dtm >= dtmWeek2 && dtm < dtmWeek3)
                        {
                            decimal dTemp = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridColWeek2));
                            dTemp = dTemp + dQty;
                            gridView评审计算.SetRowCellValue(ii, gridColWeek2, dTemp);
                        }
                        else if (dtm >= dtmWeek3 && dtm < dtmWeek4)
                        {
                            decimal dTemp = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridColWeek3));
                            dTemp = dTemp + dQty;
                            gridView评审计算.SetRowCellValue(ii, gridColWeek3, dTemp);
                        }
                        else if (dtm >= dtmWeek4 && dtm < dtmWeek5)
                        {
                            decimal dTemp = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridColWeek4));
                            dTemp = dTemp + dQty;
                            gridView评审计算.SetRowCellValue(ii, gridColWeek4, dTemp);
                        }
                        else if (dtm >= dtmWeek5 && dtm < dtmWeek6)
                        {
                            decimal dTemp = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridColWeek5));
                            dTemp = dTemp + dQty;
                            gridView评审计算.SetRowCellValue(ii, gridColWeek5, dTemp);
                        }
                        else if (dtm >= dtmWeek6 && dtm < dtmWeek7)
                        {
                            decimal dTemp = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridColWeek6));
                            dTemp = dTemp + dQty;
                            gridView评审计算.SetRowCellValue(ii, gridColWeek6, dTemp);
                        }
                        else if (dtm >= dtmWeek7 && dtm < dtmWeek8)
                        {
                            decimal dTemp = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridColWeek7));
                            dTemp = dTemp + dQty;
                            gridView评审计算.SetRowCellValue(ii, gridColWeek7, dTemp);
                        }
                        else if (dtm >= dtmWeek8)
                        {
                            decimal dTemp = BaseFunction.ReturnDecimal(gridView评审计算.GetRowCellValue(ii, gridColWeek8));
                            dTemp = dTemp + dQty;
                            gridView评审计算.SetRowCellValue(ii, gridColWeek8, dTemp);
                        }

                        d数量 = d数量 - dQty;
                    }


                    //当结余数量不足时跳出循环
                    //if (!bConJS)
                    //    break;
                }

                tran.Commit();
            }
            catch (Exception ee)
            {
                tran.Rollback();
            }

        }
    }
}
