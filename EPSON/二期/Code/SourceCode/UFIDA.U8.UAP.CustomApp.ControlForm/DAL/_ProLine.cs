using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_ProLine
    /// </summary>
    public partial class _ProLine
    {
        public _ProLine()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string cCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _ProLine");
            strSql.Append(" where cCode='" + cCode + "' ");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProLine model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.cCode != null)
            {
                strSql1.Append("cCode,");
                strSql2.Append("'" + model.cCode + "',");
            }
            if (model.cName != null)
            {
                strSql1.Append("cName,");
                strSql2.Append("'" + model.cName + "',");
            }
            if (model.Remark1 != null)
            {
                strSql1.Append("Remark1,");
                strSql2.Append("'" + model.Remark1 + "',");
            }
            if (model.Remark2 != null)
            {
                strSql1.Append("Remark2,");
                strSql2.Append("'" + model.Remark2 + "',");
            }
            if (model.Remark3 != null)
            {
                strSql1.Append("Remark3,");
                strSql2.Append("'" + model.Remark3 + "',");
            }
            if (model.Remark4 != null)
            {
                strSql1.Append("Remark4,");
                strSql2.Append("'" + model.Remark4 + "',");
            }
            if (model.Remark5 != null)
            {
                strSql1.Append("Remark5,");
                strSql2.Append("'" + model.Remark5 + "',");
            }
            if (model.Creater != null)
            {
                strSql1.Append("Creater,");
                strSql2.Append("'" + model.Creater + "',");
            }
            if (model.CreateDate != null)
            {
                strSql1.Append("CreateDate,");
                strSql2.Append("'" + model.CreateDate + "',");
            }
            if (model.UpdateUid != null)
            {
                strSql1.Append("UpdateUid,");
                strSql2.Append("'" + model.UpdateUid + "',");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("'" + model.UpdateDate + "',");
            }
            strSql.Append("insert into _ProLine(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _ProLine set ");
            if (model.cName != null)
            {
                strSql.Append("cName='" + model.cName + "',");
            }
            else
            {
                strSql.Append("cName= null ,");
            }
            if (model.Remark1 != null)
            {
                strSql.Append("Remark1='" + model.Remark1 + "',");
            }
            else
            {
                strSql.Append("Remark1= null ,");
            }
            if (model.Remark2 != null)
            {
                strSql.Append("Remark2='" + model.Remark2 + "',");
            }
            else
            {
                strSql.Append("Remark2= null ,");
            }
            if (model.Remark3 != null)
            {
                strSql.Append("Remark3='" + model.Remark3 + "',");
            }
            else
            {
                strSql.Append("Remark3= null ,");
            }
            if (model.Remark4 != null)
            {
                strSql.Append("Remark4='" + model.Remark4 + "',");
            }
            else
            {
                strSql.Append("Remark4= null ,");
            }
            if (model.Remark5 != null)
            {
                strSql.Append("Remark5='" + model.Remark5 + "',");
            }
            else
            {
                strSql.Append("Remark5= null ,");
            }
            if (model.Creater != null)
            {
                strSql.Append("Creater='" + model.Creater + "',");
            }
            else
            {
                strSql.Append("Creater= null ,");
            }
            if (model.CreateDate != null)
            {
                strSql.Append("CreateDate='" + model.CreateDate + "',");
            }
            else
            {
                strSql.Append("CreateDate= null ,");
            }
            if (model.UpdateUid != null)
            {
                strSql.Append("UpdateUid='" + model.UpdateUid + "',");
            }
            else
            {
                strSql.Append("UpdateUid= null ,");
            }
            if (model.UpdateDate != null)
            {
                strSql.Append("UpdateDate='" + model.UpdateDate + "',");
            }
            else
            {
                strSql.Append("UpdateDate= null ,");
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
            strSql.Append("delete from _ProLine ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }		
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string cCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _ProLine ");
            strSql.Append(" where cCode='" + cCode + "'");
            return (strSql.ToString());
        }	

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

