using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.ComponentModel;
using System.Collections.Generic;

/// <summary>
/// OjbData 的摘要说明
/// </summary>
[DataObject]
public class OjbData : Page
{
    string sSQL;
    ClsDataBase clsSQLCommond = new ClsDataBase();
    public OjbData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }


    #region 访客
    public DataTable GetVisitors()
    {
        string uid=Session["uID"].ToString();

        sSQL = "SELECT     * FROM         _UserRoleInfo ";
        DataTable dtrole = clsSQLCommond.ExecQuery(sSQL);
        
        return dtrole;
    }

    #endregion

    #region 获得角色信息
    public DataTable GetUserRole(string sUid)
    {
        sSQL = "select dbo._RoleInfo.vchrRoleID,vchrRoleText,vchrRemark, " +
                                "bChoosed = case isnull(dbo._UserRoleInfo.vchrRoleID,'') " +
                                "	when '' then 0 " +
                                "		else 1 " +
                                "	end " +
                        "from dbo._RoleInfo left join dbo._UserRoleInfo on dbo._UserRoleInfo.vchrRoleID = dbo._RoleInfo.vchrRoleID  " +
                        "	and vchrUserID = '" + sUid + "' " +
                        "where isnull(bClosed,0) <>1 and 1=1  " +
                        "order by dbo._RoleInfo.vchrRoleID";
        if (Session["uID"].ToString() != "admin")
        {
            sSQL = sSQL.Replace("1=1", "_RoleInfo.vchrRoleID!='administrator'");
        }
        return clsSQLCommond.ExecQuery(sSQL);
    }
    #endregion

    #region 获得用户信息
    public DataTable GetRoleUser(string sRoleID)
    {
        sSQL = "select _UserInfo.vchrUid,vchrName,vchrRemark,dtmCreate,dtmClose, " +
                        "bChoosed = case isnull(_UserRoleInfo.vchrUserID,'') when '' then 0 else 1 end " +
                    "from dbo._UserInfo left join dbo._UserRoleInfo  " +
                        "on _UserRoleInfo.vchrUserid = _UserInfo.vchrUid and vchrRoleID ='" + sRoleID + "' " +
                        "where dtmCreate<=getdate() and dtmClose >= getdate() and 1=1 " +
                   "order by _UserInfo.vchrUid";
        if (Session["uID"].ToString() != "admin")
        {
            sSQL = sSQL.Replace("1=1", "vchrUid!='admin'");
        }
        return clsSQLCommond.ExecQuery(sSQL);
    }
    #endregion

    #region 获得用户列表
    public DataTable GetUserInfo( )
    {
        sSQL = "SELECT vchrUid, vchrPwd,vchrName, vchrRemark, tstamp, dtmCreate, dtmClose " +
                         "  FROM _UserInfo where 1=1 " +
                         " order by vchrUid ";
        if (Session["uID"].ToString() != "admin")
        {
            sSQL = sSQL.Replace("1=1", "vchrUid!='admin'");
        }
        return clsSQLCommond.ExecQuery(sSQL);
    }
    #endregion

    #region 获得权限列表
    public DataTable GetRoleInfo()
    {
        sSQL = "SELECT vchrRoleID, vchrRoleText, vchrRemark, case when bClosed=0 then '否' else '是' end as bClosed, dtmCreate " +
                                "FROM _RoleInfo " +
                                "ORDER BY vchrRoleID ";
        return clsSQLCommond.ExecQuery(sSQL);
    }
    #endregion

    #region 获得LookUpType
    public DataTable GetLookUpType()
    {
        sSQL = "SELECT  * FROM  _LookUpType  ORDER BY iID ";
        return clsSQLCommond.ExecQuery(sSQL);
    }
    #endregion

    #region 获得LookUpData
    public DataTable GetLookUpData(string iType)
    {
        sSQL = "SELECT  * FROM  _LookUpDate where iType='" + iType + "'  ORDER BY iID ";
        return clsSQLCommond.ExecQuery(sSQL);
    }
    #endregion
}


