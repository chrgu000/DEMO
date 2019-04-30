using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;


/// <summary>
/// OpenWindow 的摘要说明
/// </summary>
public class OpenWindow : System.Web.UI.Page
{
	public OpenWindow()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public virtual void Alert(Page p, string str)
    {
        p.ClientScript.RegisterClientScriptBlock(this.GetType(), "js", "alert('" + str + "');", true); 

    }

    public void Alert(Page p, string str, string locationurl)
    {
        p.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('" + str + "');window.location.href =' " + locationurl + " ';", true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <param name="str"></param>
    /// <param name="skey"></param>
    public void AlertClose(Page p, string str,string skey)
    {
        str = str + "ID=" + skey;
        p.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('" + str + "');window.close();", true);
    }

}
