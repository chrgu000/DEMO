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
    #region 新增表格
    /// <summary>
    /// 新增表格
    /// </summary>
    /// <param name="r">表格条数</param>
    /// <returns></returns>
    public static DataTable New(int r)
    {
        DataTable dt = new DataTable();
        for (int i = 0; i < r; i++)
        {
            DataRow dw = dt.NewRow();
            dt.Rows.Add(dw);
        }
        return dt;
    }
    #endregion

    #region 将DataRow[] 更改为DataTable
    public static DataTable DataRowToDataTable(DataRow[] dw)
    {
        DataTable dts = new DataTable();
        foreach (DataColumn dc in dw[0].Table.Columns)
        {
            dts.Columns.Add(dc.ColumnName);
        }
        foreach (DataRow dws in dw)
        {
            dts.ImportRow(dws);
        }
        return dts;
    }
    #endregion

    #region 查询Table得到查询行
    public static DataRow[] SelectRow(DataTable dt, string[,] Requirement, string Order)
    {
        DataRow[] dw = dt.Select(GetFilter(Requirement), Order);
        return dw;
    }

    public static DataRow[] SelectRow(DataTable dt, string[,] Requirement)
    {
        return SelectRow(dt, Requirement, "");
    }
    #endregion

    #region 查询得到DataTable
    public static DataTable SelectTable(DataTable dt, string[,] Requirement)
    {
        DataRow[] dw = dt.Select(GetFilter(Requirement));
        DataTable dts = new DataTable();
        foreach (DataColumn dc in dt.Columns)
        {
            dts.Columns.Add(dc.ColumnName, dc.DataType);
        }
        foreach (DataRow dws in dw)
        {
            dts.ImportRow(dws);
        }
        return dts;
    }


    public static DataTable SelectTable(DataTable dt, string[,] Requirement, string Order)
    {
        DataRow[] dw = dt.Select(GetFilter(Requirement), Order);
        DataTable dts = new DataTable();
        foreach (DataColumn dc in dt.Columns)
        {
            dts.Columns.Add(dc.ColumnName);
        }
        foreach (DataRow dws in dw)
        {
            dts.ImportRow(dws);
        }
        return dts;
    }


    #endregion

    public static DataTable SortTable(DataTable dt, string Order, string type)
    {
        string str = "";
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            if (str != "")
            {
                str = str + ",";
            }
            str = str + dt.Columns[i].ColumnName;
        }
        DataRow[] dw = dt.Select("", Order + " " + type);
        DataTable dts = new DataTable();
        foreach (DataColumn dc in dt.Columns)
        {
            dts.Columns.Add(dc.ColumnName);
        }
        foreach (DataRow dws in dw)
        {
            dts.ImportRow(dws);
        }
        return dts;
    }

    #region 汇总Table得到Sum
    public static double Sum(DataTable dt, string[,] Requirement, string SumName)
    {
        string sum = dt.Compute("sum(" + SumName + ")", GetFilter(Requirement)).ToString();
        if (sum != "")
        {
            return DataType.DoubleParse(sum);
        }
        return 0;
    }

    public static double Sum(DataTable dt, string SumName)
    {
        string sum = dt.Compute("sum(" + SumName + ")", "").ToString();
        if (sum != "")
        {
            return DataType.DoubleParse(sum);
        }
        return 0;
    }
    #endregion

    #region 汇总Table得到Count
    public static int Count(DataTable dt, string[,] Requirement)
    {
        DataRow[] dw = dt.Select(GetFilter(Requirement));
        return dw.Length;
    }
    #endregion

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
    public static DataTable GroupSum(DataTable dt, string[] ColumnName,string [] SumColumnName)
    {
        DataView dv = new DataView(dt);
        DataTable dtgroup = dv.ToTable(true, ColumnName);
        for (int i = 0; i < SumColumnName.Length; i++)
        {
            dtgroup.Columns.Add(SumColumnName[i]);
            for (int j = 0; j < dtgroup.Rows.Count; j++)
            {
                string sel="";
                for(int s=0;s<ColumnName.Length;s++)
                {
                    if(sel!="")
                    {
                        sel = sel + " and ";
                    }
                    sel = sel + ColumnName[s] + "='" + dtgroup.Rows[j][ColumnName[s]].ToString() + "'";
                }
                dtgroup.Rows[j][SumColumnName[i]] = dt.Compute("sum(" + SumColumnName[i] + ")", sel);
            }
        }

        return dtgroup;
    }
    #endregion

    #region 汇总Table得到Max
    public static double Max(DataTable dt, string[,] Requirement, string SumName)
    {
        string sum = dt.Compute("max(" + SumName + ")", GetFilter(Requirement)).ToString();
        if (sum != "")
        {
            return DataType.DoubleParse(sum);
        }
        return 0;
    }

    public static double Max(DataTable dt, string SumName)
    {
        string sum = dt.Compute("max(" + SumName + ")", "").ToString();
        if (sum != "")
        {
            return DataType.DoubleParse(sum);
        }
        return 0;
    }

    public static string StringMax(DataTable dt, string[,] Requirement, string SumName)
    {
        return dt.Compute("max(" + SumName + ")", GetFilter(Requirement)).ToString();
    }

    public static string StringMax(DataTable dt, string SumName)
    {
        return dt.Compute("max(" + SumName + ")", "").ToString();
    }
    #endregion

    #region 汇总Table得到Min
    public static double Min(DataTable dt, string[,] Requirement, string SumName)
    {
        string sum = dt.Compute("min(" + SumName + ")", GetFilter(Requirement)).ToString();
        if (sum != "")
        {
            return DataType.DoubleParse(sum);
        }
        return 0;
    }

    public static double Min(DataTable dt, string SumName)
    {
        string sum = dt.Compute("min(" + SumName + ")", "").ToString();
        if (sum != "")
        {
            return DataType.DoubleParse(sum);
        }
        return 0;
    }

    public static string StringMin(DataTable dt, string[,] Requirement, string SumName)
    {
        return dt.Compute("min(" + SumName + ")", GetFilter(Requirement)).ToString();
    }

    public static string StringMin(DataTable dt, string SumName)
    {
        return dt.Compute("min(" + SumName + ")", "").ToString();
    }
    #endregion

    #region 需选择DataTable的列，以，分隔
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt">DataTable</param>
    /// <param name="str">需选择的列，以，分隔</param>
    /// <returns></returns>
    public static DataTable ColumnChoices(DataTable dt, string[] str)
    {
        DataTable dtnew = new DataTable();
        for (int i = 0; i < str.Length; i++)
        {
            dtnew.Columns.Add(str[i]);
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dw = dtnew.NewRow();
            for (int j = 0; j < str.Length; j++)
            {
                dw[str[j]] = dt.Rows[i][str[j]].ToString();
            }
            dtnew.Rows.Add(dw);
        }
        return dtnew;
    }
    #endregion

    private static string GetFilter(string[,] Requirement)
    {
        string s = "";
        for (int i = 0; i < Requirement.GetLength(0); i++)
        {
            if (i != 0)
            {
                s = s + " and ";
            }
            if (Requirement.Length / Requirement.GetLength(0) == 2)
            {
                if (Requirement[i, 1] != "")
                {
                    s = s + Requirement[i, 0] + "='" + Requirement[i, 1] + "'";
                }
                else
                {
                    s = s + "(" + Requirement[i, 0] + " is null or " + Requirement[i, 0] + " ='')";
                }
            }
            else
            {
                if (Requirement[i, 1] != "")
                {
                    s = s + Requirement[i, 0] + Requirement[i, 2] + "'" + Requirement[i, 1] + "'";
                }
                else
                {
                    s = s + "(" + Requirement[i, 0] + " is null or " + Requirement[i, 0] + " ='')";
                }
            }
        }
        return s;
    }



    public static string TableString(DataTable dt)
    {
        string str = "";
        str = "<table>";
        str = str + "<tr>";
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            str = str + "<th>" + dt.Columns[i].ColumnName + "</th>";
        }
        str = str + "</tr>";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str = str + "<tr>";
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                str = str + "<td>" + dt.Rows[i][j].ToString() + "</td>";
            }
            str = str + "</tr>";
        }
        str = str + "</table>";
        return str;
    }

    public static string Distinct(string strold, string[] str)
    {
        strold = "," + strold + ",";
        for (int i = 0; i < str.Length; i++)
        {
            string str1 = "," + str[i] + ",";
            if (strold.IndexOf(str1) < 0)
            {
                strold = strold + "," + str1[i];
            }
        }
        return strold;
    }
}