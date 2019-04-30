using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_Process
    /// </summary>
    public partial class _Process
    {
        public _Process()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Process model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ProcessNo != null)
            {
                strSql1.Append("ProcessNo,");
                strSql2.Append("'" + model.ProcessNo + "',");
            }
            if (model.Process != null)
            {
                strSql1.Append("Process,");
                strSql2.Append("'" + model.Process + "',");
            }
            if (model.Condition != null)
            {
                strSql1.Append("Condition,");
                strSql2.Append("'" + model.Condition + "',");
            }
            if (model.PLATINGSPEC != null)
            {
                strSql1.Append("PLATINGSPEC,");
                strSql2.Append("'" + model.PLATINGSPEC + "',");
            }
            if (model.THICKNESS != null)
            {
                strSql1.Append("THICKNESS,");
                strSql2.Append("'" + model.THICKNESS + "',");
            }
            if (model.TIME != null)
            {
                strSql1.Append("TIME,");
                strSql2.Append("" + model.TIME + ",");
            }
            if (model.AMPHRS != null)
            {
                strSql1.Append("AMPHRS,");
                strSql2.Append("'" + model.AMPHRS + "',");
            }
            if (model.cWhCode != null)
            {
                strSql1.Append("cWhCode,");
                strSql2.Append("'" + model.cWhCode + "',");
            }
            if (model.Price != null)
            {
                strSql1.Append("Price,");
                strSql2.Append("" + model.Price + ",");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            if (model.CreateUid != null)
            {
                strSql1.Append("CreateUid,");
                strSql2.Append("'" + model.CreateUid + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            strSql.Append("insert into _Process(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._Process model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _Process set ");
            if (model.Process != null)
            {
                strSql.Append("Process='" + model.Process + "',");
            }
            else
            {
                strSql.Append("Process= null ,");
            }
            if (model.Condition != null)
            {
                strSql.Append("Condition='" + model.Condition + "',");
            }
            else
            {
                strSql.Append("Condition= null ,");
            }
            if (model.PLATINGSPEC != null)
            {
                strSql.Append("PLATINGSPEC='" + model.PLATINGSPEC + "',");
            }
            else
            {
                strSql.Append("PLATINGSPEC= null ,");
            }
            if (model.THICKNESS != null)
            {
                strSql.Append("THICKNESS='" + model.THICKNESS + "',");
            }
            else
            {
                strSql.Append("THICKNESS= null ,");
            }
            if (model.TIME != null)
            {
                strSql.Append("TIME=" + model.TIME + ",");
            }
            else
            {
                strSql.Append("TIME= null ,");
            }
            if (model.AMPHRS != null)
            {
                strSql.Append("AMPHRS='" + model.AMPHRS + "',");
            }
            else
            {
                strSql.Append("AMPHRS= null ,");
            }
            if (model.cWhCode != null)
            {
                strSql.Append("cWhCode='" + model.cWhCode + "',");
            }
            else
            {
                strSql.Append("cWhCode= null ,");
            }
            if (model.Price != null)
            {
                strSql.Append("Price=" + model.Price + ",");
            }
            else
            {
                strSql.Append("Price= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            if (model.CreateUid != null)
            {
                strSql.Append("CreateUid='" + model.CreateUid + "',");
            }
            else
            {
                strSql.Append("CreateUid= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string ProcessNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _Process ");
            strSql.Append(" where ProcessNo='" + ProcessNo + "' ");
            return (strSql.ToString());
        }		

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

