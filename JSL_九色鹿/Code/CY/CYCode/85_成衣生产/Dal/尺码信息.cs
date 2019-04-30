using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace 成衣生产.DAL
{
    /// <summary>
    /// 数据访问类:尺码信息
    /// </summary>
    public partial class 尺码信息
    {
        public 尺码信息()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(成衣生产.Model.尺码信息 model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.款号 != null)
            {
                strSql1.Append("款号,");
                strSql2.Append("'" + model.款号 + "',");
            }
            if (model.身高L != null)
            {
                strSql1.Append("身高L,");
                strSql2.Append("" + model.身高L + ",");
            }
            if (model.身高T != null)
            {
                strSql1.Append("身高T,");
                strSql2.Append("" + model.身高T + ",");
            }
            if (model.体重L != null)
            {
                strSql1.Append("体重L,");
                strSql2.Append("" + model.体重L + ",");
            }
            if (model.体重T != null)
            {
                strSql1.Append("体重T,");
                strSql2.Append("" + model.体重T + ",");
            }
            if (model.胸围L != null)
            {
                strSql1.Append("胸围L,");
                strSql2.Append("" + model.胸围L + ",");
            }
            if (model.胸围T != null)
            {
                strSql1.Append("胸围T,");
                strSql2.Append("" + model.胸围T + ",");
            }
            if (model.胸围杯型L != null)
            {
                strSql1.Append("胸围杯型L,");
                strSql2.Append("" + model.胸围杯型L + ",");
            }
            if (model.胸围杯型T != null)
            {
                strSql1.Append("胸围杯型T,");
                strSql2.Append("" + model.胸围杯型T + ",");
            }
            if (model.身长L != null)
            {
                strSql1.Append("身长L,");
                strSql2.Append("" + model.身长L + ",");
            }
            if (model.身长T != null)
            {
                strSql1.Append("身长T,");
                strSql2.Append("" + model.身长T + ",");
            }
            if (model.肩宽L != null)
            {
                strSql1.Append("肩宽L,");
                strSql2.Append("" + model.肩宽L + ",");
            }
            if (model.肩宽T != null)
            {
                strSql1.Append("肩宽T,");
                strSql2.Append("" + model.肩宽T + ",");
            }
            if (model.袖长L != null)
            {
                strSql1.Append("袖长L,");
                strSql2.Append("" + model.袖长L + ",");
            }
            if (model.袖长T != null)
            {
                strSql1.Append("袖长T,");
                strSql2.Append("" + model.袖长T + ",");
            }
            if (model.制版文件 != null)
            {
                strSql1.Append("制版文件,");
                strSql2.Append("'" + model.制版文件 + "',");
            }
            if (model.制版人 != null)
            {
                strSql1.Append("制版人,");
                strSql2.Append("'" + model.制版人 + "',");
            }
            if (model.制版时间 != null)
            {
                strSql1.Append("制版时间,");
                strSql2.Append("'" + model.制版时间 + "',");
            }
            if (model.上机文件 != null)
            {
                strSql1.Append("上机文件,");
                strSql2.Append("'" + model.上机文件 + "',");
            }
            if (model.上机人 != null)
            {
                strSql1.Append("上机人,");
                strSql2.Append("'" + model.上机人 + "',");
            }
            if (model.上机时间 != null)
            {
                strSql1.Append("上机时间,");
                strSql2.Append("'" + model.上机时间 + "',");
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
            if (model.Updater != null)
            {
                strSql1.Append("Updater,");
                strSql2.Append("'" + model.Updater + "',");
            }
            if (model.UpdateDate != null)
            {
                strSql1.Append("UpdateDate,");
                strSql2.Append("'" + model.UpdateDate + "',");
            }
            strSql.Append("insert into 尺码信息(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            return (strSql.ToString());

        }
        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

