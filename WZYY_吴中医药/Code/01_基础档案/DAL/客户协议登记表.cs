using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 基础设置.DAL
{
    /// <summary>
    /// 数据访问类:客户协议登记表
    /// </summary>
    public partial class 客户协议登记表
    {
        public 客户协议登记表()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(int iYear, string 代理商)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 客户协议登记表");
            strSql.Append(" where iYear=" + iYear + " and 代理商='" + 代理商 + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(基础设置.Model.客户协议登记表 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.GUID != null)
            {
                strSql1.Append("GUID,");
                strSql2.Append("'" + model.GUID + "',");
            }
            if (model.iYear != null)
            {
                strSql1.Append("iYear,");
                strSql2.Append("" + model.iYear + ",");
            }
            if (model.业务员 != null)
            {
                strSql1.Append("业务员,");
                strSql2.Append("'" + model.业务员 + "',");
            }
            if (model.代理商 != null)
            {
                strSql1.Append("代理商,");
                strSql2.Append("'" + model.代理商 + "',");
            }
            if (model.dDate1 != null)
            {
                strSql1.Append("dDate1,");
                strSql2.Append("'" + model.dDate1 + "',");
            }
            if (model.dDate2 != null)
            {
                strSql1.Append("dDate2,");
                strSql2.Append("'" + model.dDate2 + "',");
            }
            if (model.返点方式 != null)
            {
                strSql1.Append("返点方式,");
                strSql2.Append("'" + model.返点方式 + "',");
            }
            if (model.或有条款 != null)
            {
                strSql1.Append("或有条款,");
                strSql2.Append("'" + model.或有条款 + "',");
            }
            if (model.是否有纸质合同 != null)
            {
                strSql1.Append("是否有纸质合同,");
                strSql2.Append("'" + model.是否有纸质合同 + "',");
            }
            if (model.品种 != null)
            {
                strSql1.Append("品种,");
                strSql2.Append("'" + model.品种 + "',");
            }
            if (model.底价 != null)
            {
                strSql1.Append("底价,");
                strSql2.Append("" + model.底价 + ",");
            }
            if (model.协议销量 != null)
            {
                strSql1.Append("协议销量,");
                strSql2.Append("" + model.协议销量 + ",");
            }
            if (model.保证金 != null)
            {
                strSql1.Append("保证金,");
                strSql2.Append("" + model.保证金 + ",");
            }
            if (model.M1 != null)
            {
                strSql1.Append("M1,");
                strSql2.Append("" + model.M1 + ",");
            }
            if (model.M2 != null)
            {
                strSql1.Append("M2,");
                strSql2.Append("" + model.M2 + ",");
            }
            if (model.M3 != null)
            {
                strSql1.Append("M3,");
                strSql2.Append("" + model.M3 + ",");
            }
            if (model.M4 != null)
            {
                strSql1.Append("M4,");
                strSql2.Append("" + model.M4 + ",");
            }
            if (model.M5 != null)
            {
                strSql1.Append("M5,");
                strSql2.Append("" + model.M5 + ",");
            }
            if (model.M6 != null)
            {
                strSql1.Append("M6,");
                strSql2.Append("" + model.M6 + ",");
            }
            if (model.M7 != null)
            {
                strSql1.Append("M7,");
                strSql2.Append("" + model.M7 + ",");
            }
            if (model.M8 != null)
            {
                strSql1.Append("M8,");
                strSql2.Append("" + model.M8 + ",");
            }
            if (model.M9 != null)
            {
                strSql1.Append("M9,");
                strSql2.Append("" + model.M9 + ",");
            }
            if (model.M10 != null)
            {
                strSql1.Append("M10,");
                strSql2.Append("" + model.M10 + ",");
            }
            if (model.M11 != null)
            {
                strSql1.Append("M11,");
                strSql2.Append("" + model.M11 + ",");
            }
            if (model.M12 != null)
            {
                strSql1.Append("M12,");
                strSql2.Append("" + model.M12 + ",");
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
            if (model.AuditUid != null)
            {
                strSql1.Append("AuditUid,");
                strSql2.Append("'" + model.AuditUid + "',");
            }
            if (model.AuditDate != null)
            {
                strSql1.Append("AuditDate,");
                strSql2.Append("'" + model.AuditDate + "',");
            }
            if (model.开票客户 != null)
            {
                strSql1.Append("开票客户,");
                strSql2.Append("'" + model.开票客户 + "',");
            }
            strSql.Append("insert into 客户协议登记表(");
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
        public string Update(基础设置.Model.客户协议登记表 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 客户协议登记表 set ");
            if (model.dDate1 != null)
            {
                strSql.Append("dDate1='" + model.dDate1 + "',");
            }
            else
            {
                strSql.Append("dDate1= null ,");
            }

             if (model.业务员 != null)
            {
                strSql.Append("业务员='" + model.业务员 + "',");
            }
            else
            {
                strSql.Append("业务员= null ,");
            }
           

            if (model.dDate2 != null)
            {
                strSql.Append("dDate2='" + model.dDate2 + "',");
            }
            else
            {
                strSql.Append("dDate2= null ,");
            }
            if (model.返点方式 != null)
            {
                strSql.Append("返点方式='" + model.返点方式 + "',");
            }
            else
            {
                strSql.Append("返点方式= null ,");
            }
            if (model.品种 != null)
            {
                strSql.Append("品种='" + model.品种 + "',");
            }
            else
            {
                strSql.Append("品种= null ,");
            }
            if (model.底价 != null)
            {
                strSql.Append("底价=" + model.底价 + ",");
            }
            else
            {
                strSql.Append("底价= null ,");
            }
            if (model.协议销量 != null)
            {
                strSql.Append("协议销量=" + model.协议销量 + ",");
            }
            else
            {
                strSql.Append("协议销量= null ,");
            }
            if (model.保证金 != null)
            {
                strSql.Append("保证金=" + model.保证金 + ",");
            }
            else
            {
                strSql.Append("保证金= null ,");
            }
            if (model.M1 != null)
            {
                strSql.Append("M1=" + model.M1 + ",");
            }
            else
            {
                strSql.Append("M1= null ,");
            }
            if (model.M2 != null)
            {
                strSql.Append("M2=" + model.M2 + ",");
            }
            else
            {
                strSql.Append("M2= null ,");
            }
            if (model.M3 != null)
            {
                strSql.Append("M3=" + model.M3 + ",");
            }
            else
            {
                strSql.Append("M3= null ,");
            }
            if (model.M4 != null)
            {
                strSql.Append("M4=" + model.M4 + ",");
            }
            else
            {
                strSql.Append("M4= null ,");
            }
            if (model.M5 != null)
            {
                strSql.Append("M5=" + model.M5 + ",");
            }
            else
            {
                strSql.Append("M5= null ,");
            }
            if (model.M6 != null)
            {
                strSql.Append("M6=" + model.M6 + ",");
            }
            else
            {
                strSql.Append("M6= null ,");
            }
            if (model.M7 != null)
            {
                strSql.Append("M7=" + model.M7 + ",");
            }
            else
            {
                strSql.Append("M7= null ,");
            }
            if (model.M8 != null)
            {
                strSql.Append("M8=" + model.M8 + ",");
            }
            else
            {
                strSql.Append("M8= null ,");
            }
            if (model.M9 != null)
            {
                strSql.Append("M9=" + model.M9 + ",");
            }
            else
            {
                strSql.Append("M9= null ,");
            }
            if (model.M10 != null)
            {
                strSql.Append("M10=" + model.M10 + ",");
            }
            else
            {
                strSql.Append("M10= null ,");
            }
            if (model.M11 != null)
            {
                strSql.Append("M11=" + model.M11 + ",");
            }
            else
            {
                strSql.Append("M11= null ,");
            }
            if (model.M12 != null)
            {
                strSql.Append("M12=" + model.M12 + ",");
            }
            else
            {
                strSql.Append("M12= null ,");
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
            if (model.AuditUid != null)
            {
                strSql.Append("AuditUid='" + model.AuditUid + "',");
            }
            else
            {
                strSql.Append("AuditUid= null ,");
            }
            if (model.AuditDate != null)
            {
                strSql.Append("AuditDate='" + model.AuditDate + "',");
            }
            else
            {
                strSql.Append("AuditDate= null ,");
            }
            if (model.开票客户 != null)
            {
                strSql.Append("cCusCode='" + model.开票客户 + "',");
            }
            else
            {
                strSql.Append("cCusCode= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

		/// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(int iYear, string 代理商)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 客户协议登记表 ");
            strSql.Append(" where iYear=@iYear and 代理商=@代理商 ");
            SqlParameter[] parameters = {
					new SqlParameter("@iYear", SqlDbType.Int,4),
					new SqlParameter("@代理商", SqlDbType.NVarChar,-1)};
            parameters[0].Value = iYear;
            parameters[1].Value = 代理商;

            return (strSql.ToString());
        }
       

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

