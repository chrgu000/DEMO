using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace BarCode
{
    public partial class Frm缴库产品入库 : FrmBase
    {
        DataTable dtTable;

        public Frm缴库产品入库()
        {
            InitializeComponent();

            dtTable = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "序号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料名称";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "物料规格";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "本次入库数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "计划数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "工时";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "产品编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "计划日期";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "人员";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "设备";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "生产计划明细GUID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "生产订单号";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "工序编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "工序名称";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "下道工序编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "下道工序名称";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "部门";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "接受部门";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "预计计划数量";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "条形码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "GUID";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUsed";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "bUsed2";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "货位";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库编码";
            dtTable.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "仓库";
            dtTable.Columns.Add(dc);
            
            dataGrid1.DataSource = dtTable;
        }

        DataTable dt = new DataTable();

        private void 缴库产品入库_Load(object sender, EventArgs e)
        {
            date单据日期.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void txt条形码_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13 && txt条形码.Text.Trim() != "")
                {
                    //产成品没有货位
                    //if (txt货位.Text.Trim() == "")
                    //{
                    //    MessageBox.Show("请先扫描货位");
                    //    txt条形码.Text = "";
                    //    txt货位.Focus();
                    //    return;
                    //}

                    string[] s = txt条形码.Text.Trim().Split('-');
                    if (s.Length != 2)
                    {
                        throw new Exception("条形码错误");
                    }

                    string sErr = "";

                    //   isnull(w.iQuantity,0) - isnull(sum(wd.iQuantity),0)  as 本次入库数量
                    string sSQL = @"
select cast(null as int) as 序号,w.cInvCode as 物料编码,i.cInvName as 物料名称,i.cInvStd as 物料规格,dddddddd as 本次入库数量
    ,isnull(w.iQuantity,0) as 计划数量
    ,sum(isnull(wd.worktime,0)) as 工时,w.cinvcode2 as 产品编码 
    ,isnull(w.dtmPlan,'1900-1-1') as 计划日期,w.vchrPer as 人员,w.vchrEquipment as 设备  
    ,w.AutoID as 生产计划ID,WorkOrderNO as 生产订单号
    ,workProcedure as 工序编码,wp.fName as 工序名称,workProcedureNext as 下道工序编码 
    ,wp2.fName as 下道工序名称,w.workDepment as 部门,w.workDepmentNext as 接受部门,w.iQtyPlan as 预计计划数量 
    ,w.autoid as 条形码,w.GUID,null as 生产计划明细GUID,0 as bUsed,0 as bUsed2
    ,cast(null as varchar(50)) as 货位编码 ,cast(null as varchar(50)) as 货位,cast(null as varchar(50)) as 仓库编码,cast(null as varchar(50)) as 仓库 
from UFDLImport.dbo.WorkPlan w left join (select sum(iQuantity) as iQuantity,sum(worktime) as worktime,guidhead from UFDLImport.dbo.WorkPlanDetail group by guidhead) wd on w.Guid = wd.GuidHead left join @u8.Inventory i on i.cInvcode = w.cInvCode left join UFDLImport.dbo.WorkDepment wDep on wDep.FCode = w.workDepment
    left join UFDLImport.dbo.WorkingProcedure wp on wp.fCode = w.workProcedure left join UFDLImport.dbo.WorkingProcedure wp2 on wp2.fCode = w.workProcedureNext  
where 1=1 and isnull(bRDIn,0) <> 0 and w.autoid = cccccccc and w.AccID='aaaaaaaa' and w.AccYear = 'bbbbbbbb' and isnull(w.bClose,0) = 0 
group by w.cinvcode2,w.dtmPlan,w.GUID ,w.bRDIn,w.AutoID,WorkOrderID,WorkOrderNO,WorkOrderRowNO,w.cInvCode,i.cInvName,i.cInvStd
    ,w.iQuantity,w.iQtyPlan,workProcedure,wp.fName,workProcedureNext,wp2.fName,w.workDepment,wDep.fName,w.vchrPer,w.vchrEquipment,worktime,w.workDepmentNext
";
                    sSQL = sSQL.Replace("aaaaaaaa", MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(7, 3));
                    sSQL = sSQL.Replace("bbbbbbbb", MobileBaseDLL.ClsBaseDataInfo.sUFDataBaseName.Substring(11, 4));
                    sSQL = sSQL.Replace("cccccccc", s[0]);
                    sSQL = sSQL.Replace("dddddddd", s[1]);
                    DataTable dt = clsSQLCommond.ExecQuery(sSQL);

                    if (dt.Rows.Count != 1)
                    {
                        sErr = "没有符合的单据！";
                        dt = null;
                    }

                    if (sErr != string.Empty)
                    {
                        throw new Exception(sErr);
                    }

                    string s生产计划ID = dt.Rows[0]["条形码"].ToString().Trim();
                    for (int i = 0; i < dtTable.Rows.Count; i++)
                    {
                        string s生产计划ID2 = dtTable.Rows[i]["条形码"].ToString().Trim();

                        if (s生产计划ID == s生产计划ID2)
                        {
                            DialogResult d = MessageBox.Show("该条码已扫描，是否分货位继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            if (d != DialogResult.Yes)
                            {
                                throw new Exception("该条码已扫");
                            }

                            txt条数.Text = (MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text) + 1).ToString();
                        }
                    }

                    DataRow dr = dtTable.NewRow();
                    for (int i = 0; i < dtTable.Columns.Count; i++)
                    {
                        string sColName = dtTable.Columns[i].ToString().Trim();
                        dr[sColName] = dt.Rows[0][sColName];
                    }

                    if (txt货位.Text.Trim() != "")
                    {
                        string sInvCode = dt.Rows[0]["物料编码"].ToString().Trim();
                        string s货位 = clsDES.Decrypt(txt货位.Text.Trim());
                        int iCou = clsu8.Chk货位物料(s货位, sInvCode);
                        if (iCou <= 0)
                        {
                            DialogResult d = MessageBox.Show("物料、货位不对应，是否继续", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            if (d != DialogResult.Yes)
                            {
                                throw new Exception("物料货位不对应");
                            }
                        }

                        DataTable dt货位 = clsu8.Chk货位(s货位);
                        if (dt货位 == null || dt货位.Rows.Count < 1)
                        {
                            throw new Exception("货位信息失败");
                        }
                        if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
                        {
                            throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());
                        }

                        dr["货位编码"] = dt货位.Rows[0]["货位编码"].ToString().Trim();
                        dr["仓库编码"] = dt货位.Rows[0]["仓库编码"].ToString().Trim();
                        dr["货位"] = dt货位.Rows[0]["货位"].ToString().Trim();
                        dr["仓库"] = dt货位.Rows[0]["仓库"].ToString().Trim();
                    }
                    else
                    {
                        string sInvCode = dt.Rows[0]["物料编码"].ToString().Trim();
                        DataTable dt默认仓库 = clsu8.Get默认仓库(sInvCode);
                        if (MobileBaseDLL.ClsBaseDataInfo.ReturnInt(dt默认仓库.Rows[0]["是否货位管理"]) == 0)
                        {
                            dr["仓库编码"] = dt默认仓库.Rows[0]["仓库编码"].ToString().Trim();
                            dr["仓库"] = dt默认仓库.Rows[0]["仓库"].ToString().Trim();
                        }
                        else
                        {
                            throw new Exception("必须指定货位");
                        }
                    }
                    dr["序号"] = dtTable.Rows.Count + 1;
                    dtTable.Rows.Add(dr);

                    dataGrid1.DataSource = dtTable;

                    txt条形码.Text = "";
                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                txt条形码.Text = "";
                msgBox.textBox1.Text = "扫描失败:" + ee.Message;
                msgBox.ShowDialog();
            }
        }

       

        private void btn删行_Click(object sender, EventArgs e)
        {
            for (int i = dtTable.Rows.Count - 1; i >= 0; i--)
            {
                if (dataGrid1.IsSelected(i))
                    dtTable.Rows.RemoveAt(i);
            }
        }

        /// <summary>
        /// 获得单据ID
        /// </summary>
        /// <param name="sType">单据类型</param>
        private void GetID(string sType, out long iID, out long iIDDetail)
        {
            string sSQL = "select iFatherID,iChildID from UFSystem..UA_Identity where cAcc_Id = '200' and cVouchType = '" + sType + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);

            if (dt == null || dt.Rows.Count < 1)
            {
                iID = 0;
                iIDDetail = 0;
            }
            else
            {
                iID = Convert.ToInt64(dt.Rows[0]["iFatherID"]);
                iIDDetail = Convert.ToInt64(dt.Rows[0]["iChildID"]);
            }
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            try
            {
                string sInfo = "";
                int i1 = dtTable.Rows.Count;
                int i2 = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim());
                if (i1 != i2)
                {
                    throw new Exception("条形码数量不一致");
                }
                if (dtTable == null || dtTable.Rows.Count < 1)
                {
                    throw new Exception("请先扫条形码");
                }

                decimal d本次累计 = 0;
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    dtTable.Rows[i]["bUsed"] = 0;
                    dtTable.Rows[i]["bUsed2"] = 0;

                    d本次累计 = d本次累计 + MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[i]["本次入库数量"]);
                }

                DialogResult d = MessageBox.Show("本次入库数量：" + d本次累计.ToString(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (d != DialogResult.Yes)
                    return;

                string sSQL = "select getdate()";
                DateTime dtmNow = Convert.ToDateTime(clsSQLCommond.ExecGetScalar(sSQL));

                ArrayList aList产品入库单据号id = new ArrayList();
                ArrayList aList材料出库单据号id = new ArrayList();
                ArrayList aList = new ArrayList();
                long iRdID = 0;
                long iRdIDDetail = 0;
                long iRdInCode = 0;
                long iRdOutCode = 0;

                sSQL = "select max(id) as id,max(autoid) as autoid from @u8.Rdrecords10";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                if (dt != null && dt.Rows.Count > 0)
                {
                    iRdID = Convert.ToInt64(dt.Rows[0][0]);
                    iRdIDDetail = Convert.ToInt64(dt.Rows[0][1]);
                }

                sSQL = @"
declare @p5 int
set @p5=aaaaaaaa
declare @p6 int
set @p6=bbbbbbbb
exec @u8.sp_GetId N'',N'200',N'rd',1,@p5 output,@p6 output,default
select @p5, @p6
";
                sSQL = sSQL.Replace("aaaaaaaa", iRdID.ToString());
                sSQL = sSQL.Replace("bbbbbbbb", iRdIDDetail.ToString());
                dt = clsSQLCommond.ExecQuery(sSQL);

                if (dt != null && dt.Rows.Count>0)
                {
                    iRdID = Convert.ToInt64(dt.Rows[0][0]);
                    iRdIDDetail = Convert.ToInt64(dt.Rows[0][1]);
                }

                //产成品入库单号
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0411'  and (cSeed = '" + date单据日期.Value.ToString("yyMM") + "' or cSeed = '" + date单据日期.Value.ToString("yyyyMM") + "')";
                DataTable dtCode = clsSQLCommond.ExecQuery(sSQL);
                iRdInCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);
                //材料出库单号
                sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412'  and (cSeed = '" + date单据日期.Value.ToString("yyMM") + "' or cSeed = '" + date单据日期.Value.ToString("yyyyMM") + "')";
                dtCode = clsSQLCommond.ExecQuery(sSQL);
                iRdOutCode = Convert.ToInt64(dtCode.Rows[0]["Maxnumber"]);

                string sErr = "";
                for (int i = 0; i < dtTable.Rows.Count; i++)
                {
                    if (dtTable.Rows[i]["人员"].ToString().Trim() == string.Empty)
                    {
                        sErr = sErr + "行 " + (i + 1) + " 员工信息不能为空！\r\n";
                    }
                    if (dtTable.Rows[i]["接受部门"].ToString().Trim() == string.Empty)
                    {
                        sErr = sErr + "行 " + (i + 1) + " 接受班组不能为空！\r\n";
                    }
                    if (dtTable.Rows[i]["接受部门"].ToString().Trim() == dtTable.Rows[i]["部门"].ToString().Trim())
                    {
                        sErr = sErr + "行 " + (i + 1) + " 班组不能与接受班组一致！\r\n";
                    }
                    if (dtTable.Rows[i]["本次入库数量"].ToString().Trim() == "")
                    {
                        sErr = sErr + "行 " + (i + 1) + " 本次数量不能为空！\r\n";
                    }
                    if (Convert.ToDecimal(dtTable.Rows[i]["本次入库数量"]) <= 0)
                    {
                        sErr = sErr + "行 " + (i + 1) + " 本次数量必须为正数！\r\n";
                    }
                    if (dtTable.Rows[i]["工时"].ToString().Trim() == "")
                    {
                        sErr = sErr + "行 " + (i + 1) + " 工时必须要填写！\r\n";
                    }

                    string sGuid = Guid.NewGuid().ToString().Trim();
                    sSQL = "insert into UFDLImport.dbo.WorkPlanDetail(WorkDep,iQuantity,GUIDHead,[GUID],dtmDay,vchruid,vchrPer,vchrFacility,workTime)values " +
                            "('" + dtTable.Rows[i]["接受部门"].ToString().Trim() + "'," + dtTable.Rows[i]["本次入库数量"].ToString().Trim() + ",'" + dtTable.Rows[i]["GUID"].ToString().Trim() + "','" + sGuid + "','" + date单据日期.Value.ToString("yyyy-MM-dd") + "','" + MobileBaseDLL.ClsBaseDataInfo.sUid + "','" + dtTable.Rows[i]["人员"].ToString().Trim() + "','" + dtTable.Rows[i]["设备"].ToString().Trim() + "'," + dtTable.Rows[i]["工时"].ToString().Trim() + ")";
                    aList.Add(sSQL);

                    //获得生产订单表头信息，并根据日期排序
                    sSQL = @"
select a.MoId,a.MoCode,b.WhCode as WorkWhCode,b.MoDId,b.SortSeq,b.InvCode as cInvCode,b.Qty,isnull(b.QualifiedInQty,0) as QualifiedInQty,b.AuxQty as MDAuxQty,b.ChangeRate as MDChangeRate,b.AuxUnitCode as MDAuxUnitCode,
    cast(null as decimal(16,6)) as QtyNow,isnull(g.fInExcess,0) as fInExcess,b.MDeptCode,b.WIPType, 
    b.CostItemCode,b.CostItemName,b.SoCode,b.SoDId,b.SoSeq 
from @u8.mom_order a inner join @u8.mom_orderdetail b on b.MoId = a.MoId 
	inner join @u8.mom_morder c on c.MoDId= b.MoDId 
	left join (select distinct WorkOrderNo,cInvCode,max(dtmPlan)as dtmPlan from UFDLImport.dbo.WorkPlan group by WorkOrderNo,cInvCode) e on e.WorkOrderNo = a.MoCode and e.cInvCode = b.InvCode 
    left join @u8.Inventory g on g.cInvCode = b.InvCode 
where b.Status = 3 and a.MoCode = 'aaaaaaaa' 
order by e.dtmPlan,c.StartDate,a.CreateDate 
";
                    sSQL = sSQL.Replace("aaaaaaaa", dtTable.Rows[i]["生产订单号"].ToString().Trim());
                    DataTable dtWorkOrder = clsSQLCommond.ExecQuery(sSQL);
                    //获得生产订单明细信息，并根据日期排序
                    sSQL = @"
select a.MoId,a.MoCode,b.WhCode as WorkWhCode,b.MoDId,b.SortSeq,b.InvCode as cInvCode,b.Qty,isnull(b.QualifiedInQty,0) as QualifiedInQty,b.AuxQty as MDAuxQty,b.ChangeRate as MDChangeRate,b.AuxUnitCode as MDAuxUnitCode,
    cast(null as decimal(16,6)) as QtyNow,isnull(g.fInExcess,0) as fInExcess,b.MDeptCode,d.WIPType, 
    b.CostItemCode,b.CostItemName,b.SoCode,b.SoDId,b.SoSeq,d.AllocateId,d.InvCode,h.cInvName as InvName,isnull(d.TransQty,0) as TransQty,f.WIPType as bomWIPType, 
    h.cDefWareHouse as cDefWHCode,isnull(i.iQuantity,0) as iCurrQty,isnull(i.iNum,0) as iCurrNum,isnull(j.iQuantity,0) as i01CurrQty,isnull(j.iNum,0) as i01CurrNum,d.qty/b.qty as useQty,d.ChangeRate,d.AuxUnitCode,d.OpSeq,isnull(d.IssQty,0) as IssQty,isnull(h.cInvDefine12,0) as cInvDefine12 
from @u8.mom_order a inner join @u8.mom_orderdetail b on b.MoId = a.MoId 
    inner join @u8.mom_morder c on c.MoDId= b.MoDId 
    inner join @u8.mom_moallocate d on d.MoDId = b.MoDId 
    left join (select distinct WorkOrderNo,cInvCode,max(dtmPlan)as dtmPlan from UFDLImport.dbo.WorkPlan group by WorkOrderNo,cInvCode) e on e.WorkOrderNo = a.MoCode and e.cInvCode = b.InvCode 
    left join @u8.bom_opcomponentopt f on f.OptionsId = d.OpComponentId 
    left join @u8.Inventory g on g.cInvCode = b.InvCode 
    left join @u8.Inventory h on h.cInvCode = d.InvCode 
    left join (select cWhCode,cInvCode,isnull(sum(iQuantity),0) as iQuantity,isnull(sum(iNum),0) as iNum from @u8.CurrentStock group by cWhCode,cInvCode) i on i.cWhCode = '0F' and i.cInvCode = d.InvCode 
    left join (select cWhCode,cInvCode,isnull(sum(iQuantity),0) as iQuantity,isnull(sum(iNum),0) as iNum from @u8.CurrentStock group by cWhCode,cInvCode) j on j.cWhCode = '01' and j.cInvCode = d.InvCode 
where b.Status = 3 and a.MoCode = 'aaaaaaaa' 
order by e.dtmPlan,c.StartDate,a.CreateDate 
";
                    sSQL = sSQL.Replace("aaaaaaaa", dtTable.Rows[i]["生产订单号"].ToString().Trim());
                    DataTable dtWorkOrderDetail = clsSQLCommond.ExecQuery(sSQL);

                    string sWorkOrder = dtTable.Rows[i]["生产订单号"].ToString().Trim();                    //生产订单号
                    string scInvCode = dtTable.Rows[i]["物料编码"].ToString().Trim();                       //订单物料编码
                    decimal dQtyNow = Convert.ToDecimal(dtTable.Rows[i]["本次入库数量"]);                       //本次入库数量

                    DataRow[] drWorkOrder = dtWorkOrder.Select(" MoCode = '" + sWorkOrder + "' and cInvCode = '" + scInvCode + "' ");
                    if (drWorkOrder.Length < 1)
                    {
                        sErr = sErr + " 行 " + (i + 1) + " 没有对应生产订单，请核实后入库！\r\n";
                        continue;
                    }
                    string sWorkDep = drWorkOrder[0]["MDeptCode"].ToString().Trim();                                         //部门
                    string sWorkWhCode = drWorkOrder[0]["WorkWhCode"].ToString().Trim();                                     //生产入库仓库

                    if (sWorkDep == string.Empty)
                    {
                        sSQL = "select * from @u8.Department where cDepName like '%" + dtTable.Rows[i]["部门"].ToString().Trim() + "%'";
                        DataTable dtDep = clsSQLCommond.ExecQuery(sSQL);
                        if (dtDep != null && dtDep.Rows.Count > 0)
                        {
                            sWorkDep = dtDep.Rows[0]["cDepCode"].ToString().Trim();
                        }
                        else
                        {
                            MessageBox.Show("U8系统中没有部门:" + dtTable.Rows[i]["部门"].ToString().Trim() + " 请核实后继续");
                            return;
                        }
                    }

                    //#region 生成产成品入库单，材料出库单，调拨单

                    //产成品入库单表头
                    iRdID += 1;
                    iRdInCode += 1;
                    string sRdInCode = sSetRdInCode(iRdInCode);
                    sSQL = " update UFDLImport.dbo.WorkPlanDetail set RDInCode = '" + sRdInCode + "',AuditUid = '" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "',AuditDate = '" + date单据日期.Value.ToString("yyyy-MM-dd") + "' where guid = '" + sGuid + "'";
                    aList.Add(sSQL);

                    long i生产入库单表头id = iRdID;

                    Model.rdrecord10 Modelrd10 = new BarCode.Model.rdrecord10();
                    Modelrd10.ID = i生产入库单表头id;
                    Modelrd10.bRdFlag = 1;
                    Modelrd10.cVouchType = "10";
                    Modelrd10.cBusType = "成品入库";
                    Modelrd10.cSource = "生产订单";
                    Modelrd10.cWhCode = sWorkWhCode;
                    Modelrd10.dDate = Convert.ToDateTime(date单据日期.Value.ToString("yyyy-MM-dd"));
                    Modelrd10.cCode = sRdInCode;
                    Modelrd10.cRdCode = "104";
                    Modelrd10.cDepCode = sWorkDep;
                    Modelrd10.bTransFlag = false;
                    Modelrd10.cMaker = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                    Modelrd10.cDefine7 = 0;
                    Modelrd10.bpufirst = false;
                    Modelrd10.biafirst = false;
                    Modelrd10.VT_ID = 63;
                    Modelrd10.bIsSTQc = false;
                    Modelrd10.cDefine11 = drWorkOrder[0]["SoCode"].ToString().Trim();
                    Modelrd10.cMPoCode = sWorkOrder;
                    //Modelrd10.ipurorderid
                    Modelrd10.bFromPreYear = false;
                    Modelrd10.bIsComplement = 0;
                    Modelrd10.iDiscountTaxType = 0;
                    Modelrd10.ireturncount = 0;
                    Modelrd10.iverifystate = 0;
                    Modelrd10.iswfcontrolled = 0;
                    Modelrd10.dnmaketime = dtmNow;
                    Modelrd10.bredvouch = 0;
                    Modelrd10.iPrintCount = 0;
                    DAL.rdrecord10 DalRD10 = new BarCode.DAL.rdrecord10();
                    sSQL = DalRD10.Add(Modelrd10);
                    aList.Add(sSQL);

                    aList产品入库单据号id.Add(i生产入库单表头id);

                    //sSQL = "insert into @u8.rdrecord(id,brdflag,cvouchtype,cbustype,csource,cwhcode,ddate," +
                    //         "ccode,crdcode,cdepcode,cmaker,vt_id," +
                    //         "cdefine11,cmpocode,iswfcontrolled,dnmaketime,cpspcode) values " +
                    //     "(" + i生产入库单表头id + ",1,N'10',N'成品入库',N'生产订单',N'" + sWorkWhCode + "',N'" + date单据日期.Value.ToString("yyyy-MM-dd") + "'" +
                    //         ",N'" + sRdInCode + "',N'104',N'" + sWorkDep + "',N'" + MobileBaseDLL.ClsBaseDataInfo.sUserName + "',63," +
                    //         "N'" + drWorkOrder[0]["SoCode"] + "',N'" + sWorkOrder + "',0,  getdate(),'" + scInvCode + "')";
                    //aList.Add(sSQL);
                    sInfo = sInfo + " 生成产成品入库单 " + sRdInCode + "\r\n";


                    //产成品入库单表体
                    decimal dQty = 0;                                   //订单数量
                    decimal dQualifiedInQty = 0;                        //订单已入库数量
                    decimal dNeedQty = 0;                               //订单未入库数量
                    decimal dfInExcess = 0;                             //允许超订单百分比
                    for (int j = 0; j < drWorkOrder.Length; j++)
                    {
                        dQty = dQty + Convert.ToDecimal(drWorkOrder[j]["Qty"]);
                        dQualifiedInQty = dQualifiedInQty + Convert.ToDecimal(drWorkOrder[j]["QualifiedInQty"]);
                        dfInExcess = Convert.ToDecimal(drWorkOrder[j]["fInExcess"]);
                    }
                    dNeedQty = dQty - dQualifiedInQty;
                    if (dQty * (1 + dfInExcess) < dQualifiedInQty + dQtyNow)
                    {
                        sErr = sErr + " 行 " + (i + 1) + " 超订单，不能入库，请核实后继续";
                        continue;
                    }
                    else
                    {
                        decimal dQtyNowRow = 0;                        //本次本行入库数量
                        decimal dNumNowRow = 0;                        //本次本行入库件数
                        bool bCloseWork = false;                       //是否关闭订单
                        for (int j = 0; j < drWorkOrder.Length; j++)
                        {
                            dQty = Convert.ToDecimal(drWorkOrder[j]["Qty"]);
                            dQualifiedInQty = Convert.ToDecimal(drWorkOrder[j]["QualifiedInQty"]);
                            dNeedQty = dQty - dQualifiedInQty;
                            dfInExcess = Convert.ToDecimal(drWorkOrder[j]["fInExcess"]);
                            if (dQtyNow <= 0)
                            {
                                continue;
                            }
                            if (dNeedQty >= dQtyNow)
                            {
                                dQtyNowRow = dQtyNow;
                                dQtyNow = 0;
                                if (dNeedQty > dQtyNow)
                                {
                                    bCloseWork = false;
                                }
                                else
                                {
                                    bCloseWork = true;
                                }
                            }
                            else
                            {
                                if (j == drWorkOrder.Length - 1)
                                {
                                    dQtyNowRow = dQtyNow;
                                    dQtyNow = 0;
                                    bCloseWork = true;
                                }
                                else
                                {
                                    dQtyNowRow = dNeedQty;
                                    dQtyNow = dQtyNow - dNeedQty;
                                    bCloseWork = true;
                                }
                            }

                            iRdIDDetail += 1;
                            Model.rdrecords10 Modelrds10 = new BarCode.Model.rdrecords10();
                            Modelrds10.AutoID = iRdIDDetail;
                            Modelrds10.ID = i生产入库单表头id;
                            Modelrds10.cInvCode = scInvCode;
                            //Modelrds10.iNum = 
                            Modelrds10.iQuantity = dQtyNowRow;
                            Modelrds10.iFlag = 0;
                            //Modelrds10.cPosition = 
                            Modelrds10.cDefine22 = drWorkOrder[j]["SoCode"].ToString().Trim();
                            Modelrds10.cDefine24 = dtTable.Rows[i]["下道工序编码"].ToString().Trim();
                            Modelrds10.iNQuantity = 0;
                            Modelrds10.iMPoIds = RetrunLong(drWorkOrder[j]["MoDId"]);
                            Modelrds10.bRelated = false;
                            Modelrds10.bLPUseFree = false;
                            Modelrds10.iRSRowNO = 0;
                            Modelrds10.iOriTrackID = 0;
                            Modelrds10.bCosting = true;
                            Modelrds10.bVMIUsed = false;
                            Modelrds10.cmocode = drWorkOrder[j]["MoCode"].ToString().Trim();
                            Modelrds10.imoseq = RetrunInt(drWorkOrder[j]["SortSeq"]);
                            Modelrds10.iExpiratDateCalcu = 0;
                            Modelrds10.iorderdid = RetrunInt(drWorkOrder[j]["MoDId"]);
                            Modelrds10.iordertype = 1;
                            Modelrds10.iordercode = drWorkOrder[j]["SoCode"].ToString().Trim();
                            Modelrds10.iorderseq = RetrunInt(drWorkOrder[j]["SoSeq"]);
                            Modelrds10.isodid = drWorkOrder[j]["SoDId"].ToString().Trim();
                            Modelrds10.isotype = 1;
                            Modelrds10.csocode = drWorkOrder[j]["SoCode"].ToString().Trim();
                            Modelrds10.isoseq = RetrunInt(drWorkOrder[j]["SoSeq"]);
                            Modelrds10.irowno = j + 1;
                            //Modelrds10.iposflag 
                            DAL.rdrecords10 DalRDs10 = new BarCode.DAL.rdrecords10();
                            sSQL = DalRDs10.Add(Modelrds10);
                            aList.Add(sSQL);

                            //sSQL = "Insert Into @u8.rdrecords(autoid,id,cinvcode,iquantity," +
                            //          "impoids,brelated,iordertype," +
                            //          "bcosting,iordercode,corufts,cmocode," +
                            //          "imoseq,isodid,isotype,csocode,isoseq,inquantity,cdefine24) " +
                            //      "Values (" + iRdIDDetail + "," + i生产入库单表头id + ",N'" + scInvCode + "'," + dQtyNowRow + "," +
                            //          "" + drWorkOrder[j]["MoDId"] + ",0,1," +
                            //          "1,N'" + drWorkOrder[j]["SoCode"] + "',N'1653.4411',N'" + drWorkOrder[j]["MoCode"] + "'," +
                            //          "" + drWorkOrder[j]["SortSeq"] + ",N'" + drWorkOrder[j]["SoDId"] + "',1,N'" + drWorkOrder[j]["SoCode"] + "','" + drWorkOrder[j]["SoSeq"] + "'," + sNQty + ",'" + dtTable.Rows[i]["下道工序编码"].ToString().Trim() + "')";
                            //aList.Add(sSQL);

                            drWorkOrder[j]["QualifiedInQty"] = Convert.ToDecimal(drWorkOrder[j]["QualifiedInQty"]) + dQtyNowRow;

                            sSQL = @"
update  @u8.rdrecords10 
    set iNum = cast((iQuantity/mD.Qty*AuxQty) as decimal(18, 6))
        ,cAssUnit=i.cAssComUnitCode ,iinvexchrate=cast((mD.Qty/AuxQty) as decimal(18, 6))
        ,iExpiratDateCalcu=0
        ,iNNum=cast((inQuantity/mD.Qty*AuxQty) as decimal(18, 6))
from  @u8.mom_orderdetail mD inner join  @u8.Inventory I on md.invcode = i.cInvCode 
where mD.MoDId = iMPoIds and  autoid = " + iRdIDDetail;
                            aList.Add(sSQL);

                            
                                Model.InvPosition modelInvPos = new BarCode.Model.InvPosition();

                            sSQL = "select isnull(bWhPos,0) as bWhPos from @u8.Warehouse  where cWhCode = '" + sWorkWhCode + "'";
                            DataTable dtWhPos = clsSQLCommond.ExecQuery(sSQL);
                            if (dtWhPos != null && Convert.ToBoolean(dtWhPos.Rows[0]["bWhPos"]))
                            {
                                sSQL = "select * from @u8.Inventory  where cInvCode = '" + scInvCode + "'";
                                DataTable dtInv = clsSQLCommond.ExecQuery(sSQL);

                                string s辅计量编码 = "null";
                                if (dtInv.Rows[0]["cAssComUnitCode"].ToString().Trim() != "")
                                {
                                    s辅计量编码 = dtInv.Rows[0]["cAssComUnitCode"].ToString().Trim();
                                    modelInvPos.cAssUnit = s辅计量编码;

                                    sSQL = @"select iNum from  @u8.rdrecords10  where autoid = " + iRdIDDetail;
                                    DataTable dtiNum = clsSQLCommond.ExecQuery(sSQL);

                                    modelInvPos.iNum = ReturnDecimal(dtiNum.Rows[0]["iNum"]);
                                }

                                modelInvPos.RdsID = iRdIDDetail;
                                modelInvPos.RdID = i生产入库单表头id;
                                modelInvPos.cWhCode = sWorkWhCode;
                                modelInvPos.cPosCode = dtTable.Rows[i]["货位编码"].ToString().Trim();
                                modelInvPos.cInvCode = scInvCode;
                                modelInvPos.iQuantity = dQtyNowRow;
                                //model.iNum = d货位件数;
                                modelInvPos.cHandler = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                                modelInvPos.dDate = MobileBaseDLL.ClsBaseDataInfo.ReturnDate(date单据日期.Value.ToString("yyyy-MM-dd"));
                                modelInvPos.bRdFlag = 1;
                                modelInvPos.iTrackId = 0;
                                modelInvPos.iExpiratDateCalcu = 0;
                                modelInvPos.cvouchtype = "10";
                                modelInvPos.dVouchDate = MobileBaseDLL.ClsBaseDataInfo.ReturnDate(date单据日期.Value.ToString("yyyy-MM-dd"));

                                DAL.InvPosition dalInvPos = new BarCode.DAL.InvPosition();
                                sSQL = dalInvPos.Add(modelInvPos);
                                aList.Add(sSQL);

                                sSQL = @"
if exists (select * from @u8.InvPositionSum where  cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb')
    update @u8.InvPositionSum set iQuantity = isnull(iQuantity,0) + dddddddddd,iNum = isnull(iNum,0) + eeeeeeeeee where cInvCode = 'aaaaaaaaaa' and cWhCode = 'cccccccccc' and cPosCode = 'bbbbbbbbbb'
else
    insert into @u8.InvPositionSum(cInvCode,cWhCode,cPosCode,iQuantity,iNum)
    values('aaaaaaaaaa','cccccccccc','bbbbbbbbbb',dddddddddd,eeeeeeeeee)
";
                                sSQL = sSQL.Replace("aaaaaaaaaa", modelInvPos.cInvCode);
                                sSQL = sSQL.Replace("bbbbbbbbbb", modelInvPos.cPosCode);
                                sSQL = sSQL.Replace("cccccccccc", modelInvPos.cWhCode);
                                sSQL = sSQL.Replace("dddddddddd", modelInvPos.iQuantity.ToString());

                                if (modelInvPos.iNum == 0 || modelInvPos.iNum == null)
                                {
                                    sSQL = sSQL.Replace("eeeeeeeeee", "Null");
                                }
                                else
                                {
                                    sSQL = sSQL.Replace("eeeeeeeeee", modelInvPos.iNum.ToString());
                                }
                                aList.Add(sSQL);
                            }

                            //更新现存量
                            sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + scInvCode + "' and cWhCode = '" + sWorkWhCode + "') " +
                                   "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + dQtyNowRow + "  where cInvCode = '" + scInvCode + "' and cWhCode = '" + sWorkWhCode + "' " +
                                   "else " +
                                       "begin " +
                                           "declare @itemid varchar(20); " +
                                           "declare @iCount int;  " +
                                           "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + scInvCode + "';   " +
                                           "if( @iCount > 0 ) " +
                                           "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + scInvCode + "';  " +
                                           "else  " +
                                           "	select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                           "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,itemid)values('" + sWorkWhCode + "','" + scInvCode + "'," + dQtyNowRow + ",@itemid) " +
                                       "end";
                            aList.Add(sSQL);

                            //1. 修改生产订单入库数据   
                            sSQL = "update @u8.mom_orderdetail  set QualifiedInQty = isnull(QualifiedInQty,0) + " + dQtyNowRow + " where MoDId = " + drWorkOrder[j]["MoDId"];
                            aList.Add(sSQL);

                            if (bCloseWork)
                            {
                                //2. 单据已经完全入库，关闭订单
                                sSQL = "update @u8.mom_orderdetail set Status = 4,CloseTime = '" + date单据日期.Value.ToString("yyyy-MM-dd") + "',CloseUser = '" + MobileBaseDLL.ClsBaseDataInfo.sUid + "',OrgClsTime = '" + date单据日期.Value.ToString("yyyy-MM-dd") + "',CloseDate = '" + date单据日期.Value.ToString("yyyy-MM-dd") + "',OrgClsDate = '" + date单据日期.Value.ToString("yyyy-MM-dd") + "' " +
                                       "where modid = " + drWorkOrder[j]["MoDId"];
                                aList.Add(sSQL);
                            }


                            //#region 材料出库单，一行产品入库生成一张材料出库单（生产订单子件）
                            //材料出库，从现场仓出库，没有货位，需要判断现存量
                            //材料出库单表头
                            DataRow[] drWorkOrderDetail = dtWorkOrderDetail.Select(" MoDId = '" + drWorkOrder[j]["MoDId"] + "' and ((WIPType =5 and  (bomWIPType =1 or bomWIPType =2)) or WIPType =1 or WIPType =2)");
                            if (drWorkOrderDetail.Length <= 0)
                            {
                                continue;
                            }
                            iRdOutCode += 1;
                            string sRdOutCode = sSetRdOutCode(iRdOutCode);
                            sInfo = sInfo + "材料出库单:" + sRdOutCode + "\r\n\r\n";
                            iRdID += 1;

                            Model.rdrecord11 modelRd11 = new BarCode.Model.rdrecord11();
                            modelRd11.ID = iRdID;
                            modelRd11.bRdFlag = 0;
                            modelRd11.cVouchType = "11";
                            modelRd11.cBusType = "生产倒冲";
                            modelRd11.cSource = "产成品入库单";
                            modelRd11.cBusCode = sRdInCode;
                            modelRd11.cWhCode = "0F";
                            modelRd11.dDate = Convert.ToDateTime(date单据日期.Value.ToString("yyyy-MM-dd"));
                            modelRd11.cCode = sRdOutCode;
                            modelRd11.cRdCode = "201";
                            modelRd11.cDepCode = sWorkDep;
                            modelRd11.bTransFlag = false;
                            modelRd11.cMaker = MobileBaseDLL.ClsBaseDataInfo.sUserName;
                            modelRd11.cDefine7 = 0;
                            modelRd11.bpufirst = false;
                            modelRd11.biafirst = false;
                            modelRd11.VT_ID = 65;
                            modelRd11.bIsSTQc = false;
                            modelRd11.cPsPcode = scInvCode;
                            modelRd11.cMPoCode = sWorkOrder;
                            modelRd11.bFromPreYear = false;
                            modelRd11.iDiscountTaxType = 0;
                            modelRd11.ireturncount = 0;
                            modelRd11.iverifystate = 0;
                            modelRd11.iswfcontrolled = 0;
                            modelRd11.dnmaketime = dtmNow;
                            modelRd11.bredvouch = 0;
                            modelRd11.bmotran = 0;
                            modelRd11.iPrintCount = 0;
                            DAL.rdrecord11 DalRD11 = new BarCode.DAL.rdrecord11();
                            sSQL = DalRD11.Add(modelRd11);
                            aList.Add(sSQL);

                            aList材料出库单据号id.Add(iRdID);

                            sSQL = " update UFDLImport.dbo.WorkPlanDetail set RDOutCode = RDOutCode + '," + sRdOutCode + "' where guid = '" + sGuid + "'";
                            aList.Add(sSQL);

                            //材料出库单表体，根据产成品入库单的明细逐行展开材料出库单（生产订单子件）
                            //根据生产订单子件循环
                            for (int k = 0; k < drWorkOrderDetail.Length; k++)
                            {
                                bool bQtyOrNum = true;
                                try
                                {
                                    if (Convert.ToInt64(drWorkOrderDetail[k]["cInvDefine12"]) != 0)
                                    {
                                        bQtyOrNum = false;
                                    }
                                }
                                catch { }

                                decimal d1 = 0;     //数量
                                decimal d2 = 0;     //件数

                                d1 = dQtyNowRow * Convert.ToDecimal(drWorkOrderDetail[k]["useQty"]);        //材料出库数量=当前产成品入库单数量*使用数量
                                d1 = decimal.Round(d1, 6);
                                d2 = 0;
                                if (drWorkOrderDetail[k]["ChangeRate"] != null && drWorkOrderDetail[k]["ChangeRate"].ToString().Trim() != "")
                                {
                                    d2 = d1 / Convert.ToDecimal(drWorkOrderDetail[k]["ChangeRate"]);
                                    d2 = decimal.Round(d2, 6);
                                }

                                string sd2 = "";
                                if (d2 == 0)
                                {
                                    sd2 = "null";
                                }
                                else
                                {
                                    sd2 = d2.ToString();
                                }
                                iRdIDDetail += 1;
                                string sChangeRate = "null";
                                if (drWorkOrderDetail[k]["ChangeRate"].ToString().Trim() != "")
                                {
                                    sChangeRate = drWorkOrderDetail[k]["ChangeRate"].ToString().Trim();
                                }

                                Model.rdrecords11 modelRds11 = new BarCode.Model.rdrecords11();
                                modelRds11.AutoID = iRdIDDetail;
                                modelRds11.ID = iRdID;
                                modelRds11.cInvCode = drWorkOrderDetail[k]["InvCode"].ToString().Trim();
                                if (d2 != 0)
                                {
                                    modelRds11.iNum = d2;
                                }
                                modelRds11.iQuantity = d1;
                                modelRds11.iFlag = 0;
                                //modelRds11.cItem_class = "00";
                                //modelRds11.cItemCode = 
                                modelRds11.iMPoIds = RetrunLong(drWorkOrderDetail[k]["AllocateId"]);
                                modelRds11.bLPUseFree = false;
                                modelRds11.iOriTrackID = 0;
                                modelRds11.bCosting = true;
                                modelRds11.bVMIUsed = false;
                                modelRds11.cmocode = sWorkOrder;
                                modelRds11.invcode = scInvCode;
                                modelRds11.imoseq = RetrunInt(drWorkOrderDetail[k]["SortSeq"]);
                                modelRds11.iopseq = "0000";
                                modelRds11.iExpiratDateCalcu = 0;
                                modelRds11.iorderdid = RetrunInt(drWorkOrder[j]["MoDId"]);
                                modelRds11.iordertype = 1;
                                modelRds11.iordercode = drWorkOrder[j]["SoCode"].ToString().Trim();
                                modelRds11.iorderseq = RetrunInt(drWorkOrder[j]["SoSeq"]);
                                modelRds11.isotype = 0;
                                modelRds11.irowno = k + 1;
                                DAL.rdrecords11 DalRds11 = new BarCode.DAL.rdrecords11();
                                sSQL = DalRds11.Add(modelRds11);
                                aList.Add(sSQL);

                                drWorkOrderDetail[k]["iCurrQty"] = Convert.ToDecimal(drWorkOrderDetail[k]["iCurrQty"]) - d1;
                                if (sd2.ToLower() != "null" && drWorkOrderDetail[k]["iCurrNum"] != null && drWorkOrderDetail[k]["iCurrNum"].ToString().Trim() != "")
                                {
                                    drWorkOrderDetail[k]["iCurrNum"] = Convert.ToDecimal(drWorkOrderDetail[k]["iCurrNum"]) - d2;
                                }

                                //--更新现存量
                                sSQL = "if exists(select * from  @u8.CurrentStock where cInvCode = '" + drWorkOrderDetail[k]["InvCode"] + "' and cWhCode = '0F') " +
                                       "	update  @u8.CurrentStock set iQuantity = isnull(iQuantity,0) + " + d1 + ",iNum = isnull(iNum,0) + " + d2 + "  where cInvCode = '" + drWorkOrderDetail[k]["InvCode"] + "' and cWhCode = '0F' " +
                                       "else " +
                                           "begin " +
                                           "    declare @itemid varchar(20); " +
                                                 "declare @iCount int;  " +
                                                   "select @iCount=count(itemid) from @u8.CurrentStock where cInvCode = '" + drWorkOrderDetail[k]["InvCode"] + "';   " +
                                                   "if( @iCount > 0 ) " +
                                                   "	select @itemid=itemid from @u8.CurrentStock where cInvCode = '" + drWorkOrderDetail[k]["InvCode"] + "';  " +
                                                   "else  " +
                                                   "	 select @itemid=max(itemid+1) from @u8.CurrentStock  " +
                                                   "    insert into @u8.CurrentStock(cWhCode,cInvCode,iQuantity,iNum,itemid)values('0F','" + drWorkOrderDetail[k]["InvCode"] + "'," + d1 + "," + d2 + ",@itemid) " +
                                           "end";
                                aList.Add(sSQL);

                                //更新生产订单子件用量
                                sSQL = "update @u8.mom_moallocate set IssQty = IssQty + " + d1 + " where AllocateId = " + drWorkOrderDetail[k]["AllocateId"];
                                aList.Add(sSQL);

                            }
                        }
                    }
                }
                if (sErr.Length > 0)
                {
                    throw new Exception(sErr);
                }
                if (aList.Count > 0)
                {
                    if (iRdID > 1000000000)
                    {
                        iRdID = iRdID - 1000000000;
                        iRdIDDetail = iRdIDDetail - 1000000000;
                    }
                    sSQL = "update UFSystem..UA_Identity set iFatherID = " + iRdID + ",iChildID=" + iRdIDDetail + "  where cAcc_Id = '200' and cVouchType = 'rd'";
                    aList.Add(sSQL);

                    //更改材料出库单据号
                    sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0412'  and (cSeed = '" + date单据日期.Value.ToString("yyMM") + "' or cSeed = '" + date单据日期.Value.ToString("yyyyMM") + "')";
                    DataTable dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtCodeTemp.Rows[0]["Maxnumber"].ToString().Trim() == "0")
                    {
                        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0412','日期','月','" + date单据日期.Value.ToString("yyMM") + "','1',0)";
                    }
                    else
                    {
                        sSQL = "update @u8.VoucherHistory set cNumber = '" + iRdOutCode.ToString().Trim() + "' Where CardNumber='0412' and (cSeed='" + date单据日期.Value.ToString("yyyyMM") + "' or cSeed='" + date单据日期.Value.ToString("yyMM") + "')";
                    }
                    aList.Add(sSQL);

                    //更新产成品入库单最大单据号
                    sSQL = "select isnull(max(cNumber),0) as Maxnumber From @u8.VoucherHistory  with (NOLOCK) Where  CardNumber='0411'  and (cSeed = '" + date单据日期.Value.ToString("yyMM") + "' or cSeed = '" + date单据日期.Value.ToString("yyyyMM") + "')";
                    dtCodeTemp = clsSQLCommond.ExecQuery(sSQL);
                    if (dtCodeTemp.Rows[0]["Maxnumber"].ToString().Trim() == "0")
                    {
                        sSQL = "insert into @u8.VoucherHistory(cardnumber,ccontent,ccontentrule,cseed,cnumber,bempty)values('0411','日期','月','" + date单据日期.Value.ToString("yyMM") + "','1',0)";
                    }
                    else
                    {
                        sSQL = "update @u8.VoucherHistory set cNumber = '" + iRdInCode.ToString().Trim() + "' Where  CardNumber='0411' and cContent='日期' and cSeed='" + date单据日期.Value.ToString("yyMM") + "'  ";
                    }
                    aList.Add(sSQL);


                    if (aList产品入库单据号id.Count > 0)
                    {
                        for (int i = 0; i < aList产品入库单据号id.Count; i++)
                        {
                            sSQL = "exec @u8.IA_SP_WriteUnAccountVouchForST 'aaaaaaaa',N'10'";
                            sSQL = sSQL.Replace("aaaaaaaa", aList产品入库单据号id[i].ToString());
                            aList.Add(sSQL);
                        }
                    }
                    if (aList材料出库单据号id.Count > 0)
                    {
                        for (int i = 0; i < aList材料出库单据号id.Count; i++)
                        {
                            sSQL = "exec @u8.IA_SP_WriteUnAccountVouchForST 'aaaaaaaa',N'11'";
                            sSQL = sSQL.Replace("aaaaaaaa", aList材料出库单据号id[i].ToString());
                            aList.Add(sSQL);
                        }
                    }

                    clsSQLCommond.ExecSqlTran(aList);

                    dtTable.Clear();
                    txt货位.Text = "";
                    txt条数.Text = "";
                    txt条形码.Text = "";
                    txt条数.Focus();
                    msgBox.textBox1.Text = sInfo;
                    msgBox.WindowState = FormWindowState.Maximized;
                    msgBox.ShowDialog();
                }
            }
            catch (Exception ee)
            {
                msgBox.textBox1.Text = "保存失败:\r\n" + ee.Message;
                msgBox.ShowDialog();
            }
        }

        int iRow = -1;
        int iCol = -1;
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridCell editCell = dataGrid1.CurrentCell;
                Rectangle cellPos = new Rectangle();
                iRow = editCell.RowNumber;
                iCol = editCell.ColumnNumber;

                if (iCol == 4 || iCol == 5 )
                {
                    cellPos = dataGrid1.GetCellBounds(iRow, iCol);
                    txt编辑.Left = cellPos.Left;
                    txt编辑.Top = cellPos.Top + dataGrid1.Top;
                    txt编辑.Width = cellPos.Width;
                    txt编辑.Height = cellPos.Height;
                    txt编辑.Visible = true;
                    txt编辑.Text = dtTable.Rows[editCell.RowNumber][editCell.ColumnNumber].ToString().Trim();
                    txt编辑.Focus();
                }
                else
                {
                    txt编辑.Text = "";
                    txt编辑.Visible = false;
                    iRow = -1;
                    iCol = -1;
                }
            }
            catch
            {
                txt编辑.Text = "";
                txt编辑.Visible = false;
                iRow = -1;
                iCol = -1;
            }
        }

        private void txt编辑_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    txt编辑_LostFocus(null, null);
                }
            }
            catch
            { }
        }

        private void txt条形码_LostFocus(object sender, EventArgs e)
        {
            txt编辑.Text = "";
            txt编辑.Visible = false;
        }

        private void txt条数_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt条数.Text.Trim() == "")
                        return;

                    int iR = MobileBaseDLL.ClsBaseDataInfo.ReturnInt(txt条数.Text.Trim());
                    if (iR <= 0)
                    {
                        throw new Exception("条数必须大于0");
                    }
                    txt货位.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                if (txt条数.Text.Trim() != "")
                {
                    txt条数.Text = "";
                }
            }
        }

        private void txt货位_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    if (txt货位.Text.Trim() == "")
                    {
                        return;
                    }
                    string s货位 = clsDES.Decrypt(txt货位.Text.Trim());
                    DataTable dt货位 = clsu8.Chk货位(s货位);
                    if (dt货位 == null || dt货位.Rows.Count < 1)
                    {
                        throw new Exception("货位信息失败");
                    }
                    if (dt货位.Rows[0]["返回信息"].ToString().Trim() != "")
                    {
                        throw new Exception(dt货位.Rows[0]["返回信息"].ToString().Trim());
                    }

                    txt条形码.Focus();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("货物错误:" + ee.Message);
                if (txt货位.Text.Trim() != "")
                {
                    txt货位.Text = "";
                }
            }
        }

        private void txt编辑_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (iRow == -1 || iCol == -1)
                    return;

                if (iCol == 1)
                {
                    //判断货位
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }
                if (iCol == 4)
                {
                    decimal d数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(txt编辑.Text);
                    decimal d本次入库数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["本次入库数量"]);
                    decimal d单据数量 = MobileBaseDLL.ClsBaseDataInfo.ReturnDecimal(dtTable.Rows[iRow]["计划数量"]);
                    if (d数量 != d单据数量)
                    {
                        if (d数量 <= 0)
                        {
                            MessageBox.Show("待指定数量必须大于0");
                            return;
                        }
                    }
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }

                if (iCol == 5)
                {
                    dtTable.Rows[iRow][iCol] = txt编辑.Text.Trim();
                }

                iRow = -1;
                iCol = -1;
                txt编辑.Visible = false;
                txt编辑.Text = "";
            }
            catch
            { }
        }


        /// <summary>
        /// 返回入库单单据号
        /// </summary>
        /// <param name="sCode"></param>
        /// <returns></returns>
        private string sSetRdInCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 4; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }

            return "CP" + date单据日期.Value.ToString("yyMM") + sCode;
        }

        /// <summary>
        /// 返回材料出库单单据号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string sSetRdOutCode(long s)
        {
            string sCode = s.ToString().Trim();
            for (int i = 0; i < 10; i++)
            {
                if (sCode.Length < 4)
                {
                    sCode = "0" + sCode;
                }
                else
                {
                    break;
                }
            }
            return "OP" + date单据日期.Value.ToString("yyMM") + sCode;
        }

        private void msgBox_Load(object sender, EventArgs e)
        {

        }
    }
}