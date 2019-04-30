using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using ClsBaseClass;

namespace ClsU8
{
    public class ClsLookUp
    {
        ClsDataBase clsSQLCommond = ClsDataBaseFactory.Instance();

        public string LookUpLookUpType()
        {
            string s = "";

            try
            {
                string sSQL = "select iID, iType from dbo._LookUpType order by iID";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpLoopUpData(string id)
        {
            string s = "";

            try
            {
                string sSQL = "select convert(nvarchar(50),iID) as iID,iText from dbo._LookUpDate where iType = '" + id + "' and isnull(bClose,1) = 1 order by iID";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpDepartment()
        {
            string s = "";

            try
            {
                string sSQL = "select cDepCode,cDepName from dbo.Department where 1=1 order by cDepCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL);
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpComputationUnit()
        {
            string s = "";

            try
            {
                string sSQL = @"select cComunitCode,cComunitName  from ComputationUnit order by cComunitCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpInventory()
        {
            string s = "";

            try
            {
                string sSQL = @"select cInvCode,cInvName,cInvStd,a.cComunitCode,b.cComunitName from Inventory a left join ComputationUnit b on a.cComunitCode=b.cComunitCode where 1=1 order by cInvCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpPerson()
        {
            string s = "";

            try
            {
                string sSQL = @"select PersonCode,PersonName from Person where 1=1 order by PersonCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpDistrictClass()
        {
            string s = "";

            try
            {
                string sSQL = @"select cDCCode,cDCName from DistrictClass where 1=1 order by cDCCode"; 
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpEngineering()
        {
            string s = "";

            try
            {
                string sSQL = @"select cECode, cEName from Engineering where 1=1 order by cECode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpQuality()
        {
            string s = "";

            try
            {
                string sSQL = @"select cQCode, cQName from Quality where 1=1 order by cQCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpSecurity()
        {
            string s = "";

            try
            {
                string sSQL = @"select cSCode, cSName from Security where 1=1 order by cSCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpRdRecord()
        {
            string s = "";

            try
            {
                string sSQL = @"select cRdCode from RdRecord where 1=1 order by cRdCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpUserInfo()
        {
            string s = "";

            try
            {
                string sSQL = @"select vchrUid,vchrName from _UserInfo where 1=1 order by vchrUid";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
                s = Cls序列化.SerializeDataTableXml(dt);
            }
            catch (Exception ee)
            {
                s = ee.Message;
            }
            return s;
        }

        public string LookUpProject()
        {
            string s = "";

            try
            {
                string sSQL = @"select cCode,cName from Project where 1=1 order by cCode";
                DataTable dt = clsSQLCommond.ExecQuery(sSQL); ;
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
