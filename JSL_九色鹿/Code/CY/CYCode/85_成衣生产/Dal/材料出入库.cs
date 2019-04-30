using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 成衣生产.DAL
{
    /// <summary>
    /// 数据访问类:材料出入库
    /// </summary>
    public partial class 材料出入库
    {
        public 材料出入库()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(int iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 材料出入库");
            strSql.Append(" where iID=" + iID + " ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(成衣生产.Model.材料出入库 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.生产计划iID != null)
            {
                strSql1.Append("生产计划iID,");
                strSql2.Append("" + model.生产计划iID + ",");
            }
            if (model.单据号 != null)
            {
                strSql1.Append("单据号,");
                strSql2.Append("'" + model.单据号 + "',");
            }
            if (model.单据日期 != null)
            {
                strSql1.Append("单据日期,");
                strSql2.Append("'" + model.单据日期 + "',");
            }
            if (model.业务员 != null)
            {
                strSql1.Append("业务员,");
                strSql2.Append("'" + model.业务员 + "',");
            }
            if (model.类别 != null)
            {
                strSql1.Append("类别,");
                strSql2.Append("'" + model.类别 + "',");
            }
            if (model.出入库类别 != null)
            {
                strSql1.Append("出入库类别,");
                strSql2.Append("'" + model.出入库类别 + "',");
            }
            if (model.纱种 != null)
            {
                strSql1.Append("纱种,");
                strSql2.Append("'" + model.纱种 + "',");
            }
            if (model.色号 != null)
            {
                strSql1.Append("色号,");
                strSql2.Append("'" + model.色号 + "',");
            }
            if (model.缸号 != null)
            {
                strSql1.Append("缸号,");
                strSql2.Append("'" + model.缸号 + "',");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
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
            if (model.关闭人 != null)
            {
                strSql1.Append("关闭人,");
                strSql2.Append("'" + model.关闭人 + "',");
            }
            if (model.关闭日期 != null)
            {
                strSql1.Append("关闭日期,");
                strSql2.Append("'" + model.关闭日期 + "',");
            }
            if (model.变更人 != null)
            {
                strSql1.Append("变更人,");
                strSql2.Append("'" + model.变更人 + "',");
            }
            if (model.变更日期 != null)
            {
                strSql1.Append("变更日期,");
                strSql2.Append("'" + model.变更日期 + "',");
            }
            strSql.Append("insert into 材料出入库(");
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
        public string Update(成衣生产.Model.材料出入库 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 材料出入库 set ");
            if (model.生产计划iID != null)
            {
                strSql.Append("生产计划iID=" + model.生产计划iID + ",");
            }
            else
            {
                strSql.Append("生产计划iID= null ,");
            }
            if (model.单据号 != null)
            {
                strSql.Append("单据号='" + model.单据号 + "',");
            }
            if (model.单据日期 != null)
            {
                strSql.Append("单据日期='" + model.单据日期 + "',");
            }
            if (model.业务员 != null)
            {
                strSql.Append("业务员='" + model.业务员 + "',");
            }
            else
            {
                strSql.Append("业务员= null ,");
            }
            if (model.类别 != null)
            {
                strSql.Append("类别='" + model.类别 + "',");
            }
            else
            {
                strSql.Append("类别= null ,");
            }
            if (model.出入库类别 != null)
            {
                strSql.Append("出入库类别='" + model.出入库类别 + "',");
            }
            else
            {
                strSql.Append("出入库类别= null ,");
            }
            if (model.纱种 != null)
            {
                strSql.Append("纱种='" + model.纱种 + "',");
            }
            else
            {
                strSql.Append("纱种= null ,");
            }
            if (model.色号 != null)
            {
                strSql.Append("色号='" + model.色号 + "',");
            }
            else
            {
                strSql.Append("色号= null ,");
            }
            if (model.缸号 != null)
            {
                strSql.Append("缸号='" + model.缸号 + "',");
            }
            else
            {
                strSql.Append("缸号= null ,");
            }
            if (model.数量 != null)
            {
                strSql.Append("数量=" + model.数量 + ",");
            }
            else
            {
                strSql.Append("数量= null ,");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
            }
            if (model.制单人 != null)
            {
                strSql.Append("制单人='" + model.制单人 + "',");
            }
            if (model.制单日期 != null)
            {
                strSql.Append("制单日期='" + model.制单日期 + "',");
            }
            if (model.审核人 != null)
            {
                strSql.Append("审核人='" + model.审核人 + "',");
            }
            else
            {
                strSql.Append("审核人= null ,");
            }
            if (model.审核日期 != null)
            {
                strSql.Append("审核日期='" + model.审核日期 + "',");
            }
            else
            {
                strSql.Append("审核日期= null ,");
            }
            if (model.关闭人 != null)
            {
                strSql.Append("关闭人='" + model.关闭人 + "',");
            }
            else
            {
                strSql.Append("关闭人= null ,");
            }
            if (model.关闭日期 != null)
            {
                strSql.Append("关闭日期='" + model.关闭日期 + "',");
            }
            else
            {
                strSql.Append("关闭日期= null ,");
            }
            if (model.变更人 != null)
            {
                strSql.Append("变更人='" + model.变更人 + "',");
            }
            else
            {
                strSql.Append("变更人= null ,");
            }
            if (model.变更日期 != null)
            {
                strSql.Append("变更日期='" + model.变更日期 + "',");
            }
            else
            {
                strSql.Append("变更日期= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(long iID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 材料出入库 ");
            strSql.Append(" where iID=" + iID + "");
            return (strSql.ToString());
        }		/// <summary>

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public 成衣生产.Model.材料出入库 DataRowToModel(DataRow row)
        {
            成衣生产.Model.材料出入库 model = new 成衣生产.Model.材料出入库();
            if (row != null)
            {
                if (row["iID"] != null && row["iID"].ToString() != "")
                {
                    model.iID = int.Parse(row["iID"].ToString());
                }
                if (row["生产计划iID"] != null && row["生产计划iID"].ToString() != "")
                {
                    model.生产计划iID = int.Parse(row["生产计划iID"].ToString());
                }
                if (row["单据号"] != null)
                {
                    model.单据号 = row["单据号"].ToString();
                }
                if (row["单据日期"] != null && row["单据日期"].ToString() != "")
                {
                    model.单据日期 = DateTime.Parse(row["单据日期"].ToString());
                }
                if (row["业务员"] != null)
                {
                    model.业务员 = row["业务员"].ToString();
                }
                if (row["类别"] != null)
                {
                    model.类别 = row["类别"].ToString();
                }
                if (row["出入库类别"] != null)
                {
                    model.出入库类别 = row["出入库类别"].ToString();
                }
                if (row["纱种"] != null)
                {
                    model.纱种 = row["纱种"].ToString();
                }
                if (row["色号"] != null)
                {
                    model.色号 = row["色号"].ToString();
                }
                if (row["缸号"] != null)
                {
                    model.缸号 = row["缸号"].ToString();
                }
                if (row["数量"] != null && row["数量"].ToString() != "")
                {
                    model.数量 = decimal.Parse(row["数量"].ToString());
                }
                if (row["备注"] != null)
                {
                    model.备注 = row["备注"].ToString();
                }
                if (row["制单人"] != null)
                {
                    model.制单人 = row["制单人"].ToString();
                }
                if (row["制单日期"] != null && row["制单日期"].ToString() != "")
                {
                    model.制单日期 = DateTime.Parse(row["制单日期"].ToString());
                }
                if (row["审核人"] != null)
                {
                    model.审核人 = row["审核人"].ToString();
                }
                if (row["审核日期"] != null && row["审核日期"].ToString() != "")
                {
                    model.审核日期 = DateTime.Parse(row["审核日期"].ToString());
                }
                if (row["关闭人"] != null)
                {
                    model.关闭人 = row["关闭人"].ToString();
                }
                if (row["关闭日期"] != null && row["关闭日期"].ToString() != "")
                {
                    model.关闭日期 = DateTime.Parse(row["关闭日期"].ToString());
                }
                if (row["变更人"] != null)
                {
                    model.变更人 = row["变更人"].ToString();
                }
                if (row["变更日期"] != null && row["变更日期"].ToString() != "")
                {
                    model.变更日期 = DateTime.Parse(row["变更日期"].ToString());
                }
            }
            return model;
        }

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

