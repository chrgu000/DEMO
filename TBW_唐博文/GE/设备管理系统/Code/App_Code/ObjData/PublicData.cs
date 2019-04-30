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
        sSQL = @"SELECT  convert(varchar,iID) as iID,iType as iText into #a FROM  _LookUpType  ORDER BY iID 
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

    #region 得到设备信息
    public DataTable GetEquip()
    {
        sSQL = @" SELECT  convert(varchar,S1) as iID,S2 as iText into #a FROM  Equip   " +
            @" insert into #a(iID,iText) values(' ','')
        select * from #a order by iID";
        return clsSQLCommond.ExecQuery(sSQL);
    }
    public string GetEquip(string iid)
    {
        if (iid != "")
        {
            sSQL = @" SELECT  S2 FROM  Equip where  S1='" + iid + "' ";
            return clsSQLCommond.ExecString(sSQL);
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region 得到设备类型
    public DataTable GetEquipType()
    {
        sSQL = @" SELECT  convert(varchar,S1) as iID,S2 as iText into #a FROM  EquipType   " +
            @" insert into #a(iID,iText) values(' ','')
        select * from #a order by iID";
        return clsSQLCommond.ExecQuery(sSQL);
    }
    public string GetEquipType(string iid)
    {
        if (iid != "")
        {
            sSQL = @" SELECT  S2  FROM  EquipType  where  S1='" + iid + "' ";
            return clsSQLCommond.ExecString(sSQL);
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region 得到设备信息
    public DataTable GetInventory()
    {
        sSQL = @" SELECT  convert(varchar,S1) as iID,S2 as iText into #a FROM  Inventory " +
            @" insert into #a(iID,iText) values(' ','')
        select * from #a order by iID";
        return clsSQLCommond.ExecQuery(sSQL);
    }
    public string GetInventory(string iid)
    {
        sSQL = @" SELECT  S2  FROM  Inventory where S1='" + iid + "'";
        return clsSQLCommond.ExecString(sSQL);
    }
    #endregion

    #region 得到设备信息
    public DataTable GetMachine()
    {
        sSQL = @" SELECT  convert(varchar,S1) as iID,S2 as iText into #a FROM  Machine " +
            @" insert into #a(iID,iText) values(' ','')
        select * from #a order by iID";
        return clsSQLCommond.ExecQuery(sSQL);
    }
    public string GetMachine(string iid)
    {
        sSQL = @" SELECT  S2  FROM  Machine where S1='" + iid + "'";
        return clsSQLCommond.ExecString(sSQL);
    }
    #endregion

    #region 得到操作工
    public DataTable GetWorker(string iType)
    {

        sSQL = @" SELECT  convert(varchar,S1) as iID,S2 as iText into #a FROM  Worker where 11111111111111 " +
            @" insert into #a(iID,iText) values(' ','')
        select * from #a order by iID";
        if (iType.Trim() != "")
        {
            sSQL = sSQL.Replace("11111111111111", "S3='" + iType + "'");
        }
        return clsSQLCommond.ExecQuery(sSQL);
    }
    public DataTable GetWorker()
    {

        sSQL = @" SELECT  convert(varchar,S1) as iID,S2 as iText into #a FROM  Worker where 1=1 " +
            @" insert into #a(iID,iText) values(' ','')
        select * from #a order by iID";
        return clsSQLCommond.ExecQuery(sSQL);
    }

    public string GetWorkers(string iid)
    {
        sSQL = @" SELECT  S2  FROM  Worker where S1='" + iid + "'";
        return clsSQLCommond.ExecString(sSQL);
    }
    #endregion
}
