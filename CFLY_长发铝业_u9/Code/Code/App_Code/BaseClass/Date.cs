using System;
using System.Data;
using System.Configuration;

    /// <summary>
    /// Date 的摘要说明
    /// </summary>
public class Date
{
    public static string DateToString()
    {
        return DateToString(DateTime.Now);
    }

    public static string DateToString(DateTime dt)
    {
        return dt.ToString("yyyy-MM-dd");
    }

    #region 月初月末
    /// <summary>
    /// 本月初的日期
    /// </summary>
    /// <returns></returns>
    public static DateTime MonthS()
    {
        return MonthS(DateTime.Now);
    }
    /// <summary>
    /// 月初的日期
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateTime MonthS(DateTime dt)
    {
        return Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01");
    }

    /// <summary>
    /// 本月末的日期
    /// </summary>
    /// <returns></returns>
    public static DateTime MonthE()
    {
        return MonthE(DateTime.Now);
    }

    /// <summary>
    /// 月末的日期
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateTime MonthE(DateTime dt)
    {
        return Convert.ToDateTime(dt.Year + "-" + dt.Month + "-" + "01").AddMonths(1).AddDays(-1);
    }

    //上月初的日期
    public static DateTime MonthLastS()
    {
        return MonthS(MonthS().AddMonths(-1));
    }

    //上月末的日期
    public static DateTime MonthLastE()
    {
        return MonthE(MonthE().AddMonths(-1));
    }

    //上上月初的日期
    public static DateTime MonthLastLastS()
    {
        return MonthS(MonthS().AddMonths(-2));
    }

    //上上月末的日期
    public static DateTime MonthLastLastE()
    {
        return MonthE(MonthE().AddMonths(-2));
    }
    #endregion

    #region 日期加减
    /// <summary>
    /// 日期相减
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <returns>相差天数</returns>
    public static int DeductDays(DateTime startTime, DateTime endTime)
    {
        TimeSpan ts = endTime - startTime;
        return ts.Days;
    }


    /// <summary>
    /// 日期相减
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <returns>相差小时数</returns>
    public static double DeductHours(DateTime startTime, DateTime endTime)
    {
        TimeSpan ts = endTime - startTime;
        return ts.TotalHours;
    }


    /// <summary>
    /// 日期相减
    /// </summary>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <returns>相差分钟数</returns>
    public static int DeductMinutes(DateTime startTime, DateTime endTime)
    {
        TimeSpan ts = endTime - startTime;
        return ts.Minutes;
    }
    #endregion

    #region 以周日为起始,周六为结束
    /// <summary>
    /// 计算上周开始（周日）
    /// </summary>
    /// <returns></returns>
    public static DateTime WeekLastS()
    {
        return WeekNowS().AddDays(-7);
    }

    /// <summary> 
    /// 计算上周结束（周六）
    /// </summary> 
    /// <returns></returns> 
    public static DateTime WeekLastE()
    {
        return WeekNowE().AddDays(-7);
    }

    /// <summary> 
    /// 计算本周开始（周日）
    /// </summary> 
    /// <returns></returns> 
    public static DateTime WeekNowS()
    {
        return Monday(DateTime.Now).AddDays(-1);
    }

    /// <summary> 
    /// 计算本周结束（周六）
    /// </summary> 
    /// <returns></returns> 
    public static DateTime WeekNowE()
    {
        return WeekNowS().AddDays(7);
    }

    /// <summary>
    /// 计算下周开始（周日）
    /// </summary>
    /// <returns></returns>
    public static DateTime WeekNextS()
    {
        return WeekNowS().AddDays(7);
    }

    /// <summary> 
    /// 计算下周结束（周六）
    /// </summary> 
    /// <returns></returns> 
    public static DateTime WeekNextE()
    {
        return WeekNowE().AddDays(7);
    }

    /// <summary>
    /// 计算下周的下周的周日
    /// </summary>
    /// <returns></returns>
    public static DateTime WeekTwoNextS()
    {
        return WeekNowS().AddDays(14);
    }

    /// <summary> 
    /// 计算下周的下周周六
    /// </summary> 
    /// <returns></returns> 
    public static DateTime WeekTwoNextE()
    {
        return WeekNowE().AddDays(14);
    }

    #endregion


    #region 得到第几周和礼拜一
    /// <summary>
    /// 计算第几周
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static int Week(DateTime dt)
    {
        System.Globalization.GregorianCalendar gc = new System.Globalization.GregorianCalendar();

        //System.Globalization.ChineseLunisolarCalendar cg = new System.Globalization.ChineseLunisolarCalendar();

        return gc.GetWeekOfYear(dt, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);

        //int weekOfYear = 0;
        //if (DateTime.Now.DayOfYear % 7 > 0)
        //{
        //    weekOfYear = (DateTime.Now.DayOfYear - (DateTime.Now.DayOfYear % 7)) / 7 + 1;
        //}
        //else
        //{
        //    weekOfYear = DateTime.Now.DayOfYear / 7;
        //}
        //return weekOfYear;
    }

    /// <summary>
    /// 计算第几周
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static int Week()
    {
        return Week(DateTime.Now);
    }

    public static int WeekNext()
    {
        return Week(DateTime.Now.AddDays(7));
    }

    public static int WeekLast()
    {
        return Week(DateTime.Now.AddDays(-7));
    }

    /// <summary> 
    /// 计算某日起始日期（礼拜一的日期） 
    /// </summary> 
    /// <param name="someDate">该周中任意一天</param> 
    /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns> 
    public static DateTime Monday(DateTime someDate)
    {
        int i = someDate.DayOfWeek - DayOfWeek.Monday;
        if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
        TimeSpan ts = new TimeSpan(i, 0, 0, 0);
        return someDate.Subtract(ts);
    }

    #endregion


    #region
    public static string MonthName(int i)
    {
        string str = "";
        switch (i)
        {
            case 1:
                str = "一月"; break;
            case 2:
                str = "二月"; break;
            case 3:
                str = "三月"; break;
            case 4:
                str = "四月"; break;
            case 5:
                str = "五月"; break;
            case 6:
                str = "六月"; break;
            case 7:
                str = "七月"; break;
            case 8:
                str = "八月"; break;
            case 9:
                str = "九月"; break;
            case 10:
                str = "十月"; break;
            case 11:
                str = "十一月"; break;
            case 12:
                str = "十二月"; break;
        }
        return str;
    }
    #endregion

    #region
    public static int MonthID(string str)
    {
        int i = 0;
        switch (str)
        {
            case "一月":
                i = 1; break;
            case "二月":
                i = 2; break;
            case "三月":
                i = 3; break;
            case "四月":
                i = 4; break;
            case "五月":
                i = 5; break;
            case "六月":
                i = 6; break;
            case "七月":
                i = 7; break;
            case "八月":
                i = 8; break;
            case "九月":
                i = 9; break;
            case "十月":
                i = 10; break;
            case "十一月":
                i = 11; break;
            case "十二月":
                i = 12; break;
        }
        return i;
    }
    #endregion
}