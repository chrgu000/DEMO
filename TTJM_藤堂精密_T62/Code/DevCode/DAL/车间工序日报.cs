using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace TH.DAL
{
    /// <summary>
    /// 数据访问类:车间工序日报
    /// </summary>
    public partial class 车间工序日报
    {
        public 车间工序日报()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(TH.Model.车间工序日报 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.生产订单ID != null)
            {
                strSql1.Append("生产订单ID,");
                strSql2.Append("" + model.生产订单ID + ",");
            }
            if (model.工序 != null)
            {
                strSql1.Append("工序,");
                strSql2.Append("'" + model.工序 + "',");
            }
            if (model.箱号 != null)
            {
                strSql1.Append("箱号,");
                strSql2.Append("" + model.箱号 + ",");
            }
            if (model.数量 != null)
            {
                strSql1.Append("数量,");
                strSql2.Append("" + model.数量 + ",");
            }
            if (model.登记日期 != null)
            {
                strSql1.Append("登记日期,");
                strSql2.Append("'" + model.登记日期 + "',");
            }
            if (model.机台序号 != null)
            {
                strSql1.Append("机台序号,");
                strSql2.Append("'" + model.机台序号 + "',");
            }
            if (model.作业员 != null)
            {
                strSql1.Append("作业员,");
                strSql2.Append("'" + model.作业员 + "',");
            }
            if (model.型式 != null)
            {
                strSql1.Append("型式,");
                strSql2.Append("'" + model.型式 + "',");
            }
            if (model.D1D2 != null)
            {
                strSql1.Append("D1D2,");
                strSql2.Append("'" + model.D1D2 + "',");
            }
            if (model.模号 != null)
            {
                strSql1.Append("模号,");
                strSql2.Append("'" + model.模号 + "',");
            }
            if (model.转速 != null)
            {
                strSql1.Append("转速,");
                strSql2.Append("" + model.转速 + ",");
            }
            if (model.良品数 != null)
            {
                strSql1.Append("良品数,");
                strSql2.Append("" + model.良品数 + ",");
            }
            if (model.不良数 != null)
            {
                strSql1.Append("不良数,");
                strSql2.Append("" + model.不良数 + ",");
            }
            if (model.计划停机 != null)
            {
                strSql1.Append("计划停机,");
                strSql2.Append("" + model.计划停机 + ",");
            }
            if (model.机故 != null)
            {
                strSql1.Append("机故,");
                strSql2.Append("" + model.机故 + ",");
            }
            if (model.模故 != null)
            {
                strSql1.Append("模故,");
                strSql2.Append("" + model.模故 + ",");
            }
            if (model.换料 != null)
            {
                strSql1.Append("换料,");
                strSql2.Append("" + model.换料 + ",");
            }
            if (model.测量 != null)
            {
                strSql1.Append("测量,");
                strSql2.Append("" + model.测量 + ",");
            }
            if (model.吃饭 != null)
            {
                strSql1.Append("吃饭,");
                strSql2.Append("" + model.吃饭 + ",");
            }
            if (model.换模 != null)
            {
                strSql1.Append("换模,");
                strSql2.Append("" + model.换模 + ",");
            }
            if (model.休息 != null)
            {
                strSql1.Append("休息,");
                strSql2.Append("" + model.休息 + ",");
            }
            if (model.清扫 != null)
            {
                strSql1.Append("清扫,");
                strSql2.Append("" + model.清扫 + ",");
            }
            if (model.换班 != null)
            {
                strSql1.Append("换班,");
                strSql2.Append("" + model.换班 + ",");
            }
            if (model.待料 != null)
            {
                strSql1.Append("待料,");
                strSql2.Append("" + model.待料 + ",");
            }
            if (model.其他 != null)
            {
                strSql1.Append("其他,");
                strSql2.Append("" + model.其他 + ",");
            }
            if (model.备注 != null)
            {
                strSql1.Append("备注,");
                strSql2.Append("'" + model.备注 + "',");
            }
            if (model.班次 != null)
            {
                strSql1.Append("班次,");
                strSql2.Append("'" + model.班次 + "',");
            }
            if (model.客户 != null)
            {
                strSql1.Append("客户,");
                strSql2.Append("'" + model.客户 + "',");
            }
            strSql.Append("insert into 车间工序日报(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            return  (strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public string Update(TH.Model.车间工序日报 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 车间工序日报 set ");
            if (model.数量 != null)
            {
                strSql.Append("数量=" + model.数量 + ",");
            }
            else
            {
                strSql.Append("数量= null ,");
            }
            if (model.登记日期 != null)
            {
                strSql.Append("登记日期='" + model.登记日期 + "',");
            }
            else
            {
                strSql.Append("登记日期= null ,");
            }
            if (model.机台序号 != null)
            {
                strSql.Append("机台序号='" + model.机台序号 + "',");
            }
            else
            {
                strSql.Append("机台序号= null ,");
            }
            if (model.作业员 != null)
            {
                strSql.Append("作业员='" + model.作业员 + "',");
            }
            else
            {
                strSql.Append("作业员= null ,");
            }
            if (model.型式 != null)
            {
                strSql.Append("型式='" + model.型式 + "',");
            }
            else
            {
                strSql.Append("型式= null ,");
            }
            if (model.D1D2 != null)
            {
                strSql.Append("D1D2='" + model.D1D2 + "',");
            }
            else
            {
                strSql.Append("D1D2= null ,");
            }
            if (model.模号 != null)
            {
                strSql.Append("模号='" + model.模号 + "',");
            }
            else
            {
                strSql.Append("模号= null ,");
            }
            if (model.转速 != null)
            {
                strSql.Append("转速=" + model.转速 + ",");
            }
            else
            {
                strSql.Append("转速= null ,");
            }
            if (model.良品数 != null)
            {
                strSql.Append("良品数=" + model.良品数 + ",");
            }
            else
            {
                strSql.Append("良品数= null ,");
            }
            if (model.不良数 != null)
            {
                strSql.Append("不良数=" + model.不良数 + ",");
            }
            else
            {
                strSql.Append("不良数= null ,");
            }
            if (model.计划停机 != null)
            {
                strSql.Append("计划停机=" + model.计划停机 + ",");
            }
            else
            {
                strSql.Append("计划停机= null ,");
            }
            if (model.机故 != null)
            {
                strSql.Append("机故=" + model.机故 + ",");
            }
            else
            {
                strSql.Append("机故= null ,");
            }
            if (model.模故 != null)
            {
                strSql.Append("模故=" + model.模故 + ",");
            }
            else
            {
                strSql.Append("模故= null ,");
            }
            if (model.换料 != null)
            {
                strSql.Append("换料=" + model.换料 + ",");
            }
            else
            {
                strSql.Append("换料= null ,");
            }
            if (model.测量 != null)
            {
                strSql.Append("测量=" + model.测量 + ",");
            }
            else
            {
                strSql.Append("测量= null ,");
            }
            if (model.吃饭 != null)
            {
                strSql.Append("吃饭=" + model.吃饭 + ",");
            }
            else
            {
                strSql.Append("吃饭= null ,");
            }
            if (model.换模 != null)
            {
                strSql.Append("换模=" + model.换模 + ",");
            }
            else
            {
                strSql.Append("换模= null ,");
            }
            if (model.休息 != null)
            {
                strSql.Append("休息=" + model.休息 + ",");
            }
            else
            {
                strSql.Append("休息= null ,");
            }
            if (model.清扫 != null)
            {
                strSql.Append("清扫=" + model.清扫 + ",");
            }
            else
            {
                strSql.Append("清扫= null ,");
            }
            if (model.换班 != null)
            {
                strSql.Append("换班=" + model.换班 + ",");
            }
            else
            {
                strSql.Append("换班= null ,");
            }
            if (model.待料 != null)
            {
                strSql.Append("待料=" + model.待料 + ",");
            }
            else
            {
                strSql.Append("待料= null ,");
            }
            if (model.其他 != null)
            {
                strSql.Append("其他=" + model.其他 + ",");
            }
            else
            {
                strSql.Append("其他= null ,");
            }
            if (model.备注 != null)
            {
                strSql.Append("备注='" + model.备注 + "',");
            }
            else
            {
                strSql.Append("备注= null ,");
            }
            if (model.班次 != null)
            {
                strSql.Append("班次='" + model.班次 + "',");
            }
            else
            {
                strSql.Append("班次= null ,");
            }
            if (model.客户 != null)
            {
                strSql.Append("客户='" + model.客户 + "',");
            }
            else
            {
                strSql.Append("客户= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where 生产订单ID=" + model.生产订单ID + " and 工序='" + model.工序 + "' and 箱号=" + model.箱号 + " ");
            return (strSql.ToString());
        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

