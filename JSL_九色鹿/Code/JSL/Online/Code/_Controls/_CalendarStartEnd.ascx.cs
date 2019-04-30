using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class YxCalendarStartEnd : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string ValueStart
    {
        set
        {
            string str = value;
            if (str != "" && str != null && str != "1900-01-01")
            {
                cals.Value = DateTime.Parse(str).ToString("yyyy-MM-dd");
            }
        }
        get
        {
            return cals.Value;
        }
    }

    public string ValueEnd
    {
        set
        {
            string str = value;
            if (str != "" && str != null && str != "1900-01-01")
            {
                cale.Value = DateTime.Parse(str).ToString("yyyy-MM-dd");
            }
        }
        get
        {
            return cale.Value;
        }
    }

    public void LastMonth()
    {
        cals.Value = Date.MonthLastS().ToString("yyyy-MM-dd");
        cale.Value = Date.MonthLastE().ToString("yyyy-MM-dd");
    }

    public void Month()
    {
        cals.Value = Date.MonthLastS().ToString("yyyy-MM-dd");
        cale.Value = Date.MonthE().ToString("yyyy-MM-dd");
    }

    public void Week()
    {
        cals.Value = DateTime.Now.ToString("yyyy-MM-dd");
        cale.Value = DateTime.Now.AddDays(6).ToString("yyyy-MM-dd");
    }

    public void LastWeek()
    {
        cals.Value = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd");
        cale.Value = DateTime.Now.ToString("yyyy-MM-dd");
    }
}
