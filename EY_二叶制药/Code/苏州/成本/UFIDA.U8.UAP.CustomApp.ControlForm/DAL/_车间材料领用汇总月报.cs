using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_车间材料领用汇总月报
    /// </summary>
    public partial class _车间材料领用汇总月报
    {
        public _车间材料领用汇总月报()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._车间材料领用汇总月报 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.会计期间 != null)
            {
                strSql1.Append("会计期间,");
                strSql2.Append("'" + model.会计期间 + "',");
            }
            if (model.部门编码 != null)
            {
                strSql1.Append("部门编码,");
                strSql2.Append("'" + model.部门编码 + "',");
            }
            if (model.产品编码 != null)
            {
                strSql1.Append("产品编码,");
                strSql2.Append("'" + model.产品编码 + "',");
            }
            if (model.材料编码 != null)
            {
                strSql1.Append("材料编码,");
                strSql2.Append("'" + model.材料编码 + "',");
            }
            if (model.月初存料数量 != null)
            {
                strSql1.Append("月初存料数量,");
                strSql2.Append("" + model.月初存料数量 + ",");
            }
            if (model.月初存料单价 != null)
            {
                strSql1.Append("月初存料单价,");
                strSql2.Append("" + model.月初存料单价 + ",");
            }
            if (model.月初存料金额 != null)
            {
                strSql1.Append("月初存料金额,");
                strSql2.Append("" + model.月初存料金额 + ",");
            }
            if (model.收发存汇总出库数量 != null)
            {
                strSql1.Append("收发存汇总出库数量,");
                strSql2.Append("" + model.收发存汇总出库数量 + ",");
            }
            if (model.收发存汇总出库单价 != null)
            {
                strSql1.Append("收发存汇总出库单价,");
                strSql2.Append("" + model.收发存汇总出库单价 + ",");
            }
            if (model.收发存汇总出库金额 != null)
            {
                strSql1.Append("收发存汇总出库金额,");
                strSql2.Append("" + model.收发存汇总出库金额 + ",");
            }
            if (model.月末结存数量 != null)
            {
                strSql1.Append("月末结存数量,");
                strSql2.Append("" + model.月末结存数量 + ",");
            }
            if (model.月末结存单价 != null)
            {
                strSql1.Append("月末结存单价,");
                strSql2.Append("" + model.月末结存单价 + ",");
            }
            if (model.月末结存金额 != null)
            {
                strSql1.Append("月末结存金额,");
                strSql2.Append("" + model.月末结存金额 + ",");
            }
            if (model.本月耗用数量 != null)
            {
                strSql1.Append("本月耗用数量,");
                strSql2.Append("" + model.本月耗用数量 + ",");
            }
            if (model.本月耗用单价 != null)
            {
                strSql1.Append("本月耗用单价,");
                strSql2.Append("" + model.本月耗用单价 + ",");
            }
            if (model.本月耗用金额 != null)
            {
                strSql1.Append("本月耗用金额,");
                strSql2.Append("" + model.本月耗用金额 + ",");
            }
            if (model.产品数量 != null)
            {
                strSql1.Append("产品数量,");
                strSql2.Append("" + model.产品数量 + ",");
            }
            if (model.产品单价 != null)
            {
                strSql1.Append("产品单价,");
                strSql2.Append("" + model.产品单价 + ",");
            }
            if (model.产品金额 != null)
            {
                strSql1.Append("产品金额,");
                strSql2.Append("" + model.产品金额 + ",");
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
            strSql.Append("insert into _车间材料领用汇总月报(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return (strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string 会计期间, string 部门编码, string 产品编码, string 材料编码)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _车间材料领用汇总月报 ");
            strSql.Append(" where 会计期间='" + 会计期间 + "' and 部门编码='" + 部门编码 + "' and 产品编码='" + 产品编码 + "' and 材料编码='" + 材料编码 + "' ");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

