using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using UFIDA.U8.UAP.CustomApp.MetaData;
using TH.BaseClass;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.Business
{
    public class Sa_CertificateBLL
    {
        private static string _dataSourceStr = @"select * from (
select 1 as flag,cast(0 as bit) as ischk,convert(nvarchar,SaleBillVouchZT.SBVID)  as  主键,	'记帐凭证' as 凭证类别,	DATENAME(mm,dverifydate) as 期间,1 as	凭证号,	convert(varchar(10),dDate ,120)  as 制单日期,cMaker as	制单人,	convert(varchar(10),dverifydate,120)  as 审核日期,
    ''  as	审核人,	null 签字日期,	null as 出纳,null as	附单据数,null  as 分录号,	
    case when _LookUpDate.Remark is not null and _LookUpDate.Remark<>'' then _LookUpDate.Remark else  SaleBillVouchZT.cstname end as 摘要,case when _LookUpDate.iID is null or _LookUpDate.iID='' then '112201' else _LookUpDate.iID end as 会计科目,	null 结算方式,cSBVCode as	销售发票号,	convert(varchar(10),dDate,120) as 票据日期,	cexch_name as 币种,iexchrate as 汇率,
    sum(iSum) as 借方原币金额,sum(iNatSum) as	借方本币金额,	
    null as 贷方原币金额,null as 贷方本币金额,	
    null as 借方数量,null as 贷方数量,null as 单价,
    case when cInvalider is null or cInvalider='' then '' else '已作废' end as	作废标志   ,cpersoncode as 业务员,null as 物料,ccuscode as 客户,cdepcode as 部门 
from SaleBillVouchZT inner join SaleBillVouchZW on SaleBillVouchZT.sbvid=SaleBillVouchZW.sbvid 
    left join (select * from _LookUpDate where iType=1) _LookUpDate on SaleBillVouchZT.cstcode =_LookUpDate.iText 
    left join (select ccode as 会计科目,case when bproperty=0 then '借' else '贷' end 余额方向 from code) kjkm on _LookUpDate.iID=会计科目  
where dverifydate is not null
group by SaleBillVouchZT.SBVID ,DATENAME(mm,dverifydate),dcreatesystime,cMaker,dverifydate,cverifier,dverifydate,SaleBillVouchZT.cstname,_LookUpDate.Remark,_LookUpDate.iID,cSBVCode,dcreatesystime,cexch_name,iexchrate,cInvalider,cpersoncode,ccuscode,cdepcode,dDate

union all 

select 2 as flag,cast(0 as bit) as ischk,convert(nvarchar,SaleBillVouchZT.SBVID)  as  主键,	'记帐凭证' as 凭证类别,	DATENAME(mm,dverifydate) as 期间,1 as	凭证号,	convert(varchar(10),dDate ,120)  as 制单日期,cMaker as	制单人,	convert(varchar(10),dverifydate,120)  as 审核日期,
    ''  as	审核人,	null 签字日期,	null as 出纳,3 as	附单据数,null  as 分录号,	
    case when _LookUpDate.Remark is not null and _LookUpDate.Remark<>'' then _LookUpDate.Remark else  SaleBillVouchZT.cstname end  as 摘要,case when _LookUpDate.iID is null or _LookUpDate.iID='' then '22210102' else _LookUpDate.iID end as 会计科目,	null 结算方式,cSBVCode as	销售发票号,	convert(varchar(10),dDate,120) as 票据日期,	cexch_name as 币种,iexchrate as 汇率,
    null as 借方原币金额,null as	借方本币金额,	
    sum(itax) as 贷方原币金额, sum(inattax)  as 贷方本币金额,	
    null as 借方数量,null as 贷方数量,null as 单价,
    case when cInvalider is null or cInvalider='' then '' else '已作废' end as	作废标志   ,cpersoncode as 业务员,null as 物料,ccuscode as 客户,cdepcode as 部门 
from SaleBillVouchZT inner join SaleBillVouchZW on SaleBillVouchZT.sbvid=SaleBillVouchZW.sbvid 
    left join (select * from _LookUpDate where iType=2) _LookUpDate on SaleBillVouchZT.cstcode =_LookUpDate.iText 
    left join (select ccode as 会计科目,case when bproperty=0 then '借' else '贷' end 余额方向 from code) kjkm on _LookUpDate.iID=会计科目   
where dverifydate is not null
group by SaleBillVouchZT.SBVID ,DATENAME(mm,dverifydate),dcreatesystime,cMaker,dverifydate,cverifier,dverifydate,SaleBillVouchZT.cstname,_LookUpDate.iID,_LookUpDate.Remark,cSBVCode,dcreatesystime,cexch_name,iexchrate,cInvalider,cpersoncode,ccuscode,cdepcode,dDate  having  sum(itax) <>0 

union all 

select 3 as flag,cast(0 as bit) as ischk,convert(nvarchar,SaleBillVouchZT.SBVID)  as  主键,	'记帐凭证' as 凭证类别,	DATENAME(mm,dverifydate) as 期间,1 as	凭证号,	convert(varchar(10),dDate ,120)  as 制单日期,cMaker as	制单人,	convert(varchar(10),dverifydate,120)  as 审核日期,
    ''  as	审核人,	null 签字日期,	null as 出纳,3 as	附单据数,null  as 分录号,	
    case when zr.Remark is not null and zr.Remark<>'' then zr.Remark 
    when _LookUpDate.Remark is not null and _LookUpDate.Remark<>'' then _LookUpDate.Remark else  SaleBillVouchZT.cstname end as 摘要,case when zr.iID is not null or zr.iID<>'' then zr.iID when _LookUpDate.iID is not null or _LookUpDate.iID<>'' then _LookUpDate.iID else '600010101' end as 会计科目,	null 结算方式,cSBVCode as	销售发票号,	convert(varchar(10),dDate,120) as 票据日期,	cexch_name as 币种,iexchrate as 汇率,
    null as 借方原币金额,null as	借方本币金额,	
    imoney as 贷方原币金额,  inatmoney as 贷方本币金额,	
    null as 借方数量,iQuantity as 贷方数量,iUnitPrice as 单价,
    case when cInvalider is null or cInvalider='' then '' else '已作废' end as	作废标志   ,cpersoncode as 业务员,cinvcode as 物料,ccuscode as 客户,cdepcode as 部门 
from SaleBillVouchZT inner join SaleBillVouchZW on SaleBillVouchZT.sbvid=SaleBillVouchZW.sbvid 
    left join (select * from _LookUpDate where iType=3) _LookUpDate on SaleBillVouchZT.cstcode =_LookUpDate.iText 
    left join (select ccode as 会计科目,case when bproperty=0 then '借' else '贷' end 余额方向 from code) kjkm on _LookUpDate.iID=会计科目   
    left join (select * from _LookUpDate where iType=5) zr on cinvcode=zr.iText 
where dverifydate is not null 
) a where 1=1 ";

        public static DataSet GetFormsData(string filter, string conn,string outstr)
        {
            filter = filter + " and '" + outstr + "' like '%,'+销售发票号+',%'";
            DataSet ds = new DataSet();
            DataTable dt = Get(filter, conn).Copy();
            ds.Tables.Add(dt);
            ds.Tables.Add(GetGroup(filter, conn,dt).Copy());
            ds.Tables.Add(GetFlow());
            ds.Tables["凭证"].Columns.Remove(ds.Tables["凭证"].Columns["ischk"]);
            ds.Tables["凭证"].Columns.Remove(ds.Tables["凭证"].Columns["业务员"]);
            ds.Tables["凭证"].Columns.Remove(ds.Tables["凭证"].Columns["物料"]);
            ds.Tables["凭证"].Columns.Remove(ds.Tables["凭证"].Columns["客户"]);
            ds.Tables["凭证"].Columns.Remove(ds.Tables["凭证"].Columns["部门"]);
            ds.Tables["凭证"].Columns.Remove(ds.Tables["凭证"].Columns["flag"]);

            dt.Columns["销售发票号"].ColumnName = "票据号";

            return ds;
        }

        public static DataTable GetFlow()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("凭证类型");
            dt.Columns.Add("期间");
            dt.Columns.Add("凭证号");
            dt.Columns.Add("分录号");
            dt.Columns.Add("金额");
            dt.Columns.Add("现金流量项目");
            dt.TableName = "现金流量项目";
            return dt;
        }

        public static DataTable GetFormsData2(string filter, string conn)
        {
            return Get(filter, conn).Copy();
        }

        public static DataTable Get(string filter, string conn)
        {
            string sql = _dataSourceStr.Replace("1=1", "1=1 " + filter );
            string sSQL = sql + " order by 销售发票号,flag";
            DataTable dtss = SqlHelper.ExecuteDataset(conn, CommandType.Text, sSQL).Tables[0];

            sql = "select 销售发票号 from (" + sql + ") a group by 销售发票号";
            DataTable dtnew = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            int count = dtnew.Rows.Count;
            for (int i = 0; i < dtss.Rows.Count; i++)
            {
                dtss.Rows[i]["分录号"] = i + 1;

                dtss.Rows[i]["附单据数"] = count;
            }
            dtss.TableName = "凭证";
            return dtss;
        }

        public static DataTable GetGroup(string filter, string conn,DataTable dtss)
        {
            //string sql = _dataSourceStr.Replace("1=1", "1=1 " + filter);
            //DataTable dtss = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql).Tables[0];
            ////for (int i = 0; i < dtss.Rows.Count; i++)
            ////{
            ////    dtss.Rows[i]["分录号"] = i + 1;
            ////}

            DataTable dtnew = new DataTable();
            dtnew.TableName = "辅助核算";
            dtnew.Columns.Add("凭证类别");
            dtnew.Columns.Add("期间");
            dtnew.Columns.Add("凭证号");
            dtnew.Columns.Add("分录号");
            dtnew.Columns.Add("辅助核算类别");
            dtnew.Columns.Add("辅助核算值");
            for (int i = 0; i < dtss.Rows.Count; i++)
            {
                DataTable dtfz = SqlHelper.ExecuteDataset(conn, CommandType.Text, "select * from _LookUpDate where iType=4 and iID='" + dtss.Rows[i]["会计科目"].ToString() + "'").Tables[0];
                for (int j = 0; j < dtfz.Rows.Count; j++)
                {
                    DataRow dw = dtnew.NewRow();
                    dw["凭证类别"] = dtss.Rows[i]["凭证类别"].ToString();
                    dw["期间"] = dtss.Rows[i]["期间"].ToString();
                    dw["凭证号"] = dtss.Rows[i]["凭证号"].ToString();
                    dw["分录号"] = dtss.Rows[i]["分录号"].ToString();
                    string km = dtfz.Rows[j]["iText"].ToString();
                    dw["辅助核算类别"] =km;
                    if (km == "客户")
                    {
                        dw["辅助核算值"] = dtss.Rows[i]["客户"].ToString();
                    }
                    else if (km == "物料")
                    {
                        dw["辅助核算值"] = dtss.Rows[i]["物料"].ToString();
                    }
                    else if (km == "部门")
                    {
                        dw["辅助核算值"] = dtss.Rows[i]["部门"].ToString();
                    }
                    else if (km == "业务员")
                    {
                        dw["辅助核算值"] = dtss.Rows[i]["业务员"].ToString();
                    }
                    dtnew.Rows.Add(dw);
                }
            }
            return dtnew;
        }

    }
}