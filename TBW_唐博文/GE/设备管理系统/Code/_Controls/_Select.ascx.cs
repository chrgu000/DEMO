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

public partial class FormatSelect : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        btn.Attributes.Add("onclick", "javascript:Select('" + txtHid.ClientID + "','" + txtText.ClientID + "','" + txtHidFlag.ClientID + "');");
    }

    public string Text
    {
        set
        {
            txtText.Text = value;
        }
        get
        {
            return txtText.Text;
        }
    }

    public string Value
    {
        set
        {
            txtHid.Value = value;
        }
        get
        {
            return txtHid.Value;
        }
    }

    public string Flag
    {
        set
        {
            txtHidFlag.Value = value;
        }
        get
        {
            return txtHidFlag.Value;
        }
    }
}
