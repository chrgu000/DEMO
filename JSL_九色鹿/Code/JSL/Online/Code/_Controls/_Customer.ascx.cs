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

public partial class YxCustomer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        img.Attributes.Add("onclick", "javascript:SelectVendor('" + txt.ClientID + "','" + hid.ClientID + "');");
        txt.Attributes.Add("onclick", "javascript:SelectVendor('" + txt.ClientID + "','" + hid.ClientID + "');");
    }

    public string Value
    {
        set
        {
            //hid.Value = value;
            //string sql = "select 厂商简称 from viewBaseVendor where 厂商编码='" + value + "'";
            //txt.Value = ConnUf.String(sql);
            //hid.Value = value; txt.Visible = true; img.Visible = true; lbl.Visible = false;
        }
        get { return hid.Value; }
    }


    /// <summary>
    /// 显示标签
    /// </summary>
    public string Text
    {
        set
        {
            txt.Value = value;
            txt.Visible = true; img.Visible = true; lbl.Visible = false;
        }
        get { return txt.Value; }
    }

    public string Label
    {
        set
        {
            //hid.Value = value;
            //string sql = "select 厂商简称 from Vendor where 厂商编码='" + value + "'";
            //lbl.Text = ConnUf.String(sql);
            //txt.Visible = false; img.Visible = false; lbl.Visible = true;
        }
        get { return lbl.Text; }
    }

    /// <summary>
    /// 文本框是否显示
    /// </summary>
    public bool ValueVisible
    {
        set { if (true == value) { txt.Visible = true; img.Visible = true; lbl.Visible = false; } }
    }


    public HtmlInputText mycus
    {
        set
        {

        }
        get
        {
            return txt;
        }
    }
}
