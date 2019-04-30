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

public partial class PublicFacilities_Index : System.Web.UI.Page
{
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "PublicFacilities";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "PublicFacilities";
            //cal.ValueStart = DateTime.Now.AddMonths(-10).ToString("yyyy-MM-dd");
            //cal.ValueEnd = DateTime.Now.ToString("yyyy-MM-dd");
            YxBtn.GetViewState(divSel);
            YxBtn.boolNew = false;
            GetTitle();
        }
    }

    #region 标题
    private void GetTitle()
    {
        ASPxGridViewShow gridview = new ASPxGridViewShow();
        gridview.GetTitle(ASPxGridView1, tablename);
    }
    #endregion

    #region 按钮
    protected void ToSelect(object sender, EventArgs e)
    {
        YxBtn.SetViewState(divSel);
        ASPxGridView1.DataBind();
    }

    protected void ToSave(object sender, EventArgs e)
    {

    }

    protected void ToNew(object sender, EventArgs e)
    {

    }

    protected void ToDel(object sender, EventArgs e)
    {

    }

    protected void ToExport(object sender, EventArgs e)
    {
        ASPxGridViewExporter1.WriteXlsToResponse(this.Title);
    }

    protected void ToBeck(object sender, EventArgs e)
    {

    }
    #endregion

    #region Check
    private void GetCheck(System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs e, int b)
    {
        if (gridview.ParameterIsNull(e.InputParameters["S1"]))
        {
            throw new Exception(gridview.GetFieldName(ASPxGridView1, "S1") + "不可为空");
        }
    }
    #endregion

    #region ObjectDataSource
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        //e.InputParameters["S2"] = DropDownListS1.SelectedValue;
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('11');", true);
    }

    protected void ObjectDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetCheck(e, 0); 
    }
    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        GetCheck(e, 1);
    }
    protected void ObjectDataSource1_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {

    }
    protected void ObjectDataSource1_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //WriteResultMsg("刪除", e);
    }
    #endregion

    internal class NorthwindDataException: Exception { public NorthwindDataException(string msg) : base (msg) { } }

    private void WriteResultMsg(string Action, ObjectDataSourceStatusEventArgs e)
    {
        int iResult = Convert.ToInt32(e.ReturnValue);
        if (iResult <= 0 || e.Exception != null)
        {
            Label1.Text = string.IsNullOrEmpty(Action) ? "" : Action + "失敗！";

            //// Handle the Exception if it is a NorthwindDataException
            //if (e.Exception != null)
            //{
            //    Exception ex = e.Exception;

            //    Response.Write("The following exception occurred: " + ex.ToString());
            //    //檢查更細節的例外處理- InnerException
            //    while (ex.InnerException != null)
            //    {
            //        Response.Write("<br>--------------------------------<br>");
            //        Response.Write("The following InnerException reported: " + ex.InnerException.ToString() + "<br>");
            //        ex = ex.InnerException;
            //    }

            //    // Handle the specific exception type. The ObjectDataSource wraps
            //    // any Exceptions in a TargetInvokationException wrapper, so
            //    Label1.Text = e.Exception.InnerException.Message;
            //    // Because the exception is handled, there is
            //    // no reason to throw it.
            //    e.ExceptionHandled = true;
            //}
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "js", "alert('11');", true);
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString().Trim() == "1")
        {
            sSQL = "Select S1 as iID,S2 as iText FROM   EquipType Where S3='1' orDER BY S2  ";
        }
        else if (DropDownList1.SelectedValue.ToString().Trim() == "2")
        {
            sSQL = "Select S1 as iID,S2 as iText FROM   EquipType Where S3='2' orDER BY S2  ";
        }
        DataTable dt = clsSQLCommond.ExecQuery(sSQL);
        DropDownList2.DataValueField = "iID";
        DropDownList2.DataTextField = "iText";
        DropDownList2.DataSource = dt;
        DropDownList2.DataBind();
        //DropDownList2.Items[0].Selected = true;
    }
}

