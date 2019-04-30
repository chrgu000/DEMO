using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
using System.Collections;

/// <summary>
/// ConnClass 的摘要说明
/// </summary>
public class Conn : System.Web.UI.Page
{
    public static string Online
    {
        get { return WebConfigurationManager.ConnectionStrings["ConnectionString1"].ToString(); }
        set { }
    }


    #region 查詢SQL語句，返回Datatable 类型
    /// <summary>
    /// 传入SQL语句，查询数据库，取出结果集放入DataTable中
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <returns>DataTable表</returns>
    public static DataTable DataTable(string sql)
    {
        SqlDataAdapter da;
        DataTable dt;
        CheckSession();
        da = new SqlDataAdapter(sql, Online);
        dt = new DataTable();
        da.Fill(dt);
        da.Dispose();
        return dt;
    }

    /// <summary>
    /// 传入SQL语句，查询数据库，取出结果集放入DataTable中
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <returns>DataTable表</returns>
    public static DataTable DataTableWithoutSession(string sql)
    {
        SqlDataAdapter da;
        DataTable dt;
        da = new SqlDataAdapter(sql, Online);
        dt = new DataTable();
        
        da.Fill(dt);
        da.Dispose();
        return dt;
    }
    #endregion

    #region 查询 返回String 型
    /// <summary>
    /// 传入SQL语句，查询数据库,当结果只有1行1列时，取出结果集放入string中
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <returns>string字符串</returns>
    public static string String(string sql)
    {
        SqlDataAdapter da;
        DataTable dt;
        CheckSession();
        da = new SqlDataAdapter(sql, Online);
        dt = new DataTable();
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0][0].ToString();
        }
        da.Dispose();
        return "";
    }

    /// <summary>
    /// 传入SQL语句，查询数据库,当结果只有1行1列时，取出结果集放入string中
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <returns>string字符串</returns>
    public static string StringWithoutSession(string sql)
    {
        SqlDataAdapter da;
        DataTable dt;
        da = new SqlDataAdapter(sql, Online);
        dt = new DataTable();
        
        da.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0][0].ToString();
        }
        da.Dispose();
        return "";
    }


    ///// <summary>
    ///// 传入SQL语句，查询数据库,当结果只有1行1列时，取出结果集放入string中,不检查Session
    ///// </summary>
    ///// <param name="sql">sql语句</param>
    ///// <returns>string字符串</returns>
    //public string GetStringWithoutSession(string sql)
    //{
    //    da = new SqlDataAdapter(sql, Conn.Online);
    //    dt = new DataTable();
    //    da.Fill(dt);
    //    if (dt.Rows.Count > 0)
    //    {
    //        return dt.Rows[0][0].ToString();
    //    }
    //    return "";
    //}
    #endregion

    #region 数据新增或删除或修改
    /// <summary>
    /// 传入SQL语句，进行表中数据的增删改
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <returns>bool型字符串，true或false，分别表示成功或不成功</returns>
    public static bool Update(string sql)
    {
        SqlConnection Con;
        SqlCommand Cmd;
        CheckSession();
        bool returnValue = false;
        Con = new SqlConnection(Online);
        Cmd = new SqlCommand(sql, Con);
        Con.Open();
        Cmd.ExecuteNonQuery();
        returnValue = true;

        Con.Close();
        return returnValue;
    }

    public static bool UpdateWithoutSession(string sql)
    {
        SqlConnection Con;
        SqlCommand Cmd;
        bool returnValue = false;
        Con = new SqlConnection(Online);
        Cmd = new SqlCommand(sql, Con);
        Con.Open();
        Cmd.ExecuteNonQuery();
        returnValue = true;
        Con.Close();
        return returnValue;
    }

    /// <summary>
    /// 查询Sql
    /// </summary>
    /// <param name="xsql">Sql语句</param>
    /// <returns>字符串</returns>
    public static int Int(string xsql)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(xsql,Online);
        da.SelectCommand.CommandTimeout = 600;
        da.Fill(dt);
        da.Dispose();
        if (dt.Rows.Count > 0)
        {
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// 查询Sql
    /// </summary>
    /// <param name="xsql">Sql语句</param>
    /// <returns>字符串</returns>
    public static long Long(string xsql)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(xsql, Online);
        da.SelectCommand.CommandTimeout = 600;
        da.Fill(dt);
        da.Dispose();
        if (dt.Rows.Count > 0)
        {
            return Convert.ToInt64(dt.Rows[0][0].ToString());
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// 传入SQL语句，进行表中数据的增删改 
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <returns>bool型字符串，true或false，分别表示成功或不成功</returns>
    public static bool GetUpdateWithoutSession(string sql)
    {
        bool returnValue = false;
        try
        {
            SqlConnection Con;
            SqlCommand Cmd;
            Con = new SqlConnection(Online);
            Cmd = new SqlCommand(sql, Con);
            Con.Open();
            Cmd.ExecuteNonQuery();
            returnValue = true;
            Con.Close();
        }
        catch
        {
        }
        return returnValue;
    }
    #endregion

    #region  通用存储过程查询，返回DataTable类型
    /// <summary>
    ///函数输入存储过程，输出一个结果集（DATATABLE）
    /// </summary>
    /// <param name="procName">sql：传入的sql语句</param>
    /// <param name="paras">paras:存储过程的参数数组</param>
    /// <returns>返回DataTable</returns>
    public static DataTable Procedure(string procName, params SqlParameter[] paras)
    {
        SqlConnection Con;
        SqlCommand Cmd;
        SqlDataAdapter da;
        DataTable dt;
        Con = new SqlConnection(Online);
        Cmd = new SqlCommand();
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.CommandText = procName;
        Cmd.Connection = Con;
        Cmd.CommandTimeout = 600;
        DataSet ds = new DataSet();
        if (paras != null)
        {
            foreach (SqlParameter sp in paras)
            {
                Cmd.Parameters.Add(sp);
            }
        }
        da = new SqlDataAdapter(Cmd);
        Con.Open();
        da.Fill(ds, procName);
        dt = ds.Tables[procName];
        da.Dispose();
        Con.Close();
        return dt;
    }

    public static DataTable Procedure(string procName)
    {
        SqlConnection Con;
        SqlCommand Cmd;
        SqlDataAdapter da;
        DataTable dt;
        Con = new SqlConnection(Online);
        Cmd = new SqlCommand();
        Cmd.CommandType = CommandType.StoredProcedure;
        Cmd.CommandText = procName;
        Cmd.Connection = Con;
        Cmd.CommandTimeout = 600;
        DataSet ds = new DataSet();
        da = new SqlDataAdapter(Cmd);
        Con.Open();
        da.Fill(ds, procName);
         dt = ds.Tables[procName];
         da.Dispose();
        Con.Close();
        return dt;
    }
    #endregion

    #region 判断Session
    public static void CheckSession()
    {
        if (HttpContext.Current.Session["uID"] == null || HttpContext.Current.Session["uID"].ToString() == "")
        {
            //if (this.Parent == null)
            //{
                //Response.Redirect("..//ErrorPage.aspx");
                StringBuilder str = new StringBuilder();
                str.Append("<script language=javascript>location.href('../ErrorPage.aspx');</script>");
                System.Web.HttpContext.Current.Response.Write(str.ToString());
                //if (System.IO.File.Exists("E:\\MyNet\\DolleOnline\\PerformanceEvaluation\\ErrorPage.aspx"))
                //{
                //    this.Page.Response.Redirect("..//ErrorPage.aspx");
                //    System.Web.HttpContext.Current.Response.End();
                //}
                //else if (System.IO.File.Exists("ErrorPage.aspx"))
                //{
                //    this.Page.Response.Redirect("ErrorPage.aspx");
                //    System.Web.HttpContext.Current.Response.End();
                //}
                //else if (System.IO.File.Exists("..//..//ErrorPage.aspx"))
                //{
                //    this.Page.Response.Redirect("..//..//ErrorPage.aspx");
                //    System.Web.HttpContext.Current.Response.End();
                //}
                //this.Parent.Page.Response.Redirect("../ErrorPage.aspx");
                //System.Web.HttpContext.Current.Response.End();
            //}
            //else
            //{
            //    //this.Parent.Page.Response.Redirect("../ErrorPage.aspx");
            //    //System.Web.HttpContext.Current.Response.End();
            //}
            //System.Web.HttpContext.Current.Response.Redirect("..//ErrorPage.aspx");
            //string str = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            //System.Web.HttpContext.Current.Response.End();
        }
    }

    #endregion

}

