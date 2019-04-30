using System;
using System.Collections.Generic;
using System.Text;


public class String
{
    /// <summary>
    /// 格式化字符串，并且返回数组
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string[] StringRegulate(string str)
    {
        str = StringRegulate(str, '，');
        str = StringRegulate(str, ';');
        str = StringRegulate(str, '；');
        return str.Split(',');
    }

    private static string StringRegulate(string str, char c)
    {
        if (str.IndexOf(c) > -1)
        {
            str = str.Replace(c, ',');
        }
        if (str.IndexOf(c) > -1)
        {
            StringRegulate(str, c);
        }
        return str;
    }

    public static string Distinct(string str, char type)
    {
        string[] id = str.Split(type);
        string newid = "";
        for (int i = 0; i < id.Length; i++)
        {
            if (id[i] != "")
            {
                if (i == 0)
                {
                    newid = id[i];
                }
                else
                {
                    if (("," + newid + ",").IndexOf("," + id[i] + ",") < 0)
                    {
                        newid = "," + id[i];
                    }
                }
            }
        }
        return newid;

    }
}