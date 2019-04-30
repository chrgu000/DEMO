using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:SO_SODetails_extradefine
    /// </summary>
    public partial class SO_SODetails_extradefine
    {
        public SO_SODetails_extradefine()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(long iSOsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select iSOsID from SO_SODetails_extradefine");
            strSql.Append(" where iSOsID=" + iSOsID + " ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model.SO_SODetails_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.iSOsID != null)
            {
                strSql1.Append("iSOsID,");
                strSql2.Append("" + model.iSOsID + ",");
            }
            if (model.cbdefine1 != null)
            {
                strSql1.Append("cbdefine1,");
                strSql2.Append("'" + model.cbdefine1 + "',");
            }
            if (model.cbdefine2 != null)
            {
                strSql1.Append("cbdefine2,");
                strSql2.Append("'" + model.cbdefine2 + "',");
            }
            if (model.cbdefine3 != null)
            {
                strSql1.Append("cbdefine3,");
                strSql2.Append("'" + model.cbdefine3 + "',");
            }
            if (model.cbdefine4 != null)
            {
                strSql1.Append("cbdefine4,");
                strSql2.Append("" + model.cbdefine4 + ",");
            }
            if (model.cbdefine5 != null)
            {
                strSql1.Append("cbdefine5,");
                strSql2.Append("'" + model.cbdefine5 + "',");
            }
            if (model.cbdefine6 != null)
            {
                strSql1.Append("cbdefine6,");
                strSql2.Append("'" + model.cbdefine6 + "',");
            }
            if (model.cbdefine7 != null)
            {
                strSql1.Append("cbdefine7,");
                strSql2.Append("'" + model.cbdefine7 + "',");
            }
            if (model.cbdefine8 != null)
            {
                strSql1.Append("cbdefine8,");
                strSql2.Append("'" + model.cbdefine8 + "',");
            }
            if (model.cbdefine9 != null)
            {
                strSql1.Append("cbdefine9,");
                strSql2.Append("'" + model.cbdefine9 + "',");
            }
            if (model.cbdefine10 != null)
            {
                strSql1.Append("cbdefine10,");
                strSql2.Append("'" + model.cbdefine10 + "',");
            }
            strSql.Append("insert into SO_SODetails_extradefine(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model.SO_SODetails_extradefine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SO_SODetails_extradefine set ");
            if (model.cbdefine1 != null)
            {
                strSql.Append("cbdefine1='" + model.cbdefine1 + "',");
            }
            else
            {
                strSql.Append("cbdefine1= null ,");
            }
            if (model.cbdefine2 != null)
            {
                strSql.Append("cbdefine2='" + model.cbdefine2 + "',");
            }
            else
            {
                strSql.Append("cbdefine2= null ,");
            }
            if (model.cbdefine3 != null)
            {
                strSql.Append("cbdefine3='" + model.cbdefine3 + "',");
            }
            else
            {
                strSql.Append("cbdefine3= null ,");
            }
            if (model.cbdefine4 != null)
            {
                strSql.Append("cbdefine4=" + model.cbdefine4 + ",");
            }
            else
            {
                strSql.Append("cbdefine4= null ,");
            }
            if (model.cbdefine5 != null)
            {
                strSql.Append("cbdefine5='" + model.cbdefine5 + "',");
            }
            else
            {
                strSql.Append("cbdefine5= null ,");
            }
            if (model.cbdefine6 != null)
            {
                strSql.Append("cbdefine6='" + model.cbdefine6 + "',");
            }
            else
            {
                strSql.Append("cbdefine6= null ,");
            }
            if (model.cbdefine7 != null)
            {
                strSql.Append("cbdefine7='" + model.cbdefine7 + "',");
            }
            else
            {
                strSql.Append("cbdefine7= null ,");
            }
            if (model.cbdefine8 != null)
            {
                strSql.Append("cbdefine8='" + model.cbdefine8 + "',");
            }
            else
            {
                strSql.Append("cbdefine8= null ,");
            }
            if (model.cbdefine9 != null)
            {
                strSql.Append("cbdefine9='" + model.cbdefine9 + "',");
            }
            else
            {
                strSql.Append("cbdefine9= null ,");
            }
            if (model.cbdefine10 != null)
            {
                strSql.Append("cbdefine10='" + model.cbdefine10 + "',");
            }
            else
            {
                strSql.Append("cbdefine10= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iSOsID=" + model.iSOsID + " ");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

