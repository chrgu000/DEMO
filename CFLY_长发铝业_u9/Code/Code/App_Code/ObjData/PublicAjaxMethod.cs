using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
namespace Ajax
{
    /// <summary>
    /// Summary description for AjaxClass.
    /// </summary>
    public class PublicAjaxMethod : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string sSQL = "";
        ClsDataBase clsSQLCommond = new ClsDataBase();

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool CheckVerdor(string cVenCode)
        {
            sSQL = @"select * from @u8.Vendor where cVenCode  ='" + cVenCode + "'  ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetVerdorName(string cVenCode)
        {
            sSQL = @"select * from @u8.Vendor where cVenCode  ='" + cVenCode + "'  ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["cVenName"].ToString();
            }
            else
            {
                return "";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetVerID(string cVenCode)
        {
            sSQL = @"select * from @u8.Vendor where cVenCode  like '%" + cVenCode + "%' or  cVenName  like '%" + cVenCode + "%'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["cVenCode"].ToString();
            }
            else
            {
                return "";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetVerName(string cVenCode)
        {
            sSQL = @"select * from @u8.Vendor where cVenCode  like '%" + cVenCode + "%' or  cVenName  like '%" + cVenCode + "%'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["cVenName"].ToString();
            }
            else
            {
                return "";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool CheckDepartment(string cDepCode)
        {
            sSQL = @"select * from @u8.Department where cDepCode  ='" + cDepCode + "'  ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetDepartmentName(string cDepCode)
        {
            sSQL = @"select * from @u8.Department where cDepCode= '" + cDepCode + "'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["cDepName"].ToString();
            }
            else
            {
                return "";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetDeptID(string cDepCode)
        {
            sSQL = @"select * from @u8.Department where cDepCode  like '%" + cDepCode + "%' or  cDepName  like '%" + cDepCode + "%'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["cDepCode"].ToString();
            }
            else
            {
                return "";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetDeptName(string cDepCode)
        {
            sSQL = @"select * from @u8.Department where cDepCode  like '%" + cDepCode + "%' or  cDepName  like '%" + cDepCode + "%'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["cDepName"].ToString();
            }
            else
            {
                return "";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetDepartmentNameLike(string cDepCode)
        {
            sSQL = @"select * from @u8.Department where cDepCode  like '%" + cDepCode + "%' or  cDepName  like '%" + cDepCode + "%' ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count ==1)
            {
                return dt.Rows[0]["cDepName"].ToString();
            }
            else
            {
                return "";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetDepartmentIDLike(string cDepCode)
        {
            sSQL = @"select * from @u8.Department where cDepCode  like '%" + cDepCode + "%' or  cDepName  like '%" + cDepCode + "%' ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["cDepCode"].ToString();
            }
            else
            {
                return "";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public bool CheckfItemss00(string citemcode)
        {
            sSQL = @"select * from @u8.fItemss00 where citemcode  ='" + citemcode + "'  ";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetfItemss00ID(string citemcode)
        {
            sSQL = @"select * from @u8.fItemss00 where citemcode  like '%" + citemcode + "%' or  citemname  like '%" + citemcode + "%'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["citemcode"].ToString();
            }
            else
            {
                return "";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        public string GetfItemss00Name(string citemcode)
        {
            sSQL = @"select * from @u8.fItemss00 where citemcode  like '%" + citemcode + "%' or  citemname  like '%" + citemcode + "%'";
            DataTable dt = clsSQLCommond.ExecQuery(sSQL);
            if (dt.Rows.Count == 1)
            {
                return dt.Rows[0]["citemname"].ToString();
            }
            else
            {
                return "";
            }
        }


        //[AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.Read)]
        //public string GetfItemss00Name(string citemcode)
        //{
        //    sSQL = @"select * from @u8.fItemss00 where citemcode  ='" + citemcode + "'  ";
        //    DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        //    if (dt.Rows.Count > 0)
        //    {
        //        return dt.Rows[0]["citemname"].ToString();
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
    }
}