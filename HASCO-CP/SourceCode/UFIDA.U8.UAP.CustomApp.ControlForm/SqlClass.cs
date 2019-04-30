using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Collections;


/// <summary>
/// SqlClass 的摘要说明
/// </summary>
public class SqlClass
{
    private string _Table;
    private string _Sql;
    private string _Sql2;

    public SqlClass(string Table)
	{
        _Table = Table;
        _Sql = "";
        _Sql2="";
	}

    public bool IsNew()
    {
        return true;
    }

    public void ToString(string Name, string Value)
    {
        if (IsNew())
        {
            if (Value == "")
            {
                _Sql = _Sql + Name + ",";
                _Sql2 = _Sql2 + "null,";
            }
            else
            {
                _Sql = _Sql + Name + ",";
                _Sql2 = _Sql2 + "'" + Value + "',";
            }
        }
        else
        {
            if (Value == "")
            {
                _Sql = _Sql + Name + "=null,";
            }
            else
            {
                _Sql = _Sql + Name + "='" + Value + "',";
            }
        }
    }

    public void ToString(string Name, int Value)
    {
        if (IsNew())
        {
            if (Value.ToString() == "")
            {
                _Sql = _Sql + Name + ",";
                _Sql2 = _Sql2 + "null,";
            }
            else
            {
                _Sql = _Sql + Name + ",";
                _Sql2 = _Sql2 + "'" + Value + "',";
            }
        }
        else
        {
            if (Value.ToString() == "")
            {
                _Sql = _Sql + Name + "=null,";
            }
            else
            {
                _Sql = _Sql + Name + "='" + Value + "',";
            }
        }
    }

    #region 多表返回Sql后通过SqlTransaction更新
    public string UpdateSql()
    {
        return "insert into " + _Table + "(" + _Sql.Substring(0, _Sql.Length - 1) + ") values(" + _Sql2.Substring(0, _Sql2.Length - 1) + ")";
    }
    #endregion 
}
