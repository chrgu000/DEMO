using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;


    /// <summary>
    /// TableHelp 的摘要说明
    /// </summary>
public class Tables
{

    #region 汇总(Group)Table得到Table
    /// <summary>
    /// 汇总(Group)Table得到Table
    /// </summary>
    /// <param name="dt">表名</param>
    /// <param name="ColumnName">字段名列表</param>
    /// <returns></returns>
    public static DataTable Group(DataTable dt, string[] ColumnName)
    {
        DataView dv = new DataView(dt);
        DataTable dtgroup = dv.ToTable(true, ColumnName);
        return dtgroup;
    }
    #endregion
}