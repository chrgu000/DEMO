using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace 系统服务
{
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
        public static decimal Sum(DataTable dt, string[,] Requirement, string SumName)
        {
            string sum = dt.Compute("sum(" + SumName + ")", GetFilter(Requirement)).ToString();
            if (sum != "")
            {
                return 系统服务.规格化.ReturnDecimal(sum,3);
            }
            return 0;
        }

        public static decimal Sum(DataTable dt, System.Collections.ArrayList arrList, string SumName)
        {
            string sum = dt.Compute("sum(" + SumName + ")", GetFilter(arrList)).ToString();
            if (sum != "")
            {
                return 系统服务.规格化.ReturnDecimal(sum,3);
            }
            return 0;
        }
        public static string Max(DataTable dt, System.Collections.ArrayList arrList, string MaxName)
        {
            string max = dt.Compute("max(" + MaxName + ")", GetFilter(arrList)).ToString();
            return max;
        }

        public static decimal Sum(DataTable dt, string SumName)
        {
            string sum = dt.Compute("sum(" + SumName + ")", "").ToString();
            if (sum != "")
            {
                return 系统服务.规格化.ReturnDecimal(sum,3);
            }
            return 0;
        }
        #endregion

        #region Table得到Max
        public static string Max(DataTable dt, string[,] Requirement, string SumName)
        {
            DataRow[] dw = dt.Select(GetFilter(Requirement), SumName+" desc");
            return dw[0][SumName].ToString().Trim();
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
        public static DataTable Group(DataTable dt, string[] ColumnName, string[] SumName, string[,] sWhere)
        {
            dt = SelectTable(dt, sWhere);
            return Group(dt, ColumnName, SumName);
        }

        public static DataTable Group(DataTable dt, string[] ColumnName, string[] SumName, string[] MaxName, string[,] sWhere)
        {
            dt = SelectTable(dt, sWhere);
            return Group(dt, ColumnName, SumName, MaxName);
        }

        public static DataTable Group(DataTable dt, string[] ColumnName, string[] SumName)
        {
            DataView dv = new DataView(dt);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            int len = ColumnName.Length;
            for (int p = 0; p < SumName.Length; p++)
            {
                dtgroup.Columns.Add(SumName[p]);
            }
            for (int i = 0; i < dtgroup.Rows.Count; i++)
            {
                for (int p = 0; p < SumName.Length; p++)
                {
                    System.Collections.ArrayList arrLists = new System.Collections.ArrayList();
                    for (int j = 0; j < ColumnName.Length; j++)
                    {
                        System.Collections.ArrayList arrList = new System.Collections.ArrayList();
                        arrList.Add(ColumnName[j]);
                        arrList.Add(dtgroup.Rows[i][ColumnName[j]].ToString());
                        arrLists.Add(arrList);
                    }
                    dtgroup.Rows[i][SumName[p]] = Sum(dt, arrLists, SumName[p]);
                }
            }
            return dtgroup;
        }

        public static DataTable Group(DataTable dt, string[] ColumnName, string[] SumName, string[] MaxName)
        {
            DataView dv = new DataView(dt);
            DataTable dtgroup = dv.ToTable(true, ColumnName);
            int len = ColumnName.Length;
            for (int p = 0; p < SumName.Length; p++)
            {
                dtgroup.Columns.Add(SumName[p]);
            }
            for (int p = 0; p < MaxName.Length; p++)
            {
                dtgroup.Columns.Add(MaxName[p],typeof(string));
            }
            for (int i = 0; i < dtgroup.Rows.Count; i++)
            {
                for (int p = 0; p < SumName.Length; p++)
                {
                    System.Collections.ArrayList arrLists = new System.Collections.ArrayList();
                    for (int j = 0; j < ColumnName.Length; j++)
                    {
                        System.Collections.ArrayList arrList = new System.Collections.ArrayList();
                        arrList.Add(ColumnName[j]);
                        arrList.Add(dtgroup.Rows[i][ColumnName[j]].ToString());
                        arrLists.Add(arrList);
                    }
                    dtgroup.Rows[i][SumName[p]] = Sum(dt, arrLists, SumName[p]);
                }

                for (int p = 0; p < MaxName.Length; p++)
                {
                    System.Collections.ArrayList arrLists = new System.Collections.ArrayList();
                    for (int j = 0; j < ColumnName.Length; j++)
                    {
                        System.Collections.ArrayList arrList = new System.Collections.ArrayList();
                        arrList.Add(ColumnName[j]);
                        arrList.Add(dtgroup.Rows[i][ColumnName[j]].ToString());
                        arrLists.Add(arrList);
                    }
                    dtgroup.Rows[i][MaxName[p]] = Max(dt, arrLists, MaxName[p]);
                }
            }
            return dtgroup;
        }
        #endregion

        private static string GetFilter(System.Collections.ArrayList arrLists)
        {
            string s = "";
            for (int i = 0; i < arrLists.Count; i++)
            {
                if (i != 0)
                {
                    s = s + " and ";
                }
                System.Collections.ArrayList arrList = (System.Collections.ArrayList)arrLists[i];
                s = s + arrList[0] + "='" + arrList[1] + "'";
            }
            return s;
        }

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
}