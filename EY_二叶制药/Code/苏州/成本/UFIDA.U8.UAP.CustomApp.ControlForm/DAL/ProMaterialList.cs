using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_ProMaterial
    /// </summary>
    public partial class _ProMaterial
    {
        public _ProMaterial()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProMaterial model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.会计期间 != null)
            {
                strSql1.Append("会计期间,");
                strSql2.Append("'" + model.会计期间 + "',");
            }
            if (model.部门 != null)
            {
                strSql1.Append("部门,");
                strSql2.Append("'" + model.部门 + "',");
            }
            if (model.产品编码 != null)
            {
                strSql1.Append("产品编码,");
                strSql2.Append("'" + model.产品编码 + "',");
            }
            if (model.存货编码 != null)
            {
                strSql1.Append("存货编码,");
                strSql2.Append("'" + model.存货编码 + "',");
            }
            if (model.工时 != null)
            {
                strSql1.Append("工时,");
                strSql2.Append("" + model.工时 + ",");
            }
            if (model.未完工工时 != null)
            {
                strSql1.Append("未完工工时,");
                strSql2.Append("" + model.未完工工时 + ",");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("'" + model.数量 + "',");
            }
            if (model.制单人 != null)
            {
                strSql1.Append("制单人,");
                strSql2.Append("'" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql1.Append("制单日期,");
                strSql2.Append("'" + model.制单日期 + "',");
            }
            if (model.审核人 != null)
            {
                strSql1.Append("审核人,");
                strSql2.Append("'" + model.审核人 + "',");
            }
            if (model.审核日期 != null)
            {
                strSql1.Append("审核日期,");
                strSql2.Append("'" + model.审核日期 + "',");
            }
            if (model.冻干完工工时 != null)
            {
                strSql1.Append("冻干完工工时,");
                strSql2.Append("" + model.冻干完工工时 + ",");
            }
            if (model.冻干未完工工时 != null)
            {
                strSql1.Append("冻干未完工工时,");
                strSql2.Append("" + model.冻干未完工工时 + ",");
            }
            strSql.Append("insert into _ProMaterial(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return strSql.ToString();
        }

      

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(UFIDA.U8.UAP.CustomApp.ControlForm.Model._ProMaterial model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _ProMaterial ");
            strSql.Append(" where 会计期间='" + model.会计期间 + "' and 部门='" + model.部门 + "' and 产品编码='" + model.产品编码 + "'  ");
            return strSql.ToString();
           
        }
    }
}

