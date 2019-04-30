using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using System.IO;

namespace WorkInformation
{
    public partial class FrmWorkPlan : FrameBaseFunction.Frm列表窗体模板
    {
        public FrmWorkPlan()
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
                throw new Exception(ee.Message);
            }
        }

        private void btnAdd()
        {
            try
            {
                dtBingGrid = new DataTable();

                SetTxtGridNull();
                FrmWorkPlan_Add fAdd = new FrmWorkPlan_Add();
                fAdd.ShowDialog();
                if (fAdd.DialogResult == DialogResult.OK)
                {
                    if (fAdd.iType == 0)
                    {
                        #region 销售订单

                        string sAutoID = fAdd.sAutoID;                                      //销售订单子表ID
                        //销售订单信息
                        sSQL = @"
select a.cSOCode,b.iRowNo,b.autoid,b.cInvCode,d.cInvName,b.iQuantity,b.cItemCode,a.cDefine2,b.dPreDate,a.cCusCode,c.cCusName,b.dPreMoDate,b.cDefine36,b.iQuantity,b.iNum,d.bPurchase 
from @u8.SO_SODetails b INNER JOIN @u8.SO_SOMain a ON a.ID = b.ID left join @u8.Customer c on a.cCusCode = c.cCusCode left join @u8.Inventory d on b.cInvCode=d.cInvCode
where b.autoid = 111111
order by b.iRowNo
";
                        sSQL = sSQL.Replace("111111", sAutoID.ToString());
                        DataTable dtSO = clsSQLCommond.ExecQuery(sSQL);
                        if (dtSO == null || dtSO.Rows.Count < 1)
                        {
                            throw new Exception("获得销售订单失败");
                        }

                        SetText(dtSO);

                        //产品BOM多阶
                        sSQL = @"
IF EXISTS (SELECT NAME FROM tempdb..SYSOBJECTS  WHERE NAME ='TMPUF_939096218_heron939495570_DOLLEVS05' AND Xtype='U') DROP Table tempdb..TMPUF_939096218_heron939495570_DOLLEVS05; 

IF EXISTS (SELECT NAME FROM tempdb..SYSOBJECTS  WHERE NAME ='TMPUF_939096218_heronFormat945248680_DOLLEVS05' AND Xtype='U') Drop table  tempdb..TMPUF_939096218_heronFormat945248680_DOLLEVS05; 

exec  @u8.Usp_BO_ExpandByParent ' and  1=1   And ((c.InvCode >= N''111111'') And (c.InvCode <= N''111111''))', '2012-05-18',1, 0,  0, 3, 0, 0,  0, 0,1, '', ''   ,'tempdb..TMPUF_939096218_heron939495570_DOLLEVS05'

SELECT distinct round([根母件],2) as [根母件],[级别] as [级别],round([母件Id],2) as [母件Id],[母件编码] as [母件编码],[母件代号] as [母件代号],[母件名称] as [母件名称],[PItemSpec] as [PItemSpec]
    ,[PEngineerFigNo] as [PEngineerFigNo],[母件计量单位] as [母件计量单位],round([母件损耗率],3) as [母件损耗率],[版本号] as [版本号],[版本说明] as [版本说明],[版本日期] as [版本日期],[状态] as [状态]
    ,[母件属性] as [母件属性],[变更单号] as [变更单号]
    ,[行号] as [行号],[子件行号] as [子件行号],[工序行号] as [工序行号],[子件编码] as [子件编码],[子件代码] as [子件代码],[子件名称] as [子件名称],[CItemSpec] as [CItemSpec],[CEngineerFigNo] as [CEngineerFigNo]
    ,[子件计量单位] as [子件计量单位],round([基本用量],6) as [基本用量],round([基础数量],6) as [基础数量],round([子件损耗率],3) as [子件损耗率],[辅助单位] as [辅助单位],round([换算率],2) as [换算率]
    ,round([辅助基本用量],6) as [辅助基本用量],round([辅助使用量],6) as [辅助使用量],[固定用量] as [固定用量],[供应类型] as [供应类型],round([使用数量],6) as [使用数量],[子件生效日] as [子件生效日]
    ,[子件失效日] as [子件失效日],[偏置期] as [偏置期],round([计划比例],3) as [计划比例],[产出品] as [产出品],[产出类型] as [产出类型],[成本相关] as [成本相关],[可选否] as [可选否],[选择规则] as [选择规则]
    ,[子件属性] as [子件属性],[仓库代号] as [仓库代号],[仓库名称] as [仓库名称],[领料部门代号] as [领料部门代号],[领料部门名称] as [领料部门名称]
    ,[备注] as [备注],[母件cFree1],[母件cFree2],[母件cFree3],[母件cFree4],[母件cFree5],[母件cFree6],[母件cFree7],[母件cFree8],[母件cFree9],[母件cFree10],[母件cInvDefine1],[母件cInvDefine2]
    ,[母件cInvDefine3],[母件cInvDefine4],[母件cInvDefine5],[母件cInvDefine6],[母件cInvDefine7],[母件cInvDefine8],[母件cInvDefine9],[母件cInvDefine10],[母件cInvDefine11],[母件cInvDefine12]
    ,[母件cInvDefine13],[母件cInvDefine14],[母件cInvDefine15],[母件cInvDefine16],[cDefine1],[cDefine2],[cDefine3],[cDefine4],[cDefine5],[cDefine6],[cDefine7],[cDefine8],[cDefine9]
    ,[cDefine10],[cDefine11],[cDefine12],[cDefine13],[cDefine14],[cDefine15],[cDefine16],[子件cFree1],[子件cFree2],[子件cFree3],[子件cFree4],[子件cFree5],[子件cFree6],[子件cFree7]
    ,[子件cFree8],[子件cFree9],[子件cFree10],[子件cInvDefine1],[子件cInvDefine2],[子件cInvDefine3],[子件cInvDefine4],[子件cInvDefine5],[子件cInvDefine6],[子件cInvDefine7],[子件cInvDefine8]
    ,[子件cInvDefine9],[子件cInvDefine10],[子件cInvDefine11],[子件cInvDefine12],[子件cInvDefine13],[子件cInvDefine14],[子件cInvDefine15],[子件cInvDefine16],[cDefine22],[cDefine23],[cDefine24]
    ,[cDefine25],[cDefine26],[cDefine27],[cDefine28],[cDefine29],[cDefine30],[cDefine31],[cDefine32],[cDefine33],[cDefine34],[cDefine35],[cDefine36],[cDefine37]  
from tempdb..TMPUF_939096218_heron939495570_DOLLEVS05 
";


                        sSQL = sSQL.Replace("111111", txtProInvCode.Text.Trim());
                        DataTable dtBOM = clsSQLCommond.ExecQuery(sSQL);
                        if (dtBOM == null || dtBOM.Rows.Count < 1)
                        {
                            if (!Convert.ToBoolean(dtSO.Rows[0]["bPurchase"]))
                            {
                                throw new Exception("获得产品BOM失败，请设置");
                            }
                        }

                        //产品工序
                        sSQL = @"
select cast(null as varchar(50)) as BOM中物料作为子件时供应类型, cast('0' as varchar(50)) as 手工计划,a.*,b.cInvName,
        cast(null as decimal(18,1)) as 结束时间,cast(null as varchar(50)) as 制造令号码,cast(null as decimal(18,6)) as 制造令数量,cast(null as decimal(18,10)) as 总工时
        ,cast(null as decimal(18,0)) as 开工日期,cast(null as decimal(18,0)) as 结束日期,cast(null as datetime) as 日计划起,cast(null as decimal(18,3)) as 订单数量
        ,cast(null as datetime) as 制造令开工日期,cast(null as datetime) as 制造令完工日期,cast(null as datetime) as 工时工序日计划起
        ,null as 订单需求量,cast(null as varchar(10)) as 人员,cast(null as varchar(50)) as 制造令状态 
from ProProcess a left join @u8.Inventory b on a.产品编码 = b.cInvCode 
where a.产品编码 = '" + txtProInvCode.Text.Trim() + "' order by a.母件顺序,a.加工顺序";
                        DataTable dt工序 = clsSQLCommond.ExecQuery(sSQL);
                        if (dt工序 != null && dt工序.Rows.Count < 1)
                        {
                            sSQL = "select distinct 产品编码,物料编码 from ProProcess where 物料编码 = '" + dtSO.Rows[0]["cInvCode"] + "'";
                            DataTable dtTemp工序 = clsSQLCommond.ExecQuery(sSQL);
                            if (dtTemp工序 != null && dtTemp工序.Rows.Count > 0)
                            {
                                sSQL = "select cast(null as varchar(50)) as BOM中物料作为子件时供应类型, cast('0' as varchar(50)) as 手工计划,a.*,b.cInvName,cast(null as decimal(18,1)) as 结束时间,cast(null as varchar(50)) as 制造令号码,cast(null as decimal(18,6)) as 制造令数量,cast(null as decimal(18,10)) as 总工时,cast(null as decimal(18,0)) as 开工日期,cast(null as datetime) as 结束日期,cast(null as datetime) as 日计划起,cast(null as decimal(18,3)) as 订单数量,null as 订单需求量 " +
                                        "from ProProcess a left join @u8.Inventory b on a.产品编码 = b.cInvCode " +
                                        "where a.产品编码 = '" + dtTemp工序.Rows[0]["产品编码"] + "' and a.物料编码 = '" + dtTemp工序.Rows[0]["物料编码"] + "' order by a.母件顺序,a.加工顺序";
                                dt工序 = clsSQLCommond.ExecQuery(sSQL);
                            }
                        }

                        for (int i = 0; i < dt工序.Rows.Count; i++)
                        {
                            for (int j = 0; j < dtBOM.Rows.Count; j++)
                            {
                                if (txtProInvCode.Text.Trim() == dt工序.Rows[i]["物料编码"].ToString().Trim())
                                {
                                    dt工序.Rows[i]["BOM中物料作为子件时供应类型"] = "产成品";
                                    continue;
                                }
                                if (dt工序.Rows[i]["物料编码"].ToString().Trim() == dtBOM.Rows[j]["子件编码"].ToString().Trim())
                                {
                                    dt工序.Rows[i]["BOM中物料作为子件时供应类型"] = dtBOM.Rows[j]["供应类型"];

                                    if (dt工序.Rows[i]["BOM中物料作为子件时供应类型"].ToString().Trim() == "虚拟件")
                                    {
                                        dt工序.Rows[i]["手工计划"] = 2;
                                    }
                                    continue;
                                }
                            }
                        }

                        //销售订单所匹配的生产订单
                        sSQL = "select SoCode,SoSeq,MoCode,sum(Qty) as Qty,InvCode,min(StartDate) as 开工日期,min(DueDate) as 完工日期,b.[Status]  " +
                                "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId inner join @u8.mom_morder  c on c.MoDId = b.MoDId " +
                                "where b.SoCode = '" + txtSoCode.Text.Trim() + "' and soseq = '" + txtiRowNo.Text.Trim() + "' " +
                                "group by SoCode,SoSeq,MoCode,InvCode,b.[Status]";
                        DataTable dtMom = clsSQLCommond.ExecQuery(sSQL);

                        if (dtMom == null || dtMom.Rows.Count < 1)
                        {
                            throw new Exception("获得产品对应生产订单失败");
                        }


                        sSQL = "select * from Machine";
                        DataTable dt设备人员 = clsSQLCommond.ExecQuery(sSQL);

                        for (int i = 0; i < dt工序.Rows.Count; i++)
                        {
                            DataRow[] dr人员 = dt设备人员.Select(" machine = '" + dt工序.Rows[i]["设备"] + "' ");
                            if (dr人员.Length > 0)
                            {
                                dt工序.Rows[i]["人员"] = dr人员[0]["负责人"];
                            }

                            dt工序.Rows[i]["订单数量"] = dtSO.Rows[0]["iQuantity"];
                            dt工序.Rows[i]["订单需求量"] = Convert.ToDecimal(dt工序.Rows[i]["订单数量"]) * Convert.ToDecimal(dt工序.Rows[i]["数量"]);

                            for (int j = 0; j < dtMom.Rows.Count; j++)
                            {
                                //1. 物料能对应的直接使用制造令号
                                if (dt工序.Rows[i]["物料编码"].ToString().Trim().ToLower() == dtMom.Rows[j]["InvCode"].ToString().Trim().ToLower())
                                {
                                    dt工序.Rows[i]["制造令号码"] = dtMom.Rows[j]["MoCode"];
                                    dt工序.Rows[i]["制造令数量"] = dtMom.Rows[j]["Qty"];
                                    dt工序.Rows[i]["日计划起"] = dtMom.Rows[j]["开工日期"];
                                    //dt工序.Rows[i]["开工日期"] = dtMom.Rows[j]["开工日期"];
                                    //dt工序.Rows[i]["结束日期"] = dtMom.Rows[j]["完工日期"];
                                    dt工序.Rows[i]["制造令开工日期"] = dtMom.Rows[j]["开工日期"];
                                    dt工序.Rows[i]["制造令完工日期"] = dtMom.Rows[j]["完工日期"];

                                    int iStatus = ReturnObjectToInt(dtMom.Rows[j]["Status"]);
                                    switch (iStatus)
                                    {
                                        case 1:
                                            dt工序.Rows[i]["制造令状态"] = "开立";
                                            break;
                                        case 2:
                                            dt工序.Rows[i]["制造令状态"] = "锁定";
                                            break;
                                        case 3:
                                            dt工序.Rows[i]["制造令状态"] = "审核";
                                            break;
                                        case 4:
                                            dt工序.Rows[i]["制造令状态"] = "关闭";
                                            dt工序.Rows[i]["制造令数量"] = 0;
                                            break;
                                    }

                                    break;
                                }
                            }
                            if (dt工序.Rows[i]["制造令号码"].ToString().Trim() == "")
                            {
                                //2. 虚拟件使用其母件的制造令号
                                if (dt工序.Rows[i]["BOM中物料作为子件时供应类型"].ToString().Trim() == "虚拟件")
                                {
                                    DataRow[] drtemp = dtBOM.Select("子件编码 = '" + dt工序.Rows[i]["物料编码"].ToString().Trim() + "'");
                                    if (drtemp.Length > 0)
                                    {
                                        string s母件 = drtemp[0]["母件编码"].ToString().Trim();
                                        if (drtemp[0]["供应类型"].ToString().Trim() == "虚拟件")
                                        {
                                            drtemp = dtBOM.Select("子件编码 = '" + s母件 + "'");
                                            if (drtemp.Length > 0)
                                            {
                                                s母件 = drtemp[0]["母件编码"].ToString().Trim();
                                                if (drtemp[0]["供应类型"].ToString().Trim() == "虚拟件")
                                                {
                                                    drtemp = dtBOM.Select("子件编码 = '" + s母件 + "'");
                                                    if (drtemp.Length > 0)
                                                    {
                                                        s母件 = drtemp[0]["母件编码"].ToString().Trim();
                                                    }
                                                }
                                            }
                                        }

                                        DataRow[] drtemp2 = dtMom.Select("invCode = '" + s母件 + "'");

                                        if (drtemp2.Length > 0)
                                        {
                                            dt工序.Rows[i]["制造令号码"] = drtemp2[0]["MoCode"].ToString().Trim();
                                            dt工序.Rows[i]["制造令数量"] = FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dtSO.Rows[0]["iQuantity"]) * FrameBaseFunction.ClsBaseDataInfo.ReturnDecimal(dt工序.Rows[i]["数量"]);

                                            dt工序.Rows[i]["日计划起"] = drtemp2[0]["开工日期"];
                                            //dt工序.Rows[i]["开工日期"] = drtemp2[0]["开工日期"];
                                            //dt工序.Rows[i]["结束日期"] = drtemp2[0]["完工日期"];
                                            dt工序.Rows[i]["制造令开工日期"] = drtemp2[0]["开工日期"];
                                            dt工序.Rows[i]["制造令完工日期"] = drtemp2[0]["完工日期"];

                                        }
                                    }
                                }

                                //3. 逻辑顺序是包装（组装组，铝件组）的使用产品制造令
                                if ((dt工序.Rows[i]["逻辑顺序"].ToString().Trim() == "包装" || dt工序.Rows[i]["工序"].ToString().Trim() == "挑选") && dt工序.Rows[i]["制造令号码"].ToString().Trim() == "")
                                {
                                    if (dt工序.Rows[i]["组别"].ToString().Trim() == "组装" || dt工序.Rows[i]["组别"].ToString().Trim() == "组装组" || dt工序.Rows[i]["组别"].ToString().Trim() == "铝件" || dt工序.Rows[i]["组别"].ToString().Trim() == "铝件组")
                                    {
                                        sSQL = "select distinct mocode,b.Qty,c.StartDate as  开工日期,c.DueDate as 完工日期 " +
                                              "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId inner join @u8.mom_morder c on b.modid = c.modid  " +
                                              "where b.SoCode = '" + txtSoCode.Text.Trim() + "' and b.soseq = '" + txtiRowNo.Text.Trim() + "' and b.InvCode = '" + txtProInvCode.Text.Trim() + "' ";
                                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

                                        if (dtTemp != null && dtTemp.Rows.Count > 0)
                                        {
                                            dt工序.Rows[i]["制造令号码"] = dtTemp.Rows[0]["MoCode"];
                                            dt工序.Rows[i]["制造令数量"] = dt工序.Rows[i]["订单需求量"];

                                            dt工序.Rows[i]["日计划起"] = dtTemp.Rows[0]["开工日期"];
                                            //dt工序.Rows[i]["开工日期"] = dtTemp.Rows[0]["开工日期"];
                                            //dt工序.Rows[i]["结束日期"] = dtTemp.Rows[0]["完工日期"];
                                            dt工序.Rows[i]["制造令开工日期"] = dtTemp.Rows[0]["开工日期"];
                                            dt工序.Rows[i]["制造令完工日期"] = dtTemp.Rows[0]["完工日期"];
                                        }
                                    }
                                }

                                ////4. 组别是组装组的使用产品制造令
                                //if ((dt工序.Rows[i]["组别"].ToString().Trim() == "组装" || dt工序.Rows[i]["组别"].ToString().Trim() == "组装组") && dt工序.Rows[i]["制造令号码"].ToString().Trim() == "")
                                //{
                                //    sSQL = "select distinct mocode,b.Qty " +
                                //            "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId  " +
                                //            "where b.SoCode = '" + txtSoCode.Text.Trim() + "' and b.soseq = '" + txtiRowNo.Text.Trim() + "' and b.InvCode = '" + txtProInvCode.Text.Trim() + "' ";
                                //    DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

                                //    if (dtTemp != null && dtTemp.Rows.Count > 0)
                                //    {
                                //        dt工序.Rows[i]["制造令号码"] = dtTemp.Rows[0]["MoCode"];
                                //        dt工序.Rows[i]["制造令数量"] = dtTemp.Rows[0]["Qty"];
                                //    }
                                //}

                                //5. 制造令跟产品的工序
                                if (dt工序.Rows[i]["制造令号码"].ToString().Trim() == "")
                                {
                                    DataRow[] dr制造令跟产品 = dt制造令跟产品.Select("iID = '" + dt工序.Rows[i]["逻辑顺序"].ToString().Trim() + "'");
                                    if (dr制造令跟产品.Length > 0)
                                    {
                                        sSQL = "select distinct mocode,b.Qty,c.StartDate as  开工日期,c.DueDate as 完工日期  " +
                                              "from @u8.mom_order a inner join @u8.mom_orderdetail b on a.MoId = b.MoId inner join @u8.mom_morder c on b.modid = c.modid " +
                                              "where b.SoCode = '" + txtSoCode.Text.Trim() + "' and b.soseq = '" + txtiRowNo.Text.Trim() + "' and b.InvCode = '" + txtProInvCode.Text.Trim() + "' ";
                                        DataTable dtTemp = clsSQLCommond.ExecQuery(sSQL);

                                        if (dtTemp != null && dtTemp.Rows.Count > 0)
                                        {
                                            dt工序.Rows[i]["制造令号码"] = dtTemp.Rows[0]["MoCode"];
                                            dt工序.Rows[i]["制造令数量"] = dtTemp.Rows[0]["Qty"];

                                     
                                            //dt工序.Rows[i]["制造令状态"] =;

                                            dt工序.Rows[i]["日计划起"] = dtTemp.Rows[0]["开工日期"];
                                            //dt工序.Rows[i]["开工日期"] = dtTemp.Rows[0]["开工日期"];
                                            //dt工序.Rows[i]["结束日期"] = dtTemp.Rows[0]["完工日期"];
                                            dt工序.Rows[i]["制造令开工日期"] = dtTemp.Rows[0]["开工日期"];
                                            dt工序.Rows[i]["制造令完工日期"] = dtTemp.Rows[0]["完工日期"];
                                        }
                                    }
                                }
                            }
                        }

                        dtBingGrid = SetGridJS(dt工序.Copy()).Copy();

                        DataColumn dc = new DataColumn();
                        dc.ColumnName = "bUsed";
                        dtBingGrid.Columns.Add(dc);


                        for (int i = 0; i < dtBingGrid.Rows.Count; i++)
                        {
                            if (dtBingGrid.Rows[i]["组别"].ToString().Trim() == "委外部" || dtBingGrid.Rows[i]["工序"].ToString().Trim() == "缴库")
                            {
                                dtBingGrid.Rows[i]["制造令号码"] = DBNull.Value;
                                dtBingGrid.Rows[i]["制造令数量"] = 0;
                            }

                            if (dtBingGrid.Rows[i]["制造令数量"].ToString().Trim() == "")
                            {
                                dtBingGrid.Rows[i]["制造令数量"] = 0;
                            }

                            if (dtBingGrid.Rows[i]["bUsed"].ToString().Trim() != "")
                                continue;

                            if (dtBingGrid.Rows[i]["制造令开工日期"].ToString().Trim() == "")
                                continue;

                            string s物料编码 = dtBingGrid.Rows[i]["物料编码"].ToString().Trim();
                            DateTime d工时工序日计划起 = ReturnObjectToDatetime(dtBingGrid.Rows[i]["工时工序日计划起"]);
                            DateTime d制造令开工日期 = ReturnObjectToDatetime(dtBingGrid.Rows[i]["制造令开工日期"]);
                            TimeSpan ts = d制造令开工日期 - d工时工序日计划起;
                            int iDays = ts.Days;
                            dtBingGrid.Rows[i]["日计划起"] = dtBingGrid.Rows[i]["制造令开工日期"];
                            dtBingGrid.Rows[i]["bUsed"] = "-1";
                            for (int j = i + 1; j < dtBingGrid.Rows.Count; j++)
                            {
                                string s物料编码2 = dtBingGrid.Rows[j]["物料编码"].ToString().Trim();

                                if (s物料编码 != s物料编码2)
                                    continue;

                                dtBingGrid.Rows[j]["日计划起"] = ReturnObjectToDatetime(dtBingGrid.Rows[j]["工时工序日计划起"]).AddDays(iDays);
                                dtBingGrid.Rows[j]["bUsed"] = "-1";
                            }
                        }

                        try
                        {
                            gridControl1.DataSource = dtBingGrid;
                        }
                        catch (Exception ee)
                        { }

                        gridControl1.DataSource = dtBingGrid;
                        SetText(dtSO);

                        SetEdit(true);
                        sState = "add1";

                        #endregion
                    }
                    else
                    {
                        #region 手工计划

                        sSQL = "SELECT distinct round([根母件],2) as [根母件],[级别] as [级别],round([母件Id],2) as [母件Id],[母件编码] as [母件编码],[母件代号] as [母件代号],[母件名称] as [母件名称],[PItemSpec] as [PItemSpec],[PEngineerFigNo] as [PEngineerFigNo],[母件计量单位] as [母件计量单位],round([母件损耗率],3) as [母件损耗率],[版本号] as [版本号],[版本说明] as [版本说明],[版本日期] as [版本日期],[状态] as [状态],[母件属性] as [母件属性],[变更单号] as [变更单号]" +
                                 ",[行号] as [行号],[子件行号] as [子件行号],[工序行号] as [工序行号],[子件编码] as [子件编码],[子件代码] as [子件代码],[子件名称] as [子件名称],[CItemSpec] as [CItemSpec],[CEngineerFigNo] as [CEngineerFigNo],[子件计量单位] as [子件计量单位],round([基本用量],6) as [基本用量],round([基础数量],6) as [基础数量],round([子件损耗率],3) as [子件损耗率],[辅助单位] as [辅助单位],round([换算率],2) as [换算率],round([辅助基本用量],6) as [辅助基本用量],round([辅助使用量],6) as [辅助使用量],[固定用量] as [固定用量],[供应类型] as [供应类型],round([使用数量],6) as [使用数量],[子件生效日] as [子件生效日],[子件失效日] as [子件失效日],[偏置期] as [偏置期],round([计划比例],3) as [计划比例],[产出品] as [产出品],[产出类型] as [产出类型],[成本相关] as [成本相关],[可选否] as [可选否],[选择规则] as [选择规则],[子件属性] as [子件属性],[仓库代号] as [仓库代号],[仓库名称] as [仓库名称],[领料部门代号] as [领料部门代号],[领料部门名称] as [领料部门名称],[定位符1] as [定位符1],[定位符2] as [定位符2],[定位符3] as [定位符3],[定位符4] as [定位符4],[定位符5] as [定位符5],[定位符6] as [定位符6],[定位符7] as [定位符7],[定位符8] as [定位符8],[定位符9] as [定位符9],[定位符10] as [定位符10],[备注] as [备注],[母件cFree1],[母件cFree2],[母件cFree3],[母件cFree4],[母件cFree5],[母件cFree6],[母件cFree7],[母件cFree8],[母件cFree9],[母件cFree10],[母件cInvDefine1],[母件cInvDefine2],[母件cInvDefine3],[母件cInvDefine4],[母件cInvDefine5],[母件cInvDefine6],[母件cInvDefine7],[母件cInvDefine8],[母件cInvDefine9],[母件cInvDefine10],[母件cInvDefine11],[母件cInvDefine12],[母件cInvDefine13],[母件cInvDefine14],[母件cInvDefine15],[母件cInvDefine16],[cDefine1],[cDefine2],[cDefine3],[cDefine4],[cDefine5],[cDefine6],[cDefine7],[cDefine8],[cDefine9],[cDefine10],[cDefine11],[cDefine12],[cDefine13],[cDefine14],[cDefine15],[cDefine16],[子件cFree1],[子件cFree2],[子件cFree3],[子件cFree4],[子件cFree5],[子件cFree6],[子件cFree7],[子件cFree8],[子件cFree9],[子件cFree10],[子件cInvDefine1],[子件cInvDefine2],[子件cInvDefine3],[子件cInvDefine4],[子件cInvDefine5],[子件cInvDefine6],[子件cInvDefine7],[子件cInvDefine8],[子件cInvDefine9],[子件cInvDefine10],[子件cInvDefine11],[子件cInvDefine12],[子件cInvDefine13],[子件cInvDefine14],[子件cInvDefine15],[子件cInvDefine16],[cDefine22],[cDefine23],[cDefine24],[cDefine25],[cDefine26],[cDefine27],[cDefine28],[cDefine29],[cDefine30],[cDefine31],[cDefine32],[cDefine33],[cDefine34],[cDefine35],[cDefine36],[cDefine37]  " +
                           "from TMPUF_939096218_heron939495570_DOLLEVS05 where 1=-1";
                        DataTable dtBOM = clsSQLCommond.ExecQuery(sSQL);

                        sSQL = "select a.*,b.cInvName,b.cInvStd from dbo.生产手工计划 a inner join @u8.Inventory b on a.物料编码 = b.cInvCode where a.iID = " + fAdd.sAutoID;
                        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                        if (dt == null || dt.Rows.Count < 1)
                        {
                            throw new Exception("加载手工计划失败");
                        }

                        txtProInvCode.Text = dt.Rows[0]["物料编码"].ToString().Trim();
                        txtProInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                        txtSoCode.Text = dt.Rows[0]["销售订单号"].ToString().Trim();
                        txtiRowNo.Text = dt.Rows[0]["行号"].ToString().Trim();
                        txtSoCodeW.Text = dt.Rows[0]["销售订单号"].ToString().Trim();
                        txtRemark.Text = dt.Rows[0]["备注"].ToString().Trim();
                        txtSoCodeW.Text = dt.Rows[0]["销售订单号"].ToString().Trim();
                        txt手工计划ID.Text = dt.Rows[0]["iID"].ToString().Trim();

                        dtmPlan.Text = dt.Rows[0]["完工日期"].ToString().Trim();
                        txtQty.Text = dt.Rows[0]["数量"].ToString().Trim();

                        string s = FrameBaseFunction.ClsDefDataInfo.s出货周(txtSoCode.Text.Trim(), txtiRowNo.Text.Trim());
                        if (s != "")
                        {
                            int iStart = s.IndexOf('-');
                            int iEnd = s.IndexOf('周');

                            int i周 = ReturnObjectToInt(s.Substring(iStart + 1, iEnd - iStart - 1));
                            if (i周 > 0)
                                txt出货周.Text = i周.ToString();
                            else
                                txt出货周.Text = ReturnWeekinYear(dtmG.DateTime).ToString();
                        }
                        else
                        {
                            txt出货周.Text = "";
                            //throw new Exception("请在外销订单总表登记出货信息");
                        }


                        sSQL = @"
select cast(null as varchar(50)) as BOM中物料作为子件时供应类型, cast('1' as varchar(50)) as 手工计划,a.*,b.cInvName,cast(null as decimal(18,1)) as 结束时间,cast(null as varchar(50)) as 制造令号码,cast(null as decimal(18,6)) as 制造令数量,cast(null as decimal(18,10)) as 总工时,cast(null as decimal(18,0)) as 开工日期,cast(null as datetime) as 结束日期,cast(null as datetime) as 日计划起,cast(null as decimal(18,3)) as 订单数量,null as 订单需求量,cast(null as varchar(10)) as 人员
from ProProcess a left join @u8.Inventory b on a.产品编码 = b.cInvCode 
where 1=-1 
order by a.母件顺序,a.加工顺序
";
                        if (dt.Rows[0]["产品编码"].ToString().Trim() != dt.Rows[0]["物料编码"].ToString().Trim() && dt.Rows[0]["产品编码"].ToString().Trim()!= "")
                        {
                            sSQL = sSQL.Replace("1=-1", " a.产品编码 = '" + dt.Rows[0]["产品编码"].ToString().Trim() + "' and a.物料编码 = '" + dt.Rows[0]["物料编码"].ToString().Trim() + "' ");
                        }
                        else
                        {
                            sSQL = sSQL.Replace("1=-1", " a.产品编码 = '" + txtProInvCode.Text.Trim() + "' ");
                        }
                        DataTable dt工序 = clsSQLCommond.ExecQuery(sSQL);

                        sSQL = "select * from Machine";
                        DataTable dt设备人员 = clsSQLCommond.ExecQuery(sSQL);


                        if (dt工序 != null && dt工序.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt工序.Rows.Count; i++)
                            {
                                dt工序.Rows[i]["组别"] = sDepInfo(dt工序.Rows[i]["组别"].ToString().Trim());
                                dt工序.Rows[i]["下一班组"] = sDepInfo(dt工序.Rows[i]["下一班组"].ToString().Trim());

                                DataRow[] dr人员 = dt设备人员.Select(" machine = '" + dt工序.Rows[i]["设备"] + "' ");
                                if (dr人员.Length > 0)
                                {
                                    dt工序.Rows[i]["人员"] = dr人员[0]["负责人"];
                                }

                                for (int j = 0; j < dtBOM.Rows.Count; j++)
                                {
                                    if (txtProInvCode.Text.Trim() == dt工序.Rows[i]["物料编码"].ToString().Trim())
                                    {
                                        dt工序.Rows[i]["BOM中物料作为子件时供应类型"] = "产成品";
                                        continue;
                                    }
                                    if (dt工序.Rows[i]["物料编码"].ToString().Trim() == dtBOM.Rows[j]["子件编码"].ToString().Trim())
                                    {
                                        dt工序.Rows[i]["BOM中物料作为子件时供应类型"] = dtBOM.Rows[j]["供应类型"];

                                        if (dt工序.Rows[i]["BOM中物料作为子件时供应类型"].ToString().Trim() == "虚拟件")
                                        {
                                            dt工序.Rows[i]["手工计划"] = 2;
                                        }
                                        continue;
                                    }
                                }
                            }
                        }

                        dtBingGrid = dt工序.Copy();

                        gridControl1.DataSource = dtBingGrid;

                        SetEdit(true);

                        sState = "add2";

                        #endregion
                    }
                }
                else
                {
                    throw new Exception("取消");
                }

                string sErr = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "物料编码为空\n";
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol组别).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "组别为空\n";
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol工序).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "工序为空\n";
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol设备).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "设备为空\n";
                    }
                }
                if (sErr.Length > 0)
                {
                    MsgBox("工时工序档案错误，请核实", sErr);
                }
            }
            catch (Exception ee)
            {
                SetTxtGridNull();
                throw new Exception(ee.Message);
            }
        }

        private DataTable SetGridJS(DataTable dtPro)
        {
            if (dtmPlan.DateTime < Convert.ToDateTime("2000-1-1") || dtmPlan.Text.Trim() == string.Empty)
            {
                return null;
            }
            if (txtQty.Text.Trim() == string.Empty)
            {
                return null;
            }
            if (dtPro == null || dtPro.Rows.Count < 1)
            {
                throw new Exception("获得产品工序失败，请设置");
            }

            decimal d1 = decimal.Parse(txtQty.Text.Trim());     //订单数量

            for (int i = 0; i < dtPro.Rows.Count; i++)
            {
                decimal d2 = 0; //单位工时
                decimal d3 = 0; //数量
                decimal d4 = 0; //作业人员数
                decimal d5 = 0; //开工时间
                decimal d6 = 0; //间隔时间
                decimal d7 = 0; //结束时间
                decimal d8 = 0; //总工时
                decimal d9 = 0; //开工日期
                decimal d10;    //结束日期
                if (dtPro.Rows[i]["单位工时"].ToString().Trim() != "")
                {
                    d2 = Convert.ToDecimal(dtPro.Rows[i]["单位工时"]);
                }
                if (dtPro.Rows[i]["数量"].ToString().Trim() != "")
                {
                    d3 = Convert.ToDecimal(dtPro.Rows[i]["数量"]);
                }
                if (dtPro.Rows[i]["作业人员数量"].ToString().Trim() != "")
                {
                    d4 = Convert.ToDecimal(dtPro.Rows[i]["作业人员数量"]);
                }
                if (dtPro.Rows[i]["间隔时间"].ToString().Trim() != "")
                {
                    d6 = Convert.ToDecimal(dtPro.Rows[i]["间隔时间"]);
                }

                if (dtPro.Rows[i]["开工排序"].ToString().Trim() == "")
                {
                    d5 = Convert.ToDecimal(dtPro.Rows[i]["开工时间"]);

                    if (d5 != 0 && i != 0)
                    {
                        d5 = Convert.ToDecimal(dtPro.Rows[i - 1]["结束时间"]);
                        dtPro.Rows[i]["开工时间"] = d5;
                    }
                }
                else
                {
                    string s开工排序 = dtPro.Rows[i]["开工排序"].ToString().Trim();

                    int iStart1 = -1;
                    int iEnd1 = -1;
                    int iStart2 = -1;
                    string s = "";
                    for (int j = 0; j < s开工排序.Length; j++)
                    {
                        if (s开工排序.Substring(j, 1) == "【")
                        {
                            iStart1 = j;
                            continue;
                        }
                        if (s开工排序.Substring(j, 1) == "】")
                        {
                            iEnd1 = j;
                            continue;
                        }
                        if (s开工排序.Substring(j, 1) == "〈" || s开工排序.Substring(j, 1) == "<")
                        {
                            iStart2 = j;
                            continue;
                        }
                        if (s开工排序.Substring(j, 1) == "〉" || s开工排序.Substring(j, 1) == ">")
                        {
                            string s1 = s开工排序.Substring(iStart1 + 1, iEnd1 - iStart1 - 1).Trim();
                            string s2 = s开工排序.Substring(iStart2 + 1, j - iStart2 - 1).Trim();
                            int iRowNeed = -1;
                            for (int k = 0; k < dtPro.Rows.Count; k++)
                            {
                                if (dtPro.Rows[k]["母件顺序"].ToString().Trim() == s2)
                                {
                                    iRowNeed = k;
                                }
                            }
                            if (iRowNeed >= 0)
                            {
                                s = s + GetGridColValue(dtPro, iRowNeed, s1);
                            }
                            iStart1 = -1;
                            iStart2 = -1;
                            iEnd1 = -1;
                            continue;
                        }
                        if (iStart1 == -1)
                        {
                            s = s + s开工排序.Substring(j, 1);
                        }
                    }
                    sSQL = " select " + s;
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    d5 = Convert.ToDecimal(dt.Rows[0][0]);
                    dtPro.Rows[i]["开工时间"] = d5;
                }

                d8 = d1 * d2 * d3;
                d9 = decimal.Round(d5 / 8 + 1, 0);
                d7 = decimal.Round(d8 / d4 + d5 + d6, 1);
                d10 = decimal.Round(d7 / 8 + 1, 0);
                dtPro.Rows[i]["结束时间"] = d7;
                dtPro.Rows[i]["总工时"] = d8;
                dtPro.Rows[i]["开工日期"] = d9;
                dtPro.Rows[i]["结束日期"] = d10;

                dtPro.Rows[i]["下一班组"] = sDepInfo(dtPro.Rows[i]["下一班组"].ToString().Trim());
                dtPro.Rows[i]["组别"] = sDepInfo(dtPro.Rows[i]["组别"].ToString().Trim());
            }

            for (int i = dtPro.Rows.Count - 1; i >= 0; i--)
            {
                if (i == dtPro.Rows.Count - 1)
                {
                    dtPro.Rows[i]["工时工序日计划起"] = dtmPlan.DateTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    dtPro.Rows[i]["工时工序日计划起"] = Convert.ToDateTime(dtPro.Rows[i + 1]["工时工序日计划起"]).AddDays(Convert.ToInt32(dtPro.Rows[i]["开工日期"]) - Convert.ToInt32(dtPro.Rows[i + 1]["开工日期"]));
                }
            }

            return dtPro;
        }

        private string GetGridColValue(DataTable dt, int iRow, string sColName)
        {
            return dt.Rows[iRow][sColName].ToString().Trim();
        }
             

        /// <summary>
        /// 参照数据
        /// </summary>
        /// <param name="dt"></param>
        private void SetText(DataTable dt)
        {
            txtProInvCode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
            txtProInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();
            txtQty.Text = dt.Rows[0]["iQuantity"].ToString().Trim();
            txtSoCode.Text = dt.Rows[0]["cSoCode"].ToString().Trim();
            txtiRowNo.Text = dt.Rows[0]["iRowNo"].ToString().Trim();
            txtSoCodeW.Text = dt.Rows[0]["cItemCode"].ToString().Trim();
            txtSoCodeK.Text = dt.Rows[0]["cDefine2"].ToString().Trim();
            txtCusCode.Text = dt.Rows[0]["cCusName"].ToString().Trim();

            //dtmDate.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;

            dtmC.Text = dt.Rows[0]["dPreDate"].ToString().Trim();
            dtmW.Text = dt.Rows[0]["dPreMoDate"].ToString().Trim();
            dtmG.Text = dt.Rows[0]["cDefine36"].ToString().Trim();
            dtmJ.Text = dt.Rows[0]["dPreMoDate"].ToString().Trim();
            dtmPlan.Text = dt.Rows[0]["dPreMoDate"].ToString().Trim();

            txt手工计划ID.Text = "";

            string s = FrameBaseFunction.ClsDefDataInfo.s出货周(txtSoCode.Text.Trim(), txtiRowNo.Text.Trim());
            if (s != "")
            {
                int iStart = s.IndexOf('-');
                int iEnd = s.IndexOf('周');

                int i周 = ReturnObjectToInt(s.Substring(iStart + 1, iEnd - iStart - 1));
                if (i周 > 0)
                    txt出货周.Text = i周.ToString();
                else
                    txt出货周.Text = ReturnWeekinYear(dtmG.DateTime).ToString();
            }
            else
            {
                //txt出货周.Text = ReturnWeekinYear(dtmG.DateTime).ToString();
                throw new Exception("请在外销订单总表登记出货信息");
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
            DataTable dtState = (DataTable)ItemLookUpEditState.DataSource;
            DataColumn dc = new DataColumn();
            dc.ColumnName = "StateText";
            dt.Columns.Add(dc);
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] drState = dtState.Select("iID = '" + dt.Rows[i]["State"].ToString().Trim() + "'");
                if (drState.Length > 0)
                {
                    dt.Rows[i]["StateText"] = drState[0]["State"];
                }

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

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void btnRefresh()
        {
            SetTxtGridValue(dtSel.Rows[iPage]["单据号"].ToString().Trim());
        }
        /// <summary>
        /// 查询
        /// </summary>
        private void btnSel()
        {
            FrmWorkPlan_SEL fSel = new FrmWorkPlan_SEL();
            fSel.ShowDialog();
            if (fSel.DialogResult != DialogResult.OK)
            {
                throw new Exception("取消查询");
            }

            dtSel = fSel.dtSEL.Copy();
            iPage = fSel.iPageSEL;
            string sCode = dtSel.Rows[iPage]["单据号"].ToString().Trim();
            SetTxtGridValue(sCode);
        }
        /// <summary>
        /// 首页
        /// </summary>
        private void btnFirst()
        {
            GetdtSel();
            if (dtSel == null || dtSel.Rows.Count < 1)
            {
                SetTxtGridNull();
                return;
            }
            iPage = 0;
            string sCode = dtSel.Rows[iPage]["单据号"].ToString().Trim();
            SetTxtGridValue(sCode);
        }
        /// <summary>
        /// 上页
        /// </summary>
        private void btnPrev()
        {
            if (dtSel == null || dtSel.Rows.Count < 1)
            {
                SetTxtGridNull();
                return;
            }
            if (iPage > 0)
            {
                iPage -= 1;
            }
            string sCode = dtSel.Rows[iPage]["单据号"].ToString().Trim();
            SetTxtGridValue(sCode);
        }
        /// <summary>
        /// 下页
        /// </summary>
        private void btnNext()
        {
            if (dtSel == null || dtSel.Rows.Count < 1)
            {
                SetTxtGridNull();
                return;
            }
            if (iPage < dtSel.Rows.Count - 1)
            {
                iPage += 1;
            }
            string sCode = dtSel.Rows[iPage]["单据号"].ToString().Trim();
            SetTxtGridValue(sCode);
        }
        /// <summary>
        /// 末页
        /// </summary>
        private void btnLast()
        {
            GetdtSel();

            if (dtSel == null || dtSel.Rows.Count < 1)
            {
                SetTxtGridNull();
                return;
            }
            iPage = dtSel.Rows.Count - 1;

            string sCode = dtSel.Rows[iPage]["单据号"].ToString().Trim();
            SetTxtGridValue(sCode);
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
        }
        /// <summary>
        /// 删行
        /// </summary>
        private void btnDelRow()
        {
            for (int i = gridView1.RowCount - 1; i >= 0 ; i--)
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
            if (txtAudit.Text.Trim() != "")
            {
                throw new Exception("已经审核不能修改");
            }

            SetEdit(true);
            sState = "edit";
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void btnDel()
        {
            if (txtAudit.Text.Trim() != "")
            {
                throw new Exception("该单据已审核，不能删除");
            }
            if (sState == "add")
            {
                throw new Exception("该单据尚未保存，不能删除");
            }
            DialogResult d = MessageBox.Show("确定删除单据:" + txtCode.Text.Trim() + "么？\n是：删除\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != DialogResult.Yes)
            {
                return;
            }

            aList = new System.Collections.ArrayList();
            sSQL = "delete dbo.生产计划明细 where 表头单据号 = '" + txtCode.Text.Trim() + "' ";
            aList.Add(sSQL);
            sSQL = "delete dbo.生产计划 where 单据号 = '" + txtCode.Text.Trim() + "' ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("删除成功！\n合计执行语句:" + iCou + "条");

                btnLast();
            }
        }

        /// <summary>
        /// 判断生产设备是否已经使用
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sErr"></param>
        /// <returns></returns>
        private bool CheckCanDel(string p,out string sErr)
        {
            bool b = true;
            sErr = "";

            return b;
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

            if (txt出货周.Text.Trim() == "")
            {
                throw new Exception("出货周不能为空");
            }

            if (sState == "alter")
            {
                if (txtCode.Text.Trim() == "")
                    throw new Exception("没有单据号，不能变更");


                aList = new System.Collections.ArrayList();

                sSQL = "update 生产计划 set 出货周 = '" + txt出货周.Text.Trim() + "' where 单据号 = '" + txtCode.Text.Trim() + "' ";
                aList.Add(sSQL);

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    decimal d = ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol制造令数量), 6);
                    if (d < 0)
                        continue;

                    sSQL = "update 生产计划明细 set 制造令数量 = " + d + ", 组别 = '" + gridView1.GetRowCellDisplayText(i, gridCol组别).ToString().Trim() + "',下道工序 = '" + gridView1.GetRowCellDisplayText(i, gridCol下道工序).ToString().Trim() + "' " +
                                ",下一班组 = '" + gridView1.GetRowCellDisplayText(i, gridCol下一班组) + "' " +
                            "where iID =  " + gridView1.GetRowCellDisplayText(i,gridColiID).ToString().Trim() ;
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("变更保存成功");
                }
                sState = "save";
                txt出货周.Enabled = false;
            }
            else
            {
                string sInfo = "";
                string sErr = "";
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellDisplayText(i, gridCol组别).ToString().Trim() == "委外部")
                        continue;

                    if (gridView1.GetRowCellDisplayText(i, gridCol制造令号码).ToString().Trim() == "" || gridView1.GetRowCellDisplayText(i, gridCol制造令数量).ToString().Trim() == "" || Convert.ToDecimal(gridView1.GetRowCellDisplayText(i, gridCol制造令数量)) == 0)
                    {
                        sInfo = sInfo + "行" + (i + 1) + "制造令为空，或者制造令数量为0\n";
                        continue;
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol物料编码).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "物料编码为空\n";
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol组别).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "组别为空\n";
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol工序).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "工序为空\n";
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol设备).ToString().Trim() == "")
                    {
                        sErr = sErr + "行" + (i + 1) + "设备为空\n";
                    }
                    if (gridView1.GetRowCellDisplayText(i, gridCol人员).ToString().Trim() == "")
                    {
                        if (gridView1.GetRowCellDisplayText(i, gridCol组别).ToString().Trim() != "委外部" && gridView1.GetRowCellDisplayText(i, gridCol工序).ToString().Trim() != "缴库" && ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol制造令数量), 6) <= 0)
                        {
                            sErr = sErr + "行" + (i + 1) + "人员为空\n";
                        }
                    }

                    DateTime d日计划起 = ReturnObjectToDatetime(gridView1.GetRowCellDisplayText(i, gridCol日计划起));
                    if (d日计划起 < DateTime.Today || d日计划起 > DateTime.Today.AddMonths(6))
                    {
                        sErr = sErr + "行" + (i + 1) + "日计划起小于当天，或超出当天6个月\n";
                    }
                }
                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }

                if (sInfo.Length > 0)
                {
                    sInfo = "请确认以下信息是否漏开制造令，如果确实不用生产请点击确定按钮继续保存，否则请点击取消退出保存\n\n" + sInfo;
                    DialogResult d = MsgBox("提示", sInfo);
                    if (d != DialogResult.OK)
                    {
                        throw new Exception("保存失败");
                    }
                }


                if (sState.Substring(0, 3) == "add")
                {
                    txtCreater.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                    dtmCreater.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                    sSQL = "select isnull(max(单据号),0) as 单据号 from 生产计划 where 单据号 like '" + DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMMdd") + "%'";
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                    if (dt == null || dt.Rows.Count < 1)
                    {
                        throw new Exception("获得单据号失败");
                    }

                    string sCode = dt.Rows[0]["单据号"].ToString().Trim();

                    if (sCode == "0")
                    {
                        sCode = DateTime.Parse(FrameBaseFunction.ClsBaseDataInfo.sLogDate).ToString("yyyyMMdd") + "001";
                    }
                    else
                    {
                        string sCodeTemp = (ReturnObjectToInt(sCode.Substring(8)) + 1).ToString().Trim();
                        for (int ii = 0; ii < 3; ii++)
                        {
                            if (sCodeTemp.Length < 3)
                                sCodeTemp = "0" + sCodeTemp;
                        }

                        sCode = sCode.Substring(0, 8) + sCodeTemp;
                    }

                    txtCode.Text = sCode;
                    dtmDate.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;
                }
                sSQL = "select * from dbo.生产计划 where 1 = -1";
                DataTable dtHead = clsSQLCommond.ExecQuery(sSQL);
                sSQL = "select * from dbo.生产计划明细 where 1 = -1";
                DataTable dtDetail = clsSQLCommond.ExecQuery(sSQL);

                aList = new System.Collections.ArrayList();

                DataRow drHead = dtHead.NewRow();
                drHead["单据号"] = txtCode.Text.Trim();
                drHead["单据日期"] = dtmDate.DateTime.ToString("yyyy-MM-dd");
                if (txt手工计划ID.Text.Trim() == "" || ReturnObjectToInt(txt手工计划ID.Text.Trim()) == 0)
                {
                    drHead["单据类型"] = 0;
                }
                else
                {
                    drHead["单据类型"] = 1;
                }
                drHead["数量"] = txtQty.Text.Trim();
                drHead["产品编码"] = txtProInvCode.Text.Trim();
                drHead["销售订单号"] = txtSoCode.Text.Trim();
                drHead["销售订单行号"] = txtiRowNo.Text.Trim();
                drHead["帐套号"] = int.Parse(FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                drHead["备注"] = txtRemark.Text.Trim();
                drHead["创建人"] = txtCreater.Text.Trim();
                drHead["创建日期"] = dtmCreater.DateTime.ToString("yyyy-MM-dd");
                drHead["排产完工日期"] = dtmDate.Text.Trim();
                drHead["出货周"] = txt出货周.Text.Trim();

                int i手工计划ID = ReturnObjectToInt(txt手工计划ID.Text.Trim());
                drHead["手工计划ID"] = i手工计划ID;

                dtHead.Rows.Add(drHead);

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    DataRow drDetail = dtDetail.NewRow();
                    drDetail["表头单据号"] = txtCode.Text.Trim();
                    drDetail["母件顺序"] = gridView1.GetRowCellDisplayText(i, gridCol母件顺序);
                    drDetail["帐套号"] = FrameBaseFunction.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3);
                    drDetail["物料编码"] = gridView1.GetRowCellDisplayText(i, gridCol物料编码);
                    drDetail["半成品编码"] = gridView1.GetRowCellDisplayText(i, gridCol半成品编码);
                    drDetail["逻辑顺序"] = gridView1.GetRowCellDisplayText(i, gridCol逻辑顺序);
                    drDetail["加工顺序"] = gridView1.GetRowCellDisplayText(i, gridCol加工顺序);
                    drDetail["设备"] = gridView1.GetRowCellDisplayText(i, gridCol设备);
                    drDetail["人员"] = gridView1.GetRowCellDisplayText(i, gridCol人员);
                    drDetail["制造令号码"] = gridView1.GetRowCellDisplayText(i, gridCol制造令号码);
                    drDetail["产品名称"] = gridView1.GetRowCellDisplayText(i, gridCol产品名称);
                    drDetail["产品规格"] = gridView1.GetRowCellDisplayText(i, gridCol产品规格);
                    drDetail["组别"] = gridView1.GetRowCellDisplayText(i, gridCol组别);
                    drDetail["内部流转"] = gridView1.GetRowCellDisplayText(i, gridCol内部流转);
                    drDetail["工序"] = gridView1.GetRowCellDisplayText(i, gridCol工序);
                    drDetail["数量"] = gridView1.GetRowCellDisplayText(i, gridCol数量);
                    drDetail["手工计划"] = gridView1.GetRowCellValue(i, gridCol手工计划);
                    drDetail["订单数量"] = gridView1.GetRowCellDisplayText(i, gridCol订单数量);
                    if (gridView1.GetRowCellValue(i, gridCol手工计划).ToString().Trim() == "0")
                    {
                        drDetail["开工时间"] = gridView1.GetRowCellDisplayText(i, gridCol开工时间);
                        drDetail["结束时间"] = gridView1.GetRowCellDisplayText(i, gridCol结束时间);
                        drDetail["间隔时间"] = gridView1.GetRowCellDisplayText(i, gridCol间隔时间);
                        drDetail["总工时"] = gridView1.GetRowCellDisplayText(i, gridCol总工时);
                        drDetail["开工日期"] = gridView1.GetRowCellDisplayText(i, gridCol开工日期);
                        drDetail["结束日期"] = gridView1.GetRowCellDisplayText(i, gridCol结束日期);
                    }

                    if (ReturnObjectToDatetime(gridView1.GetRowCellDisplayText(i, gridCol工时工序日计划起)) > Convert.ToDateTime("2013-1-1"))
                    {
                        drDetail["工时工序日计划起"] = gridView1.GetRowCellDisplayText(i, gridCol工时工序日计划起);
                    }
                    if (ReturnObjectToDatetime(gridView1.GetRowCellDisplayText(i, gridCol制造令开工日期)) > Convert.ToDateTime("2013-1-1"))
                    {
                        drDetail["制造令开工日期"] = gridView1.GetRowCellDisplayText(i, gridCol制造令开工日期);
                    }
                    if (ReturnObjectToDatetime(gridView1.GetRowCellDisplayText(i, gridCol制造令完工日期)) > Convert.ToDateTime("2013-1-1"))
                    {
                        drDetail["制造令完工日期"] = gridView1.GetRowCellDisplayText(i, gridCol制造令完工日期);
                    }

                    if (gridView1.GetRowCellDisplayText(i, gridCol单位工时).ToString().Trim() != string.Empty)
                    {
                        drDetail["单位工时"] = gridView1.GetRowCellDisplayText(i, gridCol单位工时);
                    }

                    if (gridView1.GetRowCellDisplayText(i, gridCol开工排序).ToString().Trim() != "")
                    {
                        drDetail["开工排序"] = gridView1.GetRowCellDisplayText(i, gridCol开工排序);
                    }
                    drDetail["作业人员数量"] = gridView1.GetRowCellDisplayText(i, gridCol作业人员数量);

                    if (gridView1.GetRowCellValue(i, gridCol日计划起).ToString().Trim() == "" && ReturnObjectToDecimal(gridView1.GetRowCellDisplayText(i, gridCol制造令数量).ToString().Trim(), 2) == 0)
                    {
                        continue;
                    }
                    drDetail["日计划起"] = gridView1.GetRowCellValue(i, gridCol日计划起);
                    drDetail["下道工序"] = gridView1.GetRowCellDisplayText(i, gridCol下道工序);
                    drDetail["下一班组"] = gridView1.GetRowCellDisplayText(i, gridCol下一班组);
                    drDetail["完工入库"] = gridView1.GetRowCellDisplayText(i, gridCol完工入库);

                    if (gridView1.GetRowCellDisplayText(i, gridCol制造令数量).ToString().Trim() == "" && sState == "add1")
                    {
                        throw new Exception("制造令数量不能为空");
                    }

                    drDetail["订单需求量"] = gridView1.GetRowCellDisplayText(i, gridCol订单需求量);
                    //if (gridView1.GetRowCellDisplayText(i, gridCol制造令号码).ToString().Trim() != "")
                    //{
                        drDetail["制造令数量"] = gridView1.GetRowCellDisplayText(i, gridCol制造令数量);
                    //}
                    dtDetail.Rows.Add(drDetail);
                }


                for (int i = 0; i < dtHead.Rows.Count; i++)
                {
                    if (sState.Substring(0, 3) == "add")
                    {
                        sSQL = clsGetSQL.GetInsertSQL("生产计划", dtHead, i);
                        aList.Add(sSQL);
                    }
                    if (sState == "edit")
                    {
                        sSQL = clsGetSQL.GetUpdateSQL("生产计划", dtHead, i);
                        aList.Add(sSQL);
                    }
                }

                if (sState == "edit")
                {
                    sSQL = "delete 生产计划明细 where 表头单据号 = '" + txtCode.Text.Trim() + "'";
                    aList.Add(sSQL);
                }
                for (int i = 0; i < dtDetail.Rows.Count; i++)
                {
                    sSQL = clsGetSQL.GetInsertSQL("生产计划明细", dtDetail, i);
                    aList.Add(sSQL);
                }

                if (aList.Count > 0)
                {
                    int iCou = clsSQLCommond.ExecSqlTran(aList);
                    MessageBox.Show("保存成功！\n合计执行语句:" + iCou + "条");
                    SetEdit(false);

                    sState = "save";

                    SetTxtGridValue(txtCode.Text.Trim());
                }
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        private void btnUnDo()
        {
            SetTxtGridValue(dtSel.Rows[iPage]["单据号"].ToString().Trim());
        }
        /// <summary>
        /// 审核
        /// </summary>
        private void btnAudit()
        {
            if (txtAudit.Text.Trim() != "")
            {
                throw new Exception("该单据已审核");
            }
            if (sState == "add")
            {
                throw new Exception("该单据尚未保存，不能审核");
            }

            aList = new System.Collections.ArrayList();
            sSQL = "update dbo.生产计划 set 审核人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',审核日期 = getdate()  where 单据号 = '" + txtCode.Text.Trim() + "' ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                txtAudit.Text = FrameBaseFunction.ClsBaseDataInfo.sUserName;
                dtmAudit.Text = FrameBaseFunction.ClsBaseDataInfo.sLogDate;

                MessageBox.Show("审核成功！");
            }
        }
        /// <summary>
        /// 弃审
        /// </summary>
        private void btnUnAudit()
        {
            if (txtAudit.Text.Trim() == "")
            {
                throw new Exception("该单据尚未审核");
            }
            if (sState == "add")
            {
                throw new Exception("该单据尚未保存，不能弃审");
            }

            //需要判断是否已经使用
            sSQL = "select count(*) from dbo.生产计划 a inner join dbo.生产计划明细 b on b.表头单据号 = a.单据号 " +
                    "where b.iID in (select distinct 生产计划明细iID from dbo.生产日计划) and a.单据号 = '" + txtCode.Text + "'";
            long iCount = Convert.ToInt64(clsSQLCommond.ExecGetScalar(sSQL));
            if (iCount > 0)
            {
                throw new Exception("该单据已经排日计划，不能弃审");
            }

            aList = new System.Collections.ArrayList();
            sSQL = "update dbo.生产计划 set 审核人 = null,审核日期 = null where 单据号 = '" + txtCode.Text.Trim() + "' ";
            aList.Add(sSQL);

            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                txtAudit.Text = "";
                dtmAudit.Text = "";

                MessageBox.Show("弃审成功！");
            }
        }
        /// <summary>
        /// 打开
        /// </summary>
        private void btnOpen()
        {
            DialogResult d = MessageBox.Show("确定打开选中的 " + txtCode.Text + " 么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            aList = new System.Collections.ArrayList();

            sSQL = " update 生产计划明细 set 关闭人 = null,关闭日期 = null " +
                   " where 表头单据号 = '" + txtCode.Text.Trim() + "' and 帐套号 = '200'";
            aList.Add(sSQL);


            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");
                SetTxtGridValue(txtCode.Text.Trim());
            }

            //DialogResult d = MessageBox.Show("确定打开选中的 " + gridView1.SelectedRowsCount + " 行么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            //if (d != System.Windows.Forms.DialogResult.Yes)
            //{
            //    return;
            //}

            //sSQL = "select * from dbo.生产计划明细 where 1 = -1";
            //DataTable dtDetail = clsSQLCommond.ExecQuery(sSQL);
            //aList = new System.Collections.ArrayList();
            //for (int i = gridView1.RowCount - 1; i >= 0; i--)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        sSQL = " update 生产计划明细 set 关闭人 =null,关闭日期 = null " +
            //               " where 表头单据号 = '" + txtCode.Text.Trim() + "' and 母件顺序 = " + gridView1.GetRowCellDisplayText(i, gridCol母件顺序) + "";
            //        aList.Add(sSQL);
            //    }
            //}

            //if (aList.Count > 0)
            //{
            //    int iCou = clsSQLCommond.ExecSqlTran(aList);
            //    MessageBox.Show("打开成功！\n合计执行语句:" + iCou + "条");
            //    SetTxtGridValue(txtCode.Text.Trim());
            //}
        }
        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose()
        {
            DialogResult d = MessageBox.Show("确定关闭选中的 " + txtCode.Text + " 么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (d != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            aList = new System.Collections.ArrayList();

            sSQL = " update 生产计划明细 set 关闭人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',关闭日期 = getdate()  " +
                   " where 表头单据号 = '" + txtCode.Text.Trim() + "' and 帐套号 = '200'";
            aList.Add(sSQL);


            if (aList.Count > 0)
            {
                int iCou = clsSQLCommond.ExecSqlTran(aList);
                MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");
                SetTxtGridValue(txtCode.Text.Trim());
            }

            //DialogResult d = MessageBox.Show("确定关闭选中的 " + gridView1.SelectedRowsCount + " 行么？\n是：继续\n否：取消", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            //if (d != System.Windows.Forms.DialogResult.Yes)
            //{
            //    return;
            //}

            //sSQL = "select * from dbo.生产计划明细 where 1 = -1";
            //DataTable dtDetail = clsSQLCommond.ExecQuery(sSQL);
            //aList = new System.Collections.ArrayList();
            //for (int i = gridView1.RowCount - 1; i >= 0; i--)
            //{
            //    if (gridView1.IsRowSelected(i))
            //    {
            //        sSQL = " update 生产计划明细 set 关闭人 = '" + FrameBaseFunction.ClsBaseDataInfo.sUserName + "',关闭日期 = '" + FrameBaseFunction.ClsBaseDataInfo.sLogDate + "' " +
            //               " where 表头单据号 = '" + txtCode.Text.Trim() + "' and 母件顺序 = " + gridView1.GetRowCellDisplayText(i, gridCol母件顺序) + "";
            //        aList.Add(sSQL);
            //    }
            //}

            //if (aList.Count > 0)
            //{
            //    int iCou = clsSQLCommond.ExecSqlTran(aList);
            //    MessageBox.Show("关闭成功！\n合计执行语句:" + iCou + "条");
            //    SetTxtGridValue(txtCode.Text.Trim());
            //    //GetGrid();
            //}
        }
        /// <summary>
        /// 变更
        /// </summary>
        private void btnAlter()
        {
            if (txtAudit.Text.Trim() == "")
            {
                throw new Exception("尚未审核，不能变更，请使用修改功能");
            }

            txt出货周.Enabled = true;

            gridView1.OptionsBehavior.Editable = true;
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].OptionsColumn.AllowEdit = false;
            }

            //gridCol物料编码.OptionsColumn.AllowEdit = true;
            gridCol制造令数量.OptionsColumn.AllowEdit = true;
            gridCol组别.OptionsColumn.AllowEdit = true;
            gridCol下道工序.OptionsColumn.AllowEdit = true;
            gridCol下一班组.OptionsColumn.AllowEdit = true;
            sState = "alter";
        }

        #endregion

        private void GetdtSel()
        {
            sSQL = "select 单据号 from 生产计划 where 帐套号 = '200' order by 单据号";
            dtSel = clsSQLCommond.ExecQuery(sSQL);

            if (dtSel != null && dtSel.Rows.Count > 0)
            {
                iPage = dtSel.Rows.Count - 1;
                string sCode = dtSel.Rows[iPage]["单据号"].ToString().Trim();
                SetTxtGridValue(sCode);
            }
            else
            {
                SetTxtGridNull();
            }
        }

        private void FrmWorkPlan_Load(object sender, EventArgs e)
        {
            try
            {
                GetLookUp();
                GetdtSel();
                dt_制造令跟产品();
            }
            catch (Exception ee)
            {
                MessageBox.Show("加载窗体失败\n" + ee.Message);
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == gridCol物料编码)
            {
                gridView1.SetRowCellValue(e.RowHandle, gridCol产品规格, gridView1.GetRowCellValue(e.RowHandle, gridCol物料编码));
                gridView1.SetRowCellValue(e.RowHandle, gridCol产品名称, gridView1.GetRowCellValue(e.RowHandle, gridCol物料编码));
            }

            if (e.Column == gridCol手工计划)
            {
                if (gridView1.GetRowCellValue(e.RowHandle, gridCol手工计划).ToString().Trim() == "1")
                {
                    gridCol制造令数量.OptionsColumn.AllowEdit = true;
                    gridCol制造令号码.OptionsColumn.AllowEdit = true;
                    gridView1.SetRowCellValue(e.RowHandle, gridCol制造令数量, gridView1.GetRowCellValue(e.RowHandle, gridCol订单需求量));
                }
                else if (gridView1.GetRowCellValue(e.RowHandle, gridCol手工计划).ToString().Trim() == "2")
                {
                    gridCol制造令数量.OptionsColumn.AllowEdit = true;
                    gridCol制造令号码.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridCol制造令数量.OptionsColumn.AllowEdit = false;
                    gridCol制造令号码.OptionsColumn.AllowEdit = false;
                }
            }

            if (gridCol制造令数量 == e.Column && ReturnObjectToInt( gridView1.GetRowCellValue(e.RowHandle,gridCol手工计划)) == 1)
            {
                gridView1.SetRowCellValue(e.RowHandle, gridCol订单数量, gridView1.GetRowCellValue(e.RowHandle, gridCol制造令数量));
                gridView1.SetRowCellValue(e.RowHandle, gridCol订单需求量, gridView1.GetRowCellValue(e.RowHandle, gridCol制造令数量));
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

        /// <summary>
        /// 获得LookUp
        /// </summary>
        private void GetLookUp()
        {
            string sSQL = "select iID,iText as State from dbo._LookUpDate where iType = '3' and isnull(bClose,1)=1 order by iID";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditState.DataSource = dt;

            sSQL = "select iID,iText from dbo._LookUpDate where iType = '6' and isnull(bClose,1)=1 order by iID";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit是否.DataSource = dt;


            sSQL = "select cInvCode,cInvName,cInvStd from @u8.Inventory order by cInvCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEditInventory.DataSource = dt;
            ItemLookUpEdit产品名称.DataSource = dt;
            ItemLookUpEdit产品规格.DataSource = dt;

            sSQL = "select MachineNO,Machine from dbo.Machine where State = 1 order by MachineNO";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit设备.DataSource = dt;

            sSQL = "select cDepCode,cDepName from @u8.Department order by cDepCode";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit班组.DataSource = dt;

            sSQL = "select WorkProcessNO,WorkProcess from dbo.WorkProcess where State = 1 order by WorkProcessNO";
            dt = clsSQLCommond.ExecQuery(sSQL);
            ItemLookUpEdit工序.DataSource = dt;
        }
        
        /// <summary>
        /// 建立U8与吕云系统的部门对应信息
        /// </summary>
        /// <param name="sDep"></param>
        /// <returns></returns>
        private string sDepInfo(string sDep)
        {
            string sDepU8Name = "";
            switch (sDep)
            {
                case "冲压组": sDepU8Name = "冲压"; break;
                case "焊接组": sDepU8Name = "电焊"; break;
                case "冲压": sDepU8Name = "冲压"; break;
                case "出冲压": sDepU8Name = "冲压"; break;
                case "电焊组": sDepU8Name = "电焊"; break;
                case "拉伸": sDepU8Name = ""; break;
                case "拉伸孔": sDepU8Name = ""; break;
                case "铝件组": sDepU8Name = "铝件"; break;
                case "品管部": sDepU8Name = "品检"; break;
                case "铁件组": sDepU8Name = "铁件组"; break;
                case "维护组": sDepU8Name = "维护组"; break;
                case "委外部": sDepU8Name = "委外部"; break;
                case "物控部": sDepU8Name = "委外部"; break;
                case "研发部": sDepU8Name = "研发"; break;
                case "组装": sDepU8Name = "组装"; break;
                case "组装组": sDepU8Name = "组装"; break;
                case "采购部": sDepU8Name = "采购"; break;
                case "生管部": sDepU8Name = "生管部"; break;
                case "销售/人事部": sDepU8Name = "人事"; break;
                case "财务部": sDepU8Name = "财务"; break;
                case "生产部": sDepU8Name = "生产"; break;
                case "裁切组": sDepU8Name = "裁切"; break;
                case "办公室": sDepU8Name = "人事"; break;

                default: sDepU8Name = sDep; break;
            }
            return sDepU8Name;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol制造令号码).ToString().Trim() == string.Empty && gridView1.GetRowCellDisplayText(e.RowHandle, gridCol手工计划).ToString().Trim() == "Y")
                {
                    e.Appearance.BackColor = Color.Tomato;
                }
                DateTime dToday = Convert.ToDateTime(gridView1.GetRowCellValue(e.RowHandle, gridCol日计划起));
                if (dToday < DateTime.Today)
                {
                    e.Appearance.BackColor = Color.Tomato;
                }


                if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol组别).ToString().Trim() == "委外部")
                {
                    e.Appearance.BackColor = Color.Cyan;
                }
                if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol工序).ToString().Trim() == "缴库")
                {
                    e.Appearance.BackColor = Color.Cyan;
                }

                if (gridView1.GetRowCellDisplayText(e.RowHandle, gridCol关闭人).ToString().Trim() != string.Empty)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }

                DateTime d制造令完工日期 = ReturnObjectToDatetime(gridView1.GetRowCellValue(e.RowHandle, gridCol制造令完工日期));
                if (d制造令完工日期 > Convert.ToDateTime(DateTime.Now.ToString("yyyy") + "-01-01"))
                {
                    DateTime d日计划起 = ReturnObjectToDatetime(gridView1.GetRowCellValue(e.RowHandle, gridCol日计划起));

                    if (d日计划起 > d制造令完工日期)
                    {
                        e.Appearance.BackColor = Color.OrangeRed;
                    }
                }
            }
            catch { }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (txtQty.Text.Trim() == string.Empty)
            {
                return;
            }
            if (dtmPlan.DateTime < Convert.ToDateTime("2000-1-1") || dtmPlan.Text.Trim() == "")
            {
                return;
            }
            if (dtBingGrid == null || dtBingGrid.Rows.Count < 1)
            {
                return;
            }
            dtBingGrid = SetGridJS(dtBingGrid.Copy()).Copy();
            gridControl1.DataSource = dtBingGrid;
        }

        private void dtmPlan_Leave(object sender, EventArgs e)
        {
            if (txtQty.Text.Trim() == string.Empty)
            {
                return;
            }
            if (dtmPlan.DateTime < Convert.ToDateTime("2000-1-1") || dtmPlan.Text.Trim() == "")
            {
                return;
            }
            if (dtBingGrid == null || dtBingGrid.Rows.Count < 1)
            {
                return;
            }
            dtBingGrid = SetGridJS(dtBingGrid.Copy()).Copy();
            gridControl1.DataSource = dtBingGrid;
        }

        private void SetTxtGridValue(string sCode)
        {
            sSQL = "select * " +
                   "from 生产计划 a left join @u8.SO_SOMain b on a.销售订单号 = b.cSOCode left join @u8.SO_SODetails c on c.ID = b.ID and a.销售订单行号 = c.iRowNo " +
                   "where a.帐套号 = '200' and 单据号 = '" + sCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtCode.Text = dt.Rows[0]["单据号"].ToString().Trim();
                dtmDate.Text = dt.Rows[0]["单据日期"].ToString().Trim();
                txtSoCode.Text = dt.Rows[0]["销售订单号"].ToString().Trim();
                txtiRowNo.Text = dt.Rows[0]["销售订单行号"].ToString().Trim();

                txtProInvCode.Text = dt.Rows[0]["cInvCode"].ToString().Trim();
                txtProInvName.Text = dt.Rows[0]["cInvName"].ToString().Trim();
                txtQty.Text = dt.Rows[0]["iQuantity"].ToString().Trim();
                
                txtSoCodeW.Text = dt.Rows[0]["cItemCode"].ToString().Trim();
                txtSoCodeK.Text = dt.Rows[0]["cDefine2"].ToString().Trim();
                txtCusCode.Text = dt.Rows[0]["cCusName"].ToString().Trim();

                dtmC.Text = dt.Rows[0]["dPreDate"].ToString().Trim();
                dtmW.Text = dt.Rows[0]["dPreMoDate"].ToString().Trim();
                dtmG.Text = dt.Rows[0]["cDefine36"].ToString().Trim();
                dtmJ.Text = dt.Rows[0]["dPreMoDate"].ToString().Trim();
                dtmPlan.Text = dt.Rows[0]["dPreMoDate"].ToString().Trim();
                txt出货周.Text = dt.Rows[0]["出货周"].ToString().Trim();
                txtRemark.Text = dt.Rows[0]["备注"].ToString().Trim();


                txt手工计划ID.Text = dt.Rows[0]["手工计划ID"].ToString().Trim();

                txtCreater.Text = dt.Rows[0]["创建人"].ToString().Trim();
                dtmCreater.Text = dt.Rows[0]["创建日期"].ToString().Trim();

                if (dt.Rows[0]["审核人"].ToString().Trim() != "")
                {
                    txtAudit.Text = dt.Rows[0]["审核人"].ToString().Trim();
                    dtmAudit.Text = dt.Rows[0]["审核日期"].ToString().Trim();
                }
                else
                {
                    txtAudit.Text = "";
                    dtmAudit.Text = "";
                }

                int iRow = gridView1.FocusedRowHandle;

                //dtBingGrid = new DataTable();
                sSQL = "select * from dbo.生产计划明细 where 表头单据号 = '" + sCode + "'and 帐套号 = '200' order by 母件顺序,加工顺序";
                dtBingGrid = clsSQLCommond.ExecQuery(sSQL);

                gridControl1.DataSource = dtBingGrid;

                lPageInfo.Text = (iPage + 1).ToString() + "/" + dtSel.Rows.Count.ToString();

                SetEdit(false);
            }
        }

        private void SetEdit(bool b)
        {
            dtmPlan.Enabled = b;
            txtRemark.Enabled = b;
            gridView1.OptionsBehavior.Editable = b;
            txt出货周.Enabled = b;
        }

        private void SetTxtGridNull()
        {
            txtCode.Text = "";
            dtmDate.Text = "";
            txtSoCode.Text = "";
            txtiRowNo.Text = "";

            txtProInvCode.Text = "";
            txtProInvName.Text = "";
            txtQty.Text = "";

            txtSoCodeW.Text = "";
            txtSoCodeK.Text = "";
            txtCusCode.Text = "";
            txt手工计划ID.Text = "";

            dtmC.Text = "";
            dtmW.Text = "";
            dtmG.Text = "";
            dtmJ.Text = "";
            dtmPlan.Text = "";

            txtCreater.Text = "";
            dtmCreater.Text = "";

            txtAudit.Text = "";
            dtmAudit.Text = "";
            txt出货周.Text = "";

            txtRemark.Text = "";

            dtBingGrid = null;
            gridControl1.DataSource = dtBingGrid;

            lPageInfo.Text = "";
        }

        private void ItemButtonEdit公式_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int iFocRow = gridView1.FocusedRowHandle;
            string sText = gridView1.GetRowCellDisplayText(iFocRow, gridCol开工排序).ToString().Trim();
            int iRowMJ = Convert.ToInt32(gridView1.GetRowCellDisplayText(iFocRow, gridCol母件顺序));
            BasicInformation.FrmProProcess_Formula fFormula = new BasicInformation.FrmProProcess_Formula(sText, iRowMJ);
            fFormula.ShowDialog();
            gridView1.SetRowCellValue(iFocRow, gridCol开工排序, fFormula.richTextBox1.Text.Trim());
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle < 0)
                    return;

                if (gridView1.GetRowCellValue(e.FocusedRowHandle, gridCol手工计划).ToString().Trim() == "1" || gridView1.GetRowCellValue(e.FocusedRowHandle, gridCol手工计划).ToString().Trim() == "2")
                {
                    gridCol内部流转.OptionsColumn.AllowEdit = true;
                    gridCol结束时间.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    gridCol内部流转.OptionsColumn.AllowEdit = false;
                    gridCol结束时间.OptionsColumn.AllowEdit = false;
                }
            }
            catch { }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int iRow = gridView1.FocusedRowHandle;
                string sInvCode = "";

                if (iRow >= 0)
                {
                    sInvCode = gridView1.GetRowCellValue(iRow, gridCol物料编码).ToString().Trim();
                    if (sInvCode != string.Empty)
                    {
                        SaleOrder.Frm物料供需分析 fSel = new SaleOrder.Frm物料供需分析();
                        fSel.sInvCode = sInvCode;
                        fSel.sSaleOrder = txtSoCode.Text.Trim();
                        fSel.ShowDialog();
                    }
                }
            }
            catch { }


            //双击在主窗体打开界面
            //SaleOrder.Frm订单评审_采购 f = new SaleOrder.Frm订单评审_采购();
            //f.MdiParent = base.MdiParent;
            //f.Tag = f.Name;
            //bool flag = false;
            //for (int i = 0; i < base.MdiParent.MdiChildren.Length; i++)
            //{
            //    if (base.MdiParent.MdiChildren[i].Name.ToString().ToLower() == f.Name.ToLower())
            //    {
            //        FrameBaseFunction.FrmBaseInfo frmBase = (FrameBaseFunction.FrmBaseInfo)base.MdiParent.MdiChildren[i];

            //        base.MdiParent.MdiChildren[i].Activate();

            //        flag = true;
            //        frmBase.ControlBox = false;
            //        break;
            //    }
            //}
            //if (!flag)
            //{
            //    f.Tag = f.Name;
            //    f.Text = f.Text.Substring(3);
            //    f.ControlBox = false;
            //    f.Show();
            //}
        }

        /// <summary>
        /// 计算第几周
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int ReturnWeekinYear(DateTime dt)
        {
            System.Globalization.GregorianCalendar gc = new System.Globalization.GregorianCalendar();

            //System.Globalization.ChineseLunisolarCalendar cg = new System.Globalization.ChineseLunisolarCalendar();

            return gc.GetWeekOfYear(dt, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            //int weekOfYear = 0;
            //if (DateTime.Now.DayOfYear % 7 > 0)
            //{
            //    weekOfYear = (DateTime.Now.DayOfYear - (DateTime.Now.DayOfYear % 7)) / 7 + 1;
            //}
            //else
            //{
            //    weekOfYear = DateTime.Now.DayOfYear / 7;
            //}
            //return weekOfYear;
        }

        DataTable dt制造令跟产品;
        private void dt_制造令跟产品()
        {
            string sSQL = "select * from dbo._LookUpDate where iType = '10'";
            dt制造令跟产品 = clsSQLCommond.ExecQuery(sSQL);
        }
    }
}
