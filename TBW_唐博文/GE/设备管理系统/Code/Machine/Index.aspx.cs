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

public partial class Machine_Index : System.Web.UI.Page
{
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "Machine";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "Machine";
            YxBtn.GetViewState(divSel);
            GetTitle();
            
        }
    }

    #region 标题
    private void GetTitle()
    {
        MachineData ed = new MachineData();
        string iID = "";
        string S1 = "";
        string S2 = "";
        string S3 = "";
        string S4 = "";
        string S5 = "";
        string S6 = "";
        string S7 = "";
        string S8 = "";
        string S9 = "";
        string S10 = "";
        string S11 = "";
        string S12 = "";
        string S13 = "";
        string S14 = "";
        string S15 = "";
        DateTime sDate1 = DateTime.MinValue;
        DateTime eDate1 = DateTime.MinValue;
        DateTime sDate2 = DateTime.MinValue;
        DateTime eDate2 = DateTime.MinValue;
        DateTime sDate3 = DateTime.MinValue;
        DateTime eDate3 = DateTime.MinValue;
        DateTime sDate4 = DateTime.MinValue;
        DateTime eDate4 = DateTime.MinValue;
        DateTime sDate5 = DateTime.MinValue;
        DateTime eDate5 = DateTime.MinValue;
        DataTable dt = ed.Get(iID, S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13, S14, S15, sDate1, eDate1, sDate2, eDate2, sDate3, eDate3, sDate4, eDate4, sDate5, eDate5);

        gridview.GetList(thead1, tbody1, tablename, dt);
    }
    #endregion

    #region 按钮
    protected void ToSelect(object sender, EventArgs e)
    {
        YxBtn.SetViewState(divSel);
        GetTitle();
    }

    protected void ToSave(object sender, EventArgs e)
    {

    }

    protected void ToNew(object sender, EventArgs e)
    {
        Response.Redirect("Update.aspx");
    }

    protected void ToDel(object sender, EventArgs e)
    {

    }

    protected void ToExport(object sender, EventArgs e)
    {
        //ASPxGridViewExporter1.WriteXlsToResponse(this.Title);
    }

    protected void ToBeck(object sender, EventArgs e)
    {

    }
    #endregion
}

