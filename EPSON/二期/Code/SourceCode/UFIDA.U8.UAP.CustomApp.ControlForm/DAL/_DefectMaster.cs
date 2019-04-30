using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_DefectMaster
    /// </summary>
    public partial class _DefectMaster
    {
        public _DefectMaster()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._DefectMaster model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.DefectCode != null)
            {
                strSql1.Append("DefectCode,");
                strSql2.Append("'" + model.DefectCode + "',");
            }
            if (model.DefectName != null)
            {
                strSql1.Append("DefectName,");
                strSql2.Append("'" + model.DefectName + "',");
            }
            strSql.Append("insert into _DefectMaster(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._DefectMaster model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _DefectMaster set ");
            if (model.DefectName != null)
            {
                strSql.Append("DefectName='" + model.DefectName + "',");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where DefectID=" + model.DefectID + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int DefectID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _DefectMaster ");
            strSql.Append(" where DefectID=" + DefectID + " ");
            return (strSql.ToString());
        }		
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

