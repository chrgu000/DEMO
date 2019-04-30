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

public partial class YxPage : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void GetAdd(string id, string addtime, string addemp, string updatetime, string updateemp)
    {
        TableAdd.Visible = true;
        lblNum.Text = id;
        lblAddTime.Text = addtime;
        lblAddEmp.Text = addemp;
        lblUpdateTime.Text = updatetime;
        lblUpdateEmp.Text = updateemp;
    }

    public void GetCheck(string time, string emp,string flag)
    {
        TableCheck.Visible = true;
        lblCheckTime.Text = time;
        lblCheckEmp.Text = emp;
        lblFlag.Text = flag;
    }


}
