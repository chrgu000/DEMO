using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_AQLSampleSizeMap
    /// </summary>
    public partial class _AQLSampleSizeMap
    {
        public _AQLSampleSizeMap()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._AQLSampleSizeMap model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.CodeLetter != null)
            {
                strSql1.Append("CodeLetter,");
                strSql2.Append("'" + model.CodeLetter + "',");
            }
            if (model.SampleSize != null)
            {
                strSql1.Append("SampleSize,");
                strSql2.Append("" + model.SampleSize + ",");
            }
            strSql.Append("insert into _AQLSampleSizeMap(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._AQLSampleSizeMap model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _AQLSampleSizeMap set ");
            if (model.SampleSize != null)
            {
                strSql.Append("SampleSize=" + model.SampleSize + ",");
            }
            else
            {
                strSql.Append("SampleSize= null ,");
            }
            if (model.CodeLetter != null)
            {
                strSql.Append("CodeLetter='" + model.CodeLetter + "',");
            }
            else
            {
                strSql.Append("CodeLetter= null ,");
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
            strSql.Append("delete from _AQLSampleSizeMap ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());

        }		
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string CodeLetter)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _AQLSampleSizeMap ");
            strSql.Append(" where CodeLetter='" + CodeLetter + "' ");
            return strSql.ToString();
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

