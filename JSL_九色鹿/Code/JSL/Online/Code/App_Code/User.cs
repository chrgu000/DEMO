using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

public class Users
{
    private static string _UserID;
    public static string UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }

    private static string _UserName;
    public static string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    private static string _DeptID;
    public static string DeptID
    {
        get { return _DeptID; }
        set { _DeptID = value; }
    }

    private static string _DeptName;
    public static string DeptName
    {
        get { return _DeptName; }
        set { _DeptName = value; }
    }

    #region 得到系统人员的ID
    public static int GetSystemID()
    {
        return 0;
    }
    #endregion

    #region 用户编号转化成用户名称列表
    /// <summary>
    /// 用户编号转化成用户名称列表
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    public static string UserIDToUserName(string UserID)
    {
        string str = "";
        if (UserID != "")
        {
            string sql = "select UserName from Employee where UserID in (" + UserID + ")  group by UserName order by UserName";
            DataTable dt = Conn.DataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (str == "")
                {
                    str = dt.Rows[i]["UserName"].ToString();
                }
                else
                {
                    str = str + "," + dt.Rows[i]["UserName"].ToString();
                }
            }
        }
        return str;
    }
    #endregion

    #region 部门编号转化成部门名称
    /// <summary>
    /// 部门编号转化成部门名称
    /// </summary>
    /// <param name="UserID"></param>
    /// <returns></returns>
    public static string DeptIDToDeptName(string ID)
    {
        string str = "";
        if (ID != "")
        {
            string sql = "select DeptName from EmployeeDepartment where DeptID in (" + ID + ")  group by DeptName order by DeptName";
            DataTable dt = Conn.DataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (str == "")
                {
                    str = dt.Rows[i]["DeptName"].ToString();
                }
                else
                {
                    str = str + "," + dt.Rows[i]["DeptName"].ToString();
                }
            }
        }
        return str;
    }
    #endregion

    #region 流程序号转化为扣分员工序号
    /// <summary>
    /// 流程序号转化为扣分员工序号
    /// </summary>
    /// <param name="AID"></param>
    /// <returns></returns>
    public static string ApplyAIDToUserName(string AID)
    {
        string str = "";
        if (AID != "")
        {
            string sql = "select Manager from FlowApply a left join EmployeeDepartment b on a.DeptID=b.DeptID where AID=" + AID + "";
            DataTable dt = Conn.DataTable(sql);
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0]["Manager"].ToString();
            }
        }
        return str;
    }
    #endregion

    #region 判断两个员工是否为同一部门
    /// <summary>
    /// 判断两个员工是否为同一部门
    /// </summary>
    /// <returns></returns>
    public static bool IsSameDept(string uid1, string uid2)
    {
        if (uid1 != "" && uid2 != "")
        {
            string sql = "select count(*) as sum from Employee where UserID=" + uid1 + " or UserID=" + uid2 + " group by DeptID";
            DataTable dt = Conn.DataTable(sql);
            if (dt.Rows.Count == 1)
            {
                if (dt.Rows[0]["sum"].ToString() == "2")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region 从部门编号得到部门主管
    /// <summary>
    /// 从部门编号得到部门主管
    /// </summary>
    /// <param name="DeptID"></param>
    /// <returns></returns>
    public static string DeptIDToManagerID(string DeptID)
    {
        if (DeptID != "")
        {
            string sql = "select Manager from EmployeeDepartment where DeptID=" + DeptID + "";
            return Conn.String(sql);
        }
        return "";
    }
    #endregion

    #region 是否为部门主管
    /// <summary>
    /// 是否为部门主管
    /// </summary>
    /// <param name="DeptID"></param>
    /// <returns></returns>
    public static bool IsManager(string UserID)
    {
        if (UserID != "")
        {
            string sql = "select count(*) from EmployeeDepartment where Manager=" + UserID + "";
            if (int.Parse(Conn.String(sql)) > 0)
            {
                return true;
            }
        }
        return false;
    }
    #endregion
}
