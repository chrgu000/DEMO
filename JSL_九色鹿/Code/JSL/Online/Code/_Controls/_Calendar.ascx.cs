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

public partial class YxCalendar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //cal.Attributes.Add("onmouseout", "javascript:IsOk('" + cal.ClientID + "')");
    }

    public string Value
    {
        set
        {
            string str = value;
            if (str !="" && str != null)
            {
                if (DateTime.Parse(str).ToString("yyyy-MM-dd") != "1900-01-01")
                {
                    cal.Value = DateTime.Parse(str).ToString("yyyy-MM-dd");
                }
                ddlHSelect(DateTime.Parse(str).Hour.ToString());
                ddlMSelect(DateTime.Parse(str).Minute.ToString());
            }
            

        }
        get
        {
            string str = "";
            if (ddlH.Visible == true)
            {
                str= cal.Value + " " + ddlH.SelectedValue + ":" + ddlM.SelectedValue;
            }
            else
            {
                str =cal.Value;
            }
            if (str == "1900-01-01")
            {
                return "";
            }
            else
            {
                return str;
            }
            
        }
    }


    public string HH
    {
        set
        {
            ddlHSelect(value);
        }
        get
        {
            return ddlH.SelectedValue;
        }
    }

    protected void ddlHSelect(string id)
    {
        if (id.Length < 2)
        {
            id = "0" + id;
        }
        for (int i = 0; i < ddlH.Items.Count; i++)
        {
            if (ddlH.Items[i].Value == id)
            {
                ddlH.Items[i].Selected = true;
            }
        }
    }

    public string MM
    {
        set
        {
            ddlMSelect(value);
        }
        get
        {
            return ddlM.SelectedValue;
        }
    }

    protected void ddlMSelect(string id)
    {
        if (id.Length < 2)
        {
            id = "0" + id;
        }
        for (int i = 0; i < ddlM.Items.Count; i++)
        {
            if (ddlM.Items[i].Value == id)
            {
                ddlM.Items[i].Selected = true;
            }
        }
    }

    public void TimeShow()
    {
        ddlH.Visible = true;
        ddlM.Visible = true;
        txt.Visible = true;
        Bind();
    }

    public void DateHid()
    {
        cal.Visible = false;
        Bind();
    }

    protected void Bind()
    {
        for (int i = 0; i < 24; i++)
        {
            string str = "";
            if (i.ToString().Length < 2)
            {
                str = "0" + i.ToString();
            }
            else
            {
                str = i.ToString();
            }
            ListItem it = new ListItem();
            it.Text = str;
            it.Value = str;
            ddlH.Items.Add(it);
        }
        ddlM.Items.Add(new ListItem("00", "00"));
        ddlM.Items.Add(new ListItem("30", "30"));
    }

    public string LongValue
    {
        get
        {
            return cal.Value + " " + ddlH.SelectedValue + ":" + ddlM.SelectedValue;
        }
    }

    public string Label
    {
        set 
        {
            lbl.Visible = true;
            lbl.Text = value;

            cal.Visible = false;
            ddlH.Visible = false;
            ddlM.Visible = false;
            txt.Visible = false;
        }
    }

    public bool Enabled
    {
        set
        {
            if (value == true)
            {
                cal.Style.Add("readonly", "false");
            }
            else
            {
                cal.Style.Add("readonly", "true");
            }
        }
    }


    public HtmlInputText mycal
    {
        set
        {
            
        }
        get
        {
            return cal;
        }
    }
}
