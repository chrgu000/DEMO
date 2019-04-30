using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace UFIDA.U8.UAP.CustomApp.ControlForm.DAL
{
    /// <summary>
    /// 数据访问类:_发票_sap
    /// </summary>
    public partial class _发票_sap
    {
        public _发票_sap()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string Exists(string 发票号码)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from _发票_sap");
            strSql.Append(" where 发票号码='" + 发票号码 + "' ");
            return (strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(UFIDA.U8.UAP.CustomApp.ControlForm.Model._发票_sap model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.销售组织 != null)
            {
                strSql1.Append("销售组织,");
                strSql2.Append("'" + model.销售组织 + "',");
            }
            if (model.发票号码 != null)
            {
                strSql1.Append("发票号码,");
                strSql2.Append("'" + model.发票号码 + "',");
            }
            if (model.发票类型 != null)
            {
                strSql1.Append("发票类型,");
                strSql2.Append("'" + model.发票类型 + "',");
            }
            if (model.发票类型名称 != null)
            {
                strSql1.Append("发票类型名称,");
                strSql2.Append("'" + model.发票类型名称 + "',");
            }
            if (model.发票日期 != null)
            {
                strSql1.Append("发票日期,");
                strSql2.Append("'" + model.发票日期 + "',");
            }
            if (model.客户编码 != null)
            {
                strSql1.Append("客户编码,");
                strSql2.Append("'" + model.客户编码 + "',");
            }
            if (model.客户旧编码 != null)
            {
                strSql1.Append("客户旧编码,");
                strSql2.Append("'" + model.客户旧编码 + "',");
            }
            if (model.客户名称 != null)
            {
                strSql1.Append("客户名称,");
                strSql2.Append("'" + model.客户名称 + "',");
            }
            if (model.代理商编码 != null)
            {
                strSql1.Append("代理商编码,");
                strSql2.Append("'" + model.代理商编码 + "',");
            }
            if (model.代理商名称 != null)
            {
                strSql1.Append("代理商名称,");
                strSql2.Append("'" + model.代理商名称 + "',");
            }
            if (model.业务员编码 != null)
            {
                strSql1.Append("业务员编码,");
                strSql2.Append("'" + model.业务员编码 + "',");
            }
            if (model.业务员名称 != null)
            {
                strSql1.Append("业务员名称,");
                strSql2.Append("'" + model.业务员名称 + "',");
            }
            if (model.省份编码 != null)
            {
                strSql1.Append("省份编码,");
                strSql2.Append("'" + model.省份编码 + "',");
            }
            if (model.省份名称 != null)
            {
                strSql1.Append("省份名称,");
                strSql2.Append("'" + model.省份名称 + "',");
            }
            if (model.城市编码 != null)
            {
                strSql1.Append("城市编码,");
                strSql2.Append("'" + model.城市编码 + "',");
            }
            if (model.发货单号 != null)
            {
                strSql1.Append("发货单号,");
                strSql2.Append("'" + model.发货单号 + "',");
            }
            if (model.发货行号 != null)
            {
                strSql1.Append("发货行号,");
                strSql2.Append("" + model.发货行号 + ",");
            }
            if (model.货物编码 != null)
            {
                strSql1.Append("货物编码,");
                strSql2.Append("'" + model.货物编码 + "',");
            }
            if (model.货物旧编码 != null)
            {
                strSql1.Append("货物旧编码,");
                strSql2.Append("'" + model.货物旧编码 + "',");
            }
            if (model.货物名称 != null)
            {
                strSql1.Append("货物名称,");
                strSql2.Append("'" + model.货物名称 + "',");
            }
            if (model.规格型号 != null)
            {
                strSql1.Append("规格型号,");
                strSql2.Append("'" + model.规格型号 + "',");
            }
            if (model.批次 != null)
            {
                strSql1.Append("批次,");
                strSql2.Append("'" + model.批次 + "',");
            }
            if (model.单价 != null)
            {
                strSql1.Append("单价,");
                strSql2.Append("" + model.单价 + ",");
            }
            if (model.开票数量 != null)
            {
                strSql1.Append("开票数量,");
                strSql2.Append("" + model.开票数量 + ",");
            }
            if (model.金额 != null)
            {
                strSql1.Append("金额,");
                strSql2.Append("" + model.金额 + ",");
            }
            if (model.货币单位 != null)
            {
                strSql1.Append("货币单位,");
                strSql2.Append("'" + model.货币单位 + "',");
            }
            if (model.金税发票号码 != null)
            {
                strSql1.Append("金税发票号码,");
                strSql2.Append("'" + model.金税发票号码 + "',");
            }
            if (model.发票已取消 != null)
            {
                strSql1.Append("发票已取消,");
                strSql2.Append("'" + model.发票已取消 + "',");
            }
            if (model.被冲销的号码 != null)
            {
                strSql1.Append("被冲销的号码,");
                strSql2.Append("'" + model.被冲销的号码 + "',");
            }
            if (model.PO项目 != null)
            {
                strSql1.Append("PO项目,");
                strSql2.Append("'" + model.PO项目 + "',");
            }
            if (model.导入人 != null)
            {
                strSql1.Append("导入人,");
                strSql2.Append("'" + model.导入人 + "',");
            }
            strSql1.Append("导入人,");
            strSql2.Append("getdate(),");
            strSql.Append("insert into _发票_sap(");
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
        public string Update(UFIDA.U8.UAP.CustomApp.ControlForm.Model._发票_sap model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update _发票_sap set ");

            if (model.金税发票号码 != null)
            {
                strSql.Append("金税发票号码='" + model.金税发票号码 + "',");
            }
            else
            {
                strSql.Append("金税发票号码= null ,");
            }

            if (model.修改人 != null)
            {
                strSql.Append("修改人='" + model.修改人 + "',");
            }
            else
            {
                strSql.Append("修改人= null ,");
            }
            strSql.Append("修改时间 = getdate(),");
          
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where iID=" + model.iID + "");
            return  (strSql.ToString());

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string Delete(string 发票号码)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from _发票_sap ");
            strSql.Append(" where 发票号码='" + 发票号码 + "'");
            return (strSql.ToString());
        }		

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

