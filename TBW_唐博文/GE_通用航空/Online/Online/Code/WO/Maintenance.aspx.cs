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

public partial class WO_Maintenance : System.Web.UI.Page
{
    系统服务.ClsDES clsDES = 系统服务.ClsDES.Instance();
    ClsDataBase clsSQLCommond = new ClsDataBase();
    ASPxGridViewShow gridview = new ASPxGridViewShow();
    string sSQL;
    string tablename = "WO";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            YxBtn.HidFormID = "Maintenance";
            cal.ValueStart = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            cal.ValueEnd = DateTime.Now.ToString("yyyy-MM-dd");
            YxBtn.GetViewState(divSel);
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
        Response.Redirect("Update.aspx");
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
        if (gridview.ParameterIsNull(e.InputParameters["Date1"]))
        {
            throw new Exception(gridview.GetFieldName(ASPxGridView1, "Date1") + "不可为空");
        }
    }
    #endregion

    #region ObjectDataSource
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["sDate1"] = cal.ValueStart;
        e.InputParameters["eDate1"] = cal.ValueEnd;
        e.InputParameters["S9"] = DropDownListS9.SelectedValue;
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

    protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
    {
        if (e.GetValue("S1") != null)
        {
            string sd = "";
            if (e.GetValue("Date3") != null)
            {
                sd = e.GetValue("Date3").ToString();
            }
            string ed = "";
            if (e.GetValue("Date4") != null)
            {
                ed = e.GetValue("Date4").ToString();
            }
            if (sd == "")
            {
                e.Row.BackColor = System.Drawing.Color.Red;
            }
            else if (sd != "" && ed == "")
            {
                e.Row.BackColor = System.Drawing.Color.Yellow;
            }
            else if (ed != "")
            {
                e.Row.BackColor = System.Drawing.Color.Green;
            }
        }
    }
}

