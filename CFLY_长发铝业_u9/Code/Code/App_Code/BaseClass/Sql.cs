using System;
using System.Data;
using System.Configuration;
using System.Collections;

    /// <summary>
    /// SqlClass 的摘要说明
    /// </summary>
public class Sql
{

    private string _Table;
    private string _Name;
    private string _ID;
    private string _Name2;
    private string _ID2;
    private string _Sql;
    private string _Sql2;
    private bool _isNew = true;

    public Sql()
    {
        _Table = "";
        _Name = "";
        _ID = "";
        _Name2 = "";
        _ID2 = "";
        _Sql = "";
        _Sql2 = "";
    }

    public void Get(string Table, string Name, string ID, bool isNew)
    {
        _Table = Table;
        _Name = Name;
        _ID = ID;
        _isNew = isNew;
    }

    public void Get(string Table, string Name, string ID, string Name2, string ID2, bool isNew)
    {
        _Table = Table;
        _Name = Name;
        _ID = ID;
        _Name2 = Name2;
        _ID2 = ID2;
        _isNew = isNew;
    }

    public void Get(string Table, string Name, long ID, bool isNew)
    {
        _Table = Table;
        _Name = Name;
        _ID = ID.ToString();
        _isNew = isNew;
    }

    public string ID
    {
        get { return _ID; }
    }

    //public bool IsNew
    //{
    //    get{ return _isNew; }
    //}

    private bool New()
    {
        if (_ID == "" || _isNew == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #region ToString

    public void ToString(string Name, string Value)
    {
        if (New())
        {
            if (Value == "" || Value == null)
            {
                _Sql = _Sql + Name + ",";
                _Sql2 = _Sql2 + "null,";
            }
            else
            {
                _Sql = _Sql + Name + ",";
                _Sql2 = _Sql2 + "'" + Value.Trim() + "',";
            }
        }
        else
        {
            if (Value == "" || Value==null)
            {
                _Sql = _Sql + Name + "=null,";
            }
            else
            {
                _Sql = _Sql + Name + "='" + Value.Trim() + "',";
            }
        }
    }

    public void ToString(string Name, double Value)
    {
        if (New())
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

    public void ToString(string Name, decimal Value)
    {
        if (New())
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

    public void ToString(string Name, int Value)
    {
        if (New())
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

    public void ToString(string Name, bool Value)
    {
        if (New())
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

    public void ToString(string Name, DateTime Value)
    {
        if (New())
        {
            if (Value==null || DateTime.MinValue == Value)
            {
                _Sql = _Sql + Name + ",";
                _Sql2 = _Sql2 + "null,";
            }
            else
            {
                _Sql = _Sql + Name + ",";
                _Sql2 = _Sql2 + "'" + Value.ToString() + "',";
            }
        }
        else
        {
            if (DateTime.MinValue == Value)
            {
                _Sql = _Sql + Name + "=null,";
            }
            else
            {
                _Sql = _Sql + Name + "='" + Value + "',";
            }
        }
    }

    #endregion

    #region 单表则直接更新
    public string ReturnSql()
    {
        if (_isNew == true)
        {
            if (_Name2 != "")
            {
                _Sql = "insert into " + _Table + "(" + _Name + "," + _Name2 + "," + _Sql.Substring(0, _Sql.Length - 1) + ") values('" + _ID + "','" + _ID2 + "'," + _Sql2.Substring(0, _Sql2.Length - 1) + ")";
            }
            else
            {
                _Sql = "insert into " + _Table + "(" + _Name + "," + _Sql.Substring(0, _Sql.Length - 1) + ") values('" + _ID + "'," + _Sql2.Substring(0, _Sql2.Length - 1) + ")";
            }
        }
        else
        {
            if (_Name2 != "")
            {
                _Sql = "update " + _Table + " set " + _Sql.Substring(0, _Sql.Length - 1) + " where " + _Name + "='" + _ID + "' and " + _Name2 + "='" + _ID2 + "'";
            }
            else
            {
                _Sql = "update " + _Table + " set " + _Sql.Substring(0, _Sql.Length - 1) + " where " + _Name + "='" + _ID + "'";
            }
        }
        return _Sql;

    }
    #endregion


}

