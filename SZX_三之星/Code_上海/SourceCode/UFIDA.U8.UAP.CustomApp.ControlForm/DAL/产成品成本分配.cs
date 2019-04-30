using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_产品成本分配
    /// </summary>
    public partial class _产品成本分配
    {
        public _产品成本分配()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string 会计期间, string 存货编码)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _产品成本分配");
            strSql.Append(" where 会计期间='" + 会计期间 + "' and 存货编码='" + 存货编码 + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._产品成本分配 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.会计期间 != null)
            {
                strSql1.Append("会计期间,");
                strSql2.Append("'" + model.会计期间 + "',");
            }
            if (model.存货分类 != null)
            {
                strSql1.Append("存货分类,");
                strSql2.Append("'" + model.存货分类 + "',");
            }
            if (model.差异Sum != null)
            {
                strSql1.Append("差异Sum,");
                strSql2.Append("" + model.差异Sum + ",");
            }
            if (model.间接原价Sum != null)
            {
                strSql1.Append("间接原价Sum,");
                strSql2.Append("" + model.间接原价Sum + ",");
            }
            if (model.存货编码 != null)
            {
                strSql1.Append("存货编码,");
                strSql2.Append("'" + model.存货编码 + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.原价 != null)
            {
                strSql1.Append("原价,");
                strSql2.Append("" + model.原价 + ",");
            }
            if (model.标准 != null)
            {
                strSql1.Append("标准,");
                strSql2.Append("" + model.标准 + ",");
            }
            if (model.差异 != null)
            {
                strSql1.Append("差异,");
                strSql2.Append("" + model.差异 + ",");
            }
            if (model.间接原价 != null)
            {
                strSql1.Append("间接原价,");
                strSql2.Append("" + model.间接原价 + ",");
            }
            if (model.实际成本 != null)
            {
                strSql1.Append("实际成本,");
                strSql2.Append("" + model.实际成本 + ",");
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
            strSql.Append("insert into _产品成本分配(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());

        }

	
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string 会计期间, string 存货编码)
        {
            string strSql = "delete from _产品成本分配  where 会计期间='aaaaaa' and 存货编码='bbbbbb'";
            strSql = strSql.Replace("aaaaaa", 会计期间);
            strSql = strSql.Replace("bbbbbb", 存货编码);
            return strSql;
        }
      
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

