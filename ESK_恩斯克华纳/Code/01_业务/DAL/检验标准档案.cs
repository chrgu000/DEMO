using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 业务.DAL
{
    /// <summary>
    /// 数据访问类:检验标准档案
    /// </summary>
    public partial class 检验标准档案
    {
        public 检验标准档案()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(业务.Model.检验标准档案 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.发射器ID != null)
            {
                strSql1.Append("发射器ID,");
                strSql2.Append("" + model.发射器ID + ",");
            }
            if (model.量具品名 != null)
            {
                strSql1.Append("量具品名,");
                strSql2.Append("'" + model.量具品名 + "',");
            }
            if (model.测定项目 != null)
            {
                strSql1.Append("测定项目,");
                strSql2.Append("'" + model.测定项目 + "',");
            }
            if (model.规格 != null)
            {
                strSql1.Append("规格,");
                strSql2.Append("'" + model.规格 + "',");
            }
            if (model.测定项目日文 != null)
            {
                strSql1.Append("测定项目日文,");
                strSql2.Append("N'" + model.测定项目日文 + "',");
            }
            if (model.尺寸公差 != null)
            {
                strSql1.Append("尺寸公差,");
                strSql2.Append("'" + model.尺寸公差 + "',");
            }
            if (model.下限 != null)
            {
                strSql1.Append("下限,");
                strSql2.Append("" + model.下限 + ",");
            }
            if (model.上限 != null)
            {
                strSql1.Append("上限,");
                strSql2.Append("" + model.上限 + ",");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
            }
            strSql.Append("insert into 检验标准档案(");
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
        public string Update(业务.Model.检验标准档案 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 检验标准档案 set ");
            if (model.发射器ID != null)
            {
                strSql.Append("发射器ID=" + model.发射器ID + ",");
            }
            else
            {
                strSql.Append("发射器ID= null ,");
            }
            if (model.量具品名 != null)
            {
                strSql.Append("量具品名='" + model.量具品名 + "',");
            }
            else
            {
                strSql.Append("量具品名= null ,");
            }
            if (model.测定项目 != null)
            {
                strSql.Append("测定项目='" + model.测定项目 + "',");
            }
            else
            {
                strSql.Append("测定项目= null ,");
            }


            if (model.规格 != null)
            {
                strSql.Append("规格='" + model.规格 + "',");
            }
            else
            {
                strSql.Append("规格= null ,");
            }
            if (model.测定项目日文 != null)
            {
                strSql.Append("测定项目日文=N'" + model.测定项目日文 + "',");
            }
            else
            {
                strSql.Append("测定项目日文= null ,");
            }
            if (model.尺寸公差 != null)
            {
                strSql.Append("尺寸公差='" + model.尺寸公差 + "',");
            }
            else
            {
                strSql.Append("尺寸公差= null ,");
            }
            if (model.下限 != null)
            {
                strSql.Append("下限=" + model.下限 + ",");
            }
            else
            {
                strSql.Append("下限= null ,");
            }
            if (model.上限 != null)
            {
                strSql.Append("上限=" + model.上限 + ",");
            }
            else
            {
                strSql.Append("上限= null ,");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
           return  (strSql.ToString());
 
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 检验标准档案 ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());

        }		
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

