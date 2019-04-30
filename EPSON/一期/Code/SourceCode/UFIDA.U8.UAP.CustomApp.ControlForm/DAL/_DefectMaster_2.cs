using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_DefectMaster_2
    /// </summary>
    public partial class _DefectMaster_2
    {
        public _DefectMaster_2()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._DefectMaster_2 model)
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
            strSql.Append("insert into _DefectMaster_2(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._DefectMaster_2 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _DefectMaster_2 set ");
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
            strSql.Append("delete from _DefectMaster_2 ");
            strSql.Append(" where DefectID=" + DefectID + " ");
            return (strSql.ToString());
        }		
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

