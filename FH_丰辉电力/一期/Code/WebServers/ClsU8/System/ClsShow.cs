using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsShow
    {
        ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();

        public string ShowlookUpDate(string code,string iType)
        {
            string s = "";
            string sSQL = "";
            try
            {
                if (iType == "2")
                {
                    sSQL = @"select cast(0 as bit) as 选择,iID as iID,iID as 工程类型编码,iText as 工程类型名称
from _LookUpDate  where 1=1 and bClose=1 and iType='" + iType + "' order by iID";
                }
                if (code != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and iID like '%" + code + "%' or iText='" + code + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string ShowInventory(string cInvCode)
        {
            string s = "";

            try
            {
                string sSQL = @"select cast(0 as bit) as 选择,cInvCode as iID,cInvCode as 存货编码,cInvName as 存货名称,cInvAddCode as 存货代码,cInvStd as 规格型号,a.cComunitCode as 计量单位,b.cComunitName as 计量单位名称 
from Inventory a left join ComputationUnit b on a.cComunitCode=b.cComunitCode where 1=1 and a.bClosed=0  order by cInvCode";
                if (cInvCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cInvCode like '%" + cInvCode + "%' or cInvName='" + cInvCode + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); 
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string ShowPerson(string PersonCode)
        {
            string s = "";

            try
            {
                string sSQL = @"select 选择,iID,人员编码,人员名称 from (
select cast(0 as bit) as 选择,PersonCode as iID,PersonCode as 人员编码,PersonName as 人员名称
,case when BeginDate is null then dateadd(d,-1,GETDATE()) else BeginDate end 开始日期
,case when EndDate is null then dateadd(d,1,GETDATE()) else EndDate end 结束日期  from Person 
where 1=1 ) a where 开始日期<GETDATE() and 结束日期>GETDATE() order by 人员编码 ";
                if (PersonCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and PersonCode like '%" + PersonCode + "%' or PersonName='" + PersonCode + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); 
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string ShowDepartment(string cDepCode)
        {
            string s = "";

            try
            {
                string sSQL = "select cast(0 as bit) as 选择,cDepCode as iID,cDepCode as 部门编码,cDepName as 部门名称 from dbo.Department where 1=1 and bClosed=0 order by cDepCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string ShowEngineering(string cECode)
        {
            string s = "";

            try
            {
                string sSQL = @"select cast(0 as bit) as 选择,cECode as iID,cECode as 工程性质编码, cEName as 工程性质名称 from Engineering where 1=1 and bClosed=0 order by cECode";
                if (cECode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cECode like '%" + cECode + "%' or cEName='" + cECode + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); 
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string ShowDistrictClass(string cDCCode)
        {
            string s = "";

            try
            {
                string sSQL = @"select cast(0 as bit) as 选择,cDCCode as iID,cDCCode as 地区编码, cDCName as 地区名称 from DistrictClass where 1=1 and bClosed=0 order by cDCCode";
                if (cDCCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cDCCode like '%" + cDCCode + "%' or cDCName='" + cDCCode + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string ShowQuality(string cQCode)
        {
            string s = "";

            try
            {
                string sSQL = @"select cast(0 as bit) as 选择,cQCode as iID,cQCode as 质量标准编码, cQName as 质量标准名称 from Quality where 1=1 and bClosed=0 order by cQCode";
                if (cQCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cQCode like '%" + cQCode + "%' or cQName='" + cQCode + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); 
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string ShowSecurity(string cSCode)
        {
            string s = "";

            try
            {
                string sSQL = @"select cast(0 as bit) as 选择,cSCode as iID,cSCode as 安全标准编码, cSName as 安全标准名称 from Security where 1=1 and bClosed=0 order by cSCode";
                if (cSCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cSCode like '%" + cSCode + "%' or cSName='" + cSCode + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string ShowProject(string cCode)
        {
            string s = "";

            try
            {
                string sSQL = @"select cast(0 as bit) as 选择,cCode as iID,cCode as 项目编码, cName as 项目名称 from Project where 1=1 and EndState=0 order by cName";
                if (cCode != "")
                {
                    sSQL = sSQL.Replace("1=1", "1=1 and cCode like '%" + cCode + "%' or cName='" + cCode + "'");
                }
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }
    }
}
