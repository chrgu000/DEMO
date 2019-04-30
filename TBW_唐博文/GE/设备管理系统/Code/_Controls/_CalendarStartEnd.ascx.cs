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

public partial class FormatCalendarStartEnd : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PublicClass pc = new PublicClass();
        string ctext = pc.GetLanguageColumn();
        datetimepicker1.Attributes.Add("onmouseover", "javascript:SelectDate(" + datetimepicker1.ClientID + ")");
        datetimepicker1.Attributes.Add("onfocus", "javascript:SelectDate(" + datetimepicker1.ClientID + ")");
        datetimepicker2.Attributes.Add("onmouseover", "javascript:SelectDate(" + datetimepicker2.ClientID + ")");
        datetimepicker2.Attributes.Add("onfocus", "javascript:SelectDate(" + datetimepicker2.ClientID + ")");
        //if (ctext == "COLUMN_Text2")
        //{
        //    Label1.Text = "From ";
        //    Label2.Text = "To ";
        //}
        //else
        //{
        //    Label1.Text = "从 ";
        //    Label2.Text = "至 ";
        //}
    }

    public string ValueStart
    {
        set { datetimepicker1.Text = value; }
        get { return datetimepicker1.Text; }
    }

    public string ValueEnd
    {
        set { datetimepicker2.Text = value; }
        get { return datetimepicker2.Text; }
    }

    public bool Enabled
    {
        set
        {
            datetimepicker1.Enabled = value;
            datetimepicker2.Enabled = value;
        }
    }
}
