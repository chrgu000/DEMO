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
    private string _Sql;
    private string _Sql2;
    private bool _isNew = true;
    private bool _hasID = true;

    public Sql()
    {
        _Table = "";
        _Name = "";
        _ID = "";
        _Sql = "";
        _Sql2 = "";
    }

    public void Get(string Table, string Name, string ID)
    {
        _Table = Table;
        _Name = Name;
        _ID = ID;
    }

    public void Get(string Table, string Name)
    {
        _Table = Table;
        _Name = Name;
    }

    public void Get(string Table, string Name, bool isNew)
    {
        _Table = Table;
        _Name = Name;
        _isNew = isNew;
    }

    public void Get(string Table)
    {
        _Table = Table;
        _hasID = false;
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

    public void ToString(string Name, long Value)
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

    public void ToString(string Name, DateTime Value)
    {
        if (New())
        {
            if (DateTime.MinValue == Value)
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

    #endregion

    //#region 单表则直接更新
    //public void Update()
    //{
    //    //try
    //    //{
    //    if (_hasID == true)
    //    {
    //        if (New())
    //        {
    //            if (_isNew == false)
    //            {
    //                _ID = SerialNumber.GetMaxInsertId(_Table).ToString();
    //                _Sql = "insert into " + _Table + "(" + _Name + "," + _Sql.Substring(0, _Sql.Length - 1) + ") values(" + _ID + "," + _Sql2.Substring(0, _Sql2.Length - 1) + ")";
    //            }
    //            else
    //            {
    //                _Sql = "insert into " + _Table + "(" + _Sql.Substring(0, _Sql.Length - 1) + ") values(" + _Sql2.Substring(0, _Sql2.Length - 1) + ")";
    //            }
    //        }
    //        else
    //        {
    //            _Sql = "update " + _Table + " set " + _Sql.Substring(0, _Sql.Length - 1) + " where " + _Name + "='" + _ID + "'";
    //        }

    //        Conn.Update(_Sql);
    //    }
    //    else
    //    {
    //        _Sql = "insert into " + _Table + "(" + _Sql.Substring(0, _Sql.Length - 1) + ") values(" + _Sql2.Substring(0, _Sql2.Length - 1) + ")";
    //        Conn.Update(_Sql);
    //    }
    //    //}
    //    //catch
    //    //{

    //    //}

    //}
    //#endregion

    #region 多表返回Sql后通过SqlTransaction更新
    public string InsertSql()
    {
        _Sql = "insert into " + _Table + "(" + _Sql.Substring(0, _Sql.Length - 1) + ") values(" + _Sql2.Substring(0, _Sql2.Length - 1) + ")";

        return _Sql;
    }
    #endregion

}

