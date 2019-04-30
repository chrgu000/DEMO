using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

    /// <summary>
    ///Public 的摘要说明
    /// </summary>
public class PublicData
{
    ClsDES clsDES = ClsDES.Instance();
    ClsDataBase clsSQLCommond = new ClsDataBase();
    string sSQL = "";
    public PublicData()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    #region 获得LookUpType
    public DataTable GetLookUpType()
    {
        sSQL = @"SELECT  convert(int,iID) as iID,iType as iText into #a FROM  _LookUpType  
        insert into #a(iID,iText) values('','')
 select * from #a order by iID";
        return clsSQLCommond.ExecQuery(sSQL);
    }

    public string GetLookUpType(string iid)
    {
        sSQL = @" SELECT  iType FROM  _LookUpType where iID='" + iid + "' ";
        return clsSQLCommond.ExecString(sSQL);
    }
    #endregion

    #region 获得LookUpData
    public DataTable GetLookUpData(string iType)
    {
        sSQL = @" SELECT  convert(varchar,iID) as iID,iText into #a FROM  _LookUpDate where iType='" + iType + "'  ORDER BY iID " +
        @" insert into #a(iID,iText) values('','')
        select * from #a order by iID";
        return clsSQLCommond.ExecQuery(sSQL);
    }
    public string GetLookUpData(string iType,string iid)
    {
        sSQL = @" SELECT  iText FROM  _LookUpDate where iType='" + iType + "' and iID='"+iid+"' ";
        return clsSQLCommond.ExecString(sSQL);
    }
    #endregion

    public DataTable GetAccvouchType()
    {
        sSQL = @" SELECT  iID,iText FROM  AccvouchType";
        return clsSQLCommond.ExecQuery(sSQL);
    }

    #region 得到用友信息
    //人员
    public DataTable GetPerson()
    {
        sSQL = @" select cDept_num,c.cPsn_Num,a.cUser_Id as cPersonCode,a.cUser_Name as cPersonName from @u8.UA_User a, @u8.UserHRPersonContro b,@u8.hr_hi_person c where a.cUser_Id = b.cUser_Id and b.cPsn_Num = c.cPsn_Num  ";
        return clsSQLCommond.ExecQuery(sSQL);
    }

    //供应商
    public DataTable GetVendor()
    {
        sSQL = "select  cVenCode ,  cVenName from @u8.Vendor ";
        return clsSQLCommond.ExecQuery(sSQL);
    }

    //凭证类别表
    public DataTable GetDsign()
    {
        sSQL = "select  i_id, ctext from @u8.dsign";
        return clsSQLCommond.ExecQuery(sSQL);
    }
    
    //结算方式
    public DataTable GetSettleStyle()
    {
        sSQL = @"select  cSSCode , cSSName into #a  from @u8.SettleStyle
        insert into #a(cSSCode , cSSName) values('','') 
select * from #a order by cSSCode";
        return clsSQLCommond.ExecQuery(sSQL);
    }

    //部门
    public DataTable GetDepartment()
    {
        sSQL = "select  cDepCode , cDepName   from @u8.Department ";
        return clsSQLCommond.ExecQuery(sSQL);
    }

    //抬头
    public DataTable GetfItemss00()
    {
        sSQL = "select  citemcode,citemname   from @u8.fItemss00 ";
        return clsSQLCommond.ExecQuery(sSQL);
    }

    ////付款申请单
    //public DataTable GetAP_ApplyPayVouch()
    //{
    //    sSQL = "select  cVouchID,cVouchID   from @u8.AP_ApplyPayVouch ";
    //    return clsSQLCommond.ExecQuery(sSQL);
    //}
    #endregion
    
    

}
