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

public partial class FormatCalendar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        datetimepicker.Attributes.Add("onmouseover", "javascript:SelectDate(" + datetimepicker.ClientID + ")");
        datetimepicker.Attributes.Add("onfocus", "javascript:SelectDate(" + datetimepicker.ClientID + ")");
        //Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "myscript", "<script>$(document).ready(function() {$('#" + datetimepicker.ClientID + "').datetimepicker({language: 'zh-CN',format: 'yyyy-mm-dd',minView: '2',todayBtn: true,autoclose: true,todayHighlight: true,startDate: '2000-1-1',forceParse: false });});</script>");
        //datetimepicker.Focus();
        //TextBox1.Focus(); 
        //Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "myscript", "<script>SelectDate('" + datetimepicker.ClientID + "');</script>");
        
        if (!this.IsPostBack)
        {
            
            
        }
    }


    public string Value
    {
        set { datetimepicker.Text = value; }
        get { return datetimepicker.Text; }
    }

    public bool Enabled
    {
        set
        {
            datetimepicker.Enabled = value;
        }
    }


}
