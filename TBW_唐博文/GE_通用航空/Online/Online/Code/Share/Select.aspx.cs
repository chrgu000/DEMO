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
//using Ajax;

public partial class Share_Select : System.Web.UI.Page
{
    ClsDataBase clsSQLCommond = new ClsDataBase();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Ajax.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
        if (!Page.IsPostBack)
        {
            GroupBind();
            //sel1.Style.Add("height", "300px");
            //ListBox1.Attributes.Add("ondblclick", "javascript:sendback();");
            sel1.Attributes.Add("ondblclick", "javascript:sendback();");
        }
       
    }

    public void GroupBind()
    {
        string sql = "select * from Inventory";
        DataTable dt = clsSQLCommond.ExecQuery(sql);
        //ListBox1.DataTextField = "S2";
        //ListBox1.DataValueField = "S1";
        //ListBox1.DataBind();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sel1.Items.Add(new ListItem(dt.Rows[i]["S2"].ToString(), dt.Rows[i]["S1"].ToString()));
        }
    }


}
