using System;
using System.Data;
using System.Configuration;
using System.Collections;

namespace UFIDA.U8.UAP.CustomApp.ControlForm
{
    /// <summary>
    /// SqlClass 的摘要说明
    /// </summary>
    public class SqlClass
    {
        private string _Table;
        private string _Name;
        private string _ID;
        private string _Sql;
        private string _Sql2;

        private bool _isnew;

        public SqlClass()
        {
            _Table = "";
            _Name = "";
            _Sql = "";
            _Sql2 = "";
        }

        public void InsertSql(string Table)
        {
            _Table = Table;
            _isnew = true;
        }

        public void UpdateSql(string Table, string Name, string ID)
        {
            _Table = Table;
            _Name = Name;
            _ID = ID;
            _isnew = false;
        }

        public string ID
        {
            get { return _ID; }
        }

        public bool IsNew()
        {
            return _isnew;
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

        public void ToString(string Name, long Value)
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

        public void ToString(string Name, object Value)
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
                    _Sql = _Sql + Name + "='" + Value.ToString() + "',";
                }
            }
        }

        #region 多表返回Sql后通过SqlTransaction更新
        public string ReturnSql()
        {
            if (_isnew == true)
            {
                _Sql = "insert into " + _Table + "(" + _Sql.Substring(0, _Sql.Length - 1) + ") values(" + _Sql2.Substring(0, _Sql2.Length - 1) + ")";
            }
            else
            {
                _Sql = "update " + _Table + " set " + _Sql.Substring(0, _Sql.Length - 1) + " where " + _Name + "='" + _ID + "'";
            }
            return _Sql;
        }
        #endregion


    }

}