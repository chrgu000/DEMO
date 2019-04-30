using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_ProcessList
    /// </summary>
    public partial class ProcessList
    {
        public ProcessList()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _ProcessList");
            strSql.Append(" where iID=" + iID + " ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Model.ProcessList model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.Status != null)
            {
                strSql1.Append("Status,");
                strSql2.Append("'" + model.Status + "',");
            }
            if (model.ProcessCode != null)
            {
                strSql1.Append("ProcessCode,");
                strSql2.Append("'" + model.ProcessCode + "',");
            }
            if (model.Seq != null)
            {
                strSql1.Append("Seq,");
                strSql2.Append("'" + model.Seq + "',");
            }
            if (model.PlatingProcess != null)
            {
                strSql1.Append("PlatingProcess,");
                strSql2.Append("'" + model.PlatingProcess + "',");
            }
            if (model.Condition != null)
            {
                strSql1.Append("Condition,");
                strSql2.Append("'" + model.Condition + "',");
            }
            if (model.Thichness != null)
            {
                strSql1.Append("Thichness,");
                strSql2.Append("'" + model.Thichness + "',");
            }
            if (model.Time != null)
            {
                strSql1.Append("Time,");
                strSql2.Append("'" + model.Time + "',");
            }
            if (model.Density != null)
            {
                strSql1.Append("Density,");
                strSql2.Append("" + model.Density + ",");
            }
            if (model.AMP != null)
            {
                strSql1.Append("AMP,");
                strSql2.Append("" + model.AMP + ",");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("'" + model.UpdateDate + "',");
            }
            if (model.Updatedby != null)
            {
                strSql1.Append("Updatedby,");
                strSql2.Append("'" + model.Updatedby + "',");
            }
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
            }
            strSql.Append("insert into _ProcessList(");
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
        public string Update(Model.ProcessList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _ProcessList set ");
            if (model.Status != null)
            {
                strSql.Append("Status='" + model.Status + "',");
            }
            else
            {
                strSql.Append("Status= null ,");
            }
            if (model.ProcessCode != null)
            {
                strSql.Append("ProcessCode='" + model.ProcessCode + "',");
            }
            if (model.Seq != null)
            {
                strSql.Append("Seq='" + model.Seq + "',");
            }
            else
            {
                strSql.Append("Seq= null ,");
            }
            if (model.PlatingProcess != null)
            {
                strSql.Append("PlatingProcess='" + model.PlatingProcess + "',");
            }
            else
            {
                strSql.Append("PlatingProcess= null ,");
            }
            if (model.Condition != null)
            {
                strSql.Append("Condition='" + model.Condition + "',");
            }
            else
            {
                strSql.Append("Condition= null ,");
            }
            if (model.Thichness != null)
            {
                strSql.Append("Thichness='" + model.Thichness + "',");
            }
            else
            {
                strSql.Append("Thichness= null ,");
            }
            if (model.Time != null)
            {
                strSql.Append("Time='" + model.Time + "',");
            }
            else
            {
                strSql.Append("Time= null ,");
            }
            if (model.Density != null)
            {
                strSql.Append("Density=" + model.Density + ",");
            }
            else
            {
                strSql.Append("Density= null ,");
            }
            if (model.AMP != null)
            {
                strSql.Append("AMP=" + model.AMP + ",");
            }
            else
            {
                strSql.Append("AMP= null ,");
            }
            if (model.UpdateDate != null)
            {
                strSql.Append("UpdateDate='" + model.UpdateDate + "',");
            }
            else
            {
                strSql.Append("UpdateDate= null ,");
            }
            if (model.Updatedby != null)
            {
                strSql.Append("Updatedby='" + model.Updatedby + "',");
            }
            else
            {
                strSql.Append("Updatedby= null ,");
            }
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _ProcessList ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());

        }		

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

