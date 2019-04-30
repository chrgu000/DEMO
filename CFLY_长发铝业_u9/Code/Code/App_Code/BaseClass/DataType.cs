using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

public class DataType
{
    public static int GetInt(string str)
    {
        if (str == null || str == "")
        {
            return 0;
        }
        else
        {
            return int.Parse(str);
        }

    }

    public static bool IsDouble(string value)
    {
        try
        {
            Convert.ToDouble(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static double DoubleParse(string value)
    {
        if (value == "")
        {
            return 0;
        }
        else
        {
            return double.Parse(value);
        }
    }

    public static double DoubleParse(object value)
    {
        if (value.ToString() == "")
        {
            return 0;
        }
        else
        {
            return double.Parse(value.ToString());
        }
    }

    public static decimal DecimalParse(object value)
    {
        decimal d = 0;
        try
        {
            d = decimal.Round(Convert.ToDecimal(value), 6);
        }
        catch { }
        return d;
    }

    public static decimal DecimalParse(object value,int i)
    {
        decimal d = 0;
        try
        {
            d = decimal.Round(Convert.ToDecimal(value), i);
        }
        catch { }
        return d;
    }

    public static bool BoolParse(object value)
    {
        if (value.ToString() == "" || value == null)
        {
            return false;
        }
        else
        {
            return bool.Parse(value.ToString());
        }
    }

    public static string DateTimeParse(string value, string type)
    {
        if (value == "")
        {
            return "";
        }
        else
        {
            return DateTime.Parse(value).ToString(type);
        }
    }

    public static int IntParse(string value)
    {
        if (value == "")
        {
            return 0;
        }
        return int.Parse(value);
    }







    public static string DateTimeParse(string value)
    {
        if (value == "")
        {
            return "";
        }
        else
        {
            return DateTime.Parse(value).ToString("yyyy-MM-dd");
        }
    }

    public static DataTable DataColumnTypeToDouble(DataTable dt, string[] name)
    {
        int i;
        int len = name.Length;
        string[,] str = new string[3, len];
        for (i = 0; i < name.Length; i++)
        {
            DataColumn dc = dt.Columns[name[i]];
            str[0, i] = dc.Ordinal.ToString();
            str[1, i] = name[i];
            str[2, i] = name[i] + "_1";
            dt.Columns.Add(name[i] + "_1", typeof(double));
        }
        for (i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < str.GetLength(1); j++)
            {
                if (dt.Rows[i][str[1, j]].ToString() != "")
                {
                    dt.Rows[i][str[2, j]] = dt.Rows[i][str[1, j]].ToString();
                }
            }
        }
        for (i = 0; i < str.GetLength(1); i++)
        {
            dt.Columns.Remove(dt.Columns[str[1, i]]);
        }
        for (i = 0; i < str.GetLength(1); i++)
        {
            dt.Columns[str[2, i]].ColumnName = str[1, i];
            dt.Columns[str[1, i]].SetOrdinal(int.Parse(str[0, i]));
        }
        return dt;
    }



    public enum ControlsType
    {
        Label,
        TextBox,
        RadioButton,
        HtmlAnchor
    }

    public struct HidID
    {
        public string Hid;
        public string HidS;
    }

    public enum MyCorrelationType
    {
        Left,
        Right
    }

    public enum Dept
    {
        品管部 = 7,
        物控部 = 8,
        外协部 = 2,
        采购部 = 9
    }
}