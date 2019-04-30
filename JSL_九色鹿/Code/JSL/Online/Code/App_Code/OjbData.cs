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
    string sql;


    public OjbData()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region Get 销售出库单
    public DataTable GetOut(string sdate,string edate)
    {
        sql = "select a.ID,a.cSOOutCode,a.cCusCode,convert(varchar(10),dDate,120) as dDate,cInvCode,BoxNo,BoxQty,iQuantity from SO_SOOutMain a left join SO_SOOutDetails b on a.ID=b.ID where 1=1 ";
        if (sdate != "")
        {
            sql = sql + " and dDate>='" + sdate + "'";
        }
        if (edate != "")
        {
            sql = sql + " and dDate<='" + edate + "'";
        }
        sql = sql + " order by a.ID desc";
        return Conn.DataTable(sql);
    }
    #endregion


    #region Get 条码扫描入库
    public DataTable GetIn(string sdate, string edate)
    {
        sql = "select a.ID,a.cRdCode,convert(varchar(10),dDate,120) as dDate,cInvCode,BoxNo,BoxQty,sBoxNo,sBoxQty from RdRecord a left join RdRecords b on a.ID=b.ID where cMPCode='0004' and cRSCode='03' ";
        if (sdate != "")
        {
            sql = sql + " and dDate>='" + sdate + "'";
        }
        if (edate != "")
        {
            sql = sql + " and dDate<='" + edate + "'";
        }
        sql = sql + " order by a.ID desc";
        return Conn.DataTable(sql);
    }
    #endregion

    #region Get 盘点单
    public DataTable GetCheckVouch(string sdate, string edate)
    {
        sql = "select a.ID,b.AutoID,a.CheckCode,convert(varchar(10),dDate,120) as dDate,cInvCode,BoxNo,BoxQty,sBoxNo,sBoxQty from CheckVouch a left join CheckVouchs b on a.ID=b.ID  ";
        if (sdate != "")
        {
            sql = sql + " and dDate>='" + sdate + "'";
        }
        if (edate != "")
        {
            sql = sql + " and dDate<='" + edate + "'";
        }
        sql = sql + " order by a.ID desc";
        return Conn.DataTable(sql);
    }
    #endregion
}


