using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

    /// <summary>
    ///Public 的摘要说明
    /// </summary>
public class UserInfoData : Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ClsDES clsDES = ClsDES.Instance();
    string sSQL = "";
    string tablename = "_UserInfo";
    public UserInfoData()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public DataTable Get()
    {
//        sSQL = @"insert into _UserInfo(vchrUid,vchrName,dtmCreate,dtmClose,vchrPwd) select cPersonCode,cPersonName,getdate(),null,'B8BF1F5E2A325363'  from 
//(
//select a.cUser_Id as cPersonCode,a.cUser_Name as cPersonName from @u8.UA_User a, @u8.UserHRPersonContro b,@u8.hr_hi_person c where a.cUser_Id = b.cUser_Id and b.cPsn_Num = c.cPsn_Num  and nState=0 
//)a " +
//@"where a.cPersonCode not in (select vchrUid from _UserInfo)
//
//SELECT * FROM   " + tablename + " a left join @u8.UA_User b on a.vchrUid=b.cUser_Id where 1=1  and nState=0  ";
        sSQL = "SELECT * FROM   " + tablename + " where 1=1   ";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        return dt;
    }

    public DataTable Get(string vchrUid)
    {
//        sSQL = @"insert into _UserInfo(vchrUid,vchrName,dtmCreate,dtmClose,vchrPwd) select cPersonCode,cPersonName,getdate(),null,'B8BF1F5E2A325363'  from 
//(
//select a.cUser_Id as cPersonCode,a.cUser_Name as cPersonName from @u8.UA_User a, @u8.UserHRPersonContro b,@u8.hr_hi_person c where a.cUser_Id = b.cUser_Id and b.cPsn_Num = c.cPsn_Num  and nState=0 
//) a " +
//@"where a.cPersonCode not in (select vchrUid from _UserInfo) 
//
//SELECT * FROM   " + tablename + " a left join @u8.UA_User b on a.vchrUid=b.cUser_Id where 1=1  and nState=0   ";
//        if (vchrUid != "")
//        {
//            sSQL = sSQL + " and (vchrUid like '%" + vchrUid + "%' or vchrName like '%" + vchrUid + "%')";
//        }
        sSQL = "SELECT * FROM   " + tablename + "  where 1=1 ";
        if (vchrUid != "")
        {
            sSQL = sSQL + " and (vchrUid like '%" + vchrUid + "%' or vchrName like '%" + vchrUid + "%')";
        }
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        return dt;
    }

    public bool Insert(string vchrUid, string vchrName, string vchrPwd, string vchrRemark, DateTime dtmCreate, DateTime dtmClose)
    {
        string uid = Session["uID"].ToString();
        ArrayList arr = new ArrayList();
        Sql sql = new Sql();
        sSQL = "select * from  " + tablename + " where vchrUid='" + vchrUid + "'";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count==0)
        {
            sql.Get(tablename, "vchrUid", vchrUid, true);
        }
        else
        {
            sql.Get(tablename, "vchrUid", vchrUid, false);
        }
        sql.ToString("vchrName", vchrName);
        if (dtmCreate != null)
        {
            sql.ToString("dtmCreate", dtmCreate);
        }
        if (dtmClose != null)
        {
            sql.ToString("dtmClose", dtmClose);
        }
        if (vchrPwd != null && vchrPwd!="")
        {
            sql.ToString("vchrPwd", clsDES.Encrypt(vchrPwd));
        }
        else
        {
            //sql.ToString("vchrPwd", clsDES.Encrypt("123456"));
        }
        sql.ToString("vchrRemark", vchrRemark);
        arr.Add(sql.ReturnSql());
        bool b = clsSQLCommond.ExecSqlTran(arr);
        return true;
    }


    public bool Delete(string vchrUid)
    {
        sSQL = "delete from " + tablename + " where vchrUid='" + vchrUid + "' ";
        bool b = clsSQLCommond.Update(sSQL);
        return b;
    }

    public bool CheckiID(string iID, string iType)
    {
        sSQL = "SELECT * FROM   " + tablename + " where iID='" + iID + "' and iType='" + iType + "'";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        return true;
    }
    public bool CheckiText(string iID, string iType, string iText)
    {
        sSQL = "SELECT * FROM   " + tablename + " where iText='" + iText + "' and iType='" + iType + "' ";
        if (iID != "")
        {
            sSQL = sSQL + " and iID<>'" + iID + "'";
        }
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        return true;
    }

    public bool CheckDel(string iID, string iType)
    {
        sSQL = "SELECT * FROM  _TableColInfo where ColSel='LookUpData' and ColSelFlag='" + iType + "' ";
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sSQL = "select count(*) from " + dt.Rows[i]["TABLE_CATALOG"].ToString() + "." + dt.Rows[i]["TABLE_SCHEMA"].ToString() + "." + dt.Rows[i]["TABLE_NAME"].ToString() + " where  COLUMN_NAME='" + iID + "' ";
            int iCount = clsSQLCommond.Int(sSQL);
            if (iCount > 0)
            {
                return false;
            }
        }
        return true;
    }
}
